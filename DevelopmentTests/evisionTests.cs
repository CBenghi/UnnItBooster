using FluentAssertions;
using System.Text.RegularExpressions;
using UnnFunctions.ModelConversions;
using UnnItBooster.ModelConversions;

namespace DevelopmentTests
{
	public class evisionTests
	{
		[Fact]
		public void TestGetTextEntries()
		{
			var src = File.ReadAllText("Files/SitsMarkEntry.html");
			var entries = eVisionMarkEntry.GetEntries(src).ToList();
			entries.Should().HaveCount(66);
			var t = entries.FirstOrDefault();
			t.Should().NotBeNull();
			t!.StudentId.Should().Be("21013004");
			t.MarkTextId.Should().Be("msa_mrk_widget_MRK.1-1-1");
			t.GradeTextId.Should().Be("msa_mrk_widget_GRD.1-1-1");
		}


		[Theory]
		[InlineData("Files/transcript.html")]
		[InlineData("Files/transcriptMultiple.html")]
		public void TestTranscript(string fileName)
		{
			var src = File.ReadAllText(fileName);
			var stud = eVision.GetStudentTranscript(src,
				new UnnFunctions.Models.QueueAction(null, UnnFunctions.Models.QueueAction.ActionRequiredData.studentTranscript,
				 UnnFunctions.Models.QueueAction.ActionSource.studentTranscript, "Some"));
			string s = stud.NumericStudentId;
		}

		[Fact]
		public void TestRegex()
		{
			// not really a test, used for development.

			string html =
				"""
				<div class="sv-row sv-hidden-xs sv-hidden-sm sv-hidden-md">
					<div class="sv-col-md-6">
						<div class="sv-form-container">
							<div class="sv-form-horizontal sv-static-form">

								<div class="sv-form-group">
									<p class="sv-col-sm-3 sv-static-text">
										Name
									</p>
									<div class="sv-col-sm-9">
										<p class="sv-form-control-static">
											Giannis Vagenas
										</p>
									</div>
								</div>
								<div class="sv-form-group">
									<p class="sv-col-sm-3 sv-static-text">
										Gender Some
									</p>
									<div class="sv-col-sm-9">
										<p class="sv-form-control-static">
											Male
										</p>
									</div>
								</div>
				""";

			var t = eVision.GetRegex("Name");
			var m = t.Match(html);
			m.Success.Should().BeTrue();
			var nm = m.Groups["Match"].Value;
			nm.Should().Be("Giannis Vagenas");

			t = eVision.GetRegex("Gender Some");
			m = t.Match(html);
			m.Success.Should().BeTrue();
			nm = m.Groups["Match"].Value;
			nm.Should().Be("Male");

		}
	}
}