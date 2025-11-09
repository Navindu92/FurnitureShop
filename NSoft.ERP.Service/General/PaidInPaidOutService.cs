using NSoft.ERP.Data;
using NSoft.ERP.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;
using System.Transactions;
using NSoft.ERP.Service.General;
using System.Data;
using System.Data.Common;
using NSoft.ERP.Utility;

namespace NSoft.ERP.Service.General
{
    public class PaidInPaidOutService
    {
        ERPDBContext context = new ERPDBContext();

        public string[] GetAllPaidInCodes()
        {
            return context.PaidInType.Where(d => d.IsDelete == false).Select(u => u.PaidInTypeCode).ToArray();
        }
        public string[] GetAllActivePaidInCodes()
        {
            return context.PaidInType.Where(d => d.IsDelete == false && d.IsActive == true).Select(u => u.PaidInTypeCode).ToArray();
        }

        public string[] GetAllPaidInNames()
        {
            return context.PaidInType.Where(d => d.IsDelete == false).Select(u => u.PaidInTypeName).ToArray();
        }
        public string[] GetAllActivePaidInNames()
        {
            return context.PaidInType.Where(d => d.IsDelete == false && d.IsActive == true).Select(u => u.PaidInTypeName).ToArray();
        }

        public string[] GetAllPaidOutCodes()
        {
            return context.PaidOutType.Where(d => d.IsDelete == false).Select(u => u.PaidOutTypeCode).ToArray();
        }
        public string[] GetAllActivePaidOutCodes()
        {
            return context.PaidOutType.Where(d => d.IsDelete == false && d.IsActive == true).Select(u => u.PaidOutTypeCode).ToArray();
        }

        public string[] GetAllPaidOutNames()
        {
            return context.PaidOutType.Where(d => d.IsDelete == false).Select(u => u.PaidOutTypeName).ToArray();
        }
        public string[] GetAllActivePaidOutNames()
        {
            return context.PaidOutType.Where(d => d.IsDelete == false && d.IsActive == true).Select(u => u.PaidOutTypeName).ToArray();
        }

        public PaidInType GetPaidInTypeByID(long paidInTypeID)
        {
            return context.PaidInType.Where(d => d.PaidInTypeID == paidInTypeID && d.IsDelete == false).FirstOrDefault();
        }
        public PaidInType GetPaidInTypeByCode(string paidInTypeCode)
        {
            return context.PaidInType.Where(d => d.PaidInTypeCode == paidInTypeCode && d.IsDelete == false).FirstOrDefault();
        }

        public PaidInType GetActivePaidInTypeByCode(string paidInTypeCode)
        {
            return context.PaidInType.Where(d => d.PaidInTypeCode == paidInTypeCode && d.IsActive == true && d.IsDelete == false).FirstOrDefault();
        }

        public PaidInType GetPaidInTypeByName(string paidInTypeName)
        {
            return context.PaidInType.Where(d => d.PaidInTypeName == paidInTypeName && d.IsDelete == false).FirstOrDefault();
        }

        public PaidInType GetActivePaidInTypeByName(string paidInTypeName)
        {
            return context.PaidInType.Where(d => d.PaidInTypeName == paidInTypeName && d.IsActive == true && d.IsDelete == false).FirstOrDefault();
        }

        public PaidOutType GetPaidOutTypeByID(long paidOutTypeID)
        {
            return context.PaidOutType.Where(d => d.PaidOutTypeID == paidOutTypeID && d.IsDelete == false).FirstOrDefault();
        }
        public PaidOutType GetPaidOutByCode(string paidOutTypeCode)
        {
            return context.PaidOutType.Where(d => d.PaidOutTypeCode == paidOutTypeCode && d.IsDelete == false).FirstOrDefault();
        }

        public PaidOutType GetActivePaidOutTypeByCode(string paidOutTypeCode)
        {
            return context.PaidOutType.Where(d => d.PaidOutTypeCode == paidOutTypeCode && d.IsActive == true && d.IsDelete == false).FirstOrDefault();
        }

        public PaidOutType GetPaidOutTypeByName(string paidOutTypeName)
        {
            return context.PaidOutType.Where(d => d.PaidOutTypeName == paidOutTypeName && d.IsDelete == false).FirstOrDefault();
        }

        public PaidOutType GetActivePaidOutTypeByName(string paidOutTypeName)
        {
            return context.PaidOutType.Where(d => d.PaidOutTypeName == paidOutTypeName && d.IsActive == true && d.IsDelete == false).FirstOrDefault();
        }

        public List<PaidInType> GetAllActivePaidInTypes()
        {
            return context.PaidInType.Where(p => p.IsDelete == false && p.IsActive == true).ToList();
        }
        public List<PaidOutType> GetAllActivePaidOutTypes()
        {
            return context.PaidOutType.Where(p => p.IsDelete == false && p.IsActive == true).ToList();
        }
        public List<PaidInPaidOutTemp> GetUpdatedPaidInPaidOutList(List<PaidInPaidOutTemp> existingList, PaidInPaidOutTemp paidInPaidOutTemp)
        {

            List<PaidInPaidOutTemp> rtnList = new List<PaidInPaidOutTemp>();
            PaidInPaidOutTemp existingPaidInPaidOutTemp;
            rtnList = existingList;
            long lineNo = 0;
            existingPaidInPaidOutTemp = rtnList.Where(i => i.PaidInPaidOutID == paidInPaidOutTemp.PaidInPaidOutID).FirstOrDefault();
            if (rtnList.ToList().Count == 0)
            { lineNo = 1; }
            else
            { lineNo = rtnList.Max(m => m.LineNo) + 1; }

            if (existingPaidInPaidOutTemp == null)
            {
                paidInPaidOutTemp.LineNo = lineNo;
                paidInPaidOutTemp.PaidInPaidOutID = paidInPaidOutTemp.PaidInPaidOutID;
                paidInPaidOutTemp.PaidInPaidOutCode = paidInPaidOutTemp.PaidInPaidOutCode;
                paidInPaidOutTemp.PaidInPaidOutName = paidInPaidOutTemp.PaidInPaidOutName;
                paidInPaidOutTemp.Amount = paidInPaidOutTemp.Amount;
            }
            else
            {
                rtnList.Remove(existingPaidInPaidOutTemp);
                paidInPaidOutTemp.LineNo = existingPaidInPaidOutTemp.LineNo;
                paidInPaidOutTemp.PaidInPaidOutID = existingPaidInPaidOutTemp.PaidInPaidOutID;
                paidInPaidOutTemp.PaidInPaidOutCode = existingPaidInPaidOutTemp.PaidInPaidOutCode;
                paidInPaidOutTemp.PaidInPaidOutName = existingPaidInPaidOutTemp.PaidInPaidOutName;
                paidInPaidOutTemp.Amount = paidInPaidOutTemp.Amount;
            }
            rtnList.Add(paidInPaidOutTemp);
            return rtnList.OrderBy(o => o.LineNo).ToList();
        }

        public List<PaidInPaidOutTemp> GetUpdatedInvestigationListWithDelete(List<PaidInPaidOutTemp> existingList, PaidInPaidOutTemp paidInPaidOutTemp)
        {
            List<PaidInPaidOutTemp> rtnList = new List<PaidInPaidOutTemp>();
            PaidInPaidOutTemp existingPaidInPaidOutTemp;
            rtnList = existingList;
            long removedLineNo = 0;
            existingPaidInPaidOutTemp = rtnList.Where(i => i.PaidInPaidOutID == paidInPaidOutTemp.PaidInPaidOutID).FirstOrDefault();
            if (existingPaidInPaidOutTemp != null)
            {
                rtnList.Remove(existingPaidInPaidOutTemp);
            }
            removedLineNo = existingPaidInPaidOutTemp.LineNo;
            rtnList.ToList().Where(d => d.LineNo > removedLineNo).ForEach(x => x.LineNo = x.LineNo - 1);

            return rtnList.OrderBy(o => o.LineNo).ThenBy(n => n.LineNo).ToList();
        }

        public bool Save(FormInfo formInfo, PaidInPaidOutMain paidInPaidOutMain, List<PaidInPaidOutTemp> paidInPaidOutSubList, out string documenNo)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                documenNo = CommonService.GenarateDocumentNo(formInfo).Trim();
                paidInPaidOutMain.DocumentNo = documenNo;
                paidInPaidOutMain.DocumentID = formInfo.DocumentID;
                context.PaidInPaidOutMain.Add(paidInPaidOutMain);
                this.context.SaveChanges();
                paidInPaidOutSubList.ToList().ForEach(x =>
                {
                    PaidInPaidOutSub paidInPaidOutSub = new PaidInPaidOutSub();
                    paidInPaidOutSub.PaidInPaidOutMainID = paidInPaidOutMain.PaidInPaidOutMainID;
                    paidInPaidOutSub.PaidInPaidOutID = x.PaidInPaidOutID;
                    paidInPaidOutSub.LineNo = x.LineNo;
                    paidInPaidOutSub.Amount = x.Amount;
                    paidInPaidOutSub.LocationID = paidInPaidOutMain.LocationID;
                    paidInPaidOutSub.CounterNo = paidInPaidOutMain.CounterNo;
                    context.PaidInPaidOutSub.Add(paidInPaidOutSub);
                    this.context.SaveChanges();
                });
                transaction.Complete();
                return true;
            }
        }
        public PaidInPaidOutMain GetAllPaidInPaidOutByDocumentNoAndTypeAndCounterID(string documentNo, int paidInPaidOutType, long counterId, long documentID)
        {
            return context.PaidInPaidOutMain.Where(p => p.DocumentNo == documentNo && p.PaidInPaidOutType == paidInPaidOutType && p.CounterNo == counterId && p.DocumentID == documentID).FirstOrDefault();
        }

        public DataTable GetAllPaidInPaidOutSubByPaidInPaidOutMainID(long paidInPaidOutMainID, int paidInPaidOutType)
        {
            PaidInPaidOutMain paidInPaidOutMain = new PaidInPaidOutMain();

            var qry = (from ins in context.PaidInPaidOutSub
                       join pi in context.PaidInType on new { a = paidInPaidOutType, b = ins.PaidInPaidOutID } equals new { a = 1, b = pi.PaidInTypeID } into g1
                       from opi in g1.DefaultIfEmpty()
                       join po in context.PaidOutType on new { a = paidInPaidOutType, b = ins.PaidInPaidOutID } equals new { a = 2, b = po.PaidOutTypeID } into g2
                       from opo in g2.DefaultIfEmpty()
                       where ins.PaidInPaidOutMainID == paidInPaidOutMainID
                       select new
                       {
                           ins.LineNo,
                           PaidInPaidOutTypeName = opi.PaidInTypeName ?? opo.PaidOutTypeName,
                           ins.Amount
                       });

            return qry.ToDataTable();
        }

        public DataSet GetPaidInPaidOutDetails(long locationID, long counterID, DateTime fromDate, DateTime toDate, bool isPaidIn)
        {
            var parameter = new DbParameter[]
                {
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@LocationID", Value=locationID},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@CounterNo", Value=counterID},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@DateFrom", Value=fromDate},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@DateTo", Value=toDate},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@IsPaidIn", Value=isPaidIn}
                };

            return CommonService.ExcecuteStoredProcedureGetDataSet("spPaidInPaidOutDetails", parameter);

        }
    }
}
