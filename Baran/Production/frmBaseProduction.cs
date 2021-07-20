using Baran.Classes.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baran.Production
{
    public partial class frmBaseProduction : Form
    {
        #region Constractor

        public frmBaseProduction(int productionID)
        {
            ProductionID = productionID;
            InitializeComponent();

      }

        #endregion

        #region Variables

        #endregion

        #region Propertise


        private int _productionID;
        public int ProductionID
        {
            get
            {
                return _productionID;
            }
            set
            {
                _productionID = value;
            }
        }


        private string _cption = null;
        public string Caption
        {
            get
            {
                return _cption;
            }
            set
            {
                _cption = value;
            }
        }

        #endregion

        #region Methods
        private void ProductionField()
        {

            if (ProductionID <= 0)
            {
                //OnMessage(BaranResources.NoRowSelectedError, PublicEnum.EnmMessageCategory.Warning);
                return;
            }
            frmProductionFieldLink ofrm = new frmProductionFieldLink(ProductionID);

            //ofrm.FormItemID = Convert.ToInt32(PublicEnum.EnmformItemId.Field);
            //if (PublicMethods.SetFormSchema(ofrm, ofrm.FormItemID))
            //{
            if (PublicPropertise.ProductionInUpate)
                ofrm.FormType = cnsFormType.Change;
            else
                ofrm.FormType = cnsFormType.New;

            if (CheckFormExist(ofrm.Name) == false)
            {
                ofrm.MdiParent = this;
                ofrm.Show();
            }
            //}
        }

        private void ProductionCropAndCultivar()
        {
            
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            PublicPropertise.ProductionID = 0;
            PublicPropertise.ProductionFieldID = 0;
            PublicPropertise.CropID = 0;
        }
        #endregion

        #region Events

        #endregion

        private void btnFields_Click(object sender, EventArgs e)
        {
            this.ProductionField();
        }

        private bool CheckFormExist(string strFormName)
        {
            bool blnResult = false;

            foreach (var frmChild in this.MdiChildren)
            {
                if (frmChild.Name == strFormName)
                {
                    if (frmChild.Visible == true)
                    {
                        frmChild.Focus();
                        blnResult = true;
                    }
                    else
                    {
                        frmChild.Close();
                        blnResult = false;
                    }
                }
            }
            return blnResult;
        }

        private void btnCropAndCultivar_Click(object sender, EventArgs e)
        {
            if (ProductionID <= 0)
            {
                //OnMessage(BaranResources.NoRowSelectedError, PublicEnum.EnmMessageCategory.Warning);
                return;
            }

            //if (PublicPropertise.ProductionFieldID <= 0)
            //{
            //    MessageBox.Show("Field link not set yet");
            //    return;
            //}
            Baran.Production.frmProductionCultivarLink ofrm = new frmProductionCultivarLink();
            
            //ofrm.FormItemID = Convert.ToInt32(PublicEnum.EnmformItemId.Field);
            //if (PublicMethods.SetFormSchema(ofrm, ofrm.FormItemID))
            //{
            if(CheckFormExist(ofrm.Name) == false)
            {
                ofrm.MdiParent = this;
                ofrm.FormType = cnsFormType.New;
                ofrm.Show();
            }
            //}
        }

        private void btnSeasons_Click(object sender, EventArgs e)
        {

            Baran.Production.frmProductionSeasonLink ofrm = new frmProductionSeasonLink();
            if (CheckFormExist(ofrm.Name) == false)
            {
                ofrm.MdiParent = this;
                ofrm.WindowState = FormWindowState.Maximized;
                ofrm.Show();
            }
        }

        private void btnTasks_Click(object sender, EventArgs e)
        {
            this.ProductionTaskList();
        }

        private void ProductionTaskList()
        {
            Baran.Production.frmProductionTaskList ofrm = new frmProductionTaskList();
            if (CheckFormExist(ofrm.Name) == false)
            {
                ofrm.MdiParent = this;
                ofrm.WindowState = FormWindowState.Maximized;
                ofrm.Show();
            }
        }

        private void frmBaseProduction_FormClosed(object sender, FormClosedEventArgs e)
        {
            PublicPropertise.ProductionID = 0;
            PublicPropertise.ActivityID = 0;
            PublicPropertise.ProductionInUpate = false;
        }

        private void frmBaseProduction_Load(object sender, EventArgs e)
        {
            if (PublicPropertise.ProductionInUpate)
            {
                this.ProductionTaskList();
            }
            else
                this.ProductionField();

            lblCaption.Text = Caption;
        }
    }
}
