using NSoft.ERP.Data;
using NSoft.ERP.Domain.General;
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
    public class SupplierService
    {
        ERPDBContext context = new ERPDBContext();

        public string[] GetAllSupplierCodes()
        {
            return context.Supplier.Where(d => d.IsDelete == false).Select(u => u.SupplierCode).ToArray();
        }
        public string[] GetAllActiveSupplierCodes()
        {
            return context.Supplier.Where(d => d.IsDelete == false && d.IsActive == true).Select(u => u.SupplierCode).ToArray();
        }

        public string[] GetAllSupplierNames()
        {
            return context.Supplier.Where(d => d.IsDelete == false).Select(u => u.SupplierName).ToArray();
        }
        public string[] GetAllActiveSupplierNames()
        {
            return context.Supplier.Where(d => d.IsDelete == false && d.IsActive == true).Select(u => u.SupplierName).ToArray();
        }

        public List<Supplier> GetAllActiveSupplier()
        {
            return context.Supplier.Where(d => d.IsDelete == false && d.IsActive == true).ToList();
        }
        public string GetNewCode(FormInfo formInfo)
        {
            string prefix;
            int codeLength;
            string newCode;
            prefix = formInfo.Prefix;
            if (prefix == string.Empty) { prefix = ""; }
            codeLength = formInfo.CodeLength;
            newCode = context.Supplier.Where(d => d.IsDelete == false).Max(d => d.SupplierCode.Substring(prefix.Length, codeLength));
            if (newCode == null)
            {
                newCode = "0";
            }

            newCode = (int.Parse(newCode) + 1).ToString();
            newCode = prefix + newCode.PadLeft(codeLength - prefix.Length, '0');
            return newCode;
        }

        public Supplier GetSupplierByID(long supplierID)
        {
            return context.Supplier.Where(d => d.SupplierID == supplierID && d.IsDelete == false).FirstOrDefault();
        }
        public Supplier GetActiveSupplierByID(long supplierID)
        {
            return context.Supplier.Where(d => d.SupplierID == supplierID && d.IsDelete == false && d.IsActive == true).FirstOrDefault();
        }
        public Supplier GetSupplierByCode(string supplierCode)
        {
            return context.Supplier.Where(d => d.SupplierCode == supplierCode && d.IsDelete == false).FirstOrDefault();
        }

        public Supplier GetActiveSupplierByCode(string supplierCode)
        {
            return context.Supplier.Where(d => d.SupplierCode == supplierCode && d.IsActive == true && d.IsDelete == false).FirstOrDefault();
        }

        public Supplier GetSupplierByName(string supplierName)
        {
            return context.Supplier.Where(d => d.SupplierName == supplierName && d.IsDelete == false).FirstOrDefault();
        }
        public Supplier GetActiveSupplierByName(string supplierName)
        {
            return context.Supplier.Where(d => d.SupplierName == supplierName && d.IsActive == true && d.IsDelete == false).FirstOrDefault();
        }

        public void AddSupplier(Supplier supplier)
        {
            context.Supplier.Add(supplier);
            context.SaveChanges();
        }

        public void UpdateSupplier(Supplier supplier)
        {
            supplier.ModifiedUser = Common.LoggedUserName;
            supplier.ModifiedDate = DateTime.Now;
            this.context.Entry(supplier).State = EntityState.Modified;
            this.context.SaveChanges();
        }
        public void DeleteSupplier(Supplier Supplier)
        {
            Supplier.ModifiedUser = Common.LoggedUserName;
            Supplier.ModifiedDate = DateTime.Now;
            Supplier.IsDelete = true;
            this.context.Entry(Supplier).State = EntityState.Modified;
            this.context.SaveChanges();
        }
    }
}
