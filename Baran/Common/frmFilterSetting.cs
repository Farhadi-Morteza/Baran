using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Baran.Classes.Common;

namespace Baran.Common
{
    public partial class frmFilterSetting : Baran.Common.frmCommonBaseForm
    {
        public frmFilterSetting()
        {
            InitializeComponent();
        }

        private void btnShowPic_Click(object sender, EventArgs e)
        {
            picShop.Image = Baran.Classes.Common.PublicMethods.PictureOpenFileDialog();
        }

        public override void OnActiveForm()
        {
            base.OnActiveForm();

            frmMain ofrm = frmMain.Instanc;
            ofrm.EnableToolBarItems(cnsToolStripButton.Cancel, cnsToolStripButton.Change);
            ofrm.EnableMenuStripItems(cnsMenustripItems.Cancel, cnsMenustripItems.Change);
        }

        public override void OnChange()
        {
            base.OnChange();

            byte[] PrintLogo = Baran.Classes.Common.PublicMethods.ImageToArray(picShop.Image);

            BaranDataAccess.Reports.dstReportSettingTableAdapters.spr_Rpt_ReportSetting_SelectTableAdapter adpUpdate =
                new BaranDataAccess.Reports.dstReportSettingTableAdapters.spr_Rpt_ReportSetting_SelectTableAdapter();
            //BaranDataAccess.Reports.dstReportSetting.spr_Rpt_ReportSetting_SelectRow drwUpdate =
            //    new BaranDataAccess.Reports.dstReportSetting.spr_Rpt_ReportSetting_SelectRow();
            //BaranDataAccess.Reports.dstReportSetting.spr_Rpt_ReportSetting_SelectDataTable tblUpdate =
            //    new BaranDataAccess.Reports.dstReportSetting.spr_Rpt_ReportSetting_SelectDataTable();

          
            

            

            //adpUpdate.spr_Rpt_ReportSetting_Update(PrintLogo);

        }
    }
}
