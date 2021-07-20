namespace Baran.Common
{
    partial class frmFilterNew
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            this.grbTools = new Baran.Windows.Forms.GroupBox();
            this.btnClear = new Baran.Windows.Forms.Button();
            this.btnOK = new Baran.Windows.Forms.Button();
            this.btnCancle = new Baran.Windows.Forms.Button();
            this.grbItems = new Baran.Windows.Forms.GroupBox();
            this.grdFilter = new Baran.Windows.Forms.UltraGrid();
            this.mnuFilterMenustrip = new Baran.Windows.Forms.Menustrip();
            this.mnu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClear = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConfirm = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).BeginInit();
            this.grpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbTools)).BeginInit();
            this.grbTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grbItems)).BeginInit();
            this.grbItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFilter)).BeginInit();
            this.mnuFilterMenustrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.Location = new System.Drawing.Point(295, 23);
            this.lblCaption.Text = "فیلتر";
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.grbItems);
            this.grpMain.Controls.Add(this.grbTools);
            this.grpMain.Location = new System.Drawing.Point(21, 65);
            this.grpMain.Size = new System.Drawing.Size(647, 429);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(581, 3);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // grpHeader
            // 
            this.grpHeader.Location = new System.Drawing.Point(21, 0);
            this.grpHeader.Size = new System.Drawing.Size(647, 65);
            // 
            // grbTools
            // 
            this.grbTools.Controls.Add(this.btnClear);
            this.grbTools.Controls.Add(this.btnOK);
            this.grbTools.Controls.Add(this.btnCancle);
            this.grbTools.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grbTools.Location = new System.Drawing.Point(3, 364);
            this.grbTools.Name = "grbTools";
            this.grbTools.Size = new System.Drawing.Size(641, 62);
            this.grbTools.TabIndex = 1;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(313, 18);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(103, 33);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "پاک   F7";
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(422, 18);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(99, 33);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "تایید   F10";
            this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(527, 18);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(106, 33);
            this.btnCancle.TabIndex = 0;
            this.btnCancle.Text = "انصراف    F12";
            this.btnCancle.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // grbItems
            // 
            this.grbItems.Controls.Add(this.grdFilter);
            this.grbItems.Controls.Add(this.mnuFilterMenustrip);
            this.grbItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbItems.Location = new System.Drawing.Point(3, 0);
            this.grbItems.Name = "grbItems";
            this.grbItems.Size = new System.Drawing.Size(641, 364);
            this.grbItems.TabIndex = 2;
            // 
            // grdFilter
            // 
            appearance2.BackColor = System.Drawing.SystemColors.Window;
            appearance2.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.grdFilter.DisplayLayout.Appearance = appearance2;
            this.grdFilter.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdFilter.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.BorderColor = System.Drawing.SystemColors.Window;
            this.grdFilter.DisplayLayout.GroupByBox.Appearance = appearance3;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdFilter.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.grdFilter.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance5.BackColor2 = System.Drawing.SystemColors.Control;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdFilter.DisplayLayout.GroupByBox.PromptAppearance = appearance5;
            this.grdFilter.DisplayLayout.MaxColScrollRegions = 1;
            this.grdFilter.DisplayLayout.MaxRowScrollRegions = 1;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            appearance6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdFilter.DisplayLayout.Override.ActiveCellAppearance = appearance6;
            appearance7.BackColor = System.Drawing.SystemColors.Highlight;
            appearance7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdFilter.DisplayLayout.Override.ActiveRowAppearance = appearance7;
            this.grdFilter.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grdFilter.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            this.grdFilter.DisplayLayout.Override.CardAreaAppearance = appearance8;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grdFilter.DisplayLayout.Override.CellAppearance = appearance9;
            this.grdFilter.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grdFilter.DisplayLayout.Override.CellPadding = 0;
            appearance10.BackColor = System.Drawing.SystemColors.Control;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance10.BorderColor = System.Drawing.SystemColors.Window;
            this.grdFilter.DisplayLayout.Override.GroupByRowAppearance = appearance10;
            appearance11.TextHAlignAsString = "Left";
            this.grdFilter.DisplayLayout.Override.HeaderAppearance = appearance11;
            this.grdFilter.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdFilter.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance1.BackColor = System.Drawing.Color.RoyalBlue;
            this.grdFilter.DisplayLayout.Override.RowAlternateAppearance = appearance1;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            this.grdFilter.DisplayLayout.Override.RowAppearance = appearance12;
            this.grdFilter.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance13.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdFilter.DisplayLayout.Override.TemplateAddRowAppearance = appearance13;
            this.grdFilter.DisplayLayout.RowConnectorColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.grdFilter.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.grdFilter.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdFilter.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdFilter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.grdFilter.Location = new System.Drawing.Point(3, 0);
            this.grdFilter.Name = "grdFilter";
            this.grdFilter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grdFilter.Size = new System.Drawing.Size(635, 361);
            this.grdFilter.TabIndex = 0;
            this.grdFilter.Text = ".";
            this.grdFilter.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdFilter_InitializeLayout);
            this.grdFilter.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.grdFilter_CellChange);
            // 
            // mnuFilterMenustrip
            // 
            this.mnuFilterMenustrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu});
            this.mnuFilterMenustrip.Location = new System.Drawing.Point(3, 0);
            this.mnuFilterMenustrip.Name = "mnuFilterMenustrip";
            this.mnuFilterMenustrip.Size = new System.Drawing.Size(656, 24);
            this.mnuFilterMenustrip.TabIndex = 1;
            this.mnuFilterMenustrip.Text = "menustrip1";
            this.mnuFilterMenustrip.Visible = false;
            // 
            // mnu
            // 
            this.mnu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCancel,
            this.mnuClear,
            this.mnuConfirm});
            this.mnu.Name = "mnu";
            this.mnu.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.mnu.Size = new System.Drawing.Size(44, 20);
            this.mnu.Text = "mnu";
            // 
            // mnuCancel
            // 
            this.mnuCancel.Name = "mnuCancel";
            this.mnuCancel.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.mnuCancel.Size = new System.Drawing.Size(143, 22);
            this.mnuCancel.Text = "Cancel";
            this.mnuCancel.Click += new System.EventHandler(this.mnuCancel_Click);
            // 
            // mnuClear
            // 
            this.mnuClear.Name = "mnuClear";
            this.mnuClear.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.mnuClear.Size = new System.Drawing.Size(143, 22);
            this.mnuClear.Text = "Clear";
            this.mnuClear.Click += new System.EventHandler(this.mnuClear_Click);
            // 
            // mnuConfirm
            // 
            this.mnuConfirm.Name = "mnuConfirm";
            this.mnuConfirm.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.mnuConfirm.Size = new System.Drawing.Size(143, 22);
            this.mnuConfirm.Text = "Confirm";
            this.mnuConfirm.Click += new System.EventHandler(this.mnuConfirm_Click);
            // 
            // frmFilterNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(668, 494);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.FormCaption = "فیلتر";
            this.MainMenuStrip = this.mnuFilterMenustrip;
            this.Name = "frmFilterNew";
            this.Text = "فیلتر";
            this.Load += new System.EventHandler(this.frmFilterNew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).EndInit();
            this.grpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();

            ((System.ComponentModel.ISupportInitialize)(this.grbTools)).EndInit();
            this.grbTools.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grbItems)).EndInit();
            this.grbItems.ResumeLayout(false);
            this.grbItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFilter)).EndInit();
            this.mnuFilterMenustrip.ResumeLayout(false);
            this.mnuFilterMenustrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Baran.Windows.Forms.GroupBox grbTools;
        private Baran.Windows.Forms.Button btnClear;
        private Baran.Windows.Forms.Button btnOK;
        private Baran.Windows.Forms.Button btnCancle;
        private Baran.Windows.Forms.GroupBox grbItems;
        private Baran.Windows.Forms.UltraGrid grdFilter;
        private Windows.Forms.Menustrip mnuFilterMenustrip;
        private System.Windows.Forms.ToolStripMenuItem mnu;
        private System.Windows.Forms.ToolStripMenuItem mnuCancel;
        private System.Windows.Forms.ToolStripMenuItem mnuClear;
        private System.Windows.Forms.ToolStripMenuItem mnuConfirm;
    }
}
