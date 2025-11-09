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
    public class SystemLog
    {
        public long SystemLogID { get; set; }
       
        [MaxLength(20)]
        public string Username { get; set; }
        [MaxLength(20)]
        public string Location { get; set; }
        public string MachineName { get; set; }
        public string DomainName { get; set; }
        public string PCUserName { get; set; }
        public string OsVersion { get; set; }
        public DateTime LoggedDate { get; set; }
        public TimeSpan LoggedTime { get; set; }
        public DateTime LogoutDate { get; set; }
        public TimeSpan LogoutTime { get; set; }
    }
}
