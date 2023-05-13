using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtendedTextBox
{
	public class ExtTextBox : TextBox
	{
		public CharacterCasing TextCase { get; internal set; }
		public TextTypes TextType { get; internal set; }
		public bool Wrapping { get; internal set; }
		public bool SpellCheck { get; internal set; }
		public string OriginalText { get; internal set; } = "";
		public Color ChangedColour { get; internal set; }

		public enum TextTypes
		{
			String,
			Int,
			Currency,
			Name
		}
	}
}
