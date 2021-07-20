

using Infragistics.Win;
namespace Baran.Windows.Forms
{
    [System.Drawing.ToolboxBitmap(typeof(Infragistics.Win.UltraWinTabControl.UltraTabControl))]
    public class ultraTabControl : Infragistics.Win.UltraWinTabControl.UltraTabControl
    {
        public ultraTabControl()
        {
            this.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Flat;
            this.TabOrientation = Infragistics.Win.UltraWinTabs.TabOrientation.TopRight;
            this.CloseButtonLocation = Infragistics.Win.UltraWinTabs.TabCloseButtonLocation.None;
            this.Appearance.ForeColor = BaranLibrary.GeneralProperties.BaseControlForeColor;
            this.Dock = System.Windows.Forms.DockStyle.Fill;
           
        }

    }
}
