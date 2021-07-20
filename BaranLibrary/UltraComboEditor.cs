
using System.Windows.Forms;
namespace Baran.Windows.Forms
{
    [System.Drawing.ToolboxBitmap(typeof(Infragistics.Win.UltraWinEditors.UltraComboEditor))]
    public class UltraComboEditor : Infragistics.Win.UltraWinEditors.UltraComboEditor
    {
        System.Globalization.CultureInfo _faCultureInfo = new System.Globalization.CultureInfo("fa-IR", false);
        System.Globalization.CultureInfo _enCultureInfo = new System.Globalization.CultureInfo("en-US", false);

        private InputLanguage _inputLanguage;
        private Editable _Editable;

        public UltraComboEditor()
        {
            this.InputLanguage = InputLanguage.Farsi;

            //this.Editable = Editable.Editable;

            //this.AllowDrop = true;
            //this.AlwaysInEditMode = true;

            this.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            //this.Text = "انتخاب آیتم"; // string.Empty;
            this.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.ForeColor = BaranLibrary.GeneralProperties.BaseControlForeColor;

            this.Appearance.BorderColor = BaranLibrary.GeneralProperties.BaseBorderColor;
            this.Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;

            this.ItemAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.ItemAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.ItemAppearance.BackColor = System.Drawing.Color.Transparent;// BaranLibrary.GeneralProperties.BaseColor;//.LightCyan;

            this.DropDownButtonAlignment = Infragistics.Win.ButtonAlignment.Right;//.Left;

            this.Text = null;// string.Empty;
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        }

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
                            //RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                            break;
                        }

                    case InputLanguage.English:
                        {
                            //RightToLeft = System.Windows.Forms.RightToLeft.No;
                            break;
                        }
                }
            }
        }

        public Editable Editable
        {
            get
            {
                return (_Editable);
            }
            set
            {
                _Editable = value;

                switch (_Editable)
                {
                    case Editable.Immutable:
                        this.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never;
                        this.Enabled = false;
                        break;
                    case Editable.Editable:
                        this.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always;
                        this.Enabled = true;
                        break;
                }
            }

        }

        protected override void OnEnter(System.EventArgs e)
        {
            //DropDown();
            DropDownStyle = Infragistics.Win.DropDownStyle.DropDown;

            //BaranLibrary.GeneralProperties.ControlPreviousBackColore = this.Appearance.BackColor;
            //BaranLibrary.GeneralProperties.ControlPreviousForeColore = this.Appearance.ForeColor;

            //this.Appearance.BackColor = BaranLibrary.GeneralProperties.ControlNewBackColor;
            //this.Appearance.ForeColor = BaranLibrary.GeneralProperties.ControlNewForeColor;

            this.Appearance.BorderColor = BaranLibrary.GeneralProperties.OnEnterBorderColor;
            this.Appearance.BackColor = this.Parent.BackColor;// BaranLibrary.GeneralProperties.BaseColor;

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

        protected override void OnGotFocus(System.EventArgs e)
        {
            base.OnGotFocus(e);
            DropDownStyle = Infragistics.Win.DropDownStyle.DropDown;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (Editable == Editable.Immutable)
            {
                e.Handled = true;
            }
        }

        protected override void OnLeave(System.EventArgs e)
        {
            base.OnLeave(e);
            this.Appearance.BorderColor = BaranLibrary.GeneralProperties.BaseBorderColor;
            //this.Appearance.BackColor = BaranLibrary.GeneralProperties.ControlPreviousBackColore;
            //this.Appearance.ForeColor = BaranLibrary.GeneralProperties.ControlPreviousForeColore;
        }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);
        //    Appearance.ForeColor = BaranLibrary.GeneralProperties.BaseControlForeColor;
        //    this.DropDownButtonAlignment = Infragistics.Win.ButtonAlignment.Right;//.Left;
        //    this.Appearance.BackColor = System.Drawing.Color.Transparent;
        //}

    }
}
