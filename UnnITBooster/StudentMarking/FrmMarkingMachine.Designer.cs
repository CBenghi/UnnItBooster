using System;
using System.Windows.Forms;

namespace StudentsFetcher.StudentMarking
{
    partial class FrmMarkingMachine
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.txtStudentId = new System.Windows.Forms.TextBox();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.cmdAdd = new System.Windows.Forms.Button();
			this.txtLibReport = new System.Windows.Forms.TextBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer4 = new System.Windows.Forms.SplitContainer();
			this.txtStudentreport = new ExtendedTextBox.ExtTextBox();
			this.flComponents = new System.Windows.Forms.FlowLayoutPanel();
			this.LblMark = new System.Windows.Forms.Label();
			this.cmdSaveMarks = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.button12 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.label8 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.ChkAutoStat = new System.Windows.Forms.CheckBox();
			this.button2 = new System.Windows.Forms.Button();
			this.cmbDocuments = new System.Windows.Forms.ComboBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtTextOrPointer = new ExtendedTextBox.ExtTextBox();
			this.txtAdditionalNote = new ExtendedTextBox.ExtTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtArea = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.cmbComponentComment = new System.Windows.Forms.ComboBox();
			this.txtSection = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.button11 = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.cmdSelectFile = new System.Windows.Forms.Button();
			this.txtExcelFileName = new System.Windows.Forms.TextBox();
			this.cmdReload = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.splitContainer3 = new System.Windows.Forms.SplitContainer();
			this.splitContainer5 = new System.Windows.Forms.SplitContainer();
			this.lstEmailSendSelection = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.cmdEmailRefreshStudents = new System.Windows.Forms.Button();
			this.cmdSelectAll = new System.Windows.Forms.Button();
			this.StudImage = new System.Windows.Forms.PictureBox();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.tabControl2 = new System.Windows.Forms.TabControl();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.button1 = new System.Windows.Forms.Button();
			this.cmdSaveEmail = new System.Windows.Forms.Button();
			this.txtEmailBody = new ExtendedTextBox.ExtTextBox();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.txtEmailPreview = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.chkSendModerationNotice = new System.Windows.Forms.CheckBox();
			this.txtEmailSubject = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.chkEmailDryRun = new System.Windows.Forms.CheckBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.button4 = new System.Windows.Forms.Button();
			this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.txtReport = new System.Windows.Forms.TextBox();
			this.tabControl3 = new System.Windows.Forms.TabControl();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.txtSourceTurnitin = new System.Windows.Forms.TextBox();
			this.button8 = new System.Windows.Forms.Button();
			this.btnCompleteData = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.tabPage7 = new System.Windows.Forms.TabPage();
			this.txtSourceDataFile = new System.Windows.Forms.TextBox();
			this.chkImportSubmissions = new System.Windows.Forms.CheckBox();
			this.lblSourceData = new System.Windows.Forms.Label();
			this.chkImportComponents = new System.Windows.Forms.CheckBox();
			this.cmdSourceDataFile = new System.Windows.Forms.Button();
			this.cmdGetData = new System.Windows.Forms.Button();
			this.chkCommentLib = new System.Windows.Forms.CheckBox();
			this.tabPage8 = new System.Windows.Forms.TabPage();
			this.button10 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.tabPage9 = new System.Windows.Forms.TabPage();
			this.TxtExcelComponentSource = new System.Windows.Forms.TextBox();
			this.BtnImportExcel = new System.Windows.Forms.Button();
			this.BtnExportExcel = new System.Windows.Forms.Button();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.BtnOpenFolder = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
			this.splitContainer4.Panel1.SuspendLayout();
			this.splitContainer4.Panel2.SuspendLayout();
			this.splitContainer4.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
			this.splitContainer3.Panel1.SuspendLayout();
			this.splitContainer3.Panel2.SuspendLayout();
			this.splitContainer3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
			this.splitContainer5.Panel1.SuspendLayout();
			this.splitContainer5.Panel2.SuspendLayout();
			this.splitContainer5.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.StudImage)).BeginInit();
			this.tableLayoutPanel3.SuspendLayout();
			this.tabControl2.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.tabControl3.SuspendLayout();
			this.tabPage6.SuspendLayout();
			this.tabPage7.SuspendLayout();
			this.tabPage8.SuspendLayout();
			this.tabPage9.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtStudentId
			// 
			this.txtStudentId.Dock = System.Windows.Forms.DockStyle.Top;
			this.txtStudentId.Location = new System.Drawing.Point(0, 24);
			this.txtStudentId.Margin = new System.Windows.Forms.Padding(6);
			this.txtStudentId.Name = "txtStudentId";
			this.txtStudentId.Size = new System.Drawing.Size(434, 29);
			this.txtStudentId.TabIndex = 0;
			this.txtStudentId.TabStop = false;
			this.txtStudentId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStudentId_KeyDown);
			// 
			// txtSearch
			// 
			this.txtSearch.Dock = System.Windows.Forms.DockStyle.Top;
			this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSearch.Location = new System.Drawing.Point(0, 24);
			this.txtSearch.Margin = new System.Windows.Forms.Padding(6);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(414, 29);
			this.txtSearch.TabIndex = 3;
			this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
			// 
			// cmdAdd
			// 
			this.cmdAdd.Location = new System.Drawing.Point(144, 933);
			this.cmdAdd.Margin = new System.Windows.Forms.Padding(6);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.Size = new System.Drawing.Size(138, 42);
			this.cmdAdd.TabIndex = 13;
			this.cmdAdd.TabStop = false;
			this.cmdAdd.Text = "Add";
			this.cmdAdd.UseVisualStyleBackColor = true;
			this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
			// 
			// txtLibReport
			// 
			this.txtLibReport.BackColor = System.Drawing.Color.LightYellow;
			this.txtLibReport.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtLibReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtLibReport.Location = new System.Drawing.Point(0, 53);
			this.txtLibReport.Margin = new System.Windows.Forms.Padding(6);
			this.txtLibReport.Multiline = true;
			this.txtLibReport.Name = "txtLibReport";
			this.txtLibReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtLibReport.Size = new System.Drawing.Size(414, 833);
			this.txtLibReport.TabIndex = 2;
			this.txtLibReport.TabStop = false;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(6, 6);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(6);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.splitContainer4);
			this.splitContainer1.Panel1.Controls.Add(this.panel2);
			this.splitContainer1.Panel1.Controls.Add(this.txtStudentId);
			this.splitContainer1.Panel1.Controls.Add(this.label6);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Size = new System.Drawing.Size(1478, 1005);
			this.splitContainer1.SplitterDistance = 434;
			this.splitContainer1.SplitterWidth = 7;
			this.splitContainer1.TabIndex = 8;
			this.splitContainer1.TabStop = false;
			// 
			// splitContainer4
			// 
			this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer4.Location = new System.Drawing.Point(0, 99);
			this.splitContainer4.Margin = new System.Windows.Forms.Padding(4);
			this.splitContainer4.Name = "splitContainer4";
			this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer4.Panel1
			// 
			this.splitContainer4.Panel1.Controls.Add(this.txtStudentreport);
			// 
			// splitContainer4.Panel2
			// 
			this.splitContainer4.Panel2.Controls.Add(this.flComponents);
			this.splitContainer4.Panel2.Controls.Add(this.LblMark);
			this.splitContainer4.Panel2.Controls.Add(this.cmdSaveMarks);
			this.splitContainer4.Size = new System.Drawing.Size(434, 906);
			this.splitContainer4.SplitterDistance = 403;
			this.splitContainer4.SplitterWidth = 6;
			this.splitContainer4.TabIndex = 15;
			// 
			// txtStudentreport
			// 
			this.txtStudentreport.AcceptsReturn = true;
			this.txtStudentreport.AcceptsTab = true;
			this.txtStudentreport.ChangedColour = System.Drawing.Color.Empty;
			this.txtStudentreport.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtStudentreport.Location = new System.Drawing.Point(0, 0);
			this.txtStudentreport.Margin = new System.Windows.Forms.Padding(7);
			this.txtStudentreport.MaxLength = 0;
			this.txtStudentreport.Name = "txtStudentreport";
			this.txtStudentreport.OriginalText = "";
			this.txtStudentreport.Size = new System.Drawing.Size(434, 403);
			this.txtStudentreport.SpellCheck = true;
			this.txtStudentreport.TabIndex = 3;
			this.txtStudentreport.TabStop = false;
			this.txtStudentreport.TextCase = System.Windows.Forms.CharacterCasing.Normal;
			this.txtStudentreport.TextType = ExtendedTextBox.ExtTextBox.TextTypes.String;
			this.txtStudentreport.Wrapping = true;
			// 
			// flComponents
			// 
			this.flComponents.AutoScroll = true;
			this.flComponents.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flComponents.Location = new System.Drawing.Point(0, 87);
			this.flComponents.Margin = new System.Windows.Forms.Padding(4);
			this.flComponents.Name = "flComponents";
			this.flComponents.Size = new System.Drawing.Size(434, 369);
			this.flComponents.TabIndex = 13;
			// 
			// LblMark
			// 
			this.LblMark.Dock = System.Windows.Forms.DockStyle.Top;
			this.LblMark.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblMark.Location = new System.Drawing.Point(0, 0);
			this.LblMark.Name = "LblMark";
			this.LblMark.Size = new System.Drawing.Size(434, 87);
			this.LblMark.TabIndex = 0;
			this.LblMark.Text = "-";
			this.LblMark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cmdSaveMarks
			// 
			this.cmdSaveMarks.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.cmdSaveMarks.Location = new System.Drawing.Point(0, 456);
			this.cmdSaveMarks.Margin = new System.Windows.Forms.Padding(6);
			this.cmdSaveMarks.Name = "cmdSaveMarks";
			this.cmdSaveMarks.Size = new System.Drawing.Size(434, 41);
			this.cmdSaveMarks.TabIndex = 6;
			this.cmdSaveMarks.Text = "Ok";
			this.cmdSaveMarks.UseVisualStyleBackColor = true;
			this.cmdSaveMarks.Click += new System.EventHandler(this.CmdSaveMarks_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.button12);
			this.panel2.Controls.Add(this.button6);
			this.panel2.Controls.Add(this.button5);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 53);
			this.panel2.Margin = new System.Windows.Forms.Padding(4);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(434, 46);
			this.panel2.TabIndex = 17;
			// 
			// button12
			// 
			this.button12.Location = new System.Drawing.Point(7, 4);
			this.button12.Margin = new System.Windows.Forms.Padding(4);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(103, 35);
			this.button12.TabIndex = 2;
			this.button12.Text = "html";
			this.button12.UseVisualStyleBackColor = true;
			this.button12.Click += new System.EventHandler(this.button12_Click);
			// 
			// button6
			// 
			this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button6.Location = new System.Drawing.Point(214, 4);
			this.button6.Margin = new System.Windows.Forms.Padding(4);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(103, 35);
			this.button6.TabIndex = 0;
			this.button6.Text = "-";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button5
			// 
			this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button5.Location = new System.Drawing.Point(325, 4);
			this.button5.Margin = new System.Windows.Forms.Padding(4);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(103, 35);
			this.button5.TabIndex = 1;
			this.button5.Text = "+";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.Next_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Dock = System.Windows.Forms.DockStyle.Top;
			this.label6.Location = new System.Drawing.Point(0, 0);
			this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(79, 24);
			this.label6.TabIndex = 12;
			this.label6.Text = "Student:";
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Margin = new System.Windows.Forms.Padding(6);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.txtLibReport);
			this.splitContainer2.Panel1.Controls.Add(this.txtSearch);
			this.splitContainer2.Panel1.Controls.Add(this.label8);
			this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel1);
			this.splitContainer2.Panel2.Controls.Add(this.label7);
			this.splitContainer2.Size = new System.Drawing.Size(1037, 1005);
			this.splitContainer2.SplitterDistance = 414;
			this.splitContainer2.SplitterWidth = 7;
			this.splitContainer2.TabIndex = 0;
			this.splitContainer2.TabStop = false;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Dock = System.Windows.Forms.DockStyle.Top;
			this.label8.Location = new System.Drawing.Point(0, 0);
			this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(75, 24);
			this.label8.TabIndex = 14;
			this.label8.Text = "Search:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.ChkAutoStat);
			this.groupBox2.Controls.Add(this.button2);
			this.groupBox2.Controls.Add(this.cmbDocuments);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox2.Location = new System.Drawing.Point(0, 886);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(6);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(6);
			this.groupBox2.Size = new System.Drawing.Size(414, 119);
			this.groupBox2.TabIndex = 15;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Documents downloaded";
			// 
			// ChkAutoStat
			// 
			this.ChkAutoStat.AutoSize = true;
			this.ChkAutoStat.Location = new System.Drawing.Point(12, 75);
			this.ChkAutoStat.Name = "ChkAutoStat";
			this.ChkAutoStat.Size = new System.Drawing.Size(100, 28);
			this.ChkAutoStat.TabIndex = 3;
			this.ChkAutoStat.Text = "Auto stat";
			this.ChkAutoStat.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Location = new System.Drawing.Point(283, 28);
			this.button2.Margin = new System.Windows.Forms.Padding(6);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(119, 42);
			this.button2.TabIndex = 2;
			this.button2.Text = "Open";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Open_Click);
			// 
			// cmbDocuments
			// 
			this.cmbDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbDocuments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDocuments.FormattingEnabled = true;
			this.cmbDocuments.Location = new System.Drawing.Point(12, 34);
			this.cmbDocuments.Margin = new System.Windows.Forms.Padding(6);
			this.cmbDocuments.Name = "cmbDocuments";
			this.cmbDocuments.Size = new System.Drawing.Size(258, 32);
			this.cmbDocuments.TabIndex = 0;
			this.cmbDocuments.TabStop = false;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.45509F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.54491F));
			this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.txtTextOrPointer, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.txtAdditionalNote, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.txtArea, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.label11, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.cmdAdd, 1, 6);
			this.tableLayoutPanel1.Controls.Add(this.cmbComponentComment, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.txtSection, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.button11, 1, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(6);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 7;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(616, 981);
			this.tableLayoutPanel1.TabIndex = 8;
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 850);
			this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(50, 24);
			this.label4.TabIndex = 19;
			this.label4.Text = "Area";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 642);
			this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 24);
			this.label2.TabIndex = 17;
			this.label2.Text = "subcomment";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// txtTextOrPointer
			// 
			this.txtTextOrPointer.AcceptsReturn = true;
			this.txtTextOrPointer.AcceptsTab = true;
			this.txtTextOrPointer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTextOrPointer.ChangedColour = System.Drawing.Color.Empty;
			this.txtTextOrPointer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTextOrPointer.Location = new System.Drawing.Point(147, 99);
			this.txtTextOrPointer.Margin = new System.Windows.Forms.Padding(9);
			this.txtTextOrPointer.MaxLength = 0;
			this.txtTextOrPointer.Name = "txtTextOrPointer";
			this.txtTextOrPointer.OriginalText = "";
			this.txtTextOrPointer.Size = new System.Drawing.Size(460, 358);
			this.txtTextOrPointer.SpellCheck = true;
			this.txtTextOrPointer.TabIndex = 4;
			this.txtTextOrPointer.TextCase = System.Windows.Forms.CharacterCasing.Normal;
			this.txtTextOrPointer.TextType = ExtendedTextBox.ExtTextBox.TextTypes.String;
			this.txtTextOrPointer.Wrapping = true;
			this.txtTextOrPointer.OnCtrlEnter += new ExtendedTextBox.ExtTextBox.CtrlEnterPressed(this.DoAdd);
			this.txtTextOrPointer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTextOrPointer_KeyUp);
			// 
			// txtAdditionalNote
			// 
			this.txtAdditionalNote.AcceptsReturn = true;
			this.txtAdditionalNote.AcceptsTab = true;
			this.txtAdditionalNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtAdditionalNote.ChangedColour = System.Drawing.Color.Empty;
			this.txtAdditionalNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtAdditionalNote.Location = new System.Drawing.Point(147, 475);
			this.txtAdditionalNote.Margin = new System.Windows.Forms.Padding(9);
			this.txtAdditionalNote.MaxLength = 0;
			this.txtAdditionalNote.Name = "txtAdditionalNote";
			this.txtAdditionalNote.OriginalText = "";
			this.txtAdditionalNote.Size = new System.Drawing.Size(460, 358);
			this.txtAdditionalNote.SpellCheck = true;
			this.txtAdditionalNote.TabIndex = 5;
			this.txtAdditionalNote.TextCase = System.Windows.Forms.CharacterCasing.Normal;
			this.txtAdditionalNote.TextType = ExtendedTextBox.ExtTextBox.TextTypes.String;
			this.txtAdditionalNote.Wrapping = true;
			this.txtAdditionalNote.OnCtrlEnter += new ExtendedTextBox.ExtTextBox.CtrlEnterPressed(this.DoAdd);
			this.txtAdditionalNote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTextOrPointer_KeyUp);
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 266);
			this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 24);
			this.label1.TabIndex = 10;
			this.label1.Text = "ptr/text";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// txtArea
			// 
			this.txtArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtArea.Location = new System.Drawing.Point(144, 848);
			this.txtArea.Margin = new System.Windows.Forms.Padding(6);
			this.txtArea.Name = "txtArea";
			this.txtArea.Size = new System.Drawing.Size(466, 29);
			this.txtArea.TabIndex = 12;
			this.txtArea.TabStop = false;
			// 
			// label11
			// 
			this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(6, 893);
			this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(109, 24);
			this.label11.TabIndex = 20;
			this.label11.Text = "Component";
			// 
			// cmbComponentComment
			// 
			this.cmbComponentComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbComponentComment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbComponentComment.FormattingEnabled = true;
			this.cmbComponentComment.Location = new System.Drawing.Point(144, 889);
			this.cmbComponentComment.Margin = new System.Windows.Forms.Padding(6);
			this.cmbComponentComment.Name = "cmbComponentComment";
			this.cmbComponentComment.Size = new System.Drawing.Size(466, 32);
			this.cmbComponentComment.TabIndex = 21;
			this.cmbComponentComment.TabStop = false;
			// 
			// txtSection
			// 
			this.txtSection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSection.Location = new System.Drawing.Point(144, 6);
			this.txtSection.Margin = new System.Windows.Forms.Padding(6);
			this.txtSection.Name = "txtSection";
			this.txtSection.Size = new System.Drawing.Size(466, 32);
			this.txtSection.TabIndex = 11;
			this.txtSection.TabStop = false;
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 10);
			this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(73, 24);
			this.label3.TabIndex = 18;
			this.label3.Text = "Section";
			// 
			// button11
			// 
			this.button11.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button11.Location = new System.Drawing.Point(144, 50);
			this.button11.Margin = new System.Windows.Forms.Padding(6);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(466, 34);
			this.button11.TabIndex = 22;
			this.button11.Text = "Section rotation";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new System.EventHandler(this.button11_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Dock = System.Windows.Forms.DockStyle.Top;
			this.label7.Location = new System.Drawing.Point(0, 0);
			this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(92, 24);
			this.label7.TabIndex = 13;
			this.label7.Text = "Comment";
			// 
			// cmdSelectFile
			// 
			this.cmdSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdSelectFile.Location = new System.Drawing.Point(1339, 9);
			this.cmdSelectFile.Margin = new System.Windows.Forms.Padding(6);
			this.cmdSelectFile.Name = "cmdSelectFile";
			this.cmdSelectFile.Size = new System.Drawing.Size(43, 41);
			this.cmdSelectFile.TabIndex = 10;
			this.cmdSelectFile.TabStop = false;
			this.cmdSelectFile.Text = "...";
			this.cmdSelectFile.UseVisualStyleBackColor = true;
			this.cmdSelectFile.Click += new System.EventHandler(this.cmdSelectFile_Click);
			// 
			// txtExcelFileName
			// 
			this.txtExcelFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtExcelFileName.Location = new System.Drawing.Point(116, 11);
			this.txtExcelFileName.Margin = new System.Windows.Forms.Padding(6);
			this.txtExcelFileName.Multiline = true;
			this.txtExcelFileName.Name = "txtExcelFileName";
			this.txtExcelFileName.Size = new System.Drawing.Size(1211, 37);
			this.txtExcelFileName.TabIndex = 9;
			this.txtExcelFileName.TabStop = false;
			this.txtExcelFileName.TextChanged += new System.EventHandler(this.txtExcelFileName_TextChanged);
			// 
			// cmdReload
			// 
			this.cmdReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdReload.Location = new System.Drawing.Point(1394, 9);
			this.cmdReload.Margin = new System.Windows.Forms.Padding(6);
			this.cmdReload.Name = "cmdReload";
			this.cmdReload.Size = new System.Drawing.Size(43, 41);
			this.cmdReload.TabIndex = 12;
			this.cmdReload.TabStop = false;
			this.cmdReload.Text = "R";
			this.cmdReload.UseVisualStyleBackColor = true;
			this.cmdReload.Click += new System.EventHandler(this.cmdReload_Click);
			// 
			// label5
			// 
			this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 17);
			this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(71, 24);
			this.label5.TabIndex = 11;
			this.label5.Text = "SQLite ";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 59);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(6);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1498, 1054);
			this.tabControl1.TabIndex = 12;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.splitContainer1);
			this.tabPage1.Location = new System.Drawing.Point(4, 33);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(6);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(6);
			this.tabPage1.Size = new System.Drawing.Size(1490, 1017);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Marking";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.splitContainer3);
			this.tabPage2.Location = new System.Drawing.Point(4, 33);
			this.tabPage2.Margin = new System.Windows.Forms.Padding(6);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(6);
			this.tabPage2.Size = new System.Drawing.Size(1490, 1017);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Emailing";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// splitContainer3
			// 
			this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer3.Location = new System.Drawing.Point(6, 6);
			this.splitContainer3.Margin = new System.Windows.Forms.Padding(6);
			this.splitContainer3.Name = "splitContainer3";
			// 
			// splitContainer3.Panel1
			// 
			this.splitContainer3.Panel1.Controls.Add(this.splitContainer5);
			// 
			// splitContainer3.Panel2
			// 
			this.splitContainer3.Panel2.Controls.Add(this.tableLayoutPanel3);
			this.splitContainer3.Size = new System.Drawing.Size(1478, 1005);
			this.splitContainer3.SplitterDistance = 592;
			this.splitContainer3.SplitterWidth = 7;
			this.splitContainer3.TabIndex = 3;
			// 
			// splitContainer5
			// 
			this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer5.Location = new System.Drawing.Point(0, 0);
			this.splitContainer5.Margin = new System.Windows.Forms.Padding(4);
			this.splitContainer5.Name = "splitContainer5";
			this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer5.Panel1
			// 
			this.splitContainer5.Panel1.Controls.Add(this.lstEmailSendSelection);
			this.splitContainer5.Panel1.Controls.Add(this.tableLayoutPanel2);
			// 
			// splitContainer5.Panel2
			// 
			this.splitContainer5.Panel2.Controls.Add(this.StudImage);
			this.splitContainer5.Size = new System.Drawing.Size(592, 1005);
			this.splitContainer5.SplitterDistance = 448;
			this.splitContainer5.SplitterWidth = 6;
			this.splitContainer5.TabIndex = 14;
			// 
			// lstEmailSendSelection
			// 
			this.lstEmailSendSelection.CheckBoxes = true;
			this.lstEmailSendSelection.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
			this.lstEmailSendSelection.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstEmailSendSelection.FullRowSelect = true;
			this.lstEmailSendSelection.GridLines = true;
			this.lstEmailSendSelection.HideSelection = false;
			this.lstEmailSendSelection.Location = new System.Drawing.Point(0, 55);
			this.lstEmailSendSelection.Margin = new System.Windows.Forms.Padding(6);
			this.lstEmailSendSelection.Name = "lstEmailSendSelection";
			this.lstEmailSendSelection.Size = new System.Drawing.Size(592, 393);
			this.lstEmailSendSelection.TabIndex = 3;
			this.lstEmailSendSelection.UseCompatibleStateImageBehavior = false;
			this.lstEmailSendSelection.View = System.Windows.Forms.View.Details;
			this.lstEmailSendSelection.SelectedIndexChanged += new System.EventHandler(this.lstEmailSendSelection_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Name";
			this.columnHeader1.Width = 146;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "# Marks";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Mark";
			this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "InternalID";
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "NumComments";
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Similarity";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 3;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
			this.tableLayoutPanel2.Controls.Add(this.cmdEmailRefreshStudents, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.cmdSelectAll, 1, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(592, 55);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// cmdEmailRefreshStudents
			// 
			this.cmdEmailRefreshStudents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdEmailRefreshStudents.Location = new System.Drawing.Point(6, 6);
			this.cmdEmailRefreshStudents.Margin = new System.Windows.Forms.Padding(6);
			this.cmdEmailRefreshStudents.Name = "cmdEmailRefreshStudents";
			this.cmdEmailRefreshStudents.Size = new System.Drawing.Size(185, 42);
			this.cmdEmailRefreshStudents.TabIndex = 2;
			this.cmdEmailRefreshStudents.Text = "Refresh";
			this.cmdEmailRefreshStudents.UseVisualStyleBackColor = true;
			this.cmdEmailRefreshStudents.Click += new System.EventHandler(this.cmdEmailRefreshStudents_Click);
			// 
			// cmdSelectAll
			// 
			this.cmdSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdSelectAll.Location = new System.Drawing.Point(203, 6);
			this.cmdSelectAll.Margin = new System.Windows.Forms.Padding(6);
			this.cmdSelectAll.Name = "cmdSelectAll";
			this.cmdSelectAll.Size = new System.Drawing.Size(185, 42);
			this.cmdSelectAll.TabIndex = 4;
			this.cmdSelectAll.Text = "All";
			this.cmdSelectAll.UseVisualStyleBackColor = true;
			this.cmdSelectAll.Click += new System.EventHandler(this.cmdSelectAll_Click);
			// 
			// StudImage
			// 
			this.StudImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.StudImage.Location = new System.Drawing.Point(0, 0);
			this.StudImage.Margin = new System.Windows.Forms.Padding(4);
			this.StudImage.Name = "StudImage";
			this.StudImage.Size = new System.Drawing.Size(592, 551);
			this.StudImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.StudImage.TabIndex = 13;
			this.StudImage.TabStop = false;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Controls.Add(this.tabControl2, 0, 3);
			this.tableLayoutPanel3.Controls.Add(this.button3, 1, 2);
			this.tableLayoutPanel3.Controls.Add(this.chkSendModerationNotice, 0, 2);
			this.tableLayoutPanel3.Controls.Add(this.txtEmailSubject, 1, 0);
			this.tableLayoutPanel3.Controls.Add(this.label10, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.chkEmailDryRun, 0, 1);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 4;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(879, 1005);
			this.tableLayoutPanel3.TabIndex = 8;
			// 
			// tabControl2
			// 
			this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel3.SetColumnSpan(this.tabControl2, 2);
			this.tabControl2.Controls.Add(this.tabPage4);
			this.tabControl2.Controls.Add(this.tabPage5);
			this.tabControl2.Location = new System.Drawing.Point(4, 134);
			this.tabControl2.Margin = new System.Windows.Forms.Padding(4);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(871, 867);
			this.tabControl2.TabIndex = 7;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.button1);
			this.tabPage4.Controls.Add(this.cmdSaveEmail);
			this.tabPage4.Controls.Add(this.txtEmailBody);
			this.tabPage4.Location = new System.Drawing.Point(4, 33);
			this.tabPage4.Margin = new System.Windows.Forms.Padding(4);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(4);
			this.tabPage4.Size = new System.Drawing.Size(863, 830);
			this.tabPage4.TabIndex = 0;
			this.tabPage4.Text = "Template";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button1.Location = new System.Drawing.Point(9, 754);
			this.button1.Margin = new System.Windows.Forms.Padding(6);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(236, 42);
			this.button1.TabIndex = 9;
			this.button1.Text = "Default";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// cmdSaveEmail
			// 
			this.cmdSaveEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cmdSaveEmail.Location = new System.Drawing.Point(257, 754);
			this.cmdSaveEmail.Margin = new System.Windows.Forms.Padding(6);
			this.cmdSaveEmail.Name = "cmdSaveEmail";
			this.cmdSaveEmail.Size = new System.Drawing.Size(236, 42);
			this.cmdSaveEmail.TabIndex = 8;
			this.cmdSaveEmail.Text = "Save";
			this.cmdSaveEmail.UseVisualStyleBackColor = true;
			this.cmdSaveEmail.Click += new System.EventHandler(this.cmdSaveEmail_Click);
			// 
			// txtEmailBody
			// 
			this.txtEmailBody.AcceptsReturn = true;
			this.txtEmailBody.AcceptsTab = true;
			this.txtEmailBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtEmailBody.ChangedColour = System.Drawing.Color.Empty;
			this.txtEmailBody.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtEmailBody.Location = new System.Drawing.Point(7, 13);
			this.txtEmailBody.Margin = new System.Windows.Forms.Padding(11);
			this.txtEmailBody.MaxLength = 0;
			this.txtEmailBody.Name = "txtEmailBody";
			this.txtEmailBody.OriginalText = "";
			this.txtEmailBody.Size = new System.Drawing.Size(844, 724);
			this.txtEmailBody.SpellCheck = true;
			this.txtEmailBody.TabIndex = 6;
			this.txtEmailBody.TabStop = false;
			this.txtEmailBody.TextCase = System.Windows.Forms.CharacterCasing.Normal;
			this.txtEmailBody.TextType = ExtendedTextBox.ExtTextBox.TextTypes.String;
			this.txtEmailBody.Wrapping = true;
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.txtEmailPreview);
			this.tabPage5.Location = new System.Drawing.Point(4, 33);
			this.tabPage5.Margin = new System.Windows.Forms.Padding(4);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new System.Windows.Forms.Padding(4);
			this.tabPage5.Size = new System.Drawing.Size(863, 830);
			this.tabPage5.TabIndex = 1;
			this.tabPage5.Text = "Output";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// txtEmailPreview
			// 
			this.txtEmailPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtEmailPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtEmailPreview.Location = new System.Drawing.Point(9, 11);
			this.txtEmailPreview.Margin = new System.Windows.Forms.Padding(6);
			this.txtEmailPreview.Multiline = true;
			this.txtEmailPreview.Name = "txtEmailPreview";
			this.txtEmailPreview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtEmailPreview.Size = new System.Drawing.Size(842, 775);
			this.txtEmailPreview.TabIndex = 7;
			this.txtEmailPreview.TabStop = false;
			this.txtEmailPreview.Text = "Dear {SUB_FirstName}, \r\nThe marking and moderation process for BE1178 has been co" +
    "mpleted a few days ago. \r\nPlease find your feedback after my signature.\r\nBest re" +
    "gards, \r\nClaudio \r\n\r\n{MarkReport}";
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.button3.Location = new System.Drawing.Point(241, 87);
			this.button3.Margin = new System.Windows.Forms.Padding(6);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(632, 37);
			this.button3.TabIndex = 0;
			this.button3.Text = "Send";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// chkSendModerationNotice
			// 
			this.chkSendModerationNotice.AutoSize = true;
			this.chkSendModerationNotice.Location = new System.Drawing.Point(6, 87);
			this.chkSendModerationNotice.Margin = new System.Windows.Forms.Padding(6);
			this.chkSendModerationNotice.Name = "chkSendModerationNotice";
			this.chkSendModerationNotice.Size = new System.Drawing.Size(223, 28);
			this.chkSendModerationNotice.TabIndex = 5;
			this.chkSendModerationNotice.Text = "Add Moderation Notice";
			this.chkSendModerationNotice.UseVisualStyleBackColor = true;
			// 
			// txtEmailSubject
			// 
			this.txtEmailSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtEmailSubject.Location = new System.Drawing.Point(241, 6);
			this.txtEmailSubject.Margin = new System.Windows.Forms.Padding(6);
			this.txtEmailSubject.Name = "txtEmailSubject";
			this.txtEmailSubject.Size = new System.Drawing.Size(632, 29);
			this.txtEmailSubject.TabIndex = 3;
			// 
			// label10
			// 
			this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(6, 8);
			this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(73, 24);
			this.label10.TabIndex = 2;
			this.label10.Text = "Subject";
			// 
			// chkEmailDryRun
			// 
			this.chkEmailDryRun.AutoSize = true;
			this.chkEmailDryRun.Checked = true;
			this.chkEmailDryRun.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkEmailDryRun.Location = new System.Drawing.Point(6, 47);
			this.chkEmailDryRun.Margin = new System.Windows.Forms.Padding(6);
			this.chkEmailDryRun.Name = "chkEmailDryRun";
			this.chkEmailDryRun.Size = new System.Drawing.Size(97, 28);
			this.chkEmailDryRun.TabIndex = 4;
			this.chkEmailDryRun.Text = "Dry Run";
			this.chkEmailDryRun.UseVisualStyleBackColor = true;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.button4);
			this.tabPage3.Controls.Add(this.zedGraphControl1);
			this.tabPage3.Controls.Add(this.groupBox3);
			this.tabPage3.Location = new System.Drawing.Point(4, 33);
			this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
			this.tabPage3.Size = new System.Drawing.Size(1490, 1017);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Tools";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(11, 480);
			this.button4.Margin = new System.Windows.Forms.Padding(4);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(103, 103);
			this.button4.TabIndex = 19;
			this.button4.Text = "Marks chart";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// zedGraphControl1
			// 
			this.zedGraphControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.zedGraphControl1.Location = new System.Drawing.Point(121, 480);
			this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(7);
			this.zedGraphControl1.Name = "zedGraphControl1";
			this.zedGraphControl1.ScrollGrace = 0D;
			this.zedGraphControl1.ScrollMaxX = 0D;
			this.zedGraphControl1.ScrollMaxY = 0D;
			this.zedGraphControl1.ScrollMaxY2 = 0D;
			this.zedGraphControl1.ScrollMinX = 0D;
			this.zedGraphControl1.ScrollMinY = 0D;
			this.zedGraphControl1.ScrollMinY2 = 0D;
			this.zedGraphControl1.Size = new System.Drawing.Size(1351, 480);
			this.zedGraphControl1.TabIndex = 18;
			this.zedGraphControl1.UseExtendedPrintDialog = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.txtReport);
			this.groupBox3.Controls.Add(this.tabControl3);
			this.groupBox3.Location = new System.Drawing.Point(11, 22);
			this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox3.Size = new System.Drawing.Size(1459, 425);
			this.groupBox3.TabIndex = 17;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Import data";
			// 
			// txtReport
			// 
			this.txtReport.Location = new System.Drawing.Point(766, 74);
			this.txtReport.Margin = new System.Windows.Forms.Padding(6);
			this.txtReport.Multiline = true;
			this.txtReport.Name = "txtReport";
			this.txtReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtReport.Size = new System.Drawing.Size(680, 331);
			this.txtReport.TabIndex = 26;
			// 
			// tabControl3
			// 
			this.tabControl3.Controls.Add(this.tabPage6);
			this.tabControl3.Controls.Add(this.tabPage7);
			this.tabControl3.Controls.Add(this.tabPage8);
			this.tabControl3.Controls.Add(this.tabPage9);
			this.tabControl3.Location = new System.Drawing.Point(9, 33);
			this.tabControl3.Margin = new System.Windows.Forms.Padding(6);
			this.tabControl3.Name = "tabControl3";
			this.tabControl3.SelectedIndex = 0;
			this.tabControl3.Size = new System.Drawing.Size(746, 382);
			this.tabControl3.TabIndex = 26;
			// 
			// tabPage6
			// 
			this.tabPage6.Controls.Add(this.txtSourceTurnitin);
			this.tabPage6.Controls.Add(this.button8);
			this.tabPage6.Controls.Add(this.btnCompleteData);
			this.tabPage6.Controls.Add(this.button7);
			this.tabPage6.Location = new System.Drawing.Point(4, 33);
			this.tabPage6.Margin = new System.Windows.Forms.Padding(6);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Padding = new System.Windows.Forms.Padding(6);
			this.tabPage6.Size = new System.Drawing.Size(738, 345);
			this.tabPage6.TabIndex = 0;
			this.tabPage6.Text = "Gradebook";
			this.tabPage6.UseVisualStyleBackColor = true;
			// 
			// txtSourceTurnitin
			// 
			this.txtSourceTurnitin.Location = new System.Drawing.Point(42, 31);
			this.txtSourceTurnitin.Margin = new System.Windows.Forms.Padding(6);
			this.txtSourceTurnitin.Multiline = true;
			this.txtSourceTurnitin.Name = "txtSourceTurnitin";
			this.txtSourceTurnitin.Size = new System.Drawing.Size(614, 100);
			this.txtSourceTurnitin.TabIndex = 24;
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(614, 144);
			this.button8.Margin = new System.Windows.Forms.Padding(6);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(46, 41);
			this.button8.TabIndex = 25;
			this.button8.Text = "...";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// btnCompleteData
			// 
			this.btnCompleteData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCompleteData.Location = new System.Drawing.Point(38, 249);
			this.btnCompleteData.Margin = new System.Windows.Forms.Padding(4);
			this.btnCompleteData.Name = "btnCompleteData";
			this.btnCompleteData.Size = new System.Drawing.Size(622, 48);
			this.btnCompleteData.TabIndex = 18;
			this.btnCompleteData.Text = "Update database from gradebook";
			this.btnCompleteData.UseVisualStyleBackColor = true;
			this.btnCompleteData.Click += new System.EventHandler(this.BtnCompleteData_Click);
			// 
			// button7
			// 
			this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button7.Location = new System.Drawing.Point(38, 194);
			this.button7.Margin = new System.Windows.Forms.Padding(4);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(622, 48);
			this.button7.TabIndex = 19;
			this.button7.Text = "Initialize database from gradebook";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.Button7_Click);
			// 
			// tabPage7
			// 
			this.tabPage7.Controls.Add(this.txtSourceDataFile);
			this.tabPage7.Controls.Add(this.chkImportSubmissions);
			this.tabPage7.Controls.Add(this.lblSourceData);
			this.tabPage7.Controls.Add(this.chkImportComponents);
			this.tabPage7.Controls.Add(this.cmdSourceDataFile);
			this.tabPage7.Controls.Add(this.cmdGetData);
			this.tabPage7.Controls.Add(this.chkCommentLib);
			this.tabPage7.Location = new System.Drawing.Point(4, 33);
			this.tabPage7.Margin = new System.Windows.Forms.Padding(6);
			this.tabPage7.Name = "tabPage7";
			this.tabPage7.Padding = new System.Windows.Forms.Padding(6);
			this.tabPage7.Size = new System.Drawing.Size(738, 345);
			this.tabPage7.TabIndex = 1;
			this.tabPage7.Text = "Other AMM database";
			this.tabPage7.UseVisualStyleBackColor = true;
			// 
			// txtSourceDataFile
			// 
			this.txtSourceDataFile.Location = new System.Drawing.Point(183, 31);
			this.txtSourceDataFile.Margin = new System.Windows.Forms.Padding(6);
			this.txtSourceDataFile.Multiline = true;
			this.txtSourceDataFile.Name = "txtSourceDataFile";
			this.txtSourceDataFile.Size = new System.Drawing.Size(516, 98);
			this.txtSourceDataFile.TabIndex = 12;
			// 
			// chkImportSubmissions
			// 
			this.chkImportSubmissions.AutoSize = true;
			this.chkImportSubmissions.Location = new System.Drawing.Point(183, 222);
			this.chkImportSubmissions.Margin = new System.Windows.Forms.Padding(4);
			this.chkImportSubmissions.Name = "chkImportSubmissions";
			this.chkImportSubmissions.Size = new System.Drawing.Size(190, 28);
			this.chkImportSubmissions.TabIndex = 23;
			this.chkImportSubmissions.Text = "Import submissions";
			this.chkImportSubmissions.UseVisualStyleBackColor = true;
			// 
			// lblSourceData
			// 
			this.lblSourceData.AutoSize = true;
			this.lblSourceData.Location = new System.Drawing.Point(20, 35);
			this.lblSourceData.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.lblSourceData.Name = "lblSourceData";
			this.lblSourceData.Size = new System.Drawing.Size(121, 24);
			this.lblSourceData.TabIndex = 14;
			this.lblSourceData.Text = "sqlite source:";
			// 
			// chkImportComponents
			// 
			this.chkImportComponents.AutoSize = true;
			this.chkImportComponents.Location = new System.Drawing.Point(183, 183);
			this.chkImportComponents.Margin = new System.Windows.Forms.Padding(4);
			this.chkImportComponents.Name = "chkImportComponents";
			this.chkImportComponents.Size = new System.Drawing.Size(237, 28);
			this.chkImportComponents.TabIndex = 17;
			this.chkImportComponents.Text = "Import mark components";
			this.chkImportComponents.UseVisualStyleBackColor = true;
			// 
			// cmdSourceDataFile
			// 
			this.cmdSourceDataFile.Location = new System.Drawing.Point(654, 144);
			this.cmdSourceDataFile.Margin = new System.Windows.Forms.Padding(6);
			this.cmdSourceDataFile.Name = "cmdSourceDataFile";
			this.cmdSourceDataFile.Size = new System.Drawing.Size(46, 41);
			this.cmdSourceDataFile.TabIndex = 13;
			this.cmdSourceDataFile.Text = "...";
			this.cmdSourceDataFile.UseVisualStyleBackColor = true;
			this.cmdSourceDataFile.Click += new System.EventHandler(this.cmdSourceDataFile_Click);
			// 
			// cmdGetData
			// 
			this.cmdGetData.Location = new System.Drawing.Point(185, 277);
			this.cmdGetData.Margin = new System.Windows.Forms.Padding(4);
			this.cmdGetData.Name = "cmdGetData";
			this.cmdGetData.Size = new System.Drawing.Size(517, 48);
			this.cmdGetData.TabIndex = 15;
			this.cmdGetData.Text = "Get Data";
			this.cmdGetData.UseVisualStyleBackColor = true;
			this.cmdGetData.Click += new System.EventHandler(this.cmdGetData_Click);
			// 
			// chkCommentLib
			// 
			this.chkCommentLib.AutoSize = true;
			this.chkCommentLib.Location = new System.Drawing.Point(183, 142);
			this.chkCommentLib.Margin = new System.Windows.Forms.Padding(4);
			this.chkCommentLib.Name = "chkCommentLib";
			this.chkCommentLib.Size = new System.Drawing.Size(229, 28);
			this.chkCommentLib.TabIndex = 16;
			this.chkCommentLib.Text = "Import Comment Library";
			this.chkCommentLib.UseVisualStyleBackColor = true;
			// 
			// tabPage8
			// 
			this.tabPage8.Controls.Add(this.button10);
			this.tabPage8.Controls.Add(this.button9);
			this.tabPage8.Location = new System.Drawing.Point(4, 33);
			this.tabPage8.Margin = new System.Windows.Forms.Padding(6);
			this.tabPage8.Name = "tabPage8";
			this.tabPage8.Size = new System.Drawing.Size(738, 345);
			this.tabPage8.TabIndex = 2;
			this.tabPage8.Text = "DocumentArchive";
			this.tabPage8.UseVisualStyleBackColor = true;
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(33, 78);
			this.button10.Margin = new System.Windows.Forms.Padding(6);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(664, 42);
			this.button10.TabIndex = 1;
			this.button10.Text = "Get manifest information";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new System.EventHandler(this.Button10_Click);
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(33, 24);
			this.button9.Margin = new System.Windows.Forms.Padding(6);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(664, 42);
			this.button9.TabIndex = 0;
			this.button9.Text = "Expand";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// tabPage9
			// 
			this.tabPage9.Controls.Add(this.TxtExcelComponentSource);
			this.tabPage9.Controls.Add(this.BtnImportExcel);
			this.tabPage9.Controls.Add(this.BtnExportExcel);
			this.tabPage9.Location = new System.Drawing.Point(4, 33);
			this.tabPage9.Margin = new System.Windows.Forms.Padding(6);
			this.tabPage9.Name = "tabPage9";
			this.tabPage9.Padding = new System.Windows.Forms.Padding(6);
			this.tabPage9.Size = new System.Drawing.Size(738, 345);
			this.tabPage9.TabIndex = 3;
			this.tabPage9.Text = "Excel";
			this.tabPage9.UseVisualStyleBackColor = true;
			// 
			// TxtExcelComponentSource
			// 
			this.TxtExcelComponentSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.TxtExcelComponentSource.Location = new System.Drawing.Point(11, 190);
			this.TxtExcelComponentSource.Margin = new System.Windows.Forms.Padding(6);
			this.TxtExcelComponentSource.Multiline = true;
			this.TxtExcelComponentSource.Name = "TxtExcelComponentSource";
			this.TxtExcelComponentSource.Size = new System.Drawing.Size(706, 37);
			this.TxtExcelComponentSource.TabIndex = 10;
			this.TxtExcelComponentSource.TabStop = false;
			// 
			// BtnImportExcel
			// 
			this.BtnImportExcel.Location = new System.Drawing.Point(11, 100);
			this.BtnImportExcel.Margin = new System.Windows.Forms.Padding(6);
			this.BtnImportExcel.Name = "BtnImportExcel";
			this.BtnImportExcel.Size = new System.Drawing.Size(348, 78);
			this.BtnImportExcel.TabIndex = 1;
			this.BtnImportExcel.Text = "Import Excel Components";
			this.BtnImportExcel.UseVisualStyleBackColor = true;
			this.BtnImportExcel.Click += new System.EventHandler(this.BtnImportExcel_Click);
			// 
			// BtnExportExcel
			// 
			this.BtnExportExcel.Location = new System.Drawing.Point(11, 11);
			this.BtnExportExcel.Margin = new System.Windows.Forms.Padding(6);
			this.BtnExportExcel.Name = "BtnExportExcel";
			this.BtnExportExcel.Size = new System.Drawing.Size(348, 78);
			this.BtnExportExcel.TabIndex = 0;
			this.BtnExportExcel.Text = "Export excel";
			this.BtnExportExcel.UseVisualStyleBackColor = true;
			this.BtnExportExcel.Click += new System.EventHandler(this.BtnExportExcel_Click);
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.ColumnCount = 5;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
			this.tableLayoutPanel4.Controls.Add(this.cmdReload, 3, 0);
			this.tableLayoutPanel4.Controls.Add(this.label5, 0, 0);
			this.tableLayoutPanel4.Controls.Add(this.cmdSelectFile, 2, 0);
			this.tableLayoutPanel4.Controls.Add(this.txtExcelFileName, 1, 0);
			this.tableLayoutPanel4.Controls.Add(this.BtnOpenFolder, 4, 0);
			this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 1;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.Size = new System.Drawing.Size(1498, 59);
			this.tableLayoutPanel4.TabIndex = 13;
			// 
			// BtnOpenFolder
			// 
			this.BtnOpenFolder.Image = global::UnnItBooster.Properties.Resources.folder;
			this.BtnOpenFolder.Location = new System.Drawing.Point(1449, 6);
			this.BtnOpenFolder.Margin = new System.Windows.Forms.Padding(6);
			this.BtnOpenFolder.Name = "BtnOpenFolder";
			this.BtnOpenFolder.Size = new System.Drawing.Size(43, 42);
			this.BtnOpenFolder.TabIndex = 13;
			this.BtnOpenFolder.UseVisualStyleBackColor = true;
			this.BtnOpenFolder.Click += new System.EventHandler(this.BtnOpenFolder_Click);
			// 
			// FrmMarkingMachine
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1498, 1113);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.tableLayoutPanel4);
			this.Margin = new System.Windows.Forms.Padding(6);
			this.Name = "FrmMarkingMachine";
			this.Text = "Marking Machine";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer4.Panel1.ResumeLayout(false);
			this.splitContainer4.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
			this.splitContainer4.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel1.PerformLayout();
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.splitContainer3.Panel1.ResumeLayout(false);
			this.splitContainer3.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
			this.splitContainer3.ResumeLayout(false);
			this.splitContainer5.Panel1.ResumeLayout(false);
			this.splitContainer5.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
			this.splitContainer5.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.StudImage)).EndInit();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.tabControl2.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.tabPage5.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.tabControl3.ResumeLayout(false);
			this.tabPage6.ResumeLayout(false);
			this.tabPage6.PerformLayout();
			this.tabPage7.ResumeLayout(false);
			this.tabPage7.PerformLayout();
			this.tabPage8.ResumeLayout(false);
			this.tabPage9.ResumeLayout(false);
			this.tabPage9.PerformLayout();
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel4.PerformLayout();
			this.ResumeLayout(false);

        }
				

		#endregion

		private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.TextBox txtLibReport;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ExtendedTextBox.ExtTextBox txtAdditionalNote;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox txtSection;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.Button cmdSelectFile;
        private System.Windows.Forms.TextBox txtExcelFileName;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cmdSaveMarks;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cmbDocuments;
        private ExtendedTextBox.ExtTextBox txtStudentreport;
        private ExtendedTextBox.ExtTextBox txtTextOrPointer;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button cmdEmailRefreshStudents;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ListView lstEmailSendSelection;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox txtEmailSubject;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkEmailDryRun;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbComponentComment;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button cmdGetData;
        private System.Windows.Forms.Label lblSourceData;
        private System.Windows.Forms.Button cmdSourceDataFile;
        private System.Windows.Forms.TextBox txtSourceDataFile;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkImportComponents;
        private System.Windows.Forms.CheckBox chkCommentLib;
        private System.Windows.Forms.FlowLayoutPanel flComponents;
        private System.Windows.Forms.Button cmdReload;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Button button4;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button cmdSelectAll;
        private System.Windows.Forms.PictureBox StudImage;
        private System.Windows.Forms.CheckBox chkSendModerationNotice;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private ExtendedTextBox.ExtTextBox txtEmailBody;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox txtEmailPreview;
        private System.Windows.Forms.Button cmdSaveEmail;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btnCompleteData;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.CheckBox chkImportSubmissions;
		private System.Windows.Forms.TextBox txtSourceTurnitin;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.TextBox txtReport;
		private System.Windows.Forms.TabControl tabControl3;
		private System.Windows.Forms.TabPage tabPage6;
		private System.Windows.Forms.TabPage tabPage7;
		private System.Windows.Forms.TabPage tabPage8;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Button button10;
		private Button BtnOpenFolder;
		private TabPage tabPage9;
		private Button BtnExportExcel;
		private Button button11;
		private Button button12;
		private Button BtnImportExcel;
		private TextBox TxtExcelComponentSource;
		private CheckBox ChkAutoStat;
		private Label LblMark;
	}
}

