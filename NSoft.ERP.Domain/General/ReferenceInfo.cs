using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.General
{
    public class ReferenceInfo:BaseEntity
    {
        public long ReferenceInfoID { get; set; }
        public long ReferenceTypeID { get; set; }
        public long SubNo { get; set; }
        [MaxLength(30)]
        public string ReferenceType { get; set; }
        [MaxLength(60)]
        public string ReferenceValue { get; set; }

        [DefaultValue(0)]
        public bool IsActive { get; set; }

        [DefaultValue(0)]
        public bool IsDelete { get; set; }
    }
}
