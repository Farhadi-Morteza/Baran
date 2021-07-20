using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baran.Reports;
//using CrystalDecisions.CrystalReports.Engine;
using System.Drawing;
//using CrystalDecisions.Shared;

namespace Baran.Classes.Common
{
    public class Facility
    {

        //private Dictionary<string, object> _Parameter = new Dictionary<string, object>();

        //private ReportDocument CreateReportFactor(string FileName, DataSet DataSource, Dictionary<string, DataSet> SubDataSource, string Username, string Fullname)
        //{
        //    string ReportName = FileName;
        //    /// Add extention
        //    FileName = System.IO.Path.ChangeExtension(FileName, ".rpt");

        //    /// Check file existance
        //    if (!File.Exists(FileName))
        //    {
        //        int intIndex = FileName.LastIndexOf(@"\");
        //        string strPath, strFile;
        //        if (intIndex > -1)
        //        {
        //            strPath = FileName.Substring(0, intIndex);
        //            strFile = FileName.Substring(FileName.LastIndexOf(@"\") + 1);
        //        }
        //        else
        //        {
        //            strFile = FileName.Substring(FileName.LastIndexOf(@"\") + 1);
        //        }
        //        FileName = Application.StartupPath + @"\Reports\" + strFile;
        //        if (!File.Exists(FileName))
        //        {
        //            throw new Exception("Report file does not exist.");
        //        }
        //    }

        //    ReportDocument rptRet = new ReportDocument();

        //    /// Load report from file
        //    try
        //    {
        //        rptRet.Load(FileName);
        //    }
        //    catch 
        //    {
        //        //return null;
        //        //throw e;
        //    }

        //    // Set report data source 
        //    //if (DataSource != null)
        //    //{
        //    // Check DataSource for report setting data          
        //    // 
        //    // 

        //    var dst = new BaranDataAccess.Reports.dstReportSetting();
        //    var dstShop = new BaranDataAccess.Reports.dstShop();
        //    for (int i = 0; i < rptRet.Database.Tables.Count; i++)
        //    {
        //        if (rptRet.Database.Tables[i].Name == "spr_Rpt_ReportSetting_Select")
        //        {
        //            dst = BaranDataAccess.Reports.dstReportSetting.GetReportSetting();
        //            if (dst != null && dst.spr_Rpt_ReportSetting_Select.Rows.Count > 0)
        //            {
                        
        //                //dst.spr_Rpt_ReportSetting_Select.Rows[0]["Username"] = Baran.Classes.Common.CurrentUser.Instance.UserName;
        //                //dst.spr_Rpt_ReportSetting_Select.Rows[0]["Fullname"] = Baran.Classes.Common.CurrentUser.Instance.FullName;
        //                //dst.spr_Rpt_ReportSetting_Select.Rows[0]["CurrentDateShamsi"] = DateTimeUtility.CurrentDatePersian();

        //                rptRet.Database.Tables["spr_Rpt_ReportSetting_Select"].SetDataSource(dst);                   
        //            }
                   
        //        }

        //        if (rptRet.Database.Tables[i].Name == "spr_Sec_Shop_Select")
        //        {
        //            dstShop = BaranDataAccess.Reports.dstShop.GetShopDescription();
        //            rptRet.Database.Tables["spr_Sec_Shop_Select"].SetDataSource(dstShop);
        //        } 
        //        //break;
        //    }
        //    //if (!DataSource.Tables.Contains("spr_Setting_Select"))
        //    //{
        //    //    //DataSource.Merge(Business.General.dstSetting.SettingSelectActive());
        //    //    //rptRet.SetDataSource(Business.General.dstSetting.SettingSelectActive());
        //    //    rptRet.Database.Tables["spr_Setting_Select"].SetDataSource(Business.General.dstSetting.SettingSelectActive());
        //    //}
        //    //}
        //    //else
        //    //{
        //    //    DataSource = Business.General.dstSetting.SettingSelectActive();
        //    //}


        //    // Set data source
        //    // 

        //    if (DataSource != null && rptRet.Database.Tables.Count > 0)
        //        rptRet.SetDataSource(DataSource);

        //    /// Set subreports data source
        //    if (SubDataSource != null)
        //    {
        //        foreach (ReportDocument subRep in rptRet.Subreports)
        //        {
        //            if (SubDataSource.Any(f => f.Key.ToLower() == subRep.Name.ToLower()))
        //            {
        //                subRep.SetDataSource(SubDataSource.First(f => f.Key.ToLower() == subRep.Name.ToLower()).Value);

        //                var hasSetting = false;
        //                for (var i = 0; i < subRep.Database.Tables.Count; i++)
        //                {
        //                    if (subRep.Database.Tables[i].Name == "spr_ReportSetting_Select")
        //                        hasSetting = true;
        //                }
        //                if (hasSetting)
        //                    subRep.Database.Tables["spr_ReportSetting_Select"].SetDataSource(dst);
        //            }
        //        }
        //    }

        //    /// Return generated report
           
        //    return rptRet;
        //}

        //private ReportDocument CreateReport(string FileName, DataSet DataSource, Dictionary<string, DataSet> SubDataSource, string Username, string Fullname)
        //{
        //    string ReportName = FileName;
        //    /// Add extention
        //    FileName = System.IO.Path.ChangeExtension(FileName, ".rpt");

        //    /// Check file existance
        //    if (!File.Exists(FileName))
        //    {
        //        int intIndex = FileName.LastIndexOf(@"\");
        //        string strPath, strFile;
        //        if (intIndex > -1)
        //        {
        //            strPath = FileName.Substring(0, intIndex);
        //            strFile = FileName.Substring(FileName.LastIndexOf(@"\") + 1);
        //        }
        //        else
        //        {
        //            strFile = FileName.Substring(FileName.LastIndexOf(@"\") + 1);
        //        }
        //        FileName = Application.StartupPath + @"\Reports\" + strFile;
        //        if (!File.Exists(FileName))
        //        {
        //            throw new Exception("Report file does not exist.");
        //        }
        //    }

        //    ReportDocument rptRet = new ReportDocument();

        //    /// Load report from file

        //    try
        //    {
        //        rptRet.Load(FileName);
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }

        //    // Set report data source 
        //    if (DataSource != null)
        //    {
        //        //Check DataSource for report setting data  
        //        rptRet.SetDataSource(DataSource);
        //    }
             
             

 
        //    /// Return generated report

        //    return rptRet;
        //}

        //private ReportDocument CreateReport(string FileName)
        //{
        //    string ReportName = FileName;
        //    /// Add extention
        //    FileName = System.IO.Path.ChangeExtension(FileName, ".rpt");

        //    /// Check file existance
        //    if (!File.Exists(FileName))
        //    {
        //        int intIndex = FileName.LastIndexOf(@"\");
        //        string strPath, strFile;
        //        if (intIndex > -1)
        //        {
        //            strPath = FileName.Substring(0, intIndex);
        //            strFile = FileName.Substring(FileName.LastIndexOf(@"\") + 1);
        //        }
        //        else
        //        {
        //            strFile = FileName.Substring(FileName.LastIndexOf(@"\") + 1);
        //        }
        //        FileName = Application.StartupPath + @"\Reports\" + strFile;
        //        if (!File.Exists(FileName))
        //        {
        //            throw new Exception("Report file does not exist.");
        //        }
        //    }

        //    ReportDocument rptRet = new ReportDocument();

        //    /// Load report from file

        //    try
        //    {
        //        rptRet.Load(FileName);
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }

        //    /// Return generated report
        //    return rptRet;
        //}



        //public Dictionary<string, object> Parameter
        //{
        //    get
        //    {
        //        return _Parameter;
        //    }
        //    set
        //    {
        //        _Parameter = value;
        //    }
        //}

        //private void ShowReport(ReportDocument rep)
        //{
        //    try
        //    {
        //        if (rep == null)
        //        {
        //            return;
        //        }

        //        if (rep.ParameterFields.Count > 0 && _Parameter.Count == 0)
        //        {
        //            throw new Exception("Report parameters not set.");
        //        }
        //        if (rep.ParameterFields.Count > 0 && rep.ParameterFields.Count != _Parameter.Count)
        //        {
        //            throw new Exception("Report parameters not equal.");
        //        }

        //        //------------------------------
        //        //Set Report Parameters
        //        //------------------------------
        //        if (_Parameter.Count > 0)
        //        {
        //            foreach (CrystalDecisions.Shared.ParameterField item in rep.ParameterFields)
        //            {
        //                if (_Parameter.ContainsKey(item.Name))
        //                {
        //                    CrystalDecisions.Shared.ParameterValues ParameterValue;
        //                    ParameterValue = new CrystalDecisions.Shared.ParameterValues();

        //                    ParameterValue.AddValue(_Parameter[item.Name]);
        //                    item.CurrentValues = ParameterValue;

        //                }
        //            }
        //        }
        //        //------------------------------
        //        ReportViewer viewer = new ReportViewer(rep);
        //        viewer.ReportTitle = rep.SummaryInfo.ReportTitle;

        //        viewer.ShowDialog();
                
        //        rep.Dispose();
        //        rep.Close();

        //    }
        //    catch 
        //    {
                
        //    }
        //    finally
        //    {
        //        GC.Collect();
        //    }
        //}

        //public void Show(string Filename, DataSet DataSource, Dictionary<string, DataSet> SubDataSource, string Username, string Fullname)
        //{
        //    ShowReport(CreateReport(Filename, DataSource, SubDataSource, Username, Fullname));
        //}

        //public void Show(ReportDocument report, DataSet DataSource, Dictionary<string, DataSet> SubDataSource, string Username, string Fullname)
        //{
        //    if (DataSource != null)
        //    {
        //        report.SetDataSource(DataSource);
        //    }
        //    foreach (ReportDocument subRep in report.Subreports)
        //    {
        //        if (SubDataSource.Any(f => f.Key.ToLower() == subRep.Name.ToLower()))
        //        {
        //            subRep.SetDataSource(SubDataSource.First(f => f.Key.ToLower() == subRep.Name.ToLower()).Value);
        //        }
        //    }

        //    ShowReport(report);
        //}

        //public void ShowFactor(string Filename, DataSet DataSource, Dictionary<string, DataSet> SubDataSource, string Username, string Fullname)
        //{
        //    ShowReport(CreateReportFactor(Filename, DataSource, SubDataSource, Username, Fullname));
        //}

        //public void ShowCheque(Int64 safeID)
        //{
        //    BaranDataAccess.Reports.dstReports.spr_Doc_Cheques_CrRpt_SelectDataTable tblChequeForPrint =
        //        new BaranDataAccess.Reports.dstReports.spr_Doc_Cheques_CrRpt_SelectDataTable();
        //    BaranDataAccess.Reports.dstReports.spr_Doc_Cheques_CrRpt_SelectRow drwChequeForPrint;

        //    BaranDataAccess.Reports.dstReports dstChequeForPrint = BaranDataAccess.Reports.dstReports.GetChequeCrRpt(safeID);

        //    if (dstChequeForPrint == null)
        //    {
        //        MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgRecordNotFound);
        //        return;
        //    }
        //    tblChequeForPrint = dstChequeForPrint.spr_Doc_Cheques_CrRpt_Select;
        //    drwChequeForPrint = (BaranDataAccess.Reports.dstReports.spr_Doc_Cheques_CrRpt_SelectRow)tblChequeForPrint[0];

        //    ReportDocument crReportDocument = CreateReport("CrCheque");
        //    crReportDocument.SetDataSource(dstChequeForPrint.Tables["spr_Doc_Cheques_CrRpt_Select"]);
        //    try
        //    {
        //        System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
        //        crReportDocument.PrintOptions.PrinterName = printDocument.PrinterSettings.PrinterName;
        //        printDocument.PrinterSettings.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
        //        crReportDocument.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(0, 0, 0, 0));

        //        System.Drawing.Printing.PageSettings pp = new System.Drawing.Printing.PageSettings();
        //        int mmm = pp.PaperSize.Width;
        //            int pppp = Convert.ToInt32((100 * PublicFunction.MillimeterToInch(Convert.ToInt32( drwChequeForPrint.ChequeSizeW))));
        //        int jjj = pp.PaperSize.Height;
        //        int lsf = Convert.ToInt32((100 * PublicFunction.MillimeterToInch(Convert.ToInt32(drwChequeForPrint.ChequeSizeH))));
        //        string p = crReportDocument.PrintOptions.PaperSize.ToString();

                

        //        Section section;
        //        FieldObject fieldObject1, fieldObject2, fieldObject3, fieldObject4, fieldObject5;
        //        BlobFieldObject blobFieldObject1;

        //        // Get the Section object by name.
        //        section = crReportDocument.ReportDefinition.Sections["Section3"];
                
        //        //section.Height = PublicFunction.MillimeterToTWIPS((int)drwChequeForPrint.ChequeSizeH);
                
        //        // Get the ReportObject by name and cast it as a FieldObject.
        //        // The name can be found in the properties window.
        //        fieldObject1 = section.ReportObjects["MatureDateShamsi1"] as FieldObject;
        //        fieldObject2 = section.ReportObjects["matureDateShamsiWord1"] as FieldObject;
        //        fieldObject3 = section.ReportObjects["ChequeAmountWord1"] as FieldObject;
        //        fieldObject4 = section.ReportObjects["ChequePayTo1"] as FieldObject;
        //        fieldObject5 = section.ReportObjects["ChequeAmount1"] as FieldObject;
        //        blobFieldObject1 = section.ReportObjects["ChequeImage1"] as BlobFieldObject;

        //        if (fieldObject1 != null)
        //        {
        //            fieldObject1.Left = PublicFunction.MillimeterToTWIPS(drwChequeForPrint.ChequeMatureDateLocationLeft - cnsPageMarginPrint.LeftMargin);
        //            fieldObject1.Top = PublicFunction.MillimeterToTWIPS(drwChequeForPrint.ChequeMatureDateLocationTop - cnsPageMarginPrint.TopMargin);
        //            fieldObject1.Width = PublicFunction.MillimeterToTWIPS(drwChequeForPrint.ChequeMatureDateSizeWidth);
        //            fieldObject1.Height = PublicFunction.MillimeterToTWIPS(drwChequeForPrint.ChequeMatureDateSizeHeight);
        //            fieldObject1.ApplyFont(new Font(drwChequeForPrint.ChequeFont.ToString(), (float)drwChequeForPrint.ChequeFontSize));
        //            fieldObject1.ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
        //        }
        //        if (fieldObject2 != null)
        //        {
        //            fieldObject2.Left = PublicFunction.MillimeterToTWIPS(drwChequeForPrint.ChequeMatureDateToWordLocationLeft - cnsPageMarginPrint.LeftMargin );
        //            fieldObject2.Top = PublicFunction.MillimeterToTWIPS(drwChequeForPrint.ChequeMatureDateToWordLocationTop - cnsPageMarginPrint.TopMargin);
        //            fieldObject2.Width = PublicFunction.MillimeterToTWIPS(drwChequeForPrint.ChequeMatureDateToWordSizeWidth);
        //            fieldObject2.Height = PublicFunction.MillimeterToTWIPS(drwChequeForPrint.ChequeMatureDateToWordSizeHeight);
        //            fieldObject2.ApplyFont(new Font(drwChequeForPrint.ChequeFont.ToString(), (float)drwChequeForPrint.ChequeFontSize));
        //            fieldObject2.ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
        //        }
        //        if (fieldObject3 != null)
        //        {
        //            fieldObject3.Left = PublicFunction.MillimeterToTWIPS(drwChequeForPrint.ChequeAmountToWordLocationLeft - cnsPageMarginPrint.LeftMargin);
        //            fieldObject3.Top = PublicFunction.MillimeterToTWIPS(drwChequeForPrint.ChequeAmountToWordLocationTop - cnsPageMarginPrint.TopMargin);
        //            fieldObject3.Width = PublicFunction.MillimeterToTWIPS(drwChequeForPrint.ChequeAmountToWordSizeWidth);
        //            fieldObject3.Height = PublicFunction.MillimeterToTWIPS(drwChequeForPrint.ChequeAmountToWordSizeHeight);
        //            fieldObject3.ApplyFont(new Font(drwChequeForPrint.ChequeFont.ToString(), (float)drwChequeForPrint.ChequeFontSize));
        //            fieldObject3.ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
        //        }
        //        if (fieldObject4 != null)
        //        {
        //            fieldObject4.Left = PublicFunction.MillimeterToTWIPS(drwChequeForPrint.ChequePayToLocationLeft - cnsPageMarginPrint.LeftMargin);
        //            fieldObject4.Top = PublicFunction.MillimeterToTWIPS(drwChequeForPrint.ChequePayToLocationTop - cnsPageMarginPrint.TopMargin);
        //            fieldObject4.Width = PublicFunction.MillimeterToTWIPS(drwChequeForPrint.ChequePayToSizeWidth);
        //            fieldObject4.Height = PublicFunction.MillimeterToTWIPS(drwChequeForPrint.ChequePayToSizeHeight);
        //            fieldObject4.ApplyFont(new Font(drwChequeForPrint.ChequeFont.ToString(), (float)drwChequeForPrint.ChequeFontSize));
        //            fieldObject4.ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
        //        }
        //        if (fieldObject5 != null)
        //        {
        //            fieldObject5.Left = PublicFunction.MillimeterToTWIPS(drwChequeForPrint.ChequeAmountLocationLeft - cnsPageMarginPrint.LeftMargin);
        //            fieldObject5.Top = PublicFunction.MillimeterToTWIPS(drwChequeForPrint.ChequeAmountLocationTop - cnsPageMarginPrint.TopMargin);
        //            fieldObject5.Width = PublicFunction.MillimeterToTWIPS(drwChequeForPrint.ChequeAmountSizeWidth);
        //            fieldObject5.Height = PublicFunction.MillimeterToTWIPS(drwChequeForPrint.ChequeAmountSizeHeight);
        //            fieldObject5.ApplyFont(new Font(drwChequeForPrint.ChequeFont.ToString(), (float)drwChequeForPrint.ChequeFontSize));
        //            fieldObject5.ObjectFormat.HorizontalAlignment = Alignment.RightAlign;
        //        }
        //        if (blobFieldObject1 != null)
        //        {

        //            blobFieldObject1.Height = PublicFunction.MillimeterToTWIPS((int)drwChequeForPrint.ChequeSizeH - cnsPageMarginPrint.TopMargin);
        //            blobFieldObject1.Width = PublicFunction.MillimeterToTWIPS((int)drwChequeForPrint.ChequeSizeW - cnsPageMarginPrint.LeftMargin);
        //            blobFieldObject1.Left = 0; // PublicFunction.MillimeterToTWIPS(cnsPageMarginPrint.LeftMargin - 10);
        //            blobFieldObject1.Top = 0; // PublicFunction.MillimeterToTWIPS(-cnsPageMarginPrint.TopMargin);
        //        }

        //        if (drwChequeForPrint.bitPreviwe)
        //        {
        //            Baran.Reports.ReportViewer viewer = new Baran.Reports.ReportViewer(crReportDocument,true);
        //            viewer.Show();
        //        }
        //        else
        //        {
        //            DialogResult msgResult = Baran.Classes.Common.MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgPrintConfirm);
        //                if(msgResult != DialogResult.No)
        //                    crReportDocument.PrintToPrinter(1, false, 1, 0);
        //        }
        //    }
        //    catch
        //    {
        //        MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgPrintFail);

        //    }
        //}
    }
}
