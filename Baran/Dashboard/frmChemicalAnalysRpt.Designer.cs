namespace Baran.Dashboard
{
    partial class frmChemicalAnalysRpt
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
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("spr_dsb_ChemicalAnalys_rpt", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ChemicalAnallysName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Date");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AnalysNumber");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Percentage");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ElementEnFaName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ElementID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TaskName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FieldName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PartName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SubCollectionName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CollectionName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LinkedArea");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ElementName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FreeSpace", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RowID", 1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("New", 2);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Detail", 3);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Delete", 4);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Update", 5);
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.UltraChart.Resources.Appearance.PaintElement paintElement1 = new Infragistics.UltraChart.Resources.Appearance.PaintElement();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            this.dstDashboard1 = new BaranDataAccess.Dashboard.dstDashboard();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.grdItem = new Baran.Windows.Forms.UltraGrid();
            this.chtMain = new Baran.Windows.Forms.UltraChartMain();
            this.grpControls = new Baran.Windows.Forms.GroupBox();
            this.mskToDate = new Baran.Windows.Forms.UltraMaskedDate();
            this.mskFromDate = new Baran.Windows.Forms.UltraMaskedDate();
            this.label1 = new Baran.Windows.Forms.Label();
            this.label2 = new Baran.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grpPrint)).BeginInit();
            this.grpPrint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpCancel)).BeginInit();
            this.grpCancel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpSave)).BeginInit();
            this.grpSave.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpChange)).BeginInit();
            this.grpChange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpClear)).BeginInit();
            this.grpClear.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpDelete)).BeginInit();
            this.grpDelete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpDoc)).BeginInit();
            this.grpDoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpRefresh)).BeginInit();
            this.grpRefresh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpNew)).BeginInit();
            this.grpNew.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpHeader)).BeginInit();
            this.grpHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMessage)).BeginInit();
            this.grpMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).BeginInit();
            this.grpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpButons)).BeginInit();
            this.grpButons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dstDashboard1)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpControls)).BeginInit();
            this.grpControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            // 
            // btnPrint
            // 
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            // 
            // btnDoc
            // 
            this.btnDoc.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            // 
            // btnClear
            // 
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            // 
            // btnChange
            // 
            this.btnChange.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            // 
            // btnCancle
            // 
            this.btnCancle.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            // 
            // grpPrint
            // 
            this.grpPrint.Location = new System.Drawing.Point(113, 0);
            this.grpPrint.Size = new System.Drawing.Size(95, 74);
            // 
            // grpCancel
            // 
            this.grpCancel.Location = new System.Drawing.Point(856, 0);
            this.grpCancel.Size = new System.Drawing.Size(127, 74);
            // 
            // grpSave
            // 
            this.grpSave.Location = new System.Drawing.Point(729, 0);
            this.grpSave.Size = new System.Drawing.Size(127, 74);
            this.grpSave.Visible = false;
            // 
            // grpChange
            // 
            this.grpChange.Location = new System.Drawing.Point(602, 0);
            this.grpChange.Size = new System.Drawing.Size(127, 74);
            this.grpChange.Visible = false;
            // 
            // grpClear
            // 
            this.grpClear.Location = new System.Drawing.Point(475, 0);
            this.grpClear.Size = new System.Drawing.Size(127, 74);
            // 
            // grpDelete
            // 
            this.grpDelete.Location = new System.Drawing.Point(348, 0);
            this.grpDelete.Size = new System.Drawing.Size(127, 74);
            this.grpDelete.Visible = false;
            // 
            // grpDoc
            // 
            this.grpDoc.Location = new System.Drawing.Point(208, 0);
            this.grpDoc.Size = new System.Drawing.Size(140, 74);
            this.grpDoc.Visible = false;
            // 
            // grpRefresh
            // 
            this.grpRefresh.Location = new System.Drawing.Point(18, 0);
            this.grpRefresh.Size = new System.Drawing.Size(95, 74);
            // 
            // grpNew
            // 
            this.grpNew.Location = new System.Drawing.Point(-109, 0);
            this.grpNew.Size = new System.Drawing.Size(127, 74);
            // 
            // btnNew
            // 
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            // 
            // btnMaxMin
            // 
            this.btnMaxMin.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            // 
            // lblLine2
            // 
            this.lblLine2.Location = new System.Drawing.Point(1, 71);
            this.lblLine2.Size = new System.Drawing.Size(982, 3);
            // 
            // grpHeader
            // 
            this.grpHeader.Size = new System.Drawing.Size(984, 75);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(919, 9);
            // 
            // lblCaption
            // 
            this.lblCaption.Location = new System.Drawing.Point(613, 22);
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(1, 0);
            this.lblMessage.Size = new System.Drawing.Size(834, 29);
            // 
            // lblLine1
            // 
            this.lblLine1.Size = new System.Drawing.Size(982, 3);
            // 
            // grpMessage
            // 
            this.grpMessage.Location = new System.Drawing.Point(0, 75);
            this.grpMessage.Size = new System.Drawing.Size(984, 30);
            // 
            // lblLine3
            // 
            this.lblLine3.Location = new System.Drawing.Point(1, 577);
            this.lblLine3.Size = new System.Drawing.Size(982, 3);
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.tableLayoutPanel);
            this.grpMain.Controls.Add(this.grpControls);
            this.grpMain.Location = new System.Drawing.Point(0, 105);
            this.grpMain.Size = new System.Drawing.Size(984, 581);
            this.grpMain.Controls.SetChildIndex(this.lblLine3, 0);
            this.grpMain.Controls.SetChildIndex(this.grpControls, 0);
            this.grpMain.Controls.SetChildIndex(this.tableLayoutPanel, 0);
            // 
            // grpButons
            // 
            this.grpButons.Location = new System.Drawing.Point(0, 686);
            this.grpButons.Size = new System.Drawing.Size(984, 75);
            this.grpButons.Visible = false;
            // 
            // dstDashboard1
            // 
            this.dstDashboard1.DataSetName = "dstDashboard";
            this.dstDashboard1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.grdItem, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.chtMain, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(1, 42);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(982, 535);
            this.tableLayoutPanel.TabIndex = 13;
            // 
            // grdItem
            // 
            this.grdItem.BaseUltraGrid = this.grdItem;
            this.grdItem.DataMember = "spr_dsb_ChemicalAnalys_rpt";
            this.grdItem.DataSource = this.dstDashboard1;
            appearance10.BackColor = System.Drawing.Color.Transparent;
            appearance10.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            appearance10.ForeColor = System.Drawing.Color.White;
            appearance10.TextHAlignAsString = "Right";
            appearance10.TextVAlignAsString = "Middle";
            this.grdItem.DisplayLayout.Appearance = appearance10;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.Caption = "نام";
            ultraGridColumn1.Header.VisiblePosition = 13;
            ultraGridColumn1.Width = 36;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.Header.Caption = "تاریخ";
            ultraGridColumn2.Header.VisiblePosition = 11;
            ultraGridColumn2.Width = 36;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.Header.Caption = "شماره آزمایش";
            ultraGridColumn3.Header.VisiblePosition = 12;
            ultraGridColumn3.Width = 76;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.Header.Caption = "درصد";
            ultraGridColumn4.Header.VisiblePosition = 9;
            ultraGridColumn4.Width = 36;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.Header.VisiblePosition = 1;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn5.Width = 36;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.Header.VisiblePosition = 2;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn6.Width = 27;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.Header.Caption = "فعالیت";
            ultraGridColumn7.Header.VisiblePosition = 8;
            ultraGridColumn7.Width = 41;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn8.Header.Caption = "قطعه زمین";
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn8.Width = 59;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn9.Header.Caption = "واحد فرعی";
            ultraGridColumn9.Header.VisiblePosition = 5;
            ultraGridColumn9.Width = 61;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn10.Header.Caption = "واحد";
            ultraGridColumn10.Header.VisiblePosition = 4;
            ultraGridColumn10.Width = 36;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn11.Header.Caption = "کشت و صنعت";
            ultraGridColumn11.Header.VisiblePosition = 3;
            ultraGridColumn11.Width = 76;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn12.Header.Caption = "مساحت-هکتار";
            ultraGridColumn12.Header.VisiblePosition = 6;
            ultraGridColumn12.Width = 80;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn13.Header.Caption = "عنصر";
            ultraGridColumn13.Header.VisiblePosition = 10;
            ultraGridColumn13.Width = 36;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn14.Header.Caption = "";
            ultraGridColumn14.Header.VisiblePosition = 0;
            ultraGridColumn14.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            ultraGridColumn14.Width = 331;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn15.Header.Caption = "#";
            ultraGridColumn15.Header.VisiblePosition = 18;
            ultraGridColumn15.TabStop = false;
            ultraGridColumn15.Width = 36;
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn16.Header.Caption = "...";
            ultraGridColumn16.Header.VisiblePosition = 14;
            ultraGridColumn16.Hidden = true;
            ultraGridColumn16.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            ultraGridColumn16.Width = 36;
            ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn17.Header.Caption = "...";
            ultraGridColumn17.Header.VisiblePosition = 15;
            ultraGridColumn17.Hidden = true;
            ultraGridColumn17.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            ultraGridColumn17.Width = 36;
            ultraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn18.Header.Caption = "...";
            ultraGridColumn18.Header.VisiblePosition = 16;
            ultraGridColumn18.Hidden = true;
            ultraGridColumn18.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            ultraGridColumn18.Width = 36;
            ultraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn19.Header.Caption = "...";
            ultraGridColumn19.Header.VisiblePosition = 17;
            ultraGridColumn19.Hidden = true;
            ultraGridColumn19.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            ultraGridColumn19.Width = 36;
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
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19});
            ultraGridBand1.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            appearance1.ForeColor = System.Drawing.Color.DarkBlue;
            ultraGridBand1.Override.SummaryValueAppearance = appearance1;
            this.grdItem.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grdItem.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            appearance12.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance12.ForeColor = System.Drawing.Color.Black;
            this.grdItem.DisplayLayout.CaptionAppearance = appearance12;
            this.grdItem.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.True;
            appearance13.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance13.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance13.BorderColor = System.Drawing.SystemColors.Window;
            this.grdItem.DisplayLayout.GroupByBox.Appearance = appearance13;
            appearance14.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdItem.DisplayLayout.GroupByBox.BandLabelAppearance = appearance14;
            this.grdItem.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance15.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance15.BackColor2 = System.Drawing.SystemColors.Control;
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance15.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdItem.DisplayLayout.GroupByBox.PromptAppearance = appearance15;
            this.grdItem.DisplayLayout.MaxColScrollRegions = 1;
            this.grdItem.DisplayLayout.MaxRowScrollRegions = 1;
            appearance16.BackColor = System.Drawing.SystemColors.Window;
            appearance16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdItem.DisplayLayout.Override.ActiveCellAppearance = appearance16;
            appearance17.BackColor = System.Drawing.Color.Gray;
            appearance17.BackColor2 = System.Drawing.Color.Gray;
            appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance17.ForeColor = System.Drawing.Color.White;
            this.grdItem.DisplayLayout.Override.ActiveRowAppearance = appearance17;
            this.grdItem.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Rounded1;
            this.grdItem.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.None;
            this.grdItem.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            this.grdItem.DisplayLayout.Override.BorderStyleRowSelector = Infragistics.Win.UIElementBorderStyle.None;
            appearance19.BackColor = System.Drawing.SystemColors.Window;
            this.grdItem.DisplayLayout.Override.CardAreaAppearance = appearance19;
            appearance20.BorderColor = System.Drawing.Color.Gray;
            appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grdItem.DisplayLayout.Override.CellAppearance = appearance20;
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
            appearance21.BackColor = System.Drawing.SystemColors.Control;
            appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance21.BorderColor = System.Drawing.SystemColors.Window;
            this.grdItem.DisplayLayout.Override.GroupByRowAppearance = appearance21;
            appearance22.BackColor = System.Drawing.Color.Transparent;
            appearance22.BackColor2 = System.Drawing.Color.Transparent;
            appearance22.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            appearance22.BorderColor = System.Drawing.Color.Transparent;
            appearance22.FontData.BoldAsString = "True";
            appearance22.FontData.Name = "B Nazanin";
            appearance22.FontData.SizeInPoints = 10F;
            appearance22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(179)))), ((int)(((byte)(4)))));
            appearance22.TextHAlignAsString = "Center";
            appearance22.TextVAlignAsString = "Middle";
            this.grdItem.DisplayLayout.Override.HeaderAppearance = appearance22;
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
            this.grdItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.grdItem.InputLanguage = Baran.Windows.Forms.InputLanguage.Farsi;
            this.grdItem.Location = new System.Drawing.Point(3, 217);
            this.grdItem.Name = "grdItem";
            this.grdItem.Size = new System.Drawing.Size(976, 315);
            this.grdItem.SumColumnsWidth = 645;
            this.grdItem.TabIndex = 8;
            this.grdItem.AfterRowFilterChanged += new Infragistics.Win.UltraWinGrid.AfterRowFilterChangedEventHandler(this.grdItem_AfterRowFilterChanged);
            // 
//			'UltraChartMain' properties's serialization: Since 'ChartType' changes the way axes look,
//			'ChartType' must be persisted ahead of any Axes change made in design time.
//		
            this.chtMain.ChartType = Infragistics.UltraChart.Shared.Styles.ChartType.LineChart;
            // 
            // chtMain
            // 
            this.chtMain.Axis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(220)))));
            paintElement1.ElementType = Infragistics.UltraChart.Shared.Styles.PaintElementType.None;
            paintElement1.Fill = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(220)))));
            this.chtMain.Axis.PE = paintElement1;
            this.chtMain.Axis.X.Labels.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.chtMain.Axis.X.Labels.FontColor = System.Drawing.Color.White;
            this.chtMain.Axis.X.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.chtMain.Axis.X.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.chtMain.Axis.X.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.chtMain.Axis.X.Labels.SeriesLabels.FormatString = "";
            this.chtMain.Axis.X.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.chtMain.Axis.X.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.chtMain.Axis.X.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chtMain.Axis.X.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chtMain.Axis.X.LineColor = System.Drawing.Color.White;
            this.chtMain.Axis.X.MajorGridLines.AlphaLevel = ((byte)(255));
            this.chtMain.Axis.X.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.chtMain.Axis.X.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chtMain.Axis.X.MajorGridLines.Visible = true;
            this.chtMain.Axis.X.MinorGridLines.AlphaLevel = ((byte)(255));
            this.chtMain.Axis.X.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.chtMain.Axis.X.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chtMain.Axis.X.MinorGridLines.Visible = false;
            this.chtMain.Axis.X.Visible = true;
            this.chtMain.Axis.X2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.chtMain.Axis.X2.Labels.ItemFormatString = "<ITEM_LABEL>";
            this.chtMain.Axis.X2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.chtMain.Axis.X2.Labels.SeriesLabels.FormatString = "";
            this.chtMain.Axis.X2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.chtMain.Axis.X2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.VerticalLeftFacing;
            this.chtMain.Axis.X2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chtMain.Axis.X2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chtMain.Axis.X2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.chtMain.Axis.X2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.chtMain.Axis.X2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chtMain.Axis.X2.MajorGridLines.Visible = true;
            this.chtMain.Axis.X2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.chtMain.Axis.X2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.chtMain.Axis.X2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chtMain.Axis.X2.MinorGridLines.Visible = false;
            this.chtMain.Axis.X2.Visible = false;
            this.chtMain.Axis.Y.Labels.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.chtMain.Axis.Y.Labels.FontColor = System.Drawing.Color.White;
            this.chtMain.Axis.Y.Labels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.chtMain.Axis.Y.Labels.ItemFormatString = "<DATA_VALUE:00.##>";
            this.chtMain.Axis.Y.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.chtMain.Axis.Y.Labels.SeriesLabels.FormatString = "";
            this.chtMain.Axis.Y.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Far;
            this.chtMain.Axis.Y.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.chtMain.Axis.Y.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chtMain.Axis.Y.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chtMain.Axis.Y.LineColor = System.Drawing.Color.White;
            this.chtMain.Axis.Y.MajorGridLines.AlphaLevel = ((byte)(255));
            this.chtMain.Axis.Y.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.chtMain.Axis.Y.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chtMain.Axis.Y.MajorGridLines.Visible = true;
            this.chtMain.Axis.Y.MinorGridLines.AlphaLevel = ((byte)(255));
            this.chtMain.Axis.Y.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.chtMain.Axis.Y.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chtMain.Axis.Y.MinorGridLines.Visible = false;
            this.chtMain.Axis.Y.Visible = true;
            this.chtMain.Axis.Y2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.chtMain.Axis.Y2.Labels.ItemFormatString = "<DATA_VALUE:00.##>";
            this.chtMain.Axis.Y2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.chtMain.Axis.Y2.Labels.SeriesLabels.FormatString = "";
            this.chtMain.Axis.Y2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.chtMain.Axis.Y2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.chtMain.Axis.Y2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chtMain.Axis.Y2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chtMain.Axis.Y2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.chtMain.Axis.Y2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.chtMain.Axis.Y2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chtMain.Axis.Y2.MajorGridLines.Visible = true;
            this.chtMain.Axis.Y2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.chtMain.Axis.Y2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.chtMain.Axis.Y2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chtMain.Axis.Y2.MinorGridLines.Visible = false;
            this.chtMain.Axis.Y2.Visible = false;
            this.chtMain.Axis.Z.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.chtMain.Axis.Z.Labels.ItemFormatString = "";
            this.chtMain.Axis.Z.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.chtMain.Axis.Z.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.chtMain.Axis.Z.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.chtMain.Axis.Z.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chtMain.Axis.Z.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chtMain.Axis.Z.MajorGridLines.AlphaLevel = ((byte)(255));
            this.chtMain.Axis.Z.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.chtMain.Axis.Z.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chtMain.Axis.Z.MajorGridLines.Visible = true;
            this.chtMain.Axis.Z.MinorGridLines.AlphaLevel = ((byte)(255));
            this.chtMain.Axis.Z.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.chtMain.Axis.Z.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chtMain.Axis.Z.MinorGridLines.Visible = false;
            this.chtMain.Axis.Z.Visible = false;
            this.chtMain.Axis.Z2.Labels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.chtMain.Axis.Z2.Labels.ItemFormatString = "";
            this.chtMain.Axis.Z2.Labels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.chtMain.Axis.Z2.Labels.SeriesLabels.HorizontalAlign = System.Drawing.StringAlignment.Near;
            this.chtMain.Axis.Z2.Labels.SeriesLabels.Orientation = Infragistics.UltraChart.Shared.Styles.TextOrientation.Horizontal;
            this.chtMain.Axis.Z2.Labels.SeriesLabels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chtMain.Axis.Z2.Labels.VerticalAlign = System.Drawing.StringAlignment.Center;
            this.chtMain.Axis.Z2.MajorGridLines.AlphaLevel = ((byte)(255));
            this.chtMain.Axis.Z2.MajorGridLines.Color = System.Drawing.Color.Gainsboro;
            this.chtMain.Axis.Z2.MajorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chtMain.Axis.Z2.MajorGridLines.Visible = true;
            this.chtMain.Axis.Z2.MinorGridLines.AlphaLevel = ((byte)(255));
            this.chtMain.Axis.Z2.MinorGridLines.Color = System.Drawing.Color.LightGray;
            this.chtMain.Axis.Z2.MinorGridLines.DrawStyle = Infragistics.UltraChart.Shared.Styles.LineDrawStyle.Dot;
            this.chtMain.Axis.Z2.MinorGridLines.Visible = false;
            this.chtMain.Axis.Z2.Visible = false;
            this.chtMain.BackColor = System.Drawing.Color.Transparent;
            this.chtMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.chtMain.ColorModel.AlphaLevel = ((byte)(150));
            this.chtMain.ColorModel.ModelStyle = Infragistics.UltraChart.Shared.Styles.ColorModels.CustomLinear;
            this.chtMain.Data.SwapRowsAndColumns = true;
            this.chtMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chtMain.EmptyChartText = "";
            this.chtMain.Legend.BackgroundColor = System.Drawing.Color.Transparent;
            this.chtMain.Legend.BorderColor = System.Drawing.Color.White;
            this.chtMain.Legend.FontColor = System.Drawing.Color.White;
            this.chtMain.Legend.SpanPercentage = 10;
            this.chtMain.Legend.Visible = true;
            this.chtMain.Location = new System.Drawing.Point(0, 0);
            this.chtMain.Margin = new System.Windows.Forms.Padding(0);
            this.chtMain.Name = "chtMain";
            this.chtMain.Size = new System.Drawing.Size(982, 214);
            this.chtMain.TabIndex = 9;
            // 
            // grpControls
            // 
            this.grpControls.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
            this.grpControls.Controls.Add(this.mskToDate);
            this.grpControls.Controls.Add(this.mskFromDate);
            this.grpControls.Controls.Add(this.label1);
            this.grpControls.Controls.Add(this.label2);
            this.grpControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpControls.Location = new System.Drawing.Point(1, 0);
            this.grpControls.Name = "grpControls";
            this.grpControls.Size = new System.Drawing.Size(982, 42);
            this.grpControls.TabIndex = 12;
            // 
            // mskToDate
            // 
            this.mskToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance26.BackColor = System.Drawing.Color.Transparent;
            appearance26.ForeColor = System.Drawing.Color.White;
            appearance26.TextHAlignAsString = "Center";
            this.mskToDate.Appearance = appearance26;
            this.mskToDate.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
            this.mskToDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.mskToDate.Editable = Baran.Windows.Forms.Editable.Editable;
            this.mskToDate.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.mskToDate.InputMask = "yyyy/mm/dd";
            this.mskToDate.Location = new System.Drawing.Point(650, 9);
            this.mskToDate.Name = "mskToDate";
            this.mskToDate.Size = new System.Drawing.Size(90, 21);
            this.mskToDate.TabIndex = 126;
            this.mskToDate.Text = "____/__/__";
            // 
            // mskFromDate
            // 
            this.mskFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance18.BackColor = System.Drawing.Color.Transparent;
            appearance18.ForeColor = System.Drawing.Color.White;
            appearance18.TextHAlignAsString = "Center";
            this.mskFromDate.Appearance = appearance18;
            this.mskFromDate.DataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
            this.mskFromDate.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.mskFromDate.Editable = Baran.Windows.Forms.Editable.Editable;
            this.mskFromDate.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask;
            this.mskFromDate.InputMask = "yyyy/mm/dd";
            this.mskFromDate.Location = new System.Drawing.Point(822, 10);
            this.mskFromDate.Name = "mskFromDate";
            this.mskFromDate.Size = new System.Drawing.Size(90, 21);
            this.mskFromDate.TabIndex = 125;
            this.mskFromDate.Text = "____/__/__";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.ForeColor = System.Drawing.Color.LightGray;
            appearance2.TextHAlignAsString = "Right";
            appearance2.TextVAlignAsString = "Middle";
            this.label1.Appearance = appearance2;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(917, 12);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 124;
            this.label1.Text = ": از تاریخ";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance8.ForeColor = System.Drawing.Color.LightGray;
            appearance8.TextHAlignAsString = "Right";
            appearance8.TextVAlignAsString = "Middle";
            this.label2.Appearance = appearance8;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(746, 11);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 123;
            this.label2.Text = ": تا تاریخ";
            // 
            // frmChemicalAnalysRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(984, 761);
            this.Name = "frmChemicalAnalysRpt";
            this.ShowIcon = false;
            this.ShowInTaskbar = true;
            this.Text = "آنالیز شیمیایی";
            ((System.ComponentModel.ISupportInitialize)(this.grpPrint)).EndInit();
            this.grpPrint.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpCancel)).EndInit();
            this.grpCancel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpSave)).EndInit();
            this.grpSave.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpChange)).EndInit();
            this.grpChange.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpClear)).EndInit();
            this.grpClear.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpDelete)).EndInit();
            this.grpDelete.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpDoc)).EndInit();
            this.grpDoc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpRefresh)).EndInit();
            this.grpRefresh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpNew)).EndInit();
            this.grpNew.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpHeader)).EndInit();
            this.grpHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMessage)).EndInit();
            this.grpMessage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).EndInit();
            this.grpMain.ResumeLayout(false);
            this.grpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpButons)).EndInit();
            this.grpButons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dstDashboard1)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpControls)).EndInit();
            this.grpControls.ResumeLayout(false);
            this.grpControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private BaranDataAccess.Dashboard.dstDashboard dstDashboard1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private Windows.Forms.GroupBox grpControls;
        private Windows.Forms.UltraMaskedDate mskToDate;
        private Windows.Forms.UltraMaskedDate mskFromDate;
        private Windows.Forms.Label label1;
        private Windows.Forms.Label label2;
        private Windows.Forms.UltraGrid grdItem;
        private Windows.Forms.UltraChartMain chtMain;
    }
}
