using NSoft.ERP.Domain.General;
using NSoft.ERP.Domain.Inventory;
using NSoft.ERP.Service.General;
using NSoft.ERP.Service.General;
using NSoft.ERP.Service.Inventory;
using NSoft.ERP.UI.Windows.General;
using NSoft.ERP.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSoft.ERP.UI.Windows.Inventory
{
    public partial class FrmSalesOrder : FrmBaseTransation
    {
        ///<summary>
        /// Developed By Navindu
        /// 2018-09-22
        /// </summary>

        private Timer timer;
        public FrmSalesOrder()
        {
            InitializeComponent();
        }

        FormInfo formInfo;
        UserPrivileges userPrivileges;
        UserService userService = new UserService();
        Customer customer;
        Item item;
        long documentID = 0;
        DataTable dtSearchItem;
        List<SalesTemp> salesTempList = new List<SalesTemp>();
        SalesTemp salesTemp;
        SalesOrderMain salesOrderMain;
        Counter counter;
        private int blinkCount = 0;
        bool isAllowMinusStock;
        string documentNo;
        bool isRecall = false;

        #region Orverride Methods

        public override void FormLoad()
        {
            try
            {
                formInfo = new FormInfo();
                formInfo = FormInfoService.GetFormInfoByName(this.Name);
                if (formInfo != null)
                {
                    this.Text = formInfo.FormText.Trim();
                    documentID = formInfo.DocumentID;
                }
                userPrivileges = new UserPrivileges();
                userPrivileges = userService.GetUserPrivilegesByUserIDAndForm(Common.LoggedUserID, formInfo);

                dgvSalesOrder.AutoGenerateColumns = false;
                dgvItemSearch.AutoGenerateColumns = false;
                dtpDocumentDate.MinDate = DateTime.Now.Date;
                Common.EnableDateTimePicker(false, dtpDocumentDate);

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

                timer = new Timer();
                timer.Interval = 1000;
                this.timer.Tick += new EventHandler(timer_Tick);

                timer.Enabled = true;

                LogWritter.WriteEventLog(this.Name, this.Text, LogWritter.EventType.Access);
                base.FormLoad();
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
                CustomerService customerService = new CustomerService();
                Common.SetAutoComplete(txtCustomerCode, customerService.GetAllActiveCustomerCodes());
                Common.SetAutoComplete(txtCustomerDescription, customerService.GetAllActiveCustomerNames());

                customer = new Customer();
                customer = customerService.GetCustomerByID(1); //Get Default
                if (customer != null)
                {
                    txtCustomerCode.Text = customer.CustomerCode.Trim();
                    txtCustomerDescription.Text = customer.CustomerName.Trim();
                }

                salesTempList = new List<SalesTemp>();
                dgvSalesOrder.DataSource = null;
                dgvSalesOrder.DataSource = salesTempList;
                dgvSalesOrder.Refresh();

                pbItem.Visible = false;
                dgvItemSearch.Visible = false;

                Common.EnableButton(false, btnSave, btnPrint);

                if (userPrivileges == null ? false : userPrivileges.IsSave) { Common.EnableButton(true, btnSave); }

                this.ActiveControl = txtItemName;
                txtItemName.Focus();

                ItemService itemService = new ItemService();
                dtSearchItem = new DataTable();
                dtSearchItem = itemService.GetAllItemsForInvoiceSearch(Common.LoggedLocationID);

                timer1.Stop();

                Common.ClearTextBox(txtWarning);

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
                if (!ValidateControles()) { return; }

                if (dgvSalesOrder.RowCount == 0)
                {
                    SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Error, this.Text, "No Data to Save.");
                    return;
                }

                Summarize();
                SaveSalesOrder(false);
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
                if (!ValidateControles()) { return; }

                if (dgvSalesOrder.RowCount == 0)
                {
                    SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Error, this.Text, "No Data to Save.");
                    return;
                }

                Summarize();
                SaveSalesOrder();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void dgvSalesOrder_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvSalesOrder.RowCount > 0)
                {
                    if (dgvSalesOrder["ItemCode", dgvSalesOrder.CurrentCell.RowIndex].Value.ToString() == string.Empty) { return; }
                    LoadItem(true, dgvSalesOrder["ItemCode", dgvSalesOrder.CurrentCell.RowIndex].Value.ToString());

                    txtSellingPrice.Text = Common.ConvertToStringCurrancy(dgvSalesOrder["SellingPrice", dgvSalesOrder.CurrentCell.RowIndex].Value.ToString());
                    txtQty.Text = Common.ConvertToStringCurrancy(dgvSalesOrder["Qty", dgvSalesOrder.CurrentCell.RowIndex].Value.ToString());
                    txtItemDis.Text = Common.ConvertToStringCurrancy(dgvSalesOrder["DiscountPercentage", dgvSalesOrder.CurrentCell.RowIndex].Value.ToString());
                    txtAmount.Text = Common.ConvertToStringCurrancy(dgvSalesOrder["Amount", dgvSalesOrder.CurrentCell.RowIndex].Value.ToString());
                    txtQty.SelectAll();
                    txtQty.Focus();

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
        private void txtQty_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                CalculateLine();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtSellingPrice_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                CalculateLine();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtItemDis_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                CalculateLine();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtItemCode.Text.Trim()))
                {
                    dgvItemSearch.Visible = true;
                    pbItem.Visible = false;
                    string query = "ItemCode LIKE '" + txtItemCode.Text.Trim().Replace("*", "").Replace("%", "") + "%'";
                    DataView dataView = new DataView();
                    dataView.Table = dtSearchItem;
                    dataView.RowFilter = query;
                    dgvItemSearch.DataSource = dataView;
                    dgvItemSearch.Refresh();
                }
                else
                { dgvItemSearch.Visible = false; }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtItemName.Text.Trim()))
                {
                    dgvItemSearch.Visible = true;
                    pbItem.Visible = false;
                    string query = "ItemName LIKE '" + txtItemName.Text.Trim().Replace("*", "").Replace("%", "") + "%'";
                    DataView dataView = new DataView();
                    dataView.Table = dtSearchItem;
                    dataView.RowFilter = query;
                    dgvItemSearch.DataSource = dataView;
                    dgvItemSearch.Refresh();
                }
                else
                { dgvItemSearch.Visible = false; }
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
        private void SaveSalesOrder(bool isPrintSalesOrder = true)
        {
            try
            {
                Summarize();

                counter = new Counter();
                CounterService counterService = new CounterService();
                counter = counterService.GetCounterByCounterNoAndLocationID(Common.CounterNo,Common.LoggedLocationID);

                salesOrderMain = new SalesOrderMain();
                salesOrderMain.DocumentDate = dtpDocumentDate.Value.Date;
                salesOrderMain.CounterID = counter.CounterID;
                salesOrderMain.LocationID = Common.LoggedLocationID;
                salesOrderMain.CustomerID = customer.CustomerID;
                salesOrderMain.ReferenceNo = txtReferenceNo.Text.Trim();

                salesOrderMain.TotalAmount = Common.ConvertStringToDecimal(txtTotalAmount.Text.Trim());
                if (txtSubTotalDis.Text != string.Empty) { salesOrderMain.DiscountPercentage = Common.ConvertStringToDecimal(txtSubTotalDis.Text.Trim()); }
                if (txtDiscountAmount.Text != string.Empty) { salesOrderMain.DiscountAmount = Common.ConvertStringToDecimal(txtDiscountAmount.Text.Trim()); }
                salesOrderMain.NetAmount = Common.ConvertStringToDecimal(txtNetAmount.Text.Trim());

                salesOrderMain.Zno = counter.Zno;
                salesOrderMain.ZDate = DateTime.Now.Date;

                salesOrderMain.OrderReferenceNo = txtSalesOrderNo.Text.Trim().ToString();

                SalesOrderService salesOrderService = new SalesOrderService();

                if (salesOrderService.Save(formInfo, salesOrderMain, salesTempList, out documentNo))
                {
                    Clear();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void UpdateGrid(SalesTemp salesTemp)
        {
            try
            {
                decimal itemDisAmount = 0;
                salesTemp.ItemID = item.ItemID;
                salesTemp.ItemCode = item.ReferenceCode1.Trim();
                salesTemp.ItemName = item.ItemName;
                salesTemp.CostPrice = item.CostPrice;
                salesTemp.SellingPrice = Common.ConvertStringToDecimal(txtSellingPrice.Text.Trim());
                salesTemp.Qty = Common.ConvertStringToDecimal(txtQty.Text.Trim());
                salesTemp.CurrentQty = Common.ConvertStringToDecimal(txtThisLocationStock.Text.Trim());
                salesTemp.DiscountPercentage = Common.ConvertStringToDecimal(txtItemDis.Text.Trim());
                salesTemp.NetAmount = Common.ConvertStringToDecimal(Common.ConvertToStringCurrancy(txtAmount.Text.Trim()));

                itemDisAmount = Common.GetDiscountAmount((salesTemp.SellingPrice * salesTemp.Qty), salesTemp.DiscountPercentage);
                salesTemp.DiscountAmount = itemDisAmount;

                SalesOrderService salesOrderService = new SalesOrderService();
                salesTempList = salesOrderService.GetUpdatedSalesTempList(salesTempList, salesTemp);
                dgvSalesOrder.DataSource = salesTempList.ToList();
                dgvSalesOrder.Refresh();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void UpdateGridForBarcode(SalesTemp salesTemp, decimal qty)
        {
            try
            {
                ItemService itemService = new ItemService();
                salesTemp.ItemID = item.ItemID;
                salesTemp.ItemCode = item.ItemCode.Trim();
                salesTemp.ItemName = item.ItemName;
                salesTemp.CostPrice = item.CostPrice;
                salesTemp.SellingPrice = item.SellingPrice;
                salesTemp.Qty = qty;
                salesTemp.CurrentQty = Math.Truncate(itemService.GetCurrentLocationStockByItemID(item.ItemID));
                salesTemp.DiscountPercentage = 0;
                salesTemp.NetAmount = (item.SellingPrice * qty);
                salesTemp.DiscountAmount = 0;

                SalesOrderService salesOrderService = new SalesOrderService();
                salesTempList = salesOrderService.GetUpdatedSalesTempList(salesTempList, salesTemp);
                dgvSalesOrder.DataSource = salesTempList.ToList();
                dgvSalesOrder.Refresh();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void CalculateLine()
        {
            try
            {
                decimal sellingPrice = 0;
                decimal qty = 0;
                decimal discountPercentage = 0;
                decimal amount = 0;

                if (!string.IsNullOrEmpty(txtSellingPrice.Text.Trim()))
                {
                    sellingPrice = Common.ConvertStringToDecimal(txtSellingPrice.Text.Trim());
                }
                if (!string.IsNullOrEmpty(txtQty.Text.Trim()))
                {
                    qty = Common.ConvertStringToDecimal(txtQty.Text.Trim());
                }
                if (!string.IsNullOrEmpty(txtItemDis.Text.Trim()))
                {
                    discountPercentage = Common.ConvertStringToDecimal(txtItemDis.Text.Trim());
                    if (discountPercentage >= 101)
                    { discountPercentage = 0; }
                }

                amount = (sellingPrice * qty) - ((sellingPrice * qty) * discountPercentage / 100);
                txtAmount.Text = Common.ConvertToStringCurrancy(amount.ToString());
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void ClearLine()
        {
            pbItem.Visible = false;
            Common.ClearTextBox(txtItemCode, txtItemName, txtSellingPrice, txtQty, txtItemDis, txtAmount, txtThisLocationStock, txtWarning);
            Common.ReadOnlyTextBox(false, txtQty);
            txtItemName.Focus();
            dgvItemSearch.Visible = false;
            timer1.Stop();
        }
        private void LoadCustomer(bool isCode, string str)
        {
            try
            {
                CustomerService customerService = new CustomerService();
                customer = new Customer();

                if (isCode)
                {
                    customer = customerService.GetCustomerByCode(str);
                }
                else
                {
                    customer = customerService.GetCustomerByName(str);
                }

                if (customer != null)
                {
                    txtCustomerCode.Text = customer.CustomerCode.Trim();
                    txtCustomerDescription.Text = customer.CustomerName.Trim();
                }
                else
                {
                    txtCustomerCode.Text = string.Empty;
                    txtCustomerDescription.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void Summarize()
        {
            try
            {
                decimal totalAmount = 0;
                decimal disAmount = 0;
                decimal disPercentage = 0;
                decimal netAmount = 0;

                totalAmount = salesTempList.Sum(x => x.NetAmount);

                txtTotalAmount.Text = Common.ConvertToStringCurrancy(totalAmount.ToString());

                if (txtSubTotalDis.Text.Trim() != string.Empty)
                {
                    disPercentage = Common.ConvertStringToDecimal(txtSubTotalDis.Text.Trim());
                    if (disPercentage >= 101)
                    {
                        disPercentage = 0;
                    }
                }

                disAmount = Common.GetDiscountAmount(totalAmount, disPercentage);
                txtDiscountAmount.Text = Common.ConvertToStringCurrancy(disAmount.ToString());

                netAmount = (totalAmount - disAmount);

                txtNetAmount.Text = Common.ConvertToStringCurrancy(netAmount.ToString());


            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private bool ValidateControles()
        {
            try
            {
                if (!Validater.ValidateTextBox(errorProvider1, Validater.ValidateType.Empty, txtCustomerCode, txtCustomerDescription))
                { return false; }

                return true;
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
                return false;
            }
        }
        private bool ValidateLineControles()
        {
            if (!Validater.ValidateTextBox(errorProvider1, Validater.ValidateType.Empty, txtItemCode, txtItemName, txtSellingPrice, txtQty, txtItemDis, txtAmount))
            { return false; }
            if (item == null || item.ItemID == 0)
            {
                return false;
            }
            if (Common.ConvertStringToDecimal(txtQty.Text.Trim()) == 0)
            {
                return false;
            }
            return true;
        }
        private void LoadItem(bool isCode, string str)
        {
            try
            {
                ItemService itemService = new ItemService();
                item = new Item();

                if (string.IsNullOrEmpty(str))
                {
                    return;
                }

                if (isCode)
                {
                    item = itemService.GetActiveItemByAllCodes(str);
                }
                else
                {
                    item = itemService.GetActiveItemByName(str);

                    if (Common.SpecialFeatures.IsBarcodeScanProcess)
                    {
                        if (item == null)
                        {
                            int strIndex = str.IndexOf('*');
                            decimal qty = 1;

                            if (strIndex == -1)
                            {
                                item = itemService.GetActiveItemByAllCodes(str);

                                if (item != null)
                                {
                                    salesTemp = new SalesTemp();
                                    UpdateGridForBarcode(salesTemp, qty);
                                    Summarize();
                                    ClearLine();
                                    return;
                                }
                            }
                            else
                            {
                                string itemBarcode = str.Substring(strIndex + 1, (str.Length - (strIndex + 1)));

                                qty = Common.ConvertStringToDecimal(str.Substring(0, strIndex));

                                item = itemService.GetActiveItemByAllCodes(itemBarcode);

                                if (item != null)
                                {
                                    salesTemp = new SalesTemp();
                                    UpdateGridForBarcode(salesTemp, qty);
                                    Summarize();
                                    ClearLine();
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (item == null)
                        {
                            item = itemService.GetActiveItemByAllCodes(str);
                        }
                    }
                }

                timer1.Stop();
                txtWarning.Text = string.Empty;

                if (item != null)
                {
                    txtItemCode.Text = item.ReferenceCode1.Trim();
                    txtItemName.Text = item.ItemName.Trim();
                    txtSellingPrice.Text = Common.ConvertToStringCurrancy(item.SellingPrice.ToString());
                    txtThisLocationStock.Text = Math.Truncate(itemService.GetCurrentLocationStockByItemID(item.ItemID)).ToString();
                    RetreveImage(item.ItemImage);
                    txtQty.Text = "1";
                    txtItemDis.Text = "0";
                    if (!item.IsCountable)
                    {
                        Common.ReadOnlyTextBox(true, txtQty);
                        txtItemDis.Focus();
                        txtItemDis.SelectAll();
                    }
                    else
                    {
                        Common.ReadOnlyTextBox(false, txtQty);
                        txtQty.Focus();
                        txtQty.SelectAll();
                    }

                    dgvItemSearch.Visible = false;

                    if (item.IsCountable)
                    {
                        if (Common.ConvertStringToLong(txtThisLocationStock.Text.Trim()) < item.ReOrderLevel)
                        {
                            blinkCount = 0;
                            timer1.Interval = 500;
                            timer1.Start();
                        }
                    }
                }
                else
                {
                    //txtItemCode.Text = string.Empty;
                    //txtItemName.Text = string.Empty;
                    //txtSellingPrice.Text = string.Empty;
                    //txtThisLocationStock.Text = string.Empty;
                    pbItem.Visible = false;
                    dgvItemSearch.Focus();
                }
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
        void timer_Tick(object sender, EventArgs e)
        {
            Counter counterOrder = new Counter();
            CounterService counterService = new CounterService();
            counterOrder = counterService.GetCounterByCounterNoAndLocationID(Common.CounterNo,Common.LoggedLocationID);

           // txtSalesOrderNo.Text = counterOrder.Salesorderno.ToString();
        }

        #endregion

        #region Keydown and Leave
        private void txtItemDis_Leave(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtItemDis.Text.Trim()))
                {
                    return;
                }
                if (Common.ConvertStringToDecimal(txtItemDis.Text.Trim()) >= 101)
                {
                    SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Information, this.Text, "Invalid Discount.");
                    txtItemDis.Focus();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void dgvSalesOrder_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (isRecall) { return; }
                    SalesOrderService salesOrderService = new SalesOrderService();

                    if (dgvSalesOrder.Rows.Count > 0)
                    {
                        if (dgvSalesOrder["ItemCode", dgvSalesOrder.CurrentCell.RowIndex].Value.ToString() == string.Empty) { return; }
                        LoadItem(true, dgvSalesOrder["ItemCode", dgvSalesOrder.CurrentCell.RowIndex].Value.ToString());
                        ClearLine();
                        if (SysMessage.ShowMessage(SysMessage.MessageAction.Delete, SysMessage.MessageType.Question, this.Text, dgvSalesOrder["ItemCode", dgvSalesOrder.CurrentCell.RowIndex].Value.ToString() + " - " + dgvSalesOrder["ItemName", dgvSalesOrder.CurrentCell.RowIndex].Value.ToString()).Equals(DialogResult.No)) { return; };
                        if (item != null)
                        {
                            salesTemp = new SalesTemp();
                            salesTemp.ItemID = item.ItemID;
                            salesTemp.SellingPrice = item.SellingPrice;
                        }

                        salesTempList = salesOrderService.GetUpdatedSalesTempListWithDelete(salesTempList, salesTemp);
                        dgvSalesOrder.DataSource = salesTempList;
                        dgvSalesOrder.Refresh();
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
        private void FrmSalesOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                txtItemCode.Focus();
                txtItemCode.SelectAll();
            }
            else if (e.KeyCode == Keys.F9)
            {
                txtItemName.Focus();
                txtItemName.SelectAll();
            }
            else if (e.KeyCode == Keys.Home)
            {
                btnClear.PerformClick();
            }
        }

        private void dgvItemSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (dgvItemSearch.Rows.Count > 0)
                    {
                        if (dgvItemSearch["SearchItemName", dgvItemSearch.CurrentCell.RowIndex].Value.ToString() == string.Empty) { return; }
                        LoadItem(false, dgvItemSearch["SearchItemName", dgvItemSearch.CurrentCell.RowIndex].Value.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void txtCustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCustomerDescription.Focus();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtCustomerDescription_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtReferenceNo.Focus();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtReferenceNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (dtpDocumentDate.Enabled)
                    {
                        dtpDocumentDate.Focus();
                    }
                    else
                    {
                        txtItemCode.Focus();
                    }

                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void dtpDocumentDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtItemCode.Focus();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtItemName.Focus();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }

        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (string.IsNullOrEmpty(txtItemName.Text.Trim()))
                    {
                        txtSubTotalDis.Focus();
                    }
                    else
                    {
                        txtSellingPrice.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtSellingPrice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtQty.Focus();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtItemDis.Focus();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtItemDis_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtAmount.Focus();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (!ValidateLineControles()) { txtItemCode.Focus(); return; }
                    salesTemp = new SalesTemp();
                    UpdateGrid(salesTemp);
                    Summarize();
                    ClearLine();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtSubTotalDis_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSave.Focus();
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
        private void txtDocumentNo_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightLable(lblDocumentNo);
        }

        private void txtCustomerCode_Leave(object sender, EventArgs e)
        {
            try
            {
                Common.UnHighlightLable(lblCustomer);
                if (txtCustomerCode.Text == string.Empty) { return; }
                LoadCustomer(true, txtCustomerCode.Text.Trim());
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtCustomerDescription_Leave(object sender, EventArgs e)
        {
            try
            {
                Common.UnHighlightLable(lblCustomer);
                if (txtCustomerDescription.Text == string.Empty) { return; }
                LoadCustomer(false, txtCustomerDescription.Text.Trim());
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtReferenceNo_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightLable(lblReferenceNo);
        }

        private void dtpDocumentDate_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightLable(lblDate);
        }

        private void txtTotalAmount_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightLable(lblTotal);
        }

        private void txtSubTotalDis_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightLable(lblDiscount);
        }

        private void txtDiscountAmount_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightLable(lblDiscount);
        }

        private void txtNetAmount_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightLable(lblNetTotal);
        }
        private void txtDocumentNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCustomerCode.Focus();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void txtItemCode_Leave(object sender, EventArgs e)
        {
            try
            {
                LoadItem(true, txtItemCode.Text.Trim());
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtItemName_Leave(object sender, EventArgs e)
        {
            try
            {
                LoadItem(false, txtItemName.Text.Trim());
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void txtQty_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!isAllowMinusStock)
                {
                    if (string.IsNullOrEmpty(txtQty.Text)) { return; }

                    if (Common.ConvertStringToDecimal(txtQty.Text.Trim()) > Common.ConvertStringToDecimal(txtThisLocationStock.Text.Trim()))
                    {
                        SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Information, this.Text, "Insufficient Stock.");
                        txtQty.Focus();
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

        #region Enter

        private void txtDocumentNo_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblDocumentNo);
        }

        private void txtReferenceNo_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblReferenceNo);
        }

        private void dtpDocumentDate_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblDate);
        }

        private void txtTotalAmount_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblTotal);
        }

        private void txtDiscountAmount_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblDiscount);
        }

        private void txtSubTotalDis_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblDiscount);
        }

        private void txtNetAmount_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblNetTotal);
        }

        private void txtCustomerCode_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblCustomer);
        }

        private void txtCustomerDescription_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblCustomer);
        }


        #endregion

        private bool ValidateSellingPrice()
        {
            if (item != null)
            {
                if (Common.ConvertStringToDecimal(txtSellingPrice.Text.Trim()) > item.MaximumPrice || Common.ConvertStringToDecimal(txtSellingPrice.Text.Trim()) < item.MinimumPrice)
                {
                    txtSellingPrice.Text = Common.ConvertToStringCurrancy(item.SellingPrice.ToString());
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        private void txtSellingPrice_Leave(object sender, EventArgs e)
        {
            if (!ValidateSellingPrice())
            {
                SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Information, this.Text, "Invalid Price.");
                txtSellingPrice.Focus();
                return;
            }
        }
    }
}
