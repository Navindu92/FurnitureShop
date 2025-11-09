namespace NSoft.ERP.UI.Windows.Inventory
{
    partial class FrmInvoiceReturn
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtpDocumentDate = new NSoft.ERP.UI.Windows.Custom_Controllers.DateTimePickerCommon();
            this.lblDate = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lblDocumentNo = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtDocumentNo = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDocumentNo();
            this.lblCustomer = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtCustomerDescription = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.txtCustomerCode = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxMasterCode();
            this.lblReferenceNo = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtReferenceNo = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCommon();
            this.dgvInvoice = new NSoft.ERP.UI.Windows.Custom_Controllers.GridViewCommon();
            this.Row = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SellingPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpInvoiceDetail = new NSoft.ERP.UI.Windows.Custom_Controllers.GroupBoxCommon();
            this.txtRow = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxMasterCode();
            this.txtAmount = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.txtItemDis = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.txtQty = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.txtSellingPrice = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.txtItemName = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.txtItemCode = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxMasterCode();
            this.lblLabReferenceNo = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtThisLocationStock = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxMasterCode();
            this.txtWarning = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCommon();
            this.grpStatus = new NSoft.ERP.UI.Windows.Custom_Controllers.GroupBoxCommon();
            this.lblNetTotal = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtNetAmount = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.txtDiscountAmount = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.txtSubTotalDis = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.lblDiscount = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lblTotal = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtTotalAmount = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.txtPaidAmount = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.lblPaidAmount = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.pbItem = new System.Windows.Forms.PictureBox();
            this.txtBalanceAmount = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.lblBalance = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.dgvItemSearch = new NSoft.ERP.UI.Windows.Custom_Controllers.GridViewCommon();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SearchItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtServiceCharge = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.lblServiceCharge = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.chkIsServiceCharge = new System.Windows.Forms.CheckBox();
            this.lblInvoiceNo = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.cmbInvoiceNo = new NSoft.ERP.UI.Windows.Custom_Controllers.ComboBoxCommonDropDown();
            this.grbMargin.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).BeginInit();
            this.grpInvoiceDetail.SuspendLayout();
            this.grpStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // grbMargin
            // 
            this.grbMargin.Controls.Add(this.cmbInvoiceNo);
            this.grbMargin.Controls.Add(this.lblInvoiceNo);
            this.grbMargin.Controls.Add(this.chkIsServiceCharge);
            this.grbMargin.Controls.Add(this.lblServiceCharge);
            this.grbMargin.Controls.Add(this.txtServiceCharge);
            this.grbMargin.Controls.Add(this.dgvItemSearch);
            this.grbMargin.Controls.Add(this.lblBalance);
            this.grbMargin.Controls.Add(this.txtBalanceAmount);
            this.grbMargin.Controls.Add(this.pbItem);
            this.grbMargin.Controls.Add(this.txtPaidAmount);
            this.grbMargin.Controls.Add(this.lblPaidAmount);
            this.grbMargin.Controls.Add(this.lblNetTotal);
            this.grbMargin.Controls.Add(this.txtNetAmount);
            this.grbMargin.Controls.Add(this.txtDiscountAmount);
            this.grbMargin.Controls.Add(this.txtSubTotalDis);
            this.grbMargin.Controls.Add(this.lblDiscount);
            this.grbMargin.Controls.Add(this.lblTotal);
            this.grbMargin.Controls.Add(this.txtTotalAmount);
            this.grbMargin.Controls.Add(this.grpStatus);
            this.grbMargin.Controls.Add(this.lblLabReferenceNo);
            this.grbMargin.Controls.Add(this.txtThisLocationStock);
            this.grbMargin.Controls.Add(this.txtReferenceNo);
            this.grbMargin.Controls.Add(this.lblReferenceNo);
            this.grbMargin.Controls.Add(this.txtCustomerDescription);
            this.grbMargin.Controls.Add(this.txtCustomerCode);
            this.grbMargin.Controls.Add(this.lblCustomer);
            this.grbMargin.Controls.Add(this.dtpDocumentDate);
            this.grbMargin.Controls.Add(this.lblDate);
            this.grbMargin.Controls.Add(this.lblDocumentNo);
            this.grbMargin.Controls.Add(this.txtDocumentNo);
            this.grbMargin.Controls.Add(this.grpInvoiceDetail);
            this.grbMargin.Size = new System.Drawing.Size(837, 549);
            this.grbMargin.Controls.SetChildIndex(this.grpInvoiceDetail, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtDocumentNo, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblDocumentNo, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblDate, 0);
            this.grbMargin.Controls.SetChildIndex(this.dtpDocumentDate, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblCustomer, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtCustomerCode, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtCustomerDescription, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblReferenceNo, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtReferenceNo, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtThisLocationStock, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblLabReferenceNo, 0);
            this.grbMargin.Controls.SetChildIndex(this.grpStatus, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtTotalAmount, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblTotal, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblDiscount, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtSubTotalDis, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtDiscountAmount, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtNetAmount, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblNetTotal, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblPaidAmount, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtPaidAmount, 0);
            this.grbMargin.Controls.SetChildIndex(this.pbItem, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtBalanceAmount, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblBalance, 0);
            this.grbMargin.Controls.SetChildIndex(this.dgvItemSearch, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtServiceCharge, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblServiceCharge, 0);
            this.grbMargin.Controls.SetChildIndex(this.chkIsServiceCharge, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblInvoiceNo, 0);
            this.grbMargin.Controls.SetChildIndex(this.cmbInvoiceNo, 0);
            this.grbMargin.Controls.SetChildIndex(this.groupBox1, 0);
            this.grbMargin.Controls.SetChildIndex(this.groupBox2, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(625, 495);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 102;
            this.btnClose.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.TabIndex = 100;
            this.btnClear.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Location = new System.Drawing.Point(7, 495);
            this.groupBox1.Size = new System.Drawing.Size(304, 48);
            this.groupBox1.Controls.SetChildIndex(this.btnSave, 0);
            this.groupBox1.Controls.SetChildIndex(this.btnView, 0);
            this.groupBox1.Controls.SetChildIndex(this.btnPrint, 0);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(205, 10);
            this.btnView.TabIndex = 101;
            this.btnView.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.TabIndex = 8;
            this.btnSave.TabStop = false;
            // 
            // dtpDocumentDate
            // 
            this.dtpDocumentDate.CustomFormat = "";
            this.dtpDocumentDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDocumentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDocumentDate.Location = new System.Drawing.Point(701, 10);
            this.dtpDocumentDate.Name = "dtpDocumentDate";
            this.dtpDocumentDate.Size = new System.Drawing.Size(131, 21);
            this.dtpDocumentDate.TabIndex = 3;
            this.dtpDocumentDate.TabStop = false;
            this.dtpDocumentDate.Enter += new System.EventHandler(this.dtpDocumentDate_Enter);
            this.dtpDocumentDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpDocumentDate_KeyDown);
            this.dtpDocumentDate.Leave += new System.EventHandler(this.dtpDocumentDate_Leave);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(653, 13);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(34, 13);
            this.lblDate.TabIndex = 109;
            this.lblDate.Text = "Date";
            // 
            // lblDocumentNo
            // 
            this.lblDocumentNo.AutoSize = true;
            this.lblDocumentNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocumentNo.Location = new System.Drawing.Point(8, 16);
            this.lblDocumentNo.Name = "lblDocumentNo";
            this.lblDocumentNo.Size = new System.Drawing.Size(84, 13);
            this.lblDocumentNo.TabIndex = 108;
            this.lblDocumentNo.Text = "Document No";
            // 
            // txtDocumentNo
            // 
            this.txtDocumentNo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDocumentNo.Location = new System.Drawing.Point(108, 13);
            this.txtDocumentNo.Name = "txtDocumentNo";
            this.txtDocumentNo.Size = new System.Drawing.Size(131, 20);
            this.txtDocumentNo.TabIndex = 0;
            this.txtDocumentNo.TabStop = false;
            this.txtDocumentNo.Enter += new System.EventHandler(this.txtDocumentNo_Enter);
            this.txtDocumentNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDocumentNo_KeyDown);
            this.txtDocumentNo.Leave += new System.EventHandler(this.txtDocumentNo_Leave);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.Location = new System.Drawing.Point(8, 41);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(63, 13);
            this.lblCustomer.TabIndex = 111;
            this.lblCustomer.Text = "Customer";
            // 
            // txtCustomerDescription
            // 
            this.txtCustomerDescription.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerDescription.Location = new System.Drawing.Point(240, 38);
            this.txtCustomerDescription.Name = "txtCustomerDescription";
            this.txtCustomerDescription.Size = new System.Drawing.Size(341, 21);
            this.txtCustomerDescription.TabIndex = 1;
            this.txtCustomerDescription.TabStop = false;
            this.txtCustomerDescription.Enter += new System.EventHandler(this.txtCustomerDescription_Enter);
            this.txtCustomerDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerDescription_KeyDown);
            this.txtCustomerDescription.Leave += new System.EventHandler(this.txtCustomerDescription_Leave);
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerCode.Location = new System.Drawing.Point(108, 38);
            this.txtCustomerCode.MaxLength = 10;
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(131, 21);
            this.txtCustomerCode.TabIndex = 0;
            this.txtCustomerCode.TabStop = false;
            this.txtCustomerCode.Enter += new System.EventHandler(this.txtCustomerCode_Enter);
            this.txtCustomerCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerCode_KeyDown);
            this.txtCustomerCode.Leave += new System.EventHandler(this.txtCustomerCode_Leave);
            // 
            // lblReferenceNo
            // 
            this.lblReferenceNo.AutoSize = true;
            this.lblReferenceNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReferenceNo.Location = new System.Drawing.Point(259, 16);
            this.lblReferenceNo.Name = "lblReferenceNo";
            this.lblReferenceNo.Size = new System.Drawing.Size(84, 13);
            this.lblReferenceNo.TabIndex = 115;
            this.lblReferenceNo.Text = "Reference No";
            // 
            // txtReferenceNo
            // 
            this.txtReferenceNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReferenceNo.Location = new System.Drawing.Point(352, 13);
            this.txtReferenceNo.Name = "txtReferenceNo";
            this.txtReferenceNo.Size = new System.Drawing.Size(229, 21);
            this.txtReferenceNo.TabIndex = 2;
            this.txtReferenceNo.TabStop = false;
            this.txtReferenceNo.Enter += new System.EventHandler(this.txtReferenceNo_Enter);
            this.txtReferenceNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReferenceNo_KeyDown);
            this.txtReferenceNo.Leave += new System.EventHandler(this.txtReferenceNo_Leave);
            // 
            // dgvInvoice
            // 
            this.dgvInvoice.AllowUserToAddRows = false;
            this.dgvInvoice.AllowUserToDeleteRows = false;
            this.dgvInvoice.AllowUserToResizeColumns = false;
            this.dgvInvoice.AllowUserToResizeRows = false;
            this.dgvInvoice.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Row,
            this.ItemCode,
            this.ItemName,
            this.SellingPrice,
            this.Qty,
            this.DiscountPercentage,
            this.Amount});
            this.dgvInvoice.Location = new System.Drawing.Point(6, 15);
            this.dgvInvoice.Name = "dgvInvoice";
            this.dgvInvoice.RowHeadersVisible = false;
            this.dgvInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoice.Size = new System.Drawing.Size(815, 200);
            this.dgvInvoice.TabIndex = 117;
            this.dgvInvoice.TabStop = false;
            this.dgvInvoice.DoubleClick += new System.EventHandler(this.dgvInvoice_DoubleClick);
            this.dgvInvoice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvInvoice_KeyDown);
            // 
            // Row
            // 
            this.Row.DataPropertyName = "LineNo";
            this.Row.HeaderText = "Row";
            this.Row.Name = "Row";
            this.Row.ReadOnly = true;
            this.Row.Width = 50;
            // 
            // ItemCode
            // 
            this.ItemCode.DataPropertyName = "ItemCode";
            this.ItemCode.HeaderText = "Item Code";
            this.ItemCode.Name = "ItemCode";
            this.ItemCode.ReadOnly = true;
            this.ItemCode.Width = 131;
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "ItemName";
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            this.ItemName.Width = 250;
            // 
            // SellingPrice
            // 
            this.SellingPrice.DataPropertyName = "SellingPrice";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.SellingPrice.DefaultCellStyle = dataGridViewCellStyle6;
            this.SellingPrice.HeaderText = "Selling Price";
            this.SellingPrice.Name = "SellingPrice";
            this.SellingPrice.ReadOnly = true;
            // 
            // Qty
            // 
            this.Qty.DataPropertyName = "Qty";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Qty.DefaultCellStyle = dataGridViewCellStyle7;
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            this.Qty.Width = 70;
            // 
            // DiscountPercentage
            // 
            this.DiscountPercentage.DataPropertyName = "DiscountPercentage";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DiscountPercentage.DefaultCellStyle = dataGridViewCellStyle8;
            this.DiscountPercentage.HeaderText = "Dis%";
            this.DiscountPercentage.Name = "DiscountPercentage";
            this.DiscountPercentage.ReadOnly = true;
            this.DiscountPercentage.Width = 70;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle9;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // grpInvoiceDetail
            // 
            this.grpInvoiceDetail.Controls.Add(this.txtRow);
            this.grpInvoiceDetail.Controls.Add(this.txtAmount);
            this.grpInvoiceDetail.Controls.Add(this.txtItemDis);
            this.grpInvoiceDetail.Controls.Add(this.txtQty);
            this.grpInvoiceDetail.Controls.Add(this.txtSellingPrice);
            this.grpInvoiceDetail.Controls.Add(this.txtItemName);
            this.grpInvoiceDetail.Controls.Add(this.dgvInvoice);
            this.grpInvoiceDetail.Controls.Add(this.txtItemCode);
            this.grpInvoiceDetail.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpInvoiceDetail.Location = new System.Drawing.Point(4, 57);
            this.grpInvoiceDetail.Name = "grpInvoiceDetail";
            this.grpInvoiceDetail.Size = new System.Drawing.Size(828, 245);
            this.grpInvoiceDetail.TabIndex = 118;
            this.grpInvoiceDetail.TabStop = false;
            // 
            // txtRow
            // 
            this.txtRow.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRow.Location = new System.Drawing.Point(7, 218);
            this.txtRow.MaxLength = 20;
            this.txtRow.Name = "txtRow";
            this.txtRow.ReadOnly = true;
            this.txtRow.Size = new System.Drawing.Size(47, 21);
            this.txtRow.TabIndex = 125;
            this.txtRow.TabStop = false;
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtAmount.Location = new System.Drawing.Point(679, 218);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(142, 21);
            this.txtAmount.TabIndex = 124;
            this.txtAmount.TabStop = false;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyDown);
            // 
            // txtItemDis
            // 
            this.txtItemDis.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtItemDis.Location = new System.Drawing.Point(608, 218);
            this.txtItemDis.Name = "txtItemDis";
            this.txtItemDis.Size = new System.Drawing.Size(70, 21);
            this.txtItemDis.TabIndex = 123;
            this.txtItemDis.TabStop = false;
            this.txtItemDis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtItemDis.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemDis_KeyDown);
            this.txtItemDis.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtItemDis_KeyUp);
            this.txtItemDis.Leave += new System.EventHandler(this.txtItemDis_Leave);
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtQty.Location = new System.Drawing.Point(539, 218);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(68, 21);
            this.txtQty.TabIndex = 122;
            this.txtQty.TabStop = false;
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQty_KeyDown);
            this.txtQty.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtQty_KeyUp);
            this.txtQty.Leave += new System.EventHandler(this.txtQty_Leave);
            // 
            // txtSellingPrice
            // 
            this.txtSellingPrice.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtSellingPrice.Location = new System.Drawing.Point(438, 218);
            this.txtSellingPrice.Name = "txtSellingPrice";
            this.txtSellingPrice.Size = new System.Drawing.Size(100, 21);
            this.txtSellingPrice.TabIndex = 121;
            this.txtSellingPrice.TabStop = false;
            this.txtSellingPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSellingPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSellingPrice_KeyDown);
            this.txtSellingPrice.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSellingPrice_KeyUp);
            this.txtSellingPrice.Leave += new System.EventHandler(this.txtSellingPrice_Leave);
            // 
            // txtItemName
            // 
            this.txtItemName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(187, 218);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(250, 21);
            this.txtItemName.TabIndex = 5;
            this.txtItemName.TabStop = false;
            this.txtItemName.TextChanged += new System.EventHandler(this.txtItemName_TextChanged);
            this.txtItemName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemName_KeyDown);
            this.txtItemName.Leave += new System.EventHandler(this.txtItemName_Leave);
            // 
            // txtItemCode
            // 
            this.txtItemCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCode.Location = new System.Drawing.Point(55, 218);
            this.txtItemCode.MaxLength = 20;
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(131, 21);
            this.txtItemCode.TabIndex = 4;
            this.txtItemCode.TabStop = false;
            this.txtItemCode.TextChanged += new System.EventHandler(this.txtItemCode_TextChanged);
            this.txtItemCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemCode_KeyDown);
            this.txtItemCode.Leave += new System.EventHandler(this.txtItemCode_Leave);
            // 
            // lblLabReferenceNo
            // 
            this.lblLabReferenceNo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblLabReferenceNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabReferenceNo.Location = new System.Drawing.Point(8, 462);
            this.lblLabReferenceNo.Name = "lblLabReferenceNo";
            this.lblLabReferenceNo.Size = new System.Drawing.Size(107, 32);
            this.lblLabReferenceNo.TabIndex = 124;
            this.lblLabReferenceNo.Text = "This Location Stock";
            this.lblLabReferenceNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtThisLocationStock
            // 
            this.txtThisLocationStock.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtThisLocationStock.BackColor = System.Drawing.Color.Yellow;
            this.txtThisLocationStock.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThisLocationStock.ForeColor = System.Drawing.Color.Red;
            this.txtThisLocationStock.Location = new System.Drawing.Point(121, 462);
            this.txtThisLocationStock.MaxLength = 10;
            this.txtThisLocationStock.Name = "txtThisLocationStock";
            this.txtThisLocationStock.ReadOnly = true;
            this.txtThisLocationStock.Size = new System.Drawing.Size(142, 33);
            this.txtThisLocationStock.TabIndex = 123;
            this.txtThisLocationStock.TabStop = false;
            this.txtThisLocationStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtWarning
            // 
            this.txtWarning.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtWarning.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWarning.Location = new System.Drawing.Point(3, 10);
            this.txtWarning.Name = "txtWarning";
            this.txtWarning.ReadOnly = true;
            this.txtWarning.Size = new System.Drawing.Size(560, 21);
            this.txtWarning.TabIndex = 125;
            this.txtWarning.TabStop = false;
            this.txtWarning.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grpStatus
            // 
            this.grpStatus.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.grpStatus.Controls.Add(this.txtWarning);
            this.grpStatus.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpStatus.Location = new System.Drawing.Point(265, 462);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Size = new System.Drawing.Size(566, 35);
            this.grpStatus.TabIndex = 126;
            this.grpStatus.TabStop = false;
            // 
            // lblNetTotal
            // 
            this.lblNetTotal.AutoSize = true;
            this.lblNetTotal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetTotal.Location = new System.Drawing.Point(551, 390);
            this.lblNetTotal.Name = "lblNetTotal";
            this.lblNetTotal.Size = new System.Drawing.Size(57, 13);
            this.lblNetTotal.TabIndex = 133;
            this.lblNetTotal.Text = "Net Total";
            // 
            // txtNetAmount
            // 
            this.txtNetAmount.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtNetAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNetAmount.Location = new System.Drawing.Point(680, 387);
            this.txtNetAmount.Name = "txtNetAmount";
            this.txtNetAmount.ReadOnly = true;
            this.txtNetAmount.Size = new System.Drawing.Size(144, 21);
            this.txtNetAmount.TabIndex = 132;
            this.txtNetAmount.TabStop = false;
            this.txtNetAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNetAmount.Enter += new System.EventHandler(this.txtNetAmount_Enter);
            this.txtNetAmount.Leave += new System.EventHandler(this.txtNetAmount_Leave);
            // 
            // txtDiscountAmount
            // 
            this.txtDiscountAmount.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDiscountAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscountAmount.Location = new System.Drawing.Point(680, 333);
            this.txtDiscountAmount.Name = "txtDiscountAmount";
            this.txtDiscountAmount.ReadOnly = true;
            this.txtDiscountAmount.Size = new System.Drawing.Size(144, 21);
            this.txtDiscountAmount.TabIndex = 131;
            this.txtDiscountAmount.TabStop = false;
            this.txtDiscountAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDiscountAmount.Enter += new System.EventHandler(this.txtDiscountAmount_Enter);
            this.txtDiscountAmount.Leave += new System.EventHandler(this.txtDiscountAmount_Leave);
            // 
            // txtSubTotalDis
            // 
            this.txtSubTotalDis.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtSubTotalDis.Location = new System.Drawing.Point(638, 333);
            this.txtSubTotalDis.Name = "txtSubTotalDis";
            this.txtSubTotalDis.Size = new System.Drawing.Size(38, 21);
            this.txtSubTotalDis.TabIndex = 6;
            this.txtSubTotalDis.TabStop = false;
            this.txtSubTotalDis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSubTotalDis.Enter += new System.EventHandler(this.txtSubTotalDis_Enter);
            this.txtSubTotalDis.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSubTotalDis_KeyDown);
            this.txtSubTotalDis.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSubTotalDis_KeyUp);
            this.txtSubTotalDis.Leave += new System.EventHandler(this.txtSubTotalDis_Leave);
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.Location = new System.Drawing.Point(551, 336);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(72, 13);
            this.lblDiscount.TabIndex = 129;
            this.lblDiscount.Text = "Discount %";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(551, 309);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(82, 13);
            this.lblTotal.TabIndex = 128;
            this.lblTotal.Text = "Total Amount";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTotalAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(680, 306);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(144, 21);
            this.txtTotalAmount.TabIndex = 127;
            this.txtTotalAmount.TabStop = false;
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalAmount.Enter += new System.EventHandler(this.txtTotalAmount_Enter);
            this.txtTotalAmount.Leave += new System.EventHandler(this.txtTotalAmount_Leave);
            // 
            // txtPaidAmount
            // 
            this.txtPaidAmount.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtPaidAmount.Location = new System.Drawing.Point(680, 414);
            this.txtPaidAmount.Name = "txtPaidAmount";
            this.txtPaidAmount.Size = new System.Drawing.Size(144, 21);
            this.txtPaidAmount.TabIndex = 7;
            this.txtPaidAmount.TabStop = false;
            this.txtPaidAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPaidAmount.Visible = false;
            this.txtPaidAmount.Enter += new System.EventHandler(this.txtPaidAmount_Enter);
            this.txtPaidAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPaidAmount_KeyDown);
            this.txtPaidAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPaidAmount_KeyUp);
            this.txtPaidAmount.Leave += new System.EventHandler(this.txtPaidAmount_Leave);
            // 
            // lblPaidAmount
            // 
            this.lblPaidAmount.AutoSize = true;
            this.lblPaidAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaidAmount.Location = new System.Drawing.Point(551, 417);
            this.lblPaidAmount.Name = "lblPaidAmount";
            this.lblPaidAmount.Size = new System.Drawing.Size(79, 13);
            this.lblPaidAmount.TabIndex = 134;
            this.lblPaidAmount.Text = "Paid Amount";
            this.lblPaidAmount.Visible = false;
            // 
            // pbItem
            // 
            this.pbItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbItem.Location = new System.Drawing.Point(407, 327);
            this.pbItem.Name = "pbItem";
            this.pbItem.Size = new System.Drawing.Size(131, 135);
            this.pbItem.TabIndex = 136;
            this.pbItem.TabStop = false;
            // 
            // txtBalanceAmount
            // 
            this.txtBalanceAmount.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtBalanceAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalanceAmount.Location = new System.Drawing.Point(680, 441);
            this.txtBalanceAmount.Name = "txtBalanceAmount";
            this.txtBalanceAmount.ReadOnly = true;
            this.txtBalanceAmount.Size = new System.Drawing.Size(145, 21);
            this.txtBalanceAmount.TabIndex = 137;
            this.txtBalanceAmount.TabStop = false;
            this.txtBalanceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBalanceAmount.Visible = false;
            this.txtBalanceAmount.Enter += new System.EventHandler(this.txtBalanceAmount_Enter);
            this.txtBalanceAmount.Leave += new System.EventHandler(this.txtBalanceAmount_Leave);
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.Location = new System.Drawing.Point(551, 444);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(52, 13);
            this.lblBalance.TabIndex = 138;
            this.lblBalance.Text = "Balance";
            this.lblBalance.Visible = false;
            // 
            // dgvItemSearch
            // 
            this.dgvItemSearch.AllowUserToAddRows = false;
            this.dgvItemSearch.AllowUserToDeleteRows = false;
            this.dgvItemSearch.AllowUserToResizeColumns = false;
            this.dgvItemSearch.AllowUserToResizeRows = false;
            this.dgvItemSearch.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItemSearch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItemSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.SearchItemName,
            this.dataGridViewTextBoxColumn4,
            this.Stock});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItemSearch.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvItemSearch.Location = new System.Drawing.Point(11, 306);
            this.dgvItemSearch.Name = "dgvItemSearch";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItemSearch.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvItemSearch.RowHeadersVisible = false;
            this.dgvItemSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItemSearch.Size = new System.Drawing.Size(527, 133);
            this.dgvItemSearch.TabIndex = 126;
            this.dgvItemSearch.TabStop = false;
            this.dgvItemSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvItemSearch_KeyDown);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ItemCode";
            this.dataGridViewTextBoxColumn2.HeaderText = "Item Code";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 115;
            // 
            // SearchItemName
            // 
            this.SearchItemName.DataPropertyName = "ItemName";
            this.SearchItemName.HeaderText = "Item Name";
            this.SearchItemName.Name = "SearchItemName";
            this.SearchItemName.ReadOnly = true;
            this.SearchItemName.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "SellingPrice";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn4.HeaderText = "Selling Price";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // Stock
            // 
            this.Stock.DataPropertyName = "Stock";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Stock.DefaultCellStyle = dataGridViewCellStyle3;
            this.Stock.HeaderText = "Stock";
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            this.Stock.Width = 80;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(104, 10);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(95, 35);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "Print ";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtServiceCharge
            // 
            this.txtServiceCharge.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtServiceCharge.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServiceCharge.Location = new System.Drawing.Point(680, 360);
            this.txtServiceCharge.Name = "txtServiceCharge";
            this.txtServiceCharge.ReadOnly = true;
            this.txtServiceCharge.Size = new System.Drawing.Size(144, 21);
            this.txtServiceCharge.TabIndex = 139;
            this.txtServiceCharge.TabStop = false;
            this.txtServiceCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtServiceCharge.Enter += new System.EventHandler(this.txtServiceCharge_Enter);
            this.txtServiceCharge.Leave += new System.EventHandler(this.txtServiceCharge_Leave);
            // 
            // lblServiceCharge
            // 
            this.lblServiceCharge.AutoSize = true;
            this.lblServiceCharge.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiceCharge.Location = new System.Drawing.Point(551, 363);
            this.lblServiceCharge.Name = "lblServiceCharge";
            this.lblServiceCharge.Size = new System.Drawing.Size(96, 13);
            this.lblServiceCharge.TabIndex = 140;
            this.lblServiceCharge.Text = "Service Charge";
            // 
            // chkIsServiceCharge
            // 
            this.chkIsServiceCharge.AutoSize = true;
            this.chkIsServiceCharge.Checked = true;
            this.chkIsServiceCharge.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsServiceCharge.Location = new System.Drawing.Point(657, 363);
            this.chkIsServiceCharge.Name = "chkIsServiceCharge";
            this.chkIsServiceCharge.Size = new System.Drawing.Size(15, 14);
            this.chkIsServiceCharge.TabIndex = 141;
            this.chkIsServiceCharge.UseVisualStyleBackColor = true;
            this.chkIsServiceCharge.CheckedChanged += new System.EventHandler(this.chkIsServiceCharge_CheckedChanged);
            this.chkIsServiceCharge.Enter += new System.EventHandler(this.chkIsServiceCharge_Enter);
            this.chkIsServiceCharge.Leave += new System.EventHandler(this.chkIsServiceCharge_Leave);
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceNo.Location = new System.Drawing.Point(619, 41);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Size = new System.Drawing.Size(68, 13);
            this.lblInvoiceNo.TabIndex = 143;
            this.lblInvoiceNo.Text = "Invoice No";
            // 
            // cmbInvoiceNo
            // 
            this.cmbInvoiceNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbInvoiceNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbInvoiceNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbInvoiceNo.FormattingEnabled = true;
            this.cmbInvoiceNo.Location = new System.Drawing.Point(701, 38);
            this.cmbInvoiceNo.Name = "cmbInvoiceNo";
            this.cmbInvoiceNo.Size = new System.Drawing.Size(131, 21);
            this.cmbInvoiceNo.TabIndex = 126;
            this.cmbInvoiceNo.Enter += new System.EventHandler(this.cmbInvoiceNo_Enter);
            this.cmbInvoiceNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbInvoiceNo_KeyDown);
            this.cmbInvoiceNo.Leave += new System.EventHandler(this.cmbInvoiceNo_Leave);
            // 
            // FrmInvoiceReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 551);
            this.Name = "FrmInvoiceReturn";
            this.Text = "FrmInvoiceReturn";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmInvoiceReturn_KeyDown);
            this.grbMargin.ResumeLayout(false);
            this.grbMargin.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).EndInit();
            this.grpInvoiceDetail.ResumeLayout(false);
            this.grpInvoiceDetail.PerformLayout();
            this.grpStatus.ResumeLayout(false);
            this.grpStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Custom_Controllers.DateTimePickerCommon dtpDocumentDate;
        private Custom_Controllers.LableCommon lblDate;
        private Custom_Controllers.LableCommon lblDocumentNo;
        private Custom_Controllers.TextBoxDocumentNo txtDocumentNo;
        private Custom_Controllers.LableCommon lblCustomer;
        private Custom_Controllers.TextBoxDescription txtCustomerDescription;
        private Custom_Controllers.TextBoxMasterCode txtCustomerCode;
        private Custom_Controllers.LableCommon lblReferenceNo;
        private Custom_Controllers.TextBoxCommon txtReferenceNo;
        private Custom_Controllers.GridViewCommon dgvInvoice;
        private Custom_Controllers.GroupBoxCommon grpInvoiceDetail;
        private Custom_Controllers.TextBoxDescription txtItemName;
        private Custom_Controllers.TextBoxMasterCode txtItemCode;
        private Custom_Controllers.TextBoxCurrency txtSellingPrice;
        private Custom_Controllers.TextBoxCurrency txtItemDis;
        private Custom_Controllers.TextBoxCurrency txtQty;
        private Custom_Controllers.TextBoxCurrency txtAmount;
        private Custom_Controllers.LableCommon lblLabReferenceNo;
        private Custom_Controllers.TextBoxMasterCode txtThisLocationStock;
        private Custom_Controllers.TextBoxCommon txtWarning;
        private Custom_Controllers.GroupBoxCommon grpStatus;
        private Custom_Controllers.LableCommon lblNetTotal;
        private Custom_Controllers.TextBoxCurrency txtNetAmount;
        private Custom_Controllers.TextBoxCurrency txtDiscountAmount;
        private Custom_Controllers.TextBoxCurrency txtSubTotalDis;
        private Custom_Controllers.LableCommon lblDiscount;
        private Custom_Controllers.LableCommon lblTotal;
        private Custom_Controllers.TextBoxCurrency txtTotalAmount;
        private Custom_Controllers.TextBoxCurrency txtPaidAmount;
        private Custom_Controllers.LableCommon lblPaidAmount;
        private System.Windows.Forms.PictureBox pbItem;
        private Custom_Controllers.TextBoxMasterCode txtRow;
        private Custom_Controllers.TextBoxCurrency txtBalanceAmount;
        private Custom_Controllers.LableCommon lblBalance;
        private Custom_Controllers.GridViewCommon dgvItemSearch;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Row;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellingPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountPercentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        protected System.Windows.Forms.Button btnPrint;
        private Custom_Controllers.LableCommon lblServiceCharge;
        private Custom_Controllers.TextBoxCurrency txtServiceCharge;
        private System.Windows.Forms.CheckBox chkIsServiceCharge;
        private Custom_Controllers.LableCommon lblInvoiceNo;
        private Custom_Controllers.ComboBoxCommonDropDown cmbInvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SearchItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
    }
}