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
    public partial class FrmSupplier : FrmBaseMaster
    {
        public FrmSupplier()
        {
            InitializeComponent();
        }

        FormInfo formInfo;
        Supplier supplier;
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

                SupplierGroupService supplierGroupService = new SupplierGroupService();
                cmbSupplierGroup.DataSource = supplierGroupService.GetAllActiveSupplierGroup();
                cmbSupplierGroup.DisplayMember = "SupplierGroupName";
                cmbSupplierGroup.ValueMember = "SupplierGroupID";
                cmbSupplierGroup.SelectedIndex = -1;
                cmbSupplierGroup.Refresh();

                Common.EnableTextBox(true, txtSupplierCode);
                Common.EnableButton(true, btnNew);
                Common.EnableButton(false, btnSave, btnDelete);
                SupplierService supplierService = new SupplierService();
                Common.SetAutoComplete(txtSupplierCode, supplierService.GetAllSupplierCodes());
                Common.SetAutoComplete(txtSupplierDescription, supplierService.GetAllSupplierNames());
                tbSupplier.SelectedIndex = 0;
                this.ActiveControl = txtSupplierCode;
                txtSupplierCode.Focus();
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
                supplier = new Supplier();
                SupplierService supplierService = new SupplierService();
                supplier = supplierService.GetSupplierByCode(txtSupplierCode.Text.Trim());
                if (supplier == null)
                {
                    if (Common.SpecialFeatures.IsConfirmBeforeSaveMasterFiles)
                    {
                        if (SysMessage.ShowMessage(SysMessage.MessageAction.Save, SysMessage.MessageType.Question, this.Text, txtSupplierDescription.Text).Equals(DialogResult.No)) { return; };
                    }
                    supplier = new Supplier();
                    FillSupplier();
                    supplierService.AddSupplier(supplier);
                    LogWritter.WriteEventLog(this.Name, this.Text, LogWritter.EventType.Save);
                }
                else
                {
                    if (Common.SpecialFeatures.IsConfirmBeforeUpdateMasterFiles)
                    {
                        if (SysMessage.ShowMessage(SysMessage.MessageAction.Update, SysMessage.MessageType.Question, this.Text, txtSupplierDescription.Text).Equals(DialogResult.No)) { return; };
                    }
                    FillSupplier();
                    supplierService.UpdateSupplier(supplier);
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
                SupplierService supplierService = new SupplierService();
                supplier = supplierService.GetSupplierByCode(txtSupplierCode.Text.Trim());
                if (supplier != null)
                {
                    if (Common.SpecialFeatures.IsConfirmBeforeDeleteMasterFiles)
                    {
                        if (SysMessage.ShowMessage(SysMessage.MessageAction.Delete, SysMessage.MessageType.Question, this.Text, txtSupplierDescription.Text).Equals(DialogResult.No)) { return; };
                    }
                    supplierService.DeleteSupplier(supplier);
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
                pbSupplier.Image = null;
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

        private void txtSupplierCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSupplierDescription.Focus();
            }
            else if (e.KeyCode == Keys.F3)
            {
                //SupplierService supplierService = new SupplierService();
                //FrmSearchView frmSearchView = new FrmSearchView(supplierService.GetAllSuppliers(), FormInfoService.GetFormInfoByName("FrmSupplier").FormText, this, txtSupplierCode);
                //frmSearchView.ShowDialog();
                //txtSupplierCode_Leave(this, e);
            }
        }

        private void txtSupplierDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbTitle.Focus();
            }
            else if (e.KeyCode == Keys.F3)
            {
                //SupplierService supplierService = new SupplierService();
                //FrmSearchView frmSearchView = new FrmSearchView(supplierService.GetAllSuppliers(), FormInfoService.GetFormInfoByName("FrmSupplier").FormText, this, txtSupplierDescription);
                //frmSearchView.ShowDialog();
                //txtSupplierDescription_Leave(this, e);
            }
        }

        private void cmbTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbSupplier.SelectedIndex = 0;
                txtNICNo.Focus();
            }
        }

        private void txtNICNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbSupplierGroup.Focus();
            }
        }

        private void cmbSupplierGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbSupplier.SelectedIndex = 1;
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
                tbSupplier.SelectedIndex = 3;
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
        private void txtSupplierCode_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSupplierCode.Text == string.Empty) { return; }
                LoadSupplier(true, txtSupplierCode.Text.Trim());
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }

        private void txtSupplierDescription_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtSupplierDescription.Text == string.Empty) { return; }
                LoadSupplier(false, txtSupplierDescription.Text.Trim());
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
        private void FillSupplier()
        {
            try
            {
                supplier.SupplierCode = txtSupplierCode.Text.Trim();
                supplier.SupplierName = txtSupplierDescription.Text.Trim();

                supplier.Title = Common.ConvertStringToLong(cmbTitle.SelectedValue.ToString());
                supplier.SupplierGropID = Common.ConvertStringToLong(cmbSupplierGroup.SelectedValue.ToString());
                supplier.Address = txtAddress.Text.Trim();
                supplier.NICNo = txtNICNo.Text.Trim();
                supplier.MobileNo = txtMobileNo.Text.Trim();
                supplier.FixedNo = txtFixedNo.Text.Trim();
                supplier.Email = txtEmail.Text.Trim();
                supplier.IsActive = chkActive.Checked;

                supplier.CreditLimit = Common.ConvertStringToDecimal(txtCreditLimit.Text.Trim());
                supplier.ChequeLimit = Common.ConvertStringToDecimal(txtChequeLimit.Text.Trim());
                supplier.CreditPeriod = Common.ConvertStringToDecimal(txtCreditPeriod.Text.Trim());
                supplier.ChequePeriod = Common.ConvertStringToDecimal(txtChequePeriod.Text.Trim());
                supplier.SupplierImage = ImageSave();
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
                if (pbSupplier.Image != null)
                {
                    pbSupplier.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
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
                    pbSupplier.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbSupplier.Image = returnImage;
                }
                else
                {
                    pbSupplier.Image = null;
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
                    pbSupplier.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbSupplier.Image = (Image)newimg;

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
                pbSupplier.SizeMode = PictureBoxSizeMode.StretchImage;
                pbSupplier.Image = CaptureImage;
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
                pbSupplier.Image = null;
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
                    SupplierService supplierService = new SupplierService();
                    txtSupplierCode.Text = supplierService.GetNewCode(formInfo);
                    Common.EnableTextBox(false, txtSupplierCode);
                    txtSupplierDescription.Focus();
                }
                else
                {
                    Common.EnableTextBox(true, txtSupplierCode);
                    txtSupplierCode.Focus();
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
                if (!Validater.ValidateTextBox(errorProvider1, Validater.ValidateType.Empty, txtSupplierCode, txtSupplierDescription, txtCreditLimit,txtCreditPeriod, txtChequeLimit, txtChequePeriod))
                { return false; }
                if (!Validater.ValidateComboBox(errorProvider1, Validater.ValidateType.Empty, cmbSupplierGroup))
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


        private void LoadSupplier(bool isCode, string str)
        {
            try
            {
                SupplierService supplierService = new SupplierService();
                supplier = new Supplier();

                if (isCode)
                {
                    supplier = supplierService.GetSupplierByCode(str);
                }
                else
                {
                    supplier = supplierService.GetSupplierByName(str);
                }

                if (supplier != null)
                {
                    txtSupplierCode.Text = supplier.SupplierCode.Trim();
                    txtSupplierDescription.Text = supplier.SupplierName.Trim();
                    txtAddress.Text = supplier.Address.Trim();
                    chkActive.Checked = supplier.IsActive;

                    cmbTitle.SelectedValue = supplier.Title;
                    cmbSupplierGroup.SelectedValue = supplier.SupplierGropID;
                    txtNICNo.Text = supplier.NICNo.Trim();
                    txtMobileNo.Text = supplier.MobileNo.Trim();
                    txtFixedNo.Text = supplier.FixedNo.Trim();
                    txtEmail.Text = supplier.Email.Trim();
                    txtCreditLimit.Text = Common.ConvertToStringCurrancy(supplier.CreditLimit.ToString());
                    txtCreditPeriod.Text = Common.ConvertToStringCurrancy(supplier.CreditPeriod.ToString());
                    txtChequeLimit.Text = Common.ConvertToStringCurrancy(supplier.ChequeLimit.ToString());
                    txtChequePeriod.Text = Common.ConvertToStringCurrancy(supplier.ChequePeriod.ToString());

                    RetreveImage(supplier.SupplierImage);
                    Common.EnableTextBox(false, txtSupplierCode);
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
                tbSupplier.SelectedIndex = 2;
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
                tbSupplier.SelectedIndex = 3;
            }
        }
    }

}
