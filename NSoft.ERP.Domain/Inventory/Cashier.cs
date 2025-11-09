using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.Inventory
{
    public class Cashier:BaseEntity
    {
        public long CashierID { get; set; }
        [MaxLength(20)]
        public string CashierName { get; set; }
        [MaxLength(20)]
        public string Password { get; set; }
        [MaxLength(20)]
        public string Encode { get; set; }
        [DefaultValue(0)]
        public bool IsActive { get; set; }

        [DefaultValue(0)]
        public bool IsDelete { get; set; }

        [DefaultValue(0)]
        public bool IsDeveloper { get; set; }
    }
}
