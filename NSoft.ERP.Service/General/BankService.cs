using NSoft.ERP.Data;
using NSoft.ERP.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Service.General
{
    public class BankService
    {
        ERPDBContext context = new ERPDBContext();
        public List<Bank> GetAllActiveBank()
        {
            return context.Bank.Where(d => d.IsDelete == false && d.IsActive == true).ToList();
        }
    }
}
