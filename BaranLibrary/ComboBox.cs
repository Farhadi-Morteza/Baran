using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baran.Windows.Forms
{
    [System.Drawing.ToolboxBitmap(typeof(System.Windows.Forms.ComboBox))]
    public class ComboBox : System.Windows.Forms.ComboBox
    {
        static int intNumberOfEntersToComboBox = 0;
        protected override void OnEnter(EventArgs e)
        {
            intNumberOfEntersToComboBox++;
            if (intNumberOfEntersToComboBox == 1)
            {
                return;
            }
            else
            {
                base.OnEnter(e);
                this.DroppedDown = true;
                this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            }
            
        }
        public ComboBox()
        {
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }
    }
}
