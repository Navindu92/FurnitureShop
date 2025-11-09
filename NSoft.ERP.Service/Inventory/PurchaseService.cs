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
    public class PurchaseService
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

        public bool Save(FormInfo formInfo, PurchaseMain purchaseMain, List<PurchaseTemp> purchaseSubList, out string documenNo)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                documenNo = CommonService.GenarateDocumentNo(formInfo).Trim();
                purchaseMain.DocumentNo = documenNo;
                purchaseMain.DocumentID = formInfo.DocumentID;
                context.PurchaseMain.Add(purchaseMain);
                this.context.SaveChanges();
                purchaseSubList.ToList().ForEach(x =>
                {
                    PurchaseSub purchaseSub = new PurchaseSub();
                    purchaseSub.PurchaseMainID = purchaseMain.PurchaseMainID;
                    purchaseSub.LineNo = x.LineNo;
                    purchaseSub.ItemID = x.ItemID;
                    purchaseSub.SellingPrice = x.SellingPrice;
                    purchaseSub.CostPrice = x.CostPrice;
                    purchaseSub.MarginPercentage = x.MarginPercentage;
                    purchaseSub.Qty = x.Qty;
                    purchaseSub.BalanceQty = x.Qty;
                    purchaseSub.FreeQty = x.FreeQty;
                    purchaseSub.BalanceFreeQty = x.FreeQty;
                    purchaseSub.CurrentQty = x.CurrentQty;
                    purchaseSub.DiscountAmount = x.DiscountAmount;
                    purchaseSub.DiscountPercentage = x.DiscountPercentage;
                    purchaseSub.Amount = x.Amount;
                    context.PurchaseSub.Add(purchaseSub);
                    this.context.SaveChanges();
                });

                #region Payment Entry

                PaymentMain paymentMain = new PaymentMain();
                paymentMain.DocumentNo = purchaseMain.DocumentNo;
                paymentMain.DocumentDate = purchaseMain.DocumentDate;
                paymentMain.PaymentDate = purchaseMain.DocumentDate;
                paymentMain.DocumentID = purchaseMain.DocumentID;
                paymentMain.LocationID = Common.LoggedLocationID;
                paymentMain.ReferenceDocumentID = purchaseMain.PurchaseMainID;
                paymentMain.ReferenceDocumentDocumentID = purchaseMain.DocumentID;
                paymentMain.ReferenceLocationID = purchaseMain.LocationID;
                paymentMain.ReferenceTypeID = 1; // Supplier
                paymentMain.ReferenceID = purchaseMain.SupplierID;
                paymentMain.Amount = purchaseMain.NetAmount;
                paymentMain.BalanceAmount = purchaseMain.NetAmount;
                paymentMain.Remark = "GRN PAYMENT";

                context.PaymentMain.Add(paymentMain);
                context.SaveChanges();

                #endregion

                var parameter = new DbParameter[]
               {
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@PurchaseMainID", Value=purchaseMain.PurchaseMainID},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@DocumentID", Value=purchaseMain.DocumentID},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@DocumentNo", Value=purchaseMain.DocumentNo},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@LocationID", Value=purchaseMain.LocationID}

               };

                if (CommonService.ExecuteStoredProcedure("spGoodsReceivedNoteSave", parameter))
                {
                    transaction.Complete();
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public bool SavePurchaseReturn(FormInfo formInfo, PurchaseMain purchaseMain, List<PurchaseTemp> purchaseSubList, out string documenNo)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                documenNo = CommonService.GenarateDocumentNo(formInfo).Trim();
                purchaseMain.DocumentNo = documenNo;
                purchaseMain.DocumentID = formInfo.DocumentID;
                context.PurchaseMain.Add(purchaseMain);
                this.context.SaveChanges();
                purchaseSubList.ToList().ForEach(x =>
                {
                    PurchaseSub purchaseSub = new PurchaseSub();
                    purchaseSub.PurchaseMainID = purchaseMain.PurchaseMainID;
                    purchaseSub.LineNo = x.LineNo;
                    purchaseSub.ItemID = x.ItemID;
                    purchaseSub.SellingPrice = x.SellingPrice;
                    purchaseSub.CostPrice = x.CostPrice;
                    purchaseSub.MarginPercentage = x.MarginPercentage;
                    purchaseSub.Qty = x.Qty;
                    purchaseSub.BalanceQty = x.Qty;
                    purchaseSub.FreeQty = x.FreeQty;
                    purchaseSub.BalanceFreeQty = x.FreeQty;
                    purchaseSub.CurrentQty = x.CurrentQty;
                    purchaseSub.DiscountAmount = x.DiscountAmount;
                    purchaseSub.DiscountPercentage = x.DiscountPercentage;
                    purchaseSub.Amount = x.Amount;
                    context.PurchaseSub.Add(purchaseSub);
                    this.context.SaveChanges();
                });

                #region Payment Entry

                PaymentMain paymentMain = new PaymentMain();
                paymentMain.DocumentNo = purchaseMain.DocumentNo;
                paymentMain.DocumentDate = purchaseMain.DocumentDate;
                paymentMain.PaymentDate = purchaseMain.DocumentDate;
                paymentMain.DocumentID = purchaseMain.DocumentID;
                paymentMain.LocationID = Common.LoggedLocationID;
                paymentMain.ReferenceDocumentID = purchaseMain.PurchaseMainID;
                paymentMain.ReferenceDocumentDocumentID = purchaseMain.DocumentID;
                paymentMain.ReferenceLocationID = purchaseMain.LocationID;
                paymentMain.ReferenceTypeID = 1; // Supplier
                paymentMain.ReferenceID = purchaseMain.SupplierID;
                paymentMain.Amount = purchaseMain.NetAmount;
                paymentMain.BalanceAmount = purchaseMain.NetAmount;
                paymentMain.Remark = "GRN PAYMENT RETURN";

                context.PaymentMain.Add(paymentMain);
                context.SaveChanges();

                #endregion

                var parameter = new DbParameter[]
               {
                  new System.Data.SqlClient.SqlParameter { ParameterName ="@PurchaseMainID", Value=purchaseMain.PurchaseMainID},
                  new System.Data.SqlClient.SqlParameter { ParameterName ="@DocumentID", Value=purchaseMain.DocumentID},
                  new System.Data.SqlClient.SqlParameter { ParameterName ="@DocumentNo", Value=purchaseMain.DocumentNo},
                  new System.Data.SqlClient.SqlParameter { ParameterName ="@LocationID", Value=purchaseMain.LocationID},
                  new System.Data.SqlClient.SqlParameter { ParameterName ="@ReferenceDocumentID", Value=purchaseMain.ReferenceDocumentID}

               };

                if (CommonService.ExecuteStoredProcedure("spPurchaseReturnSave", parameter))
                {
                    transaction.Complete();
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        public PurchaseMain GetAllPurchaseMainByDocumentNo(string documentNo)
        {
            PurchaseMain purchaseMain = new PurchaseMain();

            var qry = (from sm in context.PurchaseMain
                       join s in context.Supplier on sm.SupplierID equals s.SupplierID
                       where sm.DocumentNo.Equals(documentNo)
                       select new
                       {
                           sm.PurchaseMainID,
                           sm.DocumentNo,
                           s.SupplierName,
                           sm.TotalAmount,
                           sm.DiscountPercentage,
                           sm.DiscountAmount,
                           sm.NetAmount

                       });


            foreach (var item in qry)
            {
                purchaseMain.PurchaseMainID = item.PurchaseMainID;
                purchaseMain.DocumentNo = item.DocumentNo.Trim();
                purchaseMain.SupplierName = item.SupplierName.ToString().Trim();
                purchaseMain.TotalAmount = item.TotalAmount;
                purchaseMain.DiscountPercentage = item.DiscountPercentage;
                purchaseMain.DiscountAmount = item.DiscountAmount;
                purchaseMain.NetAmount = item.NetAmount;

            }
            return purchaseMain;
        }

        public DataTable GetAllPurchaseSubByPurchaseMainID(long purchaseMainID)
        {
            var qry = (from ins in context.PurchaseSub
                       join d in context.Item on ins.ItemID equals d.ItemID
                       where ins.PurchaseMainID == purchaseMainID
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

        public DataTable GetPurchaseTransactionDataTable(string documentNo)
        {
            var qry = (from pm in context.PurchaseMain
                       join ps in context.PurchaseSub on pm.PurchaseMainID equals ps.PurchaseMainID
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

        public DataTable GetPurchaseReturnTransactionDataTable(string documentNo)
        {
            var qry = (from pm in context.PurchaseMain
                       join ps in context.PurchaseSub on pm.PurchaseMainID equals ps.PurchaseMainID
                       join pmr in context.PurchaseMain on pm.ReferenceDocumentID equals pmr.PurchaseMainID into prnj
                       from pmr in prnj.DefaultIfEmpty()
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
                           pm.NetAmount,
                           ReferenceGRNNo = pmr.DocumentNo
                       });

            return qry.ToDataTable();
        }

        public ArrayList GetSelectionData(Common.ReportDataStruct reportDataStruct)
        {
            IQueryable query = context.PurchaseMain;
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

        public DataTable GetPurchaseDataTable(List<Common.ReportCondtionDataStruct> conditionReportDataStruct, List<Common.ReportDataStruct> reportDataStruct)
        {
            var query = context.PurchaseMain.AsQueryable();

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

        public DataSet GetPurchaseSummary(long locationID, DateTime dateFrom, DateTime dateTo, string codeFrom, string codeTo)
        {
            var parameter = new DbParameter[]
               {
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@LocationID", Value=locationID},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@dateFrom", Value=dateFrom},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@dateTo", Value=dateTo},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@CodeFrom", Value=codeFrom},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@CodeTo", Value=codeTo}
               };

            return CommonService.ExcecuteStoredProcedureGetDataSet("spPurchaseSummary", parameter);
        }

        public string[] GetPurchaseDocumentNoForBarcodePrint()
        {
            return context.PurchaseMain.Where(p => p.DocumentID == 1002).Select(p => p.DocumentNo.Trim()).ToArray();
        }

        public List<BarcodeTemp> GetAllPurchaseForBarcodePrintByDocumentNo(string documentNo)
        {
            List<BarcodeTemp> rtnList = new List<BarcodeTemp>();

            var qry = (from pm in context.PurchaseMain
                       join ps in context.PurchaseSub on pm.PurchaseMainID equals ps.PurchaseMainID
                       join im in context.Item on ps.ItemID equals im.ItemID
                       where pm.DocumentNo.Equals(documentNo)
                       select new
                       {
                           ps.ItemID,
                           im.ItemCode,
                           im.ItemName,
                           ps.SellingPrice,
                           ps.CostPrice,
                           ps.Qty,
                           ps.LineNo

                       });


            foreach (var item in qry)
            {
                BarcodeTemp barcodeTemp = new BarcodeTemp();
                barcodeTemp.ItemID = item.ItemID;
                barcodeTemp.ItemCode = item.ItemCode;
                barcodeTemp.ItemName = item.ItemName;
                barcodeTemp.SellingPrice = item.SellingPrice;
                barcodeTemp.CostPrice = item.CostPrice;
                barcodeTemp.Qty = item.Qty;
                barcodeTemp.LineNo = item.LineNo;
                rtnList.Add(barcodeTemp);
            }
            return rtnList;
        }
        public string[] GetGRNNumbersForReturn()
        {
            List<string> rtnList = new List<string>();
            var qry = (from sm in context.PurchaseMain
                       join sd in context.PurchaseSub on sm.PurchaseMainID equals sd.PurchaseMainID
                       where sd.BalanceQty > 0 && sm.DocumentID == 1002
                       orderby sm.DocumentNo
                       select new
                       {
                           sm.DocumentNo
                       }).Distinct();

            foreach (var item in qry)
            {
                rtnList.Add(item.DocumentNo);
            }

            return rtnList.ToArray();
        }
        public PurchaseMain GetPurchaseReturnByGRNNo(string documentNo)
        {
            PurchaseMain purchaseMain = null;
            var qry = (from sm in context.PurchaseMain
                       join sd in context.PurchaseSub on sm.PurchaseMainID equals sd.PurchaseMainID
                       where sd.BalanceQty > 0 && sm.DocumentNo == documentNo && sm.DocumentID == 1002
                       orderby sm.DocumentNo
                       select new
                       {
                           sm.PurchaseMainID,
                           sm.SupplierID,
                           sm.TotalAmount,
                           sm.DiscountAmount,
                           sm.DiscountPercentage,
                           sm.NetAmount,
                           sm.LocationID,
                           sm.DocumentNo,
                           sm.DocumentID

                       });

            foreach (var item in qry)
            {
                purchaseMain = new PurchaseMain();
                purchaseMain.PurchaseMainID = item.PurchaseMainID;
                purchaseMain.SupplierID = item.SupplierID;
                purchaseMain.TotalAmount = item.TotalAmount;
                purchaseMain.NetAmount = item.NetAmount;
                purchaseMain.DiscountAmount = item.DiscountAmount;
                purchaseMain.DiscountPercentage = item.DiscountPercentage;
                purchaseMain.LocationID = item.LocationID;
                purchaseMain.DocumentNo = item.DocumentNo.Trim();
                purchaseMain.DocumentID = item.DocumentID;
            }
            return purchaseMain;
        }
        public List<PurchaseTemp> GetPurchaseReturnSubByPurchaseMainID(long purchaseMainID, long locationID)
        {
            var qry = (from sd in context.PurchaseSub
                       join i in context.Item on sd.ItemID equals i.ItemID
                       join ism in context.ItemStock on i.ItemID equals ism.ItemID
                       where sd.PurchaseMainID == purchaseMainID && sd.BalanceQty > 0
                       && ism.LocationID == locationID
                       select new
                       {
                           i.ItemID,
                           ItemCode = i.ItemCode,
                           i.ItemName,
                           sd.SellingPrice,
                           sd.CostPrice,
                           sd.LineNo,
                           ism.Stock,
                           sd.BalanceQty,
                           sd.BalanceFreeQty,
                           sd.DiscountPercentage,
                           sd.DiscountAmount,
                           sd.Amount
                       });

            List<PurchaseTemp> rtnList = new List<PurchaseTemp>();

            foreach (var item in qry)
            {
                PurchaseTemp purchaseTemp = new PurchaseTemp();
                purchaseTemp.ItemID = item.ItemID;
                purchaseTemp.ItemCode = item.ItemCode;
                purchaseTemp.ItemName = item.ItemName;
                purchaseTemp.SellingPrice = item.SellingPrice;
                purchaseTemp.CostPrice = item.CostPrice;
                purchaseTemp.LineNo = item.LineNo;
                purchaseTemp.CurrentQty = item.Stock;
                purchaseTemp.Qty = item.BalanceQty;
                purchaseTemp.FreeQty = item.BalanceFreeQty;
                purchaseTemp.DiscountPercentage = item.DiscountPercentage;
                purchaseTemp.DiscountAmount = item.DiscountAmount;
                purchaseTemp.Amount = item.Amount;
                rtnList.Add(purchaseTemp);
            }
            return rtnList.ToList();
        }
        public void GetGRNQtyByDocumentNoAndProductID(string documntNo, long itemId, out decimal qty, out decimal freeQty)
        {
            qty = 0;
            freeQty = 0;

            var qry = (from ph in context.PurchaseMain
                       join pd in context.PurchaseSub on ph.PurchaseMainID equals pd.PurchaseMainID
                       where ph.DocumentNo == documntNo && pd.ItemID == itemId
                       select new
                       {
                           pd.Qty,
                           pd.FreeQty
                       });

            foreach (var temp in qry)
            {
                qty = temp.Qty;
                freeQty = temp.FreeQty;
            }
        }
    }
}
