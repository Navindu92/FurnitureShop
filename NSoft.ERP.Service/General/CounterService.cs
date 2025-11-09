using NSoft.ERP.Data;
using NSoft.ERP.Domain.General;
using NSoft.ERP.Service.General;
using NSoft.ERP.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;

namespace NSoft.ERP.Service.General
{
    public class CounterService
    {
        ERPDBContext context = new ERPDBContext();

        public void AddCounter(Counter counter)
        {
            context.Counter.Add(counter);
            context.SaveChanges();
        }

        public void UpdateCounter(Counter counter)
        {
            counter.ModifiedUser = Common.LoggedUserName;
            counter.ModifiedDate = DateTime.Now;
            this.context.Entry(counter).State = EntityState.Modified;
            this.context.SaveChanges();
        }
        public Counter GetCounterByID(long counterID)
        {
            return context.Counter.Where(d => d.CounterID == counterID).FirstOrDefault();
        }

        public Counter GetCounterByCounterNoAndLocationID(long counterNo, long locationID)
        {
            return context.Counter.Where(d => d.CounterNo == counterNo && d.LocationID == locationID).FirstOrDefault();
        }
        public void AddCounterTransaction(CounterTransaction counterTransaction, List<FloatMaster> floatMaterList)
        {
            context.CounterTransaction.Add(counterTransaction);
            context.SaveChanges();

            floatMaterList.ToList().ForEach(x =>
            {
                CounterTransactionFloat counterTransactionFloat = new CounterTransactionFloat();
                counterTransactionFloat.CounterNo = counterTransaction.CounterNo;
                counterTransactionFloat.CounterTransactionID = counterTransaction.CounterTransactionID;
                counterTransactionFloat.FloatAmount = x.FloatAmount;
                counterTransactionFloat.FloatCount = x.FloatCount;
                counterTransactionFloat.FloatMasterID = x.FloatMasterID;
                counterTransactionFloat.FloatValue = x.FloatValue;
                counterTransactionFloat.LocationID = counterTransaction.LocationID;
                counterTransactionFloat.UserID = counterTransaction.UserID;
                counterTransactionFloat.ZDate = counterTransaction.ZDate;
                counterTransactionFloat.Zno = counterTransaction.Zno;
                context.CounterTransactionFloat.Add(counterTransactionFloat);
                this.context.SaveChanges();
            });

        }

        public CounterTransaction GetCounterTransactionByLocationCounterAndDateAndZno(long loctionID, long counterID, int transactionTypeID, DateTime transactionDate, long zno)
        {
            return context.CounterTransaction.Where(d => d.CounterNo == counterID && d.LocationID == loctionID && d.TransactionTypeID == transactionTypeID && d.Zno == zno).FirstOrDefault();
        }

        public List<Counter> GetAllActiveCounters()
        {
            return context.Counter.ToList();
        }

        public DataSet GetCounterSummary(long locationID, long counterID, int reportType, DateTime fromDate, DateTime toDate, decimal declareAmount = 0)
        {

            var parameter = new DbParameter[]
                {
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@LocationID", Value=locationID},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@CounterNo", Value=counterID},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@DateFrom", Value=fromDate},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@DateTo", Value=toDate},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@ReportType", Value=reportType},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@DeclareAmount", Value=declareAmount},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@UserID", Value=Common.LoggedUserID}
                };

            return CommonService.ExcecuteStoredProcedureGetDataSet("spCounterSummary", parameter);

        }

        public DataTable GetCounterFloatForCounterOpen(Counter counter, long userId)
        {
            var qry = (from cf in context.CounterTransactionFloat
                       join ct in context.CounterTransaction on cf.CounterTransactionID equals ct.CounterTransactionID
                       where cf.LocationID == counter.LocationID && cf.CounterNo == counter.CounterNo && cf.Zno == counter.Zno
                       && cf.UserID == userId && ct.TransactionTypeID == 1
                       select new
                       {
                           cf.FloatValue,
                           cf.FloatCount,
                           cf.FloatAmount
                       });

            return qry.ToDataTable();
        }
    }
}
