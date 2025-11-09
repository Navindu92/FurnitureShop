using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.CRM
{
    public class LoyaltyTransaction : BaseEntity
    {
        public long LoyaltyTransactionID { get; set; }
        public long LoyaltyCustomerID { get; set; }
        public DateTime TransactionDate { get; set; }
        public long CounterID { get; set; }
        public long LocationID { get; set; }
        public long Zno { get; set; }
        public long TransactionType { get; set; } // 1 -Earn 2 -Redeem

        [MaxLength(20)]
        public string DocumentNo { get; set; }

        [DefaultValue(0)]
        public decimal Amount { get; set; }

        [DefaultValue(0)]
        public decimal PointsRate { get; set; }

        [DefaultValue(0)]
        public decimal Points { get; set; }

    }
}
