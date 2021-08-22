using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using Baran.Classes.Common;

namespace Baran.Classes.Common
{
    class PublicMethods
    {
        static public Base_Forms.frmChildBase CreateChildForm(string strFormName)
        {
            try
            {
                string strAssemblyName = Baran.Properties.Settings.Default.ApplicationAssemblyName;
                System.Type FormType = System.Type.GetType(strAssemblyName + "." + strFormName);
                Base_Forms.frmChildBase frmChild = (Base_Forms.frmChildBase)System.Activator.CreateInstance(FormType);
                return frmChild;
            }
            catch
            {

                System.Windows.Forms.MessageBox.Show(BaranResources.UnderConstructionErrorMessage);
                return null;
            }
        }

        //public static Base_Forms.frmSecondChildBase CreateSecondChildForm(string strFormName)
        //{
        //    try
        //    {
        //        string strAssemblyName = Baran.Properties.Settings.Default.ApplicationAssemblyName;
        //        System.Type FormType = System.Type.GetType(strAssemblyName + "." + strFormName);
        //        Base_Forms.frmSecondChildBase frmChild = (Base_Forms.frmSecondChildBase)System.Activator.CreateInstance(FormType);
        //        return frmChild;
        //    }
        //    catch
        //    {

        //        System.Windows.Forms.MessageBox.Show(BaranResources.UnderConstructionErrorMessage);
        //        return null;
        //    }
        //}

        static public bool CheckAccessibleItemForCurrentUser(int intItemID)
        {
            bool returnValue = false;

            BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectDataTable tblAccessibleItems =
                new BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectDataTable();

            BaranDataAccess.Security.dstSecurityTableAdapters.spr_AccessibleItemsForCurrentUser_SelectTableAdapter adpAccessibleItems =
                new BaranDataAccess.Security.dstSecurityTableAdapters.spr_AccessibleItemsForCurrentUser_SelectTableAdapter();

            BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectRow drwAccessibleItem;
            try
            {
                //tblAccessibleItems = adpAccessibleItems.GetAccessibleItemsForCurrentUserTable((long)BaranLibrary.CurrentUser.CurrentUserInfo[0]["UserID"]);
                tblAccessibleItems = AccessibleItemsForCurrentUser.Instance.tblAccessibleItems;

                //DataTable tblItem = tblAccessibleItems.Select("ItemID = " + intItemID).CopyToDataTable();
                drwAccessibleItem = (BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectRow)tblAccessibleItems.Select("ItemID = " + intItemID)[0];
                if (drwAccessibleItem != null)
                {
                    BaranLibrary.GeneralProperties.HeaderColor1 = drwAccessibleItem.IsPackageFormsHeaderColor1Null() ? System.Drawing.Color.LightSkyBlue.ToArgb() : drwAccessibleItem.PackageFormsHeaderColor1;
                    BaranLibrary.GeneralProperties.HeaderColor2 = drwAccessibleItem.IsPackageFormsHeaderColor2Null() ? System.Drawing.Color.White.ToArgb() : drwAccessibleItem.PackageFormsHeaderColor2;
                    returnValue = true;
                }
                else
                {
                    Baran.Classes.Common.MessageBoxX.ShowMessageBox(BaranResources.DonNotHavePermission);
                    returnValue = false;
                }
            }
            catch
            {
                Baran.Classes.Common.MessageBoxX.ShowMessageBox(BaranResources.DonNotHavePermission);
                returnValue = false;
            }

            return returnValue;
        }

        static public bool SetFormSchema(Base_Forms.frmChildBase frmCurrentChild, int prmFormItemID)
        {
            bool blnResult = true;

            BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectDataTable tblAccessibleItems =
                new BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectDataTable();

            BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectDataTable tblAccessibleItem =
                new BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectDataTable();

            BaranDataAccess.Security.dstSecurityTableAdapters.spr_AccessibleItemsForCurrentUser_SelectTableAdapter adpAccessibleItems =
                new BaranDataAccess.Security.dstSecurityTableAdapters.spr_AccessibleItemsForCurrentUser_SelectTableAdapter();

            BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectRow drwAccessibleItems;

            //tblAccessibleItems = adpAccessibleItems.GetAccessibleItemsForCurrentUserTable(Baran.Classes.Common.CurrentUser.Instance.UserID);
            tblAccessibleItems = Baran.Classes.Common.AccessibleItemsForCurrentUser.Instance.tblAccessibleItems;

            string strFilte = "FK_ItemID = " + prmFormItemID;

            try
            {
                DataTable tbl = tblAccessibleItems.Select(strFilte, "").CopyToDataTable();
                if (tbl.Rows.Count > 0)
                {
                    drwAccessibleItems = (BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectRow)tblAccessibleItems.Select(strFilte, "")[0];
                    if (drwAccessibleItems != null)
                    {
                        if (frmCurrentChild != null)
                        {
                            if (!drwAccessibleItems.IsItemLogoNull())
                            {
                                System.IO.MemoryStream mstrmTemp = new System.IO.MemoryStream(drwAccessibleItems.IsItemLogoNull() ? null : drwAccessibleItems.ItemLogo);
                                System.Drawing.Bitmap bmpTemp = new System.Drawing.Bitmap(mstrmTemp);
                                frmCurrentChild.FormLogo = bmpTemp;
                                mstrmTemp.Close();
                            }
                            frmCurrentChild.FormCaption = drwAccessibleItems.ItemName;
                            frmCurrentChild.Text = drwAccessibleItems.ItemName;
                            frmCurrentChild.FormItemID = drwAccessibleItems.ItemID;

                            //BaranLibrary.GeneralProperties.HeaderColor1 = drwAccessibleItems.IsPackageFormsHeaderColor1Null() ? System.Drawing.Color.LightSkyBlue.ToArgb() : drwAccessibleItems.PackageFormsHeaderColor1;
                            //BaranLibrary.GeneralProperties.HeaderColor2 = drwAccessibleItems.IsPackageFormsHeaderColor2Null() ? System.Drawing.Color.White.ToArgb() : drwAccessibleItems.PackageFormsHeaderColor2;
                        }


                    }
                    else
                    {
                        Baran.Classes.Common.MessageBoxX.ShowMessageBox(BaranResources.DonNotHavePermission, System.Windows.Forms.MessageBoxButtons.OK);
                        blnResult = false;
                    }
                }
                else
                {
                    Baran.Classes.Common.MessageBoxX.ShowMessageBox(BaranResources.DonNotHavePermission, System.Windows.Forms.MessageBoxButtons.OK);
                    blnResult = false;
                }
            }
            catch
            {
                Baran.Classes.Common.MessageBoxX.ShowMessageBox(BaranResources.DonNotHavePermission, System.Windows.Forms.MessageBoxButtons.OK);
                blnResult = false;
            }

            return blnResult;

        }

        static public bool SetFormSchema(Base_Forms.frmSecondChildBase frmCurrentChild, int prmFormItemID)
        {
            bool blnResult = true;

            BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectDataTable tblAccessibleItems =
                new BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectDataTable();

            BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectDataTable tblAccessibleItem =
                new BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectDataTable();

            BaranDataAccess.Security.dstSecurityTableAdapters.spr_AccessibleItemsForCurrentUser_SelectTableAdapter adpAccessibleItems =
                new BaranDataAccess.Security.dstSecurityTableAdapters.spr_AccessibleItemsForCurrentUser_SelectTableAdapter();

            BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectRow drwAccessibleItems;

            //tblAccessibleItems = adpAccessibleItems.GetAccessibleItemsForCurrentUserTable(Baran.Classes.Common.CurrentUser.Instance.UserID);
            tblAccessibleItems = Baran.Classes.Common.AccessibleItemsForCurrentUser.Instance.tblAccessibleItems;

            string strFilte = "FK_ItemID = " + prmFormItemID;

            try
            {
                DataTable tbl = tblAccessibleItems.Select(strFilte, "").CopyToDataTable();
                if (tbl.Rows.Count > 0)
                {
                    drwAccessibleItems = (BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectRow)tblAccessibleItems.Select(strFilte, "")[0];
                    if (drwAccessibleItems != null)
                    {
                        if (frmCurrentChild != null)
                        {
                            if (!drwAccessibleItems.IsItemLogoNull())
                            {
                                System.IO.MemoryStream mstrmTemp = new System.IO.MemoryStream(drwAccessibleItems.IsItemLogoNull() ? null : drwAccessibleItems.ItemLogo);
                                System.Drawing.Bitmap bmpTemp = new System.Drawing.Bitmap(mstrmTemp);
                                frmCurrentChild.FormLogo = bmpTemp;
                                mstrmTemp.Close();
                            }
                            frmCurrentChild.FormCaption = drwAccessibleItems.ItemName;
                            frmCurrentChild.Text = drwAccessibleItems.ItemName;
                            frmCurrentChild.FormItemID = drwAccessibleItems.ItemID;

                            //BaranLibrary.GeneralProperties.HeaderColor1 = drwAccessibleItems.IsPackageFormsHeaderColor1Null() ? System.Drawing.Color.LightSkyBlue.ToArgb() : drwAccessibleItems.PackageFormsHeaderColor1;
                            //BaranLibrary.GeneralProperties.HeaderColor2 = drwAccessibleItems.IsPackageFormsHeaderColor2Null() ? System.Drawing.Color.White.ToArgb() : drwAccessibleItems.PackageFormsHeaderColor2;
                        }


                    }
                    else
                    {
                        Baran.Classes.Common.MessageBoxX.ShowMessageBox(BaranResources.DonNotHavePermission, System.Windows.Forms.MessageBoxButtons.OK);
                        blnResult = false;
                    }
                }
                else
                {
                    Baran.Classes.Common.MessageBoxX.ShowMessageBox(BaranResources.DonNotHavePermission, System.Windows.Forms.MessageBoxButtons.OK);
                    blnResult = false;
                }
            }
            catch
            {
                Baran.Classes.Common.MessageBoxX.ShowMessageBox(BaranResources.DonNotHavePermission, System.Windows.Forms.MessageBoxButtons.OK);
                blnResult = false;
            }

            return blnResult;
        }

        static public byte[] ImageToArray(System.Drawing.Image image)
        {
            try
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
            catch { return null; }
        }

        public static System.Drawing.Image ArrayToImage(byte[] byteArrayIn)
        {
            try
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream(byteArrayIn);
                System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
                //returnImage.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipX);
                return returnImage;
            }
            catch { return null; }
        }

        static public System.Drawing.Image PictureOpenFileDialog()
        {
            System.IO.Stream myStream = null;
            System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            System.Drawing.Image imgReturn = null;

            openFileDialog1.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp"; // " JPEG Images(*.jpg)|*.jpg|Bitmaps(*.bmp)|*.bmp|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            //string ss = openFileDialog1.SafeFileName;
                            var size = new System.IO.FileInfo(openFileDialog1.FileName).Length;
                            if (size > 610000)
                            {
                                Baran.Classes.Common.MessageBoxX.ShowMessageBox(BaranResources.ImageSizeIsHigh, System.Windows.Forms.MessageBoxButtons.OK);
                                imgReturn = null;
                            }
                            else
                                imgReturn = System.Drawing.Image.FromFile(openFileDialog1.FileName);
                        }
                    }
                }
                catch
                {
                    Baran.Classes.Common.MessageBoxX.ShowMessageBox(BaranResources.CouldNotReadFileFromDisk, System.Windows.Forms.MessageBoxButtons.OK);
                    imgReturn = null;
                }
            }
            return imgReturn;
        }

        static public bool PictureSaveFileDialog(System.Drawing.Image img)
        {
            bool blnResult = true;

            System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();

            //saveFileDialog1.InitialDirectory = "@ C:\" ;      
            saveFileDialog1.Title = "Save Image Files";
            saveFileDialog1.CheckFileExists = true;
            saveFileDialog1.CheckPathExists = true;
            //saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp"; // "Text files (*.txt)|*.txt|All files (*.*)|*.*";      
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            

            return blnResult;
        }

        static public string PictureFileNamePath(string prmImageName)
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

        public void ShowMainProgress()
        {
            frmMain ofrm = frmMain.Instanc;
            //ofrm.usbMainStatusBar.Panels[8].Visible = true;
            //ofrm.usbMainStatusBar.Panels[8].ProgressBarInfo.Value = 10000;
            ////ofrm.usbMainStatusBar.Panels[8].ProgressBarInfo.Value = 0;
            ////ofrm.usbMainStatusBar.Panels[8].Visible = false;
            //System.Windows.Forms.Application.Idle += OnLoaded;

            ofrm.toolStripMain.Items["Prog"].Visible = true;
            System.Windows.Forms.Application.Idle += OnLoaded;

        }

        private void OnLoaded(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Idle -= OnLoaded;

        }

        public static void ClearWhereClause()
        {
            PublicVariables.WhereClause = string.Empty;
        }

        public static string MiladiToShamsi(string prmMiladiDate)
        {
            string ReturnValue;
            
            //DateTimeUtility.ToPersian((DateTime)FarsiLibrary.Utils.PersianDate.Parse(dpFromDate.Text));
            try
            {
                if (prmMiladiDate != null)
                    ReturnValue =  DateTimeUtility.ToPersian(Convert.ToDateTime( prmMiladiDate));
                else
                    ReturnValue = null;
            }
            catch
            {
                ReturnValue = null;
            }

            return ReturnValue;
         
        }

        public static  Nullable<DateTime> ShamsiToMiladi(string prmShamsiDate)
        {
            DateTime ? ReturnValue ;
            //ReturnValue = FarsiLibrary.Utils.PersianDateConverter.ToGregorianDateTime(prmShamsiDate);
            //prmShamsiDate = "13991020";
            try
            {
                if (prmShamsiDate != string.Empty)
                    
                    ReturnValue = FarsiLibrary.Utils.PersianDateConverter.ToGregorianDateTime(prmShamsiDate);
                else
                    ReturnValue = null;
            }
            catch
            {
                ReturnValue = null;
            }

            return  ReturnValue;
        }

        private static DataTable RemoveDuplicatesRecords(DataTable dt)
        {
            //Returns just 5 unique rows
            var UniqueRows = dt.AsEnumerable().Distinct(DataRowComparer.Default);
            DataTable dt2 = UniqueRows.CopyToDataTable();
            return dt2;
        }

        public static DataTable RemoveDuplicatesRecords(DataTable table, string DistinctColumn)
        {
            try
            {
                ArrayList UniqueRecords = new ArrayList();
                ArrayList DuplicateRecords = new ArrayList();

                // Check if records is already added to UniqueRecords otherwise,
                // Add the records to DuplicateRecords
                foreach (DataRow dRow in table.Rows)
                {
                    if (UniqueRecords.Contains(dRow[DistinctColumn]))
                        DuplicateRecords.Add(dRow);
                    else
                        UniqueRecords.Add(dRow[DistinctColumn]);
                }

                // Remove dupliate rows from DataTable added to DuplicateRecords
                foreach (DataRow dRow in DuplicateRecords)
                {
                    table.Rows.Remove(dRow);
                }

                // Return the clean DataTable which contains unique records.
                return table;
            }
            catch
            {
                return null;
            }
        }

        public static double ConvertToDouble(string s)
        {
            char systemSeparator = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];
            double result = 0;
            try
            {
                if (s != null)
                    if (!s.Contains(","))
                        result = double.Parse(s, System.Globalization.CultureInfo.InvariantCulture);
                    else
                        result = Convert.ToDouble(s.Replace(".", systemSeparator.ToString()).Replace(",", systemSeparator.ToString()));
            }
            catch //(Exception e)
            {
                try
                {
                    result = Convert.ToDouble(s);
                }
                catch
                {
                    try
                    {
                        result = Convert.ToDouble(s.Replace(",", ";").Replace(".", ",").Replace(";", "."));
                    }
                    catch
                    {
                        //throw new Exception("Wrong string-to-double format");
                    }
                }
            }
            return result;
        }



    }
}
