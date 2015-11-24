using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StudentsFetcher.SpellCheck
{
    public partial class frmSpeller : Form
    {
        public enum Action
        {
            keep,
            replace,
            Stop
        }

        private Hunspell _Speller;

        public frmSpeller(string origWord, Hunspell speller)
        {
            InitializeComponent();
            txtProblemWord.Text = origWord;
            _Speller = speller;
            List<string> suggestions = speller.Suggest(origWord);
            
            foreach (string suggestion in suggestions)
            {
                lstOptions.Items.Add(suggestion);
            }
        }

        public Action ResultAction { get; set; }
        public string ResultString { get; set; }

        private void cmdIgnore_Click(object sender, EventArgs e)
        {
            ResultAction = Action.keep;
            this.Close();
        }

        private void cmdChange_Click(object sender, EventArgs e)
        {
            ResultString = txtUse.Text;
            ResultAction = Action.replace;
            this.Close();
        }

        private void lstOptions_DoubleClick(object sender, EventArgs e)
        {
            ResultString = lstOptions.SelectedItems[0].Text;
            ResultAction = Action.replace;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResultAction = Action.Stop;
            this.Close();
        }

        private void frmSpeller_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ResultAction = Action.Stop;
                this.Close();
            }
        }

        private void lstOptions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmdIgnore_Click_1(object sender, EventArgs e)
        {
            ResultAction = Action.keep;
            this.Close();
        }
    }
}
