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
    public class UserPrivilegesLocation : BaseEntity
    {
        public long UserPrivilegesLocationID { get; set; }
        public long UserID { get; set; }
        public long LocationID { get; set; }
        [NotMapped]
        public string LocationName { get; set; }

        [DefaultValue(0)]
        public bool IsAllow { get; set; }
        [DefaultValue(0)]
        public bool IsDelete { get; set; }

    }
}
