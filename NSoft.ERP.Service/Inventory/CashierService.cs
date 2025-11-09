using NSoft.ERP.Data;
using NSoft.ERP.Domain.Inventory;
using NSoft.ERP.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Service.Inventory
{
    public class CashierService
    {
        ERPDBContext context = new ERPDBContext();

        public void AddCashier(Cashier cashier)
        {
            context.Cashier.Add(cashier);
            context.SaveChanges();
        }

        public void UpdateCashier(Cashier cashier)
        {
            cashier.ModifiedUser = Common.LoggedUserName;
            cashier.ModifiedDate = DateTime.Now;
            this.context.Entry(cashier).State = EntityState.Modified;
            this.context.SaveChanges();
        }
        public string[] GetAllCashierNames()
        {
            return context.Cashier.Where(u => u.IsDelete == false && u.IsDeveloper == false).Select(u => u.CashierName).ToArray();
        }
        public string[] GetAllCashierNamesWithDevelopers()
        {
            return context.Cashier.Where(u => u.IsDelete == false).Select(u => u.CashierName).ToArray();
        }

        public List<CashierFunction> GetAllCashierFunction()
        {
            List<CashierFunction> rtnList = new List<CashierFunction>();
            var query = (from f in context.CashierFunction
                         where f.IsActive == true && f.IsDelete == false
                         select new { CashierFunctionID = f.CashierFunctionID, CashierFunctionName = f.CashierFunctionName }).ToList().Distinct();
            foreach (var item in query)
            {
                CashierFunction cashierFunction = new CashierFunction();
                cashierFunction.CashierFunctionID = item.CashierFunctionID;
                cashierFunction.CashierFunctionName = item.CashierFunctionName;
                cashierFunction.MaxValue = 0;

                rtnList.Add(cashierFunction);

            }
            return rtnList.OrderBy(up => up.CashierFunctionID).ToList();
        }
        public Cashier GetCashierByCashierName(string cashierName)
        {
            return context.Cashier.Where(u => u.CashierName == cashierName && u.IsDelete == false && u.IsDeveloper == false).FirstOrDefault();
        }
        public Cashier GetCashierByCashierNameWithDeveloper(string cashierName)
        {
            return context.Cashier.Where(u => u.CashierName == cashierName && u.IsDelete == false).FirstOrDefault();
        }

        public List<CashierFunction> GetAllCashierPrivilegesByCashierName(string cashierName)
        {
            List<CashierFunction> rtnList = new List<CashierFunction>();
            var query = (
                         from f in context.CashierFunction
                         join up in context.CashierPrivileges on f.CashierFunctionID equals up.CashierFunctionID into gj
                         from up in gj.DefaultIfEmpty()
                         join u in context.Cashier on up.CashierID equals u.CashierID
                         where u.CashierName == cashierName && u.IsActive == true && u.IsDelete == false
                         && f.IsActive == true && f.IsDelete == false
                         select new
                         {
                             CashierFunctionID = f.CashierFunctionID,
                             CashierFunctionName = f.CashierFunctionName,
                             IsAccess = up.IsAccess,
                             MaxValue = up.MaxValue

                         }).ToList();
            foreach (var item in query)
            {
                CashierFunction cashierFunction = new CashierFunction();
                cashierFunction.CashierFunctionID = item.CashierFunctionID;
                cashierFunction.CashierFunctionName = item.CashierFunctionName;
                cashierFunction.IsAccess = item.IsAccess;
                cashierFunction.MaxValue = item.MaxValue;

                rtnList.Add(cashierFunction);

            }
            return rtnList.OrderBy(up => up.CashierFunctionID).ToList();
        }

        public CashierPrivileges GetCashierPrivilegeByCashierAndCashierFunctionID(Cashier cashier, long cashierFunctionID)
        {
            return context.CashierPrivileges.Where(up => up.CashierID == cashier.CashierID && up.CashierFunctionID == cashierFunctionID).FirstOrDefault();
        }

        public void AddCashierPrivileges(CashierPrivileges cashierPrivileges)
        {
            context.CashierPrivileges.Add(cashierPrivileges);
            context.SaveChanges();
        }

        public void UpdateCashierPrivileges(CashierPrivileges cashierPrivileges)
        {
            cashierPrivileges.ModifiedUser = Common.LoggedUserName;
            cashierPrivileges.ModifiedDate = DateTime.Now;
            this.context.Entry(cashierPrivileges).State = EntityState.Modified;
            this.context.SaveChanges();
        }
        public Cashier CheckCashierLogin(string password)
        {
            return context.Cashier.Where(u => u.Password == password && u.IsActive == true && u.IsDelete == false).FirstOrDefault();
        }

        public bool GetCashierPrivilegesByFunctionNameAndCashierID(string functionName, long cashierID)
        {
            bool isValid = false;

            var qry = (from f in context.CashierFunction
                       join up in context.CashierPrivileges on f.CashierFunctionID equals up.CashierFunctionID
                       where up.CashierID == cashierID && f.CashierFunctionName == functionName && up.IsAccess == true
                       select new
                       {
                           up.CashierFunctionID
                       }
                     );
            foreach (var item in qry)
            {
                isValid = true;
            }

            return isValid;
        }
        public decimal GetCashierPrivilegesValueByFunctionNameAndCashierID(string functionName, long cashierID)
        {
            decimal maxValue = 0;

            var qry = (from f in context.CashierFunction
                       join up in context.CashierPrivileges on f.CashierFunctionID equals up.CashierFunctionID
                       where up.CashierID == cashierID && f.CashierFunctionName == functionName && up.IsAccess == true
                       select new
                       {
                           up.MaxValue
                       }
                     );
            foreach (var item in qry)
            {
                maxValue=item.MaxValue;
            }

            return maxValue;
        }
    }
}
