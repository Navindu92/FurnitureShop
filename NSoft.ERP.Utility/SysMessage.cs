using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace  NSoft.ERP.Utility
{
    public static class SysMessage
    {
        public enum MessageAction
        {
            LoginNotFound,
            LoginLocationNotFound,
            Save,
            Saved,
            Update,
            Updated,
            Delete,
            Deleted,
            Exception,
            Close,
            ClearForm,
            Exit,
            NotMatch,
            NotExitSave,
            ConnectionFaild,
            CounterNotFound,
            CounterNotOpen,
            General
        }

        public enum MessageType
        {
            Information,
            Error,
            Question,
            Warning
        }
        public static DialogResult ShowMessage(MessageAction messageAction, MessageType messageType, string title, string optionalMessage="")
        {
            string message = "";
            MessageBoxButtons button=MessageBoxButtons.OK;
            MessageBoxIcon icon=MessageBoxIcon.Information;
            int totalLength = 40;
            switch (messageType)
            {
                case MessageType.Information:
                    icon = MessageBoxIcon.Information;
                    
                    break;
                case MessageType.Error:
                    icon = MessageBoxIcon.Error;

                    if (messageAction == MessageAction.LoginNotFound)
                    {
                        message = "Please enter a valid login.";
                        button = MessageBoxButtons.OK;
                    }
                    else if (messageAction == MessageAction.Exception)
                    {
                        message = "Runtime error found. \n";
                        button = MessageBoxButtons.OK;
                    }
                    else if (messageAction == MessageAction.ConnectionFaild)
                    {
                        message = "Error establishing a database connection. \n";
                        button = MessageBoxButtons.OK;
                    }
                    else if (messageAction == MessageAction.CounterNotOpen)
                    {
                        message = "Please do the counter open before \nstart transactions.";
                        button = MessageBoxButtons.OK;
                    }
                    else if (messageAction == MessageAction.CounterNotFound)
                    {
                        message = "Counter not found. \n\n";
                        button = MessageBoxButtons.OK;
                    }
                    else if (messageAction == MessageAction.LoginLocationNotFound)
                    {
                        message = "User does not have access privileges for login this location.";
                        button = MessageBoxButtons.OK;
                    }
                    else if (messageAction == MessageAction.NotMatch)
                    {
                        message = "Your password and confirmation password do not match.";
                        button = MessageBoxButtons.OK;
                    }
                    break;
                case MessageType.Question:
                     if (messageAction == MessageAction.Close)
                    {
                        message = "Are you sure you want to close this form?";
                        
                    }
                     else if (messageAction == MessageAction.ClearForm)
                     {
                         message = "Are you sure you want to clear this form?";
                     }
                     else if (messageAction == MessageAction.Delete)
                     {
                         message = "Are you sure you want to delete this?  \n";
                     }
                     else if (messageAction == MessageAction.Save)
                     {
                         message = "Are you sure you want to save?  \n";
                     }
                     else if (messageAction == MessageAction.Update)
                     {
                         message = "Are you sure you want to update?  \n";
                     }
                     else if (messageAction == MessageAction.Exit)
                     {
                         message = "Are you sure you want to exit system? ";
                     }
                     else if (messageAction == MessageAction.NotExitSave)
                     {
                         message = "Record not exist,Do you want to save as a new? \n";
                     }
                    else if (messageAction == MessageAction.General)
                    {
                        message = "";
                    }
                    button = MessageBoxButtons.YesNo;
                    break;
                default:
                    break;
            }
            totalLength = message.Length+10;
            if (optionalMessage!=string.Empty)
            {
                optionalMessage = optionalMessage.PadLeft(((totalLength - optionalMessage.Length) / 2)
                         + optionalMessage.Length)
                .PadRight(totalLength);
            }

            return MessageBox.Show(message + optionalMessage, title, button, icon);
        }
    }
}
