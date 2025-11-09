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
    public class SupplierGroupService
    {
        ERPDBContext context = new ERPDBContext();

        public string[] GetAllSupplierGroupCodes()
        {
            return context.SupplierGroup.Where(d => d.IsDelete == false).Select(u => u.SupplierGroupCode).ToArray();
        }
        public string[] GetAllActiveSupplierGroupCodes()
        {
            return context.SupplierGroup.Where(d => d.IsDelete == false && d.IsActive == true).Select(u => u.SupplierGroupCode).ToArray();
        }

        public string[] GetAllSupplierGroupNames()
        {
            return context.SupplierGroup.Where(d => d.IsDelete == false).Select(u => u.SupplierGroupName).ToArray();
        }
        public string[] GetAllActiveSupplierGroupNames()
        {
            return context.SupplierGroup.Where(d => d.IsDelete == false && d.IsActive == true).Select(u => u.SupplierGroupName).ToArray();
        }

        public List<SupplierGroup> GetAllActiveSupplierGroup()
        {
            return context.SupplierGroup.Where(d => d.IsDelete == false && d.IsActive == true).ToList();
        }
        public string GetNewCode(FormInfo formInfo)
        {
            string prefix;
            int codeLength;
            string newCode;
            prefix = formInfo.Prefix;
            if (prefix == string.Empty) { prefix = ""; }
            codeLength = formInfo.CodeLength;
            newCode = context.SupplierGroup.Where(d => d.IsDelete == false).Max(d => d.SupplierGroupCode.Substring(prefix.Length, codeLength));
            if (newCode == null)
            {
                newCode = "0";
            }

            newCode = (int.Parse(newCode) + 1).ToString();
            newCode = prefix + newCode.PadLeft(codeLength - prefix.Length, '0');
            return newCode;
        }

        public SupplierGroup GetSupplierGroupByID(long supplierGroupID)
        {
            return context.SupplierGroup.Where(d => d.SupplierGroupID == supplierGroupID && d.IsDelete == false).FirstOrDefault();
        }
        public SupplierGroup GetActiveSupplierGroupByID(long supplierGroupID)
        {
            return context.SupplierGroup.Where(d => d.SupplierGroupID == supplierGroupID && d.IsDelete == false && d.IsActive == true).FirstOrDefault();
        }
        public SupplierGroup GetSupplierGroupByCode(string supplierGroupCode)
        {
            return context.SupplierGroup.Where(d => d.SupplierGroupCode == supplierGroupCode && d.IsDelete == false).FirstOrDefault();
        }

        public SupplierGroup GetActiveSupplierGroupByCode(string supplierGroupCode)
        {
            return context.SupplierGroup.Where(d => d.SupplierGroupCode == supplierGroupCode && d.IsActive == true && d.IsDelete == false).FirstOrDefault();
        }

        public SupplierGroup GetSupplierGroupByName(string supplierGroupName)
        {
            return context.SupplierGroup.Where(d => d.SupplierGroupName == supplierGroupName && d.IsDelete == false).FirstOrDefault();
        }
        public SupplierGroup GetActiveSupplierGroupByName(string supplierGroupName)
        {
            return context.SupplierGroup.Where(d => d.SupplierGroupName == supplierGroupName && d.IsActive == true && d.IsDelete == false).FirstOrDefault();
        }

        public void AddSupplierGroup(SupplierGroup supplierGroup)
        {
            context.SupplierGroup.Add(supplierGroup);
            context.SaveChanges();
        }

        public void UpdateSupplierGroup(SupplierGroup supplierGroup)
        {
            supplierGroup.ModifiedUser = Common.LoggedUserName;
            supplierGroup.ModifiedDate = DateTime.Now;
            this.context.Entry(supplierGroup).State = EntityState.Modified;
            this.context.SaveChanges();
        }
        public void DeleteSupplierGroup(SupplierGroup SupplierGroup)
        {
            SupplierGroup.ModifiedUser = Common.LoggedUserName;
            SupplierGroup.ModifiedDate = DateTime.Now;
            SupplierGroup.IsDelete = true;
            this.context.Entry(SupplierGroup).State = EntityState.Modified;
            this.context.SaveChanges();
        }
    }
}
