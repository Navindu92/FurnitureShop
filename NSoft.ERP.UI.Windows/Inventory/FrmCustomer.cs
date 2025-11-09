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
    public partial class FrmCustomer : FrmBaseMaster
    {
        public FrmCustomer()
        {
            InitializeComponent();
        }

        FormInfo formInfo;
        Customer customer;
        UserPrivileges userPrivileges;
        UserService userService = new UserService();
        bool isAutogenerate = false;
        static Image CaptureImage;

        #region Override Method
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

                ReferenceInfoService referenceInfoService = new ReferenceInfoService();
                cmbTitle.DataSource = referenceInfoService.GetReferenceValuesByID((int)Common.ReferenceType.Title);
                cmbTitle.DisplayMember = "ReferenceValue";
                cmbTitle.ValueMember = "SubNo";
                cmbTitle.SelectedIndex = -1;
                cmbTitle.Refresh();

                CustomerGroupService customerGroupService = new CustomerGroupService();
                cmbCustomerGroup.DataSource = customerGroupService.GetAllActiveCustomerGroup();
                cmbCustomerGroup.DisplayMember = "CustomerGroupName";
                cmbCustomerGroup.ValueMember = "CustomerGroupID";
                cmbCustomerGroup.SelectedIndex = -1;
                cmbCustomerGroup.Refresh();

                Common.EnableTextBox(true, txtCustomerCode);
                Common.EnableButton(true, btnNew);
                Common.EnableButton(false, btnSave, btnDelete);
                CustomerService customerService = new CustomerService();
                Common.SetAutoComplete(txtCustomerCode, customerService.GetAllCustomerCodes());
                Common.SetAutoComplete(txtCustomerDescription, customerService.GetAllCustomerNames());
                tbCustomer.SelectedIndex = 0;
                this.ActiveControl = txtCustomerCode;
                txtCustomerCode.Focus();
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
                customer = new Customer();
                CustomerService customerService = new CustomerService();
                customer = customerService.GetCustomerByCode(txtCustomerCode.Text.Trim());
                if (customer == null)
                {
                    if (Common.SpecialFeatures.IsConfirmBeforeSaveMasterFiles)
                    {
                        if (SysMessage.ShowMessage(SysMessage.MessageAction.Save, SysMessage.MessageType.Question, this.Text, txtCustomerDescription.Text).Equals(DialogResult.No)) { return; };
                    }
                    customer = new Customer();
                    FillCustomer();
                    customerService.AddCustomer(customer);
                    LogWritter.WriteEventLog(this.Name, this.Text, LogWritter.EventType.Save);
                }
                else
                {
                    if (Common.SpecialFeatures.IsConfirmBeforeUpdateMasterFiles)
                    {
                        if (SysMessage.ShowMessage(SysMessage.MessageAction.Update, SysMessage.MessageType.Question, this.Text, txtCustomerDescription.Text).Equals(DialogResult.No)) { return; };
                    }
                    FillCustomer();
                    customerService.UpdateCustomer(customer);
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
                CustomerService customerService = new CustomerService();
                customer = customerService.GetCustomerByCode(txtCustomerCode.Text.Trim());
                if (customer != null)
                {
                    if (Common.SpecialFeatures.IsConfirmBeforeDeleteMasterFiles)
                    {
                        if (SysMessage.ShowMessage(SysMessage.MessageAction.Delete, SysMessage.MessageType.Question, this.Text, txtCustomerDescription.Text).Equals(DialogResult.No)) { return; };
                    }
                    customerService.DeleteCustomer(customer);
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

        public override void Clear()
        {
            try
            {
                pbCustomer.Image = null;
                base.Clear();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        #endregion

        #region KeyDown and Leave Events

        private void txtCustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCustomerDescription.Focus();
            }
            else if (e.KeyCode == Keys.F3)
            {
                //CustomerService customerService = new CustomerService();
                //FrmSearchView frmSearchView = new FrmSearchView(customerService.GetAllCustomers(), FormInfoService.GetFormInfoByName("FrmCustomer").FormText, this, txtCustomerCode);
                //frmSearchView.ShowDialog();
                //txtCustomerCode_Leave(this, e);
            }
        }

        private void txtCustomerDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbTitle.Focus();
            }
            else if (e.KeyCode == Keys.F3)
            {
                //CustomerService customerService = new CustomerService();
                //FrmSearchView frmSearchView = new FrmSearchView(customerService.GetAllCustomers(), FormInfoService.GetFormInfoByName("FrmCustomer").FormText, this, txtCustomerDescription);
                //frmSearchView.ShowDialog();
                //txtCustomerDescription_Leave(this, e);
            }
        }

        private void cmbTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbCustomer.SelectedIndex = 0;
                txtNICNo.Focus();
            }
        }

        private void txtNICNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbCustomerGroup.Focus();
            }
        }

        private void cmbCustomerGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbCustomer.SelectedIndex = 1;
                txtAddress.Focus();
            }
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMobileNo.Focus();
            }
        }

        private void txtMobileNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtFixedNo.Focus();
            }
        }

        private void txtUniversity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbCustomer.SelectedIndex = 3;
                txtCreditLimit.Focus();
            }
        }

        private void txtCreditLimit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCreditPeriod.Focus();
            }
        }
        private void txtCustomerCode_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtCustomerCode.Text == string.Empty) { return; }
                LoadCustomer(true, txtCustomerCode.Text.Trim());
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }

        private void txtCustomerDescription_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtCustomerDescription.Text == string.Empty) { return; }
                LoadCustomer(false, txtCustomerDescription.Text.Trim());
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void txtChequeLimit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtChequePeriod.Focus();
            }
        }
        private void txtWorkingHospital_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }
        #endregion

        #region Other
        private void FillCustomer()
        {
            try
            {
                customer.CustomerCode = txtCustomerCode.Text.Trim();
                customer.CustomerName = txtCustomerDescription.Text.Trim();

                customer.Title = Common.ConvertStringToLong(cmbTitle.SelectedValue.ToString());
                customer.CustomerGropID = Common.ConvertStringToLong(cmbCustomerGroup.SelectedValue.ToString());
                customer.Address = txtAddress.Text.Trim();
                customer.NICNo = txtNICNo.Text.Trim();
                customer.MobileNo = txtMobileNo.Text.Trim();
                customer.FixedNo = txtFixedNo.Text.Trim();
                customer.Email = txtEmail.Text.Trim();
                customer.IsActive = chkActive.Checked;

                customer.CreditLimit = Common.ConvertStringToDecimal(txtCreditLimit.Text.Trim());
                customer.ChequeLimit = Common.ConvertStringToDecimal(txtChequeLimit.Text.Trim());
                customer.CreditPeriod = Common.ConvertStringToDecimal(txtCreditPeriod.Text.Trim());
                customer.ChequePeriod = Common.ConvertStringToDecimal(txtChequePeriod.Text.Trim());
                customer.CustomerImage = ImageSave();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private byte[] ImageSave()
        {
            try
            {
                MemoryStream stream = new MemoryStream();
                if (pbCustomer.Image != null)
                {
                    pbCustomer.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                }
                byte[] pic = stream.ToArray();
                return pic;
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
                return null;
            }
        }

        private void RetreveImage(byte[] pic)
        {
            try
            {
                if (pic.Length > 0)
                {
                    Stream stream = new MemoryStream(pic);
                    Image returnImage = Image.FromStream(stream);
                    pbCustomer.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbCustomer.Image = returnImage;
                }
                else
                {
                    pbCustomer.Image = null;
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                FileDialog fileDialog = new OpenFileDialog();
                fileDialog.InitialDirectory = @":D\";
                fileDialog.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    Bitmap newimg = new Bitmap(fileDialog.FileName);
                    pbCustomer.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbCustomer.Image = (Image)newimg;

                }
                fileDialog = null;

            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void btnCamera_Click(object sender, EventArgs e)
        {
            try
            {
                CaptureImage = null;
                FrmWebCamera frmWebCamera = new FrmWebCamera(FrmWebCamera.WebCamForm.Layer1);
                frmWebCamera.ShowDialog();
                pbCustomer.SizeMode = PictureBoxSizeMode.StretchImage;
                pbCustomer.Image = CaptureImage;
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void btnImageClear_Click(object sender, EventArgs e)
        {
            try
            {
                pbCustomer.Image = null;
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        public void SetWebCamImage(Image WebCamImage)
        {
            CaptureImage = WebCamImage;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAutogenerate)
                {
                    CustomerService customerService = new CustomerService();
                    txtCustomerCode.Text = customerService.GetNewCode(formInfo);
                    Common.EnableTextBox(false, txtCustomerCode);
                    txtCustomerDescription.Focus();
                }
                else
                {
                    Common.EnableTextBox(true, txtCustomerCode);
                    txtCustomerCode.Focus();
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

        private bool ValidateControles()
        {
            try
            {
                if (!Validater.ValidateTextBox(errorProvider1, Validater.ValidateType.Empty, txtCustomerCode, txtCustomerDescription, txtCreditLimit,txtCreditPeriod, txtChequeLimit, txtChequePeriod))
                { return false; }
                if (!Validater.ValidateComboBox(errorProvider1, Validater.ValidateType.Empty, cmbCustomerGroup))
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


        private void LoadCustomer(bool isCode, string str)
        {
            try
            {
                CustomerService customerService = new CustomerService();
                customer = new Customer();

                if (isCode)
                {
                    customer = customerService.GetCustomerByCode(str);
                }
                else
                {
                    customer = customerService.GetCustomerByName(str);
                }

                if (customer != null)
                {
                    txtCustomerCode.Text = customer.CustomerCode.Trim();
                    txtCustomerDescription.Text = customer.CustomerName.Trim();
                    txtAddress.Text = customer.Address.Trim();
                    chkActive.Checked = customer.IsActive;

                    cmbTitle.SelectedValue = customer.Title;
                    cmbCustomerGroup.SelectedValue = customer.CustomerGropID;
                    txtNICNo.Text = customer.NICNo.Trim();
                    txtMobileNo.Text = customer.MobileNo.Trim();
                    txtFixedNo.Text = customer.FixedNo.Trim();
                    txtEmail.Text = customer.Email.Trim();
                    txtCreditLimit.Text = Common.ConvertToStringCurrancy(customer.CreditLimit.ToString());
                    txtCreditPeriod.Text = Common.ConvertToStringCurrancy(customer.CreditPeriod.ToString());
                    txtChequeLimit.Text = Common.ConvertToStringCurrancy(customer.ChequeLimit.ToString());
                    txtChequePeriod.Text = Common.ConvertToStringCurrancy(customer.ChequePeriod.ToString());

                    RetreveImage(customer.CustomerImage);
                    Common.EnableTextBox(false, txtCustomerCode);
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
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }


        #endregion

        private void txtFixedNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmail.Focus();
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbCustomer.SelectedIndex = 2;
                txtCreditLimit.Focus();
            }
        }

        private void txtCreditPeriod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtChequeLimit.Focus();
            }
        }

        private void txtChequePeriod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbLedger.Focus();
            }

        }

        private void cmbLedger_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbCustomer.SelectedIndex = 3;
            }
        }
    }

}
