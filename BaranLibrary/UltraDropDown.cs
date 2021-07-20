using Infragistics.Win;
namespace Baran.Windows.Forms
{
    [System.Drawing.ToolboxBitmap(typeof(Infragistics.Win.UltraWinGrid.UltraDropDown))]
    public class UltraDropDown : Infragistics.Win.UltraWinGrid.UltraDropDown
    {
        protected override void OnInitializeRowsCollection(Infragistics.Win.UltraWinGrid.InitializeRowsCollectionEventArgs e)
        {
            base.OnInitializeRowsCollection(e);
            
        }

        public UltraDropDown()
        {
            this.DisplayLayout.Appearance.TextHAlign = HAlign.Right;
            this.DisplayLayout.Appearance.TextVAlign = VAlign.Middle;

            
        }

        protected override void OnLayout(System.Windows.Forms.LayoutEventArgs levent)
        {
            base.OnLayout(levent);
    
        }
        public  void OnMyInitializeLayout(Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            
            e.Layout.Appearance.TextHAlign = HAlign.Right;
            e.Layout.Appearance.TextVAlign = VAlign.Middle;

            e.Layout.Override.RowAlternateAppearance.BackColor = System.Drawing.Color.LightYellow; //.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            e.Layout.Override.ActiveRowAppearance.BackColor = System.Drawing.Color.LightSkyBlue;
            e.Layout.Override.ActiveRowAppearance.ForeColor = System.Drawing.Color.DarkBlue;

            e.Layout.Override.HeaderAppearance.TextHAlign = HAlign.Center;
            e.Layout.Override.HeaderAppearance.TextVAlign = VAlign.Middle;

            e.Layout.BorderStyle = UIElementBorderStyle.Rounded3;
            e.Layout.CaptionVisible = DefaultableBoolean.True;
            e.Layout.CaptionAppearance.ForeColor = System.Drawing.Color.DarkBlue;

            e.Layout.Override.HeaderAppearance.BackColor = System.Drawing.Color.YellowGreen;
        }       
    }
}
