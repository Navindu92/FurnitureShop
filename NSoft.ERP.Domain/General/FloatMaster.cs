using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.General
{
    public class FloatMaster : BaseEntity
    {
        public int FloatMasterID { get; set; }

        public string FloatCode { get; set; }
        [MaxLength(60)]
        public string FloatName { get; set; }

        [DefaultValue(0)]
        public int FloatValue { get; set; }

        [NotMapped]
        public int FloatCount { get; set; }
        [NotMapped]
        public int FloatAmount { get; set; }

        [DefaultValue(0)]
        public bool IsActive { get; set; }

        [DefaultValue(0)]
        public bool IsDelete { get; set; }
    }
}
