using NSoft.ERP.Data;
using NSoft.ERP.Domain.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Service.CRM
{
    public class LoyaltyCustomerService
    {
        ERPDBContext context = new ERPDBContext();

        public LoyaltyCustomer GetLoyaltyCustomerByID(long customerId)
        {
            return context.LoyaltyCustomer.Where(lc => lc.IsActive == true && lc.IsBlackList == false && lc.IsDelete == false && lc.LoyaltyCustomerID == customerId).FirstOrDefault();
        }
        public LoyaltyCustomer GetLoyaltyCustomerByReference(string strSearch)
        {
            return context.LoyaltyCustomer.Where(lc => lc.IsActive == true && lc.IsBlackList == false && lc.IsDelete == false && (lc.CardNo == strSearch || lc.MobileNo == strSearch || lc.NICNo == strSearch)).FirstOrDefault();
        }

        public bool CheckLoyaltyCardNo(string cardNo)
        {
            if (context.LoyaltyCustomer.Where(lc => lc.IsActive == true && lc.IsBlackList == false && lc.IsDelete == false && lc.CardNo == cardNo).FirstOrDefault() != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckLoyaltyPhoneNo(string phoneNo)
        {
            if (context.LoyaltyCustomer.Where(lc => lc.IsActive == true && lc.IsBlackList == false && lc.IsDelete == false && lc.MobileNo == phoneNo).FirstOrDefault() != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckLoyaltyNicNo(string nicNo)
        {
            if (context.LoyaltyCustomer.Where(lc => lc.IsActive == true && lc.IsBlackList == false && lc.IsDelete == false && lc.NICNo == nicNo).FirstOrDefault() != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AddLoyaltyCustomer(LoyaltyCustomer loyaltyCustomer)
        {
            context.LoyaltyCustomer.Add(loyaltyCustomer);
            context.SaveChanges();
        }
    }
}
