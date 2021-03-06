namespace Baran.Dashboard
{
    partial class frmFieldTaskListRpt
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
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("spr_dsb_FieldTaskList_rpt_Select", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FieldID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LinkedArea");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ProductionName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CropName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CultivarName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TaskName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("StatusName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ProductionTaskID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("StartDate");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EndDate");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FreeSpace", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RowID", 1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("New", 2);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Detail", 3);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Delete", 4);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Update", 5);
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.MainMap = new Demo.WindowsForms.Map();
            this.grdItem = new Baran.Windows.Forms.UltraGrid();
            this.dstDashboard1 = new BaranDataAccess.Dashboard.dstDashboard();
            this.grpControls = new Baran.Windows.Forms.GroupBox();
            this.cmbField = new Baran.Windows.Forms.UltraComboEditor();
            this.label1 = new Baran.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grpHeader)).BeginInit();
            this.grpHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMessage)).BeginInit();
            this.grpMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).BeginInit();
            this.grpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpButons)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstDashboard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpControls)).BeginInit();
            this.grpControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbField)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMaxMin
            // 
            this.btnMaxMin.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            // 
            // lblLine2
            // 
            this.lblLine2.Location = new System.Drawing.Point(1, 71);
            this.lblLine2.Size = new System.Drawing.Size(919, 3);
            // 
            // grpHeader
            // 
            this.grpHeader.Size = new System.Drawing.Size(921, 75);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(856, 9);
            // 
            // lblCaption
            // 
            this.lblCaption.Location = new System.Drawing.Point(550, 22);
            // 
            // lblMessage
            // 
            this.lblMessage.Text = "";
            // 
            // lblLine1
            // 
            this.lblLine1.Size = new System.Drawing.Size(919, 3);
            // 
            // grpMessage
            // 
            this.grpMessage.Location = new System.Drawing.Point(0, 75);
            this.grpMessage.Size = new System.Drawing.Size(921, 30);
            // 
            // lblLine3
            // 
            this.lblLine3.Location = new System.Drawing.Point(1, 447);
            this.lblLine3.Size = new System.Drawing.Size(919, 3);
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.tableLayoutPanel);
            this.grpMain.Controls.Add(this.grpControls);
            this.grpMain.Location = new System.Drawing.Point(0, 105);
            this.grpMain.Size = new System.Drawing.Size(921, 451);
            this.grpMain.Controls.SetChildIndex(this.lblLine3, 0);
            this.grpMain.Controls.SetChildIndex(this.grpControls, 0);
            this.grpMain.Controls.SetChildIndex(this.tableLayoutPanel, 0);
            // 
            // grpButons
            // 
            this.grpButons.Location = new System.Drawing.Point(0, 556);
            this.grpButons.Size = new System.Drawing.Size(921, 75);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.MainMap, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.grdItem, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(1, 47);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(919, 400);
            this.tableLayoutPanel.TabIndex = 4;
            // 
            // MainMap
            // 
            this.MainMap.Bearing = 0F;
            this.MainMap.CanDragMap = true;
            this.MainMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.MainMap.GrayScaleMode = false;
            this.MainMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.MainMap.LevelsKeepInMemmory = 5;
            this.MainMap.Location = new System.Drawing.Point(3, 3);
            this.MainMap.MarkersEnabled = true;
            this.MainMap.MaxZoom = 20;
            this.MainMap.MinZoom = 1;
            this.MainMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.MainMap.Name = "MainMap";
            this.MainMap.NegativeMode = false;
            this.MainMap.PolygonsEnabled = true;
            this.MainMap.RetryLoadTile = 0;
            this.MainMap.RoutesEnabled = true;
            this.MainMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.MainMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.MainMap.ShowTileGridLines = false;
            this.MainMap.Size = new System.Drawing.Size(454, 394);
            this.MainMap.TabIndex = 2;
            this.MainMap.Zoom = 5D;
            this.MainMap.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.MainMap_OnMarkerClick);
            // 
            // grdItem
            // 
            this.grdItem.BaseUltraGrid = this.grdItem;
            this.grdItem.DataMember = "spr_dsb_FieldTaskList_rpt_Select";
            this.grdItem.DataSource = this.dstDashboard1;
            appearance11.BackColor = System.Drawing.Color.Transparent;
            appearance11.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            appearance11.ForeColor = System.Drawing.Color.White;
            appearance11.TextHAlignAsString = "Right";
            appearance11.TextVAlignAsString = "Middle";
            this.grdItem.DisplayLayout.Appearance = appearance11;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.VisiblePosition = 1;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn1.Width = 27;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.Header.Caption = "مساحت-هکتار";
            ultraGridColumn2.Header.VisiblePosition = 9;
            ultraGridColumn2.Width = 80;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.Header.Caption = "نام فرآیند تولید";
            ultraGridColumn3.Header.VisiblePosition = 10;
            ultraGridColumn3.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            ultraGridColumn3.Width = 83;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.Header.Caption = "محصول";
            ultraGridColumn4.Header.VisiblePosition = 8;
            ultraGridColumn4.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            ultraGridColumn4.Width = 45;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.Header.Caption = "رقم";
            ultraGridColumn5.Header.VisiblePosition = 7;
            ultraGridColumn5.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            ultraGridColumn5.Width = 36;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.Header.Caption = "فعالیت";
            ultraGridColumn6.Header.VisiblePosition = 6;
            ultraGridColumn6.Width = 41;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.Header.Caption = "وضعیت";
            ultraGridColumn7.Header.VisiblePosition = 2;
            ultraGridColumn7.Width = 44;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn8.Header.VisiblePosition = 3;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn8.Width = 27;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn9.Header.Caption = "شروع فعالیت";
            ultraGridColumn9.Header.VisiblePosition = 5;
            ultraGridColumn9.Width = 71;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn10.Header.Caption = "پایان فعالیت";
            ultraGridColumn10.Header.VisiblePosition = 4;
            ultraGridColumn10.Width = 67;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn11.Header.Caption = "";
            ultraGridColumn11.Header.VisiblePosition = 0;
            ultraGridColumn11.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            ultraGridColumn11.Width = 36;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn12.Header.Caption = "#";
            ultraGridColumn12.Header.VisiblePosition = 15;
            ultraGridColumn12.TabStop = false;
            ultraGridColumn12.Width = 36;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn13.Header.Caption = "...";
            ultraGridColumn13.Header.VisiblePosition = 11;
            ultraGridColumn13.Hidden = true;
            ultraGridColumn13.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            ultraGridColumn13.Width = 36;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn14.Header.Caption = "...";
            ultraGridColumn14.Header.VisiblePosition = 12;
            ultraGridColumn14.Hidden = true;
            ultraGridColumn14.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            ultraGridColumn14.Width = 36;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn15.Header.Caption = "...";
            ultraGridColumn15.Header.VisiblePosition = 13;
            ultraGridColumn15.Hidden = true;
            ultraGridColumn15.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            ultraGridColumn15.Width = 36;
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn16.Header.Caption = "...";
            ultraGridColumn16.Header.VisiblePosition = 14;
            ultraGridColumn16.Hidden = true;
            ultraGridColumn16.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            ultraGridColumn16.Width = 36;
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
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16});
            ultraGridBand1.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            appearance1.ForeColor = System.Drawing.Color.DarkBlue;
            ultraGridBand1.Override.SummaryValueAppearance = appearance1;
            this.grdItem.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grdItem.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            appearance14.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance14.ForeColor = System.Drawing.Color.Black;
            this.grdItem.DisplayLayout.CaptionAppearance = appearance14;
            this.grdItem.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.True;
            appearance15.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance15.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance15.BorderColor = System.Drawing.SystemColors.Window;
            this.grdItem.DisplayLayout.GroupByBox.Appearance = appearance15;
            appearance16.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdItem.DisplayLayout.GroupByBox.BandLabelAppearance = appearance16;
            this.grdItem.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance17.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance17.BackColor2 = System.Drawing.SystemColors.Control;
            appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance17.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdItem.DisplayLayout.GroupByBox.PromptAppearance = appearance17;
            this.grdItem.DisplayLayout.MaxColScrollRegions = 1;
            this.grdItem.DisplayLayout.MaxRowScrollRegions = 1;
            appearance18.BackColor = System.Drawing.SystemColors.Window;
            appearance18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdItem.DisplayLayout.Override.ActiveCellAppearance = appearance18;
            appearance19.BackColor = System.Drawing.Color.Gray;
            appearance19.BackColor2 = System.Drawing.Color.Gray;
            appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance19.ForeColor = System.Drawing.Color.White;
            this.grdItem.DisplayLayout.Override.ActiveRowAppearance = appearance19;
            this.grdItem.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Rounded1;
            this.grdItem.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.None;
            this.grdItem.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            this.grdItem.DisplayLayout.Override.BorderStyleRowSelector = Infragistics.Win.UIElementBorderStyle.None;
            appearance20.BackColor = System.Drawing.SystemColors.Window;
            this.grdItem.DisplayLayout.Override.CardAreaAppearance = appearance20;
            appearance21.BorderColor = System.Drawing.Color.Gray;
            appearance21.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grdItem.DisplayLayout.Override.CellAppearance = appearance21;
            this.grdItem.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.grdItem.DisplayLayout.Override.CellPadding = 0;
            this.grdItem.DisplayLayout.Override.CellSpacing = 2;
            this.grdItem.DisplayLayout.Override.DefaultRowHeight = 20;
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
            appearance22.BackColor = System.Drawing.SystemColors.Control;
            appearance22.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance22.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance22.BorderColor = System.Drawing.SystemColors.Window;
            this.grdItem.DisplayLayout.Override.GroupByRowAppearance = appearance22;
            appearance35.BackColor = System.Drawing.Color.Transparent;
            appearance35.BackColor2 = System.Drawing.Color.Transparent;
            appearance35.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance35.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            appearance35.BorderColor = System.Drawing.Color.Transparent;
            appearance35.FontData.BoldAsString = "True";
            appearance35.FontData.Name = "B Nazanin";
            appearance35.FontData.SizeInPoints = 10F;
            appearance35.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(179)))), ((int)(((byte)(4)))));
            appearance35.TextHAlignAsString = "Center";
            appearance35.TextVAlignAsString = "Middle";
            this.grdItem.DisplayLayout.Override.HeaderAppearance = appearance35;
            this.grdItem.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdItem.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsVista;
            appearance36.ForeColor = System.Drawing.Color.Yellow;
            this.grdItem.DisplayLayout.Override.HotTrackRowAppearance = appearance36;
            this.grdItem.DisplayLayout.Override.MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
            appearance37.BackColor = System.Drawing.Color.Transparent;
            appearance37.BorderColor = System.Drawing.Color.Silver;
            this.grdItem.DisplayLayout.Override.RowAppearance = appearance37;
            this.grdItem.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance38.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdItem.DisplayLayout.Override.TemplateAddRowAppearance = appearance38;
            appearance39.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            scrollBarLook1.Appearance = appearance39;
            appearance40.BackColor = System.Drawing.Color.DarkGray;
            appearance40.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            scrollBarLook1.ButtonAppearance = appearance40;
            appearance41.BackColor = System.Drawing.Color.Gray;
            appearance41.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            scrollBarLook1.ThumbAppearance = appearance41;
            appearance42.BackColor = System.Drawing.Color.DarkGray;
            appearance42.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            scrollBarLook1.TrackAppearance = appearance42;
            scrollBarLook1.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2007;
            this.grdItem.DisplayLayout.ScrollBarLook = scrollBarLook1;
            this.grdItem.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdItem.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.grdItem.InputLanguage = Baran.Windows.Forms.InputLanguage.Farsi;
            this.grdItem.Location = new System.Drawing.Point(463, 3);
            this.grdItem.Name = "grdItem";
            this.grdItem.Size = new System.Drawing.Size(453, 394);
            this.grdItem.SumColumnsWidth = 539;
            this.grdItem.TabIndex = 1;
            // 
            // dstDashboard1
            // 
            this.dstDashboard1.DataSetName = "dstDashboard";
            this.dstDashboard1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // grpControls
            // 
            this.grpControls.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
            this.grpControls.Controls.Add(this.cmbField);
            this.grpControls.Controls.Add(this.label1);
            this.grpControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpControls.Location = new System.Drawing.Point(1, 0);
            this.grpControls.Name = "grpControls";
            this.grpControls.Size = new System.Drawing.Size(919, 47);
            this.grpControls.TabIndex = 3;
            // 
            // cmbField
            // 
            this.cmbField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.BorderColor = System.Drawing.Color.LightGray;
            appearance3.ForeColor = System.Drawing.Color.White;
            appearance3.TextHAlignAsString = "Right";
            appearance3.TextVAlignAsString = "Middle";
            this.cmbField.Appearance = appearance3;
            this.cmbField.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.cmbField.BackColor = System.Drawing.Color.Transparent;
            this.cmbField.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbField.Editable = Baran.Windows.Forms.Editable.Editable;
            this.cmbField.InputLanguage = Baran.Windows.Forms.InputLanguage.Farsi;
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.TextHAlignAsString = "Right";
            appearance4.TextVAlignAsString = "Middle";
            this.cmbField.ItemAppearance = appearance4;
            this.cmbField.Location = new System.Drawing.Point(535, 12);
            this.cmbField.Name = "cmbField";
            this.cmbField.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbField.Size = new System.Drawing.Size(300, 22);
            this.cmbField.TabIndex = 1;
            this.cmbField.ValueChanged += new System.EventHandler(this.cmbField_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.ForeColor = System.Drawing.Color.White;
            appearance2.TextHAlignAsString = "Right";
            appearance2.TextVAlignAsString = "Middle";
            this.label1.Appearance = appearance2;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(841, 16);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = ": قطعه زمین";
            // 
            // frmFieldTaskListRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(921, 631);
            this.FormMessage = "";
            this.Name = "frmFieldTaskListRpt";
            ((System.ComponentModel.ISupportInitialize)(this.grpHeader)).EndInit();
            this.grpHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMessage)).EndInit();
            this.grpMessage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).EndInit();
            this.grpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpButons)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstDashboard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpControls)).EndInit();
            this.grpControls.ResumeLayout(false);
            this.grpControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbField)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private Windows.Forms.GroupBox grpControls;
        private Windows.Forms.UltraComboEditor cmbField;
        private Windows.Forms.Label label1;
        private BaranDataAccess.Dashboard.dstDashboard dstDashboard1;
        private Windows.Forms.UltraGrid grdItem;
        private Demo.WindowsForms.Map MainMap;
    }
}
