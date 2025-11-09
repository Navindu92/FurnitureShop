using Microsoft.Win32;
using NSoft.ERP.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NSoft.ERP.Service.General
{
    public class ConnectionService
    {
        public bool CheckConnectionString()
        {
            bool isConnectionFound = false;

            RegistryKey conncetionInfo = null;
            conncetionInfo = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\NSOFT\INVENTORY");

            if (conncetionInfo != null)
            {
                Object connectionString = conncetionInfo.GetValue("Connection");

                if (connectionString != null)
                {
                    Common.connectionString = Common.DecryptString(connectionString.ToString());
                    isConnectionFound = true;
                }
                else
                {
                    isConnectionFound = false;
                }
            }
            else
            {
                isConnectionFound = false;

            }
            return isConnectionFound;
        }

        public bool CheckIsValidCounter()
        {
            bool isCounterFound = false;

            RegistryKey counterInfo = null;
            counterInfo = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\NSOFT\INVENTORY");

            if (counterInfo != null)
            {
                Object location = counterInfo.GetValue("INVENTORYLocationID");
                Object counter = counterInfo.GetValue("INVENTORYCounterNo");

                if (location != null && counter != null)
                {
                    try
                    {
                        Common.LoggedLocationID = long.Parse(location.ToString());
                        Common.CounterNo = long.Parse(counter.ToString());

                        isCounterFound = true;
                    }
                    catch (Exception ex)
                    {
                        isCounterFound = false;
                    }

                }
                else
                {
                    isCounterFound = false;
                }
            }
            else
            {
                isCounterFound = false;

            }
            return isCounterFound;
        }
    }
}
