using Baran.Classes.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Baran.Company
{
    public partial class frmCollectionList : Baran.Base_Forms.frmChildBase
    {
        #region Constractor

        public frmCollectionList()
        {
            InitializeComponent();
        }

        #endregion

        #region Propertise

        private int _CollectionID;
        public int CollectionID
        {
            get
            {
                return _CollectionID;
            }
            set
            {
                _CollectionID = value;
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
            ofrm.EnableToolBarItems(cnsToolStripButton.Cancel, cnsToolStripButton.Change, cnsToolStripButton.New, cnsToolStripButton.Delete, cnsToolStripButton.Refresh, cnsToolStripButton.Export);
            ofrm.EnableMenuStripItems(cnsMenustripItems.Cancel, cnsMenustripItems.Change, cnsMenustripItems.New, cnsMenustripItems.Delete, cnsMenustripItems.Refresh, cnsMenustripItems.Export);
        }

        public override void OnNew()
        {
            base.OnNew();

            Baran.Company.frmCollection ofrm = new frmCollection();

            ofrm.FormItemID = Convert.ToInt32(PublicEnum.EnmformItemId.Collection);
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

            if (CollectionID < 0)
            {
                OnMessage(BaranResources.NoRowSelectedError, PublicEnum.EnmMessageCategory.Warning);
                return;
            }
            Baran.Company.frmCollection ofrm = new frmCollection(dstCompany1, CollectionID);

            ofrm.FormItemID = Convert.ToInt32(PublicEnum.EnmformItemId.Collection);
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
            if (CollectionID <= 0)
            {
                OnMessage(BaranResources.NoRowSelectedError, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            if (CollectionID <= 0)
                return;

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;

            BaranDataAccess.Company.dstCompanyTableAdapters.spr_src_Collection_SelectTableAdapter adpCollection =
                new BaranDataAccess.Company.dstCompanyTableAdapters.spr_src_Collection_SelectTableAdapter();

            try
            {
                int RowAffected = (int)adpCollection.Delete(CollectionID, Convert.ToInt32(CurrentUser.Instance.UserID));
                if (RowAffected > 0)
                {
                    OnMessage(BaranResources.DeleteSuccessful, PublicEnum.EnmMessageCategory.Success);
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

        public override void OnRefresh()
        {
            base.OnRefresh();

            this.FillGrid();
        }

        private void FillGrid()
        {
            dstCompany1.spr_src_Collection_Select.Clear();
            dstCompany1.spr_src_Collection_Select.Merge(BaranDataAccess.Company.dstCompany.CollectionTable(CurrentUser.Instance.UserID).spr_src_Collection_Select);
        }

        public override void OnExport(Windows.Forms.UltraGrid grdItem)
        {
            base.OnExport(this.grdItem);
        }

        #endregion

        #region Events

        private void grdItem_AfterRowActivate(object sender, EventArgs e)
        {
            if ((grdItem.ActiveRow == null) || (grdItem.ActiveRow.Cells[dstCompany1.spr_src_Collection_Select.CollectionIDColumn.ColumnName].Value == DBNull.Value))
                return;
            CollectionID = (int)grdItem.ActiveRow.Cells[dstCompany1.spr_src_Collection_Select.CollectionIDColumn.ColumnName].Value;
        }

        private void grdItem_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            this.OnChange();
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
