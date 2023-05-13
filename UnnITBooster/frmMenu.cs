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
					where Attribute.IsDefined(type, typeof(AmmFormAttributes))
					select type;

			var menuData = (from item in q
							let atts = item.GetCustomAttributes(false)
							let att = atts[0] as AmmFormAttributes
							select new MenuData(att, item)).ToList().OrderBy(x => x.Att.Order);
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
			public MenuData(AmmFormAttributes att, Type type)
			{
				Att = att;
				Type = type;
			}

			public AmmFormAttributes Att;
			public Type Type;
		}


		private void AddButton(AmmFormAttributes att, Type item)
		{
			// create the button
			//
			var addButton = new Button
			{
				Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
				AutoSize = true,
				Location = new System.Drawing.Point(3, 3),
				Name = item.Name,
				Size = new System.Drawing.Size(257, 35),
				TabIndex = 0,
				Text = att.ButtonText,
				UseVisualStyleBackColor = true,
				Tag = item
			};
			addButton.Click += AddButton_Click;

			flowLayoutPanel1.Controls.Add(addButton);
		}


		void AddButton_Click(object sender, EventArgs e)
		{
			var t = ((Button)sender).Tag as Type;
			if (t == null)
				return;
			var instance = Activator.CreateInstance(t);
			var f = instance as Form;

			f?.Show();
		}
	}
}
