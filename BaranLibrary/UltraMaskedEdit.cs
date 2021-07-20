using Infragistics.Win;
namespace Baran.Windows.Forms
{
    [System.Drawing.ToolboxBitmap(typeof(Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit))]
    public class UltraMaskedEdit : Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    {
        public UltraMaskedEdit()
        {
            this.DataMode= Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw;
            this.DisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
            this.ClipMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
            this.DisplayStyle = EmbeddableElementDisplayStyle.Office2007;
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.ForeColor = BaranLibrary.GeneralProperties.BaseControlForeColor;
        }

        private Editable _Editable;
        public Editable Editable
        {
            get
            {
                return (_Editable);
            }
            set
            {
                _Editable = value;
            }
        }

        private bool _editableText = true;

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

        protected override void OnEnter(System.EventArgs e)
        {
            base.OnEnter(e);

            SelectAll();

            this.Appearance.BackColor = this.Parent.BackColor;
            this.Appearance.BorderColor = BaranLibrary.GeneralProperties.OnEnterBorderColor;
            this.Appearance.ForeColor = BaranLibrary.GeneralProperties.OnEnterControlForeColor;
        }

        protected override void OnLeave(System.EventArgs e)
        {
            base.OnLeave(e);

            this.Appearance.BorderColor = BaranLibrary.GeneralProperties.BaseBorderColor;
            this.Appearance.ForeColor = BaranLibrary.GeneralProperties.BaseControlForeColor;
        }

        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            #region Editable
            if (!EditableText)
                e.Handled = true;
            #endregion
        }
    }
}
