using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnnFunctions.Powerpoint;
using Xunit.Abstractions;

namespace DevelopmentTests
{
	public class pptxTests
	{
        public pptxTests(ITestOutputHelper outputWriter)
		{
			output = outputWriter;
			logger = GetXunitLogger(outputWriter);
		}

		private readonly ITestOutputHelper output;
		ILogger logger;

		internal static ILogger GetXunitLogger(ITestOutputHelper helper)
		{
			var services = new ServiceCollection()
						.AddLogging((builder) => builder.AddXUnit(helper).SetMinimumLevel(LogLevel.Debug));
			IServiceProvider provider = services.BuildServiceProvider();
			var logg = provider.GetRequiredService<ILogger<pptxTests>>();
			Assert.NotNull(logg);
			return logg;
		}

		[Fact]
		public void CanReplaceMedia()
		{
			return;
			var dire = new DirectoryInfo(@"C:\Users\Claudio\OneDrive - Northumbria University - Production Azure AD\2024\KA7065 - Feasibility and Economics\Materials");
			foreach (var f in dire.GetFiles("*.pptx", SearchOption.AllDirectories))
			{
				var m = new MediaWork(f.FullName);
				m.ReplaceMedia(
					new FileInfo(@"C:\Users\Claudio\OneDrive - Northumbria University - Production Azure AD\2024\KA4033 - Built asset management\rep\image2.jpeg"),
					new FileInfo(@"C:\Users\Claudio\OneDrive - Northumbria University - Production Azure AD\2024\KA4033 - Built asset management\rep\image2.rep.jpeg"),
					logger
					);
			}
		}

		[Fact]
		public void CanRemoveFonts()
		{
			return;
			string[] unwanted = ["g_d0_f4", "Geneva", "g_d0_f5", "g_d0_f1", "Google Sans", "azo-sans-web", "g_d0_f3", "Bliss Light"];

			var dire = new DirectoryInfo(@"C:\Users\Claudio\OneDrive - Northumbria University - Production Azure AD\2024\KA7065 - Feasibility and Economics\Materials");
			foreach (var f in dire.GetFiles("*.pptx", SearchOption.AllDirectories))
			{
				var replacements = Enumerable.Empty<FontWork.ReplaceXml>();
				var thisFile = FontWork.FromFile(f.FullName);
				foreach (var item in thisFile.GetFonts(@"ppt/slides").GroupBy(x => x.FontName))
				{
					if (!unwanted.Contains(item.Key))
						continue;
					var fls = item.Select(x => x.EntryFullName).Distinct().ToList();
					var files = string.Join(", ", fls);
					logger.LogInformation("{typeface}, {count}: {files}", item.Key, fls.Count, files);

					var xmls = item.Select(x => x.Element.ToString()).Distinct().ToList();
					var elems = string.Join(", ", xmls);
					logger.LogInformation("{typeface}, {count}: {files}", item.Key, xmls.Count, elems);
				}
				replacements = thisFile.RemoveFonts(unwanted, @"ppt/slides", logger);
				thisFile.Replace(replacements, logger);
			}
		}
	}
}
