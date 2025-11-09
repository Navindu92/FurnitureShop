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
    public class SubCategory2Service
    {
        ERPDBContext context = new ERPDBContext();

        public string[] GetAllSubCategory2Codes()
        {
            return context.SubCategory2.Where(d => d.IsDelete == false).Select(u => u.SubCategory2Code).ToArray();
        }
        public string[] GetAllActiveSubCategory2Codes()
        {
            return context.SubCategory2.Where(d => d.IsDelete == false && d.IsActive == true).Select(u => u.SubCategory2Code).ToArray();
        }

        public string[] GetAllSubCategory2Names()
        {
            return context.SubCategory2.Where(d => d.IsDelete == false).Select(u => u.SubCategory2Name).ToArray();
        }
        public string[] GetAllActiveSubCategory2Names()
        {
            return context.SubCategory2.Where(d => d.IsDelete == false && d.IsActive == true).Select(u => u.SubCategory2Name).ToArray();
        }

        public List<SubCategory2> GetAllActiveSubCategory2()
        {
            return context.SubCategory2.Where(d => d.IsDelete == false && d.IsActive == true).ToList();
        }
        public string GetNewCode(FormInfo formInfo)
        {
            string prefix;
            int codeLength;
            string newCode;
            prefix = formInfo.Prefix;
            if (prefix == string.Empty) { prefix = ""; }
            codeLength = formInfo.CodeLength;
            newCode = context.SubCategory2.Where(d => d.IsDelete == false).Max(d => d.SubCategory2Code.Substring(prefix.Length, codeLength));
            if (newCode == null)
            {
                newCode = "0";
            }

            newCode = (int.Parse(newCode) + 1).ToString();
            newCode = prefix + newCode.PadLeft(codeLength - prefix.Length, '0');
            return newCode;
        }

        public SubCategory2 GetSubCategory2ByID(long subCategory1ID)
        {
            return context.SubCategory2.Where(d => d.SubCategory2ID == subCategory1ID && d.IsDelete == false).FirstOrDefault();
        }
        public SubCategory2 GetActiveSubCategory2ByID(long subCategory1ID)
        {
            return context.SubCategory2.Where(d => d.SubCategory2ID == subCategory1ID && d.IsDelete == false && d.IsActive == true).FirstOrDefault();
        }
        public SubCategory2 GetSubCategory2ByCode(string subCategory1Code)
        {
            return context.SubCategory2.Where(d => d.SubCategory2Code == subCategory1Code && d.IsDelete == false).FirstOrDefault();
        }

        public SubCategory2 GetActiveSubCategory2ByCode(string subCategory1Code)
        {
            return context.SubCategory2.Where(d => d.SubCategory2Code == subCategory1Code && d.IsActive == true && d.IsDelete == false).FirstOrDefault();
        }

        public SubCategory2 GetSubCategory2ByName(string subCategory1Name)
        {
            return context.SubCategory2.Where(d => d.SubCategory2Name == subCategory1Name && d.IsDelete == false).FirstOrDefault();
        }
        public SubCategory2 GetActiveSubCategory2ByName(string subCategory1Name)
        {
            return context.SubCategory2.Where(d => d.SubCategory2Name == subCategory1Name && d.IsActive == true && d.IsDelete == false).FirstOrDefault();
        }

        public void AddSubCategory2(SubCategory2 subCategory1)
        {
            context.SubCategory2.Add(subCategory1);
            context.SaveChanges();
        }

        public void UpdateSubCategory2(SubCategory2 subCategory1)
        {
            subCategory1.ModifiedUser = Common.LoggedUserName;
            subCategory1.ModifiedDate = DateTime.Now;
            this.context.Entry(subCategory1).State = EntityState.Modified;
            this.context.SaveChanges();
        }
        public void DeleteSubCategory2(SubCategory2 SubCategory2)
        {
            SubCategory2.ModifiedUser = Common.LoggedUserName;
            SubCategory2.ModifiedDate = DateTime.Now;
            SubCategory2.IsDelete = true;
            this.context.Entry(SubCategory2).State = EntityState.Modified;
            this.context.SaveChanges();
        }
    }
}
