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
    public class SystemConfiguration : BaseEntity
    {
        public long SystemConfigurationID { get; set; }
        public long LocationID { get; set; }
        public bool IsAutoSignOut { get; set; }
        public int AutoSignOutTimeDuration { get; set; }
        public bool IsAllowMinusStock { get; set; }
        public bool IsLocationCodePrefix { get; set; }
        public long LaboratoryDepartmentID { get; set; }
        public long AmbulanceDepartmentID { get; set; }
    }
}
