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
    public partial class frmPartList : Baran.Base_Forms.frmChildBase
    {

        #region Constractor

        public frmPartList()
        {
            InitializeComponent();
        }

        #endregion

        #region Propertise

        private int _PartID;
        public int PartID
        {
            get
            {
                return _PartID;
            }
            set
            {
                _PartID = value;
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

            Baran.Company.frmPart ofrm = new frmPart();

            ofrm.FormItemID = Convert.ToInt32(PublicEnum.EnmformItemId.Part);
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

            Baran.Company.frmPart ofrm = new frmPart(dstCompany1, PartID);

            ofrm.FormItemID = Convert.ToInt32(PublicEnum.EnmformItemId.Part);
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

            if (PartID <= 0)
                return;

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;

            BaranDataAccess.Company.dstCompanyTableAdapters.spr_src_Part_SelectTableAdapter adp =
                new BaranDataAccess.Company.dstCompanyTableAdapters.spr_src_Part_SelectTableAdapter();

            try
            {
                int RowAffected = (int)adp.Delete(PartID, Convert.ToInt32(CurrentUser.Instance.UserID));
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
            dstCompany1.spr_src_Part_Select.Clear();
            dstCompany1.spr_src_Part_Select.Merge(BaranDataAccess.Company.dstCompany.PartTable(CurrentUser.Instance.UserID).spr_src_Part_Select);
        }

        public override void OnExport(Windows.Forms.UltraGrid grdItem)
        {
            base.OnExport(this.grdItem);
        }

        #endregion

        #region Events

        private void grdItem_AfterRowActivate(object sender, EventArgs e)
        {
            if ((grdItem.ActiveRow == null) || (grdItem.ActiveRow.Cells[dstCompany1.spr_src_Part_Select.PartIDColumn.ColumnName].Value == DBNull.Value))
                return;
            PartID = (int)grdItem.ActiveRow.Cells[dstCompany1.spr_src_Part_Select.PartIDColumn.ColumnName].Value;
        }

        private void grdItem_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            this.OnChange();
        }

        #endregion



    }
}
