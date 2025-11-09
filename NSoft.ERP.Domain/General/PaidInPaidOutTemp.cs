using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.General
{
    public class PaidInPaidOutTemp
    {
        public long PaidInPaidOutID { get; set; }
        [MaxLength(10)]
        public string PaidInPaidOutCode { get; set; }
        [MaxLength(40)]

        public string PaidInPaidOutName { get; set; }

        public long LineNo { get; set; }
        public decimal Amount { get; set; }
    }
}
