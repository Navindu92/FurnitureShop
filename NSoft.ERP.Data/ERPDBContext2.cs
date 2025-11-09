using NSoft.ERP.Domain.Log;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.Data
{
    public class ERPDBContext2:DbContext
    {
        public ERPDBContext2():base("SysConn2")
        {
            Database.SetInitializer<ERPDBContext2>(new CreateDatabaseIfNotExists<ERPDBContext2>());
            //Database.SetInitializer<ERPDBContext2>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
        }
        #region DBSets
        public DbSet<MasterFileLog> MasterFileLog { get; set; }
        public DbSet<TransactionLog> TransactionLog { get; set; }
        public DbSet<SystemLog> SystemLog { get; set; }

        #endregion
    }
}
