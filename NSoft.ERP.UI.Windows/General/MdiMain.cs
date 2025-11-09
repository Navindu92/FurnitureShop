using NSoft.ERP.Domain.General;
using NSoft.ERP.UI.Windows.General.UI.Windows;
using NSoft.ERP.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NSoft.ERP.Reports.Forms.General;
using NSoft.ERP.Service.General;
using NSoft.ERP.Service.General;
using NSoft.ERP.UI.Windows.Inventory;
using NSoft.ERP.Reports.Forms.Inventory;
using NSoft.ERP.Reports.Reports.Inventory;
using NSoft.ERP.UI.Windows.Accounts;

namespace NSoft.ERP.UI.Windows.General
{
    public partial class MdiMain : Form
    {
        public MdiMain()
        {
            InitializeComponent();
            DisableMenu();
            //ChangeTheme();
        }

        Ribbon ribbon;
        private void ChangeTheme()
        {
            Theme.ThemeColor = RibbonTheme.Purple;
            mnuMenu.BackColor = Color.Purple;
            this.Refresh();
        }

        private void MdiMain_Load(object sender, EventArgs e)
        {
            try
            {
                tmDisplayCurrentTime.Enabled = true;
                ActiveModules();
                SetClientWiseSetting();
                SetStatusSignOut();


            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }

        #region Button Events
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (SysMessage.ShowMessage(SysMessage.MessageAction.Exit, SysMessage.MessageType.Question, "Exit ERP").Equals(DialogResult.Yes))
            {
                Application.Exit();
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnSignOut_Click(object sender, EventArgs e)
        {
            try
            {
                this.MdiChildren.OfType<Form>().ToList().ForEach(x => x.Close());
                Common.CloseChildForms(this);
                DisableMenu();
                FrmLogin FrmLogin = new FrmLogin(this);
                Common.SetForm(FrmLogin, this);
                SetStatusSignOut();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        #endregion

        #region Private Methods 

        #region Active Modules 
        private void ActiveModules()
        {
            try
            {
                #region General

                if (Common.ModuleType.General == true)
                { rbtbGeneral.Visible = true; mnuMFGenaral.Visible = true; }
                else
                { rbtbGeneral.Visible = false; mnuMFGenaral.Visible = false; }

                #endregion

                #region Inventory

                if (Common.ModuleType.Inventory == true)
                { rbtbInventory.Visible = true; mnuMFInventory.Visible = true; mnuTRInventory.Visible = true; mnuRptInventory.Visible = true; }
                else
                { rbtbInventory.Visible = false; mnuMFInventory.Visible = false; mnuTRInventory.Visible = false; mnuRptInventory.Visible = false; }

                #endregion

                #region Accounts
                if (Common.ModuleType.Account == true)
                { rbtbAccounts.Visible = true; mnuMFAccounts.Visible = true; mnuTRAccounts.Visible = true; mnuRptAccounts.Visible = true; }
                else
                { rbtbAccounts.Visible = false; mnuMFAccounts.Visible = false; mnuTRAccounts.Visible = false; mnuRptAccounts.Visible = false; }
                #endregion
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        #endregion

        public void SetClientWiseSetting()
        {
            try
            {
                FormInfo formInfoSubCategory = new FormInfo();
                FormInfo formInfoSubCategory2 = new FormInfo();

                formInfoSubCategory = FormInfoService.GetFormInfoByName("FrmSubCategory1");
                formInfoSubCategory2 = FormInfoService.GetFormInfoByName("FrmSubCategory2");

                if (formInfoSubCategory != null)
                {
                    mnuMFSubCategory.Text = formInfoSubCategory.FormText.Trim();
                }
                if (formInfoSubCategory2 != null)
                {
                    mnuMFSubCategory2.Text = formInfoSubCategory2.FormText.Trim();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void SetStatusSignOut()
        {
            try
            {
                lblStatusLocation.Font = new Font(lblStatusLocation.Font, FontStyle.Regular);
                lblStatusUser.Font = new Font(lblStatusUser.Font, FontStyle.Regular);
                lblStatusDate.Font = new Font(lblStatusDate.Font, FontStyle.Regular);
                lblStatusTime.Font = new Font(lblStatusTime.Font, FontStyle.Regular);
                lblStatusServer.Font = new Font(lblStatusServer.Font, FontStyle.Regular);

                lblStatusUser.Text = string.Empty;
                lblStatusLocation.Text = string.Empty;
                lblStatus.Text = ":: Sign Out";

                StatusProgressBar.Visible = false;
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        #region Disable Menu

        private void DisableMenu()
        {
            try
            {
                #region Ribbon

                #region General
                rbtnLocation.Enabled = false;
                #endregion

                #region Options
                rbtnUserGroups.Enabled = false;
                rbtnUserMaster.Enabled = false;
                #endregion

                #region Inventory
                rbtnSupplier.Enabled = false;
                rbtnCustomer.Enabled = false;
                rbtnBrand.Enabled = false;
                rbtnCategory.Enabled = false;
                rbtnItem.Enabled = false;
                rbtnOpeningStock.Enabled = false;
                rbtnPurcahseOrder.Enabled = false;
                rbtnGoodReceivedNote.Enabled = false;
                rbtnInvoice.Enabled = false;
                rbtnPaidInInventory.Enabled = false;
                rbtnPaidOutInventory.Enabled = false;
                rbtnInvOpenDrawer.Enabled = false;
                rbtnSalesOrder.Enabled = false;
                rbtnStockAdjustment.Enabled = false;
                rbtnBarcodePrint.Enabled = false;
                #endregion

                #region Accounts
                rbtnChequeBookEntry.Enabled = false;
                rbtnChequePrint.Enabled = false;
                #endregion

                #region POS
                rbtnCashier.Enabled = false;
                #endregion

                #region Gift Voucher
                rbtnGVGroup.Enabled = false;
                rbtnGVBook.Enabled = false;
                #endregion

                #endregion

                #region Menu

                #region General

                mnuMFLocation.Enabled = false;
                #region Report
                mnuRptCounterSummary.Enabled = false;
                mnuRptPaidInPaidOutDetails.Enabled = false;
                #endregion

                #endregion

                #region Inventory
                mnuMFSupplier.Enabled = false;
                mnuMFCustomer.Enabled = false;
                mnuMFSupplierGroup.Enabled = false;
                mnuMFCustomerGroup.Enabled = false;
                mnuMFBrand.Enabled = false;
                mnuMFCategory.Enabled = false;
                mnuMFItem.Enabled = false;
                mnuMFSalesMan.Enabled = false;
                mnuTROpeningStock.Enabled = false;
                mnuTRPurchaseOrder.Enabled = false;
                mnuTRGoodsReceivedNote.Enabled = false;
                mnuTRInvoice.Enabled = false;
                mnuTrPaidInInventory.Enabled = false;
                mnuTrPaidOutInventory.Enabled = false;
                mnuMFSubCategory.Enabled = false;
                mnuMFSubCategory2.Enabled = false;
                mnuTrCounterOpenInventory.Enabled = false;
                mnuTrCounterCloseInventory.Enabled = false;
                mnuTrXReadingInventory.Enabled = false;
                mnuTRSalesOrder.Enabled = false;
                mnuTRStockAdjustment.Enabled = false;
                mnuTRSalesReturn.Enabled = false;
                mnuTrBarcodePrint.Enabled = false;
                mnuTrPurchaseReturn.Enabled = false;

                #region Report
                mnuRptStockBinCard.Enabled = false;
                mnuRptFastMoving.Enabled = false;
                mnuRptSlowMoving.Enabled = false;
                mnuRptNonMoving.Enabled = false;
                mnuRptGRNDetails.Enabled = false;
                mnuRptGivenDateStock.Enabled = false;
                mnuRptInvoiceDetails.Enabled = false;
                mnuRptPurchaseSummary.Enabled = false;
                mnuRptPurchaseSummary.Enabled = false;
                mnuRptSalesSummary.Enabled = false;
                mnuRptSalesAnalysis.Enabled = false;
                #endregion
                #endregion

                #region Accounts
                mnuMFChequeBookEntry.Enabled = false;
                mnuTRChequePrint.Enabled = false;
                mnuTRSupplierPayment.Enabled = false;
                #endregion

                #region POS
                mnuMFCashier.Enabled = false;
                #endregion

                #region Gift Voucher
                mnuMFGiftVoucherGroup.Enabled = false;
                mnuMFGiftVoucherBook.Enabled = false;
                #endregion

                #region Options
                mnuUserGroups.Enabled = false;
                mnuUser.Enabled = false;
                mnuSystemConfiguration.Enabled = false;
                #endregion

                #endregion
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        #endregion

        #region Get Privileges

        public void GetUserPrivileges(string username)
        {
            try
            {
                UserService userService = new UserService();
                var privileges = userService.GetAllAccessPrivilegesByUserName(username);
                foreach (var item in privileges)
                {
                    switch (item.FormName)
                    {
                        #region General

                        #region Master Files
                        case "FrmLocation":
                            rbtnLocation.Enabled = true;
                            mnuMFLocation.Enabled = true;
                            break;

                        #region Reports
                        case "FrmCounterSummary":
                            mnuRptCounterSummary.Enabled = true;
                            break;

                        case "FrmPaidInPaidOutReport":
                            mnuRptPaidInPaidOutDetails.Enabled = true;
                            break;

                        case "FrmSalesAnalysis":
                            mnuRptSalesAnalysis.Enabled = true;
                            break;

                        #endregion
                        #endregion

                        #endregion

                        #region Inventory

                        #region Master Files
                        case "FrmSupplier":
                            rbtnSupplier.Enabled = true;
                            mnuMFSupplier.Enabled = true;
                            break;
                        case "FrmSupplierGroup":
                            mnuMFSupplierGroup.Enabled = true;
                            break;
                        case "FrmCustomer":
                            rbtnCustomer.Enabled = true;
                            mnuMFCustomer.Enabled = true;
                            break;
                        case "FrmCustomerGroup":
                            mnuMFCustomerGroup.Enabled = true;
                            break;
                        case "FrmCategory":
                            rbtnCategory.Enabled = true;
                            mnuMFCategory.Enabled = true;
                            break;
                        case "FrmBrand":
                            rbtnBrand.Enabled = true;
                            mnuMFBrand.Enabled = true;
                            break;

                        case "FrmItem":
                            rbtnItem.Enabled = true;
                            mnuMFItem.Enabled = true;
                            break;
                        case "FrmSubCategory1":
                            mnuMFSubCategory.Enabled = true;
                            break;
                        case "FrmSubCategory2":
                            mnuMFSubCategory2.Enabled = true;
                            break;

                        case "FrmSalesman":
                            mnuMFSalesMan.Enabled = true;
                            break;
                        #endregion

                        #region Transaction
                        case "InventoryPaidIn":
                            mnuTrPaidInInventory.Enabled = true;
                            rbtnPaidInInventory.Enabled = true;
                            break;
                        case "InventoryPaidOut":
                            mnuTrPaidOutInventory.Enabled = true;
                            rbtnPaidOutInventory.Enabled = true;
                            break;
                        case "FrmOpeningStock":
                            rbtnOpeningStock.Enabled = true;
                            mnuTROpeningStock.Enabled = true;
                            break;
                        case "FrmPurchaseOrder":
                            rbtnPurcahseOrder.Enabled = true;
                            mnuTRPurchaseOrder.Enabled = true;
                            break;
                        case "FrmInvoice":
                            rbtnInvoice.Enabled = true;
                            mnuTRInvoice.Enabled = true;
                            mnuRptInvoiceDetails.Enabled = true;
                            break;
                        case "FrmInvoiceReturn":
                            mnuTRSalesReturn.Enabled = true;
                            break;
                        case "FrmGoodsReceivedNote":
                            rbtnGoodReceivedNote.Enabled = true;
                            mnuTRGoodsReceivedNote.Enabled = true;
                            mnuRptGRNDetails.Enabled = true;
                            break;
                        case "FrmPurchaseReturn":
                            mnuTrPurchaseReturn.Enabled = true;
                            break;
                        case "CounterOpenInventory":
                            mnuTrCounterOpenInventory.Enabled = true;
                            break;
                        case "CounterCloseInventory":
                            mnuTrCounterCloseInventory.Enabled = true;
                            break;
                        case "XReadingInventory":
                            mnuTrXReadingInventory.Enabled = true;
                            break;
                        case "OpenDrawerInventory":
                            rbtnInvOpenDrawer.Enabled = true;
                            break;
                        case "FrmSalesOrder":
                            rbtnSalesOrder.Enabled = true;
                            mnuTRSalesOrder.Enabled = true;
                            break;
                        case "FrmStockAdjustment":
                            rbtnStockAdjustment.Enabled = true;
                            mnuTRStockAdjustment.Enabled = true;
                            break;
                        case "FrmBarcode":
                            rbtnBarcodePrint.Enabled = true;
                            mnuTrBarcodePrint.Enabled = true;
                            break;

                        #endregion

                        #region Reports                           
                        case "FrmFastMoving":
                            mnuRptFastMoving.Enabled = true;
                            break;
                        case "FrmSlowMoving":
                            mnuRptSlowMoving.Enabled = true;
                            break;
                        case "FrmNonMoving":
                            mnuRptNonMoving.Enabled = true;
                            break;
                        case "FrmBinCard":
                            mnuRptStockBinCard.Enabled = true;
                            break;
                        case "FrmGivenDateStock":
                            mnuRptGivenDateStock.Enabled = true;
                            break;
                        case "FrmPurchaseSummary":
                            mnuRptPurchaseSummary.Enabled = true;
                            break;
                        case "FrmSalesSummary":
                            mnuRptSalesSummary.Enabled = true;
                            break;

                        #endregion

                        #endregion

                        #region POS

                        #region Master Files
                        case "FrmCashier":
                            rbtnCashier.Enabled = true;
                            mnuMFCashier.Enabled = true;
                            break;
                        #endregion

                        #endregion

                        #region Gift Voucher

                        #region Master Files
                        case "FrmGiftVoucherGroup":
                            rbtnGVGroup.Enabled = true;
                            mnuMFGiftVoucherGroup.Enabled = true;
                            break;

                        case "FrmGiftVoucherBook":
                            rbtnGVBook.Enabled = true;
                            mnuMFGiftVoucherBook.Enabled = true;
                            break;
                        #endregion

                        #endregion

                        #region Option

                        case "FrmUser":
                            rbtnUserMaster.Enabled = true;
                            mnuUser.Enabled = true;
                            break;

                        case "FrmSystemConfiguration":
                            mnuSystemConfiguration.Enabled = true;
                            break;

                        #endregion

                        #region Accounts

                        #region Master Files
                        case "FrmChequeBookEntry":
                            mnuMFChequeBookEntry.Enabled = true;
                            rbtnChequeBookEntry.Enabled = true;
                            break;
                        #endregion

                        #region Transaction
                        case "FrmChequePrint":
                            mnuTRChequePrint.Enabled = true;
                            rbtnChequePrint.Enabled = true;
                            break;
                        case "FrmSupplierPayment":
                            mnuTRSupplierPayment.Enabled = true;
                            break;
                        #endregion
                        #endregion

                        case "FrmTechnician":

                            break;
                        case "FrmDepartment":

                            break;

                        case "FrmVehicle":

                            break;


                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        #endregion

        private bool CheckCounterStatus()
        {
            try
            {
                CounterService counterService = new CounterService();
                CounterTransaction counterTransaction = new CounterTransaction();
                Counter counter = new Counter();
                counter = counterService.GetCounterByCounterNoAndLocationID(Common.CounterNo, Common.LoggedLocationID);
                counterTransaction = counterService.GetCounterTransactionByLocationCounterAndDateAndZno(Common.LoggedLocationID, Common.CounterNo, 1, DateTime.Now.Date, counter.Zno);
                if (counterTransaction != null)
                { return true; }
                else
                {
                    SysMessage.ShowMessage(SysMessage.MessageAction.CounterNotOpen, SysMessage.MessageType.Error, this.Text);
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
                return false;
            }
        }

        #endregion

        #region Ribbon Click
        private void rbtnPaidOutInventory_Click(object sender, EventArgs e)
        {
            mnuTrPaidOutInventory.PerformClick();
        }
        private void rbtnGoodReceivedNote_Click(object sender, EventArgs e)
        {
            mnuTRGoodsReceivedNote.PerformClick();
        }
        private void rbtnOpeningStock_Click(object sender, EventArgs e)
        {
            mnuTROpeningStock.PerformClick();
        }
        private void rbtnCustomer_Click(object sender, EventArgs e)
        {
            mnuMFCustomer.PerformClick();
        }
        private void rbtnInvoice_Click(object sender, EventArgs e)
        {
            mnuTRInvoice.PerformClick();
        }
        private void rbtnSalesOrder_Click(object sender, EventArgs e)
        {
            mnuTRSalesOrder.PerformClick();
        }
        private void rbtnStockAdjustment_Click(object sender, EventArgs e)
        {
            mnuTRStockAdjustment.PerformClick();
        }
        private void rbtnSupplier_Click(object sender, EventArgs e)
        {
            mnuMFSupplier.PerformClick();
        }

        private void rbtnCategory_Click(object sender, EventArgs e)
        {
            mnuMFCategory.PerformClick();
        }

        private void rbtnBrand_Click(object sender, EventArgs e)
        {
            mnuMFBrand.PerformClick();
        }

        private void rbtnItem_Click(object sender, EventArgs e)
        {
            mnuMFItem.PerformClick();
        }
        private void rbtnLocation_Click(object sender, EventArgs e)
        {
            mnuMFLocation.PerformClick();
        }

        private void rbtnUserMaster_Click(object sender, EventArgs e)
        {
            mnuUser.PerformClick();
        }

        private void rbtnChequeBookEntry_Click(object sender, EventArgs e)
        {
            mnuMFChequeBookEntry.PerformClick();
        }
        private void rbtnChequePrint_Click(object sender, EventArgs e)
        {
            mnuTRChequePrint.PerformClick();
        }
        #endregion

        #region Menu Click

        #region Inventory
        private void mnuTRGoodsReceivedNote_Click(object sender, EventArgs e)
        {
            FrmGoodsReceivedNote frmGoodsReceivedNote = new FrmGoodsReceivedNote();
            Common.SetForm(frmGoodsReceivedNote, this);
        }
        private void mnuTROpeningStock_Click(object sender, EventArgs e)
        {
            FrmOpeningStock frmOpeningStock = new FrmOpeningStock();
            Common.SetForm(frmOpeningStock, this);
        }
        private void mnuTrCounterOpenInventory_Click(object sender, EventArgs e)
        {
            FrmCounterTranasaction frmCounterOpenChannelling = new FrmCounterTranasaction(1, "CounterOpenInventory");
            Common.SetForm(frmCounterOpenChannelling, this);
        }

        private void mnuTrCounterCloseInventory_Click(object sender, EventArgs e)
        {
            FrmCounterTranasaction frmCounterCloseChannelling = new FrmCounterTranasaction(2, "CounterCloseInventory");
            Common.SetForm(frmCounterCloseChannelling, this);
        }

        private void mnuTrBarcodePrint_Click(object sender, EventArgs e)
        {
            FrmBarcode frmBarcode = new FrmBarcode();
            Common.SetForm(frmBarcode, this);
        }
        private void mnuTrXReadingInventory_Click(object sender, EventArgs e)
        {
            if (CheckCounterStatus())
            {
                FrmCounterTranasaction frmCounterCloseChannelling = new FrmCounterTranasaction(3, "XReadingInventory");
                Common.SetForm(frmCounterCloseChannelling, this);
            }
        }

        private void mnuTrPaidInInventory_Click(object sender, EventArgs e)
        {
            if (CheckCounterStatus())
            {
                FrmPaidInPaidOut frmPaidInPaidOut = new FrmPaidInPaidOut(1, Common.CounterNo, "InventoryPaidIn");
                Common.SetForm(frmPaidInPaidOut, this);
            }
        }

        private void mnuTrPaidOutInventory_Click(object sender, EventArgs e)
        {
            if (CheckCounterStatus())
            {
                FrmPaidInPaidOut frmPaidInPaidOut = new FrmPaidInPaidOut(2, Common.CounterNo, "InventoryPaidOut");
                Common.SetForm(frmPaidInPaidOut, this);
            }
        }

        private void rbtnPaidInInventory_Click(object sender, EventArgs e)
        {
            mnuTrPaidInInventory.PerformClick();
        }
        private void mnuTRInvoice_Click(object sender, EventArgs e)
        {
            if (CheckCounterStatus())
            {
                FrmInvoice frmInvoice = new FrmInvoice();
                Common.SetForm(frmInvoice, this);
            }
        }
        private void mnuTRSalesReturn_Click(object sender, EventArgs e)
        {
            if (CheckCounterStatus())
            {
                FrmInvoiceReturn frmInvoiceReturn = new FrmInvoiceReturn();
                Common.SetForm(frmInvoiceReturn, this);
            }
        }
        private void mnuTRSalesOrder_Click(object sender, EventArgs e)
        {
            if (CheckCounterStatus())
            {
                FrmSalesOrder frmSalesOrder = new FrmSalesOrder();
                Common.SetForm(frmSalesOrder, this);
            }
        }
        private void mnuTRStockAdjustment_Click(object sender, EventArgs e)
        {
            FrmStockAdjustment frmStockAdjustment = new FrmStockAdjustment();
            Common.SetForm(frmStockAdjustment, this);

        }
        private void mnuMFCustomer_Click(object sender, EventArgs e)
        {
            FrmCustomer frmCustomer = new FrmCustomer();
            Common.SetForm(frmCustomer, this);
        }

        private void mnuMFSupplierGroup_Click(object sender, EventArgs e)
        {
            FrmSupplierGroup frmSupplierGroup = new FrmSupplierGroup();
            Common.SetForm(frmSupplierGroup, this);
        }

        private void mnuMFCustomerGroup_Click(object sender, EventArgs e)
        {
            FrmCustomerGroup frmCustomerGroup = new FrmCustomerGroup();
            Common.SetForm(frmCustomerGroup, this);
        }
        private void mnuMFSupplier_Click(object sender, EventArgs e)
        {
            FrmSupplier frmSupplier = new FrmSupplier();
            Common.SetForm(frmSupplier, this);
        }
        private void mnuMFCategory_Click(object sender, EventArgs e)
        {
            FrmCategory frmCategory = new FrmCategory();
            Common.SetForm(frmCategory, this);
        }
        private void mnuMFBrand_Click(object sender, EventArgs e)
        {
            FrmBrand frmBrand = new FrmBrand();
            Common.SetForm(frmBrand, this);
        }
        private void mnuMFSubCategory_Click(object sender, EventArgs e)
        {
            FrmSubCategory1 frmSubCategory = new FrmSubCategory1();
            Common.SetForm(frmSubCategory, this);
        }
        private void mnuMFSubCategory2_Click(object sender, EventArgs e)
        {
            FrmSubCategory2 frmSubCategory2 = new FrmSubCategory2();
            Common.SetForm(frmSubCategory2, this);
        }
        private void mnuMFItem_Click(object sender, EventArgs e)
        {
            FrmItem frmItem = new FrmItem();
            Common.SetForm(frmItem, this);
        }
        #endregion

        #region General
        private void mnuUser_Click(object sender, EventArgs e)
        {
            FrmUser frmUser = new FrmUser();
            Common.SetForm(frmUser, this);
        }
        private void mnuMFLocation_Click(object sender, EventArgs e)
        {
            FrmLocation frmLocation = new FrmLocation();
            Common.SetForm(frmLocation, this);
        }
        private void mnuSystemConfiguration_Click(object sender, EventArgs e)
        {
            FrmSystemConfiguration frmSystemConfiguration = new FrmSystemConfiguration();
            Common.SetForm(frmSystemConfiguration, this);
        }

        #endregion

        #region Account
        private void mnuMFChequeBookEntry_Click(object sender, EventArgs e)
        {
            FrmChequeBookEntry frmChequeBookEntry = new FrmChequeBookEntry();
            Common.SetForm(frmChequeBookEntry, this);
        }
        private void mnuTRChequePrint_Click(object sender, EventArgs e)
        {
            FrmChequePrint frmChequePrint = new FrmChequePrint();
            Common.SetForm(frmChequePrint, this);
        }
        private void mnuTRSupplierPayment_Click(object sender, EventArgs e)
        {
            FrmSupplierPayment frmSupplierPayment = new FrmSupplierPayment();
            Common.SetForm(frmSupplierPayment, this);
        }

        #endregion

        #region Reports

        #region Inventory
        private void mnuRptFastMoving_Click(object sender, EventArgs e)
        {
            FrmFastMoving frmFastMoving = new FrmFastMoving();
            Common.SetForm(frmFastMoving, this);
        }
        private void mnuRptSlowMoving_Click(object sender, EventArgs e)
        {
            FrmSlowMoving frmSlowMoving = new FrmSlowMoving();
            Common.SetForm(frmSlowMoving, this);
        }
        private void mnuRptNonMoving_Click(object sender, EventArgs e)
        {
            FrmNonMoving frmNonMoving = new FrmNonMoving();
            Common.SetForm(frmNonMoving, this);
        }

        private void mnuRptStockBinCard_Click(object sender, EventArgs e)
        {
            FrmBinCard frmBinCard = new FrmBinCard();
            Common.SetForm(frmBinCard, this);
        }

        private void mnuRptGivenDateStock_Click(object sender, EventArgs e)
        {
            FrmGivenDateStock frmGivenDateStock = new FrmGivenDateStock();
            Common.SetForm(frmGivenDateStock, this);
        }

        private void mnuRptGRNDetails_Click(object sender, EventArgs e)
        {
            FormInfo formInfo = new FormInfo();
            formInfo = FormInfoService.GetFormInfoByName("FrmGoodsReceivedNote");
            InvTransaction invTransaction = new InvTransaction();
            Common.SetForm(invTransaction.SetFormFields(formInfo), this);
        }
        private void mnuRptInvoiceDetails_Click(object sender, EventArgs e)
        {
            FormInfo formInfo = new FormInfo();
            formInfo = FormInfoService.GetFormInfoByName("FrmInvoice");
            InvTransaction invTransaction = new InvTransaction();
            Common.SetForm(invTransaction.SetFormFields(formInfo), this);
        }

        #endregion

        #endregion

        #endregion

        #region Other

        private void tmDisplayCurrentTime_Tick(object sender, EventArgs e)
        {
            try
            {
                lblStatusDate.Text = "Date :: " + DateTime.Now.ToLongDateString() + "  ";
                lblStatusTime.Text = "Time :: " + DateTime.Now.ToLongTimeString() + "  ";
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }


        }

        private void MdiMain_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }



        #endregion

        private void mnuRptCounterSummary_Click(object sender, EventArgs e)
        {
            FrmCounterSummary frmCounterSummary = new FrmCounterSummary();
            Common.SetForm(frmCounterSummary, this);
        }

        private void mnuRptPurchaseSummary_Click(object sender, EventArgs e)
        {
            FrmPurchaseSummary frmPurchaseSummary = new FrmPurchaseSummary();
            Common.SetForm(frmPurchaseSummary, this);
        }

        private void mnuRptSalesSummary_Click(object sender, EventArgs e)
        {
            FrmSalesSummary frmSalesSummary = new FrmSalesSummary();
            Common.SetForm(frmSalesSummary, this);
        }

        private void mnuTRPurchaseOrder_Click(object sender, EventArgs e)
        {
            FrmPurchaseOrder frmPurchaseOrder = new FrmPurchaseOrder();
            Common.SetForm(frmPurchaseOrder, this);
        }

        private void mnuMFCashier_Click(object sender, EventArgs e)
        {
            FrmCashier frmCashier = new FrmCashier();
            Common.SetForm(frmCashier, this);
        }

        private void rbtnCashier_Click(object sender, EventArgs e)
        {
            mnuMFCashier.PerformClick();
        }

        private void rbtnBarcodePrint_Click(object sender, EventArgs e)
        {
            mnuTrBarcodePrint.PerformClick();
        }

        private void mnuRptReOrderLevel_Click(object sender, EventArgs e)
        {
            FrmReOrderLevel frmReOrderLevel = new FrmReOrderLevel();
            Common.SetForm(frmReOrderLevel, this);
        }

        private void mnuRptPaidInPaidOutDetails_Click(object sender, EventArgs e)
        {
            FrmPaidInPaidOutReport frmPaidInPaidOutReport = new FrmPaidInPaidOutReport();
            Common.SetForm(frmPaidInPaidOutReport, this);

        }

        private void mnuTrPurchaseReturn_Click(object sender, EventArgs e)
        {
            FrmPurchaseReturn frmPurchaseReturn = new FrmPurchaseReturn();
            Common.SetForm(frmPurchaseReturn, this);
        }

        private void mnuMFGiftVoucherGroup_Click(object sender, EventArgs e)
        {
            FrmGiftVoucherGroup frmGiftVoucherGroup = new FrmGiftVoucherGroup();
            Common.SetForm(frmGiftVoucherGroup, this);
        }

        private void rbtnGVGroup_Click(object sender, EventArgs e)
        {
            mnuMFGiftVoucherGroup.PerformClick();
        }

        private void mnuMFGiftVoucherBook_Click(object sender, EventArgs e)
        {

        }

        private void mnuMFSalesMan_Click(object sender, EventArgs e)
        {
            FrmSalesman frmSalesman = new FrmSalesman();
            Common.SetForm(frmSalesman, this);
        }

        private void mnuRptSalesAnalysis_Click(object sender, EventArgs e)
        {
            FrmSalesAnalysis frmSalesAnalysis = new FrmSalesAnalysis();
            Common.SetForm(frmSalesAnalysis, this);
        }
    }
}
