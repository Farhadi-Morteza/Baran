using Baran.Classes.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Baran.Producte
{
    public partial class frmCultivarList : Baran.Base_Forms.frmChildBase
    {

        #region Constractor

        public frmCultivarList()
        {
            InitializeComponent();
        }

        #endregion

        #region Variables

        #endregion

        #region Propertise

        private int _cultivarID;
        public int CultivarID
        {
            get
            {
                return _cultivarID;
            }
            set
            {
                _cultivarID = value;
            }
        }

        #endregion

        #region Methods

        public override void OnformLoad()
        {
            base.OnformLoad();
            this.FillGrid();
        }

        public override void OnActiveForm()
        {
            base.OnActiveForm();

            frmMain ofrm = frmMain.Instanc;
            ofrm.EnableToolBarItems(cnsToolStripButton.Cancel, cnsToolStripButton.Change, cnsToolStripButton.New, cnsToolStripButton.Delete, cnsToolStripButton.Clear, cnsToolStripButton.Export, cnsToolStripButton.Refresh);
            ofrm.EnableMenuStripItems(cnsMenustripItems.Cancel, cnsMenustripItems.Change, cnsMenustripItems.New, cnsMenustripItems.Delete, cnsMenustripItems.Clear, cnsMenustripItems.Export, cnsMenustripItems.Refresh);
        }

        public override void OnNew()
        {
            base.OnNew();

            Baran.Producte.frmCultivar ofrm =
                new frmCultivar();

            //ofrm.FormItemID = Convert.ToInt32(PublicEnum.EnmformItemId.Crop);
            //if (PublicMethods.SetFormSchema(ofrm, ofrm.FormItemID))
            //{
                ofrm.FormType = cnsFormType.New;
                ofrm.ShowDialog();
                this.FillGrid();

            //}
        }

        public override void OnChange()
        {
            base.OnChange();

            if (CultivarID <= 0)
            {
                OnMessage(BaranResources.NoRowSelectedError, PublicEnum.EnmMessageCategory.Warning);
                return;
            }
            Baran.Producte.frmCultivar ofrm =
                new frmCultivar(CultivarID);

            //ofrm.FormItemID = Convert.ToInt32(PublicEnum.EnmformItemId.Field);
            //if (PublicMethods.SetFormSchema(ofrm, ofrm.FormItemID))
            //{
                ofrm.FormType = cnsFormType.Change;
                ofrm.ShowDialog();
                this.FillGrid();

            //}
        }

        public override void OnDelete()
        {
            base.OnDelete();

            if (CultivarID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;

            BaranDataAccess.Product.dstProductTableAdapters.spr_cmn_Cultivar_SelectTableAdapter adp =
                new BaranDataAccess.Product.dstProductTableAdapters.spr_cmn_Cultivar_SelectTableAdapter();

            try
            {
                int RowAffected = Convert.ToInt32(adp.Delete(CultivarID, CurrentUser.Instance.UserID));
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

        public override void OnRefresh()
        {
            base.OnRefresh();

            this.FillGrid();
        }

        private void FillGrid()
        {
            dstProduct1.spr_cmn_CultivarList_Select.Clear();
            BaranDataAccess.Product.dstProductTableAdapters.spr_cmn_CultivarList_SelectTableAdapter adp =
                new BaranDataAccess.Product.dstProductTableAdapters.spr_cmn_CultivarList_SelectTableAdapter();
            try
            {
                adp.FillCultivarListTable(dstProduct1.spr_cmn_CultivarList_Select);
            }
            catch
            {

            }
        }

        #endregion

        #region Events

        private void grdItem_AfterRowActivate(object sender, EventArgs e)
        {
            if ((grdItem.ActiveRow == null) || (grdItem.ActiveRow.Cells["CultivarID"].Value == DBNull.Value))
                return;
            CultivarID = (int)grdItem.ActiveRow.Cells["CultivarID"].Value;
        }

        #endregion

        private void grdItem_ClickCellButton(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            try
            {
                if (e.Cell.Column.Key == ColumnKey.Update)
                    OnChange();
                else if (e.Cell.Column.Key == ColumnKey.Delete)
                    OnDelete();
                else if (e.Cell.Column.Key == ColumnKey.New)
                    OnNew();
                else if (e.Cell.Column.Key == ColumnKey.Detail)
                    OnDetail();
            }
            catch { }
        }
    }
}
