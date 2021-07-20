namespace Baran.Windows.Forms
{
    [System.Drawing.ToolboxBitmap(typeof(System.Windows.Forms.TextBox))]
    //[System.Drawing.ToolboxBitmap(typeof(Infragistics.Win.UltraWinEditors.UltraTextEditor))]
    public class WinTextBox :System.Windows.Forms.TextBox // Infragistics.Win.UltraWinEditors.UltraTextEditor//  
    {
        private bool _required;
        private bool _selectAllChar;
        private bool _editableText = true;
        private bool _Removable = false;
        private bool _Resizable = false;

        bool IsDrag = false;
        int lastSizeX = 0;
        int lastSizeY = 0;
        bool IsResizX = false;
        bool IsReSizeY = false;

        private string _caption;
        private System.Windows.Forms.ErrorProvider _errorProvider = null;
        private Baran.Windows.Forms.InputType _inputType;
        private InputLanguage _inputLanguage;
        System.Globalization.CultureInfo _faCultureInfo = new System.Globalization.CultureInfo("fa-IR", false);
        System.Globalization.CultureInfo _enCultureInfo = new System.Globalization.CultureInfo("en-US", false);
        private System.Drawing.Point MousDownLocation;

        public WinTextBox() : base()
        {
            
            Caption = "";
            Required = false;

            InputType = InputType.Text;
            InputLanguage = InputLanguage.Farsi;


            if (InputType == InputType.Currency)
                MaxLength = 18;

            //BorderStyle =  Infragistics.Win.UIElementBorderStyle.Default;// System.Windows.Forms.BorderStyle.FixedSingle; //
        }

        private string _unfomattedText;
        public string UnformattedText
        {
            get
            {
                return _unfomattedText;
            }
            set
            {
                _unfomattedText = value;
            }
        }

        public void ClearFormat()
        {
            if ((InputType == InputType.Currency) && (this.Text != ""))
            {
                UnformattedText = this.Text.Replace(",", "").Replace(" ", "").Replace("ریال", "").Replace("$", "");
            }

        }

        protected override void OnLeave(System.EventArgs e)
        {
            base.OnLeave(e);
            ClearFormat();
        }

        [System.ComponentModel.DefaultValue(false)]
        public bool Required
        {
            get
            {
                return (_required);
            }
            set
            {
                _required = value;
            }
        }

        [System.ComponentModel.DefaultValue(true)]
        public bool EditableText
        {
            get
            {
                return (_editableText);
            }
            set
            {
                _editableText = value;
            }
        }

        [System.ComponentModel.DefaultValue(false)]
        public bool SelectAllChar
        {
            get
            {
                return (_selectAllChar);
            }
            set
            {
                _selectAllChar = value;
            }
        }

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
                _Resizable= value;
            }
        }

        [System.ComponentModel.DefaultValue("")]
        public string Caption
        {
            get
            {
                return (_caption);
            }
            set
            {
                _caption = value;
            }
        }

        [System.ComponentModel.DefaultValue(Baran.Windows.Forms.InputType.Text)]
        public InputType InputType
        {
            get
            {
                return (_inputType);
            }
            set
            {
                _inputType = value;
            }
        }

        [System.ComponentModel.DefaultValue(InputLanguage.Farsi)]
        public InputLanguage InputLanguage
        {
            get
            {
                return (_inputLanguage);
            }
            set
            {
                _inputLanguage = value;

                switch (_inputLanguage)
                {
                    case InputLanguage.Farsi:
                        {
                            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                            break;
                        }

                    case InputLanguage.English:
                        {
                            RightToLeft = System.Windows.Forms.RightToLeft.No;
                            break;
                        }
                }
            }
        }

        //[System.ComponentModel.Browsable(false)]
        //public override System.Drawing.Font Font
        //{
        //    get
        //    {
        //        return base.Font;
        //    }
        //    set
        //    {
        //        base.Font = value;
        //    }
        //}

        [System.ComponentModel.ReadOnly(true)]
        public override System.Windows.Forms.RightToLeft RightToLeft
        {
            get
            {
                return base.RightToLeft;
            }
            set
            {
                base.RightToLeft = value;
            }
        }

        private System.Drawing.Color _PreviousBackColor;
        public System.Drawing.Color PreviousBackColor
        {
            get
            {
                return _PreviousBackColor;
            }
            set
            {
                _PreviousBackColor = value;
            }
        }

        private System.Drawing.Color _PreviousForeColor;
        public System.Drawing.Color PreviousForeColor
        {
            get
            {
                return _PreviousForeColor;
            }
            set
            {
                _PreviousForeColor = value;
            }
        }

        private int _FontSize;
        public int FontSize
        {
            get
            {
                return _FontSize;
            }
            set
            {
                _FontSize = value;
            }
        }

        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            #region Editable
                if (!EditableText)
                    e.Handled = true;
            #endregion

            #region Input Type
                switch (InputType)
                {
                    case InputType.Text:
                        break;

                    case InputType.Numeric:
                    case InputType.Currency:
                        {
                            if (TextLength >= 24) e.Handled = true ;
                            if (!(((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (e.KeyChar == 8) || (e.KeyChar == 46)))
                                e.Handled = true;
                            else
                            {
                                if ((Text.Length == 0) && (e.KeyChar == '0'))
                                    e.Handled = true;
                            }

                            break;
                        }
                    case InputType.Date:
                        {
                            if ((TextLength >= 10) &&(e.KeyChar >= '0') && (e.KeyChar <= '9'))
                                e.Handled = true;
                            break;
                        }
                }
            #endregion
        }

        protected override void OnValidating(System.ComponentModel.CancelEventArgs e)
        {
            base.OnValidating(e);

            if (Required)
            {
                if (Text == "")
                {
                    if (_errorProvider == null)
                        _errorProvider = new System.Windows.Forms.ErrorProvider();

                    string strMessage = "فيلد مربوط به" + " " + Caption + " " + "را وارد نکرده ايد!";

                    _errorProvider.SetIconAlignment(this, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
                    _errorProvider.SetError(this, strMessage);
                }
                else
                {
                    //_errorProvider.SetError(this, "");
                }
            }
        }

        protected override void OnValidated(System.EventArgs e)
        {
            base.OnValidated(e);

            switch (InputType)
            {
                case InputType.Currency:
                    {
                        if (Text != "")
                        {
                            switch (InputLanguage)
                            {
                                case InputLanguage.Farsi:
                                    {
                                        Select(Text.Length, 0);
                                        Text = Text + "ریال";
                                        break;
                                    }

                                case InputLanguage.English:
                                    {
                                        //Text = lngValue.ToString("$#,##0");
                                        break;
                                    }
                            }
                        }

                        break;
                    }
            }
        }

        protected override void OnKeyUp(System.Windows.Forms.KeyEventArgs e)
        {
            base.OnKeyUp(e);
            try
            {

                switch (InputType)
                {
                    case InputType.Currency:
                        {
                            Text = Text.Replace(",", "").Replace(" ", "").Replace("ریال", "").Replace("$", "");
                            if (Text != "")
                            {
                                long lngValue = System.Convert.ToInt64(Text);

                                switch (InputLanguage)
                                {
                                    case InputLanguage.Farsi:
                                        {
                                            Text = lngValue.ToString("#,##0");
                                            break;
                                        }

                                    case InputLanguage.English:
                                        {
                                            Text = lngValue.ToString("$#,##0");
                                            break;
                                        }
                                }
                            }
   
                            //To position the cursor at the end of the contents of a TextBox control
                            Select(Text.Length, 0);
                            break;
                            }
                    case InputType.Date:
                            {
                                Text = Text.Replace(",", "").Replace(" ", "").Replace("ریال", "").Replace("$", "").Replace("/", "");
                                long lngValue = System.Convert.ToInt64(Text);
                                if (Text != "")
                                    Text = lngValue.ToString("####/##/##");
                                Select(Text.Length, 0);
                                break;
                            }
                }
                this.Tag = this.Text.Replace(",", "").Replace(" ", "").Replace("ریال", "").Replace("$", "");
            }
            catch
            { }
        }

        protected override void OnEnter(System.EventArgs e)
        {
            BaranLibrary.GeneralProperties.ControlPreviousBackColore = this.BackColor;
            this.BackColor = BaranLibrary.GeneralProperties.ControlNewBackColor;

            this.PreviousForeColor = this.ForeColor;
            this.ForeColor = BaranLibrary.GeneralProperties.ControlNewForeColor;

            base.OnEnter(e);

            if (SelectAllChar)
            {
                if (Multiline)
                    Select(0, 0);
                else
                    SelectAll();
            }
          
            switch (InputType)
            {
                case InputType.Currency:
                    {
                        System.Windows.Forms.Clipboard.Clear();

                        Tag = Text.Replace(",", "").Replace(" ", "").Replace("ریال", "").Replace("$", "");

                        break;
                    }
            }

            switch (InputLanguage)
            {
                case InputLanguage.Farsi:
                    {
                        System.Windows.Forms.InputLanguage.CurrentInputLanguage =
                            System.Windows.Forms.InputLanguage.FromCulture(_faCultureInfo);

                        break;
                    }

                case InputLanguage.English:
                    {
                        System.Windows.Forms.InputLanguage.CurrentInputLanguage =
                            System.Windows.Forms.InputLanguage.FromCulture(_enCultureInfo);

                        break;
                    }
            }
        }

        protected override void OnLostFocus(System.EventArgs e)
        {
            base.OnLostFocus(e);
            this.BackColor = BaranLibrary.GeneralProperties.ControlPreviousBackColore;
            this.ForeColor = BaranLibrary.GeneralProperties.ControlPreviousForeColore;
        }

        protected override void OnMouseClick(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (SelectAllChar)
            {
                if (Multiline)
                    Select(0, 0);
                else
                    SelectAll();
            }
        }

        protected override void OnClick(System.EventArgs e)
        {
            base.OnClick(e);

            if (SelectAllChar)
            {
                if (Multiline)
                    Select(0, 0);
                else
                    SelectAll();
            }
        }

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

        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
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

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            //System.Windows.Forms.ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, System.Drawing.Color.Red, System.Windows.Forms.ButtonBorderStyle.Solid);

            //base.OnPaint(e);
            //System.Drawing.Pen penBorder = new System.Drawing.Pen(System.Drawing.Color.Red, 1);
            //System.Drawing.Rectangle rectBorder = new System.Drawing.Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            //e.Graphics.DrawRectangle(penBorder, rectBorder);

            //System.Drawing.Rectangle textRec = new System.Drawing.Rectangle(e.ClipRectangle.X + 1, e.ClipRectangle.Y + 1, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            //System.Windows.Forms.TextRenderer.DrawText(e.Graphics, Text, this.Font, textRec, this.ForeColor, this.BackColor, System.Windows.Forms.TextFormatFlags.Default);

            //System.Windows.Forms.ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, System.Drawing.Color.Green, System.Windows.Forms.ButtonBorderStyle.Solid);

            //int variance = 1;
            //this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            //System.Drawing.Pen BorderPen = new System.Drawing.Pen(System.Drawing.Color.Green);
            //System.Drawing.Graphics BorderGrafics = e.Graphics;
            //BorderGrafics.DrawRectangle(BorderPen, new System.Drawing.Rectangle(this.Location.X - variance, this.Location.Y - variance, this.Width + variance, this.Height + variance));
        }

        protected override void OnLayout(System.Windows.Forms.LayoutEventArgs levent)
        {
            base.OnLayout(levent);

            this.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            //int variance = 3;
            //this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            //System.Drawing.Graphics tt = this.CreateGraphics(); ;
            //System.Drawing.Pen BorderPen = new System.Drawing.Pen(System.Drawing.Color.Green);
            //tt.DrawRectangle(BorderPen, new System.Drawing.Rectangle(this.Location.X - variance, this.Location.Y - variance, this.Width + variance, this.Height + variance));

            this.ForeColor = System.Drawing.SystemColors.WindowText;
        }
    }
}

