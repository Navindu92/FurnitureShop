using NSoft.ERP.Domain.General;
using NSoft.ERP.Domain.Inventory;
using NSoft.ERP.Reports.Reports.Inventory;
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
    public partial class FrmStockAdjustment : FrmBaseTransation
    {
        ///<summary>
        /// Developed By Navindu
        /// 2017-10-22
        /// </summary>
        public FrmStockAdjustment()
        {
            InitializeComponent();
        }

        FormInfo formInfo;
        UserPrivileges userPrivileges;
        UserService userService = new UserService();
        Item item;
        long documentID = 0;
        DataTable dtSearchItem;
        List<StockAdjustmentTemp> stockAdjustmentTempList = new List<StockAdjustmentTemp>();
        StockAdjustmentTemp stockAdjustmentTemp;
        StockAdjustmentMain stockAdjustmentMain;
        Counter counter;
        private int blinkCount = 0;
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

                dgvStockAdjustment.AutoGenerateColumns = false;
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

                ItemService itemService = new ItemService();
                Common.SetAutoCompleteWithoutAppend(txtItemCode, itemService.GetAllActiveCountableItemCodes());
                Common.SetAutoCompleteWithoutAppend(txtItemName, itemService.GetAllActiveCountableItemNames());

                ReferenceInfoService referenceInfoService = new ReferenceInfoService();
                cmbAdjustmentType.DataSource = referenceInfoService.GetReferenceValuesByID((int)Common.ReferenceType.AdjustmentType);
                cmbAdjustmentType.DisplayMember = "ReferenceValue";
                cmbAdjustmentType.ValueMember = "SubNo";
                cmbAdjustmentType.SelectedIndex = -1;
                cmbAdjustmentType.Refresh();

                stockAdjustmentTempList = new List<StockAdjustmentTemp>();
                dgvStockAdjustment.DataSource = null;
                dgvStockAdjustment.DataSource = stockAdjustmentTempList;
                dgvStockAdjustment.Refresh();

                pbItem.Visible = false;
                dgvItemSearch.Visible = false;

                this.ActiveControl = txtReferenceNo;
                txtReferenceNo.Focus();

                dtSearchItem = new DataTable();
                dtSearchItem = itemService.GetAllCountableItemsForInvoiceSearch(Common.LoggedLocationID);

                timer1.Stop();

                EnableLine(false);
                Common.EnableComboBox(true, cmbAdjustmentType);

                Common.ClearTextBox(txtWarning);

                base.Initialize();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void EnableLine(bool enable)
        {
            Common.EnableTextBox(enable, txtItemCode, txtItemName, txtCostPrice, txtSellingPrice, txtQty, txtCostPrice, txtCostValue, txtSellingValue);
        }
        public override void Save()
        {
            try
            {
                if (!ValidateControles()) { return; }

                if (dgvStockAdjustment.RowCount == 0)
                {
                    SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Error, this.Text, "No Data to Save.");
                    return;
                }

                Summarize();
                SaveStockAdjustment();
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
        private void dgvStockAdjustment_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvStockAdjustment.RowCount > 0)
                {
                    if (dgvStockAdjustment["ItemCode", dgvStockAdjustment.CurrentCell.RowIndex].Value.ToString() == string.Empty) { return; }
                    LoadItem(true, dgvStockAdjustment["ItemCode", dgvStockAdjustment.CurrentCell.RowIndex].Value.ToString());

                    txtSellingPrice.Text = Common.ConvertToStringCurrancy(dgvStockAdjustment["SellingPrice", dgvStockAdjustment.CurrentCell.RowIndex].Value.ToString());
                    txtCostPrice.Text = Common.ConvertToStringCurrancy(dgvStockAdjustment["CostPrice", dgvStockAdjustment.CurrentCell.RowIndex].Value.ToString());
                    txtQty.Text = Common.ConvertToStringCurrancy(dgvStockAdjustment["Qty", dgvStockAdjustment.CurrentCell.RowIndex].Value.ToString());
                    txtSellingValue.Text = Common.ConvertToStringCurrancy(dgvStockAdjustment["SellingValue", dgvStockAdjustment.CurrentCell.RowIndex].Value.ToString());
                    txtCostValue.Text = Common.ConvertToStringCurrancy(dgvStockAdjustment["CostValue", dgvStockAdjustment.CurrentCell.RowIndex].Value.ToString());
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
        private void txtCostPrice_KeyUp(object sender, KeyEventArgs e)
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
        #endregion

        #region Private Methods 
        private void SaveStockAdjustment()
        {
            try
            {
                Summarize();

                stockAdjustmentMain = new StockAdjustmentMain();
                stockAdjustmentMain.DocumentDate = dtpDocumentDate.Value.Date;
                stockAdjustmentMain.AdjustmentType = Common.ConvertStringToInt(cmbAdjustmentType.SelectedValue.ToString());
                stockAdjustmentMain.LocationID = Common.LoggedLocationID;
                stockAdjustmentMain.ReferenceNo = txtReferenceNo.Text.Trim();
                stockAdjustmentMain.Remarks = txtRemark.Text.Trim();

                stockAdjustmentMain.TotalQty = Common.ConvertStringToDecimal(txtTotalQty.Text.Trim());
                stockAdjustmentMain.TotalCostValue = Common.ConvertStringToDecimal(txtTotalSellingValue.Text.Trim());
                stockAdjustmentMain.TotalSellingValue = Common.ConvertStringToDecimal(txtTotalSellingValue.Text.Trim());

                StockAdjustmentService stockAdjustmentService = new StockAdjustmentService();

                if (stockAdjustmentService.Save(formInfo, stockAdjustmentMain, stockAdjustmentTempList, out documentNo))
                {
                    GenerateStockAdjustmentDocument();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void UpdateGrid(StockAdjustmentTemp stockAdjustmentTemp)
        {
            try
            {
                stockAdjustmentTemp.ItemID = item.ItemID;
                stockAdjustmentTemp.ItemCode = item.ItemCode.Trim();
                stockAdjustmentTemp.ItemName = item.ItemName;
                stockAdjustmentTemp.CostPrice = Common.ConvertStringToDecimal(txtCostPrice.Text.Trim());
                stockAdjustmentTemp.SellingPrice = Common.ConvertStringToDecimal(txtSellingPrice.Text.Trim());
                stockAdjustmentTemp.CurrentQty = Common.ConvertStringToDecimal(txtThisLocationStock.Text.Trim());
                stockAdjustmentTemp.Qty = Common.ConvertStringToDecimal(txtQty.Text.Trim());
                stockAdjustmentTemp.AdjustQty = (stockAdjustmentTemp.CurrentQty - stockAdjustmentTemp.Qty);

                int adjustmentType = Common.ConvertStringToInt(cmbAdjustmentType.SelectedValue.ToString());

                if (adjustmentType == 1)
                {
                    stockAdjustmentTemp.AddQty = stockAdjustmentTemp.Qty;
                    stockAdjustmentTemp.ReduceQty = 0;
                }
                else if (adjustmentType == 2)
                {
                    stockAdjustmentTemp.AddQty = 0;
                    stockAdjustmentTemp.ReduceQty = stockAdjustmentTemp.Qty;
                }
                else if (adjustmentType == 3)
                {
                    if (stockAdjustmentTemp.CurrentQty < stockAdjustmentTemp.Qty)
                    {
                        stockAdjustmentTemp.AddQty = (stockAdjustmentTemp.Qty - stockAdjustmentTemp.CurrentQty);
                        stockAdjustmentTemp.ReduceQty = 0;
                    }
                    else if (stockAdjustmentTemp.CurrentQty > stockAdjustmentTemp.Qty)
                    {
                        stockAdjustmentTemp.AddQty = 0;
                        stockAdjustmentTemp.ReduceQty = (stockAdjustmentTemp.CurrentQty - stockAdjustmentTemp.Qty);
                    }
                }

                stockAdjustmentTemp.CostValue = Common.ConvertStringToDecimal(Common.ConvertToStringCurrancy(txtCostValue.Text.Trim()));
                stockAdjustmentTemp.SellingValue = Common.ConvertStringToDecimal(Common.ConvertToStringCurrancy(txtSellingValue.Text.Trim()));

                StockAdjustmentService stockAdjustmentService = new StockAdjustmentService();
                stockAdjustmentTempList = stockAdjustmentService.GetUpdatedStockAdjustmentTempList(stockAdjustmentTempList, stockAdjustmentTemp);
                dgvStockAdjustment.DataSource = stockAdjustmentTempList.ToList();
                dgvStockAdjustment.Refresh();


                if (dgvStockAdjustment.RowCount > 0)
                {
                    dgvStockAdjustment.ClearSelection();
                    dgvStockAdjustment.Rows[dgvStockAdjustment.RowCount - 1].Selected = true;
                    dgvStockAdjustment.FirstDisplayedScrollingRowIndex = dgvStockAdjustment.RowCount - 1;

                }
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
                decimal costPrice = 0;
                decimal qty = 0;
                decimal costValue = 0;
                decimal sellingValue = 0;

                if (!string.IsNullOrEmpty(txtSellingPrice.Text.Trim()))
                {
                    sellingPrice = Common.ConvertStringToDecimal(txtSellingPrice.Text.Trim());
                }
                if (!string.IsNullOrEmpty(txtCostPrice.Text.Trim()))
                {
                    costPrice = Common.ConvertStringToDecimal(txtCostPrice.Text.Trim());
                }
                if (!string.IsNullOrEmpty(txtQty.Text.Trim()))
                {
                    qty = Common.ConvertStringToDecimal(txtQty.Text.Trim());
                }

                sellingValue = (sellingPrice * qty);
                txtSellingValue.Text = Common.ConvertToStringCurrancy(sellingValue.ToString());

                costValue = (costPrice * qty);
                txtCostValue.Text = Common.ConvertToStringCurrancy(costValue.ToString());
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
            Common.ClearTextBox(txtItemCode, txtItemName, txtCostPrice, txtSellingPrice, txtQty, txtCostPrice, txtCostValue, txtSellingValue, txtThisLocationStock, txtWarning);
            txtItemCode.Focus();
            dgvItemSearch.Visible = false;
            timer1.Stop();
        }

        private void Summarize()
        {
            try
            {
                decimal totalQty = 0;
                decimal totalCostValue = 0;
                decimal totalSellingValue = 0;

                totalQty = stockAdjustmentTempList.Sum(x => x.Qty);
                totalCostValue = stockAdjustmentTempList.Sum(x => x.CostValue);
                totalSellingValue = stockAdjustmentTempList.Sum(x => x.SellingValue);

                txtTotalQty.Text = Common.ConvertToStringCurrancy(totalQty.ToString());
                txtTotalCostValue.Text = Common.ConvertToStringCurrancy(totalCostValue.ToString());
                txtTotalSellingValue.Text = Common.ConvertToStringCurrancy(totalSellingValue.ToString());

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
                if (!Validater.ValidateTextBox(errorProvider1, Validater.ValidateType.Empty, txtTotalQty))
                { return false; }

                if (!Validater.ValidateComboBox(errorProvider1, Validater.ValidateType.Empty, cmbAdjustmentType))
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
            if (!Validater.ValidateTextBox(errorProvider1, Validater.ValidateType.Empty, txtItemCode, txtItemName, txtCostPrice, txtSellingPrice, txtQty, txtCostValue, txtSellingValue))
            { return false; }
            if (!Validater.ValidateComboBox(errorProvider1,Validater.ValidateType.Empty,cmbAdjustmentType))
            {
                return false;
            }
            if (item == null || item.ItemID == 0)
            {
                return false;
            }
            //if (Common.ConvertStringToDecimal(txtQty.Text.Trim()) == 0)
            //{
            //    return false;
            //}
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
                    txtThisLocationStock.Text = Math.Truncate(itemService.GetCurrentLocationStockByItemID(item.ItemID)).ToString();
                    RetreveImage(item.ItemImage);
                    txtQty.Text = "0";
                    txtQty.Focus();
                    txtQty.SelectAll();
                    dgvItemSearch.Visible = false;

                    //if (Common.ConvertStringToLong(txtThisLocationStock.Text.Trim()) < item.ReOrderLevel)
                    //{
                    //    blinkCount = 0;
                    //    timer1.Interval = 500;
                    //    timer1.Start();
                    //}
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
        private void GenerateStockAdjustmentDocument()
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

        private void dgvStockAdjustment_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (isRecall) { return; }
                    StockAdjustmentService stockAdjustmentService = new StockAdjustmentService();

                    if (dgvStockAdjustment.Rows.Count > 0)
                    {
                        if (dgvStockAdjustment["ItemCode", dgvStockAdjustment.CurrentCell.RowIndex].Value.ToString() == string.Empty) { return; }
                        LoadItem(true, dgvStockAdjustment["ItemCode", dgvStockAdjustment.CurrentCell.RowIndex].Value.ToString());
                        ClearLine();
                        if (SysMessage.ShowMessage(SysMessage.MessageAction.Delete, SysMessage.MessageType.Question, this.Text, dgvStockAdjustment["ItemCode", dgvStockAdjustment.CurrentCell.RowIndex].Value.ToString() + " - " + dgvStockAdjustment["ItemName", dgvStockAdjustment.CurrentCell.RowIndex].Value.ToString()).Equals(DialogResult.No)) { return; };
                        if (item != null)
                        {
                            stockAdjustmentTemp = new StockAdjustmentTemp();
                            stockAdjustmentTemp.ItemID = item.ItemID;
                            stockAdjustmentTemp.SellingPrice = item.SellingPrice;
                        }

                        stockAdjustmentTempList = stockAdjustmentService.GetUpdatedStockAdjustmentTempListWithDelete(stockAdjustmentTempList, stockAdjustmentTemp);
                        dgvStockAdjustment.DataSource = stockAdjustmentTempList;
                        dgvStockAdjustment.Refresh();
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
        private void FrmStockAdjustment_KeyDown(object sender, KeyEventArgs e)
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
                        txtRemark.Focus();
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
                    txtRemark.Focus();
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
                    if (!string.IsNullOrEmpty(txtItemName.Text.Trim()))
                    {
                        txtCostPrice.Focus();
                    }
                    else
                    {
                        btnSave.Focus();
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
                    txtCostValue.Focus();
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

        private void txtReferenceNo_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightLable(lblReferenceNo);
        }

        private void dtpDocumentDate_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightLable(lblDate);
        }


        private void txtDocumentNo_KeyDown(object sender, KeyEventArgs e)
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
                if (string.IsNullOrEmpty(txtQty.Text)) { return; }

                //if (Common.ConvertStringToDecimal(txtQty.Text.Trim()) > Common.ConvertStringToDecimal(txtThisLocationStock.Text.Trim()))
                //{
                //    SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Information, this.Text, "Insufficient Stock.");
                //    txtQty.Focus();
                //}
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }
        private void txtSellingValue_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (!ValidateLineControles()) { txtItemCode.Focus(); return; }
                    stockAdjustmentTemp = new StockAdjustmentTemp();
                    UpdateGrid(stockAdjustmentTemp);
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
        private void txtRemark_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbAdjustmentType.Focus();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void cmbAdjustmentType_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    EnableLine(true);
                    txtItemCode.Focus();
                    Common.EnableComboBox(false, cmbAdjustmentType);
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtRemark_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightLable(lblRemark);
        }

        private void txtCostPrice_KeyDown(object sender, KeyEventArgs e)
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
        private void txtCostValue_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSellingValue.Focus();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }
        private void txtTotalQty_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightLable(lblTotalQty);
        }

        private void txtTotalCostValue_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightLable(lblTotalCostValue);
        }

        private void txtTotalSellingValue_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightLable(lblTotalSellingValue);
        }

        private void cmbAdjustmentType_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightLable(lblAdjustmentType);
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
        private void txtRemark_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblRemark);
        }


        private void txtTotalQty_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblTotalQty);
        }

        private void txtTotalCostValue_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblTotalCostValue);
        }

        private void txtTotalSellingValue_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblTotalSellingValue);
        }

        private void cmbAdjustmentType_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblAdjustmentType);
        }

        #endregion

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
