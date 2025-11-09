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
using EntityFramework.Extensions;

namespace NSoft.ERP.Service.Inventory
{
    public class CategoryService
    {
        ERPDBContext context = new ERPDBContext();

        public string[] GetAllCategoryCodes()
        {
            return context.Category.Where(d => d.IsDelete == false).Select(u => u.CategoryCode).ToArray();
        }
        public string[] GetAllActiveCategoryCodes()
        {
            return context.Category.Where(d => d.IsDelete == false && d.IsActive == true).Select(u => u.CategoryCode).ToArray();
        }

        public string[] GetAllCategoryNames()
        {
            return context.Category.Where(d => d.IsDelete == false).Select(u => u.CategoryName).ToArray();
        }
        public string[] GetAllActiveCategoryNames()
        {
            return context.Category.Where(d => d.IsDelete == false && d.IsActive == true).Select(u => u.CategoryName).ToArray();
        }

        public List<Category> GetAllActiveCategory()
        {
            return context.Category.Where(d => d.IsDelete == false && d.IsActive == true).ToList();
        }
        public string GetNewCode(FormInfo formInfo)
        {
            string prefix;
            int codeLength;
            string newCode;
            prefix = formInfo.Prefix;
            if (prefix == string.Empty) { prefix = ""; }
            codeLength = formInfo.CodeLength;
            newCode = context.Category.Where(d => d.IsDelete == false).Max(d => d.CategoryCode.Substring(prefix.Length, codeLength));
            if (newCode == null)
            {
                newCode = "0";
            }

            newCode = (int.Parse(newCode) + 1).ToString();
            newCode = prefix + newCode.PadLeft(codeLength - prefix.Length, '0');
            return newCode;
        }

        public Category GetCategoryByID(long categoryID)
        {
            return context.Category.Where(d => d.CategoryID == categoryID && d.IsDelete == false).FirstOrDefault();
        }
        public Category GetActiveCategoryByID(long categoryID)
        {
            return context.Category.Where(d => d.CategoryID == categoryID && d.IsDelete == false && d.IsActive == true).FirstOrDefault();
        }
        public Category GetCategoryByCode(string categoryCode)
        {
            return context.Category.Where(d => d.CategoryCode == categoryCode && d.IsDelete == false).FirstOrDefault();
        }

        public Category GetActiveCategoryByCode(string categoryCode)
        {
            return context.Category.Where(d => d.CategoryCode == categoryCode && d.IsActive == true && d.IsDelete == false).FirstOrDefault();
        }

        public Category GetCategoryByName(string categoryName)
        {
            return context.Category.Where(d => d.CategoryName == categoryName && d.IsDelete == false).FirstOrDefault();
        }
        public Category GetActiveCategoryByName(string categoryName)
        {
            return context.Category.Where(d => d.CategoryName == categoryName && d.IsActive == true && d.IsDelete == false).FirstOrDefault();
        }

        public void AddCategory(Category category)
        {
            context.Category.Add(category);
            context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            category.ModifiedUser = Common.LoggedUserName;
            category.ModifiedDate = DateTime.Now;
            this.context.Entry(category).State = EntityState.Modified;
            this.context.SaveChanges();
        }
        public void DeleteCategory(Category Category)
        {
            Category.ModifiedUser = Common.LoggedUserName;
            Category.ModifiedDate = DateTime.Now;
            Category.IsDelete = true;
            this.context.Entry(Category).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        public DataTable GetCategoryDataTableForSearch()
        {
            var query = (from c in context.Category
                         where c.IsDelete == false
                         select new
                         {
                             c.CategoryCode,
                             c.CategoryName,
                             c.Remark
                         });

            return query.ToDataTable();
        }
        public DataTable GetActiveCategoryDataTableForSearch()
        {
            var query = (from c in context.Category
                         where c.IsDelete == false && c.IsActive==true
                         select new
                         {
                             c.CategoryCode,
                             c.CategoryName,
                             c.Remark
                         });

            return query.ToDataTable();
        }
    }
}
