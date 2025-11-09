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
    public partial class FrmBrand : NSoft.ERP.UI.Windows.General.FrmBaseMaster
    {
        public FrmBrand()
        {
            InitializeComponent();
        }

        FormInfo formInfo;
        Brand brand;
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
                Common.EnableTextBox(true, txtBrandCode);
                Common.EnableButton(true, btnNew);
                Common.EnableButton(false, btnSave, btnDelete);
                BrandService brandService = new BrandService();
                Common.SetAutoComplete(txtBrandCode, brandService.GetAllBrandCodes());
                Common.SetAutoComplete(txtBrandDescription, brandService.GetAllBrandNames());
                this.ActiveControl = txtBrandCode;
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
                brand = new Brand();
                BrandService brandService = new BrandService();
                brand = brandService.GetBrandByCode(txtBrandCode.Text.Trim());
                if (brand == null)
                {
                    if (SysMessage.ShowMessage(SysMessage.MessageAction.Save, SysMessage.MessageType.Question, this.Text, txtBrandDescription.Text).Equals(DialogResult.No)) { return; };
                    brand = new Brand();
                    FillBrand();
                    brandService.AddBrand(brand);
                    LogWritter.WriteEventLog(this.Name, this.Text, LogWritter.EventType.Save);
                }
                else
                {
                    if (SysMessage.ShowMessage(SysMessage.MessageAction.Update, SysMessage.MessageType.Question, this.Text, txtBrandDescription.Text).Equals(DialogResult.No)) { return; };
                    FillBrand();
                    brandService.UpdateBrand(brand);
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
                BrandService brandService = new BrandService();
                brand = brandService.GetBrandByCode(txtBrandCode.Text.Trim());
                if (brand != null)
                {
                    if (SysMessage.ShowMessage(SysMessage.MessageAction.Delete, SysMessage.MessageType.Question, this.Text, txtBrandDescription.Text).Equals(DialogResult.No)) { return; };
                    brandService.DeleteBrand(brand);
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

        private void FillBrand()
        {
            try
            {
                brand.BrandCode = txtBrandCode.Text.Trim();
                brand.BrandName = txtBrandDescription.Text.Trim();
                brand.Remark = txtRemark.Text.Trim();
                brand.IsActive = chkActive.Checked;
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
                if (!Validater.ValidateTextBox(errorProvider1, Validater.ValidateType.Empty, txtBrandCode, txtBrandDescription))
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
                    BrandService brandService = new BrandService();
                    txtBrandCode.Text = brandService.GetNewCode(formInfo);
                    Common.EnableTextBox(false, txtBrandCode);
                    txtBrandDescription.Focus();
                }
                else
                {
                    Common.EnableTextBox(true, txtBrandCode);
                    txtBrandCode.Focus();
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

        private void txtBrandCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtBrandDescription.Focus();
                }
                else if (e.KeyCode == Keys.F1)
                {
                    FrmReferenceSearch frmReferenceSearch = new FrmReferenceSearch(this.Name,txtBrandCode.Text.Trim());
                    frmReferenceSearch.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }

        private void txtBrandDescription_KeyDown(object sender, KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtRemark.Focus();
                }
                else if (e.KeyCode == Keys.F1)
                {
                    FrmReferenceSearch frmReferenceSearch = new FrmReferenceSearch(this.Name, txtBrandDescription.Text.Trim(),false);
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

        private void txtBrandCode_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtBrandCode.Text == string.Empty) { return; }
                BrandService brandService = new BrandService();
                brand = new Brand();
                brand = brandService.GetBrandByCode(txtBrandCode.Text.Trim());
                if (brand != null)
                {
                    txtBrandCode.Text = brand.BrandCode.Trim();
                    txtBrandDescription.Text = brand.BrandName.Trim();
                    txtRemark.Text = brand.Remark.Trim();
                    chkActive.Checked = brand.IsActive;
                    Common.EnableTextBox(false, txtBrandCode);
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

        private void txtBrandDescription_Leave(object sender, EventArgs e)
        {

            try
            {
                if (txtBrandDescription.Text == string.Empty) { return; }
                BrandService brandService = new BrandService();
                brand = new Brand();
                brand = brandService.GetActiveBrandByName(txtBrandDescription.Text.Trim());
                if (brand != null)
                {
                    txtBrandCode.Text = brand.BrandCode.Trim();
                    txtBrandDescription.Text = brand.BrandName.Trim();
                    txtRemark.Text = brand.Remark.Trim();
                    chkActive.Checked = brand.IsActive;
                    Common.EnableTextBox(false, txtBrandCode);
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
