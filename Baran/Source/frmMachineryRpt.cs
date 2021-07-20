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
    public partial class frmMachineryRpt : Baran.Base_Forms.frmChildBase
    {
        #region Constractor

        public frmMachineryRpt()
        {
            InitializeComponent();
        }

        #endregion

        #region Variables
        //@Action AS INT
        string
            strWhereClause
            , strSelectStatement
            , strGroupByClause
            , strOrderByClause
            ;
        #endregion

        #region Propertise

        #endregion

        #region Methods

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

            if (tbcMain.TabControl.ActiveTab.Index == 0)
                this.FillGrid();
            if (tbcMain.TabControl.ActiveTab.Index == 1)
                this.DrowChart();  
        }

        public override void OnExport(Windows.Forms.UltraGrid grdItem)
        {
            base.OnExport(this.grdItem);
        }

        private void FillGrid()
        {
            this.SetVariables();

            BaranDataAccess.Source.dstReport.spr_src_Machinery_Rpt_SelectDataTable tbl =
                new BaranDataAccess.Source.dstReport.spr_src_Machinery_Rpt_SelectDataTable();
            BaranDataAccess.Source.dstReportTableAdapters.spr_src_Machinery_Rpt_SelectTableAdapter adp =
                new BaranDataAccess.Source.dstReportTableAdapters.spr_src_Machinery_Rpt_SelectTableAdapter();
            try
            {
                grdItem.DataMember = null;
                grdItem.DataSource = null;
                grdItem.DataBindings.Clear();

                BaranDataAccess.Source.dstReport dst =
                    new BaranDataAccess.Source.dstReport();

                grdItem.DataSource = dst;
                grdItem.DataMember = "spr_src_Machinery_Rpt_Select";

                tbl = adp.GetMachineryRptTable(1, strWhereClause, strSelectStatement, strGroupByClause, strOrderByClause, CurrentUser.Instance.UserID.ToString());
                if (tbl.Count > 0)
                {
                    grdItem.ClearUndoHistory();

                    dst.spr_src_Machinery_Rpt_Select.Merge(tbl);

                    grdItem.DisplayLayout.Bands[0].Columns["RowID"].Header.VisiblePosition = grdItem.DisplayLayout.Bands[0].Columns.Count;
                    grdItem.DisplayLayout.Bands[0].Columns["FreeSpace"].Header.VisiblePosition = 0;

                    Infragistics.Win.UltraWinGrid.UltraGridBand band = this.grdItem.DisplayLayout.Bands[0];

                    // Add a summary.
                    Infragistics.Win.UltraWinGrid.SummarySettings summary = band.Summaries.Add(Infragistics.Win.UltraWinGrid.SummaryType.Sum, band.Columns["تعداد کل"]);
                    summary.SummaryPosition = Infragistics.Win.UltraWinGrid.SummaryPosition.Right;
                    summary.DisplayFormat = " {0:###,##.##}";
                    ///////////////////////////////////////////////////////////////////
                    band.Override.BorderStyleSummaryValue = Infragistics.Win.UIElementBorderStyle.None;
                    band.SummaryFooterCaption = "";

                    grdItem.FreeSpaceGenerator();
                }
                else
                {
                    OnMessage(BaranResources.RecordNotFound, PublicEnum.EnmMessageCategory.Warning);
                }

            }
            catch
            {
            }
        }

        private void DrowChart()
        {
            BaranDataAccess.Source.dstReport.spr_src_Machinery_cht_SelectDataTable tbl =
                new BaranDataAccess.Source.dstReport.spr_src_Machinery_cht_SelectDataTable();
            BaranDataAccess.Source.dstReportTableAdapters.spr_src_Machinery_cht_SelectTableAdapter adp =
                new BaranDataAccess.Source.dstReportTableAdapters.spr_src_Machinery_cht_SelectTableAdapter();
            try
            {
                int intCompanyCategory = 1;
                if (rdbCompany.Checked)
                    intCompanyCategory = 1;
                else if (rdbCollection.Checked)
                    intCompanyCategory = 2;
                else if (rdbSubcollection.Checked)
                    intCompanyCategory = 3;
                else if (rdbPart.Checked)
                    intCompanyCategory = 4;

                int intAction = 1;


                //chtChart.Data = null;
                chtChart.DataMember = string.Empty;
                chtChart.DataSource = null;
                //chtChart.DataBindings.Clear();

                BaranDataAccess.Source.dstReport dst =
                    new BaranDataAccess.Source.dstReport();

                chtChart.DataSource = dst;
                chtChart.DataMember = "spr_src_Machinery_cht_Select";

                tbl.Clear();
                tbl = adp.GetMachineryChtTable(intAction, intCompanyCategory);

                if (tbl.Count >= 1)
                {
                    chtChart.Visible = true;
                    dst.spr_src_Machinery_cht_Select.Clear();
                    dst.spr_src_Machinery_cht_Select.Merge(tbl);
                }
                else
                    chtChart.Visible = false;
            }
            catch
            {
                this.lblMessage.Text = BaranResources.AccessibleItemsInsertionInDBError;
            }
        }

        private void SetVariables()
        {
            strSelectStatement = string.Empty;
            strWhereClause = string.Empty;
            strGroupByClause = string.Empty;
            strOrderByClause = string.Empty;

            try
            {
                if (chkCategory.Checked)
                {
                    strSelectStatement += ", dbo.tbl_src_MachineryCategory.NameFa AS [گروه] ";
                    strGroupByClause += ",    dbo.tbl_src_MachineryCategory.NameFa  ";
                }
                if (chkPart.Checked)
                {
                    strSelectStatement += ",dbo.tbl_src_Part.Name AS [واحد فرعی] ";
                    strGroupByClause += ", dbo.tbl_src_Part.Name ";
                }
                if (chkSubcollection.Checked)
                {
                    strSelectStatement += ", dbo.tbl_src_Subcollection.Name AS [واحد] ";
                    strGroupByClause += ", dbo.tbl_src_Subcollection.Name  ";
                }
                if (chkCollection.Checked)
                {
                    //strWhereClause += " AND dbo.tbl_src_Collection.CollectionID = " + cmbCollection.Value;
                    strSelectStatement += ", dbo.tbl_src_Collection.Name AS [کشت و صنعت] ";
                    strGroupByClause += ", dbo.tbl_src_Collection.Name ";
                }
                if (chkCompany.Checked)
                {
                    strSelectStatement += ", dbo.tbl_src_Company.Name AS [شرکت] ";
                    strGroupByClause += ", dbo.tbl_src_Company.Name ";
                }

                //---------------------------------------------------------------------------------------------------

                if (chkCompany.Checked)
                {
                    strOrderByClause += ", dbo.tbl_src_Company.Name ";
                }
                if (chkCollection.Checked)
                {
                    strOrderByClause += ", dbo.tbl_src_Collection.Name ";
                }
                if (chkSubcollection.Checked)
                {
                    strOrderByClause += ", dbo.tbl_src_Subcollection.Name  ";
                }
                if (chkPart.Checked)
                {
                    strOrderByClause += ", dbo.tbl_src_Part.Name ";
                }
                if (strOrderByClause != string.Empty)
                {
                    strOrderByClause = strOrderByClause.Remove(0, 1);
                    strOrderByClause = " ORDER BY " + strOrderByClause;
                }
            }
            catch { }
        }


        #endregion

        #region Events

        #endregion
    }
}
