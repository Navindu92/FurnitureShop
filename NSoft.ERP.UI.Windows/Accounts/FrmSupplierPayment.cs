using NSoft.ERP.Domain.Accounts;
using NSoft.ERP.Domain.General;
using NSoft.ERP.Domain.Inventory;
using NSoft.ERP.Service.Accounts;
using NSoft.ERP.Service.General;
using NSoft.ERP.Service.Inventory;
using NSoft.ERP.UI.Windows.General;
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

namespace NSoft.ERP.UI.Windows.Accounts
{
    public partial class FrmSupplierPayment : FrmBaseTransation
    {
        Supplier supplier;
        FormInfo formInfo;
        UserPrivileges userPrivileges;
        UserService userService = new UserService();
        long documentID = 0;
        List<PaymentMain> paymentMainList;
        List<PaymentSub> paymentSubList;
        public FrmSupplierPayment()
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

                dgvPendingPaymentDetails.AutoGenerateColumns = false;

                PayTypeService payTypeService = new PayTypeService();
                cmbPaymentMethod.DataSource = payTypeService.GetAllActivePayTypes();
                cmbPaymentMethod.DisplayMember = "PayTypeName";
                cmbPaymentMethod.ValueMember = "PayTypeID";
                cmbPaymentMethod.SelectedIndex = -1;
                cmbPaymentMethod.Refresh();
                cmbPaymentMethod.Refresh();

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

                Common.EnableTextBox(false, txtChequeNo);

                this.ActiveControl = txtSupplierCode;
                txtSupplierCode.Focus();

                dgvPaymentDetails.DataSource = null;
                dgvPendingPaymentDetails.DataSource = null;

                paymentMainList = new List<PaymentMain>();

                base.Initialize();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

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
                    LoadPendingPayments(supplier);
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

        private void LoadPendingPayments(Supplier supplier)
        {
            try
            {
                if (supplier != null)
                {
                    long grnDocumentid = FormInfoService.GetFormInfoByName("FrmGoodsReceivedNote").DocumentID;

                    PaymentService paymentService = new PaymentService();
                    paymentMainList = paymentService.GetAllPendingGRNForPayment(supplier.SupplierID, Common.LoggedLocationID, grnDocumentid);
                    dgvPendingPaymentDetails.DataSource = paymentMainList.ToList();
                    dgvPendingPaymentDetails.Refresh();

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
            if (e.KeyCode == Keys.Enter)
            {
                dgvPendingPaymentDetails.Focus();
            }
        }

        private void dgvPendingPaymentDetails_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvPendingPaymentDetails.RowCount > 0)
                {
                    if (dgvPendingPaymentDetails["DocumentNo", dgvPendingPaymentDetails.CurrentCell.RowIndex].Value.ToString() == string.Empty) { return; }


                    txtRow.Text = dgvPendingPaymentDetails["Row", dgvPendingPaymentDetails.CurrentCell.RowIndex].Value.ToString();
                    txtGRNNo.Text = dgvPendingPaymentDetails["DocumentNo", dgvPendingPaymentDetails.CurrentCell.RowIndex].Value.ToString();
                    txtBalance.Text = Common.ConvertToStringCurrancy(dgvPendingPaymentDetails["Balance", dgvPendingPaymentDetails.CurrentCell.RowIndex].Value.ToString());
                    txtAmountToPay.Text = Common.ConvertToStringCurrancy(dgvPendingPaymentDetails["Balance", dgvPendingPaymentDetails.CurrentCell.RowIndex].Value.ToString());
                    txtAmountToPay.SelectAll();
                    txtAmountToPay.Focus();

                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtAmountToPay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (!ValidateLineControles())
                    {
                        return;
                    }
                    PaymentMain paymentMain = new PaymentMain();
                    UpdateGrid(paymentMain);
                    ClearLine();
                }
                catch (Exception ex)
                {
                    LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                    SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
                }
            }
        }
        private void ClearLine()
        {
            Common.ClearTextBox(txtGRNNo, txtBalance, txtAmountToPay);
        }
        private void UpdateGrid(PaymentMain paymentMain)
        {
            try
            {
                paymentMain.DocumentNo = txtGRNNo.Text.Trim();

                paymentMain.PayAmount = Common.ConvertStringToDecimal(txtAmountToPay.Text.Trim());

                txtBalance.Text = (Common.ConvertStringToDecimal(txtBalance.Text.Trim()) - Common.ConvertStringToDecimal(txtAmountToPay.Text.Trim())).ToString();

                PaymentService paymentService = new PaymentService();
                paymentMainList = paymentService.GetUpdatedPaymentTempList(paymentMainList, paymentMain);
                dgvPendingPaymentDetails.DataSource = paymentMainList.ToList();
                dgvPendingPaymentDetails.Refresh();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void UpdatePaymentSubGrid(PaymentSub paymentSub)
        {
            try
            {
                paymentSub.PayTypeName = cmbPaymentMethod.Text.Trim();
                paymentSub.ReferenceNo = txtChequeNo.Text.Trim();
                paymentSub.Amount = Common.ConvertStringToDecimal(txtPayAmount.Text.Trim());


                PaymentService paymentService = new PaymentService();
                paymentSubList = paymentService.GetUpdatedPaymentSubTempList(paymentSubList,paymentSub);
                dgvPendingPaymentDetails.DataSource = paymentMainList.ToList();
                dgvPendingPaymentDetails.Refresh();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private bool ValidateLineControles()
        {
            if (!Validater.ValidateTextBox(errorProvider1, Validater.ValidateType.Empty, txtAmountToPay))
            { return false; }

            if (Common.ConvertStringToDecimal(txtAmountToPay.Text.Trim()) == 0)
            {
                return false;
            }
            if (Common.ConvertStringToDecimal(txtAmountToPay.Text.Trim()) > Common.ConvertStringToDecimal(txtBalance.Text.Trim()))
            {
                SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Error, this.Text, "Pay Amount Cannot Exceed Balance Amount.");
                return false;
            }
            return true;
        }

        private void cmbPaymentMethod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbPaymentMethod.Text == "CHEQUE")
                {
                    Common.EnableTextBox(true, txtChequeNo);
                    txtChequeNo.Focus();
                }
                else
                {
                    txtPayAmount.Focus();
                }
            }
        }

        private void txtPayAmount_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
