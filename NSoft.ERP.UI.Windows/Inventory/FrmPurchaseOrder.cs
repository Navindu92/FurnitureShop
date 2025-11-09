using NSoft.ERP.Domain.General;
using NSoft.ERP.Domain.Inventory;
using NSoft.ERP.Reports.Forms.General;
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
using NSoft.ERP.Reports.Reports.Inventory.Transaction;
using NSoft.ERP.Reports.Reports.Inventory;

namespace NSoft.ERP.UI.Windows.Inventory
{
    public partial class FrmPurchaseOrder : FrmBaseTransation
    {
        ///<summary>
        /// Developed By Navindu
        /// 2017-10-22
        /// </summary>
        public FrmPurchaseOrder()
        {
            InitializeComponent();
        }

        FormInfo formInfo;
        UserPrivileges userPrivileges;
        UserService userService = new UserService();
        Supplier supplier;
        Item item;
        long documentID = 0;
        DataTable dtSearchItem;
        List<PurchaseTemp> purchaseTempList = new List<PurchaseTemp>();
        PurchaseTemp purchaseTemp;
        PurchaseOrderMain purchaseOrderMain;
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

                dgvPurchaseOrder.AutoGenerateColumns = false;
                dgvItemSearch.AutoGenerateColumns = false;
                dtpDocumentDate.MinDate = DateTime.Now.Date;
                Common.EnableDateTimePicker(false, dtpDocumentDate);

                if (userPrivileges != null && userPrivileges.IsSave) { Common.EnableButton(true, btnSave); } else { Common.EnableButton(false, btnSave); }

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
                SupplierService supplierService = new SupplierService();
                Common.SetAutoComplete(txtSupplierCode, supplierService.GetAllActiveSupplierCodes());
                Common.SetAutoComplete(txtSupplierDescription, supplierService.GetAllActiveSupplierNames());

                ItemService itemService = new ItemService();
                Common.SetAutoCompleteWithoutAppend(txtItemCode, itemService.GetAllActiveCountableItemCodes());
                Common.SetAutoCompleteWithoutAppend(txtItemName, itemService.GetAllActiveCountableItemNames());

                purchaseTempList = new List<PurchaseTemp>();
                dgvPurchaseOrder.DataSource = null;
                dgvPurchaseOrder.DataSource = purchaseTempList;
                dgvPurchaseOrder.Refresh();

                pbItem.Visible = false;
                dgvItemSearch.Visible = false;


                dtSearchItem = new DataTable();
                dtSearchItem = itemService.GetAllCountableItemsForInvoiceSearch(Common.LoggedLocationID);

                this.ActiveControl = txtSupplierCode;
                txtSupplierCode.Focus();


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

                if (dgvPurchaseOrder.RowCount == 0)
                {
                    SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Error, this.Text, "No Data to Save.");
                    return;
                }

                Summarize();
                SavePurchaseOrder(false);
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

                if (dgvPurchaseOrder.RowCount == 0)
                {
                    SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Error, this.Text, "No Data to Save.");
                    return;
                }

                Summarize();
                SavePurchaseOrder();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void dgvPurchaseOrder_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvPurchaseOrder.RowCount > 0)
                {
                    if (dgvPurchaseOrder["ItemCode", dgvPurchaseOrder.CurrentCell.RowIndex].Value.ToString() == string.Empty) { return; }
                    LoadItem(true, dgvPurchaseOrder["ItemCode", dgvPurchaseOrder.CurrentCell.RowIndex].Value.ToString());

                    txtCostPrice.Text = Common.ConvertToStringCurrancy(dgvPurchaseOrder["CostPrice", dgvPurchaseOrder.CurrentCell.RowIndex].Value.ToString());
                    txtSellingPrice.Text = Common.ConvertToStringCurrancy(dgvPurchaseOrder["SellingPrice", dgvPurchaseOrder.CurrentCell.RowIndex].Value.ToString());
                    txtMargin.Text = Common.ConvertToStringCurrancy(dgvPurchaseOrder["Margin", dgvPurchaseOrder.CurrentCell.RowIndex].Value.ToString());
                    txtQty.Text = Common.ConvertToStringCurrancy(dgvPurchaseOrder["Qty", dgvPurchaseOrder.CurrentCell.RowIndex].Value.ToString());
                    txtFreeQty.Text = Common.ConvertToStringCurrancy(dgvPurchaseOrder["FreeQty", dgvPurchaseOrder.CurrentCell.RowIndex].Value.ToString());
                    txtItemDis.Text = Common.ConvertToStringCurrancy(dgvPurchaseOrder["DiscountPercentage", dgvPurchaseOrder.CurrentCell.RowIndex].Value.ToString());
                    txtAmount.Text = Common.ConvertToStringCurrancy(dgvPurchaseOrder["Amount", dgvPurchaseOrder.CurrentCell.RowIndex].Value.ToString());
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
                CalculateMarginPercentage();
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
                    string query = "ItemCode LIKE " + "'%" + txtItemCode.Text.Trim().Replace("*", "").Replace("%", "") + "%'";
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
                    string query = "ItemName LIKE " + "'%" + txtItemName.Text.Trim().Replace("*", "").Replace("%", "") + "%'";
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
        private void SavePurchaseOrder(bool isPrintPurchaseOrder = true)
        {
            try
            {
                Summarize();

                purchaseOrderMain = new PurchaseOrderMain();
                purchaseOrderMain.DocumentDate = dtpDocumentDate.Value.Date;
                purchaseOrderMain.LocationID = Common.LoggedLocationID;
                purchaseOrderMain.SupplierID = supplier.SupplierID;
                purchaseOrderMain.ReferenceNo = txtReferenceNo.Text.Trim();

                purchaseOrderMain.TotalAmount = Common.ConvertStringToDecimal(txtTotalAmount.Text.Trim());
                if (txtSubTotalDis.Text != string.Empty) { purchaseOrderMain.DiscountPercentage = Common.ConvertStringToDecimal(txtSubTotalDis.Text.Trim()); }
                if (txtDiscountAmount.Text != string.Empty) { purchaseOrderMain.DiscountAmount = Common.ConvertStringToDecimal(txtDiscountAmount.Text.Trim()); }
                purchaseOrderMain.NetAmount = Common.ConvertStringToDecimal(txtNetAmount.Text.Trim());


                PurchaseOrderService purchaseOrderService = new PurchaseOrderService();

                if (purchaseOrderService.Save(formInfo, purchaseOrderMain, purchaseTempList, out documentNo))
                {
                    Clear();
                    GeneratePurchaseOrderDocument();                 
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void UpdateGrid(PurchaseTemp purchaseTemp)
        {
            try
            {
                decimal itemDisAmount = 0;
                purchaseTemp.ItemID = item.ItemID;
                purchaseTemp.ItemCode = item.ItemCode.Trim();
                purchaseTemp.ItemName = item.ItemName;
                purchaseTemp.CostPrice = Common.ConvertStringToDecimal(txtCostPrice.Text.Trim());
                purchaseTemp.SellingPrice = Common.ConvertStringToDecimal(txtSellingPrice.Text.Trim());
                purchaseTemp.MarginPercentage = Common.ConvertStringToDecimal(txtMargin.Text.Trim());
                purchaseTemp.Qty = Common.ConvertStringToDecimal(txtQty.Text.Trim());
                purchaseTemp.FreeQty = Common.ConvertStringToDecimal(txtFreeQty.Text.Trim());
                purchaseTemp.CurrentQty = Common.ConvertStringToDecimal(txtThisLocationStock.Text.Trim());
                purchaseTemp.DiscountPercentage = Common.ConvertStringToDecimal(txtItemDis.Text.Trim());
                purchaseTemp.Amount = Common.ConvertStringToDecimal(Common.ConvertToStringCurrancy(txtAmount.Text.Trim()));

                itemDisAmount = Common.GetDiscountAmount((purchaseTemp.SellingPrice * purchaseTemp.Qty), purchaseTemp.DiscountPercentage);
                purchaseTemp.DiscountAmount = itemDisAmount;

                PurchaseService purchaseService = new PurchaseService();
                purchaseTempList = purchaseService.GetUpdatedPurchaseTempList(purchaseTempList, purchaseTemp);
                dgvPurchaseOrder.DataSource = purchaseTempList.ToList();
                dgvPurchaseOrder.Refresh();
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
                decimal costPrice = 0;
                decimal qty = 0;
                decimal discountPercentage = 0;
                decimal amount = 0;

                if (!string.IsNullOrEmpty(txtSellingPrice.Text.Trim()))
                {
                    costPrice = Common.ConvertStringToDecimal(txtCostPrice.Text.Trim());
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

                amount = (costPrice * qty) - ((costPrice * qty) * discountPercentage / 100);
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
            Common.ClearTextBox(txtItemCode, txtItemName, txtCostPrice, txtMargin, txtSellingPrice, txtQty, txtFreeQty, txtItemDis, txtAmount, txtThisLocationStock, txtWarning);
            txtItemName.Focus();
            dgvItemSearch.Visible = false;
            timer1.Stop();
        }
        private void LoadSupplier(bool isCode, string str)
        {
            try
            {
                SupplierService supplierService = new SupplierService();
                supplier = new Supplier();

                if (isCode)
                {
                    supplier = supplierService.GetSupplierByCode(str);
                }
                else
                {
                    supplier = supplierService.GetSupplierByName(str);
                }

                if (supplier != null)
                {
                    txtSupplierCode.Text = supplier.SupplierCode.Trim();
                    txtSupplierDescription.Text = supplier.SupplierName.Trim();
                }
                else
                {
                    txtSupplierCode.Text = string.Empty;
                    txtSupplierDescription.Text = string.Empty;
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

                totalAmount = purchaseTempList.Sum(x => x.Amount);

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
                if (!Validater.ValidateTextBox(errorProvider1, Validater.ValidateType.Empty, txtSupplierCode, txtSupplierDescription))
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
            if (!Validater.ValidateTextBox(errorProvider1, Validater.ValidateType.Empty, txtItemCode, txtItemName, txtSellingPrice, txtCostPrice, txtMargin, txtFreeQty, txtQty, txtItemDis, txtAmount))
            { return false; }
            if (item == null || item.ItemID == 0)
            {
                return false;
            }
            if (Common.ConvertStringToDecimal(txtQty.Text.Trim()) == 0)
            {
                return false;
            }
            if (Common.ConvertStringToDecimal(txtCostPrice.Text.Trim()) > Common.ConvertStringToDecimal(txtSellingPrice.Text.Trim()))
            {
                SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Error, this.Text, "Cost Price Cannot Exceed Selling Price.");
                return false;
            }
            return true;
        }
        private void CalculateSellingPrice()
        {
            try
            {
                if (txtCostPrice.Text != string.Empty && txtMargin.Text != string.Empty)
                {
                    decimal sellingPrice = 0;
                    decimal costPrice = 0;
                    decimal marginPercentage = 0;

                    marginPercentage = Common.ConvertStringToDecimal(txtMargin.Text.Trim());
                    costPrice = Common.ConvertStringToDecimal(txtCostPrice.Text.Trim());

                    sellingPrice = Math.Round(((marginPercentage / 100) * costPrice) + costPrice, 2, MidpointRounding.AwayFromZero);

                    txtSellingPrice.Text = Common.ConvertToStringCurrancy(sellingPrice.ToString());
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void CalculateMarginPercentage()
        {
            try
            {
                if (txtSellingPrice.Text != string.Empty && txtCostPrice.Text != string.Empty)
                {
                    decimal sellingPrice = 0;
                    decimal costPrice = 0;
                    decimal marginPercentage = 0;

                    sellingPrice = Common.ConvertStringToDecimal(txtSellingPrice.Text.Trim());
                    costPrice = Common.ConvertStringToDecimal(txtCostPrice.Text.Trim());

                    // marginPercentage = ((sellingPrice - costPrice) / costPrice) * 100;
                    marginPercentage = Math.Round(((sellingPrice - costPrice) / costPrice) * 100, 2);

                    txtMargin.Text = Common.ConvertToStringCurrancy(marginPercentage.ToString());
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
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
                    item = itemService.GetActiveCountableItemByAllCodes(str);
                }
                else
                {
                    item = itemService.GetActiveCountableItemByName(str);
                }

                timer1.Stop();
                txtWarning.Text = string.Empty;

                if (item != null)
                {
                    txtItemCode.Text = item.ItemCode.Trim();
                    txtItemName.Text = item.ItemName.Trim();
                    txtCostPrice.Text = Common.ConvertToStringCurrancy(item.CostPrice.ToString());
                    txtSellingPrice.Text = Common.ConvertToStringCurrancy(item.SellingPrice.ToString());
                    txtMargin.Text = Common.ConvertToStringCurrancy(item.MarginPercentage.ToString());
                    txtThisLocationStock.Text = itemService.GetCurrentLocationStockByItemID(item.ItemID).ToString();
                    RetreveImage(item.ItemImage);
                    txtQty.Text = "1";
                    txtFreeQty.Text = "0";
                    txtItemDis.Text = "0";
                    txtCostPrice.Focus();
                    txtCostPrice.SelectAll();
                    dgvItemSearch.Visible = false;

                    if (Common.ConvertStringToDecimal(txtThisLocationStock.Text.Trim()) < item.ReOrderLevel)
                    {
                        blinkCount = 0;
                        timer1.Interval = 500;
                        timer1.Start();
                    }
                }
                else
                {
                    txtItemCode.Text = string.Empty;
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
        private void GeneratePurchaseOrderDocument()
        {
            try
            {
                InvTransaction invTransaction = new InvTransaction();
                invTransaction.GenerateTransactionReport(formInfo, documentNo);
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
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
        private void dgvPurchaseOrder_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (isRecall) { return; }
                    PurchaseService purchaseService = new PurchaseService();

                    if (dgvPurchaseOrder.Rows.Count > 0)
                    {
                        if (dgvPurchaseOrder["ItemCode", dgvPurchaseOrder.CurrentCell.RowIndex].Value.ToString() == string.Empty) { return; }
                        LoadItem(true, dgvPurchaseOrder["ItemCode", dgvPurchaseOrder.CurrentCell.RowIndex].Value.ToString());
                        ClearLine();
                        if (SysMessage.ShowMessage(SysMessage.MessageAction.Delete, SysMessage.MessageType.Question, this.Text, dgvPurchaseOrder["ItemCode", dgvPurchaseOrder.CurrentCell.RowIndex].Value.ToString() + " - " + dgvPurchaseOrder["ItemName", dgvPurchaseOrder.CurrentCell.RowIndex].Value.ToString()).Equals(DialogResult.No)) { return; };
                        if (item != null)
                        {
                            purchaseTemp = new PurchaseTemp();
                            purchaseTemp.ItemID = item.ItemID;
                            purchaseTemp.CostPrice = Common.ConvertStringToDecimal(dgvPurchaseOrder["CostPrice", dgvPurchaseOrder.CurrentCell.RowIndex].Value.ToString());
                            purchaseTemp.SellingPrice = Common.ConvertStringToDecimal(dgvPurchaseOrder["SellingPrice", dgvPurchaseOrder.CurrentCell.RowIndex].Value.ToString());
                        }

                        purchaseTempList = purchaseService.GetUpdatedPurchaseTempListWithDelete(purchaseTempList, purchaseTemp);
                        dgvPurchaseOrder.DataSource = purchaseTempList;
                        dgvPurchaseOrder.Refresh();
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
        private void FrmPurchaseOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                txtItemCode.Focus();
            }
            else if (e.KeyCode == Keys.F9)
            {
                txtItemName.Focus();
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
        private void txtSupplierCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSupplierDescription.Focus();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtSupplierDescription_KeyDown(object sender, KeyEventArgs e)
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
                    txtFreeQty.Focus();
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
                    purchaseTemp = new PurchaseTemp();
                    UpdateGrid(purchaseTemp);
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
        private void txtFreeQty_KeyDown(object sender, KeyEventArgs e)
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
        private void txtCostPrice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtMargin.Focus();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void txtMargin_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSellingPrice.Focus();
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
        private void txtDocumentNo_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightLable(lblDocumentNo);
        }

        private void txtSupplierCode_Leave(object sender, EventArgs e)
        {
            try
            {
                Common.UnHighlightLable(lblSupplier);
                if (txtSupplierCode.Text == string.Empty) { return; }
                LoadSupplier(true, txtSupplierCode.Text.Trim());
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtSupplierDescription_Leave(object sender, EventArgs e)
        {
            try
            {
                Common.UnHighlightLable(lblSupplier);
                if (txtSupplierDescription.Text == string.Empty) { return; }
                LoadSupplier(false, txtSupplierDescription.Text.Trim());
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
                    txtSupplierCode.Focus();
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
                //if (!isAllowMinusStock)
                //{
                //    if (string.IsNullOrEmpty(txtQty.Text)) { return; }

                //    if (Common.ConvertStringToDecimal(txtQty.Text.Trim()) > Common.ConvertStringToDecimal(txtThisLocationStock.Text.Trim()))
                //    {
                //        SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Information, this.Text, "Insufficient Stock.");
                //        txtQty.Focus();
                //    }
                //}
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

        private void txtSupplierCode_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblSupplier);
        }

        private void txtSupplierDescription_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblSupplier);
        }




        #endregion

        private void txtCostPrice_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                CalculateMarginPercentage();
                //CalculateSellingPrice();
                CalculateLine();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }

        private void txtCostPrice_Leave(object sender, EventArgs e)
        {
            try
            {
                CalculateMarginPercentage();
                // CalculateSellingPrice();
                CalculateLine();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtMargin_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                //CalculateSellingPrice();
                CalculateLine();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtMargin_Leave(object sender, EventArgs e)
        {
            try
            {
                // CalculateSellingPrice();
                CalculateLine();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtSellingPrice_Leave(object sender, EventArgs e)
        {
            try
            {
                CalculateMarginPercentage();
                CalculateLine();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
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
    }
}
