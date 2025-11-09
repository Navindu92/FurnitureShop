using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.GiftVoucher
{
    public class GiftVoucherGroup:BaseEntity
    {
        public long GiftVoucherGroupID { get; set; }
        [MaxLength(10)]
        public string GiftVoucherGroupCode { get; set; }
        [MaxLength(60)]
        public string GiftVoucherGroupName { get; set; }

        [MaxLength(100)]
        [DefaultValue("")]
        public string Remark { get; set; }
        [DefaultValue(0)]

        public bool IsActive { get; set; }

        [DefaultValue(0)]
        public bool IsDelete { get; set; }
    }
}
