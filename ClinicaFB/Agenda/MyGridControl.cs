using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms.Tools.Win32API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFB.Agenda
{
	public class MyGridControl : GridControl
	{
		protected override void OnSetCursor(ref Message m)
		{
			base.OnSetCursor(ref m);
			POINT pt = this.PointToClient(Control.MousePosition);
			int row, col;
			if (this.PointToRowCol(pt, out row, out col, -1)
				&& row == 2 && col == 2)
			{
				Cursor.Current = Cursors.Cross;
			}
		}
	}
}
