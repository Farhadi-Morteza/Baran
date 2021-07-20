namespace Baran.Windows.Forms
{
    [System.Drawing.ToolboxBitmap(typeof(System.Windows.Forms.Button))]
    //[System.Drawing.ToolboxBitmap(typeof(Infragistics.Win.UltraWinEditors.button))
    public class Button : System.Windows.Forms.Button
    {
        public Button() : base()
        {
            FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FlatAppearance.BorderColor = BaranLibrary.GeneralProperties.BaseBorderColor;
            this.ForeColor = BaranLibrary.GeneralProperties.BaseControlForeColor;
        }

        //private bool _CircularButton;

        //[System.ComponentModel.DefaultValue(false)]
        //public bool CircularButton
        //{
        //    get
        //    {
        //        return(_CircularButton);
        //    }
        //    set
        //    {
        //        _CircularButton = value;
        //    }
        //}

        //Mouse Enter

        [System.ComponentModel.Browsable(true)]
        protected override void OnMouseEnter(System.EventArgs e)
        {
            base.OnMouseEnter(e);
            if (!(Font.Bold))
            {
                Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Bold);
            }

            Size = new System.Drawing.Size(this.Size.Width + 3, this.Size.Height + 3);

            //FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            //FlatAppearance.BorderSize = 1;
        }

        //Mouse Leave
        protected override void OnMouseLeave(System.EventArgs e)
        {
            base.OnMouseLeave(e);
            if (Font.Bold)
                Font = new System.Drawing.Font(Font, System.Drawing.FontStyle.Regular);

            Size = new System.Drawing.Size(this.Size.Width - 3, this.Size.Height - 3);

            //FlatAppearance.BorderSize = 0;
        }

       

        ////CircularButton
        //protected override void OnPaint(System.Windows.Forms.PaintEventArgs pevent)
        //{
        //    if (CircularButton)
        //    {
        //        System.Drawing.Drawing2D.GraphicsPath g = new System.Drawing.Drawing2D.GraphicsPath();
        //        g.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
        //        this.Region = new System.Drawing.Region(g);

        //        FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        //        FlatAppearance.BorderSize = 0;

        //    }
        //     base.OnPaint(pevent);
        //}
    }
}
