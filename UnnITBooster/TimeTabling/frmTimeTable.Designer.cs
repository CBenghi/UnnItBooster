namespace StudentsFetcher
{
    partial class frmTimeTable
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.nudToWeek = new System.Windows.Forms.NumericUpDown();
            this.nudFromWeek = new System.Windows.Forms.NumericUpDown();
            this.txtStudentId = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudToWeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFromWeek)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.nudToWeek);
            this.groupBox1.Controls.Add(this.nudFromWeek);
            this.groupBox1.Controls.Add(this.txtStudentId);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(672, 528);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Students";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(191, 87);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "GetTimes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nudToWeek
            // 
            this.nudToWeek.Location = new System.Drawing.Point(191, 55);
            this.nudToWeek.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudToWeek.Name = "nudToWeek";
            this.nudToWeek.Size = new System.Drawing.Size(160, 22);
            this.nudToWeek.TabIndex = 3;
            this.nudToWeek.Value = new decimal(new int[] {
            21,
            0,
            0,
            0});
            // 
            // nudFromWeek
            // 
            this.nudFromWeek.Location = new System.Drawing.Point(191, 23);
            this.nudFromWeek.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudFromWeek.Name = "nudFromWeek";
            this.nudFromWeek.Size = new System.Drawing.Size(160, 22);
            this.nudFromWeek.TabIndex = 2;
            this.nudFromWeek.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // txtStudentId
            // 
            this.txtStudentId.Location = new System.Drawing.Point(8, 23);
            this.txtStudentId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStudentId.Multiline = true;
            this.txtStudentId.Name = "txtStudentId";
            this.txtStudentId.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStudentId.Size = new System.Drawing.Size(136, 482);
            this.txtStudentId.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(191, 123);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(160, 28);
            this.button2.TabIndex = 5;
            this.button2.Text = "Test";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmTimeTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 572);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmTimeTable";
            this.Text = "frmTimeTable";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudToWeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFromWeek)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown nudToWeek;
        private System.Windows.Forms.NumericUpDown nudFromWeek;
        private System.Windows.Forms.Button button2;
    }
}