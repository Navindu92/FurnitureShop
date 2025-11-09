namespace NSoft.ERP.UI.Windows.Inventory
{
    partial class FrmGoodsReceivedNote
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGoodsReceivedNote));
            this.dtpDocumentDate = new NSoft.ERP.UI.Windows.Custom_Controllers.DateTimePickerCommon();
            this.lblDate = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lblDocumentNo = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtDocumentNo = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDocumentNo();
            this.lblSupplier = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtSupplierDescription = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.txtSupplierCode = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxMasterCode();
            this.lblReferenceNo = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtReferenceNo = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCommon();
            this.dgvGoodsReceivedNote = new NSoft.ERP.UI.Windows.Custom_Controllers.GridViewCommon();
            this.Row = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Margin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SellingPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FreeQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountPercentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpGoodsReceivedNoteDetail = new NSoft.ERP.UI.Windows.Custom_Controllers.GroupBoxCommon();
            this.txtFreeQty = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxQty();
            this.txtQty = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxQty();
            this.txtCostPrice = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.txtMargin = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.txtRow = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxMasterCode();
            this.txtAmount = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.txtItemDis = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
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
            this.pbItem = new System.Windows.Forms.PictureBox();
            this.dgvItemSearch = new NSoft.ERP.UI.Windows.Custom_Controllers.GridViewCommon();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SearchItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.grpMarginWarning = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.lableCommon3 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.grbMargin.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoodsReceivedNote)).BeginInit();
            this.grpGoodsReceivedNoteDetail.SuspendLayout();
            this.grpStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemSearch)).BeginInit();
            this.grpMarginWarning.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // grbMargin
            // 
            this.grbMargin.Controls.Add(this.dgvItemSearch);
            this.grbMargin.Controls.Add(this.pbItem);
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
            this.grbMargin.Controls.Add(this.txtSupplierDescription);
            this.grbMargin.Controls.Add(this.txtSupplierCode);
            this.grbMargin.Controls.Add(this.lblSupplier);
            this.grbMargin.Controls.Add(this.dtpDocumentDate);
            this.grbMargin.Controls.Add(this.lblDate);
            this.grbMargin.Controls.Add(this.lblDocumentNo);
            this.grbMargin.Controls.Add(this.txtDocumentNo);
            this.grbMargin.Controls.Add(this.grpGoodsReceivedNoteDetail);
            this.grbMargin.Size = new System.Drawing.Size(1042, 531);
            this.grbMargin.Controls.SetChildIndex(this.grpGoodsReceivedNoteDetail, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtDocumentNo, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblDocumentNo, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblDate, 0);
            this.grbMargin.Controls.SetChildIndex(this.dtpDocumentDate, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblSupplier, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtSupplierCode, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtSupplierDescription, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblReferenceNo, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtReferenceNo, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtThisLocationStock, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblLabReferenceNo, 0);
            this.grbMargin.Controls.SetChildIndex(this.groupBox1, 0);
            this.grbMargin.Controls.SetChildIndex(this.groupBox2, 0);
            this.grbMargin.Controls.SetChildIndex(this.grpStatus, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtTotalAmount, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblTotal, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblDiscount, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtSubTotalDis, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtDiscountAmount, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtNetAmount, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblNetTotal, 0);
            this.grbMargin.Controls.SetChildIndex(this.pbItem, 0);
            this.grbMargin.Controls.SetChildIndex(this.dgvItemSearch, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(830, 477);
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
            this.groupBox1.Location = new System.Drawing.Point(7, 477);
            this.groupBox1.Size = new System.Drawing.Size(202, 48);
            // 
            // btnView
            // 
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
            this.dtpDocumentDate.Location = new System.Drawing.Point(898, 13);
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
            this.lblDate.Location = new System.Drawing.Point(850, 16);
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
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplier.Location = new System.Drawing.Point(8, 41);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(54, 13);
            this.lblSupplier.TabIndex = 111;
            this.lblSupplier.Text = "Supplier";
            // 
            // txtSupplierDescription
            // 
            this.txtSupplierDescription.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierDescription.Location = new System.Drawing.Point(240, 38);
            this.txtSupplierDescription.Name = "txtSupplierDescription";
            this.txtSupplierDescription.Size = new System.Drawing.Size(341, 21);
            this.txtSupplierDescription.TabIndex = 1;
            this.txtSupplierDescription.TabStop = false;
            this.txtSupplierDescription.Enter += new System.EventHandler(this.txtSupplierDescription_Enter);
            this.txtSupplierDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSupplierDescription_KeyDown);
            this.txtSupplierDescription.Leave += new System.EventHandler(this.txtSupplierDescription_Leave);
            // 
            // txtSupplierCode
            // 
            this.txtSupplierCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierCode.Location = new System.Drawing.Point(108, 38);
            this.txtSupplierCode.MaxLength = 10;
            this.txtSupplierCode.Name = "txtSupplierCode";
            this.txtSupplierCode.Size = new System.Drawing.Size(131, 21);
            this.txtSupplierCode.TabIndex = 0;
            this.txtSupplierCode.TabStop = false;
            this.txtSupplierCode.Enter += new System.EventHandler(this.txtSupplierCode_Enter);
            this.txtSupplierCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSupplierCode_KeyDown);
            this.txtSupplierCode.Leave += new System.EventHandler(this.txtSupplierCode_Leave);
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
            // dgvGoodsReceivedNote
            // 
            this.dgvGoodsReceivedNote.AllowUserToAddRows = false;
            this.dgvGoodsReceivedNote.AllowUserToDeleteRows = false;
            this.dgvGoodsReceivedNote.AllowUserToResizeColumns = false;
            this.dgvGoodsReceivedNote.AllowUserToResizeRows = false;
            this.dgvGoodsReceivedNote.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvGoodsReceivedNote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGoodsReceivedNote.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Row,
            this.ItemCode,
            this.ItemName,
            this.CostPrice,
            this.Margin,
            this.SellingPrice,
            this.Qty,
            this.FreeQty,
            this.DiscountPercentage,
            this.Amount});
            this.dgvGoodsReceivedNote.Location = new System.Drawing.Point(6, 13);
            this.dgvGoodsReceivedNote.Name = "dgvGoodsReceivedNote";
            this.dgvGoodsReceivedNote.RowHeadersVisible = false;
            this.dgvGoodsReceivedNote.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGoodsReceivedNote.Size = new System.Drawing.Size(1023, 201);
            this.dgvGoodsReceivedNote.TabIndex = 117;
            this.dgvGoodsReceivedNote.TabStop = false;
            this.dgvGoodsReceivedNote.DoubleClick += new System.EventHandler(this.dgvGoodsReceivedNote_DoubleClick);
            this.dgvGoodsReceivedNote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvGoodsReceivedNote_KeyDown);
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
            // CostPrice
            // 
            this.CostPrice.DataPropertyName = "CostPrice";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CostPrice.DefaultCellStyle = dataGridViewCellStyle6;
            this.CostPrice.HeaderText = "Cost Price";
            this.CostPrice.Name = "CostPrice";
            this.CostPrice.ReadOnly = true;
            this.CostPrice.Width = 90;
            // 
            // Margin
            // 
            this.Margin.DataPropertyName = "MarginPercentage";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Margin.DefaultCellStyle = dataGridViewCellStyle7;
            this.Margin.HeaderText = "Markup%";
            this.Margin.Name = "Margin";
            this.Margin.ReadOnly = true;
            this.Margin.Width = 85;
            // 
            // SellingPrice
            // 
            this.SellingPrice.DataPropertyName = "SellingPrice";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.SellingPrice.DefaultCellStyle = dataGridViewCellStyle8;
            this.SellingPrice.HeaderText = "Selling Price";
            this.SellingPrice.Name = "SellingPrice";
            this.SellingPrice.ReadOnly = true;
            // 
            // Qty
            // 
            this.Qty.DataPropertyName = "Qty";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Qty.DefaultCellStyle = dataGridViewCellStyle9;
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            this.Qty.Width = 60;
            // 
            // FreeQty
            // 
            this.FreeQty.DataPropertyName = "FreeQty";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.FreeQty.DefaultCellStyle = dataGridViewCellStyle10;
            this.FreeQty.HeaderText = "Free";
            this.FreeQty.Name = "FreeQty";
            this.FreeQty.ReadOnly = true;
            this.FreeQty.Width = 60;
            // 
            // DiscountPercentage
            // 
            this.DiscountPercentage.DataPropertyName = "DiscountPercentage";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DiscountPercentage.DefaultCellStyle = dataGridViewCellStyle11;
            this.DiscountPercentage.HeaderText = "Dis%";
            this.DiscountPercentage.Name = "DiscountPercentage";
            this.DiscountPercentage.ReadOnly = true;
            this.DiscountPercentage.Width = 60;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle12;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // grpGoodsReceivedNoteDetail
            // 
            this.grpGoodsReceivedNoteDetail.Controls.Add(this.txtFreeQty);
            this.grpGoodsReceivedNoteDetail.Controls.Add(this.txtQty);
            this.grpGoodsReceivedNoteDetail.Controls.Add(this.txtCostPrice);
            this.grpGoodsReceivedNoteDetail.Controls.Add(this.txtMargin);
            this.grpGoodsReceivedNoteDetail.Controls.Add(this.txtRow);
            this.grpGoodsReceivedNoteDetail.Controls.Add(this.txtAmount);
            this.grpGoodsReceivedNoteDetail.Controls.Add(this.txtItemDis);
            this.grpGoodsReceivedNoteDetail.Controls.Add(this.txtSellingPrice);
            this.grpGoodsReceivedNoteDetail.Controls.Add(this.txtItemName);
            this.grpGoodsReceivedNoteDetail.Controls.Add(this.dgvGoodsReceivedNote);
            this.grpGoodsReceivedNoteDetail.Controls.Add(this.txtItemCode);
            this.grpGoodsReceivedNoteDetail.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGoodsReceivedNoteDetail.Location = new System.Drawing.Point(4, 57);
            this.grpGoodsReceivedNoteDetail.Name = "grpGoodsReceivedNoteDetail";
            this.grpGoodsReceivedNoteDetail.Size = new System.Drawing.Size(1034, 245);
            this.grpGoodsReceivedNoteDetail.TabIndex = 118;
            this.grpGoodsReceivedNoteDetail.TabStop = false;
            // 
            // txtFreeQty
            // 
            this.txtFreeQty.Location = new System.Drawing.Point(773, 218);
            this.txtFreeQty.Name = "txtFreeQty";
            this.txtFreeQty.Size = new System.Drawing.Size(59, 21);
            this.txtFreeQty.TabIndex = 130;
            this.txtFreeQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFreeQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFreeQty_KeyDown);
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(713, 218);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(59, 21);
            this.txtQty.TabIndex = 129;
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQty_KeyDown);
            this.txtQty.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtQty_KeyUp);
            this.txtQty.Leave += new System.EventHandler(this.txtQty_Leave);
            // 
            // txtCostPrice
            // 
            this.txtCostPrice.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtCostPrice.Location = new System.Drawing.Point(438, 218);
            this.txtCostPrice.Name = "txtCostPrice";
            this.txtCostPrice.Size = new System.Drawing.Size(90, 21);
            this.txtCostPrice.TabIndex = 128;
            this.txtCostPrice.TabStop = false;
            this.txtCostPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCostPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCostPrice_KeyDown);
            this.txtCostPrice.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCostPrice_KeyUp);
            this.txtCostPrice.Leave += new System.EventHandler(this.txtCostPrice_Leave);
            // 
            // txtMargin
            // 
            this.txtMargin.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtMargin.Location = new System.Drawing.Point(529, 218);
            this.txtMargin.Name = "txtMargin";
            this.txtMargin.ReadOnly = true;
            this.txtMargin.Size = new System.Drawing.Size(83, 21);
            this.txtMargin.TabIndex = 127;
            this.txtMargin.TabStop = false;
            this.txtMargin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMargin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMargin_KeyDown);
            this.txtMargin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMargin_KeyUp);
            this.txtMargin.Leave += new System.EventHandler(this.txtMargin_Leave);
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
            this.txtAmount.Location = new System.Drawing.Point(892, 218);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(137, 21);
            this.txtAmount.TabIndex = 124;
            this.txtAmount.TabStop = false;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyDown);
            // 
            // txtItemDis
            // 
            this.txtItemDis.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtItemDis.Location = new System.Drawing.Point(833, 218);
            this.txtItemDis.Name = "txtItemDis";
            this.txtItemDis.Size = new System.Drawing.Size(58, 21);
            this.txtItemDis.TabIndex = 123;
            this.txtItemDis.TabStop = false;
            this.txtItemDis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtItemDis.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemDis_KeyDown);
            this.txtItemDis.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtItemDis_KeyUp);
            this.txtItemDis.Leave += new System.EventHandler(this.txtItemDis_Leave);
            // 
            // txtSellingPrice
            // 
            this.txtSellingPrice.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtSellingPrice.Location = new System.Drawing.Point(613, 218);
            this.txtSellingPrice.Name = "txtSellingPrice";
            this.txtSellingPrice.Size = new System.Drawing.Size(99, 21);
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
            this.lblLabReferenceNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabReferenceNo.Location = new System.Drawing.Point(8, 444);
            this.lblLabReferenceNo.Name = "lblLabReferenceNo";
            this.lblLabReferenceNo.Size = new System.Drawing.Size(107, 32);
            this.lblLabReferenceNo.TabIndex = 124;
            this.lblLabReferenceNo.Text = "This Location Stock";
            this.lblLabReferenceNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtThisLocationStock
            // 
            this.txtThisLocationStock.BackColor = System.Drawing.Color.Yellow;
            this.txtThisLocationStock.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThisLocationStock.ForeColor = System.Drawing.Color.Red;
            this.txtThisLocationStock.Location = new System.Drawing.Point(121, 444);
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
            this.txtWarning.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWarning.Location = new System.Drawing.Point(3, 10);
            this.txtWarning.Name = "txtWarning";
            this.txtWarning.ReadOnly = true;
            this.txtWarning.Size = new System.Drawing.Size(763, 21);
            this.txtWarning.TabIndex = 125;
            this.txtWarning.TabStop = false;
            this.txtWarning.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // grpStatus
            // 
            this.grpStatus.Controls.Add(this.txtWarning);
            this.grpStatus.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpStatus.Location = new System.Drawing.Point(265, 444);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Size = new System.Drawing.Size(769, 35);
            this.grpStatus.TabIndex = 126;
            this.grpStatus.TabStop = false;
            // 
            // lblNetTotal
            // 
            this.lblNetTotal.AutoSize = true;
            this.lblNetTotal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetTotal.Location = new System.Drawing.Point(768, 365);
            this.lblNetTotal.Name = "lblNetTotal";
            this.lblNetTotal.Size = new System.Drawing.Size(57, 13);
            this.lblNetTotal.TabIndex = 133;
            this.lblNetTotal.Text = "Net Total";
            // 
            // txtNetAmount
            // 
            this.txtNetAmount.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtNetAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNetAmount.Location = new System.Drawing.Point(897, 362);
            this.txtNetAmount.Name = "txtNetAmount";
            this.txtNetAmount.ReadOnly = true;
            this.txtNetAmount.Size = new System.Drawing.Size(137, 21);
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
            this.txtDiscountAmount.Location = new System.Drawing.Point(897, 335);
            this.txtDiscountAmount.Name = "txtDiscountAmount";
            this.txtDiscountAmount.ReadOnly = true;
            this.txtDiscountAmount.Size = new System.Drawing.Size(136, 21);
            this.txtDiscountAmount.TabIndex = 131;
            this.txtDiscountAmount.TabStop = false;
            this.txtDiscountAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDiscountAmount.Enter += new System.EventHandler(this.txtDiscountAmount_Enter);
            this.txtDiscountAmount.Leave += new System.EventHandler(this.txtDiscountAmount_Leave);
            // 
            // txtSubTotalDis
            // 
            this.txtSubTotalDis.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtSubTotalDis.Location = new System.Drawing.Point(855, 335);
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
            this.lblDiscount.Location = new System.Drawing.Point(768, 338);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(72, 13);
            this.lblDiscount.TabIndex = 129;
            this.lblDiscount.Text = "Discount %";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(768, 311);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(82, 13);
            this.lblTotal.TabIndex = 128;
            this.lblTotal.Text = "Total Amount";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTotalAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(897, 308);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(137, 21);
            this.txtTotalAmount.TabIndex = 127;
            this.txtTotalAmount.TabStop = false;
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalAmount.Enter += new System.EventHandler(this.txtTotalAmount_Enter);
            this.txtTotalAmount.Leave += new System.EventHandler(this.txtTotalAmount_Leave);
            // 
            // pbItem
            // 
            this.pbItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbItem.Location = new System.Drawing.Point(612, 309);
            this.pbItem.Name = "pbItem";
            this.pbItem.Size = new System.Drawing.Size(131, 135);
            this.pbItem.TabIndex = 136;
            this.pbItem.TabStop = false;
            this.pbItem.Click += new System.EventHandler(this.pbItem_Click);
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
            // grpMarginWarning
            // 
            this.grpMarginWarning.BackColor = System.Drawing.Color.LightGray;
            this.grpMarginWarning.Controls.Add(this.pictureBox1);
            this.grpMarginWarning.Controls.Add(this.btnOk);
            this.grpMarginWarning.Controls.Add(this.lableCommon3);
            this.grpMarginWarning.Location = new System.Drawing.Point(337, 151);
            this.grpMarginWarning.Name = "grpMarginWarning";
            this.grpMarginWarning.Size = new System.Drawing.Size(377, 215);
            this.grpMarginWarning.TabIndex = 147;
            this.grpMarginWarning.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(146, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 114;
            this.pictureBox1.TabStop = false;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(151, 172);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(71, 32);
            this.btnOk.TabIndex = 113;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lableCommon3
            // 
            this.lableCommon3.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon3.ForeColor = System.Drawing.Color.Red;
            this.lableCommon3.Location = new System.Drawing.Point(18, 90);
            this.lableCommon3.Name = "lableCommon3";
            this.lableCommon3.Size = new System.Drawing.Size(350, 79);
            this.lableCommon3.TabIndex = 112;
            this.lableCommon3.Text = "You are getting an abnormal Markup percentage, Please Re-Check.";
            this.lableCommon3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmGoodsReceivedNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 533);
            this.Controls.Add(this.grpMarginWarning);
            this.Name = "FrmGoodsReceivedNote";
            this.Text = "FrmGoodsReceivedNote";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmGoodsReceivedNote_KeyDown);
            this.Controls.SetChildIndex(this.grbMargin, 0);
            this.Controls.SetChildIndex(this.grpMarginWarning, 0);
            this.grbMargin.ResumeLayout(false);
            this.grbMargin.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoodsReceivedNote)).EndInit();
            this.grpGoodsReceivedNoteDetail.ResumeLayout(false);
            this.grpGoodsReceivedNoteDetail.PerformLayout();
            this.grpStatus.ResumeLayout(false);
            this.grpStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemSearch)).EndInit();
            this.grpMarginWarning.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Custom_Controllers.DateTimePickerCommon dtpDocumentDate;
        private Custom_Controllers.LableCommon lblDate;
        private Custom_Controllers.LableCommon lblDocumentNo;
        private Custom_Controllers.TextBoxDocumentNo txtDocumentNo;
        private Custom_Controllers.LableCommon lblSupplier;
        private Custom_Controllers.TextBoxDescription txtSupplierDescription;
        private Custom_Controllers.TextBoxMasterCode txtSupplierCode;
        private Custom_Controllers.LableCommon lblReferenceNo;
        private Custom_Controllers.TextBoxCommon txtReferenceNo;
        private Custom_Controllers.GridViewCommon dgvGoodsReceivedNote;
        private Custom_Controllers.GroupBoxCommon grpGoodsReceivedNoteDetail;
        private Custom_Controllers.TextBoxDescription txtItemName;
        private Custom_Controllers.TextBoxMasterCode txtItemCode;
        private Custom_Controllers.TextBoxCurrency txtSellingPrice;
        private Custom_Controllers.TextBoxCurrency txtItemDis;
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
        private System.Windows.Forms.PictureBox pbItem;
        private Custom_Controllers.TextBoxMasterCode txtRow;
        private Custom_Controllers.GridViewCommon dgvItemSearch;
        private System.Windows.Forms.Timer timer1;
        private Custom_Controllers.TextBoxCurrency txtMargin;
        private Custom_Controllers.TextBoxCurrency txtCostPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SearchItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Row;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Margin;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellingPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn FreeQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountPercentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private Custom_Controllers.TextBoxQty txtQty;
        private Custom_Controllers.TextBoxQty txtFreeQty;
        private System.Windows.Forms.GroupBox grpMarginWarning;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnOk;
        private Custom_Controllers.LableCommon lableCommon3;
    }
}