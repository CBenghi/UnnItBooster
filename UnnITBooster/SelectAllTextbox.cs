using System;
using System.Windows.Forms;

namespace StudentsFetcher
{
	public class SelectAllTextbox : System.Windows.Forms.TextBox
	{
		private bool _focused;

		protected override void OnEnter(EventArgs e)
		{
			base.OnEnter(e);
			if (MouseButtons == MouseButtons.None)
			{
				SelectAll();
				_focused = true;
			}
		}

		protected override void OnLeave(EventArgs e)
		{
			base.OnLeave(e);
			_focused = false;
		}

		protected override void OnMouseUp(MouseEventArgs mevent)
		{
			base.OnMouseUp(mevent);
			if (!_focused)
			{
				if (SelectionLength == 0)
					SelectAll();
				_focused = true;
			}
		}
	}
}
