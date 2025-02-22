namespace UnnOutlookAddin.UI
{
    partial class UnnStudent
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
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.CmbFolder = new System.Windows.Forms.ComboBox();
			this.CmdFolder = new System.Windows.Forms.Button();
			this.ButtonToggleWrap = new System.Windows.Forms.Button();
			this.txtInformation = new System.Windows.Forms.TextBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.button1 = new System.Windows.Forms.Button();
			this.cmbAction = new System.Windows.Forms.ComboBox();
			this.ButtonThread = new System.Windows.Forms.Button();
			this.StudImage = new System.Windows.Forms.PictureBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label1 = new System.Windows.Forms.Label();
			this.txtCollection = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.BtnSolveStudentName = new System.Windows.Forms.Button();
			this.txtSystemInfo = new System.Windows.Forms.TextBox();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.StudImage)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(6, 6);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(6);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(490, 720);
			this.tabControl1.TabIndex = 2;
			this.tabControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseDoubleClick);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Location = new System.Drawing.Point(4, 33);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(6);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(6);
			this.tabPage1.Size = new System.Drawing.Size(482, 683);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Information";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.CmbFolder);
			this.groupBox1.Controls.Add(this.CmdFolder);
			this.groupBox1.Controls.Add(this.ButtonToggleWrap);
			this.groupBox1.Controls.Add(this.txtInformation);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(6, 6);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
			this.groupBox1.Size = new System.Drawing.Size(470, 671);
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
			this.CmbFolder.Location = new System.Drawing.Point(64, 34);
			this.CmbFolder.Margin = new System.Windows.Forms.Padding(6);
			this.CmbFolder.Name = "CmbFolder";
			this.CmbFolder.Size = new System.Drawing.Size(290, 32);
			this.CmbFolder.TabIndex = 7;
			// 
			// CmdFolder
			// 
			this.CmdFolder.Image = global::UnnOutlookAddin.Properties.Resources.folder;
			this.CmdFolder.Location = new System.Drawing.Point(6, 31);
			this.CmdFolder.Margin = new System.Windows.Forms.Padding(6);
			this.CmdFolder.Name = "CmdFolder";
			this.CmdFolder.Size = new System.Drawing.Size(46, 42);
			this.CmdFolder.TabIndex = 6;
			this.CmdFolder.UseVisualStyleBackColor = true;
			this.CmdFolder.Click += new System.EventHandler(this.CmdFolder_Click);
			// 
			// ButtonToggleWrap
			// 
			this.ButtonToggleWrap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ButtonToggleWrap.Location = new System.Drawing.Point(366, 31);
			this.ButtonToggleWrap.Margin = new System.Windows.Forms.Padding(6);
			this.ButtonToggleWrap.Name = "ButtonToggleWrap";
			this.ButtonToggleWrap.Size = new System.Drawing.Size(98, 42);
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
			this.txtInformation.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtInformation.Location = new System.Drawing.Point(6, 85);
			this.txtInformation.Margin = new System.Windows.Forms.Padding(6);
			this.txtInformation.Multiline = true;
			this.txtInformation.Name = "txtInformation";
			this.txtInformation.Size = new System.Drawing.Size(458, 580);
			this.txtInformation.TabIndex = 1;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.button1);
			this.tabPage3.Controls.Add(this.cmbAction);
			this.tabPage3.Controls.Add(this.ButtonThread);
			this.tabPage3.Controls.Add(this.StudImage);
			this.tabPage3.Location = new System.Drawing.Point(4, 33);
			this.tabPage3.Margin = new System.Windows.Forms.Padding(6);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(482, 683);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Picture";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(379, 6);
			this.button1.Margin = new System.Windows.Forms.Padding(6);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(97, 42);
			this.button1.TabIndex = 23;
			this.button1.Text = "Go";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// cmbAction
			// 
			this.cmbAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAction.FormattingEnabled = true;
			this.cmbAction.Location = new System.Drawing.Point(156, 12);
			this.cmbAction.Margin = new System.Windows.Forms.Padding(6);
			this.cmbAction.Name = "cmbAction";
			this.cmbAction.Size = new System.Drawing.Size(211, 32);
			this.cmbAction.TabIndex = 22;
			// 
			// ButtonThread
			// 
			this.ButtonThread.Location = new System.Drawing.Point(6, 6);
			this.ButtonThread.Margin = new System.Windows.Forms.Padding(6);
			this.ButtonThread.Name = "ButtonThread";
			this.ButtonThread.Size = new System.Drawing.Size(138, 42);
			this.ButtonThread.TabIndex = 21;
			this.ButtonThread.Text = "Thread";
			this.ButtonThread.UseVisualStyleBackColor = true;
			this.ButtonThread.Click += new System.EventHandler(this.ButtonThread_Click);
			// 
			// StudImage
			// 
			this.StudImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.StudImage.BackColor = System.Drawing.Color.Gray;
			this.StudImage.Location = new System.Drawing.Point(6, 58);
			this.StudImage.Margin = new System.Windows.Forms.Padding(4);
			this.StudImage.Name = "StudImage";
			this.StudImage.Size = new System.Drawing.Size(470, 621);
			this.StudImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.StudImage.TabIndex = 20;
			this.StudImage.TabStop = false;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.label1);
			this.tabPage2.Controls.Add(this.txtCollection);
			this.tabPage2.Controls.Add(this.button2);
			this.tabPage2.Controls.Add(this.BtnSolveStudentName);
			this.tabPage2.Controls.Add(this.txtSystemInfo);
			this.tabPage2.Location = new System.Drawing.Point(4, 33);
			this.tabPage2.Margin = new System.Windows.Forms.Padding(6);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(6);
			this.tabPage2.Size = new System.Drawing.Size(482, 683);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "System";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 651);
			this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(93, 24);
			this.label1.TabIndex = 4;
			this.label1.Text = "Collection";
			// 
			// txtCollection
			// 
			this.txtCollection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCollection.Location = new System.Drawing.Point(135, 648);
			this.txtCollection.Margin = new System.Windows.Forms.Padding(6);
			this.txtCollection.Name = "txtCollection";
			this.txtCollection.Size = new System.Drawing.Size(341, 29);
			this.txtCollection.TabIndex = 3;
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Location = new System.Drawing.Point(6, 603);
			this.button2.Margin = new System.Windows.Forms.Padding(6);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(470, 42);
			this.button2.TabIndex = 2;
			this.button2.Text = "Add thread students to Collection";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// BtnSolveStudentName
			// 
			this.BtnSolveStudentName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnSolveStudentName.Location = new System.Drawing.Point(6, 12);
			this.BtnSolveStudentName.Margin = new System.Windows.Forms.Padding(6);
			this.BtnSolveStudentName.Name = "BtnSolveStudentName";
			this.BtnSolveStudentName.Size = new System.Drawing.Size(470, 42);
			this.BtnSolveStudentName.TabIndex = 1;
			this.BtnSolveStudentName.Text = "Resolve first names";
			this.BtnSolveStudentName.UseVisualStyleBackColor = true;
			this.BtnSolveStudentName.Click += new System.EventHandler(this.BtnSolveStudentName_Click);
			// 
			// txtSystemInfo
			// 
			this.txtSystemInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSystemInfo.Location = new System.Drawing.Point(6, 66);
			this.txtSystemInfo.Margin = new System.Windows.Forms.Padding(6);
			this.txtSystemInfo.Multiline = true;
			this.txtSystemInfo.Name = "txtSystemInfo";
			this.txtSystemInfo.Size = new System.Drawing.Size(470, 525);
			this.txtSystemInfo.TabIndex = 0;
			// 
			// UnnStudent
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControl1);
			this.Margin = new System.Windows.Forms.Padding(6);
			this.Name = "UnnStudent";
			this.Size = new System.Drawing.Size(500, 731);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.StudImage)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TextBox txtSystemInfo;
		private System.Windows.Forms.TextBox txtInformation;
		private System.Windows.Forms.PictureBox StudImage;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button ButtonToggleWrap;
		private System.Windows.Forms.ComboBox CmbFolder;
		private System.Windows.Forms.Button CmdFolder;
		private System.Windows.Forms.Button BtnSolveStudentName;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox cmbAction;
		private System.Windows.Forms.Button ButtonThread;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox txtCollection;
		private System.Windows.Forms.Label label1;
	}
}
