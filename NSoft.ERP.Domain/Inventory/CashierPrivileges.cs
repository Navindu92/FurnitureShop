using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.Inventory
{
    public class CashierPrivileges:BaseEntity
    {
        public long CashierPrivilegesID { get; set; }
        public long CashierID { get; set; }
        public long CashierFunctionID { get; set; }

        [DefaultValue(0)]
        public bool IsAccess { get; set; }

        [DefaultValue(0)]
        public decimal MaxValue { get; set; }

    }
}
