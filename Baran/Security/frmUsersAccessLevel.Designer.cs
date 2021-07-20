namespace Baran.Security
{
    partial class frmUsersAccessLevel
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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("spr_Sec_UsersAccessLevel_Select", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UserID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UserName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IsActiveUser");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FullName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ShopName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PackageID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PackageName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PackageLogo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ItemID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ItemName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ItemLogo");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("bitSave");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("bitChange");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("bitDelete");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("bitNew");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("bitPrint");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IsManager");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IsAccountant");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IsSalesPerson");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("IsOtherStaff");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("RowID", 0);
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            this.dstsecurity1 = new BaranDataAccess.Security.dstSecurity();
            this.dgvUsers = new Baran.Windows.Forms.UltraGrid();

            ((System.ComponentModel.ISupportInitialize)(this.grpButons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMessage)).BeginInit();
            this.grpMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).BeginInit();
            this.grpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstsecurity1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Size = new System.Drawing.Size(697, 29);
            // 
            // grpHeader
            // 
            this.grpHeader.Size = new System.Drawing.Size(699, 65);
            // 
            // grpButons
            // 
            this.grpButons.Location = new System.Drawing.Point(0, 297);
            this.grpButons.Size = new System.Drawing.Size(699, 67);
            // 
            // grpMessage
            // 
            this.grpMessage.Location = new System.Drawing.Point(0, 65);
            this.grpMessage.Size = new System.Drawing.Size(699, 30);
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.dgvUsers);
            this.grpMain.Location = new System.Drawing.Point(0, 95);
            this.grpMain.Size = new System.Drawing.Size(699, 202);
            this.grpMain.Controls.SetChildIndex(this.dgvUsers, 0);
            // 
            // lblLine1
            // 
            this.lblLine1.Size = new System.Drawing.Size(697, 3);
            // 
            // lblLine2
            // 
            this.lblLine2.Location = new System.Drawing.Point(1, 61);
            this.lblLine2.Size = new System.Drawing.Size(697, 3);
            // 
            // dstsecurity1
            // 
            this.dstsecurity1.DataSetName = "dstSecurity1";
            this.dstsecurity1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgvUsers
            // 
            this.dgvUsers.DataMember = "spr_Sec_UsersAccessLevel_Select";
            this.dgvUsers.DataSource = this.dstsecurity1;
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            appearance4.ForeColor = System.Drawing.Color.White;
            appearance4.TextHAlignAsString = "Right";
            appearance4.TextVAlignAsString = "Middle";
            this.dgvUsers.DisplayLayout.Appearance = appearance4;
            this.dgvUsers.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn1.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.DropDownList;
            ultraGridColumn1.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn2.Header.Caption = "نام کاربری";
            ultraGridColumn2.Header.VisiblePosition = 19;
            ultraGridColumn2.Width = 78;
            ultraGridColumn3.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn3.Header.Caption = "وضعیت";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Width = 69;
            ultraGridColumn4.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn4.Header.Caption = "نام خانوادگی";
            ultraGridColumn4.Header.VisiblePosition = 18;
            ultraGridColumn4.Width = 106;
            ultraGridColumn5.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn5.Header.Caption = "فروشگاه";
            ultraGridColumn5.Header.VisiblePosition = 1;
            ultraGridColumn5.Width = 49;
            ultraGridColumn6.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn6.Header.VisiblePosition = 3;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn7.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn7.Header.Caption = "گروه";
            ultraGridColumn7.Header.VisiblePosition = 17;
            ultraGridColumn7.Width = 84;
            ultraGridColumn8.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn8.Header.VisiblePosition = 4;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn9.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn9.Header.VisiblePosition = 5;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn10.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn10.Header.Caption = "آیتم";
            ultraGridColumn10.Header.VisiblePosition = 16;
            ultraGridColumn10.Width = 96;
            ultraGridColumn11.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn11.Header.VisiblePosition = 6;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn12.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn12.Header.Caption = "ثبت";
            ultraGridColumn12.Header.VisiblePosition = 15;
            ultraGridColumn12.Width = 31;
            ultraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn13.Header.Caption = "تغییر";
            ultraGridColumn13.Header.VisiblePosition = 14;
            ultraGridColumn13.Width = 32;
            ultraGridColumn14.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn14.Header.Caption = "حذف";
            ultraGridColumn14.Header.VisiblePosition = 13;
            ultraGridColumn14.Width = 36;
            ultraGridColumn15.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn15.Header.Caption = "جدید";
            ultraGridColumn15.Header.VisiblePosition = 12;
            ultraGridColumn15.Width = 39;
            ultraGridColumn16.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn16.Header.Caption = "پرینت";
            ultraGridColumn16.Header.VisiblePosition = 11;
            ultraGridColumn16.Width = 53;
            ultraGridColumn17.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn17.Header.Caption = "مدیر";
            ultraGridColumn17.Header.VisiblePosition = 10;
            ultraGridColumn17.Hidden = true;
            ultraGridColumn17.Width = 40;
            ultraGridColumn18.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn18.Header.Caption = "حسابدار";
            ultraGridColumn18.Header.VisiblePosition = 9;
            ultraGridColumn18.Hidden = true;
            ultraGridColumn18.Width = 51;
            ultraGridColumn19.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn19.Header.Caption = "فروشنده";
            ultraGridColumn19.Header.VisiblePosition = 8;
            ultraGridColumn19.Hidden = true;
            ultraGridColumn19.Width = 51;
            ultraGridColumn20.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn20.Header.Caption = "سایر";
            ultraGridColumn20.Header.VisiblePosition = 7;
            ultraGridColumn20.Hidden = true;
            ultraGridColumn20.Width = 31;
            ultraGridColumn21.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append;
            ultraGridColumn21.Header.Caption = "ردیف";
            ultraGridColumn21.Header.VisiblePosition = 20;
            ultraGridColumn21.TabStop = false;
            ultraGridColumn21.Width = 24;
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
            ultraGridColumn19,
            ultraGridColumn20,
            ultraGridColumn21});
            ultraGridBand1.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            appearance1.ForeColor = System.Drawing.Color.DarkBlue;
            ultraGridBand1.Override.SummaryValueAppearance = appearance1;
            this.dgvUsers.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.dgvUsers.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            appearance5.ForeColor = System.Drawing.Color.AliceBlue;
            this.dgvUsers.DisplayLayout.CaptionAppearance = appearance5;
            this.dgvUsers.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.True;
            appearance6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.dgvUsers.DisplayLayout.GroupByBox.Appearance = appearance6;
            appearance7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgvUsers.DisplayLayout.GroupByBox.BandLabelAppearance = appearance7;
            this.dgvUsers.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance8.BackColor2 = System.Drawing.SystemColors.Control;
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance8.ForeColor = System.Drawing.SystemColors.GrayText;
            this.dgvUsers.DisplayLayout.GroupByBox.PromptAppearance = appearance8;
            this.dgvUsers.DisplayLayout.MaxColScrollRegions = 1;
            this.dgvUsers.DisplayLayout.MaxRowScrollRegions = 1;
            appearance2.BackColor = System.Drawing.Color.Gray;
            appearance2.BackColor2 = System.Drawing.Color.Gray;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.ForeColor = System.Drawing.Color.White;
            this.dgvUsers.DisplayLayout.Override.ActiveRowAppearance = appearance2;
            this.dgvUsers.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.dgvUsers.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.dgvUsers.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.dgvUsers.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.dgvUsers.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Rounded1;
            this.dgvUsers.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.None;
            this.dgvUsers.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;
            this.dgvUsers.DisplayLayout.Override.BorderStyleRowSelector = Infragistics.Win.UIElementBorderStyle.None;
            appearance12.BorderColor = System.Drawing.Color.Gray;
            appearance12.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.dgvUsers.DisplayLayout.Override.CellAppearance = appearance12;
            this.dgvUsers.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.dgvUsers.DisplayLayout.Override.CellSpacing = 2;
            this.dgvUsers.DisplayLayout.Override.DefaultRowHeight = 25;
            this.dgvUsers.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Combo;
            this.dgvUsers.DisplayLayout.Override.FilterOperatorDropDownItems = ((Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems)(((((((((((((((((Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.Equals | Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.NotEquals) 
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
            this.dgvUsers.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.WithOperand;
            this.dgvUsers.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            appearance13.BackColor = System.Drawing.SystemColors.Control;
            appearance13.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance13.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance13.BorderColor = System.Drawing.SystemColors.Window;
            this.dgvUsers.DisplayLayout.Override.GroupByRowAppearance = appearance13;
            appearance14.BackColor = System.Drawing.Color.Transparent;
            appearance14.BackColor2 = System.Drawing.Color.Transparent;
            appearance14.BackColorAlpha = Infragistics.Win.Alpha.Transparent;
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            appearance14.BorderColor = System.Drawing.Color.Transparent;
            appearance14.FontData.BoldAsString = "True";
            appearance14.FontData.Name = "B Nazanin";
            appearance14.FontData.SizeInPoints = 11F;
            appearance14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(179)))), ((int)(((byte)(4)))));
            appearance14.TextHAlignAsString = "Center";
            appearance14.TextVAlignAsString = "Middle";
            this.dgvUsers.DisplayLayout.Override.HeaderAppearance = appearance14;
            this.dgvUsers.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsVista;
            appearance15.ForeColor = System.Drawing.Color.Yellow;
            this.dgvUsers.DisplayLayout.Override.HotTrackRowAppearance = appearance15;
            this.dgvUsers.DisplayLayout.Override.MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
            this.dgvUsers.DisplayLayout.Override.MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
            appearance17.BackColor = System.Drawing.Color.Transparent;
            this.dgvUsers.DisplayLayout.Override.RowAppearance = appearance17;
            this.dgvUsers.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.dgvUsers.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.dgvUsers.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.dgvUsers.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            appearance18.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dgvUsers.DisplayLayout.Override.TemplateAddRowAppearance = appearance18;
            appearance3.BorderAlpha = Infragistics.Win.Alpha.Transparent;
            scrollBarLook1.Appearance = appearance3;
            appearance9.BackColor = System.Drawing.Color.DarkGray;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            scrollBarLook1.ButtonAppearance = appearance9;
            appearance10.BackColor = System.Drawing.Color.Gray;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            scrollBarLook1.ThumbAppearance = appearance10;
            appearance11.BackColor = System.Drawing.Color.DarkGray;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            scrollBarLook1.TrackAppearance = appearance11;
            scrollBarLook1.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2007;
            this.dgvUsers.DisplayLayout.ScrollBarLook = scrollBarLook1;
            this.dgvUsers.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.dgvUsers.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dgvUsers.InputLanguage = Baran.Windows.Forms.InputLanguage.Farsi;
            this.dgvUsers.Location = new System.Drawing.Point(1, 0);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvUsers.Size = new System.Drawing.Size(697, 201);
            this.dgvUsers.SumColumnsWidth = 0;
            this.dgvUsers.TabIndex = 0;
            // 
            // frmUsersAccessLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(699, 364);
            this.Name = "frmUsersAccessLevel";
            this.Activated += new System.EventHandler(this.frmUsersAccessLevel_Activated);
            this.Load += new System.EventHandler(this.frmUsersAccessLevel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpButons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMessage)).EndInit();
            this.grpMessage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpMain)).EndInit();
            this.grpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstsecurity1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BaranDataAccess.Security.dstSecurity dstsecurity1;
        private Baran.Windows.Forms.UltraGrid dgvUsers;
    }
}
