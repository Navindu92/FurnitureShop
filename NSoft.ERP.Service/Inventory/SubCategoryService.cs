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
    public class SubCategory1Service
    {
        ERPDBContext context = new ERPDBContext();

        public string[] GetAllSubCategory1Codes()
        {
            return context.SubCategory1.Where(d => d.IsDelete == false).Select(u => u.SubCategory1Code).ToArray();
        }
        public string[] GetAllActiveSubCategory1Codes()
        {
            return context.SubCategory1.Where(d => d.IsDelete == false && d.IsActive == true).Select(u => u.SubCategory1Code).ToArray();
        }

        public string[] GetAllSubCategory1Names()
        {
            return context.SubCategory1.Where(d => d.IsDelete == false).Select(u => u.SubCategory1Name).ToArray();
        }
        public string[] GetAllActiveSubCategory1Names()
        {
            return context.SubCategory1.Where(d => d.IsDelete == false && d.IsActive == true).Select(u => u.SubCategory1Name).ToArray();
        }

        public List<SubCategory1> GetAllActiveSubCategory1()
        {
            return context.SubCategory1.Where(d => d.IsDelete == false && d.IsActive == true).ToList();
        }
        public string GetNewCode(FormInfo formInfo)
        {
            string prefix;
            int codeLength;
            string newCode;
            prefix = formInfo.Prefix;
            if (prefix == string.Empty) { prefix = ""; }
            codeLength = formInfo.CodeLength;
            newCode = context.SubCategory1.Where(d => d.IsDelete == false).Max(d => d.SubCategory1Code.Substring(prefix.Length, codeLength));
            if (newCode == null)
            {
                newCode = "0";
            }

            newCode = (int.Parse(newCode) + 1).ToString();
            newCode = prefix + newCode.PadLeft(codeLength - prefix.Length, '0');
            return newCode;
        }

        public SubCategory1 GetSubCategory1ByID(long subCategory1ID)
        {
            return context.SubCategory1.Where(d => d.SubCategory1ID == subCategory1ID && d.IsDelete == false).FirstOrDefault();
        }
        public SubCategory1 GetActiveSubCategory1ByID(long subCategory1ID)
        {
            return context.SubCategory1.Where(d => d.SubCategory1ID == subCategory1ID && d.IsDelete == false && d.IsActive == true).FirstOrDefault();
        }
        public SubCategory1 GetSubCategory1ByCode(string subCategory1Code)
        {
            return context.SubCategory1.Where(d => d.SubCategory1Code == subCategory1Code && d.IsDelete == false).FirstOrDefault();
        }

        public SubCategory1 GetActiveSubCategory1ByCode(string subCategory1Code)
        {
            return context.SubCategory1.Where(d => d.SubCategory1Code == subCategory1Code && d.IsActive == true && d.IsDelete == false).FirstOrDefault();
        }

        public SubCategory1 GetSubCategory1ByName(string subCategory1Name)
        {
            return context.SubCategory1.Where(d => d.SubCategory1Name == subCategory1Name && d.IsDelete == false).FirstOrDefault();
        }
        public SubCategory1 GetActiveSubCategory1ByName(string subCategory1Name)
        {
            return context.SubCategory1.Where(d => d.SubCategory1Name == subCategory1Name && d.IsActive == true && d.IsDelete == false).FirstOrDefault();
        }

        public void AddSubCategory1(SubCategory1 subCategory1)
        {
            context.SubCategory1.Add(subCategory1);
            context.SaveChanges();
        }

        public void UpdateSubCategory1(SubCategory1 subCategory1)
        {
            subCategory1.ModifiedUser = Common.LoggedUserName;
            subCategory1.ModifiedDate = DateTime.Now;
            this.context.Entry(subCategory1).State = EntityState.Modified;
            this.context.SaveChanges();
        }
        public void DeleteSubCategory1(SubCategory1 SubCategory1)
        {
            SubCategory1.ModifiedUser = Common.LoggedUserName;
            SubCategory1.ModifiedDate = DateTime.Now;
            SubCategory1.IsDelete = true;
            this.context.Entry(SubCategory1).State = EntityState.Modified;
            this.context.SaveChanges();
        }
    }
}
