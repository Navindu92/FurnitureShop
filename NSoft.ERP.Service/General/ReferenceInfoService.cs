using NSoft.ERP.Data;
using NSoft.ERP.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Service.General
{
    public class ReferenceInfoService
    {
        ERPDBContext context = new ERPDBContext();
        public List<ReferenceInfo> GetReferenceValuesByID(int referenceTypeID)
        {
            return context.ReferenceInfo.Where(rt => rt.ReferenceTypeID == referenceTypeID && rt.IsDelete == false && rt.IsActive == true).ToList();
        }
    }
}
