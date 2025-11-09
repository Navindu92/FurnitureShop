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
    public class UserGroup : BaseEntity
    {
        public long UserGroupID { get; set; }
        [MaxLength(20)]
        public string UserGroupCode { get; set; }
        [MaxLength(20)]
        public string UserGroupName { get; set; }
        public bool IsActive { get; set; }

        [DefaultValue(0)]
        public bool IsDelete { get; set; }
    }
}
