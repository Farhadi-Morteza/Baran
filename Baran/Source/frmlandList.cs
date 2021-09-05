using Baran.Classes.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Baran.Source
{
    public partial class frmlandList : Baran.Base_Forms.frmChildBase
    {
        public frmlandList()
        {
            InitializeComponent();
        }

        #region Propertise

        private int _landID;
        public int LandID
        {
            get
            {
                return _landID;
            }
            set
            {
                _landID = value;
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
            ofrm.EnableToolBarItems(cnsToolStripButton.Cancel, cnsToolStripButton.Change, cnsToolStripButton.New, cnsToolStripButton.Delete, cnsToolStripButton.Refresh, cnsToolStripButton.Export, cnsToolStripButton.Detail);
            ofrm.EnableMenuStripItems(cnsMenustripItems.Cancel, cnsMenustripItems.Change, cnsMenustripItems.New, cnsMenustripItems.Delete, cnsMenustripItems.Refresh, cnsMenustripItems.Export, cnsMenustripItems.Detail);
        }

        public override void OnNew()
        {
            base.OnNew();

            Baran.Source.frmLand ofrm =
                new frmLand();

            ofrm.FormItemID = Convert.ToInt32(PublicEnum.EnmformItemId.Land);
            if (PublicMethods.SetFormSchema(ofrm, ofrm.FormItemID))
            {
                ofrm.FormType = cnsFormType.New;
                if (ofrm.ShowDialog() == DialogResult.OK)
                {
                    this.FillGrid();
                }
            }
        }

        public override void OnChange()
        {
            base.OnChange();
            if (LandID <= 0)
            {
                OnMessage(BaranResources.NoRowSelectedError, PublicEnum.EnmMessageCategory.Warning);
                return;
            }
            Baran.Source.frmLand ofrm =
                new frmLand(LandID);

            ofrm.FormItemID = Convert.ToInt32(PublicEnum.EnmformItemId.Land);
            if (PublicMethods.SetFormSchema(ofrm, ofrm.FormItemID))
            {
                ofrm.FormType = cnsFormType.Change;
            if (ofrm.ShowDialog() == DialogResult.OK)
            {
                this.FillGrid();
            }
            }
        }

        public override void OnDelete()
        {
            base.OnDelete();

            if (LandID <= 0)
            {
                OnMessage(BaranResources.NoRowSelectedError, PublicEnum.EnmMessageCategory.Warning);
                return;
            }


            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;

            BaranDataAccess.Source.dstSourceTableAdapters.spr_src_Field_SelectTableAdapter adp =
                new BaranDataAccess.Source.dstSourceTableAdapters.spr_src_Field_SelectTableAdapter();

            BaranDataAccess.UnitOfWork dbContext = new BaranDataAccess.UnitOfWork();
            BaranDataAccess.tbl_src_Land land = new BaranDataAccess.tbl_src_Land();
            try
            {
                land = dbContext.LandRepository.GetById(LandID);
                land.IsActive = false;
                land.InactivationUserID = CurrentUser.Instance.UserID;
                land.InactivationDate = System.DateTime.Now;

                dbContext.LandRepository.Update(land);
                dbContext.Save();
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

        public override void OnDetail()
        {
            base.OnDetail();
            this.Detail();
        }

        private void FillGrid()
        {

            BaranDataAccess.Source.dstSourceTableAdapters.spr_src_Land_Lst_SelectTableAdapter adp =
                new BaranDataAccess.Source.dstSourceTableAdapters.spr_src_Land_Lst_SelectTableAdapter();
            try
            {
                dstSource1.Clear();
                adp.FillLandListTable(dstSource1.spr_src_Land_Lst_Select, CurrentUser.Instance.UserID);
            }
            catch
            {
            }

        }

        public override void OnExport(Windows.Forms.UltraGrid grdItem)
        {
            base.OnExport(this.grdItem);
        }

        private void Detail()
        {
            if (LandID <= 0)
            {
                OnMessage(BaranResources.NoRowSelectedError, PublicEnum.EnmMessageCategory.Warning);
                return;
            }
            Baran.Source.frmLandView ofrm = new frmLandView(LandID);
            ofrm.ShowDialog();
        }

        #endregion

        #region Events

        private void grdItem_AfterRowActivate(object sender, EventArgs e)
        {
            if ((grdItem.ActiveRow == null) || (grdItem.ActiveRow.Cells[dstSource1.spr_src_Land_Lst_Select.LandIDColumn.ColumnName].Value == DBNull.Value))
                return;
            LandID = (int)grdItem.ActiveRow.Cells[dstSource1.spr_src_Land_Lst_Select.LandIDColumn.ColumnName].Value;
        }

        private void grdItem_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            this.Detail();

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
