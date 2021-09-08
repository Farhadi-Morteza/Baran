using Baran.Classes.Common;
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
    public partial class frmWorkerRpt : Baran.Base_Forms.frmChildBase
    {
        public frmWorkerRpt()
        {
            InitializeComponent();
        }

        public frmWorkerRpt(string fromDate, string toDate , int? fieldID, int? productionID)
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

        private int? PersonID = null;
        private Nullable<DateTime>
            FromDate
            , ToDate;


        public override void OnformLoad()
        {
            base.OnformLoad();

            ComboBoxSetting.FillComboBox(PublicEnum.EnmComboSource.srcPersonByPersonCategoryIDCmb, cmbWorker, cnsPersonCategory.Worker.ToString());

            //Size mySize  = grpMain.Size;// new Size(egbMain.Size.Width, Screen.PrimaryScreen.WorkingArea.Height);

            //for (int i = 0; i < tlpMain.RowCount; i++)
            //{
            //    tlpMain.RowStyles[i].Height = (mySize.Height - 100) / 2;
            //}
        }

        public override void OnActiveForm()
        {
            base.OnActiveForm();

            frmMain ofrm = frmMain.Instanc;
            ofrm.EnableToolBarItems(cnsToolStripButton.Confirm, cnsToolStripButton.Cancel, cnsToolStripButton.Clear);
            ofrm.EnableMenuStripItems(cnsMenustripItems.Confirm, cnsMenustripItems.Cancel, cnsMenustripItems.Clear);
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

            BaranDataAccess.Dashboard.dstDashboardTableAdapters.spr_dsb_Worker_rptTableAdapter adp =
                new BaranDataAccess.Dashboard.dstDashboardTableAdapters.spr_dsb_Worker_rptTableAdapter();

            if (mskFromDate.Text != null)
                FromDate = DateTimeUtility.ToGregorian(mskFromDate.Value.ToString());

            if (mskToDate.Text != null)
                ToDate = DateTimeUtility.ToGregorian(mskToDate.Value.ToString());

            adp.FillWorkerTable(dstDashboard1.spr_dsb_Worker_rpt, CurrentUser.Instance.UserID, FromDate, ToDate, PersonID, FieldID, ProductionID);
            grdItem.FreeSpaceGenerator();

            this.DrowChart();
        }

        public override void OnClear()
        {
            base.OnClear();
            ControlsSetting.ClearControls(grpControls.Controls);
            dstDashboard1.spr_dsb_Worker_rpt.Clear();
            chtMain.Visible = false;
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

        private void cmbWorker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbWorker.Value != null)                   
                    PersonID = Convert.ToInt32(cmbWorker.Value);
                else
                 PersonID = null;
            }
            catch
            {
                PersonID = null;
            }
        }

        private void grdItem_FilterCellValueChanged(object sender, Infragistics.Win.UltraWinGrid.FilterCellValueChangedEventArgs e)
        {
            //this.DrowChart();
        }

        private void DrowChart()
        {
            try
            {
                DataTable dtResult = new DataTable();

                dtResult.Columns.Add("Date", typeof(string));
                dtResult.Columns.Add("TreatedArea", typeof(decimal));
                dtResult.Columns.Add("WorkHoursDecimal", typeof(decimal));

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
                          row["TreatedArea"] = g.Sum(r => r.Field<decimal>("TreatedArea"));
                          row["WorkHoursDecimal"] = g.Sum(t => t.Field<decimal>("WorkHoursDecimal"));
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

        private void grdItem_AfterRowFilterChanged(object sender, Infragistics.Win.UltraWinGrid.AfterRowFilterChangedEventArgs e)
        {
            DrowChart();
        }

        private DataTable CopyUltraGridToDataTable(ref Baran.Windows.Forms.UltraGrid uGrid)
        {
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("Date", typeof(string));
            dtResult.Columns.Add("TreatedArea", typeof(decimal));
            dtResult.Columns.Add("WorkHoursDecimal", typeof(decimal));

            //DataTable dtResult = new DataTable();
            //foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn uCol in uGrid.DisplayLayout.Bands[0].Columns)
            //{
            //    var dNewCol = new DataColumn();
            //    dNewCol.Caption = uCol.Header.Caption;
            //    dNewCol.ColumnName = uCol.Key;
            //    dNewCol.DataType = uCol.DataType;
            //    dtResult.Columns.Add(dNewCol);
            //}

            DataRow dRow;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow uRow in uGrid.Rows)
            {
                if (!uRow.IsFilteredOut)
                {
                    dRow = dtResult.NewRow();
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn uCol in uGrid.DisplayLayout.Bands[0].Columns)
                    {
                        try
                        {
                            if(dRow.Table.Columns.Contains(uCol.Key))
                                dRow[uCol.Key] = uRow.Cells[uCol.Key].Value;
                        }
                        catch
                        {
                        }
                    }

                    dtResult.Rows.Add(dRow);
                }
            }


            var q = dtResult.AsEnumerable()
                .GroupBy(r => r.Field<string>("LastName"))
                .Select(g => new { Company = g.Key, TotalSales = g.Sum(s => s.Field<decimal>("TreatedArea")) });

            //DataTable newDt = dtResult.AsEnumerable()
            //.GroupBy(r => r.Field<string>("LastName"))
            //.Select
            //(
            //    g => new
            //    {
            //        name = g.Key
            //        , TotalArea = g.Sum(s => s.Field<decimal>("TreatedArea"))
            //        , dfasdf = g.Sum(s => s.Field<decimal>("TreatedArea"))
            //    }             
            //);



            //        DataTable newDt = dtResult.AsEnumerable()
            //          .GroupBy(r => r.Field<string>("Date"))
            //          .Select(g =>
            //          {
            //              var row = dtResult.NewRow();

            //              row["Date"] = g.Key;
            //              row["TreatedArea"] = g.Sum(r => r.Field<decimal>("TreatedArea"));
            //              row["WorkHours"] = g.Sum(t => t.Field<TimeSpan>("WorkHours").Ticks);
            //              return row;
            //          }).CopyToDataTable();

            //        var q = dtResult.AsEnumerable()
            //.GroupBy(r => r.Field<string>("LastName"))
            //        .Select
            //        (
            //            g => new { Company = g.Key, TotalSales = g.Sum(s => s.Field<decimal>("TreatedArea")) }
            //        );

            DataTable dd = dtResult.AsEnumerable().OrderBy(d => d.Field<string>("Date")).CopyToDataTable();

            DataTable newDt = dtResult.AsEnumerable().OrderBy(d => d.Field<string>("Date"))
              .GroupBy(r => r.Field<string>("Date"))
              .Select(g =>
              {
                  var row = dtResult.NewRow();
                  try
                  {
                      row["Date"] = g.Key;
                      row["TreatedArea"] = g.Sum(r => r.Field<decimal>("TreatedArea"));
                      row["WorkHoursDecimal"] = g.Sum(t => t.Field<decimal>("WorkHoursDecimal"));                      
                  }
                  catch { }
                  return row;
              }).CopyToDataTable();








            //ultraChart1.DataSource = dtResult;// dtResult;
            return dtResult;
            
        }

        //private DataTable CopyUltraGridToDataTable(ref Infragistics.Win.UltraWinGrid.UltraGrid uGrid)
        //{
        //    var dtResult = new DataTable();
        //    foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn uCol in uGrid.DisplayLayout.Bands(0).Columns)
        //    {
        //        var dNewCol = new DataColumn();
        //        dNewCol.Caption = uCol.Header.Caption;
        //        dNewCol.ColumnName = uCol.Key;
        //        dNewCol.DataType = uCol.DataType;
        //        dtResult.Columns.Add(dNewCol);
        //    }

        //    DataRow dRow;
        //    foreach (Infragistics.Win.UltraWinGrid.UltraGridRow uRow in uGrid.Rows)
        //    {
        //        if (!uRow.IsFilteredOut)
        //        {
        //            dRow = dtResult.NewRow();
        //            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn uCol in uGrid.DisplayLayout.Bands(0).Columns)
        //            {
        //                try
        //                {
        //                    dRow(uCol.Key) = uRow.Cells(uCol.Key).Value;
        //                }
        //                catch
        //                {
        //                }
        //            }

        //            dtResult.Rows.Add(dRow);
        //        }
        //    }

        //    return dtResult;
        //}
    }
}
