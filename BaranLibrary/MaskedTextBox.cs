namespace Baran.Windows.Forms
{
    [System.Drawing.ToolboxBitmap(typeof(System.Windows.Forms.MaskedTextBox))]
    public class MaskedTextBox : System.Windows.Forms.MaskedTextBox
    {
        private bool _required;
        private bool _selectAllChar;
        private string _caption;
        private string _unfomattedText;
        //private System.Windows.Forms.ErrorProvider _errorProvider = null;

        private Baran.Windows.Forms.InputType _inputType;
        private InputLanguage _inputLanguage;

        System.Globalization.CultureInfo _faCultureInfo = new System.Globalization.CultureInfo("fa-IR", false);
        System.Globalization.CultureInfo _enCultureInfo = new System.Globalization.CultureInfo("en-US", false);

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

        [System.ComponentModel.DefaultValue(Baran.Windows.Forms.InputType.Numeric)]
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

        [System.ComponentModel.DefaultValue(InputLanguage.English)]
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

        [System.ComponentModel.Browsable(false)]
        public override System.Drawing.Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
            }
        }

        [System.ComponentModel.ReadOnly(false)]
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

        public MaskedTextBox()
        {
            Required = false;

            InputType = InputType.Numeric;
            InputLanguage = InputLanguage.English;
            //this.BackColor = System.Drawing.Color.Transparent;
        }



        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            switch (InputType)
            {
                case InputType.Text:
                    break;

                case InputType.Numeric:
                case InputType.Currency:
                    {
                        if (!(((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (e.KeyChar == 8)))
                            e.Handled = true;
                        else
                        {
                            if ((Text.Length == 0) && (e.KeyChar == '0'))
                                e.Handled = true;
                        }

                        break;
                    }
            }
        }

        protected override void OnValidating(System.ComponentModel.CancelEventArgs e)
        {
            //base.OnValidating(e);

            //if (Required)
            //{
            //    if (Text == "")
            //    {
            //        if (_errorProvider == null)
            //            _errorProvider = new System.Windows.Forms.ErrorProvider();

            //        string strMessage = "فيلد مربوط به" + " " + Caption + " " + "را وارد نکرده ايد!";

            //        _errorProvider.SetIconAlignment(this, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            //        _errorProvider.SetError(this, strMessage);
            //    }
            //    else
            //    {
            //        _errorProvider.SetError(this, "");
            //    }
            //}
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
            }
        }

        protected override void OnEnter(System.EventArgs e)
        {
            base.OnEnter(e);

            if (SelectAllChar)
            {
                if (Multiline)
                    Select(0, 0);
                else
                    SelectAll();
            }
            /*
            switch (InputType)
            {
                case InputType.Currency:
                    {
                        System.Windows.Forms.Clipboard.Clear();

                        Text = Text.Replace(",", "").Replace(" ", "").Replace("ریال", "").Replace("$", "");

                        break;
                    }
            }
            */
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
    }
}
