using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.Inventory
{
    public class ItemStock : BaseEntity
    {
        public long ItemStockID { get; set; }
        [DefaultValue(0)]
        public long ItemID { get; set; }
        [DefaultValue(0)]
        public long LocationID { get; set; }
        [NotMapped]
        public string LocationName { get; set; }
        [DefaultValue(0)]
        public decimal Stock { get; set; }
        [DefaultValue(0)]
        public bool IsDelete { get; set; }
    }
}
