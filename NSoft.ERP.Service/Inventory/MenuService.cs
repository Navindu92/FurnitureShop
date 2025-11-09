using NSoft.ERP.Data;
using NSoft.ERP.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Service.Inventory
{
    public class MenuService
    {
        ERPDBContext context = new ERPDBContext();

        public List<Menu> GetAllActiveMenu()
        {
            return context.Menu.Where(d => d.IsDelete == false && d.IsActive == true).ToList();
        }
    }
}
