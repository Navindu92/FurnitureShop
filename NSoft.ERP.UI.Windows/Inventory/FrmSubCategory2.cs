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
    public partial class FrmSubCategory2 : NSoft.ERP.UI.Windows.General.FrmBaseMaster
    {
        public FrmSubCategory2()
        {
            InitializeComponent();
        }

        FormInfo formInfo;
        SubCategory2 subCategory2;
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

                    lblSubCategory2Code.Text = formInfo.FormText.Trim() + " Code";
                    lblSubCategory2Description.Text = formInfo.FormText.Trim() + " Desc.";
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
                Common.EnableTextBox(true, txtSubCategory2Code);
                Common.EnableButton(true, btnNew);
                Common.EnableButton(false, btnSave, btnDelete);
                SubCategory2Service subCategory1Service = new SubCategory2Service();
                Common.SetAutoComplete(txtSubCategory2Code, subCategory1Service.GetAllSubCategory2Codes());
                Common.SetAutoComplete(txtSubCategory2Description, subCategory1Service.GetAllSubCategory2Names());
                this.ActiveControl = txtSubCategory2Code;
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
                subCategory2 = new SubCategory2();
                SubCategory2Service subCategory2Service = new SubCategory2Service();
                subCategory2 = subCategory2Service.GetSubCategory2ByCode(txtSubCategory2Code.Text.Trim());
                if (subCategory2 == null)
                {
                    if (SysMessage.ShowMessage(SysMessage.MessageAction.Save, SysMessage.MessageType.Question, this.Text, txtSubCategory2Description.Text).Equals(DialogResult.No)) { return; };
                    subCategory2 = new SubCategory2();
                    FillSubCategory2();
                    subCategory2Service.AddSubCategory2(subCategory2);
                    LogWritter.WriteEventLog(this.Name, this.Text, LogWritter.EventType.Save);
                }
                else
                {
                    if (SysMessage.ShowMessage(SysMessage.MessageAction.Update, SysMessage.MessageType.Question, this.Text, txtSubCategory2Description.Text).Equals(DialogResult.No)) { return; };
                    FillSubCategory2();
                    subCategory2Service.UpdateSubCategory2(subCategory2);
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
                SubCategory2Service subCategory2Service = new SubCategory2Service();
                subCategory2 = subCategory2Service.GetSubCategory2ByCode(txtSubCategory2Code.Text.Trim());
                if (subCategory2 != null)
                {
                    if (SysMessage.ShowMessage(SysMessage.MessageAction.Delete, SysMessage.MessageType.Question, this.Text, txtSubCategory2Description.Text).Equals(DialogResult.No)) { return; };
                    subCategory2Service.DeleteSubCategory2(subCategory2);
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

        private void FillSubCategory2()
        {
            try
            {
                subCategory2.SubCategory2Code = txtSubCategory2Code.Text.Trim();
                subCategory2.SubCategory2Name = txtSubCategory2Description.Text.Trim();
                subCategory2.Remark = txtRemark.Text.Trim();
                subCategory2.IsActive = chkActive.Checked;
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
                if (!Validater.ValidateTextBox(errorProvider1, Validater.ValidateType.Empty, txtSubCategory2Code, txtSubCategory2Description))
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
                    SubCategory2Service subCategory2Service = new SubCategory2Service();
                    txtSubCategory2Code.Text = subCategory2Service.GetNewCode(formInfo);
                    Common.EnableTextBox(false, txtSubCategory2Code);
                    txtSubCategory2Description.Focus();
                }
                else
                {
                    Common.EnableTextBox(true, txtSubCategory2Code);
                    txtSubCategory2Code.Focus();
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

        private void txtSubCategory2Code_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSubCategory2Description.Focus();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }

        private void txtSubCategory2Description_KeyDown(object sender, KeyEventArgs e)
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

        private void txtSubCategory2Code_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSubCategory2Code.Text == string.Empty) { return; }
                SubCategory2Service subCategory2Service = new SubCategory2Service();
                subCategory2 = new SubCategory2();
                subCategory2 = subCategory2Service.GetSubCategory2ByCode(txtSubCategory2Code.Text.Trim());
                if (subCategory2 != null)
                {
                    txtSubCategory2Code.Text = subCategory2.SubCategory2Code.Trim();
                    txtSubCategory2Description.Text = subCategory2.SubCategory2Name.Trim();
                    txtRemark.Text = subCategory2.Remark.Trim();
                    chkActive.Checked = subCategory2.IsActive;
                    Common.EnableTextBox(false, txtSubCategory2Code);
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

        private void txtSubCategory2Description_Leave(object sender, EventArgs e)
        {

            try
            {
                if (txtSubCategory2Description.Text == string.Empty) { return; }
                SubCategory2Service subCategory2Service = new SubCategory2Service();
                subCategory2 = new SubCategory2();
                subCategory2 = subCategory2Service.GetActiveSubCategory2ByName(txtSubCategory2Description.Text.Trim());
                if (subCategory2 != null)
                {
                    txtSubCategory2Code.Text = subCategory2.SubCategory2Code.Trim();
                    txtSubCategory2Description.Text = subCategory2.SubCategory2Name.Trim();
                    txtRemark.Text = subCategory2.Remark.Trim();
                    chkActive.Checked = subCategory2.IsActive;
                    Common.EnableTextBox(false, txtSubCategory2Code);
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
