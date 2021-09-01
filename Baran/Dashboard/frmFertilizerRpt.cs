using Baran.Classes.Common;
using Baran.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Baran.Dashboard
{
    public partial class frmFertilizerRpt : Baran.Base_Forms.frmChildBase
    {
        public frmFertilizerRpt()
        {
            InitializeComponent();
        }

        public frmFertilizerRpt(string fromDate, string toDate)
        {
            InitializeComponent();
            grpHeader.Visible = false;

            mskFromDate.Text = fromDate;
            mskToDate.Text = toDate;

            FillControls();
        }

        private int? FertilizerID = null;
        private Nullable<DateTime>
            FromDate
            , ToDate;

        WaiteForm waite;


        public override void OnformLoad()
        {
            base.OnformLoad();

            dstProduct1.spr_src_Fertilizer_cmbLst_Select.Clear();
            BaranDataAccess.Product.dstProductTableAdapters.spr_src_Fertilizer_cmbLst_SelectTableAdapter adpFertilizer =
                new BaranDataAccess.Product.dstProductTableAdapters.spr_src_Fertilizer_cmbLst_SelectTableAdapter();
            adpFertilizer.FillFertilizerCmdLstTable(dstProduct1.spr_src_Fertilizer_cmbLst_Select);
        }

        public override void OnActiveForm()
        {
            base.OnActiveForm();

            frmMain ofrm = frmMain.Instanc;
            ofrm.EnableToolBarItems(cnsToolStripButton.Confirm, cnsToolStripButton.Cancel, cnsToolStripButton.Clear, cnsToolStripButton.Export);
            ofrm.EnableMenuStripItems(cnsMenustripItems.Confirm, cnsMenustripItems.Cancel, cnsMenustripItems.Clear, cnsMenustripItems.Export);
        }

        public override void OnConfirm()
        {
            base.OnConfirm();
            FillControls();
        }

        private void FillControls()
        {

            if (!this.ControlsValidation())
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            BaranDataAccess.Dashboard.dstDashboardTableAdapters.spr_dsb_Fertilizer_rptTableAdapter adp =
                new BaranDataAccess.Dashboard.dstDashboardTableAdapters.spr_dsb_Fertilizer_rptTableAdapter();
 
            try
            {
                if (mskFromDate.Text != null)
                    FromDate = DateTimeUtility.ToGregorian(mskFromDate.Value.ToString());

                if (mskToDate.Text != null)
                    ToDate = DateTimeUtility.ToGregorian(mskToDate.Value.ToString());

      
                adp.FillFertilizerTable(dstDashboard1.spr_dsb_Fertilizer_rpt, CurrentUser.Instance.UserID, FromDate, ToDate, FertilizerID);
                grdItem.FreeSpaceGenerator();

                this.DrowChart();
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
   
        }
        public override void OnClear()
        {
            base.OnClear();
            ControlsSetting.ClearControls(grpControls.Controls);
            dstDashboard1.spr_dsb_Fertilizer_rpt.Clear();
            chtMain.Visible = false;
        }

        public override void OnExport(UltraGrid grdItem)
        {
            base.OnExport(this.grdItem);
        }

        private bool ControlsValidation()
        {
            bool blnResult = true;

            if (mskFromDate.Value.ToString() == string.Empty)
            {
                mskFromDate.Focus();
                blnResult = false;
            }
            else if (mskToDate.Value.ToString() == string.Empty)
            {
                mskToDate.Focus();
                blnResult = false;
            }

            return blnResult;
        }

        private void DrowChart()
        {
            try
            {
                DataTable dtResult = new DataTable();

                dtResult.Columns.Add("Date", typeof(string));
                dtResult.Columns.Add("Quantity", typeof(decimal));

                DataRow dRow;
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow uRow in grdItem.Rows)
                {
                    if (!uRow.IsFilteredOut)
                    {
                        dRow = dtResult.NewRow();
                        foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn uCol in grdItem.DisplayLayout.Bands[0].Columns)
                        {
                            try
                            {
                                if (dRow.Table.Columns.Contains(uCol.Key))
                                    dRow[uCol.Key] = uRow.Cells[uCol.Key].Value;
                            }
                            catch
                            {
                            }
                        }

                        dtResult.Rows.Add(dRow);
                    }
                }

                DataTable dtChart = dtResult.AsEnumerable().OrderBy(d => d.Field<string>("Date"))
                  .GroupBy(r => r.Field<string>("Date"))
                  .Select(g =>
                  {
                      var row = dtResult.NewRow();
                      try
                      {
                          row["Date"] = g.Key;
                          row["Quantity"] = g.Sum(r => r.Field<decimal>("Quantity"));
                      }
                      catch { }
                      return row;
                  }).CopyToDataTable();

                chtMain.DataSource = dtChart;
                chtMain.Visible = true;
            }
            catch
            {
                chtMain.Visible = false;
            }
        }

        private void cmbFertilizer_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbFertilizer.Value != null)
                    FertilizerID = Convert.ToInt32(cmbFertilizer.Value);
                else
                    FertilizerID = null;
            }
            catch
            {
                FertilizerID = null;
            }
        }
        
        private void grdItem_AfterRowFilterChanged(object sender, Infragistics.Win.UltraWinGrid.AfterRowFilterChangedEventArgs e)
        {
            DrowChart();
        }

    }
}
