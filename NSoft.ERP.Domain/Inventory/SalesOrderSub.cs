using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.Inventory
{
    public class SalesOrderSub : BaseEntity
    {
        public long SalesOrderSubID { get; set; }
        public long SalesOrderMainID { get; set; }
        public long LineNo { get; set; }
        public long ItemID { get; set; }
        [DefaultValue(0)]
        public decimal SellingPrice { get; set; }
        [DefaultValue(0)]
        public decimal CostPrice { get; set; }
        [DefaultValue(0)]
        public decimal CurrentQty { get; set; }
        [DefaultValue(0)]
        public decimal Qty { get; set; }
        [DefaultValue(0)]
        public decimal BalanceQty { get; set; }
        [DefaultValue(0)]
        public decimal DiscountPercentage { get; set; }
        [DefaultValue(0)]
        public decimal DiscountAmount { get; set; }
        [DefaultValue(0)]
        public decimal Amount { get; set; }
    }
}
