namespace NSoft.ERP.UI.Windows.Accounts
{
    partial class FrmChequeBookEntry
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
            this.cmbNoOfPages = new NSoft.ERP.UI.Windows.Custom_Controllers.ComboBoxCommon();
            this.lblNoOfPages = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtStartingNo = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxInteger();
            this.lblStartingNo = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.dgvChequeNumbers = new NSoft.ERP.UI.Windows.Custom_Controllers.GridViewCommon();
            this.ChequeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.grbMargin.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChequeNumbers)).BeginInit();
            this.SuspendLayout();
            // 
            // grbMargin
            // 
            this.grbMargin.Controls.Add(this.btnGenerate);
            this.grbMargin.Controls.Add(this.dgvChequeNumbers);
            this.grbMargin.Controls.Add(this.lblStartingNo);
            this.grbMargin.Controls.Add(this.txtStartingNo);
            this.grbMargin.Controls.Add(this.cmbNoOfPages);
            this.grbMargin.Controls.Add(this.lblNoOfPages);
            this.grbMargin.Size = new System.Drawing.Size(549, 311);
            this.grbMargin.Controls.SetChildIndex(this.groupBox1, 0);
            this.grbMargin.Controls.SetChildIndex(this.groupBox2, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblNoOfPages, 0);
            this.grbMargin.Controls.SetChildIndex(this.cmbNoOfPages, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtStartingNo, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblStartingNo, 0);
            this.grbMargin.Controls.SetChildIndex(this.dgvChequeNumbers, 0);
            this.grbMargin.Controls.SetChildIndex(this.btnGenerate, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 259);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(341, 259);
            // 
            // cmbNoOfPages
            // 
            this.cmbNoOfPages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNoOfPages.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNoOfPages.FormattingEnabled = true;
            this.cmbNoOfPages.Location = new System.Drawing.Point(116, 20);
            this.cmbNoOfPages.Name = "cmbNoOfPages";
            this.cmbNoOfPages.Size = new System.Drawing.Size(87, 21);
            this.cmbNoOfPages.TabIndex = 55;
            this.cmbNoOfPages.Enter += new System.EventHandler(this.cmbNoOfPages_Enter);
            this.cmbNoOfPages.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbNoOfPages_KeyDown);
            this.cmbNoOfPages.Leave += new System.EventHandler(this.cmbNoOfPages_Leave);
            // 
            // lblNoOfPages
            // 
            this.lblNoOfPages.AutoSize = true;
            this.lblNoOfPages.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoOfPages.Location = new System.Drawing.Point(15, 23);
            this.lblNoOfPages.Name = "lblNoOfPages";
            this.lblNoOfPages.Size = new System.Drawing.Size(88, 13);
            this.lblNoOfPages.TabIndex = 54;
            this.lblNoOfPages.Text = "No Of Pages *";
            // 
            // txtStartingNo
            // 
            this.txtStartingNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartingNo.Location = new System.Drawing.Point(314, 20);
            this.txtStartingNo.Name = "txtStartingNo";
            this.txtStartingNo.Size = new System.Drawing.Size(83, 21);
            this.txtStartingNo.TabIndex = 112;
            this.txtStartingNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtStartingNo.Enter += new System.EventHandler(this.txtStartingNo_Enter);
            this.txtStartingNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStartingNo_KeyDown);
            this.txtStartingNo.Leave += new System.EventHandler(this.txtStartingNo_Leave);
            // 
            // lblStartingNo
            // 
            this.lblStartingNo.AutoSize = true;
            this.lblStartingNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartingNo.Location = new System.Drawing.Point(218, 23);
            this.lblStartingNo.Name = "lblStartingNo";
            this.lblStartingNo.Size = new System.Drawing.Size(82, 13);
            this.lblStartingNo.TabIndex = 113;
            this.lblStartingNo.Text = "Starting No *";
            // 
            // dgvChequeNumbers
            // 
            this.dgvChequeNumbers.AllowUserToAddRows = false;
            this.dgvChequeNumbers.AllowUserToDeleteRows = false;
            this.dgvChequeNumbers.AllowUserToResizeColumns = false;
            this.dgvChequeNumbers.AllowUserToResizeRows = false;
            this.dgvChequeNumbers.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dgvChequeNumbers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChequeNumbers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ChequeNo});
            this.dgvChequeNumbers.Location = new System.Drawing.Point(9, 57);
            this.dgvChequeNumbers.Name = "dgvChequeNumbers";
            this.dgvChequeNumbers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChequeNumbers.Size = new System.Drawing.Size(394, 197);
            this.dgvChequeNumbers.TabIndex = 44;
            // 
            // ChequeNo
            // 
            this.ChequeNo.DataPropertyName = "ChequeNo";
            this.ChequeNo.HeaderText = "Cheque Numbers";
            this.ChequeNo.Name = "ChequeNo";
            this.ChequeNo.ReadOnly = true;
            this.ChequeNo.Width = 200;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Location = new System.Drawing.Point(422, 131);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(121, 35);
            this.btnGenerate.TabIndex = 114;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // FrmChequeBookEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 312);
            this.Name = "FrmChequeBookEntry";
            this.Text = "FrmChequeBookEntry";
            this.grbMargin.ResumeLayout(false);
            this.grbMargin.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChequeNumbers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Custom_Controllers.ComboBoxCommon cmbNoOfPages;
        private Custom_Controllers.LableCommon lblNoOfPages;
        private Custom_Controllers.LableCommon lblStartingNo;
        private Custom_Controllers.TextBoxInteger txtStartingNo;
        private Custom_Controllers.GridViewCommon dgvChequeNumbers;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChequeNo;
    }
}