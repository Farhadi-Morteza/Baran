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
    public partial class frmChemicalAnalysRpt : Baran.Base_Forms.frmChildBase
    {
        public frmChemicalAnalysRpt()
        {
            InitializeComponent();
        }

        private Nullable<DateTime>
            FromDate
            , ToDate;

        WaiteForm waite;


        public override void OnformLoad()
        {
            base.OnformLoad();
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

            if (!this.ControlsValidation())
            {
                OnMessage(BaranResources.FeildIsEmpty, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            BaranDataAccess.Dashboard.dstDashboardTableAdapters.spr_dsb_ChemicalAnalys_rptTableAdapter adp =
                new BaranDataAccess.Dashboard.dstDashboardTableAdapters.spr_dsb_ChemicalAnalys_rptTableAdapter();
            waite = new WaiteForm();
            try
            {
                if (mskFromDate.Text != null)
                    FromDate = DateTimeUtility.ToGregorian(mskFromDate.Value.ToString());

                if (mskToDate.Text != null)
                    ToDate = DateTimeUtility.ToGregorian(mskToDate.Value.ToString());

                waite.Show();
                adp.FillChemicalAnalysTable(dstDashboard1.spr_dsb_ChemicalAnalys_rpt, CurrentUser.Instance.UserID, FromDate, ToDate);
                grdItem.FreeSpaceGenerator();

                this.DrowChart();
            }
            catch
            {
                OnMessage(BaranResources.DoNotDoPleaseTryAgine, PublicEnum.EnmMessageCategory.Warning);
            }
            waite.Close();
        }

        public override void OnClear()
        {
            base.OnClear();
            ControlsSetting.ClearControls(grpControls.Controls);
            dstDashboard1.spr_dsb_ChemicalAnalys_rpt.Clear();
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


                DataTable dtResult = new DataTable();

                dtResult.Columns.Add("ElementName", typeof(string));
                dtResult.Columns.Add("Date", typeof(string));
                dtResult.Columns.Add("Percentage", typeof(decimal));
            try
            { 
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
                //=======================================
                var dtResultGroup = (from row in dtResult.AsEnumerable()
                                     group row by new
                                     {
                                         ElementName = row.Field<string>("ElementName"),
                                         Date = row.Field<string>("Date"),
                                     } into grp
                                     select new
                                     {
                                         grp.Key.ElementName,
                                         grp.Key.Date,
                                         TotalPercentage = grp.Sum(r => r.Field<decimal>("Percentage")),
                                     }).ToList();
                //============================================
                var dtChart = dtResult.AsEnumerable()
                      .GroupBy(r1 => r1.Field<string>("ElementName"))
                    .Select(g => g.Key).ToList();

                DataTable tbl = new DataTable("ChemicalAnalysTable");
                tbl.Columns.Add("Date", typeof(string));
                foreach (var i in dtChart)
                {
                    tbl.Columns.Add(i.ToString(), typeof(decimal));
                }

                var dtDate = dtResult.AsEnumerable()
                    .GroupBy(d => d.Field<string>("Date"))
                    .Select(g => g.Key).ToList();

                foreach (var col in dtDate)
                {
                    DataRow r = tbl.NewRow();
                    r["Date"] = col;
                    foreach (var row in dtResultGroup)
                    {
                        if (row.Date == col)
                        {
                            r[row.ElementName] = row.TotalPercentage;
                        }
                        else
                        {
                            r[row.ElementName] = 0;
                        }
                    }
                    tbl.Rows.Add(r);
                }
                chtMain.DataSource = tbl;
                chtMain.DataMember = tbl.TableName;

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

//DataTable sourceData = new DataTable();
//sourceData.Columns.AddRange(new DataColumn[]
//                {
//        new DataColumn("BL", typeof(int)),
//        new DataColumn("PREP", typeof(string)),
//        new DataColumn("NBLIG", typeof(int)),
//        new DataColumn("QTY", typeof(int)),
//        new DataColumn("ERRTYPE", typeof(string))
//                });
//            sourceData.Rows.Add(new object[] { 125485, "P1", 5, 125, "RNF" });
//            sourceData.Rows.Add(new object[] { 189654, "P2", 12, 762, "RNF" });
//            sourceData.Rows.Add(new object[] { 156985, "P2", 3, 36, "FNR" });
//            sourceData.Rows.Add(new object[] { 219874, "P1", 36, 5423, "OTH" });
//            sourceData.Rows.Add(new object[] { 123698, "P3", 6, 112, "OTH" });
//            sourceData.Rows.Add(new object[] { 719736, "P1", 25, 998, "RNF" });

//            var query = (from row in sourceData.AsEnumerable()
//                         group row by new
//                         {
//                             PREP = row.Field<string>("PREP"),
//                             me = row.Field<string>("ERRTYPE"),
//                         } into grp
//                         select new
//                         {
//                             PREP = grp.Key.PREP,
//                             me = grp.Key.me,

//                             TotLIG = grp.Sum(r => r.Field<int>("NBLIG")),
//                             TotQTY = grp.Sum(r => r.Field<int>("QTY"))
//                         }).ToList();





//            try
//            {
//                DataTable outTable = new DataTable("PrepData");
//DataColumn[] dataColumn = {
//                    new DataColumn("PREP", typeof(string)),
//                    new DataColumn("NB_BL", typeof(int)),
//                    new DataColumn("TOTLIG", typeof(int)),
//                    new DataColumn("TOTQTY", typeof(int)),
//                    new DataColumn("TOTRNF", typeof(int)),
//                    new DataColumn("TOTFNR", typeof(int)),
//                    new DataColumn("TOTOTH", typeof(int))
//                };
//outTable.Columns.AddRange(dataColumn);

//                var output = sourceData.AsEnumerable()
//                    .GroupBy(Prep => Prep.Field<string>("PREP"))
//                    .Select(PrepGroup => new
//                    {
//                        PREP = PrepGroup.Key,
//                        NB_BL = PrepGroup.Count(),
//                        TOTLIG = PrepGroup.Where(x => x.Field<string>("PREP") == PrepGroup.Key).Sum(x => x.Field<int>("NBLIG")),
//                        TOTQTY = PrepGroup.Where(x => x.Field<string>("PREP") == PrepGroup.Key).Sum(x => x.Field<int>("QTY")),
//                        TOTRNF = PrepGroup.Where(x => x.Field<string>("ERRTYPE") == "RNF").Count(),
//                        TOTFNR = PrepGroup.Where(x => x.Field<string>("ERRTYPE") == "FNR").Count(),
//                        TOTOTH = PrepGroup.Where(x => x.Field<string>("ERRTYPE") == "OTH").Count()
//                    }).ToList();

//                foreach (var xdRow in output)
//                {
//                    DataRow row = outTable.NewRow();
//row["PREP"] = xdRow.PREP;
//                    row["NB_BL"] = xdRow.NB_BL;
//                    row["TOTLIG"] = xdRow.TOTLIG;
//                    row["TOTQTY"] = xdRow.TOTQTY;
//                    row["TOTRNF"] = xdRow.TOTRNF;
//                    row["TOTFNR"] = xdRow.TOTFNR;
//                    row["TOTOTH"] = xdRow.TOTOTH;
//                    outTable.Rows.Add(row);
//                }

//                DataTable mytbl = outTable;
  
        
        //DataTable mytbl = new DataTable();
        //foreach (DataRow g in mytblbase.Rows)
        //{

        //    mytbl.Columns.Add(g[0].ToString(), typeof(string));
        //}
        //-----------------------------------------

          
        ////////////////////////////


        /////////////////////////////
        //int p = 1;
        //DataTable f = new DataTable();
        //DataRow rrr;
        //foreach (var jojo in query2)
        //{
        //    rrr = mytbl.NewRow();
        //    foreach (var c in mytbl.Columns)
        //    {
        //        if (jojo.elementName == c.ToString())
        //        {
        //            rrr[jojo.elementName.ToString()] = jojo.totPercent;
        //        }
        //    }
        //}
        ////f.Rows.Add(rrr);
        //DataTable dtChart = dtResult.AsEnumerable()
        //  .GroupBy(r1 => r1.Field<string>("ElementName"))
        //.Select(g =>
        //{
        //    var row = dtResult.NewRow();
        //    try
        //    {
        //        row["ElementName"] = g.Key;
        //        row["Date"] = g.Select(r1 => r1.Field<string>("Date"));// g.GroupBy(d => d.Field<string>("Date"));
        //        row["Percentage"] = g.Sum(r => r.Field<decimal>("Percentage"));
        //    }
        //    catch { }
        //    return row;
        //}).CopyToDataTable();

        //DataTable dtChart2 = dtResult.AsEnumerable()

        //    .Select(g =>
        //    {
        //        var row = dtResult.NewRow();
        //        try
        //        {
        //            row["ElementName"] = g.Field<string>("ElementName");
        //            row["Date"] = g.Field<string>("Date");
        //            row["Percentage"] = g.Field<decimal>("Percentage");
        //        }
        //        catch { }
        //        return row;
        //    }).CopyToDataTable();
        //string dfp = "sdf";

        //            var totals = dt.AsEnumerable()
        //.GroupBy(row => row.Field<string>("Name")
        //.Select(g => new { Name = g.Key, Total = g.Sum(row => row.Field<int>("Count")));

        //DataTable dtChart2 = dtResult.AsEnumerable()
        //     .GroupBy(ro => ro.Field<string>("ElementName")
        //  .Select(g => new { Element = g.Key, percent = g.Sum(ro => ro.Field<decimal>("Percentage")));
        //{
        //    var row = dtResult.NewRow();
        //    try
        //    {
        //        row["ElementName"] =  g.Field<string>("ElementName");
        //        row["Date"] = g.Field<string>("Date");
        //        row["Percentage"] = g.Field<decimal>("Percentage");
        //    }
        //    catch { }
        //    return row;
        //}).CopyToDataTable();


}
}
