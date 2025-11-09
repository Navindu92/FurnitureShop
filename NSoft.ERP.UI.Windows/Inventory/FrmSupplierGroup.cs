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
    public partial class FrmSupplierGroup : NSoft.ERP.UI.Windows.General.FrmBaseMaster
    {
        public FrmSupplierGroup()
        {
            InitializeComponent();
        }

        FormInfo formInfo;
        SupplierGroup supplierGroup;
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
                Common.EnableTextBox(true, txtSupplierGroupCode);
                Common.EnableButton(true, btnNew);
                Common.EnableButton(false, btnSave, btnDelete);
                SupplierGroupService supplierGroupService = new SupplierGroupService();
                Common.SetAutoComplete(txtSupplierGroupCode, supplierGroupService.GetAllSupplierGroupCodes());
                Common.SetAutoComplete(txtSupplierGroupDescription, supplierGroupService.GetAllSupplierGroupNames());
                this.ActiveControl = txtSupplierGroupCode;
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
                supplierGroup = new SupplierGroup();
                SupplierGroupService supplierGroupService = new SupplierGroupService();
                supplierGroup = supplierGroupService.GetSupplierGroupByCode(txtSupplierGroupCode.Text.Trim());
                if (supplierGroup == null)
                {
                    if (SysMessage.ShowMessage(SysMessage.MessageAction.Save, SysMessage.MessageType.Question, this.Text, txtSupplierGroupDescription.Text).Equals(DialogResult.No)) { return; };
                    supplierGroup = new SupplierGroup();
                    FillSupplierGroup();
                    supplierGroupService.AddSupplierGroup(supplierGroup);
                    LogWritter.WriteEventLog(this.Name, this.Text, LogWritter.EventType.Save);
                }
                else
                {
                    if (SysMessage.ShowMessage(SysMessage.MessageAction.Update, SysMessage.MessageType.Question, this.Text, txtSupplierGroupDescription.Text).Equals(DialogResult.No)) { return; };
                    FillSupplierGroup();
                    supplierGroupService.UpdateSupplierGroup(supplierGroup);
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
                SupplierGroupService supplierGroupService = new SupplierGroupService();
                supplierGroup = supplierGroupService.GetSupplierGroupByCode(txtSupplierGroupCode.Text.Trim());
                if (supplierGroup != null)
                {
                    if (SysMessage.ShowMessage(SysMessage.MessageAction.Delete, SysMessage.MessageType.Question, this.Text, txtSupplierGroupDescription.Text).Equals(DialogResult.No)) { return; };
                    supplierGroupService.DeleteSupplierGroup(supplierGroup);
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

        private void FillSupplierGroup()
        {
            try
            {
                supplierGroup.SupplierGroupCode = txtSupplierGroupCode.Text.Trim();
                supplierGroup.SupplierGroupName = txtSupplierGroupDescription.Text.Trim();
                supplierGroup.Remark = txtRemark.Text.Trim();
                supplierGroup.IsActive = chkActive.Checked;
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
                if (!Validater.ValidateTextBox(errorProvider1, Validater.ValidateType.Empty, txtSupplierGroupCode, txtSupplierGroupDescription))
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
                    SupplierGroupService supplierGroupService = new SupplierGroupService();
                    txtSupplierGroupCode.Text = supplierGroupService.GetNewCode(formInfo);
                    Common.EnableTextBox(false, txtSupplierGroupCode);
                    txtSupplierGroupDescription.Focus();
                }
                else
                {
                    Common.EnableTextBox(true, txtSupplierGroupCode);
                    txtSupplierGroupCode.Focus();
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

        private void txtSupplierGroupCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSupplierGroupDescription.Focus();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }

        private void txtSupplierGroupDescription_KeyDown(object sender, KeyEventArgs e)
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

        private void txtSupplierGroupCode_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSupplierGroupCode.Text == string.Empty) { return; }
                SupplierGroupService supplierGroupService = new SupplierGroupService();
                supplierGroup = new SupplierGroup();
                supplierGroup = supplierGroupService.GetSupplierGroupByCode(txtSupplierGroupCode.Text.Trim());
                if (supplierGroup != null)
                {
                    txtSupplierGroupCode.Text = supplierGroup.SupplierGroupCode.Trim();
                    txtSupplierGroupDescription.Text = supplierGroup.SupplierGroupName.Trim();
                    txtRemark.Text = supplierGroup.Remark.Trim();
                    chkActive.Checked = supplierGroup.IsActive;
                    Common.EnableTextBox(false, txtSupplierGroupCode);
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

        private void txtSupplierGroupDescription_Leave(object sender, EventArgs e)
        {

            try
            {
                if (txtSupplierGroupDescription.Text == string.Empty) { return; }
                SupplierGroupService supplierGroupService = new SupplierGroupService();
                supplierGroup = new SupplierGroup();
                supplierGroup = supplierGroupService.GetActiveSupplierGroupByName(txtSupplierGroupDescription.Text.Trim());
                if (supplierGroup != null)
                {
                    txtSupplierGroupCode.Text = supplierGroup.SupplierGroupCode.Trim();
                    txtSupplierGroupDescription.Text = supplierGroup.SupplierGroupName.Trim();
                    txtRemark.Text = supplierGroup.Remark.Trim();
                    chkActive.Checked = supplierGroup.IsActive;
                    Common.EnableTextBox(false, txtSupplierGroupCode);
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
