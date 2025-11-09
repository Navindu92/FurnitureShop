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
    public class CashierFunction : BaseEntity
    {
        public long CashierFunctionID { get; set; }

        [MaxLength(10)]
        public string CashierFunctionCode { get; set; }

        [MaxLength(50)]
        public string CashierFunctionName { get; set; }

        [DefaultValue(0)]
        public bool IsActive { get; set; }

        [DefaultValue(0)]
        public bool IsDelete { get; set; }

        [NotMapped]
        public bool IsAccess { get; set; }

        [NotMapped]
        public decimal MaxValue { get; set; }


    }
}
