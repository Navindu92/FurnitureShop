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
using MoreLinq;
using EntityFramework.Extensions;


namespace NSoft.ERP.Service.Inventory
{
    public class StockAdjustmentService
    {
        ERPDBContext context = new ERPDBContext();
        public List<StockAdjustmentTemp> GetUpdatedStockAdjustmentTempList(List<StockAdjustmentTemp> existingList, StockAdjustmentTemp stockAdjustmentTemp)
        {

            List<StockAdjustmentTemp> rtnList = new List<StockAdjustmentTemp>();
            StockAdjustmentTemp existingStockAdjustmentTemp;
            rtnList = existingList;
            long lineNo = 0;
            existingStockAdjustmentTemp = rtnList.Where(i => i.ItemID == stockAdjustmentTemp.ItemID).FirstOrDefault();
            if (rtnList.ToList().Count == 0)
            { lineNo = 1; }
            else
            { lineNo = rtnList.Max(m => m.LineNo) + 1; }

            if (existingStockAdjustmentTemp == null)
            {
                stockAdjustmentTemp.LineNo = lineNo;
                stockAdjustmentTemp.ItemID = stockAdjustmentTemp.ItemID;
                stockAdjustmentTemp.ItemCode = stockAdjustmentTemp.ItemCode;
                stockAdjustmentTemp.ItemName = stockAdjustmentTemp.ItemName;
                stockAdjustmentTemp.SellingPrice = stockAdjustmentTemp.SellingPrice;
                stockAdjustmentTemp.CostPrice = stockAdjustmentTemp.CostPrice;
                stockAdjustmentTemp.SellingValue = stockAdjustmentTemp.SellingValue;
                stockAdjustmentTemp.CostValue = stockAdjustmentTemp.SellingValue;
            }
            else
            {
                rtnList.Remove(existingStockAdjustmentTemp);
                stockAdjustmentTemp.LineNo = existingStockAdjustmentTemp.LineNo;
                stockAdjustmentTemp.ItemID = existingStockAdjustmentTemp.ItemID;
                stockAdjustmentTemp.ItemCode = existingStockAdjustmentTemp.ItemCode;
                stockAdjustmentTemp.ItemName = existingStockAdjustmentTemp.ItemName;
                stockAdjustmentTemp.SellingPrice = stockAdjustmentTemp.SellingPrice;
                stockAdjustmentTemp.CostPrice = stockAdjustmentTemp.CostPrice;
                stockAdjustmentTemp.SellingValue = stockAdjustmentTemp.SellingValue;
                stockAdjustmentTemp.CostValue = stockAdjustmentTemp.CostValue;
            }
            rtnList.Add(stockAdjustmentTemp);
            return rtnList.OrderBy(o => o.LineNo).ToList();
        }
        public List<StockAdjustmentTemp> GetUpdatedStockAdjustmentTempListWithDelete(List<StockAdjustmentTemp> existingList, StockAdjustmentTemp stockAdjustmentTemp)
        {
            List<StockAdjustmentTemp> rtnList = new List<StockAdjustmentTemp>();
            StockAdjustmentTemp existinginvestigationTemp;
            rtnList = existingList;
            long removedLineNo = 0;
            existinginvestigationTemp = rtnList.Where(i => i.ItemID == stockAdjustmentTemp.ItemID && i.SellingPrice == stockAdjustmentTemp.SellingPrice).FirstOrDefault();
            if (existinginvestigationTemp != null)
            {
                rtnList.Remove(existinginvestigationTemp);
            }
            removedLineNo = existinginvestigationTemp.LineNo;
            rtnList.ToList().Where(d => d.LineNo > removedLineNo).ForEach(x => x.LineNo = x.LineNo - 1);

            return rtnList.OrderBy(o => o.LineNo).ThenBy(n => n.LineNo).ToList();
        }

        public bool Save(FormInfo formInfo, StockAdjustmentMain stockAdjustmentMain, List<StockAdjustmentTemp> stockAdjustmentSubList, out string documenNo)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                documenNo = CommonService.GenarateDocumentNo(formInfo).Trim();
                stockAdjustmentMain.DocumentNo = documenNo;
                stockAdjustmentMain.DocumentID = formInfo.DocumentID;
                context.StockAdjustmentMain.Add(stockAdjustmentMain);
                this.context.SaveChanges();
                stockAdjustmentSubList.ToList().ForEach(x =>
                {
                    StockAdjustmentSub stockAdjustmentSub = new StockAdjustmentSub();
                    stockAdjustmentSub.StockAdjustmentMainID = stockAdjustmentMain.StockAdjustmentMainID;
                    stockAdjustmentSub.LineNo = x.LineNo;
                    stockAdjustmentSub.ItemID = x.ItemID;
                    stockAdjustmentSub.CostPrice = x.CostPrice;
                    stockAdjustmentSub.SellingPrice = x.SellingPrice;
                    stockAdjustmentSub.CurrentQty = x.CurrentQty;
                    stockAdjustmentSub.Qty = x.Qty;
                    stockAdjustmentSub.AdjustQty = x.AdjustQty;
                    stockAdjustmentSub.AddQty = x.AddQty;
                    stockAdjustmentSub.ReduceQty = x.ReduceQty;
                    stockAdjustmentSub.CostValue = x.CostValue;
                    stockAdjustmentSub.SellingValue = x.SellingValue;
                    stockAdjustmentSub.AdjustmentType = stockAdjustmentMain.AdjustmentType;
                    context.StockAdjustmentSub.Add(stockAdjustmentSub);
                    this.context.SaveChanges();

                    //Update Stock

                    if (stockAdjustmentMain.AdjustmentType == 1)
                    {
                        context.ItemStock.Update(ns => ns.LocationID == stockAdjustmentMain.LocationID && ns.ItemID == x.ItemID, ns => new ItemStock { Stock = ns.Stock + x.AddQty });
                    }
                    else if (stockAdjustmentMain.AdjustmentType == 2)
                    {
                        context.ItemStock.Update(ns => ns.LocationID == stockAdjustmentMain.LocationID && ns.ItemID == x.ItemID, ns => new ItemStock { Stock = ns.Stock - x.ReduceQty });
                    }
                    else if (stockAdjustmentMain.AdjustmentType == 3)
                    {
                        if (x.CurrentQty < x.Qty)
                        {
                            context.ItemStock.Update(ns => ns.LocationID == stockAdjustmentMain.LocationID && ns.ItemID == x.ItemID, ns => new ItemStock { Stock = ns.Stock + x.AddQty });
                        }
                        else if (x.CurrentQty > x.Qty)
                        {
                            context.ItemStock.Update(ns => ns.LocationID == stockAdjustmentMain.LocationID && ns.ItemID == x.ItemID, ns => new ItemStock { Stock = ns.Stock - x.ReduceQty });
                        }
                    }

                });

                transaction.Complete();
                return true;
                // var parameter = new DbParameter[]
                //{
                //         new System.Data.SqlClient.SqlParameter { ParameterName ="@StockAdjustmentMainID", Value=stockAdjustmentMain.StockAdjustmentMainID},
                //         new System.Data.SqlClient.SqlParameter { ParameterName ="@AdjustmentType", Value=stockAdjustmentMain.AdjustmentType},
                //         new System.Data.SqlClient.SqlParameter { ParameterName ="@DocumentID", Value=stockAdjustmentMain.DocumentID},
                //         new System.Data.SqlClient.SqlParameter { ParameterName ="@DocumentNo", Value=stockAdjustmentMain.DocumentNo},
                //         new System.Data.SqlClient.SqlParameter { ParameterName ="@LocationID", Value=stockAdjustmentMain.LocationID},
                //};

                // if (CommonService.ExecuteStoredProcedure("spStockAdjustmentSave", parameter))
                // {
                //     transaction.Complete();
                //     return true;
                // }
                // else
                // {
                //     return false;
                // }

            }
        }
        public StockAdjustmentMain GetAllStockAdjustmentMainByDocumentNo(string documentNo)
        {
            StockAdjustmentMain stockAdjustmentMain = new StockAdjustmentMain();

            var qry = (from om in context.StockAdjustmentMain
                       where om.DocumentNo.Equals(documentNo)
                       select new
                       {
                           om.StockAdjustmentMainID,
                           om.DocumentNo,
                           om.ReferenceNo,
                           om.Remarks,
                           om.DocumentDate,
                           om.TotalQty,
                           om.TotalCostValue,
                           om.TotalSellingValue,

                       });


            foreach (var item in qry)
            {
                stockAdjustmentMain.StockAdjustmentMainID = item.StockAdjustmentMainID;
                stockAdjustmentMain.DocumentNo = item.DocumentNo.Trim();
                stockAdjustmentMain.ReferenceNo = item.ReferenceNo.Trim();
                stockAdjustmentMain.Remarks = item.Remarks.Trim();
                stockAdjustmentMain.TotalQty = item.TotalQty;
                stockAdjustmentMain.TotalCostValue = item.TotalCostValue;
                stockAdjustmentMain.TotalSellingValue = item.TotalSellingValue;
            }
            return stockAdjustmentMain;
        }

        public DataTable GetAllStockAdjustmentSubByStockAdjustmentMainID(long stockAdjustmentMainID)
        {
            var qry = (from ins in context.StockAdjustmentSub
                       join d in context.Item on ins.ItemID equals d.ItemID
                       where ins.StockAdjustmentMainID == stockAdjustmentMainID
                       select new
                       {
                           ins.LineNo,
                           d.NameOnInvoice,
                           ins.Qty,
                           ins.SellingPrice,
                           ins.CostPrice,
                           ins.SellingValue,
                           ins.CostValue
                       });

            return qry.ToDataTable();
        }

        public DataTable GetStockAdjustmentTransactionDataTable(string documentNo)
        {
            var qry = (from pm in context.StockAdjustmentMain
                       join ps in context.StockAdjustmentSub on pm.StockAdjustmentMainID equals ps.StockAdjustmentMainID
                       join l in context.Location on pm.LocationID equals l.LocationID
                       join im in context.Item on ps.ItemID equals im.ItemID
                       join s in context.ReferenceInfo on pm.AdjustmentType equals s.SubNo
                       where pm.DocumentNo == documentNo && s.ReferenceTypeID == (int)Common.ReferenceType.AdjustmentType
                       select new
                       {
                           pm.DocumentNo,
                           RefNo = pm.ReferenceNo,
                           pm.Remarks,
                           pm.DocumentDate,
                           Location = l.LocationName,
                           AdjustmentType = s.ReferenceValue,
                           ps.LineNo,
                           ItemCode = im.ItemCode,
                           im.ItemName,
                           ps.CostPrice,
                           ps.SellingPrice,
                           ps.CostValue,
                           ps.SellingValue,
                           ps.Qty,
                           ps.CurrentQty,
                           pm.TotalQty,
                           pm.TotalCostValue,
                           pm.TotalSellingValue
                       });

            return qry.ToDataTable();
        }

    }
}
