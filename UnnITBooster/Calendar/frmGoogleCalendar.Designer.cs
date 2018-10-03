namespace StudentsFetcher
{
    partial class Form1
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
            this.dtWeek1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSchedule = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dstchange = new System.Windows.Forms.DateTimePicker();
            this.chkIsSummer = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // dtWeek1
            // 
            this.dtWeek1.Location = new System.Drawing.Point(89, 266);
            this.dtWeek1.Name = "dtWeek1";
            this.dtWeek1.Size = new System.Drawing.Size(252, 20);
            this.dtWeek1.TabIndex = 0;
            this.dtWeek1.Value = new System.DateTime(2018, 9, 24, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Day 1";
            // 
            // txtSchedule
            // 
            this.txtSchedule.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSchedule.Location = new System.Drawing.Point(18, 39);
            this.txtSchedule.Multiline = true;
            this.txtSchedule.Name = "txtSchedule";
            this.txtSchedule.Size = new System.Drawing.Size(323, 214);
            this.txtSchedule.TabIndex = 2;
            this.txtSchedule.Text = "weeks 5,6\r\n2-1-2-Be1178 Lecture-EBB003\r\n3-3-2-Be1178 Seminar-WJC207";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(184, 345);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 294);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "DST change";
            // 
            // dstchange
            // 
            this.dstchange.CustomFormat = "dd MMMM yyyy HH mm";
            this.dstchange.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dstchange.Location = new System.Drawing.Point(89, 292);
            this.dstchange.Name = "dstchange";
            this.dstchange.Size = new System.Drawing.Size(252, 20);
            this.dstchange.TabIndex = 7;
            this.dstchange.Value = new System.DateTime(2018, 10, 28, 0, 0, 0, 0);
            // 
            // chkIsSummer
            // 
            this.chkIsSummer.AutoSize = true;
            this.chkIsSummer.Checked = true;
            this.chkIsSummer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsSummer.Location = new System.Drawing.Point(89, 318);
            this.chkIsSummer.Name = "chkIsSummer";
            this.chkIsSummer.Size = new System.Drawing.Size(123, 17);
            this.chkIsSummer.TabIndex = 9;
            this.chkIsSummer.Text = "It\'s currently Summer";
            this.chkIsSummer.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 397);
            this.Controls.Add(this.chkIsSummer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dstchange);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSchedule);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtWeek1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtWeek1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSchedule;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dstchange;
        private System.Windows.Forms.CheckBox chkIsSummer;
    }
}

