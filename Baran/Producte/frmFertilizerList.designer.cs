namespace Baran.Producte
{
    partial class frmFertilizerList
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
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("spr_src_Fertilizer_lst_Select", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FertilizerID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Name");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Manufacture");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RegistrationNumber");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FertilizerCategory");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ProductionCategory");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Description");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FreeSpace", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RowID", 1);
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            this.dstProduct1 = new BaranDataAccess.Product.dstProduct();
            this.grdItem = new Baran.Windows.Forms.UltraGrid();
            ((System.ComponentModel.ISupportInitialize)(this.grpHeader)).BeginInit();
            this.grpHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpButons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMessage)).BeginInit();
            this.grpMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).BeginInit();
            this.grpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dstProduct1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItem)).BeginInit();
            this.SuspendLayout();
            // 
            // grpHeader
            // 
            this.grpHeader.Size = new System.Drawing.Size(682, 74);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(618, 9);
            // 
            // btnMaxMin
            // 
            this.btnMaxMin.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            // 
            // lblMessage
            // 
            this.lblMessage.Text = "";
            // 
            // grpButons
            // 
            this.grpButons.Location = new System.Drawing.Point(0, 420);
            this.grpButons.Size = new System.Drawing.Size(682, 67);
            // 
            // lblLine2
            // 
            this.lblLine2.Location = new System.Drawing.Point(1, 70);
            this.lblLine2.Size = new System.Drawing.Size(680, 3);
            // 
            // lblLine1
            // 
            this.lblLine1.Size = new System.Drawing.Size(680, 3);
            // 
            // grpMessage
            // 
            this.grpMessage.Location = new System.Drawing.Point(0, 74);
            this.grpMessage.Size = new System.Drawing.Size(682, 30);
            // 
            // lblLine3
            // 
            this.lblLine3.Location = new System.Drawing.Point(1, 312);
            this.lblLine3.Size = new System.Drawing.Size(680, 3);
            // 
            // lblCaption
            // 
            this.lblCaption.Location = new System.Drawing.Point(316, 24);
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.grdItem);
            this.grpMain.Location = new System.Drawing.Point(0, 104);
            this.grpMain.Size = new System.Drawing.Size(682, 316);
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
            this.grdItem.DataMember = "spr_src_Fertilizer_lst_Select";
            this.grdItem.DataSource = this.dstProduct1;
            appearance28.BackColor = System.Drawing.Color.Transparent;
            appearance28.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            appearance28.ForeColor = System.Drawing.Color.White;
            appearance28.TextHAlignAsString = "Right";
            appearance28.TextVAlignAsString = "Middle";
            this.grdItem.DisplayLayout.Appearance = appearance28;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn1.Width = 29;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.Header.Caption = "نام تجاری کود";
            ultraGridColumn2.Header.VisiblePosition = 7;
            ultraGridColumn2.Width = 82;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.Header.Caption = "شرکت سازنده";
            ultraGridColumn3.Header.VisiblePosition = 4;
            ultraGridColumn3.Width = 82;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.Header.Caption = "شماره ثبت";
            ultraGridColumn4.Header.VisiblePosition = 6;
            ultraGridColumn4.Width = 66;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.Header.Caption = "وضعیت فیزیکی";
            ultraGridColumn5.Header.VisiblePosition = 5;
            ultraGridColumn5.Width = 90;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.Header.Caption = "نوع تولید";
            ultraGridColumn6.Header.VisiblePosition = 3;
            ultraGridColumn6.Width = 58;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.Header.Caption = "توضیحات";
            ultraGridColumn7.Header.VisiblePosition = 2;
            ultraGridColumn7.Width = 60;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn8.Header.Caption = "";
            ultraGridColumn8.Header.VisiblePosition = 1;
            ultraGridColumn8.Width = 160;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn9.Header.Caption = "ردیف";
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridColumn9.TabStop = false;
            ultraGridColumn9.Width = 41;
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
            appearance2.ForeColor = System.Drawing.Color.DarkBlue;
            this.grdItem.DisplayLayout.CaptionAppearance = appearance2;
            this.grdItem.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.True;
            appearance29.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance29.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance29.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance29.BorderColor = System.Drawing.SystemColors.Window;
            this.grdItem.DisplayLayout.GroupByBox.Appearance = appearance29;
            appearance30.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdItem.DisplayLayout.GroupByBox.BandLabelAppearance = appearance30;
            this.grdItem.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance31.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance31.BackColor2 = System.Drawing.SystemColors.Control;
            appearance31.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance31.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdItem.DisplayLayout.GroupByBox.PromptAppearance = appearance31;
            this.grdItem.DisplayLayout.MaxColScrollRegions = 1;
            this.grdItem.DisplayLayout.MaxRowScrollRegions = 1;
            appearance20.BackColor = System.Drawing.SystemColors.Window;
            appearance20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdItem.DisplayLayout.Override.ActiveCellAppearance = appearance20;
            appearance21.BackColor = System.Drawing.Color.Gray;
            appearance21.BackColor2 = System.Drawing.Color.Gray;
            appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance21.ForeColor = System.Drawing.Color.White;
            this.grdItem.DisplayLayout.Override.ActiveRowAppearance = appearance21;
            this.grdItem.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Rounded1;
            this.grdItem.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.None;
            this.grdItem.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            this.grdItem.DisplayLayout.Override.BorderStyleRowSelector = Infragistics.Win.UIElementBorderStyle.None;
            appearance22.BackColor = System.Drawing.SystemColors.Window;
            this.grdItem.DisplayLayout.Override.CardAreaAppearance = appearance22;
            appearance23.BorderColor = System.Drawing.Color.Gray;
            appearance23.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grdItem.DisplayLayout.Override.CellAppearance = appearance23;
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
            appearance24.BackColor = System.Drawing.SystemColors.Control;
            appearance24.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance24.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance24.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance24.BorderColor = System.Drawing.SystemColors.Window;
            this.grdItem.DisplayLayout.Override.GroupByRowAppearance = appearance24;
            appearance25.BackColor = System.Drawing.Color.Transparent;
            appearance25.BackColor2 = System.Drawing.Color.Transparent;
            appearance25.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            appearance25.BorderColor = System.Drawing.Color.Transparent;
            appearance25.FontData.BoldAsString = "True";
            appearance25.FontData.Name = "B Nazanin";
            appearance25.FontData.SizeInPoints = 11F;
            appearance25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(179)))), ((int)(((byte)(4)))));
            appearance25.TextHAlignAsString = "Center";
            appearance25.TextVAlignAsString = "Middle";
            this.grdItem.DisplayLayout.Override.HeaderAppearance = appearance25;
            this.grdItem.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdItem.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsVista;
            appearance3.ForeColor = System.Drawing.Color.Yellow;
            this.grdItem.DisplayLayout.Override.HotTrackRowAppearance = appearance3;
            this.grdItem.DisplayLayout.Override.MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
            appearance26.BackColor = System.Drawing.Color.Transparent;
            appearance26.BorderColor = System.Drawing.Color.Silver;
            this.grdItem.DisplayLayout.Override.RowAppearance = appearance26;
            this.grdItem.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance27.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdItem.DisplayLayout.Override.TemplateAddRowAppearance = appearance27;
            appearance4.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            scrollBarLook1.Appearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.DarkGray;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            scrollBarLook1.ButtonAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.Gray;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            scrollBarLook1.ThumbAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.DarkGray;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            scrollBarLook1.TrackAppearance = appearance7;
            scrollBarLook1.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2007;
            this.grdItem.DisplayLayout.ScrollBarLook = scrollBarLook1;
            this.grdItem.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdItem.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdItem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.grdItem.InputLanguage = Baran.Windows.Forms.InputLanguage.Farsi;
            this.grdItem.Location = new System.Drawing.Point(1, 0);
            this.grdItem.Name = "grdItem";
            this.grdItem.Size = new System.Drawing.Size(680, 312);
            this.grdItem.SumColumnsWidth = 520;
            this.grdItem.TabIndex = 15;
            this.grdItem.AfterRowActivate += new System.EventHandler(this.grdItem_AfterRowActivate);
            // 
            // frmFertilizerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(682, 487);
            this.FormMessage = "";
            this.Name = "frmFertilizerList";
            ((System.ComponentModel.ISupportInitialize)(this.grpHeader)).EndInit();
            this.grpHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpButons)).EndInit();
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
