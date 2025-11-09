using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EntityFramework.Extensions;

using NSoft.ERP.Data;
using NSoft.ERP.Domain;
using NSoft.ERP.Domain.Log;
using NSoft.ERP.Domain.General;
using System.Configuration;
using NSoft.ERP.Utility;

namespace NSoft.ERP.Service.General
{
    public static class CommonService
    {
        static ERPDBContext context = new ERPDBContext();
        static ERPDBContext2 context2 = new ERPDBContext2();
        public static void AddSystemLog(SystemLog systemLog)
        {
            context2.SystemLog.Add(systemLog);
            context2.SaveChanges();
        }

        public static void AddDrawerLog(DrawerTransaction drawerTransaction)
        {
            context.DrawerTransaction.Add(drawerTransaction);
            context.SaveChanges();
        }

        public static bool ExecuteStoredProcedure(string spName, object[] parameters)
        {
            try
            {
                //SqlConnection con = new SqlConnection(context.Database.Connection.ConnectionString);
                //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SysConn"].ToString());
                SqlConnection con = new SqlConnection(Common.connectionString);
                SqlCommand cmd = new SqlCommand(spName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var item in parameters)
                {
                    cmd.Parameters.Add(item);
                }
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static DataTable ExcecuteStoredProcedureGetDataTable(string spName, object[] parameters)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dataTable = new DataTable();
                // SqlConnection con = new SqlConnection(context.Database.Connection.ConnectionString);
                //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SysConn"].ToString());
                SqlConnection con = new SqlConnection(Common.connectionString);
                SqlCommand cmd = new SqlCommand(spName, con);
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (var item in parameters)
                {
                    cmd.Parameters.Add(item);
                }

                da.SelectCommand = cmd;
                da.Fill(dataTable);
                return dataTable;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static DataSet ExcecuteStoredProcedureGetDataSet(string spName, object[] parameters)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet dataSet = new DataSet();
                // SqlConnection con = new SqlConnection(context.Database.Connection.ConnectionString);
                //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SysConn"].ToString());
                SqlConnection con = new SqlConnection(Common.connectionString);
                SqlCommand cmd = new SqlCommand(spName, con);
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (var item in parameters)
                {
                    cmd.Parameters.Add(item);
                }

                da.SelectCommand = cmd;
                da.Fill(dataSet);
                return dataSet;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static string GenarateDocumentNo(FormInfo formInfo)
        {
            string prefix;
            int codeLength;
            string newCode;
            string tempCode;
            prefix = formInfo.Prefix;
            if (prefix == string.Empty) { prefix = ""; }
            codeLength = formInfo.CodeLength;
            context.NumberSetup.Update(ns => ns.DocumentID == formInfo.DocumentID, ns => new NumberSetup { SerialNo = ns.SerialNo + 1 });
            context.SaveChanges();
            tempCode = context.NumberSetup.Where(ns => ns.IsDelete == false && ns.DocumentID == formInfo.DocumentID).Select(ns => ns.SerialNo).FirstOrDefault().ToString();
            newCode = prefix + tempCode.PadLeft(codeLength - prefix.Length, '0');
            return newCode;
        }

        public static string GenaratePOSInvoiceNo(Counter counter)
        {
            string prefix;
            int codeLength;
            string newCode;
            string tempCode;
            prefix = string.Empty;
            if (prefix == string.Empty) { prefix = ""; }
            codeLength = 8;
            tempCode = context.Counter.Where(ns => ns.LocationID == counter.LocationID && ns.CounterID == counter.CounterNo).Select(ns => ns.InvoiceNo).FirstOrDefault().ToString();
            newCode = prefix + tempCode.PadLeft(codeLength - prefix.Length, '0');
            return newCode;
        }

        public static string GenaratePOSSalesHoldNo(Counter counter)
        {
            string prefix;
            int codeLength;
            string newCode;
            string tempCode;
            prefix ="H";
            if (prefix == string.Empty) { prefix = ""; }
            codeLength = 8;
            tempCode = context.Counter.Where(ns => ns.LocationID == counter.LocationID && ns.CounterID == counter.CounterNo).Select(ns => ns.HoldNo).FirstOrDefault().ToString();
            newCode = prefix + tempCode.PadLeft(codeLength - prefix.Length, '0');
            return newCode;
        }

        public static bool CheckValidTimeRange(TimeSpan fromTime, TimeSpan toTime)
        {
            if (toTime < fromTime)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static SystemConfiguration GetSystemConfiguration()
        {
            return context.SystemConfiguration.FirstOrDefault();
        }

        public static string GetServerName(string conctionString)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(conctionString);
     
            string serverName = builder.DataSource;

            return serverName;
        }

    }
}
