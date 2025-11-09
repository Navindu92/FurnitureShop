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
    public class User : BaseEntity
    {
        public long UserID { get; set; }
        [MaxLength(20)]
        public string Username { get; set; }
        [MaxLength(20)]
        public string Password { get; set; }

        [MaxLength(50)]
        [DefaultValue("")]       
        public string FullName { get; set; }
        public long UserGroupID { get; set; }
        [DefaultValue(0)]

        public bool IsDeveloper { get; set; }
        [DefaultValue(0)]
        public bool IsActive { get; set; }

        [DefaultValue(0)]
        public bool IsDelete { get; set; }
    }
}
