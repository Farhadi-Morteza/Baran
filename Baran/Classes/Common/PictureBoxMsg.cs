using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaranDataAccess.Common;

namespace Baran.Classes.Common
{

    public class PictureBoxMsg
    {
       private static PictureBoxMsg _instance;
        public static PictureBoxMsg Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PictureBoxMsg();

                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        private PictureBoxMsg()
        {
            _picBoxX = new Windows.Forms.PictureBox();
 
        }


        private Baran.Windows.Forms.PictureBox _picBoxX;
        public Baran.Windows.Forms.PictureBox PicBoxX
        {
            get
            {
                return _picBoxX;
            }
            set
            {
                _picBoxX = value;
            }
        }
    }
}
