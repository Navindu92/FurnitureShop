using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSoft.ERP.Domain.Accounts;
using NSoft.ERP.Domain.General;
using System.Transactions;
using NSoft.ERP.Data;
using EntityFramework.Extensions;
using NSoft.ERP.Utility;
using System.Data.Entity;

namespace NSoft.ERP.Service.Accounts
{
    public class ChequeBookEntryService
    {
        ERPDBContext context = new ERPDBContext();

        public bool CheckExistChequeNumbers(string startingNo, int noOfPages)
        {
            string chequeNo;
            bool isValidate = true;

            for (int i = 0; i < noOfPages; i++)
            {
                chequeNo = (int.Parse(startingNo) + i).ToString();

                if (context.ChequeBookEntry.Where(ch => ch.ChequeNo == chequeNo).Any() == true)
                {
                    isValidate = false;
                }

            }

            return isValidate;
        }
        public List<ChequeBookEntry> GenerateChequeNumbers(string startingNo, int noOfPages)
        {
            string chequeNo;

            List<ChequeBookEntry> chequeNumbers = new List<ChequeBookEntry>();

            for (int i = 0; i < noOfPages; i++)
            {
                chequeNo = (int.Parse(startingNo) + i).ToString();
                ChequeBookEntry chequeBookEntry = new ChequeBookEntry();
                chequeBookEntry.ChequeNo = chequeNo;
                chequeNumbers.Add(chequeBookEntry);
            }

            return chequeNumbers;
        }
        public bool Save(List<ChequeBookEntry> chequeBookEntryList)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                chequeBookEntryList.ToList().ForEach(x =>
                {
                    ChequeBookEntry chequeBookEntry = new ChequeBookEntry();
                    chequeBookEntry.ChequeDate = DateTime.Now;
                    chequeBookEntry.ChequeNo = x.ChequeNo;
                    chequeBookEntry.PayeeName = string.Empty;
                    chequeBookEntry.IsCrossed = false;
                    chequeBookEntry.Amount = 0;
                    chequeBookEntry.PrintDate = DateTime.Now;
                    chequeBookEntry.IsPrint = false;
                    context.ChequeBookEntry.Add(chequeBookEntry);
                    this.context.SaveChanges();
                });

                transaction.Complete();
                return true;
            }
        }

        public ChequeBookEntry GetNonPrintChequeByChequeNo(string chequeNo)
        {
            return context.ChequeBookEntry.Where(ch => ch.ChequeNo == chequeNo && ch.IsPrint == false).FirstOrDefault();
        }
        public void UpdateCheque(ChequeBookEntry chequeBookEntry)
        {
            chequeBookEntry.ModifiedUser = Common.LoggedUserName;
            chequeBookEntry.ModifiedDate = DateTime.Now;
            this.context.Entry(chequeBookEntry).State = EntityState.Modified;
            this.context.SaveChanges();
        }
    }
}
