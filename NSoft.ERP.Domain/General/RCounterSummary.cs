using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.General
{
    public class RCounterSummary : BaseEntity
    {
        public long RCounterSummaryID { get; set; }
        public long CounterID { get; set; }
        public long LocationID { get; set; }

        [DefaultValue(0)]
        public decimal CounterOpen { get; set; }

        [DefaultValue(0)]
        public decimal Channeling { get; set; }

        [DefaultValue(0)]
        public long NChanneling { get; set; }

        [DefaultValue(0)]
        public decimal Investigation { get; set; }

        [DefaultValue(0)]
        public long NInvestigation { get; set; }

        [DefaultValue(0)]
        public decimal PaidIn { get; set; }

        [DefaultValue(0)]
        public long NPaidIn { get; set; }

        [DefaultValue(0)]
        public decimal InvestigationDiscount { get; set; }

        [DefaultValue(0)]
        public long NInvestigationDiscount { get; set; }

        [DefaultValue(0)]
        public decimal ChannelingCancel { get; set; }

        [DefaultValue(0)]
        public long NChannelingCancel { get; set; }

        [DefaultValue(0)]
        public decimal ChannelingDoctorRefund { get; set; }

        [DefaultValue(0)]
        public long NChannelingDoctorRefund { get; set; }

        [DefaultValue(0)]
        public decimal ChannelingHospitalRefund { get; set; }

        [DefaultValue(0)]
        public long NChannelingHospitalRefund { get; set; }

        [DefaultValue(0)]
        public decimal PaidOut { get; set; }

        [DefaultValue(0)]
        public long NPaidOut { get; set; }

        [DefaultValue(0)]
        public decimal DoctorPayment { get; set; }

        [DefaultValue(0)]
        public long NDoctorPayment { get; set; }

        [DefaultValue(0)]
        public decimal ChannelingAdvance { get; set; }

        [DefaultValue(0)]
        public long NChannelingAdvance { get; set; }

        [DefaultValue(0)]
        public decimal ChannelingAdvanceSettle { get; set; }

        [DefaultValue(0)]
        public long NChannelingAdvanceSettle { get; set; }

        [DefaultValue(0)]
        public decimal InvestigationAdvance { get; set; }

        [DefaultValue(0)]
        public long NInvestigationAdvance { get; set; }

        [DefaultValue(0)]
        public decimal InvestigationAdvanceSettle { get; set; }

        [DefaultValue(0)]
        public long NInvestigationAdvanceSettle { get; set; }

        [DefaultValue(0)]
        public decimal CounterClose { get; set; }

        [DefaultValue(0)]
        public decimal GrossSale { get; set; }

        [DefaultValue(0)]
        public decimal NetSale { get; set; }

        [DefaultValue(0)]
        public decimal BalanceAmount { get; set; }

        [DefaultValue(0)]
        public decimal InvestigationCashSale { get; set; }

        [DefaultValue(0)]
        public long NInvestigationCashSale { get; set; }

        [DefaultValue(0)]
        public decimal ChannelingCashSale { get; set; }

        [DefaultValue(0)]
        public long NChannelingCashSale { get; set; }

        [DefaultValue(0)]
        public decimal CashSale { get; set; }

        [DefaultValue(0)]
        public long NCashSale { get; set; }

        [DefaultValue(0)]
        public decimal CashDiscount { get; set; }

        [DefaultValue(0)]
        public long NCashDiscount { get; set; }

        [DefaultValue(0)]
        public decimal CashCancel { get; set; }

        [DefaultValue(0)]
        public long NCashCancel { get; set; }

        [DefaultValue(0)]
        public decimal CashRefund { get; set; }

        [DefaultValue(0)]
        public long NCashRefund { get; set; }

        [DefaultValue(0)]
        public decimal CashPayment { get; set; }

        [DefaultValue(0)]
        public decimal NCashPayment { get; set; }

        [DefaultValue(0)]
        public decimal CashAdvance { get; set; }

        [DefaultValue(0)]
        public long NCashAdvance { get; set; }

        [DefaultValue(0)]
        public decimal CashAdvanceSettle { get; set; }

        [DefaultValue(0)]
        public long NCashAdvanceSettle { get; set; }

        [DefaultValue(0)]
        public decimal ChannellingCreditCard { get; set; }

        [DefaultValue(0)]
        public long NChannellingCreditCard { get; set; }

        [DefaultValue(0)]
        public decimal Invoice { get; set; }
        [DefaultValue(0)]
        public decimal NInvoice { get; set; }

        [DefaultValue(0)]
        public decimal InvoiceItemDiscount { get; set; }
        [DefaultValue(0)]
        public decimal NInvoiceItemDiscount { get; set; }

        [DefaultValue(0)]
        public decimal InvoiceSubTotalDiscount { get; set; }
        [DefaultValue(0)]
        public decimal NInvoiceSubTotalDiscount { get; set; }

        [DefaultValue(0)]
        public decimal InvoiceReturn { get; set; }
        [DefaultValue(0)]
        public decimal NInvoiceReturn { get; set; }

        public decimal InvoiceCash { get; set; }
        [DefaultValue(0)]
        public decimal NInvoiceCash { get; set; }

        [DefaultValue(0)]
        public decimal InvoiceCashDiscount { get; set; }
        [DefaultValue(0)]
        public decimal NInvoiceCashDiscount { get; set; }

        [DefaultValue(0)]
        public decimal InvoiceCashRefund { get; set; }
        [DefaultValue(0)]
        public decimal NInvoiceCashRefund { get; set; }

        [DefaultValue(0)]
        public decimal InvoiceCreditCard { get; set; }

        [DefaultValue(0)]
        public long NInvoiceCreditCard { get; set; }

        [DefaultValue(0)]
        public decimal InvestigationCreditCard { get; set; }

        [DefaultValue(0)]
        public long NInvestigationCreditCard { get; set; }

        [DefaultValue(0)]
        public long UserID { get; set; }

        [DefaultValue(0)]
        public int ReportType { get; set; }  //1-Z  2-Sales Summary 3 Current Sales

    }
}
