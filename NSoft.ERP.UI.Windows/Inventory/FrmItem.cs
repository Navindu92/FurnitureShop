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
    public partial class FrmItem : FrmBaseMaster
    {
        public FrmItem()
        {
            InitializeComponent();
        }

        ///<summary>
        /// Developed By Navindu
        /// 2017-10-15
        /// </summary>

        FormInfo formInfo;
        UserPrivileges userPrivileges;
        UserService userService = new UserService();
        bool isAutogenerate = false;
        long documentID = 0;
        static Image CaptureImage;

        Category category;
        SubCategory1 subCategory1;
        SubCategory2 subCategory2;
        Brand brand;
        Item item;

        List<ItemSupplier> itemSupplierList = new List<ItemSupplier>();
        List<ItemStock> itemStockList = new List<ItemStock>();
        List<ItemPrice> itemPriceList = new List<ItemPrice>();

        bool isNew = false;
        bool isNonClearValue = false;
        #region Orverride Methods

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
                    documentID = formInfo.DocumentID;
                }
                userPrivileges = new UserPrivileges();
                userPrivileges = userService.GetUserPrivilegesByUserIDAndForm(Common.LoggedUserID, formInfo);

                dgvItemSupplier.AutoGenerateColumns = false;
                dgvItemStock.AutoGenerateColumns = false;

                FormInfo formInfoSubCategory = new FormInfo();
                FormInfo formInfoSubCategory2 = new FormInfo();

                formInfoSubCategory = FormInfoService.GetFormInfoByName("FrmSubCategory1");
                formInfoSubCategory2 = FormInfoService.GetFormInfoByName("FrmSubCategory2");

                if (formInfoSubCategory != null)
                {
                    lblSubCategory1.Text = formInfoSubCategory.FormText.Trim() + " *";
                }
                if (formInfoSubCategory2 != null)
                {
                    lblSubcategory2.Text = formInfoSubCategory2.FormText.Trim() + " *";
                }

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
                Common.ReadOnlyTextBox(false, txtItemCode, txtReferenceCode1, txtCategoryCode, txtCategoryDescription, txtSubCategory1Code, txtSubCategory1Description, txtSubCategory2Code, txtSubCategory2Description, txtBrandCode, txtBrandDescription);
                Common.EnableButton(true, btnNew);
                Common.EnableButton(false, btnSave, btnDelete);

                ItemService itemService = new ItemService();
                Common.SetAutoComplete(txtItemCode, itemService.GetAllItemCodes());
                Common.SetAutoComplete(txtItemName, itemService.GetAllItemNames());

                BrandService brandService = new BrandService();
                Common.SetAutoComplete(txtBrandCode, brandService.GetAllActiveBrandCodes());
                Common.SetAutoComplete(txtBrandDescription, brandService.GetAllActiveBrandNames());

                CategoryService categoryService = new CategoryService();
                Common.SetAutoComplete(txtCategoryCode, categoryService.GetAllActiveCategoryCodes());
                Common.SetAutoComplete(txtCategoryDescription, categoryService.GetAllActiveCategoryNames());

                SubCategory1Service subCategory1Service = new SubCategory1Service();
                Common.SetAutoComplete(txtSubCategory1Code, subCategory1Service.GetAllActiveSubCategory1Codes());
                Common.SetAutoComplete(txtSubCategory1Description, subCategory1Service.GetAllActiveSubCategory1Names());

                SubCategory2Service subCategory2Service = new SubCategory2Service();
                Common.SetAutoComplete(txtSubCategory2Code, subCategory2Service.GetAllActiveSubCategory2Codes());
                Common.SetAutoComplete(txtSubCategory2Description, subCategory2Service.GetAllActiveSubCategory2Names());

                SupplierService supplierService = new SupplierService();
                Common.SetAutoComplete(txtSupplierCode, supplierService.GetAllActiveSupplierCodes());
                Common.SetAutoComplete(txtSupplierDescription, supplierService.GetAllActiveSupplierNames());

                itemSupplierList = new List<ItemSupplier>();
                itemPriceList = new List<ItemPrice>();
                category = new Category();
                subCategory1 = new SubCategory1();
                subCategory2 = new SubCategory2();
                brand = new Brand();
                item = new Item();

                dgvItemSupplier.DataSource = null;
                dgvItemStock.DataSource = null;
                dgvPriceLevel.DataSource = null;

                lblSinhalaName.Text = string.Empty;

                chkIsCountable.Checked = true;

                tbItem.SelectedTab = tbpPrice;
                this.ActiveControl = txtItemCode;
                txtItemCode.Focus();

                isNew = false;

                chkClearValues.Checked = true;

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

                if (Common.ConvertStringToDecimal(txtMinimumPrice.Text) < Common.ConvertStringToDecimal(txtCostPrice.Text))
                {
                    SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Error, this.Text, "Minimum Price Cannot Less Than Cost Price.");
                    txtMinimumPrice.Focus();
                    return;
                }
                if (Common.ConvertStringToDecimal(txtMinimumPrice.Text) > Common.ConvertStringToDecimal(txtMaximumPrice.Text))
                {
                    SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Error, this.Text, "Minimum Price Cannot Exceed Maximum Price.");
                    txtMinimumPrice.Focus();
                    return;
                }
                if (Common.ConvertStringToDecimal(txtMinimumPrice.Text) > Common.ConvertStringToDecimal(txtSellingPrice.Text))
                {
                    SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Error, this.Text, "Minimum Price Cannot Exceed Selling Price.");
                    txtMinimumPrice.Focus();
                    return;
                }


                item = new Item();
                ItemService itemService = new ItemService();
                item = itemService.GetItemByCode(txtItemCode.Text.Trim());
                if (item == null)
                {
                    if (Common.SpecialFeatures.IsConfirmBeforeSaveMasterFiles)
                    {
                        if (SysMessage.ShowMessage(SysMessage.MessageAction.Save, SysMessage.MessageType.Question, this.Text, txtItemName.Text).Equals(DialogResult.No)) { return; };
                    }


                    item = new Item();
                    FillItem();
                    itemService.AddItem(item);
                    LogWritter.WriteEventLog(this.Name, this.Text, LogWritter.EventType.Save);
                }
                else
                {
                    if (isNew)
                    {
                        if (SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Question, this.Text, "Item Code " + txtItemCode.Text + " Already Exit,Do you want to create as new code").Equals(DialogResult.No)) { return; };

                        ItemCodeDependency itemCodeDependency = new ItemCodeDependency();
                        itemCodeDependency = itemService.GetCodeDependency(documentID);
                        if (itemCodeDependency != null)
                        { }
                        else
                        {
                            txtItemCode.Text = itemService.GetNewDirectItemCode(formInfo.CodeLength);
                        }
                        item = new Item();
                        FillItem();
                        itemService.AddItem(item);
                        LogWritter.WriteEventLog(this.Name, this.Text, LogWritter.EventType.Save);
                    }
                    else
                    {
                        if (Common.SpecialFeatures.IsConfirmBeforeUpdateMasterFiles)
                        {
                            if (SysMessage.ShowMessage(SysMessage.MessageAction.Update, SysMessage.MessageType.Question, this.Text, txtItemName.Text).Equals(DialogResult.No)) { return; };
                        }
                        FillItem();
                        itemService.UpdateItem(item);
                        LogWritter.WriteEventLog(this.Name, this.Text, LogWritter.EventType.Update);
                    }
                }
                SaveItemSupplier();
                SaveItemStock();
                SaveItemPrice();

                if (chkClearValues.Checked)
                {
                    Clear();
                }
                else
                {
                    Common.EnableButton(true, btnNew);
                    btnNew.PerformClick();
                    Common.EnableButton(false, btnSave);
                    isNonClearValue = true;
                    Common.ClearTextBox(txtBarcode, txtReferenceCode1, txtReferenceCode2, txtReferenceCode3);
                }


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
                ItemService itemService = new ItemService();
                item = itemService.GetItemByCode(txtItemCode.Text.Trim());
                if (item != null)
                {
                    if (Common.SpecialFeatures.IsConfirmBeforeDeleteMasterFiles)
                    {
                        if (SysMessage.ShowMessage(SysMessage.MessageAction.Delete, SysMessage.MessageType.Question, this.Text, txtItemName.Text).Equals(DialogResult.No)) { return; };
                    }
                    itemService.DeleteItem(item);
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
                pbItem.Image = null;
                isNonClearValue = false;
                base.Clear();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        #endregion

        #region Keydown and Leave

        private void txtItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtItemName.Focus();
            }

        }

        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtReferenceCode1.Focus();
            }
            else if (e.KeyCode == Keys.F1)
            {
                ItemService itemServiceSearch = new ItemService();
                DataTable dtSearchItem = new DataTable();
                dtSearchItem = itemServiceSearch.GetAllItemsForInvoiceSearch(Common.LoggedLocationID);
                FrmItemSearch frmItemSearch = new FrmItemSearch(dtSearchItem, txtItemName.Text);
                frmItemSearch.ShowDialog();
                if (frmItemSearch.isItemSelected)
                {
                    txtItemCode.Text = frmItemSearch.itemCode;
                    txtItemCode_Leave(this, e);
                }

            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void txtReferenceCode1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNameOnInvoice.Focus();
            }
        }

        private void txtNameOnInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCategoryCode.Focus();
            }
        }

        private void txtCategoryCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCategoryDescription.Focus();
            }
            else if (e.KeyCode == Keys.F1)
            {
                FrmReferenceSearch frmReferenceSearch = new FrmReferenceSearch("FrmCategory", txtCategoryCode.Text.Trim(), true, true);
                frmReferenceSearch.ShowDialog();
            }
        }

        private void txtCategoryDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSubCategory1Code.Focus();
            }
        }

        private void txtSubCategory1Code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSubCategory1Description.Focus();
            }
        }

        private void txtSubCategory1Description_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSubCategory2Code.Focus();
            }
        }

        private void txtSubCategory2Code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSubCategory2Description.Focus();
            }
        }

        private void txtSubCategory2Description_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBrandCode.Focus();
            }
        }

        private void txtBrandCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBrandDescription.Focus();
            }
            else if (e.KeyCode == Keys.F1)
            {
                FrmReferenceSearch frmReferenceSearch = new FrmReferenceSearch("FrmBrand", txtBrandCode.Text.Trim(), true, true);
                frmReferenceSearch.ShowDialog();
            }
        }

        private void txtBrandDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtReOrderLevel.Focus();
            }
        }

        private void txtReOrderLevel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtReOrderQty.Focus();
            }
        }

        private void txtReOrderQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbItem.SelectedIndex = 0;
                txtSellingPrice.Focus();
            }
        }

        private void txtSellingPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCostPrice.Focus();
            }
        }

        private void txtCostPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMarginPercentage.Focus();
            }
        }

        private void txtMarginPercentage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMaximumPrice.Focus();
            }
        }

        private void txtMaximumPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMinimumPrice.Focus();
            }
        }

        private void txtMinimumPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtFixedDiscountPercentage.Focus();
            }
        }

        private void txtFixedDiscountPercentage_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void txtItemCode_Leave(object sender, EventArgs e)
        {
            try
            {
                Common.UnHighlightLable(lblItemCode);
                if (txtItemCode.Text == string.Empty) { return; }
                LoadItem(true, txtItemCode.Text.Trim());
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtItemName_Leave(object sender, EventArgs e)
        {
            try
            {
                Common.UnHighlightLable(lblItemName);
                if (txtItemName.Text == string.Empty) { return; }
                LoadItem(false, txtItemName.Text.Trim());
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtBarcode_Leave(object sender, EventArgs e)
        {
            try
            {
                Common.UnHighlightLable(lblBarcode);
                if (txtBarcode.Text == string.Empty) { return; }
                // LoadItem(true, txtBarcode.Text.Trim());
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtReferenceCode1_Leave(object sender, EventArgs e)
        {
            try
            {
                Common.UnHighlightLable(lblReferenceCode);
                if (txtReferenceCode1.Text == string.Empty) { return; }
                LoadItem(true, txtReferenceCode1.Text.Trim());
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtNameOnInvoice_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightLable(lblNameOnInvoice);
        }

        private void txtCategoryCode_Leave(object sender, EventArgs e)
        {
            try
            {
                Common.UnHighlightLable(lblCategory);
                if (txtCategoryCode.Text == string.Empty) { return; }
                CategoryService categoryService = new CategoryService();
                category = new Category();
                category = categoryService.GetActiveCategoryByCode(txtCategoryCode.Text.Trim());
                if (category != null)
                {
                    txtCategoryCode.Text = category.CategoryCode.Trim();
                    txtCategoryDescription.Text = category.CategoryName.Trim();
                }
                else
                {
                    txtCategoryCode.Text = string.Empty;
                    txtCategoryDescription.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString()); ;
            }
        }

        private void txtCategoryDescription_Leave(object sender, EventArgs e)
        {
            try
            {
                Common.UnHighlightLable(lblCategory);
                if (txtCategoryDescription.Text == string.Empty) { return; }
                CategoryService categoryService = new CategoryService();
                category = new Category();
                category = categoryService.GetActiveCategoryByName(txtCategoryDescription.Text.Trim());
                if (category != null)
                {
                    txtCategoryCode.Text = category.CategoryCode.Trim();
                    txtCategoryDescription.Text = category.CategoryName.Trim();
                }
                else
                {
                    txtCategoryCode.Text = string.Empty;
                    txtCategoryDescription.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString()); ;
            }
        }

        private void txtSubCategory1Code_Leave(object sender, EventArgs e)
        {
            try
            {
                Common.UnHighlightLable(lblSubCategory1);
                if (txtSubCategory1Code.Text == string.Empty) { return; }
                SubCategory1Service subCategory1Service = new SubCategory1Service();
                subCategory1 = new SubCategory1();
                subCategory1 = subCategory1Service.GetActiveSubCategory1ByCode(txtSubCategory1Code.Text.Trim());
                if (subCategory1 != null)
                {
                    txtSubCategory1Code.Text = subCategory1.SubCategory1Code.Trim();
                    txtSubCategory1Description.Text = subCategory1.SubCategory1Name.Trim();
                }
                else
                {
                    txtSubCategory1Code.Text = string.Empty;
                    txtSubCategory1Description.Text = string.Empty;
                }

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
                Common.UnHighlightLable(lblSubCategory1);
                if (txtSubCategory1Description.Text == string.Empty) { return; }
                SubCategory1Service subCategory1Service = new SubCategory1Service();
                subCategory1 = new SubCategory1();
                subCategory1 = subCategory1Service.GetActiveSubCategory1ByName(txtSubCategory1Description.Text.Trim());
                if (subCategory1 != null)
                {
                    txtSubCategory1Code.Text = subCategory1.SubCategory1Code.Trim();
                    txtSubCategory1Description.Text = subCategory1.SubCategory1Name.Trim();
                }
                else
                {
                    txtSubCategory1Code.Text = string.Empty;
                    txtSubCategory1Description.Text = string.Empty;
                }

            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString()); ;
            }
        }

        private void txtSubCategory2Code_Leave(object sender, EventArgs e)
        {
            try
            {
                Common.UnHighlightLable(lblSubcategory2);
                if (txtSubCategory2Code.Text == string.Empty) { return; }
                SubCategory2Service subCategory2Service = new SubCategory2Service();
                subCategory2 = new SubCategory2();
                subCategory2 = subCategory2Service.GetActiveSubCategory2ByCode(txtSubCategory2Code.Text.Trim());
                if (subCategory2 != null)
                {
                    txtSubCategory2Code.Text = subCategory2.SubCategory2Code.Trim();
                    txtSubCategory2Description.Text = subCategory2.SubCategory2Name.Trim();
                }
                else
                {
                    txtSubCategory2Code.Text = string.Empty;
                    txtSubCategory2Description.Text = string.Empty;
                }
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
                Common.UnHighlightLable(lblSubcategory2);
                if (txtSubCategory2Description.Text == string.Empty) { return; }
                SubCategory2Service subCategory2Service = new SubCategory2Service();
                subCategory2 = new SubCategory2();
                subCategory2 = subCategory2Service.GetActiveSubCategory2ByName(txtSubCategory2Description.Text.Trim());
                if (subCategory2 != null)
                {
                    txtSubCategory2Code.Text = subCategory2.SubCategory2Code.Trim();
                    txtSubCategory2Description.Text = subCategory2.SubCategory2Name.Trim();
                }
                else
                {
                    txtSubCategory2Code.Text = string.Empty;
                    txtSubCategory2Description.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString()); ;
            }
            Common.UnHighlightLable(lblSubcategory2);
        }

        private void txtBrandCode_Leave(object sender, EventArgs e)
        {
            try
            {
                Common.UnHighlightLable(lblBrand);
                if (txtBrandCode.Text == string.Empty) { return; }
                BrandService brandService = new BrandService();
                brand = new Brand();
                brand = brandService.GetActiveBrandByCode(txtBrandCode.Text.Trim());
                if (brand != null)
                {
                    txtBrandCode.Text = brand.BrandCode.Trim();
                    txtBrandDescription.Text = brand.BrandName.Trim();
                }
                else
                {
                    txtBrandCode.Text = string.Empty;
                    txtBrandDescription.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString()); ;
            }
        }

        private void txtBrandDescription_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightLable(lblBrand);
            try
            {
                Common.UnHighlightLable(lblBrand);
                if (txtBrandDescription.Text == string.Empty) { return; }
                BrandService brandService = new BrandService();
                brand = new Brand();
                brand = brandService.GetActiveBrandByName(txtBrandDescription.Text.Trim());
                if (brand != null)
                {
                    txtBrandCode.Text = brand.BrandCode.Trim();
                    txtBrandDescription.Text = brand.BrandName.Trim();
                }
                else
                {
                    txtBrandCode.Text = string.Empty;
                    txtBrandDescription.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString()); ;
            }
        }

        private void txtReOrderLevel_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightLable(lblReOrderLevel);
        }

        private void txtReOrderQty_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightLable(lblReOrderQty);
        }

        private void txtSellingPrice_Leave(object sender, EventArgs e)
        {
            try
            {
                Common.UnHighlightLable(lblSellingPrice);
                CalculateMarginPercentage();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtCostPrice_Leave(object sender, EventArgs e)
        {
            try
            {
                Common.UnHighlightLable(lblCostPrice);
                CalculateMarginPercentage();
                // CalculateSellingPrice();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }

        private void txtMarginPercentage_Leave(object sender, EventArgs e)
        {
            try
            {
                Common.UnHighlightLable(lblMargin);
                //CalculateSellingPrice();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtMaximumPrice_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightLable(lblMaximumPrice);
        }

        private void txtMinimumPrice_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightLable(lblMinimumPrice);
        }

        private void txtFixedDiscountPercentage_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightLable(lblFixedDiscount);
        }
        private void txtSupplierCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSupplierDescription.Focus();
            }
        }

        private void txtSupplierDescription_Leave(object sender, EventArgs e)
        {
            try
            {
                SupplierService supplierService = new SupplierService();
                Supplier supplier = new Supplier();
                supplier = supplierService.GetActiveSupplierByName(txtSupplierDescription.Text.Trim());

                if (supplier != null)
                {
                    txtSupplierCode.Text = supplier.SupplierCode.Trim();
                    txtSupplierDescription.Text = supplier.SupplierName.Trim();
                }
                else
                {
                    txtSupplierCode.Text = string.Empty;
                    txtSupplierDescription.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtSupplierCode_Leave(object sender, EventArgs e)
        {
            try
            {
                SupplierService supplierService = new SupplierService();
                Supplier supplier = new Supplier();
                supplier = supplierService.GetActiveSupplierByCode(txtSupplierCode.Text.Trim());

                if (supplier != null)
                {
                    txtSupplierCode.Text = supplier.SupplierCode.Trim();
                    txtSupplierDescription.Text = supplier.SupplierName.Trim();
                }
                else
                {
                    txtSupplierCode.Text = string.Empty;
                    txtSupplierDescription.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtSupplierDescription_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ItemSupplier itemSupplier = new ItemSupplier();
                    UpdateItemSupplierGrid(itemSupplier);
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        #endregion

        #region Enter 

        private void txtItemCode_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblItemCode);
        }

        private void txtItemName_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblItemName);
        }

        private void txtBarcode_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblBarcode);
        }

        private void txtReferenceCode1_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblReferenceCode);
        }

        private void txtNameOnInvoice_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblNameOnInvoice);
        }

        private void txtCategoryCode_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblCategory);
        }

        private void txtCategoryDescription_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblCategory);
        }

        private void txtSubCategory1Code_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblSubCategory1);
        }

        private void txtSubCategory1Description_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblSubCategory1);
        }

        private void txtSubCategory2Code_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblSubcategory2);
        }

        private void txtSubCategory2Description_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblSubcategory2);
        }

        private void txtBrandCode_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblBrand);
        }

        private void txtBrandDescription_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblBrand);
        }

        private void txtReOrderLevel_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblReOrderLevel);
        }

        private void txtReOrderQty_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblReOrderQty);
        }

        private void txtSellingPrice_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblSellingPrice);
        }

        private void txtCostPrice_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblCostPrice);
        }

        private void txtMarginPercentage_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblMargin);
        }

        private void txtMaximumPrice_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblMaximumPrice);
        }

        private void txtMinimumPrice_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblMinimumPrice);
        }

        private void txtFixedDiscountPercentage_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblFixedDiscount);
        }

        #endregion

        #region Private Methods
        private void SaveItemSupplier()
        {
            try
            {
                ItemService itemService = new ItemService();
                itemService.SaveItemSupplierList(itemSupplierList, item);
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void SaveItemPrice()
        {
            try
            {
                ItemService itemService = new ItemService();
                itemService.SaveItemPriceList(itemPriceList, item);
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void SaveItemStock()
        {
            try
            {
                ItemService itemService = new ItemService();
                itemService.SaveItemStock(item);
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
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
                    pbItem.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbItem.Image = returnImage;
                }
                else
                {
                    pbItem.Image = null;
                }
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
                if (!Validater.ValidateTextBox(errorProvider1, Validater.ValidateType.Empty, txtItemCode, txtItemName, txtNameOnInvoice, txtCategoryCode, txtCategoryDescription, txtSubCategory1Code, txtSubCategory1Description,
                    txtSubCategory2Code, txtSubCategory2Description, txtBrandCode, txtBrandDescription, txtSellingPrice, txtCostPrice, txtMarginPercentage, txtMaximumPrice, txtMinimumPrice))
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
        private void FillItem()
        {
            try
            {
                item.ItemCode = txtItemCode.Text.Trim();
                item.ItemName = txtItemName.Text.Trim();
                item.BarCode = txtBarcode.Text.Trim();
                item.ReferenceCode1 = txtReferenceCode1.Text.Trim();
                item.ReferenceCode2 = txtReferenceCode2.Text.Trim();
                item.ReferenceCode3 = txtReferenceCode3.Text.Trim();
                item.NameOnInvoice = txtNameOnInvoice.Text.Trim();
                item.SinhalaName = txtSinhalaName.Text.Trim();
                item.CategoryID = category.CategoryID;
                item.SubCategory1ID = subCategory1.SubCategory1ID;
                item.SubCategory2ID = subCategory2.SubCategory2ID;
                item.BrandID = brand.BrandID;
                if (txtReOrderLevel.Text == string.Empty) { item.ReOrderLevel = 0; } else { item.ReOrderLevel = Common.ConvertStringToDecimal(txtReOrderLevel.Text.Trim()); }
                if (txtReOrderQty.Text == string.Empty) { item.ReOrderQty = 0; } else { item.ReOrderQty = Common.ConvertStringToDecimal(txtReOrderQty.Text.Trim()); }
                item.SellingPrice = Common.ConvertStringToDecimal(txtSellingPrice.Text.Trim());
                item.CostPrice = Common.ConvertStringToDecimal(txtCostPrice.Text.Trim());
                item.MarginPercentage = Common.ConvertStringToDecimal(txtMarginPercentage.Text.Trim());
                item.MaximumPrice = Common.ConvertStringToDecimal(txtMaximumPrice.Text.Trim());
                item.MinimumPrice = Common.ConvertStringToDecimal(txtMinimumPrice.Text.Trim());
                if (txtFixedDiscountPercentage.Text == string.Empty) { item.FixedDiscountPercentage = 0; } else { item.FixedDiscountPercentage = Common.ConvertStringToDecimal(txtFixedDiscountPercentage.Text.Trim()); }
                if (txtFixedDiscount.Text == string.Empty) { item.FixedDiscount = 0; } else { item.FixedDiscount = Common.ConvertStringToDecimal(txtFixedDiscount.Text.Trim()); }
                item.IsActive = chkActive.Checked;
                item.IsCountable = chkIsCountable.Checked;
                item.ItemImage = ImageSave();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void LoadItem(bool isCode, string str)
        {
            try
            {
                ItemService itemService = new ItemService();
                item = new Item();

                if (isCode)
                {
                    item = itemService.GetItemByAllCodes(str);
                }
                else
                {
                    item = itemService.GetItemByName(str);
                }

                if (item != null)
                {
                    txtItemCode.Text = item.ItemCode.Trim();
                    txtItemName.Text = item.ItemName.Trim();
                    txtBarcode.Text = item.BarCode.Trim();
                    txtReferenceCode1.Text = item.ReferenceCode1.Trim();
                    txtReferenceCode2.Text = item.ReferenceCode2.Trim();
                    txtReferenceCode3.Text = item.ReferenceCode3.Trim();
                    txtNameOnInvoice.Text = item.NameOnInvoice.Trim();
                    txtSinhalaName.Text = item.SinhalaName.Trim();
                    lblSinhalaName.Text = item.SinhalaName.Trim();
                    chkActive.Checked = item.IsActive;
                    chkIsCountable.Checked = item.IsCountable;

                    CategoryService categoryService = new CategoryService();
                    category = new Category();
                    category = categoryService.GetActiveCategoryByID(item.CategoryID);
                    if (category != null)
                    {
                        txtCategoryCode.Text = category.CategoryCode.Trim();
                        txtCategoryDescription.Text = category.CategoryName.Trim();
                    }

                    SubCategory1Service subCategory1Service = new SubCategory1Service();
                    subCategory1 = new SubCategory1();
                    subCategory1 = subCategory1Service.GetActiveSubCategory1ByID(item.SubCategory1ID);
                    if (subCategory1 != null)
                    {
                        txtSubCategory1Code.Text = subCategory1.SubCategory1Code.Trim();
                        txtSubCategory1Description.Text = subCategory1.SubCategory1Name.Trim();
                    }

                    SubCategory2Service subCategory2Service = new SubCategory2Service();
                    subCategory2 = new SubCategory2();
                    subCategory2 = subCategory2Service.GetActiveSubCategory2ByID(item.SubCategory2ID);
                    if (subCategory2 != null)
                    {
                        txtSubCategory2Code.Text = subCategory2.SubCategory2Code.Trim();
                        txtSubCategory2Description.Text = subCategory2.SubCategory2Name.Trim();
                    }

                    BrandService brandService = new BrandService();
                    brand = new Brand();
                    brand = brandService.GetActiveBrandByID(item.BrandID);
                    if (brand != null)
                    {
                        txtBrandCode.Text = brand.BrandCode.Trim();
                        txtBrandDescription.Text = brand.BrandName.Trim();
                    }
                    txtReOrderLevel.Text = item.ReOrderLevel.ToString();
                    txtReOrderQty.Text = item.ReOrderQty.ToString();

                    txtSellingPrice.Text = Common.ConvertToStringCurrancy(item.SellingPrice.ToString());
                    txtCostPrice.Text = Common.ConvertToStringCurrancy(item.CostPrice.ToString());
                    txtMarginPercentage.Text = Common.ConvertToStringCurrancy(item.MarginPercentage.ToString());
                    txtMaximumPrice.Text = Common.ConvertToStringCurrancy(item.MaximumPrice.ToString());
                    txtMinimumPrice.Text = Common.ConvertToStringCurrancy(item.MinimumPrice.ToString());
                    txtFixedDiscountPercentage.Text = Common.ConvertToStringCurrancy(item.FixedDiscountPercentage.ToString());
                    txtFixedDiscount.Text = Common.ConvertToStringCurrancy(item.FixedDiscount.ToString());

                    RetreveImage(item.ItemImage);

                    LoadItemSupplierList(item.ItemID);
                    LoadItemStock(item.ItemID);
                    LoadItemPriceList(item.ItemID);

                    txtThisLocationStock.Text = itemService.GetCurrentLocationStockByItemID(item.ItemID).ToString();

                    Common.ReadOnlyTextBox(true, txtItemCode);
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

        private void LoadItemSupplierList(long itemID)
        {
            try
            {
                ItemService itemService = new ItemService();
                itemSupplierList = itemService.GetItemSupplierListByItemID(itemID);
                dgvItemSupplier.DataSource = itemSupplierList;
                dgvItemSupplier.Refresh();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void LoadItemPriceList(long itemID)
        {
            try
            {
                ItemService itemService = new ItemService();
                itemPriceList = itemService.GetItemPriceListByItemID(itemID);
                dgvPriceLevel.DataSource = itemPriceList;
                dgvPriceLevel.Refresh();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void LoadItemStock(long itemID)
        {
            try
            {
                ItemService itemService = new ItemService();
                itemStockList = itemService.GetItemStockListByItemID(itemID);
                dgvItemStock.DataSource = itemStockList;
                dgvItemStock.Refresh();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void UpdateItemSupplierGrid(ItemSupplier itemSupplier)
        {
            try
            {
                ItemService itemService = new ItemService();

                SupplierService supplierService = new SupplierService();
                Supplier supplier = new Supplier();

                supplier = supplierService.GetActiveSupplierByName(txtSupplierDescription.Text.Trim());
                if (supplier != null)
                {
                    itemSupplier.SupplierCode = supplier.SupplierCode.Trim();
                    itemSupplier.SupplierName = supplier.SupplierName.Trim();
                    itemSupplier.SupplierID = supplier.SupplierID;

                    itemSupplierList = itemService.GetUpdatedItemSupplierList(itemSupplierList, itemSupplier);
                    dgvItemSupplier.DataSource = itemSupplierList;
                    dgvItemSupplier.Refresh();

                }
                Common.ClearTextBox(txtSupplierCode, txtSupplierDescription);
                txtSupplierCode.Focus();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void UpdateItemPriceGrid(ItemPrice itemPrice)
        {
            try
            {
                ItemService itemService = new ItemService();

                if (txtPriceLevelCost.Text != string.Empty && txtPriceLevelSelling.Text != string.Empty)
                {
                    itemPrice.CostPrice = Common.ConvertStringToDecimal(Common.ConvertToStringCurrancy(txtPriceLevelCost.Text.Trim()));
                    itemPrice.SellingPrice = Common.ConvertStringToDecimal(Common.ConvertToStringCurrancy(txtPriceLevelSelling.Text.Trim()));

                    itemPriceList = itemService.GetUpdatedItemPriceList(itemPriceList, itemPrice);
                    dgvPriceLevel.DataSource = itemPriceList;
                    dgvPriceLevel.Refresh();

                }
                Common.ClearTextBox(txtPriceLevelCost, txtPriceLevelSelling);
                txtPriceLevelCost.Focus();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
  
        private void CalculateMarginPercentage()
        {
            try
            {
                if (txtSellingPrice.Text != string.Empty && txtCostPrice.Text != string.Empty)
                {
                    decimal sellingPrice = 0;
                    decimal costPrice = 0;
                    decimal marginPercentage = 0;

                    sellingPrice = Common.ConvertStringToDecimal(txtSellingPrice.Text.Trim());
                    costPrice = Common.ConvertStringToDecimal(txtCostPrice.Text.Trim());

                    marginPercentage = Math.Round(((sellingPrice - costPrice) / costPrice) * 100, 2);

                    txtMarginPercentage.Text = Common.ConvertToStringCurrancy(marginPercentage.ToString());
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void CalculateSellingPrice()
        {
            try
            {
                if (txtCostPrice.Text != string.Empty && txtMarginPercentage.Text != string.Empty)
                {
                    decimal sellingPrice = 0;
                    decimal costPrice = 0;
                    decimal marginPercentage = 0;

                    marginPercentage = Common.ConvertStringToDecimal(txtMarginPercentage.Text.Trim());
                    costPrice = Common.ConvertStringToDecimal(txtCostPrice.Text.Trim());

                    sellingPrice = Math.Round(((marginPercentage / 100) * costPrice) + costPrice, 2, MidpointRounding.AwayFromZero);

                    txtSellingPrice.Text = Common.ConvertToStringCurrancy(sellingPrice.ToString());
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        #endregion

        #region Other
        private void dgvItemSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {

                    if (dgvItemSupplier.Rows.Count > 0)
                    {
                        if (dgvItemSupplier["SupplierCode", dgvItemSupplier.CurrentCell.RowIndex].Value.ToString() == string.Empty) { return; }
                        SupplierService supplierService = new SupplierService();
                        Supplier supplier = new Supplier();
                        supplier = supplierService.GetActiveSupplierByCode(dgvItemSupplier["SupplierCode", dgvItemSupplier.CurrentCell.RowIndex].Value.ToString());
                        if (supplier != null)
                        {

                            if (SysMessage.ShowMessage(SysMessage.MessageAction.Delete, SysMessage.MessageType.Question, this.Text, dgvItemSupplier["SupplierCode", dgvItemSupplier.CurrentCell.RowIndex].Value.ToString() + " - " + dgvItemSupplier["SupplierName", dgvItemSupplier.CurrentCell.RowIndex].Value.ToString()).Equals(DialogResult.No)) { return; };

                            ItemSupplier itemSupplier = new ItemSupplier();
                            ItemService itemService = new ItemService();

                            itemSupplier.SupplierID = supplier.SupplierID;
                            itemSupplierList = itemService.GetUpdatedItemSupplierListWithDelete(itemSupplierList, itemSupplier);
                            dgvItemSupplier.DataSource = itemSupplierList;
                            dgvItemSupplier.Refresh();

                        }
                    }
                }
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
                if (pbItem.Image != null)
                {
                    pbItem.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
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
        private void btnImageClear_Click(object sender, EventArgs e)
        {
            try
            {
                pbItem.Image = null;
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
                CaptureImage = frmWebCamera.captureImage;
                pbItem.SizeMode = PictureBoxSizeMode.StretchImage;
                pbItem.Image = CaptureImage;
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
                fileDialog.Filter = "Image File (*.jpg;*.bmp;*.gif;*.jpeg)|*.jpg;*.bmp;*.gif;*.jpeg";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    Bitmap newimg = new Bitmap(fileDialog.FileName);
                    pbItem.SizeMode = PictureBoxSizeMode.StretchImage;
                    Bitmap converted = new Bitmap((Image)newimg, new Size(400, 400));
                    pbItem.Image = (Image)converted;

                }
                fileDialog = null;

            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAutogenerate)
                {
                    ItemService itemService = new ItemService();
                    ItemCodeDependency itemCodeDependency = new ItemCodeDependency();
                    itemCodeDependency = itemService.GetCodeDependency(documentID);
                    if (itemCodeDependency != null)
                    {
                        if (!itemCodeDependency.IsDependCategoryCode && !itemCodeDependency.IsDependSubCategory1Code && !itemCodeDependency.IsDependSubCategory2Code && !itemCodeDependency.IsDependBrandCode)
                        {
                            txtItemCode.Text = itemService.GetNewCode(formInfo);
                            Common.ReadOnlyTextBox(true, txtItemCode);
                            txtItemName.Focus();
                        }
                        else if (itemCodeDependency.IsDependCategoryCode && itemCodeDependency.IsDependSubCategory1Code && itemCodeDependency.IsDependSubCategory2Code && itemCodeDependency.IsDependBrandCode)
                        {
                            if (category == null || category.CategoryID == 0)
                            {
                                SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Error, this.Text, "Please Select " + lblCategory.Text.Substring(0, lblCategory.Text.Length - 2) + ".");
                                txtCategoryCode.Focus();
                                return;
                            }
                            if (subCategory1 == null || subCategory1.SubCategory1ID == 0)
                            {
                                SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Error, this.Text, "Please Select " + lblSubCategory1.Text.Substring(0, lblSubCategory1.Text.Length - 2) + ".");
                                txtSubCategory1Code.Focus();
                                return;
                            }
                            if (subCategory2 == null || subCategory2.SubCategory2ID == 0)
                            {
                                SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Error, this.Text, "Please Select " + lblSubcategory2.Text.Substring(0, lblSubcategory2.Text.Length - 2) + ".");
                                txtSubCategory2Code.Focus();
                                return;
                            }
                            if (brand == null || brand.BrandID == 0)
                            {
                                SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Error, this.Text, "Please Select " + lblBrand.Text.Substring(0, lblBrand.Text.Length - 2) + ".");
                                txtBrandCode.Focus();
                                return;
                            }

                            string tempCode = itemService.GetNewDependancyCode(formInfo, category, subCategory1, subCategory2, brand);

                            txtItemCode.Text = category.CategoryCode.Trim() + subCategory1.SubCategory1Code.Trim() + subCategory2.SubCategory2Code.Trim() + brand.BrandCode.Trim() + tempCode;
                            txtReferenceCode1.Text = itemService.GetNewReferenceCode();

                            Common.ReadOnlyTextBox(true, txtItemCode, txtReferenceCode1, txtCategoryCode, txtCategoryDescription, txtSubCategory1Code, txtSubCategory1Description, txtSubCategory2Code, txtSubCategory2Description, txtBrandCode, txtBrandDescription);
                            txtItemName.Focus();
                        }
                        else
                        {
                            Common.ReadOnlyTextBox(false, txtItemCode);
                            txtItemCode.Focus();
                        }
                    }
                    else
                    {
                        txtItemCode.Text = itemService.GetNewDirectItemCode(formInfo.CodeLength);
                        Common.ReadOnlyTextBox(true, txtItemCode);
                        txtItemName.Focus();
                    }
                    Common.EnableButton(false, btnNew);
                    if (userPrivileges == null ? false : userPrivileges.IsSave) { Common.EnableButton(true, btnSave); }
                }
                else
                {
                    Common.EnableButton(false, btnNew);
                    if (userPrivileges == null ? false : userPrivileges.IsSave) { Common.EnableButton(true, btnSave); }
                    txtItemCode.Focus();
                }

                isNew = true;
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void tbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tbItem.SelectedTab == tbpPrice)
                {
                    txtSellingPrice.Focus();
                }
                else if (tbItem.SelectedTab == tbpSupplier)
                {
                    txtSupplierCode.Focus();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtSellingPrice_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                // CalculateMarginPercentage();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }

        private void txtCostPrice_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                CalculateMarginPercentage();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtMarginPercentage_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                // CalculateSellingPrice();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        #endregion

        private void txtPriceLevelCost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPriceLevelSelling.Focus();
            }
        }

        private void txtPriceLevelSelling_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ItemPrice itemPrice = new ItemPrice();
                    UpdateItemPriceGrid(itemPrice);
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void dgvPriceLevel_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {

                    if (dgvPriceLevel.Rows.Count > 0)
                    {
                        if (dgvPriceLevel["PriceLevelCost", dgvPriceLevel.CurrentCell.RowIndex].Value.ToString() == string.Empty) { return; }

                        if (SysMessage.ShowMessage(SysMessage.MessageAction.Delete, SysMessage.MessageType.Question, this.Text, dgvPriceLevel["PriceLevelCost", dgvPriceLevel.CurrentCell.RowIndex].Value.ToString() + " - " + dgvPriceLevel["PriceLevelSelling", dgvPriceLevel.CurrentCell.RowIndex].Value.ToString()).Equals(DialogResult.No)) { return; };

                        ItemPrice itemPrice = new ItemPrice();
                        ItemService itemService = new ItemService();
                        itemPrice.CostPrice = Common.ConvertStringToDecimal(dgvPriceLevel["PriceLevelCost", dgvPriceLevel.CurrentCell.RowIndex].Value.ToString());
                        itemPrice.SellingPrice = Common.ConvertStringToDecimal(dgvPriceLevel["PriceLevelSelling", dgvPriceLevel.CurrentCell.RowIndex].Value.ToString());

                        itemPriceList = itemService.GetUpdatedItemPriceListWithDelete(itemPriceList, itemPrice);
                        dgvPriceLevel.DataSource = itemPriceList;
                        dgvPriceLevel.Refresh();

                    }
                }

            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtFixedDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    tbItem.SelectedIndex = 1;
                    txtSupplierCode.Focus();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtSinhalaName_TextChanged(object sender, EventArgs e)
        {
            lblSinhalaName.Text = txtSinhalaName.Text.Trim();
        }

        private void pbItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmShowImage frmShowImage = new FrmShowImage(pbItem.Image);
                frmShowImage.ShowDialog();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (isNonClearValue)
                {
                    if (userPrivileges.IsSave)
                    {
                        Common.EnableButton(true, btnSave);
                    }
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
