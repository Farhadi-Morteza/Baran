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
    public partial class frmWaterTransmissionList : Baran.Base_Forms.frmChildBase
    {
        #region Constractor

        public frmWaterTransmissionList()
        {
            InitializeComponent();
        }


        #endregion

        #region Variables

        DialogResult msgResult;



        #endregion

        #region Propertise

        private int _WaterTransmissionLineID = 0;
        public int WaterTransmissionLineID
        {
            get
            {
                return _WaterTransmissionLineID;
            }
            set
            {
                _WaterTransmissionLineID = value;
            }
        }

        #endregion

        #region Methods

        public override void OnActiveForm()
        {
            base.OnActiveForm();

            frmMain ofrm = frmMain.Instanc;
            ofrm.EnableToolBarItems(cnsToolStripButton.Cancel, cnsToolStripButton.Change, cnsToolStripButton.Delete, cnsToolStripButton.Export, cnsToolStripButton.New, cnsToolStripButton.Detail);
            ofrm.EnableMenuStripItems(cnsMenustripItems.Cancel, cnsMenustripItems.Change, cnsMenustripItems.Delete, cnsMenustripItems.Export, cnsMenustripItems.New, cnsMenustripItems.Detail);
        }

        public override void OnformLoad()
        {
            base.OnformLoad();
            this.FillGrid();
        }

        public override void OnNew()
        {
            base.OnNew();
            Baran.Source.frmWaterTransmission ofrm =
                new frmWaterTransmission();

            ofrm.FormItemID = Convert.ToInt32(PublicEnum.EnmformItemId.WaterTransmissionLine);
            if (PublicMethods.SetFormSchema(ofrm, ofrm.FormItemID))
            {
                ofrm.FormType = cnsFormType.New;
                ofrm.ShowDialog();
                this.FillGrid();

            }
        }

        public override void OnChange()
        {
            base.OnChange();
            if (grdItem.Selected.Rows.Count == 0)
            {
                OnMessage(BaranResources.NoRowSelectedError, PublicEnum.EnmMessageCategory.Warning);
                return;
            }
            Baran.Source.frmWaterTransmission ofrm =
                new frmWaterTransmission(WaterTransmissionLineID);

            ofrm.FormItemID = Convert.ToInt32(PublicEnum.EnmformItemId.WaterTransmissionLine);
            if (PublicMethods.SetFormSchema(ofrm, ofrm.FormItemID))
            {
                ofrm.FormType = cnsFormType.Change;
                ofrm.ShowDialog();
                this.FillGrid();
            }

        }

        public override void OnDelete()
        {
            base.OnDelete();
            if (grdItem.Selected.Rows.Count == 0)
            {
                OnMessage(BaranResources.NoRowSelectedError, PublicEnum.EnmMessageCategory.Warning);
                return;
            }
            if (WaterTransmissionLineID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;

            BaranDataAccess.Source.dstSourceTableAdapters.spr_src_WaterTransmissionLine_SelectTableAdapter adp
                = new BaranDataAccess.Source.dstSourceTableAdapters.spr_src_WaterTransmissionLine_SelectTableAdapter();
            try
            {
                int RowAffected = Convert.ToInt32(adp.Delete(WaterTransmissionLineID, Convert.ToInt32(CurrentUser.Instance.UserID)));
                if (RowAffected > 0)
                {
                    OnMessage(BaranResources.DeleteSuccessful, PublicEnum.EnmMessageCategory.Success);
                    WaterTransmissionLineID = 0;
                    this.FillGrid();
                }
                else
                    OnMessage(BaranResources.DeleteFail, PublicEnum.EnmMessageCategory.Warning);
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
        }

        public override void OnExport(Windows.Forms.UltraGrid grdItem)
        {
            base.OnExport(this.grdItem);
        }

        public override void OnDetail()
        {
            base.OnDetail();
            this.Detail();
        }

        private void FillGrid()
        {
            //BaranDataAccess.Source.dstSource dst = new BaranDataAccess.Source.dstSource();
            //dst = BaranDataAccess.Source.dstSource.WaterTransmissionLineListTable(CurrentUser.Instance.UserID);
            //grdItem.DataSource = dst;
            //grdItem.DataMember = dst.spr_src_WaterTransmissionLine_Lst_Select.ToString();

            dstSource1.spr_src_WaterTransmissionLine_Lst_Select.Clear();
            dstSource1.spr_src_WaterTransmissionLine_Lst_Select.Merge(BaranDataAccess.Source.dstSource.WaterTransmissionLineListTable(CurrentUser.Instance.UserID).spr_src_WaterTransmissionLine_Lst_Select);
        }

        private void Detail()
        {
            Baran.Source.frmWaterTransmissionView ofrm = new frmWaterTransmissionView(WaterTransmissionLineID);
            ofrm.ShowDialog();
        }

        #endregion

        #region Events

        private void grdItem_AfterRowActivate(object sender, EventArgs e)
        {
            if (grdItem.ActiveRow == null || (grdItem.ActiveRow.Cells[dstSource1.spr_src_WaterTransmissionLine_Lst_Select.WaterTransmissionLineIDColumn.ColumnName].Value == DBNull.Value))
                return;

            WaterTransmissionLineID = Convert.ToInt32(grdItem.ActiveRow.Cells[dstSource1.spr_src_WaterTransmissionLine_Lst_Select.WaterTransmissionLineIDColumn.ColumnName].Value);

        }

        private void grdItem_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            this.Detail();
        }

        #endregion


    }
}
