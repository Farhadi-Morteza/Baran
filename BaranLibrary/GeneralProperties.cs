using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaranLibrary
{
    static public class GeneralProperties
    {
        private static System.Drawing.Color _baseColor;
        public static System.Drawing.Color BaseColor
        {
            get
            {
                return _baseColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(48)))), ((int)(((byte)(61)))));
            }
            set
            {
                _baseColor = value;
            }
        }

        private static System.Drawing.Color _secondBaseColor;
        public static System.Drawing.Color SecondBaseColor
        {
            get
            {
                return _secondBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(94)))), ((int)(((byte)(112)))));
            }
            set
            {
                _secondBaseColor = value;
            }
        }

        private static System.Drawing.Color _baseColor2;
        public static System.Drawing.Color BaseColor2
        {
            get
            {
                return _baseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(179)))), ((int)(((byte)(4)))));
            }
            set
            {
                _baseColor2 = value;
            }
        }

        private static int _HeaderColor1;
        public static int HeaderColor1
        {
            get
            {
                return _HeaderColor1;
            }
            set
            {
                _HeaderColor1 = value;
            }
        }

        private static int _HeaderColor2;
        public static int HeaderColor2
        {
            get
            {
                return _HeaderColor2;
            }
            set
            {
                _HeaderColor2 = value;
            }

        }

        private static System.Drawing.Color _ControlNewBackColor;
        public static System.Drawing.Color ControlNewBackColor
        {
            get
            {
                return _ControlNewBackColor = System.Drawing.Color.LightSkyBlue;//.Transparent;////.Honeydew;//.LightGray;//
            }
            set
            {
                _ControlNewBackColor = value;
            }
        }

        private static System.Drawing.Color _ControlPreviousBackColor;
        public static System.Drawing.Color ControlPreviousBackColore
        {
            get
            {
                return _ControlPreviousBackColor;
            }
            set
            {
                _ControlPreviousBackColor = value;
            }
        }

        private static System.Drawing.Color _ControlNewForeColor;
        public static System.Drawing.Color ControlNewForeColor
        {
            get
            {
                return _ControlNewForeColor = System.Drawing.Color.DarkBlue;//.DarkGreen;//.Black;//
            }
            set
            {
                _ControlNewForeColor = value;
            }
        }

        private static System.Drawing.Color _ControlPreviousForeColor;
        public static System.Drawing.Color ControlPreviousForeColore
        {
            get
            {
                return _ControlPreviousForeColor;
            }
            set
            {
                _ControlPreviousForeColor = value;
            }
        }

        private static System.Drawing.Color _ControlNewBorderColor;
        public static System.Drawing.Color ControlNewBorderColor
        {
            get
            {
                return _ControlNewBorderColor = System.Drawing.Color.DeepSkyBlue;//.DarkGreen;//.Black;//
            }
            set
            {
                _ControlNewBorderColor = value;
            }
        }

        private static System.Drawing.Color _ControlPreviousBorderColor;
        public static System.Drawing.Color ControlPreviousBorderColore
        {
            get
            {
                return _ControlPreviousBorderColor;
            }
            set
            {
                _ControlPreviousBorderColor = value;
            }
        }

        ///////////////////////////////////////////////////////////////////////////
        private static System.Drawing.Color _baseBorderColor = System.Drawing.Color.LightGray;
        public static System.Drawing.Color BaseBorderColor
        {
            get
            {
                return _baseBorderColor;
            }
            set
            {
                _baseBorderColor = value;
            }
        }

        private static System.Drawing.Color _onEnterBorderColor = BaseColor2;// System.Drawing.Color.DeepSkyBlue;
        public static System.Drawing.Color OnEnterBorderColor
        {
            get
            {
                return _onEnterBorderColor;
            }
            set
            {
                _onEnterBorderColor = value;
            }
        }

        private static System.Drawing.Color _baseControlForeColor = System.Drawing.Color.White;
        public static System.Drawing.Color BaseControlForeColor
        {
            get
            {
                return _baseControlForeColor;
            }
            set
            {
                _baseControlForeColor = value;
            }
        }

        private static System.Drawing.Color _onEnterControlForeColor = System.Drawing.Color.White;
        public static System.Drawing.Color OnEnterControlForeColor
        {
            get
            {
                return _onEnterControlForeColor;
            }
            set
            {
                _onEnterControlForeColor = value;
            }
        }

        
       
    }
}
