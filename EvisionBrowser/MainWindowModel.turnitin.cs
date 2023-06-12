using CommunityToolkit.Mvvm.ComponentModel;
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
using System.Windows.Controls;
using System.Windows.Threading;
using UnnFunctions.ModelConversions;
using UnnFunctions.Models;
using UnnItBooster.ModelConversions;
using UnnItBooster.Models;
using static UnnFunctions.Models.QueueAction;
using WebViewCore = Microsoft.Web.WebView2.Core;
using WebViewWpf = Microsoft.Web.WebView2.Wpf;

namespace EvisionBrowser
{
	public partial class MainWindow
	{
		[ObservableProperty]
		private string turnitinPaperIds = string.Empty;


		[RelayCommand()]
		private async Task<bool> ProcessSubmissions()
		{
			
			return true;
		}
	}
}
