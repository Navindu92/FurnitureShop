using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.Inventory
{
    public class OpeningStockSub:BaseEntity
    {
        public long OpeningStockSubID { get; set; }
        public long OpeningStockMainID { get; set; }
        public long LineNo { get; set; }
        public long ItemID { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal Qty { get; set; }
        public decimal CostValue { get; set; }
        public decimal SellingValue { get; set; }
    }
}
