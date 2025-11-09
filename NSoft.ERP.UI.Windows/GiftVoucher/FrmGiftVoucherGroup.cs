using NSoft.ERP.Domain.General;
using NSoft.ERP.Domain.GiftVoucher;
using NSoft.ERP.Domain.Inventory;
using NSoft.ERP.Service.General;
using NSoft.ERP.Service.GiftVoucher;
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
    public partial class FrmGiftVoucherGroup : NSoft.ERP.UI.Windows.General.FrmBaseMaster
    {
        public FrmGiftVoucherGroup()
        {
            InitializeComponent();
        }

        FormInfo formInfo;
        GiftVoucherGroup giftVoucherGroup;
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
                Common.EnableTextBox(true, txtGiftVoucherGroupCode);
                Common.EnableButton(true, btnNew);
                Common.EnableButton(false, btnSave, btnDelete);
                GiftVoucherGroupService giftVoucherGroupService = new GiftVoucherGroupService();
                Common.SetAutoComplete(txtGiftVoucherGroupCode, giftVoucherGroupService.GetAllGiftVoucherGroupCodes());
                Common.SetAutoComplete(txtGiftVoucherGroupDescription, giftVoucherGroupService.GetAllGiftVoucherGroupNames());
                this.ActiveControl = txtGiftVoucherGroupCode;
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
                giftVoucherGroup = new GiftVoucherGroup();
                GiftVoucherGroupService giftVoucherGroupService = new GiftVoucherGroupService();
                giftVoucherGroup = giftVoucherGroupService.GetGiftVoucherGroupByCode(txtGiftVoucherGroupCode.Text.Trim());
                if (giftVoucherGroup == null)
                {
                    if (SysMessage.ShowMessage(SysMessage.MessageAction.Save, SysMessage.MessageType.Question, this.Text, txtGiftVoucherGroupDescription.Text).Equals(DialogResult.No)) { return; };
                    giftVoucherGroup = new GiftVoucherGroup();
                    FillGiftVoucherGroup();
                    giftVoucherGroupService.AddGiftVoucherGroup(giftVoucherGroup);
                    LogWritter.WriteEventLog(this.Name, this.Text, LogWritter.EventType.Save);
                }
                else
                {
                    if (SysMessage.ShowMessage(SysMessage.MessageAction.Update, SysMessage.MessageType.Question, this.Text, txtGiftVoucherGroupDescription.Text).Equals(DialogResult.No)) { return; };
                    FillGiftVoucherGroup();
                    giftVoucherGroupService.UpdateGiftVoucherGroup(giftVoucherGroup);
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
                GiftVoucherGroupService giftVoucherGroupService = new GiftVoucherGroupService();
                giftVoucherGroup = giftVoucherGroupService.GetGiftVoucherGroupByCode(txtGiftVoucherGroupCode.Text.Trim());
                if (giftVoucherGroup != null)
                {
                    if (SysMessage.ShowMessage(SysMessage.MessageAction.Delete, SysMessage.MessageType.Question, this.Text, txtGiftVoucherGroupDescription.Text).Equals(DialogResult.No)) { return; };
                    giftVoucherGroupService.DeleteGiftVoucherGroup(giftVoucherGroup);
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

        private void FillGiftVoucherGroup()
        {
            try
            {
                giftVoucherGroup.GiftVoucherGroupCode = txtGiftVoucherGroupCode.Text.Trim();
                giftVoucherGroup.GiftVoucherGroupName = txtGiftVoucherGroupDescription.Text.Trim();
                giftVoucherGroup.Remark = txtRemark.Text.Trim();
                giftVoucherGroup.IsActive = chkActive.Checked;
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
                if (!Validater.ValidateTextBox(errorProvider1, Validater.ValidateType.Empty, txtGiftVoucherGroupCode, txtGiftVoucherGroupDescription))
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
                    GiftVoucherGroupService giftVoucherGroupService = new GiftVoucherGroupService();
                    txtGiftVoucherGroupCode.Text = giftVoucherGroupService.GetNewCode(formInfo);
                    Common.EnableTextBox(false, txtGiftVoucherGroupCode);
                    txtGiftVoucherGroupDescription.Focus();
                }
                else
                {
                    Common.EnableTextBox(true, txtGiftVoucherGroupCode);
                    txtGiftVoucherGroupCode.Focus();
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

        private void txtGiftVoucherGroupCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtGiftVoucherGroupDescription.Focus();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }

        private void txtGiftVoucherGroupDescription_KeyDown(object sender, KeyEventArgs e)
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

        private void txtGiftVoucherGroupCode_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtGiftVoucherGroupCode.Text == string.Empty) { return; }
                GiftVoucherGroupService giftVoucherGroupService = new GiftVoucherGroupService();
                giftVoucherGroup = new GiftVoucherGroup();
                giftVoucherGroup = giftVoucherGroupService.GetGiftVoucherGroupByCode(txtGiftVoucherGroupCode.Text.Trim());
                if (giftVoucherGroup != null)
                {
                    txtGiftVoucherGroupCode.Text = giftVoucherGroup.GiftVoucherGroupCode.Trim();
                    txtGiftVoucherGroupDescription.Text = giftVoucherGroup.GiftVoucherGroupName.Trim();
                    txtRemark.Text = giftVoucherGroup.Remark.Trim();
                    chkActive.Checked = giftVoucherGroup.IsActive;
                    Common.EnableTextBox(false, txtGiftVoucherGroupCode);
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

        private void txtGiftVoucherGroupDescription_Leave(object sender, EventArgs e)
        {

            try
            {
                if (txtGiftVoucherGroupDescription.Text == string.Empty) { return; }
                GiftVoucherGroupService giftVoucherGroupService = new GiftVoucherGroupService();
                giftVoucherGroup = new GiftVoucherGroup();
                giftVoucherGroup = giftVoucherGroupService.GetActiveGiftVoucherGroupByName(txtGiftVoucherGroupDescription.Text.Trim());
                if (giftVoucherGroup != null)
                {
                    txtGiftVoucherGroupCode.Text = giftVoucherGroup.GiftVoucherGroupCode.Trim();
                    txtGiftVoucherGroupDescription.Text = giftVoucherGroup.GiftVoucherGroupName.Trim();
                    txtRemark.Text = giftVoucherGroup.Remark.Trim();
                    chkActive.Checked = giftVoucherGroup.IsActive;
                    Common.EnableTextBox(false, txtGiftVoucherGroupCode);
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
