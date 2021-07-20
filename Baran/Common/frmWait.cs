using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baran.Common
{
    public partial class frmWait : Form
    {
        public frmWait()
        {
            InitializeComponent();
            //_frmWait = this;
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.BackColor = System.Drawing.Color.Fuchsia;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        //private static frmWait _frmWait = null;
        //public static frmWait Instanc
        //{
        //    get
        //    {
        //        if (_frmWait == null)
        //            _frmWait = new frmWait();

        //        return _frmWait;
        //    }
        //}

        public frmWait(Form parent)
        {
            InitializeComponent();
            if (parent != null)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(parent.Location.X + parent.Width / 2 - this.Width / 2, parent.Location.Y + parent.Height / 2 - this.Height / 2);
            }
            else
            {
                this.StartPosition = FormStartPosition.CenterParent;
            }
        }

        public void CloseLoadingForm()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
            if (label1.Image != null)
            {
                label1.Image.Dispose();
            }
        }
    }
}
