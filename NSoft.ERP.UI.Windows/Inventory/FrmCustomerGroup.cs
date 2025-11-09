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
    public partial class FrmCustomerGroup : NSoft.ERP.UI.Windows.General.FrmBaseMaster
    {
        public FrmCustomerGroup()
        {
            InitializeComponent();
        }

        FormInfo formInfo;
        CustomerGroup customerGroup;
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
                Common.EnableTextBox(true, txtCustomerGroupCode);
                Common.EnableButton(true, btnNew);
                Common.EnableButton(false, btnSave, btnDelete);
                CustomerGroupService customerGroupService = new CustomerGroupService();
                Common.SetAutoComplete(txtCustomerGroupCode, customerGroupService.GetAllCustomerGroupCodes());
                Common.SetAutoComplete(txtCustomerGroupDescription, customerGroupService.GetAllCustomerGroupNames());
                this.ActiveControl = txtCustomerGroupCode;
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
                customerGroup = new CustomerGroup();
                CustomerGroupService customerGroupService = new CustomerGroupService();
                customerGroup = customerGroupService.GetCustomerGroupByCode(txtCustomerGroupCode.Text.Trim());
                if (customerGroup == null)
                {
                    if (SysMessage.ShowMessage(SysMessage.MessageAction.Save, SysMessage.MessageType.Question, this.Text, txtCustomerGroupDescription.Text).Equals(DialogResult.No)) { return; };
                    customerGroup = new CustomerGroup();
                    FillCustomerGroup();
                    customerGroupService.AddCustomerGroup(customerGroup);
                    LogWritter.WriteEventLog(this.Name, this.Text, LogWritter.EventType.Save);
                }
                else
                {
                    if (SysMessage.ShowMessage(SysMessage.MessageAction.Update, SysMessage.MessageType.Question, this.Text, txtCustomerGroupDescription.Text).Equals(DialogResult.No)) { return; };
                    FillCustomerGroup();
                    customerGroupService.UpdateCustomerGroup(customerGroup);
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
                CustomerGroupService customerGroupService = new CustomerGroupService();
                customerGroup = customerGroupService.GetCustomerGroupByCode(txtCustomerGroupCode.Text.Trim());
                if (customerGroup != null)
                {
                    if (SysMessage.ShowMessage(SysMessage.MessageAction.Delete, SysMessage.MessageType.Question, this.Text, txtCustomerGroupDescription.Text).Equals(DialogResult.No)) { return; };
                    customerGroupService.DeleteCustomerGroup(customerGroup);
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

        private void FillCustomerGroup()
        {
            try
            {
                customerGroup.CustomerGroupCode = txtCustomerGroupCode.Text.Trim();
                customerGroup.CustomerGroupName = txtCustomerGroupDescription.Text.Trim();
                customerGroup.Remark = txtRemark.Text.Trim();
                customerGroup.IsActive = chkActive.Checked;
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
                if (!Validater.ValidateTextBox(errorProvider1, Validater.ValidateType.Empty, txtCustomerGroupCode, txtCustomerGroupDescription))
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
                    CustomerGroupService customerGroupService = new CustomerGroupService();
                    txtCustomerGroupCode.Text = customerGroupService.GetNewCode(formInfo);
                    Common.EnableTextBox(false, txtCustomerGroupCode);
                    txtCustomerGroupDescription.Focus();
                }
                else
                {
                    Common.EnableTextBox(true, txtCustomerGroupCode);
                    txtCustomerGroupCode.Focus();
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

        private void txtCustomerGroupCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCustomerGroupDescription.Focus();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }

        private void txtCustomerGroupDescription_KeyDown(object sender, KeyEventArgs e)
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

        private void txtCustomerGroupCode_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtCustomerGroupCode.Text == string.Empty) { return; }
                CustomerGroupService customerGroupService = new CustomerGroupService();
                customerGroup = new CustomerGroup();
                customerGroup = customerGroupService.GetCustomerGroupByCode(txtCustomerGroupCode.Text.Trim());
                if (customerGroup != null)
                {
                    txtCustomerGroupCode.Text = customerGroup.CustomerGroupCode.Trim();
                    txtCustomerGroupDescription.Text = customerGroup.CustomerGroupName.Trim();
                    txtRemark.Text = customerGroup.Remark.Trim();
                    chkActive.Checked = customerGroup.IsActive;
                    Common.EnableTextBox(false, txtCustomerGroupCode);
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

        private void txtCustomerGroupDescription_Leave(object sender, EventArgs e)
        {

            try
            {
                if (txtCustomerGroupDescription.Text == string.Empty) { return; }
                CustomerGroupService customerGroupService = new CustomerGroupService();
                customerGroup = new CustomerGroup();
                customerGroup = customerGroupService.GetActiveCustomerGroupByName(txtCustomerGroupDescription.Text.Trim());
                if (customerGroup != null)
                {
                    txtCustomerGroupCode.Text = customerGroup.CustomerGroupCode.Trim();
                    txtCustomerGroupDescription.Text = customerGroup.CustomerGroupName.Trim();
                    txtRemark.Text = customerGroup.Remark.Trim();
                    chkActive.Checked = customerGroup.IsActive;
                    Common.EnableTextBox(false, txtCustomerGroupCode);
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
    }
}
