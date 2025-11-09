using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.Accounts
{
    public class PaymentMain : BaseEntity
    {
        public long PaymentMainID { get; set; }

        [MaxLength(20)]
        public string DocumentNo { get; set; }

        public DateTime DocumentDate { get; set; }

        public DateTime PaymentDate { get; set; }

        public long DocumentID { get; set; }

        public long LocationID { get; set; }

        public long ReferenceDocumentID { get; set; }

        public long ReferenceDocumentDocumentID { get; set; }

        public long ReferenceLocationID { get; set; }

        public long ReferenceTypeID { get; set; } // 1 -Supplier 2-Customer

        public long ReferenceID { get; set; }

        public decimal Amount { get; set; }

        public decimal BalanceAmount { get; set; }

        public string Remark { get; set; }

        [NotMapped]
        public string ReferenceNo { get; set; }

        [NotMapped]
        public long LineNo { get; set; }

        [NotMapped]
        public decimal PayAmount { get; set; }

    }
}
