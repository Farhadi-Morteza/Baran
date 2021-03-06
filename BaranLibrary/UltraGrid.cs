using BaranLibrary;
using Infragistics.Win;
namespace Baran.Windows.Forms
{
    [System.Drawing.ToolboxBitmap(typeof(Infragistics.Win.UltraWinGrid.UltraGrid))]
    public class UltraGrid : Infragistics.Win.UltraWinGrid.UltraGrid
    {
        public UltraGrid()
        {
            this.InputLanguage = InputLanguage.Farsi;

            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));

            Dock = System.Windows.Forms.DockStyle.Fill;

            Infragistics.Win.UltraWinGrid.UltraGrid newUltraGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.BaseUltraGrid = newUltraGrid;

        }

        System.Globalization.CultureInfo _faCultureInfo = new System.Globalization.CultureInfo("fa-IR", false);
        System.Globalization.CultureInfo _enCultureInfo = new System.Globalization.CultureInfo("en-US", false);

        public static class ColumnKey
        {
            public static readonly string RowID = "RowID";
            public static readonly string New = "New";
            public static readonly string Delete = "Delete";
            public static readonly string Update = "Update";
            public static readonly string Detail = "Detail";
        }

        public static class ColumnCaption
        {
            public static readonly string RowID = "#";
            public static readonly string New = "...";
            public static readonly string Delete = "...";
            public static readonly string Update = "...";
            public static readonly string Detail = "...";
        }

        private bool _IsfreeSpaceGenerator = true;
        [System.ComponentModel.DefaultValue(true)]
        public bool IsFreeSpaceGenerator
        {
            get
            {
                return (_IsfreeSpaceGenerator);
            }
            set
            {
                _IsfreeSpaceGenerator = value;
            }
        }

        private int _SumColumnsWidth;
        public int SumColumnsWidth
        {
            get
            {
                return _SumColumnsWidth;
            }
            set
            {
                _SumColumnsWidth = value;
            }
        }

        private Infragistics.Win.UltraWinGrid.UltraGrid _BaseUltraGrid;
        public Infragistics.Win.UltraWinGrid.UltraGrid BaseUltraGrid
        {
            get
            {
                return _BaseUltraGrid;
            }
            set
            {
                _BaseUltraGrid = value;
            }
        }

        private InputLanguage _inputLanguage;

        public InputLanguage InputLanguage
        {
            get
            {
                return (_inputLanguage);
            }
            set
            {
                _inputLanguage = value;

                //switch (_inputLanguage)
                //{
                //    case InputLanguage.Farsi:
                //        {
                //            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                //            break;
                //        }

                //    case InputLanguage.English:
                //        {
                //            RightToLeft = System.Windows.Forms.RightToLeft.No;
                //            break;
                //        }
                //}
            }
        }

        protected override void OnEnter(System.EventArgs e)
        {
            base.OnEnter(e);

            switch (InputLanguage)
            {
                case InputLanguage.Farsi:
                    {
                        System.Windows.Forms.InputLanguage.CurrentInputLanguage =
                            System.Windows.Forms.InputLanguage.FromCulture(_faCultureInfo);

                        break;
                    }

                case InputLanguage.English:
                    {
                        System.Windows.Forms.InputLanguage.CurrentInputLanguage =
                            System.Windows.Forms.InputLanguage.FromCulture(_enCultureInfo);

                        break;
                    }
            }
        }

        protected override void OnBeforeRowsDeleted(Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            base.OnBeforeRowsDeleted(e);
            e.DisplayPromptMsg = false;
        }

        protected override void OnInitializeLayout(Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            base.OnInitializeLayout(e);
            this.FreeSpaceGenerator();

            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));

            try
            {
                e.Layout.Bands[0].Columns.Add("RowID", "#");

            }
            catch
            { }

            try
            {
                e.Layout.Bands[0].Columns.Add(ColumnKey.New, ColumnCaption.New);
                e.Layout.Bands[0].Columns.Add(ColumnKey.Detail, ColumnCaption.Detail);
                e.Layout.Bands[0].Columns.Add(ColumnKey.Delete, ColumnCaption.Delete);
                e.Layout.Bands[0].Columns.Add(ColumnKey.Update, ColumnCaption.Update);
                e.Layout.Bands[0].Columns.Add(ColumnKey.RowID, ColumnCaption.RowID);

                e.Layout.Bands[0].Columns[ColumnKey.New].Width = 30;
                e.Layout.Bands[0].Columns[ColumnKey.Detail].Width = 30;
                e.Layout.Bands[0].Columns[ColumnKey.Delete].Width = 30;
                e.Layout.Bands[0].Columns[ColumnKey.Update].Width = 30;
                e.Layout.Bands[0].Columns[ColumnKey.RowID].Width = 30;

            }
            catch { }

            try
            {
                e.Layout.Bands[0].Columns[ColumnKey.RowID].TabStop = false;
                //e.Layout.Bands[0].Columns["RowID"].TabIndex = 1;
                e.Layout.Bands[0].Columns[ColumnKey.RowID].Header.VisiblePosition = BaseUltraGrid.DisplayLayout.Bands[0].Columns.Count;
                e.Layout.Bands[0].Columns[ColumnKey.Update].Header.VisiblePosition = BaseUltraGrid.DisplayLayout.Bands[0].Columns.Count - 1;
                e.Layout.Bands[0].Columns[ColumnKey.Delete].Header.VisiblePosition = BaseUltraGrid.DisplayLayout.Bands[0].Columns.Count - 2;
                e.Layout.Bands[0].Columns[ColumnKey.Detail].Header.VisiblePosition = BaseUltraGrid.DisplayLayout.Bands[0].Columns.Count - 3;
                e.Layout.Bands[0].Columns[ColumnKey.New].Header.VisiblePosition = BaseUltraGrid.DisplayLayout.Bands[0].Columns.Count - 4;

                e.Layout.Bands[0].Columns[ColumnKey.New].Hidden = true;
            }
            catch { }

            try
            {
                e.Layout.Bands[0].Columns[ColumnKey.Update].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
                e.Layout.Bands[0].Columns[ColumnKey.Delete].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
                e.Layout.Bands[0].Columns[ColumnKey.Detail].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
                e.Layout.Bands[0].Columns[ColumnKey.New].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            }
            catch 
            { }

            e.Layout.Bands[0].Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            e.Layout.Bands[0].Override.SummaryValueAppearance.ForeColor = System.Drawing.Color.DarkBlue;
                       
            //Appearance ------------------------------------------------------------------------------------------------------------------
            e.Layout.Appearance.ForeColor = BaranLibrary.GeneralProperties.BaseControlForeColor;
            e.Layout.Appearance.TextHAlign = HAlign.Right;
            e.Layout.Appearance.TextVAlign = VAlign.Middle;            
            e.Layout.BorderStyle = UIElementBorderStyle.None;
            e.Layout.Appearance.BackColor = System.Drawing.Color.Transparent;
            e.Layout.CaptionVisible = DefaultableBoolean.True;
            e.Layout.CaptionAppearance.ForeColor = System.Drawing.Color.Black;
            e.Layout.CaptionAppearance.BackColor = System.Drawing.Color.WhiteSmoke;
            //-------------------------------------------------------------------------------------------------------------------------

            //Row ------------------------------------------------------------------------------------------------------------------
            e.Layout.Override.BorderStyleRow = UIElementBorderStyle.None;
            e.Layout.Override.BorderStyleRowSelector = UIElementBorderStyle.None;
            e.Layout.Override.DefaultRowHeight = 20;
            e.Layout.Override.RowAppearance.BackColor = System.Drawing.Color.Transparent;
            e.Layout.Override.HotTrackRowAppearance.ForeColor = System.Drawing.Color.Yellow;
            
            //e.Layout.Override.RowAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Override.RowAppearance.TextVAlign = VAlign.Middle;
            //e.Layout.Override.HotTrackRowAppearance.FontData.Bold = DefaultableBoolean.True;
            //e.Layout.Override.RowAlternateAppearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            //-------------------------------------------------------------------------------------------------------------------------

            //Cell ------------------------------------------------------------------------------------------------------------------
            e.Layout.Override.CellSpacing = 2;
            e.Layout.Override.BorderStyleCell = UIElementBorderStyle.Rounded1;
            e.Layout.Override.CellAppearance.BorderColor = System.Drawing.Color.Gray;
            e.Layout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            //-------------------------------------------------------------------------------------------------------------------------

            //Header------------------------------------------------------------------------------------------------------------------
            e.Layout.Override.HeaderStyle = HeaderStyle.WindowsVista;
            e.Layout.Override.BorderStyleHeader = UIElementBorderStyle.None;
            e.Layout.Override.HeaderAppearance.TextHAlign = HAlign.Center;
            e.Layout.Override.HeaderAppearance.TextVAlign = VAlign.Middle;
            e.Layout.Override.HeaderAppearance.ForeColor = BaranLibrary.GeneralProperties.BaseColor2;
            e.Layout.Override.HeaderAppearance.BackColor = System.Drawing.Color.Transparent;
            e.Layout.Override.HeaderAppearance.BackColor2 = System.Drawing.Color.Transparent;
            e.Layout.Override.HeaderAppearance.BorderColor = System.Drawing.Color.Transparent;
            e.Layout.Override.HeaderAppearance.BackColorAlpha = Alpha.Transparent;
            e.Layout.Override.HeaderAppearance.BackGradientStyle = GradientStyle.None;
            e.Layout.Override.HeaderAppearance.FontData.Name = "B Nazanin";
            e.Layout.Override.HeaderAppearance.FontData.Bold = DefaultableBoolean.True;
            e.Layout.Override.HeaderAppearance.FontData.SizeInPoints = 10F;
            //-------------------------------------------------------------------------------------------------------------------------

            //Filter------------------------------------------------------------------------------------------------------------------
            e.Layout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            e.Layout.Override.FilterOperatorDropDownItems = Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.All;
            e.Layout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Default;
            e.Layout.Override.FilterRowPrompt = ""; // "برای فیلتر اینجا را کلیک کنید";
            e.Layout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Combo;            
            e.Layout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.WithOperand;
            //e.Layout.Bands[0].Columns[0].FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden;
            //e.Layout.Bands[0].Columns[0].FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.DropDownList;
            //-------------------------------------------------------------------------------------------------------------------------

            //ActiveRow------------------------------------------------------------------------------------------------------------------
            e.Layout.Override.ActiveRowAppearance.BackColor = System.Drawing.Color.Gray;
            e.Layout.Override.ActiveRowAppearance.BackColor2 = System.Drawing.Color.Gray;
            e.Layout.Override.ActiveRowAppearance.ForeColor = System.Drawing.Color.White;
            e.Layout.Override.ActiveRowAppearance.BackGradientStyle = GradientStyle.Vertical;
            //-------------------------------------------------------------------------------------------------------------------------

            //ActiveRow------------------------------------------------------------------------------------------------------------------
            this.ActiveColScrollRegion.Position = this.ActiveColScrollRegion.Position + 31000; // this.Size.Width;        
            
            //-------------------------------------------------------------------------------------------------------------------------
            //ScrollBar------------------------------------------------------------------------------------------------------------------
            e.Layout.ScrollBarLook.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2007;
            e.Layout.ScrollBarLook.TrackAppearance.BackColor = System.Drawing.Color.DarkGray;// BaranLibrary.GeneralProperties.BaseColor;
            e.Layout.ScrollBarLook.TrackAppearance.BackGradientStyle = GradientStyle.None;
            e.Layout.ScrollBarLook.ThumbAppearance.BackColor = System.Drawing.Color.Gray;
            e.Layout.ScrollBarLook.ThumbAppearance.BackGradientStyle = GradientStyle.None;            
            e.Layout.ScrollBarLook.Appearance.BorderAlpha = Alpha.Transparent;
            e.Layout.ScrollBarLook.ButtonAppearance.BackColor = System.Drawing.Color.DarkGray;
            e.Layout.ScrollBarLook.ButtonAppearance.BackGradientStyle = GradientStyle.None;
            //-------------------------------------------------------------------------------------------------------------------------
            e.Layout.Override.MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
        }

        protected override void OnError(Infragistics.Win.UltraWinGrid.ErrorEventArgs e)
        {
            //base.OnError(e);
            //e.Cancel = true;
        }

        protected override void OnCellDataError(Infragistics.Win.UltraWinGrid.CellDataErrorEventArgs e)
        {
            //base.OnCellDataError(e);
            //e.RaiseErrorEvent = false;
            //e.StayInEditMode = false;
        }

        protected override void OnInitializeRow(Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {
            base.OnInitializeRow(e);
            e.Row.Cells[ColumnKey.RowID].Value = e.Row.Index + 1;
            
            e.Row.Cells[ColumnKey.RowID].Appearance.BackColor = System.Drawing.Color.Transparent;

            try
            {
                e.Row.Cells[ColumnKey.Update].Appearance.ImageBackground = System.Drawing.Image.FromFile(GeneralMethods.PictureFileNamePath("replaceWhite16.png"));
                e.Row.Cells[ColumnKey.Update].ButtonAppearance.ImageBackground = System.Drawing.Image.FromFile(GeneralMethods.PictureFileNamePath("replaceColore16.png"));

                e.Row.Cells[ColumnKey.Delete].Appearance.ImageBackground = System.Drawing.Image.FromFile(GeneralMethods.PictureFileNamePath("deleteWhite16.png"));
                e.Row.Cells[ColumnKey.Delete].ButtonAppearance.ImageBackground = System.Drawing.Image.FromFile(GeneralMethods.PictureFileNamePath("deleteColore16.png"));

                e.Row.Cells[ColumnKey.New].Appearance.ImageBackground = System.Drawing.Image.FromFile(GeneralMethods.PictureFileNamePath("replaceWhite16.png"));
                e.Row.Cells[ColumnKey.New].ButtonAppearance.ImageBackground = System.Drawing.Image.FromFile(GeneralMethods.PictureFileNamePath("replaceColore16.png"));

                e.Row.Cells[ColumnKey.Detail].Appearance.ImageBackground = System.Drawing.Image.FromFile(GeneralMethods.PictureFileNamePath("DetailWhite16.png"));
                e.Row.Cells[ColumnKey.Detail].ButtonAppearance.ImageBackground = System.Drawing.Image.FromFile(GeneralMethods.PictureFileNamePath("DetailColore16.png"));


                e.Row.Cells[ColumnKey.Update].ToolTipText = "تغییر";
                e.Row.Cells[ColumnKey.Delete].ToolTipText = "حذف";
                e.Row.Cells[ColumnKey.New].ToolTipText = "جدید";
                e.Row.Cells[ColumnKey.Detail].ToolTipText = "جزئیات";
            }
            catch { }
        }


        protected override void OnAfterCellUpdate(Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            base.OnAfterCellUpdate(e);

            if (e.Cell.Column.Key == "RowID")
                return;

            if (BaseUltraGrid.DisplayLayout.Override.CellClickAction != Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect)
                this.FreeSpaceGenerator();
        }

        protected override void OnAfterExitEditMode()
        {
            base.OnAfterExitEditMode();

            if (BaseUltraGrid.DisplayLayout.Override.CellClickAction != Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect)
                this.FreeSpaceGenerator();
        }

        protected override void OnSizeChanged(System.EventArgs e)
        {
            base.OnSizeChanged(e);
            this.FreeSpaceGenerator();
        }

        protected override void OnAfterRowInsert(Infragistics.Win.UltraWinGrid.RowEventArgs e)
        {
            base.OnAfterRowInsert(e);
            this.FreeSpaceGenerator();
        }

        public void FreeSpaceGenerator()
        {
            if (IsFreeSpaceGenerator == false)
                return;

            try
            {
                BaseUltraGrid.DisplayLayout.Bands[0].Columns["RowID"].Header.VisiblePosition = BaseUltraGrid.DisplayLayout.Bands[0].Columns.Count;
            }
            catch { }

            //BaseUltraGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;

            this.ActiveColScrollRegion.Position = this.ActiveColScrollRegion.Position + 31000;

            for (int i = 0; i < BaseUltraGrid.DisplayLayout.Bands.Count; i++)
            {
                for (int j = 0; j <= BaseUltraGrid.DisplayLayout.Bands[i].Columns.Count - 1; j++)
                {
                    if(BaseUltraGrid.DisplayLayout.Bands[i].Columns[j].Style != Infragistics.Win.UltraWinGrid.ColumnStyle.Image)
                        BaseUltraGrid.DisplayLayout.Bands[i].Columns[j].PerformAutoResize(Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
                }
            }





            for (int p = 0; p < BaseUltraGrid.DisplayLayout.Bands.Count; p++)
            {
                SumColumnsWidth = 0;
                for (int j = 0; j <= BaseUltraGrid.DisplayLayout.Bands[p].Columns.Count - 1; j++)
                {
                    if (BaseUltraGrid.DisplayLayout.Bands[p].Columns[j].Hidden == false)
                        SumColumnsWidth = SumColumnsWidth + BaseUltraGrid.DisplayLayout.Bands[p].Columns[j].Width;
                }

                int m = SumColumnsWidth;

                if (BaseUltraGrid.DisplayLayout.Bands[p].Columns.Count != 0)
                {
                    if (SumColumnsWidth < BaseUltraGrid.Width)
                    {
                        try
                        {
                            BaseUltraGrid.DisplayLayout.Bands[p].Columns.Add("FreeSpace", "");
                            BaseUltraGrid.DisplayLayout.Bands[p].Columns["FreeSpace"].Header.VisiblePosition = 0;
                            BaseUltraGrid.DisplayLayout.Bands[p].Columns["FreeSpace"].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
                        }
                        catch { }

                        BaseUltraGrid.DisplayLayout.Bands[p].Columns["FreeSpace"].Hidden = false;
                        BaseUltraGrid.DisplayLayout.Bands[p].Columns["FreeSpace"].Width = (BaseUltraGrid.Size.Width - SumColumnsWidth);
                    }
                }
            }

        }

    }
}
