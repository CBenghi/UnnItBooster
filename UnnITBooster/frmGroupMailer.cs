using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StudentsFetcher
{
    public partial class frmGroupMailer : Form
    {
        public frmGroupMailer()
        {
            InitializeComponent();
        }

        private void cmdSelectFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = "accdb";
            openFileDialog1.Multiselect = false;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                txtDataFileName.Text = openFileDialog1.FileName;
            }
        }
    }
}
