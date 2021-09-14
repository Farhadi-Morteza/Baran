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
    public partial class frmWaterRpt : Baran.Base_Forms.frmSecondChildBase
    {
        public frmWaterRpt()
        {
            InitializeComponent();
        }

        public frmWaterRpt(string fromDate, string toDate, int? fieldID, int? productionID)
        {
            InitializeComponent();
            grpHeader.Visible = false;

            mskFromDate.Text = fromDate;
            mskToDate.Text = toDate;
            FieldID = fieldID;
            ProductionID = productionID;

            FillControls();
        }

        public int? FieldID { get; set; }
        public int? ProductionID { get; set; }

        private int? WaterID = null;
        private Nullable<DateTime>
            FromDate
            , ToDate;

        WaiteForm waite;


        public override void OnformLoad()
        {
            base.OnformLoad();

            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcWaterByUserIDCmb, cmbWater);
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

            BaranDataAccess.Dashboard.dstDashboardTableAdapters.spr_dsb_Water_rptTableAdapter adp =
                new BaranDataAccess.Dashboard.dstDashboardTableAdapters.spr_dsb_Water_rptTableAdapter();

            try
            {
                if (mskFromDate.Text != null)
                    FromDate = DateTimeUtility.ToGregorian(mskFromDate.Value.ToString());

                if (mskToDate.Text != null)
                    ToDate = DateTimeUtility.ToGregorian(mskToDate.Value.ToString());

                adp.FillWaterTable(dstDashboard1.spr_dsb_Water_rpt, CurrentUser.Instance.UserID, FromDate, ToDate, WaterID, FieldID, ProductionID);
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
            dstDashboard1.spr_dsb_Water_rpt.Clear();
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
                dtResult.Columns.Add("UsageVolume", typeof(decimal));

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
                          row["UsageVolume"] = g.Sum(r => r.Field<decimal>("UsageVolume"));
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

        private void cmbWater_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbWater.Value != null)
                    WaterID = Convert.ToInt32(cmbWater.Value);
                else
                    WaterID = null;
            }
            catch
            {
                WaterID = null;
            }
        }

        private void grdItem_AfterRowFilterChanged(object sender, Infragistics.Win.UltraWinGrid.AfterRowFilterChangedEventArgs e)
        {
            DrowChart();
        }

    }
}
