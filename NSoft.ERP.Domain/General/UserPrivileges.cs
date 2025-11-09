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
    public class UserPrivileges : BaseEntity
    {
        public long UserPrivilegesID { get; set; }
        public long UserID { get; set; }
        public long FormInfoID { get; set; }

        [NotMapped]
        public string FormText { get; set; }
        [NotMapped]
        public long FormType { get; set; }
        [DefaultValue(0)]
        public bool IsAccess { get; set; }
        [DefaultValue(0)]
        public bool IsSave { get; set; }
        [DefaultValue(0)]
        public bool IsRemove { get; set; }
        [DefaultValue(0)]
        public bool IsDelete { get; set; }
    }
}
