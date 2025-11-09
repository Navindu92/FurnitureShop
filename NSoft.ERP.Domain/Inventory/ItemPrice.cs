using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.Inventory
{
    public class ItemPrice:BaseEntity
    {
        public long ItemPriceID { get; set; }
        [DefaultValue(0)]
        public long ItemID { get; set; }

        [DefaultValue(0)]
        public decimal CostPrice { get; set; }

        [DefaultValue(0)]
        public decimal SellingPrice { get; set; }


        [DefaultValue(0)]
          
        public long LineNo { get; set; }

        [DefaultValue(0)]
        public bool IsDelete { get; set; }
    }
}
