using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnnFunctions.Models.SubmissionContent;
using Xunit.Abstractions;

namespace DevelopmentTests
{
	public class ReferencingTests
	{

		public ReferencingTests(ITestOutputHelper output)
		{
			this.output = output;
		}

		private readonly ITestOutputHelper output;

		[Fact]
		public void CanGetReferences()
		{
			var pars = File.ReadAllLines(@"Files\textExample.txt");
			pars.Should().NotBeNullOrEmpty();
			List<string> refs = new List<string>();
			var l = 0;
			foreach (var paragraph in pars)
			{
				l += paragraph.Length;
				refs.AddRange(SubmissionFile.GetInlineReferencesFromParagraph(paragraph));
			}
			refs.Should().NotBeNullOrEmpty();
			refs.Sort();
			foreach (var item in refs)
			{
				output.WriteLine(item);
			}
			output.WriteLine($"Len: {l}");
			refs.Count.Should().Be(115);
		}
	}
}
