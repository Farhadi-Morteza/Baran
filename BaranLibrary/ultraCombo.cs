using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baran.Windows.Forms
{
    [System.Drawing.ToolboxBitmap(typeof(Infragistics.Win.UltraWinGrid.UltraCombo))]
    public class ultraCombo : Infragistics.Win.UltraWinGrid.UltraCombo
    {
        public ultraCombo()
        {
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.ForeColor = System.Drawing.Color.White;
            this.Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
        }
    }

}
