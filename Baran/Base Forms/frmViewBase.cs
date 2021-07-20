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
    public partial class frmViewBase : Form
    {
        public frmViewBase()
        {
            InitializeComponent();
        }


        public virtual void OnformLoad()
        {
           
        }

        public virtual void OnCancel()
        {
            this.Close();
        }

        private void frmViewBase_Load(object sender, EventArgs e)
        {
            OnformLoad();
        }

        private void frmViewBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.F12)
            {
                this.OnCancel();
            }
        }

        private void frmViewBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.OnCancel();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.OnCancel();
        }

        private void frmViewBase_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keys)e.KeyCode == Keys.F12)
            {
                this.OnCancel();
            }
        }
    }
}
