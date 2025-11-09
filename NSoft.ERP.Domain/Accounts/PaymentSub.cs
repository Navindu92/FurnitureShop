using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.Accounts
{
    public class PaymentSub : BaseEntity
    {
        public long PaymentSubID { get; set; }

        public long PaymentMainID { get; set; }

        public long PayTypeID { get; set; }

        [NotMapped]
        public string PayTypeName { get; set; }

        public string ReferenceNo { get; set; }

        public long LineNo { get; set; }

        public DateTime PaymentDate { get; set; }

        public decimal Amount { get; set; }

    }
}
