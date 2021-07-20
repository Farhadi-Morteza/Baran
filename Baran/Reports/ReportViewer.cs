using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using CrystalDecisions.CrystalReports.Engine;
//using CrystalDecisions.Shared;
using Baran.Classes.Common;

namespace Baran.Reports
{
    public partial class ReportViewer : Form
    {
        //public ReportViewer()
        //{
        //    InitializeComponent();
        //}

        private string _ReportTitle = "(Unknown)";

        public string ReportTitle
        {
            set
            {
                _ReportTitle = value;
            }
        }

        //ReportDocument rep;

        //public ReportViewer(ReportDocument report)
        //{
        //    InitializeComponent();
        //    crvReportViewer.ReportSource = report;
        //    //report.PrintOptions.PaperSize = PaperSize.PaperA5;
        //    //report.PrintToPrinter(1, false, 1, 1);
        //}

        //public ReportViewer(ReportDocument report, Boolean cathPrintEvent)
        //{
        //    if (cathPrintEvent)
        //    {
        //        InitializeComponent();
        //        crvReportViewer.ReportSource = report;
        //        rep = report;
        //        //foreach(Control ctrl in crvReportViewer.Controls )
        //        //    if (ctrl is ToolStrip)
        //        //    {
        //        //        foreach (ToolStripButton tsb in ctrl. ts.Items.OfType<ToolStripButton>())
        //        //    {
        //        //    }
        //    //foreach (Control control in crvReportViewer.Controls) {
        //    //    if (control is System.Windows.Forms.ToolStrip) {


        //        try
        //        {
        //            foreach (ToolStrip ts in crvReportViewer.Controls.OfType<ToolStrip>())
        //            {
        //                foreach (ToolStripButton tsb in ts.Items.OfType<ToolStripButton>())
        //                {
        //                    //hacky but should work. you can probably figure out a better method
        //                    if (tsb.ToolTipText.ToLower().Contains("Print Report"))
        //                    {
        //                        //Adding a handler for our propose
        //                        Section section = report.ReportDefinition.Sections["Section3"];
        //                        BlobFieldObject blobFieldObject1 = section.ReportObjects["ChequeImage1"] as BlobFieldObject;
        //                        if (blobFieldObject1 != null)
        //                        {
        //                            blobFieldObject1.ObjectFormat.EnableSuppress = true;
        //                        }
        //                    }
        //                }
        //            } 
        //        }
        //        catch (Exception)
        //        {
                    
        //            throw;
        //        }
  
        //    }
        //    else
        //    { }
        //}

        private void ReportViewer_Load(object sender, EventArgs e)
        {
            if (_ReportTitle == string.Empty)
            {
                lblCaption.Text = lblCaption.Text + "[N/A]";
            }
            else
            {
                lblCaption.Text = lblCaption.Text + "[" + _ReportTitle + "]";
            }

            this.SettoolStripButtonImage();
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //crvReportViewer.PrintReport();
            //crvReportViewer.RefreshReport();
            //crvReportViewer.ExportReport();
            //crvReportViewer.ShowGroupTree();
            

            //crvReportViewer.ShowNthPage(1);
            
        }

        private void tlsButtonExport_Click(object sender, EventArgs e)
        {
            //crvReportViewer.ExportReport();
        }

        private void tlsButtonPrint_Click(object sender, EventArgs e)
        {
            //section = crReportDocument.ReportDefinition.Sections["Section3"];
            //BlobFieldObject blobFieldObject1 = crvReportViewer.report.ReportObjects["ChequeImage1"] as BlobFieldObject;
            //BlobFieldObject blobFieldObject1 = rep.ReportDefinition.Sections["Section3"].ReportObjects["ChequeImage1"] as BlobFieldObject;
            //blobFieldObject1.ObjectFormat.EnableSuppress = true;
            //crvReportViewer.ReportSource = rep;
            //crvReportViewer.PrintReport();
        }

        private void tlsButtonFirstPage_Click(object sender, EventArgs e)
        {
            //crvReportViewer.ShowFirstPage();
        }

        private void tlsButtonPreviousPage_Click(object sender, EventArgs e)
        {
            //crvReportViewer.ShowPreviousPage();
        }

        private void tlsButtonNextPage_Click(object sender, EventArgs e)
        {
            //crvReportViewer.ShowNextPage();
        }

        private void tlsButtonLastPage_Click(object sender, EventArgs e)
        {
            //crvReportViewer.ShowLastPage();
        }

        private void tlsSplitButtonZoom_TextChanged(object sender, EventArgs e)
        {
            //crvReportViewer.Zoom(100);
        }

        private void SettoolStripButtonImage()
        {
            try
            {
                tlsButtonExport.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Export));
                tlsButtonPrint.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.printer));
                tlsButtonFirstPage.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.End));
                tlsButtonPreviousPage.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Next));
                tlsButtonNextPage.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Previous));
                tlsButtonLastPage.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.First));
                tlsButtonZoom.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Zoom));

                this.pictureBox1.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.PrintPreView));
            }
            catch
            { }
        }

        private void miniToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
