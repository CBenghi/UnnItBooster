using CommunityToolkit.Mvvm.Input;
using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using UnnItBooster.Models;

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
			InitializeAsync();
			DataContext = this;
			dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
			dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
			dispatcherTimer.Interval = new TimeSpan(0,0,3);
			dispatcherTimer.Start();
		}

		async void InitializeAsync()
		{
			await wbSample.EnsureCoreWebView2Async(null);
			wbSample.CoreWebView2.WebResourceResponseReceived += wbSample_WebResourceResponseReceived;
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
			if (!Url.Text.StartsWith("http"))
				url = $"http://{url}";
			var uri = new Uri(url);
			if (uri.ToString() != wbSample.Source.ToString())
				wbSample.Source = uri;
			else
				wbSample.Reload();
		}
		private void PerformHome(object sender, RoutedEventArgs e)
		{
			if (Url.Text == "https://sits.northumbria.ac.uk/live/sits.urd/run/siw_sso.saml")
				Url.Text = "http://one.northumbria.ac.uk/";
			else
				Url.Text = "https://sits.northumbria.ac.uk/live/sits.urd/run/siw_sso.saml";
			wbSample.Source = new Uri(Url.Text);
		}
	}
}
