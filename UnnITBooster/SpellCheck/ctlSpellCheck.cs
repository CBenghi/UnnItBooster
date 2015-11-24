using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHunspell;
using System.Text.RegularExpressions;
using System.IO;

namespace StudentsFetcher.SpellCheck
{
    class ctlSpellCheck : TextBox
    {
        public string DictLanguage { get; set; }
        public ctlSpellCheck()
        {
            DictLanguage = "en_GB";
        }

        List<string> ignoreText = new List<string>();

        protected override void OnKeyDown(KeyEventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(".");
            string d2 = d.FullName;
            if (e.KeyCode == Keys.Up && e.Alt)
            {
                using (Hunspell hunspell = new Hunspell(DictLanguage + ".aff", DictLanguage + ".dic"))
                {
                    Dictionary<string, string> Replacements = new Dictionary<string, string>();

                    // string[] split = Text.Split(new char[] { ' ', '!', '?', '.', ',', ':', ';', '\n', '\r', '(', ')', '-', '=' }, StringSplitOptions.RemoveEmptyEntries);
                    // foreach (string word in split)
                    var mts = Regex.Matches(Text, "\\b\\w*\\b");

                    for (int i = 0; i < mts.Count; i++)
                    {
                        string word = mts[i].Value;
                        if (Replacements.ContainsKey(word) || ignoreText.Contains(word))
                            continue;

                        bool correct = hunspell.Spell(word);
                        if (!correct)
                        {
                            frmSpeller sp = new frmSpeller(word, hunspell);
                            sp.ShowDialog();
                            if (sp.ResultAction == frmSpeller.Action.Stop)
                                break;
                            if (sp.ResultAction == frmSpeller.Action.keep)
                            {
                                if (!ignoreText.Contains(word))
                                    ignoreText.Add(word);
                            }
                            else
                            {
                                Replacements.Add(word, sp.ResultString);
                            }
                        }
                    }
                    string outv = this.Text;
                    foreach (var item in Replacements.Keys)
                    {
                        outv = Regex.Replace(outv, "\\b" + item + "\\b", Replacements[item]);
                    }
                    this.Text = outv;
                    //Console.WriteLine("Make suggestions for the word 'Recommendatio'");
                    //List<string> suggestions = hunspell.Suggest("Recommendatio");
                    //Console.WriteLine("There are " + suggestions.Count.ToString() + " suggestions");
                    //foreach (string suggestion in suggestions)
                    //{
                    //    Console.WriteLine("Suggestion is: " + suggestion);
                    //}
                }
            }
            

            base.OnKeyDown(e);
        }
    }
}
