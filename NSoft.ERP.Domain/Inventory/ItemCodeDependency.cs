using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.Inventory
{
    public class ItemCodeDependency:BaseEntity
    {
        public long ItemCodeDependencyID { get; set; }
        [DefaultValue(0)]
        public long DocumentID { get; set; }
        [DefaultValue(0)]
        public bool IsDependCategoryCode { get; set; }
        [DefaultValue(0)]
        public bool IsDependSubCategory1Code { get; set; }
        [DefaultValue(0)]
        public bool IsDependSubCategory2Code { get; set; }
        [DefaultValue(0)]
        public bool IsDependBrandCode { get; set; }
        [DefaultValue(0)]
        public bool IsDelete { get; set; }
    }
}
