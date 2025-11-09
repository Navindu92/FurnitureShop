using NSoft.ERP.Data;
using NSoft.ERP.Domain.General;
using NSoft.ERP.Domain.Inventory;
using NSoft.ERP.Service.General;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using MoreLinq;
using System.Data;
using NSoft.ERP.Utility;
using System.Collections;
using NSoft.ERP.Domain.Accounts;

namespace NSoft.ERP.Service.Inventory
{
    public class PurchaseOrderService
    {
        ERPDBContext context = new ERPDBContext();
        public List<PurchaseTemp> GetUpdatedPurchaseTempList(List<PurchaseTemp> existingList, PurchaseTemp purchaseTemp)
        {

            List<PurchaseTemp> rtnList = new List<PurchaseTemp>();
            PurchaseTemp existingPurchaseTemp;
            rtnList = existingList;
            long lineNo = 0;
            existingPurchaseTemp = rtnList.Where(i => i.ItemID == purchaseTemp.ItemID && i.CostPrice == purchaseTemp.CostPrice && i.SellingPrice == purchaseTemp.SellingPrice).FirstOrDefault();
            if (rtnList.ToList().Count == 0)
            { lineNo = 1; }
            else
            { lineNo = rtnList.Max(m => m.LineNo) + 1; }

            if (existingPurchaseTemp == null)
            {
                purchaseTemp.LineNo = lineNo;
                purchaseTemp.ItemID = purchaseTemp.ItemID;
                purchaseTemp.ItemCode = purchaseTemp.ItemCode;
                purchaseTemp.ItemName = purchaseTemp.ItemName;
                purchaseTemp.SellingPrice = purchaseTemp.SellingPrice;
                purchaseTemp.CostPrice = purchaseTemp.CostPrice;
                purchaseTemp.MarginPercentage = purchaseTemp.MarginPercentage;
                purchaseTemp.DiscountPercentage = purchaseTemp.DiscountPercentage;
                purchaseTemp.DiscountAmount = purchaseTemp.DiscountAmount;
                purchaseTemp.Amount = purchaseTemp.Amount;
            }
            else
            {
                rtnList.Remove(existingPurchaseTemp);
                purchaseTemp.LineNo = existingPurchaseTemp.LineNo;
                purchaseTemp.ItemID = existingPurchaseTemp.ItemID;
                purchaseTemp.ItemCode = existingPurchaseTemp.ItemCode;
                purchaseTemp.ItemName = existingPurchaseTemp.ItemName;
                purchaseTemp.SellingPrice = purchaseTemp.SellingPrice;
                purchaseTemp.DiscountPercentage = purchaseTemp.DiscountPercentage;
                purchaseTemp.DiscountAmount = purchaseTemp.DiscountAmount;
                purchaseTemp.Amount = purchaseTemp.Amount;
            }
            rtnList.Add(purchaseTemp);
            return rtnList.OrderBy(o => o.LineNo).ToList();
        }
        public List<PurchaseTemp> GetUpdatedPurchaseTempListWithDelete(List<PurchaseTemp> existingList, PurchaseTemp purchaseTemp)
        {
            List<PurchaseTemp> rtnList = new List<PurchaseTemp>();
            PurchaseTemp existinginvestigationTemp;
            rtnList = existingList;
            long removedLineNo = 0;
            existinginvestigationTemp = rtnList.Where(i => i.ItemID == purchaseTemp.ItemID && i.CostPrice == purchaseTemp.CostPrice && i.SellingPrice == purchaseTemp.SellingPrice).FirstOrDefault();
            if (existinginvestigationTemp != null)
            {
                rtnList.Remove(existinginvestigationTemp);
            }
            removedLineNo = existinginvestigationTemp.LineNo;
            rtnList.ToList().Where(d => d.LineNo > removedLineNo).ForEach(x => x.LineNo = x.LineNo - 1);

            return rtnList.OrderBy(o => o.LineNo).ThenBy(n => n.LineNo).ToList();
        }

        public bool Save(FormInfo formInfo, PurchaseOrderMain purchaseOrderMain, List<PurchaseTemp> purchaseOrderSubList, out string documenNo)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                documenNo = CommonService.GenarateDocumentNo(formInfo).Trim();
                purchaseOrderMain.DocumentNo = documenNo;
                purchaseOrderMain.DocumentID = formInfo.DocumentID;
                context.PurchaseOrderMain.Add(purchaseOrderMain);
                this.context.SaveChanges();
                purchaseOrderSubList.ToList().ForEach(x =>
                {
                    PurchaseOrderSub purchaseOrderSub = new PurchaseOrderSub();
                    purchaseOrderSub.PurchaseOrderMainID = purchaseOrderMain.PurchaseOrderMainID;
                    purchaseOrderSub.LineNo = x.LineNo;
                    purchaseOrderSub.ItemID = x.ItemID;
                    purchaseOrderSub.SellingPrice = x.SellingPrice;
                    purchaseOrderSub.CostPrice = x.CostPrice;
                    purchaseOrderSub.MarginPercentage = x.MarginPercentage;
                    purchaseOrderSub.Qty = x.Qty;
                    purchaseOrderSub.FreeQty = x.FreeQty;
                    purchaseOrderSub.BalanceQty = x.Qty;
                    purchaseOrderSub.BalanceFreeQty = x.FreeQty;
                    purchaseOrderSub.CurrentQty = x.CurrentQty;
                    purchaseOrderSub.DiscountAmount = x.DiscountAmount;
                    purchaseOrderSub.DiscountPercentage = x.DiscountPercentage;
                    purchaseOrderSub.Amount = x.Amount;
                    context.PurchaseOrderSub.Add(purchaseOrderSub);
                    this.context.SaveChanges();
                });

                transaction.Complete();
                return true;

            }
        }
        public PurchaseOrderMain GetAllPurchaseOrderMainByDocumentNo(string documentNo)
        {
            PurchaseOrderMain purchaseOrderMain = new PurchaseOrderMain();

            var qry = (from sm in context.PurchaseOrderMain
                       join s in context.Supplier on sm.SupplierID equals s.SupplierID
                       where sm.DocumentNo.Equals(documentNo)
                       select new
                       {
                           sm.PurchaseOrderMainID,
                           sm.DocumentNo,
                           s.SupplierName,
                           sm.TotalAmount,
                           sm.DiscountPercentage,
                           sm.DiscountAmount,
                           sm.NetAmount

                       });


            foreach (var item in qry)
            {
                purchaseOrderMain.PurchaseOrderMainID = item.PurchaseOrderMainID;
                purchaseOrderMain.DocumentNo = item.DocumentNo.Trim();
                purchaseOrderMain.SupplierName = item.SupplierName.ToString().Trim();
                purchaseOrderMain.TotalAmount = item.TotalAmount;
                purchaseOrderMain.DiscountPercentage = item.DiscountPercentage;
                purchaseOrderMain.DiscountAmount = item.DiscountAmount;
                purchaseOrderMain.NetAmount = item.NetAmount;

            }
            return purchaseOrderMain;
        }

        public DataTable GetAllPurchaseOrderSubByPurchaseOrderMainID(long purchaseOrderMainID)
        {
            var qry = (from ins in context.PurchaseOrderSub
                       join d in context.Item on ins.ItemID equals d.ItemID
                       where ins.PurchaseOrderMainID == purchaseOrderMainID
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

        public DataTable GetPurchaseOrderTransactionDataTable(string documentNo)
        {
            var qry = (from pm in context.PurchaseOrderMain
                       join ps in context.PurchaseOrderSub on pm.PurchaseOrderMainID equals ps.PurchaseOrderMainID
                       join l in context.Location on pm.LocationID equals l.LocationID
                       join im in context.Item on ps.ItemID equals im.ItemID
                       join s in context.Supplier on pm.SupplierID equals s.SupplierID
                       where pm.DocumentNo == documentNo
                       select new
                       {
                           pm.DocumentNo,
                           RefNo = pm.ReferenceNo,
                           pm.DocumentDate,
                           Location = l.LocationName,
                           Supplier = s.SupplierName,
                           ps.LineNo,
                           ItemCode = im.ItemCode,
                           im.ItemName,
                           ps.CostPrice,
                           ps.MarginPercentage,
                           ps.SellingPrice,
                           ps.Qty,
                           ps.FreeQty,
                           ps.DiscountPercentage,
                           ps.DiscountAmount,
                           ps.Amount,
                           pm.TotalAmount,
                           SubTotalDiscountPercentage = pm.DiscountPercentage,
                           SubTotalDiscountAmount = pm.DiscountAmount,
                           pm.NetAmount
                       });

            return qry.ToDataTable();
        }

        public ArrayList GetSelectionData(Common.ReportDataStruct reportDataStruct)
        {
            IQueryable query = context.PurchaseOrderMain;
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
                case "SupplierID":
                    query = query.Join(context.Supplier, reportDataStruct.DbColumnName.Trim(),
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

        public DataTable GetPurchaseOrderDataTable(List<Common.ReportCondtionDataStruct> conditionReportDataStruct, List<Common.ReportDataStruct> reportDataStruct)
        {
            var query = context.PurchaseOrderMain.AsQueryable();

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
                               join s in context.Supplier on q.SupplierID equals s.SupplierID
                               select new
                               {
                                   q.DocumentNo,
                                   q.DocumentDate,
                                   Location = l.LocationName,
                                   Supplier = s.SupplierName,
                                   q.ReferenceNo,
                                   q.TotalAmount,
                                   q.DiscountPercentage,
                                   q.DiscountAmount,
                                   q.NetAmount,
                                   q.CreatedUser
                               });

            return queryResult.ToDataTable();
        }

        public DataSet GetPurchaseOrderSummary(long locationID, DateTime dateFrom, DateTime dateTo, string codeFrom, string codeTo)
        {
            var parameter = new DbParameter[]
               {
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@LocationID", Value=locationID},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@dateFrom", Value=dateFrom},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@dateTo", Value=dateTo},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@CodeFrom", Value=codeFrom},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@CodeTo", Value=codeTo}
               };

            return CommonService.ExcecuteStoredProcedureGetDataSet("spPurchaseOrderSummary", parameter);
        }

    }
}
