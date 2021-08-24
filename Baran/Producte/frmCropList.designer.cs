namespace Baran.Producte
{
    partial class frmCropList
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
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("spr_cmn_Crop_lst_Select", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CropID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BusinessCategoryName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("BusinessName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ActivityName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CropName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CropCategory");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Unitmeasurment");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RowID", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FreeSpace", 1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            this.dstProduct1 = new BaranDataAccess.Product.dstProduct();
            this.grdItem = new Baran.Windows.Forms.UltraGrid();
            ((System.ComponentModel.ISupportInitialize)(this.grpButons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpHeader)).BeginInit();
            this.grpHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMessage)).BeginInit();
            this.grpMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).BeginInit();
            this.grpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dstProduct1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItem)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMaxMin
            // 
            this.btnMaxMin.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            // 
            // grpButons
            // 
            this.grpButons.Location = new System.Drawing.Point(0, 420);
            this.grpButons.Size = new System.Drawing.Size(812, 67);
            // 
            // lblLine2
            // 
            this.lblLine2.Size = new System.Drawing.Size(810, 3);
            // 
            // grpHeader
            // 
            this.grpHeader.Size = new System.Drawing.Size(812, 75);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(750, 9);
            // 
            // lblCaption
            // 
            this.lblCaption.Location = new System.Drawing.Point(444, 22);
            // 
            // lblMessage
            // 
            this.lblMessage.Text = "";
            // 
            // lblLine1
            // 
            this.lblLine1.Size = new System.Drawing.Size(810, 3);
            // 
            // grpMessage
            // 
            this.grpMessage.Size = new System.Drawing.Size(812, 30);
            // 
            // lblLine3
            // 
            this.lblLine3.Location = new System.Drawing.Point(1, 311);
            this.lblLine3.Size = new System.Drawing.Size(810, 3);
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.grdItem);
            this.grpMain.Size = new System.Drawing.Size(812, 315);
            this.grpMain.Controls.SetChildIndex(this.lblLine3, 0);
            this.grpMain.Controls.SetChildIndex(this.grdItem, 0);
            // 
            // dstProduct1
            // 
            this.dstProduct1.DataSetName = "dstProduct";
            this.dstProduct1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // grdItem
            // 
            this.grdItem.BaseUltraGrid = this.grdItem;
            this.grdItem.DataMember = "spr_cmn_Crop_lst_Select";
            this.grdItem.DataSource = this.dstProduct1;
            appearance9.BackColor = System.Drawing.Color.Transparent;
            appearance9.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            appearance9.ForeColor = System.Drawing.Color.White;
            appearance9.TextHAlignAsString = "Right";
            appearance9.TextVAlignAsString = "Middle";
            this.grdItem.DisplayLayout.Appearance = appearance9;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.VisiblePosition = 1;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn1.Width = 29;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.Header.Caption = "حوزه";
            ultraGridColumn2.Header.VisiblePosition = 7;
            ultraGridColumn2.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            ultraGridColumn2.Width = 41;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.Header.Caption = "کسب و کار";
            ultraGridColumn3.Header.VisiblePosition = 6;
            ultraGridColumn3.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            ultraGridColumn3.Width = 66;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.Header.Caption = "فعالیت";
            ultraGridColumn4.Header.VisiblePosition = 5;
            ultraGridColumn4.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            ultraGridColumn4.Width = 44;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.Header.Caption = "محصول";
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Width = 50;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.Header.Caption = "نوع محصول";
            ultraGridColumn6.Header.VisiblePosition = 3;
            ultraGridColumn6.Width = 71;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.Header.Caption = "واحد اندازه گیری";
            ultraGridColumn7.Header.VisiblePosition = 2;
            ultraGridColumn7.Width = 98;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn8.Header.Caption = "ردیف";
            ultraGridColumn8.Header.VisiblePosition = 8;
            ultraGridColumn8.TabStop = false;
            ultraGridColumn8.Width = 41;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn9.Header.Caption = "";
            ultraGridColumn9.Header.VisiblePosition = 0;
            ultraGridColumn9.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            ultraGridColumn9.Width = 358;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9});
            ultraGridBand1.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            appearance1.ForeColor = System.Drawing.Color.DarkBlue;
            ultraGridBand1.Override.SummaryValueAppearance = appearance1;
            this.grdItem.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grdItem.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            appearance11.ForeColor = System.Drawing.Color.DarkBlue;
            this.grdItem.DisplayLayout.CaptionAppearance = appearance11;
            this.grdItem.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.True;
            appearance12.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance12.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance12.BorderColor = System.Drawing.SystemColors.Window;
            this.grdItem.DisplayLayout.GroupByBox.Appearance = appearance12;
            appearance13.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdItem.DisplayLayout.GroupByBox.BandLabelAppearance = appearance13;
            this.grdItem.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance14.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance14.BackColor2 = System.Drawing.SystemColors.Control;
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance14.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdItem.DisplayLayout.GroupByBox.PromptAppearance = appearance14;
            this.grdItem.DisplayLayout.MaxColScrollRegions = 1;
            this.grdItem.DisplayLayout.MaxRowScrollRegions = 1;
            appearance15.BackColor = System.Drawing.SystemColors.Window;
            appearance15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdItem.DisplayLayout.Override.ActiveCellAppearance = appearance15;
            appearance16.BackColor = System.Drawing.Color.Gray;
            appearance16.BackColor2 = System.Drawing.Color.Gray;
            appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance16.ForeColor = System.Drawing.Color.White;
            this.grdItem.DisplayLayout.Override.ActiveRowAppearance = appearance16;
            this.grdItem.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Rounded1;
            this.grdItem.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.None;
            this.grdItem.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            this.grdItem.DisplayLayout.Override.BorderStyleRowSelector = Infragistics.Win.UIElementBorderStyle.None;
            appearance17.BackColor = System.Drawing.SystemColors.Window;
            this.grdItem.DisplayLayout.Override.CardAreaAppearance = appearance17;
            appearance18.BorderColor = System.Drawing.Color.Gray;
            appearance18.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grdItem.DisplayLayout.Override.CellAppearance = appearance18;
            this.grdItem.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.grdItem.DisplayLayout.Override.CellPadding = 0;
            this.grdItem.DisplayLayout.Override.CellSpacing = 2;
            this.grdItem.DisplayLayout.Override.DefaultRowHeight = 25;
            this.grdItem.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Combo;
            this.grdItem.DisplayLayout.Override.FilterOperatorDropDownItems = ((Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems)(((((((((((((((((Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.Equals | Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.NotEquals) 
            | Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.LessThan) 
            | Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.LessThanOrEqualTo) 
            | Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.GreaterThan) 
            | Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.GreaterThanOrEqualTo) 
            | Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.Like) 
            | Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.Match) 
            | Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.NotLike) 
            | Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.DoesNotMatch) 
            | Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.StartsWith) 
            | Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.DoesNotStartWith) 
            | Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.EndsWith) 
            | Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.DoesNotEndWith) 
            | Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.Contains) 
            | Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.DoesNotContain) 
            | Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.Reserved)));
            this.grdItem.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.WithOperand;
            this.grdItem.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            appearance19.BackColor = System.Drawing.SystemColors.Control;
            appearance19.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance19.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance19.BorderColor = System.Drawing.SystemColors.Window;
            this.grdItem.DisplayLayout.Override.GroupByRowAppearance = appearance19;
            appearance32.BackColor = System.Drawing.Color.Transparent;
            appearance32.BackColor2 = System.Drawing.Color.Transparent;
            appearance32.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance32.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            appearance32.BorderColor = System.Drawing.Color.Transparent;
            appearance32.FontData.BoldAsString = "True";
            appearance32.FontData.Name = "B Nazanin";
            appearance32.FontData.SizeInPoints = 11F;
            appearance32.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(179)))), ((int)(((byte)(4)))));
            appearance32.TextHAlignAsString = "Center";
            appearance32.TextVAlignAsString = "Middle";
            this.grdItem.DisplayLayout.Override.HeaderAppearance = appearance32;
            this.grdItem.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdItem.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsVista;
            appearance33.ForeColor = System.Drawing.Color.Yellow;
            this.grdItem.DisplayLayout.Override.HotTrackRowAppearance = appearance33;
            this.grdItem.DisplayLayout.Override.MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
            appearance34.BackColor = System.Drawing.Color.Transparent;
            appearance34.BorderColor = System.Drawing.Color.Silver;
            this.grdItem.DisplayLayout.Override.RowAppearance = appearance34;
            this.grdItem.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance35.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdItem.DisplayLayout.Override.TemplateAddRowAppearance = appearance35;
            appearance36.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            scrollBarLook1.Appearance = appearance36;
            appearance37.BackColor = System.Drawing.Color.DarkGray;
            appearance37.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            scrollBarLook1.ButtonAppearance = appearance37;
            appearance38.BackColor = System.Drawing.Color.Gray;
            appearance38.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            scrollBarLook1.ThumbAppearance = appearance38;
            appearance39.BackColor = System.Drawing.Color.DarkGray;
            appearance39.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            scrollBarLook1.TrackAppearance = appearance39;
            scrollBarLook1.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2007;
            this.grdItem.DisplayLayout.ScrollBarLook = scrollBarLook1;
            this.grdItem.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdItem.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdItem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.grdItem.InputLanguage = Baran.Windows.Forms.InputLanguage.Farsi;
            this.grdItem.Location = new System.Drawing.Point(1, 0);
            this.grdItem.Name = "grdItem";
            this.grdItem.Size = new System.Drawing.Size(810, 311);
            this.grdItem.SumColumnsWidth = 452;
            this.grdItem.TabIndex = 15;
            this.grdItem.AfterRowActivate += new System.EventHandler(this.grdItem_AfterRowActivate);
            // 
            // frmCropList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(812, 487);
            this.FormMessage = "";
            this.Name = "frmCropList";
            ((System.ComponentModel.ISupportInitialize)(this.grpButons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpHeader)).EndInit();
            this.grpHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMessage)).EndInit();
            this.grpMessage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).EndInit();
            this.grpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dstProduct1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BaranDataAccess.Product.dstProduct dstProduct1;
        private Windows.Forms.UltraGrid grdItem;
    }
}
