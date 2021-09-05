using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Baran.Classes.Common;

namespace Baran.Base_Forms
{
    public partial class frmChildBase : Form
    {

    #region Constractor

        public frmChildBase()
        {
            InitializeComponent();
            _frmChildBase = this;
        }

    #endregion

    #region Variables

        private bool
            _SaveAccess
            , _ChangeAccess
            , _DeleteAccess
            , _NewAccess
            , _PrintAccess
            ;

        #endregion

        #region Propertise

        private static frmChildBase _frmChildBase = null;
        public static frmChildBase Instanc
        {
            get
            {
                if (_frmChildBase == null)
                    _frmChildBase = new frmChildBase();

                return _frmChildBase;
            }
        }

        public bool SaveAccess
        {
            get
            {
                return _SaveAccess;
            }
            set
            {
                _SaveAccess = value;
            }
        }

        public bool ChangeAccess
        {
            get
            {
                return _ChangeAccess;
            }
            set
            {
                _ChangeAccess = value;
            }
        }

        public bool DeleteAccess
        {
            get
            {
                return _DeleteAccess;
            }
            set
            {
                _DeleteAccess = value;
            }
        }

        public bool NewAccess
        {
            get
            {
                return _NewAccess;
            }
            set
            {
                _NewAccess = value;
            }
        }

        public bool PrintAccess
        {
            get
            {
                return _PrintAccess;
            }
            set
            {
                _PrintAccess = value;
            }
        }

        protected bool isFormReadOnly = false;
        public bool IsFormReadOnly
        {
            get
            {
                return isFormReadOnly;
            }
            set
            {
                isFormReadOnly = value;
            }
        }

        public string FormCaption
        {
            get
            {
                return lblCaption.Text;
            }
            set
            {
                lblCaption.Text = value;
            }
        }

        public string FormMessage
        {
            get
            {
                return lblMessage.Text;
            }
            set
            {
                lblMessage.Text = value;
            }
        }

        public Image FormLogo
        {
            get
            {
                return pictureBox1.Image;
            }
            set
            {
                pictureBox1.Image = value;
            }
        }

        private int _formItemID;
        public int FormItemID
        {
            get
            {
                return _formItemID;
            }
            set
            {
                _formItemID = value;
            }
        }

        Baran.Common.frmFilter.stcProperty[] _arrFilterProperties;
        public Baran.Common.frmFilter.stcProperty[] arrFilterProperties
        {
            get
            {
                return _arrFilterProperties;
            }
            set
            {
                _arrFilterProperties = value;
            }
        }

        Baran.Common.frmFilterNew.stcProperty[] _arrFilterPropertiesNew;
        public Baran.Common.frmFilterNew.stcProperty[] arrFilterPropertiesNew
        {
            get
            {
                return _arrFilterPropertiesNew;
            }
            set
            {
                _arrFilterPropertiesNew = value;
            }
        }

    #endregion

    #region Method

        public virtual void OnActiveForm()
        {
            
        }

        public virtual void OnNext()
        {
            this.RefreshForm();
        }

        public virtual void OnPrevious()
        {
            this.RefreshForm();
        }

        public virtual void OnFirstRecord()
        {
            this.RefreshForm();
        }

        public virtual void OnLastRecord()
        {
            this.RefreshForm();
        }

        public virtual void OnNumberOfRecordsKeyPress()
        {
        }

        public virtual void OnRefresh()
        {
            this.RefreshForm();

            // set focus to the first control
            SelectNextControl(null,true, true, true, true);
            ShowMainProgress();
        }

        public virtual void OnSave()
        {
            this.RefreshForm();            
        }

        public virtual void OnCancel()
        {
        }

        public virtual void OnChange()
        {
            this.RefreshForm();
            //ShowMainProgress();
        }

        public virtual void OnDelete()
        {
            this.RefreshForm();
        }

        public virtual void OnPrint()
        {
            this.RefreshForm();
        }

        public virtual void OnExit()
        {
        }

        public virtual void OnConfirm()
        {
            this.RefreshForm();
            ShowMainProgress();
        }

        public virtual void OnClear()
        {
            this.RefreshForm();

            // set focus to the first control
            SelectNextControl(null, true, true, true, true);
        }

        public virtual void OnNew()
        {
            this.RefreshForm();
            ShowMainProgress();
        }

        public virtual void OnCash()
        {
            this.RefreshForm();
        }

        public virtual void OnElectronic()
        {
            this.RefreshForm();
        }

        public virtual void OnCheque()
        {
            this.RefreshForm();
        }

        public virtual void OnPos()
        {
            this.RefreshForm();
        }

        public virtual void OnClearMessage()
        {
            this.FormMessage = string.Empty;
        }

        public virtual void OnformLoad()
        {
            this.RefreshForm();
            ShowMainProgress();
        }

        public virtual void OnDetail()
        {
            this.RefreshForm();
            ShowMainProgress();
        }

        public virtual void OnView()
        {
            ShowMainProgress();
        }

        public virtual void OnExport(Baran.Windows.Forms.UltraGrid grdItem)
        {
            //ShowMainProgress();
          

            //System.IO.Stream myStream;
            SaveFileDialog sfdSaveFileDialog = new SaveFileDialog();
            DialogResult msgResult;

            sfdSaveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //sfdSaveFileDialog.AddExtension = true;
            //sfdSaveFileDialog.Filter = "Excel file (*.xls, *.xlsx)|*.xls;*.xlsx";

            


//dlg.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png|Tiff Image (.tiff)|*.tiff|Wmf Image (.wmf)|*.wmf";
            sfdSaveFileDialog.Filter = "Excel file (*.xls, *.xlsx)|*.xls;*.xlsx| pdf File (.pdf)| *.Pdf";
           
            if (sfdSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //    if ((myStream = sfdSaveFileDialog.OpenFile()) != null)
                //    {
                waitForm.Show();
                string myfileName = sfdSaveFileDialog.FileName;


                switch (sfdSaveFileDialog.FilterIndex)
                {
                    case 1:
                        ultraGridExcelExporter1.Export(grdItem, myfileName);
                        break;
                    case 2:
                        ultraGridDocumentExporter1.Export(grdItem, myfileName, Infragistics.Win.UltraWinGrid.DocumentExport.GridExportFileFormat.PDF);
                        break;
                }



                waitForm.Close();
                msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgSaveAndOpenFile);
                if (msgResult == DialogResult.Yes)
                    System.Diagnostics.Process.Start(myfileName);
                //myStream.Close();
                //    }
               
            }

            

        }

        public virtual void OnExport(Baran.Windows.Forms.UltraGrid2 ugItems)
        {
            //ShowMainProgress();

            //System.IO.Stream myStream;
            SaveFileDialog sfdSaveFileDialog = new SaveFileDialog();
            DialogResult msgResult;

            sfdSaveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //sfdSaveFileDialog.AddExtension = true;
            //sfdSaveFileDialog.Filter = "Excel file (*.xls, *.xlsx)|*.xls;*.xlsx";




            //dlg.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png|Tiff Image (.tiff)|*.tiff|Wmf Image (.wmf)|*.wmf";
            sfdSaveFileDialog.Filter = "Excel file (*.xls, *.xlsx)|*.xls;*.xlsx| pdf File (.pdf)| *.Pdf";

            if (sfdSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //    if ((myStream = sfdSaveFileDialog.OpenFile()) != null)
                //    {
                waitForm.Show();
                string myfileName = sfdSaveFileDialog.FileName;


                switch (sfdSaveFileDialog.FilterIndex)
                {
                    case 1:
                        ultraGridExcelExporter1.Export(ugItems, myfileName);
                        break;
                    case 2:
                        ultraGridDocumentExporter1.Export(ugItems, myfileName, Infragistics.Win.UltraWinGrid.DocumentExport.GridExportFileFormat.PDF);
                        break;
                }



                waitForm.Close();
                msgResult = MessageBoxX.ShowMessageBox(PublicEnum.EnmMessageType.msgSaveAndOpenFile);
                if (msgResult == DialogResult.Yes)
                    System.Diagnostics.Process.Start(myfileName);
                //myStream.Close();
                //    }

                
            }



        }

        private void AccessLevel()
        {
            BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectDataTable tblAccessLevel =
                new BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectDataTable();
            BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectRow drwAccessLevel;
            string strFilter = "ItemID = " + FormItemID;

            try
            {
                tblAccessLevel = Baran.Classes.Common.AccessibleItemsForCurrentUser.Instance.tblAccessibleItems;

                drwAccessLevel = (BaranDataAccess.Security.dstSecurity.spr_AccessibleItemsForCurrentUser_SelectRow)tblAccessLevel.Select(strFilter, "")[0];

                SaveAccess = drwAccessLevel.IsbitSaveNull() ? false : drwAccessLevel.bitSave;
                ChangeAccess = drwAccessLevel.IsbitChangeNull() ? false : drwAccessLevel.bitChange;
                DeleteAccess = drwAccessLevel.IsbitDeleteNull() ? false : drwAccessLevel.bitDelete;
                NewAccess = drwAccessLevel.IsbitNewNull() ? false : drwAccessLevel.bitNew;
                PrintAccess = drwAccessLevel.IsbitPrintNull() ? false : drwAccessLevel.bitPrint;

                //int grpHeaderColor1 = drwAccessLevel.IsPackageFormsHeaderColor1Null() ? System.Drawing.Color.LightSkyBlue.ToArgb() : drwAccessLevel.PackageFormsHeaderColor1;
                //int grpHeaderColor2 = drwAccessLevel.IsPackageFormsHeaderColor2Null() ? System.Drawing.Color.White.ToArgb() : drwAccessLevel.PackageFormsHeaderColor2;

                //this.grpHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(grpHeaderColor1);
                //this.grpHeader.Appearance.BackColor2 = System.Drawing.Color.FromArgb(grpHeaderColor2);

                //BaranLibrary.GeneralProperties.HeaderColor1 = grpHeaderColor1;
                //BaranLibrary.GeneralProperties.HeaderColor2 = grpHeaderColor2;

                if (PublicVariables.IsFiscalYearClose)
                {
                    SaveAccess = false;
                    ChangeAccess = false;
                    DeleteAccess = false;
                }
            }
            catch
            { }
        }

        public virtual string OnMakesWhereClause()
        {
            return string.Empty;
        }

        public virtual Boolean OnFilter(params string[] FilterPropertyKey)
        {
            //   Protected P_stcProperties() As frmFilter.stcProperty

            string strWhereClause = string.Empty;
            Boolean blnReturnValue = true;

            //Baran.Common.frmFilter ofrmFilter = new Baran.Common.frmFilter();
            Baran.Common.frmFilterNew ofrmFilter = new Baran.Common.frmFilterNew();

            //PublicMethods.SetFormSchema(ofrmFilter, ofrmFilter.FormItemID);

            ofrmFilter.CurrentChaildFormProperty(FilterPropertyKey);


            ofrmFilter.ShowDialog();
            //if (ofrmFilter.ShowDialog() == DialogResult.Cancel)
            //{
            //    ofrmFilter.Dispose();
            //    blnReturnValue = false;
            //    return false;
            //}

            //arrFilterProperties = ofrmFilter.arrFilterProp;
            arrFilterPropertiesNew = ofrmFilter.arrFilterProp;

            if (ofrmFilter.FilterIsOn)
                strWhereClause = OnMakesWhereClause();
            else
                strWhereClause = string.Empty;
            //            ChildForm frmMyChild = new ChildForm();
            //            frmChild.btnClickMeToo.Click += new
            //EventHandler(frmMain.btnClickMe_Click);

            return blnReturnValue;
        }

        private void RefreshForm()
        {
            try
            {
                this.FormMessage = string.Empty;
                lblMessage.Visible = false;
                //grpMessage.Visible = false;

                //frmMain ofrm = frmMain.Instanc;
                //frmChildBase ofrmmm = frmChildBase.Instanc;
                ////this.lblMessage.Text = "sdfasdfa";
                
                //foreach (Baran.Base_Forms.frmChildBase frmChild in ofrm.MdiChildren)
                //{
                //    frmChild.lblMessage.Text = "dsfsf"; // string.Empty;
                //}



                //!!!!!!!!!!!
                //ShowMainProgress();
            }
            catch { }
        }

        //private void ShowProgressBar()
        //{
        //    string strFileName;
        //    strFileName = PublicMethods.PictureFileNamePath(cnsPictureName.ProgressBar);

        //    //picProgressBar.Image = Image.FromFile(strFileName);

        //    Application.Idle += OnLoaded;
        //}
        Baran.Classes.Common.WaiteForm waitForm = new WaiteForm();
        public void ShowMainProgress()
        {
            //frmMain ofrm = frmMain.Instanc;
            //ofrm.toolStripMain.Items[cnsToolStripButton.ProgressBar].Visible = true;
            waitForm.Show();
            System.Threading.Thread othread = new System.Threading.Thread(ShowMainProgress);
            othread.Start();
            //ofrm.usbMainStatusBar.Panels[8].Visible = true;
            //ofrm.usbMainStatusBar.Panels[8].ProgressBarInfo.Value = 10000;
            ////ofrm.usbMainStatusBar.Panels[8].ProgressBarInfo.Value = 0;
            ////ofrm.usbMainStatusBar.Panels[8].Visible = false;
            //System.Windows.Forms.Application.Idle += OnLoaded;



            System.Windows.Forms.Application.Idle += OnLoaded;
            othread.Abort();
   
        }

        private void OnLoaded(object sender, EventArgs e)
        {
            Application.Idle -= OnLoaded;
            //frmMain ofrm = frmMain.Instanc;
            ////System.Threading.Thread.Sleep(3000);
            ////ofrm.usbMainStatusBar.Panels[8].Visible = false;
            //ofrm.toolStripMain.Items[cnsToolStripButton.ProgressBar].Visible = false;
            waitForm.Close();

        }

        public void OnMessage(string message, Baran.Classes.Common.PublicEnum.EnmMessageCategory msgCategory)
        {
            if (msgCategory == PublicEnum.EnmMessageCategory.Danger)
            {
                lblMessage.Appearance.BackColor = System.Drawing.Color.FromArgb(244,  67, 54);   
            }
            else if (msgCategory == PublicEnum.EnmMessageCategory.Info)
            {
                lblMessage.Appearance.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);  
            }
            else if (msgCategory == PublicEnum.EnmMessageCategory.Success)
            {
                lblMessage.Appearance.BackColor = System.Drawing.Color.FromArgb(132, 183, 82);//.FromArgb(244, 67, 54);  
            }
            else if (msgCategory == PublicEnum.EnmMessageCategory.Warning)
            {
                lblMessage.Appearance.BackColor = System.Drawing.Color.FromArgb(255, 152, 0);  
            }


            lblMessage.Text = message;
            lblMessage.Appearance.ForeColor = System.Drawing.Color.Black;
            lblMessage.Visible = true;
            grpMessage.Visible = true;
            tmrTimer.Enabled = false;
            tmrTimer.Enabled = true;
            tmrTimer.Interval = 10000;
            
        }

        public virtual void OnDoc(int? companyID, int? collectionID, int? subcollectionID, int? partID, int? landID, int? fieldID, int? warehouseID, int? buildingID, int? machineryID, int? waterID, int? waterStorageID, int? waterTransmissionLineID)
        {
            this.RefreshForm();
            ShowMainProgress();

            Baran.Common.frmDocument ofrm = new Common.frmDocument();
            //Baran.Common.frmDocument ofrm = Baran.Common.frmDocument.Instanc;

            ofrm.FormItemID = Convert.ToInt32(PublicEnum.EnmformItemId.Document);
            if (PublicMethods.SetFormSchema(ofrm, ofrm.FormItemID))
            {
                ofrm.CompanyID = companyID;
                ofrm.CollectionID = collectionID;
                ofrm.SubcollectionID = subcollectionID;
                ofrm.PartID = partID;
                ofrm.LandID = landID;
                ofrm.FieldID = fieldID;
                ofrm.WarehouseID = warehouseID;
                ofrm.BuildingID = buildingID;
                ofrm.MachineryID = machineryID;
                ofrm.WaterID = waterID;
                ofrm.WaterStorageID = waterStorageID;
                ofrm.WaterTransmissionLineID = waterTransmissionLineID;

                ofrm.FormType = cnsFormType.New;
                ofrm.ShowDialog();
            }
        }

        #endregion

    #region Events

        private void lblMessage_TextChanged(object sender, EventArgs e)
        {

            //if (lblMessage.Tag == null)
            //    lblMessage.Appearance.ForeColor = System.Drawing.Color.Blue;
            //else
            //    lblMessage.Appearance.ForeColor = System.Drawing.Color.YellowGreen;

            //if (lblMessage.Tag == null)
            //    lblMessage.Tag = 1;
            //else
            //    lblMessage.Tag = null;
        }

        private void frmChildBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

            //Control nextControl = null;
            //if (e.KeyCode == Keys.Enter)
            //{
            //    SendKeys.Send("{TAB}");
            //    //nextControl = GetNextControl(ActiveControl, true);
            //    //if (nextControl == null)
            //    //{
            //    //    nextControl = GetNextControl(null, true);
            //    //}
            //    //nextControl.Focus();
            //}

            //else if (e.KeyCode == Keys.Right)
            //{
            //    nextControl = GetNextControl(ActiveControl, true);
            //    if (nextControl == null)
            //    {
            //        nextControl = GetNextControl(null, true);
            //    }
            //    nextControl.Focus();
            //    //Finally - it suppresses the Enter Key
            //    //e.SuppressKeyPress = true;
            //}
            //else if (e.KeyCode == Keys.Left)
            //{
            //    nextControl = GetNextControl(ActiveControl, false);
            //    if (nextControl == null)
            //    {
            //        nextControl = GetNextControl(null, true);
            //    }
            //    nextControl.Focus();
            //    //Finally - it suppresses the Enter Key
            //    //e.SuppressKeyPress = true;
            //}



            ////Control nextControl;
            ////Checks if the Enter Key was Pressed
            //if (e.KeyCode == Keys.Enter)
            //{
            //    //If so, it gets the next control and applies the focus to it
            //    //nextControl = GetNextControl(ActiveControl, !e.Shift);
            //    if (nextControl == null)
            //    {
            //        nextControl = GetNextControl(null, true);
            //    }
            //    nextControl.Focus();
            //    //Finally - it suppresses the Enter Key
            //    e.SuppressKeyPress = true;
            //}
        }

        private void frmChildBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.OnCancel();
        }

        private void frmChildBase_Activated(object sender, EventArgs e)
        {
            this.OnActiveForm();
        }

        private void frmChildBase_Deactivate(object sender, EventArgs e)
        {

            Baran.frmMain ofrmMain = Baran.frmMain.Instanc;

            ofrmMain.DisableAllToolbarItems();
            ofrmMain.DisableAllMenuStripItems();
        }

        private void frmChildBase_Load(object sender, EventArgs e)
        {
            this.AccessLevel();
            OnformLoad();
     
        }

        private void btnMaxMin_Click(object sender, EventArgs e)
        {
            if (this.MdiParent != null)
            {
                this.IsMdiContainer = false;
                this.MdiParent = null;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                frmMain ofrm = frmMain.Instanc;
                this.MdiParent = ofrm;
            }
        }

        private void tmrTimer_Tick(object sender, EventArgs e)
        {
            //grpMessage.Visible = false;
            lblMessage.Text = string.Empty;
            lblMessage.Visible = false;
            //grpMessage.Visible = false;

            tmrTimer.Enabled = false;
            ControlsSetting.RemovePictureMessage();
        }

    #endregion

        private void grpHeader_Click(object sender, EventArgs e)
        {

        }

    }
}
