using Infragistics.Win;
namespace Baran.Windows.Forms
{
    [System.Drawing.ToolboxBitmap(typeof(Infragistics.Win.UltraWinGrid.UltraGrid))]
    public class UltraGrid2 : Infragistics.Win.UltraWinGrid.UltraGrid
    {
        public UltraGrid2()
        {
            this.InputLanguage = InputLanguage.Farsi;

            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));

            Dock = System.Windows.Forms.DockStyle.Fill;
        }

        System.Globalization.CultureInfo _faCultureInfo = new System.Globalization.CultureInfo("fa-IR", false);
        System.Globalization.CultureInfo _enCultureInfo = new System.Globalization.CultureInfo("en-US", false);

        private Infragistics.Win.UltraWinGrid.UltraGrid _BaseUltraGrid2;
        public Infragistics.Win.UltraWinGrid.UltraGrid BaseUltraGrid2
        {
            get
            {
                return _BaseUltraGrid2;
            }
            set
            {
                _BaseUltraGrid2 = value;
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

                switch (_inputLanguage)
                {
                    case InputLanguage.Farsi:
                        {
                            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                            break;
                        }

                    case InputLanguage.English:
                        {
                            RightToLeft = System.Windows.Forms.RightToLeft.No;
                            break;
                        }
                }
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

            //try
            //{
            //    e.Layout.Bands[0].Columns.Add("RowID", "ردیف");
            //}
            //catch
            //{ }

            ////this.DisplayLayout.UseScrollWindow = Infragistics.Win.UltraWinGrid.UseScrollWindow.None;

            ////this.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            ////this.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;
            //this.ActiveColScrollRegion.Position = this.ActiveColScrollRegion.Position + 11000; // this.Size.Width;

            //e.Layout.Bands[0].Columns["RowID"].Width = 35;
            //e.Layout.Bands[0].Columns["RowID"].CellAppearance.BackColor = System.Drawing.Color.FromArgb(BaranLibrary.GeneralProperties.HeaderColor1);
            //e.Layout.Bands[0].Columns["RowID"].TabStop = false;
            //e.Layout.Bands[0].Columns["RowID"].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;

            //e.Layout.Bands[0].Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed;
            //e.Layout.Bands[0].Override.SummaryValueAppearance.ForeColor = System.Drawing.Color.Green;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));

            e.Layout.Appearance.TextHAlign = HAlign.Right;
            e.Layout.Appearance.TextVAlign = VAlign.Middle;

            e.Layout.Override.RowAlternateAppearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));

            e.Layout.Override.ActiveRowAppearance.BackColor = System.Drawing.Color.LightSkyBlue;
            e.Layout.Override.ActiveRowAppearance.BackColor2 = System.Drawing.Color.White;
            e.Layout.Override.ActiveRowAppearance.ForeColor = System.Drawing.Color.DarkBlue;
            e.Layout.Override.ActiveRowAppearance.BackGradientStyle = GradientStyle.Vertical;

            e.Layout.Override.HeaderAppearance.TextHAlign = HAlign.Center;
            e.Layout.Override.HeaderAppearance.TextVAlign = VAlign.Middle;

            e.Layout.BorderStyle = UIElementBorderStyle.Rounded3;
            e.Layout.CaptionVisible = DefaultableBoolean.True;
            e.Layout.CaptionAppearance.ForeColor = System.Drawing.Color.DarkBlue;

            e.Layout.Appearance.TextHAlign = HAlign.Right;
            e.Layout.Appearance.TextVAlign = VAlign.Middle;

            // This will apply to the row that's under the mouse.
            //e.Layout.Override.HotTrackRowAppearance.ForeColor = System.Drawing.Color.FromArgb(BaranLibrary.GeneralProperties.HeaderColor1);
            e.Layout.Override.HotTrackRowAppearance.ForeColor = System.Drawing.Color.DarkViolet;
            //e.Layout.Override.HotTrackRowAppearance.FontData.Bold = DefaultableBoolean.True;

            //e.Layout.Override.ActiveCellAppearance.BackColor = System.Drawing.Color.FromArgb(BaranLibrary.GeneralProperties.HeaderColor1);

            //e.Layout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            //e.Layout.Override.HeaderStyle = HeaderStyle.Default;
            //e.Layout.Override.HeaderAppearance.BackColor = System.Drawing.Color.FromArgb(BaranLibrary.GeneralProperties.HeaderColor1);
            //e.Layout.Override.HeaderAppearance.BackColor2 = System.Drawing.Color.FromArgb(BaranLibrary.GeneralProperties.HeaderColor2);
            //e.Layout.Override.HeaderAppearance.BackGradientStyle = GradientStyle.Vertical;

            //e.Layout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            //e.Layout.Override.FilterOperatorDropDownItems = Infragistics.Win.UltraWinGrid.FilterOperatorDropDownItems.StartsWith;
            //e.Layout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.StartsWith;
            //e.Layout.Override.FilterRowPrompt = "برای فیلتر اینجا را کلیک کنید";

            e.Layout.Override.DefaultRowHeight = 25;
            e.Layout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
            //e.Layout.Override.SummaryValueAppearance.BackColor = System.Drawing.Color.LightSkyBlue;
            e.Layout.Override.SummaryValueAppearance.ForeColor = System.Drawing.Color.Blue;

            e.Layout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            e.Layout.RowConnectorColor = System.Drawing.Color.DarkRed;
            e.Layout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
        }

        protected override void OnError(Infragistics.Win.UltraWinGrid.ErrorEventArgs e)
        {
            base.OnError(e);
            e.Cancel = true;
        }

        protected override void OnCellDataError(Infragistics.Win.UltraWinGrid.CellDataErrorEventArgs e)
        {
            base.OnCellDataError(e);
            e.RaiseErrorEvent = false;
            e.StayInEditMode = false;
        }       

        protected override void OnInitializeRow(Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {
            for (int i = 0; i <= e.Row.Cells.Count - 1; i++)
            {
                System.Type tt = e.Row.Cells[i].Column.DataType;
                if (tt.FullName == "System.Int64")
                {
                    e.Row.Cells[i].Column.MaskInput = "-n,nnn,nnn,nnn,nnn,nnn,nnn";
                    e.Row.Cells[i].Column.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
                    e.Row.Cells[i].Column.MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
                    e.Row.Cells[i].Column.PromptChar = '\0';
                }

                if (tt.FullName == "System.Int32")
                {
                    e.Row.Cells[i].Column.MaskInput = "-n,nnn,nnn,nnn";
                    e.Row.Cells[i].Column.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
                    e.Row.Cells[i].Column.MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
                    e.Row.Cells[i].Column.PromptChar = '\0';
                }

                if(tt.FullName == "System.Int16")
                {
                    e.Row.Cells[i].Column.MaskInput = "-n,nnn,nnn";
                    e.Row.Cells[i].Column.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
                    e.Row.Cells[i].Column.MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
                    e.Row.Cells[i].Column.PromptChar = '\0';
                }

                if (tt.FullName == "System.Decimal")
                {
                    e.Row.Cells[i].Column.MaskInput = "-n,nnn,nnn,nnn,nnn,nnn,nnn";
                    e.Row.Cells[i].Column.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth;
                    e.Row.Cells[i].Column.MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals;
                    e.Row.Cells[i].Column.PromptChar = '\0';
                }
            }
            //base.OnInitializeRow(e);
            //e.Row.Cells["RowID"].Value = e.Row.Index + 1;
            //e.Row.Cells["RowID"].Appearance.BackColor = System.Drawing.Color.Silver;
        }

        protected override void OnAfterCellUpdate(Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            base.OnAfterCellUpdate(e);

            if (BaseUltraGrid2.DisplayLayout.Override.CellClickAction == Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect)
                this.FreeSpaceGenerator();
        }

        protected override void OnSizeChanged(System.EventArgs e)
        {
            base.OnSizeChanged(e);


            if (BaseUltraGrid2.DisplayLayout.Override.CellClickAction == Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect)
                this.FreeSpaceGenerator();
        }

        protected override void OnBindingContextChanged(System.EventArgs e)
        {
            base.OnBindingContextChanged(e);

            if (BaseUltraGrid2.DisplayLayout.Override.CellClickAction == Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect)
                this.FreeSpaceGenerator();
        }

        private void FreeSpaceGenerator()
        {
            for (int i = 0; i < BaseUltraGrid2.DisplayLayout.Bands.Count; i++)
            {
                for (int j = 0; j <= BaseUltraGrid2.DisplayLayout.Bands[i].Columns.Count - 1; j++)
                {
                    BaseUltraGrid2.DisplayLayout.Bands[i].Columns[j].PerformAutoResize(Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand);
                }
            }



            for (int i = 0; i < BaseUltraGrid2.DisplayLayout.Bands.Count; i++)
            {
                SumColumnsWidth = 0;
                for (int j = 0; j <= BaseUltraGrid2.DisplayLayout.Bands[i].Columns.Count - 1; j++)
                {
                    if (BaseUltraGrid2.DisplayLayout.Bands[i].Columns[j].Hidden == false)
                        SumColumnsWidth = SumColumnsWidth + BaseUltraGrid2.DisplayLayout.Bands[i].Columns[j].Width;
                }

                int m = SumColumnsWidth;

                if (BaseUltraGrid2.DisplayLayout.Bands[i].Columns.Count != 0)
                {
                    if (SumColumnsWidth < BaseUltraGrid2.Width)
                    {
                        try
                        {
                            BaseUltraGrid2.DisplayLayout.Bands[i].Columns.Add("FreeSpace", "");
                        }
                        catch { }

                        BaseUltraGrid2.DisplayLayout.Bands[i].Columns["FreeSpace"].Hidden = false;
                        //BaseUltraGrid2.DisplayLayout.Bands[i].Columns["FreeSpace"].Width = (BaseUltraGrid2.Size.Width - SumColumnsWidth);


                        //BaseUltraGrid.DisplayLayout.Bands[0].Columns["FreeSpace"].Hidden = false;
                        //BaseUltraGrid.DisplayLayout.Bands[0].Columns["FreeSpace"].Width = (BaseUltraGrid.Size.Width - SumColumnsWidth);
                    }
                }
            }
        }



    }
}
