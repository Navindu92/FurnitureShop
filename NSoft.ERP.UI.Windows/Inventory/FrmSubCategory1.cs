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
    public partial class FrmSubCategory1 : NSoft.ERP.UI.Windows.General.FrmBaseMaster
    {
        public FrmSubCategory1()
        {
            InitializeComponent();
        }

        FormInfo formInfo;
        SubCategory1 subCategory1;
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

                    lblSubCategory1Code.Text = formInfo.FormText.Trim() + " Code";
                    lblSubCategory1Description.Text = formInfo.FormText.Trim() + " Desc.";
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
                Common.EnableTextBox(true, txtSubCategory1Code);
                Common.EnableButton(true, btnNew);
                Common.EnableButton(false, btnSave, btnDelete);
                SubCategory1Service subCategory1Service = new SubCategory1Service();
                Common.SetAutoComplete(txtSubCategory1Code, subCategory1Service.GetAllSubCategory1Codes());
                Common.SetAutoComplete(txtSubCategory1Description, subCategory1Service.GetAllSubCategory1Names());
                this.ActiveControl = txtSubCategory1Code;
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
                subCategory1 = new SubCategory1();
                SubCategory1Service subCategory1Service = new SubCategory1Service();
                subCategory1 = subCategory1Service.GetSubCategory1ByCode(txtSubCategory1Code.Text.Trim());
                if (subCategory1 == null)
                {
                    if (SysMessage.ShowMessage(SysMessage.MessageAction.Save, SysMessage.MessageType.Question, this.Text, txtSubCategory1Description.Text).Equals(DialogResult.No)) { return; };
                    subCategory1 = new SubCategory1();
                    FillSubCategory1();
                    subCategory1Service.AddSubCategory1(subCategory1);
                    LogWritter.WriteEventLog(this.Name, this.Text, LogWritter.EventType.Save);
                }
                else
                {
                    if (SysMessage.ShowMessage(SysMessage.MessageAction.Update, SysMessage.MessageType.Question, this.Text, txtSubCategory1Description.Text).Equals(DialogResult.No)) { return; };
                    FillSubCategory1();
                    subCategory1Service.UpdateSubCategory1(subCategory1);
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
                SubCategory1Service subCategory1Service = new SubCategory1Service();
                subCategory1 = subCategory1Service.GetSubCategory1ByCode(txtSubCategory1Code.Text.Trim());
                if (subCategory1 != null)
                {
                    if (SysMessage.ShowMessage(SysMessage.MessageAction.Delete, SysMessage.MessageType.Question, this.Text, txtSubCategory1Description.Text).Equals(DialogResult.No)) { return; };
                    subCategory1Service.DeleteSubCategory1(subCategory1);
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

        private void FillSubCategory1()
        {
            try
            {
                subCategory1.SubCategory1Code = txtSubCategory1Code.Text.Trim();
                subCategory1.SubCategory1Name = txtSubCategory1Description.Text.Trim();
                subCategory1.Remark = txtRemark.Text.Trim();
                subCategory1.IsActive = chkActive.Checked;
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
                if (!Validater.ValidateTextBox(errorProvider1, Validater.ValidateType.Empty, txtSubCategory1Code, txtSubCategory1Description))
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
                    SubCategory1Service subCategory1Service = new SubCategory1Service();
                    txtSubCategory1Code.Text = subCategory1Service.GetNewCode(formInfo);
                    Common.EnableTextBox(false, txtSubCategory1Code);
                    txtSubCategory1Description.Focus();
                }
                else
                {
                    Common.EnableTextBox(true, txtSubCategory1Code);
                    txtSubCategory1Code.Focus();
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

        private void txtSubCategory1Code_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtSubCategory1Description.Focus();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }

        private void txtSubCategory1Description_KeyDown(object sender, KeyEventArgs e)
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

        private void txtSubCategory1Code_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSubCategory1Code.Text == string.Empty) { return; }
                SubCategory1Service subCategory1Service = new SubCategory1Service();
                subCategory1 = new SubCategory1();
                subCategory1 = subCategory1Service.GetSubCategory1ByCode(txtSubCategory1Code.Text.Trim());
                if (subCategory1 != null)
                {
                    txtSubCategory1Code.Text = subCategory1.SubCategory1Code.Trim();
                    txtSubCategory1Description.Text = subCategory1.SubCategory1Name.Trim();
                    txtRemark.Text = subCategory1.Remark.Trim();
                    chkActive.Checked = subCategory1.IsActive;
                    Common.EnableTextBox(false, txtSubCategory1Code);
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

        private void txtSubCategory1Description_Leave(object sender, EventArgs e)
        {

            try
            {
                if (txtSubCategory1Description.Text == string.Empty) { return; }
                SubCategory1Service subCategory1Service = new SubCategory1Service();
                subCategory1 = new SubCategory1();
                subCategory1 = subCategory1Service.GetActiveSubCategory1ByName(txtSubCategory1Description.Text.Trim());
                if (subCategory1 != null)
                {
                    txtSubCategory1Code.Text = subCategory1.SubCategory1Code.Trim();
                    txtSubCategory1Description.Text = subCategory1.SubCategory1Name.Trim();
                    txtRemark.Text = subCategory1.Remark.Trim();
                    chkActive.Checked = subCategory1.IsActive;
                    Common.EnableTextBox(false, txtSubCategory1Code);
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
