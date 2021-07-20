namespace BaranLibrary
{
    partial class MaskedDate
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.mskDate = new Baran.Windows.Forms.UltraMaskedEdit();
            this.SuspendLayout();
            // 
            // mskDate
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.mskDate.Appearance = appearance1;
            this.mskDate.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.mskDate.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
            this.mskDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.mskDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mskDate.Editable = Baran.Windows.Forms.Editable.Editable;
            this.mskDate.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.mskDate.InputMask = "####/##/##";
            this.mskDate.Location = new System.Drawing.Point(0, 0);
            this.mskDate.Name = "mskDate";
            this.mskDate.Size = new System.Drawing.Size(73, 20);
            this.mskDate.TabIndex = 0;
            this.mskDate.Text = "____/__/__";
            // 
            // MaskedDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.mskDate);
            this.Name = "MaskedDate";
            this.Size = new System.Drawing.Size(73, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Baran.Windows.Forms.UltraMaskedEdit mskDate;



    }
}
