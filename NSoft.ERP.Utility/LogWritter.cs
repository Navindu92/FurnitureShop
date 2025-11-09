using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace NSoft.ERP.Utility
{
    public static class LogWritter
    {
        public static string errorLogPath = AppDomain.CurrentDomain.BaseDirectory + @"\ErrorLog";
        public static string eventLogPath = AppDomain.CurrentDomain.BaseDirectory + @"\EventLog";
        public static string errorFileName = "ErrorLog";
        public static string eventFileName = "EventLog";
        public enum EventType
        { 
            Access,
            Save,
            Update,
            Delete
        }
        public static void WriteErrorLog(string formName, string currentMethod, string exceptionType, string exceptionMessage)
        {
            if (!Directory.Exists(errorLogPath))
            {
                Directory.CreateDirectory(errorLogPath);
            }
            string errorText = formName + " " + currentMethod + " [" + exceptionType + "," + exceptionMessage + "] " + Common.LoggedUserName + " " + Common.LoggedLocation + " " + Common.LoggedPCName + " [" + DateTime.Now + "]";
            errorText += Environment.NewLine;
            File.AppendAllText(errorLogPath + @"\ErrorLog-" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".log", errorText);
        }
        public static void WriteEventLog(string formName,string formText,EventType eventType)
        {
            if (!Directory.Exists(eventLogPath))
            {
                Directory.CreateDirectory(eventLogPath);
            }
            string eventText = DateTime.Now.ToString("t") + " | " + formText + "[" + formName + "] " + eventType.ToString() + " by " + Common.LoggedUserName + " on " + Common.LoggedLocation + " from " + Common.LoggedPCName;
            eventText += Environment.NewLine;
            File.AppendAllText(eventLogPath + @"\EventLog-" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".log", eventText);
        }
    }
}
