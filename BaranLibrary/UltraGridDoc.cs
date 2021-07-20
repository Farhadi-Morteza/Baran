using BaranLibrary;
using Infragistics.Win;
using System.Windows.Forms;

namespace Baran.Windows.Forms

{
    [System.Drawing.ToolboxBitmap(typeof(Infragistics.Win.UltraWinGrid.UltraGrid))]
    public class UltraGridDoc : Infragistics.Win.UltraWinGrid.UltraGrid
    {
        BaranDataAccess.Common.dstCommon _dstCommon = new BaranDataAccess.Common.dstCommon();
        public BaranDataAccess.Common.dstCommon dstCommon
        {
            get
            {
                return _dstCommon;
            }
        }


        //private Infragistics.Win.UltraWinGrid.UltraGrid _BaseUltraGridDoc;
        //public Infragistics.Win.UltraWinGrid.UltraGrid BaseUltraGridDoc
        //{
        //    get
        //    {
        //        return _BaseUltraGridDoc;
        //    }
        //    set
        //    {
        //        _BaseUltraGridDoc = value;
        //    }
        //}

        public UltraGridDoc()
        {
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            Dock = System.Windows.Forms.DockStyle.Fill;            
            
            DataSource = dstCommon;
            DataMember = dstCommon.spr_cmn_DocumentByFkID_Select.ToString();
            //try
            //{
            //    Name = "grdDoc";
            //}
            //catch 
            //{

            //}

        }

        protected override void OnBeforeRowsDeleted(Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            base.OnBeforeRowsDeleted(e);
            e.DisplayPromptMsg = false;
        }

        protected override void OnInitializeLayout(Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            base.OnInitializeLayout(e);

            try
            {
                e.Layout.Bands[0].Columns.Add("Download", "");
                e.Layout.Bands[0].Columns.Add("Delete", "");
                e.Layout.Bands[0].Columns.Add("Update", "");                
                e.Layout.Bands[0].Columns.Add("RowID", "ردیف");

                e.Layout.Bands[0].Columns["Delete"].Width = 30;
                e.Layout.Bands[0].Columns["Update"].Width = 30;
                e.Layout.Bands[0].Columns["RowID"].Width = 30;
                e.Layout.Bands[0].Columns["Download"].Width = 30;
                e.Layout.Bands[0].Columns[dstCommon.spr_cmn_DocumentByFkID_Select.DocumentColumn.ColumnName].Width = 156;
                e.Layout.Bands[0].Columns[dstCommon.spr_cmn_DocumentByFkID_Select.NameColumn.ColumnName].Width = 164;
                e.Layout.Bands[0].Columns[dstCommon.spr_cmn_DocumentByFkID_Select.DescriptionColumn.ColumnName].Width = 500;

            }
            catch{}

            try
            {
                e.Layout.Bands[0].Columns[dstCommon.spr_cmn_DocumentByFkID_Select.DescriptionColumn.ColumnName].Header.VisiblePosition = 1;
                e.Layout.Bands[0].Columns[dstCommon.spr_cmn_DocumentByFkID_Select.NameColumn.ColumnName].Header.VisiblePosition = 2;
                e.Layout.Bands[0].Columns[dstCommon.spr_cmn_DocumentByFkID_Select.DocumentColumn.ColumnName].Header.VisiblePosition = 3;
                e.Layout.Bands[0].Columns["Download"].Header.VisiblePosition = 4;
                e.Layout.Bands[0].Columns["Delete"].Header.VisiblePosition = 5;
                e.Layout.Bands[0].Columns["Update"].Header.VisiblePosition = 6;
                e.Layout.Bands[0].Columns["RowID"].Header.VisiblePosition = 7;
            }
            catch 
            {
             
            }

            try
            {
                e.Layout.Bands[0].Columns["Delete"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
                e.Layout.Bands[0].Columns["Update"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
                e.Layout.Bands[0].Columns["Download"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
                


                //e.Layout.Bands[0].Columns["Update"].CellButtonAppearance.Image =System.Drawing.Image.FromFile("");

                //e.Layout.Bands[0].Columns["Delete"].CellAppearance.Image = System.Drawing.Image.FromFile("E:\AMS\BaranLibrary\Resources\Delete16Old.png");
                //e.Layout.Bands[0].Columns["Delete"].CellButtonAppearance.Image = System.Drawing.Image.FromFile("E:\AMS\BaranLibrary\Resources\Delete16Old.png");  
                this.ActiveColScrollRegion.Position = this.ActiveColScrollRegion.Position + 31000; // this.Size.Width;

                e.Layout.Bands[0].Columns["RowID"].TabStop = false;

                //e.Layout.Bands[0].Columns["Delete"].CellAppearance.Image = System.Drawing.Image.FromFile(BaranLibrary.GeneralMethods.PictureFileNamePath("Delete16Old.png"));
                //e.Layout.Bands[0].Columns["Delete"].CellButtonAppearance.Image = System.Drawing.Image.FromFile(BaranLibrary.GeneralMethods.PictureFileNamePath("Delete16Old.png"));
                e.Layout.Appearance.TextHAlign = HAlign.Right;
                e.Layout.Appearance.TextVAlign = VAlign.Middle;

                e.Layout.Override.HeaderAppearance.TextHAlign = HAlign.Center;
                e.Layout.Override.HeaderAppearance.TextVAlign = VAlign.Middle;
                e.Layout.Override.MinRowHeight = 80;
                e.Layout.Override.RowSpacingAfter = 5;
                e.Layout.Override.RowSpacingBefore = 5;

                //// This will apply to the row that's under the mouse.
                e.Layout.Override.HotTrackRowAppearance.ForeColor = System.Drawing.Color.Yellow;//.DarkViolet;
                //e.Layout.Override.HotTrackRowAppearance.FontData.Bold = DefaultableBoolean.True;

                e.Layout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
                e.Layout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

                e.Layout.Override.DefaultRowHeight = 25;
                e.Layout.Appearance.BackColor = System.Drawing.Color.Transparent;//.SystemColors.Control;
                e.Layout.Appearance.ForeColor = BaranLibrary.GeneralProperties.BaseControlForeColor;
                e.Layout.Override.RowAppearance.BackColor = System.Drawing.Color.Transparent;

                e.Layout.Override.CellAppearance.BorderColor = System.Drawing.Color.Gray;

                e.Layout.Override.ActiveRowAppearance.BackColor = System.Drawing.Color.Gray;
                e.Layout.Override.ActiveRowAppearance.BackColor2 = System.Drawing.Color.Gray;
                e.Layout.Override.ActiveRowAppearance.ForeColor = System.Drawing.Color.White;
                e.Layout.Override.ActiveRowAppearance.BackGradientStyle = GradientStyle.Vertical;

                e.Layout.Bands[0].ColHeadersVisible = false;
                e.Layout.BorderStyle = UIElementBorderStyle.None;
                e.Layout.Override.BorderStyleCell = UIElementBorderStyle.None;
                e.Layout.Override.BorderStyleRow = UIElementBorderStyle.Solid;

                e.Layout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
                e.Layout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.Horizontal;

                e.Layout.Bands[0].Columns[dstCommon.spr_cmn_DocumentByFkID_Select.DescriptionColumn.ColumnName].CellMultiLine = DefaultableBoolean.True;
                //e.Layout.Bands[0].Override.
                e.Layout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Show;
                
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

        protected override void OnInitializeRow(Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {
            base.OnInitializeRow(e);
            e.Row.Cells["RowID"].Value = e.Row.Index + 1;
            e.Row.Cells["RowID"].Appearance.BackColor = System.Drawing.Color.Silver;


            e.Row.Cells["Update"].Appearance.ImageBackground = System.Drawing.Image.FromFile(GeneralMethods.PictureFileNamePath("replaceColore16.png"));
            e.Row.Cells["Update"].ButtonAppearance.ImageBackground = System.Drawing.Image.FromFile(GeneralMethods.PictureFileNamePath("replaceColore16.png"));

            e.Row.Cells["Delete"].Appearance.ImageBackground = System.Drawing.Image.FromFile(GeneralMethods.PictureFileNamePath("DeleteColore16.png"));
            e.Row.Cells["Delete"].ButtonAppearance.ImageBackground = System.Drawing.Image.FromFile(GeneralMethods.PictureFileNamePath("DeleteColore16.png"));

            e.Row.Cells["Download"].Appearance.ImageBackground = System.Drawing.Image.FromFile(GeneralMethods.PictureFileNamePath("DownloadsColore16.png"));
            e.Row.Cells["Download"].ButtonAppearance.ImageBackground = System.Drawing.Image.FromFile(GeneralMethods.PictureFileNamePath("DownloadsColore16.png"));

            e.Row.Cells[dstCommon.spr_cmn_DocumentByFkID_Select.DocumentColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Image;
            e.Row.Cells[dstCommon.spr_cmn_DocumentByFkID_Select.DocumentIDColumn.ColumnName].Hidden = true;

            e.Row.Cells["Update"].ToolTipText = "تغییر";
            e.Row.Cells["Delete"].ToolTipText = "حذف";
            e.Row.Cells["Download"].ToolTipText = "دانلود";

        }

        protected override void OnClickCellButton(Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            base.OnClickCellButton(e);

            if (e.Cell.Column.Key == "Delete")
            {
                BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_Document_SelectTableAdapter adp =
                    new BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_Document_SelectTableAdapter();

                try
                {
                    DialogResult msgResult = MessageBox.Show("آیا از حذف سند اطمینان دارید", "Delete Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (msgResult == DialogResult.No) return;

                    int RowAffected = (int)adp.Delete((int)e.Cell.Row.Cells["DocumentID"].Value, BaranLibrary.CurrentUser.CurrentUserInfo.UserIDColumn.ColumnName[0]);

                    if (RowAffected > 0)
                    {
                        e.Cell.Row.Delete();
                        
                        //OnMessage(BaranResources.DeleteSuccessful, PublicEnum.EnmMessageCategory.Success);
                    }
                    else
                        MessageBox.Show("خطا در حذف سند", "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }
                catch
                {
                    //OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
                }

            }
            else if (e.Cell.Column.Key == "Download")
            {
                System.Drawing.Image img;

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|png Image|*.png";
                saveFileDialog1.Title = "Save an Image File";
                //saveFileDialog1.CheckFileExists = true;
                //saveFileDialog1.CheckPathExists = true; 
                saveFileDialog1.ShowDialog();


                System.Byte[] bb = (System.Byte[])e.Cell.Row.Cells["Document"].Value;
                
                System.IO.MemoryStream ms = new System.IO.MemoryStream(bb);
                img = System.Drawing.Image.FromStream(ms);

                if (saveFileDialog1.FileName != "")
                {
                    System.IO.FileStream fs =
                        (System.IO.FileStream)saveFileDialog1.OpenFile();

                    switch (saveFileDialog1.FilterIndex)
                    {
                        case 1:
                            img.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;

                        case 2:
                            img.Save(fs,System.Drawing.Imaging.ImageFormat.Bmp);
                            break;

                        case 3:
                            img.Save(fs,
                              System.Drawing.Imaging.ImageFormat.Gif);
                            break;
                        case 4:
                            img.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                            break;
                    }

                    fs.Close();
                    MessageBox.Show("سند با موفقیت ذخیره شد", "Save Document", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

    }
}