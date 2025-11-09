using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NSoft.ERP.Domain.General
{
    public class Location:BaseEntity
    {
        public long LocationID { get; set; }
        [MaxLength(10)]
        public string LocationCode { get; set; }
        [MaxLength(20)]
        public string LocationName { get; set; }
        [MaxLength(50)]
        [DefaultValue("")]
        public string Address { get; set; }
        [DefaultValue(0)]
        public bool IsStock { get; set; }
        [DefaultValue(0)]
        public bool IsActive { get; set; }

        [DefaultValue(0)]
        public bool IsHeadOffice { get; set; }

        [DefaultValue(0)]
        public bool IsDelete { get; set; }
    }
}
