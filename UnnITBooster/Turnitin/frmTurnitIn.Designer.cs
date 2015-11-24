namespace StudentsFetcher
{
    partial class frmTurnitIn
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
            this.cmdFetch = new System.Windows.Forms.Button();
            this.txtTunrintinUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExcelFileName = new System.Windows.Forms.TextBox();
            this.cmdSelectFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.button2 = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.cmdMakeDatabase = new System.Windows.Forms.Button();
            this.cmdGetFurtherData = new System.Windows.Forms.Button();
            this.cmdGetFiles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdFetch
            // 
            this.cmdFetch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdFetch.Location = new System.Drawing.Point(920, 16);
            this.cmdFetch.Margin = new System.Windows.Forms.Padding(4);
            this.cmdFetch.Name = "cmdFetch";
            this.cmdFetch.Size = new System.Drawing.Size(249, 28);
            this.cmdFetch.TabIndex = 0;
            this.cmdFetch.Text = "1. Fetch";
            this.cmdFetch.UseVisualStyleBackColor = true;
            this.cmdFetch.Click += new System.EventHandler(this.cmdFetch_Click);
            // 
            // txtTunrintinUrl
            // 
            this.txtTunrintinUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTunrintinUrl.Location = new System.Drawing.Point(164, 55);
            this.txtTunrintinUrl.Margin = new System.Windows.Forms.Padding(4);
            this.txtTunrintinUrl.Multiline = true;
            this.txtTunrintinUrl.Name = "txtTunrintinUrl";
            this.txtTunrintinUrl.Size = new System.Drawing.Size(1005, 112);
            this.txtTunrintinUrl.TabIndex = 1;
            this.txtTunrintinUrl.TextChanged += new System.EventHandler(this.txtTunrintinUrl_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Turnitin Sample URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 181);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Session Id";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(164, 175);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(748, 26);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Excel file report";
            // 
            // txtExcelFileName
            // 
            this.txtExcelFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExcelFileName.Location = new System.Drawing.Point(164, 15);
            this.txtExcelFileName.Margin = new System.Windows.Forms.Padding(4);
            this.txtExcelFileName.Multiline = true;
            this.txtExcelFileName.Name = "txtExcelFileName";
            this.txtExcelFileName.Size = new System.Drawing.Size(681, 26);
            this.txtExcelFileName.TabIndex = 5;
            // 
            // cmdSelectFile
            // 
            this.cmdSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSelectFile.Location = new System.Drawing.Point(853, 16);
            this.cmdSelectFile.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSelectFile.Name = "cmdSelectFile";
            this.cmdSelectFile.Size = new System.Drawing.Size(59, 27);
            this.cmdSelectFile.TabIndex = 7;
            this.cmdSelectFile.Text = "...";
            this.cmdSelectFile.UseVisualStyleBackColor = true;
            this.cmdSelectFile.Click += new System.EventHandler(this.cmdSelectFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(16, 215);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(4);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(27, 25);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(1155, 351);
            this.webBrowser1.TabIndex = 11;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            this.webBrowser1.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser1_Navigating);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(16, 574);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 12;
            this.button2.Text = "Navigate to:";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl.Location = new System.Drawing.Point(124, 575);
            this.txtUrl.Margin = new System.Windows.Forms.Padding(4);
            this.txtUrl.Multiline = true;
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(1045, 26);
            this.txtUrl.TabIndex = 13;
            // 
            // cmdMakeDatabase
            // 
            this.cmdMakeDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdMakeDatabase.Enabled = false;
            this.cmdMakeDatabase.Location = new System.Drawing.Point(920, 660);
            this.cmdMakeDatabase.Margin = new System.Windows.Forms.Padding(4);
            this.cmdMakeDatabase.Name = "cmdMakeDatabase";
            this.cmdMakeDatabase.Size = new System.Drawing.Size(249, 28);
            this.cmdMakeDatabase.TabIndex = 15;
            this.cmdMakeDatabase.Text = "3. Make database";
            this.cmdMakeDatabase.UseVisualStyleBackColor = true;
            this.cmdMakeDatabase.Click += new System.EventHandler(this.makeDatabase_Click);
            // 
            // cmdGetFurtherData
            // 
            this.cmdGetFurtherData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdGetFurtherData.Enabled = false;
            this.cmdGetFurtherData.Location = new System.Drawing.Point(920, 609);
            this.cmdGetFurtherData.Margin = new System.Windows.Forms.Padding(4);
            this.cmdGetFurtherData.Name = "cmdGetFurtherData";
            this.cmdGetFurtherData.Size = new System.Drawing.Size(249, 28);
            this.cmdGetFurtherData.TabIndex = 16;
            this.cmdGetFurtherData.Text = "2. Get further data";
            this.cmdGetFurtherData.UseVisualStyleBackColor = true;
            this.cmdGetFurtherData.Click += new System.EventHandler(this.button3_Click);
            // 
            // cmdGetFiles
            // 
            this.cmdGetFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdGetFiles.Enabled = false;
            this.cmdGetFiles.Location = new System.Drawing.Point(920, 175);
            this.cmdGetFiles.Margin = new System.Windows.Forms.Padding(4);
            this.cmdGetFiles.Name = "cmdGetFiles";
            this.cmdGetFiles.Size = new System.Drawing.Size(249, 28);
            this.cmdGetFiles.TabIndex = 17;
            this.cmdGetFiles.Text = "2. Get available files";
            this.cmdGetFiles.UseVisualStyleBackColor = true;
            this.cmdGetFiles.Click += new System.EventHandler(this.button4_Click);
            // 
            // frmTurnitIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 701);
            this.Controls.Add(this.cmdGetFiles);
            this.Controls.Add(this.cmdGetFurtherData);
            this.Controls.Add(this.cmdMakeDatabase);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.cmdSelectFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtExcelFileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTunrintinUrl);
            this.Controls.Add(this.cmdFetch);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTurnitIn";
            this.Text = "frmTurnitIn";
            this.Load += new System.EventHandler(this.frmTurnitIn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdFetch;
        private System.Windows.Forms.TextBox txtTunrintinUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExcelFileName;
        private System.Windows.Forms.Button cmdSelectFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button cmdMakeDatabase;
        private System.Windows.Forms.Button cmdGetFurtherData;
        private System.Windows.Forms.Button cmdGetFiles;
    }
}