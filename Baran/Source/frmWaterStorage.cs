using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Baran.Classes.Common;

namespace Baran.Source
{
    public partial class frmWaterStorage : Baran.Base_Forms.frmSecondChildBase
    {
        #region Constractor

        public frmWaterStorage()
        {
            InitializeComponent();
              

            this.WaterStorageID = 0;
        }

        public frmWaterStorage(int WaterStorageID)
        {
            InitializeComponent();
              

            this.WaterStorageID = WaterStorageID;
            cmbParentCo.Editable = Windows.Forms.Editable.Immutable;
        }

        #endregion

        #region Variables
        WaiteForm waite;
        
        BaranDataAccess.Source.dstSourceTableAdapters.spr_src_WaterStorage_SelectTableAdapter adp
            = new BaranDataAccess.Source.dstSourceTableAdapters.spr_src_WaterStorage_SelectTableAdapter();
        BaranDataAccess.Source.dstSource.spr_src_WaterStorage_SelectRow drw;

        BaranDataAccess.Source.dstSourceTableAdapters.spr_src_WaterStorageD_SelectTableAdapter adPD
            = new BaranDataAccess.Source.dstSourceTableAdapters.spr_src_WaterStorageD_SelectTableAdapter();

        DialogResult msgResult;

        int intParentID;
        int UserID = (int)CurrentUser.Instance.UserID;

        string
            strName
            , strDescription;

        decimal
            dclVolume
            , dclArea
            , dclOutput
            ;

        #endregion

        #region Propertise

        private int _WaterStorageID = -1;
        public int WaterStorageID
        {
            get
            {
                return _WaterStorageID;
            }
            set
            {
                _WaterStorageID = value;
            }
        }

        #endregion

        #region Methods

        public override void OnformLoad()
        {
            base.OnformLoad();
            Baran.Classes.Common.ComboBoxSetting.FillComboBox(Classes.Common.PublicEnum.EnmComboSource.srcPart, cmbParentCo, "");
            btnGeo.Image = btnPrint.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Map64));
            this.SetControlsValue();
            this.FillGridDoc();

        }

        public override void OnSave()
        {
            base.OnSave();

            //if (WaterStorageID > 0)
            //{
            //    OnMessage(BaranResources.SavedLastTime, PublicEnum.EnmMessageCategory.Warning);
            //    return;
            //}
            if (!this.ControlsValidation())
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgSaveConfirm);
            if (msgResult == DialogResult.No) return;

            waite = new WaiteForm();
            try
            {
                waite.Show();
                this.SetVariables();

                WaterStorageID = Convert.ToInt32(adp.New_WaterStorage_Insert(strName, dclVolume, dclArea, dclOutput, UserID, strDescription, intParentID));

                if (WaterStorageID > 0)
                {
                    for (int i = 0; i <= dstSource1.spr_src_WaterStorageD_Select.Count - 1; i++)
                    {
                        dstSource1.spr_src_WaterStorageD_Select.Rows[i][dstSource1.spr_src_WaterStorageD_Select.Fk_WaterStorageIDColumn.ColumnName] = WaterStorageID;
                    }
                    adPD.Update(dstSource1.spr_src_WaterStorageD_Select);
                    OnMessage(BaranResources.SaveSuccessful, PublicEnum.EnmMessageCategory.Success);
                }
                else
                    OnMessage(BaranResources.SaveFail, PublicEnum.EnmMessageCategory.Warning);
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
            waite.Close();
        }

        public override void OnChange()
        {
            base.OnChange();

            if (WaterStorageID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            if (!this.ControlsValidation())
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgEditConfirm);
            if (msgResult == DialogResult.No) return;

            waite = new WaiteForm();
            try
            {
                waite.Show();
                this.SetVariables();
                int RowAffected = Convert.ToInt32(adp.Update(WaterStorageID, strName, dclVolume, dclArea, dclOutput, UserID, strDescription, intParentID));

                if (RowAffected > 0)
                {
                    for (int i = 0; i <= dstSource1.spr_src_WaterStorageD_Select.Count - 1; i++)
                    {
                        try
                        {
                            dstSource1.spr_src_WaterStorageD_Select.Rows[i][dstSource1.spr_src_WaterStorageD_Select.Fk_WaterStorageIDColumn.ColumnName] = WaterStorageID;
                        }
                        catch { }
                    }
                    adPD.Update(dstSource1.spr_src_WaterStorageD_Select);
                    OnMessage(BaranResources.EditSuccessful, PublicEnum.EnmMessageCategory.Success);

                }
                else
                    OnMessage(BaranResources.EditFail, PublicEnum.EnmMessageCategory.Warning);
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
            waite.Close();
        }

        public override void OnDelete()
        {
            base.OnDelete();

            if (grdItem.ActiveRow == null)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;
            try
            {
                int WaterStorageDID = Convert.ToInt32(grdItem.ActiveRow.Cells[dstSource1.spr_src_WaterStorageD_Select.WaterStorageDIDColumn.ColumnName].Value);
                int RowAffected = Convert.ToInt32(adPD.Delete(WaterStorageDID));
                if (RowAffected > 0)
                {

                    OnMessage(BaranResources.DeleteSuccessful, PublicEnum.EnmMessageCategory.Success);
                    grdItem.ActiveRow.Delete();
                }
                else
                    OnMessage(BaranResources.DeleteFail, PublicEnum.EnmMessageCategory.Warning);
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        public override void OnDoc(int? companyID, int? collectionID, int? subcollectionID, int? partID, int? landID, int? fieldID, int? warehouseID, int? buildingID, int? machineryID, int? waterID, int? waterStorageID, int? waterTransmissionLineID)
        {
            if (WaterStorageID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }
            base.OnDoc(null, null, null, null, null, null, null, null, null, null, this.WaterStorageID, null);
            this.FillGridDoc();
        }

        private void SetControlsValue()
        {
            if (WaterStorageID > 0)
            {
                drw = BaranDataAccess.Source.dstSource.WaterStorageByIDTable(WaterStorageID).spr_src_WaterStorage_Select[0];

                txtName.Text = drw.IsNameNull() ? string.Empty : drw.Name;
                txtArea.Text = drw.IsAreaNull() ? string.Empty : drw.Area.ToString();
                txtVolume.Text = drw.IsVolumeNull() ? string.Empty : drw.Volume.ToString();
                txtOutput.Text = drw.IsOutputNull() ? string.Empty : drw.Output.ToString();
                txtDescription.Text = drw.IsDescriptionNull() ? string.Empty : drw.Description;

                if (!drw.IsFk_PartIDNull())
                    cmbParentCo.Value = drw.Fk_PartID;

                dstSource1.spr_src_WaterStorageD_Select.Merge(BaranDataAccess.Source.dstSource.WaterStorageDTable(WaterStorageID).spr_src_WaterStorageD_Select);
            }

        }

        private void SetVariables()
        {
            strName = txtName.Text.Trim();
            strDescription = txtDescription.Text.Trim();

            if(txtArea.Text.Trim() != string.Empty)
                dclArea = Convert.ToDecimal(txtArea.Text.Trim());

            dclVolume = Convert.ToDecimal(txtVolume.Text.Trim());
            dclOutput = Convert.ToDecimal(txtOutput.Text.Trim());

            if (cmbParentCo.Value != null)
                intParentID = Convert.ToInt32(cmbParentCo.Value);
        }

        private bool ControlsValidation()
        {
            bool blnResult = true;

            if (cmbParentCo.Value == null)
            {
                cmbParentCo.Focus();
                blnResult = false;
            }
            else if (txtName.Text.Trim() == string.Empty)
            {
                txtName.Focus();
                blnResult = false;
            }
            else if (txtVolume.Text.Trim() == string.Empty)
            {
                txtVolume.Focus();
                blnResult = false;
            }
            else if (txtOutput.Text.Trim() == string.Empty)
            {
                txtOutput.Focus();
                blnResult = false;
            }

            return blnResult;
        }

        private void FillGridDoc()
        {
            this.Height = this.Height - grdDoc.Height;
            if (WaterStorageID > 0)
            {
                BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_DocumentByFkID_SelectTableAdapter adp =
                    new BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_DocumentByFkID_SelectTableAdapter();

                try
                {
                    adp.FillDocumentByFkIDTable(grdDoc.dstCommon.spr_cmn_DocumentByFkID_Select,null, null, null, null, null, null, null, null, null, null, this.WaterStorageID, null);

                    if (grdDoc.dstCommon.spr_cmn_DocumentByFkID_Select.Count > 0 && grdDoc.dstCommon.spr_cmn_DocumentByFkID_Select.Count <= 2)
                    {
                        this.Height = this.Height + 35 + (grdDoc.dstCommon.spr_cmn_DocumentByFkID_Select.Count * (grdDoc.DisplayLayout.Rows[0].Height));
                    }
                    else
                    {
                        this.Height = this.Height + 40 + (2 * (grdDoc.DisplayLayout.Rows[0].Height));
                    }
                }
                catch
                { }
            }
        }

        #endregion

        #region Events

        private void cmbParentCo_ValueChanged(object sender, EventArgs e)
        {
            int intPartID = Convert.ToInt32(cmbParentCo.Value);
            dstSource1.spr_src_WaterStorageD_Select.Clear();
            dstSource1.spr_src_Water_Select.Clear();
            dstSource1.spr_src_Water_Select.Merge(BaranDataAccess.Source.dstSource.WaterByPartIDTable(intPartID, CurrentUser.Instance.UserID).spr_src_Water_Select);
        }

        private void drpItem_RowSelected(object sender, Infragistics.Win.UltraWinGrid.RowSelectedEventArgs e)
        {
            if (e.Row == null)
                return;

            grdItem.ActiveRow.Cells[dstSource1.spr_src_WaterStorageD_Select.Fk_WaterIDColumn.ColumnName].Value
                = e.Row.Cells[dstSource1.spr_src_Water_Select.WaterIDColumn.ColumnName].Value;
        }

        private void btnGeo_Click(object sender, EventArgs e)
        {
            if (WaterStorageID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            Baran.Maps.frmBaseMap ofrm = new Maps.frmBaseMap(PublicEnum.EnmShapeType.Polygon);
            ofrm.WaterstorageID = WaterStorageID;
            ofrm.ShowDialog();
        }

        private void grdDoc_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (e.Cell.Column.Key == "Delete")
            {
                BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_Document_SelectTableAdapter adp =
                    new BaranDataAccess.Common.dstCommonTableAdapters.spr_cmn_Document_SelectTableAdapter();

                try
                {
                    msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
                    if (msgResult == DialogResult.No) return;

                    int RowAffected = (int)adp.Delete((int)e.Cell.Row.Cells[grdDoc.dstCommon.spr_cmn_DocumentByFkID_Select.DocumentIDColumn.ColumnName].Value, (int)CurrentUser.Instance.UserID);

                    if (RowAffected > 0)
                    {
                        e.Cell.Row.Delete();
                        OnMessage(BaranResources.DeleteSuccessful, PublicEnum.EnmMessageCategory.Success);
                    }
                    else
                        OnMessage(BaranResources.DeleteFail, PublicEnum.EnmMessageCategory.Warning);


                }
                catch
                {
                    OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
                }

            }
            else if (e.Cell.Column.Key == "Update")
            {
                try
                {
                    Baran.Common.frmDocument ofrm = new Common.frmDocument((int)e.Cell.Row.Cells[grdDoc.dstCommon.spr_cmn_Document_Select.DocumentIDColumn.ColumnName].Value);
                    ofrm.WaterStorageID = this.WaterStorageID;
                    ofrm.ShowDialog();

                    this.FillGridDoc();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else if (e.Cell.Column.Key == "Download")
            {
                System.Drawing.Image img;

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
                saveFileDialog1.Title = "Save an Image File";
                saveFileDialog1.ShowDialog();

                BaranDataAccess.Common.dstCommon.spr_cmn_DocumentByFkID_SelectRow rw;
                string strFilter = "DocumentID = " + (int)e.Cell.Row.Cells["DocumentID"].Value;
                rw = (BaranDataAccess.Common.dstCommon.spr_cmn_DocumentByFkID_SelectRow)grdDoc.dstCommon.spr_cmn_DocumentByFkID_Select.Select(strFilter)[0];

                img = PublicMethods.ArrayToImage(rw.Document);

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
                            img.Save(fs,
                              System.Drawing.Imaging.ImageFormat.Bmp);
                            break;

                        case 3:
                            img.Save(fs,
                              System.Drawing.Imaging.ImageFormat.Gif);
                            break;
                    }

                    fs.Close();
                    OnMessage(BaranResources.SaveSuccessful, PublicEnum.EnmMessageCategory.Success);
                }

            }
        }



        #endregion
    }
}
