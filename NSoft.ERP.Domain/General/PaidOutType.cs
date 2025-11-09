using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.General
{
    public class PaidOutType:BaseEntity
    {
        public long PaidOutTypeID { get; set; }
        [MaxLength(10)]
        public string PaidOutTypeCode { get; set; }
        [MaxLength(20)]
        public string PaidOutTypeName { get; set; }
        public decimal Amount { get; set; }

        [DefaultValue(0)]
        public bool IsActive { get; set; }
        [DefaultValue(0)]
        public bool IsDelete { get; set; }
    }
}
