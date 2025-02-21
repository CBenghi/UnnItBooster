using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace StudentsFetcher
{
	[AmmFormAttributes("Play with text", 5)]
	public partial class frmTextGames : Form
	{
		public frmTextGames()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var frmt = new[] { TextDataFormat.Html }; // , TextDataFormat.Text, TextDataFormat.UnicodeText, TextDataFormat.Rtf };
			foreach (var item in frmt)
			{

				var txt = Clipboard.ContainsText(item);
				if (txt)
				{
					var v = Clipboard.GetText(item);
					Debug.WriteLine($"{item}: -- \r\n{v}\r\n -- \r\n");

					v = v.Replace("improvement", "some else");


				}
			}

			var val = """
						Version:0.9
						StartHTML:0000000192
						EndHTML:0000005886
						StartFragment:0000000228
						EndFragment:0000005850
						SourceURL:https://ev.turnitinuk.com/app/carta/en_us/?u=1519823&o=207253836&lang=en_us
						<html>
						<body>
						<!--StartFragment--><p style="box-sizing: border-box; margin: 0px; padding: 0px; color: rgb(40, 48, 65); font-family: roboto, &quot;Helvetica Neue&quot;, helvetica, arial, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 300; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; white-space: normal; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;"><span style="box-sizing: border-box; font-weight: bold;">Areas of good practice</span></p><p style="box-sizing: border-box; margin: 0px; padding: 0px; color: rgb(40, 48, 65); font-family: roboto, &quot;Helvetica Neue&quot;, helvetica, arial, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 300; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; white-space: normal; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;">- <br style="box-sizing: border-box;"></p><p style="box-sizing: border-box; margin: 0px; padding: 0px; color: rgb(40, 48, 65); font-family: roboto, &quot;Helvetica Neue&quot;, helvetica, arial, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 300; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; white-space: normal; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;">-</p><p style="box-sizing: border-box; margin: 0px; padding: 0px; color: rgb(40, 48, 65); font-family: roboto, &quot;Helvetica Neue&quot;, helvetica, arial, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 300; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; white-space: normal; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;">-</p><p style="box-sizing: border-box; margin: 0px; padding: 0px; color: rgb(40, 48, 65); font-family: roboto, &quot;Helvetica Neue&quot;, helvetica, arial, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 300; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; white-space: normal; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;"><span style="box-sizing: border-box; font-weight: bold;"><br style="box-sizing: border-box;"></span></p><p style="box-sizing: border-box; margin: 0px; padding: 0px; color: rgb(40, 48, 65); font-family: roboto, &quot;Helvetica Neue&quot;, helvetica, arial, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 300; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; white-space: normal; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;"><span style="box-sizing: border-box; font-weight: bold;">Areas of improvement</span></p><p style="box-sizing: border-box; margin: 0px; padding: 0px; color: rgb(40, 48, 65); font-family: roboto, &quot;Helvetica Neue&quot;, helvetica, arial, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 300; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; white-space: normal; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;"><span style="box-sizing: border-box; font-weight: bold;"><br style="box-sizing: border-box;"></span></p><p style="box-sizing: border-box; margin: 0px; padding: 0px; color: rgb(40, 48, 65); font-family: roboto, &quot;Helvetica Neue&quot;, helvetica, arial, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 300; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; white-space: normal; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;"><span style="box-sizing: border-box; font-weight: bold;"><p style="box-sizing: border-box; margin: 0px; padding: 0px; font-weight: 300; font-style: normal;">- </p><p style="box-sizing: border-box; margin: 0px; padding: 0px; font-weight: 300; font-style: normal;">-</p><p style="box-sizing: border-box; margin: 0px; padding: 0px; font-weight: 300; font-style: normal;">-</p></span></p><br class="Apple-interchange-newline"><!--EndFragment-->
						</body>
						</html>
						""";

			val = """
						Version:0.9
						StartHTML:0000000192
						EndHTML:0000005886
						StartFragment:0000000228
						EndFragment:0000005850
						SourceURL:https://ev.turnitinuk.com/app/carta/en_us/?u=1519823&o=207253836&lang=en_us
						<html>
							<body>
								<!--StartFragment-->
								<p style="box-sizing: border-box; margin: 0px; padding: 0px; color: rgb(40, 48, 65); font-family: roboto, &quot;Helvetica Neue&quot;, helvetica, arial, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 300; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; white-space: normal; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;">
									<span style="box-sizing: border-box; font-weight: bold;">Areas of good practice</span>
								</p>
								<p style="box-sizing: border-box; margin: 0px; padding: 0px; font-weight: 300; font-style: normal;">-</p>
								<p style="box-sizing: border-box; margin: 0px; padding: 0px; font-weight: 300; font-style: normal;">-</p>
								<p style="box-sizing: border-box; margin: 0px; padding: 0px; font-weight: 300; font-style: normal;">-</p>
								<p style="box-sizing: border-box; margin: 0px; padding: 0px; color: rgb(40, 48, 65); font-family: roboto, &quot;Helvetica Neue&quot;, helvetica, arial, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 300; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; white-space: normal; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;">
									<span style="box-sizing: border-box; font-weight: bold;">Areas of improvement</span>
								</p>
								<p style="box-sizing: border-box; margin: 0px; padding: 0px; font-weight: 300; font-style: normal;">-</p>
								<p style="box-sizing: border-box; margin: 0px; padding: 0px; font-weight: 300; font-style: normal;">-</p>
								<p style="box-sizing: border-box; margin: 0px; padding: 0px; font-weight: 300; font-style: normal;">-</p>
								<!--EndFragment-->
							</body>
						</html>
						""";

			Clipboard.SetText(val, TextDataFormat.Html);

			txtBoxTo.Text = System.Web.HttpUtility.HtmlDecode(txtBoxFrom.Text);
		}



		private void button2_Click(object sender, EventArgs e)
		{
			txtBoxFrom.Text = txtBoxTo.Text;
			txtBoxTo.Text = "";
		}

		private void button3_Click(object sender, EventArgs e)
		{
			txtBoxTo.Text = System.Web.HttpUtility.UrlDecode(txtBoxFrom.Text);
		}

		private void button5_Click(object sender, EventArgs e)
		{
			txtBoxTo.Text = System.Web.HttpUtility.HtmlEncode(txtBoxFrom.Text);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			txtBoxTo.Text = System.Web.HttpUtility.UrlEncode(txtBoxFrom.Text);
		}

		private void button6_Click(object sender, EventArgs e)
		{
			txtBoxTo.Text = txtBoxFrom.Text.Replace(textBox3.Text, "\r\n\r\n");
		}
	}
}
