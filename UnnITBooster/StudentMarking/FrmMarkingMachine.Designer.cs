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
			this.LblOverlap = new System.Windows.Forms.Label();
			this.button12 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.panel1 = new System.Windows.Forms.Panel();
			this.cmdReportSizeDecrease = new System.Windows.Forms.Button();
			this.cmdReportSizeIncrease = new System.Windows.Forms.Button();
			this.cmdWrap = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.ChkCommNumber = new System.Windows.Forms.CheckBox();
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
			this.BtnEditLast = new System.Windows.Forms.Button();
			this.BtnShowStudentStat = new System.Windows.Forms.Button();
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
			this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.cmdEmailRefreshStudents = new System.Windows.Forms.Button();
			this.cmdSelectAll = new System.Windows.Forms.Button();
			this.NudOverlap = new System.Windows.Forms.NumericUpDown();
			this.chkShowDelegate = new System.Windows.Forms.CheckBox();
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.ChkExclude0 = new System.Windows.Forms.CheckBox();
			this.NudMarkOffset = new System.Windows.Forms.NumericUpDown();
			this.label9 = new System.Windows.Forms.Label();
			this.ChkRoundupX9 = new System.Windows.Forms.CheckBox();
			this.ChkShowLabels = new System.Windows.Forms.CheckBox();
			this.CmbGrouping = new System.Windows.Forms.ComboBox();
			this.ChkIncludeNoMark = new System.Windows.Forms.CheckBox();
			this.ChkOddRows = new System.Windows.Forms.CheckBox();
			this.ChkEvenRows = new System.Windows.Forms.CheckBox();
			this.button4 = new System.Windows.Forms.Button();
			this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.txtReport = new System.Windows.Forms.TextBox();
			this.tabControl3 = new System.Windows.Forms.TabControl();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.txtElpCode = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
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
			this.tabPage10 = new System.Windows.Forms.TabPage();
			this.label12 = new System.Windows.Forms.Label();
			this.TxtScaleFactor = new System.Windows.Forms.TextBox();
			this.TxtMergeReportFolder = new System.Windows.Forms.TextBox();
			this.BtnMergeReport = new System.Windows.Forms.Button();
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
			this.panel1.SuspendLayout();
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
			((System.ComponentModel.ISupportInitialize)(this.NudOverlap)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.StudImage)).BeginInit();
			this.tableLayoutPanel3.SuspendLayout();
			this.tabControl2.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.NudMarkOffset)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.tabControl3.SuspendLayout();
			this.tabPage6.SuspendLayout();
			this.tabPage7.SuspendLayout();
			this.tabPage8.SuspendLayout();
			this.tabPage9.SuspendLayout();
			this.tabPage10.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtStudentId
			// 
			this.txtStudentId.Dock = System.Windows.Forms.DockStyle.Top;
			this.txtStudentId.Location = new System.Drawing.Point(0, 13);
			this.txtStudentId.Name = "txtStudentId";
			this.txtStudentId.Size = new System.Drawing.Size(316, 20);
			this.txtStudentId.TabIndex = 0;
			this.txtStudentId.TabStop = false;
			this.txtStudentId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStudentId_KeyDown);
			// 
			// txtSearch
			// 
			this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSearch.Location = new System.Drawing.Point(0, 13);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(216, 29);
			this.txtSearch.TabIndex = 3;
			this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
			// 
			// cmdAdd
			// 
			this.cmdAdd.Location = new System.Drawing.Point(105, 500);
			this.cmdAdd.Name = "cmdAdd";
			this.cmdAdd.Size = new System.Drawing.Size(75, 23);
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
			this.txtLibReport.Location = new System.Drawing.Point(0, 40);
			this.txtLibReport.Multiline = true;
			this.txtLibReport.Name = "txtLibReport";
			this.txtLibReport.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtLibReport.Size = new System.Drawing.Size(304, 435);
			this.txtLibReport.TabIndex = 2;
			this.txtLibReport.TabStop = false;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(3, 3);
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
			this.splitContainer1.Size = new System.Drawing.Size(1083, 539);
			this.splitContainer1.SplitterDistance = 316;
			this.splitContainer1.TabIndex = 8;
			this.splitContainer1.TabStop = false;
			// 
			// splitContainer4
			// 
			this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer4.Location = new System.Drawing.Point(0, 58);
			this.splitContainer4.Margin = new System.Windows.Forms.Padding(2);
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
			this.splitContainer4.Size = new System.Drawing.Size(316, 481);
			this.splitContainer4.SplitterDistance = 213;
			this.splitContainer4.SplitterWidth = 3;
			this.splitContainer4.TabIndex = 15;
			// 
			// txtStudentreport
			// 
			this.txtStudentreport.AcceptsReturn = true;
			this.txtStudentreport.AcceptsTab = true;
			this.txtStudentreport.ChangedColour = System.Drawing.Color.Empty;
			this.txtStudentreport.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtStudentreport.Location = new System.Drawing.Point(0, 0);
			this.txtStudentreport.Margin = new System.Windows.Forms.Padding(4);
			this.txtStudentreport.MaxLength = 0;
			this.txtStudentreport.Name = "txtStudentreport";
			this.txtStudentreport.OriginalText = "";
			this.txtStudentreport.Size = new System.Drawing.Size(316, 213);
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
			this.flComponents.Location = new System.Drawing.Point(0, 47);
			this.flComponents.Margin = new System.Windows.Forms.Padding(2);
			this.flComponents.Name = "flComponents";
			this.flComponents.Size = new System.Drawing.Size(316, 196);
			this.flComponents.TabIndex = 13;
			// 
			// LblMark
			// 
			this.LblMark.Dock = System.Windows.Forms.DockStyle.Top;
			this.LblMark.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LblMark.Location = new System.Drawing.Point(0, 0);
			this.LblMark.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.LblMark.Name = "LblMark";
			this.LblMark.Size = new System.Drawing.Size(316, 47);
			this.LblMark.TabIndex = 0;
			this.LblMark.Text = "-";
			this.LblMark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cmdSaveMarks
			// 
			this.cmdSaveMarks.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.cmdSaveMarks.Location = new System.Drawing.Point(0, 243);
			this.cmdSaveMarks.Name = "cmdSaveMarks";
			this.cmdSaveMarks.Size = new System.Drawing.Size(316, 22);
			this.cmdSaveMarks.TabIndex = 6;
			this.cmdSaveMarks.Text = "Ok";
			this.cmdSaveMarks.UseVisualStyleBackColor = true;
			this.cmdSaveMarks.Click += new System.EventHandler(this.CmdSaveMarks_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.LblOverlap);
			this.panel2.Controls.Add(this.button12);
			this.panel2.Controls.Add(this.button6);
			this.panel2.Controls.Add(this.button5);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 33);
			this.panel2.Margin = new System.Windows.Forms.Padding(2);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(316, 25);
			this.panel2.TabIndex = 17;
			// 
			// LblOverlap
			// 
			this.LblOverlap.AutoSize = true;
			this.LblOverlap.Location = new System.Drawing.Point(65, 5);
			this.LblOverlap.Name = "LblOverlap";
			this.LblOverlap.Size = new System.Drawing.Size(10, 13);
			this.LblOverlap.TabIndex = 3;
			this.LblOverlap.Text = "-";
			// 
			// button12
			// 
			this.button12.Location = new System.Drawing.Point(4, 2);
			this.button12.Margin = new System.Windows.Forms.Padding(2);
			this.button12.Name = "button12";
			this.button12.Size = new System.Drawing.Size(56, 19);
			this.button12.TabIndex = 2;
			this.button12.Text = "html";
			this.button12.UseVisualStyleBackColor = true;
			this.button12.Click += new System.EventHandler(this.button12_Click);
			// 
			// button6
			// 
			this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button6.Location = new System.Drawing.Point(196, 2);
			this.button6.Margin = new System.Windows.Forms.Padding(2);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(56, 19);
			this.button6.TabIndex = 0;
			this.button6.Text = "-";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button5
			// 
			this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button5.Location = new System.Drawing.Point(256, 2);
			this.button5.Margin = new System.Windows.Forms.Padding(2);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(56, 19);
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
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(47, 13);
			this.label6.TabIndex = 12;
			this.label6.Text = "Student:";
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.txtLibReport);
			this.splitContainer2.Panel1.Controls.Add(this.panel1);
			this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel1);
			this.splitContainer2.Panel2.Controls.Add(this.label7);
			this.splitContainer2.Size = new System.Drawing.Size(763, 539);
			this.splitContainer2.SplitterDistance = 304;
			this.splitContainer2.TabIndex = 0;
			this.splitContainer2.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.txtSearch);
			this.panel1.Controls.Add(this.cmdReportSizeDecrease);
			this.panel1.Controls.Add(this.cmdReportSizeIncrease);
			this.panel1.Controls.Add(this.cmdWrap);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(304, 40);
			this.panel1.TabIndex = 16;
			// 
			// cmdReportSizeDecrease
			// 
			this.cmdReportSizeDecrease.Dock = System.Windows.Forms.DockStyle.Right;
			this.cmdReportSizeDecrease.Location = new System.Drawing.Point(216, 13);
			this.cmdReportSizeDecrease.Name = "cmdReportSizeDecrease";
			this.cmdReportSizeDecrease.Size = new System.Drawing.Size(24, 27);
			this.cmdReportSizeDecrease.TabIndex = 17;
			this.cmdReportSizeDecrease.Text = "-";
			this.cmdReportSizeDecrease.UseVisualStyleBackColor = true;
			this.cmdReportSizeDecrease.Click += new System.EventHandler(this.cmdReportSizeDecrease_Click);
			// 
			// cmdReportSizeIncrease
			// 
			this.cmdReportSizeIncrease.Dock = System.Windows.Forms.DockStyle.Right;
			this.cmdReportSizeIncrease.Location = new System.Drawing.Point(240, 13);
			this.cmdReportSizeIncrease.Name = "cmdReportSizeIncrease";
			this.cmdReportSizeIncrease.Size = new System.Drawing.Size(24, 27);
			this.cmdReportSizeIncrease.TabIndex = 16;
			this.cmdReportSizeIncrease.Text = "+";
			this.cmdReportSizeIncrease.UseVisualStyleBackColor = true;
			this.cmdReportSizeIncrease.Click += new System.EventHandler(this.cmdReportSizeIncrease_Click);
			// 
			// cmdWrap
			// 
			this.cmdWrap.Dock = System.Windows.Forms.DockStyle.Right;
			this.cmdWrap.Location = new System.Drawing.Point(264, 13);
			this.cmdWrap.Name = "cmdWrap";
			this.cmdWrap.Size = new System.Drawing.Size(40, 27);
			this.cmdWrap.TabIndex = 15;
			this.cmdWrap.Text = "wrap";
			this.cmdWrap.UseVisualStyleBackColor = true;
			this.cmdWrap.Click += new System.EventHandler(this.cmdWrap_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Dock = System.Windows.Forms.DockStyle.Top;
			this.label8.Location = new System.Drawing.Point(0, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(44, 13);
			this.label8.TabIndex = 14;
			this.label8.Text = "Search:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.ChkCommNumber);
			this.groupBox2.Controls.Add(this.ChkAutoStat);
			this.groupBox2.Controls.Add(this.button2);
			this.groupBox2.Controls.Add(this.cmbDocuments);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox2.Location = new System.Drawing.Point(0, 475);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(304, 64);
			this.groupBox2.TabIndex = 15;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Documents downloaded";
			// 
			// ChkCommNumber
			// 
			this.ChkCommNumber.AutoSize = true;
			this.ChkCommNumber.Location = new System.Drawing.Point(81, 42);
			this.ChkCommNumber.Margin = new System.Windows.Forms.Padding(2);
			this.ChkCommNumber.Name = "ChkCommNumber";
			this.ChkCommNumber.Size = new System.Drawing.Size(117, 17);
			this.ChkCommNumber.TabIndex = 4;
			this.ChkCommNumber.Text = "Add Comm Number";
			this.ChkCommNumber.UseVisualStyleBackColor = true;
			// 
			// ChkAutoStat
			// 
			this.ChkAutoStat.AutoSize = true;
			this.ChkAutoStat.Location = new System.Drawing.Point(7, 41);
			this.ChkAutoStat.Margin = new System.Windows.Forms.Padding(2);
			this.ChkAutoStat.Name = "ChkAutoStat";
			this.ChkAutoStat.Size = new System.Drawing.Size(68, 17);
			this.ChkAutoStat.TabIndex = 3;
			this.ChkAutoStat.Text = "Auto stat";
			this.ChkAutoStat.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Location = new System.Drawing.Point(234, 16);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(65, 23);
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
			this.cmbDocuments.Location = new System.Drawing.Point(7, 18);
			this.cmbDocuments.Name = "cmbDocuments";
			this.cmbDocuments.Size = new System.Drawing.Size(221, 21);
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
			this.tableLayoutPanel1.Controls.Add(this.BtnEditLast, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.BtnShowStudentStat, 0, 6);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 13);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 7;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(455, 526);
			this.tableLayoutPanel1.TabIndex = 8;
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 450);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(29, 13);
			this.label4.TabIndex = 19;
			this.label4.Text = "Area";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 254);
			this.label2.Margin = new System.Windows.Forms.Padding(6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 13);
			this.label2.TabIndex = 17;
			this.label2.Text = "specific comment";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// txtTextOrPointer
			// 
			this.txtTextOrPointer.AcceptsReturn = true;
			this.txtTextOrPointer.AcceptsTab = false;
			this.txtTextOrPointer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTextOrPointer.ChangedColour = System.Drawing.Color.Empty;
			this.txtTextOrPointer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTextOrPointer.Location = new System.Drawing.Point(107, 57);
			this.txtTextOrPointer.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.txtTextOrPointer.MaxLength = 0;
			this.txtTextOrPointer.Name = "txtTextOrPointer";
			this.txtTextOrPointer.OriginalText = "";
			this.txtTextOrPointer.Size = new System.Drawing.Size(343, 186);
			this.txtTextOrPointer.SpellCheck = true;
			this.txtTextOrPointer.TabIndex = 4;
			this.txtTextOrPointer.TextCase = System.Windows.Forms.CharacterCasing.Normal;
			this.txtTextOrPointer.TextType = ExtendedTextBox.ExtTextBox.TextTypes.String;
			this.txtTextOrPointer.Wrapping = true;
			this.txtTextOrPointer.OnCtrlEnter += new ExtendedTextBox.ExtTextBox.CtrlKeyPressed(this.DoAdd);
			this.txtTextOrPointer.OnCtrlTab += new ExtendedTextBox.ExtTextBox.CtrlKeyPressed(this.txtTextOrPointer_OnCtrlTab);
			this.txtTextOrPointer.OnCtrlKey += new ExtendedTextBox.ExtTextBox.CtrlKeyboardPressed(this.txtTextOrPointer_OnCtrlKey);
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
			this.txtAdditionalNote.Location = new System.Drawing.Point(107, 253);
			this.txtAdditionalNote.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.txtAdditionalNote.MaxLength = 0;
			this.txtAdditionalNote.Name = "txtAdditionalNote";
			this.txtAdditionalNote.OriginalText = "";
			this.txtAdditionalNote.Size = new System.Drawing.Size(343, 186);
			this.txtAdditionalNote.SpellCheck = true;
			this.txtAdditionalNote.TabIndex = 5;
			this.txtAdditionalNote.TextCase = System.Windows.Forms.CharacterCasing.Normal;
			this.txtAdditionalNote.TextType = ExtendedTextBox.ExtTextBox.TextTypes.String;
			this.txtAdditionalNote.Wrapping = true;
			this.txtAdditionalNote.OnCtrlEnter += new ExtendedTextBox.ExtTextBox.CtrlKeyPressed(this.DoAdd);
			this.txtAdditionalNote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTextOrPointer_KeyUp);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 58);
			this.label1.Margin = new System.Windows.Forms.Padding(6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 10;
			this.label1.Text = "ptr/text";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// txtArea
			// 
			this.txtArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtArea.Location = new System.Drawing.Point(105, 447);
			this.txtArea.Name = "txtArea";
			this.txtArea.Size = new System.Drawing.Size(347, 20);
			this.txtArea.TabIndex = 12;
			this.txtArea.TabStop = false;
			// 
			// label11
			// 
			this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(3, 477);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(61, 13);
			this.label11.TabIndex = 20;
			this.label11.Text = "Component";
			// 
			// cmbComponentComment
			// 
			this.cmbComponentComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbComponentComment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbComponentComment.FormattingEnabled = true;
			this.cmbComponentComment.Location = new System.Drawing.Point(105, 473);
			this.cmbComponentComment.Name = "cmbComponentComment";
			this.cmbComponentComment.Size = new System.Drawing.Size(347, 21);
			this.cmbComponentComment.TabIndex = 21;
			this.cmbComponentComment.TabStop = false;
			// 
			// txtSection
			// 
			this.txtSection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSection.Location = new System.Drawing.Point(105, 3);
			this.txtSection.Name = "txtSection";
			this.txtSection.Size = new System.Drawing.Size(347, 21);
			this.txtSection.TabIndex = 11;
			this.txtSection.TabStop = false;
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 7);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 13);
			this.label3.TabIndex = 18;
			this.label3.Text = "Section";
			// 
			// button11
			// 
			this.button11.Dock = System.Windows.Forms.DockStyle.Fill;
			this.button11.Location = new System.Drawing.Point(105, 30);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(347, 19);
			this.button11.TabIndex = 22;
			this.button11.Text = "Section rotation";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new System.EventHandler(this.button11_Click);
			// 
			// BtnEditLast
			// 
			this.BtnEditLast.Location = new System.Drawing.Point(3, 30);
			this.BtnEditLast.Name = "BtnEditLast";
			this.BtnEditLast.Size = new System.Drawing.Size(69, 19);
			this.BtnEditLast.TabIndex = 23;
			this.BtnEditLast.Text = "Edit last";
			this.BtnEditLast.UseVisualStyleBackColor = true;
			this.BtnEditLast.Click += new System.EventHandler(this.BtnEditLast_Click);
			// 
			// BtnShowStudentStat
			// 
			this.BtnShowStudentStat.Location = new System.Drawing.Point(3, 500);
			this.BtnShowStudentStat.Name = "BtnShowStudentStat";
			this.BtnShowStudentStat.Size = new System.Drawing.Size(69, 23);
			this.BtnShowStudentStat.TabIndex = 24;
			this.BtnShowStudentStat.Text = "Stat";
			this.BtnShowStudentStat.UseVisualStyleBackColor = true;
			this.BtnShowStudentStat.Click += new System.EventHandler(this.BtnShowStudentStat_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Dock = System.Windows.Forms.DockStyle.Top;
			this.label7.Location = new System.Drawing.Point(0, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(51, 13);
			this.label7.TabIndex = 13;
			this.label7.Text = "Comment";
			// 
			// cmdSelectFile
			// 
			this.cmdSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdSelectFile.Location = new System.Drawing.Point(1010, 5);
			this.cmdSelectFile.Name = "cmdSelectFile";
			this.cmdSelectFile.Size = new System.Drawing.Size(24, 22);
			this.cmdSelectFile.TabIndex = 10;
			this.cmdSelectFile.TabStop = false;
			this.cmdSelectFile.Text = "...";
			this.cmdSelectFile.UseVisualStyleBackColor = true;
			this.cmdSelectFile.Click += new System.EventHandler(this.cmdSelectFile_Click);
			// 
			// txtExcelFileName
			// 
			this.txtExcelFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtExcelFileName.Location = new System.Drawing.Point(63, 5);
			this.txtExcelFileName.Multiline = true;
			this.txtExcelFileName.Name = "txtExcelFileName";
			this.txtExcelFileName.Size = new System.Drawing.Size(941, 22);
			this.txtExcelFileName.TabIndex = 9;
			this.txtExcelFileName.TabStop = false;
			this.txtExcelFileName.TextChanged += new System.EventHandler(this.txtExcelFileName_TextChanged);
			// 
			// cmdReload
			// 
			this.cmdReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdReload.Location = new System.Drawing.Point(1040, 5);
			this.cmdReload.Name = "cmdReload";
			this.cmdReload.Size = new System.Drawing.Size(24, 22);
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
			this.label5.Location = new System.Drawing.Point(3, 9);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(42, 13);
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
			this.tabControl1.Location = new System.Drawing.Point(0, 32);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1097, 571);
			this.tabControl1.TabIndex = 12;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.splitContainer1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(1089, 545);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Marking";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.splitContainer3);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(1089, 545);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Emailing";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// splitContainer3
			// 
			this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer3.Location = new System.Drawing.Point(3, 3);
			this.splitContainer3.Name = "splitContainer3";
			// 
			// splitContainer3.Panel1
			// 
			this.splitContainer3.Panel1.Controls.Add(this.splitContainer5);
			// 
			// splitContainer3.Panel2
			// 
			this.splitContainer3.Panel2.Controls.Add(this.tableLayoutPanel3);
			this.splitContainer3.Size = new System.Drawing.Size(1083, 539);
			this.splitContainer3.SplitterDistance = 431;
			this.splitContainer3.TabIndex = 3;
			// 
			// splitContainer5
			// 
			this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer5.Location = new System.Drawing.Point(0, 0);
			this.splitContainer5.Margin = new System.Windows.Forms.Padding(2);
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
			this.splitContainer5.Size = new System.Drawing.Size(431, 539);
			this.splitContainer5.SplitterDistance = 240;
			this.splitContainer5.SplitterWidth = 3;
			this.splitContainer5.TabIndex = 14;
			// 
			// lstEmailSendSelection
			// 
			this.lstEmailSendSelection.CheckBoxes = true;
			this.lstEmailSendSelection.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader7,
            this.columnHeader5,
            this.columnHeader6});
			this.lstEmailSendSelection.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstEmailSendSelection.FullRowSelect = true;
			this.lstEmailSendSelection.GridLines = true;
			this.lstEmailSendSelection.HideSelection = false;
			this.lstEmailSendSelection.Location = new System.Drawing.Point(0, 30);
			this.lstEmailSendSelection.Name = "lstEmailSendSelection";
			this.lstEmailSendSelection.Size = new System.Drawing.Size(431, 210);
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
			// columnHeader7
			// 
			this.columnHeader7.Text = "Last update";
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "NumComments";
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Similarity";
			this.columnHeader6.Width = 300;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 4;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.99999F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
			this.tableLayoutPanel2.Controls.Add(this.cmdEmailRefreshStudents, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.cmdSelectAll, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.NudOverlap, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.chkShowDelegate, 3, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.Size = new System.Drawing.Size(431, 30);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// cmdEmailRefreshStudents
			// 
			this.cmdEmailRefreshStudents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdEmailRefreshStudents.Location = new System.Drawing.Point(3, 3);
			this.cmdEmailRefreshStudents.Name = "cmdEmailRefreshStudents";
			this.cmdEmailRefreshStudents.Size = new System.Drawing.Size(105, 23);
			this.cmdEmailRefreshStudents.TabIndex = 2;
			this.cmdEmailRefreshStudents.Text = "Refresh";
			this.cmdEmailRefreshStudents.UseVisualStyleBackColor = true;
			this.cmdEmailRefreshStudents.Click += new System.EventHandler(this.cmdEmailRefreshStudents_Click);
			// 
			// cmdSelectAll
			// 
			this.cmdSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdSelectAll.Location = new System.Drawing.Point(114, 3);
			this.cmdSelectAll.Name = "cmdSelectAll";
			this.cmdSelectAll.Size = new System.Drawing.Size(106, 23);
			this.cmdSelectAll.TabIndex = 4;
			this.cmdSelectAll.Text = "All";
			this.cmdSelectAll.UseVisualStyleBackColor = true;
			this.cmdSelectAll.Click += new System.EventHandler(this.cmdSelectAll_Click);
			// 
			// NudOverlap
			// 
			this.NudOverlap.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.NudOverlap.Location = new System.Drawing.Point(243, 5);
			this.NudOverlap.Name = "NudOverlap";
			this.NudOverlap.Size = new System.Drawing.Size(60, 20);
			this.NudOverlap.TabIndex = 5;
			this.NudOverlap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.NudOverlap.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
			// 
			// chkShowDelegate
			// 
			this.chkShowDelegate.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.chkShowDelegate.AutoSize = true;
			this.chkShowDelegate.Location = new System.Drawing.Point(342, 6);
			this.chkShowDelegate.Name = "chkShowDelegate";
			this.chkShowDelegate.Size = new System.Drawing.Size(69, 17);
			this.chkShowDelegate.TabIndex = 6;
			this.chkShowDelegate.Text = "Delegate";
			this.chkShowDelegate.UseVisualStyleBackColor = true;
			// 
			// StudImage
			// 
			this.StudImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.StudImage.Location = new System.Drawing.Point(0, 0);
			this.StudImage.Margin = new System.Windows.Forms.Padding(2);
			this.StudImage.Name = "StudImage";
			this.StudImage.Size = new System.Drawing.Size(431, 296);
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
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 4;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(648, 539);
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
			this.tabControl2.Location = new System.Drawing.Point(2, 77);
			this.tabControl2.Margin = new System.Windows.Forms.Padding(2);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(644, 460);
			this.tabControl2.TabIndex = 7;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.button1);
			this.tabPage4.Controls.Add(this.cmdSaveEmail);
			this.tabPage4.Controls.Add(this.txtEmailBody);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Margin = new System.Windows.Forms.Padding(2);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(2);
			this.tabPage4.Size = new System.Drawing.Size(636, 434);
			this.tabPage4.TabIndex = 0;
			this.tabPage4.Text = "Template";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button1.Location = new System.Drawing.Point(5, 405);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(129, 23);
			this.button1.TabIndex = 9;
			this.button1.Text = "Default";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// cmdSaveEmail
			// 
			this.cmdSaveEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cmdSaveEmail.Location = new System.Drawing.Point(140, 405);
			this.cmdSaveEmail.Name = "cmdSaveEmail";
			this.cmdSaveEmail.Size = new System.Drawing.Size(129, 23);
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
			this.txtEmailBody.Location = new System.Drawing.Point(4, 7);
			this.txtEmailBody.Margin = new System.Windows.Forms.Padding(6);
			this.txtEmailBody.MaxLength = 0;
			this.txtEmailBody.Name = "txtEmailBody";
			this.txtEmailBody.OriginalText = "";
			this.txtEmailBody.Size = new System.Drawing.Size(629, 389);
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
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Margin = new System.Windows.Forms.Padding(2);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new System.Windows.Forms.Padding(2);
			this.tabPage5.Size = new System.Drawing.Size(636, 434);
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
			this.txtEmailPreview.Location = new System.Drawing.Point(5, 6);
			this.txtEmailPreview.Multiline = true;
			this.txtEmailPreview.Name = "txtEmailPreview";
			this.txtEmailPreview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtEmailPreview.Size = new System.Drawing.Size(629, 418);
			this.txtEmailPreview.TabIndex = 7;
			this.txtEmailPreview.TabStop = false;
			this.txtEmailPreview.Text = "Dear {SUB_FirstName}, \r\nThe marking and moderation process for BE1178 has been co" +
    "mpleted a few days ago. \r\nPlease find your feedback after my signature.\r\nBest re" +
    "gards, \r\nClaudio \r\n\r\n{MarkReport}";
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.button3.Location = new System.Drawing.Point(144, 52);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(501, 20);
			this.button3.TabIndex = 0;
			this.button3.Text = "Send";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// chkSendModerationNotice
			// 
			this.chkSendModerationNotice.AutoSize = true;
			this.chkSendModerationNotice.Location = new System.Drawing.Point(3, 52);
			this.chkSendModerationNotice.Name = "chkSendModerationNotice";
			this.chkSendModerationNotice.Size = new System.Drawing.Size(135, 17);
			this.chkSendModerationNotice.TabIndex = 5;
			this.chkSendModerationNotice.Text = "Add Moderation Notice";
			this.chkSendModerationNotice.UseVisualStyleBackColor = true;
			// 
			// txtEmailSubject
			// 
			this.txtEmailSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtEmailSubject.Location = new System.Drawing.Point(144, 3);
			this.txtEmailSubject.Name = "txtEmailSubject";
			this.txtEmailSubject.Size = new System.Drawing.Size(501, 20);
			this.txtEmailSubject.TabIndex = 3;
			// 
			// label10
			// 
			this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(3, 6);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(43, 13);
			this.label10.TabIndex = 2;
			this.label10.Text = "Subject";
			// 
			// chkEmailDryRun
			// 
			this.chkEmailDryRun.AutoSize = true;
			this.chkEmailDryRun.Checked = true;
			this.chkEmailDryRun.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkEmailDryRun.Location = new System.Drawing.Point(3, 29);
			this.chkEmailDryRun.Name = "chkEmailDryRun";
			this.chkEmailDryRun.Size = new System.Drawing.Size(65, 17);
			this.chkEmailDryRun.TabIndex = 4;
			this.chkEmailDryRun.Text = "Dry Run";
			this.chkEmailDryRun.UseVisualStyleBackColor = true;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.groupBox1);
			this.tabPage3.Controls.Add(this.ChkShowLabels);
			this.tabPage3.Controls.Add(this.CmbGrouping);
			this.tabPage3.Controls.Add(this.ChkIncludeNoMark);
			this.tabPage3.Controls.Add(this.ChkOddRows);
			this.tabPage3.Controls.Add(this.ChkEvenRows);
			this.tabPage3.Controls.Add(this.button4);
			this.tabPage3.Controls.Add(this.zedGraphControl1);
			this.tabPage3.Controls.Add(this.groupBox3);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(2);
			this.tabPage3.Size = new System.Drawing.Size(1089, 545);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Tools";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.ChkExclude0);
			this.groupBox1.Controls.Add(this.NudMarkOffset);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.ChkRoundupX9);
			this.groupBox1.Location = new System.Drawing.Point(11, 390);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(113, 94);
			this.groupBox1.TabIndex = 29;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Mark tweak";
			// 
			// ChkExclude0
			// 
			this.ChkExclude0.AutoSize = true;
			this.ChkExclude0.Checked = true;
			this.ChkExclude0.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ChkExclude0.Location = new System.Drawing.Point(9, 68);
			this.ChkExclude0.Name = "ChkExclude0";
			this.ChkExclude0.Size = new System.Drawing.Size(78, 17);
			this.ChkExclude0.TabIndex = 28;
			this.ChkExclude0.Text = "Exclude 0s";
			this.ChkExclude0.UseVisualStyleBackColor = true;
			// 
			// NudMarkOffset
			// 
			this.NudMarkOffset.Location = new System.Drawing.Point(64, 19);
			this.NudMarkOffset.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.NudMarkOffset.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
			this.NudMarkOffset.Name = "NudMarkOffset";
			this.NudMarkOffset.Size = new System.Drawing.Size(43, 20);
			this.NudMarkOffset.TabIndex = 24;
			this.NudMarkOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(6, 21);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(35, 13);
			this.label9.TabIndex = 25;
			this.label9.Text = "Offset";
			// 
			// ChkRoundupX9
			// 
			this.ChkRoundupX9.AutoSize = true;
			this.ChkRoundupX9.Checked = true;
			this.ChkRoundupX9.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ChkRoundupX9.Location = new System.Drawing.Point(9, 45);
			this.ChkRoundupX9.Name = "ChkRoundupX9";
			this.ChkRoundupX9.Size = new System.Drawing.Size(83, 17);
			this.ChkRoundupX9.TabIndex = 27;
			this.ChkRoundupX9.Text = "Roundup *9";
			this.ChkRoundupX9.UseVisualStyleBackColor = true;
			// 
			// ChkShowLabels
			// 
			this.ChkShowLabels.AutoSize = true;
			this.ChkShowLabels.Location = new System.Drawing.Point(11, 520);
			this.ChkShowLabels.Name = "ChkShowLabels";
			this.ChkShowLabels.Size = new System.Drawing.Size(83, 17);
			this.ChkShowLabels.TabIndex = 28;
			this.ChkShowLabels.Text = "Show labels";
			this.ChkShowLabels.UseVisualStyleBackColor = true;
			// 
			// CmbGrouping
			// 
			this.CmbGrouping.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CmbGrouping.FormattingEnabled = true;
			this.CmbGrouping.Location = new System.Drawing.Point(11, 363);
			this.CmbGrouping.Name = "CmbGrouping";
			this.CmbGrouping.Size = new System.Drawing.Size(113, 21);
			this.CmbGrouping.TabIndex = 26;
			// 
			// ChkIncludeNoMark
			// 
			this.ChkIncludeNoMark.AutoSize = true;
			this.ChkIncludeNoMark.Checked = true;
			this.ChkIncludeNoMark.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ChkIncludeNoMark.Location = new System.Drawing.Point(11, 497);
			this.ChkIncludeNoMark.Name = "ChkIncludeNoMark";
			this.ChkIncludeNoMark.Size = new System.Drawing.Size(116, 17);
			this.ChkIncludeNoMark.TabIndex = 23;
			this.ChkIncludeNoMark.Text = "Show missing mark";
			this.ChkIncludeNoMark.UseVisualStyleBackColor = true;
			// 
			// ChkOddRows
			// 
			this.ChkOddRows.AutoSize = true;
			this.ChkOddRows.Checked = true;
			this.ChkOddRows.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ChkOddRows.Location = new System.Drawing.Point(11, 321);
			this.ChkOddRows.Name = "ChkOddRows";
			this.ChkOddRows.Size = new System.Drawing.Size(63, 17);
			this.ChkOddRows.TabIndex = 21;
			this.ChkOddRows.Text = "Odd Ids";
			this.ChkOddRows.UseVisualStyleBackColor = true;
			// 
			// ChkEvenRows
			// 
			this.ChkEvenRows.AutoSize = true;
			this.ChkEvenRows.Checked = true;
			this.ChkEvenRows.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ChkEvenRows.Location = new System.Drawing.Point(11, 344);
			this.ChkEvenRows.Name = "ChkEvenRows";
			this.ChkEvenRows.Size = new System.Drawing.Size(68, 17);
			this.ChkEvenRows.TabIndex = 20;
			this.ChkEvenRows.Text = "Even Ids";
			this.ChkEvenRows.UseVisualStyleBackColor = true;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(6, 260);
			this.button4.Margin = new System.Windows.Forms.Padding(2);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(119, 56);
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
			this.zedGraphControl1.Location = new System.Drawing.Point(131, 260);
			this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(4);
			this.zedGraphControl1.Name = "zedGraphControl1";
			this.zedGraphControl1.ScrollGrace = 0D;
			this.zedGraphControl1.ScrollMaxX = 0D;
			this.zedGraphControl1.ScrollMaxY = 0D;
			this.zedGraphControl1.ScrollMaxY2 = 0D;
			this.zedGraphControl1.ScrollMinX = 0D;
			this.zedGraphControl1.ScrollMinY = 0D;
			this.zedGraphControl1.ScrollMinY2 = 0D;
			this.zedGraphControl1.Size = new System.Drawing.Size(672, 276);
			this.zedGraphControl1.TabIndex = 18;
			this.zedGraphControl1.UseExtendedPrintDialog = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.txtReport);
			this.groupBox3.Controls.Add(this.tabControl3);
			this.groupBox3.Location = new System.Drawing.Point(6, 12);
			this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox3.Size = new System.Drawing.Size(796, 230);
			this.groupBox3.TabIndex = 17;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Import data";
			// 
			// txtReport
			// 
			this.txtReport.Location = new System.Drawing.Point(444, 40);
			this.txtReport.Multiline = true;
			this.txtReport.Name = "txtReport";
			this.txtReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtReport.Size = new System.Drawing.Size(347, 181);
			this.txtReport.TabIndex = 26;
			// 
			// tabControl3
			// 
			this.tabControl3.Controls.Add(this.tabPage6);
			this.tabControl3.Controls.Add(this.tabPage7);
			this.tabControl3.Controls.Add(this.tabPage8);
			this.tabControl3.Controls.Add(this.tabPage9);
			this.tabControl3.Controls.Add(this.tabPage10);
			this.tabControl3.Location = new System.Drawing.Point(5, 18);
			this.tabControl3.Name = "tabControl3";
			this.tabControl3.SelectedIndex = 0;
			this.tabControl3.Size = new System.Drawing.Size(433, 207);
			this.tabControl3.TabIndex = 26;
			// 
			// tabPage6
			// 
			this.tabPage6.Controls.Add(this.txtElpCode);
			this.tabPage6.Controls.Add(this.label13);
			this.tabPage6.Controls.Add(this.txtSourceTurnitin);
			this.tabPage6.Controls.Add(this.button8);
			this.tabPage6.Controls.Add(this.btnCompleteData);
			this.tabPage6.Controls.Add(this.button7);
			this.tabPage6.Location = new System.Drawing.Point(4, 22);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage6.Size = new System.Drawing.Size(425, 181);
			this.tabPage6.TabIndex = 0;
			this.tabPage6.Text = "Gradebook";
			this.tabPage6.UseVisualStyleBackColor = true;
			// 
			// txtElpCode
			// 
			this.txtElpCode.Location = new System.Drawing.Point(156, 68);
			this.txtElpCode.Name = "txtElpCode";
			this.txtElpCode.Size = new System.Drawing.Size(230, 20);
			this.txtElpCode.TabIndex = 27;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(23, 71);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(48, 13);
			this.label13.TabIndex = 26;
			this.label13.Text = "elp code";
			// 
			// txtSourceTurnitin
			// 
			this.txtSourceTurnitin.Location = new System.Drawing.Point(23, 6);
			this.txtSourceTurnitin.Multiline = true;
			this.txtSourceTurnitin.Name = "txtSourceTurnitin";
			this.txtSourceTurnitin.Size = new System.Drawing.Size(337, 56);
			this.txtSourceTurnitin.TabIndex = 24;
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(366, 40);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(25, 22);
			this.button8.TabIndex = 25;
			this.button8.Text = "...";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// btnCompleteData
			// 
			this.btnCompleteData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCompleteData.Location = new System.Drawing.Point(23, 150);
			this.btnCompleteData.Margin = new System.Windows.Forms.Padding(2);
			this.btnCompleteData.Name = "btnCompleteData";
			this.btnCompleteData.Size = new System.Drawing.Size(365, 26);
			this.btnCompleteData.TabIndex = 18;
			this.btnCompleteData.Text = "Update database from elp Learning Analytics";
			this.btnCompleteData.UseVisualStyleBackColor = true;
			this.btnCompleteData.Click += new System.EventHandler(this.BtnCompleteData_Click);
			// 
			// button7
			// 
			this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button7.Location = new System.Drawing.Point(23, 93);
			this.button7.Margin = new System.Windows.Forms.Padding(2);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(365, 53);
			this.button7.TabIndex = 19;
			this.button7.Text = "Initialize database from elp Learning Analytics  (link on top of submission list)" +
    "";
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
			this.tabPage7.Location = new System.Drawing.Point(4, 22);
			this.tabPage7.Name = "tabPage7";
			this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage7.Size = new System.Drawing.Size(425, 181);
			this.tabPage7.TabIndex = 1;
			this.tabPage7.Text = "Other AMM database";
			this.tabPage7.UseVisualStyleBackColor = true;
			// 
			// txtSourceDataFile
			// 
			this.txtSourceDataFile.Location = new System.Drawing.Point(100, 17);
			this.txtSourceDataFile.Multiline = true;
			this.txtSourceDataFile.Name = "txtSourceDataFile";
			this.txtSourceDataFile.Size = new System.Drawing.Size(283, 55);
			this.txtSourceDataFile.TabIndex = 12;
			// 
			// chkImportSubmissions
			// 
			this.chkImportSubmissions.AutoSize = true;
			this.chkImportSubmissions.Location = new System.Drawing.Point(100, 120);
			this.chkImportSubmissions.Margin = new System.Windows.Forms.Padding(2);
			this.chkImportSubmissions.Name = "chkImportSubmissions";
			this.chkImportSubmissions.Size = new System.Drawing.Size(114, 17);
			this.chkImportSubmissions.TabIndex = 23;
			this.chkImportSubmissions.Text = "Import submissions";
			this.chkImportSubmissions.UseVisualStyleBackColor = true;
			// 
			// lblSourceData
			// 
			this.lblSourceData.AutoSize = true;
			this.lblSourceData.Location = new System.Drawing.Point(11, 19);
			this.lblSourceData.Name = "lblSourceData";
			this.lblSourceData.Size = new System.Drawing.Size(69, 13);
			this.lblSourceData.TabIndex = 14;
			this.lblSourceData.Text = "sqlite source:";
			// 
			// chkImportComponents
			// 
			this.chkImportComponents.AutoSize = true;
			this.chkImportComponents.Location = new System.Drawing.Point(100, 99);
			this.chkImportComponents.Margin = new System.Windows.Forms.Padding(2);
			this.chkImportComponents.Name = "chkImportComponents";
			this.chkImportComponents.Size = new System.Drawing.Size(142, 17);
			this.chkImportComponents.TabIndex = 17;
			this.chkImportComponents.Text = "Import mark components";
			this.chkImportComponents.UseVisualStyleBackColor = true;
			// 
			// cmdSourceDataFile
			// 
			this.cmdSourceDataFile.Location = new System.Drawing.Point(357, 78);
			this.cmdSourceDataFile.Name = "cmdSourceDataFile";
			this.cmdSourceDataFile.Size = new System.Drawing.Size(25, 22);
			this.cmdSourceDataFile.TabIndex = 13;
			this.cmdSourceDataFile.Text = "...";
			this.cmdSourceDataFile.UseVisualStyleBackColor = true;
			this.cmdSourceDataFile.Click += new System.EventHandler(this.cmdSourceDataFile_Click);
			// 
			// cmdGetData
			// 
			this.cmdGetData.Location = new System.Drawing.Point(101, 150);
			this.cmdGetData.Margin = new System.Windows.Forms.Padding(2);
			this.cmdGetData.Name = "cmdGetData";
			this.cmdGetData.Size = new System.Drawing.Size(282, 26);
			this.cmdGetData.TabIndex = 15;
			this.cmdGetData.Text = "Get Data";
			this.cmdGetData.UseVisualStyleBackColor = true;
			this.cmdGetData.Click += new System.EventHandler(this.cmdGetData_Click);
			// 
			// chkCommentLib
			// 
			this.chkCommentLib.AutoSize = true;
			this.chkCommentLib.Location = new System.Drawing.Point(100, 77);
			this.chkCommentLib.Margin = new System.Windows.Forms.Padding(2);
			this.chkCommentLib.Name = "chkCommentLib";
			this.chkCommentLib.Size = new System.Drawing.Size(136, 17);
			this.chkCommentLib.TabIndex = 16;
			this.chkCommentLib.Text = "Import Comment Library";
			this.chkCommentLib.UseVisualStyleBackColor = true;
			// 
			// tabPage8
			// 
			this.tabPage8.Controls.Add(this.button10);
			this.tabPage8.Controls.Add(this.button9);
			this.tabPage8.Location = new System.Drawing.Point(4, 22);
			this.tabPage8.Name = "tabPage8";
			this.tabPage8.Size = new System.Drawing.Size(425, 181);
			this.tabPage8.TabIndex = 2;
			this.tabPage8.Text = "DocumentArchive";
			this.tabPage8.UseVisualStyleBackColor = true;
			// 
			// button10
			// 
			this.button10.Location = new System.Drawing.Point(18, 42);
			this.button10.Name = "button10";
			this.button10.Size = new System.Drawing.Size(362, 23);
			this.button10.TabIndex = 1;
			this.button10.Text = "Get manifest information";
			this.button10.UseVisualStyleBackColor = true;
			this.button10.Click += new System.EventHandler(this.Button10_Click);
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(18, 13);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(362, 23);
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
			this.tabPage9.Location = new System.Drawing.Point(4, 22);
			this.tabPage9.Name = "tabPage9";
			this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage9.Size = new System.Drawing.Size(425, 181);
			this.tabPage9.TabIndex = 3;
			this.tabPage9.Text = "Excel";
			this.tabPage9.UseVisualStyleBackColor = true;
			// 
			// TxtExcelComponentSource
			// 
			this.TxtExcelComponentSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.TxtExcelComponentSource.Location = new System.Drawing.Point(6, 106);
			this.TxtExcelComponentSource.Multiline = true;
			this.TxtExcelComponentSource.Name = "TxtExcelComponentSource";
			this.TxtExcelComponentSource.Size = new System.Drawing.Size(413, 22);
			this.TxtExcelComponentSource.TabIndex = 10;
			this.TxtExcelComponentSource.TabStop = false;
			// 
			// BtnImportExcel
			// 
			this.BtnImportExcel.Location = new System.Drawing.Point(6, 54);
			this.BtnImportExcel.Name = "BtnImportExcel";
			this.BtnImportExcel.Size = new System.Drawing.Size(190, 42);
			this.BtnImportExcel.TabIndex = 1;
			this.BtnImportExcel.Text = "Import Excel Components";
			this.BtnImportExcel.UseVisualStyleBackColor = true;
			this.BtnImportExcel.Click += new System.EventHandler(this.BtnImportExcel_Click);
			// 
			// BtnExportExcel
			// 
			this.BtnExportExcel.Location = new System.Drawing.Point(6, 6);
			this.BtnExportExcel.Name = "BtnExportExcel";
			this.BtnExportExcel.Size = new System.Drawing.Size(190, 42);
			this.BtnExportExcel.TabIndex = 0;
			this.BtnExportExcel.Text = "Export excel";
			this.BtnExportExcel.UseVisualStyleBackColor = true;
			this.BtnExportExcel.Click += new System.EventHandler(this.BtnExportExcel_Click);
			// 
			// tabPage10
			// 
			this.tabPage10.Controls.Add(this.label12);
			this.tabPage10.Controls.Add(this.TxtScaleFactor);
			this.tabPage10.Controls.Add(this.TxtMergeReportFolder);
			this.tabPage10.Controls.Add(this.BtnMergeReport);
			this.tabPage10.Location = new System.Drawing.Point(4, 22);
			this.tabPage10.Name = "tabPage10";
			this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage10.Size = new System.Drawing.Size(425, 181);
			this.tabPage10.TabIndex = 4;
			this.tabPage10.Text = "PlagiarismReport";
			this.tabPage10.UseVisualStyleBackColor = true;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(12, 87);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(34, 13);
			this.label12.TabIndex = 14;
			this.label12.Text = "Scale";
			// 
			// TxtScaleFactor
			// 
			this.TxtScaleFactor.Location = new System.Drawing.Point(52, 84);
			this.TxtScaleFactor.Name = "TxtScaleFactor";
			this.TxtScaleFactor.Size = new System.Drawing.Size(132, 20);
			this.TxtScaleFactor.TabIndex = 13;
			this.TxtScaleFactor.Text = "1.0";
			this.TxtScaleFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// TxtMergeReportFolder
			// 
			this.TxtMergeReportFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.TxtMergeReportFolder.Location = new System.Drawing.Point(15, 116);
			this.TxtMergeReportFolder.Multiline = true;
			this.TxtMergeReportFolder.Name = "TxtMergeReportFolder";
			this.TxtMergeReportFolder.Size = new System.Drawing.Size(392, 22);
			this.TxtMergeReportFolder.TabIndex = 12;
			this.TxtMergeReportFolder.TabStop = false;
			// 
			// BtnMergeReport
			// 
			this.BtnMergeReport.Location = new System.Drawing.Point(15, 16);
			this.BtnMergeReport.Name = "BtnMergeReport";
			this.BtnMergeReport.Size = new System.Drawing.Size(169, 42);
			this.BtnMergeReport.TabIndex = 11;
			this.BtnMergeReport.Text = "Merge reports";
			this.BtnMergeReport.UseVisualStyleBackColor = true;
			this.BtnMergeReport.Click += new System.EventHandler(this.BtnMergeReport_Click);
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.ColumnCount = 5;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel4.Controls.Add(this.cmdReload, 3, 0);
			this.tableLayoutPanel4.Controls.Add(this.label5, 0, 0);
			this.tableLayoutPanel4.Controls.Add(this.cmdSelectFile, 2, 0);
			this.tableLayoutPanel4.Controls.Add(this.txtExcelFileName, 1, 0);
			this.tableLayoutPanel4.Controls.Add(this.BtnOpenFolder, 4, 0);
			this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 1;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.Size = new System.Drawing.Size(1097, 32);
			this.tableLayoutPanel4.TabIndex = 13;
			// 
			// BtnOpenFolder
			// 
			this.BtnOpenFolder.Image = global::UnnItBooster.Properties.Resources.folder;
			this.BtnOpenFolder.Location = new System.Drawing.Point(1070, 3);
			this.BtnOpenFolder.Name = "BtnOpenFolder";
			this.BtnOpenFolder.Size = new System.Drawing.Size(23, 23);
			this.BtnOpenFolder.TabIndex = 13;
			this.BtnOpenFolder.UseVisualStyleBackColor = true;
			this.BtnOpenFolder.Click += new System.EventHandler(this.BtnOpenFolder_Click);
			// 
			// FrmMarkingMachine
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1097, 603);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.tableLayoutPanel4);
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
			this.panel2.PerformLayout();
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel1.PerformLayout();
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
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
			this.tableLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.NudOverlap)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.StudImage)).EndInit();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.tabControl2.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.tabPage5.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.NudMarkOffset)).EndInit();
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
			this.tabPage10.ResumeLayout(false);
			this.tabPage10.PerformLayout();
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
		private CheckBox ChkCommNumber;
		private Label label1;
		private Button BtnEditLast;
		private Button BtnShowStudentStat;
		private ColumnHeader columnHeader7;
		private CheckBox ChkOddRows;
		private CheckBox ChkEvenRows;
		private CheckBox ChkIncludeNoMark;
		private Label label9;
		private NumericUpDown NudMarkOffset;
		private ComboBox CmbGrouping;
		private CheckBox ChkRoundupX9;
		private CheckBox ChkShowLabels;
		private GroupBox groupBox1;
		private Label LblOverlap;
		private NumericUpDown NudOverlap;
		private CheckBox ChkExclude0;
		private TabPage tabPage10;
		private TextBox TxtMergeReportFolder;
		private Button BtnMergeReport;
		private Label label12;
		private TextBox TxtScaleFactor;
		private TextBox txtElpCode;
		private Label label13;
		private CheckBox chkShowDelegate;
		private Panel panel1;
		private Button cmdWrap;
		private Button cmdReportSizeDecrease;
		private Button cmdReportSizeIncrease;
	}
}

