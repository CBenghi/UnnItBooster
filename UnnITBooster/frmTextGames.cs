using System;
using System.Windows.Forms;

namespace StudentsFetcher
{
    [AmmFormAttributes("Play with text")] 
    public partial class frmTextGames : Form
    {
        public frmTextGames()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtBoxTo.Text = System.Web.HttpUtility.HtmlDecode(txtBoxFrom.Text);
        }



        private void button2_Click(object sender, EventArgs e)
        {
            txtBoxFrom.Text = txtBoxTo.Text;
            txtBoxTo.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtBoxTo.Text = System.Web.HttpUtility.UrlDecode(txtBoxFrom.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtBoxTo.Text = System.Web.HttpUtility.HtmlEncode(txtBoxFrom.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtBoxTo.Text = System.Web.HttpUtility.UrlEncode(txtBoxFrom.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtBoxTo.Text = txtBoxFrom.Text.Replace(textBox3.Text, "\r\n\r\n");
        }
    }
}
