using NSoft.ERP.Domain.CRM;
using NSoft.ERP.Domain.General;
using NSoft.ERP.Domain.Inventory;
using NSoft.ERP.Service.General;
using NSoft.ERP.Service.Inventory;
using NSoft.ERP.UI.Windows.Device;
using NSoft.ERP.UI.Windows.General;
using NSoft.ERP.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSoft.ERP.UI.Windows.Inventory
{
    public partial class FrmInvoice : FrmBaseTransation
    {
        ///<summary>
        /// Developed By Navindu
        /// 2017-10-22
        /// </summary>
        public FrmInvoice()
        {
            InitializeComponent();

        }

        FormInfo formInfo;
        UserPrivileges userPrivileges;
        UserService userService = new UserService();
        Item item;
        long documentID = 0;
        DataTable dtSearchItem;
        List<SalesTemp> salesTempList = new List<SalesTemp>();
        SalesTemp salesTemp;
        SalesMain salesMain;
        Counter counter;
        private int blinkCount = 0;
        bool isAllowMinusStock;
        string documentNo, salesHoldNo;
        bool isRecall = false;

        bool isRecallSalesHold = false;
        LoyaltyCustomer loyaltyCustomer = null;
        Salesman salesman = null;
        int keyboardLayer = 0;

        #region Orverride Methods

        private void GetCompanyDetails()
        {
            try
            {
                GroupOfCompanyService groupOfCompanyService = new GroupOfCompanyService();
                GroupOfCompany groupOfCompany = new GroupOfCompany();
                groupOfCompany = groupOfCompanyService.GetActiveGroupOfCompany();
                if (groupOfCompany != null)
                {
                    Common.GroupOfCompanyID = groupOfCompany.GroupOfCompanyID;
                    Common.CompanyName = groupOfCompany.GroupOfCompanyName;
                    Common.Address1 = groupOfCompany.Address1.Trim();
                    Common.Address2 = groupOfCompany.Address2.Trim();
                    Common.SetModule(groupOfCompany.GroupOfCompanyID);
                    Common.SetSpecialFeatures(groupOfCompany.GroupOfCompanyID);
                }
            }
            catch (Exception ex)
            {

                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.ConnectionFaild, SysMessage.MessageType.Error, this.Text, "Please contact System Administrator for more details.");
                //Application.Exit();
                this.Hide();
                FrmConnection connection = new FrmConnection();
                connection.ShowDialog();
            }
        }
        public override void FormLoad()
        {
            try
            {
                if (!Common.IsShowDeveloperLogo)
                {
                    pbDeveloperLogo.Visible = false;
                }

                dgvInvoice.AutoGenerateColumns = false;

                formInfo = new FormInfo();
                formInfo = FormInfoService.GetFormInfoByName(this.Name);
                if (formInfo != null)
                {
                    this.Text = formInfo.FormText.Trim();
                    documentID = formInfo.DocumentID;
                }

                GetCompanyDetails();

                CounterService counterService = new CounterService();
                counter = counterService.GetCounterByCounterNoAndLocationID(Common.CounterNo, Common.LoggedLocationID);

                if (counter != null)
                {

                    CustomerDisplay.isDisplayConnected = counter.IsDisplayConnected;
                    DualDisplay.IsDualDisplay = counter.IsDualDisplay;
                    POSPrinter.printerName = counter.PrinterName;

                    POSPrinter.header1 = counter.Header1.Trim();
                    POSPrinter.header2 = counter.Header2.Trim();
                    POSPrinter.header3 = counter.Header3.Trim();
                    POSPrinter.header4 = counter.Header4.Trim();
                    POSPrinter.header5 = counter.Header5.Trim();

                    POSPrinter.tail1 = counter.Tail1.Trim();
                    POSPrinter.tail2 = counter.Tail2.Trim();
                    POSPrinter.tail3 = counter.Tail3.Trim();
                    POSPrinter.tail4 = counter.Tail4.Trim();
                    POSPrinter.tail5 = counter.Tail5.Trim();

                    POSPrinter.printerWidth = counter.PrinterWidth;
                    POSPrinter.marginX = counter.MarginX;
                    POSPrinter.dashWidth = counter.DashWidth;

                    if (CustomerDisplay.isDisplayConnected)
                    {
                        CustomerDisplay.displayComPort = counter.DisplayComPort.Trim();
                        CustomerDisplay.DisplayText(CustomerDisplay.eClear);
                        CustomerDisplay.DisplayText(CustomerDisplay.eBlinkOn);
                        CustomerDisplay.DisplayText(CustomerDisplay.displayCounterClosed, CustomerDisplay.DisplayAlignment.Center);
                        CustomerDisplay.DisplayText(Common.CompanyName, CustomerDisplay.DisplayAlignment.Center);

                        CustomerDisplay.displayText1 = counter.DisplayText1.Trim();
                        CustomerDisplay.displayText2 = counter.DisplayText2.Trim();
                    }

                    if (DualDisplay.IsDualDisplay)
                    {
                        if (Screen.AllScreens.Length > 1)
                        {
                            Screen screen = DualDisplay.GetSecondaryScreen();
                            if (screen != null)
                            {
                                DualDisplay.VideoPath = counter.VideoPath.Trim();

                                DualDisplay.ShowDualDisplay(screen);
                                DualDisplay.ShowCounterClose();
                            }
                        }
                    }

                }


                lblLocation.Text = string.Empty;
                lblCounter.Text = counter.CounterName.Trim();
                lblCompany.Text = Common.CompanyName.Trim();
                lblUser.Text = string.Empty;

                if (File.Exists(Common.binPath + "/Images/Print.png"))
                {
                    btnPrint.Image = Image.FromFile(Common.binPath + "/Images/Print.png");
                }

                SystemConfiguration systemConfiguration = new SystemConfiguration();
                systemConfiguration = CommonService.GetSystemConfiguration();
                if (systemConfiguration != null)
                {
                    isAllowMinusStock = systemConfiguration.IsAllowMinusStock;
                }

                groupBox1.Visible = false;
                groupBox2.Visible = false;

                timer2.Enabled = true;

                //DisableKeys();

                dgvInvoice.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 9.75f);
                dgvInvoice.DefaultCellStyle.Font = new Font("Verdana", 9.75f);

                Location location = new Location();
                LocationService locationService = new LocationService();

                location = locationService.GetLocationByID(Common.LoggedLocationID);

                if (location != null)
                {
                    Common.LoggedLocation = location.LocationName.Trim();
                    lblLocation.Text = Common.LoggedLocation;
                }

                if (File.Exists(Common.binPath + "//CompanyImage1.jpg"))
                {
                    pbImage1.Image = Image.FromFile(Common.binPath + "//CompanyImage1.jpg");
                }
                else
                {
                    pbImage1.Image = null;
                }

                if (File.Exists(Common.binPath + "//CompanyImage2.jpg"))
                {
                    pbImage2.Image = Image.FromFile(Common.binPath + "//CompanyImage2.jpg");
                }
                else
                {
                    pbImage2.Image = null;
                }

                if (File.Exists(Common.binPath + "//CompanyImage3.jpg"))
                {
                    pbImage3.Image = Image.FromFile(Common.binPath + "//CompanyImage3.jpg");
                }
                else
                {
                    pbImage3.Image = null;
                }

                LogWritter.WriteEventLog(this.Name, this.Text, LogWritter.EventType.Access);

                base.FormLoad();

            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void RefreshGrid()
        {
            try
            {
                if (salesTemp != null)
                {
                    SummarizeSub();
                }

                SalesService salesService = new SalesService();
                salesTempList = new List<SalesTemp>();

                salesTempList = salesService.GetSalesTempByDocumentNoAndLocationAndCounter(lblInvoiceNo.Text.Trim(), Common.LoggedLocationID, Common.CounterNo);

                dgvInvoice.DataSource = null;
                dgvInvoice.DataSource = salesTempList;
                dgvInvoice.Refresh();

                if (dgvInvoice.RowCount > 0)
                {
                    dgvInvoice.ClearSelection();
                    dgvInvoice.Rows[dgvInvoice.RowCount - 1].Selected = true;
                    dgvInvoice.FirstDisplayedScrollingRowIndex = dgvInvoice.RowCount - 1;

                    if (salesTemp == null)
                    {
                        salesTemp = salesTempList.Last();
                    }
                }

                if (!string.IsNullOrEmpty(salesTempList.Select(h => h.HoldDocumentNo).FirstOrDefault()))
                {
                    isRecallSalesHold = true;
                    salesHoldNo = salesTempList.Select(h => h.HoldDocumentNo).FirstOrDefault();
                }

                Summarize();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        public override void Initialize()
        {
            try
            {
                GetPOSInvoiceNo();
                GetPOSBillCount();

                salesTemp = null;

                pbItem.Visible = false;
                salesHoldNo = string.Empty;

                this.ActiveControl = txtCommon;
                txtCommon.Focus();

                ItemService itemServiceSearch = new ItemService();
                dtSearchItem = new DataTable();
                dtSearchItem = itemServiceSearch.GetAllItemsForInvoiceSearch(Common.LoggedLocationID);

                timer1.Stop();

                Common.ClearTextBox(txtWarning);

                lblTotal.Text = Common.ConvertToStringCurrancy("0");
                lblNoOfItems.Text = Common.ConvertToStringCurrancy("0");
                lblNoOfPieces.Text = Common.ConvertToStringCurrancy("0");

                isRecallSalesHold = false;
                documentID = 1000;
                lblTransactionMode.Text = "Sales";

                loyaltyCustomer = null;
                salesman = null;
                lblLoyaltyCustomer.Text = string.Empty;
                lblLoyaltyCustomer.Visible = false;
                lblSalesman.Text = string.Empty;
                lblSalesman.Visible = false;

                lblThisLocationStock.Text = string.Empty;

                keyboardLayer = 2;
                ChangeKeyboardLayer();

                RefreshGrid();
                ClearLine();

                if (!Common.IsLogin)
                {
                    FrmPOSLogin frmPOSLogin = new FrmPOSLogin();
                    frmPOSLogin.Focus();
                    this.Focus();
                    frmPOSLogin.ShowDialog();
                }
                else
                {

                    if (CustomerDisplay.isDisplayConnected)
                    {
                        CustomerDisplay.DisplayText(CustomerDisplay.eClear);
                        CustomerDisplay.DisplayText(CustomerDisplay.eBlinkOn);
                        CustomerDisplay.DisplayText(CustomerDisplay.displayText1.Trim(), CustomerDisplay.DisplayAlignment.Center);
                        CustomerDisplay.DisplayText(CustomerDisplay.displayText2.Trim(), CustomerDisplay.DisplayAlignment.Center);
                    }

                    if (DualDisplay.IsDualDisplay)
                    {
                        DualDisplay.ShowNextCustomer();
                    }
                }

                lblUser.Text = Common.LoggedUserName.Trim();


                // GetUserPrivileges(Common.LoggedUserName.Trim());

                CounterService counterService = new CounterService();
                CounterTransaction counterTransaction = new CounterTransaction();
                counterTransaction = counterService.GetCounterTransactionByLocationCounterAndDateAndZno(Common.LoggedLocationID, Common.CounterNo, 1, DateTime.Now.Date, counter.Zno);
                if (counterTransaction == null)
                {
                    FrmPOSCounterTransaction frmPOSCounterTransaction = new FrmPOSCounterTransaction(1);
                    frmPOSCounterTransaction.ShowDialog();

                    int transactionStatus = frmPOSCounterTransaction.transactionStatus;

                    switch (transactionStatus)
                    {
                        case 1:
                            Common.IsLogin = false;
                            Initialize();
                            break;

                        default:
                            break;
                    }

                }

                base.Initialize();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        public override void Save()
        {
            try
            {
                if (dgvInvoice.RowCount == 0)
                {
                    SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Error, this.Text, "No Data to Save.");
                    return;
                }

                base.Save();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        #endregion

        #region Other
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {

                if (dgvInvoice.RowCount == 0)
                {
                    SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Error, this.Text, "No Data to Save.");
                    return;
                }

                Summarize();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void dgvInvoice_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvInvoice.RowCount > 0)
                {
                    if (dgvInvoice["ItemCode", dgvInvoice.CurrentCell.RowIndex].Value.ToString() == string.Empty) { return; }

                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void txtSubTotalDis_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                Summarize();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtPaidAmount_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                Summarize();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }


        private void txtCommon_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCommon.Text.Trim()))
                {
                    pbItem.Visible = false;
                    string query = "ItemCode LIKE '" + txtCommon.Text.Trim().Replace("*", "").Replace("%", "") + "%'";
                    DataView dataView = new DataView();
                    dataView.Table = dtSearchItem;
                    dataView.RowFilter = query;

                }

            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            txtWarning.BackColor = SystemColors.Control;
            if (txtWarning.ForeColor == Color.Red)
                txtWarning.ForeColor = SystemColors.Control;
            else
                txtWarning.ForeColor = Color.Red;

            blinkCount++;
            txtWarning.Text = "++++++++++ Reorder This Item Immediately ++++++++++";

            //if (m_nBlinkCount >= 10)
            //    timer1.Stop();
        }

        #endregion

        #region Private Methods 

        private void UpdateGridForBarcode(SalesTemp salesTemp, decimal qty)
        {
            try
            {
                ItemService itemService = new ItemService();
                salesTemp.ItemID = item.ItemID;
                salesTemp.ItemCode = item.ItemCode.Trim();
                salesTemp.ItemName = item.ItemName;


                //Check Multi Price

                List<ItemPrice> itemPriceList = new List<ItemPrice>();
                itemPriceList = itemService.GetItemPriceListByItemID(item.ItemID);

                if (itemPriceList.Count > 0)
                {
                    itemPriceList.Add(new ItemPrice { CostPrice = item.CostPrice, SellingPrice = item.SellingPrice });
                    FrmPriceList frmPriceList = new FrmPriceList(itemPriceList);
                    frmPriceList.ShowDialog();

                    if (frmPriceList.isPriceSelected)
                    {
                        salesTemp.CostPrice = Common.ConvertStringToDecimal(Common.ConvertToStringCurrancy(frmPriceList.selectedCostPrice.ToString()));
                        salesTemp.SellingPrice = Common.ConvertStringToDecimal(Common.ConvertToStringCurrancy(frmPriceList.selectedPrice.ToString()));
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    salesTemp.CostPrice = Common.ConvertStringToDecimal(Common.ConvertToStringCurrancy(item.CostPrice.ToString()));
                    salesTemp.SellingPrice = Common.ConvertStringToDecimal(Common.ConvertToStringCurrancy(item.SellingPrice.ToString()));
                }

                if (item.FixedDiscount > 0)
                {
                    salesTemp.DiscountAmount = (item.FixedDiscount * qty);
                    salesTemp.FixedDiscount = item.FixedDiscount;
                }
                else
                {
                    salesTemp.DiscountAmount = 0;
                    salesTemp.FixedDiscount = 0;
                }

                if (item.FixedDiscountPercentage > 0)
                {
                    salesTemp.DiscountPercentage = Common.ConvertStringToDecimal(item.FixedDiscountPercentage.ToString());
                    salesTemp.FixedDiscount = item.FixedDiscountPercentage;
                }

                salesTemp.Qty = Common.ConvertStringToDecimal(Common.ConvertToStringQty(qty.ToString()));
                salesTemp.CurrentQty = Math.Truncate(itemService.GetCurrentLocationStockByItemID(item.ItemID));


                SalesService salesService = new SalesService();
                salesService.UpdateSalesTemp(salesTemp, salesTempList);
                RefreshGrid();


            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void ClearLine()
        {
            Common.ClearTextBox(txtCommon);
            txtCommon.Focus();
        }

        private void Summarize()
        {
            try
            {
                decimal totalAmount = 0;
                decimal disAmount = 0;
                decimal disPercentage = 0;
                decimal netAmount = 0;
                decimal serviceChargeAmount = 0;
                decimal noOfItems = 0;
                decimal noOfPieces = 0;

                totalAmount = salesTempList.Sum(x => x.NetAmount);
                noOfItems = salesTempList.GroupBy(g => g.ItemID).Count();
                noOfPieces = salesTempList.Sum(g => g.Qty);

                lblTotal.Text = String.Format("{0:n}", Math.Round(Common.ConvertStringToDecimal(totalAmount.ToString()), 2));
                lblNoOfItems.Text = Common.ConvertStringToDecimal(noOfItems.ToString()).ToString();
                lblNoOfPieces.Text = noOfPieces.ToString();

                disAmount = Common.GetDiscountAmount(totalAmount, disPercentage);

                netAmount = (totalAmount - disAmount) + serviceChargeAmount;

                if (DualDisplay.IsDualDisplay)
                {
                    DualDisplay.ShowLine2("Total", lblTotal.Text);
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void SummarizeSub()
        {
            try
            {
                SalesService salesService = new SalesService();
                salesService.GetUpdatedGridValueTempList(salesTemp);

                if (dgvInvoice.Rows.Count > 1)
                {
                    dgvInvoice.ClearSelection();
                    dgvInvoice.FirstDisplayedScrollingRowIndex = dgvInvoice.Rows.Count - 1;
                    dgvInvoice.Rows[dgvInvoice.Rows.Count - 1].Selected = true;
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private bool ValidateLineControles()
        {
            if (!Validater.ValidateTextBox(errorProvider1, Validater.ValidateType.Empty, txtCommon))
            { return false; }
            if (item == null || item.ItemID == 0)
            {
                return false;
            }
            return true;
        }
        private void LoadItem(string str)
        {
            try
            {
                timer1.Stop();

                ItemService itemService = new ItemService();
                item = new Item();

                if (string.IsNullOrEmpty(str))
                {
                    return;
                }

                int strIndex = str.IndexOf('*');
                decimal qty = 1;

                if (strIndex == -1)
                {
                    item = itemService.GetActiveItemByAllCodes(str);

                    if (item != null)
                    {
                        salesTemp = new SalesTemp();

                        salesTemp.DocumentNo = lblInvoiceNo.Text.Trim();
                        salesTemp.LocationID = counter.LocationID;
                        salesTemp.CounterNo = counter.CounterNo;

                        UpdateGridForBarcode(salesTemp, qty);

                        lblThisLocationStock.Text = itemService.GetCurrentLocationStockByItemID(item.ItemID).ToString();

                        RetreveImage(item.ItemImage);

                        if (item.IsCountable)
                        {
                            if (Common.ConvertStringToDecimal(lblThisLocationStock.Text.Trim()) < item.ReOrderLevel)
                            {
                                blinkCount = 0;
                                timer1.Interval = 500;
                                timer1.Start();
                            }
                        }

                        if (DualDisplay.IsDualDisplay)
                        {
                            DualDisplay.ShowLine1(item.NameOnInvoice.Trim(), Common.ConvertToStringCurrancy(salesTemp.SellingPrice.ToString()));
                        }


                        if (CustomerDisplay.isDisplayConnected)
                        {
                            CustomerDisplay.DisplayText(CustomerDisplay.eClear);
                            CustomerDisplay.DisplayText(CustomerDisplay.eBlinkOff);

                            string tempSpace;
                            string sellingPrice = Common.ConvertToStringCurrancy(salesTemp.SellingPrice.ToString());

                            int nameLength = item.NameOnInvoice.Trim().Length;
                            int priceLength = sellingPrice.Length;

                            int displayDifference = CustomerDisplay.displayLength - priceLength;

                            if (nameLength > displayDifference)
                            {
                                string itemName = item.NameOnInvoice.Trim().Substring(0, (CustomerDisplay.displayLength - sellingPrice.Length - 1));
                                tempSpace = new string(' ', CustomerDisplay.displayLength - (sellingPrice.Length + itemName.Length));

                                CustomerDisplay.DisplayText(itemName + tempSpace + sellingPrice, CustomerDisplay.DisplayAlignment.Left);
                            }
                            else
                            {
                                string itemName = item.NameOnInvoice.Trim();
                                tempSpace = new string(' ', CustomerDisplay.displayLength - (sellingPrice.Length + itemName.Length));

                                CustomerDisplay.DisplayText(itemName + tempSpace + sellingPrice, CustomerDisplay.DisplayAlignment.Left);
                            }

                            string subtotalAmount = Common.ConvertToStringCurrancy(lblTotal.Text.Trim());
                            string totalheader = "SUB TOTAL";
                            tempSpace = new string(' ', CustomerDisplay.displayLength - (subtotalAmount.Length + totalheader.Length));

                            CustomerDisplay.DisplayText(totalheader + tempSpace + subtotalAmount, CustomerDisplay.DisplayAlignment.Left);

                        }

                        ClearLine();

                        return;
                    }
                    else
                    {

                        string description = @"There is a problem with the Item Code.
check that the barcode is damage or whether itemcode 
was created from office.";
                        FrmDisplayMessage frmDisplayMessage = new FrmDisplayMessage("Item Code '" + txtCommon.Text.Trim() + "' Not Found.", description.Trim());

                        txtCommon.Text = string.Empty;


                        frmDisplayMessage.ShowDialog();
                    }
                }
                else
                {
                    string itemBarcode = str.Substring(strIndex + 1, (str.Length - (strIndex + 1)));

                    if (Common.CheckIsNumeric(str.Substring(0, strIndex)))
                    {
                        qty = Common.ConvertStringToDecimal(str.Substring(0, strIndex));
                    }
                    else
                    {
                        ClearLine();
                        return;
                    }

                    item = itemService.GetActiveItemByAllCodes(itemBarcode);

                    if (item != null)
                    {
                        salesTemp = new SalesTemp();

                        salesTemp.DocumentNo = lblInvoiceNo.Text.Trim();
                        salesTemp.LocationID = counter.LocationID;
                        salesTemp.CounterNo = counter.CounterNo;

                        UpdateGridForBarcode(salesTemp, qty);

                        lblThisLocationStock.Text = Math.Truncate(itemService.GetCurrentLocationStockByItemID(item.ItemID)).ToString();
                        RetreveImage(item.ItemImage);

                        if (item.IsCountable)
                        {
                            if (Common.ConvertStringToLong(lblThisLocationStock.Text.Trim()) < item.ReOrderLevel)
                            {
                                blinkCount = 0;
                                timer1.Interval = 500;
                                timer1.Start();
                            }
                        }


                        if (DualDisplay.IsDualDisplay)
                        {
                            DualDisplay.ShowLine1(item.NameOnInvoice.Trim(), Common.ConvertToStringCurrancy(salesTemp.SellingPrice.ToString()));
                        }

                        if (CustomerDisplay.isDisplayConnected)
                        {
                            CustomerDisplay.DisplayText(CustomerDisplay.eClear);
                            CustomerDisplay.DisplayText(CustomerDisplay.eBlinkOff);

                            string tempSpace;
                            string sellingPrice = Common.ConvertToStringCurrancy(salesTemp.SellingPrice.ToString());
                            int nameLength = item.NameOnInvoice.Trim().Length;
                            int priceLength = sellingPrice.Length;

                            int displayDifference = CustomerDisplay.displayLength - priceLength;

                            if (nameLength > displayDifference)
                            {
                                string itemName = item.NameOnInvoice.Trim().Substring(0, (CustomerDisplay.displayLength - sellingPrice.Length - 1));
                                tempSpace = new string(' ', CustomerDisplay.displayLength - (sellingPrice.Length + itemName.Length));

                                CustomerDisplay.DisplayText(itemName + tempSpace + sellingPrice, CustomerDisplay.DisplayAlignment.Left);
                            }
                            else
                            {
                                string itemName = item.NameOnInvoice.Trim();
                                tempSpace = new string(' ', CustomerDisplay.displayLength - (sellingPrice.Length + itemName.Length));

                                CustomerDisplay.DisplayText(itemName + tempSpace + sellingPrice, CustomerDisplay.DisplayAlignment.Left);
                            }

                            string subtotalAmount = Common.ConvertToStringCurrancy(lblTotal.Text.Trim());
                            string totalheader = "SUB TOTAL";
                            tempSpace = new string(' ', CustomerDisplay.displayLength - (subtotalAmount.Length + totalheader.Length));

                            CustomerDisplay.DisplayText(totalheader + tempSpace + subtotalAmount, CustomerDisplay.DisplayAlignment.Left);
                        }

                        ClearLine();
                        return;
                    }
                    else
                    {
                        txtCommon.Text = string.Empty;
                    }
                }

                timer1.Stop();
                txtWarning.Text = string.Empty;
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void RetreveImage(byte[] pic)
        {
            try
            {
                if (pic.Length > 0)
                {
                    Stream stream = new MemoryStream(pic);
                    Image returnImage = Image.FromStream(stream);
                    pbItem.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbItem.Image = returnImage;
                    pbItem.Visible = true;
                }
                else
                {
                    pbItem.Image = null;
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }

        #endregion

        #region Keydown and Leave
        private void dgvInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (isRecall) { return; }
                    SalesService salesService = new SalesService();

                    if (dgvInvoice.Rows.Count > 0)
                    {
                        if (dgvInvoice["ItemCode", dgvInvoice.CurrentCell.RowIndex].Value.ToString() == string.Empty) { return; }
                        LoadItem(dgvInvoice["ItemCode", dgvInvoice.CurrentCell.RowIndex].Value.ToString());
                        ClearLine();
                        if (SysMessage.ShowMessage(SysMessage.MessageAction.Delete, SysMessage.MessageType.Question, this.Text, dgvInvoice["ItemCode", dgvInvoice.CurrentCell.RowIndex].Value.ToString() + " - " + dgvInvoice["ItemName", dgvInvoice.CurrentCell.RowIndex].Value.ToString()).Equals(DialogResult.No)) { return; };
                        if (item != null)
                        {
                            salesTemp = new SalesTemp();
                            salesTemp.ItemID = item.ItemID;
                            salesTemp.SellingPrice = item.SellingPrice;
                        }

                        salesTempList = salesService.GetUpdatedSalesTempListWithDelete(salesTempList, salesTemp);
                        dgvInvoice.DataSource = salesTempList;
                        dgvInvoice.Refresh();
                        Summarize();


                    }
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void FrmInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btnF1.PerformClick();
            }
            else if (e.KeyCode == Keys.F2)
            {
                btnF2.PerformClick();
            }
            else if (e.KeyCode == Keys.F3)
            {
                btnF3.PerformClick();
            }
            else if (e.KeyCode == Keys.F4)
            {
                btnF4.PerformClick();
            }
            else if (e.KeyCode == Keys.F5)
            {
                btnF5.PerformClick();
            }
            else if (e.KeyCode == Keys.F6)
            {
                btnF6.PerformClick();
            }
            else if (e.KeyCode == Keys.F7)
            {
                btnF7.PerformClick();
            }
            else if (e.KeyCode == Keys.F8)
            {
                btnF8.PerformClick();
            }
            else if (e.KeyCode == Keys.F9)
            {
                btnF9.PerformClick();
            }
            else if (e.KeyCode == Keys.F10)
            {
                btnF10.PerformClick();
            }
            else if (e.KeyCode == Keys.F11)
            {
                btnF11.PerformClick();
            }
            else if (e.KeyCode == Keys.F12)
            {
                btnF12.PerformClick();
            }
            else if (e.KeyCode == Keys.Add)
            {
                btnPlus.PerformClick();
            }
            else if (e.KeyCode == Keys.Delete)
            {

            }
            else if (e.KeyCode == Keys.PageUp)
            {
                btnPgUp.PerformClick();
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                btnPgDn.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Common.LoggedUserID = 0;
                Common.IsLogin = false;
                lblUser.Text = string.Empty;

                if (CustomerDisplay.isDisplayConnected)
                {
                    CustomerDisplay.DisplayText(CustomerDisplay.eClear);
                    CustomerDisplay.DisplayText(CustomerDisplay.eBlinkOn);
                    CustomerDisplay.DisplayText(CustomerDisplay.displayCounterClosed, CustomerDisplay.DisplayAlignment.Center);
                    CustomerDisplay.DisplayText(Common.CompanyName, CustomerDisplay.DisplayAlignment.Center);
                }

                if (DualDisplay.IsDualDisplay)
                {
                    DualDisplay.ShowCounterClose();
                }

                Initialize();
            }
        }

        private void txtItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCommon.Focus();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }

        private void txtCommon_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtCommon.Text.StartsWith("H"))
                    {

                        isRecallSalesHold = false;
                        salesHoldNo = string.Empty;

                        RecallHoldSale(txtCommon.Text.Trim());
                        return;
                    }
                    LoadItem(txtCommon.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtPaidAmount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnPrint.Focus();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }



        private void txtTotalAmount_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightLable(lblTotal);
        }
        private void txtCommon_Leave(object sender, EventArgs e)
        {

        }

        #endregion

        #region Enter

        private void txtTotalAmount_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblTotal);
        }

        private bool CheckCashierPrivileges(string functionName)
        {
            try
            {
                bool isValid = false;

                CashierService cashierService = new CashierService();
                isValid = cashierService.GetCashierPrivilegesByFunctionNameAndCashierID(functionName, Common.LoggedUserID);

                if (!isValid)
                {
                    FrmAccessDenied frmAccessDenied = new FrmAccessDenied();
                    frmAccessDenied.ShowDialog();
                }

                return isValid;
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
                return false;
            }
        }

        private decimal CheckCashierPrivilegesValue(string functionName)
        {
            try
            {
                decimal maxValue = 0;

                CashierService cashierService = new CashierService();
                maxValue = cashierService.GetCashierPrivilegesValueByFunctionNameAndCashierID(functionName, Common.LoggedUserID);

                return maxValue;
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
                return 0;
            }
        }
        private void btnF1_Click(object sender, EventArgs e)
        {
            try
            {
                if (keyboardLayer == 1)
                {

                    if (!CheckCashierPrivileges("Search"))
                    {
                        return;
                    }

                    string searchText = string.Empty;
                    string qty = "1";

                    if (txtCommon.Text.Contains('*'))
                    {
                        int index = txtCommon.Text.IndexOf('*');

                        if (Common.CheckIsNumeric(txtCommon.Text.Substring(0, index)))
                        {
                            searchText = txtCommon.Text.Trim().Substring(index + 1, (txtCommon.Text.Trim().Length - 1) - txtCommon.Text.Trim().Substring(0, index).Length);
                            qty = txtCommon.Text.Trim().Substring(0, index);
                        }
                    }
                    else
                    {
                        searchText = txtCommon.Text.Trim();
                    }


                    FrmItemSearch frmItemSearch = new FrmItemSearch(dtSearchItem, searchText);
                    frmItemSearch.ShowDialog();
                    txtCommon.Text = qty + "*" + frmItemSearch.itemCode;

                    if (frmItemSearch.isItemSelected)
                    {
                        LoadItem(txtCommon.Text.Trim());
                    }
                    ClearLine();
                }
                else if (keyboardLayer == 2)
                {


                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnF7_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckCashierPrivileges("Cancel"))
                {
                    return;
                }

                SalesService salesService = new SalesService();
                salesService.CancelInvoice(salesTemp);
                Clear();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void btnF2_Click(object sender, EventArgs e)
        {
            try
            {

                if (!CheckCashierPrivileges("Menu"))
                {
                    return;
                }

                if (dgvInvoice.Rows.Count > 0)
                {
                    SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Information, this.Text, "Plese Close The Current Bill.");
                    return;
                }

                FrmMenu frmItemSearch = new FrmMenu();
                frmItemSearch.ShowDialog();

                if (frmItemSearch.menuCode == "005")
                {
                    documentID = 1001;
                    lblTransactionMode.Text = "Sales Return";
                    loyaltyCustomer = null;
                    lblLoyaltyCustomer.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void btnF3_Click(object sender, EventArgs e)
        {
            try
            {


                if (!CheckCashierPrivileges("Qty"))
                {
                    return;
                }

                if (salesTemp != null)
                {
                    if (Common.CheckIsNumeric(txtCommon.Text.Trim()))
                    {
                        salesTemp.Qty = Common.ConvertStringToDecimal(Common.ConvertToStringQty(txtCommon.Text.Trim()));
                    }
                    else
                    {
                        FrmQty frmQty = new FrmQty();
                        frmQty.ShowDialog();
                        salesTemp.Qty = frmQty.qty;
                    }

                    if (salesTemp.Qty == 0)
                    {
                        return;
                    }

                    SalesService salesService = new SalesService();
                    salesService.UpdateQty(salesTemp);

                    RefreshGrid();
                    ClearLine();

                    if (CustomerDisplay.isDisplayConnected)
                    {
                        string tempSpace;
                        string sellingPrice = Common.ConvertToStringCurrancy(salesTemp.SellingPrice.ToString());
                        string itemName = item.NameOnInvoice.Trim().Substring(0, (CustomerDisplay.displayLength - sellingPrice.Length - 1));
                        tempSpace = new string(' ', CustomerDisplay.displayLength - (sellingPrice.Length + itemName.Length));

                        CustomerDisplay.DisplayText(itemName + tempSpace + sellingPrice, CustomerDisplay.DisplayAlignment.Left);

                        string subtotalAmount = Common.ConvertToStringCurrancy(lblTotal.Text.Trim());
                        string totalheader = "SUB TOTAL";
                        tempSpace = new string(' ', CustomerDisplay.displayLength - (subtotalAmount.Length + totalheader.Length));

                        CustomerDisplay.DisplayText(totalheader + tempSpace + subtotalAmount, CustomerDisplay.DisplayAlignment.Left);

                    }
                }
                else
                {
                    string description = @"There is a problem with the item selection.
check that the barcode is enter in the grid.";
                    FrmDisplayMessage frmDisplayMessage = new FrmDisplayMessage("Item Not Found.", description.Trim());

                    txtCommon.Text = string.Empty;


                    frmDisplayMessage.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void btnF4_Click(object sender, EventArgs e)
        {

            if (!CheckCashierPrivileges("Drawer"))
            {
                return;
            }

            POSPrinter.PrintText(POSPrinter.eInitialize + POSPrinter.eDrawer);
        }

        private void btnF5_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckCashierPrivileges("Item Discount Percentage"))
                {
                    return;
                }

                SalesService salesService = new SalesService();

                if (salesTemp != null)
                {
                    if (Common.CheckIsNumeric(txtCommon.Text.Trim()))
                    {
                        if (Common.ConvertStringToDecimal(txtCommon.Text.Trim()) <= 100)
                        {
                            salesTemp.DiscountAmount = Common.ConvertStringToDecimal(Common.ConvertToStringCurrancy("0"));
                            salesTemp.DiscountPercentage = Common.ConvertStringToDecimal(Common.ConvertToStringCurrancy(txtCommon.Text.Trim()));

                            decimal maxValue = 0;

                            maxValue = CheckCashierPrivilegesValue("Item Discount Percentage");

                            if (salesTemp.DiscountPercentage > maxValue)
                            {
                                FrmLimitExceed frmLimitExceed = new FrmLimitExceed("Discount");
                                frmLimitExceed.ShowDialog();
                                return;
                            }

                        }
                    }
                    else
                    {
                        FrmDiscount frmDiscount = new FrmDiscount(1, salesTemp.TotalAmount,1);
                        frmDiscount.ShowDialog();
                        salesTemp.DiscountAmount = Common.ConvertStringToDecimal(Common.ConvertToStringCurrancy("0"));
                        salesTemp.DiscountPercentage = Common.ConvertStringToDecimal(Common.ConvertToStringCurrancy(frmDiscount.discountPercentage.ToString()));
                    }


                    RefreshGrid();

                    if (CustomerDisplay.isDisplayConnected)
                    {
                        string tempSpace;
                        string discountAmount = Common.ConvertToStringCurrancy(salesTemp.DiscountPercentage.ToString());
                        string discountheader = "DISCOUNT %";
                        tempSpace = new string(' ', CustomerDisplay.displayLength - (discountAmount.Length + discountheader.Length));

                        CustomerDisplay.DisplayText(discountheader + tempSpace + discountAmount, CustomerDisplay.DisplayAlignment.Left);

                        string subtotalAmount = Common.ConvertToStringCurrancy(lblTotal.Text.Trim());
                        string totalheader = "SUB TOTAL";
                        tempSpace = new string(' ', CustomerDisplay.displayLength - (subtotalAmount.Length + totalheader.Length));

                        CustomerDisplay.DisplayText(totalheader + tempSpace + subtotalAmount, CustomerDisplay.DisplayAlignment.Left);

                    }

                    ClearLine();
                }
                else
                {
                    string description = @"There is a problem with the item selection.
check that the barcode is enter in the grid.";
                    FrmDisplayMessage frmDisplayMessage = new FrmDisplayMessage("Item Not Found.", description.Trim());

                    txtCommon.Text = string.Empty;


                    frmDisplayMessage.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void btnF6_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckCashierPrivileges("Item Discount Amount"))
                {
                    return;
                }

                SalesService salesService = new SalesService();

                if (salesTemp != null)
                {
                    if (Common.CheckIsNumeric(txtCommon.Text.Trim()))
                    {
                        if (Common.ConvertStringToDecimal(txtCommon.Text.Trim()) <= salesTemp.NetAmount)
                        {
                            salesTemp.DiscountAmount = Common.ConvertStringToDecimal(Common.ConvertToStringCurrancy(txtCommon.Text.Trim()));
                            salesTemp.DiscountPercentage = Common.ConvertStringToDecimal(Common.ConvertToStringCurrancy("0"));


                            decimal maxValue = 0;

                            maxValue = CheckCashierPrivilegesValue("Item Discount Amount");

                            if (salesTemp.DiscountAmount > maxValue)
                            {
                                FrmLimitExceed frmLimitExceed = new FrmLimitExceed("Discount");
                                frmLimitExceed.ShowDialog();
                                return;
                            }

                            RefreshGrid();

                            if (CustomerDisplay.isDisplayConnected)
                            {
                                string tempSpace;
                                string discountAmount = Common.ConvertToStringCurrancy(salesTemp.DiscountAmount.ToString());
                                string discountheader = "DISCOUNT";
                                tempSpace = new string(' ', CustomerDisplay.displayLength - (discountAmount.Length + discountheader.Length));

                                CustomerDisplay.DisplayText(discountheader + tempSpace + discountAmount, CustomerDisplay.DisplayAlignment.Left);

                                string subtotalAmount = Common.ConvertToStringCurrancy(lblTotal.Text.Trim());
                                string totalheader = "SUB TOTAL";
                                tempSpace = new string(' ', CustomerDisplay.displayLength - (subtotalAmount.Length + totalheader.Length));

                                CustomerDisplay.DisplayText(totalheader + tempSpace + subtotalAmount, CustomerDisplay.DisplayAlignment.Left);

                            }
                        }
                        ClearLine();
                    }
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void btnF8_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckCashierPrivileges("Void"))
                {
                    return;
                }

                if (dgvInvoice.Rows.Count > 0)
                {
                    SalesTemp salesTempVoid = new SalesTemp();
                    salesTempVoid.LocationID = counter.LocationID;
                    salesTempVoid.CounterNo = counter.CounterNo;
                    salesTempVoid.DocumentNo = lblInvoiceNo.Text.Trim();

                    FrmVoid frmVoid = new FrmVoid(salesTempList, salesTempVoid);
                    frmVoid.ShowDialog();

                    this.salesTempList = frmVoid.salesTempList.ToList();
                    dgvInvoice.DataSource = salesTempList;
                    dgvInvoice.Refresh();

                    Summarize();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void dgvItemSearch_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnF11_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckCashierPrivileges("Price"))
                {
                    return;
                }

                if (salesTemp != null)
                {
                    if (Common.CheckIsNumeric(txtCommon.Text.Trim()))
                    {
                        salesTemp.NewSellingPrice = Common.ConvertStringToDecimal(Common.ConvertToStringCurrancy(txtCommon.Text.Trim()));
                        SalesService salesService = new SalesService();
                        salesService.UpdatePrice(salesTemp);

                        salesTemp.SellingPrice = Common.ConvertStringToDecimal(Common.ConvertToStringCurrancy(txtCommon.Text.Trim()));
                        RefreshGrid();
                        ClearLine();

                        if (CustomerDisplay.isDisplayConnected)
                        {
                            string tempSpace;
                            string sellingPrice = Common.ConvertToStringCurrancy(salesTemp.SellingPrice.ToString());
                            string itemName = item.NameOnInvoice.Trim().Substring(0, (CustomerDisplay.displayLength - sellingPrice.Length - 1));
                            tempSpace = new string(' ', CustomerDisplay.displayLength - (sellingPrice.Length + itemName.Length));

                            CustomerDisplay.DisplayText(itemName + tempSpace + sellingPrice, CustomerDisplay.DisplayAlignment.Left);

                            string subtotalAmount = Common.ConvertToStringCurrancy(lblTotal.Text.Trim());
                            string totalheader = "SUB TOTAL";
                            tempSpace = new string(' ', CustomerDisplay.displayLength - (subtotalAmount.Length + totalheader.Length));

                            CustomerDisplay.DisplayText(totalheader + tempSpace + subtotalAmount, CustomerDisplay.DisplayAlignment.Left);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void btnF9_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckCashierPrivileges("Hold"))
                {
                    return;
                }

                if (dgvInvoice.RowCount == 0)
                {
                    SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Error, this.Text, "No Data to Save.");
                    return;
                }

                Summarize();

                string printerStaus = "";
                bool isPrinterAvailable = POSPrinter.CheckPrinterAvailability(out printerStaus);

                if (isPrinterAvailable)
                {
                    SalesService salesService = new SalesService();
                    if (salesService.SaveSalesHold(salesTempList, counter, out documentNo))
                    {
                        PrintSalesHold();
                        Clear();
                    }
                }
                else
                {
                    FrmNoPrinter frmNoPrinter = new FrmNoPrinter(printerStaus);
                    frmNoPrinter.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            txtCommon.Focus();
            lblDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy h:mm:ss");
        }

        #endregion

        private void chkIsServiceCharge_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Summarize();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void FrmInvoice_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (CustomerDisplay.isDisplayConnected)
                {
                    CustomerDisplay.DisplayText(CustomerDisplay.eClear);
                }

                Application.Exit();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void pd_PrintSalesHold(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            float startX = 10;
            float startY = 20;
            float marginX = 0;

            Font fontNormal = new Font("POSNormal", 9.5f, FontStyle.Bold);
            Font fontNormalSinhala = new Font("POSNormal", 7.5f, FontStyle.Bold);
            Font fontDoubleHeight = new Font("POSDouble", 9.5f, FontStyle.Bold);

            float lineHeightNormal = fontNormal.GetHeight();
            float lineHeightDoubleHeight = fontDoubleHeight.GetHeight() + 2;

            Brush brush = Brushes.Black;

            float pageWidth = 0;
            float textWidth = 0;
            float printWidth = 0;

            if (counter != null)
            {
                pageWidth = POSPrinter.printerWidth;
                marginX = POSPrinter.marginX;
                printWidth = pageWidth - (marginX * 2);


                if (counter.IsPrintLogo)
                {
                    Image img = Image.FromFile(counter.LogoPath.Trim());
                    e.Graphics.DrawImage(img, (pageWidth - 250) / 2, startY, 250, 100);
                    startY += 100;
                }

                if (counter.Header1 != string.Empty)
                {
                    textWidth = e.Graphics.MeasureString(counter.Header1.Trim(), fontDoubleHeight).Width;
                    startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                    graphics.DrawString(counter.Header1.Trim(), fontDoubleHeight, brush, startX, startY);
                    startY += lineHeightDoubleHeight;
                }

                if (counter.Header2 != string.Empty)
                {
                    textWidth = e.Graphics.MeasureString(counter.Header2.Trim(), fontNormal).Width;
                    startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                    graphics.DrawString(counter.Header2.Trim(), fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;
                }

                if (counter.Header3 != string.Empty)
                {
                    textWidth = e.Graphics.MeasureString(counter.Header3.Trim(), fontNormal).Width;
                    startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                    graphics.DrawString(counter.Header3.Trim(), fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;
                }

                if (counter.Header4 != string.Empty)
                {
                    textWidth = e.Graphics.MeasureString(counter.Header4.Trim(), fontNormal).Width;
                    startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                    graphics.DrawString(counter.Header4.Trim(), fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;
                }

                if (counter.Header5 != string.Empty)
                {
                    textWidth = (int)e.Graphics.MeasureString(counter.Header5.Trim(), fontNormal).Width;
                    startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                    graphics.DrawString(counter.Header5.Trim(), fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;
                }
            }

            string dashLine = new string('-', (int)counter.DashWidth);

            textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
            startX = (pageWidth - (marginX * 2) - textWidth) / 2;
            graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
            startY += lineHeightNormal;

            string header = "Sales Hold";

            textWidth = e.Graphics.MeasureString(header, fontDoubleHeight).Width;
            startX = (pageWidth - (marginX * 2) - textWidth) / 2;
            graphics.DrawString(header, fontDoubleHeight, brush, startX, startY);
            startY += lineHeightDoubleHeight;

            textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
            startX = (pageWidth - (marginX * 2) - textWidth) / 2;
            graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
            startY += lineHeightNormal;

            startX = marginX;
            graphics.DrawString("Date :" + DateTime.Now.Date.ToString("dd-MMM-yyyy"), fontNormal, brush, startX, startY);
            startY += lineHeightNormal;

            graphics.DrawString("Location : " + Common.LoggedLocation.Trim(), fontNormal, brush, startX, startY);
            startY += lineHeightNormal;

            graphics.DrawString("Unit : " + counter.CounterCode.Trim(), fontNormal, brush, startX, startY);
            startY += lineHeightNormal;

            graphics.DrawString("Staff : " + Common.LoggedUserName.Trim(), fontNormal, brush, startX, startY);
            startY += lineHeightNormal;

            textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
            startX = (pageWidth - (marginX * 2) - textWidth) / 2;
            graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
            startY += lineHeightNormal;

            SalesService salesService = new SalesService();
            List<SalesHold> salesHoldList = new List<SalesHold>();

            salesHoldList = salesService.GetAllSalesHoldDocumentNo(documentNo, Common.LoggedLocationID, counter);

            if (salesHoldList != null && salesHoldList.Count > 0)
            {
                startX = marginX;
                string productDetailTailLeft = "Amount";
                string productDetailTailRight = Common.ConvertToStringCurrancy(salesHoldList.Sum(s => s.Amount).ToString());

                graphics.DrawString(productDetailTailLeft, fontDoubleHeight, brush, startX, startY);

                textWidth = e.Graphics.MeasureString(productDetailTailRight, fontDoubleHeight).Width;
                startX = pageWidth - (marginX * 2) - textWidth;
                graphics.DrawString(productDetailTailRight, fontDoubleHeight, brush, startX, startY);
                startY += lineHeightDoubleHeight;

                int barcodeWidth = 250;
                int barcodeHeight = 30;

                startY += 10;

                Image barcode = BarcodeLib.Barcode.DoEncode(BarcodeLib.TYPE.CODE128, documentNo);

                startX = (pageWidth - (marginX * 2) - barcodeWidth) / 2;
                // startX = (pageWidth - barcodeWidth) / 2;
                e.Graphics.DrawImage(barcode, startX, startY, barcodeWidth, barcodeHeight);
                startY += barcodeHeight;

                textWidth = e.Graphics.MeasureString(documentNo, fontNormal).Width;
                startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                graphics.DrawString(documentNo, fontNormal, brush, startX, startY);
                startY += lineHeightNormal;
            }

            textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
            startX = (pageWidth - (marginX * 2) - textWidth) / 2;
            graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
            startY += lineHeightNormal;

            textWidth = e.Graphics.MeasureString("System By NSoft", fontNormal).Width;
            startX = (pageWidth - (marginX * 2) - textWidth) / 2;
            graphics.DrawString("System By NSoft", fontNormal, brush, startX, startY);
            startY += lineHeightNormal;

        }
        public void PrintSalesHold()
        {
            PrintDocument printSalesHold = new PrintDocument();
            printSalesHold.PrinterSettings.PrinterName = POSPrinter.printerName;

            printSalesHold.PrintPage += new PrintPageEventHandler(pd_PrintSalesHold);

            PrintController printController = new StandardPrintController();
            printSalesHold.PrintController = printController;

            printSalesHold.Print();
        }

        public void RecallHoldSale(string documentNo)
        {
            try
            {
                SalesService salesService = new SalesService();
                salesService.GetPendingSalesHoldByDocumentNoAndLocationAndCounter(documentNo, Common.LoggedLocationID, Common.CounterNo, lblInvoiceNo.Text.Trim());
                RefreshGrid();
                Common.ClearTextBox(txtCommon);
                salesHoldNo = salesTempList.Select(d => d.HoldDocumentNo == null ? string.Empty : d.HoldDocumentNo).FirstOrDefault();
                isRecallSalesHold = true;
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        public void GetUserPrivileges(string username)
        {
            try
            {
                UserService userService = new UserService();
                var privileges = userService.GetAllPOSAccessPrivilegesByUserName(username);

                Common.EnableButton(true, btnF12);

                foreach (var item in privileges)
                {
                    switch (item.FormName)
                    {
                        case "POSSalesHold":
                            Common.EnableButton(true, btnF9);
                            break;
                        case "POSSearch":
                            Common.EnableButton(true, btnF1);
                            break;
                        case "POSMenu":
                            Common.EnableButton(true, btnF2);
                            break;
                        case "POSQty":
                            Common.EnableButton(true, btnF3);
                            break;
                        case "POSDrawer":
                            Common.EnableButton(true, btnF4);
                            break;
                        case "POSItemDiscountPercentage":
                            Common.EnableButton(true, btnF5);
                            break;
                        case "POSItemDiscountAmount":
                            Common.EnableButton(true, btnF6);
                            break;
                        case "POSClear":
                            Common.EnableButton(true, btnF7);
                            break;
                        case "POSPayment":
                            Common.EnableButton(true, btnF8);
                            break;
                        case "POSReCopy":
                            Common.EnableButton(true, btnF10);
                            break;
                        case "POSPrice":
                            Common.EnableButton(true, btnF11);
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

        private void btnF10_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckCashierPrivileges("Copy"))
                {
                    return;
                }

                if (dgvInvoice.Rows.Count > 0)
                {
                    SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Information, this.Text, "Plese Close The Current Bill.");
                    return;
                }

                FrmRePrint frmRePrint = new FrmRePrint();
                frmRePrint.ShowDialog();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void btnF12_Click(object sender, EventArgs e)
        {
            try
            {
                /*  if (documentID != 1000)
                  {
                      SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Information, this.Text, "Please Change Transaction Mode to Sales.");
                      return;
                  }

                  FrmPOSMore frmPOSMore = new FrmPOSMore();
                  frmPOSMore.ShowDialog();
                  loyaltyCustomer = frmPOSMore.loyaltyCustomer;
                  if (loyaltyCustomer != null)
                  {
                      lblLoyaltyCustomer.Text = loyaltyCustomer.LoyaltyCustomerName.Trim();
                  }
                  */

                if (!CheckCashierPrivileges("More"))
                {
                    return;
                }

                ChangeKeyboardLayer();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void ChangeKeyboardLayer()
        {
            if (keyboardLayer == 1)
            {
                keyboardLayer = 2;
                lblKeyboardLayer.Text = "Layer 2";
            }
            else
            {
                keyboardLayer = 1;
                lblKeyboardLayer.Text = "Layer 1";
            }

            btnPgUp.BackgroundImage = Properties.Resources.l1pgup;
            btnPgDn.BackgroundImage = Properties.Resources.l1pgdn;
            btnEnter.BackgroundImage = Properties.Resources.l1Enter;
            btnPlus.BackgroundImage = Properties.Resources.l1plus;

            foreach (Control ctrl in grpFunctionButton1.Controls)
            {
                if (ctrl is Button)
                {
                    ctrl.Text = string.Empty;

                    if (keyboardLayer == 2)
                    {
                        if (ctrl.Name == "btnF1")
                        {
                            btnF1.BackgroundImage = Properties.Resources.l2F1;
                            //ctrl.Text = "Loyalty\r\n\r\nF1";
                        }
                        else if (ctrl.Name == "btnF2")
                        {
                            btnF2.BackgroundImage = Properties.Resources.l2F2;
                            //ctrl.Text = "GV\r\n\r\nF2";
                        }
                        else if (ctrl.Name == "btnF3")
                        {
                            btnF3.BackgroundImage = Properties.Resources.l2F3;
                            //ctrl.Text = "\r\n\r\nF3";
                        }
                        else if (ctrl.Name == "btnF4")
                        {
                            btnF4.BackgroundImage = null;
                            //ctrl.Text = "\r\n\r\nF4";
                        }
                        if (ctrl.Name == "btnF5")
                        {
                            btnF5.BackgroundImage = null;
                            //ctrl.Text = "\r\n\r\nF5";
                        }
                        else if (ctrl.Name == "btnF6")
                        {
                            btnF6.BackgroundImage = null;
                            //ctrl.Text = "\r\n\r\nF6";
                        }
                        else if (ctrl.Name == "btnF7")
                        {
                            btnF7.BackgroundImage = null;
                            //ctrl.Text = "\r\n\r\nF7";
                        }
                        else if (ctrl.Name == "btnF8")
                        {
                            btnF8.BackgroundImage = null;
                            //ctrl.Text = "\r\n\r\nF8";
                        }
                        else if (ctrl.Name == "btnF9")
                        {
                            btnF9.BackgroundImage = null;
                            //ctrl.Text = "\r\n\r\nF8";
                        }
                        else if (ctrl.Name == "btnF10")
                        {
                            btnF10.BackgroundImage = null;
                            //ctrl.Text = "\r\n\r\nF8";
                        }
                        else if (ctrl.Name == "btnF11")
                        {
                            btnF11.BackgroundImage = null;
                            //ctrl.Text = "\r\n\r\nF8";
                        }
                        else if (ctrl.Name == "btnF12")
                        {
                            btnF12.BackgroundImage = null;
                            //ctrl.Text = "\r\n\r\nF8";
                        }
                    }
                    else if (keyboardLayer == 1)
                    {
                        if (ctrl.Name == "btnF1")
                        {
                            ctrl.BackgroundImage = Properties.Resources.l1F1;
                            //ctrl.Text = "Search\r\n\r\nF1";
                        }
                        else if (ctrl.Name == "btnF2")
                        {
                            ctrl.BackgroundImage = Properties.Resources.l1F2;
                            //ctrl.Text = "Menu\r\n\r\nF2";
                        }
                        else if (ctrl.Name == "btnF3")
                        {
                            ctrl.BackgroundImage = Properties.Resources.l1F3;
                            //ctrl.Text = "Qty\r\n\r\nF3";
                        }
                        else if (ctrl.Name == "btnF4")
                        {
                            ctrl.BackgroundImage = Properties.Resources.l1F4;
                            //ctrl.Text = "Drawer\r\n\r\nF4";
                        }
                        if (ctrl.Name == "btnF5")
                        {
                            ctrl.BackgroundImage = Properties.Resources.l1F5;
                            //ctrl.Text = "Dis %\r\n\r\nF5";
                        }
                        else if (ctrl.Name == "btnF6")
                        {
                            ctrl.BackgroundImage = Properties.Resources.l1F6;
                            //ctrl.Text = "Disc\r\n\r\nF6";
                        }
                        else if (ctrl.Name == "btnF7")
                        {
                            ctrl.BackgroundImage = Properties.Resources.l1F7;
                            //ctrl.Text = "Clear\r\n\r\nF7";
                        }
                        else if (ctrl.Name == "btnF8")
                        {
                            ctrl.BackgroundImage = Properties.Resources.l1F8;
                            //ctrl.Text = "Payment\r\n\r\nF8";
                        }
                        else if (ctrl.Name == "btnF9")
                        {
                            ctrl.BackgroundImage = Properties.Resources.l1F9;
                            //ctrl.Text = "Payment\r\n\r\nF8";
                        }
                        else if (ctrl.Name == "btnF10")
                        {
                            ctrl.BackgroundImage = Properties.Resources.l1F10;
                            //ctrl.Text = "Payment\r\n\r\nF8";
                        }
                        else if (ctrl.Name == "btnF11")
                        {
                            ctrl.BackgroundImage = Properties.Resources.l1F11;
                            //ctrl.Text = "Payment\r\n\r\nF8";
                        }
                        else if (ctrl.Name == "btnF12")
                        {
                            ctrl.BackgroundImage = Properties.Resources.l1F12;
                            //ctrl.Text = "Payment\r\n\r\nF8";
                        }
                    }
                }

            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (dgvInvoice.RowCount == 0)
            {
                SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Error, this.Text, "No Data to Save.");
                return;
            }

            Summarize();

            salesMain = new SalesMain();
            salesMain.DocumentDate = DateTime.Now.Date;
            salesMain.DocumentID = documentID;
            salesMain.CounterNo = counter.CounterNo;
            salesMain.LocationID = Common.LoggedLocationID;
            salesMain.CustomerID = 1; //Default Customer

            salesMain.TotalAmount = Common.ConvertStringToDecimal(lblTotal.Text.Trim());
            salesMain.NoOfPieces = Common.ConvertStringToDecimal(lblNoOfPieces.Text.Trim());
            salesMain.NoOfQty = Common.ConvertStringToDecimal(lblNoOfItems.Text.Trim());

            salesMain.Zno = counter.Zno;
            salesMain.ZDate = DateTime.Now.Date;

            salesMain.IsRecallSalesHold = isRecallSalesHold;
            salesMain.SalesHoldNo = salesHoldNo;


            if (counter.IsSalesmanPopupOnSubtotal)
            {

                FrmPOSSalesman frmPOSSalesman = new FrmPOSSalesman();
                frmPOSSalesman.ShowDialog();
                if (!frmPOSSalesman.isItemSelected)
                {
                    return;
                }
                else
                {
                    SalesmanService salesmanService = new SalesmanService();
                    salesman = salesmanService.GetActiveSalesmanByCode(frmPOSSalesman.salesmanCode.Trim());

                    if (salesman != null)
                    {
                        lblSalesman.Text = salesman.SalesmanCode.Trim() + " - " + salesman.SalesmanName.Trim();
                        lblSalesman.Visible = true;
                    }
                    else
                    {
                        lblSalesman.Text = string.Empty;
                        lblSalesman.Visible = false;
                    }
                }
            }


            FrmPayment frmPayment = new FrmPayment(lblTotal.Text.Trim(), formInfo, salesMain, salesTempList, counter, loyaltyCustomer, salesman);
            frmPayment.ShowDialog();
            txtCommon.Text = string.Empty;

            if (frmPayment.isPaymentComplete)
            {
                Clear();
            }


        }

        private void btnPgUp_Click(object sender, EventArgs e)
        {
            try
            {

                if (!CheckCashierPrivileges("Loyalty"))
                {
                    return;
                }


                FrmPOSLoyaltyCustomer frmPOSLoyaltyCustomer = new FrmPOSLoyaltyCustomer();
                frmPOSLoyaltyCustomer.ShowDialog();
                loyaltyCustomer = frmPOSLoyaltyCustomer.loyaltyCustomer;

                if (loyaltyCustomer != null)
                {
                    lblLoyaltyCustomer.Text = "L/C : " + loyaltyCustomer.LoyaltyCustomerName.Trim();
                    lblLoyaltyCustomer.Visible = true;
                }
                else
                {
                    lblLoyaltyCustomer.Text = string.Empty;
                    lblLoyaltyCustomer.Visible = false;
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void DisableKeys()
        {
            Common.EnableButton(false, btnF1, btnF2, btnF3, btnF4, btnF5, btnF6, btnF7, btnF8, btnF9, btnF10, btnF11, btnF12);
        }

        private void pbItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmShowImage frmShowImage = new FrmShowImage(pbItem.Image);
                frmShowImage.ShowDialog();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                KeyEventArgs enterkey = new KeyEventArgs(Keys.Enter);

                txtCommon_KeyDown(null, enterkey);
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void GetPOSInvoiceNo()
        {
            lblInvoiceNo.Text = CommonService.GenaratePOSInvoiceNo(counter);
        }

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            FrmPOSKeyboard frmPOSKeyboard = new FrmPOSKeyboard();
            frmPOSKeyboard.ShowDialog();

            if (frmPOSKeyboard.isPressEnter)
            {
                txtCommon.Text = frmPOSKeyboard.txtKeyboardText.Text;
            }
        }

        private void btnPgDn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckCashierPrivileges("Salesman"))
                {
                    return;
                }

                FrmPOSSalesman frmPOSSalesman = new FrmPOSSalesman();
                frmPOSSalesman.ShowDialog();

                SalesmanService salesmanService = new SalesmanService();
                salesman = salesmanService.GetActiveSalesmanByCode(frmPOSSalesman.salesmanCode.Trim());

                if (salesman != null)
                {
                    lblSalesman.Text = salesman.SalesmanCode.Trim() + " - " + salesman.SalesmanName.Trim();
                    lblSalesman.Visible = true;
                }
                else
                {
                    lblSalesman.Text = string.Empty;
                    lblSalesman.Visible = false;
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void GetPOSBillCount()
        {
            SalesService salesService = new SalesService();
            string billCount;
            billCount = salesService.GetNoOfBillOnCounter(counter).ToString().PadLeft(3, '0');

            lblBillCount.Text = billCount;
        }
    }
}
