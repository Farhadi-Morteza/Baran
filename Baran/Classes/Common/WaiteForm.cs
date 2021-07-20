using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace Baran.Classes.Common
{
    public class WaiteForm
    {
        Baran.Common.frmWait loadingForm;
        Thread loadthread;

        public void Show()
        {
            loadthread = new Thread(new ThreadStart(LoadingProcessEx));
            Thread.Sleep(200);
            loadthread.Start();
            Thread.Sleep(200);
        }
        /// <summary>
        /// 显示等待框
        /// </summary>
        /// <param name="parent">父窗体</param>
        public void Show(Form parent)
        {
            loadthread = new Thread(new ParameterizedThreadStart(LoadingProcessEx));
            loadthread.Start(parent);
        }
        public void Close()
        {
            try
            {
                if (loadingForm != null)
                {
                    //Application.UseWaitCursor = false;
                    //Cursor.Current = Cursors.Default;

                    loadingForm.BeginInvoke(new System.Threading.ThreadStart(loadingForm.CloseLoadingForm));
                    loadingForm = null;
                    loadthread = null;



                }
            }
            catch
            { }
        }
        private void LoadingProcessEx()
        {
            loadingForm = new Baran.Common.frmWait();// Baran.Common.frmWait.Instanc;// Baran.Common.frmWait.Instanc; 
   
            loadingForm.ShowDialog();
            //Application.UseWaitCursor = true;
            
        }
        private void LoadingProcessEx(object parent)
        {
            Form Cparent = parent as Form;
            loadingForm = new Baran.Common.frmWait(Cparent);

            loadingForm.ShowDialog();
            //Cursor.Current = Cursors.WaitCursor;
            //Application.UseWaitCursor = true;

        }
    }
}
