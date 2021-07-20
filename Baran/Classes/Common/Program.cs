
namespace Baran
{
    static class Program
    {
        [System.STAThread]
        static void Main()
        {

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fa-IR");
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            Baran.frmMain frmMain = new Baran.frmMain();
            //Baran.Main.frmMainNew frmMain = new Main.frmMainNew();
            System.Windows.Forms.Application.Run(frmMain);
            frmMain.Dispose();
            frmMain = null;


        }
    }
}
