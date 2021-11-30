using System.Linq;
using Baran.Classes.Common;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System;
using System.Net;
using System.IO.Compression;

namespace Baran
{
    public partial class frmMain : System.Windows.Forms.Form
    {
        #region Constractor
        public frmMain()
        {
            InitializeComponent();
            _FrmMain = this;
            SettoolStripButtonImage();
            //SettoolStripButtonText();
            SetUltraStatusBarImage();
            this.SetBackgroundImage();
           
       }
        #endregion

        #region Variables
        private System.Windows.Forms.MdiClient mdcMdiClient = null;
        #endregion

        #region Propertise
        private static frmMain _FrmMain = null;
        public static frmMain Instanc
        {
            get
            {
                if (_FrmMain == null)
                { _FrmMain = new frmMain(); }
                return _FrmMain;

            }
        }
        #endregion

        #region Method

        private System.Boolean Login()
        {
            Baran.Security.frmLoginNew oLoginForm = new Security.frmLoginNew();

            if (oLoginForm.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                oLoginForm.Dispose();
                return false;
            }
            else
            {
                oLoginForm.Dispose();
                BaranDataAccess.Settings.dstSettingsTableAdapters.spr_Setting_VersionCheck_SelectTableAdapter adpVersionInfo = new BaranDataAccess.Settings.dstSettingsTableAdapters.spr_Setting_VersionCheck_SelectTableAdapter();
                BaranDataAccess.Settings.dstSettings.spr_Setting_VersionCheck_SelectDataTable tblVersionInfo = new BaranDataAccess.Settings.dstSettings.spr_Setting_VersionCheck_SelectDataTable();
                tblVersionInfo = adpVersionInfo.GetVersionTable();

                if (tblVersionInfo.Rows.Count != 0)
                {
                    BaranDataAccess.Settings.dstSettings.spr_Setting_VersionCheck_SelectRow drwVersion = tblVersionInfo.Newspr_Setting_VersionCheck_SelectRow();
                    drwVersion = (BaranDataAccess.Settings.dstSettings.spr_Setting_VersionCheck_SelectRow)tblVersionInfo.Rows[0];
                    if (drwVersion.VersionNumber != BaranResources.CrossCheckForVersionNumber)
                    {
                        DialogResult result = System.Windows.Forms.MessageBox.Show(UpdateSoftwareInfo.ConfirmMessage,
                                                                                    "Software Update", 
                                                                                    System.Windows.Forms.MessageBoxButtons.YesNo, 
                                                                                    MessageBoxIcon.Information, 
                                                                                    MessageBoxDefaultButton.Button1, 
                                                                                    MessageBoxOptions.RtlReading |MessageBoxOptions.RightAlign);
                        if (result == DialogResult.Yes)
                        {
                            if (UpdateSofteware())
                                MessageBox.Show(UpdateSoftwareInfo.SuccessUpdateMessage, "Update", MessageBoxButtons.OK);
                            else
                                return false;
                        }
                        else
                            return false;
                    }
                }
                BaranDataAccess.Security.dstSecurityTableAdapters.spr_ShopCheckForCurrentUser_SelectTableAdapter adpCheckLegitimation = new BaranDataAccess.Security.dstSecurityTableAdapters.spr_ShopCheckForCurrentUser_SelectTableAdapter();
                BaranDataAccess.Security.dstSecurity.spr_ShopCheckForCurrentUser_SelectDataTable tblLegitimationCheck = new BaranDataAccess.Security.dstSecurity.spr_ShopCheckForCurrentUser_SelectDataTable();

                tblLegitimationCheck = adpCheckLegitimation.GetLegitimateUserTable((int)BaranLibrary.CurrentUser.CurrentUserInfo.Rows[0][BaranResources.UserTableFK_ShopIDColumn]);

                if (tblLegitimationCheck.Rows.Count == 0)
                {
                    System.Windows.Forms.MessageBox.Show(BaranResources.LegitimationErrorMessage.ToString());
                    this.Dispose();
                    //this.LogOff();
                    //System.Windows.Forms.Application.Exit();
                }
                BaranLibrary.CurrentShop.CurrentShopInfo = tblLegitimationCheck;
                //BaranDataAccess.Security.dstSecurity.spr_ShopCheckForCurrentUser_SelectRow drwCurrentShop = tblLegitimationCheck[0]; //.Newspr_ShopCheckForCurrentUser_SelectRow();
                BaranDataAccess.Security.dstSecurity.spr_ShopCheckForCurrentUser_SelectRow drwCurrentShop = (BaranDataAccess.Security.dstSecurity.spr_ShopCheckForCurrentUser_SelectRow)tblLegitimationCheck.Rows[0];
                if ((int)BaranLibrary.CurrentShop.CurrentShopInfo.Rows[0][BaranResources.ShopTableShopCodeColumn] != int.Parse(BaranLibrary.SystemInformation.ShopEconomicCode))
                {
                    System.Windows.Forms.MessageBox.Show(BaranResources.Licence.ToString());
                    return false;
                }


                usbMainStatusBar.Panels[1].Text = drwCurrentShop.ShopName;
                BaranDataAccess.Security.dstSecurity.spr_Sec_UserAuthentication_SelectDataTable tblUser = 
                    new BaranDataAccess.Security.dstSecurity.spr_Sec_UserAuthentication_SelectDataTable();

                BaranDataAccess.Security.dstSecurity.spr_Sec_UserAuthentication_SelectRow drwUser = tblUser.Newspr_Sec_UserAuthentication_SelectRow();
                drwUser = (BaranDataAccess.Security.dstSecurity.spr_Sec_UserAuthentication_SelectRow)BaranLibrary.CurrentUser.CurrentUserInfo.Rows[0];
                string strFullName = drwUser.FirstName + " " + drwUser.LastName;
                usbMainStatusBar.Panels[3].Text = strFullName;
                //usbMainStatusBar.Panels[5].Text = string.Format("{0:YYYY/MM/DD HH:MM}", BaranLibrary.GeneralMethods.GetServerDateShamsi());
                //usbMainStatusBar.Panels[7].Text =PublicVariables.FiscalYearName;

                tmrClock.Enabled = true;
                BaranDataAccess.Security.dstSecurityTableAdapters.spr_AccessiblePackagesForCurrentUserGrouped_SelectTableAdapter adpAccessiblePackages = new BaranDataAccess.Security.dstSecurityTableAdapters.spr_AccessiblePackagesForCurrentUserGrouped_SelectTableAdapter();
                BaranDataAccess.Security.dstSecurity.spr_AccessiblePackagesForCurrentUserGrouped_SelectDataTable tblAccessiblePackages = new BaranDataAccess.Security.dstSecurity.spr_AccessiblePackagesForCurrentUserGrouped_SelectDataTable();
                BaranDataAccess.Security.dstSecurity.spr_AccessiblePackagesForCurrentUserGrouped_SelectRow drwAccessiblePackages = tblAccessiblePackages.Newspr_AccessiblePackagesForCurrentUserGrouped_SelectRow();
                tblAccessiblePackages = adpAccessiblePackages.GetPackagesTableInGroupedCondition(drwUser.UserID);

                BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectDataTable tblAccessibleItems = new BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectDataTable();
                BaranDataAccess.Security.dstSecurityTableAdapters.spr_AccessibleItemsForCurrentUser_SelectTableAdapter adpAccessibleItems = new BaranDataAccess.Security.dstSecurityTableAdapters.spr_AccessibleItemsForCurrentUser_SelectTableAdapter();
                tblAccessibleItems = adpAccessibleItems.GetAccessibleItemsForCurrentUserTable(drwUser.UserID);

                BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectRow drwAccessibleItem = tblAccessibleItems.Newspr_AccessibleItemsForCurrentUser_SelectRow();

                for (int i = 0; i <= tblAccessiblePackages.Count - 1; i++)
                {
                    Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup UltraGroup = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
                    UltraGroup.Text = tblAccessiblePackages[i].PackageName;
                    UltraGroup.Key = tblAccessiblePackages[i].PackageID.ToString();
                    UltraGroup.Expanded = false;

                    uebMainExplorerBar.Groups.Add(UltraGroup);
                    int intTemp = tblAccessiblePackages[i].PackageID;
                    //linqe
                    var lnqItems = from accessibleItems in tblAccessibleItems where accessibleItems.PackageID == intTemp select accessibleItems;
                    foreach (BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectRow accessibleItems in lnqItems)
                    {
                        if (accessibleItems.EnableOnExplorerBar)
                        {
                            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem UltrItem = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem();
                            try
                            {
                                System.IO.MemoryStream mstrmTemp = new System.IO.MemoryStream(accessibleItems.ItemLogo);
                                System.Drawing.Bitmap bmpTemp = new System.Drawing.Bitmap(mstrmTemp);
                                UltrItem.Settings.AppearancesLarge.Appearance.Image = bmpTemp;
                                mstrmTemp.Close();
                            }
                            catch
                            {
                            }

                            UltrItem.Text = accessibleItems.ItemName;
                            //UltrItem.Settings.AppearancesLarge.Appearance.BorderColor = System.Drawing.Color.Blue;
                            UltrItem.Key = accessibleItems.RelatedFormName + ";" + (accessibleItems.HasWrite ? "WR" : "R").ToString();
                            UltrItem.Tag = accessibleItems.ItemID;
                            UltraGroup.Items.Add(UltrItem);
                        }
                    }
                }

                uebMainExplorerBar.Groups[2].Selected = true;
                //if (uebMainExplorerBar.Groups[8].IsInView == false)
                //    uebMainExplorerBar.Groups[8].Visible = false;

                return true;
            }
        }

        private bool UpdateSofteware()
        {
            WaiteForm waite = new WaiteForm();
            bool blnResult = false;
            int bufferSize = 100000;

            Uri url = new Uri(Path.Combine(ftpServerInfo.UpdateHost, UpdateSoftwareInfo.FileName));
            try
            {
                waite.Show();
                if (url.Scheme == Uri.UriSchemeFtp)
                {
                    FtpWebRequest objRequest = (FtpWebRequest)FtpWebRequest.Create(url);
                    NetworkCredential objCredential = new NetworkCredential(ftpServerInfo.User, ftpServerInfo.Pass);

                    objRequest.Credentials = objCredential;
                    objRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                    FtpWebResponse objResponse = (FtpWebResponse)objRequest.GetResponse();
                    StreamReader objReader = new StreamReader(objResponse.GetResponseStream());

                    byte[] buffer = new byte[bufferSize];
                    int len = 0;
                    
                    FileStream objfs = new FileStream(Path.Combine(Application.StartupPath, UpdateSoftwareInfo.FileName), FileMode.Create, FileAccess.Write, FileShare.Read);

                    while ((len = objReader.BaseStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        objfs.Write(buffer, 0, len);
                    }

                    objfs.Close();
                    objResponse.Close();

                    string extractPath = Application.StartupPath;
                    string zipPath = Path.Combine(Application.StartupPath, UpdateSoftwareInfo.FileName);
                    extractPath = Path.GetFullPath(extractPath);

                    if (!extractPath.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal))
                        extractPath += Path.DirectorySeparatorChar;

                    using (ZipArchive archive = ZipFile.OpenRead(zipPath))
                    {
                        foreach (ZipArchiveEntry entry in archive.Entries)
                        {
                            string entryFullName = Path.Combine(extractPath, entry.FullName);
                            string entryPath = Path.GetDirectoryName(entryFullName);
                            if (Directory.Exists(entryPath))
                                Directory.CreateDirectory(entryPath);

                            string entryFn = Path.GetFileName(entry.FullName);
                            if (!string.IsNullOrEmpty(entryFn))
                                entry.ExtractToFile(entryFullName, true);
                        }
                    }

                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    try
                    {
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.FileName = Path.Combine(Application.StartupPath, "AMS.exe");
                        process.StartInfo.CreateNoWindow = true;

                        File.Delete(zipPath);

                        process.Start();

                        System.Environment.Exit(1);
                    }
                    catch 
                    {
                    }


                    //ZipFile.ExtractToDirectory(Path.Combine(Application.StartupPath, UpdateSoftwareInfo.FileName), extractPath);// Application.StartupPath);

                    //File.Delete(zipPath);

                    //MessageBox.Show(UpdateSoftwareInfo.SuccessUpdateMessage, "Update", MessageBoxButtons.OK);
                    //blnResult = true;
                    waite.Close(); 
                }
            }
            catch
            {
                MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgDoNotDoPleaseTryAgine);
                blnResult = false;
                waite.Close();
            }
            waite.Close();
            return blnResult;
        }

        private void PaintBackGround(System.Drawing.Graphics graphics)
        {
            //int x = 0;
            //int y = 0;

            //System.Drawing.Image img = Baran.BaranResources.Rain;


            //x = mdcMdiClient.ClientRectangle.Width - img.Width - 20;
            //y = mdcMdiClient.ClientRectangle.Height - img.Height - 20;

            //System.Drawing.Bitmap bmpTemporary = (System.Drawing.Bitmap)img;
            //bmpTemporary.MakeTransparent();
            //System.Drawing.Point pntPoint = new System.Drawing.Point(x, y);
            //graphics.DrawImageUnscaled(bmpTemporary, pntPoint);
        }

        private void SettoolStripButtonImage()
        {
            try
            {
                toolStripButtonExit.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Exit));
                toolStripButtonCancel.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Cancel));
                toolStripButtonSave.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Save));
                toolStripButtonDelete.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.delete));
                toolStripButtonChange.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Change));

                toolStripButtonNew.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.New));
                toolStripButtonClear.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.clear));
                toolStripButtonRefresh.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.refresh));
                toolStripButtonFilter.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.filter));

                toolStripButtonPrint.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.printer));
                toolStripButtonConfirm.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Check));
                //toolStripButtonLast.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.End));
                //toolStripButtonNext.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Next));

                //toolStripButtonprevious.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Previous));
                //toolStripButtonFirstRecord.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.First));
                toolStripButtonProgressBar.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.ProgressBar));
                toolStripButtonCalculator.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Calculator));

                toolStripButtonExport.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.ExportExcel));
                toolStripButtonDetail.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Detail));

            }
            catch
            { }
        }

        private void SettoolStripButtonText()
        {
            try
            {
                toolStripButtonChange.Text = "HaHaHa" + Environment.NewLine + "F4";
                toolStripButtonExit.Text = "Exit" + Environment.NewLine + "(Alt+F4)";
                toolStripButtonCancel.Text = "Close" + Environment.NewLine + "(F12)";
                toolStripButtonSave.Text = "Save" + Environment.NewLine + "(F2)";
                //toolStripButtonDelete.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.delete));
                //toolStripButtonChange.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Change));

                //toolStripButtonNew.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.New));
                //toolStripButtonClear.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.clear));
                //toolStripButtonRefresh.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.refresh));
                //toolStripButtonFilter.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.filter));

                //toolStripButtonPrint.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.printer));
                //toolStripButtonConfirm.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Check));
                ////toolStripButtonLast.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.End));
                ////toolStripButtonNext.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Next));

                ////toolStripButtonprevious.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Previous));
                ////toolStripButtonFirstRecord.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.First));
                //toolStripButtonProgressBar.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.ProgressBar));
                //toolStripButtonCalculator.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Calculator));

                //toolStripButtonExport.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.ExportExcel));
                //toolStripButtonDetail.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Detail));

            }
            catch
            {
            }
        }

        private void SetUltraStatusBarImage()
        {
            try
            {
                usbMainStatusBar.Panels[0].Appearance.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Building16));
                usbMainStatusBar.Panels[2].Appearance.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.User16));
                usbMainStatusBar.Panels[4].Appearance.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.clock16));
                usbMainStatusBar.Panels[6].Appearance.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Calandar16));
            }
            catch
            { }
        }

        private string PictureFileNamePath(string prmImageName)
        {
            string filename = prmImageName;

            int intIndex = filename.LastIndexOf(@"\");
            string strPath, strFile;

            if (intIndex > -1)
            {
                strPath = filename.Substring(0, intIndex);
                strFile = filename.Substring(filename.LastIndexOf(@"\") + 1);
            }
            else
            {
                strFile = filename.Substring(filename.LastIndexOf(@"\") + 1);
            }

            filename = System.Windows.Forms.Application.StartupPath + @"\Pic\" + strFile;

            if (!System.IO.File.Exists(filename))
            {
                //throw new Exception("Report file does not exist.");
                filename = string.Empty;
            }
            else
            {

            }

            return filename;
        }

        private void SetBackgroundImage()
        {


            string path = System.IO.Path.GetDirectoryName(
                 System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            string filename = "BackgroundPic.jpg";

            int intIndex = filename.LastIndexOf(@"\");
            string strPath, strFile;

            if (intIndex > -1)
            {
                strPath = filename.Substring(0, intIndex);
                strFile = filename.Substring(filename.LastIndexOf(@"\") + 1);
            }
            else
            {
                strFile = filename.Substring(filename.LastIndexOf(@"\") + 1);
            }

            filename = Application.StartupPath + @"\Pic\" + strFile;

            if (!File.Exists(filename))
            {
                //throw new Exception("Report file does not exist.");
            }

            path = System.Reflection.Assembly.GetExecutingAssembly().Location + "\\Pic";
            //path = System.IO.Path.ChangeExtension(




            this.BackgroundImage = Image.FromFile(filename);
            //this.BackgroundImage = Properties.Resources.ResourceManager._1366x768_windows_7_desktop_pc_and_mac;
        }

        #endregion

        #region Events

        private void frmMain_Load(object sender, System.EventArgs e)
        {
            try
            {

                if (Login() == false)
                {
                    this.Dispose();
                }
                else
                {

                    DisableAllToolbarItems();
                    //toolStripButtonExit.Enabled = true;

                    this.WindowState = FormWindowState.Maximized;

                    foreach (System.Windows.Forms.Control ctrl in this.Controls)
                    {
                        if (ctrl is System.Windows.Forms.MdiClient)
                        {
                            mdcMdiClient = (System.Windows.Forms.MdiClient)ctrl;
                            //mdcMdiClient.Paint += new System.Windows.Forms.PaintEventHandler(mdcMdiClient_Paint);
                            break;
                        }
                    }
                }
            }
            catch
            {
                this.Dispose();
            }
        }

        private void frmMain_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            //this.Exit();
            System.Windows.Forms.DialogResult dgrResult = new System.Windows.Forms.DialogResult();
            //dgrResult = System.Windows.Forms.MessageBox.Show(BaranResources.MainFormClosingMessage, BaranResources.ainFormClosingMessageBoxCaption
            //                                     , System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question);
            dgrResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgExitConfirm);

            if (dgrResult == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            else
            {
                foreach (System.Windows.Forms.Form frmChild in this.MdiChildren)
                {
                    frmChild.Close();
                }

                this.Dispose();

            }
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            Baran.Base_Forms.frmChildBase activeChild = (Baran.Base_Forms.frmChildBase)this.ActiveMdiChild;

            if (activeChild != null)
                activeChild.OnActiveForm();
        }

        private void frmMain_Resize(object sender, System.EventArgs e)
        {
            if (mdcMdiClient != null)
            {
                mdcMdiClient.Invalidate();
            }
        }

        private void tmrClock_Tick(object sender, System.EventArgs e)
        {
            usbMainStatusBar.Panels[5].Text = string.Format("{0:YYYY/MM/DD HH:MM}", Baran.Classes.Common.DateTimeUtility.ToPersianFullDate(DateTime.Now));
            //usbMainStatusBar.Panels[5].Text = BaranLibrary.GeneralMethods.GetServerDate().ToString("yyyy/MM/dd HH:mm");
            //string strCurrentDateShamsi = string.Format("{0:YYYY/MM/DD HH:MM}", BaranLibrary.GeneralMethods.GetServerDateShamsi());
            //usbMainStatusBar.Panels[5].Text = strCurrentDateShamsi;


            //foreach (Baran.Base_Forms.frmChildBase frmChild in this.MdiChildren)
            //{
            //    if (tmrClock.Tag != null)
            //    {
            //        frmChild.FormMessage = string.Empty;
            //    }
            //}
            //if (tmrClock.Tag == null)
            //    tmrClock.Tag = 1;
            //else
            //    tmrClock.Tag = null;
        }

        private void uebMainExplorerBar_ItemClick(object sender, Infragistics.Win.UltraWinExplorerBar.ItemEventArgs e)
        {

            if (PublicMethods.CheckAccessibleItemForCurrentUser((int)e.Item.Tag))
            {

                int intPosition = e.Item.Key.IndexOf(";");
                string strFormName = e.Item.Key.Substring(0, intPosition);
                foreach (Baran.Base_Forms.frmChildBase frmChild in this.MdiChildren)
                {
                    if (frmChild.Name == strFormName)
                    {
                        if (frmChild.Visible == true)
                        {
                            frmChild.Focus();
                            return;
                        }
                        else
                        {
                            frmChild.Close();
                            break;
                        }
                    }
                }

                Base_Forms.frmChildBase frmCurrentChild = PublicMethods.CreateChildForm(strFormName);

                if (frmCurrentChild != null)
                {

                    if (e.Item.Key.Substring(intPosition + 1).StartsWith("W"))
                    {
                        frmCurrentChild.IsFormReadOnly = false;
                    }
                    else
                    {
                        frmCurrentChild.IsFormReadOnly = true;
                    }
                    frmCurrentChild.FormLogo = (System.Drawing.Image)e.Item.Settings.AppearancesLarge.Appearance.Image;
                    frmCurrentChild.FormCaption = e.Item.Text;
                    frmCurrentChild.Text = e.Item.Text;
                    frmCurrentChild.FormItemID = (int)e.Item.Tag;

                    if (!frmCurrentChild.IsMdiContainer)
                        frmCurrentChild.MdiParent = this;

                    frmCurrentChild.Show();
                }
                //else
                //{
                //        Base_Forms.frmSecondChildBase frmSecondCurrentChild = PublicMethods.CreateSecondChildForm(strFormName);

                //        if (frmSecondCurrentChild != null)
                //        {

                //            if (e.Item.Key.Substring(intPosition + 1).StartsWith("W"))
                //            {
                //                frmSecondCurrentChild.IsFormReadOnly = false;
                //            }
                //            else
                //            {
                //                frmSecondCurrentChild.IsFormReadOnly = true;
                //            }
                //            frmSecondCurrentChild.FormLogo = (System.Drawing.Image)e.Item.Settings.AppearancesLarge.Appearance.Image;
                //            frmSecondCurrentChild.FormCaption = e.Item.Text;
                //            frmSecondCurrentChild.Text = e.Item.Text;
                //            frmSecondCurrentChild.FormItemID = (int)e.Item.Tag;
                //            frmSecondCurrentChild.MdiParent = this;
                //            frmSecondCurrentChild.Show();
                //        }

                //}

            }
        }

        #endregion

        #region MainButtomsEvent

        public void DisableAllToolbarItems()
        {
            try
            {
                for (int i = 0; i <= toolStripMain.Items.Count - 1; i++)
                    toolStripMain.Items[i].Enabled = false;

                toolStripMain.Items["toolStripTextBoxNumberOfRecords"].Text = string.Empty;
                toolStripMain.Items["toolStripButtonProgressBar"].Enabled = true;
                toolStripMain.Items["toolStripButtonCalculator"].Enabled = true;
                toolStripMain.Items[cnsToolStripButton.Export].Visible = false;
                toolStripMain.Items[cnsToolStripButton.Exit].Visible = true;
                toolStripMain.Items[cnsToolStripButton.Exit].Enabled = true;
            }
            catch
            {}
        }

        public void EnableToolBarItems(params string[] Keys)
        {
            this.DisableAllToolbarItems();

            for (int i = 0; i <= (Keys.GetLength(0) - 1); i++)
            {
                toolStripMain.Items[Keys[i]].Visible = true;
                toolStripMain.Items[Keys[i]].Enabled = true;
            }
        }

        public void EnableMenuStripItems(params string[] Keys)
        {
            this.DisableAllMenuStripItems();

            for (int i = 0; (i<= (menustripMain.Items.Count - 1)); i++)
            {
                for (int j = 0; (j<= (((ToolStripMenuItem)( menustripMain.Items[i])).DropDownItems.Count - 1)); j++)
                {
                    if ((Array.IndexOf(Keys, ((ToolStripMenuItem)(menustripMain.Items[i])).DropDownItems[j].Name) > -1))
                    {
                        ((ToolStripMenuItem)(menustripMain.Items[i])).DropDownItems[j].Enabled = true;
                    }
                }
            }
        }

        public void DisableAllMenuStripItems()
            {
                for (int i = 0; (i <= (menustripMain.Items.Count - 1)); i++)
                {
                    for (int j = 0; (j<= (((ToolStripMenuItem)(menustripMain.Items[i])).DropDownItems.Count - 1)); j++)
                    {
                        if ((((ToolStripMenuItem)(menustripMain.Items[i])).DropDownItems[j].Name.StartsWith("tol") == true))
                        {
                            ((ToolStripMenuItem)(menustripMain.Items[i])).DropDownItems[j].Enabled = false;
                        }
                    }
                }
            }

    //Public Sub DisableMenuStripKeys()

        //For i As Integer = 0 To MenuStrip.Items.Count - 1

        //    For j As Integer = 0 To CType(MenuStrip.Items(i), ToolStripMenuItem).DropDownItems.Count - 1

        //        If CType(MenuStrip.Items(i), ToolStripMenuItem).DropDownItems(j).Name.StartsWith("mnu") = True Then

        //            CType(MenuStrip.Items(i), ToolStripMenuItem).DropDownItems(j).Enabled = False

        //        End If

        //    Next j

        //Next i

    //    mnuFilter.Checked = False

    //End Sub
        #endregion

        #region ToolStripButtons

            private void toolStripButtonSave_Click(object sender, System.EventArgs e)
            {
               
                this.Save();
            }

            private void toolStripButtonCancel_Click(object sender, System.EventArgs e)
            {   
                this.Cansel();
            }

            private void toolStripButtonFilter1_Click(object sender, System.EventArgs e)
            {
                this.Filter();
            }

            private void toolStripButtonFilter_Click(object sender, EventArgs e)
            {
                this.Filter();
            }

            private void toolStripButtonChange_Click(object sender, System.EventArgs e)
            {
                this.Change();
            }

            private void toolStripButtonDelete_Click(object sender, System.EventArgs e)
            {
                this.Delete();
            }

            private void toolStripButtonPrint_Click(object sender, System.EventArgs e)
            {
                this.Print();
            }

            private void toolStripButtonExit_Click(object sender, System.EventArgs e)
            {
                //this.Exit();
            }

            private void toolStripButtonConfirm_Click(object sender, System.EventArgs e)
            {
                this.Confirm();
            }

            private void toolStripButtonRefresh_Click(object sender, System.EventArgs e)
            {
                this.Fresh();
            }

            private void toolStripButtonNext_Click(object sender, System.EventArgs e)
            {
                this.Next();
            }

            private void toolStripButtonprevious_Click(object sender, System.EventArgs e)
            {
                this.previous();
            }

            private void toolStripButtonFirstRecord_Click(object sender, System.EventArgs e)
            {
                this.FirstRecord();
            }

            private void toolStripButtonLast_Click(object sender, System.EventArgs e)
            {
                this.Last();
            }

            private void toolStripButtonClear_Click(object sender, System.EventArgs e)
            {
                this.Clear();
            }

            private void toolStripButtonNew_Click(object sender, EventArgs e)
            {
                this.New();
            }

            private void toolStripTextBoxNumberOfRecords_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == '\r')
                    this.NumberOfRecordsKeyPress();
            }

            private void tolMenuItemCash_Click(object sender, EventArgs e)
            {
                this.Cash();
            }

            private void tolMenuItemCheque_Click(object sender, EventArgs e)
            {
                this.Cheque();
            }

            private void tolMenuItemPos_Click(object sender, EventArgs e)
            {
                this.Pos();
            }

            private void toolStripButtonExport_Click(object sender, EventArgs e)
            {
                this.Export();
            }

            private void toolStripButtonPrintCalculator_Click(object sender, EventArgs e)
            {
                this.Calculator();
            }

            private void toolStripButtonCalculator_Click(object sender, EventArgs e)
            {
                this.Calculator();
            }

            private void ToolStripMenuItemExit_Click(object sender, System.EventArgs e)
            {
                this.Close();
            }

            private void ToolStripMenuItemLogOff_Click(object sender, System.EventArgs e)
            {
                this.LogOff();
                
                //If MsgBox("Are Sure To Log Off Rahyab Sailing?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.No Then Return

                //For Each OfrmChilds As frmChilds In Me.MdiChildren
                //    OfrmChilds.Close()
                //Next OfrmChilds

                //UltraExplorerBar_Main.Groups.Clear()

                //If LogIn() = False Then

                //    Me.Close()
                //    End

                //End If
            }
        #endregion toolstrip

        #region MenuStripMain
            private void canselToolStripMenuItem_Click(object sender, System.EventArgs e)
            {
                this.Cansel();
            }

            private void saveToolStripMenuItem_Click(object sender, System.EventArgs e)
            {
                this.Save();
            }

            private void deleteToolStripMenuItem_Click(object sender, System.EventArgs e)
            {
                this.Delete();
            }

            private void changeToolStripMenuItem_Click(object sender, System.EventArgs e)
            {
                this.Change();
            }

            private void NewToolStripMenuItem_Click(object sender, System.EventArgs e)
            {
                this.New();                
            }

            private void clearToolStripMenuItem_Click(object sender, EventArgs e)
            {
                this.Clear();
            }

            private void refreshToolStripMenuItem_Click(object sender, System.EventArgs e)
            {
                this.Fresh();
            }

            private void tolMenuItemFilter_Click(object sender, EventArgs e)

        {
                this.Filter();
            }

            private void printToolStripMenuItem_Click(object sender, System.EventArgs e)
            {
                this.Print();
            }

            private void ConfirmToolStripMenuItem_Click(object sender, System.EventArgs e)
            {
                this.Confirm();
            }

            private void detailToolStripMenuItem_Click(object sender, EventArgs e)
            {
                this.Detail();
            }

            private void tolMenuItemExport_Click(object sender, EventArgs e)
            {
                this.Export();
            }

            private void tolMenuItemNext_Click(object sender, EventArgs e)
            {
                this.Next();
            }

        #endregion

        #region ToolStripButtonsEvent

            private void Cansel()
            {
                //Base_Forms.frmChildBase ofrmChildBase = new Baran.Base_Forms.frmChildBase();
                //ofrmChildBase = (Base_Forms.frmChildBase)this.ActiveMdiChild;
                //ofrmChildBase.OnCancel();
                if (MdiChildren.Length > 1)
                    ActiveMdiChild.Close();
                else if (MdiChildren.Length == 1)
                {
                    ActiveMdiChild.Close();
                    this.DisableAllMenuStripItems();
                    this.DisableAllToolbarItems();
                }
            }

            private void Save()
            {
                Base_Forms.frmChildBase ofrmChildBase = Baran.Base_Forms.frmChildBase.Instanc;
                ofrmChildBase = (Base_Forms.frmChildBase)this.ActiveMdiChild;
                if (ofrmChildBase.SaveAccess)
                    ofrmChildBase.OnSave();
                else
                    ofrmChildBase.FormMessage = BaranResources.SaveAccessDenied;


            }

            private void Filter()
            {
                Base_Forms.frmChildBase ofrmChildBase = Baran.Base_Forms.frmChildBase.Instanc;// new Baran.Base_Forms.frmChildBase();
                ofrmChildBase = (Base_Forms.frmChildBase)this.ActiveMdiChild;
                ofrmChildBase.OnFilter();
            }

            private void Change()
            {
                Base_Forms.frmChildBase ofrmChildBase = Baran.Base_Forms.frmChildBase.Instanc;
                ofrmChildBase = (Base_Forms.frmChildBase)this.ActiveMdiChild;
                if (ofrmChildBase.ChangeAccess)
                {
                    ofrmChildBase.OnChange();
                }
                else
                    ofrmChildBase.FormMessage = BaranResources.EditAccessDenied;
            }

            private void Delete()
            {
                Base_Forms.frmChildBase ofrmChildBase = Baran.Base_Forms.frmChildBase.Instanc;
                ofrmChildBase = (Base_Forms.frmChildBase)this.ActiveMdiChild;
                if (ofrmChildBase.DeleteAccess)
                    ofrmChildBase.OnDelete();
                else
                    ofrmChildBase.FormMessage = BaranResources.DeleteAccessDenied;
            }

            private void Print()
            {
                Base_Forms.frmChildBase ofrmChildBase = Baran.Base_Forms.frmChildBase.Instanc;
                ofrmChildBase = (Base_Forms.frmChildBase)this.ActiveMdiChild;
                if (ofrmChildBase.PrintAccess)
                    ofrmChildBase.OnPrint();
                else
                    ofrmChildBase.FormMessage = BaranResources.PrintAccessDenied;
            }

            private void Exit()
            {
                System.Windows.Forms.DialogResult dgrResult = new System.Windows.Forms.DialogResult();
                //dgrResult =  System.Windows.Forms.MessageBox.Show(BaranResources.MainFormClosingMessage, BaranResources.ainFormClosingMessageBoxCaption
                //                                     , System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question);
                dgrResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgExitConfirm);
                if (dgrResult == System.Windows.Forms.DialogResult.No)
                {
                    //e.Cancel = true;

                    this.Dispose(false);
                   
                    //this.Disposing = false;
                   
                    return;
                }
                else
                {
                    foreach (System.Windows.Forms.Form frmChild in this.MdiChildren)
                    {
                        frmChild.Close();
                    }

                    this.Dispose();

                }
                //this.Close();
                //Base_Forms.frmChildBase ofrmChildBase = new Baran.Base_Forms.frmChildBase();
                //ofrmChildBase = (Base_Forms.frmChildBase)this.ActiveMdiChild;
                //ofrmChildBase.OnExit();
            }

            private void Confirm()
            {
                Base_Forms.frmChildBase ofrmChildBase = Baran.Base_Forms.frmChildBase.Instanc;// new Baran.Base_Forms.frmChildBase();
                ofrmChildBase = (Base_Forms.frmChildBase)this.ActiveMdiChild;
                ofrmChildBase.OnConfirm();
            }

            private void Fresh()
            {
                Base_Forms.frmChildBase ofrmChildBase = Baran.Base_Forms.frmChildBase.Instanc;// new Baran.Base_Forms.frmChildBase();
                ofrmChildBase = (Base_Forms.frmChildBase)this.ActiveMdiChild;
                ofrmChildBase.OnRefresh();
            }

            private void Next()
            {                
                Base_Forms.frmChildBase ofrmChildBase = Baran.Base_Forms.frmChildBase.Instanc;// new Baran.Base_Forms.frmChildBase();
                ofrmChildBase = (Base_Forms.frmChildBase)this.ActiveMdiChild;
                ofrmChildBase.OnNext();
            }

            private void previous()
            {
                Base_Forms.frmChildBase ofrmChildBase = Baran.Base_Forms.frmChildBase.Instanc;// new Baran.Base_Forms.frmChildBase();
                ofrmChildBase = (Base_Forms.frmChildBase)this.ActiveMdiChild;
                ofrmChildBase.OnPrevious();
            }

            private void FirstRecord()
            {
                Base_Forms.frmChildBase ofrmChildBase = Baran.Base_Forms.frmChildBase.Instanc;// new Baran.Base_Forms.frmChildBase();
                ofrmChildBase = (Base_Forms.frmChildBase)this.ActiveMdiChild;
                ofrmChildBase.OnFirstRecord();
            }

            private void Last()
            {
                Base_Forms.frmChildBase ofrmChildBase = Baran.Base_Forms.frmChildBase.Instanc;// new Baran.Base_Forms.frmChildBase();
                ofrmChildBase = (Base_Forms.frmChildBase)this.ActiveMdiChild;
                ofrmChildBase.OnLastRecord();
            }

            private void Clear()
            {
                Base_Forms.frmChildBase ofrmChildBase = Baran.Base_Forms.frmChildBase.Instanc;// new Baran.Base_Forms.frmChildBase();
                ofrmChildBase = (Base_Forms.frmChildBase)this.ActiveMdiChild;
                ofrmChildBase.OnClear();
            }

            private void New()
            {
                Base_Forms.frmChildBase ofrmChildBase = Baran.Base_Forms.frmChildBase.Instanc;// new Baran.Base_Forms.frmChildBase();
                ofrmChildBase = (Base_Forms.frmChildBase)this.ActiveMdiChild;
                if (ofrmChildBase.NewAccess)
                    ofrmChildBase.OnNew();
                else
                    ofrmChildBase.FormMessage = BaranResources.NewAccessDenied;
            }

            private void NumberOfRecordsKeyPress()
            {
                
                Base_Forms.frmChildBase ofrmChildBase = Baran.Base_Forms.frmChildBase.Instanc;// new Baran.Base_Forms.frmChildBase();
                ofrmChildBase = (Base_Forms.frmChildBase)this.ActiveMdiChild;
                ofrmChildBase.OnNumberOfRecordsKeyPress();
            }

            private void Cash()
            {
                Base_Forms.frmChildBase ofrmChildBase = Baran.Base_Forms.frmChildBase.Instanc;// new Baran.Base_Forms.frmChildBase();
                ofrmChildBase = (Base_Forms.frmChildBase)this.ActiveMdiChild;
                ofrmChildBase.OnCash();
            }

            private void Cheque()
            {
                Base_Forms.frmChildBase ofrmChildBase = Baran.Base_Forms.frmChildBase.Instanc;// new Baran.Base_Forms.frmChildBase();
                ofrmChildBase = (Base_Forms.frmChildBase)this.ActiveMdiChild;
                ofrmChildBase.OnCheque();
            }

            private void Pos()
            {
                Base_Forms.frmChildBase ofrmChildBase = Baran.Base_Forms.frmChildBase.Instanc;// new Baran.Base_Forms.frmChildBase();
                ofrmChildBase = (Base_Forms.frmChildBase)this.ActiveMdiChild;
                ofrmChildBase.OnPos();
            }

            private void Detail()
            {
                Base_Forms.frmChildBase ofrmChildBase = Baran.Base_Forms.frmChildBase.Instanc;// new Baran.Base_Forms.frmChildBase();
                ofrmChildBase = (Base_Forms.frmChildBase)this.ActiveMdiChild;
                ofrmChildBase.OnDetail();
            }

            private void Calculator()
            {
                System.Diagnostics.Process.Start("calc.exe");
            }

            private void Export()
            {
                Base_Forms.frmChildBase ofrmChildBase = Baran.Base_Forms.frmChildBase.Instanc;// new Baran.Base_Forms.frmChildBase();
                ofrmChildBase = (Base_Forms.frmChildBase)this.ActiveMdiChild;
                Baran.Windows.Forms.UltraGrid grdItems = new Windows.Forms.UltraGrid();
                ofrmChildBase.OnExport(grdItems);
            }

            private void LogOff()
            {
                DialogResult Result = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgLogOff);

                if (Result == DialogResult.No)
                    return;
                
                foreach (System.Windows.Forms.Form frmChild in this.MdiChildren)
                {
                    frmChild.Close();
                }

                uebMainExplorerBar.Groups.Clear();
                Baran.Classes.Common.CurrentUser.Instance = null;
                if (Login() == false)
                    this.Close();
            }

            private void View()
            {
 
            }

        #endregion


            private void toolStripButtonLogOff_Click(object sender, EventArgs e)
            {
                this.LogOff();
            }

            private void toolStripButtonLogOut_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void btnMaximize_Click(object sender, EventArgs e)
            {
                this.WindowState = FormWindowState.Normal;
            }

            private void btnMinimize_Click(object sender, EventArgs e)
            {
                this.WindowState = FormWindowState.Minimized;
            }

            private void btnClose_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void toolStripButtonDetail_Click(object sender, EventArgs e)
            {
                this.Detail();
            }

            private void tolMenuItemDetail_Click(object sender, EventArgs e)
            {
                this.Detail();
            }

            private void toolStripButtonClose_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void toolStripButtonMinimaize_Click(object sender, EventArgs e)
            {
                this.WindowState = FormWindowState.Minimized;
            }

            private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
            {
                for (int i = 1; i <= 100; i++)
                {
                    System.Threading.Thread.Sleep(10);

                    backgroundWorker1.WorkerReportsProgress = true;
                    backgroundWorker1.ReportProgress(i);
                }
            }

            private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
            {
                toolStripProgressBar1.Value = e.ProgressPercentage;
            }

    }
}





































































































