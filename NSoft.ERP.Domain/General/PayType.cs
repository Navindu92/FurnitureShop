using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.General
{
    public class PayType : BaseEntity
    {
        public long PayTypeID { get; set; }
        [MaxLength(10)]
        public string PayTypeCode { get; set; }
        [MaxLength(20)]
        public string PayTypeName { get; set; }

        [DefaultValue(0)]
        public bool IsPopupBank { get; set; }

        [DefaultValue(0)]
        public bool IsUsedReferenceNo { get; set; }

        [DefaultValue(0)]
        public int ReferenceNoLength { get; set; }

        [DefaultValue(0)]
        public bool IsActive { get; set; }

        [DefaultValue(0)]
        public bool IsDelete { get; set; }
    }
}
