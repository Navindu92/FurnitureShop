namespace NSoft.ERP.UI.Windows.Inventory
{
    partial class FrmItem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmItem));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtItemName = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.txtItemCode = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxMasterCode();
            this.btnNew = new NSoft.ERP.UI.Windows.Custom_Controllers.ButtonNew();
            this.lblItemCode = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lblItemName = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lblNameOnInvoice = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtNameOnInvoice = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.lblBarcode = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lblReferenceCode = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtReferenceCode1 = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.txtBarcode = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.grpProperty = new NSoft.ERP.UI.Windows.Custom_Controllers.GroupBoxCommon();
            this.lblBrand = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtBrandDescription = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.txtBrandCode = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxMasterCode();
            this.txtSubCategory2Description = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.txtSubCategory2Code = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxMasterCode();
            this.txtSubCategory1Description = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.txtSubCategory1Code = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxMasterCode();
            this.lblSubcategory2 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lblSubCategory1 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lblCategory = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtCategoryDescription = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.txtCategoryCode = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxMasterCode();
            this.btnImageClear = new System.Windows.Forms.Button();
            this.btnCamera = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.pbItem = new System.Windows.Forms.PictureBox();
            this.grpReOrder = new NSoft.ERP.UI.Windows.Custom_Controllers.GroupBoxCommon();
            this.txtReOrderQty = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxInteger();
            this.txtReOrderLevel = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxInteger();
            this.lblReOrderQty = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lblReOrderLevel = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.tbItem = new System.Windows.Forms.TabControl();
            this.tbpPrice = new System.Windows.Forms.TabPage();
            this.lableCommon4 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtFixedDiscount = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.lblFixedDiscount = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtFixedDiscountPercentage = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.lblMargin = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtMarginPercentage = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.lblMinimumPrice = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtMinimumPrice = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.lblCostPrice = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtCostPrice = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.lblMaximumPrice = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtMaximumPrice = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.lblSellingPrice = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtSellingPrice = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.tbpStock = new System.Windows.Forms.TabPage();
            this.dgvItemStock = new NSoft.ERP.UI.Windows.Custom_Controllers.GridViewCommon();
            this.LocationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbpSupplier = new System.Windows.Forms.TabPage();
            this.txtSupplierDescription = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.txtSupplierCode = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxMasterCode();
            this.dgvItemSupplier = new NSoft.ERP.UI.Windows.Custom_Controllers.GridViewCommon();
            this.SupplierCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtPriceLevelSelling = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.txtPriceLevelCost = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.dgvPriceLevel = new NSoft.ERP.UI.Windows.Custom_Controllers.GridViewCommon();
            this.PriceLevelCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceLevelSelling = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtThisLocationStock = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxMasterCode();
            this.lblLabReferenceNo = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.groupBoxCommon1 = new NSoft.ERP.UI.Windows.Custom_Controllers.GroupBoxCommon();
            this.chkClearValues = new System.Windows.Forms.CheckBox();
            this.chkIsCountable = new System.Windows.Forms.CheckBox();
            this.lableCommon1 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtReferenceCode2 = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.lableCommon2 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtReferenceCode3 = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.lableCommon3 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lblSinhalaName = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtSinhalaName = new System.Windows.Forms.TextBox();
            this.grbMargin.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.grpProperty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbItem)).BeginInit();
            this.grpReOrder.SuspendLayout();
            this.tbItem.SuspendLayout();
            this.tbpPrice.SuspendLayout();
            this.tbpStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemStock)).BeginInit();
            this.tbpSupplier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemSupplier)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceLevel)).BeginInit();
            this.groupBoxCommon1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbMargin
            // 
            this.grbMargin.Controls.Add(this.txtSinhalaName);
            this.grbMargin.Controls.Add(this.lblSinhalaName);
            this.grbMargin.Controls.Add(this.txtReferenceCode3);
            this.grbMargin.Controls.Add(this.lableCommon3);
            this.grbMargin.Controls.Add(this.txtReferenceCode2);
            this.grbMargin.Controls.Add(this.lableCommon1);
            this.grbMargin.Controls.Add(this.lableCommon2);
            this.grbMargin.Controls.Add(this.groupBoxCommon1);
            this.grbMargin.Controls.Add(this.lblLabReferenceNo);
            this.grbMargin.Controls.Add(this.txtThisLocationStock);
            this.grbMargin.Controls.Add(this.tbItem);
            this.grbMargin.Controls.Add(this.btnImageClear);
            this.grbMargin.Controls.Add(this.btnCamera);
            this.grbMargin.Controls.Add(this.btnBrowse);
            this.grbMargin.Controls.Add(this.pbItem);
            this.grbMargin.Controls.Add(this.txtBarcode);
            this.grbMargin.Controls.Add(this.txtReferenceCode1);
            this.grbMargin.Controls.Add(this.lblReferenceCode);
            this.grbMargin.Controls.Add(this.lblBarcode);
            this.grbMargin.Controls.Add(this.lblNameOnInvoice);
            this.grbMargin.Controls.Add(this.txtNameOnInvoice);
            this.grbMargin.Controls.Add(this.lblItemName);
            this.grbMargin.Controls.Add(this.lblItemCode);
            this.grbMargin.Controls.Add(this.txtItemName);
            this.grbMargin.Controls.Add(this.chkActive);
            this.grbMargin.Controls.Add(this.txtItemCode);
            this.grbMargin.Controls.Add(this.btnNew);
            this.grbMargin.Controls.Add(this.grpProperty);
            this.grbMargin.Controls.Add(this.grpReOrder);
            this.grbMargin.Location = new System.Drawing.Point(2, -4);
            this.grbMargin.Size = new System.Drawing.Size(721, 548);
            this.grbMargin.Controls.SetChildIndex(this.groupBox1, 0);
            this.grbMargin.Controls.SetChildIndex(this.grpReOrder, 0);
            this.grbMargin.Controls.SetChildIndex(this.grpProperty, 0);
            this.grbMargin.Controls.SetChildIndex(this.btnNew, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtItemCode, 0);
            this.grbMargin.Controls.SetChildIndex(this.chkActive, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtItemName, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblItemCode, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblItemName, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtNameOnInvoice, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblNameOnInvoice, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblBarcode, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblReferenceCode, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtReferenceCode1, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtBarcode, 0);
            this.grbMargin.Controls.SetChildIndex(this.pbItem, 0);
            this.grbMargin.Controls.SetChildIndex(this.btnBrowse, 0);
            this.grbMargin.Controls.SetChildIndex(this.btnCamera, 0);
            this.grbMargin.Controls.SetChildIndex(this.btnImageClear, 0);
            this.grbMargin.Controls.SetChildIndex(this.tbItem, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtThisLocationStock, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblLabReferenceNo, 0);
            this.grbMargin.Controls.SetChildIndex(this.groupBoxCommon1, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon2, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon1, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtReferenceCode2, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon3, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtReferenceCode3, 0);
            this.grbMargin.Controls.SetChildIndex(this.groupBox2, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblSinhalaName, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtSinhalaName, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(4, 496);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(513, 496);
            // 
            // txtItemName
            // 
            this.txtItemName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(139, 39);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(289, 21);
            this.txtItemName.TabIndex = 32;
            this.txtItemName.TextChanged += new System.EventHandler(this.txtItemName_TextChanged);
            this.txtItemName.Enter += new System.EventHandler(this.txtItemName_Enter);
            this.txtItemName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemName_KeyDown);
            this.txtItemName.Leave += new System.EventHandler(this.txtItemName_Leave);
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(326, 15);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(61, 17);
            this.chkActive.TabIndex = 31;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // txtItemCode
            // 
            this.txtItemCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCode.Location = new System.Drawing.Point(139, 12);
            this.txtItemCode.MaxLength = 20;
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(131, 21);
            this.txtItemCode.TabIndex = 30;
            this.txtItemCode.Enter += new System.EventHandler(this.txtItemCode_Enter);
            this.txtItemCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemCode_KeyDown);
            this.txtItemCode.Leave += new System.EventHandler(this.txtItemCode_Leave);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(270, 11);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(50, 23);
            this.btnNew.TabIndex = 29;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // lblItemCode
            // 
            this.lblItemCode.AutoSize = true;
            this.lblItemCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemCode.Location = new System.Drawing.Point(8, 15);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(79, 13);
            this.lblItemCode.TabIndex = 85;
            this.lblItemCode.Text = "Item Code *";
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.Location = new System.Drawing.Point(8, 42);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(82, 13);
            this.lblItemName.TabIndex = 86;
            this.lblItemName.Text = "Item Name *";
            // 
            // lblNameOnInvoice
            // 
            this.lblNameOnInvoice.AutoSize = true;
            this.lblNameOnInvoice.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameOnInvoice.Location = new System.Drawing.Point(8, 69);
            this.lblNameOnInvoice.Name = "lblNameOnInvoice";
            this.lblNameOnInvoice.Size = new System.Drawing.Size(117, 13);
            this.lblNameOnInvoice.TabIndex = 88;
            this.lblNameOnInvoice.Text = "Name On Invoice *";
            // 
            // txtNameOnInvoice
            // 
            this.txtNameOnInvoice.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameOnInvoice.Location = new System.Drawing.Point(139, 66);
            this.txtNameOnInvoice.Name = "txtNameOnInvoice";
            this.txtNameOnInvoice.Size = new System.Drawing.Size(289, 21);
            this.txtNameOnInvoice.TabIndex = 87;
            this.txtNameOnInvoice.Enter += new System.EventHandler(this.txtNameOnInvoice_Enter);
            this.txtNameOnInvoice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNameOnInvoice_KeyDown);
            this.txtNameOnInvoice.Leave += new System.EventHandler(this.txtNameOnInvoice_Leave);
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarcode.Location = new System.Drawing.Point(434, 15);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(54, 13);
            this.lblBarcode.TabIndex = 89;
            this.lblBarcode.Text = "Barcode";
            // 
            // lblReferenceCode
            // 
            this.lblReferenceCode.AutoSize = true;
            this.lblReferenceCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReferenceCode.Location = new System.Drawing.Point(434, 42);
            this.lblReferenceCode.Name = "lblReferenceCode";
            this.lblReferenceCode.Size = new System.Drawing.Size(110, 13);
            this.lblReferenceCode.TabIndex = 90;
            this.lblReferenceCode.Text = "Reference Code 1";
            // 
            // txtReferenceCode1
            // 
            this.txtReferenceCode1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReferenceCode1.Location = new System.Drawing.Point(543, 39);
            this.txtReferenceCode1.Name = "txtReferenceCode1";
            this.txtReferenceCode1.Size = new System.Drawing.Size(170, 21);
            this.txtReferenceCode1.TabIndex = 91;
            this.txtReferenceCode1.Enter += new System.EventHandler(this.txtReferenceCode1_Enter);
            this.txtReferenceCode1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReferenceCode1_KeyDown);
            this.txtReferenceCode1.Leave += new System.EventHandler(this.txtReferenceCode1_Leave);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.Location = new System.Drawing.Point(543, 12);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(170, 21);
            this.txtBarcode.TabIndex = 92;
            this.txtBarcode.Enter += new System.EventHandler(this.txtBarcode_Enter);
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            this.txtBarcode.Leave += new System.EventHandler(this.txtBarcode_Leave);
            // 
            // grpProperty
            // 
            this.grpProperty.Controls.Add(this.lblBrand);
            this.grpProperty.Controls.Add(this.txtBrandDescription);
            this.grpProperty.Controls.Add(this.txtBrandCode);
            this.grpProperty.Controls.Add(this.txtSubCategory2Description);
            this.grpProperty.Controls.Add(this.txtSubCategory2Code);
            this.grpProperty.Controls.Add(this.txtSubCategory1Description);
            this.grpProperty.Controls.Add(this.txtSubCategory1Code);
            this.grpProperty.Controls.Add(this.lblSubcategory2);
            this.grpProperty.Controls.Add(this.lblSubCategory1);
            this.grpProperty.Controls.Add(this.lblCategory);
            this.grpProperty.Controls.Add(this.txtCategoryDescription);
            this.grpProperty.Controls.Add(this.txtCategoryCode);
            this.grpProperty.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpProperty.Location = new System.Drawing.Point(4, 132);
            this.grpProperty.Name = "grpProperty";
            this.grpProperty.Size = new System.Drawing.Size(565, 124);
            this.grpProperty.TabIndex = 93;
            this.grpProperty.TabStop = false;
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrand.Location = new System.Drawing.Point(6, 98);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(52, 13);
            this.lblBrand.TabIndex = 103;
            this.lblBrand.Text = "Brand *";
            // 
            // txtBrandDescription
            // 
            this.txtBrandDescription.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBrandDescription.Location = new System.Drawing.Point(268, 95);
            this.txtBrandDescription.Name = "txtBrandDescription";
            this.txtBrandDescription.Size = new System.Drawing.Size(291, 21);
            this.txtBrandDescription.TabIndex = 102;
            this.txtBrandDescription.Enter += new System.EventHandler(this.txtBrandDescription_Enter);
            this.txtBrandDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBrandDescription_KeyDown);
            this.txtBrandDescription.Leave += new System.EventHandler(this.txtBrandDescription_Leave);
            // 
            // txtBrandCode
            // 
            this.txtBrandCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBrandCode.Location = new System.Drawing.Point(135, 95);
            this.txtBrandCode.MaxLength = 10;
            this.txtBrandCode.Name = "txtBrandCode";
            this.txtBrandCode.Size = new System.Drawing.Size(131, 21);
            this.txtBrandCode.TabIndex = 101;
            this.txtBrandCode.Enter += new System.EventHandler(this.txtBrandCode_Enter);
            this.txtBrandCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBrandCode_KeyDown);
            this.txtBrandCode.Leave += new System.EventHandler(this.txtBrandCode_Leave);
            // 
            // txtSubCategory2Description
            // 
            this.txtSubCategory2Description.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubCategory2Description.Location = new System.Drawing.Point(268, 68);
            this.txtSubCategory2Description.Name = "txtSubCategory2Description";
            this.txtSubCategory2Description.Size = new System.Drawing.Size(291, 21);
            this.txtSubCategory2Description.TabIndex = 100;
            this.txtSubCategory2Description.Enter += new System.EventHandler(this.txtSubCategory2Description_Enter);
            this.txtSubCategory2Description.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSubCategory2Description_KeyDown);
            this.txtSubCategory2Description.Leave += new System.EventHandler(this.txtSubCategory2Description_Leave);
            // 
            // txtSubCategory2Code
            // 
            this.txtSubCategory2Code.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubCategory2Code.Location = new System.Drawing.Point(135, 68);
            this.txtSubCategory2Code.MaxLength = 10;
            this.txtSubCategory2Code.Name = "txtSubCategory2Code";
            this.txtSubCategory2Code.Size = new System.Drawing.Size(131, 21);
            this.txtSubCategory2Code.TabIndex = 99;
            this.txtSubCategory2Code.Enter += new System.EventHandler(this.txtSubCategory2Code_Enter);
            this.txtSubCategory2Code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSubCategory2Code_KeyDown);
            this.txtSubCategory2Code.Leave += new System.EventHandler(this.txtSubCategory2Code_Leave);
            // 
            // txtSubCategory1Description
            // 
            this.txtSubCategory1Description.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubCategory1Description.Location = new System.Drawing.Point(268, 41);
            this.txtSubCategory1Description.Name = "txtSubCategory1Description";
            this.txtSubCategory1Description.Size = new System.Drawing.Size(291, 21);
            this.txtSubCategory1Description.TabIndex = 98;
            this.txtSubCategory1Description.Enter += new System.EventHandler(this.txtSubCategory1Description_Enter);
            this.txtSubCategory1Description.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSubCategory1Description_KeyDown);
            this.txtSubCategory1Description.Leave += new System.EventHandler(this.txtSubCategory1Description_Leave);
            // 
            // txtSubCategory1Code
            // 
            this.txtSubCategory1Code.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubCategory1Code.Location = new System.Drawing.Point(135, 41);
            this.txtSubCategory1Code.MaxLength = 10;
            this.txtSubCategory1Code.Name = "txtSubCategory1Code";
            this.txtSubCategory1Code.Size = new System.Drawing.Size(131, 21);
            this.txtSubCategory1Code.TabIndex = 97;
            this.txtSubCategory1Code.Enter += new System.EventHandler(this.txtSubCategory1Code_Enter);
            this.txtSubCategory1Code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSubCategory1Code_KeyDown);
            this.txtSubCategory1Code.Leave += new System.EventHandler(this.txtSubCategory1Code_Leave);
            // 
            // lblSubcategory2
            // 
            this.lblSubcategory2.AutoSize = true;
            this.lblSubcategory2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubcategory2.Location = new System.Drawing.Point(6, 71);
            this.lblSubcategory2.Name = "lblSubcategory2";
            this.lblSubcategory2.Size = new System.Drawing.Size(104, 13);
            this.lblSubcategory2.TabIndex = 96;
            this.lblSubcategory2.Text = "Sub Category2 *";
            // 
            // lblSubCategory1
            // 
            this.lblSubCategory1.AutoSize = true;
            this.lblSubCategory1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubCategory1.Location = new System.Drawing.Point(6, 44);
            this.lblSubCategory1.Name = "lblSubCategory1";
            this.lblSubCategory1.Size = new System.Drawing.Size(97, 13);
            this.lblSubCategory1.TabIndex = 95;
            this.lblSubCategory1.Text = "Sub Category *";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(6, 17);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(71, 13);
            this.lblCategory.TabIndex = 94;
            this.lblCategory.Text = "Category *";
            // 
            // txtCategoryDescription
            // 
            this.txtCategoryDescription.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoryDescription.Location = new System.Drawing.Point(268, 14);
            this.txtCategoryDescription.Name = "txtCategoryDescription";
            this.txtCategoryDescription.Size = new System.Drawing.Size(291, 21);
            this.txtCategoryDescription.TabIndex = 13;
            this.txtCategoryDescription.Enter += new System.EventHandler(this.txtCategoryDescription_Enter);
            this.txtCategoryDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCategoryDescription_KeyDown);
            this.txtCategoryDescription.Leave += new System.EventHandler(this.txtCategoryDescription_Leave);
            // 
            // txtCategoryCode
            // 
            this.txtCategoryCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoryCode.Location = new System.Drawing.Point(135, 14);
            this.txtCategoryCode.MaxLength = 10;
            this.txtCategoryCode.Name = "txtCategoryCode";
            this.txtCategoryCode.Size = new System.Drawing.Size(131, 21);
            this.txtCategoryCode.TabIndex = 10;
            this.txtCategoryCode.Enter += new System.EventHandler(this.txtCategoryCode_Enter);
            this.txtCategoryCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCategoryCode_KeyDown);
            this.txtCategoryCode.Leave += new System.EventHandler(this.txtCategoryCode_Leave);
            // 
            // btnImageClear
            // 
            this.btnImageClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImageClear.BackgroundImage")));
            this.btnImageClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImageClear.Location = new System.Drawing.Point(663, 265);
            this.btnImageClear.Name = "btnImageClear";
            this.btnImageClear.Size = new System.Drawing.Size(35, 30);
            this.btnImageClear.TabIndex = 97;
            this.btnImageClear.UseVisualStyleBackColor = true;
            this.btnImageClear.Click += new System.EventHandler(this.btnImageClear_Click);
            // 
            // btnCamera
            // 
            this.btnCamera.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCamera.BackgroundImage")));
            this.btnCamera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCamera.Location = new System.Drawing.Point(622, 265);
            this.btnCamera.Name = "btnCamera";
            this.btnCamera.Size = new System.Drawing.Size(35, 30);
            this.btnCamera.TabIndex = 96;
            this.btnCamera.UseVisualStyleBackColor = true;
            this.btnCamera.Click += new System.EventHandler(this.btnCamera_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBrowse.BackgroundImage")));
            this.btnBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBrowse.Location = new System.Drawing.Point(581, 265);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(35, 30);
            this.btnBrowse.TabIndex = 95;
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // pbItem
            // 
            this.pbItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbItem.Location = new System.Drawing.Point(575, 121);
            this.pbItem.Name = "pbItem";
            this.pbItem.Size = new System.Drawing.Size(131, 135);
            this.pbItem.TabIndex = 94;
            this.pbItem.TabStop = false;
            this.pbItem.Click += new System.EventHandler(this.pbItem_Click);
            // 
            // grpReOrder
            // 
            this.grpReOrder.Controls.Add(this.txtReOrderQty);
            this.grpReOrder.Controls.Add(this.txtReOrderLevel);
            this.grpReOrder.Controls.Add(this.lblReOrderQty);
            this.grpReOrder.Controls.Add(this.lblReOrderLevel);
            this.grpReOrder.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpReOrder.Location = new System.Drawing.Point(4, 251);
            this.grpReOrder.Name = "grpReOrder";
            this.grpReOrder.Size = new System.Drawing.Size(565, 38);
            this.grpReOrder.TabIndex = 98;
            this.grpReOrder.TabStop = false;
            // 
            // txtReOrderQty
            // 
            this.txtReOrderQty.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReOrderQty.Location = new System.Drawing.Point(428, 12);
            this.txtReOrderQty.Name = "txtReOrderQty";
            this.txtReOrderQty.Size = new System.Drawing.Size(131, 21);
            this.txtReOrderQty.TabIndex = 106;
            this.txtReOrderQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtReOrderQty.Enter += new System.EventHandler(this.txtReOrderQty_Enter);
            this.txtReOrderQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReOrderQty_KeyDown);
            this.txtReOrderQty.Leave += new System.EventHandler(this.txtReOrderQty_Leave);
            // 
            // txtReOrderLevel
            // 
            this.txtReOrderLevel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReOrderLevel.Location = new System.Drawing.Point(135, 12);
            this.txtReOrderLevel.Name = "txtReOrderLevel";
            this.txtReOrderLevel.Size = new System.Drawing.Size(131, 21);
            this.txtReOrderLevel.TabIndex = 99;
            this.txtReOrderLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtReOrderLevel.Enter += new System.EventHandler(this.txtReOrderLevel_Enter);
            this.txtReOrderLevel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReOrderLevel_KeyDown);
            this.txtReOrderLevel.Leave += new System.EventHandler(this.txtReOrderLevel_Leave);
            // 
            // lblReOrderQty
            // 
            this.lblReOrderQty.AutoSize = true;
            this.lblReOrderQty.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReOrderQty.Location = new System.Drawing.Point(338, 15);
            this.lblReOrderQty.Name = "lblReOrderQty";
            this.lblReOrderQty.Size = new System.Drawing.Size(83, 13);
            this.lblReOrderQty.TabIndex = 105;
            this.lblReOrderQty.Text = "Re Order Qty";
            // 
            // lblReOrderLevel
            // 
            this.lblReOrderLevel.AutoSize = true;
            this.lblReOrderLevel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReOrderLevel.Location = new System.Drawing.Point(6, 15);
            this.lblReOrderLevel.Name = "lblReOrderLevel";
            this.lblReOrderLevel.Size = new System.Drawing.Size(93, 13);
            this.lblReOrderLevel.TabIndex = 104;
            this.lblReOrderLevel.Text = "Re Order Level";
            // 
            // tbItem
            // 
            this.tbItem.Controls.Add(this.tbpPrice);
            this.tbItem.Controls.Add(this.tbpStock);
            this.tbItem.Controls.Add(this.tbpSupplier);
            this.tbItem.Controls.Add(this.tabPage1);
            this.tbItem.Location = new System.Drawing.Point(4, 296);
            this.tbItem.Name = "tbItem";
            this.tbItem.SelectedIndex = 0;
            this.tbItem.Size = new System.Drawing.Size(565, 201);
            this.tbItem.TabIndex = 99;
            this.tbItem.SelectedIndexChanged += new System.EventHandler(this.tbItem_SelectedIndexChanged);
            // 
            // tbpPrice
            // 
            this.tbpPrice.Controls.Add(this.lableCommon4);
            this.tbpPrice.Controls.Add(this.txtFixedDiscount);
            this.tbpPrice.Controls.Add(this.lblFixedDiscount);
            this.tbpPrice.Controls.Add(this.txtFixedDiscountPercentage);
            this.tbpPrice.Controls.Add(this.lblMargin);
            this.tbpPrice.Controls.Add(this.txtMarginPercentage);
            this.tbpPrice.Controls.Add(this.lblMinimumPrice);
            this.tbpPrice.Controls.Add(this.txtMinimumPrice);
            this.tbpPrice.Controls.Add(this.lblCostPrice);
            this.tbpPrice.Controls.Add(this.txtCostPrice);
            this.tbpPrice.Controls.Add(this.lblMaximumPrice);
            this.tbpPrice.Controls.Add(this.txtMaximumPrice);
            this.tbpPrice.Controls.Add(this.lblSellingPrice);
            this.tbpPrice.Controls.Add(this.txtSellingPrice);
            this.tbpPrice.Location = new System.Drawing.Point(4, 22);
            this.tbpPrice.Name = "tbpPrice";
            this.tbpPrice.Padding = new System.Windows.Forms.Padding(3);
            this.tbpPrice.Size = new System.Drawing.Size(557, 175);
            this.tbpPrice.TabIndex = 0;
            this.tbpPrice.Text = "Price";
            this.tbpPrice.UseVisualStyleBackColor = true;
            // 
            // lableCommon4
            // 
            this.lableCommon4.AutoSize = true;
            this.lableCommon4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon4.Location = new System.Drawing.Point(286, 100);
            this.lableCommon4.Name = "lableCommon4";
            this.lableCommon4.Size = new System.Drawing.Size(90, 13);
            this.lableCommon4.TabIndex = 119;
            this.lableCommon4.Text = "Fixed Discount";
            // 
            // txtFixedDiscount
            // 
            this.txtFixedDiscount.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtFixedDiscount.Location = new System.Drawing.Point(407, 97);
            this.txtFixedDiscount.Name = "txtFixedDiscount";
            this.txtFixedDiscount.Size = new System.Drawing.Size(131, 21);
            this.txtFixedDiscount.TabIndex = 118;
            this.txtFixedDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFixedDiscount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFixedDiscount_KeyDown);
            // 
            // lblFixedDiscount
            // 
            this.lblFixedDiscount.AutoSize = true;
            this.lblFixedDiscount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFixedDiscount.Location = new System.Drawing.Point(286, 73);
            this.lblFixedDiscount.Name = "lblFixedDiscount";
            this.lblFixedDiscount.Size = new System.Drawing.Size(106, 13);
            this.lblFixedDiscount.TabIndex = 117;
            this.lblFixedDiscount.Text = "Fixed Discount %";
            // 
            // txtFixedDiscountPercentage
            // 
            this.txtFixedDiscountPercentage.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtFixedDiscountPercentage.Location = new System.Drawing.Point(407, 70);
            this.txtFixedDiscountPercentage.Name = "txtFixedDiscountPercentage";
            this.txtFixedDiscountPercentage.Size = new System.Drawing.Size(131, 21);
            this.txtFixedDiscountPercentage.TabIndex = 116;
            this.txtFixedDiscountPercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFixedDiscountPercentage.Enter += new System.EventHandler(this.txtFixedDiscountPercentage_Enter);
            this.txtFixedDiscountPercentage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFixedDiscountPercentage_KeyDown);
            this.txtFixedDiscountPercentage.Leave += new System.EventHandler(this.txtFixedDiscountPercentage_Leave);
            // 
            // lblMargin
            // 
            this.lblMargin.AutoSize = true;
            this.lblMargin.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMargin.Location = new System.Drawing.Point(2, 74);
            this.lblMargin.Name = "lblMargin";
            this.lblMargin.Size = new System.Drawing.Size(76, 13);
            this.lblMargin.TabIndex = 115;
            this.lblMargin.Text = "Markup % *";
            // 
            // txtMarginPercentage
            // 
            this.txtMarginPercentage.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtMarginPercentage.Location = new System.Drawing.Point(127, 70);
            this.txtMarginPercentage.Name = "txtMarginPercentage";
            this.txtMarginPercentage.ReadOnly = true;
            this.txtMarginPercentage.Size = new System.Drawing.Size(131, 21);
            this.txtMarginPercentage.TabIndex = 114;
            this.txtMarginPercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMarginPercentage.Enter += new System.EventHandler(this.txtMarginPercentage_Enter);
            this.txtMarginPercentage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMarginPercentage_KeyDown);
            this.txtMarginPercentage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMarginPercentage_KeyUp);
            this.txtMarginPercentage.Leave += new System.EventHandler(this.txtMarginPercentage_Leave);
            // 
            // lblMinimumPrice
            // 
            this.lblMinimumPrice.AutoSize = true;
            this.lblMinimumPrice.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinimumPrice.Location = new System.Drawing.Point(286, 46);
            this.lblMinimumPrice.Name = "lblMinimumPrice";
            this.lblMinimumPrice.Size = new System.Drawing.Size(101, 13);
            this.lblMinimumPrice.TabIndex = 113;
            this.lblMinimumPrice.Text = "Minimum Price *";
            // 
            // txtMinimumPrice
            // 
            this.txtMinimumPrice.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtMinimumPrice.Location = new System.Drawing.Point(407, 43);
            this.txtMinimumPrice.Name = "txtMinimumPrice";
            this.txtMinimumPrice.Size = new System.Drawing.Size(131, 21);
            this.txtMinimumPrice.TabIndex = 112;
            this.txtMinimumPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMinimumPrice.Enter += new System.EventHandler(this.txtMinimumPrice_Enter);
            this.txtMinimumPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMinimumPrice_KeyDown);
            this.txtMinimumPrice.Leave += new System.EventHandler(this.txtMinimumPrice_Leave);
            // 
            // lblCostPrice
            // 
            this.lblCostPrice.AutoSize = true;
            this.lblCostPrice.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostPrice.Location = new System.Drawing.Point(2, 46);
            this.lblCostPrice.Name = "lblCostPrice";
            this.lblCostPrice.Size = new System.Drawing.Size(76, 13);
            this.lblCostPrice.TabIndex = 111;
            this.lblCostPrice.Text = "Cost Price *";
            // 
            // txtCostPrice
            // 
            this.txtCostPrice.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtCostPrice.Location = new System.Drawing.Point(127, 43);
            this.txtCostPrice.Name = "txtCostPrice";
            this.txtCostPrice.Size = new System.Drawing.Size(131, 21);
            this.txtCostPrice.TabIndex = 110;
            this.txtCostPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCostPrice.Enter += new System.EventHandler(this.txtCostPrice_Enter);
            this.txtCostPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCostPrice_KeyDown);
            this.txtCostPrice.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCostPrice_KeyUp);
            this.txtCostPrice.Leave += new System.EventHandler(this.txtCostPrice_Leave);
            // 
            // lblMaximumPrice
            // 
            this.lblMaximumPrice.AutoSize = true;
            this.lblMaximumPrice.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaximumPrice.Location = new System.Drawing.Point(286, 19);
            this.lblMaximumPrice.Name = "lblMaximumPrice";
            this.lblMaximumPrice.Size = new System.Drawing.Size(105, 13);
            this.lblMaximumPrice.TabIndex = 109;
            this.lblMaximumPrice.Text = "Maximum Price *";
            // 
            // txtMaximumPrice
            // 
            this.txtMaximumPrice.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtMaximumPrice.Location = new System.Drawing.Point(407, 16);
            this.txtMaximumPrice.Name = "txtMaximumPrice";
            this.txtMaximumPrice.Size = new System.Drawing.Size(131, 21);
            this.txtMaximumPrice.TabIndex = 108;
            this.txtMaximumPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMaximumPrice.Enter += new System.EventHandler(this.txtMaximumPrice_Enter);
            this.txtMaximumPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaximumPrice_KeyDown);
            this.txtMaximumPrice.Leave += new System.EventHandler(this.txtMaximumPrice_Leave);
            // 
            // lblSellingPrice
            // 
            this.lblSellingPrice.AutoSize = true;
            this.lblSellingPrice.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSellingPrice.Location = new System.Drawing.Point(2, 19);
            this.lblSellingPrice.Name = "lblSellingPrice";
            this.lblSellingPrice.Size = new System.Drawing.Size(88, 13);
            this.lblSellingPrice.TabIndex = 107;
            this.lblSellingPrice.Text = "Selling Price *";
            // 
            // txtSellingPrice
            // 
            this.txtSellingPrice.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtSellingPrice.Location = new System.Drawing.Point(127, 16);
            this.txtSellingPrice.Name = "txtSellingPrice";
            this.txtSellingPrice.Size = new System.Drawing.Size(131, 21);
            this.txtSellingPrice.TabIndex = 43;
            this.txtSellingPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSellingPrice.Enter += new System.EventHandler(this.txtSellingPrice_Enter);
            this.txtSellingPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSellingPrice_KeyDown);
            this.txtSellingPrice.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSellingPrice_KeyUp);
            this.txtSellingPrice.Leave += new System.EventHandler(this.txtSellingPrice_Leave);
            // 
            // tbpStock
            // 
            this.tbpStock.Controls.Add(this.dgvItemStock);
            this.tbpStock.Location = new System.Drawing.Point(4, 22);
            this.tbpStock.Name = "tbpStock";
            this.tbpStock.Padding = new System.Windows.Forms.Padding(3);
            this.tbpStock.Size = new System.Drawing.Size(557, 175);
            this.tbpStock.TabIndex = 3;
            this.tbpStock.Text = "Stock";
            this.tbpStock.UseVisualStyleBackColor = true;
            // 
            // dgvItemStock
            // 
            this.dgvItemStock.AllowUserToAddRows = false;
            this.dgvItemStock.AllowUserToDeleteRows = false;
            this.dgvItemStock.AllowUserToResizeColumns = false;
            this.dgvItemStock.AllowUserToResizeRows = false;
            this.dgvItemStock.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvItemStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LocationName,
            this.Stock});
            this.dgvItemStock.Location = new System.Drawing.Point(6, 7);
            this.dgvItemStock.Name = "dgvItemStock";
            this.dgvItemStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItemStock.Size = new System.Drawing.Size(545, 165);
            this.dgvItemStock.TabIndex = 121;
            // 
            // LocationName
            // 
            this.LocationName.DataPropertyName = "LocationName";
            this.LocationName.HeaderText = "Location";
            this.LocationName.Name = "LocationName";
            this.LocationName.ReadOnly = true;
            this.LocationName.Width = 300;
            // 
            // Stock
            // 
            this.Stock.DataPropertyName = "Stock";
            this.Stock.HeaderText = "Stock";
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            this.Stock.Width = 120;
            // 
            // tbpSupplier
            // 
            this.tbpSupplier.Controls.Add(this.txtSupplierDescription);
            this.tbpSupplier.Controls.Add(this.txtSupplierCode);
            this.tbpSupplier.Controls.Add(this.dgvItemSupplier);
            this.tbpSupplier.Location = new System.Drawing.Point(4, 22);
            this.tbpSupplier.Name = "tbpSupplier";
            this.tbpSupplier.Padding = new System.Windows.Forms.Padding(3);
            this.tbpSupplier.Size = new System.Drawing.Size(557, 175);
            this.tbpSupplier.TabIndex = 1;
            this.tbpSupplier.Text = "Supplier";
            this.tbpSupplier.UseVisualStyleBackColor = true;
            // 
            // txtSupplierDescription
            // 
            this.txtSupplierDescription.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierDescription.Location = new System.Drawing.Point(184, 147);
            this.txtSupplierDescription.Name = "txtSupplierDescription";
            this.txtSupplierDescription.Size = new System.Drawing.Size(367, 21);
            this.txtSupplierDescription.TabIndex = 27;
            this.txtSupplierDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSupplierDescription_KeyDown);
            this.txtSupplierDescription.Leave += new System.EventHandler(this.txtSupplierDescription_Leave);
            // 
            // txtSupplierCode
            // 
            this.txtSupplierCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierCode.Location = new System.Drawing.Point(6, 147);
            this.txtSupplierCode.MaxLength = 10;
            this.txtSupplierCode.Name = "txtSupplierCode";
            this.txtSupplierCode.Size = new System.Drawing.Size(177, 21);
            this.txtSupplierCode.TabIndex = 121;
            this.txtSupplierCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSupplierCode_KeyDown);
            this.txtSupplierCode.Leave += new System.EventHandler(this.txtSupplierCode_Leave);
            // 
            // dgvItemSupplier
            // 
            this.dgvItemSupplier.AllowUserToAddRows = false;
            this.dgvItemSupplier.AllowUserToDeleteRows = false;
            this.dgvItemSupplier.AllowUserToResizeColumns = false;
            this.dgvItemSupplier.AllowUserToResizeRows = false;
            this.dgvItemSupplier.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvItemSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemSupplier.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SupplierCode,
            this.SupplierName});
            this.dgvItemSupplier.Location = new System.Drawing.Point(6, 7);
            this.dgvItemSupplier.Name = "dgvItemSupplier";
            this.dgvItemSupplier.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItemSupplier.Size = new System.Drawing.Size(545, 136);
            this.dgvItemSupplier.TabIndex = 120;
            this.dgvItemSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvItemSupplier_KeyDown);
            // 
            // SupplierCode
            // 
            this.SupplierCode.DataPropertyName = "SupplierCode";
            this.SupplierCode.HeaderText = "Supplier Code";
            this.SupplierCode.Name = "SupplierCode";
            this.SupplierCode.ReadOnly = true;
            this.SupplierCode.Width = 135;
            // 
            // SupplierName
            // 
            this.SupplierName.DataPropertyName = "SupplierName";
            this.SupplierName.HeaderText = "Supplier Name";
            this.SupplierName.Name = "SupplierName";
            this.SupplierName.ReadOnly = true;
            this.SupplierName.Width = 325;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtPriceLevelSelling);
            this.tabPage1.Controls.Add(this.txtPriceLevelCost);
            this.tabPage1.Controls.Add(this.dgvPriceLevel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(557, 175);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "Price Level";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtPriceLevelSelling
            // 
            this.txtPriceLevelSelling.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtPriceLevelSelling.Location = new System.Drawing.Point(181, 147);
            this.txtPriceLevelSelling.Name = "txtPriceLevelSelling";
            this.txtPriceLevelSelling.Size = new System.Drawing.Size(137, 21);
            this.txtPriceLevelSelling.TabIndex = 123;
            this.txtPriceLevelSelling.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPriceLevelSelling.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPriceLevelSelling_KeyDown);
            // 
            // txtPriceLevelCost
            // 
            this.txtPriceLevelCost.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtPriceLevelCost.Location = new System.Drawing.Point(6, 147);
            this.txtPriceLevelCost.Name = "txtPriceLevelCost";
            this.txtPriceLevelCost.Size = new System.Drawing.Size(174, 21);
            this.txtPriceLevelCost.TabIndex = 122;
            this.txtPriceLevelCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPriceLevelCost.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPriceLevelCost_KeyDown);
            // 
            // dgvPriceLevel
            // 
            this.dgvPriceLevel.AllowUserToAddRows = false;
            this.dgvPriceLevel.AllowUserToDeleteRows = false;
            this.dgvPriceLevel.AllowUserToResizeColumns = false;
            this.dgvPriceLevel.AllowUserToResizeRows = false;
            this.dgvPriceLevel.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvPriceLevel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPriceLevel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PriceLevelCost,
            this.PriceLevelSelling});
            this.dgvPriceLevel.Location = new System.Drawing.Point(6, 7);
            this.dgvPriceLevel.Name = "dgvPriceLevel";
            this.dgvPriceLevel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPriceLevel.Size = new System.Drawing.Size(545, 136);
            this.dgvPriceLevel.TabIndex = 121;
            this.dgvPriceLevel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPriceLevel_KeyDown);
            // 
            // PriceLevelCost
            // 
            this.PriceLevelCost.DataPropertyName = "CostPrice";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PriceLevelCost.DefaultCellStyle = dataGridViewCellStyle1;
            this.PriceLevelCost.HeaderText = "Cost Price";
            this.PriceLevelCost.Name = "PriceLevelCost";
            this.PriceLevelCost.ReadOnly = true;
            this.PriceLevelCost.Width = 135;
            // 
            // PriceLevelSelling
            // 
            this.PriceLevelSelling.DataPropertyName = "SellingPrice";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PriceLevelSelling.DefaultCellStyle = dataGridViewCellStyle2;
            this.PriceLevelSelling.HeaderText = "Selling Price";
            this.PriceLevelSelling.Name = "PriceLevelSelling";
            this.PriceLevelSelling.ReadOnly = true;
            this.PriceLevelSelling.Width = 135;
            // 
            // txtThisLocationStock
            // 
            this.txtThisLocationStock.BackColor = System.Drawing.Color.Yellow;
            this.txtThisLocationStock.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThisLocationStock.ForeColor = System.Drawing.Color.Red;
            this.txtThisLocationStock.Location = new System.Drawing.Point(571, 454);
            this.txtThisLocationStock.MaxLength = 10;
            this.txtThisLocationStock.Name = "txtThisLocationStock";
            this.txtThisLocationStock.ReadOnly = true;
            this.txtThisLocationStock.Size = new System.Drawing.Size(142, 33);
            this.txtThisLocationStock.TabIndex = 100;
            this.txtThisLocationStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblLabReferenceNo
            // 
            this.lblLabReferenceNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabReferenceNo.Location = new System.Drawing.Point(591, 419);
            this.lblLabReferenceNo.Name = "lblLabReferenceNo";
            this.lblLabReferenceNo.Size = new System.Drawing.Size(107, 32);
            this.lblLabReferenceNo.TabIndex = 122;
            this.lblLabReferenceNo.Text = "This Location Stock";
            this.lblLabReferenceNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxCommon1
            // 
            this.groupBoxCommon1.Controls.Add(this.chkClearValues);
            this.groupBoxCommon1.Controls.Add(this.chkIsCountable);
            this.groupBoxCommon1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCommon1.Location = new System.Drawing.Point(575, 313);
            this.groupBoxCommon1.Name = "groupBoxCommon1";
            this.groupBoxCommon1.Size = new System.Drawing.Size(131, 103);
            this.groupBoxCommon1.TabIndex = 123;
            this.groupBoxCommon1.TabStop = false;
            // 
            // chkClearValues
            // 
            this.chkClearValues.AutoSize = true;
            this.chkClearValues.Checked = true;
            this.chkClearValues.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClearValues.Location = new System.Drawing.Point(19, 43);
            this.chkClearValues.Name = "chkClearValues";
            this.chkClearValues.Size = new System.Drawing.Size(57, 17);
            this.chkClearValues.TabIndex = 125;
            this.chkClearValues.Text = "Clear";
            this.chkClearValues.UseVisualStyleBackColor = true;
            // 
            // chkIsCountable
            // 
            this.chkIsCountable.AutoSize = true;
            this.chkIsCountable.Checked = true;
            this.chkIsCountable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsCountable.Location = new System.Drawing.Point(19, 20);
            this.chkIsCountable.Name = "chkIsCountable";
            this.chkIsCountable.Size = new System.Drawing.Size(84, 17);
            this.chkIsCountable.TabIndex = 124;
            this.chkIsCountable.Text = "Countable";
            this.chkIsCountable.UseVisualStyleBackColor = true;
            // 
            // lableCommon1
            // 
            this.lableCommon1.AutoSize = true;
            this.lableCommon1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon1.Location = new System.Drawing.Point(8, 96);
            this.lableCommon1.Name = "lableCommon1";
            this.lableCommon1.Size = new System.Drawing.Size(86, 13);
            this.lableCommon1.TabIndex = 125;
            this.lableCommon1.Text = "Sinhala Name";
            // 
            // txtReferenceCode2
            // 
            this.txtReferenceCode2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReferenceCode2.Location = new System.Drawing.Point(543, 66);
            this.txtReferenceCode2.Name = "txtReferenceCode2";
            this.txtReferenceCode2.Size = new System.Drawing.Size(170, 21);
            this.txtReferenceCode2.TabIndex = 127;
            // 
            // lableCommon2
            // 
            this.lableCommon2.AutoSize = true;
            this.lableCommon2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon2.Location = new System.Drawing.Point(434, 69);
            this.lableCommon2.Name = "lableCommon2";
            this.lableCommon2.Size = new System.Drawing.Size(110, 13);
            this.lableCommon2.TabIndex = 126;
            this.lableCommon2.Text = "Reference Code 2";
            // 
            // txtReferenceCode3
            // 
            this.txtReferenceCode3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReferenceCode3.Location = new System.Drawing.Point(543, 93);
            this.txtReferenceCode3.Name = "txtReferenceCode3";
            this.txtReferenceCode3.Size = new System.Drawing.Size(170, 21);
            this.txtReferenceCode3.TabIndex = 129;
            // 
            // lableCommon3
            // 
            this.lableCommon3.AutoSize = true;
            this.lableCommon3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon3.Location = new System.Drawing.Point(434, 96);
            this.lableCommon3.Name = "lableCommon3";
            this.lableCommon3.Size = new System.Drawing.Size(110, 13);
            this.lableCommon3.TabIndex = 128;
            this.lableCommon3.Text = "Reference Code 3";
            // 
            // lblSinhalaName
            // 
            this.lblSinhalaName.AutoSize = true;
            this.lblSinhalaName.Font = new System.Drawing.Font("FMDerana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSinhalaName.Location = new System.Drawing.Point(139, 118);
            this.lblSinhalaName.Name = "lblSinhalaName";
            this.lblSinhalaName.Size = new System.Drawing.Size(173, 20);
            this.lblSinhalaName.TabIndex = 130;
            this.lblSinhalaName.Text = "fuda;d fc,s iafg%dafnß .%E50";
            // 
            // txtSinhalaName
            // 
            this.txtSinhalaName.Location = new System.Drawing.Point(139, 93);
            this.txtSinhalaName.Name = "txtSinhalaName";
            this.txtSinhalaName.Size = new System.Drawing.Size(289, 21);
            this.txtSinhalaName.TabIndex = 131;
            this.txtSinhalaName.TextChanged += new System.EventHandler(this.txtSinhalaName_TextChanged);
            // 
            // FrmItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 549);
            this.Name = "FrmItem";
            this.Text = "FrmItem";
            this.grbMargin.ResumeLayout(false);
            this.grbMargin.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.grpProperty.ResumeLayout(false);
            this.grpProperty.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbItem)).EndInit();
            this.grpReOrder.ResumeLayout(false);
            this.grpReOrder.PerformLayout();
            this.tbItem.ResumeLayout(false);
            this.tbpPrice.ResumeLayout(false);
            this.tbpPrice.PerformLayout();
            this.tbpStock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemStock)).EndInit();
            this.tbpSupplier.ResumeLayout(false);
            this.tbpSupplier.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemSupplier)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceLevel)).EndInit();
            this.groupBoxCommon1.ResumeLayout(false);
            this.groupBoxCommon1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Custom_Controllers.TextBoxDescription txtItemName;
        private System.Windows.Forms.CheckBox chkActive;
        private Custom_Controllers.TextBoxMasterCode txtItemCode;
        private Custom_Controllers.ButtonNew btnNew;
        private Custom_Controllers.LableCommon lblItemCode;
        private Custom_Controllers.LableCommon lblItemName;
        private Custom_Controllers.LableCommon lblNameOnInvoice;
        private Custom_Controllers.TextBoxDescription txtNameOnInvoice;
        private Custom_Controllers.LableCommon lblReferenceCode;
        private Custom_Controllers.LableCommon lblBarcode;
        private Custom_Controllers.TextBoxDescription txtBarcode;
        private Custom_Controllers.TextBoxDescription txtReferenceCode1;
        private Custom_Controllers.GroupBoxCommon grpProperty;
        private Custom_Controllers.LableCommon lblCategory;
        private Custom_Controllers.TextBoxDescription txtCategoryDescription;
        private Custom_Controllers.TextBoxMasterCode txtCategoryCode;
        private Custom_Controllers.LableCommon lblSubcategory2;
        private Custom_Controllers.LableCommon lblSubCategory1;
        private Custom_Controllers.TextBoxDescription txtSubCategory1Description;
        private Custom_Controllers.TextBoxMasterCode txtSubCategory1Code;
        private Custom_Controllers.TextBoxDescription txtSubCategory2Description;
        private Custom_Controllers.TextBoxMasterCode txtSubCategory2Code;
        private Custom_Controllers.TextBoxDescription txtBrandDescription;
        private Custom_Controllers.TextBoxMasterCode txtBrandCode;
        private Custom_Controllers.LableCommon lblBrand;
        private System.Windows.Forms.Button btnImageClear;
        private System.Windows.Forms.Button btnCamera;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.PictureBox pbItem;
        private Custom_Controllers.GroupBoxCommon grpReOrder;
        private Custom_Controllers.LableCommon lblReOrderLevel;
        private Custom_Controllers.LableCommon lblReOrderQty;
        private Custom_Controllers.TextBoxInteger txtReOrderQty;
        private Custom_Controllers.TextBoxInteger txtReOrderLevel;
        private System.Windows.Forms.TabControl tbItem;
        private System.Windows.Forms.TabPage tbpPrice;
        private System.Windows.Forms.TabPage tbpSupplier;
        private System.Windows.Forms.TabPage tbpStock;
        private Custom_Controllers.TextBoxMasterCode txtThisLocationStock;
        private Custom_Controllers.LableCommon lblLabReferenceNo;
        private Custom_Controllers.LableCommon lblSellingPrice;
        private Custom_Controllers.TextBoxCurrency txtSellingPrice;
        private Custom_Controllers.LableCommon lblMaximumPrice;
        private Custom_Controllers.TextBoxCurrency txtMaximumPrice;
        private Custom_Controllers.LableCommon lblCostPrice;
        private Custom_Controllers.TextBoxCurrency txtCostPrice;
        private Custom_Controllers.LableCommon lblMinimumPrice;
        private Custom_Controllers.TextBoxCurrency txtMinimumPrice;
        private Custom_Controllers.LableCommon lblMargin;
        private Custom_Controllers.TextBoxCurrency txtMarginPercentage;
        private Custom_Controllers.LableCommon lblFixedDiscount;
        private Custom_Controllers.TextBoxCurrency txtFixedDiscountPercentage;
        private Custom_Controllers.GridViewCommon dgvItemSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierName;
        private Custom_Controllers.TextBoxMasterCode txtSupplierCode;
        private Custom_Controllers.TextBoxDescription txtSupplierDescription;
        private Custom_Controllers.GridViewCommon dgvItemStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private Custom_Controllers.GroupBoxCommon groupBoxCommon1;
        private System.Windows.Forms.CheckBox chkIsCountable;
        private Custom_Controllers.LableCommon lableCommon1;
        private Custom_Controllers.TextBoxDescription txtReferenceCode2;
        private Custom_Controllers.LableCommon lableCommon2;
        private Custom_Controllers.TextBoxDescription txtReferenceCode3;
        private Custom_Controllers.LableCommon lableCommon3;
        private System.Windows.Forms.TabPage tabPage1;
        private Custom_Controllers.GridViewCommon dgvPriceLevel;
        private Custom_Controllers.TextBoxCurrency txtPriceLevelSelling;
        private Custom_Controllers.TextBoxCurrency txtPriceLevelCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceLevelCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceLevelSelling;
        private Custom_Controllers.LableCommon lableCommon4;
        private Custom_Controllers.TextBoxCurrency txtFixedDiscount;
        private Custom_Controllers.LableCommon lblSinhalaName;
        private System.Windows.Forms.TextBox txtSinhalaName;
        private System.Windows.Forms.CheckBox chkClearValues;
    }
}