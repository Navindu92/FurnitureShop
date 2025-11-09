using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.General
{
    public class PaidInPaidOutMain : BaseEntity
    {
        public long PaidInPaidOutMainID { get; set; }
        [MaxLength(20)]
        public string DocumentNo { get; set; }
        public long DocumentID { get; set; }
        public DateTime DocumentDate { get; set; }
        public long CounterNo { get; set; }
        public long LocationID { get; set; }
        public int PaidInPaidOutType { get; set; }
        public string Person { get; set; }
        public decimal TotalAmount { get; set; }
        public long Zno { get; set; }
        public DateTime ZDate { get; set; }
    }
}
