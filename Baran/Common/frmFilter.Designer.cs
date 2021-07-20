namespace Baran.Common
{
    partial class frmFilter
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            this.grbTools = new Baran.Windows.Forms.GroupBox();
            this.btnClear = new Baran.Windows.Forms.Button();
            this.btnOK = new Baran.Windows.Forms.Button();
            this.btnCancle = new Baran.Windows.Forms.Button();
            this.grdFilter = new Baran.Windows.Forms.UltraGrid();
            this.ultraDataSource1 = new Infragistics.Win.UltraWinDataSource.UltraDataSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).BeginInit();
            this.grpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)(this.grbTools)).BeginInit();
            this.grbTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.Location = new System.Drawing.Point(201, 23);
            this.lblCaption.Text = "فیلتر";
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.grdFilter);
            this.grpMain.Controls.Add(this.grbTools);
            this.grpMain.Size = new System.Drawing.Size(553, 384);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(487, 3);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // lblMessage
            // 
            this.lblMessage.Size = new System.Drawing.Size(456, 20);
            this.lblMessage.Text = "فیلتر";
            // 
            // grpHeader
            // 
            this.grpHeader.Size = new System.Drawing.Size(553, 65);
            // 
            // grbTools
            // 
            this.grbTools.Controls.Add(this.btnClear);
            this.grbTools.Controls.Add(this.btnOK);
            this.grbTools.Controls.Add(this.btnCancle);
            this.grbTools.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grbTools.Location = new System.Drawing.Point(3, 319);
            this.grbTools.Name = "grbTools";
            this.grbTools.Size = new System.Drawing.Size(547, 62);
            this.grbTools.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(240, 19);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(93, 24);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "پاک";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(339, 19);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(93, 24);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "تایید";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(438, 19);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(93, 24);
            this.btnCancle.TabIndex = 0;
            this.btnCancle.Text = "انصراف";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // grdFilter
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grdFilter.DisplayLayout.Appearance = appearance1;
            this.grdFilter.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdFilter.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.grdFilter.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdFilter.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.grdFilter.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance3.BackColor2 = System.Drawing.SystemColors.Control;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdFilter.DisplayLayout.GroupByBox.PromptAppearance = appearance3;
            this.grdFilter.DisplayLayout.MaxColScrollRegions = 1;
            this.grdFilter.DisplayLayout.MaxRowScrollRegions = 1;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            appearance7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdFilter.DisplayLayout.Override.ActiveCellAppearance = appearance7;
            appearance10.BackColor = System.Drawing.SystemColors.Highlight;
            appearance10.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdFilter.DisplayLayout.Override.ActiveRowAppearance = appearance10;
            this.grdFilter.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grdFilter.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            this.grdFilter.DisplayLayout.Override.CardAreaAppearance = appearance12;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grdFilter.DisplayLayout.Override.CellAppearance = appearance8;
            this.grdFilter.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grdFilter.DisplayLayout.Override.CellPadding = 0;
            appearance6.BackColor = System.Drawing.SystemColors.Control;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.grdFilter.DisplayLayout.Override.GroupByRowAppearance = appearance6;
            appearance5.TextHAlignAsString = "Left";
            this.grdFilter.DisplayLayout.Override.HeaderAppearance = appearance5;
            this.grdFilter.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdFilter.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.grdFilter.DisplayLayout.Override.RowAppearance = appearance11;
            this.grdFilter.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance9.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdFilter.DisplayLayout.Override.TemplateAddRowAppearance = appearance9;
            this.grdFilter.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdFilter.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdFilter.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.grdFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdFilter.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.grdFilter.Location = new System.Drawing.Point(3, 0);
            this.grdFilter.Name = "grdFilter";
            this.grdFilter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdFilter.Size = new System.Drawing.Size(547, 319);
            this.grdFilter.TabIndex = 1;
            this.grdFilter.Text = "ultraGrid1";
            // 
            // frmFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(553, 449);
            this.FormCaption = "فیلتر";
            this.FormMessage = "فیلتر";
            this.Name = "frmFilter";
            this.Text = "فیلتر";
            this.Load += new System.EventHandler(this.frmFilter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).EndInit();
            this.grpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbTools)).EndInit();
            this.grbTools.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraDataSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Baran.Windows.Forms.GroupBox grbTools;
        private Baran.Windows.Forms.Button btnClear;
        private Baran.Windows.Forms.Button btnOK;
        private Baran.Windows.Forms.Button btnCancle;
        private Windows.Forms.UltraGrid grdFilter;
        private Infragistics.Win.UltraWinDataSource.UltraDataSource ultraDataSource1;
    }
}
