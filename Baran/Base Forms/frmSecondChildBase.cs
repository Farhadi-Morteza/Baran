using Baran.Classes.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Baran.Base_Forms
{
    public partial class frmSecondChildBase : Baran.Base_Forms.frmChildBase
    {


        #region Constractor

        public frmSecondChildBase()
        {
            InitializeComponent();
            //this.SetControlsImage();
        }

        #endregion

        #region Variables

        #endregion

        #region Propertise

        private int _formType;
        public int FormType
        {
            get
            {
                return _formType;
            }
            set
            {
                _formType = value;
            }
        }

        #endregion

        #region Methods

        public override void OnformLoad()
        {
            base.OnformLoad();
        }

        public void SetControlsImage()
        {
            try
            {
                //this.btnClose.BackgroundImage = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Close));
                btnRefresh.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.refresh16));
                this.btnCancle.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Cancel16));
                btnChange.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Change16));
                btnSave.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Save16));
                btnClear.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.clear16));
                //btnNew.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.New16));
                btnDelete.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.delete16));
                btnPrint.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.printer16));
                btnDoc.Image = System.Drawing.Image.FromFile(PublicMethods.PictureFileNamePath(cnsPictureName.Doc16));


            }
            catch
            {

                throw;
            }
        }

        public void EnableButtons(params string[] controls)
        {
            this.SetControlsImage();
            foreach (var btn in controls)
            {
                //grpButons.Controls[btn].Visible = true;
                grpButons.Controls[btn].BringToFront();
            }
        }

        #endregion

        #region Events

        private void frmSecondChildBase_Load(object sender, EventArgs e)
        {
            if (FormType == cnsFormType.New)
            {
                grpChange.Visible = false;
                grpDelete.Visible = false;
                mnuChange.Enabled = false;
                mnuDelete.Enabled = false;
            }
            else if (FormType == cnsFormType.Change)
            {
                grpSave.Visible = false;
                mnuSave.Enabled = false;
            }
        }

        #endregion

        #region ButtonsEvents

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OnSave();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            OnChange();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            OnClear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            OnDelete();
        }

        private void btnDoc_Click(object sender, EventArgs e)
        {
            OnDoc(null, null, null, null, null,null, null, null, null, null, null, null);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            OnPrint();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            OnRefresh();
        }

        #endregion

        #region MenuStripEvents

        private void mnuCansel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            OnSave();
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            OnDelete();
        }

        private void mnuChange_Click(object sender, EventArgs e)
        {
            OnChange();
        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            OnNew();
        }

        private void mnuClear_Click(object sender, EventArgs e)
        {
            OnClear();
        }

        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            OnRefresh();
        }

        private void mnuConfirm_Click(object sender, EventArgs e)
        {
            OnConfirm();
        }

        private void mnuDoc_Click(object sender, EventArgs e)
        {
            OnDoc(null, null, null, null,null, null, null, null, null, null, null, null);
        }
        
        #endregion

          private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            //btnSave.ForeColor = System.Drawing.Color.FromArgb(1, 132, 183, 82);
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            //btnSave.ForeColor = System.Drawing.Color.White;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            OnNew();
        }
    }
}
