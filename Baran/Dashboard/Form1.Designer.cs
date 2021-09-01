namespace Baran.Dashboard
{
    partial class Form1
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
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("spr_dsb_Worker_rpt", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LastName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FirstName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Date");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("WorkHours");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TreatedArea");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TaskName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FieldName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PartName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SubCollectionName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CollectionName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("WorkHoursDecimal");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LinkedArea");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FreeSpace", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RowID", 1);
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.SummarySettings summarySettings1 = new Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, null, "WorkHoursDecimal", 10, true, "spr_dsb_Worker_rpt", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "WorkHours", 3, true);
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.SummarySettings summarySettings2 = new Infragistics.Win.UltraWinGrid.SummarySettings("", Infragistics.Win.UltraWinGrid.SummaryType.Sum, null, "TreatedArea", 4, true, "spr_dsb_Worker_rpt", 0, Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn, "TreatedArea", 4, true);
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ultraGrid1 = new Baran.Windows.Forms.UltraGrid();
            ((System.ComponentModel.ISupportInitialize)(this.grpButons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpHeader)).BeginInit();
            this.grpHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMessage)).BeginInit();
            this.grpMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).BeginInit();
            this.grpMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMaxMin
            // 
            this.btnMaxMin.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            // 
            // grpButons
            // 
            this.grpButons.Location = new System.Drawing.Point(0, 577);
            this.grpButons.Size = new System.Drawing.Size(908, 75);
            // 
            // lblLine2
            // 
            this.lblLine2.Size = new System.Drawing.Size(906, 3);
            // 
            // grpHeader
            // 
            this.grpHeader.Size = new System.Drawing.Size(908, 75);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(843, 9);
            // 
            // lblCaption
            // 
            this.lblCaption.Location = new System.Drawing.Point(537, 22);
            // 
            // lblMessage
            // 
            this.lblMessage.Text = "";
            // 
            // lblLine1
            // 
            this.lblLine1.Size = new System.Drawing.Size(906, 3);
            // 
            // grpMessage
            // 
            this.grpMessage.Size = new System.Drawing.Size(908, 30);
            // 
            // lblLine3
            // 
            this.lblLine3.Location = new System.Drawing.Point(1, 468);
            this.lblLine3.Size = new System.Drawing.Size(906, 3);
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.tableLayoutPanel1);
            this.grpMain.Controls.Add(this.tlpMain);
            this.grpMain.Size = new System.Drawing.Size(908, 472);
            this.grpMain.Controls.SetChildIndex(this.lblLine3, 0);
            this.grpMain.Controls.SetChildIndex(this.tlpMain, 0);
            this.grpMain.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            // 
            // tlpMain
            // 
            this.tlpMain.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tlpMain.AutoSize = true;
            this.tlpMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Location = new System.Drawing.Point(13, -81);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(0, 400);
            this.tlpMain.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.ultraGrid1, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(17, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(875, 468);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // ultraGrid1
            // 
            this.ultraGrid1.BaseUltraGrid = this.ultraGrid1;
            this.ultraGrid1.DataMember = "spr_dsb_Worker_rpt";
            appearance32.BackColor = System.Drawing.Color.Transparent;
            appearance32.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            appearance32.ForeColor = System.Drawing.Color.White;
            appearance32.TextHAlignAsString = "Right";
            appearance32.TextVAlignAsString = "Middle";
            this.ultraGrid1.DisplayLayout.Appearance = appearance32;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.Caption = "نام خانوادگی";
            ultraGridColumn1.Header.VisiblePosition = 11;
            ultraGridColumn1.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            ultraGridColumn1.Width = 75;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.Header.Caption = "نام";
            ultraGridColumn2.Header.VisiblePosition = 10;
            ultraGridColumn2.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            ultraGridColumn2.Width = 41;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.Header.Caption = "تاریخ";
            ultraGridColumn3.Header.VisiblePosition = 9;
            ultraGridColumn3.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            ultraGridColumn3.Width = 41;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.Header.Caption = "فعالیت/ساعت";
            ultraGridColumn4.Header.VisiblePosition = 8;
            ultraGridColumn4.Width = 82;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.Header.Caption = "فعالیت؟هکتار";
            ultraGridColumn5.Header.VisiblePosition = 7;
            ultraGridColumn5.Width = 80;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.Header.Caption = "فعالیت";
            ultraGridColumn6.Header.VisiblePosition = 6;
            ultraGridColumn6.Width = 44;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.Header.Caption = "قطعه زمین";
            ultraGridColumn7.Header.VisiblePosition = 5;
            ultraGridColumn7.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            ultraGridColumn7.Width = 65;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn8.Header.Caption = "واحد فرعی";
            ultraGridColumn8.Header.VisiblePosition = 3;
            ultraGridColumn8.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            ultraGridColumn8.Width = 67;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn9.Header.Caption = "واحد";
            ultraGridColumn9.Header.VisiblePosition = 2;
            ultraGridColumn9.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            ultraGridColumn9.Width = 41;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn10.Header.Caption = "کشت و صنعت";
            ultraGridColumn10.Header.VisiblePosition = 1;
            ultraGridColumn10.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            ultraGridColumn10.Width = 83;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn11.Header.VisiblePosition = 12;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn11.Width = 41;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn12.Header.Caption = "مساحت-هکتار";
            ultraGridColumn12.Header.VisiblePosition = 4;
            ultraGridColumn12.Width = 88;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn13.Header.Caption = "";
            ultraGridColumn13.Header.VisiblePosition = 0;
            ultraGridColumn13.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            ultraGridColumn13.Width = 80;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn14.Header.Caption = "#";
            ultraGridColumn14.Header.VisiblePosition = 13;
            ultraGridColumn14.TabStop = false;
            ultraGridColumn14.Width = 41;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14});
            ultraGridBand1.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            appearance1.ForeColor = System.Drawing.Color.DarkBlue;
            ultraGridBand1.Override.SummaryValueAppearance = appearance1;
            summarySettings1.DisplayFormat = "{0:#,###,###,###.##}";
            summarySettings1.GroupBySummaryValueAppearance = appearance10;
            summarySettings1.ToolTipText = "فعالیت/ساعت";
            summarySettings2.DisplayFormat = "{0:#,###,###,###.##}";
            summarySettings2.GroupBySummaryValueAppearance = appearance11;
            summarySettings2.ToolTipText = "فعالیت/هکتار";
            ultraGridBand1.Summaries.AddRange(new Infragistics.Win.UltraWinGrid.SummarySettings[] {
            summarySettings1,
            summarySettings2});
            ultraGridBand1.SummaryFooterCaption = "";
            this.ultraGrid1.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ultraGrid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            appearance3.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance3.ForeColor = System.Drawing.Color.Black;
            this.ultraGrid1.DisplayLayout.CaptionAppearance = appearance3;
            this.ultraGrid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.True;
            appearance33.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance33.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance33.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance33.BorderColor = System.Drawing.SystemColors.Window;
            this.ultraGrid1.DisplayLayout.GroupByBox.Appearance = appearance33;
            appearance34.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ultraGrid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance34;
            this.ultraGrid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance35.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance35.BackColor2 = System.Drawing.SystemColors.Control;
            appearance35.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance35.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ultraGrid1.DisplayLayout.GroupByBox.PromptAppearance = appearance35;
            this.ultraGrid1.DisplayLayout.MaxColScrollRegions = 1;
            this.ultraGrid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance23.BackColor = System.Drawing.SystemColors.Window;
            appearance23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ultraGrid1.DisplayLayout.Override.ActiveCellAppearance = appearance23;
            appearance24.BackColor = System.Drawing.Color.Gray;
            appearance24.BackColor2 = System.Drawing.Color.Gray;
            appearance24.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance24.ForeColor = System.Drawing.Color.White;
            this.ultraGrid1.DisplayLayout.Override.ActiveRowAppearance = appearance24;
            this.ultraGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Rounded1;
            this.ultraGrid1.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.None;
            this.ultraGrid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            this.ultraGrid1.DisplayLayout.Override.BorderStyleRowSelector = Infragistics.Win.UIElementBorderStyle.None;
            appearance25.BackColor = System.Drawing.SystemColors.Window;
            this.ultraGrid1.DisplayLayout.Override.CardAreaAppearance = appearance25;
            appearance27.BorderColor = System.Drawing.Color.Gray;
            appearance27.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ultraGrid1.DisplayLayout.Override.CellAppearance = appearance27;
            this.ultraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.ultraGrid1.DisplayLayout.Override.CellPadding = 0;
            this.ultraGrid1.DisplayLayout.Override.CellSpacing = 2;
            this.ultraGrid1.DisplayLayout.Override.DefaultRowHeight = 25;
            this.ultraGrid1.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Combo;
            this.ultraGrid1.DisplayLayout.Override.FilterOperatorDropDownItems = ((Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems)(((((((((((((((((Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.Equals | Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.NotEquals) 
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
            this.ultraGrid1.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.WithOperand;
            this.ultraGrid1.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            appearance28.BackColor = System.Drawing.SystemColors.Control;
            appearance28.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance28.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance28.BorderColor = System.Drawing.SystemColors.Window;
            this.ultraGrid1.DisplayLayout.Override.GroupByRowAppearance = appearance28;
            appearance29.BackColor = System.Drawing.Color.Transparent;
            appearance29.BackColor2 = System.Drawing.Color.Transparent;
            appearance29.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance29.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            appearance29.BorderColor = System.Drawing.Color.Transparent;
            appearance29.FontData.BoldAsString = "True";
            appearance29.FontData.Name = "B Nazanin";
            appearance29.FontData.SizeInPoints = 11F;
            appearance29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(179)))), ((int)(((byte)(4)))));
            appearance29.TextHAlignAsString = "Center";
            appearance29.TextVAlignAsString = "Middle";
            this.ultraGrid1.DisplayLayout.Override.HeaderAppearance = appearance29;
            this.ultraGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ultraGrid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsVista;
            appearance4.ForeColor = System.Drawing.Color.Yellow;
            this.ultraGrid1.DisplayLayout.Override.HotTrackRowAppearance = appearance4;
            this.ultraGrid1.DisplayLayout.Override.MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
            appearance30.BackColor = System.Drawing.Color.Transparent;
            appearance30.BorderColor = System.Drawing.Color.Silver;
            this.ultraGrid1.DisplayLayout.Override.RowAppearance = appearance30;
            this.ultraGrid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance31.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ultraGrid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance31;
            appearance5.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            scrollBarLook1.Appearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.DarkGray;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            scrollBarLook1.ButtonAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.Gray;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            scrollBarLook1.ThumbAppearance = appearance7;
            appearance9.BackColor = System.Drawing.Color.DarkGray;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            scrollBarLook1.TrackAppearance = appearance9;
            scrollBarLook1.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2007;
            this.ultraGrid1.DisplayLayout.ScrollBarLook = scrollBarLook1;
            this.ultraGrid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ultraGrid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ultraGrid1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ultraGrid1.InputLanguage = Baran.Windows.Forms.InputLanguage.Farsi;
            this.ultraGrid1.Location = new System.Drawing.Point(3, 237);
            this.ultraGrid1.Name = "ultraGrid1";
            this.ultraGrid1.Size = new System.Drawing.Size(869, 228);
            this.ultraGrid1.SumColumnsWidth = 789;
            this.ultraGrid1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(908, 652);
            this.FormMessage = "";
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.grpButons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpHeader)).EndInit();
            this.grpHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMessage)).EndInit();
            this.grpMessage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).EndInit();
            this.grpMain.ResumeLayout(false);
            this.grpMain.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Windows.Forms.UltraGrid ultraGrid1;
    }
}
