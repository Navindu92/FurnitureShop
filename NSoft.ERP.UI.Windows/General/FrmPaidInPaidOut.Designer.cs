namespace NSoft.ERP.UI.Windows.General
{
    partial class FrmPaidInPaidOut
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lableCommon18 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtDocumentNo = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDocumentNo();
            this.txtPerson = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.lableCommon5 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.dtpDocumentDate = new NSoft.ERP.UI.Windows.Custom_Controllers.DateTimePickerCommon();
            this.lableCommon3 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.dgvPaidInPaidOut = new NSoft.ERP.UI.Windows.Custom_Controllers.GridViewCommon();
            this.PaidInPaidOutCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaidInPaidOutName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lableCommon13 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtTotalAmount = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.txtAmount = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.txtPaidInPaidOutCode = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxMasterCode();
            this.txtPaidInPaidOutName = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.grbMargin.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaidInPaidOut)).BeginInit();
            this.SuspendLayout();
            // 
            // grbMargin
            // 
            this.grbMargin.Controls.Add(this.txtPaidInPaidOutName);
            this.grbMargin.Controls.Add(this.txtAmount);
            this.grbMargin.Controls.Add(this.txtPaidInPaidOutCode);
            this.grbMargin.Controls.Add(this.lableCommon13);
            this.grbMargin.Controls.Add(this.txtTotalAmount);
            this.grbMargin.Controls.Add(this.dgvPaidInPaidOut);
            this.grbMargin.Controls.Add(this.lableCommon18);
            this.grbMargin.Controls.Add(this.txtDocumentNo);
            this.grbMargin.Controls.Add(this.txtPerson);
            this.grbMargin.Controls.Add(this.lableCommon5);
            this.grbMargin.Controls.Add(this.dtpDocumentDate);
            this.grbMargin.Controls.Add(this.lableCommon3);
            this.grbMargin.Size = new System.Drawing.Size(529, 354);
            this.grbMargin.Controls.SetChildIndex(this.groupBox1, 0);
            this.grbMargin.Controls.SetChildIndex(this.groupBox2, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon3, 0);
            this.grbMargin.Controls.SetChildIndex(this.dtpDocumentDate, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon5, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtPerson, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtDocumentNo, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon18, 0);
            this.grbMargin.Controls.SetChildIndex(this.dgvPaidInPaidOut, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtTotalAmount, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon13, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtPaidInPaidOutCode, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtAmount, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtPaidInPaidOutName, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(317, 300);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(7, 300);
            // 
            // lableCommon18
            // 
            this.lableCommon18.AutoSize = true;
            this.lableCommon18.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon18.Location = new System.Drawing.Point(11, 21);
            this.lableCommon18.Name = "lableCommon18";
            this.lableCommon18.Size = new System.Drawing.Size(93, 13);
            this.lableCommon18.TabIndex = 108;
            this.lableCommon18.Text = "Document No";
            // 
            // txtDocumentNo
            // 
            this.txtDocumentNo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtDocumentNo.Location = new System.Drawing.Point(131, 16);
            this.txtDocumentNo.Name = "txtDocumentNo";
            this.txtDocumentNo.Size = new System.Drawing.Size(131, 20);
            this.txtDocumentNo.TabIndex = 107;
            // 
            // txtPerson
            // 
            this.txtPerson.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPerson.Location = new System.Drawing.Point(131, 42);
            this.txtPerson.Name = "txtPerson";
            this.txtPerson.Size = new System.Drawing.Size(388, 21);
            this.txtPerson.TabIndex = 106;
            this.txtPerson.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPerson_KeyDown);
            // 
            // lableCommon5
            // 
            this.lableCommon5.AutoSize = true;
            this.lableCommon5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon5.Location = new System.Drawing.Point(11, 45);
            this.lableCommon5.Name = "lableCommon5";
            this.lableCommon5.Size = new System.Drawing.Size(52, 13);
            this.lableCommon5.TabIndex = 105;
            this.lableCommon5.Text = "Person";
            // 
            // dtpDocumentDate
            // 
            this.dtpDocumentDate.CustomFormat = "";
            this.dtpDocumentDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDocumentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDocumentDate.Location = new System.Drawing.Point(388, 15);
            this.dtpDocumentDate.Name = "dtpDocumentDate";
            this.dtpDocumentDate.Size = new System.Drawing.Size(131, 21);
            this.dtpDocumentDate.TabIndex = 104;
            // 
            // lableCommon3
            // 
            this.lableCommon3.AutoSize = true;
            this.lableCommon3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon3.Location = new System.Drawing.Point(329, 21);
            this.lableCommon3.Name = "lableCommon3";
            this.lableCommon3.Size = new System.Drawing.Size(37, 13);
            this.lableCommon3.TabIndex = 103;
            this.lableCommon3.Text = "Date";
            // 
            // dgvPaidInPaidOut
            // 
            this.dgvPaidInPaidOut.AllowUserToAddRows = false;
            this.dgvPaidInPaidOut.AllowUserToDeleteRows = false;
            this.dgvPaidInPaidOut.AllowUserToResizeColumns = false;
            this.dgvPaidInPaidOut.AllowUserToResizeRows = false;
            this.dgvPaidInPaidOut.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPaidInPaidOut.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPaidInPaidOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaidInPaidOut.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PaidInPaidOutCode,
            this.PaidInPaidOutName,
            this.Amount});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPaidInPaidOut.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPaidInPaidOut.Location = new System.Drawing.Point(14, 69);
            this.dgvPaidInPaidOut.Name = "dgvPaidInPaidOut";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPaidInPaidOut.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPaidInPaidOut.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPaidInPaidOut.Size = new System.Drawing.Size(505, 172);
            this.dgvPaidInPaidOut.TabIndex = 109;
            this.dgvPaidInPaidOut.DoubleClick += new System.EventHandler(this.dgvPaidInPaidOut_DoubleClick);
            this.dgvPaidInPaidOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPaidInPaidOut_KeyDown);
            // 
            // PaidInPaidOutCode
            // 
            this.PaidInPaidOutCode.DataPropertyName = "PaidInPaidOutCode";
            this.PaidInPaidOutCode.HeaderText = "Code";
            this.PaidInPaidOutCode.Name = "PaidInPaidOutCode";
            this.PaidInPaidOutCode.ReadOnly = true;
            this.PaidInPaidOutCode.Width = 105;
            // 
            // PaidInPaidOutName
            // 
            this.PaidInPaidOutName.DataPropertyName = "PaidInPaidOutName";
            this.PaidInPaidOutName.HeaderText = "Name";
            this.PaidInPaidOutName.Name = "PaidInPaidOutName";
            this.PaidInPaidOutName.ReadOnly = true;
            this.PaidInPaidOutName.Width = 220;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle2;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // lableCommon13
            // 
            this.lableCommon13.AutoSize = true;
            this.lableCommon13.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon13.Location = new System.Drawing.Point(249, 279);
            this.lableCommon13.Name = "lableCommon13";
            this.lableCommon13.Size = new System.Drawing.Size(94, 13);
            this.lableCommon13.TabIndex = 111;
            this.lableCommon13.Text = "Total Amount";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTotalAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(375, 276);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(144, 21);
            this.txtTotalAmount.TabIndex = 110;
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtAmount.Location = new System.Drawing.Point(375, 247);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(144, 21);
            this.txtAmount.TabIndex = 113;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyDown);
            // 
            // txtPaidInPaidOutCode
            // 
            this.txtPaidInPaidOutCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaidInPaidOutCode.Location = new System.Drawing.Point(14, 247);
            this.txtPaidInPaidOutCode.MaxLength = 10;
            this.txtPaidInPaidOutCode.Name = "txtPaidInPaidOutCode";
            this.txtPaidInPaidOutCode.Size = new System.Drawing.Size(145, 21);
            this.txtPaidInPaidOutCode.TabIndex = 112;
            this.txtPaidInPaidOutCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPaidInPaidOutCode_KeyDown);
            this.txtPaidInPaidOutCode.Leave += new System.EventHandler(this.txtPaidInPaidOutCode_Leave);
            // 
            // txtPaidInPaidOutName
            // 
            this.txtPaidInPaidOutName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaidInPaidOutName.Location = new System.Drawing.Point(160, 247);
            this.txtPaidInPaidOutName.Name = "txtPaidInPaidOutName";
            this.txtPaidInPaidOutName.Size = new System.Drawing.Size(214, 21);
            this.txtPaidInPaidOutName.TabIndex = 114;
            this.txtPaidInPaidOutName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPaidInPaidOutName_KeyDown);
            this.txtPaidInPaidOutName.Leave += new System.EventHandler(this.txtPaidInPaidOutName_Leave);
            // 
            // FrmPaidInPaidOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 356);
            this.Name = "FrmPaidInPaidOut";
            this.Text = "FrmPaidInPaidOut";
            this.grbMargin.ResumeLayout(false);
            this.grbMargin.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaidInPaidOut)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Custom_Controllers.LableCommon lableCommon18;
        private Custom_Controllers.TextBoxDocumentNo txtDocumentNo;
        private Custom_Controllers.TextBoxDescription txtPerson;
        private Custom_Controllers.LableCommon lableCommon5;
        private Custom_Controllers.DateTimePickerCommon dtpDocumentDate;
        private Custom_Controllers.LableCommon lableCommon3;
        private Custom_Controllers.GridViewCommon dgvPaidInPaidOut;
        private Custom_Controllers.LableCommon lableCommon13;
        private Custom_Controllers.TextBoxCurrency txtTotalAmount;
        private Custom_Controllers.TextBoxCurrency txtAmount;
        private Custom_Controllers.TextBoxMasterCode txtPaidInPaidOutCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaidInPaidOutCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaidInPaidOutName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private Custom_Controllers.TextBoxDescription txtPaidInPaidOutName;
    }
}