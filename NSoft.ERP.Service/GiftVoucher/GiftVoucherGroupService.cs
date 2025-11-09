using NSoft.ERP.Data;
using NSoft.ERP.Domain.General;
using NSoft.ERP.Domain.GiftVoucher;
using NSoft.ERP.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Service.GiftVoucher
{
    public class GiftVoucherGroupService
    {
        ERPDBContext context = new ERPDBContext();

        public string[] GetAllGiftVoucherGroupCodes()
        {
            return context.GiftVoucherGroup.Where(d => d.IsDelete == false).Select(u => u.GiftVoucherGroupCode).ToArray();
        }
        public string[] GetAllActiveGiftVoucherGroupCodes()
        {
            return context.GiftVoucherGroup.Where(d => d.IsDelete == false && d.IsActive == true).Select(u => u.GiftVoucherGroupCode).ToArray();
        }

        public string[] GetAllGiftVoucherGroupNames()
        {
            return context.GiftVoucherGroup.Where(d => d.IsDelete == false).Select(u => u.GiftVoucherGroupName).ToArray();
        }
        public string[] GetAllActiveGiftVoucherGroupNames()
        {
            return context.GiftVoucherGroup.Where(d => d.IsDelete == false && d.IsActive == true).Select(u => u.GiftVoucherGroupName).ToArray();
        }

        public List<GiftVoucherGroup> GetAllActiveGiftVoucherGroup()
        {
            return context.GiftVoucherGroup.Where(d => d.IsDelete == false && d.IsActive == true).ToList();
        }
        public string GetNewCode(FormInfo formInfo)
        {
            string prefix;
            int codeLength;
            string newCode;
            prefix = formInfo.Prefix;
            if (prefix == string.Empty) { prefix = ""; }
            codeLength = formInfo.CodeLength;
            newCode = context.GiftVoucherGroup.Where(d => d.IsDelete == false).Max(d => d.GiftVoucherGroupCode.Substring(prefix.Length, codeLength));
            if (newCode == null)
            {
                newCode = "0";
            }

            newCode = (int.Parse(newCode) + 1).ToString();
            newCode = prefix + newCode.PadLeft(codeLength - prefix.Length, '0');
            return newCode;
        }

        public GiftVoucherGroup GetGiftVoucherGroupByID(long customerGroupID)
        {
            return context.GiftVoucherGroup.Where(d => d.GiftVoucherGroupID == customerGroupID && d.IsDelete == false).FirstOrDefault();
        }
        public GiftVoucherGroup GetActiveGiftVoucherGroupByID(long customerGroupID)
        {
            return context.GiftVoucherGroup.Where(d => d.GiftVoucherGroupID == customerGroupID && d.IsDelete == false && d.IsActive == true).FirstOrDefault();
        }
        public GiftVoucherGroup GetGiftVoucherGroupByCode(string customerGroupCode)
        {
            return context.GiftVoucherGroup.Where(d => d.GiftVoucherGroupCode == customerGroupCode && d.IsDelete == false).FirstOrDefault();
        }

        public GiftVoucherGroup GetActiveGiftVoucherGroupByCode(string customerGroupCode)
        {
            return context.GiftVoucherGroup.Where(d => d.GiftVoucherGroupCode == customerGroupCode && d.IsActive == true && d.IsDelete == false).FirstOrDefault();
        }

        public GiftVoucherGroup GetGiftVoucherGroupByName(string customerGroupName)
        {
            return context.GiftVoucherGroup.Where(d => d.GiftVoucherGroupName == customerGroupName && d.IsDelete == false).FirstOrDefault();
        }
        public GiftVoucherGroup GetActiveGiftVoucherGroupByName(string customerGroupName)
        {
            return context.GiftVoucherGroup.Where(d => d.GiftVoucherGroupName == customerGroupName && d.IsActive == true && d.IsDelete == false).FirstOrDefault();
        }

        public void AddGiftVoucherGroup(GiftVoucherGroup customerGroup)
        {
            context.GiftVoucherGroup.Add(customerGroup);
            context.SaveChanges();
        }

        public void UpdateGiftVoucherGroup(GiftVoucherGroup customerGroup)
        {
            customerGroup.ModifiedUser = Common.LoggedUserName;
            customerGroup.ModifiedDate = DateTime.Now;
            this.context.Entry(customerGroup).State = EntityState.Modified;
            this.context.SaveChanges();
        }
        public void DeleteGiftVoucherGroup(GiftVoucherGroup GiftVoucherGroup)
        {
            GiftVoucherGroup.ModifiedUser = Common.LoggedUserName;
            GiftVoucherGroup.ModifiedDate = DateTime.Now;
            GiftVoucherGroup.IsDelete = true;
            this.context.Entry(GiftVoucherGroup).State = EntityState.Modified;
            this.context.SaveChanges();
        }
    }
}
