using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Baran.Classes.Common;

namespace Baran.Reports
{
    public partial class frmReaportSettings : Baran.Base_Forms.frmChildBase
    {

    #region Constractor

        public frmReaportSettings()
        {
            InitializeComponent();
        }

    #endregion // End Constractor ---------------------------------------------------------------------

    #region Variables

        BaranDataAccess.Reports.dstReportSetting.spr_Rpt_ReportSetting_SelectDataTable tblRptSettings =
            new BaranDataAccess.Reports.dstReportSetting.spr_Rpt_ReportSetting_SelectDataTable();
        BaranDataAccess.Reports.dstReportSettingTableAdapters.spr_Rpt_ReportSetting_SelectTableAdapter adpRptSettings =
            new BaranDataAccess.Reports.dstReportSettingTableAdapters.spr_Rpt_ReportSetting_SelectTableAdapter();
        BaranDataAccess.Reports.dstReportSetting.spr_Rpt_ReportSetting_SelectRow drwRptSettings;

    #endregion // End Variables -----------------------------------------------------------------------

    #region Propertise

    #endregion // End Propertiese ---------------------------------------------------------------------

    #region Methods

        public override void OnActiveForm()
        {
            base.OnActiveForm();

            frmMain ofrm = frmMain.Instanc;
            ofrm.EnableToolBarItems(cnsToolStripButton.Cancel, cnsToolStripButton.Change, cnsToolStripButton.Refresh);
            ofrm.EnableMenuStripItems(cnsMenustripItems.Cancel, cnsMenustripItems.Change, cnsMenustripItems.Refresh);
        }

        public override void OnformLoad()
        {
            base.OnformLoad();

            tblRptSettings = adpRptSettings.GetReportSettingsTable();
            this.SetControlsValue(tblRptSettings);
        }

        public override void OnRefresh()
        {
            base.OnRefresh();

            tblRptSettings = adpRptSettings.GetReportSettingsTable();
            SetControlsValue(tblRptSettings);
        }

        public override void OnChange()
        {
            base.OnChange();
            int
                intRowAffected
                , intPrintPageSize
                , intPrintA4MoreThan
                , intPrintA5lessThan
                , intPrintA6LessThan
                ;
            long lngUserID;
            string
                strReportHeader
                , strReportFooter
                , strTitleA4
                , strTitleA5
                , strTitleA6
                ;

            DialogResult msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgEditConfirm);
            if (msgResult == System.Windows.Forms.DialogResult.No)
                return;

            try
            {
                strReportHeader = txtReportHeader.Text.Trim();
                strReportFooter = txtReportFooter.Text.Trim();
                byte[] bytReportPicture = Baran.Classes.Common.PublicMethods.ImageToArray(picReport.Image);
                lngUserID = CurrentUser.Instance.UserID;
                strTitleA4 = txtFacRptTitleA4.Text.Trim();
                strTitleA5 = txtFacRptTitleA5.Text.Trim();
                strTitleA6 = txtFacRptTitleA6.Text.Trim();
                intPrintA4MoreThan = Convert.ToInt32(txtFacRptAutoPageSizeA4MoreThan.Text.Trim());
                intPrintA5lessThan = Convert.ToInt32(txtFacRptAutoPageSizeA5LessThan.Text.Trim());
                intPrintA6LessThan = Convert.ToInt32(txtFacRptAutoPageSizeA6LessThan.Text.Trim());
                if (rdbFacRptPageSizeA4.Checked)
                    intPrintPageSize = cnsReportSetting.A4;
                else if (rdbFacRptPageSizeA5.Checked)
                    intPrintPageSize = cnsReportSetting.A5;
                else if (rdbFacRptPageSizeA6.Checked)
                    intPrintPageSize = cnsReportSetting.A6;
                else if (rdbFacRptPageSizeAotumatic.Checked)
                    intPrintPageSize = cnsReportSetting.Automatic;
                else
                    intPrintPageSize = cnsReportSetting.A5;

                intRowAffected = adpRptSettings.Update(strReportHeader
                                                       , strReportFooter
                                                       , bytReportPicture
                                                       , chkShowPrintedBy.Checked
                                                       , chkShowPrintDate.Checked
                                                       , chkShowReportPicture.Checked
                                                       , lngUserID
                                                       , strTitleA4
                                                       , strTitleA5
                                                       , strTitleA6
                                                       , chkAlternateRowColore.Checked
                                                       , Int32.Parse(txtFacRptPointUnit1QuantityMoreThan.Text)
                                                       , Int32.Parse( txtFacRptPointUnit1QuantityLessThan.Text)
                                                       , intPrintPageSize
                                                       , intPrintA4MoreThan
                                                       , intPrintA5lessThan
                                                       , intPrintA6LessThan
                                                       , chkFacRptShowPointUnit1QuantityLessThan.Checked
                                                       , chkFacRptShowPointUnit1QuantityMoreThan.Checked
                                                       , chkFacCheckReplicaPrint.Checked
                                                       , chkFacShowRepliceInPrint.Checked
                                                       , chkFacShowFactorPrintDescriptionInReplica.Checked
                                                       , chkFacShowReportPictrue.Checked
                                                       , chkPrintPreView.Checked
                                                       , chkFacPrintPreView.Checked
                                                       , chkShowReportHeader.Checked
                                                       , chkShowReportFooter.Checked
                                                       , chkFacPrintPreView.Checked
                                                       , chkEconomicCode.Checked
                                                       );

                if (intRowAffected > 0)
                    this.lblMessage.Text = BaranResources.EditSuccessful;
                else
                    this.lblMessage.Text = BaranResources.DoNotDoPleaseTryAgine;

                Baran.Classes.Singleton.ReportSetting.Instance = null;
            }
            catch
            {
                this.lblMessage.Text = BaranResources.EditFail;
            }
        }

        private void SetControlsValue(BaranDataAccess.Reports.dstReportSetting.spr_Rpt_ReportSetting_SelectDataTable prmtblReportSetting)
        {
            if (tblRptSettings.Count > 0)
            {
                try
                {
                    drwRptSettings = prmtblReportSetting[0];

                    txtReportHeader.Text = drwRptSettings.IsReportHeaderNull() ? string.Empty : drwRptSettings.ReportHeader;
                    txtReportFooter.Text = drwRptSettings.IsReportFooterNull() ? string.Empty : drwRptSettings.ReportFooter;
                    txtFacRptTitleA4.Text = drwRptSettings.IsFacRptTitleA4Null() ? string.Empty : drwRptSettings.FacRptTitleA4;
                    txtFacRptTitleA5.Text = drwRptSettings.IsFacRptTitleA5Null() ? string.Empty : drwRptSettings.FacRptTitleA5;
                    txtFacRptTitleA6.Text = drwRptSettings.IsFacRptTitleA6Null() ? string.Empty : drwRptSettings.FacRptTitleA6;
                    txtFacRptPointUnit1QuantityMoreThan.Text = drwRptSettings.IsFacRptPointUnit1QuantityMoreThanNull() ? string.Empty : drwRptSettings.FacRptPointUnit1QuantityMoreThan.ToString();
                    txtFacRptPointUnit1QuantityLessThan.Text = drwRptSettings.IsFacRptPointUnit1QuantityLessThanNull() ? string.Empty : drwRptSettings.FacRptPointUnit1QuantityLessThan.ToString();
                    txtFacRptAutoPageSizeA6LessThan.Text = drwRptSettings.IsFacRptAutoPageSizeA6LessThanNull() ? string.Empty : drwRptSettings.FacRptAutoPageSizeA6LessThan.ToString();
                    txtFacRptAutoPageSizeA5LessThan.Text = drwRptSettings.IsFacRptAutoPageSizeA5LessThanNull() ? string.Empty : drwRptSettings.FacRptAutoPageSizeA5LessThan.ToString();
                    txtFacRptAutoPageSizeA4MoreThan.Text = drwRptSettings.IsFacRptAutoPageSizeA4MoreThanNull() ? string.Empty : drwRptSettings.FacRptAutoPageSizeA4MoreThan.ToString();
                    txtFacRptPointUnit1QuantityMoreThan.Text = drwRptSettings.FacRptPointUnit1QuantityMoreThan.ToString();
                    txtFacRptPointUnit1QuantityLessThan.Text = drwRptSettings.FacRptPointUnit1QuantityLessThan.ToString();

                    chkShowReportHeader.Checked = drwRptSettings.ShowReportHeader;
                    chkShowReportFooter.Checked = drwRptSettings.ShowReportFooter;
                    chkShowPrintDate.Checked = drwRptSettings.ShowPrintDate;
                    chkShowPrintedBy.Checked = drwRptSettings.ShowPrintedBy;
                    chkAlternateRowColore.Checked = drwRptSettings.AlternateRowColore;
                    chkShowReportPicture.Checked = drwRptSettings.ShowReportPicture;
                    chkFacRptShowPointUnit1QuantityLessThan.Checked = drwRptSettings.FacRptShowPointUnit1QuantityLessThan;
                    chkFacRptShowPointUnit1QuantityMoreThan.Checked = drwRptSettings.FacRptShowPointUnit1QuantityMoreThan;                    
                    chkFacShowRepliceInPrint.Checked = drwRptSettings.FacShowReplicaInPrint;
                    chkFacCheckReplicaPrint.Checked = drwRptSettings.FacCheckReplicaPrint;
                    chkFacShowFactorPrintDescriptionInReplica.Checked = drwRptSettings.FacShowFactorPrintDescriptionInReplica;
                    chkFacShowReportPictrue.Checked = drwRptSettings.FacShowReportPictrue;
                    chkPrintPreView.Checked = drwRptSettings.PrintPreView;
                    chkFacPrintPreView.Checked = drwRptSettings.FacRptPrintPreView;
                    chkEconomicCode.Checked = drwRptSettings.ShowEconomicCode;

                    txtFacRptAutoPageSizeA4MoreThan.Text = drwRptSettings.FacRptAutoPageSizeA4MoreThan.ToString();
                    txtFacRptAutoPageSizeA5LessThan.Text = drwRptSettings.FacRptAutoPageSizeA5LessThan.ToString();
                    txtFacRptAutoPageSizeA6LessThan.Text = drwRptSettings.FacRptAutoPageSizeA6LessThan.ToString();


                    if (drwRptSettings.FacRptPageSize == cnsReportSetting.A4)
                        rdbFacRptPageSizeA4.Checked = true;
                    else if (drwRptSettings.FacRptPageSize == cnsReportSetting.A5)
                        rdbFacRptPageSizeA5.Checked = true;
                    else if (drwRptSettings.FacRptPageSize == cnsReportSetting.A6)
                        rdbFacRptPageSizeA6.Checked = true;
                    else if (drwRptSettings.FacRptPageSize == cnsReportSetting.Automatic)
                        rdbFacRptPageSizeAotumatic.Checked = true;

                    picReport.Image = PublicMethods.ArrayToImage(drwRptSettings.ReportPicture);                    
                }
                catch
                { }
            }
        }

    #endregion // End Methods -------------------------------------------------------------------------

    #region Events

        private void chkFacRptShowPointUnit1QuantityLessThan_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFacRptShowPointUnit1QuantityLessThan.Checked)
                txtFacRptPointUnit1QuantityLessThan.Visible = true;
            else
                txtFacRptPointUnit1QuantityLessThan.Visible = false;
        }

        private void chkFacRptShowPointUnit1QuantityMoreThan_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFacRptShowPointUnit1QuantityMoreThan.Checked)
                txtFacRptPointUnit1QuantityMoreThan.Visible = true;
            else
                txtFacRptPointUnit1QuantityMoreThan.Visible = false;

        }

        private void rdbFacRptPageSizeAotumatic_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbFacRptPageSizeAotumatic.Checked)
                grpPageSize.Visible = true;
            else
                grpPageSize.Visible = false;
        }

        private void btnShowPic_Click(object sender, EventArgs e)
        {
            picReport.Image = Baran.Classes.Common.PublicMethods.PictureOpenFileDialog();
        }
        
    #endregion // End Events --------------------------------------------------------------------------

        private void txtFacRptAutoPageSizeA6LessThan_KeyUp(object sender, KeyEventArgs e)
        {
            txtA6.Text = txtFacRptAutoPageSizeA6LessThan.Text;
        }

        private void txtFacRptAutoPageSizeA4MoreThan_KeyUp(object sender, KeyEventArgs e)
        {
            txtA4.Text = txtFacRptAutoPageSizeA4MoreThan.Text;
        }





    }
}
