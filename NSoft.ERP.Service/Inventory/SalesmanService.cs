using NSoft.ERP.Data;
using NSoft.ERP.Domain.General;
using NSoft.ERP.Domain.Inventory;
using NSoft.ERP.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;

namespace NSoft.ERP.Service.Inventory
{
    public class SalesmanService
    {
        ERPDBContext context = new ERPDBContext();

        public string[] GetAllSalesmanCodes()
        {
            return context.Salesman.Where(d => d.IsDelete == false).Select(u => u.SalesmanCode).ToArray();
        }
        public string[] GetAllActiveSalesmanCodes()
        {
            return context.Salesman.Where(d => d.IsDelete == false && d.IsActive == true).Select(u => u.SalesmanCode).ToArray();
        }

        public string[] GetAllSalesmanNames()
        {
            return context.Salesman.Where(d => d.IsDelete == false).Select(u => u.SalesmanName).ToArray();
        }
        public string[] GetAllActiveSalesmanNames()
        {
            return context.Salesman.Where(d => d.IsDelete == false && d.IsActive == true).Select(u => u.SalesmanName).ToArray();
        }

        public List<Salesman> GetAllActiveSalesman()
        {
            return context.Salesman.Where(d => d.IsDelete == false && d.IsActive == true).ToList();
        }
        public string GetNewCode(FormInfo formInfo)
        {
            string prefix;
            int codeLength;
            string newCode;
            prefix = formInfo.Prefix;
            if (prefix == string.Empty) { prefix = ""; }
            codeLength = formInfo.CodeLength;
            newCode = context.Salesman.Where(d => d.IsDelete == false).Max(d => d.SalesmanCode.Substring(prefix.Length, codeLength));
            if (newCode == null)
            {
                newCode = "0";
            }

            newCode = (int.Parse(newCode) + 1).ToString();
            newCode = prefix + newCode.PadLeft(codeLength - prefix.Length, '0');
            return newCode;
        }

        public Salesman GetSalesmanByID(long brandID)
        {
            return context.Salesman.Where(d => d.SalesmanID == brandID && d.IsDelete == false).FirstOrDefault();
        }
        public Salesman GetActiveSalesmanByID(long brandID)
        {
            return context.Salesman.Where(d => d.SalesmanID == brandID && d.IsDelete == false && d.IsActive == true).FirstOrDefault();
        }
        public Salesman GetSalesmanByCode(string brandCode)
        {
            return context.Salesman.Where(d => d.SalesmanCode == brandCode && d.IsDelete == false).FirstOrDefault();
        }

        public Salesman GetActiveSalesmanByCode(string brandCode)
        {
            return context.Salesman.Where(d => d.SalesmanCode == brandCode && d.IsActive == true && d.IsDelete == false).FirstOrDefault();
        }

        public Salesman GetSalesmanByName(string brandName)
        {
            return context.Salesman.Where(d => d.SalesmanName == brandName && d.IsDelete == false).FirstOrDefault();
        }
        public Salesman GetActiveSalesmanByName(string brandName)
        {
            return context.Salesman.Where(d => d.SalesmanName == brandName && d.IsActive == true && d.IsDelete == false).FirstOrDefault();
        }

        public void AddSalesman(Salesman brand)
        {
            context.Salesman.Add(brand);
            context.SaveChanges();
        }

        public void UpdateSalesman(Salesman brand)
        {
            brand.ModifiedUser = Common.LoggedUserName;
            brand.ModifiedDate = DateTime.Now;
            this.context.Entry(brand).State = EntityState.Modified;
            this.context.SaveChanges();
        }
        public void DeleteSalesman(Salesman Salesman)
        {
            Salesman.ModifiedUser = Common.LoggedUserName;
            Salesman.ModifiedDate = DateTime.Now;
            Salesman.IsDelete = true;
            this.context.Entry(Salesman).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        public DataTable GetSalesmanDataTableForSearch()
        {
            var query = (from c in context.Salesman
                         where c.IsDelete == false
                         select new
                         {
                             c.SalesmanCode,
                             c.SalesmanName,
                             c.Remark
                         });

            return query.ToDataTable();
        }
        public DataTable GetActiveSalesmanDataTableForSearch()
        {
            var query = (from c in context.Salesman
                         where c.IsDelete == false && c.IsActive==true
                         select new
                         {
                             c.SalesmanCode,
                             c.SalesmanName,
                             c.Remark
                         });

            return query.ToDataTable();
        }
    }
}
