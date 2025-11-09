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
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSoft.ERP.UI.Windows.Inventory
{
    public partial class FrmSalesman : NSoft.ERP.UI.Windows.General.FrmBaseMaster
    {
        public FrmSalesman()
        {
            InitializeComponent();
        }

        FormInfo formInfo;
        Salesman salesman;
        UserPrivileges userPrivileges;
        UserService userService = new UserService();
        bool isAutogenerate = false;

        #region Override Methods
        public override void FormLoad()
        {
            try
            {
                formInfo = new FormInfo();
                formInfo = FormInfoService.GetFormInfoByName(this.Name);
                if (formInfo != null)
                {
                    this.Text = formInfo.FormText.Trim();
                    isAutogenerate = formInfo.IsAutoGenerate;
                }
                userPrivileges = new UserPrivileges();
                userPrivileges = userService.GetUserPrivilegesByUserIDAndForm(Common.LoggedUserID, formInfo);

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
                Common.EnableTextBox(true, txtSalesmanCode);
                Common.EnableButton(true, btnNew);
                Common.EnableButton(false, btnSave, btnDelete);
                SalesmanService salesmanService = new SalesmanService();
                Common.SetAutoComplete(txtSalesmanCode, salesmanService.GetAllSalesmanCodes());
                Common.SetAutoComplete(txtSalesmanDescription, salesmanService.GetAllSalesmanNames());
                this.ActiveControl = txtSalesmanCode;
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
                salesman = new Salesman();
                SalesmanService salesmanService = new SalesmanService();
                salesman = salesmanService.GetSalesmanByCode(txtSalesmanCode.Text.Trim());
                if (salesman == null)
                {
                    if (SysMessage.ShowMessage(SysMessage.MessageAction.Save, SysMessage.MessageType.Question, this.Text, txtSalesmanDescription.Text).Equals(DialogResult.No)) { return; };
                    salesman = new Salesman();
                    FillSalesman();
                    salesmanService.AddSalesman(salesman);
                    LogWritter.WriteEventLog(this.Name, this.Text, LogWritter.EventType.Save);
                }
                else
                {
                    if (SysMessage.ShowMessage(SysMessage.MessageAction.Update, SysMessage.MessageType.Question, this.Text, txtSalesmanDescription.Text).Equals(DialogResult.No)) { return; };
                    FillSalesman();
                    salesmanService.UpdateSalesman(salesman);
                    LogWritter.WriteEventLog(this.Name, this.Text, LogWritter.EventType.Update);
                }
                Clear();
                base.Save();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        public override void Delete()
        {
            try
            {
                SalesmanService salesmanService = new SalesmanService();
                salesman = salesmanService.GetSalesmanByCode(txtSalesmanCode.Text.Trim());
                if (salesman != null)
                {
                    if (SysMessage.ShowMessage(SysMessage.MessageAction.Delete, SysMessage.MessageType.Question, this.Text, txtSalesmanDescription.Text).Equals(DialogResult.No)) { return; };
                    salesmanService.DeleteSalesman(salesman);
                    Clear();
                }
                base.Delete();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        #endregion

        #region Other

        private void FillSalesman()
        {
            try
            {
                salesman.SalesmanCode = txtSalesmanCode.Text.Trim();
                salesman.SalesmanName = txtSalesmanDescription.Text.Trim();
                salesman.Remark = txtRemark.Text.Trim();
                salesman.CommissionRate = Common.ConvertStringToDecimal(txtCommissionRate.Text.Trim());
                salesman.IsActive = chkActive.Checked;
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
                if (!Validater.ValidateTextBox(errorProvider1, Validater.ValidateType.Empty, txtSalesmanCode, txtSalesmanDescription))
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
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAutogenerate)
                {
                    SalesmanService salesmanService = new SalesmanService();
                    txtSalesmanCode.Text = salesmanService.GetNewCode(formInfo);
                    Common.EnableTextBox(false, txtSalesmanCode);
                    txtSalesmanDescription.Focus();
                }
                else
                {
                    Common.EnableTextBox(true, txtSalesmanCode);
                    txtSalesmanCode.Focus();
                }
                Common.EnableButton(false, btnNew);
                if (userPrivileges == null ? false : userPrivileges.IsSave) { Common.EnableButton(true, btnSave); }

            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        #endregion

        #region KeyDown and Leave Event

        private void txtSalesmanCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSalesmanDescription.Focus();
                }
                else if (e.KeyCode == Keys.F1)
                {
                    FrmReferenceSearch frmReferenceSearch = new FrmReferenceSearch(this.Name,txtSalesmanCode.Text.Trim());
                    frmReferenceSearch.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }

        private void txtSalesmanDescription_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCommissionRate.Focus();
                }
                else if (e.KeyCode == Keys.F1)
                {
                    FrmReferenceSearch frmReferenceSearch = new FrmReferenceSearch(this.Name, txtSalesmanDescription.Text.Trim(),false);
                    frmReferenceSearch.ShowDialog();
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

            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtSalesmanCode_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSalesmanCode.Text == string.Empty) { return; }
                SalesmanService salesmanService = new SalesmanService();
                salesman = new Salesman();
                salesman = salesmanService.GetSalesmanByCode(txtSalesmanCode.Text.Trim());
                if (salesman != null)
                {
                    txtSalesmanCode.Text = salesman.SalesmanCode.Trim();
                    txtSalesmanDescription.Text = salesman.SalesmanName.Trim();
                    txtCommissionRate.Text = Common.ConvertToStringCurrancy(salesman.CommissionRate.ToString());
                    txtRemark.Text = salesman.Remark.Trim();
                    chkActive.Checked = salesman.IsActive;
                    Common.EnableTextBox(false, txtSalesmanCode);
                    Common.EnableButton(false, btnNew);
                    if (userPrivileges == null ? false : userPrivileges.IsRemove) { Common.EnableButton(true, btnDelete); }
                    if (userPrivileges == null ? false : userPrivileges.IsSave) { Common.EnableButton(true, btnSave); }
                }
                else
                { btnNew.PerformClick(); }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString()); ;
            }
        }

        private void txtSalesmanDescription_Leave(object sender, EventArgs e)
        {

            try
            {
                if (txtSalesmanDescription.Text == string.Empty) { return; }
                SalesmanService salesmanService = new SalesmanService();
                salesman = new Salesman();
                salesman = salesmanService.GetActiveSalesmanByName(txtSalesmanDescription.Text.Trim());
                if (salesman != null)
                {
                    txtSalesmanCode.Text = salesman.SalesmanCode.Trim();
                    txtSalesmanDescription.Text = salesman.SalesmanName.Trim();
                    txtCommissionRate.Text = Common.ConvertToStringCurrancy(salesman.CommissionRate.ToString());
                    txtRemark.Text = salesman.Remark.Trim();
                    chkActive.Checked = salesman.IsActive;
                    Common.EnableTextBox(false, txtSalesmanCode);
                    Common.EnableButton(false, btnNew);
                    if (userPrivileges == null ? false : userPrivileges.IsRemove) { Common.EnableButton(true, btnDelete); }
                    if (userPrivileges == null ? false : userPrivileges.IsSave) { Common.EnableButton(true, btnSave); }
                }
                else
                { btnNew.PerformClick(); }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString()); ;
            }
        }

        #endregion

        private void txtCommissionRate_KeyDown(object sender, KeyEventArgs e)
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
    }
}
