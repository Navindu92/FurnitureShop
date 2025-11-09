









using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NSoft.ERP.Domain.General;
using NSoft.ERP.Domain.Inventory;

namespace NSoft.ERP.Data
{
    public class ERPDBContextInitializer : DropCreateDatabaseAlways<ERPDBContext>
    {
        protected override void Seed(ERPDBContext context)
        {
            AddGroupOfCompany(context);
            AddFormInfo(context);
            AddLocation(context);
            AddUserGroup(context);
            AddUser(context);
            // AddUserPrivileges(context);
            AddUserUserPrivilegesLocation(context);
            AddNumberSetup(context);
            AddReferenceInfo(context);
            AddPayType(context);
            AddCashier(context);
            AddCashierFunction(context);
            base.Seed(context);
        }

        private void AddGroupOfCompany(ERPDBContext context)
        {
            IList<GroupOfCompany> groupOfCompany = new List<GroupOfCompany>();
            groupOfCompany.Add(new GroupOfCompany { GroupOfCompanyCode = "001", GroupOfCompanyName = "ABC Super", IsActive = true });
            base.Seed(context);

            foreach (GroupOfCompany item in groupOfCompany)
                context.GroupOfCompany.Add(item);
        }
        private void AddUserGroup(ERPDBContext context)
        {
            IList<UserGroup> userGroup = new List<UserGroup>();
            userGroup.Add(new UserGroup { UserGroupCode = "01", UserGroupName = "Administrator", IsActive = true });
            userGroup.Add(new UserGroup { UserGroupCode = "02", UserGroupName = "Office", IsActive = true });
            userGroup.Add(new UserGroup { UserGroupCode = "03", UserGroupName = "Account", IsActive = true });
            base.Seed(context);

            foreach (UserGroup item in userGroup)
                context.UserGroup.Add(item);
        }
        private void AddUser(ERPDBContext context)
        {
            IList<User> user = new List<User>();
            user.Add(new User { Username = "Admin", Password = "12345", FullName = "", UserGroupID = 1, IsActive = true });
            base.Seed(context);

            foreach (User item in user)
                context.User.Add(item);
        }
        private void AddLocation(ERPDBContext context)
        {
            IList<Location> location = new List<Location>();
            location.Add(new Location { LocationCode = "001", LocationName = "Telijjawila", Address = "", IsStock = true, IsActive = true });
            base.Seed(context);

            foreach (Location item in location)
                context.Location.Add(item);
        }
        private void AddUserUserPrivilegesLocation(ERPDBContext context)
        {

            IList<UserPrivilegesLocation> userPrivilegesLocations = new List<UserPrivilegesLocation>();
            userPrivilegesLocations.Add(new UserPrivilegesLocation { UserID = 1, LocationID = 1, IsAllow = true });
            base.Seed(context);

            foreach (UserPrivilegesLocation item in userPrivilegesLocations)
                context.UserPrivilegesLocation.Add(item);
        }

        private void AddFormInfo(ERPDBContext context)
        {
            IList<FormInfo> formInfo = new List<FormInfo>();
            formInfo.Add(new FormInfo { FormName = "FrmUser", FormText = "User", Prefix = "", CodeLength = 3, FormType = 1, DocumentID = 1, IsActive = true, IsDepend = false, ModuleType = 1 });
            formInfo.Add(new FormInfo { FormName = "FrmLocation", FormText = "Location", Prefix = "", CodeLength = 3, FormType = 1, DocumentID = 2, IsActive = true, IsDepend = false, ModuleType = 1 });
            formInfo.Add(new FormInfo { FormName = "FrmCustomer", FormText = "Customer", Prefix = "C", CodeLength = 4, FormType = 1, DocumentID = 3, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "FrmDepartment", FormText = "Department", Prefix = "", CodeLength = 2, FormType = 1, DocumentID = 4, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "FrmCategory", FormText = "Category", Prefix = "", CodeLength = 2, FormType = 1, DocumentID = 5, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "FrmSupplier", FormText = "Supplier", Prefix = "S", CodeLength = 4, FormType = 1, DocumentID = 6, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "FrmSupplierGroup", FormText = "SupplierGroup", Prefix = "", CodeLength = 2, FormType = 1, DocumentID = 7, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "FrmCustomerGroup", FormText = "CustomerGroup", Prefix = "", CodeLength = 2, FormType = 1, DocumentID = 8, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "FrmBrand", FormText = "Brand", Prefix = "", CodeLength = 2, FormType = 1, DocumentID = 9, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "FrmSubCategory1", FormText = "SubCategory1", Prefix = "", CodeLength = 2, FormType = 1, DocumentID = 10, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "FrmSubCategory2", FormText = "SubCategory2", Prefix = "", CodeLength = 2, FormType = 1, DocumentID = 11, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "FrmItem", FormText = "Item", Prefix = "", CodeLength = 8, FormType = 1, DocumentID = 12, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "FrmSalesman", FormText = "Salesman", Prefix = "SM", CodeLength = 5, FormType = 1, DocumentID = 13, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "FrmInvoice", FormText = "Invoice", Prefix = "INV", CodeLength = 12, FormType = 2, DocumentID = 1000, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "FrmInvoiceReturn", FormText = "Invoice Return", Prefix = "SRN", CodeLength = 12, FormType = 2, DocumentID = 1001, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "FrmGoodsReceivedNote", FormText = "Goods Received Note", Prefix = "GRN", CodeLength = 12, FormType = 2, DocumentID = 1002, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "FrmPurchaseReturn", FormText = "Purchase Return", Prefix = "PRN", CodeLength = 12, FormType = 2, DocumentID = 1003, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "FrmPurchaseOrder", FormText = "Purchase Order", Prefix = "PO", CodeLength = 12, FormType = 2, DocumentID = 1004, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "FrmOpeningStock", FormText = "Opening Stock", Prefix = "OP", CodeLength = 12, FormType = 2, DocumentID = 1005, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "FrmCounterSummary", FormText = "Counter Summary", Prefix = "", CodeLength = 0, FormType = 3, DocumentID = 1006, IsActive = true, IsDepend = false, ModuleType = 1 });
            formInfo.Add(new FormInfo { FormName = "CounterOpenInventory", FormText = "Counter Open Inventory", Prefix = "", CodeLength = 0, FormType = 2, DocumentID = 1007, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "CounterCloseInventory", FormText = "Counter Close Inventory", Prefix = "", CodeLength = 0, FormType = 2, DocumentID = 1008, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "XReadingInventory", FormText = "X Reading Inventory", Prefix = "", CodeLength = 0, FormType = 2, DocumentID = 1009, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "PaidInInventory", FormText = "Inventory Paid In", Prefix = "", CodeLength = 0, FormType = 2, DocumentID = 1010, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "PaidOutInventory", FormText = "Inventory Paid Out", Prefix = "", CodeLength = 0, FormType = 2, DocumentID = 1011, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "OpenDrawer", FormText = "Open Drawer Inventory", Prefix = "", CodeLength = 0, FormType = 2, DocumentID = 1012, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "FrmBarcode", FormText = "Barcode", Prefix = "BR", CodeLength = 12, FormType = 2, DocumentID = 1013, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "FrmFastMoving", FormText = "Item Wise Fast Moving", Prefix = "", CodeLength = 0, FormType = 3, DocumentID = 2500, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "FrmSlowMoving", FormText = "Item Wise Slow Moving", Prefix = "", CodeLength = 0, FormType = 3, DocumentID = 2501, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "FrmNonMoving", FormText = "Item Wise Non Moving", Prefix = "", CodeLength = 0, FormType = 3, DocumentID = 2502, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "FrmBinCard", FormText = "Bin Card", Prefix = "", CodeLength = 0, FormType = 3, DocumentID = 2503, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "FrmGivenDateStock", FormText = "Given Date Stock", Prefix = "", CodeLength = 0, FormType = 3, DocumentID = 2504, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "FrmSystemConfiguration", FormText = "SystemConfiguration", Prefix = "", CodeLength = 3, FormType = 1, DocumentID = 13, IsActive = true, IsDepend = false, ModuleType = 1 });
            formInfo.Add(new FormInfo { FormName = "FrmSalesOrder", FormText = "Sales Order", Prefix = "SO", CodeLength = 12, FormType = 2, DocumentID = 1013, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "FrmStockAdjustment", FormText = "Stock Adjustment", Prefix = "STA", CodeLength = 12, FormType = 2, DocumentID = 1014, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "FrmChequeBookEntry", FormText = "Cheque Book Entry", Prefix = "", CodeLength = 2, FormType = 1, DocumentID = 14, IsActive = true, IsDepend = false, ModuleType = 6 });
            formInfo.Add(new FormInfo { FormName = "FrmChequePrint", FormText = "Cheque Print", Prefix = "", CodeLength = 2, FormType = 2, DocumentID = 1014, IsActive = true, IsDepend = false, ModuleType = 6 });
            formInfo.Add(new FormInfo { FormName = "FrmPaidInPaidOutReport", FormText = "Paid In Paid Out Report", Prefix = "", CodeLength = 0, FormType = 3, DocumentID = 2505, IsActive = true, IsDepend = false, ModuleType = 1 });
            formInfo.Add(new FormInfo { FormName = "FrmPurchaseSummary", FormText = "Purchase Summary", Prefix = "", CodeLength = 0, FormType = 3, DocumentID = 2506, IsActive = true, IsDepend = false, ModuleType = 1 });
            formInfo.Add(new FormInfo { FormName = "FrmSalesSummary", FormText = "Sales Summary", Prefix = "", CodeLength = 0, FormType = 3, DocumentID = 2507, IsActive = true, IsDepend = false, ModuleType = 1 });
            formInfo.Add(new FormInfo { FormName = "POSSalesHold", FormText = "Sales Hold", Prefix = "", CodeLength = 0, FormType = 4, DocumentID = 3000, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "POSSearch", FormText = "Search", Prefix = "", CodeLength = 0, FormType = 4, DocumentID = 3001, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "POSMenu", FormText = "Menu", Prefix = "", CodeLength = 0, FormType = 4, DocumentID = 3002, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "POSQty", FormText = "Qty", Prefix = "", CodeLength = 0, FormType = 4, DocumentID = 3003, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "POSDrawer", FormText = "Drawer", Prefix = "", CodeLength = 0, FormType = 4, DocumentID = 3004, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "POSItemDiscountPercentage", FormText = "Item Discount Percentage", Prefix = "", CodeLength = 0, FormType = 4, DocumentID = 3005, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "POSItemDiscountAmount", FormText = "Item Discount Amount", Prefix = "", CodeLength = 0, FormType = 4, DocumentID = 3006, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "POSClear", FormText = "Clear", Prefix = "", CodeLength = 0, FormType = 4, DocumentID = 3007, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "POSPayment", FormText = "Payment", Prefix = "", CodeLength = 0, FormType = 4, DocumentID = 3008, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "POSReCopy", FormText = "ReCopy", Prefix = "", CodeLength = 0, FormType = 4, DocumentID = 3009, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "POSPrice", FormText = "Price", Prefix = "", CodeLength = 0, FormType = 4, DocumentID = 3010, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "FrmPayment", FormText = "Payment", Prefix = "PY", CodeLength = 12, FormType = 2, DocumentID = 5000, IsActive = true, IsDepend = false, ModuleType = 3 });
            formInfo.Add(new FormInfo { FormName = "FrmCashier", FormText = "Cashier", Prefix = "", CodeLength = 4, FormType = 1, DocumentID = 4000, IsActive = true, IsDepend = false, ModuleType = 2 });
            formInfo.Add(new FormInfo { FormName = "FrmGiftVoucherGroup", FormText = "Gift Voucher Group", Prefix = "", CodeLength = 4, FormType = 1, DocumentID = 8000, IsActive = true, IsDepend = false, ModuleType = 8 });
            formInfo.Add(new FormInfo { FormName = "FrmGiftVoucherBook", FormText = "Gift Voucher Book", Prefix = "", CodeLength = 4, FormType = 1, DocumentID = 8001, IsActive = true, IsDepend = false, ModuleType = 8 });
            formInfo.Add(new FormInfo { FormName = "FrmSalesAnalysis", FormText = "Sales Analysis", Prefix = "", CodeLength = 0, FormType = 3, DocumentID = 2509, IsActive = true, IsDepend = false, ModuleType = 2 });

            base.Seed(context);

            foreach (FormInfo item in formInfo)
                context.FormInfo.Add(item);
        }

        private void AddUserPrivileges(ERPDBContext context)
        {
            var forms = context.FormInfo.ToList();
            var user = context.User.FirstOrDefault();
            IList<UserPrivileges> userPrivileges = new List<UserPrivileges>();
            foreach (var item in forms)
            {
                userPrivileges.Add(new UserPrivileges { UserID = user.UserID, FormInfoID = item.FormInfoID, IsAccess = true, IsSave = true, IsRemove = true });
            }
            base.Seed(context);

            foreach (UserPrivileges item in userPrivileges)
                context.UserPrivileges.Add(item);
        }

        private void AddNumberSetup(ERPDBContext context)
        {
            IList<NumberSetup> numberSetup = new List<NumberSetup>();
            numberSetup.Add(new NumberSetup { NumberSetupCode = "001", NumberSetupName = "InvoiceNo", DocumentID = 2000, SerialNo = 0 });
            numberSetup.Add(new NumberSetup { NumberSetupCode = "002", NumberSetupName = "GoodReceivedNo", DocumentID = 2002, SerialNo = 0 });
            numberSetup.Add(new NumberSetup { NumberSetupCode = "003", NumberSetupName = "SalesReturnNo", DocumentID = 2001, SerialNo = 0 });
            numberSetup.Add(new NumberSetup { NumberSetupCode = "004", NumberSetupName = "PurchaseReturnNo", DocumentID = 2003, SerialNo = 0 });
            numberSetup.Add(new NumberSetup { NumberSetupCode = "005", NumberSetupName = "PatientRegitrationNo", DocumentID = 4000, SerialNo = 0 });
            numberSetup.Add(new NumberSetup { NumberSetupCode = "006", NumberSetupName = "InvestigationNo", DocumentID = 4001, SerialNo = 0 });
            numberSetup.Add(new NumberSetup { NumberSetupCode = "007", NumberSetupName = "DoctorPayment", DocumentID = 4002, SerialNo = 0 });
            numberSetup.Add(new NumberSetup { NumberSetupCode = "008", NumberSetupName = "PaidInNo", DocumentID = 4008, SerialNo = 0 });
            numberSetup.Add(new NumberSetup { NumberSetupCode = "009", NumberSetupName = "PaidOutNo", DocumentID = 4009, SerialNo = 0 });
            numberSetup.Add(new NumberSetup { NumberSetupCode = "010", NumberSetupName = "LabReferenceNo", DocumentID = 4012, SerialNo = 0 });
            numberSetup.Add(new NumberSetup { NumberSetupCode = "011", NumberSetupName = "OpeningStockNo", DocumentID = 2005, SerialNo = 0 });
            numberSetup.Add(new NumberSetup { NumberSetupCode = "012", NumberSetupName = "SalesOrderNo", DocumentID = 2012, SerialNo = 0 });
            numberSetup.Add(new NumberSetup { NumberSetupCode = "013", NumberSetupName = "StockAdjustmentNo", DocumentID = 2013, SerialNo = 0 });
            numberSetup.Add(new NumberSetup { NumberSetupCode = "014", NumberSetupName = "POSSalesHoldNo", DocumentID = 3000, SerialNo = 0 });
            base.Seed(context);

            foreach (NumberSetup item in numberSetup)
                context.NumberSetup.Add(item);
        }

        private void AddReferenceInfo(ERPDBContext context)
        {
            IList<ReferenceInfo> referenceInfo = new List<ReferenceInfo>();
            referenceInfo.Add(new ReferenceInfo { ReferenceTypeID = 1, SubNo = 1, ReferenceType = "Gender", ReferenceValue = "Male", IsActive = true });
            referenceInfo.Add(new ReferenceInfo { ReferenceTypeID = 1, SubNo = 2, ReferenceType = "Gender", ReferenceValue = "Female", IsActive = true });
            referenceInfo.Add(new ReferenceInfo { ReferenceTypeID = 1, SubNo = 3, ReferenceType = "Gender", ReferenceValue = "Other", IsActive = true });
            referenceInfo.Add(new ReferenceInfo { ReferenceTypeID = 2, SubNo = 1, ReferenceType = "Title", ReferenceValue = "Mr.", IsActive = true });
            referenceInfo.Add(new ReferenceInfo { ReferenceTypeID = 2, SubNo = 2, ReferenceType = "Title", ReferenceValue = "Miss.", IsActive = true });
            referenceInfo.Add(new ReferenceInfo { ReferenceTypeID = 2, SubNo = 3, ReferenceType = "Title", ReferenceValue = "Mrs.", IsActive = true });
            referenceInfo.Add(new ReferenceInfo { ReferenceTypeID = 2, SubNo = 4, ReferenceType = "Title", ReferenceValue = "Dr.", IsActive = true });
            referenceInfo.Add(new ReferenceInfo { ReferenceTypeID = 2, SubNo = 5, ReferenceType = "Title", ReferenceValue = "Prof.", IsActive = true });
            referenceInfo.Add(new ReferenceInfo { ReferenceTypeID = 3, SubNo = 1, ReferenceType = "RoomType", ReferenceValue = "AC", IsActive = true });
            referenceInfo.Add(new ReferenceInfo { ReferenceTypeID = 3, SubNo = 2, ReferenceType = "RoomType", ReferenceValue = "Non AC", IsActive = true });
            referenceInfo.Add(new ReferenceInfo { ReferenceTypeID = 4, SubNo = 1, ReferenceType = "Days", ReferenceValue = "Sunday", IsActive = true });
            referenceInfo.Add(new ReferenceInfo { ReferenceTypeID = 4, SubNo = 2, ReferenceType = "Days", ReferenceValue = "Monday", IsActive = true });
            referenceInfo.Add(new ReferenceInfo { ReferenceTypeID = 4, SubNo = 3, ReferenceType = "Days", ReferenceValue = "Tuseday", IsActive = true });
            referenceInfo.Add(new ReferenceInfo { ReferenceTypeID = 4, SubNo = 4, ReferenceType = "Days", ReferenceValue = "Wednesday", IsActive = true });
            referenceInfo.Add(new ReferenceInfo { ReferenceTypeID = 4, SubNo = 5, ReferenceType = "Days", ReferenceValue = "Thurseday", IsActive = true });
            referenceInfo.Add(new ReferenceInfo { ReferenceTypeID = 4, SubNo = 6, ReferenceType = "Days", ReferenceValue = "Friday", IsActive = true });
            referenceInfo.Add(new ReferenceInfo { ReferenceTypeID = 4, SubNo = 7, ReferenceType = "Days", ReferenceValue = "Satureday", IsActive = true });
            referenceInfo.Add(new ReferenceInfo { ReferenceTypeID = 5, SubNo = 1, ReferenceType = "Serial Visibility", ReferenceValue = "Sequential", IsActive = true });
            referenceInfo.Add(new ReferenceInfo { ReferenceTypeID = 5, SubNo = 2, ReferenceType = "Serial Visibility", ReferenceValue = "Timestamp", IsActive = true });
            referenceInfo.Add(new ReferenceInfo { ReferenceTypeID = 6, SubNo = 1, ReferenceType = "Appointment Status", ReferenceValue = "Book", IsActive = true });
            referenceInfo.Add(new ReferenceInfo { ReferenceTypeID = 6, SubNo = 2, ReferenceType = "Appointment Status", ReferenceValue = "Paid", IsActive = true });
            referenceInfo.Add(new ReferenceInfo { ReferenceTypeID = 7, SubNo = 1, ReferenceType = "Appointment Cancel Status", ReferenceValue = "Cancel", IsActive = true });
            referenceInfo.Add(new ReferenceInfo { ReferenceTypeID = 7, SubNo = 2, ReferenceType = "Appointment Cancel Status", ReferenceValue = "Refund", IsActive = true });
            referenceInfo.Add(new ReferenceInfo { ReferenceTypeID = 8, SubNo = 1, ReferenceType = "Age Type", ReferenceValue = "Year", IsActive = true });
            referenceInfo.Add(new ReferenceInfo { ReferenceTypeID = 8, SubNo = 2, ReferenceType = "Age Type", ReferenceValue = "Years", IsActive = true });
            referenceInfo.Add(new ReferenceInfo { ReferenceTypeID = 8, SubNo = 3, ReferenceType = "Age Type", ReferenceValue = "Month", IsActive = true });
            referenceInfo.Add(new ReferenceInfo { ReferenceTypeID = 8, SubNo = 4, ReferenceType = "Age Type", ReferenceValue = "Months", IsActive = true });
            referenceInfo.Add(new ReferenceInfo { ReferenceTypeID = 8, SubNo = 5, ReferenceType = "Age Type", ReferenceValue = "Week", IsActive = true });
            referenceInfo.Add(new ReferenceInfo { ReferenceTypeID = 8, SubNo = 6, ReferenceType = "Age Type", ReferenceValue = "Weeks", IsActive = true });
            referenceInfo.Add(new ReferenceInfo { ReferenceTypeID = 8, SubNo = 7, ReferenceType = "Age Type", ReferenceValue = "Day", IsActive = true });
            referenceInfo.Add(new ReferenceInfo { ReferenceTypeID = 8, SubNo = 8, ReferenceType = "Age Type", ReferenceValue = "Days", IsActive = true });
            referenceInfo.Add(new ReferenceInfo { ReferenceTypeID = 9, SubNo = 1, ReferenceType = "Adjustment Type", ReferenceValue = "Add", IsActive = true });
            referenceInfo.Add(new ReferenceInfo { ReferenceTypeID = 9, SubNo = 2, ReferenceType = "Adjustment Type", ReferenceValue = "Reduce", IsActive = true });
            base.Seed(context);

            foreach (ReferenceInfo item in referenceInfo)
                context.ReferenceInfo.Add(item);
        }

        private void AddPayType(ERPDBContext context)
        {
            IList<PayType> payType = new List<PayType>();
            payType.Add(new PayType { PayTypeCode = "001", PayTypeName = "Cash", IsActive = true });
            payType.Add(new PayType { PayTypeCode = "002", PayTypeName = "Credit Card", IsActive = true });
            payType.Add(new PayType { PayTypeCode = "003", PayTypeName = "Cheque", IsActive = true });
            base.Seed(context);

            foreach (PayType item in payType)
                context.PayType.Add(item);
        }

        private void AddPaidInType(ERPDBContext context)
        {
            IList<PaidInType> paidInType = new List<PaidInType>();
            paidInType.Add(new PaidInType { PaidInTypeCode = "001", PaidInTypeName = "PAID IN", IsActive = true });

            base.Seed(context);

            foreach (PaidInType item in paidInType)
                context.PaidInType.Add(item);
        }
        private void AddPaidOutType(ERPDBContext context)
        {
            IList<PaidOutType> paidOutType = new List<PaidOutType>();
            paidOutType.Add(new PaidOutType { PaidOutTypeCode = "001", PaidOutTypeName = "PAID OUT", IsActive = true });
            paidOutType.Add(new PaidOutType { PaidOutTypeCode = "002", PaidOutTypeName = "BANK DEPOSIT", IsActive = true });
            paidOutType.Add(new PaidOutType { PaidOutTypeCode = "003", PaidOutTypeName = "SALARY ADVANCE", IsActive = true });
            base.Seed(context);

            foreach (PaidOutType item in paidOutType)
                context.PaidOutType.Add(item);
        }

        private void AddCashier(ERPDBContext context)
        {
            IList<Cashier> cashier = new List<Cashier>();
            cashier.Add(new Cashier { CashierName = "Admin", Password = "12345", Encode = "", IsActive = true, IsDelete = false });

            base.Seed(context);

            foreach (Cashier item in cashier)
                context.Cashier.Add(item);
        }
        private void AddCashierFunction(ERPDBContext context)
        {
            IList<CashierFunction> cashierFunction = new List<CashierFunction>();
            cashierFunction.Add(new CashierFunction { CashierFunctionCode = "001", CashierFunctionName = "Search", IsActive = true, IsDelete = false });
            cashierFunction.Add(new CashierFunction { CashierFunctionCode = "002", CashierFunctionName = "Menu", IsActive = true, IsDelete = false });
            cashierFunction.Add(new CashierFunction { CashierFunctionCode = "003", CashierFunctionName = "Qty", IsActive = true, IsDelete = false });
            cashierFunction.Add(new CashierFunction { CashierFunctionCode = "004", CashierFunctionName = "Drawer", IsActive = true, IsDelete = false });
            cashierFunction.Add(new CashierFunction { CashierFunctionCode = "005", CashierFunctionName = "Item Discount Percentage", IsActive = true, IsDelete = false });
            cashierFunction.Add(new CashierFunction { CashierFunctionCode = "006", CashierFunctionName = "Item Discount Amount", IsActive = true, IsDelete = false });
            cashierFunction.Add(new CashierFunction { CashierFunctionCode = "007", CashierFunctionName = "Cancel", IsActive = true, IsDelete = false });
            cashierFunction.Add(new CashierFunction { CashierFunctionCode = "008", CashierFunctionName = "Void", IsActive = true, IsDelete = false });
            cashierFunction.Add(new CashierFunction { CashierFunctionCode = "009", CashierFunctionName = "Hold", IsActive = true, IsDelete = false });
            cashierFunction.Add(new CashierFunction { CashierFunctionCode = "010", CashierFunctionName = "Copy", IsActive = true, IsDelete = false });
            cashierFunction.Add(new CashierFunction { CashierFunctionCode = "011", CashierFunctionName = "Price", IsActive = true, IsDelete = false });
            cashierFunction.Add(new CashierFunction { CashierFunctionCode = "012", CashierFunctionName = "More", IsActive = true, IsDelete = false });
            cashierFunction.Add(new CashierFunction { CashierFunctionCode = "013", CashierFunctionName = "Loyalty", IsActive = true, IsDelete = false });
            cashierFunction.Add(new CashierFunction { CashierFunctionCode = "014", CashierFunctionName = "Salesman", IsActive = true, IsDelete = false });
            cashierFunction.Add(new CashierFunction { CashierFunctionCode = "015", CashierFunctionName = "Sub Total", IsActive = true, IsDelete = false });
            base.Seed(context);

            foreach (CashierFunction item in cashierFunction)
                context.CashierFunction.Add(item);
        }
    }
}
