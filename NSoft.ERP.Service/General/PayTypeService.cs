using NSoft.ERP.Data;
using NSoft.ERP.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Service.General
{
    public class PayTypeService
    {
        ERPDBContext context = new ERPDBContext();

        public List<PayType> GetAllActivePayTypes()
        {
            return context.PayType.Where(p => p.IsActive == true && p.IsDelete == false).ToList();
        }
        public PayType GetActivePayTypeByID(long payTypeId)
        {
            return context.PayType.Where(p => p.IsActive == true && p.IsDelete == false && p.PayTypeID == payTypeId).FirstOrDefault();
        }
    }
}
