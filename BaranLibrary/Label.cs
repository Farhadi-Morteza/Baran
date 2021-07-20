namespace Baran.Windows.Forms
{
    //[System.Drawing.ToolboxBitmap(typeof(System.Windows.Forms.Label))]
    [System.Drawing.ToolboxBitmap(typeof(Infragistics.Win.Misc.UltraLabel))]
    public class Label :Infragistics.Win.Misc.UltraLabel    // System.Windows.Forms.Label
    {
        private System.Drawing.Point MousDownLocation;

        private bool _Removable = false;
        private bool _Resizable = false;

        bool IsDrag = false;
        int lastSizeX = 0;
        int lastSizeY = 0;
        bool IsResizX = false;
        bool IsReSizeY = false;

        [System.ComponentModel.DefaultValue(false)]
        public bool Removable
        {
            get
            {
                return (_Removable);
            }
            set
            {
                _Removable = value;
            }
        }

        [System.ComponentModel.DefaultValue(false)]
        public bool Resizable
        {
            get
            {
                return (_Resizable);
            }
            set
            {
                _Resizable = value;
            }
        }

        public Label()
        {
            //AutoSize = true;
            Appearance.ForeColor = BaranLibrary.GeneralProperties.BaseControlForeColor;// System.Drawing.Color.DarkGreen;//.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            //AutoSize = true;
            //Font = new System.Drawing.Font("B koodak", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            //this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        }

        //protected override void OnPaint(System.Windows.Forms.PaintEventArgs pe)
        //{
        //    base.OnPaint(pe);
        //    this.Appearance.ForeColor = System.Drawing.Color.LightGray;//.LightGray;//.DarkBlue;//.DarkGreen;
        //    //this.Appearance.BackColor = System.Drawing.Color.Transparent;
        //}

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (Removable || Resizable)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    MousDownLocation = e.Location;


                    if (e.X >= (this.ClientRectangle.Right - 5) && e.X <= (this.ClientRectangle.Right + 5))
                    {
                        IsDrag = true;
                        lastSizeX = e.X;
                        IsResizX = true;
                    }
                    else if (e.Y >= (this.ClientRectangle.Bottom - 5) && e.Y <= (this.ClientRectangle.Bottom + 5))
                    {
                        IsDrag = true;
                        lastSizeY = e.Y;
                        IsReSizeY = true;
                    }

                }
            }
        }

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (Removable || Resizable)
            {
                if (IsDrag)
                {
                    IsDrag = false;
                    IsResizX = false;
                    IsReSizeY = false;
                }
            }
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (Removable && Resizable)
            {
                if (e.X >= (this.ClientRectangle.Right - 5) && e.X <= (this.ClientRectangle.Right + 5))
                    Cursor = System.Windows.Forms.Cursors.SizeWE;
                else if (e.Y >= (this.ClientRectangle.Bottom - 5) && e.Y <= (this.ClientRectangle.Bottom + 5))
                    Cursor = System.Windows.Forms.Cursors.SizeNS;
                else
                    Cursor = System.Windows.Forms.Cursors.SizeAll;


                if (IsDrag && IsResizX)
                {
                    this.Width += (e.X - lastSizeX);
                    lastSizeX = e.X;
                }
                else if (IsDrag && IsReSizeY)
                {
                    this.Height += (e.Y - lastSizeY);
                    lastSizeY = e.Y;
                }
                else if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    this.Left = e.X + Left - MousDownLocation.X;
                    this.Top = e.Y + Top - MousDownLocation.Y;
                }
            }
            else if (Removable)
            {
                Cursor = System.Windows.Forms.Cursors.SizeAll;
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    this.Left = e.X + Left - MousDownLocation.X;
                    this.Top = e.Y + Top - MousDownLocation.Y;
                }
            }
            else if (Resizable)
            {
                if (e.X >= (this.ClientRectangle.Right - 5) && e.X <= (this.ClientRectangle.Right + 5))
                    Cursor = System.Windows.Forms.Cursors.SizeWE;
                else if (e.Y >= (this.ClientRectangle.Bottom - 5) && e.Y <= (this.ClientRectangle.Bottom + 5))
                    Cursor = System.Windows.Forms.Cursors.SizeNS;
                else
                    Cursor = System.Windows.Forms.Cursors.IBeam;

                if (IsDrag)
                {
                    if (IsResizX)
                    {
                        this.Width += (e.X - lastSizeX);
                        lastSizeX = e.X;
                    }
                    else if (IsReSizeY)
                    {
                        this.Height += (e.Y - lastSizeY);
                        lastSizeY = e.Y;
                    }
                }
            }
        }

    }
}
