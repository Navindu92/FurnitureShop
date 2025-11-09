using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.Inventory
{
    public class StockAdjustmentTemp
    {
        public long ItemID { get; set; }
        [MaxLength(20)]
        public string ItemCode { get; set; }
        [MaxLength(60)]
        public string ItemName { get; set; }
        [DefaultValue(0)]
        public decimal CostPrice { get; set; }
        [DefaultValue(0)]
        public decimal SellingPrice { get; set; }
        [DefaultValue(0)]
        public decimal CurrentQty { get; set; }
        [DefaultValue(0)]
        public decimal Qty { get; set; }
        [DefaultValue(0)]
        public decimal AdjustQty { get; set; }
        [DefaultValue(0)]
        public decimal AddQty { get; set; }
        [DefaultValue(0)]
        public decimal ReduceQty { get; set; }
        [DefaultValue(0)]
        public long LineNo { get; set; }
        public decimal CostValue { get; set; }
        public decimal SellingValue { get; set; }
        public int AdjustmentType { get; set; } // 1-Add Stock 2-Reduce Stock
    }
}
