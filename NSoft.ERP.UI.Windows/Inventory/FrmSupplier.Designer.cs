namespace NSoft.ERP.UI.Windows.Inventory
{
    partial class FrmSupplier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSupplier));
            this.lblSupplierCode = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lblSupplierName = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lblTitle = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.txtSupplierCode = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxMasterCode();
            this.btnNew = new NSoft.ERP.UI.Windows.Custom_Controllers.ButtonNew();
            this.txtSupplierDescription = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.cmbTitle = new NSoft.ERP.UI.Windows.Custom_Controllers.ComboBoxCommon();
            this.tbSupplier = new System.Windows.Forms.TabControl();
            this.tbpPersonal = new System.Windows.Forms.TabPage();
            this.cmbSupplierGroup = new NSoft.ERP.UI.Windows.Custom_Controllers.ComboBoxCommon();
            this.lableCommon6 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtNICNo = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.lableCommon4 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.tbpContact = new System.Windows.Forms.TabPage();
            this.lableCommon2 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtEmail = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.txtFixedNo = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxContactNo();
            this.lableCommon1 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtMobileNo = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxContactNo();
            this.lableCommon8 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtAddress = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.lableCommon7 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.tbpFinance = new System.Windows.Forms.TabPage();
            this.cmbLedger = new NSoft.ERP.UI.Windows.Custom_Controllers.ComboBoxCommon();
            this.lableCommon12 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lableCommon10 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lableCommon9 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtChequePeriod = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.lableCommon3 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtCreditPeriod = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.lableCommon5 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtChequeLimit = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.lblChequeLimit = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtCreditLimit = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.lblCreditLimit = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.tbpTax = new System.Windows.Forms.TabPage();
            this.tbpOther = new System.Windows.Forms.TabPage();
            this.pbSupplier = new System.Windows.Forms.PictureBox();
            this.btnImageClear = new System.Windows.Forms.Button();
            this.btnCamera = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.grbMargin.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tbSupplier.SuspendLayout();
            this.tbpPersonal.SuspendLayout();
            this.tbpContact.SuspendLayout();
            this.tbpFinance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSupplier)).BeginInit();
            this.SuspendLayout();
            // 
            // grbMargin
            // 
            this.grbMargin.Controls.Add(this.btnImageClear);
            this.grbMargin.Controls.Add(this.btnCamera);
            this.grbMargin.Controls.Add(this.btnBrowse);
            this.grbMargin.Controls.Add(this.pbSupplier);
            this.grbMargin.Controls.Add(this.tbSupplier);
            this.grbMargin.Controls.Add(this.cmbTitle);
            this.grbMargin.Controls.Add(this.txtSupplierDescription);
            this.grbMargin.Controls.Add(this.chkActive);
            this.grbMargin.Controls.Add(this.txtSupplierCode);
            this.grbMargin.Controls.Add(this.btnNew);
            this.grbMargin.Controls.Add(this.lblTitle);
            this.grbMargin.Controls.Add(this.lblSupplierName);
            this.grbMargin.Controls.Add(this.lblSupplierCode);
            this.grbMargin.Size = new System.Drawing.Size(601, 326);
            this.grbMargin.Controls.SetChildIndex(this.groupBox1, 0);
            this.grbMargin.Controls.SetChildIndex(this.groupBox2, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblSupplierCode, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblSupplierName, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblTitle, 0);
            this.grbMargin.Controls.SetChildIndex(this.btnNew, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtSupplierCode, 0);
            this.grbMargin.Controls.SetChildIndex(this.chkActive, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtSupplierDescription, 0);
            this.grbMargin.Controls.SetChildIndex(this.cmbTitle, 0);
            this.grbMargin.Controls.SetChildIndex(this.tbSupplier, 0);
            this.grbMargin.Controls.SetChildIndex(this.pbSupplier, 0);
            this.grbMargin.Controls.SetChildIndex(this.btnBrowse, 0);
            this.grbMargin.Controls.SetChildIndex(this.btnCamera, 0);
            this.grbMargin.Controls.SetChildIndex(this.btnImageClear, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(4, 274);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(393, 274);
            // 
            // lblSupplierCode
            // 
            this.lblSupplierCode.AutoSize = true;
            this.lblSupplierCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplierCode.Location = new System.Drawing.Point(9, 20);
            this.lblSupplierCode.Name = "lblSupplierCode";
            this.lblSupplierCode.Size = new System.Drawing.Size(109, 13);
            this.lblSupplierCode.TabIndex = 8;
            this.lblSupplierCode.Text = "Supplier Code *";
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplierName.Location = new System.Drawing.Point(9, 51);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(114, 13);
            this.lblSupplierName.TabIndex = 9;
            this.lblSupplierName.Text = "Supplier Name *";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(9, 80);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(48, 13);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "Title *";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(317, 19);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(61, 17);
            this.chkActive.TabIndex = 25;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // txtSupplierCode
            // 
            this.txtSupplierCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierCode.Location = new System.Drawing.Point(124, 17);
            this.txtSupplierCode.MaxLength = 10;
            this.txtSupplierCode.Name = "txtSupplierCode";
            this.txtSupplierCode.Size = new System.Drawing.Size(131, 21);
            this.txtSupplierCode.TabIndex = 24;
            this.txtSupplierCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSupplierCode_KeyDown);
            this.txtSupplierCode.Leave += new System.EventHandler(this.txtSupplierCode_Leave);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(261, 15);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(50, 23);
            this.btnNew.TabIndex = 23;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtSupplierDescription
            // 
            this.txtSupplierDescription.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierDescription.Location = new System.Drawing.Point(124, 48);
            this.txtSupplierDescription.Name = "txtSupplierDescription";
            this.txtSupplierDescription.Size = new System.Drawing.Size(341, 21);
            this.txtSupplierDescription.TabIndex = 26;
            this.txtSupplierDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSupplierDescription_KeyDown);
            this.txtSupplierDescription.Leave += new System.EventHandler(this.txtSupplierDescription_Leave);
            // 
            // cmbTitle
            // 
            this.cmbTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTitle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTitle.FormattingEnabled = true;
            this.cmbTitle.Location = new System.Drawing.Point(124, 77);
            this.cmbTitle.Name = "cmbTitle";
            this.cmbTitle.Size = new System.Drawing.Size(131, 21);
            this.cmbTitle.TabIndex = 27;
            this.cmbTitle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbTitle_KeyDown);
            // 
            // tbSupplier
            // 
            this.tbSupplier.Controls.Add(this.tbpPersonal);
            this.tbSupplier.Controls.Add(this.tbpContact);
            this.tbSupplier.Controls.Add(this.tbpFinance);
            this.tbSupplier.Controls.Add(this.tbpTax);
            this.tbSupplier.Controls.Add(this.tbpOther);
            this.tbSupplier.Location = new System.Drawing.Point(12, 111);
            this.tbSupplier.Name = "tbSupplier";
            this.tbSupplier.SelectedIndex = 0;
            this.tbSupplier.Size = new System.Drawing.Size(445, 167);
            this.tbSupplier.TabIndex = 28;
            // 
            // tbpPersonal
            // 
            this.tbpPersonal.Controls.Add(this.cmbSupplierGroup);
            this.tbpPersonal.Controls.Add(this.lableCommon6);
            this.tbpPersonal.Controls.Add(this.txtNICNo);
            this.tbpPersonal.Controls.Add(this.lableCommon4);
            this.tbpPersonal.Location = new System.Drawing.Point(4, 22);
            this.tbpPersonal.Name = "tbpPersonal";
            this.tbpPersonal.Padding = new System.Windows.Forms.Padding(3);
            this.tbpPersonal.Size = new System.Drawing.Size(437, 141);
            this.tbpPersonal.TabIndex = 0;
            this.tbpPersonal.Text = "Personal";
            this.tbpPersonal.UseVisualStyleBackColor = true;
            // 
            // cmbSupplierGroup
            // 
            this.cmbSupplierGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplierGroup.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSupplierGroup.FormattingEnabled = true;
            this.cmbSupplierGroup.Location = new System.Drawing.Point(138, 38);
            this.cmbSupplierGroup.Name = "cmbSupplierGroup";
            this.cmbSupplierGroup.Size = new System.Drawing.Size(141, 21);
            this.cmbSupplierGroup.TabIndex = 36;
            this.cmbSupplierGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSupplierGroup_KeyDown);
            // 
            // lableCommon6
            // 
            this.lableCommon6.AutoSize = true;
            this.lableCommon6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon6.Location = new System.Drawing.Point(17, 41);
            this.lableCommon6.Name = "lableCommon6";
            this.lableCommon6.Size = new System.Drawing.Size(116, 13);
            this.lableCommon6.TabIndex = 37;
            this.lableCommon6.Text = "Supplier Group *";
            // 
            // txtNICNo
            // 
            this.txtNICNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNICNo.Location = new System.Drawing.Point(138, 11);
            this.txtNICNo.Name = "txtNICNo";
            this.txtNICNo.Size = new System.Drawing.Size(141, 21);
            this.txtNICNo.TabIndex = 34;
            this.txtNICNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNICNo_KeyDown);
            // 
            // lableCommon4
            // 
            this.lableCommon4.AutoSize = true;
            this.lableCommon4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon4.Location = new System.Drawing.Point(17, 14);
            this.lableCommon4.Name = "lableCommon4";
            this.lableCommon4.Size = new System.Drawing.Size(51, 13);
            this.lableCommon4.TabIndex = 33;
            this.lableCommon4.Text = "NIC No";
            // 
            // tbpContact
            // 
            this.tbpContact.Controls.Add(this.lableCommon2);
            this.tbpContact.Controls.Add(this.txtEmail);
            this.tbpContact.Controls.Add(this.txtFixedNo);
            this.tbpContact.Controls.Add(this.lableCommon1);
            this.tbpContact.Controls.Add(this.txtMobileNo);
            this.tbpContact.Controls.Add(this.lableCommon8);
            this.tbpContact.Controls.Add(this.txtAddress);
            this.tbpContact.Controls.Add(this.lableCommon7);
            this.tbpContact.Location = new System.Drawing.Point(4, 22);
            this.tbpContact.Name = "tbpContact";
            this.tbpContact.Padding = new System.Windows.Forms.Padding(3);
            this.tbpContact.Size = new System.Drawing.Size(437, 141);
            this.tbpContact.TabIndex = 1;
            this.tbpContact.Text = "Contact";
            this.tbpContact.UseVisualStyleBackColor = true;
            // 
            // lableCommon2
            // 
            this.lableCommon2.AutoSize = true;
            this.lableCommon2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon2.Location = new System.Drawing.Point(17, 110);
            this.lableCommon2.Name = "lableCommon2";
            this.lableCommon2.Size = new System.Drawing.Size(43, 13);
            this.lableCommon2.TabIndex = 40;
            this.lableCommon2.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(83, 109);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(337, 21);
            this.txtEmail.TabIndex = 33;
            this.txtEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmail_KeyDown);
            // 
            // txtFixedNo
            // 
            this.txtFixedNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFixedNo.Location = new System.Drawing.Point(301, 82);
            this.txtFixedNo.MaxLength = 10;
            this.txtFixedNo.Name = "txtFixedNo";
            this.txtFixedNo.Size = new System.Drawing.Size(119, 21);
            this.txtFixedNo.TabIndex = 39;
            this.txtFixedNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFixedNo_KeyDown);
            // 
            // lableCommon1
            // 
            this.lableCommon1.AutoSize = true;
            this.lableCommon1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon1.Location = new System.Drawing.Point(235, 85);
            this.lableCommon1.Name = "lableCommon1";
            this.lableCommon1.Size = new System.Drawing.Size(43, 13);
            this.lableCommon1.TabIndex = 38;
            this.lableCommon1.Text = "Fixed";
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobileNo.Location = new System.Drawing.Point(83, 82);
            this.txtMobileNo.MaxLength = 10;
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(119, 21);
            this.txtMobileNo.TabIndex = 37;
            this.txtMobileNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMobileNo_KeyDown);
            // 
            // lableCommon8
            // 
            this.lableCommon8.AutoSize = true;
            this.lableCommon8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon8.Location = new System.Drawing.Point(17, 85);
            this.lableCommon8.Name = "lableCommon8";
            this.lableCommon8.Size = new System.Drawing.Size(49, 13);
            this.lableCommon8.TabIndex = 36;
            this.lableCommon8.Text = "Mobile";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(83, 11);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(337, 65);
            this.txtAddress.TabIndex = 35;
            this.txtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddress_KeyDown);
            // 
            // lableCommon7
            // 
            this.lableCommon7.AutoSize = true;
            this.lableCommon7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon7.Location = new System.Drawing.Point(17, 14);
            this.lableCommon7.Name = "lableCommon7";
            this.lableCommon7.Size = new System.Drawing.Size(60, 13);
            this.lableCommon7.TabIndex = 34;
            this.lableCommon7.Text = "Address";
            // 
            // tbpFinance
            // 
            this.tbpFinance.Controls.Add(this.cmbLedger);
            this.tbpFinance.Controls.Add(this.lableCommon12);
            this.tbpFinance.Controls.Add(this.lableCommon10);
            this.tbpFinance.Controls.Add(this.lableCommon9);
            this.tbpFinance.Controls.Add(this.txtChequePeriod);
            this.tbpFinance.Controls.Add(this.lableCommon3);
            this.tbpFinance.Controls.Add(this.txtCreditPeriod);
            this.tbpFinance.Controls.Add(this.lableCommon5);
            this.tbpFinance.Controls.Add(this.txtChequeLimit);
            this.tbpFinance.Controls.Add(this.lblChequeLimit);
            this.tbpFinance.Controls.Add(this.txtCreditLimit);
            this.tbpFinance.Controls.Add(this.lblCreditLimit);
            this.tbpFinance.Location = new System.Drawing.Point(4, 22);
            this.tbpFinance.Name = "tbpFinance";
            this.tbpFinance.Padding = new System.Windows.Forms.Padding(3);
            this.tbpFinance.Size = new System.Drawing.Size(437, 141);
            this.tbpFinance.TabIndex = 3;
            this.tbpFinance.Text = "Finance";
            this.tbpFinance.UseVisualStyleBackColor = true;
            // 
            // cmbLedger
            // 
            this.cmbLedger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLedger.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLedger.FormattingEnabled = true;
            this.cmbLedger.Location = new System.Drawing.Point(116, 67);
            this.cmbLedger.Name = "cmbLedger";
            this.cmbLedger.Size = new System.Drawing.Size(274, 21);
            this.cmbLedger.TabIndex = 46;
            this.cmbLedger.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLedger_KeyDown);
            // 
            // lableCommon12
            // 
            this.lableCommon12.AutoSize = true;
            this.lableCommon12.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon12.Location = new System.Drawing.Point(10, 70);
            this.lableCommon12.Name = "lableCommon12";
            this.lableCommon12.Size = new System.Drawing.Size(52, 13);
            this.lableCommon12.TabIndex = 47;
            this.lableCommon12.Text = "Ledger";
            // 
            // lableCommon10
            // 
            this.lableCommon10.AutoSize = true;
            this.lableCommon10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon10.Location = new System.Drawing.Point(395, 43);
            this.lableCommon10.Name = "lableCommon10";
            this.lableCommon10.Size = new System.Drawing.Size(39, 13);
            this.lableCommon10.TabIndex = 45;
            this.lableCommon10.Text = "Days";
            // 
            // lableCommon9
            // 
            this.lableCommon9.AutoSize = true;
            this.lableCommon9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon9.Location = new System.Drawing.Point(395, 16);
            this.lableCommon9.Name = "lableCommon9";
            this.lableCommon9.Size = new System.Drawing.Size(39, 13);
            this.lableCommon9.TabIndex = 44;
            this.lableCommon9.Text = "Days";
            // 
            // txtChequePeriod
            // 
            this.txtChequePeriod.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtChequePeriod.Location = new System.Drawing.Point(334, 40);
            this.txtChequePeriod.Name = "txtChequePeriod";
            this.txtChequePeriod.Size = new System.Drawing.Size(56, 21);
            this.txtChequePeriod.TabIndex = 43;
            this.txtChequePeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtChequePeriod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChequePeriod_KeyDown);
            // 
            // lableCommon3
            // 
            this.lableCommon3.AutoSize = true;
            this.lableCommon3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon3.Location = new System.Drawing.Point(220, 43);
            this.lableCommon3.Name = "lableCommon3";
            this.lableCommon3.Size = new System.Drawing.Size(103, 13);
            this.lableCommon3.TabIndex = 42;
            this.lableCommon3.Text = "Cheque Limit *";
            // 
            // txtCreditPeriod
            // 
            this.txtCreditPeriod.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtCreditPeriod.Location = new System.Drawing.Point(334, 13);
            this.txtCreditPeriod.Name = "txtCreditPeriod";
            this.txtCreditPeriod.Size = new System.Drawing.Size(56, 21);
            this.txtCreditPeriod.TabIndex = 41;
            this.txtCreditPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCreditPeriod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCreditPeriod_KeyDown);
            // 
            // lableCommon5
            // 
            this.lableCommon5.AutoSize = true;
            this.lableCommon5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon5.Location = new System.Drawing.Point(220, 16);
            this.lableCommon5.Name = "lableCommon5";
            this.lableCommon5.Size = new System.Drawing.Size(108, 13);
            this.lableCommon5.TabIndex = 40;
            this.lableCommon5.Text = "Credit  Period *";
            // 
            // txtChequeLimit
            // 
            this.txtChequeLimit.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtChequeLimit.Location = new System.Drawing.Point(116, 40);
            this.txtChequeLimit.Name = "txtChequeLimit";
            this.txtChequeLimit.Size = new System.Drawing.Size(96, 21);
            this.txtChequeLimit.TabIndex = 39;
            this.txtChequeLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtChequeLimit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChequeLimit_KeyDown);
            // 
            // lblChequeLimit
            // 
            this.lblChequeLimit.AutoSize = true;
            this.lblChequeLimit.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChequeLimit.Location = new System.Drawing.Point(10, 43);
            this.lblChequeLimit.Name = "lblChequeLimit";
            this.lblChequeLimit.Size = new System.Drawing.Size(103, 13);
            this.lblChequeLimit.TabIndex = 38;
            this.lblChequeLimit.Text = "Cheque Limit *";
            // 
            // txtCreditLimit
            // 
            this.txtCreditLimit.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtCreditLimit.Location = new System.Drawing.Point(116, 13);
            this.txtCreditLimit.Name = "txtCreditLimit";
            this.txtCreditLimit.Size = new System.Drawing.Size(96, 21);
            this.txtCreditLimit.TabIndex = 37;
            this.txtCreditLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCreditLimit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCreditLimit_KeyDown);
            // 
            // lblCreditLimit
            // 
            this.lblCreditLimit.AutoSize = true;
            this.lblCreditLimit.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditLimit.Location = new System.Drawing.Point(10, 16);
            this.lblCreditLimit.Name = "lblCreditLimit";
            this.lblCreditLimit.Size = new System.Drawing.Size(94, 13);
            this.lblCreditLimit.TabIndex = 36;
            this.lblCreditLimit.Text = "Credit Limit *";
            // 
            // tbpTax
            // 
            this.tbpTax.Location = new System.Drawing.Point(4, 22);
            this.tbpTax.Name = "tbpTax";
            this.tbpTax.Padding = new System.Windows.Forms.Padding(3);
            this.tbpTax.Size = new System.Drawing.Size(437, 141);
            this.tbpTax.TabIndex = 2;
            this.tbpTax.Text = "Tax";
            this.tbpTax.UseVisualStyleBackColor = true;
            // 
            // tbpOther
            // 
            this.tbpOther.Location = new System.Drawing.Point(4, 22);
            this.tbpOther.Name = "tbpOther";
            this.tbpOther.Padding = new System.Windows.Forms.Padding(3);
            this.tbpOther.Size = new System.Drawing.Size(437, 141);
            this.tbpOther.TabIndex = 4;
            this.tbpOther.Text = "Other";
            this.tbpOther.UseVisualStyleBackColor = true;
            // 
            // pbSupplier
            // 
            this.pbSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSupplier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSupplier.Location = new System.Drawing.Point(463, 94);
            this.pbSupplier.Name = "pbSupplier";
            this.pbSupplier.Size = new System.Drawing.Size(131, 135);
            this.pbSupplier.TabIndex = 29;
            this.pbSupplier.TabStop = false;
            // 
            // btnImageClear
            // 
            this.btnImageClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImageClear.BackgroundImage")));
            this.btnImageClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImageClear.Location = new System.Drawing.Point(551, 234);
            this.btnImageClear.Name = "btnImageClear";
            this.btnImageClear.Size = new System.Drawing.Size(35, 30);
            this.btnImageClear.TabIndex = 32;
            this.btnImageClear.UseVisualStyleBackColor = true;
            this.btnImageClear.Click += new System.EventHandler(this.btnImageClear_Click);
            // 
            // btnCamera
            // 
            this.btnCamera.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCamera.BackgroundImage")));
            this.btnCamera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCamera.Location = new System.Drawing.Point(510, 234);
            this.btnCamera.Name = "btnCamera";
            this.btnCamera.Size = new System.Drawing.Size(35, 30);
            this.btnCamera.TabIndex = 31;
            this.btnCamera.UseVisualStyleBackColor = true;
            this.btnCamera.Click += new System.EventHandler(this.btnCamera_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBrowse.BackgroundImage")));
            this.btnBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBrowse.Location = new System.Drawing.Point(469, 234);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(35, 30);
            this.btnBrowse.TabIndex = 30;
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // FrmSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 330);
            this.Name = "FrmSupplier";
            this.Text = "FrmSupplier";
            this.grbMargin.ResumeLayout(false);
            this.grbMargin.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tbSupplier.ResumeLayout(false);
            this.tbpPersonal.ResumeLayout(false);
            this.tbpPersonal.PerformLayout();
            this.tbpContact.ResumeLayout(false);
            this.tbpContact.PerformLayout();
            this.tbpFinance.ResumeLayout(false);
            this.tbpFinance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSupplier)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Custom_Controllers.LableCommon lblSupplierCode;
        private Custom_Controllers.LableCommon lblTitle;
        private Custom_Controllers.LableCommon lblSupplierName;
        private System.Windows.Forms.CheckBox chkActive;
        private Custom_Controllers.TextBoxMasterCode txtSupplierCode;
        private Custom_Controllers.ButtonNew btnNew;
        private Custom_Controllers.TextBoxDescription txtSupplierDescription;
        private Custom_Controllers.ComboBoxCommon cmbTitle;
        private System.Windows.Forms.TabControl tbSupplier;
        private System.Windows.Forms.TabPage tbpPersonal;
        private System.Windows.Forms.TabPage tbpContact;
        private System.Windows.Forms.TabPage tbpTax;
        private System.Windows.Forms.TabPage tbpFinance;
        private System.Windows.Forms.PictureBox pbSupplier;
        private System.Windows.Forms.Button btnImageClear;
        private System.Windows.Forms.Button btnCamera;
        private System.Windows.Forms.Button btnBrowse;
        private Custom_Controllers.LableCommon lableCommon4;
        private Custom_Controllers.TextBoxDescription txtNICNo;
        private Custom_Controllers.ComboBoxCommon cmbSupplierGroup;
        private Custom_Controllers.LableCommon lableCommon6;
        private Custom_Controllers.LableCommon lableCommon7;
        private Custom_Controllers.TextBoxDescription txtAddress;
        private Custom_Controllers.TextBoxContactNo txtMobileNo;
        private Custom_Controllers.LableCommon lableCommon8;
        private Custom_Controllers.LableCommon lblCreditLimit;
        private Custom_Controllers.TextBoxCurrency txtCreditLimit;
        private System.Windows.Forms.TabPage tbpOther;
        private Custom_Controllers.TextBoxCurrency txtChequeLimit;
        private Custom_Controllers.LableCommon lblChequeLimit;
        private Custom_Controllers.TextBoxContactNo txtFixedNo;
        private Custom_Controllers.LableCommon lableCommon1;
        private Custom_Controllers.TextBoxDescription txtEmail;
        private Custom_Controllers.LableCommon lableCommon2;
        private Custom_Controllers.LableCommon lableCommon10;
        private Custom_Controllers.LableCommon lableCommon9;
        private Custom_Controllers.TextBoxCurrency txtChequePeriod;
        private Custom_Controllers.LableCommon lableCommon3;
        private Custom_Controllers.TextBoxCurrency txtCreditPeriod;
        private Custom_Controllers.LableCommon lableCommon5;
        private Custom_Controllers.ComboBoxCommon cmbLedger;
        private Custom_Controllers.LableCommon lableCommon12;
    }
}