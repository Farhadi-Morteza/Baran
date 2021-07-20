using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Manina.Windows.Forms;

namespace Manina.Windows.Forms
{
    [System.Drawing.ToolboxBitmap(typeof(Manina.Windows.Forms.ImageListView))]
    public class imageListView : Manina.Windows.Forms.ImageListView
    {
        public imageListView()
        {
            //this.BackColor = this.Parent.BackColor;
            this.ForeColor = BaranLibrary.GeneralProperties.BaseControlForeColor;
            this.BackColor = BaranLibrary.GeneralProperties.SecondBaseColor;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;



            //System.Reflection.Assembly assembly = System.Reflection.Assembly.GetAssembly(typeof(ImageListView));
            //ImageListView.ImageListViewRenderer renderer = assembly.CreateInstance("Manina.Windows.Forms.ImageListViewRenderers+ZoomingRenderer") as ImageListView.ImageListViewRenderer;
            //this.SetRenderer(renderer);
            //this.Focus();
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Cursor = System.Windows.Forms.Cursors.Hand;
        }
    }

}



