
namespace Baran.Windows.Forms
{
    [System.Drawing.ToolboxBitmap(typeof(Infragistics.Win.Misc.UltraExpandableGroupBox))]
    public class UltraExpandableGroupBox : Infragistics.Win.Misc.UltraExpandableGroupBox
    {
        public UltraExpandableGroupBox()
        {
            //this.Appearance.BackColor = BaranLibrary.GeneralProperties.BaseColor;
            //this.Panel.SizeChanged = true;
            this.Cursor = System.Windows.Forms.Cursors.Hand;

        }

        private bool _growOnHeight = false;
        [System.ComponentModel.DefaultValue(false)]
        public bool GrowOnHeight
        {
            get
            {
                return (_growOnHeight);
            }
            set
            {
                _growOnHeight = value;
            }
        }

        protected override void OnClientSizeChanged(System.EventArgs e)
        {
            base.OnClientSizeChanged(e);
        }

        protected override void OnPanelInitialized()
        {
            base.OnPanelInitialized();
            //if (GrowOnHeight)
            //{
            //    int Height = 0;
            //    foreach (System.Windows.Forms.Control control in this.Panel.Controls)
            //    {
            //        Height += control.Size.Height;
            //    }

            //    this.Size = new System.Drawing.Size(this.Size.Width, Height +10);
            //}
        }

        protected override void OnSizeChanged(System.EventArgs e)
        {
            base.OnSizeChanged(e);
            //if (GrowOnHeight)
            //{
            //    int Height = 0;
            //    foreach (System.Windows.Forms.Control control in this.Panel.Controls)
            //    {
            //        Height += control.Size.Height;
            //    }

            //    this.Size = new System.Drawing.Size(this.Size.Width, Height + 10);
            //}
        }

        protected override void OnClick(System.EventArgs e)
        {
            base.OnClick(e);

            if (this.Expanded)
                this.Expanded = false;
            else
                this.Expanded = true;
        }
    }
}
