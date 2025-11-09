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
    public class NumberSetup:BaseEntity
    {
        public long NumberSetupID { get; set; }
        [MaxLength(10)]
        public string NumberSetupCode { get; set; }
        [MaxLength(20)]
        public string NumberSetupName { get; set; }
        public long DocumentID { get; set; }
        public long SerialNo { get; set; }

        [DefaultValue(0)]
        public bool IsDelete { get; set; }
        
    }
}
