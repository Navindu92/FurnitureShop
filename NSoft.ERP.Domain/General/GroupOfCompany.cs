using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.General
{
    public class GroupOfCompany
    {
        public int GroupOfCompanyID { get; set; }
        public string GroupOfCompanyCode { get; set; }

        [MaxLength(50)]
        public string GroupOfCompanyName { get; set; }

        [MaxLength(30)]
        public string Address1 { get; set; }

        [MaxLength(30)]
        public string Address2 { get; set; }


        [DefaultValue(0)]
        public bool IsActive { get; set; }

        [DefaultValue(0)]
        public bool IsDelete { get; set; }
    }
}
