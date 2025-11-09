using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.Inventory
{
    public class SalesSub : BaseEntity
    {
        public long SalesSubID { get; set; }
        public long SalesMainID { get; set; }
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
        public decimal TotalAmount { get; set; }

        [DefaultValue(0)]
        public decimal DiscountPercentage { get; set; }
        [DefaultValue(0)]
        public decimal DiscountAmount { get; set; }
        [DefaultValue(0)]
        public decimal NetAmount { get; set; }

        [MaxLength(20)]
        public string DocumentNo { get; set; }
        public long DocumentID { get; set; }
        public long CounterNo { get; set; }
        public long LocationID { get; set; }
        public long Zno { get; set; }
        public DateTime ZDate { get; set; }
    }
}
