using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.Inventory
{
    public class SalesOrderMain : BaseEntity
    {
        public long SalesOrderMainID { get; set; }
        [MaxLength(20)]
        public string DocumentNo { get; set; }
        public string OrderReferenceNo { get; set; }
        public long DocumentID { get; set; }
        public DateTime DocumentDate { get; set; }

        [MaxLength(20)]
        public string ReferenceNo { get; set; }
        public long CounterID { get; set; }
        public long LocationID { get; set; }
        public long CustomerID { get; set; }

        [NotMapped]
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal NetAmount { get; set; }

        public long Zno { get; set; }
        public DateTime ZDate { get; set; }
    }
}
