using NSoft.ERP.Domain.General;
using NSoft.ERP.Service.General;
using NSoft.ERP.Service.Inventory;
using NSoft.ERP.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSoft.ERP.UI.Windows.General
{
    public partial class FrmLocation : FrmBaseMaster
    {
        public FrmLocation()
        {
            InitializeComponent();
        }

        FormInfo formInfo;
        Location location;
        UserPrivileges userPrivileges;
        UserService userService = new UserService();
        bool isAutogenerate = false;

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
                Common.EnableTextBox(true, txtLocationCode);
                Common.EnableButton(true, btnNew);
                Common.EnableButton(false, btnSave, btnDelete);
                LocationService locationService = new LocationService();
                Common.SetAutoComplete(txtLocationCode, locationService.GetAllLocationCodes());
                Common.SetAutoComplete(txtLocationName, locationService.GetAllLocationNames());
                this.ActiveControl = txtLocationCode;
                base.Initialize();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void txtLocationCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtLocationName.Focus();
            }
        }

        private void txtLocationName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAddress.Focus();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAutogenerate)
                {
                    LocationService locationService = new LocationService();
                    txtLocationCode.Text = locationService.GetNewCode(formInfo);
                    Common.EnableTextBox(false, txtLocationCode);
                    txtLocationName.Focus();
                }
                else
                {
                    Common.EnableTextBox(true, txtLocationCode);
                    txtLocationCode.Focus();
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

        private void txtLocationCode_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtLocationCode.Text == string.Empty) { return; }
                LocationService locationService = new LocationService();
                location = new Location();
                location = locationService.GetLocationByCode(txtLocationCode.Text.Trim());
                if (location != null)
                {
                    txtLocationCode.Text = location.LocationCode.Trim();
                    txtLocationName.Text = location.LocationName.Trim();
                    txtAddress.Text = location.Address.Trim();
                    chkActive.Checked = location.IsActive;
                    chkHeadOffice.Checked = location.IsHeadOffice;
                    chkStockLocation.Checked = location.IsActive;
                    Common.EnableTextBox(false, txtLocationCode);
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

        private void txtLocationName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtLocationName.Text == string.Empty) { return; }
                LocationService locationService = new LocationService();
                location = new Location();
                location = locationService.GetLocationByName(txtLocationName.Text.Trim());
                if (location != null)
                {
                    txtLocationCode.Text = location.LocationCode.Trim();
                    txtLocationName.Text = location.LocationName.Trim();
                    txtAddress.Text = location.Address.Trim();
                    chkActive.Checked = location.IsActive;
                    chkHeadOffice.Checked = location.IsHeadOffice;
                    chkStockLocation.Checked = location.IsActive;
                    Common.EnableTextBox(false, txtLocationCode);
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

        public override void Save()
        {
            try
            {

                if (!ValidateControles()) { return; }
                location = new Location();
                LocationService locationService = new LocationService();
                location = locationService.GetLocationByCode(txtLocationCode.Text.Trim());
                if (location == null)
                {
                    if (Common.SpecialFeatures.IsConfirmBeforeSaveMasterFiles)
                    {
                        if (SysMessage.ShowMessage(SysMessage.MessageAction.Save, SysMessage.MessageType.Question, this.Text, txtLocationName.Text).Equals(DialogResult.No)) { return; };
                    }
                    location = new Location();
                    FillLocation();
                    locationService.AddLocation(location);
                    LogWritter.WriteEventLog(this.Name, this.Text, LogWritter.EventType.Save);
                }
                else
                {
                    if (Common.SpecialFeatures.IsConfirmBeforeUpdateMasterFiles)
                    {
                        if (SysMessage.ShowMessage(SysMessage.MessageAction.Update, SysMessage.MessageType.Question, this.Text, txtLocationName.Text).Equals(DialogResult.No)) { return; };
                    }
                    FillLocation();
                    locationService.UpdateLocation(location);
                    LogWritter.WriteEventLog(this.Name, this.Text, LogWritter.EventType.Update);
                }
                UserService userService = new UserService();
                userService.UpdateUserPrivilegeLocations(location);

                ItemService itemService = new ItemService();
                itemService.UpdateItemStockLocation(location);
                Clear();
                base.Save();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString()); ;
            }
        }
        private bool ValidateControles()
        {
            try
            {
                if (!Validater.ValidateTextBox(errorProvider1, Validater.ValidateType.Empty, txtLocationCode, txtLocationName))
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
        private void FillLocation()
        {
            try
            {
                location.LocationCode = txtLocationCode.Text.Trim();
                location.LocationName = txtLocationName.Text.Trim();
                location.Address = txtAddress.Text.Trim();
                location.IsActive = chkActive.Checked;
                location.IsHeadOffice = chkHeadOffice.Checked;
                location.IsStock = chkStockLocation.Checked;
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
                LocationService locationService = new LocationService();
                location = locationService.GetLocationByCode(txtLocationCode.Text.Trim());
                if (location != null)
                {
                    if (Common.SpecialFeatures.IsConfirmBeforeDeleteMasterFiles)
                    {
                        if (SysMessage.ShowMessage(SysMessage.MessageAction.Delete, SysMessage.MessageType.Question, this.Text, txtLocationName.Text).Equals(DialogResult.No)) { return; };
                    }
                    locationService.DeleteLocation(location);
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

    }
}
