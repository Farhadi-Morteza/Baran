﻿using Baran.Classes.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaranDataAccess;

namespace Baran.Source
{
    public partial class frmFieldList : Baran.Base_Forms.frmChildBase
    {
        public frmFieldList()
        {
            InitializeComponent();
        }

        #region Propertise

        private int _FieldID;
        public int FieldID
        {
            get
            {
                return _FieldID;
            }
            set
            {
                _FieldID = value;
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

            Baran.Source.frmField ofrm =
                new frmField();

            ofrm.FormItemID = Convert.ToInt32(PublicEnum.EnmformItemId.Field);
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
            Baran.Source.frmField ofrm =
                new frmField(FieldID);

            ofrm.FormItemID = Convert.ToInt32(PublicEnum.EnmformItemId.Field);
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

            if (grdItem.Selected.Rows.Count == 0)
            {
                OnMessage(BaranResources.NoRowSelectedError, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            if (FieldID <= 0)
                return;

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDeleteConfirm);
            if (msgResult == DialogResult.No) return;

            BaranDataAccess.Source.dstSourceTableAdapters.spr_src_Field_SelectTableAdapter adp =
                new BaranDataAccess.Source.dstSourceTableAdapters.spr_src_Field_SelectTableAdapter();
            try
            {
                int RowAffected = (int)adp.Delete(FieldID, Convert.ToInt32(CurrentUser.Instance.UserID));
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

            try
            {
                dstSource1.Clear();
                dstSource1.spr_src_Field_Lst_Select.Merge(BaranDataAccess.Source.dstSource.FieldListTable(CurrentUser.Instance.UserID).spr_src_Field_Lst_Select);
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
 
            Baran.Source.frmFieldView ofrm = new frmFieldView(FieldID);
            ofrm.ShowDialog(); 
        }

        #endregion

        #region Events

        private void grdItem_AfterRowActivate(object sender, EventArgs e)
        {
            if ((grdItem.ActiveRow == null) || (grdItem.ActiveRow.Cells[dstSource1.spr_src_Field_Select.FieldIDColumn.ColumnName].Value == DBNull.Value))
                return;
            FieldID = (int)grdItem.ActiveRow.Cells[dstSource1.spr_src_Field_Select.FieldIDColumn.ColumnName].Value;
        }

        private void grdItem_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            this.Detail();

        }

        #endregion



    }
}
