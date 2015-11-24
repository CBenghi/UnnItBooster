using System;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;

namespace StudentsFetcher
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();


            var q = from type in Assembly.GetExecutingAssembly().GetTypes()
                    where Attribute.IsDefined(type, typeof(AMMFormAttributes))
                    select type;

            var menuData = (from item in q
                let atts = item.GetCustomAttributes(false)
                let att = atts[0] as AMMFormAttributes
                select new MenuData()
                {
                    Att = att,
                    Type = item
                }).ToList().OrderBy(x => x.Att.Order);

            foreach (var menuitem in menuData)
            {
                AddButton(menuitem);
            }
        }

        private void AddButton(MenuData menuitem)
        {
            AddButton(menuitem.Att, menuitem.Type);
        }

        private class MenuData
        {
            public AMMFormAttributes Att;
            public Type Type;
        }


        private void AddButton(AMMFormAttributes att, Type item)
        {
            // create the button
            //
            var addButton = new Button();
            addButton.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            addButton.AutoSize = true;
            addButton.Location = new System.Drawing.Point(3, 3);
            addButton.Name = item.Name;
            addButton.Size = new System.Drawing.Size(257, 35);
            addButton.TabIndex = 0;
            addButton.Text = att.ButtonText;
            addButton.UseVisualStyleBackColor = true;
            addButton.Tag = item;
            addButton.Click += new EventHandler(addButton_Click);

            this.flowLayoutPanel1.Controls.Add(addButton);
        }


        void addButton_Click(object sender, EventArgs e)
        {
            Type t = ((Button)sender).Tag as Type;
            if (t != null)
            {
                object instance = Activator.CreateInstance(t);
                Form f = instance as Form;

                if (f != null)
                {
                    f.Show();
                }
                if (instance.GetType() == typeof(Form))
                {

                }
            }
        }

        void CreateInstance<T>() where T : Form, new()
        {
            T t = new T();
            t.Show();
        }
    }
}
