using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.General
{
    public class FormInfo:BaseEntity
    {
        public long FormInfoID { get; set; }
        [MaxLength(30)]
        public string FormName { get; set; }
        [MaxLength(50)]
        public string FormText { get; set; }
        [MaxLength(5)]
        public string Prefix { get; set; }
        public int CodeLength { get; set; }
        public int FormType { get; set; }

        public int ModuleType { get; set; }
        public long DocumentID { get; set; }

        [DefaultValue(0)]
        public bool IsAutoGenerate { get; set; }

        [DefaultValue(0)]
        public bool IsDepend { get; set; }

        [DefaultValue(0)]
        public bool IsActive { get; set; }

        [DefaultValue(0)]
        public bool IsDelete { get; set; }
    }
}
