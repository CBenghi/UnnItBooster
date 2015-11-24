namespace StudentsFetcher.SpellCheck
{
    partial class frmSpeller
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
            this.cmdChange = new System.Windows.Forms.Button();
            this.txtProblemWord = new System.Windows.Forms.TextBox();
            this.lstOptions = new System.Windows.Forms.ListView();
            this.txtUse = new System.Windows.Forms.TextBox();
            this.cmdIgnore = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdChange
            // 
            this.cmdChange.Location = new System.Drawing.Point(349, 217);
            this.cmdChange.Name = "cmdChange";
            this.cmdChange.Size = new System.Drawing.Size(99, 23);
            this.cmdChange.TabIndex = 0;
            this.cmdChange.Text = "Change";
            this.cmdChange.UseVisualStyleBackColor = true;
            this.cmdChange.Click += new System.EventHandler(this.cmdChange_Click);
            // 
            // txtProblemWord
            // 
            this.txtProblemWord.Location = new System.Drawing.Point(96, 12);
            this.txtProblemWord.Name = "txtProblemWord";
            this.txtProblemWord.Size = new System.Drawing.Size(245, 20);
            this.txtProblemWord.TabIndex = 1;
            // 
            // lstOptions
            // 
            this.lstOptions.Location = new System.Drawing.Point(95, 47);
            this.lstOptions.Name = "lstOptions";
            this.lstOptions.Size = new System.Drawing.Size(245, 152);
            this.lstOptions.TabIndex = 2;
            this.lstOptions.UseCompatibleStateImageBehavior = false;
            this.lstOptions.View = System.Windows.Forms.View.List;
            this.lstOptions.SelectedIndexChanged += new System.EventHandler(this.lstOptions_SelectedIndexChanged);
            this.lstOptions.DoubleClick += new System.EventHandler(this.lstOptions_DoubleClick);
            // 
            // txtUse
            // 
            this.txtUse.Location = new System.Drawing.Point(95, 217);
            this.txtUse.Name = "txtUse";
            this.txtUse.Size = new System.Drawing.Size(245, 20);
            this.txtUse.TabIndex = 3;
            // 
            // cmdIgnore
            // 
            this.cmdIgnore.Location = new System.Drawing.Point(349, 10);
            this.cmdIgnore.Name = "cmdIgnore";
            this.cmdIgnore.Size = new System.Drawing.Size(99, 23);
            this.cmdIgnore.TabIndex = 4;
            this.cmdIgnore.Text = "Keep";
            this.cmdIgnore.UseVisualStyleBackColor = true;
            this.cmdIgnore.Click += new System.EventHandler(this.cmdIgnore_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(95, 254);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(353, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Stop";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmSpeller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 289);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdIgnore);
            this.Controls.Add(this.txtUse);
            this.Controls.Add(this.lstOptions);
            this.Controls.Add(this.txtProblemWord);
            this.Controls.Add(this.cmdChange);
            this.KeyPreview = true;
            this.Name = "frmSpeller";
            this.Text = "frmTest";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSpeller_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdChange;
        private System.Windows.Forms.TextBox txtProblemWord;
        private System.Windows.Forms.ListView lstOptions;
        private System.Windows.Forms.TextBox txtUse;
        private System.Windows.Forms.Button cmdIgnore;
        private System.Windows.Forms.Button button1;
    }
}