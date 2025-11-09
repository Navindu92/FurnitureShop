using NSoft.ERP.Domain.General;
using NSoft.ERP.Domain.Inventory;
using NSoft.ERP.Service.General;
using NSoft.ERP.Service.Inventory;
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

namespace NSoft.ERP.UI.Windows.Inventory
{
    public partial class FrmCashier : NSoft.ERP.UI.Windows.General.FrmBaseMaster
    {
        FormInfo formInfo;
        Cashier cashier;
        List<CashierFunction> cashierFunctionList = new List<CashierFunction>();
        public FrmCashier()
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
                }

                base.FormLoad();

                LogWritter.WriteEventLog(this.Name, this.Text, LogWritter.EventType.Access);
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
                Common.EnableTextBox(true, txtCashierName);

                CashierService cashierService = new CashierService();

                if (Common.IsDeveloper)
                {
                    Common.SetAutoComplete(txtCashierName, cashierService.GetAllCashierNamesWithDevelopers());
                }
                else
                {
                    Common.SetAutoComplete(txtCashierName, cashierService.GetAllCashierNames());
                }

                this.ActiveControl = txtCashierName;
                txtCashierName.Focus();

                cashierFunctionList = cashierService.GetAllCashierFunction();
                dgvCashierPrivileges.DataSource = Common.ToDataTable(cashierFunctionList);
                dgvCashierPrivileges.Refresh();

                base.Initialize();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void CheckAllAccess(bool chkStatus)
        {
            try
            {
                foreach (DataGridViewRow dr in dgvCashierPrivileges.Rows)
                {
                    dr.Cells["IsAccess"].Value = chkStatus;
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void chkAllAccess_CheckedChanged(object sender, EventArgs e)
        {
            CheckAllAccess(chkAllAccess.Checked);
        }

        private void txtCashierName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtCashierName.Text == string.Empty) { return; }
                CashierService cashierService = new CashierService();
                cashier = new Cashier();

                if (Common.IsDeveloper)
                {
                    cashier = cashierService.GetCashierByCashierNameWithDeveloper(txtCashierName.Text.Trim());
                }
                else
                {
                    cashier = cashierService.GetCashierByCashierName(txtCashierName.Text.Trim());
                    Cashier checkAdminCashier = new Cashier();
                    if (cashier == null)
                    {
                        checkAdminCashier = cashierService.GetCashierByCashierNameWithDeveloper(txtCashierName.Text.Trim());
                        if (checkAdminCashier != null)
                        {
                            Common.ClearTextBox(txtCashierName);
                            return;
                        }
                    }
                }

                if (cashier != null)
                {
                    txtCashierName.Text = cashier.CashierName.Trim();
                    txtPassword.Text = cashier.Password.Trim();
                    txtEncode.Text = cashier.Encode.Trim();
                    chkActive.Checked = cashier.IsActive;

                    Common.EnableTextBox(false, txtCashierName);
                    cashierFunctionList = cashierService.GetAllCashierPrivilegesByCashierName(txtCashierName.Text.Trim());
                    if (cashierFunctionList.Count > 0)
                    {
                        dgvCashierPrivileges.DataSource = Common.ToDataTable(cashierFunctionList);
                        dgvCashierPrivileges.Refresh();
                    }

                }

            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtCashierName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEncode.Focus();
            }
        }

        public override void Save()
        {
            try
            {
                if (!ValidateControles()) { return; }

                CashierService cashierService = new CashierService();

                cashier = new Cashier();
                if (Common.IsDeveloper)
                {
                    cashier = cashierService.GetCashierByCashierNameWithDeveloper(txtCashierName.Text.Trim());
                }
                else
                {
                    cashier = cashierService.GetCashierByCashierName(txtCashierName.Text.Trim());
                }

                if (cashier == null)
                {
                    if (SysMessage.ShowMessage(SysMessage.MessageAction.Save, SysMessage.MessageType.Question, this.Text, txtCashierName.Text.Trim()).Equals(DialogResult.No)) { return; };
                    cashier = new Cashier();
                    FillCashier();
                    cashierService.AddCashier(cashier);
                    LogWritter.WriteEventLog(this.Name, this.Text, LogWritter.EventType.Save);
                }
                else
                {
                    if (SysMessage.ShowMessage(SysMessage.MessageAction.Update, SysMessage.MessageType.Question, this.Text, txtCashierName.Text.Trim()).Equals(DialogResult.No)) { return; };
                    FillCashier();
                    cashierService.UpdateCashier(cashier);
                    LogWritter.WriteEventLog(this.Name, this.Text, LogWritter.EventType.Update);
                }

                SaveCashierPrivileges();
                Clear();

                base.Save();


            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void SaveCashierPrivileges()
        {
            try
            {
                CashierService cashierService = new CashierService();
                CashierPrivileges cashierPrivileges = new CashierPrivileges();
                for (int i = 0; i < dgvCashierPrivileges.Rows.Count; i++)
                {
                    cashierPrivileges = new CashierPrivileges();
                    cashierPrivileges = cashierService.GetCashierPrivilegeByCashierAndCashierFunctionID(cashier, Common.ConvertStringToLong(dgvCashierPrivileges.Rows[i].Cells["CashierFunctionID"].Value.ToString()));

                    if (cashierPrivileges == null)
                    {
                        cashierPrivileges = new CashierPrivileges();
                        cashierPrivileges.CashierID = cashier.CashierID;
                        cashierPrivileges.CashierFunctionID = Common.ConvertStringToLong(dgvCashierPrivileges.Rows[i].Cells["CashierFunctionID"].Value.ToString());
                        cashierPrivileges.IsAccess = Common.ConvertStringToBool(dgvCashierPrivileges.Rows[i].Cells["IsAccess"].Value.ToString());
                        cashierPrivileges.MaxValue = Common.ConvertStringToDecimal(dgvCashierPrivileges.Rows[i].Cells["MaxValue"].Value.ToString());

                        cashierService.AddCashierPrivileges(cashierPrivileges);
                    }
                    else
                    {
                        cashierPrivileges.CashierID = cashier.CashierID;
                        cashierPrivileges.CashierFunctionID = Common.ConvertStringToLong(dgvCashierPrivileges.Rows[i].Cells["CashierFunctionID"].Value.ToString());
                        cashierPrivileges.IsAccess = Common.ConvertStringToBool(dgvCashierPrivileges.Rows[i].Cells["IsAccess"].Value.ToString());
                        cashierPrivileges.MaxValue = Common.ConvertStringToDecimal(dgvCashierPrivileges.Rows[i].Cells["MaxValue"].Value.ToString());
                        cashierService.UpdateCashierPrivileges(cashierPrivileges);
                    }

                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }


        private void FillCashier()
        {
            try
            {
                cashier.CashierName = txtCashierName.Text.Trim();
                cashier.Password = txtPassword.Text.Trim();
                cashier.Encode = txtEncode.Text.Trim();
                cashier.IsActive = chkActive.Checked;
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
                if (!Validater.ValidateTextBox(errorProvider1, Validater.ValidateType.Empty, txtCashierName, txtPassword))
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
    }
}
