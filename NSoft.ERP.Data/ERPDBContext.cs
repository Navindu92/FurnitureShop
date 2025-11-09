using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NSoft.ERP.Domain.General;
using System.ComponentModel.DataAnnotations.Schema;

using NSoft.ERP.Domain.Inventory;
using NSoft.ERP.Domain.Accounts;
using NSoft.ERP.Utility;
using NSoft.ERP.Domain.CRM;
using NSoft.ERP.Domain.GiftVoucher;

namespace NSoft.ERP.Data
{
    public class ERPDBContext : DbContext
    {

        public ERPDBContext() : base("SysConn")
        {
            //Database.SetInitializer<ERPDBContext>(new CreateDatabaseIfNotExists<ERPDBContext>());
            //Database.SetInitializer<ERPDBContext>(new DropCreateDatabaseIfModelChanges<ERPDBContext>());
            //Database.SetInitializer<ERPDBContext>(new DropCreateDatabaseAlways<ERPDBContext>());
            //Database.SetInitializer<ERPDBContext>(new ERPDBContextInitializer());

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<ERPDBContext>(new DropCreateDatabaseIfModelChanges<ERPDBContext>());
            //Database.SetInitializer<ERPDBContext>(new ERPDBContextInitializer());
            Database.SetInitializer<ERPDBContext>(null);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            #region Change Decimal Places

            byte decimalPointsQty = Common.QtyDecimalPlaces;

            modelBuilder.Entity<Item>().Property(x => x.ReOrderLevel).HasPrecision(18, decimalPointsQty);
            modelBuilder.Entity<Item>().Property(x => x.ReOrderQty).HasPrecision(18, decimalPointsQty);

            modelBuilder.Entity<ItemStock>().Property(x => x.Stock).HasPrecision(18, decimalPointsQty);

            modelBuilder.Entity<OpeningStockSub>().Property(x => x.Qty).HasPrecision(18, decimalPointsQty);

            modelBuilder.Entity<SalesMain>().Property(x => x.NoOfPieces).HasPrecision(18, decimalPointsQty);

            modelBuilder.Entity<SalesSub>().Property(x => x.CurrentQty).HasPrecision(18, decimalPointsQty);
            modelBuilder.Entity<SalesSub>().Property(x => x.Qty).HasPrecision(18, 3);
            modelBuilder.Entity<SalesSub>().Property(x => x.BalanceQty).HasPrecision(18, decimalPointsQty);

            modelBuilder.Entity<SalesTemp>().Property(x => x.CurrentQty).HasPrecision(18, decimalPointsQty);
            modelBuilder.Entity<SalesTemp>().Property(x => x.Qty).HasPrecision(18, decimalPointsQty);

            modelBuilder.Entity<SalesHold>().Property(x => x.CurrentQty).HasPrecision(18, decimalPointsQty);
            modelBuilder.Entity<SalesHold>().Property(x => x.Qty).HasPrecision(18, decimalPointsQty);
            modelBuilder.Entity<SalesHold>().Property(x => x.BalanceQty).HasPrecision(18, decimalPointsQty);

            modelBuilder.Entity<PurchaseSub>().Property(x => x.CurrentQty).HasPrecision(18, decimalPointsQty);
            modelBuilder.Entity<PurchaseSub>().Property(x => x.Qty).HasPrecision(18, decimalPointsQty);
            modelBuilder.Entity<PurchaseSub>().Property(x => x.FreeQty).HasPrecision(18, decimalPointsQty);

            modelBuilder.Entity<StockAdjustmentSub>().Property(x => x.CurrentQty).HasPrecision(18, decimalPointsQty);
            modelBuilder.Entity<StockAdjustmentSub>().Property(x => x.Qty).HasPrecision(18, decimalPointsQty);
            modelBuilder.Entity<StockAdjustmentSub>().Property(x => x.AdjustQty).HasPrecision(18, decimalPointsQty);

            modelBuilder.Entity<PurchaseOrderSub>().Property(x => x.CurrentQty).HasPrecision(18, decimalPointsQty);
            modelBuilder.Entity<PurchaseOrderSub>().Property(x => x.Qty).HasPrecision(18, decimalPointsQty);
            modelBuilder.Entity<PurchaseOrderSub>().Property(x => x.FreeQty).HasPrecision(18, decimalPointsQty);
            modelBuilder.Entity<PurchaseOrderSub>().Property(x => x.BalanceQty).HasPrecision(18, decimalPointsQty);
            modelBuilder.Entity<PurchaseOrderSub>().Property(x => x.BalanceFreeQty).HasPrecision(18, decimalPointsQty);

            #endregion
            base.OnModelCreating(modelBuilder);
        }
        #region DBSets
        public DbSet<GroupOfCompany> GroupOfCompany { get; set; }
        public DbSet<FormInfo> FormInfo { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<UserGroup> UserGroup { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserPrivilegesLocation> UserPrivilegesLocation { get; set; }
        public DbSet<UserPrivileges> UserPrivileges { get; set; }
        public DbSet<NumberSetup> NumberSetup { get; set; }
        public DbSet<ReferenceInfo> ReferenceInfo { get; set; }
        public DbSet<PayType> PayType { get; set; }
        public DbSet<Counter> Counter { get; set; }
        public DbSet<CounterTransaction> CounterTransaction { get; set; }
        public DbSet<CounterTransactionFloat> CounterTransactionFloat { get; set; }
        public DbSet<PaidInType> PaidInType { get; set; }
        public DbSet<PaidOutType> PaidOutType { get; set; }
        public DbSet<PaidInPaidOutMain> PaidInPaidOutMain { get; set; }
        public DbSet<PaidInPaidOutSub> PaidInPaidOutSub { get; set; }
        public DbSet<RCounterSummary> RCounterSummary { get; set; }
        public DbSet<DrawerTransaction> DrawerTransaction { get; set; }
        public DbSet<SystemConfiguration> SystemConfiguration { get; set; }
        //public DbSet<CounterConfiguration> CounterConfiguration { get; set; }
        public DbSet<Bank> Bank { get; set; }

        #region Inventory
        public DbSet<SupplierGroup> SupplierGroup { get; set; }
        public DbSet<CustomerGroup> CustomerGroup { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<SubCategory1> SubCategory1 { get; set; }
        public DbSet<SubCategory2> SubCategory2 { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<ItemSupplier> ItemSupplier { get; set; }
        public DbSet<ItemStock> ItemStock { get; set; }
        public DbSet<ItemPrice> ItemPrice { get; set; }
        public DbSet<ItemCodeDependency> ItemCodeDependency { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<SalesMain> SalesMain { get; set; }
        public DbSet<SalesSub> SalesSub { get; set; }
        public DbSet<SalesPayment> SalesPayment { get; set; }
        public DbSet<SalesHold> SalesHold { get; set; }
        public DbSet<SalesTemp> SalesTemp { get; set; }
        public DbSet<OpeningStockMain> OpeningStockMain { get; set; }
        public DbSet<OpeningStockSub> OpeningStockSub { get; set; }
        public DbSet<PurchaseMain> PurchaseMain { get; set; }
        public DbSet<PurchaseSub> PurchaseSub { get; set; }
        public DbSet<PurchaseOrderMain> PurchaseOrderMain { get; set; }
        public DbSet<PurchaseOrderSub> PurchaseOrderSub { get; set; }
        public DbSet<SalesOrderMain> SalesOrderMain { get; set; }
        public DbSet<SalesOrderSub> SalesOrderSub { get; set; }
        public DbSet<StockAdjustmentMain> StockAdjustmentMain { get; set; }
        public DbSet<StockAdjustmentSub> StockAdjustmentSub { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<FloatMaster> FloatMaster { get; set; }
        public DbSet<CashierFunction> CashierFunction { get; set; }
        public DbSet<Cashier> Cashier { get; set; }
        public DbSet<CashierPrivileges> CashierPrivileges { get; set; }
        public DbSet<Salesman> Salesman { get; set; }

        #endregion

        #region Accounts

        public DbSet<ChequeBookEntry> ChequeBookEntry { get; set; }

        public DbSet<PaymentMain> PaymentMain { get; set; }

        #endregion

        #region CRM

        public DbSet<LoyaltyCard> LoyaltyCard { get; set; }
        public DbSet<LoyaltyCustomer> LoyaltyCustomer { get; set; }
        public DbSet<LoyaltyTransaction> LoyaltyTransaction { get; set; }

        #endregion

        #region Gift Voucher
        public DbSet<GiftVoucherGroup> GiftVoucherGroup { get; set; }
        public DbSet<GiftVoucherBook> GiftVoucherBook { get; set; }
        public DbSet<GiftVoucherMaster> GiftVoucherMaster { get; set; }

        #endregion

        #endregion
    }
}
