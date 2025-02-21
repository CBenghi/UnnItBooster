using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Text.RegularExpressions;
using LateBindingTest;
using System.Threading;
using StudentsFetcher;
using System.Net;
using UnnItBooster.Models;
using StudentsFetcher.StudentMarking;
using System.Linq;
using System.Globalization;
using System.Text.Json;
using UnnItBooster;
using System.Windows.Media.Media3D;
using UnnFunctions.Models;

namespace StudentMarking
{
	[AmmFormAttributes("Mass mailing", 3)]
	public partial class frmMassMail : Form
	{
        private StudentsRepository studentsRepo;

        public frmMassMail()
		{
			InitializeComponent();
			txtEmailBody.Text = StudentsFetcher.Properties.Settings.Default.emailBody;
			cmbEmailSubject.Text = StudentsFetcher.Properties.Settings.Default.emailSubject;
			txtEmailCC.Text = StudentsFetcher.Properties.Settings.Default.emailCC;
            studentsRepo = new StudentsRepository(StudentsFetcher.Properties.Settings.Default.StudentsFolder);
			cmbSelectedModule.Items.Clear();
			studentsRepo.Reload();
			foreach (var coll in studentsRepo.GetPersonCollections())
			{
				var ct = new ComboTag($"{coll.Name} - {coll.Students.Count}", coll.Name);
				cmbSelectedModule.Items.Add(ct);
			}
			var names = EmailContent.GetTemplateNames(studentsRepo.ConfigurationFolder);
			cmbEmailSubject.Items.AddRange(names.ToArray());
			cmbEmailTransformationRule.Items.AddRange(EmailContent.GetOptions());
			cmbEmailTransformationRule.SelectedIndex = 0;
		}

		private void cmdSelectFile_Click(object sender, EventArgs e)
		{
			openFileDialog1.DefaultExt = "*.xlsx";
			openFileDialog1.Multiselect = false;
			openFileDialog1.ShowDialog();
			if (openFileDialog1.FileName != "")
			{
				txtExcelFileName.Text = openFileDialog1.FileName;
			}
		}

		private void txtExcelFileName_TextChanged(object sender, EventArgs e)
		{
			ReloadDb();
		}

		private OleDbConnection? GetConn()
		{
			var f = GetExcelFileInfo();
			if (f == null)
				return null;
			if (!f.Exists)
				return null;
			string[] options = new[]
			{
                //$@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={f.FullName};Extended Properties=Excel 8.0;",
                $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={f.FullName};Extended Properties=""Excel 12.0 Xml;HDR=YES"";",
				$@"Excel File={f.FullName};"
			};

			for (int i = 0; i < options.Length; i++)
			{
				string item = options[i];
				try
				{
					var con = new OleDbConnection(item);
					con.Open();
					return con;
				}
				catch (Exception)
				{

				}
			}
			return null;
		}

		private FileInfo? GetExcelFileInfo()
		{
			if (string.IsNullOrWhiteSpace(txtExcelFileName.Text))
				return null;
			var f = new FileInfo(txtExcelFileName.Text);
			return f;
		}

		private void ReloadDb()
		{
			using var con = GetConn();
			if (con == null)
				return;
			var dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
			if (dt == null)
			{
				return;
			}
			var excelSheets = new string[dt.Rows.Count];
			int i = 0;

			// Add the sheet name to the string array.
			foreach (DataRow row in dt.Rows)
			{
				excelSheets[i] = row["TABLE_NAME"].ToString();
				i++;
			}
			con.Close();
			cmbTableNames.DataSource = excelSheets;
		}

		private void ReloadTable()
		{
			if (cmbTableNames.SelectedItem == null)
				return;
			var tbname = cmbTableNames.SelectedItem.ToString();
			using var con = GetConn();
			if (con is null)
				return;
			var cmd = $"select * from [{tbname}]";
			var da = new OleDbDataAdapter(cmd, con);
			var dt = new DataTable();
			da.Fill(dt);
			con.Close();
			UpdateUI(dt);
		}

		private DataTable? currentTable = null;

		private void UpdateUI(DataTable dt)
		{
			currentTable = dt;
			UpdateCombos();
			UpdateList();
		}

		private void UpdateCombos()
		{
			var curr = cmbEmailField.Text;
			cmbEmailField.Items.Clear();
			lstEmailSendSelection.Columns.Clear();
			lstEmailSendSelection.Columns.Add("FirstCol");
			if (currentTable is not null)
			{
				foreach (DataColumn clm in currentTable.Columns)
				{
					if (string.IsNullOrEmpty(curr))
					{
						if (clm.ColumnName.ToLowerInvariant().Contains(@"email"))
						{
							curr = clm.ColumnName.ToString();
						}
					}
					cmbEmailField.Items.Add(clm.ColumnName.ToString());
					lstEmailSendSelection.Columns.Add(clm.ColumnName.ToString());
				}
			}
			try
			{
				if (!string.IsNullOrEmpty(curr))
					cmbEmailField.SelectedItem = curr;
			}
			catch (Exception)
			{

			}
		}

        private void UpdateList()
		{
			// a regex to get the email from text
			var emaiRegex = new Regex(".+@.+\\..+");
			lstEmailSendSelection.Items.Clear();
			if (currentTable == null)
				return;
			foreach (DataRow row in currentTable.Rows)
			{
				if (!string.IsNullOrEmpty(cmbEmailField.Text))
				{
					if (!emaiRegex.IsMatch(row[cmbEmailField.Text].ToString()))
						continue;
				}
				var lvi = new ListViewItem { Text = row[0].ToString(), Tag = row };
				foreach (var subitem in row.ItemArray)
				{
					lvi.SubItems.Add(subitem.ToString());
				}
				lstEmailSendSelection.Items.Add(lvi);
			}
		}

		List<string> GetReplacementList(string emailbody)
		{
			var ret = new List<string>();

			MatchCollection mts = Regex.Matches(emailbody, "{([^}]*)}");
			foreach (Match match in mts)
			{
				ret.Add(match.Groups[1].ToString());
			}
			return ret;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (cmbEmailSubject.Text == "")
			{
				MessageBox.Show("Subject is empty.");
				return;
			}

			if (string.IsNullOrEmpty(cmbEmailField.Text))
			{
				MessageBox.Show("email field is invalid.");
				return;
			}

			if (!string.IsNullOrWhiteSpace(txtEmailCC.Text) && !txtEmailCC.Text.Trim().EndsWith(";"))
			{
				MessageBox.Show("email CC needs to end with semicolon.");
				return;
			}

			// var textInfo = Thread.CurrentThread.CurrentCulture.TextInfo;
			var app = new OutlookLateBindingEmailer();
			var replacements = GetReplacementList(txtEmailBody.Text);
			foreach (ListViewItem studentId in lstEmailSendSelection.Items)
			{
				if (!studentId.Checked)
					continue;

				var row = (DataRow)studentId.Tag;
				try
				{
					string emailtext = GetMailBody(replacements, row);
					var emailSubject = replaceFields(cmbEmailSubject.Text, replacements, row);
					var destEmail = EmailContent.ResolveEmail(row[cmbEmailField.Text].ToString(), cmbEmailTransformationRule.Text);
					if (string.IsNullOrWhiteSpace(destEmail))
						continue;
					if (chkEmailDryRun.Checked)
						app.SendOutlookEmail("claudio.benghi@gmail.com", emailSubject, emailtext, txtEmailCC.Text.Trim());
					else
						app.SendOutlookEmail(destEmail, emailSubject, emailtext, txtEmailCC.Text);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}
			MessageBox.Show("Done.");
		}

		private string GetMailBody(List<string> replacements, DataRow row)
		{
			var ret = replaceFields(txtEmailBody.Text, replacements, row);
			var ex = GetExcelFileInfo();
			if (ex != null)
			{
				ret = replaceFile(ret, ex.Directory);
			}
			return ret;
		}

		private string replaceFile(string ret, DirectoryInfo directory)
		{
			var r = new Regex("FILE<<(.*)>>");
			foreach (Match m in r.Matches(ret))
			{
				var toRep = m.Groups[0].Value;
				var fname = m.Groups[1].Value;

				var fullFName = Path.Combine(directory.FullName, fname);
				string rep = "";
				var f = new FileInfo(fullFName);
				if (f.Exists)
				{
					using var reader = f.OpenText();
					rep = reader.ReadToEnd();
				}
				ret = ret.Replace(toRep, rep);
			}
			return ret;
		}

		private string replaceFields(string emailtext, IEnumerable<string> replacements, DataRow row)
		{
			foreach (var item in replacements)
			{
				var data = item.Split(':');
				var dataId = data[0];

                // start with the data
                var repvalue = "";
                repvalue = row[dataId].ToString();
                repvalue = repvalue.Replace("\n", "\r\n");
                var oValue = row[dataId];
                if (oValue.GetType() == typeof(double))
                {
                    // repvalue = Math.Ceiling((double) oValue).ToString();
                    repvalue = Math.Round((double)oValue).ToString();
                }
				// any modifier?
                if (data.Length > 1)
				{
                    var dataFun = data[1].ToLowerInvariant();
					switch(dataFun)
					{
						case "resultshort":
						case "resultlong":
						case "shortresult":
						case "longresult":
							{
								if (ModuleResult.TryGetResultDescription(repvalue, out var shortVal, out var longVal))
								{
									if (dataFun == "resultshort" || dataFun == "shortresult")
										repvalue = shortVal;
									else
										repvalue = longVal;
								}
								else
									repvalue = "";
							}
							break;
						case "capitalize": // case is checked lowered
							repvalue = capitalize(repvalue.ToLowerInvariant()); 
							break;
						case "resolvestudentname": // case is checked lowered
							{
								if (studentsRepo.TryGetStudentByAnyReference(repvalue, out var student))
								{
									repvalue = student.Forename;
								}
							}
							break;
						case "firstcomponent": // case is checked lowered
							{
								var tmp = repvalue.Split(new char[] {' ','\t'}, StringSplitOptions.RemoveEmptyEntries);
								if (tmp.Length > 0)
								{
									repvalue = tmp[0];
								}
							}
							break;
						case "mcrfname": // case is checked lowered
							{
								var tmp = repvalue.Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
								if (tmp.Length == 0)
								{
									repvalue = "";
								}
								else if (tmp.Length > 0 && !IsWorkaround(tmp[0]))
								{
									repvalue = capitalize(tmp[0]);
								}
								else if (tmp.Length > 1 && IsWorkaround(tmp[0]))
								{
									repvalue = string.Join(" ", tmp.Skip(1));
									repvalue = capitalize(repvalue);
								}
								else
								{

								}

							}
							break;
					}
                }				
				// now fix it
				emailtext = emailtext.Replace("{" + item + "}", repvalue);
			}
			return emailtext;
		}

		private bool IsWorkaround(string name)
		{
			if (name == "-")
				return true;
			if (name == ".")
				return true;
			return false;
		}

		private string capitalize(string repvalue)
		{
			// Creates a TextInfo based on the "en-US" culture.
			TextInfo textInfo = new CultureInfo("en-GB", false).TextInfo;

			// Changes a string to titlecase.
			repvalue = repvalue.ToLowerInvariant(); // all capital would be otherwise ignored because considered Acronyms
			return textInfo.ToTitleCase(repvalue);
		}

        private void cmdReload_Click(object sender, EventArgs e)
		{
			ReloadDb();
		}

		private void cmdSelectAll_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem item in lstEmailSendSelection.Items)
			{
				item.Checked = true;
			}
		}

		private string folder
		{
			get
			{
				return new FileInfo(txtExcelFileName.Text).DirectoryName;
			}
		}

		private bool GetImage(string destfolder, string sid)
		{
			var req = new WebClient();
			string url = string.Format(@"http://nuweb2.northumbria.ac.uk/photoids/{0}.jpg", sid);


			string destfilename = sid + ".jpg";

			if (!System.IO.Directory.Exists(destfolder))
				System.IO.Directory.CreateDirectory(destfolder);
			destfilename = System.IO.Path.Combine(destfolder, destfilename);
			try
			{
				if (!System.IO.File.Exists(destfilename))
				{
					req.DownloadFile(url, destfilename);
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		private void cmdEmailRefreshStudents_Click(object sender, EventArgs e)
		{
			UpdateList();
		}

		private void lstEmailSendSelection_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstEmailSendSelection.SelectedItems.Count == 0)
				return;

			var emailColumn = cmbEmailField.Text;
			
			var row = lstEmailSendSelection.SelectedItems[0].Tag as DataRow;
			if (row == null)
				return;

			if (string.IsNullOrWhiteSpace(emailColumn) || !row.Table.Columns.Contains(emailColumn))
			{
				txtEmailPreview.Text = $"Error: Invalid email column '{emailColumn}'";
				return;
			}

			var replacements = GetReplacementList(txtEmailBody.Text);
			var destEmail = EmailContent.ResolveEmail(row[emailColumn].ToString(), cmbEmailTransformationRule.Text);
			lblSelectedEmail.Text = destEmail;
			try
			{
				var emailtext = GetMailBody(replacements, row);
				txtEmailPreview.Text = emailtext;
			}
			catch (Exception exception)
			{
				txtEmailPreview.Text = "Error: " + exception.Message;
			}
		}

		

		private void SaveSettings()
		{
			StudentsFetcher.Properties.Settings.Default.emailBody = txtEmailBody.Text;
			StudentsFetcher.Properties.Settings.Default.emailSubject = cmbEmailSubject.Text;
			StudentsFetcher.Properties.Settings.Default.emailCC = txtEmailCC.Text;
			StudentsFetcher.Properties.Settings.Default.Save();

			var email = new EmailContent()
			{
				EmailBody = txtEmailBody.Text,
				EmailCC = txtEmailCC.Text,
				EmailSubject = cmbEmailSubject.Text,
				EmailIdentificationField = cmbEmailField.Text,
				EmailIdentificationTransform = cmbEmailTransformationRule.Text,
			};
			email.Save(studentsRepo.ConfigurationFolder);
		}
		
		private void Button1_Click(object sender, EventArgs e)
		{
			SaveSettings();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			ReloadTable();
		}

        private void cmdSetModule_Click(object sender, EventArgs e)
        {
			var sel = cmbSelectedModule.SelectedItem as ComboTag;
			if (sel == null)
				return;
			var code = sel.Tag.ToString();
			var c = studentsRepo.GetPersonCollections().ToList();
            var  coll = c.Where(x => x.Name == code).FirstOrDefault();
			if (coll == null) 
				return;

            // Create a table with a schema that matches that of the query results.
            var table = new DataTable();
            table.Columns.Add("email", typeof(string));
            table.Columns.Add("first", typeof(string));
            table.Columns.Add("last", typeof(string));
            table.Columns.Add("full", typeof(string));
			var query = coll.Students.Where(x => !string.IsNullOrEmpty(x.Email)).Select(x=>ToDataRow(x, table));
            query.CopyToDataTable(table, LoadOption.PreserveChanges);
            UpdateUI(table);
        }

        private DataRow ToDataRow(Student x, DataTable table)
        {
			var r = table.NewRow();
			r["email"] = x.Email;
			r["first"] = x.Forename;
			r["last"] = x.Surname;
			r["full"] = x.FullName;
			return r;
        }

		internal void SetMailerDatabase(string databaseSource)
		{
			txtExcelFileName.Text = databaseSource;
		}

		private void cmbEmailSubject_SelectedValueChanged(object sender, EventArgs e)
		{
			var email = EmailContent.FromFile(
				studentsRepo.ConfigurationFolder,
				cmbEmailSubject.Text
				);
			if (email is null)
				return;
			// cmbEmailSubject.Text = email.EmailSubject;
			txtEmailCC.Text = email.EmailCC;
			txtEmailBody.Text = email.EmailBody;
			cmbEmailField.Text = email.EmailIdentificationField;
			cmbEmailTransformationRule.Text = email.EmailIdentificationTransform;
		}
	}
}
