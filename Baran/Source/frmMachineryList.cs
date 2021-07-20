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
    public partial class frmMachineryList : Baran.Base_Forms.frmChildBase
    {
        #region Constractor

        public frmMachineryList()
        {
            InitializeComponent();
        }

        #endregion

        #region Variables

        #endregion

        #region Propertise

        private int _MachineryID;
        public int MachineryID
        {
            get
            {
                return _MachineryID;
            }
            set
            {
                _MachineryID = value;
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
            Baran.Source.frmMachinery ofrm = new frmMachinery();

            ofrm.FormItemID = Convert.ToInt32(PublicEnum.EnmformItemId.Machinery);
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
            Baran.Source.frmMachinery ofrm =
                new frmMachinery(MachineryID);

            ofrm.FormItemID = Convert.ToInt32(PublicEnum.EnmformItemId.Machinery);
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

            if (MachineryID <= 0)
                return;

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;

            BaranDataAccess.Source.dstSourceTableAdapters.spr_src_Machinery_SelectTableAdapter adp =
                new BaranDataAccess.Source.dstSourceTableAdapters.spr_src_Machinery_SelectTableAdapter();
            try
            {
                int RowAffected = (int)adp.Delete(MachineryID, Convert.ToInt32(CurrentUser.Instance.UserID));
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

        public override void OnDetail()
        {
            base.OnDetail();
            this.Detail();
        }

        private void FillGrid()
        {
            dstSource1.spr_src_Machinery_Lst_Select.Clear();
            dstSource1.spr_src_Machinery_Lst_Select.Merge(BaranDataAccess.Source.dstSource.MachineryListTable(CurrentUser.Instance.UserID).spr_src_Machinery_Lst_Select);
        }

        public override void OnExport(Windows.Forms.UltraGrid grdItem)
        {
            base.OnExport(this.grdItem);
        }

        private void Detail()
        {            
            Baran.Source.frmMachineryView ofrm = new frmMachineryView(MachineryID);
            ofrm.ShowDialog();
        }

        #endregion

        #region Events

        private void grdItem_AfterRowActivate(object sender, EventArgs e)
        {
            if ((grdItem.ActiveRow == null) || (grdItem.ActiveRow.Cells[dstSource1.spr_src_Machinery_Select.MachineryIDColumn.ColumnName].Value == DBNull.Value))
                return;
            MachineryID = (int)grdItem.ActiveRow.Cells[dstSource1.spr_src_Machinery_Lst_Select.MachineryIDColumn.ColumnName].Value;
        }

        #endregion

        private void grdItem_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            this.Detail();
        }
    }
}
