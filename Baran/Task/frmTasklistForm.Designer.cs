namespace Baran.Task
{
    partial class frmTasklistForm
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
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("spr_tsk_Task_cmb_Select", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TaskID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TaskName");
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("spr_tsk_Tasklist_Task_Link_Select", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TasklistTaskID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Fk_TaskID", -1, "drpTask");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Fk_TasklistID");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTasklistForm));
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DaysAfterStartDeason");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TaskPeriod");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FreeSpace", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RowID", 1);
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            this.grpControls = new Baran.Windows.Forms.GroupBox();
            this.label1 = new Baran.Windows.Forms.Label();
            this.txtTasklistName = new Baran.Windows.Forms.TextBox();
            this.dstTask1 = new BaranDataAccess.Task.dstTask();
            this.drpTask = new Baran.Windows.Forms.UltraDropDown();
            this.grdItem = new Baran.Windows.Forms.UltraGrid();
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
            ((System.ComponentModel.ISupportInitialize)(this.txtTasklistName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstTask1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpTask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItem)).BeginInit();
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
            this.grpPrint.Location = new System.Drawing.Point(63, 0);
            this.grpPrint.Size = new System.Drawing.Size(71, 74);
            // 
            // grpCancel
            // 
            this.grpCancel.Location = new System.Drawing.Point(779, 0);
            this.grpCancel.Size = new System.Drawing.Size(127, 74);
            // 
            // grpSave
            // 
            this.grpSave.Location = new System.Drawing.Point(652, 0);
            this.grpSave.Size = new System.Drawing.Size(127, 74);
            // 
            // grpChange
            // 
            this.grpChange.Location = new System.Drawing.Point(525, 0);
            this.grpChange.Size = new System.Drawing.Size(127, 74);
            // 
            // grpClear
            // 
            this.grpClear.Location = new System.Drawing.Point(398, 0);
            this.grpClear.Size = new System.Drawing.Size(127, 74);
            // 
            // grpDelete
            // 
            this.grpDelete.Location = new System.Drawing.Point(271, 0);
            this.grpDelete.Size = new System.Drawing.Size(127, 74);
            // 
            // grpDoc
            // 
            this.grpDoc.Location = new System.Drawing.Point(134, 0);
            this.grpDoc.Size = new System.Drawing.Size(137, 74);
            this.grpDoc.Visible = false;
            // 
            // grpRefresh
            // 
            this.grpRefresh.Location = new System.Drawing.Point(-8, 0);
            this.grpRefresh.Size = new System.Drawing.Size(71, 74);
            // 
            // grpNew
            // 
            this.grpNew.Location = new System.Drawing.Point(-135, 0);
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
            this.grpButons.Location = new System.Drawing.Point(0, 452);
            this.grpButons.Size = new System.Drawing.Size(907, 75);
            // 
            // lblLine2
            // 
            this.lblLine2.Size = new System.Drawing.Size(905, 3);
            // 
            // grpHeader
            // 
            this.grpHeader.Size = new System.Drawing.Size(907, 75);
            this.grpHeader.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(841, 9);
            // 
            // lblCaption
            // 
            this.lblCaption.Location = new System.Drawing.Point(539, 24);
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(1, 0);
            this.lblMessage.Size = new System.Drawing.Size(974, 29);
            // 
            // lblLine1
            // 
            this.lblLine1.Size = new System.Drawing.Size(905, 3);
            // 
            // grpMessage
            // 
            this.grpMessage.Size = new System.Drawing.Size(907, 30);
            // 
            // lblLine3
            // 
            this.lblLine3.Location = new System.Drawing.Point(1, 343);
            this.lblLine3.Size = new System.Drawing.Size(905, 3);
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.drpTask);
            this.grpMain.Controls.Add(this.grdItem);
            this.grpMain.Controls.Add(this.grpControls);
            this.grpMain.Size = new System.Drawing.Size(907, 347);
            this.grpMain.Controls.SetChildIndex(this.grpControls, 0);
            this.grpMain.Controls.SetChildIndex(this.lblLine3, 0);
            this.grpMain.Controls.SetChildIndex(this.grdItem, 0);
            this.grpMain.Controls.SetChildIndex(this.drpTask, 0);
            // 
            // grpControls
            // 
            this.grpControls.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None;
            this.grpControls.Controls.Add(this.label1);
            this.grpControls.Controls.Add(this.txtTasklistName);
            this.grpControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpControls.Location = new System.Drawing.Point(1, 0);
            this.grpControls.Name = "grpControls";
            this.grpControls.Size = new System.Drawing.Size(905, 64);
            this.grpControls.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance15.ForeColor = System.Drawing.Color.White;
            appearance15.TextHAlignAsString = "Right";
            appearance15.TextVAlignAsString = "Middle";
            this.label1.Appearance = appearance15;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(772, 19);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(107, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "نام لیست فعالیت";
            // 
            // txtTasklistName
            // 
            this.txtTasklistName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Right";
            this.txtTasklistName.Appearance = appearance1;
            this.txtTasklistName.BackColor = System.Drawing.Color.Transparent;
            this.txtTasklistName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtTasklistName.FontSize = 0;
            this.txtTasklistName.Location = new System.Drawing.Point(171, 17);
            this.txtTasklistName.Name = "txtTasklistName";
            this.txtTasklistName.PreviousBackColor = System.Drawing.Color.Transparent;
            this.txtTasklistName.PreviousForeColor = System.Drawing.Color.Transparent;
            this.txtTasklistName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTasklistName.Size = new System.Drawing.Size(598, 26);
            this.txtTasklistName.TabIndex = 0;
            this.txtTasklistName.UnformattedText = null;
            // 
            // dstTask1
            // 
            this.dstTask1.DataSetName = "dstTask";
            this.dstTask1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // drpTask
            // 
            this.drpTask.DataMember = "spr_tsk_Task_cmb_Select";
            this.drpTask.DataSource = this.dstTask1;
            appearance47.BackColor = System.Drawing.SystemColors.Window;
            appearance47.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.drpTask.DisplayLayout.Appearance = appearance47;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.Header.Caption = "";
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.MinWidth = 250;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2});
            this.drpTask.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.drpTask.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.drpTask.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance48.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance48.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance48.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance48.BorderColor = System.Drawing.SystemColors.Window;
            this.drpTask.DisplayLayout.GroupByBox.Appearance = appearance48;
            appearance49.ForeColor = System.Drawing.SystemColors.GrayText;
            this.drpTask.DisplayLayout.GroupByBox.BandLabelAppearance = appearance49;
            this.drpTask.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance50.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance50.BackColor2 = System.Drawing.SystemColors.Control;
            appearance50.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance50.ForeColor = System.Drawing.SystemColors.GrayText;
            this.drpTask.DisplayLayout.GroupByBox.PromptAppearance = appearance50;
            this.drpTask.DisplayLayout.MaxColScrollRegions = 1;
            this.drpTask.DisplayLayout.MaxRowScrollRegions = 1;
            appearance14.BackColor = System.Drawing.SystemColors.Window;
            appearance14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.drpTask.DisplayLayout.Override.ActiveCellAppearance = appearance14;
            appearance40.BackColor = System.Drawing.SystemColors.Highlight;
            appearance40.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.drpTask.DisplayLayout.Override.ActiveRowAppearance = appearance40;
            this.drpTask.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.drpTask.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance41.BackColor = System.Drawing.SystemColors.Window;
            this.drpTask.DisplayLayout.Override.CardAreaAppearance = appearance41;
            appearance42.BorderColor = System.Drawing.Color.Silver;
            appearance42.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.drpTask.DisplayLayout.Override.CellAppearance = appearance42;
            this.drpTask.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.drpTask.DisplayLayout.Override.CellPadding = 0;
            appearance43.BackColor = System.Drawing.SystemColors.Control;
            appearance43.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance43.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance43.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance43.BorderColor = System.Drawing.SystemColors.Window;
            this.drpTask.DisplayLayout.Override.GroupByRowAppearance = appearance43;
            appearance44.TextHAlignAsString = "Left";
            this.drpTask.DisplayLayout.Override.HeaderAppearance = appearance44;
            this.drpTask.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.drpTask.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance45.BackColor = System.Drawing.SystemColors.Window;
            appearance45.BorderColor = System.Drawing.Color.Silver;
            this.drpTask.DisplayLayout.Override.RowAppearance = appearance45;
            this.drpTask.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance46.BackColor = System.Drawing.SystemColors.ControlLight;
            this.drpTask.DisplayLayout.Override.TemplateAddRowAppearance = appearance46;
            this.drpTask.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.drpTask.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.drpTask.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.drpTask.DisplayMember = "TaskName";
            this.drpTask.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.drpTask.Location = new System.Drawing.Point(272, 132);
            this.drpTask.Name = "drpTask";
            this.drpTask.Size = new System.Drawing.Size(249, 80);
            this.drpTask.TabIndex = 3;
            this.drpTask.Text = "ultraDropDown1";
            this.drpTask.ValueMember = "TaskID";
            this.drpTask.Visible = false;
            // 
            // grdItem
            // 
            this.grdItem.BaseUltraGrid = this.grdItem;
            this.grdItem.DataMember = "spr_tsk_Tasklist_Task_Link_Select";
            this.grdItem.DataSource = this.dstTask1;
            appearance59.BackColor = System.Drawing.Color.Transparent;
            appearance59.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            appearance59.ForeColor = System.Drawing.Color.White;
            appearance59.TextHAlignAsString = "Right";
            appearance59.TextVAlignAsString = "Middle";
            this.grdItem.DisplayLayout.Appearance = appearance59;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.Header.VisiblePosition = 1;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn3.Width = 36;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.Header.Caption = "         فعالیت        ";
            ultraGridColumn4.Header.VisiblePosition = 5;
            ultraGridColumn4.MinWidth = 250;
            ultraGridColumn4.TabIndex = 0;
            ultraGridColumn4.Width = 250;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.DefaultCellValue = ((object)(resources.GetObject("ultraGridColumn5.DefaultCellValue")));
            ultraGridColumn5.Header.VisiblePosition = 2;
            ultraGridColumn5.Hidden = true;
            ultraGridColumn5.Width = 36;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.Header.Caption = "شروع فعالیت چند روز بعد از شروع فصل زراعی";
            ultraGridColumn6.Header.VisiblePosition = 4;
            ultraGridColumn6.TabIndex = 1;
            ultraGridColumn6.Width = 314;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.Header.Caption = "طول دوره فعالیت";
            ultraGridColumn7.Header.VisiblePosition = 3;
            ultraGridColumn7.TabIndex = 2;
            ultraGridColumn7.Width = 121;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn8.Header.Caption = "";
            ultraGridColumn8.Header.VisiblePosition = 0;
            ultraGridColumn8.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            ultraGridColumn8.TabStop = false;
            ultraGridColumn8.Width = 124;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn9.Header.Caption = "ردیف";
            ultraGridColumn9.Header.VisiblePosition = 6;
            ultraGridColumn9.TabStop = false;
            ultraGridColumn9.Width = 48;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9});
            ultraGridBand2.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            ultraGridBand2.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            appearance2.ForeColor = System.Drawing.Color.DarkBlue;
            ultraGridBand2.Override.SummaryValueAppearance = appearance2;
            this.grdItem.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.grdItem.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            appearance4.ForeColor = System.Drawing.Color.DarkBlue;
            this.grdItem.DisplayLayout.CaptionAppearance = appearance4;
            this.grdItem.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.True;
            appearance60.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance60.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance60.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance60.BorderColor = System.Drawing.SystemColors.Window;
            this.grdItem.DisplayLayout.GroupByBox.Appearance = appearance60;
            appearance61.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdItem.DisplayLayout.GroupByBox.BandLabelAppearance = appearance61;
            this.grdItem.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance62.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance62.BackColor2 = System.Drawing.SystemColors.Control;
            appearance62.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance62.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdItem.DisplayLayout.GroupByBox.PromptAppearance = appearance62;
            this.grdItem.DisplayLayout.MaxColScrollRegions = 1;
            this.grdItem.DisplayLayout.MaxRowScrollRegions = 1;
            appearance51.BackColor = System.Drawing.SystemColors.Window;
            appearance51.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdItem.DisplayLayout.Override.ActiveCellAppearance = appearance51;
            appearance52.BackColor = System.Drawing.Color.Gray;
            appearance52.BackColor2 = System.Drawing.Color.Gray;
            appearance52.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance52.ForeColor = System.Drawing.Color.White;
            this.grdItem.DisplayLayout.Override.ActiveRowAppearance = appearance52;
            appearance17.BackColor = System.Drawing.Color.Transparent;
            appearance17.ForeColor = System.Drawing.Color.White;
            this.grdItem.DisplayLayout.Override.AddRowAppearance = appearance17;
            this.grdItem.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom;
            this.grdItem.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Rounded1;
            this.grdItem.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.None;
            this.grdItem.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            this.grdItem.DisplayLayout.Override.BorderStyleRowSelector = Infragistics.Win.UIElementBorderStyle.None;
            appearance53.BackColor = System.Drawing.SystemColors.Window;
            this.grdItem.DisplayLayout.Override.CardAreaAppearance = appearance53;
            appearance54.BorderColor = System.Drawing.Color.Gray;
            appearance54.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grdItem.DisplayLayout.Override.CellAppearance = appearance54;
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
            appearance55.BackColor = System.Drawing.SystemColors.Control;
            appearance55.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance55.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance55.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance55.BorderColor = System.Drawing.SystemColors.Window;
            this.grdItem.DisplayLayout.Override.GroupByRowAppearance = appearance55;
            appearance56.BackColor = System.Drawing.Color.Transparent;
            appearance56.BackColor2 = System.Drawing.Color.Transparent;
            appearance56.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance56.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            appearance56.BorderColor = System.Drawing.Color.Transparent;
            appearance56.FontData.BoldAsString = "True";
            appearance56.FontData.Name = "B Nazanin";
            appearance56.FontData.SizeInPoints = 11F;
            appearance56.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(179)))), ((int)(((byte)(4)))));
            appearance56.TextHAlignAsString = "Center";
            appearance56.TextVAlignAsString = "Middle";
            this.grdItem.DisplayLayout.Override.HeaderAppearance = appearance56;
            this.grdItem.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdItem.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsVista;
            appearance5.ForeColor = System.Drawing.Color.Yellow;
            this.grdItem.DisplayLayout.Override.HotTrackRowAppearance = appearance5;
            this.grdItem.DisplayLayout.Override.MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
            appearance57.BackColor = System.Drawing.Color.Transparent;
            appearance57.BorderColor = System.Drawing.Color.Silver;
            this.grdItem.DisplayLayout.Override.RowAppearance = appearance57;
            this.grdItem.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance58.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdItem.DisplayLayout.Override.TemplateAddRowAppearance = appearance58;
            appearance6.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            scrollBarLook1.Appearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.DarkGray;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            scrollBarLook1.ButtonAppearance = appearance7;
            appearance8.BackColor = System.Drawing.Color.Gray;
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            scrollBarLook1.ThumbAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.DarkGray;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            scrollBarLook1.TrackAppearance = appearance9;
            scrollBarLook1.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2007;
            this.grdItem.DisplayLayout.ScrollBarLook = scrollBarLook1;
            this.grdItem.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdItem.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdItem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.grdItem.InputLanguage = Baran.Windows.Forms.InputLanguage.Farsi;
            this.grdItem.Location = new System.Drawing.Point(1, 64);
            this.grdItem.Name = "grdItem";
            this.grdItem.Size = new System.Drawing.Size(905, 279);
            this.grdItem.SumColumnsWidth = 781;
            this.grdItem.TabIndex = 1;
            // 
            // frmTasklistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.ClientSize = new System.Drawing.Size(907, 527);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTasklistForm";
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
            this.grpHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMessage)).EndInit();
            this.grpMessage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).EndInit();
            this.grpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpControls)).EndInit();
            this.grpControls.ResumeLayout(false);
            this.grpControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTasklistName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstTask1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drpTask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.Forms.GroupBox grpControls;
        private Windows.Forms.Label label1;
        private Windows.Forms.TextBox txtTasklistName;
        private BaranDataAccess.Task.dstTask dstTask1;
        private Windows.Forms.UltraDropDown drpTask;
        private Windows.Forms.UltraGrid grdItem;
    }
}
