using MoreLinq;
using NSoft.ERP.Data;
using NSoft.ERP.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Service.Inventory
{
    public class BarcodeService
    {
        ERPDBContext context = new ERPDBContext();
        public List<BarcodeTemp> GetUpdatedBarcodeTempList(List<BarcodeTemp> existingList, BarcodeTemp barcodeTemp)
        {

            List<BarcodeTemp> rtnList = new List<BarcodeTemp>();
            BarcodeTemp existingBarcodeTemp;
            rtnList = existingList;
            long lineNo = 0;
            existingBarcodeTemp = rtnList.Where(i => i.ItemID == barcodeTemp.ItemID && i.CostPrice == barcodeTemp.CostPrice && i.SellingPrice == barcodeTemp.SellingPrice).FirstOrDefault();
            if (rtnList.ToList().Count == 0)
            { lineNo = 1; }
            else
            { lineNo = rtnList.Max(m => m.LineNo) + 1; }

            if (existingBarcodeTemp == null)
            {
                barcodeTemp.LineNo = lineNo;
                barcodeTemp.ItemID = barcodeTemp.ItemID;
                barcodeTemp.ItemCode = barcodeTemp.ItemCode;
                barcodeTemp.ItemName = barcodeTemp.ItemName;
                barcodeTemp.SellingPrice = barcodeTemp.SellingPrice;
                barcodeTemp.CostPrice = barcodeTemp.CostPrice;

            }
            else
            {
                rtnList.Remove(existingBarcodeTemp);
                barcodeTemp.LineNo = existingBarcodeTemp.LineNo;
                barcodeTemp.ItemID = existingBarcodeTemp.ItemID;
                barcodeTemp.ItemCode = existingBarcodeTemp.ItemCode;
                barcodeTemp.ItemName = existingBarcodeTemp.ItemName;
                barcodeTemp.SellingPrice = barcodeTemp.SellingPrice;

            }
            rtnList.Add(barcodeTemp);
            return rtnList.OrderBy(o => o.LineNo).ToList();
        }
        public List<BarcodeTemp> GetUpdatedBarcodeTempListWithDelete(List<BarcodeTemp> existingList, BarcodeTemp barcodeTemp)
        {
            List<BarcodeTemp> rtnList = new List<BarcodeTemp>();
            BarcodeTemp existingBarcodeTemp;
            rtnList = existingList;
            long removedLineNo = 0;
            existingBarcodeTemp = rtnList.Where(i => i.ItemID == barcodeTemp.ItemID && i.CostPrice == barcodeTemp.CostPrice && i.SellingPrice == barcodeTemp.SellingPrice).FirstOrDefault();
            if (existingBarcodeTemp != null)
            {
                rtnList.Remove(existingBarcodeTemp);
            }
            removedLineNo = existingBarcodeTemp.LineNo;
            rtnList.ToList().Where(d => d.LineNo > removedLineNo).ForEach(x => x.LineNo = x.LineNo - 1);

            return rtnList.OrderBy(o => o.LineNo).ThenBy(n => n.LineNo).ToList();
        }
    }
}
