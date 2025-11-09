using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NSoft.ERP.Domain.Log
{
    public class TransactionLog
    {
        public long TransactionLogID { get; set; }
        [MaxLength(20)]
        public string FormName { get; set; }
        [MaxLength(20)]
        public string Username { get; set; }
        public string PCName { get; set; }
        [MaxLength(20)]
        public string Location { get; set; }
        [MaxLength(10)]
        public string Action { get; set; }
        public DateTime LogDate { get; set; }
        public TimeSpan LogTime { get; set; }
    }
}
