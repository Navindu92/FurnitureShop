using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.Inventory
{
    public class SalesTemp
    {
        public long SalesTempID { get; set; }
        public string DocumentNo { get; set; }
        public long CounterNo { get; set; }
        public long LocationID { get; set; }
        public long ItemID { get; set; }
        [MaxLength(20)]
        public string ItemCode { get; set; }
        [MaxLength(60)]
        public string ItemName { get; set; }
        [DefaultValue(0)]
        public decimal SellingPrice { get; set; }

        [NotMapped]
        public decimal NewSellingPrice { get; set; }

        [DefaultValue(0)]
        public decimal CostPrice { get; set; }
        [DefaultValue(0)]
        public long LineNo { get; set; }
        [DefaultValue(0)]
        public decimal CurrentQty { get; set; }
        [DefaultValue(0)]
        public decimal Qty { get; set; }

        [DefaultValue(0)]
        public decimal TotalAmount { get; set; }
        [DefaultValue(0)]
        public decimal FixedDiscount { get; set; }
        [DefaultValue(0)]
        public decimal DiscountPercentage { get; set; }
        [DefaultValue(0)]
        public decimal DiscountAmount { get; set; }
        [DefaultValue(0)]
        public decimal NetAmount { get; set; }

        [MaxLength(20)]
        public string HoldDocumentNo { get; set; }

    }
}
