using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NSoft.ERP.Domain;
using NSoft.ERP.Data;
using NSoft.ERP.Domain.General;

namespace NSoft.ERP.Service.General
{
    public static class FormInfoService
    {
        static ERPDBContext context = new ERPDBContext();
        public static FormInfo GetFormInfoByName(string formName)
        {
            return context.FormInfo.Where(f => f.IsActive == true && f.IsDelete == false && f.FormName==formName).FirstOrDefault();
        }
        public static FormInfo GetFormInfoByDocumentId(long documentId)
        {
            return context.FormInfo.Where(f => f.IsActive == true && f.IsDelete == false && f.DocumentID == documentId).FirstOrDefault();
        }
    }
}
