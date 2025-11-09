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
    public class CustomerService
    {
        ERPDBContext context = new ERPDBContext();

        public string[] GetAllCustomerCodes()
        {
            return context.Customer.Where(d => d.IsDelete == false).Select(u => u.CustomerCode).ToArray();
        }
        public string[] GetAllActiveCustomerCodes()
        {
            return context.Customer.Where(d => d.IsDelete == false && d.IsActive == true).Select(u => u.CustomerCode).ToArray();
        }

        public string[] GetAllCustomerNames()
        {
            return context.Customer.Where(d => d.IsDelete == false).Select(u => u.CustomerName).ToArray();
        }
        public string[] GetAllActiveCustomerNames()
        {
            return context.Customer.Where(d => d.IsDelete == false && d.IsActive == true).Select(u => u.CustomerName).ToArray();
        }

        public List<Customer> GetAllActiveCustomer()
        {
            return context.Customer.Where(d => d.IsDelete == false && d.IsActive == true).ToList();
        }
        public string GetNewCode(FormInfo formInfo)
        {
            string prefix;
            int codeLength;
            string newCode;
            prefix = formInfo.Prefix;
            if (prefix == string.Empty) { prefix = ""; }
            codeLength = formInfo.CodeLength;
            newCode = context.Customer.Where(d => d.IsDelete == false).Max(d => d.CustomerCode.Substring(prefix.Length, codeLength));
            if (newCode == null)
            {
                newCode = "0";
            }

            newCode = (int.Parse(newCode) + 1).ToString();
            newCode = prefix + newCode.PadLeft(codeLength - prefix.Length, '0');
            return newCode;
        }

        public Customer GetCustomerByID(long customerID)
        {
            return context.Customer.Where(d => d.CustomerID == customerID && d.IsDelete == false).FirstOrDefault();
        }
        public Customer GetActiveCustomerByID(long customerID)
        {
            return context.Customer.Where(d => d.CustomerID == customerID && d.IsDelete == false && d.IsActive == true).FirstOrDefault();
        }
        public Customer GetCustomerByCode(string customerCode)
        {
            return context.Customer.Where(d => d.CustomerCode == customerCode && d.IsDelete == false).FirstOrDefault();
        }

        public Customer GetActiveCustomerByCode(string customerCode)
        {
            return context.Customer.Where(d => d.CustomerCode == customerCode && d.IsActive == true && d.IsDelete == false).FirstOrDefault();
        }

        public Customer GetCustomerByName(string customerName)
        {
            return context.Customer.Where(d => d.CustomerName == customerName && d.IsDelete == false).FirstOrDefault();
        }
        public Customer GetActiveCustomerByName(string customerName)
        {
            return context.Customer.Where(d => d.CustomerName == customerName && d.IsActive == true && d.IsDelete == false).FirstOrDefault();
        }

        public void AddCustomer(Customer customer)
        {
            context.Customer.Add(customer);
            context.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            customer.ModifiedUser = Common.LoggedUserName;
            customer.ModifiedDate = DateTime.Now;
            this.context.Entry(customer).State = EntityState.Modified;
            this.context.SaveChanges();
        }
        public void DeleteCustomer(Customer Customer)
        {
            Customer.ModifiedUser = Common.LoggedUserName;
            Customer.ModifiedDate = DateTime.Now;
            Customer.IsDelete = true;
            this.context.Entry(Customer).State = EntityState.Modified;
            this.context.SaveChanges();
        }
    }
}
