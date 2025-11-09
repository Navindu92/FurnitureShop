using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.General
{
    public class CounterTransactionFloat
    {
        public long CounterTransactionFloatID { get; set; }
        public long CounterTransactionID { get; set; }
        public long LocationID { get; set; }
        public long CounterNo { get; set; }
        public int FloatMasterID { get; set; }
        [DefaultValue(0)]
        public int FloatValue { get; set; }
        public int FloatCount { get; set; }
        public int FloatAmount { get; set; }
        public long UserID { get; set; }
        public long Zno { get; set; }
        public DateTime ZDate { get; set; }
    }
}
