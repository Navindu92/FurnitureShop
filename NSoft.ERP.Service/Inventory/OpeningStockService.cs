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

namespace NSoft.ERP.Service.Inventory
{
    public class OpeningStockService
    {
        ERPDBContext context = new ERPDBContext();
        public List<OpeningStockTemp> GetUpdatedOpeningStockTempList(List<OpeningStockTemp> existingList, OpeningStockTemp openingStockTemp)
        {

            List<OpeningStockTemp> rtnList = new List<OpeningStockTemp>();
            OpeningStockTemp existingOpeningStockTemp;
            rtnList = existingList;
            long lineNo = 0;
            existingOpeningStockTemp = rtnList.Where(i => i.ItemID == openingStockTemp.ItemID).FirstOrDefault();
            if (rtnList.ToList().Count == 0)
            { lineNo = 1; }
            else
            { lineNo = rtnList.Max(m => m.LineNo) + 1; }

            if (existingOpeningStockTemp == null)
            {
                openingStockTemp.LineNo = lineNo;
                openingStockTemp.ItemID = openingStockTemp.ItemID;
                openingStockTemp.ItemCode = openingStockTemp.ItemCode;
                openingStockTemp.ItemName = openingStockTemp.ItemName;
                openingStockTemp.SellingPrice = openingStockTemp.SellingPrice;
                openingStockTemp.CostPrice = openingStockTemp.CostPrice;
                openingStockTemp.SellingValue = openingStockTemp.SellingValue;
                openingStockTemp.CostValue = openingStockTemp.SellingValue;
            }
            else
            {
                rtnList.Remove(existingOpeningStockTemp);
                openingStockTemp.LineNo = existingOpeningStockTemp.LineNo;
                openingStockTemp.ItemID = existingOpeningStockTemp.ItemID;
                openingStockTemp.ItemCode = existingOpeningStockTemp.ItemCode;
                openingStockTemp.ItemName = existingOpeningStockTemp.ItemName;
                openingStockTemp.SellingPrice = openingStockTemp.SellingPrice;
                openingStockTemp.CostPrice = openingStockTemp.CostPrice;
                openingStockTemp.SellingValue = openingStockTemp.SellingValue;
                openingStockTemp.CostValue = openingStockTemp.CostValue;
            }
            rtnList.Add(openingStockTemp);
            return rtnList.OrderBy(o => o.LineNo).ToList();
        }
        public List<OpeningStockTemp> GetUpdatedOpeningStockTempListWithDelete(List<OpeningStockTemp> existingList, OpeningStockTemp openingStockTemp)
        {
            List<OpeningStockTemp> rtnList = new List<OpeningStockTemp>();
            OpeningStockTemp existinginvestigationTemp;
            rtnList = existingList;
            long removedLineNo = 0;
            existinginvestigationTemp = rtnList.Where(i => i.ItemID == openingStockTemp.ItemID && i.SellingPrice == openingStockTemp.SellingPrice).FirstOrDefault();
            if (existinginvestigationTemp != null)
            {
                rtnList.Remove(existinginvestigationTemp);
            }
            removedLineNo = existinginvestigationTemp.LineNo;
            rtnList.ToList().Where(d => d.LineNo > removedLineNo).ForEach(x => x.LineNo = x.LineNo - 1);

            return rtnList.OrderBy(o => o.LineNo).ThenBy(n => n.LineNo).ToList();
        }

        public bool Save(FormInfo formInfo, OpeningStockMain openingStockMain, List<OpeningStockTemp> openingStockSubList, out string documenNo)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                documenNo = CommonService.GenarateDocumentNo(formInfo).Trim();
                openingStockMain.DocumentNo = documenNo;
                openingStockMain.DocumentID = formInfo.DocumentID;
                context.OpeningStockMain.Add(openingStockMain);
                this.context.SaveChanges();
                openingStockSubList.ToList().ForEach(x =>
                {
                    OpeningStockSub openingStockSub = new OpeningStockSub();
                    openingStockSub.OpeningStockMainID = openingStockMain.OpeningStockMainID;
                    openingStockSub.LineNo = x.LineNo;
                    openingStockSub.ItemID = x.ItemID;
                    openingStockSub.CostPrice = x.CostPrice;
                    openingStockSub.SellingPrice = x.SellingPrice;
                    openingStockSub.Qty = x.Qty;                   
                    openingStockSub.CostValue = x.CostValue;
                    openingStockSub.SellingValue = x.SellingValue;
                    context.OpeningStockSub.Add(openingStockSub);
                    this.context.SaveChanges();
                });

                var parameter = new DbParameter[]
               {
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@OpeningStockMainID", Value=openingStockMain.OpeningStockMainID},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@DocumentID", Value=openingStockMain.DocumentID},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@DocumentNo", Value=openingStockMain.DocumentNo},
                        new System.Data.SqlClient.SqlParameter { ParameterName ="@LocationID", Value=openingStockMain.LocationID},
               };

                if (CommonService.ExecuteStoredProcedure("spOpeningStockSave", parameter))
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
        public OpeningStockMain GetAllOpeningStockMainByDocumentNo(string documentNo)
        {
            OpeningStockMain openingStockMain = new OpeningStockMain();

            var qry = (from om in context.OpeningStockMain
                       where om.DocumentNo.Equals(documentNo)
                       select new
                       {
                           om.OpeningStockMainID,
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
                openingStockMain.OpeningStockMainID = item.OpeningStockMainID;
                openingStockMain.DocumentNo = item.DocumentNo.Trim();
                openingStockMain.ReferenceNo = item.ReferenceNo.Trim();
                openingStockMain.Remarks = item.Remarks.Trim();
                openingStockMain.TotalQty = item.TotalQty;
                openingStockMain.TotalCostValue = item.TotalCostValue;
                openingStockMain.TotalSellingValue = item.TotalSellingValue;
            }
            return openingStockMain;
        }

        public DataTable GetAllOpeningStockSubByOpeningStockMainID(long openingStockMainID)
        {
            var qry = (from ins in context.OpeningStockSub
                       join d in context.Item on ins.ItemID equals d.ItemID
                       where ins.OpeningStockMainID == openingStockMainID
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

    }
}
