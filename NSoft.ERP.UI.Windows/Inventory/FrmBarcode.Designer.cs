namespace NSoft.ERP.UI.Windows.Inventory
{
    partial class FrmBarcode
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpGoodsReceivedNoteDetail = new NSoft.ERP.UI.Windows.Custom_Controllers.GroupBoxCommon();
            this.txtQty = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxQty();
            this.txtCostPrice = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.txtRow = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxMasterCode();
            this.txtSellingPrice = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.txtItemName = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.dgvBarcode = new NSoft.ERP.UI.Windows.Custom_Controllers.GridViewCommon();
            this.Row = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SellingPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtItemCode = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxMasterCode();
            this.cmbTransaction = new NSoft.ERP.UI.Windows.Custom_Controllers.ComboBoxCommon();
            this.lblRemark = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.cmbDocumentNo = new NSoft.ERP.Reports.Custom_Controllers.ComboBoxCommonDropDown();
            this.lableCommon1 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.dtpDocumentDate = new NSoft.ERP.UI.Windows.Custom_Controllers.DateTimePickerCommon();
            this.lblDate = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lblTotalQty = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtTotalQty = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.lableCommon2 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.cmbLable = new NSoft.ERP.UI.Windows.Custom_Controllers.ComboBoxCommon();
            this.grbMargin.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.grpGoodsReceivedNoteDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarcode)).BeginInit();
            this.SuspendLayout();
            // 
            // grbMargin
            // 
            this.grbMargin.Controls.Add(this.lableCommon2);
            this.grbMargin.Controls.Add(this.cmbLable);
            this.grbMargin.Controls.Add(this.lblTotalQty);
            this.grbMargin.Controls.Add(this.dtpDocumentDate);
            this.grbMargin.Controls.Add(this.txtTotalQty);
            this.grbMargin.Controls.Add(this.lblDate);
            this.grbMargin.Controls.Add(this.lableCommon1);
            this.grbMargin.Controls.Add(this.cmbDocumentNo);
            this.grbMargin.Controls.Add(this.lblRemark);
            this.grbMargin.Controls.Add(this.cmbTransaction);
            this.grbMargin.Controls.Add(this.grpGoodsReceivedNoteDetail);
            this.grbMargin.Size = new System.Drawing.Size(752, 401);
            this.grbMargin.Controls.SetChildIndex(this.groupBox1, 0);
            this.grbMargin.Controls.SetChildIndex(this.groupBox2, 0);
            this.grbMargin.Controls.SetChildIndex(this.grpGoodsReceivedNoteDetail, 0);
            this.grbMargin.Controls.SetChildIndex(this.cmbTransaction, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblRemark, 0);
            this.grbMargin.Controls.SetChildIndex(this.cmbDocumentNo, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon1, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblDate, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtTotalQty, 0);
            this.grbMargin.Controls.SetChildIndex(this.dtpDocumentDate, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblTotalQty, 0);
            this.grbMargin.Controls.SetChildIndex(this.cmbLable, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon2, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(542, 347);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(7, 347);
            // 
            // grpGoodsReceivedNoteDetail
            // 
            this.grpGoodsReceivedNoteDetail.Controls.Add(this.txtQty);
            this.grpGoodsReceivedNoteDetail.Controls.Add(this.txtCostPrice);
            this.grpGoodsReceivedNoteDetail.Controls.Add(this.txtRow);
            this.grpGoodsReceivedNoteDetail.Controls.Add(this.txtSellingPrice);
            this.grpGoodsReceivedNoteDetail.Controls.Add(this.txtItemName);
            this.grpGoodsReceivedNoteDetail.Controls.Add(this.dgvBarcode);
            this.grpGoodsReceivedNoteDetail.Controls.Add(this.txtItemCode);
            this.grpGoodsReceivedNoteDetail.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGoodsReceivedNoteDetail.Location = new System.Drawing.Point(6, 68);
            this.grpGoodsReceivedNoteDetail.Name = "grpGoodsReceivedNoteDetail";
            this.grpGoodsReceivedNoteDetail.Size = new System.Drawing.Size(741, 245);
            this.grpGoodsReceivedNoteDetail.TabIndex = 119;
            this.grpGoodsReceivedNoteDetail.TabStop = false;
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(629, 218);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(59, 21);
            this.txtQty.TabIndex = 129;
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQty_KeyDown);
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
            // txtSellingPrice
            // 
            this.txtSellingPrice.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtSellingPrice.Location = new System.Drawing.Point(529, 218);
            this.txtSellingPrice.Name = "txtSellingPrice";
            this.txtSellingPrice.Size = new System.Drawing.Size(99, 21);
            this.txtSellingPrice.TabIndex = 121;
            this.txtSellingPrice.TabStop = false;
            this.txtSellingPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtItemName
            // 
            this.txtItemName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(187, 218);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(250, 21);
            this.txtItemName.TabIndex = 5;
            this.txtItemName.TabStop = false;
            this.txtItemName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemName_KeyDown);
            this.txtItemName.Leave += new System.EventHandler(this.txtItemName_Leave);
            // 
            // dgvBarcode
            // 
            this.dgvBarcode.AllowUserToAddRows = false;
            this.dgvBarcode.AllowUserToDeleteRows = false;
            this.dgvBarcode.AllowUserToResizeColumns = false;
            this.dgvBarcode.AllowUserToResizeRows = false;
            this.dgvBarcode.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvBarcode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBarcode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Row,
            this.ItemCode,
            this.ItemName,
            this.CostPrice,
            this.SellingPrice,
            this.Qty});
            this.dgvBarcode.Location = new System.Drawing.Point(6, 13);
            this.dgvBarcode.Name = "dgvBarcode";
            this.dgvBarcode.RowHeadersVisible = false;
            this.dgvBarcode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBarcode.Size = new System.Drawing.Size(731, 201);
            this.dgvBarcode.TabIndex = 117;
            this.dgvBarcode.TabStop = false;
            this.dgvBarcode.DoubleClick += new System.EventHandler(this.dgvBarcode_DoubleClick);
            this.dgvBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvBarcode_KeyDown);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CostPrice.DefaultCellStyle = dataGridViewCellStyle1;
            this.CostPrice.HeaderText = "Cost Price";
            this.CostPrice.Name = "CostPrice";
            this.CostPrice.ReadOnly = true;
            this.CostPrice.Width = 90;
            // 
            // SellingPrice
            // 
            this.SellingPrice.DataPropertyName = "SellingPrice";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.SellingPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.SellingPrice.HeaderText = "Selling Price";
            this.SellingPrice.Name = "SellingPrice";
            this.SellingPrice.ReadOnly = true;
            // 
            // Qty
            // 
            this.Qty.DataPropertyName = "Qty";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Qty.DefaultCellStyle = dataGridViewCellStyle3;
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            this.Qty.Width = 60;
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
            this.txtItemCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemCode_KeyDown);
            this.txtItemCode.Leave += new System.EventHandler(this.txtItemCode_Leave);
            // 
            // cmbTransaction
            // 
            this.cmbTransaction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransaction.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTransaction.FormattingEnabled = true;
            this.cmbTransaction.Items.AddRange(new object[] {
            "Manual Item",
            "Goods Received Note"});
            this.cmbTransaction.Location = new System.Drawing.Point(101, 16);
            this.cmbTransaction.Name = "cmbTransaction";
            this.cmbTransaction.Size = new System.Drawing.Size(196, 21);
            this.cmbTransaction.TabIndex = 121;
            this.cmbTransaction.SelectedIndexChanged += new System.EventHandler(this.cmbTransaction_SelectedIndexChanged);
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemark.Location = new System.Drawing.Point(10, 16);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(72, 13);
            this.lblRemark.TabIndex = 141;
            this.lblRemark.Text = "Transaction";
            // 
            // cmbDocumentNo
            // 
            this.cmbDocumentNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDocumentNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDocumentNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDocumentNo.FormattingEnabled = true;
            this.cmbDocumentNo.Location = new System.Drawing.Point(101, 47);
            this.cmbDocumentNo.Name = "cmbDocumentNo";
            this.cmbDocumentNo.Size = new System.Drawing.Size(196, 21);
            this.cmbDocumentNo.TabIndex = 142;
            this.cmbDocumentNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDocumentNo_KeyDown);
            this.cmbDocumentNo.Leave += new System.EventHandler(this.cmbDocumentNo_Leave);
            // 
            // lableCommon1
            // 
            this.lableCommon1.AutoSize = true;
            this.lableCommon1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon1.Location = new System.Drawing.Point(10, 50);
            this.lableCommon1.Name = "lableCommon1";
            this.lableCommon1.Size = new System.Drawing.Size(84, 13);
            this.lableCommon1.TabIndex = 143;
            this.lableCommon1.Text = "Document No";
            // 
            // dtpDocumentDate
            // 
            this.dtpDocumentDate.CustomFormat = "";
            this.dtpDocumentDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDocumentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDocumentDate.Location = new System.Drawing.Point(612, 13);
            this.dtpDocumentDate.Name = "dtpDocumentDate";
            this.dtpDocumentDate.Size = new System.Drawing.Size(131, 21);
            this.dtpDocumentDate.TabIndex = 144;
            this.dtpDocumentDate.TabStop = false;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(564, 16);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(34, 13);
            this.lblDate.TabIndex = 145;
            this.lblDate.Text = "Date";
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.AutoSize = true;
            this.lblTotalQty.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalQty.Location = new System.Drawing.Point(531, 322);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Size = new System.Drawing.Size(58, 13);
            this.lblTotalQty.TabIndex = 135;
            this.lblTotalQty.Text = "Total Qty";
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTotalQty.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalQty.Location = new System.Drawing.Point(595, 319);
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.ReadOnly = true;
            this.txtTotalQty.Size = new System.Drawing.Size(146, 21);
            this.txtTotalQty.TabIndex = 134;
            this.txtTotalQty.TabStop = false;
            this.txtTotalQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lableCommon2
            // 
            this.lableCommon2.AutoSize = true;
            this.lableCommon2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon2.Location = new System.Drawing.Point(10, 322);
            this.lableCommon2.Name = "lableCommon2";
            this.lableCommon2.Size = new System.Drawing.Size(37, 13);
            this.lableCommon2.TabIndex = 147;
            this.lableCommon2.Text = "Lable";
            // 
            // cmbLable
            // 
            this.cmbLable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLable.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLable.FormattingEnabled = true;
            this.cmbLable.Items.AddRange(new object[] {
            "3Sticker",
            "2X1 Sticker"});
            this.cmbLable.Location = new System.Drawing.Point(61, 319);
            this.cmbLable.Name = "cmbLable";
            this.cmbLable.Size = new System.Drawing.Size(196, 21);
            this.cmbLable.TabIndex = 146;
            // 
            // FrmBarcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 403);
            this.Name = "FrmBarcode";
            this.Text = "FrmBarcode";
            this.grbMargin.ResumeLayout(false);
            this.grbMargin.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.grpGoodsReceivedNoteDetail.ResumeLayout(false);
            this.grpGoodsReceivedNoteDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarcode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Custom_Controllers.GroupBoxCommon grpGoodsReceivedNoteDetail;
        private Custom_Controllers.TextBoxQty txtQty;
        private Custom_Controllers.TextBoxCurrency txtCostPrice;
        private Custom_Controllers.TextBoxMasterCode txtRow;
        private Custom_Controllers.TextBoxCurrency txtSellingPrice;
        private Custom_Controllers.TextBoxDescription txtItemName;
        private Custom_Controllers.GridViewCommon dgvBarcode;
        private Custom_Controllers.TextBoxMasterCode txtItemCode;
        private Custom_Controllers.ComboBoxCommon cmbTransaction;
        private Custom_Controllers.LableCommon lblRemark;
        private Reports.Custom_Controllers.ComboBoxCommonDropDown cmbDocumentNo;
        private Custom_Controllers.LableCommon lableCommon1;
        private Custom_Controllers.DateTimePickerCommon dtpDocumentDate;
        private Custom_Controllers.LableCommon lblDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Row;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellingPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private Custom_Controllers.LableCommon lblTotalQty;
        private Custom_Controllers.TextBoxCurrency txtTotalQty;
        private Custom_Controllers.LableCommon lableCommon2;
        private Custom_Controllers.ComboBoxCommon cmbLable;
    }
}