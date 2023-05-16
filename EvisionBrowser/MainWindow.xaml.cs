using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace EvisionBrowser
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			wbSample.EnsureCoreWebView2Async();
			DataContext = this;
		}

		private void PerformBack(object sender, RoutedEventArgs e)
		{
			wbSample.GoBack();
		}

		private void PerformForward(object sender, RoutedEventArgs e)
		{
			wbSample.GoForward();
		}

		private void PerformGo(object sender, RoutedEventArgs e)
		{
			string url = Url.Text;		
			if (!Url.Text.StartsWith("http://"))
				url = $"http://{url}";
			wbSample.Source = new Uri(url);
			
		}
		private void PerformHome(object sender, RoutedEventArgs e)
		{
			wbSample.Source = new Uri("https://sits.northumbria.ac.uk/live/sits.urd/run/siw_sso.saml");
		}

		string html = string.Empty;

		private void NavigationDone(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
		{
			var viewer = sender as Microsoft.Web.WebView2.Wpf.WebView2;
			if (viewer == null)
				return;
			Url.Text = viewer.Source.ToString();
		}

		Queue<string> PagesToView = new Queue<string>();

		[RelayCommand]
		private async Task<bool> ProcessStudents()
		{
			var students = await GetSource();
			return true;
		}
		
		private async Task<string> GetSource()
		{
			string v = await wbSample.ExecuteScriptAsync("document.documentElement.outerHTML;");
			var t = JsonDocument.Parse(v);
			var elem = t.RootElement;
			var str = elem.GetString();
			if (str is null)
				return string.Empty;
			return str;
		}
	}
}
