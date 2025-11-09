namespace NSoft.ERP.UI.Windows.Accounts
{
    partial class FrmSupplierPayment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtReferenceNo = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCommon();
            this.lblReferenceNo = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lblDocumentNo = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtDocumentNo = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDocumentNo();
            this.txtSupplierDescription = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.txtSupplierCode = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxMasterCode();
            this.lblSupplier = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.dtpDocumentDate = new NSoft.ERP.UI.Windows.Custom_Controllers.DateTimePickerCommon();
            this.lblDate = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.grpGoodsReceivedNoteDetail = new NSoft.ERP.UI.Windows.Custom_Controllers.GroupBoxCommon();
            this.txtBalance = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.txtRow = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxMasterCode();
            this.txtAmountToPay = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.dgvPendingPaymentDetails = new NSoft.ERP.UI.Windows.Custom_Controllers.GridViewCommon();
            this.Row = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReferenceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtGRNNo = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxMasterCode();
            this.groupBoxCommon1 = new NSoft.ERP.UI.Windows.Custom_Controllers.GroupBoxCommon();
            this.cmbPaymentMethod = new NSoft.ERP.Reports.Custom_Controllers.ComboBoxDropDown();
            this.textBoxMasterCode1 = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxMasterCode();
            this.txtPayAmount = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.dgvPaymentDetails = new NSoft.ERP.UI.Windows.Custom_Controllers.GridViewCommon();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtChequeNo = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxMasterCode();
            this.txtTotalPaidAmount = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.grbMargin.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.grpGoodsReceivedNoteDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingPaymentDetails)).BeginInit();
            this.groupBoxCommon1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // grbMargin
            // 
            this.grbMargin.Controls.Add(this.txtTotalPaidAmount);
            this.grbMargin.Controls.Add(this.dtpDocumentDate);
            this.grbMargin.Controls.Add(this.lblDate);
            this.grbMargin.Controls.Add(this.txtSupplierDescription);
            this.grbMargin.Controls.Add(this.txtSupplierCode);
            this.grbMargin.Controls.Add(this.lblSupplier);
            this.grbMargin.Controls.Add(this.txtReferenceNo);
            this.grbMargin.Controls.Add(this.lblReferenceNo);
            this.grbMargin.Controls.Add(this.lblDocumentNo);
            this.grbMargin.Controls.Add(this.txtDocumentNo);
            this.grbMargin.Controls.Add(this.grpGoodsReceivedNoteDetail);
            this.grbMargin.Controls.Add(this.groupBoxCommon1);
            this.grbMargin.Size = new System.Drawing.Size(815, 501);
            this.grbMargin.Controls.SetChildIndex(this.groupBox2, 0);
            this.grbMargin.Controls.SetChildIndex(this.groupBox1, 0);
            this.grbMargin.Controls.SetChildIndex(this.groupBoxCommon1, 0);
            this.grbMargin.Controls.SetChildIndex(this.grpGoodsReceivedNoteDetail, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtDocumentNo, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblDocumentNo, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblReferenceNo, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtReferenceNo, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblSupplier, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtSupplierCode, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtSupplierDescription, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblDate, 0);
            this.grbMargin.Controls.SetChildIndex(this.dtpDocumentDate, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtTotalPaidAmount, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(603, 447);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(7, 447);
            // 
            // txtReferenceNo
            // 
            this.txtReferenceNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReferenceNo.Location = new System.Drawing.Point(352, 17);
            this.txtReferenceNo.Name = "txtReferenceNo";
            this.txtReferenceNo.Size = new System.Drawing.Size(229, 21);
            this.txtReferenceNo.TabIndex = 117;
            this.txtReferenceNo.TabStop = false;
            // 
            // lblReferenceNo
            // 
            this.lblReferenceNo.AutoSize = true;
            this.lblReferenceNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReferenceNo.Location = new System.Drawing.Point(259, 20);
            this.lblReferenceNo.Name = "lblReferenceNo";
            this.lblReferenceNo.Size = new System.Drawing.Size(84, 13);
            this.lblReferenceNo.TabIndex = 119;
            this.lblReferenceNo.Text = "Reference No";
            // 
            // lblDocumentNo
            // 
            this.lblDocumentNo.AutoSize = true;
            this.lblDocumentNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocumentNo.Location = new System.Drawing.Point(8, 20);
            this.lblDocumentNo.Name = "lblDocumentNo";
            this.lblDocumentNo.Size = new System.Drawing.Size(84, 13);
            this.lblDocumentNo.TabIndex = 118;
            this.lblDocumentNo.Text = "Document No";
            // 
            // txtDocumentNo
            // 
            this.txtDocumentNo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDocumentNo.Location = new System.Drawing.Point(108, 17);
            this.txtDocumentNo.Name = "txtDocumentNo";
            this.txtDocumentNo.Size = new System.Drawing.Size(131, 20);
            this.txtDocumentNo.TabIndex = 116;
            this.txtDocumentNo.TabStop = false;
            // 
            // txtSupplierDescription
            // 
            this.txtSupplierDescription.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierDescription.Location = new System.Drawing.Point(240, 43);
            this.txtSupplierDescription.Name = "txtSupplierDescription";
            this.txtSupplierDescription.Size = new System.Drawing.Size(341, 21);
            this.txtSupplierDescription.TabIndex = 121;
            this.txtSupplierDescription.TabStop = false;
            this.txtSupplierDescription.Leave += new System.EventHandler(this.txtSupplierDescription_Leave);
            // 
            // txtSupplierCode
            // 
            this.txtSupplierCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierCode.Location = new System.Drawing.Point(108, 43);
            this.txtSupplierCode.MaxLength = 10;
            this.txtSupplierCode.Name = "txtSupplierCode";
            this.txtSupplierCode.Size = new System.Drawing.Size(131, 21);
            this.txtSupplierCode.TabIndex = 120;
            this.txtSupplierCode.TabStop = false;
            this.txtSupplierCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSupplierCode_KeyDown);
            this.txtSupplierCode.Leave += new System.EventHandler(this.txtSupplierCode_Leave);
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplier.Location = new System.Drawing.Point(8, 46);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(54, 13);
            this.lblSupplier.TabIndex = 122;
            this.lblSupplier.Text = "Supplier";
            // 
            // dtpDocumentDate
            // 
            this.dtpDocumentDate.CustomFormat = "";
            this.dtpDocumentDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDocumentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDocumentDate.Location = new System.Drawing.Point(678, 20);
            this.dtpDocumentDate.Name = "dtpDocumentDate";
            this.dtpDocumentDate.Size = new System.Drawing.Size(131, 21);
            this.dtpDocumentDate.TabIndex = 123;
            this.dtpDocumentDate.TabStop = false;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(630, 23);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(34, 13);
            this.lblDate.TabIndex = 124;
            this.lblDate.Text = "Date";
            // 
            // grpGoodsReceivedNoteDetail
            // 
            this.grpGoodsReceivedNoteDetail.Controls.Add(this.txtBalance);
            this.grpGoodsReceivedNoteDetail.Controls.Add(this.txtRow);
            this.grpGoodsReceivedNoteDetail.Controls.Add(this.txtAmountToPay);
            this.grpGoodsReceivedNoteDetail.Controls.Add(this.dgvPendingPaymentDetails);
            this.grpGoodsReceivedNoteDetail.Controls.Add(this.txtGRNNo);
            this.grpGoodsReceivedNoteDetail.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGoodsReceivedNoteDetail.Location = new System.Drawing.Point(7, 63);
            this.grpGoodsReceivedNoteDetail.Name = "grpGoodsReceivedNoteDetail";
            this.grpGoodsReceivedNoteDetail.Size = new System.Drawing.Size(801, 177);
            this.grpGoodsReceivedNoteDetail.TabIndex = 125;
            this.grpGoodsReceivedNoteDetail.TabStop = false;
            // 
            // txtBalance
            // 
            this.txtBalance.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtBalance.Location = new System.Drawing.Point(519, 150);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.Size = new System.Drawing.Size(100, 21);
            this.txtBalance.TabIndex = 127;
            this.txtBalance.TabStop = false;
            this.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtRow
            // 
            this.txtRow.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRow.Location = new System.Drawing.Point(7, 150);
            this.txtRow.MaxLength = 20;
            this.txtRow.Name = "txtRow";
            this.txtRow.ReadOnly = true;
            this.txtRow.Size = new System.Drawing.Size(47, 21);
            this.txtRow.TabIndex = 125;
            this.txtRow.TabStop = false;
            // 
            // txtAmountToPay
            // 
            this.txtAmountToPay.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtAmountToPay.Location = new System.Drawing.Point(620, 150);
            this.txtAmountToPay.Name = "txtAmountToPay";
            this.txtAmountToPay.Size = new System.Drawing.Size(175, 21);
            this.txtAmountToPay.TabIndex = 121;
            this.txtAmountToPay.TabStop = false;
            this.txtAmountToPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmountToPay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmountToPay_KeyDown);
            // 
            // dgvPendingPaymentDetails
            // 
            this.dgvPendingPaymentDetails.AllowUserToAddRows = false;
            this.dgvPendingPaymentDetails.AllowUserToDeleteRows = false;
            this.dgvPendingPaymentDetails.AllowUserToResizeColumns = false;
            this.dgvPendingPaymentDetails.AllowUserToResizeRows = false;
            this.dgvPendingPaymentDetails.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvPendingPaymentDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendingPaymentDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Row,
            this.DocumentDate,
            this.DocumentNo,
            this.ReferenceNo,
            this.Amount,
            this.Balance,
            this.PayAmount});
            this.dgvPendingPaymentDetails.Location = new System.Drawing.Point(6, 13);
            this.dgvPendingPaymentDetails.Name = "dgvPendingPaymentDetails";
            this.dgvPendingPaymentDetails.RowHeadersVisible = false;
            this.dgvPendingPaymentDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPendingPaymentDetails.Size = new System.Drawing.Size(789, 133);
            this.dgvPendingPaymentDetails.TabIndex = 117;
            this.dgvPendingPaymentDetails.TabStop = false;
            this.dgvPendingPaymentDetails.DoubleClick += new System.EventHandler(this.dgvPendingPaymentDetails_DoubleClick);
            // 
            // Row
            // 
            this.Row.DataPropertyName = "LineNo";
            this.Row.HeaderText = "Row";
            this.Row.Name = "Row";
            this.Row.ReadOnly = true;
            this.Row.Width = 50;
            // 
            // DocumentDate
            // 
            this.DocumentDate.DataPropertyName = "DocumentDate";
            this.DocumentDate.HeaderText = "Date";
            this.DocumentDate.Name = "DocumentDate";
            this.DocumentDate.ReadOnly = true;
            this.DocumentDate.Width = 110;
            // 
            // DocumentNo
            // 
            this.DocumentNo.DataPropertyName = "DocumentNo";
            this.DocumentNo.HeaderText = "Document No";
            this.DocumentNo.Name = "DocumentNo";
            this.DocumentNo.ReadOnly = true;
            this.DocumentNo.Width = 131;
            // 
            // ReferenceNo
            // 
            this.ReferenceNo.DataPropertyName = "ReferenceNo";
            this.ReferenceNo.HeaderText = "Reference No";
            this.ReferenceNo.Name = "ReferenceNo";
            this.ReferenceNo.ReadOnly = true;
            this.ReferenceNo.Width = 120;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle5;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // Balance
            // 
            this.Balance.DataPropertyName = "BalanceAmount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Balance.DefaultCellStyle = dataGridViewCellStyle6;
            this.Balance.HeaderText = "Balance";
            this.Balance.Name = "Balance";
            this.Balance.ReadOnly = true;
            // 
            // PayAmount
            // 
            this.PayAmount.DataPropertyName = "PayAmount";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PayAmount.DefaultCellStyle = dataGridViewCellStyle7;
            this.PayAmount.HeaderText = "Pay Amount";
            this.PayAmount.Name = "PayAmount";
            this.PayAmount.ReadOnly = true;
            // 
            // txtGRNNo
            // 
            this.txtGRNNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGRNNo.Location = new System.Drawing.Point(169, 150);
            this.txtGRNNo.MaxLength = 20;
            this.txtGRNNo.Name = "txtGRNNo";
            this.txtGRNNo.ReadOnly = true;
            this.txtGRNNo.Size = new System.Drawing.Size(131, 21);
            this.txtGRNNo.TabIndex = 4;
            this.txtGRNNo.TabStop = false;
            // 
            // groupBoxCommon1
            // 
            this.groupBoxCommon1.Controls.Add(this.cmbPaymentMethod);
            this.groupBoxCommon1.Controls.Add(this.textBoxMasterCode1);
            this.groupBoxCommon1.Controls.Add(this.txtPayAmount);
            this.groupBoxCommon1.Controls.Add(this.dgvPaymentDetails);
            this.groupBoxCommon1.Controls.Add(this.txtChequeNo);
            this.groupBoxCommon1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCommon1.Location = new System.Drawing.Point(7, 235);
            this.groupBoxCommon1.Name = "groupBoxCommon1";
            this.groupBoxCommon1.Size = new System.Drawing.Size(801, 177);
            this.groupBoxCommon1.TabIndex = 128;
            this.groupBoxCommon1.TabStop = false;
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Location = new System.Drawing.Point(56, 150);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(126, 21);
            this.cmbPaymentMethod.TabIndex = 133;
            this.cmbPaymentMethod.TabStop = false;
            this.cmbPaymentMethod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbPaymentMethod_KeyDown);
            // 
            // textBoxMasterCode1
            // 
            this.textBoxMasterCode1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMasterCode1.Location = new System.Drawing.Point(7, 150);
            this.textBoxMasterCode1.MaxLength = 20;
            this.textBoxMasterCode1.Name = "textBoxMasterCode1";
            this.textBoxMasterCode1.ReadOnly = true;
            this.textBoxMasterCode1.Size = new System.Drawing.Size(47, 21);
            this.textBoxMasterCode1.TabIndex = 125;
            this.textBoxMasterCode1.TabStop = false;
            // 
            // txtPayAmount
            // 
            this.txtPayAmount.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtPayAmount.Location = new System.Drawing.Point(306, 150);
            this.txtPayAmount.Name = "txtPayAmount";
            this.txtPayAmount.Size = new System.Drawing.Size(132, 21);
            this.txtPayAmount.TabIndex = 121;
            this.txtPayAmount.TabStop = false;
            this.txtPayAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPayAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPayAmount_KeyDown);
            // 
            // dgvPaymentDetails
            // 
            this.dgvPaymentDetails.AllowUserToAddRows = false;
            this.dgvPaymentDetails.AllowUserToDeleteRows = false;
            this.dgvPaymentDetails.AllowUserToResizeColumns = false;
            this.dgvPaymentDetails.AllowUserToResizeRows = false;
            this.dgvPaymentDetails.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvPaymentDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaymentDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dgvPaymentDetails.Location = new System.Drawing.Point(6, 13);
            this.dgvPaymentDetails.Name = "dgvPaymentDetails";
            this.dgvPaymentDetails.RowHeadersVisible = false;
            this.dgvPaymentDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPaymentDetails.Size = new System.Drawing.Size(789, 133);
            this.dgvPaymentDetails.TabIndex = 117;
            this.dgvPaymentDetails.TabStop = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "LineNo";
            this.dataGridViewTextBoxColumn1.HeaderText = "Row";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "PaymentMethod";
            this.dataGridViewTextBoxColumn3.HeaderText = "Payment Method";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 131;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ChequeNo";
            this.dataGridViewTextBoxColumn4.HeaderText = "Cheque No";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Amount";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn5.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 120;
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChequeNo.Location = new System.Drawing.Point(184, 150);
            this.txtChequeNo.MaxLength = 20;
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(120, 21);
            this.txtChequeNo.TabIndex = 4;
            this.txtChequeNo.TabStop = false;
            // 
            // txtTotalPaidAmount
            // 
            this.txtTotalPaidAmount.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTotalPaidAmount.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtTotalPaidAmount.Location = new System.Drawing.Point(670, 420);
            this.txtTotalPaidAmount.Name = "txtTotalPaidAmount";
            this.txtTotalPaidAmount.ReadOnly = true;
            this.txtTotalPaidAmount.Size = new System.Drawing.Size(132, 21);
            this.txtTotalPaidAmount.TabIndex = 134;
            this.txtTotalPaidAmount.TabStop = false;
            this.txtTotalPaidAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FrmSupplierPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 503);
            this.Name = "FrmSupplierPayment";
            this.Text = "FrmPayment";
            this.grbMargin.ResumeLayout(false);
            this.grbMargin.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.grpGoodsReceivedNoteDetail.ResumeLayout(false);
            this.grpGoodsReceivedNoteDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingPaymentDetails)).EndInit();
            this.groupBoxCommon1.ResumeLayout(false);
            this.groupBoxCommon1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Custom_Controllers.TextBoxCommon txtReferenceNo;
        private Custom_Controllers.LableCommon lblReferenceNo;
        private Custom_Controllers.LableCommon lblDocumentNo;
        private Custom_Controllers.TextBoxDocumentNo txtDocumentNo;
        private Custom_Controllers.TextBoxDescription txtSupplierDescription;
        private Custom_Controllers.TextBoxMasterCode txtSupplierCode;
        private Custom_Controllers.LableCommon lblSupplier;
        private Custom_Controllers.DateTimePickerCommon dtpDocumentDate;
        private Custom_Controllers.LableCommon lblDate;
        private Custom_Controllers.GroupBoxCommon grpGoodsReceivedNoteDetail;
        private Custom_Controllers.TextBoxCurrency txtBalance;
        private Custom_Controllers.TextBoxMasterCode txtRow;
        private Custom_Controllers.TextBoxCurrency txtAmountToPay;
        private Custom_Controllers.GridViewCommon dgvPendingPaymentDetails;
        private Custom_Controllers.TextBoxMasterCode txtGRNNo;
        private Custom_Controllers.GroupBoxCommon groupBoxCommon1;
        private Custom_Controllers.TextBoxMasterCode textBoxMasterCode1;
        private Custom_Controllers.TextBoxCurrency txtPayAmount;
        private Custom_Controllers.GridViewCommon dgvPaymentDetails;
        private Custom_Controllers.TextBoxMasterCode txtChequeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private Reports.Custom_Controllers.ComboBoxDropDown cmbPaymentMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Row;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReferenceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayAmount;
        private Custom_Controllers.TextBoxCurrency txtTotalPaidAmount;
    }
}