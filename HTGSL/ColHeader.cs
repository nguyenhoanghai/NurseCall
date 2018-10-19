using System;
using System.Windows.Forms;
namespace HTGSL
{
	public class ColHeader : ColumnHeader
	{
		public bool ascending;
		public ColHeader(string text, int width, HorizontalAlignment align, bool asc)
		{
			base.Text = text;
			base.Width = width;
			base.TextAlign = align;
			this.ascending = asc;
		}
	}
}
