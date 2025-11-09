using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.Inventory
{
    public class ItemSupplier:BaseEntity
    {
        public long ItemSupplierID { get; set; }
        [DefaultValue(0)]
        public long ItemID { get; set; }
        [DefaultValue(0)]
        public long SupplierID { get; set; }
        [NotMapped]
        public string SupplierCode { get; set; }
        [NotMapped]
        public string SupplierName { get; set; }

        [NotMapped]
        public long LineNo { get; set; }

        [DefaultValue(0)]
        public bool IsDelete { get; set; }
    }
}
