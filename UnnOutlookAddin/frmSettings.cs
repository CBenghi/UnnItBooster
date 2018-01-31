using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnnOutlookAddin
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();

            LoadSettings();
        }

        private void LoadSettings()
        {
            txtConfigFolder.Text = Properties.Settings.Default.StudentsFolder;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.StudentsFolder = txtConfigFolder.Text;
            Properties.Settings.Default.Save();
        }
    }
}
