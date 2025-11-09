using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.GiftVoucher
{
    public class GiftVoucherBook : BaseEntity
    {
        public long GiftVoucherBookID { get; set; }
        [MaxLength(10)]
        public string GiftVoucherBookCode { get; set; }
        [MaxLength(60)]
        public string GiftVoucherBookName { get; set; }
        public long GiftVoucherGroupID { get; set; }
        public long StartingNo { get; set; }
        public long NoOfVouchers { get; set; }
        public long VoucherLength { get; set; }
        public long VoucherPrefix { get; set; }
        public decimal VoucherValue { get; set; }
    }
}
