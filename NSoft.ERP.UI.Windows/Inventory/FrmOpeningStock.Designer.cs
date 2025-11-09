namespace NSoft.ERP.UI.Windows.Inventory
{
    partial class FrmOpeningStock
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtpDocumentDate = new NSoft.ERP.UI.Windows.Custom_Controllers.DateTimePickerCommon();
            this.lblDate = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lblDocumentNo = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtDocumentNo = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDocumentNo();
            this.lblReferenceNo = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtReferenceNo = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCommon();
            this.dgvOpeningStock = new NSoft.ERP.UI.Windows.Custom_Controllers.GridViewCommon();
            this.Row = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SellingPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SellingValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpOpeningStockDetail = new NSoft.ERP.UI.Windows.Custom_Controllers.GroupBoxCommon();
            this.txtCostValue = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.txtCostPrice = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.txtRow = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxMasterCode();
            this.txtSellingValue = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.txtQty = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.txtSellingPrice = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.txtItemName = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.txtItemCode = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxMasterCode();
            this.lblLabReferenceNo = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtThisLocationStock = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxMasterCode();
            this.txtWarning = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCommon();
            this.grpStatus = new NSoft.ERP.UI.Windows.Custom_Controllers.GroupBoxCommon();
            this.lblTotalQty = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtTotalSellingValue = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.txtTotalCostValue = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.lblTotalSellingValue = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lblTotalCostValue = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtTotalQty = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.pbItem = new System.Windows.Forms.PictureBox();
            this.dgvItemSearch = new NSoft.ERP.UI.Windows.Custom_Controllers.GridViewCommon();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtRemark = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCommon();
            this.lblRemark = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SearchItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbMargin.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpeningStock)).BeginInit();
            this.grpOpeningStockDetail.SuspendLayout();
            this.grpStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // grbMargin
            // 
            this.grbMargin.Controls.Add(this.txtRemark);
            this.grbMargin.Controls.Add(this.lblRemark);
            this.grbMargin.Controls.Add(this.dgvItemSearch);
            this.grbMargin.Controls.Add(this.pbItem);
            this.grbMargin.Controls.Add(this.lblTotalQty);
            this.grbMargin.Controls.Add(this.txtTotalSellingValue);
            this.grbMargin.Controls.Add(this.txtTotalCostValue);
            this.grbMargin.Controls.Add(this.lblTotalSellingValue);
            this.grbMargin.Controls.Add(this.lblTotalCostValue);
            this.grbMargin.Controls.Add(this.txtTotalQty);
            this.grbMargin.Controls.Add(this.grpStatus);
            this.grbMargin.Controls.Add(this.lblLabReferenceNo);
            this.grbMargin.Controls.Add(this.txtThisLocationStock);
            this.grbMargin.Controls.Add(this.txtReferenceNo);
            this.grbMargin.Controls.Add(this.lblReferenceNo);
            this.grbMargin.Controls.Add(this.dtpDocumentDate);
            this.grbMargin.Controls.Add(this.lblDate);
            this.grbMargin.Controls.Add(this.lblDocumentNo);
            this.grbMargin.Controls.Add(this.txtDocumentNo);
            this.grbMargin.Controls.Add(this.grpOpeningStockDetail);
            this.grbMargin.Size = new System.Drawing.Size(972, 531);
            this.grbMargin.Controls.SetChildIndex(this.grpOpeningStockDetail, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtDocumentNo, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblDocumentNo, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblDate, 0);
            this.grbMargin.Controls.SetChildIndex(this.dtpDocumentDate, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblReferenceNo, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtReferenceNo, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtThisLocationStock, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblLabReferenceNo, 0);
            this.grbMargin.Controls.SetChildIndex(this.groupBox1, 0);
            this.grbMargin.Controls.SetChildIndex(this.groupBox2, 0);
            this.grbMargin.Controls.SetChildIndex(this.grpStatus, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtTotalQty, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblTotalCostValue, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblTotalSellingValue, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtTotalCostValue, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtTotalSellingValue, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblTotalQty, 0);
            this.grbMargin.Controls.SetChildIndex(this.pbItem, 0);
            this.grbMargin.Controls.SetChildIndex(this.dgvItemSearch, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblRemark, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtRemark, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(760, 477);
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
            this.dtpDocumentDate.Location = new System.Drawing.Point(828, 12);
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
            this.lblDate.Location = new System.Drawing.Point(780, 15);
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
            // dgvOpeningStock
            // 
            this.dgvOpeningStock.AllowUserToAddRows = false;
            this.dgvOpeningStock.AllowUserToDeleteRows = false;
            this.dgvOpeningStock.AllowUserToResizeColumns = false;
            this.dgvOpeningStock.AllowUserToResizeRows = false;
            this.dgvOpeningStock.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvOpeningStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOpeningStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Row,
            this.ItemCode,
            this.ItemName,
            this.CostPrice,
            this.SellingPrice,
            this.Qty,
            this.CostValue,
            this.SellingValue});
            this.dgvOpeningStock.Location = new System.Drawing.Point(6, 15);
            this.dgvOpeningStock.Name = "dgvOpeningStock";
            this.dgvOpeningStock.RowHeadersVisible = false;
            this.dgvOpeningStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOpeningStock.Size = new System.Drawing.Size(952, 200);
            this.dgvOpeningStock.TabIndex = 117;
            this.dgvOpeningStock.TabStop = false;
            this.dgvOpeningStock.DoubleClick += new System.EventHandler(this.dgvOpeningStock_DoubleClick);
            this.dgvOpeningStock.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvOpeningStock_KeyDown);
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
            // 
            // SellingPrice
            // 
            this.SellingPrice.DataPropertyName = "SellingPrice";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.SellingPrice.DefaultCellStyle = dataGridViewCellStyle7;
            this.SellingPrice.HeaderText = "Selling Price";
            this.SellingPrice.Name = "SellingPrice";
            this.SellingPrice.ReadOnly = true;
            // 
            // Qty
            // 
            this.Qty.DataPropertyName = "Qty";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Qty.DefaultCellStyle = dataGridViewCellStyle8;
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            this.Qty.Width = 70;
            // 
            // CostValue
            // 
            this.CostValue.DataPropertyName = "CostValue";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CostValue.DefaultCellStyle = dataGridViewCellStyle9;
            this.CostValue.HeaderText = "Cost Value";
            this.CostValue.Name = "CostValue";
            this.CostValue.ReadOnly = true;
            // 
            // SellingValue
            // 
            this.SellingValue.DataPropertyName = "SellingValue";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.SellingValue.DefaultCellStyle = dataGridViewCellStyle10;
            this.SellingValue.HeaderText = "Selling Value";
            this.SellingValue.Name = "SellingValue";
            this.SellingValue.ReadOnly = true;
            this.SellingValue.Width = 110;
            // 
            // grpOpeningStockDetail
            // 
            this.grpOpeningStockDetail.Controls.Add(this.txtCostValue);
            this.grpOpeningStockDetail.Controls.Add(this.txtCostPrice);
            this.grpOpeningStockDetail.Controls.Add(this.txtRow);
            this.grpOpeningStockDetail.Controls.Add(this.txtSellingValue);
            this.grpOpeningStockDetail.Controls.Add(this.txtQty);
            this.grpOpeningStockDetail.Controls.Add(this.txtSellingPrice);
            this.grpOpeningStockDetail.Controls.Add(this.txtItemName);
            this.grpOpeningStockDetail.Controls.Add(this.dgvOpeningStock);
            this.grpOpeningStockDetail.Controls.Add(this.txtItemCode);
            this.grpOpeningStockDetail.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpOpeningStockDetail.Location = new System.Drawing.Point(4, 57);
            this.grpOpeningStockDetail.Name = "grpOpeningStockDetail";
            this.grpOpeningStockDetail.Size = new System.Drawing.Size(964, 245);
            this.grpOpeningStockDetail.TabIndex = 118;
            this.grpOpeningStockDetail.TabStop = false;
            // 
            // txtCostValue
            // 
            this.txtCostValue.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtCostValue.Location = new System.Drawing.Point(711, 218);
            this.txtCostValue.Name = "txtCostValue";
            this.txtCostValue.ReadOnly = true;
            this.txtCostValue.Size = new System.Drawing.Size(100, 21);
            this.txtCostValue.TabIndex = 127;
            this.txtCostValue.TabStop = false;
            this.txtCostValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCostValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCostValue_KeyDown);
            // 
            // txtCostPrice
            // 
            this.txtCostPrice.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtCostPrice.Location = new System.Drawing.Point(438, 218);
            this.txtCostPrice.Name = "txtCostPrice";
            this.txtCostPrice.Size = new System.Drawing.Size(100, 21);
            this.txtCostPrice.TabIndex = 126;
            this.txtCostPrice.TabStop = false;
            this.txtCostPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCostPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCostPrice_KeyDown);
            this.txtCostPrice.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCostPrice_KeyUp);
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
            // txtSellingValue
            // 
            this.txtSellingValue.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtSellingValue.Location = new System.Drawing.Point(812, 218);
            this.txtSellingValue.Name = "txtSellingValue";
            this.txtSellingValue.ReadOnly = true;
            this.txtSellingValue.Size = new System.Drawing.Size(146, 21);
            this.txtSellingValue.TabIndex = 124;
            this.txtSellingValue.TabStop = false;
            this.txtSellingValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSellingValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSellingValue_KeyDown);
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtQty.Location = new System.Drawing.Point(642, 218);
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
            this.txtSellingPrice.Location = new System.Drawing.Point(539, 218);
            this.txtSellingPrice.Name = "txtSellingPrice";
            this.txtSellingPrice.Size = new System.Drawing.Size(101, 21);
            this.txtSellingPrice.TabIndex = 121;
            this.txtSellingPrice.TabStop = false;
            this.txtSellingPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSellingPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSellingPrice_KeyDown);
            this.txtSellingPrice.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSellingPrice_KeyUp);
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
            this.txtWarning.Size = new System.Drawing.Size(693, 21);
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
            this.grpStatus.Size = new System.Drawing.Size(699, 35);
            this.grpStatus.TabIndex = 126;
            this.grpStatus.TabStop = false;
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.AutoSize = true;
            this.lblTotalQty.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalQty.Location = new System.Drawing.Point(686, 305);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Size = new System.Drawing.Size(58, 13);
            this.lblTotalQty.TabIndex = 133;
            this.lblTotalQty.Text = "Total Qty";
            // 
            // txtTotalSellingValue
            // 
            this.txtTotalSellingValue.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTotalSellingValue.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalSellingValue.Location = new System.Drawing.Point(816, 356);
            this.txtTotalSellingValue.Name = "txtTotalSellingValue";
            this.txtTotalSellingValue.ReadOnly = true;
            this.txtTotalSellingValue.Size = new System.Drawing.Size(146, 21);
            this.txtTotalSellingValue.TabIndex = 132;
            this.txtTotalSellingValue.TabStop = false;
            this.txtTotalSellingValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalSellingValue.Enter += new System.EventHandler(this.txtTotalSellingValue_Enter);
            this.txtTotalSellingValue.Leave += new System.EventHandler(this.txtTotalSellingValue_Leave);
            // 
            // txtTotalCostValue
            // 
            this.txtTotalCostValue.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTotalCostValue.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalCostValue.Location = new System.Drawing.Point(816, 329);
            this.txtTotalCostValue.Name = "txtTotalCostValue";
            this.txtTotalCostValue.ReadOnly = true;
            this.txtTotalCostValue.Size = new System.Drawing.Size(146, 21);
            this.txtTotalCostValue.TabIndex = 131;
            this.txtTotalCostValue.TabStop = false;
            this.txtTotalCostValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalCostValue.Enter += new System.EventHandler(this.txtTotalCostValue_Enter);
            this.txtTotalCostValue.Leave += new System.EventHandler(this.txtTotalCostValue_Leave);
            // 
            // lblTotalSellingValue
            // 
            this.lblTotalSellingValue.AutoSize = true;
            this.lblTotalSellingValue.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSellingValue.Location = new System.Drawing.Point(686, 359);
            this.lblTotalSellingValue.Name = "lblTotalSellingValue";
            this.lblTotalSellingValue.Size = new System.Drawing.Size(111, 13);
            this.lblTotalSellingValue.TabIndex = 129;
            this.lblTotalSellingValue.Text = "Total Selling Value";
            // 
            // lblTotalCostValue
            // 
            this.lblTotalCostValue.AutoSize = true;
            this.lblTotalCostValue.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCostValue.Location = new System.Drawing.Point(686, 332);
            this.lblTotalCostValue.Name = "lblTotalCostValue";
            this.lblTotalCostValue.Size = new System.Drawing.Size(99, 13);
            this.lblTotalCostValue.TabIndex = 128;
            this.lblTotalCostValue.Text = "Total Cost Value";
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTotalQty.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalQty.Location = new System.Drawing.Point(816, 302);
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.ReadOnly = true;
            this.txtTotalQty.Size = new System.Drawing.Size(146, 21);
            this.txtTotalQty.TabIndex = 127;
            this.txtTotalQty.TabStop = false;
            this.txtTotalQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalQty.Enter += new System.EventHandler(this.txtTotalQty_Enter);
            this.txtTotalQty.Leave += new System.EventHandler(this.txtTotalQty_Leave);
            // 
            // pbItem
            // 
            this.pbItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbItem.Location = new System.Drawing.Point(407, 306);
            this.pbItem.Name = "pbItem";
            this.pbItem.Size = new System.Drawing.Size(131, 135);
            this.pbItem.TabIndex = 136;
            this.pbItem.TabStop = false;
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
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Location = new System.Drawing.Point(108, 39);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(473, 21);
            this.txtRemark.TabIndex = 139;
            this.txtRemark.TabStop = false;
            this.txtRemark.Enter += new System.EventHandler(this.txtRemark_Enter);
            this.txtRemark.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRemark_KeyDown);
            this.txtRemark.Leave += new System.EventHandler(this.txtRemark_Leave);
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemark.Location = new System.Drawing.Point(8, 42);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(52, 13);
            this.lblRemark.TabIndex = 140;
            this.lblRemark.Text = "Remark";
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
            // FrmOpeningStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 533);
            this.Name = "FrmOpeningStock";
            this.Text = "FrmOpeningStock";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmOpeningStock_KeyDown);
            this.grbMargin.ResumeLayout(false);
            this.grbMargin.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpeningStock)).EndInit();
            this.grpOpeningStockDetail.ResumeLayout(false);
            this.grpOpeningStockDetail.PerformLayout();
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
        private Custom_Controllers.LableCommon lblReferenceNo;
        private Custom_Controllers.TextBoxCommon txtReferenceNo;
        private Custom_Controllers.GridViewCommon dgvOpeningStock;
        private Custom_Controllers.GroupBoxCommon grpOpeningStockDetail;
        private Custom_Controllers.TextBoxDescription txtItemName;
        private Custom_Controllers.TextBoxMasterCode txtItemCode;
        private Custom_Controllers.TextBoxCurrency txtSellingPrice;
        private Custom_Controllers.TextBoxCurrency txtQty;
        private Custom_Controllers.TextBoxCurrency txtSellingValue;
        private Custom_Controllers.LableCommon lblLabReferenceNo;
        private Custom_Controllers.TextBoxMasterCode txtThisLocationStock;
        private Custom_Controllers.TextBoxCommon txtWarning;
        private Custom_Controllers.GroupBoxCommon grpStatus;
        private Custom_Controllers.LableCommon lblTotalQty;
        private Custom_Controllers.TextBoxCurrency txtTotalSellingValue;
        private Custom_Controllers.TextBoxCurrency txtTotalCostValue;
        private Custom_Controllers.LableCommon lblTotalSellingValue;
        private Custom_Controllers.LableCommon lblTotalCostValue;
        private Custom_Controllers.TextBoxCurrency txtTotalQty;
        private System.Windows.Forms.PictureBox pbItem;
        private Custom_Controllers.TextBoxMasterCode txtRow;
        private Custom_Controllers.GridViewCommon dgvItemSearch;
        private System.Windows.Forms.Timer timer1;
        private Custom_Controllers.TextBoxCommon txtRemark;
        private Custom_Controllers.LableCommon lblRemark;
        private Custom_Controllers.TextBoxCurrency txtCostPrice;
        private Custom_Controllers.TextBoxCurrency txtCostValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Row;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellingPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellingValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SearchItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
    }
}