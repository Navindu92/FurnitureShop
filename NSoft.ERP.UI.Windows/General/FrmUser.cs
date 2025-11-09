
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

using NSoft.ERP.Utility;
using NSoft.ERP.Service;
using NSoft.ERP.Domain;
using NSoft.ERP.Domain.General;
using NSoft.ERP.Service.General;

namespace NSoft.ERP.UI.Windows.General.UI.Windows
{
    public partial class FrmUser : FrmBaseMaster
    {
        public FrmUser()
        {
            InitializeComponent();
        }

        FormInfo formInfo;
        User user;
        UserPrivileges userPrivileges;
        List<UserPrivileges> userPrivilegesList = new List<UserPrivileges>();
        List<UserPrivilegesLocation> userPrivilegesLocationList = new List<UserPrivilegesLocation>();
        public override void Initialize()
        {
            try
            {
                Common.EnableTextBox(true, txtUsername);

                UserService userService = new UserService();

                if (Common.IsDeveloper)
                {
                    Common.SetAutoComplete(txtUsername, userService.GetAllUsernamesWithDevelopers());
                }
                else
                {
                    Common.SetAutoComplete(txtUsername, userService.GetAllUsernames());
                }

                this.ActiveControl = txtUsername;
                txtUsername.Focus();

                userPrivilegesList = userService.GetAllPrivileges();
                dgvUserPrivileges.DataSource = Common.ToDataTable(userPrivilegesList);
                dgvUserPrivileges.Refresh();

                userPrivilegesLocationList = userService.GetAllLocationPrivileges();
                dgvAllowLocations.DataSource = Common.ToDataTable(userPrivilegesLocationList);
                dgvAllowLocations.Refresh();

                userPrivileges = new UserPrivileges();
                userPrivileges = userService.GetUserPrivilegesByUserIDAndForm(Common.LoggedUserID, formInfo);
                if (userPrivileges == null ? false : userPrivileges.IsSave) { Common.EnableButton(true, btnSave); } else { Common.EnableButton(false, btnSave); }
                if (userPrivileges == null ? false : userPrivileges.IsRemove) { Common.EnableButton(true, btnDelete); } else { Common.EnableButton(false, btnDelete); }

                base.Initialize();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
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

                if (Common.IsDeveloper)
                {
                    Common.VisibleCheckBox(true, chkIsDeveloper);
                }
                else
                {
                    Common.VisibleCheckBox(false, chkIsDeveloper);
                    chkIsDeveloper.Checked = false;
                }

                UserService userService = new UserService();
                cmbUserGroup.DataSource = userService.GetAllUserGroups();
                cmbUserGroup.ValueMember = "UserGroupID";
                cmbUserGroup.DisplayMember = "UserGroupName";
                cmbUserGroup.Refresh();
                base.FormLoad();

                LogWritter.WriteEventLog(this.Name, this.Text, LogWritter.EventType.Access);
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


                DataTable dtUserPrivileges = (DataTable)dgvUserPrivileges.DataSource;
                DataTable dtUserPrivilegesLocation = (DataTable)dgvAllowLocations.DataSource;
                UserService userService = new UserService();
                user = new User();
                if (Common.IsDeveloper)
                {
                    user = userService.GetUserByUsernameWithDeveloper(txtUsername.Text.Trim());
                }
                else
                {
                    user = userService.GetUserByUsername(txtUsername.Text.Trim());
                }
                if (user == null)
                {
                    if (SysMessage.ShowMessage(SysMessage.MessageAction.Save, SysMessage.MessageType.Question, this.Text, txtUsername.Text.Trim()).Equals(DialogResult.No)) { return; };
                    user = new User();
                    FillUser();
                    userService.AddUser(user, dtUserPrivileges, dtUserPrivilegesLocation);
                    LogWritter.WriteEventLog(this.Name, this.Text, LogWritter.EventType.Save);
                }
                else
                {
                    if (SysMessage.ShowMessage(SysMessage.MessageAction.Update, SysMessage.MessageType.Question, this.Text, txtUsername.Text.Trim()).Equals(DialogResult.No)) { return; };
                    FillUser();
                    userService.UpdateUser(user, dtUserPrivileges, dtUserPrivilegesLocation);
                    LogWritter.WriteEventLog(this.Name, this.Text, LogWritter.EventType.Update);
                }
                SaveUserPrivileges();
                SaveUserPrivilegeLocations();
                Clear();
                base.Save();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void FillUser()
        {
            user.Username = txtUsername.Text.Trim();
            user.Password = txtPassword.Text.Trim();
            user.FullName = txtFullName.Text.Trim();
            user.UserGroupID = Common.ConvertStringToInt(cmbUserGroup.SelectedValue.ToString());
            user.IsActive = chkActive.Checked;
            user.IsDeveloper = chkIsDeveloper.Checked;
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text == string.Empty) { return; }
                UserService userService = new UserService();
                user = new User();

                if (Common.IsDeveloper)
                {
                    user = userService.GetUserByUsernameWithDeveloper(txtUsername.Text.Trim());
                }
                else
                {
                    user = userService.GetUserByUsername(txtUsername.Text.Trim());
                    User checkAdminUser = new User();
                    if (user == null)
                    {
                        checkAdminUser = userService.GetUserByUsernameWithDeveloper(txtUsername.Text.Trim());
                        if (checkAdminUser != null)
                        {
                            Common.ClearTextBox(txtUsername);
                            return;
                        }
                    }
                }

                if (user != null)
                {
                    txtUsername.Text = user.Username.Trim();
                    txtPassword.Text = user.Password.Trim();
                    txtFullName.Text = user.FullName.Trim();
                    txtConfirmPassword.Text = user.Password.Trim();
                    cmbUserGroup.SelectedValue = user.UserGroupID;
                    chkActive.Checked = user.IsActive;
                    chkIsDeveloper.Checked = user.IsDeveloper;
                    Common.EnableTextBox(false, txtUsername);
                    userPrivilegesList = userService.GetAllUserPrivilegesByUsername(txtUsername.Text.Trim());
                    if (userPrivilegesList.Count > 0)
                    {
                        dgvUserPrivileges.DataSource = Common.ToDataTable(userPrivilegesList);
                        dgvUserPrivileges.Refresh();
                    }
                    userPrivilegesLocationList = userService.GetAllUserPrivilegesLocationByUsername(txtUsername.Text.Trim());
                    if (userPrivilegesLocationList.Count > 0)
                    {
                        dgvAllowLocations.DataSource = Common.ToDataTable(userPrivilegesLocationList);
                        dgvAllowLocations.Refresh();
                    }
                }

            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
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
                txtConfirmPassword.Focus();
            }
        }

        private void txtConfirmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtFullName.Focus();
            }
        }

        private void txtFullName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbUserGroup.Focus();
            }
        }

        private void CheckAllAccess(bool chkStatus)
        {
            try
            {
                foreach (DataGridViewRow dr in dgvUserPrivileges.Rows)
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
        private void CheckAllSave(bool chkStatus)
        {
            try
            {
                foreach (DataGridViewRow dr in dgvUserPrivileges.Rows)
                {
                    dr.Cells["IsSave"].Value = chkStatus;
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void CheckAllRemove(bool chkStatus)
        {
            try
            {
                foreach (DataGridViewRow dr in dgvUserPrivileges.Rows)
                {
                    dr.Cells["IsRemove"].Value = chkStatus;
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void CheckAllLocation(bool chkStatus)
        {
            try
            {
                foreach (DataGridViewRow dr in dgvAllowLocations.Rows)
                {
                    dr.Cells["IsAllow"].Value = chkStatus;
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

        private void chkAllSave_CheckedChanged(object sender, EventArgs e)
        {
            CheckAllSave(chkAllSave.Checked);
        }

        private void chkAllRemove_CheckedChanged(object sender, EventArgs e)
        {
            CheckAllRemove(chkAllRemove.Checked);
        }

        private void chkAllLocation_CheckedChanged(object sender, EventArgs e)
        {
            CheckAllLocation(chkAllLocation.Checked);
        }


        private bool ValidateControles()
        {
            try
            {
                if (!Validater.ValidateTextBox(errorProvider1, Validater.ValidateType.Empty, txtUsername, txtPassword, txtConfirmPassword, txtFullName))
                { return false; }
                if (!Validater.ValidateComboBox(errorProvider1, Validater.ValidateType.Empty, cmbUserGroup))
                { return false; }
                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    SysMessage.ShowMessage(SysMessage.MessageAction.NotMatch, SysMessage.MessageType.Error, this.Text);
                    return false;
                }
                return true; ;
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
                return false;
            }
        }

        public override void Delete()
        {
            try
            {
                UserService userService = new UserService();
                user = new User();
                user = userService.GetUserByUsername(txtUsername.Text.Trim());
                if (user != null)
                {
                    if (SysMessage.ShowMessage(SysMessage.MessageAction.Delete, SysMessage.MessageType.Question, this.Text, txtUsername.Text).Equals(DialogResult.No)) { return; };
                    userService.DeleteUser(user);
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

        private void SaveUserPrivileges()
        {
            try
            {
                UserService userService = new UserService();
                UserPrivileges userPrivileges = new UserPrivileges();
                for (int i = 0; i < dgvUserPrivileges.Rows.Count; i++)
                {
                    userPrivileges = new UserPrivileges();
                    userPrivileges = userService.GetUserPrivilegeByUserAndFormID(user, Common.ConvertStringToLong(dgvUserPrivileges.Rows[i].Cells["FormInfoID"].Value.ToString()));

                    if (userPrivileges == null)
                    {
                        userPrivileges = new UserPrivileges();
                        userPrivileges.UserID = user.UserID;
                        userPrivileges.FormInfoID = Common.ConvertStringToLong(dgvUserPrivileges.Rows[i].Cells["FormInfoID"].Value.ToString());
                        userPrivileges.IsAccess = Common.ConvertStringToBool(dgvUserPrivileges.Rows[i].Cells["IsAccess"].Value.ToString());
                        userPrivileges.IsSave = Common.ConvertStringToBool(dgvUserPrivileges.Rows[i].Cells["IsSave"].Value.ToString());
                        userPrivileges.IsRemove = Common.ConvertStringToBool(dgvUserPrivileges.Rows[i].Cells["IsRemove"].Value.ToString());
                        userPrivileges.IsDelete = false;
                        userService.AddUserPrivilege(userPrivileges);
                    }
                    else
                    {
                        userPrivileges.UserID = user.UserID;
                        userPrivileges.FormInfoID = Common.ConvertStringToLong(dgvUserPrivileges.Rows[i].Cells["FormInfoID"].Value.ToString());
                        userPrivileges.IsAccess = Common.ConvertStringToBool(dgvUserPrivileges.Rows[i].Cells["IsAccess"].Value.ToString());
                        userPrivileges.IsSave = Common.ConvertStringToBool(dgvUserPrivileges.Rows[i].Cells["IsSave"].Value.ToString());
                        userPrivileges.IsRemove = Common.ConvertStringToBool(dgvUserPrivileges.Rows[i].Cells["IsRemove"].Value.ToString());
                        userPrivileges.IsDelete = false;
                        userService.UpdateUserPrivilege(userPrivileges);
                    }

                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void SaveUserPrivilegeLocations()
        {
            try
            {
                UserService userService = new UserService();
                UserPrivilegesLocation userPrivilegesLocation = new UserPrivilegesLocation();
                for (int i = 0; i < dgvAllowLocations.Rows.Count; i++)
                {
                    userPrivilegesLocation = new UserPrivilegesLocation();
                    userPrivilegesLocation = userService.GetUserPrivilegeLocationByUserAndLocationID(user, Common.ConvertStringToLong(dgvAllowLocations.Rows[i].Cells["LocationID"].Value.ToString()));

                    if (userPrivilegesLocation == null)
                    {
                        userPrivilegesLocation = new UserPrivilegesLocation();
                        userPrivilegesLocation.UserID = user.UserID;
                        userPrivilegesLocation.LocationID = Common.ConvertStringToLong(dgvAllowLocations.Rows[i].Cells["LocationID"].Value.ToString());
                        userPrivilegesLocation.IsAllow = Common.ConvertStringToBool(dgvAllowLocations.Rows[i].Cells["IsAllow"].Value.ToString());
                        userPrivilegesLocation.IsDelete = false;
                        userService.AddUserPrivilegeLocation(userPrivilegesLocation);
                    }
                    else
                    {
                        userPrivilegesLocation.UserID = user.UserID;
                        userPrivilegesLocation.LocationID = Common.ConvertStringToLong(dgvAllowLocations.Rows[i].Cells["LocationID"].Value.ToString());
                        userPrivilegesLocation.IsAllow = Common.ConvertStringToBool(dgvAllowLocations.Rows[i].Cells["IsAllow"].Value.ToString());
                        userPrivilegesLocation.IsDelete = false;
                        userService.UpdateUserPrivilegeLocation(userPrivilegesLocation);
                    }

                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void dgvUserPrivileges_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            try
            {
                if (Common.ConvertStringToLong(dgvUserPrivileges.Rows[e.RowIndex].Cells["FormType"].Value.ToString()) == 4)
                {
                    dgvUserPrivileges.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.SkyBlue;
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
