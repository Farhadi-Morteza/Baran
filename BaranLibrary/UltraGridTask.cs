using BaranLibrary;
using Infragistics.Win;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baran.Windows.Forms
{
    [System.Drawing.ToolboxBitmap(typeof(Infragistics.Win.UltraWinGrid.UltraGrid))]
    public class UltraGridTask : Infragistics.Win.UltraWinGrid.UltraGrid
    {
        public UltraGridTask()
        {
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            //Dock = System.Windows.Forms.DockStyle.Fill;       
            //this.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None;

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

        protected override void OnBeforeRowsDeleted(Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            base.OnBeforeRowsDeleted(e);
            e.DisplayPromptMsg = false;
        }

        protected override void OnInitializeLayout(Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            base.OnInitializeLayout(e);
            this.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;  
           

            try
            {
                e.Layout.Bands[0].Columns.Add("Delete", "");
                e.Layout.Bands[0].Columns.Add("Update", "");

                e.Layout.Bands[0].Columns["Delete"].Width = 32;
                e.Layout.Bands[0].Columns["Update"].Width = 32;

                
            }
            catch { }

            //try
            //{
            //    e.Layout.Bands[0].Columns["Delete"].Header.VisiblePosition = 5;
            //    e.Layout.Bands[0].Columns["Update"].Header.VisiblePosition = 6;
            //}
            //catch
            //{

            //}

            try
            {
                e.Layout.Bands[0].Columns["Delete"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
                e.Layout.Bands[0].Columns["Update"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;

                this.ActiveColScrollRegion.Position = this.ActiveColScrollRegion.Position + 31000; // this.Size.Width;


                //e.Layout.Bands[0].Columns["Delete"].CellAppearance.Image = System.Drawing.Image.FromFile(BaranLibrary.GeneralMethods.PictureFileNamePath("Delete16Old.png"));
                //e.Layout.Bands[0].Columns["Delete"].CellButtonAppearance.Image = System.Drawing.Image.FromFile(BaranLibrary.GeneralMethods.PictureFileNamePath("Delete16Old.png"));

                //e.Layout.Override.MinRowHeight = 80;
                //e.Layout.Override.RowSpacingAfter = 5;
                //e.Layout.Override.RowSpacingBefore = 5;

                //// This will apply to the row that's under the mouse.
                e.Layout.Override.HotTrackRowAppearance.ForeColor = System.Drawing.Color.GreenYellow;//.DarkViolet;
                //e.Layout.Override.HotTrackRowAppearance.FontData.Bold = DefaultableBoolean.True;

                e.Layout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
                e.Layout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

                //e.Layout.Override.DefaultRowHeight = 25;
                e.Layout.Appearance.BackColor = System.Drawing.Color.Transparent;//.SystemColors.Control;
                e.Layout.Appearance.ForeColor = BaranLibrary.GeneralProperties.BaseControlForeColor;
                e.Layout.Override.RowAppearance.BackColor = System.Drawing.Color.Transparent;

                e.Layout.Override.CellAppearance.BorderColor = System.Drawing.Color.Gray;

                e.Layout.Override.ActiveRowAppearance.BackColor = System.Drawing.Color.Gray;
                e.Layout.Override.ActiveRowAppearance.BackColor2 = System.Drawing.Color.Gray;
                e.Layout.Override.ActiveRowAppearance.ForeColor = System.Drawing.Color.White;
                e.Layout.Override.ActiveRowAppearance.BackGradientStyle = GradientStyle.Vertical;

                //e.Layout.Bands[0].ColHeadersVisible = false;
                e.Layout.BorderStyle = UIElementBorderStyle.None;
                e.Layout.Override.BorderStyleCell = UIElementBorderStyle.None;
                e.Layout.Override.BorderStyleRow = UIElementBorderStyle.Solid;
                

                e.Layout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
                //e.Layout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.Horizontal;

                e.Layout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Show;

                //Header------------------------------------------------------------------------------------------------------------------
                e.Layout.Override.HeaderStyle = HeaderStyle.WindowsVista;
                e.Layout.Override.BorderStyleHeader = UIElementBorderStyle.None;
                e.Layout.Override.HeaderAppearance.TextHAlign = HAlign.Center;
                e.Layout.Override.HeaderAppearance.TextVAlign = VAlign.Middle;
                e.Layout.Override.HeaderAppearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(188)))), ((int)(((byte)(66)))));// BaranLibrary.GeneralProperties.BaseColor2;
                e.Layout.Override.HeaderAppearance.BackColor = System.Drawing.Color.Transparent;
                e.Layout.Override.HeaderAppearance.BackColor2 = System.Drawing.Color.Transparent;
                e.Layout.Override.HeaderAppearance.BorderColor = System.Drawing.Color.Transparent;
                e.Layout.Override.HeaderAppearance.BackColorAlpha = Alpha.Transparent;
                e.Layout.Override.HeaderAppearance.BackGradientStyle = GradientStyle.None;
                e.Layout.Override.HeaderAppearance.FontData.Name = "B Nazanin";
                e.Layout.Override.HeaderAppearance.FontData.Bold = DefaultableBoolean.True;
                e.Layout.Override.HeaderAppearance.FontData.SizeInPoints = 9F;

                e.Layout.Appearance.TextHAlign = HAlign.Center;
                e.Layout.Appearance.TextVAlign = VAlign.Middle;

                //e.Layout.Override.RowSpacingAfter = 3;
                //e.Layout.Override.RowSpacingBefore = 3;
            }
            catch
            { }
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

        protected override void OnAfterCellUpdate(Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            base.OnAfterCellUpdate(e);

            //if (BaseUltraGrid.DisplayLayout.Override.CellClickAction != Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect)
            //    this.FreeSpaceGenerator();
        }

        protected override void OnSizeChanged(System.EventArgs e)
        {
            base.OnSizeChanged(e);
            //this.FreeSpaceGenerator();

            //string mm = this.Parent.Name;
            //int pp = this.Parent.Controls.Count;
            //foreach (System.Windows.Forms.Control control in this.Parent.Controls)
            //{
            //    string pppp = control.Name;
            //    ////this.Parent.Size = new System.Drawing.Size(248, 180);//(this.Parent.Size.Width, this.Parent.Size.Height + 10);
            //}
        }

        protected override void OnInitializeRow(Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {
            base.OnInitializeRow(e);

            

            e.Row.Cells["Update"].Appearance.ImageBackground = System.Drawing.Image.FromFile(GeneralMethods.PictureFileNamePath("replaceColore16.png"));
            e.Row.Cells["Update"].ButtonAppearance.ImageBackground = System.Drawing.Image.FromFile(GeneralMethods.PictureFileNamePath("replaceColore16.png"));

            e.Row.Cells["Delete"].Appearance.ImageBackground = System.Drawing.Image.FromFile(GeneralMethods.PictureFileNamePath("DeleteColore16.png"));
            e.Row.Cells["Delete"].ButtonAppearance.ImageBackground = System.Drawing.Image.FromFile(GeneralMethods.PictureFileNamePath("DeleteColore16.png"));

            e.Row.Cells["Update"].ToolTipText = "تغییر";
            e.Row.Cells["Delete"].ToolTipText = "حذف";

           

            //e.Row.ExpandAll();
            int RowHeight = e.Row.Height + e.Row.RowSpacingAfter + e.Row.RowSpacingBefore;

            this.DisplayLayout.Override.DefaultRowHeight = 30;
            this.Size = new System.Drawing.Size(this.Size.Width,
            this.DisplayLayout.Override.DefaultRowHeight * this.DisplayLayout.Rows.Count + this.DisplayLayout.Bands[0].Columns
            [0].Header.SizeResolved.Height + 10);       
            //this.Size = new System.Drawing.Size(this.Size.Width,
            //RowHeight * this.DisplayLayout.Rows.Count + this.DisplayLayout.Bands[0].Columns
            //[0].Header.SizeResolved.Height + 10); 


        }
    }
}
