using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.Inventory
{
    public class Supplier : BaseEntity
    {
        public long SupplierID { get; set; }
        [MaxLength(10)]
        public string SupplierCode { get; set; }
        [MaxLength(60)]
        public string SupplierName { get; set; }

        public long SupplierGropID { get; set; }
        public long Title { get; set; }

        [MaxLength(300)]
        public string ContactPerson { get; set; }
        [MaxLength(20)]
        public string NICNo { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(10)]
        public string MobileNo { get; set; }
        [MaxLength(10)]
        public string FixedNo { get; set; }
        public decimal CreditLimit { get; set; }
        public decimal CreditPeriod { get; set; }
        public decimal ChequeLimit { get; set; }
        public decimal ChequePeriod { get; set; }
        public byte[] SupplierImage { get; set; }
        public string TaxNo1 { get; set; }
        public string TaxNo2 { get; set; }
        public string TaxNo3 { get; set; }
        public string TaxNo4 { get; set; }
        public string TaxNo5 { get; set; }
        public long LedgerID { get; set; }

        [MaxLength(100)]
        [DefaultValue("")]
        public string Remark { get; set; }
        [DefaultValue(0)]

        public bool IsActive { get; set; }

        [DefaultValue(0)]
        public bool IsDelete { get; set; }
    }
}
