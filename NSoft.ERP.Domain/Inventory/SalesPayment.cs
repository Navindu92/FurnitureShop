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
    public class SalesPayment:BaseEntity
    {
        public long SalesPaymentID { get; set; }
        public long SalesMainID { get; set; }
        public long LineNo { get; set; }
        public long PayTypeID { get; set; }

        public long BankID { get; set; }

        [NotMapped]
        public string PayType { get; set; }

        [DefaultValue(0)]
        public decimal Amount { get; set; }

        [DefaultValue(0)]
        public decimal Balance { get; set; }
        public string Reference { get; set; }

        [MaxLength(20)]
        public string DocumentNo { get; set; }
        public long DocumentID { get; set; }
        public long CounterNo { get; set; }
        public long LocationID { get; set; }
        public long Zno { get; set; }
        public DateTime ZDate { get; set; }

    }
}
