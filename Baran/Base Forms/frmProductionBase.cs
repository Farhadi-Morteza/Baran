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

namespace Baran.Base_Forms
{
    public partial class frmProductionBase : Form
    {
        public frmProductionBase()
        {
            InitializeComponent();
        }

        public virtual void OnformLoad()
        {
        }

        public virtual void OnClearMessage()
        {
            this.lblMessage.Text = string.Empty;
        }

        public void OnMessage(string message, Baran.Classes.Common.PublicEnum.EnmMessageCategory msgCategory)
        {
            if (msgCategory == PublicEnum.EnmMessageCategory.Danger)
            {
                lblMessage.Appearance.BackColor = System.Drawing.Color.FromArgb(244, 67, 54);
            }
            else if (msgCategory == PublicEnum.EnmMessageCategory.Info)
            {
                lblMessage.Appearance.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            }
            else if (msgCategory == PublicEnum.EnmMessageCategory.Success)
            {
                lblMessage.Appearance.BackColor = System.Drawing.Color.FromArgb(1, 132, 183, 82);//.FromArgb(244, 67, 54);  
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

        private void frmProductionBase_Load(object sender, EventArgs e)
        {
            this.OnformLoad();
        }

    }
}
