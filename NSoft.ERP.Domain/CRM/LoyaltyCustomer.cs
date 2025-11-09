using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.CRM
{
    public class LoyaltyCustomer : BaseEntity
    {
        public long LoyaltyCustomerID { get; set; }
        [MaxLength(30)]
        public string CardNo { get; set; }
        [MaxLength(60)]
        public string LoyaltyCustomerName { get; set; }
        public string NICNo { get; set; }
        [MaxLength(10)]
        public string MobileNo { get; set; }

        public DateTime DateOfBirth { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        public long LoyaltyCardID { get; set; }

        [DefaultValue(0)]
        public bool IsActive { get; set; }
        [DefaultValue(0)]
        public bool IsBlackList { get; set; }
        public DateTime ExpiryDate { get; set; }

        [DefaultValue(0)]
        public decimal EarnPoints { get; set; }
        [DefaultValue(0)]
        public decimal RedeemPoints { get; set; }
        [DefaultValue(0)]
        public decimal CurrentPoints { get; set; }

        [DefaultValue(0)]
        public bool IsDelete { get; set; }
    }
}
