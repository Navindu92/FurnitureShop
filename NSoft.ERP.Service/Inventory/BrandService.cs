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
    public class BrandService
    {
        ERPDBContext context = new ERPDBContext();

        public string[] GetAllBrandCodes()
        {
            return context.Brand.Where(d => d.IsDelete == false).Select(u => u.BrandCode).ToArray();
        }
        public string[] GetAllActiveBrandCodes()
        {
            return context.Brand.Where(d => d.IsDelete == false && d.IsActive == true).Select(u => u.BrandCode).ToArray();
        }

        public string[] GetAllBrandNames()
        {
            return context.Brand.Where(d => d.IsDelete == false).Select(u => u.BrandName).ToArray();
        }
        public string[] GetAllActiveBrandNames()
        {
            return context.Brand.Where(d => d.IsDelete == false && d.IsActive == true).Select(u => u.BrandName).ToArray();
        }

        public List<Brand> GetAllActiveBrand()
        {
            return context.Brand.Where(d => d.IsDelete == false && d.IsActive == true).ToList();
        }
        public string GetNewCode(FormInfo formInfo)
        {
            string prefix;
            int codeLength;
            string newCode;
            prefix = formInfo.Prefix;
            if (prefix == string.Empty) { prefix = ""; }
            codeLength = formInfo.CodeLength;
            newCode = context.Brand.Where(d => d.IsDelete == false).Max(d => d.BrandCode.Substring(prefix.Length, codeLength));
            if (newCode == null)
            {
                newCode = "0";
            }

            newCode = (int.Parse(newCode) + 1).ToString();
            newCode = prefix + newCode.PadLeft(codeLength - prefix.Length, '0');
            return newCode;
        }

        public Brand GetBrandByID(long brandID)
        {
            return context.Brand.Where(d => d.BrandID == brandID && d.IsDelete == false).FirstOrDefault();
        }
        public Brand GetActiveBrandByID(long brandID)
        {
            return context.Brand.Where(d => d.BrandID == brandID && d.IsDelete == false && d.IsActive == true).FirstOrDefault();
        }
        public Brand GetBrandByCode(string brandCode)
        {
            return context.Brand.Where(d => d.BrandCode == brandCode && d.IsDelete == false).FirstOrDefault();
        }

        public Brand GetActiveBrandByCode(string brandCode)
        {
            return context.Brand.Where(d => d.BrandCode == brandCode && d.IsActive == true && d.IsDelete == false).FirstOrDefault();
        }

        public Brand GetBrandByName(string brandName)
        {
            return context.Brand.Where(d => d.BrandName == brandName && d.IsDelete == false).FirstOrDefault();
        }
        public Brand GetActiveBrandByName(string brandName)
        {
            return context.Brand.Where(d => d.BrandName == brandName && d.IsActive == true && d.IsDelete == false).FirstOrDefault();
        }

        public void AddBrand(Brand brand)
        {
            context.Brand.Add(brand);
            context.SaveChanges();
        }

        public void UpdateBrand(Brand brand)
        {
            brand.ModifiedUser = Common.LoggedUserName;
            brand.ModifiedDate = DateTime.Now;
            this.context.Entry(brand).State = EntityState.Modified;
            this.context.SaveChanges();
        }
        public void DeleteBrand(Brand Brand)
        {
            Brand.ModifiedUser = Common.LoggedUserName;
            Brand.ModifiedDate = DateTime.Now;
            Brand.IsDelete = true;
            this.context.Entry(Brand).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        public DataTable GetBrandDataTableForSearch()
        {
            var query = (from c in context.Brand
                         where c.IsDelete == false
                         select new
                         {
                             c.BrandCode,
                             c.BrandName,
                             c.Remark
                         });

            return query.ToDataTable();
        }
        public DataTable GetActiveBrandDataTableForSearch()
        {
            var query = (from c in context.Brand
                         where c.IsDelete == false && c.IsActive==true
                         select new
                         {
                             c.BrandCode,
                             c.BrandName,
                             c.Remark
                         });

            return query.ToDataTable();
        }
    }
}
