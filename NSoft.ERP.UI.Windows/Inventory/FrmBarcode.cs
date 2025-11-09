using NSoft.ERP.Domain.General;
using NSoft.ERP.Domain.Inventory;
using NSoft.ERP.Service.General;
using NSoft.ERP.Service.Inventory;
using NSoft.ERP.UI.Windows.General;
using NSoft.ERP.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSoft.ERP.UI.Windows.Inventory
{
    public partial class FrmBarcode : FrmBaseTransation
    {
        ///<summary>
        /// Developed By Navindu
        /// 2021-09-19
        /// </summary>

        FormInfo formInfo;
        UserPrivileges userPrivileges;
        UserService userService = new UserService();
        long documentID = 0;
        Item item;
        List<BarcodeTemp> barcodeTempList = new List<BarcodeTemp>();
        BarcodeTemp barcodeTemp;
        public FrmBarcode()
        {
            InitializeComponent();
        }

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

                dgvBarcode.AutoGenerateColumns = false;
                dtpDocumentDate.MinDate = DateTime.Now.Date;
                Common.EnableDateTimePicker(false, dtpDocumentDate);

                Common.ReadOnlyTextBox(true, txtSellingPrice, txtCostPrice);

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

                this.ActiveControl = cmbTransaction;
                cmbTransaction.Focus();

                EnableLine(false);
                ClearLine();

                Common.EnableComboBox(true, cmbTransaction, cmbDocumentNo);

                barcodeTempList = new List<BarcodeTemp>();
                dgvBarcode.DataSource = null;
                dgvBarcode.Focus();

                cmbLable.SelectedIndex = 0;

                base.Initialize();
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
                decimal totalQty = 0;

                totalQty = barcodeTempList.Sum(x => x.Qty);

                txtTotalQty.Text = Common.ConvertToStringQty(totalQty.ToString());
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void EnableLine(bool enable)
        {
            Common.EnableTextBox(enable, txtItemCode, txtItemName, txtCostPrice, txtSellingPrice, txtQty);
        }

        private void cmbTransaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbTransaction.Text.Trim() == "Manual Item")
                {
                    EnableLine(true);
                    cmbDocumentNo.DataSource = null;
                    cmbDocumentNo.Refresh();
                    txtItemCode.Focus();
                }
                else if (cmbTransaction.Text.Trim() == "Goods Received Note")
                {
                    EnableLine(false);
                    PurchaseService purchaseService = new PurchaseService();
                    cmbDocumentNo.DataSource = purchaseService.GetPurchaseDocumentNoForBarcodePrint();
                    cmbDocumentNo.Refresh();
                    cmbDocumentNo.Focus();
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

                if (item != null)
                {
                    txtItemCode.Text = item.ItemCode.Trim();
                    txtItemName.Text = item.ItemName.Trim();
                    txtCostPrice.Text = Common.ConvertToStringCurrancy(item.CostPrice.ToString());
                    txtSellingPrice.Text = Common.ConvertToStringCurrancy(item.SellingPrice.ToString());

                    txtQty.Text = "1";
                    txtQty.Focus();
                    txtQty.SelectAll();


                }
                else
                {
                    txtItemCode.Text = string.Empty;

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

        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (string.IsNullOrEmpty(txtItemName.Text.Trim()))
                    {
                        txtQty.Focus();
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
        private void UpdateGrid(BarcodeTemp barcodeTemp)
        {
            try
            {
                decimal itemDisAmount = 0;
                barcodeTemp.ItemID = item.ItemID;
                barcodeTemp.ItemCode = item.ItemCode.Trim();
                barcodeTemp.ItemName = item.ItemName;
                barcodeTemp.CostPrice = Common.ConvertStringToDecimal(txtCostPrice.Text.Trim());
                barcodeTemp.SellingPrice = Common.ConvertStringToDecimal(txtSellingPrice.Text.Trim());
                barcodeTemp.Qty = Common.ConvertStringToDecimal(txtQty.Text.Trim());


                BarcodeService barcodeService = new BarcodeService();
                barcodeTempList = barcodeService.GetUpdatedBarcodeTempList(barcodeTempList, barcodeTemp);
                dgvBarcode.DataSource = barcodeTempList.ToList();
                dgvBarcode.Refresh();

                if (dgvBarcode.RowCount > 0)
                {
                    dgvBarcode.ClearSelection();
                    dgvBarcode.Rows[dgvBarcode.RowCount - 1].Selected = true;
                    dgvBarcode.FirstDisplayedScrollingRowIndex = dgvBarcode.RowCount - 1;

                }

                Common.EnableComboBox(false, cmbTransaction, cmbDocumentNo);

                if (cmbTransaction.Text.Trim() != "Manual Item")
                {
                    EnableLine(false);
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void ClearLine()
        {
            Common.ClearTextBox(txtItemCode, txtItemName, txtCostPrice, txtSellingPrice, txtQty);
            txtItemCode.Focus();
        }
        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (!ValidateLineControles()) { txtItemCode.Focus(); return; }
                    barcodeTemp = new BarcodeTemp();
                    UpdateGrid(barcodeTemp);
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
        private bool ValidateLineControles()
        {
            if (!Validater.ValidateTextBox(errorProvider1, Validater.ValidateType.Empty, txtItemCode, txtItemName, txtSellingPrice, txtCostPrice, txtQty))
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

        private void dgvBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    BarcodeService barcodeService = new BarcodeService();

                    if (dgvBarcode.Rows.Count > 0)
                    {
                        if (dgvBarcode["ItemCode", dgvBarcode.CurrentCell.RowIndex].Value.ToString() == string.Empty) { return; }
                        LoadItem(true, dgvBarcode["ItemCode", dgvBarcode.CurrentCell.RowIndex].Value.ToString());
                        ClearLine();
                        if (SysMessage.ShowMessage(SysMessage.MessageAction.Delete, SysMessage.MessageType.Question, this.Text, dgvBarcode["ItemCode", dgvBarcode.CurrentCell.RowIndex].Value.ToString() + " - " + dgvBarcode["ItemName", dgvBarcode.CurrentCell.RowIndex].Value.ToString()).Equals(DialogResult.No)) { return; };
                        if (item != null)
                        {
                            barcodeTemp = new BarcodeTemp();
                            barcodeTemp.ItemID = item.ItemID;
                            barcodeTemp.CostPrice = Common.ConvertStringToDecimal(dgvBarcode["CostPrice", dgvBarcode.CurrentCell.RowIndex].Value.ToString());
                            barcodeTemp.SellingPrice = Common.ConvertStringToDecimal(dgvBarcode["SellingPrice", dgvBarcode.CurrentCell.RowIndex].Value.ToString());
                        }

                        barcodeTempList = barcodeService.GetUpdatedBarcodeTempListWithDelete(barcodeTempList, barcodeTemp);
                        dgvBarcode.DataSource = barcodeTempList;
                        dgvBarcode.Refresh();
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

        private void dgvBarcode_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvBarcode.RowCount > 0)
                {
                    if (dgvBarcode["ItemCode", dgvBarcode.CurrentCell.RowIndex].Value.ToString() == string.Empty) { return; }
                    LoadItem(true, dgvBarcode["ItemCode", dgvBarcode.CurrentCell.RowIndex].Value.ToString());

                    Common.EnableTextBox(true, txtQty);

                    txtCostPrice.Text = Common.ConvertToStringCurrancy(dgvBarcode["CostPrice", dgvBarcode.CurrentCell.RowIndex].Value.ToString());
                    txtSellingPrice.Text = Common.ConvertToStringCurrancy(dgvBarcode["SellingPrice", dgvBarcode.CurrentCell.RowIndex].Value.ToString());
                    txtQty.Text = Common.ConvertToStringCurrancy(dgvBarcode["Qty", dgvBarcode.CurrentCell.RowIndex].Value.ToString());
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
        private bool ValidateControles()
        {
            try
            {
                if (!Validater.ValidateComboBox(errorProvider1, Validater.ValidateType.Empty, cmbLable))
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

        public override void Save()
        {
            if (!ValidateControles()) { return; }

            if (dgvBarcode.RowCount == 0)
            {
                SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Error, this.Text, "No Data to Save.");
                return;
            }

            Summarize();
            PrintBarcode();
            base.Save();
        }

        private void PrintBarcode()
        {
            try
            {
                string tagFileName = string.Empty;
                string barcodeTextPath = string.Empty;
                string seperator = string.Empty;
                string textFileName = string.Empty;

                tagFileName = cmbLable.Text.Trim() + ".btw";
                barcodeTextPath = @"C:\Barcode";
                seperator = ",";
                textFileName = "bar.txt";

                StreamWriter streamWriter;

                if (!Directory.Exists(barcodeTextPath))
                {
                    Directory.CreateDirectory(barcodeTextPath);
                }

                if (Directory.Exists(barcodeTextPath))
                {
                    FileStream fileStream = new FileStream(barcodeTextPath + @"\\" + textFileName, FileMode.Create);
                    streamWriter = new StreamWriter(fileStream);

                    foreach (BarcodeTemp barcodeTemp in barcodeTempList)
                    {
                        for (int i = 0; i < barcodeTemp.Qty; i++)
                        {
                            string sellingPrice = (string.Format("{0:#0.##}", barcodeTemp.SellingPrice)) + " /-";
                            string costPrice = (string.Format("{0:#0.##}", barcodeTemp.CostPrice)) + " /-";
                            streamWriter.WriteLine(barcodeTemp.ItemID + seperator +
                                                    barcodeTemp.ItemCode + seperator +
                                                    barcodeTemp.ItemName + seperator +
                                                    costPrice + seperator +
                                                    sellingPrice);
                        }
                    }

                    streamWriter.Close();
                    fileStream.Close();

                }

                Process.Start(barcodeTextPath + @"\\" + tagFileName);
                Clear();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void cmbDocumentNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbLable.Focus();
            }
        }

        private void cmbDocumentNo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cmbTransaction.Text.Trim() == "Goods Received Note")
                {
                    EnableLine(false);
                    PurchaseService purchaseService = new PurchaseService();
                    barcodeTempList = new List<BarcodeTemp>();
                    barcodeTempList = purchaseService.GetAllPurchaseForBarcodePrintByDocumentNo(cmbDocumentNo.Text.Trim());
                    dgvBarcode.DataSource = barcodeTempList;
                    dgvBarcode.Refresh();
                    cmbLable.Focus();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
    }
}
