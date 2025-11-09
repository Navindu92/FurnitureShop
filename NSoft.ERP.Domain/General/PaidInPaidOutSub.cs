using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.General
{
    public class PaidInPaidOutSub : BaseEntity
    {
        public long PaidInPaidOutSubID { get; set; }
        public long PaidInPaidOutMainID { get; set; }
        public long LineNo { get; set; }
        public long PaidInPaidOutID { get; set; }
        public long CounterNo { get; set; }
        public long LocationID { get; set; }
        public decimal Amount { get; set; }
    }
}
