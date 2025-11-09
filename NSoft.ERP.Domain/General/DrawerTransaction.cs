using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Domain.General
{
    public class DrawerTransaction:BaseEntity
    {
        public long DrawerTransactionID { get; set; }
        public long LocationID { get; set; }
        public long CounterID { get; set; }
        public long UserID { get; set; }
        public int TrasactionType { get; set; } //1-Drawer Open /2-Drawer Close 
        public DateTime TransactionDate { get; set; }
        public TimeSpan TransactionTime { get; set; }
    }
}
