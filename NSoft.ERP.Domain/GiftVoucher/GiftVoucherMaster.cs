using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.GiftVoucher
{
    public class GiftVoucherMaster : BaseEntity
    {
        public long GiftVoucherMasterID { get; set; }
        public long GiftVoucherBookID { get; set; }
        public long GiftVoucherGroupID { get; set; }
        [MaxLength(30)]
        public string VoucherNo { get; set; }
        public decimal VoucherValue { get; set; }
        public int VoucherStatus { get; set; } // 1 - Create,2 - GRN 3 - TOG,4 - Issue,5 - LOST,6-Redeem
        public string VoucherPrefix { get; set; }
        public long CreatedLocationID { get; set; }
        public long IssuedLocationID { get; set; }
        public long IssuedCashierID { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime IssuedCounterID { get; set; }
        public DateTime IssuedZNo { get; set; }
        public DateTime IssuedInvoiceNo { get; set; }
        public long RedeemedLocationID { get; set; }
        public long RedeemedCashierID { get; set; }
        public DateTime RedeemedDate { get; set; }
        public DateTime RedeemedCounterID { get; set; }
        public DateTime RedeemedZNo { get; set; }
        public DateTime RedeemedInvoiceNo { get; set; }
    }
}
