using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.Inventory
{
    public class StockAdjustmentSub : BaseEntity
    {
        public long StockAdjustmentSubID { get; set; }
        public long StockAdjustmentMainID { get; set; }
        public long LineNo { get; set; }
        public long ItemID { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal CurrentQty { get; set; }
        public decimal Qty { get; set; }
        public decimal AddQty { get; set; }
        public decimal ReduceQty { get; set; }
        public decimal AdjustQty { get; set; }
        public decimal CostValue { get; set; }
        public decimal SellingValue { get; set; }
        public int AdjustmentType { get; set; } // 1-Add Stock 2-Reduce Stock
    }
}
