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
    public class CustomerGroupService
    {
        ERPDBContext context = new ERPDBContext();

        public string[] GetAllCustomerGroupCodes()
        {
            return context.CustomerGroup.Where(d => d.IsDelete == false).Select(u => u.CustomerGroupCode).ToArray();
        }
        public string[] GetAllActiveCustomerGroupCodes()
        {
            return context.CustomerGroup.Where(d => d.IsDelete == false && d.IsActive == true).Select(u => u.CustomerGroupCode).ToArray();
        }

        public string[] GetAllCustomerGroupNames()
        {
            return context.CustomerGroup.Where(d => d.IsDelete == false).Select(u => u.CustomerGroupName).ToArray();
        }
        public string[] GetAllActiveCustomerGroupNames()
        {
            return context.CustomerGroup.Where(d => d.IsDelete == false && d.IsActive == true).Select(u => u.CustomerGroupName).ToArray();
        }

        public List<CustomerGroup> GetAllActiveCustomerGroup()
        {
            return context.CustomerGroup.Where(d => d.IsDelete == false && d.IsActive == true).ToList();
        }
        public string GetNewCode(FormInfo formInfo)
        {
            string prefix;
            int codeLength;
            string newCode;
            prefix = formInfo.Prefix;
            if (prefix == string.Empty) { prefix = ""; }
            codeLength = formInfo.CodeLength;
            newCode = context.CustomerGroup.Where(d => d.IsDelete == false).Max(d => d.CustomerGroupCode.Substring(prefix.Length, codeLength));
            if (newCode == null)
            {
                newCode = "0";
            }

            newCode = (int.Parse(newCode) + 1).ToString();
            newCode = prefix + newCode.PadLeft(codeLength - prefix.Length, '0');
            return newCode;
        }

        public CustomerGroup GetCustomerGroupByID(long customerGroupID)
        {
            return context.CustomerGroup.Where(d => d.CustomerGroupID == customerGroupID && d.IsDelete == false).FirstOrDefault();
        }
        public CustomerGroup GetActiveCustomerGroupByID(long customerGroupID)
        {
            return context.CustomerGroup.Where(d => d.CustomerGroupID == customerGroupID && d.IsDelete == false && d.IsActive == true).FirstOrDefault();
        }
        public CustomerGroup GetCustomerGroupByCode(string customerGroupCode)
        {
            return context.CustomerGroup.Where(d => d.CustomerGroupCode == customerGroupCode && d.IsDelete == false).FirstOrDefault();
        }

        public CustomerGroup GetActiveCustomerGroupByCode(string customerGroupCode)
        {
            return context.CustomerGroup.Where(d => d.CustomerGroupCode == customerGroupCode && d.IsActive == true && d.IsDelete == false).FirstOrDefault();
        }

        public CustomerGroup GetCustomerGroupByName(string customerGroupName)
        {
            return context.CustomerGroup.Where(d => d.CustomerGroupName == customerGroupName && d.IsDelete == false).FirstOrDefault();
        }
        public CustomerGroup GetActiveCustomerGroupByName(string customerGroupName)
        {
            return context.CustomerGroup.Where(d => d.CustomerGroupName == customerGroupName && d.IsActive == true && d.IsDelete == false).FirstOrDefault();
        }

        public void AddCustomerGroup(CustomerGroup customerGroup)
        {
            context.CustomerGroup.Add(customerGroup);
            context.SaveChanges();
        }

        public void UpdateCustomerGroup(CustomerGroup customerGroup)
        {
            customerGroup.ModifiedUser = Common.LoggedUserName;
            customerGroup.ModifiedDate = DateTime.Now;
            this.context.Entry(customerGroup).State = EntityState.Modified;
            this.context.SaveChanges();
        }
        public void DeleteCustomerGroup(CustomerGroup CustomerGroup)
        {
            CustomerGroup.ModifiedUser = Common.LoggedUserName;
            CustomerGroup.ModifiedDate = DateTime.Now;
            CustomerGroup.IsDelete = true;
            this.context.Entry(CustomerGroup).State = EntityState.Modified;
            this.context.SaveChanges();
        }
    }
}
