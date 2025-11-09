using EntityFramework.Extensions;
using MoreLinq;
using NSoft.ERP.Data;
using NSoft.ERP.Domain.General;
using NSoft.ERP.Domain.Inventory;
using NSoft.ERP.Service.General;
using NSoft.ERP.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace NSoft.ERP.Service.Inventory
{
    public class SalesOrderService
    {
        ERPDBContext context = new ERPDBContext();
        public List<SalesTemp> GetUpdatedSalesTempList(List<SalesTemp> existingList, SalesTemp salesTemp)
        {

            List<SalesTemp> rtnList = new List<SalesTemp>();
            SalesTemp existingSalesTemp;
            rtnList = existingList;
            long lineNo = 0;
            existingSalesTemp = rtnList.Where(i => i.ItemID == salesTemp.ItemID && i.SellingPrice == salesTemp.SellingPrice).FirstOrDefault();
            if (rtnList.ToList().Count == 0)
            { lineNo = 1; }
            else
            { lineNo = rtnList.Max(m => m.LineNo) + 1; }

            if (existingSalesTemp == null)
            {
                salesTemp.LineNo = lineNo;
                salesTemp.ItemID = salesTemp.ItemID;
                salesTemp.ItemCode = salesTemp.ItemCode;
                salesTemp.ItemName = salesTemp.ItemName;
                salesTemp.SellingPrice = salesTemp.SellingPrice;
                salesTemp.DiscountPercentage = salesTemp.DiscountPercentage;
                salesTemp.DiscountAmount = salesTemp.DiscountAmount;
                salesTemp.NetAmount = salesTemp.NetAmount;
            }
            else
            {
                rtnList.Remove(existingSalesTemp);
                salesTemp.LineNo = existingSalesTemp.LineNo;
                salesTemp.ItemID = existingSalesTemp.ItemID;
                salesTemp.ItemCode = existingSalesTemp.ItemCode;
                salesTemp.ItemName = existingSalesTemp.ItemName;
                salesTemp.SellingPrice = salesTemp.SellingPrice;
                salesTemp.DiscountPercentage = salesTemp.DiscountPercentage;
                salesTemp.DiscountAmount = salesTemp.DiscountAmount;
                salesTemp.NetAmount = salesTemp.NetAmount;
            }
            rtnList.Add(salesTemp);
            return rtnList.OrderBy(o => o.LineNo).ToList();
        }
        public List<SalesTemp> GetUpdatedSalesTempListWithDelete(List<SalesTemp> existingList, SalesTemp salesTemp)
        {
            List<SalesTemp> rtnList = new List<SalesTemp>();
            SalesTemp existinginvestigationTemp;
            rtnList = existingList;
            long removedLineNo = 0;
            existinginvestigationTemp = rtnList.Where(i => i.ItemID == salesTemp.ItemID && i.SellingPrice == salesTemp.SellingPrice).FirstOrDefault();
            if (existinginvestigationTemp != null)
            {
                rtnList.Remove(existinginvestigationTemp);
            }
            removedLineNo = existinginvestigationTemp.LineNo;
            rtnList.ToList().Where(d => d.LineNo > removedLineNo).ForEach(x => x.LineNo = x.LineNo - 1);

            return rtnList.OrderBy(o => o.LineNo).ThenBy(n => n.LineNo).ToList();
        }

        public bool Save(FormInfo formInfo, SalesOrderMain salesMain, List<SalesTemp> salesSubList, out string documenNo)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                documenNo = CommonService.GenarateDocumentNo(formInfo).Trim();
                salesMain.DocumentNo = documenNo;
                salesMain.DocumentID = formInfo.DocumentID;
                context.SalesOrderMain.Add(salesMain);
                this.context.SaveChanges();
                salesSubList.ToList().ForEach(x =>
                {
                    SalesOrderSub salesSub = new SalesOrderSub();
                    salesSub.SalesOrderMainID = salesMain.SalesOrderMainID;
                    salesSub.LineNo = x.LineNo;
                    salesSub.ItemID = x.ItemID;
                    salesSub.CostPrice = x.CostPrice;
                    salesSub.SellingPrice = x.SellingPrice;
                    salesSub.Qty = x.Qty;
                    salesSub.BalanceQty = x.Qty;
                    salesSub.CurrentQty = x.CurrentQty;
                    salesSub.DiscountAmount = x.DiscountAmount;
                    salesSub.DiscountPercentage = x.DiscountPercentage;
                    salesSub.Amount = x.NetAmount;
                    context.SalesOrderSub.Add(salesSub);
                    this.context.SaveChanges();
                });

            
                transaction.Complete();
                return true;

            }
        }
        public SalesOrderMain GetAllSalesOrderMainByDocumentNo(string documentNo)
        {
            SalesOrderMain salesMain = new SalesOrderMain();

            var qry = (from sm in context.SalesOrderMain
                       join c in context.Customer on sm.CustomerID equals c.CustomerID
                       where sm.DocumentNo.Equals(documentNo)
                       select new
                       {
                           sm.SalesOrderMainID,
                           sm.DocumentNo,
                           c.CustomerName,
                           sm.TotalAmount,
                           sm.DiscountPercentage,
                           sm.DiscountAmount,
                           sm.NetAmount,
                           sm.LocationID,
                           sm.CounterID,
                           sm.CreatedUser,
                           sm.DocumentDate,
                           sm.CreatedDate
                       });


            foreach (var item in qry)
            {
                salesMain.SalesOrderMainID = item.SalesOrderMainID;
                salesMain.DocumentNo = item.DocumentNo.Trim();
                salesMain.CustomerName = item.CustomerName.ToString().Trim();
                salesMain.TotalAmount = item.TotalAmount;
                salesMain.DiscountPercentage = item.DiscountPercentage;
                salesMain.DiscountAmount = item.DiscountAmount;
                salesMain.NetAmount = item.NetAmount;
                salesMain.LocationID = item.LocationID;
                salesMain.CounterID = item.CounterID;
                salesMain.CreatedUser = item.CreatedUser;
                salesMain.DocumentDate = item.DocumentDate;
                salesMain.CreatedDate = item.CreatedDate;
            }
            return salesMain;
        }

        public DataTable GetAllSalesOrderSubBySalesOrderMainID(long salesMainID)
        {
            var qry = (from ins in context.SalesOrderSub
                       join d in context.Item on ins.ItemID equals d.ItemID
                       where ins.SalesOrderMainID == salesMainID
                       select new
                       {
                           ins.LineNo,
                           d.NameOnInvoice,
                           ins.Qty,
                           ins.SellingPrice,
                           ins.DiscountPercentage,
                           ins.DiscountAmount,
                           ins.Amount
                       });

            return qry.ToDataTable();
        }

        public ArrayList GetSelectionData(Common.ReportDataStruct reportDataStruct)
        {
            IQueryable query = context.SalesOrderMain;
            switch (reportDataStruct.DbColumnName.Trim())
            {
                case "LocationID":
                    query = query.Join(context.Location, reportDataStruct.DbColumnName.Trim(),
                                               reportDataStruct.DbColumnName.Trim(),
                                               "new(inner." + reportDataStruct.DbJoinColumnName.Trim() + ")")
                                         .GroupBy("new(" + reportDataStruct.DbJoinColumnName.Trim() + ")",
                                                  "new(" + reportDataStruct.DbJoinColumnName.Trim() + ")")
                                         .OrderBy("Key." + reportDataStruct.DbJoinColumnName.Trim() + "")
                                         .Select("Key." + reportDataStruct.DbJoinColumnName.Trim() + "");
                    break;
                case "CustomerID":
                    query = query.Join(context.Customer, reportDataStruct.DbColumnName.Trim(),
                                               reportDataStruct.DbColumnName.Trim(),
                                               "new(inner." + reportDataStruct.DbJoinColumnName.Trim() + ")")
                                         .GroupBy("new(" + reportDataStruct.DbJoinColumnName.Trim() + ")",
                                                  "new(" + reportDataStruct.DbJoinColumnName.Trim() + ")")
                                         .OrderBy("Key." + reportDataStruct.DbJoinColumnName.Trim() + "")
                                         .Select("Key." + reportDataStruct.DbJoinColumnName.Trim() + "");
                    break;
                default:
                    query = query.GroupBy("new(" + reportDataStruct.DbColumnName.Trim() + ")",
                                                  "new(" + reportDataStruct.DbColumnName.Trim() + ")")
                          .Select("Key." + reportDataStruct.DbColumnName.Trim() + "");
                    break;
            }
            ArrayList arrayList = new ArrayList();
            foreach (var item in query)
            {
                arrayList.Add(item.ToString());
            }
            return arrayList;
        }
        public DataTable GetSalesOrderDataTable(List<Common.ReportCondtionDataStruct> conditionReportDataStruct, List<Common.ReportDataStruct> reportDataStruct)
        {
            var query = context.SalesOrderMain.AsQueryable();

            foreach (Common.ReportCondtionDataStruct reportCondtionDataStruct in conditionReportDataStruct)
            {
                if (reportCondtionDataStruct.ReportDataStruct.ReportDataType.Equals(typeof(string)))
                {
                    query = query.Where(
                            "" + reportCondtionDataStruct.ReportDataStruct.DbColumnName.Trim() + " >= " + "@0 AND " +
                            reportCondtionDataStruct.ReportDataStruct.DbColumnName.Trim() + " <= @1",
                            reportCondtionDataStruct.ConditionFrom.Trim(),
                            reportCondtionDataStruct.ConditionTo.Trim());
                }
                else if (reportCondtionDataStruct.ReportDataStruct.ReportDataType.Equals(typeof(DateTime)))
                {
                    query =
                        query.Where(
                            "" + reportCondtionDataStruct.ReportDataStruct.DbColumnName.Trim() + " >= " + "@0 AND " +
                            reportCondtionDataStruct.ReportDataStruct.DbColumnName.Trim() + " <= @1",
                            DateTime.Parse(reportCondtionDataStruct.ConditionFrom.Trim()),
                            DateTime.Parse(reportCondtionDataStruct.ConditionTo.Trim()));
                }
                else if (reportCondtionDataStruct.ReportDataStruct.ReportDataType.Equals(typeof(int)))
                { query = query.Where("" + reportCondtionDataStruct.ReportDataStruct.DbColumnName.Trim() + " >= " + "@0 AND " + reportCondtionDataStruct.ReportDataStruct.DbColumnName.Trim() + " <= @1", int.Parse(reportCondtionDataStruct.ConditionFrom.Trim()), int.Parse(reportCondtionDataStruct.ConditionTo.Trim())); }
            }

            var queryResult = (from q in query
                               join l in context.Location on q.LocationID equals l.LocationID
                               join c in context.Customer on q.CustomerID equals c.CustomerID
                               select new
                               {
                                   q.DocumentNo,
                                   q.DocumentDate,
                                   Location = l.LocationName,
                                   Customer = c.CustomerName,
                                   q.ReferenceNo,
                                   q.TotalAmount,
                                   q.DiscountPercentage,
                                   q.DiscountAmount,
                                   q.NetAmount,
                                   q.CreatedUser
                               });

            return queryResult.ToDataTable();
        }

        public string[] GetPendingSalesOrderNumbers(long counterId, long zno)
        {
            List<string> rtnList = new List<string>();
            var qry = (from som in context.SalesOrderMain
                       join sod in context.SalesOrderSub on som.SalesOrderMainID equals sod.SalesOrderMainID
                       where som.CounterID == counterId && som.Zno == zno && sod.BalanceQty > 0
                       orderby som.OrderReferenceNo
                       select new
                       {
                           som.OrderReferenceNo
                       }).Distinct();

            foreach (var item in qry)
            {
                rtnList.Add(item.OrderReferenceNo);
            }

            return rtnList.ToArray();
        }

        public SalesOrderMain GetPendingSalesOrderMainByReferenceSalesOrderNo(string referenceSalesOrderNo, long counterId, long zno)
        {
            SalesOrderMain salesOrderMain = null;
            var qry = (from som in context.SalesOrderMain
                       join sod in context.SalesOrderSub on som.SalesOrderMainID equals sod.SalesOrderMainID
                       where som.CounterID == counterId && som.Zno == zno && sod.BalanceQty > 0 && som.OrderReferenceNo == referenceSalesOrderNo
                       orderby som.OrderReferenceNo
                       select new
                       {
                           som.SalesOrderMainID,
                           som.CustomerID,
                           som.ReferenceNo,
                           som.TotalAmount,
                           som.DiscountAmount,
                           som.DiscountPercentage,
                           som.NetAmount,
                           som.LocationID,
                           som.OrderReferenceNo

                       });

            foreach (var item in qry)
            {
                salesOrderMain = new SalesOrderMain();
                salesOrderMain.SalesOrderMainID = item.SalesOrderMainID;
                salesOrderMain.CustomerID = item.CustomerID;
                salesOrderMain.ReferenceNo = item.ReferenceNo;
                salesOrderMain.TotalAmount = item.TotalAmount;
                salesOrderMain.NetAmount = item.NetAmount;
                salesOrderMain.DiscountAmount = item.DiscountAmount;
                salesOrderMain.DiscountPercentage = item.DiscountPercentage;
                salesOrderMain.LocationID = item.LocationID;
                salesOrderMain.OrderReferenceNo = item.OrderReferenceNo.Trim();
            }
            return salesOrderMain;
        }

        public List<SalesTemp> GetPendingSalesOrderSubBySalesOrderMainID(long salesOrderMainID, long locationID)
        {
            var qry = (from sod in context.SalesOrderSub
                       join i in context.Item on sod.ItemID equals i.ItemID
                       join ism in context.ItemStock on i.ItemID equals ism.ItemID
                       where sod.SalesOrderMainID == salesOrderMainID && sod.BalanceQty > 0
                       && ism.LocationID == locationID
                       select new
                       {
                           i.ItemID,
                           ItemCode=i.ReferenceCode1,
                           i.ItemName,
                           sod.SellingPrice,
                           sod.CostPrice,
                           sod.LineNo,
                           ism.Stock,
                           sod.BalanceQty,
                           sod.DiscountPercentage,
                           sod.DiscountAmount,
                           sod.Amount
                       });

            List<SalesTemp> rtnList = new List<SalesTemp>();     

            foreach (var item in qry)
            {
                SalesTemp salesTemp = new SalesTemp();
                salesTemp.ItemID = item.ItemID;
                salesTemp.ItemCode = item.ItemCode;
                salesTemp.ItemName = item.ItemName;
                salesTemp.SellingPrice = item.SellingPrice;
                salesTemp.CostPrice = item.CostPrice;
                salesTemp.LineNo = item.LineNo;
                salesTemp.CurrentQty = item.Stock;
                salesTemp.Qty = item.BalanceQty;
                salesTemp.DiscountPercentage = item.DiscountPercentage;
                salesTemp.DiscountAmount = item.DiscountAmount;
                salesTemp.NetAmount = item.Amount;
                rtnList.Add(salesTemp);
            }
            return rtnList.ToList();
        }
    }
}
