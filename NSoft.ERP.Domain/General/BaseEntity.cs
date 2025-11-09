using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NSoft.ERP.Utility;
namespace NSoft.ERP.Domain
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            GroupOfCompanyID = Common.GroupOfCompanyID;
            CreatedUser = Common.LoggedUserName;
            CreatedDate = DateTime.Now;
            ModifiedUser = Common.LoggedUserName;
            ModifiedDate = DateTime.Now;
        }
        public int GroupOfCompanyID { get; set; }

        [MaxLength(50)]
        public string CreatedUser { get; set; }

        public DateTime CreatedDate { get; set; }

        [MaxLength(50)]
        public string ModifiedUser { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
