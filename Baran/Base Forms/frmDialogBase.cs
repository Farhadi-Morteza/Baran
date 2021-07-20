
namespace Baran.Base_Forms
{
    public partial class frmDialogBase : System.Windows.Forms.Form
    {
        public System.Drawing.Image FormLogo
        {
            get
            {
                return pibFormpicture.Image;
            }
            set
            {
                pibFormpicture.Image = value;
            }
        }
        public string Caption
        {
            get
            {
                return lblCaption.Text;
            }
            set
            {
                lblCaption.Text = value;
                this.Text = value;
            }
        }
        public frmDialogBase()
        {
            InitializeComponent();
        }

        private void frmDialogBase_Load(object sender, System.EventArgs e)
        {

        }
    }
}
