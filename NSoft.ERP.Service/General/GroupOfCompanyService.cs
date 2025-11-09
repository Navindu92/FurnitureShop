using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NSoft.ERP.Data;
using NSoft.ERP.Domain.General;
namespace NSoft.ERP.Service.General
{
    public class GroupOfCompanyService
    {
        ERPDBContext context = new ERPDBContext();
        public GroupOfCompany GetActiveGroupOfCompany()
        {
            return context.GroupOfCompany.Where(g => g.IsActive == true && g.IsDelete==false).FirstOrDefault();
        }
    }
}
