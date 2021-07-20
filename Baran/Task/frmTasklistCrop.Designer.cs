namespace Baran.Task
{
    partial class frmTasklistCrop
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("spr_tsk_Tasklist_Crop_Link_Select", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TasklistCropID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Fk_TasklistID", -1, "drpTasklist");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Fk_CropID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IsActive");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RowID", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FreeSpace", 1);
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("spr_tsk_Tasklist_cmb_Select", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TasklistID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TasklistName");
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            this.grpControls = new Baran.Windows.Forms.GroupBox();
            this.label1 = new Baran.Windows.Forms.Label();
            this.cmbCrop = new Baran.Windows.Forms.UltraComboEditor();
            this.dstTask1 = new BaranDataAccess.Task.dstTask();
            this.grdItem = new Baran.Windows.Forms.UltraGrid();
            this.drpTasklist = new Baran.Windows.Forms.UltraDropDown();
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
            ((System.ComponentModel.ISupportInitialize)(this.grpButons)).BeginInit();
            this.grpButons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpHeader)).BeginInit();
            this.grpHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMessage)).BeginInit();
            this.grpMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).BeginInit();
            this.grpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpControls)).BeginInit();
            this.grpControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCrop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstTask1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpTasklist)).BeginInit();
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
            this.grpPrint.Location = new System.Drawing.Point(-59, 0);
            this.grpPrint.Size = new System.Drawing.Size(95, 74);
            // 
            // grpCancel
            // 
            this.grpCancel.Location = new System.Drawing.Point(684, 0);
            this.grpCancel.Size = new System.Drawing.Size(127, 74);
            // 
            // grpSave
            // 
            this.grpSave.Location = new System.Drawing.Point(557, 0);
            this.grpSave.Size = new System.Drawing.Size(127, 74);
            // 
            // grpChange
            // 
            this.grpChange.Location = new System.Drawing.Point(430, 0);
            this.grpChange.Size = new System.Drawing.Size(127, 74);
            // 
            // grpClear
            // 
            this.grpClear.Location = new System.Drawing.Point(303, 0);
            this.grpClear.Size = new System.Drawing.Size(127, 74);
            // 
            // grpDelete
            // 
            this.grpDelete.Location = new System.Drawing.Point(176, 0);
            this.grpDelete.Size = new System.Drawing.Size(127, 74);
            // 
            // grpDoc
            // 
            this.grpDoc.Location = new System.Drawing.Point(36, 0);
            this.grpDoc.Size = new System.Drawing.Size(140, 74);
            this.grpDoc.Visible = false;
            // 
            // grpRefresh
            // 
            this.grpRefresh.Location = new System.Drawing.Point(-154, 0);
            this.grpRefresh.Size = new System.Drawing.Size(95, 74);
            // 
            // grpNew
            // 
            this.grpNew.Location = new System.Drawing.Point(-281, 0);
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
            // grpButons
            // 
            this.grpButons.Location = new System.Drawing.Point(0, 408);
            this.grpButons.Size = new System.Drawing.Size(812, 75);
            // 
            // lblLine2
            // 
            this.lblLine2.Location = new System.Drawing.Point(1, 72);
            this.lblLine2.Size = new System.Drawing.Size(810, 2);
            this.lblLine2.Visible = false;
            // 
            // grpHeader
            // 
            this.grpHeader.Size = new System.Drawing.Size(812, 75);
            this.grpHeader.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(546, 7);
            // 
            // lblCaption
            // 
            this.lblCaption.Location = new System.Drawing.Point(238, 12);
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(1, 0);
            this.lblMessage.Size = new System.Drawing.Size(730, 22);
            // 
            // lblLine1
            // 
            this.lblLine1.Size = new System.Drawing.Size(810, 2);
            // 
            // grpMessage
            // 
            this.grpMessage.Size = new System.Drawing.Size(812, 23);
            // 
            // lblLine3
            // 
            this.lblLine3.Location = new System.Drawing.Point(1, 307);
            this.lblLine3.Size = new System.Drawing.Size(810, 2);
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.drpTasklist);
            this.grpMain.Controls.Add(this.grdItem);
            this.grpMain.Controls.Add(this.grpControls);
            this.grpMain.Location = new System.Drawing.Point(0, 98);
            this.grpMain.Size = new System.Drawing.Size(812, 310);
            this.grpMain.Controls.SetChildIndex(this.lblLine3, 0);
            this.grpMain.Controls.SetChildIndex(this.grpControls, 0);
            this.grpMain.Controls.SetChildIndex(this.grdItem, 0);
            this.grpMain.Controls.SetChildIndex(this.drpTasklist, 0);
            // 
            // grpControls
            // 
            this.grpControls.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
            this.grpControls.Controls.Add(this.label1);
            this.grpControls.Controls.Add(this.cmbCrop);
            this.grpControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpControls.Location = new System.Drawing.Point(1, 0);
            this.grpControls.Name = "grpControls";
            this.grpControls.Size = new System.Drawing.Size(810, 75);
            this.grpControls.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.ForeColor = System.Drawing.Color.White;
            appearance3.TextHAlignAsString = "Right";
            appearance3.TextVAlignAsString = "Middle";
            this.label1.Appearance = appearance3;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(733, 22);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(48, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "محصول";
            // 
            // cmbCrop
            // 
            this.cmbCrop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.BorderColor = System.Drawing.Color.LightGray;
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.cmbCrop.Appearance = appearance1;
            this.cmbCrop.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.cmbCrop.BackColor = System.Drawing.Color.Transparent;
            this.cmbCrop.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbCrop.Editable = Baran.Windows.Forms.Editable.Editable;
            this.cmbCrop.InputLanguage = Baran.Windows.Forms.InputLanguage.Farsi;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.TextHAlignAsString = "Right";
            appearance2.TextVAlignAsString = "Middle";
            this.cmbCrop.ItemAppearance = appearance2;
            this.cmbCrop.Location = new System.Drawing.Point(288, 18);
            this.cmbCrop.Name = "cmbCrop";
            this.cmbCrop.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbCrop.Size = new System.Drawing.Size(439, 26);
            this.cmbCrop.TabIndex = 0;
            this.cmbCrop.ValueChanged += new System.EventHandler(this.cmbCrop_ValueChanged);
            // 
            // dstTask1
            // 
            this.dstTask1.DataSetName = "dstTask";
            this.dstTask1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // grdItem
            // 
            this.grdItem.BaseUltraGrid = this.grdItem;
            this.grdItem.DataMember = "spr_tsk_Tasklist_Crop_Link_Select";
            this.grdItem.DataSource = this.dstTask1;
            appearance31.BackColor = System.Drawing.Color.Transparent;
            appearance31.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            appearance31.ForeColor = System.Drawing.Color.White;
            appearance31.TextHAlignAsString = "Right";
            appearance31.TextVAlignAsString = "Middle";
            this.grdItem.DisplayLayout.Appearance = appearance31;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.Header.VisiblePosition = 1;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn3.Width = 36;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.Header.Caption = "                           لیست فعالیت";
            ultraGridColumn4.Header.VisiblePosition = 2;
            ultraGridColumn4.Width = 207;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.Header.VisiblePosition = 3;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn5.Width = 36;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.Header.VisiblePosition = 4;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn6.Width = 26;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.Header.Caption = "ردیف";
            ultraGridColumn7.Header.VisiblePosition = 5;
            ultraGridColumn7.TabStop = false;
            ultraGridColumn7.Width = 48;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn8.Header.Caption = "";
            ultraGridColumn8.Header.VisiblePosition = 0;
            ultraGridColumn8.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            ultraGridColumn8.TabStop = false;
            ultraGridColumn8.Width = 507;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8});
            ultraGridBand2.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom;
            ultraGridBand2.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            appearance4.ForeColor = System.Drawing.Color.DarkBlue;
            ultraGridBand2.Override.SummaryValueAppearance = appearance4;
            this.grdItem.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.grdItem.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            appearance5.ForeColor = System.Drawing.Color.DarkBlue;
            this.grdItem.DisplayLayout.CaptionAppearance = appearance5;
            this.grdItem.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.True;
            appearance32.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance32.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance32.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance32.BorderColor = System.Drawing.SystemColors.Window;
            this.grdItem.DisplayLayout.GroupByBox.Appearance = appearance32;
            appearance33.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdItem.DisplayLayout.GroupByBox.BandLabelAppearance = appearance33;
            this.grdItem.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance34.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance34.BackColor2 = System.Drawing.SystemColors.Control;
            appearance34.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance34.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdItem.DisplayLayout.GroupByBox.PromptAppearance = appearance34;
            this.grdItem.DisplayLayout.MaxColScrollRegions = 1;
            this.grdItem.DisplayLayout.MaxRowScrollRegions = 1;
            appearance23.BackColor = System.Drawing.SystemColors.Window;
            appearance23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdItem.DisplayLayout.Override.ActiveCellAppearance = appearance23;
            appearance24.BackColor = System.Drawing.Color.Gray;
            appearance24.BackColor2 = System.Drawing.Color.Gray;
            appearance24.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance24.ForeColor = System.Drawing.Color.White;
            this.grdItem.DisplayLayout.Override.ActiveRowAppearance = appearance24;
            this.grdItem.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Rounded1;
            this.grdItem.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.None;
            this.grdItem.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            this.grdItem.DisplayLayout.Override.BorderStyleRowSelector = Infragistics.Win.UIElementBorderStyle.None;
            appearance25.BackColor = System.Drawing.SystemColors.Window;
            this.grdItem.DisplayLayout.Override.CardAreaAppearance = appearance25;
            appearance26.BorderColor = System.Drawing.Color.Gray;
            appearance26.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grdItem.DisplayLayout.Override.CellAppearance = appearance26;
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
            appearance27.BackColor = System.Drawing.SystemColors.Control;
            appearance27.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance27.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance27.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance27.BorderColor = System.Drawing.SystemColors.Window;
            this.grdItem.DisplayLayout.Override.GroupByRowAppearance = appearance27;
            appearance28.BackColor = System.Drawing.Color.Transparent;
            appearance28.BackColor2 = System.Drawing.Color.Transparent;
            appearance28.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            appearance28.BorderColor = System.Drawing.Color.Transparent;
            appearance28.FontData.BoldAsString = "True";
            appearance28.FontData.Name = "B Nazanin";
            appearance28.FontData.SizeInPoints = 11F;
            appearance28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(179)))), ((int)(((byte)(4)))));
            appearance28.TextHAlignAsString = "Center";
            appearance28.TextVAlignAsString = "Middle";
            this.grdItem.DisplayLayout.Override.HeaderAppearance = appearance28;
            this.grdItem.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdItem.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsVista;
            appearance6.ForeColor = System.Drawing.Color.Yellow;
            this.grdItem.DisplayLayout.Override.HotTrackRowAppearance = appearance6;
            this.grdItem.DisplayLayout.Override.MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
            appearance29.BackColor = System.Drawing.Color.Transparent;
            appearance29.BorderColor = System.Drawing.Color.Silver;
            this.grdItem.DisplayLayout.Override.RowAppearance = appearance29;
            this.grdItem.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance30.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdItem.DisplayLayout.Override.TemplateAddRowAppearance = appearance30;
            appearance7.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            scrollBarLook1.Appearance = appearance7;
            appearance8.BackColor = System.Drawing.Color.DarkGray;
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            scrollBarLook1.ButtonAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.Gray;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            scrollBarLook1.ThumbAppearance = appearance9;
            appearance10.BackColor = System.Drawing.Color.DarkGray;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            scrollBarLook1.TrackAppearance = appearance10;
            scrollBarLook1.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2007;
            this.grdItem.DisplayLayout.ScrollBarLook = scrollBarLook1;
            this.grdItem.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdItem.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdItem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.grdItem.InputLanguage = Baran.Windows.Forms.InputLanguage.Farsi;
            this.grdItem.Location = new System.Drawing.Point(1, 75);
            this.grdItem.Name = "grdItem";
            this.grdItem.Size = new System.Drawing.Size(810, 232);
            this.grdItem.SumColumnsWidth = 303;
            this.grdItem.TabIndex = 1;
            // 
            // drpTasklist
            // 
            this.drpTasklist.DataMember = "spr_tsk_Tasklist_cmb_Select";
            this.drpTasklist.DataSource = this.dstTask1;
            appearance43.BackColor = System.Drawing.SystemColors.Window;
            appearance43.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.drpTasklist.DisplayLayout.Appearance = appearance43;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.Header.Caption = "";
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2});
            this.drpTasklist.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.drpTasklist.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.drpTasklist.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance44.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance44.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance44.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance44.BorderColor = System.Drawing.SystemColors.Window;
            this.drpTasklist.DisplayLayout.GroupByBox.Appearance = appearance44;
            appearance45.ForeColor = System.Drawing.SystemColors.GrayText;
            this.drpTasklist.DisplayLayout.GroupByBox.BandLabelAppearance = appearance45;
            this.drpTasklist.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance46.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance46.BackColor2 = System.Drawing.SystemColors.Control;
            appearance46.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance46.ForeColor = System.Drawing.SystemColors.GrayText;
            this.drpTasklist.DisplayLayout.GroupByBox.PromptAppearance = appearance46;
            this.drpTasklist.DisplayLayout.MaxColScrollRegions = 1;
            this.drpTasklist.DisplayLayout.MaxRowScrollRegions = 1;
            appearance35.BackColor = System.Drawing.SystemColors.Window;
            appearance35.ForeColor = System.Drawing.SystemColors.ControlText;
            this.drpTasklist.DisplayLayout.Override.ActiveCellAppearance = appearance35;
            appearance36.BackColor = System.Drawing.SystemColors.Highlight;
            appearance36.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.drpTasklist.DisplayLayout.Override.ActiveRowAppearance = appearance36;
            this.drpTasklist.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.drpTasklist.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance37.BackColor = System.Drawing.SystemColors.Window;
            this.drpTasklist.DisplayLayout.Override.CardAreaAppearance = appearance37;
            appearance38.BorderColor = System.Drawing.Color.Silver;
            appearance38.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.drpTasklist.DisplayLayout.Override.CellAppearance = appearance38;
            this.drpTasklist.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.drpTasklist.DisplayLayout.Override.CellPadding = 0;
            appearance39.BackColor = System.Drawing.SystemColors.Control;
            appearance39.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance39.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance39.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance39.BorderColor = System.Drawing.SystemColors.Window;
            this.drpTasklist.DisplayLayout.Override.GroupByRowAppearance = appearance39;
            appearance40.TextHAlignAsString = "Left";
            this.drpTasklist.DisplayLayout.Override.HeaderAppearance = appearance40;
            this.drpTasklist.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.drpTasklist.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance41.BackColor = System.Drawing.SystemColors.Window;
            appearance41.BorderColor = System.Drawing.Color.Silver;
            this.drpTasklist.DisplayLayout.Override.RowAppearance = appearance41;
            this.drpTasklist.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance42.BackColor = System.Drawing.SystemColors.ControlLight;
            this.drpTasklist.DisplayLayout.Override.TemplateAddRowAppearance = appearance42;
            this.drpTasklist.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.drpTasklist.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.drpTasklist.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.drpTasklist.DisplayMember = "TasklistName";
            this.drpTasklist.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.drpTasklist.Location = new System.Drawing.Point(246, 126);
            this.drpTasklist.Name = "drpTasklist";
            this.drpTasklist.Size = new System.Drawing.Size(161, 80);
            this.drpTasklist.TabIndex = 3;
            this.drpTasklist.ValueMember = "TasklistID";
            this.drpTasklist.Visible = false;
            // 
            // frmTasklistCrop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.ClientSize = new System.Drawing.Size(812, 483);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTasklistCrop";
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
            ((System.ComponentModel.ISupportInitialize)(this.grpButons)).EndInit();
            this.grpButons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpHeader)).EndInit();
            this.grpHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMessage)).EndInit();
            this.grpMessage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).EndInit();
            this.grpMain.ResumeLayout(false);
            this.grpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpControls)).EndInit();
            this.grpControls.ResumeLayout(false);
            this.grpControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCrop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstTask1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpTasklist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.Forms.GroupBox grpControls;
        private Windows.Forms.UltraComboEditor cmbCrop;
        private Windows.Forms.UltraGrid grdItem;
        private BaranDataAccess.Task.dstTask dstTask1;
        private Windows.Forms.Label label1;
        private Windows.Forms.UltraDropDown drpTasklist;
    }
}
