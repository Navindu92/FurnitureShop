namespace NSoft.ERP.UI.Windows.Accounts
{
    partial class FrmChequePrint
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
            this.lblChequeNo = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtChequeNo = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxInteger();
            this.dtpChequeDate = new NSoft.ERP.UI.Windows.Custom_Controllers.DateTimePickerCommon();
            this.lblChequeDate = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtAmount = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.lblAmount = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.rdbCash = new System.Windows.Forms.RadioButton();
            this.rdbPayee = new System.Windows.Forms.RadioButton();
            this.txtPayee = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCommon();
            this.chkCrossed = new System.Windows.Forms.CheckBox();
            this.grpReportViewer = new NSoft.ERP.UI.Windows.Custom_Controllers.GroupBoxCommon();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.reportDocument1 = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            this.grbMargin.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.grpReportViewer.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbMargin
            // 
            this.grbMargin.Controls.Add(this.grpReportViewer);
            this.grbMargin.Controls.Add(this.chkCrossed);
            this.grbMargin.Controls.Add(this.txtPayee);
            this.grbMargin.Controls.Add(this.rdbPayee);
            this.grbMargin.Controls.Add(this.rdbCash);
            this.grbMargin.Controls.Add(this.txtAmount);
            this.grbMargin.Controls.Add(this.lblAmount);
            this.grbMargin.Controls.Add(this.dtpChequeDate);
            this.grbMargin.Controls.Add(this.lblChequeDate);
            this.grbMargin.Controls.Add(this.lblChequeNo);
            this.grbMargin.Controls.Add(this.txtChequeNo);
            this.grbMargin.Size = new System.Drawing.Size(799, 518);
            this.grbMargin.Controls.SetChildIndex(this.groupBox1, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtChequeNo, 0);
            this.grbMargin.Controls.SetChildIndex(this.groupBox2, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblChequeNo, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblChequeDate, 0);
            this.grbMargin.Controls.SetChildIndex(this.dtpChequeDate, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblAmount, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtAmount, 0);
            this.grbMargin.Controls.SetChildIndex(this.rdbCash, 0);
            this.grbMargin.Controls.SetChildIndex(this.rdbPayee, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtPayee, 0);
            this.grbMargin.Controls.SetChildIndex(this.chkCrossed, 0);
            this.grbMargin.Controls.SetChildIndex(this.grpReportViewer, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(4, 466);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(591, 466);
            // 
            // lblChequeNo
            // 
            this.lblChequeNo.AutoSize = true;
            this.lblChequeNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChequeNo.Location = new System.Drawing.Point(12, 18);
            this.lblChequeNo.Name = "lblChequeNo";
            this.lblChequeNo.Size = new System.Drawing.Size(70, 13);
            this.lblChequeNo.TabIndex = 115;
            this.lblChequeNo.Text = "Cheque No";
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChequeNo.Location = new System.Drawing.Point(108, 15);
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(131, 21);
            this.txtChequeNo.TabIndex = 114;
            this.txtChequeNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtChequeNo.Enter += new System.EventHandler(this.txtChequeNo_Enter);
            this.txtChequeNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChequeNo_KeyDown);
            this.txtChequeNo.Leave += new System.EventHandler(this.txtChequeNo_Leave);
            // 
            // dtpChequeDate
            // 
            this.dtpChequeDate.CustomFormat = "";
            this.dtpChequeDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpChequeDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpChequeDate.Location = new System.Drawing.Point(349, 15);
            this.dtpChequeDate.Name = "dtpChequeDate";
            this.dtpChequeDate.Size = new System.Drawing.Size(131, 21);
            this.dtpChequeDate.TabIndex = 117;
            this.dtpChequeDate.Enter += new System.EventHandler(this.dtpChequeDate_Enter);
            this.dtpChequeDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpChequeDate_KeyDown);
            this.dtpChequeDate.Leave += new System.EventHandler(this.dtpChequeDate_Leave);
            // 
            // lblChequeDate
            // 
            this.lblChequeDate.AutoSize = true;
            this.lblChequeDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChequeDate.Location = new System.Drawing.Point(248, 18);
            this.lblChequeDate.Name = "lblChequeDate";
            this.lblChequeDate.Size = new System.Drawing.Size(86, 13);
            this.lblChequeDate.TabIndex = 116;
            this.lblChequeDate.Text = " Cheque Date";
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtAmount.Location = new System.Drawing.Point(108, 42);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(131, 21);
            this.txtAmount.TabIndex = 71;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Enter += new System.EventHandler(this.txtAmount_Enter);
            this.txtAmount.Leave += new System.EventHandler(this.txtAmount_Leave);
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(12, 45);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(51, 13);
            this.lblAmount.TabIndex = 118;
            this.lblAmount.Text = "Amount";
            // 
            // rdbCash
            // 
            this.rdbCash.AutoSize = true;
            this.rdbCash.Location = new System.Drawing.Point(246, 43);
            this.rdbCash.Name = "rdbCash";
            this.rdbCash.Size = new System.Drawing.Size(54, 17);
            this.rdbCash.TabIndex = 119;
            this.rdbCash.TabStop = true;
            this.rdbCash.Text = "Cash";
            this.rdbCash.UseVisualStyleBackColor = true;
            this.rdbCash.CheckedChanged += new System.EventHandler(this.rdbCash_CheckedChanged);
            // 
            // rdbPayee
            // 
            this.rdbPayee.AutoSize = true;
            this.rdbPayee.Location = new System.Drawing.Point(324, 43);
            this.rdbPayee.Name = "rdbPayee";
            this.rdbPayee.Size = new System.Drawing.Size(60, 17);
            this.rdbPayee.TabIndex = 120;
            this.rdbPayee.TabStop = true;
            this.rdbPayee.Text = "Payee";
            this.rdbPayee.UseVisualStyleBackColor = true;
            this.rdbPayee.CheckedChanged += new System.EventHandler(this.rdbPayee_CheckedChanged);
            // 
            // txtPayee
            // 
            this.txtPayee.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPayee.Location = new System.Drawing.Point(390, 42);
            this.txtPayee.Name = "txtPayee";
            this.txtPayee.Size = new System.Drawing.Size(321, 21);
            this.txtPayee.TabIndex = 121;
            this.txtPayee.Leave += new System.EventHandler(this.txtPayee_Leave);
            // 
            // chkCrossed
            // 
            this.chkCrossed.AutoSize = true;
            this.chkCrossed.Location = new System.Drawing.Point(722, 44);
            this.chkCrossed.Name = "chkCrossed";
            this.chkCrossed.Size = new System.Drawing.Size(73, 17);
            this.chkCrossed.TabIndex = 122;
            this.chkCrossed.Text = "Crossed";
            this.chkCrossed.UseVisualStyleBackColor = true;
            // 
            // grpReportViewer
            // 
            this.grpReportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpReportViewer.Controls.Add(this.crystalReportViewer1);
            this.grpReportViewer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpReportViewer.Location = new System.Drawing.Point(4, 69);
            this.grpReportViewer.Name = "grpReportViewer";
            this.grpReportViewer.Size = new System.Drawing.Size(790, 402);
            this.grpReportViewer.TabIndex = 123;
            this.grpReportViewer.TabStop = false;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.DisplayStatusBar = false;
            this.crystalReportViewer1.DisplayToolbar = false;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(3, 17);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(784, 382);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FrmChequePrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 519);
            this.Name = "FrmChequePrint";
            this.Text = "FrmChequePrint";
            this.grbMargin.ResumeLayout(false);
            this.grbMargin.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.grpReportViewer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Custom_Controllers.LableCommon lblChequeNo;
        private Custom_Controllers.TextBoxInteger txtChequeNo;
        private Custom_Controllers.DateTimePickerCommon dtpChequeDate;
        private Custom_Controllers.LableCommon lblChequeDate;
        private Custom_Controllers.TextBoxCurrency txtAmount;
        private Custom_Controllers.LableCommon lblAmount;
        private System.Windows.Forms.RadioButton rdbCash;
        private System.Windows.Forms.RadioButton rdbPayee;
        private Custom_Controllers.TextBoxCommon txtPayee;
        private System.Windows.Forms.CheckBox chkCrossed;
        private Custom_Controllers.GroupBoxCommon grpReportViewer;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument1;
    }
}