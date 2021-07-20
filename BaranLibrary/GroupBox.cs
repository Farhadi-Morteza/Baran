namespace Baran.Windows.Forms
{
    //[System.Drawing.ToolboxBitmap(typeof(System.Windows.Forms.GroupBox))]
    //public class GroupBox : System.Windows.Forms.GroupBox
    [System.Drawing.ToolboxBitmap(typeof(Infragistics.Win.Misc.UltraGroupBox))]
    public class GroupBox : Infragistics.Win.Misc.UltraGroupBox
    {
        public GroupBox()
        {
            //this.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.Dotted;
            //this.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.RightOnBorder;        
            this.Text = string.Empty;
            this.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;

        }

        //protected override void OnPaint(System.Windows.Forms.PaintEventArgs pe)
        //{
        //    //pe.Graphics.FillRectangle(System.Drawing.Brushes.Azure, this.ClientRectangle);
        //    base.OnPaint(pe);
        //    //this.Appearance.BackColor = BaranLibrary.GeneralProperties.BaseColor;
        //}
    }
}
