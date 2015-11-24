namespace StudentsFetcher
{
    partial class frmSpellerTest
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
            this.ctlSpellCheck1 = new StudentsFetcher.SpellCheck.ctlSpellCheck();
            this.SuspendLayout();
            // 
            // ctlSpellCheck1
            // 
            this.ctlSpellCheck1.DictLanguage = "en_GB";
            this.ctlSpellCheck1.Location = new System.Drawing.Point(75, 34);
            this.ctlSpellCheck1.Name = "ctlSpellCheck1";
            this.ctlSpellCheck1.Size = new System.Drawing.Size(100, 20);
            this.ctlSpellCheck1.TabIndex = 0;
            // 
            // frmSpellerTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 380);
            this.Controls.Add(this.ctlSpellCheck1);
            this.Name = "frmSpellerTest";
            this.Text = "Speller test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SpellCheck.ctlSpellCheck ctlSpellCheck1;

    }
}