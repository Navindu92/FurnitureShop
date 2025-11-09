using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.Accounts
{
    public class ChequeBookEntry : BaseEntity
    {
        public int ChequeBookEntryID { get; set; }
        public DateTime ChequeDate { get; set; }
        public string ChequeNo { get; set; }
        public string PayeeName { get; set; }
        public bool IsCrossed { get; set; }
        public decimal Amount { get; set; }
        public DateTime PrintDate { get; set; }
        public bool IsPrint { get; set; }
    }
}
