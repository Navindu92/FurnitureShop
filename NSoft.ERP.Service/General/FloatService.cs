using NSoft.ERP.Data;
using NSoft.ERP.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Service.General
{
    public class FloatService
    {
        ERPDBContext context = new ERPDBContext();

        public List<FloatMaster> GetAllActiveFloatMaster()
        {
            List<FloatMaster> floatMasterList = new List<FloatMaster>();

            var qry = (from fm in context.FloatMaster
                       where fm.IsActive == true && fm.IsDelete == false
                       select new
                       {
                           fm.FloatMasterID,
                           fm.FloatValue,
                           FloatCount = 0,
                           FloatAmount = 0
                       });

            foreach (var temp in qry)
            {
                FloatMaster floatMaster = new FloatMaster();
                floatMaster.FloatMasterID = temp.FloatMasterID;
                floatMaster.FloatValue = temp.FloatValue;
                floatMaster.FloatCount = temp.FloatCount;
                floatMaster.FloatAmount = temp.FloatAmount;
                floatMasterList.Add(floatMaster);
            }

            return floatMasterList;
        }
    }
}
