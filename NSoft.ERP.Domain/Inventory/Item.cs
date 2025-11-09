using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.Inventory
{
    public class Item : BaseEntity
    {
        public long ItemID { get; set; }
        [MaxLength(20)]
        public string ItemCode { get; set; }
        [MaxLength(50)]
        public string BarCode { get; set; }
        [MaxLength(50)]
        public string ReferenceCode1 { get; set; }

        [MaxLength(50)]
        public string ReferenceCode2 { get; set; }

        [MaxLength(50)]
        public string ReferenceCode3 { get; set; }
        [MaxLength(60)]
        public string ItemName { get; set; }
        [MaxLength(150)]
        public string NameOnInvoice { get; set; }

        [MaxLength(150)]
        public string SinhalaName { get; set; }
        [DefaultValue(0)]
        public long CategoryID { get; set; }
        [DefaultValue(0)]
        public long SubCategory1ID { get; set; }
        [DefaultValue(0)]
        public long SubCategory2ID { get; set; }

        [DefaultValue(0)]
        public long BrandID { get; set; }
        [DefaultValue(0)]
        public decimal ReOrderLevel { get; set; }
        [DefaultValue(0)]
        public decimal ReOrderQty { get; set; }
        [DefaultValue(0)]
        public decimal SellingPrice { get; set; }
        [DefaultValue(0)]
        public decimal CostPrice { get; set; }
        [DefaultValue(0)]
        public decimal MarginPercentage { get; set; }
        [DefaultValue(0)]
        public decimal MaximumPrice { get; set; }
        [DefaultValue(0)]
        public decimal MinimumPrice { get; set; }
        [DefaultValue(0)]
        public decimal FixedDiscountPercentage { get; set; }

        [DefaultValue(0)]
        public decimal FixedDiscount { get; set; }
        public byte[] ItemImage { get; set; }
        [DefaultValue(0)]
        public bool IsActive { get; set; }

        [DefaultValue(0)]
        public bool IsCountable { get; set; }

        [DefaultValue(0)]
        public bool IsDelete { get; set; }
    }
}
