using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.Inventory
{
    public class OpeningStockMain : BaseEntity
    {
        public long OpeningStockMainID { get; set; }
        public string DocumentNo { get; set; }
        public long DocumentID { get; set; }
        public int DocumentStaus { get; set; } // 0-Last Opening Stock 1-Old OpeningStock
        public DateTime DocumentDate { get; set; }
        public long LocationID { get; set; }
        [MaxLength(20)]
        public string ReferenceNo { get; set; }
        public string Remarks { get; set; }
        public decimal TotalQty { get; set; }
        public decimal TotalCostValue { get; set; }
        public decimal TotalSellingValue { get; set; }

    }
}
