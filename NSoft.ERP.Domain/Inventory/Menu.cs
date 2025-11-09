using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.Inventory
{
    public class Menu : BaseEntity
    {
        public long MenuID { get; set; }
        [MaxLength(10)]
        public string MenuCode { get; set; }
        [MaxLength(60)]
        public string MenuName { get; set; }

        [DefaultValue(0)]

        public bool IsActive { get; set; }

        [DefaultValue(0)]
        public bool IsDelete { get; set; }
    }
}
