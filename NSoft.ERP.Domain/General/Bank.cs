using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.General
{
    public class Bank : BaseEntity
    {
        public long BankID { get; set; }
        [MaxLength(10)]
        public string BankCode { get; set; }
        [MaxLength(60)]
        public string BankName { get; set; }
        [DefaultValue(0)]
        public bool IsTerminal { get; set; }
        [DefaultValue(0)]
        public bool IsActive { get; set; }

        [DefaultValue(0)]
        public bool IsDelete { get; set; }
    }
}
