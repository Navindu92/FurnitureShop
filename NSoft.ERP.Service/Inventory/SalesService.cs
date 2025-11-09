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
using System.Data.Entity;
using System.Collections;
using NSoft.ERP.Utility;
using EntityFramework.Extensions;
using NSoft.ERP.Domain.CRM;
using NSoft.ERP.Service.CRM;

namespace NSoft.ERP.Service.Inventory
{
    public class SalesService
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
                salesTemp.DiscountPercentage = Common.ConvertStringToDecimal(Common.ConvertToStringCurrancy(salesTemp.DiscountPercentage.ToString()));
                salesTemp.DiscountAmount = Common.ConvertStringToDecimal(Common.ConvertToStringCurrancy(salesTemp.DiscountAmount.ToString()));
                salesTemp.Qty = salesTemp.Qty;
                salesTemp.NetAmount = Common.ConvertStringToDecimal(Common.ConvertToStringCurrancy((salesTemp.SellingPrice * salesTemp.Qty).ToString()));
            }
            else
            {
                rtnList.Remove(existingSalesTemp);
                salesTemp.LineNo = existingSalesTemp.LineNo;
                salesTemp.ItemID = existingSalesTemp.ItemID;
                salesTemp.ItemCode = existingSalesTemp.ItemCode;
                salesTemp.ItemName = existingSalesTemp.ItemName;
                salesTemp.SellingPrice = salesTemp.SellingPrice;
                salesTemp.DiscountPercentage = Common.ConvertStringToDecimal(Common.ConvertToStringCurrancy(existingSalesTemp.DiscountPercentage.ToString()));
                salesTemp.DiscountAmount = Common.ConvertStringToDecimal(Common.ConvertToStringCurrancy(existingSalesTemp.DiscountAmount.ToString()));
                salesTemp.Qty = Common.ConvertStringToDecimal(Common.ConvertToStringQty((existingSalesTemp.Qty + salesTemp.Qty).ToString()));
                salesTemp.NetAmount = (salesTemp.SellingPrice * salesTemp.Qty);

            }

            return rtnList.OrderBy(o => o.LineNo).ToList();
        }
        public List<SalesTemp> GetUpdatedSalesTempListWithDelete(List<SalesTemp> existingList, SalesTemp salesTemp)
        {
            List<SalesTemp> rtnList = new List<SalesTemp>();
            SalesTemp existinginvestigationTemp;
            rtnList = existingList;
            long removedLineNo = 0;
            existinginvestigationTemp = context.SalesTemp.Where(i => i.ItemCode == salesTemp.ItemCode && i.SellingPrice == salesTemp.SellingPrice && i.LocationID == salesTemp.LocationID && i.CounterNo == salesTemp.CounterNo && i.DocumentNo == salesTemp.DocumentNo).FirstOrDefault();
            if (existinginvestigationTemp != null)
            {
                context.SalesTemp.Remove(existinginvestigationTemp);
                context.SaveChanges();
            }
            removedLineNo = existinginvestigationTemp.LineNo;

            context.SalesTemp.Where(i => i.LocationID == salesTemp.LocationID && i.CounterNo == salesTemp.CounterNo && i.DocumentNo == salesTemp.DocumentNo && i.LineNo > removedLineNo).ToList().
                ForEach(x => x.LineNo = x.LineNo - 1);
            context.SaveChanges();

            return rtnList.OrderBy(o => o.LineNo).ThenBy(n => n.LineNo).ToList();
        }

        public void GetUpdatedSalesTempListVoid(List<SalesTemp> existingList, SalesTemp salesTemp)
        {
            List<SalesTemp> rtnList = new List<SalesTemp>();
            SalesTemp existinginvestigationTemp;
            rtnList = existingList;
            long removedLineNo = 0;
            existinginvestigationTemp = context.SalesTemp.Where(i => i.ItemCode == salesTemp.ItemCode && i.SellingPrice == salesTemp.SellingPrice && i.LocationID == salesTemp.LocationID && i.CounterNo == salesTemp.CounterNo && i.DocumentNo == salesTemp.DocumentNo).FirstOrDefault();
            if (existinginvestigationTemp != null)
            {
                context.SalesTemp.Remove(existinginvestigationTemp);
                context.SaveChanges();
            }
            removedLineNo = existinginvestigationTemp.LineNo;

            context.SalesTemp.Where(i => i.LocationID == salesTemp.LocationID && i.CounterNo == salesTemp.CounterNo && i.DocumentNo == salesTemp.DocumentNo && i.LineNo > removedLineNo).ToList().
                ForEach(x => x.LineNo = x.LineNo - 1);
            context.SaveChanges();

        }

        public bool Save(FormInfo formInfo, SalesMain salesMain, List<SalesTemp> salesSubList, List<SalesPayment> salesPaymentList, LoyaltyCustomer loyaltyCustomer, out string documenNo, Counter counter)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                documenNo = string.Empty;

                documenNo = CommonService.GenaratePOSInvoiceNo(counter);

                salesMain.DocumentNo = documenNo;

                #region Loyalty

                if (loyaltyCustomer != null)
                {

                    LoyaltyCustomerService loyaltyCustomerService = new LoyaltyCustomerService();

                    #region Loyalty Points Earn

                    decimal pointsRate = 0;

                    LoyaltyCard loyaltyCard = new LoyaltyCard();
                    loyaltyCard = context.LoyaltyCard.Where(lc => lc.LoyaltyCardID == loyaltyCustomer.LoyaltyCardID && lc.IsActive == true && lc.IsDelete == false).FirstOrDefault();

                    if (loyaltyCard != null)
                    {
                        pointsRate = loyaltyCard.PointsRate;
                    }

                    decimal loyaltyEarnAmount = (salesMain.NetAmount * pointsRate);

                    LoyaltyTransaction loyaltyTransaction = new LoyaltyTransaction();
                    loyaltyTransaction.LoyaltyCustomerID = loyaltyCustomer.LoyaltyCustomerID;
                    loyaltyTransaction.TransactionDate = salesMain.DocumentDate;
                    loyaltyTransaction.CounterID = salesMain.CounterNo;
                    loyaltyTransaction.LocationID = salesMain.LocationID;
                    loyaltyTransaction.Zno = salesMain.Zno;
                    loyaltyTransaction.TransactionType = 1;
                    loyaltyTransaction.DocumentNo = salesMain.DocumentNo;
                    loyaltyTransaction.Amount = salesMain.NetAmount;
                    loyaltyTransaction.PointsRate = pointsRate;
                    loyaltyTransaction.Points = loyaltyEarnAmount;

                    context.LoyaltyTransaction.Add(loyaltyTransaction);
                    this.context.SaveChanges();

                    #endregion

                    #region Loyalty Points Redeem

                    decimal loyaltyRedeemAmount = GetExistPaidAmountByPayTypeID(6, salesPaymentList);

                    if (loyaltyRedeemAmount > 0)
                    {
                        loyaltyTransaction = new LoyaltyTransaction();
                        loyaltyTransaction.LoyaltyCustomerID = loyaltyCustomer.LoyaltyCustomerID;
                        loyaltyTransaction.TransactionDate = salesMain.DocumentDate;
                        loyaltyTransaction.CounterID = salesMain.CounterNo;
                        loyaltyTransaction.LocationID = salesMain.LocationID;
                        loyaltyTransaction.Zno = salesMain.Zno;
                        loyaltyTransaction.TransactionType = 2;
                        loyaltyTransaction.DocumentNo = salesMain.DocumentNo;
                        loyaltyTransaction.Amount = salesMain.NetAmount;
                        loyaltyTransaction.PointsRate = pointsRate;
                        loyaltyTransaction.Points = loyaltyRedeemAmount;

                        context.LoyaltyTransaction.Add(loyaltyTransaction);
                        this.context.SaveChanges();
                    }

                    #endregion


                    LoyaltyCustomer loyaltyPrint = new LoyaltyCustomer();
                    loyaltyPrint = loyaltyCustomerService.GetLoyaltyCustomerByID(loyaltyCustomer.LoyaltyCustomerID);
                    if (loyaltyPrint != null)
                    {
                        salesMain.LoyaltyCustomerID = loyaltyPrint.LoyaltyCustomerID;
                        salesMain.CPoints = loyaltyPrint.CurrentPoints;
                        salesMain.EPoints = loyaltyEarnAmount;
                        salesMain.RPoints = loyaltyRedeemAmount;
                    }

                }

                #endregion

                context.SalesMain.Add(salesMain);
                this.context.SaveChanges();
                salesSubList.ToList().ForEach(x =>
                {
                    SalesSub salesSub = new SalesSub();
                    salesSub.SalesMainID = salesMain.SalesMainID;
                    salesSub.LineNo = x.LineNo;
                    salesSub.ItemID = x.ItemID;
                    salesSub.CostPrice = x.CostPrice;
                    salesSub.SellingPrice = x.SellingPrice;
                    salesSub.Qty = x.Qty;
                    salesSub.BalanceQty = x.Qty;
                    salesSub.CurrentQty = x.CurrentQty;
                    salesSub.DiscountAmount = x.DiscountAmount;
                    salesSub.DiscountPercentage = x.DiscountPercentage;
                    salesSub.TotalAmount = x.TotalAmount;
                    salesSub.NetAmount = x.NetAmount;
                    salesSub.DocumentNo = salesMain.DocumentNo;
                    salesSub.DocumentID = salesMain.DocumentID;
                    salesSub.LocationID = salesMain.LocationID;
                    salesSub.CounterNo = salesMain.CounterNo;
                    salesSub.ZDate = salesMain.ZDate;
                    salesSub.Zno = salesMain.Zno;
                    context.SalesSub.Add(salesSub);
                    this.context.SaveChanges();
                });

                salesPaymentList.ToList().ForEach(x =>
                {
                    SalesPayment salesPayment = new SalesPayment();
                    salesPayment.SalesMainID = salesMain.SalesMainID;
                    salesPayment.LineNo = x.LineNo;
                    salesPayment.PayTypeID = x.PayTypeID;
                    salesPayment.Amount = x.Amount;
                    salesPayment.Reference = x.Reference;
                    salesPayment.BankID = x.BankID;
                    salesPayment.Balance = x.Balance;
                    salesPayment.DocumentNo = salesMain.DocumentNo;
                    salesPayment.DocumentID = salesMain.DocumentID;
                    salesPayment.LocationID = salesMain.LocationID;
                    salesPayment.CounterNo = salesMain.CounterNo;
                    salesPayment.ZDate = salesMain.ZDate;
                    salesPayment.Zno = salesMain.Zno;
                    context.SalesPayment.Add(salesPayment);
                    this.context.SaveChanges();
                });

                if (salesMain.IsRecallSalesHold)
                {
                    context.SalesHold.Update(ns => ns.HoldDocumentNo == salesMain.SalesHoldNo && ns.LocationID == salesMain.LocationID && ns.CounterNo == salesMain.CounterNo, ns => new SalesHold { IsRecall = true, RecallUser = salesMain.CreatedUser, RecallDocumentNo = salesMain.DocumentNo });
                }

                context.Counter.Update(ns => ns.LocationID == counter.LocationID && ns.CounterID == counter.CounterNo, ns => new Counter { InvoiceNo = ns.InvoiceNo + 1 });
                context.SaveChanges();

                context.SalesTemp.Delete(d => d.LocationID == counter.LocationID && d.CounterNo == counter.CounterNo && d.DocumentNo == salesMain.DocumentNo);

                var parameter = new DbParameter[]
               {
                  new System.Data.SqlClient.SqlParameter { ParameterName ="@SalesMainID", Value=salesMain.SalesMainID},
                  new System.Data.SqlClient.SqlParameter { ParameterName ="@DocumentID", Value=salesMain.DocumentID},
                  new System.Data.SqlClient.SqlParameter { ParameterName ="@DocumentNo", Value=salesMain.DocumentNo},
                  new System.Data.SqlClient.SqlParameter { ParameterName ="@LocationID", Value=salesMain.LocationID},
                  new System.Data.SqlClient.SqlParameter { ParameterName ="@CounterNo", Value=salesMain.CounterNo},
               };

                if (CommonService.ExecuteStoredProcedure("spInvoiceSave", parameter))
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

        public bool SaveInvoiceReturn(FormInfo formInfo, SalesMain salesMain, List<SalesTemp> salesSubList, out string documenNo)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                documenNo = CommonService.GenarateDocumentNo(formInfo).Trim();
                salesMain.DocumentNo = documenNo;
                salesMain.DocumentID = formInfo.DocumentID;
                context.SalesMain.Add(salesMain);
                this.context.SaveChanges();
                salesSubList.ToList().ForEach(x =>
                {
                    SalesSub salesSub = new SalesSub();
                    salesSub.SalesMainID = salesMain.SalesMainID;
                    salesSub.LineNo = x.LineNo;
                    salesSub.ItemID = x.ItemID;
                    salesSub.CostPrice = x.CostPrice;
                    salesSub.SellingPrice = x.SellingPrice;
                    salesSub.Qty = x.Qty;
                    salesSub.BalanceQty = x.Qty;
                    salesSub.CurrentQty = x.CurrentQty;
                    salesSub.DiscountAmount = x.DiscountAmount;
                    salesSub.DiscountPercentage = x.DiscountPercentage;
                    salesSub.NetAmount = x.NetAmount;
                    context.SalesSub.Add(salesSub);
                    this.context.SaveChanges();
                });

                var parameter = new DbParameter[]
               {
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@SalesMainID", Value=salesMain.SalesMainID},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@DocumentID", Value=salesMain.DocumentID},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@DocumentNo", Value=salesMain.DocumentNo},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@LocationID", Value=salesMain.LocationID},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@CounterNo", Value=salesMain.CounterNo},
               };

                if (CommonService.ExecuteStoredProcedure("spInvoiceReturnSave", parameter))
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
        public SalesMain GetAllSalesMainByDocumentNo(string documentNo)
        {
            SalesMain salesMain = new SalesMain();

            var qry = (from sm in context.SalesMain
                       where sm.DocumentNo.Equals(documentNo)
                       select new
                       {
                           sm.SalesMainID,
                           sm.DocumentNo,
                           sm.TotalAmount,
                           sm.DiscountPercentage,
                           sm.DiscountAmount,
                           sm.NetAmount,
                           sm.BalanceAmount,
                           sm.NoOfPieces,
                           sm.NoOfQty,
                           sm.LocationID,
                           sm.CounterNo,
                           sm.CreatedUser,
                           sm.DocumentDate,
                           sm.DocumentID,
                           sm.CreatedDate,
                           sm.LoyaltyCustomerID,
                           sm.CPoints,
                           sm.EPoints,
                           sm.RPoints,
                           sm.SalesmanID
                       });


            foreach (var item in qry)
            {
                salesMain.SalesMainID = item.SalesMainID;
                salesMain.DocumentNo = item.DocumentNo.Trim();
                salesMain.TotalAmount = item.TotalAmount;
                salesMain.DiscountPercentage = item.DiscountPercentage;
                salesMain.DiscountAmount = item.DiscountAmount;
                salesMain.NetAmount = item.NetAmount;
                salesMain.BalanceAmount = item.BalanceAmount;
                salesMain.NoOfQty = item.NoOfQty;
                salesMain.NoOfPieces = item.NoOfPieces;
                salesMain.LocationID = item.LocationID;
                salesMain.CounterNo = item.CounterNo;
                salesMain.CreatedUser = item.CreatedUser;
                salesMain.DocumentDate = item.DocumentDate;
                salesMain.DocumentID = item.DocumentID;
                salesMain.CreatedDate = item.CreatedDate;
                salesMain.LoyaltyCustomerID = item.LoyaltyCustomerID;
                salesMain.CPoints = item.CPoints;
                salesMain.EPoints = item.EPoints;
                salesMain.RPoints = item.RPoints;
                salesMain.SalesmanID = item.SalesmanID;

            }
            return salesMain;
        }

        public DataTable GetAllSalesSubBySalesMainID(long salesMainID)
        {
            var qry = (from ins in context.SalesSub
                       join d in context.Item on ins.ItemID equals d.ItemID
                       where ins.SalesMainID == salesMainID
                       orderby ins.LineNo
                       select new
                       {
                           ins.LineNo,
                           d.ItemCode,
                           d.NameOnInvoice,
                           d.SinhalaName,
                           ins.Qty,
                           ins.SellingPrice,
                           ins.DiscountPercentage,
                           ins.DiscountAmount,
                           ins.NetAmount,
                           ins.TotalAmount
                       });

            return qry.ToDataTable();
        }

        public DataTable GetAllSalesPaymentBySalesMainID(long salesMainID)
        {
            var qry = (from inp in context.SalesPayment
                       join p in context.PayType on inp.PayTypeID equals p.PayTypeID
                       where inp.SalesMainID == salesMainID
                       select new
                       {
                           inp.LineNo,
                           p.PayTypeName,
                           inp.Reference,
                           inp.Amount
                       });

            return qry.ToDataTable();
        }

        public DataTable GetItemWiseFastMovingDetails(long locationId, DateTime fromDate, DateTime toDate, string codeFrom, string codeTo)
        {
            if (locationId == 0)
            {
                var query = (from sm in context.SalesMain
                             join sb in context.SalesSub on sm.SalesMainID equals sb.SalesMainID
                             join im in context.Item on sb.ItemID equals im.ItemID
                             join l in context.Location on sm.LocationID equals l.LocationID
                             where DbFunctions.TruncateTime(sm.DocumentDate) >= fromDate && DbFunctions.TruncateTime(sm.DocumentDate) <= toDate
                             && im.ReferenceCode1.CompareTo(codeFrom) >= 0 && im.ReferenceCode1.CompareTo(codeTo) <= 0
                             && im.IsDelete == false && im.IsActive == true
                             group new { l, im, sb, sm }
                             by new
                             {
                                 l.LocationID,
                                 l.LocationCode,
                                 l.LocationName,
                                 im.ItemID,
                                 im.ItemCode,
                                 im.ItemName,
                                 im.CostPrice,
                                 sb.SellingPrice,

                             } into grouped
                             select new
                             {
                                 grouped.Key.LocationID,
                                 grouped.Key.LocationCode,
                                 grouped.Key.LocationName,
                                 grouped.Key.ItemID,
                                 grouped.Key.ItemCode,
                                 grouped.Key.ItemName,
                                 grouped.Key.CostPrice,
                                 grouped.Key.SellingPrice,
                                 SaleQty = grouped.Sum(s => s.sm.DocumentID == 1000 ? s.sb.Qty : (s.sm.DocumentID == 2001 ? -s.sb.Qty : 0)),
                                 CostValue = (grouped.Key.CostPrice * grouped.Sum(s => s.sm.DocumentID == 1000 ? s.sb.Qty : (s.sm.DocumentID == 2001 ? -s.sb.Qty : 0))),
                                 SellingValue = (grouped.Key.SellingPrice * grouped.Sum(s => s.sm.DocumentID == 1000 ? s.sb.Qty : (s.sm.DocumentID == 2001 ? -s.sb.Qty : 0)))
                             }
                           ).OrderByDescending(o => o.SaleQty);

                return query.ToDataTable();
            }
            else
            {
                var query = (from sm in context.SalesMain
                             join sb in context.SalesSub on sm.SalesMainID equals sb.SalesMainID
                             join im in context.Item on sb.ItemID equals im.ItemID
                             join l in context.Location on sm.LocationID equals l.LocationID
                             where DbFunctions.TruncateTime(sm.DocumentDate) >= fromDate && DbFunctions.TruncateTime(sm.DocumentDate) <= toDate
                             && im.ReferenceCode1.CompareTo(codeFrom) >= 0 && im.ReferenceCode1.CompareTo(codeTo) <= 0 && sm.LocationID == locationId
                              && im.IsDelete == false && im.IsActive == true
                             group new { l, im, sb, sm }
                             by new
                             {
                                 l.LocationID,
                                 l.LocationCode,
                                 l.LocationName,
                                 im.ItemID,
                                 im.ItemCode,
                                 im.ItemName,
                                 im.CostPrice,
                                 sb.SellingPrice,

                             } into grouped
                             select new
                             {
                                 grouped.Key.LocationID,
                                 grouped.Key.LocationCode,
                                 grouped.Key.LocationName,
                                 grouped.Key.ItemID,
                                 grouped.Key.ItemCode,
                                 grouped.Key.ItemName,
                                 grouped.Key.CostPrice,
                                 grouped.Key.SellingPrice,
                                 SaleQty = grouped.Sum(s => s.sm.DocumentID == 1000 ? s.sb.Qty : (s.sm.DocumentID == 2001 ? -s.sb.Qty : 0)),
                                 CostValue = (grouped.Key.CostPrice * grouped.Sum(s => s.sm.DocumentID == 1000 ? s.sb.Qty : (s.sm.DocumentID == 2001 ? -s.sb.Qty : 0))),
                                 SellingValue = (grouped.Key.SellingPrice * grouped.Sum(s => s.sm.DocumentID == 1000 ? s.sb.Qty : (s.sm.DocumentID == 2001 ? -s.sb.Qty : 0)))
                             }

                           ).OrderByDescending(o => o.SaleQty);

                return query.ToDataTable();
            }
        }
        public DataTable GetItemWiseFastMovingDetails(long locationId, DateTime fromDate, DateTime toDate)
        {
            if (locationId == 0)
            {
                var query = (from sm in context.SalesMain
                             join sb in context.SalesSub on sm.SalesMainID equals sb.SalesMainID
                             join im in context.Item on sb.ItemID equals im.ItemID
                             join l in context.Location on sm.LocationID equals l.LocationID
                             where DbFunctions.TruncateTime(sm.DocumentDate) >= fromDate && DbFunctions.TruncateTime(sm.DocumentDate) <= toDate
                             && im.IsDelete == false && im.IsActive == true
                             group new { l, im, sb, sm }
                             by new
                             {
                                 l.LocationID,
                                 l.LocationCode,
                                 l.LocationName,
                                 im.ItemID,
                                 im.ItemCode,
                                 im.ItemName,
                                 sb.CostPrice,
                                 sb.SellingPrice,

                             } into grouped
                             select new
                             {
                                 grouped.Key.LocationID,
                                 grouped.Key.LocationCode,
                                 grouped.Key.LocationName,
                                 grouped.Key.ItemID,
                                 grouped.Key.ItemCode,
                                 grouped.Key.ItemName,
                                 grouped.Key.CostPrice,
                                 grouped.Key.SellingPrice,
                                 SaleQty = grouped.Sum(s => s.sm.DocumentID == 1000 ? s.sb.Qty : (s.sm.DocumentID == 2001 ? -s.sb.Qty : 0)),
                                 CostValue = (grouped.Key.CostPrice * grouped.Sum(s => s.sm.DocumentID == 1000 ? s.sb.Qty : (s.sm.DocumentID == 2001 ? -s.sb.Qty : 0))),
                                 SellingValue = (grouped.Key.SellingPrice * grouped.Sum(s => s.sm.DocumentID == 1000 ? s.sb.Qty : (s.sm.DocumentID == 2001 ? -s.sb.Qty : 0)))
                             }
                           ).OrderByDescending(o => o.SaleQty);

                return query.ToDataTable();
            }
            else
            {
                var query = (from sm in context.SalesMain
                             join sb in context.SalesSub on sm.SalesMainID equals sb.SalesMainID
                             join im in context.Item on sb.ItemID equals im.ItemID
                             join l in context.Location on sm.LocationID equals l.LocationID
                             where DbFunctions.TruncateTime(sm.DocumentDate) >= fromDate && DbFunctions.TruncateTime(sm.DocumentDate) <= toDate
                             && sm.LocationID == locationId
                              && im.IsDelete == false && im.IsActive == true
                             group new { l, im, sb, sm }
                             by new
                             {
                                 l.LocationID,
                                 l.LocationCode,
                                 l.LocationName,
                                 im.ItemID,
                                 im.ItemCode,
                                 im.ItemName,
                                 sb.CostPrice,
                                 sb.SellingPrice,

                             } into grouped
                             select new
                             {
                                 grouped.Key.LocationID,
                                 grouped.Key.LocationCode,
                                 grouped.Key.LocationName,
                                 grouped.Key.ItemID,
                                 grouped.Key.ItemCode,
                                 grouped.Key.ItemName,
                                 grouped.Key.CostPrice,
                                 grouped.Key.SellingPrice,
                                 SaleQty = grouped.Sum(s => s.sm.DocumentID == 1000 ? s.sb.Qty : (s.sm.DocumentID == 2001 ? -s.sb.Qty : 0)),
                                 CostValue = (grouped.Key.CostPrice * grouped.Sum(s => s.sm.DocumentID == 1000 ? s.sb.Qty : (s.sm.DocumentID == 2001 ? -s.sb.Qty : 0))),
                                 SellingValue = (grouped.Key.SellingPrice * grouped.Sum(s => s.sm.DocumentID == 1000 ? s.sb.Qty : (s.sm.DocumentID == 2001 ? -s.sb.Qty : 0)))
                             }

                           ).OrderByDescending(o => o.SaleQty);

                DataTable st = query.ToDataTable();
                return query.ToDataTable();
            }
        }
        public DataTable GetItemWiseSlowMovingDetails(long locationId, DateTime fromDate, DateTime toDate, string codeFrom, string codeTo)
        {
            if (locationId == 0)
            {
                var query = (from sm in context.SalesMain
                             join sb in context.SalesSub on sm.SalesMainID equals sb.SalesMainID
                             join im in context.Item on sb.ItemID equals im.ItemID
                             join l in context.Location on sm.LocationID equals l.LocationID
                             where DbFunctions.TruncateTime(sm.DocumentDate) >= fromDate && DbFunctions.TruncateTime(sm.DocumentDate) <= toDate
                             && im.ReferenceCode1.CompareTo(codeFrom) >= 0 && im.ReferenceCode1.CompareTo(codeTo) <= 0
                              && im.IsDelete == false && im.IsActive == true
                             group new { l, im, sb, sm }
                             by new
                             {
                                 l.LocationID,
                                 l.LocationCode,
                                 l.LocationName,
                                 im.ItemID,
                                 ItemCode = im.ReferenceCode1,
                                 im.ItemName,
                                 sb.CostPrice,
                                 sb.SellingPrice,

                             } into grouped
                             select new
                             {
                                 grouped.Key.LocationID,
                                 grouped.Key.LocationCode,
                                 grouped.Key.LocationName,
                                 grouped.Key.ItemID,
                                 grouped.Key.ItemCode,
                                 grouped.Key.ItemName,
                                 grouped.Key.CostPrice,
                                 grouped.Key.SellingPrice,
                                 SaleQty = grouped.Sum(s => s.sm.DocumentID == 2000 ? s.sb.Qty : (s.sm.DocumentID == 2001 ? -s.sb.Qty : 0)),
                                 CostValue = (grouped.Key.CostPrice * grouped.Sum(s => s.sm.DocumentID == 2000 ? s.sb.Qty : (s.sm.DocumentID == 2001 ? -s.sb.Qty : 0))),
                                 SellingValue = (grouped.Key.SellingPrice * grouped.Sum(s => s.sm.DocumentID == 2000 ? s.sb.Qty : (s.sm.DocumentID == 2001 ? -s.sb.Qty : 0)))
                             }
                           ).OrderBy(o => o.SaleQty);

                return query.ToDataTable();
            }
            else
            {
                var query = (from sm in context.SalesMain
                             join sb in context.SalesSub on sm.SalesMainID equals sb.SalesMainID
                             join im in context.Item on sb.ItemID equals im.ItemID
                             join l in context.Location on sm.LocationID equals l.LocationID
                             where DbFunctions.TruncateTime(sm.DocumentDate) >= fromDate && DbFunctions.TruncateTime(sm.DocumentDate) <= toDate
                             && im.ReferenceCode1.CompareTo(codeFrom) >= 0 && im.ReferenceCode1.CompareTo(codeTo) <= 0 && sm.LocationID == locationId
                              && im.IsDelete == false && im.IsActive == true
                             group new { l, im, sb, sm }
                             by new
                             {
                                 l.LocationID,
                                 l.LocationCode,
                                 l.LocationName,
                                 im.ItemID,
                                 ItemCode = im.ReferenceCode1,
                                 im.ItemName,
                                 sb.CostPrice,
                                 sb.SellingPrice,

                             } into grouped
                             select new
                             {
                                 grouped.Key.LocationID,
                                 grouped.Key.LocationCode,
                                 grouped.Key.LocationName,
                                 grouped.Key.ItemID,
                                 grouped.Key.ItemCode,
                                 grouped.Key.ItemName,
                                 grouped.Key.CostPrice,
                                 grouped.Key.SellingPrice,
                                 SaleQty = grouped.Sum(s => s.sm.DocumentID == 2000 ? s.sb.Qty : (s.sm.DocumentID == 2001 ? -s.sb.Qty : 0)),
                                 CostValue = (grouped.Key.CostPrice * grouped.Sum(s => s.sm.DocumentID == 2000 ? s.sb.Qty : (s.sm.DocumentID == 2001 ? -s.sb.Qty : 0))),
                                 SellingValue = (grouped.Key.SellingPrice * grouped.Sum(s => s.sm.DocumentID == 2000 ? s.sb.Qty : (s.sm.DocumentID == 2001 ? -s.sb.Qty : 0)))
                             }

                           ).OrderBy(o => o.SaleQty);

                return query.ToDataTable();
            }
        }
        public DataTable GetItemWiseSlowMovingDetails(long locationId, DateTime fromDate, DateTime toDate)
        {
            if (locationId == 0)
            {
                var query = (from sm in context.SalesMain
                             join sb in context.SalesSub on sm.SalesMainID equals sb.SalesMainID
                             join im in context.Item on sb.ItemID equals im.ItemID
                             join l in context.Location on sm.LocationID equals l.LocationID
                             where DbFunctions.TruncateTime(sm.DocumentDate) >= fromDate && DbFunctions.TruncateTime(sm.DocumentDate) <= toDate
                              && im.IsDelete == false && im.IsActive == true
                             group new { l, im, sb, sm }
                             by new
                             {
                                 l.LocationID,
                                 l.LocationCode,
                                 l.LocationName,
                                 im.ItemID,
                                 im.ItemCode,
                                 im.ItemName,
                                 sb.CostPrice,
                                 sb.SellingPrice,

                             } into grouped
                             select new
                             {
                                 grouped.Key.LocationID,
                                 grouped.Key.LocationCode,
                                 grouped.Key.LocationName,
                                 grouped.Key.ItemID,
                                 grouped.Key.ItemCode,
                                 grouped.Key.ItemName,
                                 grouped.Key.CostPrice,
                                 grouped.Key.SellingPrice,
                                 SaleQty = grouped.Sum(s => s.sm.DocumentID == 1000 ? s.sb.Qty : (s.sm.DocumentID == 2001 ? -s.sb.Qty : 0)),
                                 CostValue = (grouped.Key.CostPrice * grouped.Sum(s => s.sm.DocumentID == 1000 ? s.sb.Qty : (s.sm.DocumentID == 2001 ? -s.sb.Qty : 0))),
                                 SellingValue = (grouped.Key.SellingPrice * grouped.Sum(s => s.sm.DocumentID == 1000 ? s.sb.Qty : (s.sm.DocumentID == 2001 ? -s.sb.Qty : 0)))
                             }
                           ).OrderBy(o => o.SaleQty);

                return query.ToDataTable();
            }
            else
            {
                var query = (from sm in context.SalesMain
                             join sb in context.SalesSub on sm.SalesMainID equals sb.SalesMainID
                             join im in context.Item on sb.ItemID equals im.ItemID
                             join l in context.Location on sm.LocationID equals l.LocationID
                             where DbFunctions.TruncateTime(sm.DocumentDate) >= fromDate && DbFunctions.TruncateTime(sm.DocumentDate) <= toDate
                             && sm.LocationID == locationId
                              && im.IsDelete == false && im.IsActive == true
                             group new { l, im, sb, sm }
                             by new
                             {
                                 l.LocationID,
                                 l.LocationCode,
                                 l.LocationName,
                                 im.ItemID,
                                 im.ItemCode,
                                 im.ItemName,
                                 sb.CostPrice,
                                 sb.SellingPrice,

                             } into grouped
                             select new
                             {
                                 grouped.Key.LocationID,
                                 grouped.Key.LocationCode,
                                 grouped.Key.LocationName,
                                 grouped.Key.ItemID,
                                 grouped.Key.ItemCode,
                                 grouped.Key.ItemName,
                                 grouped.Key.CostPrice,
                                 grouped.Key.SellingPrice,
                                 SaleQty = grouped.Sum(s => s.sm.DocumentID == 1000 ? s.sb.Qty : (s.sm.DocumentID == 2001 ? -s.sb.Qty : 0)),
                                 CostValue = (grouped.Key.CostPrice * grouped.Sum(s => s.sm.DocumentID == 1000 ? s.sb.Qty : (s.sm.DocumentID == 2001 ? -s.sb.Qty : 0))),
                                 SellingValue = (grouped.Key.SellingPrice * grouped.Sum(s => s.sm.DocumentID == 1000 ? s.sb.Qty : (s.sm.DocumentID == 2001 ? -s.sb.Qty : 0)))
                             }

                           ).OrderBy(o => o.SaleQty);

                return query.ToDataTable();
            }
        }
        public DataTable GetItemWiseNonMovingDetails(long locationId, DateTime fromDate, DateTime toDate, string codeFrom, string codeTo)
        {
            if (locationId == 0)
            {
                var query = (from im in context.Item
                             where !(from sm in context.SalesMain
                                     join sb in context.SalesSub
                  on sm.SalesMainID equals sb.SalesMainID
                                     join l in context.Location on sm.LocationID equals l.LocationID
                                     where DbFunctions.TruncateTime(sm.DocumentDate) >= fromDate && DbFunctions.TruncateTime(sm.DocumentDate) <= toDate
                                     select sb.ItemID).Contains(im.ItemID)
                             from l in context.Location
                             join ims in context.ItemStock on im.ItemID equals ims.ItemID
                             where im.ReferenceCode1.CompareTo(codeFrom) >= 0 && im.ReferenceCode1.CompareTo(codeTo) <= 0 && l.LocationID == ims.LocationID
                             && im.IsDelete == false && im.IsActive == true
                             group new { im, ims }
                             by new
                             {
                                 l.LocationID,
                                 l.LocationCode,
                                 l.LocationName,
                                 im.ItemID,
                                 ItemCode = im.ReferenceCode1,
                                 im.ItemName,
                                 im.CostPrice,
                                 im.SellingPrice,
                                 ims.Stock
                             } into grouped
                             select new
                             {
                                 grouped.Key.LocationID,
                                 grouped.Key.LocationCode,
                                 grouped.Key.LocationName,
                                 grouped.Key.ItemID,
                                 grouped.Key.ItemCode,
                                 grouped.Key.ItemName,
                                 grouped.Key.CostPrice,
                                 grouped.Key.SellingPrice,
                                 SaleQty = grouped.Key.Stock,
                                 CostValue = (grouped.Key.CostPrice * grouped.Key.Stock),
                                 SellingValue = (grouped.Key.SellingPrice * grouped.Key.Stock)
                             }
                           ).OrderByDescending(o => o.SaleQty);

                return query.ToDataTable();
            }
            else
            {
                var query = (from im in context.Item
                             where !(from sm in context.SalesMain
                                     join sb in context.SalesSub
                  on sm.SalesMainID equals sb.SalesMainID
                                     join l in context.Location on sm.LocationID equals l.LocationID
                                     where DbFunctions.TruncateTime(sm.DocumentDate) >= fromDate && DbFunctions.TruncateTime(sm.DocumentDate) <= toDate
                                     & sm.LocationID == locationId
                                     select sb.ItemID).Contains(im.ItemID)
                             from l in context.Location
                             join ims in context.ItemStock on im.ItemID equals ims.ItemID
                             where im.ReferenceCode1.CompareTo(codeFrom) >= 0 && im.ReferenceCode1.CompareTo(codeTo) <= 0 && l.LocationID == ims.LocationID
                              && im.IsDelete == false && im.IsActive == true
                             group new { im, ims }
                             by new
                             {
                                 l.LocationID,
                                 l.LocationCode,
                                 l.LocationName,
                                 im.ItemID,
                                 ItemCode = im.ReferenceCode1,
                                 im.ItemName,
                                 im.CostPrice,
                                 im.SellingPrice,
                                 ims.Stock

                             } into grouped
                             select new
                             {
                                 grouped.Key.LocationID,
                                 grouped.Key.LocationCode,
                                 grouped.Key.LocationName,
                                 grouped.Key.ItemID,
                                 grouped.Key.ItemCode,
                                 grouped.Key.ItemName,
                                 grouped.Key.CostPrice,
                                 grouped.Key.SellingPrice,
                                 SaleQty = grouped.Key.Stock,
                                 CostValue = (grouped.Key.CostPrice * grouped.Key.Stock),
                                 SellingValue = (grouped.Key.SellingPrice * grouped.Key.Stock)
                             }
                           ).OrderByDescending(o => o.SaleQty);

                return query.ToDataTable();
            }
        }
        public DataTable GetItemWiseNonMovingDetails(long locationId, DateTime fromDate, DateTime toDate)
        {
            if (locationId == 0)
            {
                var query = (from im in context.Item
                             where !(from sm in context.SalesMain
                                     join sb in context.SalesSub
                  on sm.SalesMainID equals sb.SalesMainID
                                     join l in context.Location on sm.LocationID equals l.LocationID
                                     where DbFunctions.TruncateTime(sm.DocumentDate) >= fromDate && DbFunctions.TruncateTime(sm.DocumentDate) <= toDate
                                     select sb.ItemID).Contains(im.ItemID)
                             from l in context.Location
                             join ims in context.ItemStock on im.ItemID equals ims.ItemID
                             where l.LocationID == ims.LocationID
                              && im.IsDelete == false && im.IsActive == true
                             //from sbjb in sbj.DefaultIfEmpty()
                             //join sm in context.SalesMain on sbjb.SalesMainID equals sm.SalesMainID
                             //into smj
                             //from smjb in smj.DefaultIfEmpty()
                             //join l in context.Location on smjb.LocationID equals l.LocationID
                             //into lj
                             //from ljb in lj.DefaultIfEmpty()
                             group new { im, ims }
                             by new
                             {
                                 l.LocationID,
                                 l.LocationCode,
                                 l.LocationName,
                                 im.ItemID,
                                 im.ItemCode,
                                 im.ItemName,
                                 im.CostPrice,
                                 im.SellingPrice,
                                 ims.Stock
                             } into grouped
                             select new
                             {
                                 grouped.Key.LocationID,
                                 grouped.Key.LocationCode,
                                 grouped.Key.LocationName,
                                 grouped.Key.ItemID,
                                 grouped.Key.ItemCode,
                                 grouped.Key.ItemName,
                                 grouped.Key.CostPrice,
                                 grouped.Key.SellingPrice,
                                 SaleQty = grouped.Key.Stock,
                                 CostValue = (grouped.Key.CostPrice * grouped.Key.Stock),
                                 SellingValue = (grouped.Key.SellingPrice * grouped.Key.Stock)

                             }
                           ).OrderByDescending(o => o.SaleQty);

                return query.ToDataTable();
            }
            else
            {
                var query = (from im in context.Item
                             where !(from sm in context.SalesMain
                                     join sb in context.SalesSub
                  on sm.SalesMainID equals sb.SalesMainID
                                     join l in context.Location on sm.LocationID equals l.LocationID
                                     where DbFunctions.TruncateTime(sm.DocumentDate) >= fromDate && DbFunctions.TruncateTime(sm.DocumentDate) <= toDate
                                     && sm.LocationID == locationId
                                     select sb.ItemID).Contains(im.ItemID)
                             from l in context.Location
                             join ims in context.ItemStock on im.ItemID equals ims.ItemID
                             where l.LocationID == ims.LocationID
                              && im.IsDelete == false && im.IsActive == true
                             //join sb in context.SalesSub on im.ItemID equals sb.ItemID
                             //into sbj
                             //from sbjb in sbj.DefaultIfEmpty()
                             //join sm in context.SalesMain on sbjb.SalesMainID equals sm.SalesMainID
                             //into smj
                             //from smjb in smj.DefaultIfEmpty()
                             //join l in context.Location on smjb.LocationID equals l.LocationID
                             //into lj
                             //from ljb in lj.DefaultIfEmpty()
                             //where ljb.LocationID ==locationId
                             group new { im, ims }
                             by new
                             {
                                 l.LocationID,
                                 l.LocationCode,
                                 l.LocationName,
                                 im.ItemID,
                                 im.ItemCode,
                                 im.ItemName,
                                 im.CostPrice,
                                 im.SellingPrice,
                                 ims.Stock
                             } into grouped
                             select new
                             {
                                 grouped.Key.LocationID,
                                 grouped.Key.LocationCode,
                                 grouped.Key.LocationName,
                                 grouped.Key.ItemID,
                                 grouped.Key.ItemCode,
                                 grouped.Key.ItemName,
                                 grouped.Key.CostPrice,
                                 grouped.Key.SellingPrice,
                                 SaleQty = grouped.Key.Stock,
                                 CostValue = (grouped.Key.CostPrice * grouped.Key.Stock),
                                 SellingValue = (grouped.Key.SellingPrice * grouped.Key.Stock)
                             }
                           ).OrderByDescending(o => o.SaleQty);

                return query.ToDataTable();
            }
        }
        public ArrayList GetSelectionData(Common.ReportDataStruct reportDataStruct)
        {
            IQueryable query = context.SalesMain;
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
        public DataTable GetSalesDataTable(List<Common.ReportCondtionDataStruct> conditionReportDataStruct, List<Common.ReportDataStruct> reportDataStruct)
        {
            var query = context.SalesMain.AsQueryable();

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
                               //join c in context.Customer on q.CustomerID equals c.CustomerID
                               select new
                               {
                                   q.DocumentNo,
                                   q.DocumentDate,
                                   Location = l.LocationName,
                                   q.TotalAmount,
                                   q.DiscountPercentage,
                                   q.DiscountAmount,
                                   q.NetAmount,
                                   q.CreatedUser
                               });

            return queryResult.ToDataTable();
        }

        public string[] GetInvoiceNumbersForReturn()
        {
            List<string> rtnList = new List<string>();
            var qry = (from sm in context.SalesMain
                       join sd in context.SalesSub on sm.SalesMainID equals sd.SalesMainID
                       where sd.BalanceQty > 0 && sm.DocumentID == 2000
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

        public SalesMain GetInvoiceReturnByInvoiceNo(string documentNo)
        {
            SalesMain salesMain = null;
            var qry = (from sm in context.SalesMain
                       join sd in context.SalesSub on sm.SalesMainID equals sd.SalesMainID
                       where sd.BalanceQty > 0 && sm.DocumentNo == documentNo && sm.DocumentID == 2000
                       orderby sm.DocumentNo
                       select new
                       {
                           sm.SalesMainID,
                           sm.CustomerID,
                           sm.TotalAmount,
                           sm.DiscountAmount,
                           sm.DiscountPercentage,
                           sm.NetAmount,
                           sm.LocationID,
                           sm.DocumentNo

                       });

            foreach (var item in qry)
            {
                salesMain = new SalesMain();
                salesMain.SalesMainID = item.SalesMainID;
                salesMain.CustomerID = item.CustomerID;
                salesMain.TotalAmount = item.TotalAmount;
                salesMain.NetAmount = item.NetAmount;
                salesMain.DiscountAmount = item.DiscountAmount;
                salesMain.DiscountPercentage = item.DiscountPercentage;
                salesMain.LocationID = item.LocationID;
                salesMain.DocumentNo = item.DocumentNo.Trim();
            }
            return salesMain;
        }
        public List<SalesTemp> GetInvoiceReturnSubBySalesMainID(long salesMainID, long locationID)
        {
            var qry = (from sd in context.SalesSub
                       join i in context.Item on sd.ItemID equals i.ItemID
                       join ism in context.ItemStock on i.ItemID equals ism.ItemID
                       where sd.SalesMainID == salesMainID && sd.BalanceQty > 0
                       && ism.LocationID == locationID
                       select new
                       {
                           i.ItemID,
                           ItemCode = i.ReferenceCode1,
                           i.ItemName,
                           sd.SellingPrice,
                           sd.CostPrice,
                           sd.LineNo,
                           ism.Stock,
                           sd.BalanceQty,
                           sd.DiscountPercentage,
                           sd.DiscountAmount,
                           sd.NetAmount
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
                salesTemp.NetAmount = item.NetAmount;
                rtnList.Add(salesTemp);
            }
            return rtnList.ToList();
        }

        public List<SalesPayment> GetUpdatedSalesPaymentTempList(List<SalesPayment> existingList, SalesPayment salesPaymentTemp)
        {
            List<SalesPayment> rtnList = new List<SalesPayment>();
            SalesPayment existingSalesPaymentTemp;
            rtnList = existingList;
            long lineNo = 0;
            existingSalesPaymentTemp = rtnList.Where(i => i.PayTypeID == salesPaymentTemp.PayTypeID && i.Amount == salesPaymentTemp.Amount && i.Reference == salesPaymentTemp.Reference).FirstOrDefault();
            if (rtnList.ToList().Count == 0)
            { lineNo = 1; }
            else
            { lineNo = rtnList.Max(m => m.LineNo) + 1; }

            if (existingSalesPaymentTemp == null)
            {
                salesPaymentTemp.LineNo = lineNo;
                salesPaymentTemp.PayTypeID = salesPaymentTemp.PayTypeID;
                salesPaymentTemp.BankID = salesPaymentTemp.BankID;
                salesPaymentTemp.PayType = salesPaymentTemp.PayType;
                salesPaymentTemp.Amount = salesPaymentTemp.Amount;
                salesPaymentTemp.Reference = salesPaymentTemp.Reference;
            }
            else
            {
                rtnList.Remove(existingSalesPaymentTemp);
                salesPaymentTemp.LineNo = existingSalesPaymentTemp.LineNo;
                salesPaymentTemp.PayTypeID = existingSalesPaymentTemp.PayTypeID;
                salesPaymentTemp.BankID = existingSalesPaymentTemp.BankID;
                salesPaymentTemp.PayType = existingSalesPaymentTemp.PayType;
                salesPaymentTemp.Reference = existingSalesPaymentTemp.Reference;
            }
            rtnList.Add(salesPaymentTemp);
            return rtnList.OrderBy(o => o.LineNo).ToList();
        }

        public List<SalesTemp> GetUpdatedGridValueTempList(List<SalesTemp> existingList, SalesTemp salesTemp)
        {
            List<SalesTemp> rtnList = new List<SalesTemp>();
            rtnList = existingList;
            var obj = rtnList.FirstOrDefault(i => i.LineNo == salesTemp.LineNo);
            if (obj != null)
            {

                obj.SellingPrice = salesTemp.SellingPrice;
                obj.Qty = salesTemp.Qty;

                decimal discountPercentage = 0, discount = 0;

                if (salesTemp.DiscountPercentage != 0)
                {
                    discountPercentage = salesTemp.DiscountPercentage;
                    discount = ((salesTemp.SellingPrice * salesTemp.Qty) * discountPercentage / 100);
                }
                else
                {
                    if (salesTemp.FixedDiscount > 0)
                    {
                        discount = (salesTemp.FixedDiscount * salesTemp.Qty);
                    }
                    else
                    {
                        discount = salesTemp.DiscountAmount;
                    }
                }

                salesTemp.DiscountAmount = Common.ConvertStringToDecimal(Common.ConvertToStringCurrancy(discount.ToString()));

                if (discountPercentage >= 101)
                { discountPercentage = 0; }

                obj.NetAmount = Common.ConvertStringToDecimal(Common.ConvertToStringCurrancy(((salesTemp.SellingPrice * salesTemp.Qty) - discount).ToString()));
                obj.TotalAmount = Common.ConvertStringToDecimal(Common.ConvertToStringCurrancy(((salesTemp.SellingPrice * salesTemp.Qty)).ToString()));
            };
            return rtnList;
        }
        public DataSet GetSalesSummary(long locationID, DateTime dateFrom, DateTime dateTo, string codeFrom, string codeTo)
        {
            var parameter = new DbParameter[]
               {
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@LocationID", Value=locationID},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@dateFrom", Value=dateFrom},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@dateTo", Value=dateTo},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@CodeFrom", Value=codeFrom},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@CodeTo", Value=codeTo}
               };

            return CommonService.ExcecuteStoredProcedureGetDataSet("spSalesSummary", parameter);
        }

        public DataSet GetReOrderLevel(long locationID,string codeFrom, string codeTo)
        {
            var parameter = new DbParameter[]
               {
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@LocationID", Value=locationID},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@CodeFrom", Value=codeFrom},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@CodeTo", Value=codeTo}
               };

            return CommonService.ExcecuteStoredProcedureGetDataSet("spReorderLevel", parameter);
        }

        public bool SaveSalesHold(List<SalesTemp> salesSubList, Counter counter, out string documentNo)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                documentNo = CommonService.GenaratePOSSalesHoldNo(counter);
                string holdNo = documentNo;
                string posDocumenetNo = CommonService.GenaratePOSInvoiceNo(counter);

                salesSubList.ToList().ForEach(x =>
                {
                    SalesHold salesHold = new SalesHold();
                    salesHold.LineNo = x.LineNo;
                    salesHold.ItemID = x.ItemID;
                    salesHold.CostPrice = x.CostPrice;
                    salesHold.SellingPrice = x.SellingPrice;
                    salesHold.Qty = x.Qty;
                    salesHold.BalanceQty = x.Qty;
                    salesHold.CurrentQty = x.CurrentQty;
                    salesHold.DiscountAmount = x.DiscountAmount;
                    salesHold.DiscountPercentage = x.DiscountPercentage;
                    salesHold.TotalAmount = x.TotalAmount;
                    salesHold.Amount = x.NetAmount;
                    salesHold.DocumentNo = posDocumenetNo;
                    salesHold.LocationID = Common.LoggedLocationID;
                    salesHold.CounterNo = Common.CounterNo;
                    salesHold.ZDate = DateTime.Now.Date;
                    salesHold.Zno = counter.Zno;
                    salesHold.IsRecall = false;
                    salesHold.RecallUser = string.Empty;
                    salesHold.RecallDocumentNo = string.Empty;
                    salesHold.HoldDocumentNo = holdNo;
                    context.SalesHold.Add(salesHold);
                    this.context.SaveChanges();
                });

                context.SalesTemp.Delete(d => d.LocationID == counter.LocationID && d.CounterNo == counter.CounterNo);

                context.Counter.Update(ns => ns.LocationID == counter.LocationID && ns.CounterID == counter.CounterNo, ns => new Counter { HoldNo = ns.HoldNo + 1 });
                context.SaveChanges();

                transaction.Complete();
                return true;

            }
        }
        public List<SalesHold> GetAllSalesHoldDocumentNo(string documentNo, long locationId, Counter counter)
        {
            var qry = (from sh in context.SalesHold
                       where sh.HoldDocumentNo.Equals(documentNo) && sh.LocationID == locationId
                       && sh.CounterNo == counter.CounterNo
                       select new
                       {
                           sh.DocumentNo,
                           sh.Amount,
                           sh.HoldDocumentNo
                       });

            List<SalesHold> rtnList = new List<SalesHold>();

            foreach (var item in qry)
            {
                SalesHold salesHold = new SalesHold();
                salesHold.DocumentNo = item.DocumentNo;
                salesHold.Amount = item.Amount;
                salesHold.HoldDocumentNo = item.HoldDocumentNo;
                rtnList.Add(salesHold);
            }
            return rtnList.ToList();
        }

        public void GetPendingSalesHoldByDocumentNoAndLocationAndCounter(string holodNo, long locationId, long counterId, string documentNo)
        {
            context.SalesTemp.Delete(d => d.LocationID == locationId && d.CounterNo == counterId && d.DocumentNo == documentNo);

            var qry = (from sod in context.SalesHold
                       join i in context.Item on sod.ItemID equals i.ItemID
                       join ism in context.ItemStock on i.ItemID equals ism.ItemID
                       where sod.HoldDocumentNo == holodNo && sod.IsRecall == false
                       && sod.LocationID == locationId && sod.CounterNo == counterId
                       select new
                       {
                           i.ItemID,
                           i.ItemCode,
                           i.ItemName,
                           sod.SellingPrice,
                           sod.CostPrice,
                           sod.LineNo,
                           ism.Stock,
                           sod.BalanceQty,
                           sod.DiscountPercentage,
                           sod.DiscountAmount,
                           sod.TotalAmount,
                           sod.Amount,
                           sod.DocumentNo,
                           sod.LocationID,
                           sod.CounterNo,
                           sod.HoldDocumentNo
                       });

            qry.ToList().ForEach(item =>
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
                salesTemp.TotalAmount = item.TotalAmount;
                salesTemp.NetAmount = item.Amount;
                salesTemp.DocumentNo = documentNo;
                salesTemp.LocationID = item.LocationID;
                salesTemp.CounterNo = item.CounterNo;
                salesTemp.HoldDocumentNo = item.HoldDocumentNo;
                context.SalesTemp.Add(salesTemp);
                context.SaveChanges();
            });


        }

        public List<SalesTemp> GetSalesTempByDocumentNoAndLocationAndCounter(string documentNo, long locationId, long counterId)
        {
            var qry = (from st in context.SalesTemp
                       where st.DocumentNo == documentNo
                       && st.LocationID == locationId && st.CounterNo == counterId
                       select new
                       {
                           st.ItemID,
                           st.ItemCode,
                           st.ItemName,
                           st.SellingPrice,
                           st.CostPrice,
                           st.LineNo,
                           st.CurrentQty,
                           st.Qty,
                           st.DiscountPercentage,
                           st.DiscountAmount,
                           st.TotalAmount,
                           st.NetAmount,
                           st.DocumentNo,
                           st.HoldDocumentNo,
                           st.LocationID,
                           st.CounterNo
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
                salesTemp.CurrentQty = item.CurrentQty;
                salesTemp.Qty = item.Qty;
                salesTemp.DiscountPercentage = item.DiscountPercentage;
                salesTemp.DiscountAmount = item.DiscountAmount;
                salesTemp.TotalAmount = item.TotalAmount;
                salesTemp.NetAmount = item.NetAmount;
                salesTemp.DocumentNo = item.DocumentNo;
                salesTemp.HoldDocumentNo = item.HoldDocumentNo;
                salesTemp.LocationID = item.LocationID;
                salesTemp.CounterNo = item.CounterNo;

                rtnList.Add(salesTemp);
            }
            return rtnList.OrderBy(o => o.LineNo).ToList();
        }

        public DataTable GetInvoiceNoForRePrint(long locationId, long counterId, long zNo)
        {
            var qyery = (from sm in context.SalesMain
                         where sm.LocationID == locationId && sm.CounterNo == counterId
                         && sm.Zno == zNo
                         orderby sm.SalesMainID descending
                         select new
                         {
                             sm.DocumentNo,
                             sm.DocumentID
                         });

            return qyery.ToDataTable();
        }

        public void UpdateSalesTemp(SalesTemp salesTemp, List<SalesTemp> salesTempList)
        {
            SalesTemp existingSalesTemp = null;

            long lineNo = 0;

            existingSalesTemp = context.SalesTemp.Where(i => i.LocationID == salesTemp.LocationID && i.CounterNo == salesTemp.CounterNo && i.DocumentNo == salesTemp.DocumentNo && i.ItemID == salesTemp.ItemID && i.SellingPrice == salesTemp.SellingPrice).FirstOrDefault();

            if (existingSalesTemp == null)
            {
                if (salesTempList.Count == 0)
                { lineNo = 1; }
                else
                { lineNo = salesTempList.Max(m => m.LineNo) + 1; }

                salesTemp.LineNo = lineNo;
                context.SalesTemp.Add(salesTemp);
                context.SaveChanges();
            }
            else
            {
                existingSalesTemp.Qty += salesTemp.Qty;

                this.context.Entry(existingSalesTemp).State = EntityState.Modified;
                this.context.SaveChanges();
            }


        }
        public void GetUpdatedGridValueTempList(SalesTemp salesTemp)
        {

            SalesTemp existingSalesTemp = null;

            existingSalesTemp = context.SalesTemp.Where(i => i.LocationID == salesTemp.LocationID && i.CounterNo == salesTemp.CounterNo && i.DocumentNo == salesTemp.DocumentNo && i.ItemID == salesTemp.ItemID && i.SellingPrice == salesTemp.SellingPrice).FirstOrDefault();

            decimal discountPercentage = 0, discount = 0, qty = 0;

            if (existingSalesTemp != null)
            {
                qty = existingSalesTemp.Qty;
            }

            if (salesTemp.DiscountPercentage != 0)
            {
                discountPercentage = salesTemp.DiscountPercentage;
                discount = ((salesTemp.SellingPrice * qty) * discountPercentage / 100);
            }
            else
            {
                if (salesTemp.FixedDiscount > 0)
                {
                    discount = (salesTemp.FixedDiscount * qty);
                }
                else
                {
                    discount = salesTemp.DiscountAmount;
                }
            }

            salesTemp.DiscountAmount = Common.ConvertStringToDecimal(Common.ConvertToStringCurrancy(discount.ToString()));

            if (discountPercentage >= 101)
            { discountPercentage = 0; }

            salesTemp.NetAmount = Common.ConvertStringToDecimal(Common.ConvertToStringCurrancy(((salesTemp.SellingPrice * qty) - discount).ToString()));
            salesTemp.TotalAmount = Common.ConvertStringToDecimal(Common.ConvertToStringCurrancy(((salesTemp.SellingPrice * qty)).ToString()));

            if (existingSalesTemp != null)
            {
                existingSalesTemp.DiscountPercentage = salesTemp.DiscountPercentage;
                existingSalesTemp.DiscountAmount = salesTemp.DiscountAmount;
                existingSalesTemp.NetAmount = salesTemp.NetAmount;
                existingSalesTemp.TotalAmount = salesTemp.TotalAmount;

                this.context.Entry(existingSalesTemp).State = EntityState.Modified;
                this.context.SaveChanges();

            }
        }

        public void UpdateQty(SalesTemp salesTemp)
        {
            SalesTemp existingSalesTemp = null;

            existingSalesTemp = context.SalesTemp.Where(i => i.LocationID == salesTemp.LocationID && i.CounterNo == salesTemp.CounterNo && i.DocumentNo == salesTemp.DocumentNo && i.ItemID == salesTemp.ItemID && i.SellingPrice == salesTemp.SellingPrice).FirstOrDefault();

            if (existingSalesTemp != null)
            {
                existingSalesTemp.Qty = salesTemp.Qty;
            }

            this.context.Entry(existingSalesTemp).State = EntityState.Modified;
            this.context.SaveChanges();
        }
        public void UpdatePrice(SalesTemp salesTemp)
        {
            SalesTemp existingSalesTemp = null;

            existingSalesTemp = context.SalesTemp.Where(i => i.LocationID == salesTemp.LocationID && i.CounterNo == salesTemp.CounterNo && i.DocumentNo == salesTemp.DocumentNo && i.ItemID == salesTemp.ItemID && i.SellingPrice == salesTemp.SellingPrice).FirstOrDefault();

            if (existingSalesTemp != null)
            {
                existingSalesTemp.SellingPrice = salesTemp.NewSellingPrice;
            }

            this.context.Entry(existingSalesTemp).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        public void CancelInvoice(SalesTemp salesTemp)
        {
            context.SalesTemp.Delete(d => d.LocationID == salesTemp.LocationID && d.CounterNo == salesTemp.CounterNo && d.DocumentNo == salesTemp.DocumentNo);
        }

        public decimal GetExistPaidAmountByPayTypeID(long paytypeID, List<SalesPayment> salesPaymentList)
        {
            return salesPaymentList.Where(p => p.PayTypeID == paytypeID).Sum(x => x.Amount);
        }

        public long GetNoOfBillOnCounter(Counter counter)
        {
            FormInfo formInfo = FormInfoService.GetFormInfoByName("FrmInvoice");

            return context.SalesMain.Where(sm => sm.LocationID == counter.LocationID && sm.CounterNo == counter.CounterNo && sm.Zno == counter.Zno && sm.DocumentID == formInfo.DocumentID).Count();
        }
        public DataTable GetItemWiseSalesAnalysisDetails(long locationId, DateTime dateGivenDate, string itemCode)
        {
            var parameter = new DbParameter[]
               {
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@LocationID", Value=locationId},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@GivenDate", Value=dateGivenDate},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@ItemCode", Value=itemCode}
               };

            return CommonService.ExcecuteStoredProcedureGetDataSet("spSalesAnalysis", parameter).Tables[0];

        }
    }
}
