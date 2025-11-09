using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.General
{
    public class CounterTransaction:BaseEntity
    {
        public long CounterTransactionID { get; set; }
        public long LocationID { get; set; }
        public long TransactionTypeID { get; set; } // 1 - Open 2 - Close
        public long CounterNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public long UserID { get; set; }
        public decimal Amount { get; set; }
        public long Zno { get; set; }
        public DateTime ZDate { get; set; }
    }
}
