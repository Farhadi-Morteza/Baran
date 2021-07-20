using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Baran.Classes.Common
{
    public static class ControlsSetting
    {

        private static Dictionary<Type, Action<Control>> controldefaults = new Dictionary<Type, Action<Control>>() 
        { 
            {typeof(TextBox), c => ((TextBox)c).Clear()},
            {typeof(CheckBox), c => ((CheckBox)c).Checked = false},
            {typeof(ListBox), c => ((ListBox)c).Items.Clear()},
            {typeof(RadioButton), c => ((RadioButton)c).Checked = false},
            {typeof(GroupBox), c => ((GroupBox)c).Controls.Clear()},
            {typeof(Panel), c => ((Panel)c).Controls.Clear()},
            {typeof(Baran.Windows.Forms.UltraMaskedEdit),c => ((Baran.Windows.Forms.UltraMaskedEdit)c).Controls.Clear()},
            {typeof(Baran.Windows.Forms.UltraComboEditor),c => ((Baran.Windows.Forms.UltraComboEditor)c).Controls.Clear()},
            {typeof(BaranLibrary.MaskedDate),c => ((BaranLibrary.MaskedDate)c).Controls.Clear()}
        };

        public static void ClearControls(this Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {

                if (control is TextBox)
                {
                    control.Text = string.Empty;
                }
                else if (control is Baran.Windows.Forms.TextBox)
                {
                    control.Text = string.Empty;
                }
                else if (control is ComboBox)
                {
                    ComboBox cmbComboBox = (ComboBox)control;
                    if (cmbComboBox != null)
                    {
                        cmbComboBox.Text = string.Empty;
                        cmbComboBox.SelectedIndex = -1;
                    }
                }
                else if (control is Baran.Windows.Forms.UltraMaskedEdit)
                {
                    control.Text = string.Empty; // control.Tag == null ? "":control.Tag.ToString(); // 
                }
                else if (control is Baran.Windows.Forms.UltraComboEditor)
                {
                    control.Text = "";
                }

                else if (control is BaranLibrary.MaskedDate)
                {
                    control.Text = FarsiLibrary.Utils.PersianDate.Now.ToString();
                }

                else if (control is Baran.Windows.Forms.CheckBox.CheckBox)
                {
                    //control. = false;
                }

                else if (control is Baran.Windows.Forms.UltraMaskedDate)
                {
                    control.Text = null;
                }
            }
        }

        public static void AddPictureMessage(this Control prmControl, int prmPictureMessageType, int prmPictureMessagePosition)
        {
            int
                SizeX
                , SizeY
                , LocationX
                , LocationY
                ;
            try
            {

                string strFileName = string.Empty;

                SizeX = prmControl.Size.Width;
                SizeY = SizeX;

                if (prmPictureMessagePosition == cnsPictureMessagePosition.Right)
                {
                    LocationX = prmControl.Location.X + SizeX + 2;
                    LocationY = prmControl.Location.Y + 4;
                }
                else
                {
                    LocationX = prmControl.Location.X - SizeX + 2;
                    LocationY = prmControl.Location.Y + 4;
                }

                Control cntParent = prmControl.Parent;

                if (PictureBoxMsg.Instance.PicBoxX.Tag != null)
                    PictureBoxMsg.Instance = null;

                if (prmPictureMessageType == cnsPictureMessageType.Success)
                    PictureBoxMsg.Instance.PicBoxX.Tag = 1;
                else
                    PictureBoxMsg.Instance.PicBoxX.Tag = null;


                if (prmPictureMessageType == cnsPictureMessageType.Error)
                    strFileName = PublicMethods.PictureFileNamePath(cnsPictureName.picError16);
                else if (prmPictureMessageType == cnsPictureMessageType.Success)
                    strFileName = PublicMethods.PictureFileNamePath(cnsPictureName.picSuccess16);
                else if (prmPictureMessageType == cnsPictureMessageType.Information)
                    strFileName = PublicMethods.PictureFileNamePath(cnsPictureName.picInformation16);
                else if (prmPictureMessageType == cnsPictureMessageType.Warning)
                    strFileName = PublicMethods.PictureFileNamePath(cnsPictureName.picWarning16);

                //Baran.Windows.Forms.PictureBox pp = PictureBoxMsg.Instance.PicBoxX;
                Baran.Windows.Forms.PictureBox pp = new Windows.Forms.PictureBox();

                pp.ClientSize = new System.Drawing.Size(24, 24);
                pp.Location = new System.Drawing.Point(LocationX, LocationY);



                pp.Image = System.Drawing.Image.FromFile(strFileName);
                pp.BringToFront();

                cntParent.Controls.Add(pp);
                pp.BringToFront();
                pp.BackColor = System.Drawing.Color.Transparent;
            }
            catch { }

        }

        public static void RemovePictureMessage()
        {
    
            PictureBoxMsg.Instance = null;
        }

        public static void SetControlsFont(this Control.ControlCollection controls, string fontFamily)
        {
            try
            {
                foreach (Control control in controls)
                {
                    control.Font = new System.Drawing.Font(fontFamily, control.Font.Size);
                }
            }
            catch
            {
               
            }
        }

        public static void SetControlsFontSize(this Control.ControlCollection controls, string fontSize)
        {
            try
            {
                foreach (Control control in controls)
                {
                    control.Font = new System.Drawing.Font(control.Font.FontFamily, float.Parse(fontSize));
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public static void SetControlsBackColorTransparent(this Control.ControlCollection Controls, Control parentControl)
        {
            //foreach (Control control in Controls)
            //{
            //    control.BackColor = System.Drawing.Color.Transparent;
            //}
            for (int i = Controls.Count - 1; i>=0; i--)
            {
                string str = Controls[i].Name;
                Controls[i].BackColor = System.Drawing.Color.Transparent;
                Controls[i].Parent = parentControl;
            }
        }

   


}
}
