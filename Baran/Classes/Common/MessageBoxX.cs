using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Baran.Classes.Common
{
    class MessageBoxX
    {
        public static DialogResult ShowMessageBox(PublicEnum.EnmMessageType MessageType, [System.Runtime.InteropServices.Optional] string OptParam)
        {
            DialogResult Result;
            try
            {
                switch (MessageType)
                {

                    case PublicEnum.EnmMessageType.msgSaveConfirm:
                        Result = MessageBox.Show(BaranResources.SaveConfirm, "Save Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        break;

                    case PublicEnum.EnmMessageType.msgSaveFail:
                        Result = MessageBox.Show(BaranResources.SaveFail, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case PublicEnum.EnmMessageType.msgSaveSuccessful:
                        Result = MessageBox.Show(BaranResources.SaveSuccessful, "Sucsses Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case PublicEnum.EnmMessageType.msgSaveAndOpenFile:
                        Result = MessageBox.Show(BaranResources.SaveSuccessful + "   آیا فایل باز شود", "Save Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        break;

                    case PublicEnum.EnmMessageType.msgDeleteConfirm:
                        Result = MessageBox.Show(BaranResources.DeleteConfirm, "Delete Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                        break;

                    case PublicEnum.EnmMessageType.msgDeleteFail:
                        Result = MessageBox.Show(BaranResources.DeleteFail, "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case PublicEnum.EnmMessageType.msgDeleteSuccessful:
                        Result = MessageBox.Show(BaranResources.DeleteSuccessful, "Delete Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case PublicEnum.EnmMessageType.msgEditConfirm:
                        Result = MessageBox.Show(BaranResources.EditConfirm, "Update Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        break;

                    case PublicEnum.EnmMessageType.msgEditFail:
                        Result = MessageBox.Show(BaranResources.EditFail, "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case PublicEnum.EnmMessageType.msgEditSuccessful:
                        Result = MessageBox.Show(BaranResources.EditSuccessful, "Update Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case PublicEnum.EnmMessageType.msgDateInvalid:
                        Result = MessageBox.Show(BaranResources.DateInvalid, "DateInvalid Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case PublicEnum.EnmMessageType.msgRecordNotFound:
                        Result = MessageBox.Show(BaranResources.RecordNotFound, "Not Found Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case PublicEnum.EnmMessageType.msgLogOff:
                        Result = MessageBox.Show(BaranResources.LogOff, "LogOff", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        break;

                    case PublicEnum.EnmMessageType.msgPrintConfirm:
                        Result = MessageBox.Show(BaranResources.PrintConfirm, "Print Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        break;

                    case PublicEnum.EnmMessageType.msgPrintSuccessful:
                        Result = MessageBox.Show(BaranResources.PrintSuccessful, "Sucsses Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case PublicEnum.EnmMessageType.msgPrintFail:
                        Result = MessageBox.Show(BaranResources.PrintFail, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case PublicEnum.EnmMessageType.msgSavedLastTimeEditConfirm:
                        Result = MessageBox.Show(BaranResources.SavedLastTimeDoYouWantEditConfirm, "Saved Last Time, Edit Confirm Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        break;
                    case PublicEnum.EnmMessageType.msgSaveNotLastTimeSaveConfirm:
                        Result = MessageBox.Show(BaranResources.SaveNotLastTimeSaveConfirm, "Saved Not Last Time, Save Confirm Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        break;
                    case PublicEnum.EnmMessageType.msgExitConfirm:
                        Result = MessageBox.Show(BaranResources.MainFormClosingMessage, BaranResources.ainFormClosingMessageBoxCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        break;
                    case PublicEnum.EnmMessageType.msgFileExists:
                        Result = MessageBox.Show(OptParam + "\n" + BaranResources.FileAlreadyExistsDoYouWantToReplace, BaranResources.ainFormClosingMessageBoxCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        break;

                    default: 
                        throw new ArgumentOutOfRangeException();     
                   

                }
                
            }
            catch (Exception)
            {
                Result = DialogResult.Ignore;
            }
            return Result;
          
        }

        public static void ShowMessageBox(string MessageText)
        {
            MessageBox.Show(MessageText, "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static DialogResult ShowMessageBox(string MessageText, MessageBoxButtons MessageButton)
        {
            DialogResult Result;
            try
            {
                switch (MessageButton)
                {

                    case MessageBoxButtons.YesNo:
                        Result = MessageBox.Show(MessageText, "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        break;

                    case MessageBoxButtons.OK:
                        Result = MessageBox.Show(MessageText, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

            }
            catch (Exception)
            {
                Result = DialogResult.Ignore;
            }
            return Result;
 
        }
    }

}
