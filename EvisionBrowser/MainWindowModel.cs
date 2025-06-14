﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Threading;
using UnnFunctions.ModelConversions;
using UnnFunctions.Models;
using UnnItBooster.ModelConversions;
using UnnItBooster.Models;
using static UnnFunctions.Models.QueueAction;
using WebViewCore = Microsoft.Web.WebView2.Core;
using WebViewWpf = Microsoft.Web.WebView2.Wpf;

namespace EvisionBrowser;

[ObservableObject]
public partial class MainWindow
{
	private StudentsRepository studentsRepo => UnnToolsConfiguration.Settings.StudentsRepository;

	DispatcherTimer dispatcherTimer;

	Stopwatch? stopwatch;
	List<long> elapsedTimes = new List<long>();

	/// <summary>
	/// Actions are started here, and their results analysed in <see cref="NavigationDone(object, WebViewCore.CoreWebView2NavigationCompletedEventArgs)"/>
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void dispatcherTimer_Tick(object? sender, EventArgs e)
	{
		if (!QueueActive)
			return;

		{

		}
		if (currentAction is null && queuedActions.Any())
		{
			currentAction = queuedActions.Dequeue(); // action is started here, but then set to null when page is loaded
			OnPropertyChanged(nameof(QueueDisplayText));
			stopwatch = Stopwatch.StartNew();
			wbSample.Source = currentAction.Page;
		}
		else if (!queuedActions.Any())
		{
			QueueActive = false;
		}
	}


	private void PerformStatUpdate()
	{
		if (elapsedTimes.Any())
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"Page fetch performance:");
			sb.AppendLine($"min: {elapsedTimes.Min()}ms.");
			sb.AppendLine($"max: {elapsedTimes.Max()}ms.");
			sb.AppendLine($"avg: {elapsedTimes.Average():0}ms.");
			Report = sb.ToString();
		}
	}

	private async void NavigationDone(object sender, WebViewCore.CoreWebView2NavigationCompletedEventArgs e)
	{
		var viewer = sender as WebViewWpf.WebView2;
		if (viewer == null)
			return;
		Url.Text = viewer.Source.ToString();

		stopwatch?.Stop();
		if (stopwatch != null)
			elapsedTimes.Add(stopwatch.ElapsedMilliseconds);
		PerformStatUpdate();

		if (currentAction != null)
		{
			await ProcessAvailableDataAsync(currentAction); // from navigation done
		}
	}

	[RelayCommand]
	private async void Test()
	{
		var src = await GetPageSource();

		var script = "document.getElementById('sc5054').click();";
		Report = await GetScriptString(script);
	}

	[RelayCommand]
	private async void CopyHtml()
	{
		var src = await GetPageSource();
		if (string.IsNullOrEmpty(src))
			return;
		TextCopy.Clipboard clipboard = new();
		await clipboard.SetTextAsync(src);
	}

	Regex r = new Regex("https://nuweb2.northumbria.ac.uk/photoids/(\\d+).jpg");

	private async void wbSample_WebResourceResponseReceived(object? sender, WebViewCore.CoreWebView2WebResourceResponseReceivedEventArgs e)
	{
		var uri = new Uri(e.Request.Uri);
		Debug.WriteLine(uri.ToString());
		if (currentAction is null)
			return;
		if (currentAction.DataRequired.HasFlag(ActionRequiredData.photos))
		{
			r = new Regex("https://nuweb2.northumbria.ac.uk/photoids/(\\d+).jpg");
			var m = r.Match(e.Request.Uri);
			if (m.Success)
			{
				Debug.WriteLine($"WebImageReceived: {e.Request.Uri}");
				var number = m.Groups[1].Value;
				var tName = studentsRepo.GetDefaultImageName(number, ModuleCode);
				if (File.Exists(tName))
					return;
				// this would overwrite if it's there already
				using (var stream = await e.Response.GetContentAsync())
				using (var fileStream = new FileStream(tName, FileMode.Create, FileAccess.Write))
				{
					stream.CopyTo(fileStream);
				};
			}
		}
	}

	QueueAction? currentAction = null;

	Queue<QueueAction> queuedActions = new Queue<QueueAction>();

	[ObservableProperty]
	private string report = string.Empty;

	[ObservableProperty]
	[NotifyPropertyChangedFor(nameof(SideVisibilityLabel))]
	private bool sideBarVisibility = true;

	[ObservableProperty]
	private bool updateOnly = false;

	[ObservableProperty]
	private string moduleCode = string.Empty;

	[RelayCommand()]
	private async Task<bool> ProcessStudents()
	{
		var studentsSource = await GetPageSource();
		var students = eVision.GetStudentsFromEvisionHtml(studentsSource).ToList();

		if (UpdateOnly) // remove students that are not yet in the collection
		{
			if (string.IsNullOrEmpty(ModuleCode))
			{
				Report = "Specify module code to update.";
				return false;
			}
			var coll = studentsRepo.GetPersonCollections().FirstOrDefault(x => x.Name == ModuleCode);
			if (coll is null)
			{
				Report = "module code not found.";
				return false;
			}
			var existingIds = new HashSet<string>(coll.Students.Select(x => x.NumericStudentId));
			students.RemoveAll(x => !existingIds.Contains(x.NumericStudentId));
		}

		if (!string.IsNullOrEmpty(ModuleCode))
		{
			Report = studentsRepo.ConsiderNewStudents(students, ModuleCode);
			// initialize the queue
			var r = GetRequiredDataSettings();
			if (r != ActionRequiredData.none)
			{
				var InterestingIds = new HashSet<string>(students.Select(x => x.NumericStudentId));
				_ = ProcessAvailableDataAsync(new QueueAction(wbSample.Source, r, ActionSource.studentsList, ModuleCode), InterestingIds); // from init
			}
		}
		else
		{
			Report = $"Got {students.Count()} entries. No course code set for saving.";
			var st = students.FirstOrDefault();
			if (st != null && st.Module != null)
			{
				ModuleCode = st.Module;
				Report += "\r\nModule set to :" + ModuleCode;
			}
			return false;
		}
		return true;
	}

	private async Task<bool> ProcessAvailableDataAsync(QueueAction context, HashSet<string>? interestingIds = null)
	{
		var ret = false;
		var src = await GetPageSource();
		switch (context.DataSource)
		{
			// these funcions may enrich the queue and archive any data found
			case ActionSource.studentsList:
				ProcessStudentList(src, context, interestingIds);
				ret = true;
				break;
			case ActionSource.studentsListWithPictures:
				ret = true;
				break;
			case ActionSource.studentDetails:
				ProcessStudentDetails(src, context);
				ret = true;
				break;
			case ActionSource.studentTranscript:
				ProcessStudentTranscript(src, context);
				ret = true;
				break;
			default:
				break;
		}
		currentAction = null;
		return ret;
	}

	private void ProcessStudentTranscript(string src, QueueAction context)
	{
		var student = eVision.GetStudentTranscript(src, context);
		if (student is not null)
			studentsRepo.UpdateStudentInfo(student, context.DestinationCollection);
	}

	private void ProcessStudentDetails(string src, QueueAction context)
	{
		var student = eVision.GetStudentFromIndividualSource(src, context);
		if (student is not null)
			studentsRepo.UpdateStudentInfo(student, context.DestinationCollection);
		if (context.DataRequired.HasFlag(ActionRequiredData.studentTranscript))
		{
			var actions = eVision.GetTranscriptPageFromIndividualSource(src, context);
			QueueActions(actions);
		}
	}
	private void ProcessStudentList(string studentListPage, QueueAction context, HashSet<string>? interestingIds)
	{
		if (
			context.DataRequired.HasFlag(ActionRequiredData.studentEmail) ||
			context.DataRequired.HasFlag(ActionRequiredData.studentPersonalEmail) ||
			context.DataRequired.HasFlag(ActionRequiredData.studentPhone) ||
			context.DataRequired.HasFlag(ActionRequiredData.studentTranscript)
			)
		{
			var actions = eVision.GetStudentIndividualSource(studentListPage, context).ToList();
			if (interestingIds != null)
				actions.RemoveAll(x => x.StudentId == null || !interestingIds.Contains(x.StudentId));
			QueueActions(actions);
		}
		else if (context.DataRequired.HasFlag(ActionRequiredData.photos)) // photos can also be downloaded from individual page, so if we go above we don't go below
		{
			var actions = eVision.GetStudentPicurePage(studentListPage, context).ToList();
			QueueActions(actions);
		}
	}

	private void QueueActions(IEnumerable<QueueAction> actions)
	{
		foreach (var action in actions)
		{
			if (queuedActions.Contains(action))
				continue;
			queuedActions.Enqueue(action);
		}
		OnPropertyChanged(nameof(QueueDisplayText));
	}

	[ObservableProperty]
	[NotifyPropertyChangedFor(nameof(QueueStatus))]
	[NotifyPropertyChangedFor(nameof(QueueDisplayText))]
	private bool queueActive = false;

	private string QueueStatus => QueueActive ? "Processing" : "Paused";

	public string QueueDisplayText
	{
		get
		{
			StringBuilder sb = new();
			sb.AppendLine($"{QueueStatus}");
			foreach (var item in queuedActions.GroupBy(x => x.DataSource))
			{
				sb.AppendLine($"{item.Key} {item.Count()}");
			}
			return sb.ToString();
		}
	}



	private async Task<string> GetPageSource()
	{
		var script = "document.documentElement.outerHTML;";
		return await GetScriptString(script);
	}

	private async Task<string> GetScriptString(string script)
	{
		string v = await wbSample.ExecuteScriptAsync(script);
		var t = JsonDocument.Parse(v);
		var elem = t.RootElement;
		var str = elem.GetString();
		if (str is null)
			return string.Empty;
		return str;
	}

	public string SideVisibilityLabel => SideBarVisibility ? ">>" : "<<";

	[RelayCommand]
	private void ToggleSidebar() => SideBarVisibility = !SideBarVisibility;

	[RelayCommand]
	private void ToggleQueueProcessing() => QueueActive = !QueueActive;

	[RelayCommand]
	private void ClearQueue()
	{
		queuedActions.Clear();
		OnPropertyChanged(nameof(QueueDisplayText));
	}

	[ObservableProperty] private bool scrapeEmail = true;
	[ObservableProperty] private bool scrapePersonalEmail = true;
	[ObservableProperty] private bool scrapePictures = true;
	[ObservableProperty] private bool scrapeTelephone = true;
	[ObservableProperty] private bool scrapeTranscript = true;

	private ActionRequiredData GetRequiredDataSettings()
	{
		ActionRequiredData ret = ActionRequiredData.none;
		if (ScrapeEmail) ret = ActionRequiredData.studentEmail | ret;
		if (ScrapePersonalEmail) ret = ActionRequiredData.studentPersonalEmail | ret;
		if (ScrapePictures) ret = ActionRequiredData.photos | ret;
		if (ScrapeTelephone) ret = ActionRequiredData.studentPhone | ret;
		if (ScrapeTranscript) ret = ActionRequiredData.studentTranscript | ret;
		return ret;
	}

	[ObservableProperty]
	private string mcrfMarks = string.Empty;

	/// <summary>
	/// Tab separated user id and mark
	/// </summary>
	/// <returns></returns>
	[RelayCommand]
	private async Task<bool> SetMcrf()
	{
		var studentMarks = eVisionMarkEntry.FromTabSeparated(McrfMarks);
		var source = await GetPageSource();
		var entries = eVisionMarkEntry.GetEntries(source).ToList();
		if (entries is null)
		{
			Report = "No entries found";
			return false;
		}
		var sb = new StringBuilder();
		sb.AppendLine($"{entries.Count()} student fields");
		foreach (var f in entries)
		{
			if (!studentMarks.TryGetValue(f.StudentId, out var mark))
			{
				sb.AppendLine($"Student {f.StudentId} not found.");
				continue;
			}
			var current = await wbSample.ExecuteScriptAsync($"document.getElementById(\"{f.MarkTextId}\").value;");
			if (current == mark)
			{
				sb.AppendLine($"Student {f.StudentId} was already {mark}.");
				continue;
			}
			var script = $"document.getElementById(\"{f.MarkTextId}\").value='{mark}';";
			string v = await wbSample.ExecuteScriptAsync(script);
			sb.AppendLine($"Student {f.StudentId} set to {mark}.");
			script = $"document.getElementById(\"{f.GradeTextId}\").value='a';";
			v = await wbSample.ExecuteScriptAsync(script);
		}
		Report = sb.ToString();
		return true;
	}
}
