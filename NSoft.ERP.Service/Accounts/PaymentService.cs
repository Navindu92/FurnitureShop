using NSoft.ERP.Data;
using NSoft.ERP.Domain.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Service.Accounts
{
    public class PaymentService
    {
        ERPDBContext context = new ERPDBContext();

        public List<PaymentMain> GetAllPendingGRNForPayment(long supplierId, long locationId, long documentId)
        {
            var query = (from pm in context.PaymentMain
                         join ph in context.PurchaseMain on pm.ReferenceDocumentID equals ph.PurchaseMainID
                         where pm.ReferenceTypeID == 1 && pm.ReferenceTypeID == supplierId && pm.BalanceAmount > 0
                         && pm.DocumentID == documentId
                         select new
                         {
                             pm.DocumentNo,
                             pm.BalanceAmount,
                             ph.ReferenceNo,
                             pm.Amount,
                             pm.DocumentDate
                         });

            List<PaymentMain> rtnList = new List<PaymentMain>();

            long lineNo = 0;

            foreach (var item in query)
            {
                PaymentMain paymentMain = new PaymentMain();
                paymentMain.DocumentNo = item.DocumentNo.Trim();
                paymentMain.BalanceAmount = item.BalanceAmount;
                paymentMain.ReferenceNo = item.ReferenceNo;
                paymentMain.Amount = item.Amount;
                paymentMain.DocumentDate = item.DocumentDate;
                paymentMain.LineNo = lineNo + 1;
                rtnList.Add(paymentMain);
                lineNo++;
            }

            return rtnList.ToList();
        }

        public List<PaymentMain> GetUpdatedPaymentTempList(List<PaymentMain> existingList, PaymentMain paymentMain)
        {
            List<PaymentMain> rtnList = new List<PaymentMain>();
            PaymentMain existingPaymentMain;
            rtnList = existingList;
            long lineNo = 0;
            existingPaymentMain = rtnList.Where(i => i.DocumentNo == paymentMain.DocumentNo).FirstOrDefault();
            if (rtnList.ToList().Count == 0)
            { lineNo = 1; }
            else
            { lineNo = rtnList.Max(m => m.LineNo) + 1; }

            if (existingPaymentMain != null)
            {
                rtnList.Remove(existingPaymentMain);
                existingPaymentMain.LineNo = existingPaymentMain.LineNo;
                existingPaymentMain.DocumentNo = existingPaymentMain.DocumentNo;
                existingPaymentMain.DocumentDate = existingPaymentMain.DocumentDate;
                existingPaymentMain.ReferenceNo = existingPaymentMain.ReferenceNo;
                existingPaymentMain.Amount = existingPaymentMain.Amount;
                existingPaymentMain.PayAmount = existingPaymentMain.PayAmount + paymentMain.PayAmount;
                existingPaymentMain.BalanceAmount = (existingPaymentMain.BalanceAmount - paymentMain.PayAmount);

            }
            rtnList.Add(existingPaymentMain);
            return rtnList.OrderBy(o => o.LineNo).ToList();
        }

        public List<PaymentSub> GetUpdatedPaymentSubTempList(List<PaymentSub> existingList, PaymentSub paymentSub)
        {
            List<PaymentSub> rtnList = new List<PaymentSub>();
            PaymentSub existingPaymentSub;
            rtnList = existingList;
            long lineNo = 0;
            existingPaymentSub = rtnList.Where(i => i.PayTypeName == paymentSub.PayTypeName).FirstOrDefault();
            if (rtnList.ToList().Count == 0)
            { lineNo = 1; }
            else
            { lineNo = rtnList.Max(m => m.LineNo) + 1; }

            if (existingPaymentSub != null)
            {
                rtnList.Remove(existingPaymentSub);
                existingPaymentSub.LineNo = existingPaymentSub.LineNo;
                existingPaymentSub.PayTypeName = existingPaymentSub.PayTypeName;
                existingPaymentSub.ReferenceNo = existingPaymentSub.ReferenceNo;
                existingPaymentSub.Amount = existingPaymentSub.Amount;
            }
            rtnList.Add(existingPaymentSub);
            return rtnList.OrderBy(o => o.LineNo).ToList();
        }
    }
}
