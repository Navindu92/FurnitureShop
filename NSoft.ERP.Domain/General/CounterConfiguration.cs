using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.General
{
    public class CounterConfiguration : BaseEntity
    {
        public long CounterConfigurationID { get; set; }
        public long LocationID { get; set; }
        public long CounterID { get; set; }
        public string PrinterName { get; set; }
        public float PrinterWidth { get; set; }
        public int DashWidth { get; set; }
        public int MarginX { get; set; }
        public bool IsPrintLogo { get; set; }
        public string LogoPath { get; set; }
        public bool IsPrintSinhala { get; set; }

        [MaxLength(50)]
        public string Header1 { get; set; }
        [MaxLength(50)]
        public string Header2 { get; set; }
        [MaxLength(50)]
        public string Header3 { get; set; }
        [MaxLength(50)]
        public string Header4 { get; set; }
        [MaxLength(50)]
        public string Header5 { get; set; }
        [MaxLength(50)]
        public string Tail1 { get; set; }
        [MaxLength(50)]
        public string Tail2 { get; set; }

        [MaxLength(50)]
        public string Tail3 { get; set; }
        public bool IsDisplayConnected { get; set; }
        public string DisplayComPort { get; set; }

        [MaxLength(50)]
        public string DisplayText1 { get; set; }
        [MaxLength(50)]
        public string DisplayText2 { get; set; }
        public bool IsDualDisplay { get; set; }

        [MaxLength(100)]
        public string VideoPath { get; set; }

    }
}
