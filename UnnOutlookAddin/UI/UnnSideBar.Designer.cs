namespace UnnOutlookAddin.UI
{
    partial class UnnSideBar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tbSelection = new System.Windows.Forms.TabPage();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.CmbFolder = new System.Windows.Forms.ComboBox();
			this.CmdFolder = new System.Windows.Forms.Button();
			this.ButtonToggleWrap = new System.Windows.Forms.Button();
			this.txtInformation = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.StudImage = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			this.ButtonThread = new System.Windows.Forms.Button();
			this.cmbAction = new System.Windows.Forms.ComboBox();
			this.tbSystem = new System.Windows.Forms.TabPage();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.BtnSolveStudentName = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.cmdMoveMail = new System.Windows.Forms.Button();
			this.cmbRepository = new System.Windows.Forms.ComboBox();
			this.button3 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtCollection = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.txtSystemInfo = new System.Windows.Forms.TextBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.tabControl1.SuspendLayout();
			this.tbSelection.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.StudImage)).BeginInit();
			this.tbSystem.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tbSelection);
			this.tabControl1.Controls.Add(this.tbSystem);
			this.tabControl1.Location = new System.Drawing.Point(3, 3);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(267, 677);
			this.tabControl1.TabIndex = 2;
			this.tabControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseDoubleClick);
			// 
			// tbSelection
			// 
			this.tbSelection.Controls.Add(this.splitContainer1);
			this.tbSelection.Location = new System.Drawing.Point(4, 22);
			this.tbSelection.Name = "tbSelection";
			this.tbSelection.Padding = new System.Windows.Forms.Padding(3);
			this.tbSelection.Size = new System.Drawing.Size(259, 651);
			this.tbSelection.TabIndex = 0;
			this.tbSelection.Text = "Selection";
			this.tbSelection.UseVisualStyleBackColor = true;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(3, 3);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
			this.splitContainer1.Size = new System.Drawing.Size(253, 645);
			this.splitContainer1.SplitterDistance = 327;
			this.splitContainer1.TabIndex = 22;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.groupBox5);
			this.groupBox1.Controls.Add(this.ButtonToggleWrap);
			this.groupBox1.Controls.Add(this.ButtonThread);
			this.groupBox1.Controls.Add(this.txtInformation);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(253, 327);
			this.groupBox1.TabIndex = 21;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "General";
			// 
			// CmbFolder
			// 
			this.CmbFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CmbFolder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CmbFolder.FormattingEnabled = true;
			this.CmbFolder.Location = new System.Drawing.Point(37, 19);
			this.CmbFolder.Name = "CmbFolder";
			this.CmbFolder.Size = new System.Drawing.Size(200, 21);
			this.CmbFolder.TabIndex = 7;
			// 
			// CmdFolder
			// 
			this.CmdFolder.Image = global::UnnOutlookAddin.Properties.Resources.folder;
			this.CmdFolder.Location = new System.Drawing.Point(6, 19);
			this.CmdFolder.Name = "CmdFolder";
			this.CmdFolder.Size = new System.Drawing.Size(25, 23);
			this.CmdFolder.TabIndex = 6;
			this.CmdFolder.UseVisualStyleBackColor = true;
			this.CmdFolder.Click += new System.EventHandler(this.CmdFolder_Click);
			// 
			// ButtonToggleWrap
			// 
			this.ButtonToggleWrap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.ButtonToggleWrap.Location = new System.Drawing.Point(197, 298);
			this.ButtonToggleWrap.Name = "ButtonToggleWrap";
			this.ButtonToggleWrap.Size = new System.Drawing.Size(53, 23);
			this.ButtonToggleWrap.TabIndex = 3;
			this.ButtonToggleWrap.Text = "Wrap";
			this.ButtonToggleWrap.UseVisualStyleBackColor = true;
			this.ButtonToggleWrap.Click += new System.EventHandler(this.ButtonToggleWrap_Click);
			// 
			// txtInformation
			// 
			this.txtInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtInformation.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtInformation.Location = new System.Drawing.Point(6, 103);
			this.txtInformation.Multiline = true;
			this.txtInformation.Name = "txtInformation";
			this.txtInformation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtInformation.Size = new System.Drawing.Size(244, 189);
			this.txtInformation.TabIndex = 1;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.StudImage);
			this.groupBox2.Controls.Add(this.button1);
			this.groupBox2.Controls.Add(this.cmbAction);
			this.groupBox2.Location = new System.Drawing.Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(253, 311);
			this.groupBox2.TabIndex = 24;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Picture";
			// 
			// StudImage
			// 
			this.StudImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.StudImage.BackColor = System.Drawing.Color.Gray;
			this.StudImage.Location = new System.Drawing.Point(5, 18);
			this.StudImage.Margin = new System.Windows.Forms.Padding(2);
			this.StudImage.Name = "StudImage";
			this.StudImage.Size = new System.Drawing.Size(244, 259);
			this.StudImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.StudImage.TabIndex = 20;
			this.StudImage.TabStop = false;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(197, 282);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(53, 23);
			this.button1.TabIndex = 23;
			this.button1.Text = "Go";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// ButtonThread
			// 
			this.ButtonThread.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ButtonThread.Location = new System.Drawing.Point(6, 74);
			this.ButtonThread.Name = "ButtonThread";
			this.ButtonThread.Size = new System.Drawing.Size(244, 23);
			this.ButtonThread.TabIndex = 21;
			this.ButtonThread.Text = "List thread students";
			this.ButtonThread.UseVisualStyleBackColor = true;
			this.ButtonThread.Click += new System.EventHandler(this.ButtonThread_Click);
			// 
			// cmbAction
			// 
			this.cmbAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAction.FormattingEnabled = true;
			this.cmbAction.Location = new System.Drawing.Point(6, 282);
			this.cmbAction.Name = "cmbAction";
			this.cmbAction.Size = new System.Drawing.Size(185, 21);
			this.cmbAction.TabIndex = 22;
			// 
			// tbSystem
			// 
			this.tbSystem.Controls.Add(this.groupBox4);
			this.tbSystem.Controls.Add(this.groupBox3);
			this.tbSystem.Controls.Add(this.button3);
			this.tbSystem.Controls.Add(this.label1);
			this.tbSystem.Controls.Add(this.txtCollection);
			this.tbSystem.Controls.Add(this.button2);
			this.tbSystem.Controls.Add(this.txtSystemInfo);
			this.tbSystem.Location = new System.Drawing.Point(4, 22);
			this.tbSystem.Name = "tbSystem";
			this.tbSystem.Padding = new System.Windows.Forms.Padding(3);
			this.tbSystem.Size = new System.Drawing.Size(259, 651);
			this.tbSystem.TabIndex = 1;
			this.tbSystem.Text = "System";
			this.tbSystem.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.BtnSolveStudentName);
			this.groupBox4.Location = new System.Drawing.Point(6, 120);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(247, 81);
			this.groupBox4.TabIndex = 8;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Resolve missing data";
			// 
			// BtnSolveStudentName
			// 
			this.BtnSolveStudentName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnSolveStudentName.Location = new System.Drawing.Point(45, 19);
			this.BtnSolveStudentName.Name = "BtnSolveStudentName";
			this.BtnSolveStudentName.Size = new System.Drawing.Size(196, 56);
			this.BtnSolveStudentName.TabIndex = 1;
			this.BtnSolveStudentName.Text = "Resolve missing first names and Outlook addresses";
			this.BtnSolveStudentName.UseVisualStyleBackColor = true;
			this.BtnSolveStudentName.Click += new System.EventHandler(this.BtnSolveStudentName_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.cmdMoveMail);
			this.groupBox3.Controls.Add(this.cmbRepository);
			this.groupBox3.Location = new System.Drawing.Point(6, 35);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(247, 79);
			this.groupBox3.TabIndex = 7;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Move mail to folder";
			// 
			// cmdMoveMail
			// 
			this.cmdMoveMail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdMoveMail.Location = new System.Drawing.Point(45, 46);
			this.cmdMoveMail.Name = "cmdMoveMail";
			this.cmdMoveMail.Size = new System.Drawing.Size(196, 23);
			this.cmdMoveMail.TabIndex = 7;
			this.cmdMoveMail.Text = "Move";
			this.cmdMoveMail.UseVisualStyleBackColor = true;
			this.cmdMoveMail.Click += new System.EventHandler(this.cmdMoveMail_Click);
			// 
			// cmbRepository
			// 
			this.cmbRepository.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbRepository.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbRepository.FormattingEnabled = true;
			this.cmbRepository.Location = new System.Drawing.Point(6, 19);
			this.cmbRepository.Name = "cmbRepository";
			this.cmbRepository.Size = new System.Drawing.Size(235, 21);
			this.cmbRepository.TabIndex = 6;
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button3.Location = new System.Drawing.Point(6, 6);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(247, 23);
			this.button3.TabIndex = 5;
			this.button3.Text = "Refresh";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 757);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Collection";
			// 
			// txtCollection
			// 
			this.txtCollection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCollection.Location = new System.Drawing.Point(74, 755);
			this.txtCollection.Name = "txtCollection";
			this.txtCollection.Size = new System.Drawing.Size(188, 20);
			this.txtCollection.TabIndex = 3;
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Location = new System.Drawing.Point(3, 731);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(256, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "Add thread students to Collection";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// txtSystemInfo
			// 
			this.txtSystemInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSystemInfo.Location = new System.Drawing.Point(6, 207);
			this.txtSystemInfo.Multiline = true;
			this.txtSystemInfo.Name = "txtSystemInfo";
			this.txtSystemInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtSystemInfo.Size = new System.Drawing.Size(247, 438);
			this.txtSystemInfo.TabIndex = 0;
			// 
			// groupBox5
			// 
			this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox5.Controls.Add(this.CmbFolder);
			this.groupBox5.Controls.Add(this.CmdFolder);
			this.groupBox5.Location = new System.Drawing.Point(6, 19);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(243, 49);
			this.groupBox5.TabIndex = 8;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Move to folder";
			// 
			// UnnSideBar
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControl1);
			this.Name = "UnnSideBar";
			this.Size = new System.Drawing.Size(273, 683);
			this.tabControl1.ResumeLayout(false);
			this.tbSelection.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.StudImage)).EndInit();
			this.tbSystem.ResumeLayout(false);
			this.tbSystem.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tbSelection;
		private System.Windows.Forms.TabPage tbSystem;
		private System.Windows.Forms.TextBox txtSystemInfo;
		private System.Windows.Forms.TextBox txtInformation;
		private System.Windows.Forms.PictureBox StudImage;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button ButtonToggleWrap;
		private System.Windows.Forms.ComboBox CmbFolder;
		private System.Windows.Forms.Button CmdFolder;
		private System.Windows.Forms.Button BtnSolveStudentName;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox cmbAction;
		private System.Windows.Forms.Button ButtonThread;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox txtCollection;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button cmdMoveMail;
		private System.Windows.Forms.ComboBox cmbRepository;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox5;
	}
}
