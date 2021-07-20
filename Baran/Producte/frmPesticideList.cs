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
    public partial class frmPesticideList : Baran.Base_Forms.frmChildBase
    {
        #region Constractor

        public frmPesticideList()
        {
            InitializeComponent();
        }

        #endregion

        #region Variables

        BaranDataAccess.Product.dstProductTableAdapters.spr_src_Pesticide_lst_SelectTableAdapter adp =
            new BaranDataAccess.Product.dstProductTableAdapters.spr_src_Pesticide_lst_SelectTableAdapter();

        #endregion

        #region Propertise

        private int _pesticideID;
        public int PesticideID
        {
            get
            {
                return _pesticideID;
            }
            set
            {
                _pesticideID = value;
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

            Baran.Producte.frmPesticide ofrm = new frmPesticide();

            ofrm.FormType = cnsFormType.New;
            ofrm.ShowDialog();
            this.FillGrid();

        }

        public override void OnChange()
        {
            base.OnChange();

            if (grdItem.Selected.Rows.Count == 0)
            {
                OnMessage(BaranResources.NoRowSelectedError, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            Baran.Producte.frmPesticide ofrm = new frmPesticide(PesticideID);

            ofrm.FormType = cnsFormType.Change;
            ofrm.ShowDialog();
            this.FillGrid();

        }

        public override void OnDelete()
        {
            base.OnDelete();

            if (PesticideID <= 0)
            {
                OnMessage(BaranResources.SavedNotLastTime, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;

            BaranDataAccess.Product.dstProductTableAdapters.spr_src_Pesticide_SelectTableAdapter adpDelete =
                new BaranDataAccess.Product.dstProductTableAdapters.spr_src_Pesticide_SelectTableAdapter();
            try
            {
                int RowAffected = Convert.ToInt32(adpDelete.Delete(PesticideID, CurrentUser.Instance.UserID));
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
            dstProduct1.spr_src_Pesticide_lst_Select.Clear();
            try
            {
                adp.FillPesticideListTable(dstProduct1.spr_src_Pesticide_lst_Select);
            }
            catch
            {

            }
        }

        #endregion

        #region Events

        private void grdItem_AfterRowActivate(object sender, EventArgs e)
        {
            if ((grdItem.ActiveRow == null) || (grdItem.ActiveRow.Cells["PesticideID"].Value == DBNull.Value))
                return;
            PesticideID = (int)grdItem.ActiveRow.Cells["PesticideID"].Value;
        }

        #endregion
    }
}
