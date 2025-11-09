using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.Inventory
{
    public class SalesMain : BaseEntity
    {
        public long SalesMainID { get; set; }
        [MaxLength(20)]
        public string DocumentNo { get; set; }
        public long DocumentID { get; set; }
        public DateTime DocumentDate { get; set; }
        public long CounterNo { get; set; }
        public long LocationID { get; set; }
        public long CustomerID { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public decimal NoOfPieces { get; set; }
        public decimal NoOfQty { get; set; }
        public long Zno { get; set; }
        public DateTime ZDate { get; set; }
        [NotMapped]
        public bool IsRecallSalesHold { get; set; }
        [NotMapped]
        public string SalesHoldNo { get; set; }
        public long LoyaltyCustomerID { get; set; }
        public decimal CPoints { get; set; }
        public decimal EPoints { get; set; }
        public decimal RPoints { get; set; }
        public long SalesmanID { get; set; }
        public decimal CommissionRate { get; set; }
        public decimal CommissionAmount { get; set; }
    }
}
