namespace NSoft.ERP.UI.Windows.Inventory
{
    partial class FrmSalesman
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
            this.btnNew = new NSoft.ERP.UI.Windows.Custom_Controllers.ButtonNew();
            this.txtSalesmanCode = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxMasterCode();
            this.lableCommon1 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lableCommon2 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtSalesmanDescription = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.txtRemark = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.lableCommon4 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lableCommon3 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtCommissionRate = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.lableCommon5 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.grbMargin.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // grbMargin
            // 
            this.grbMargin.Controls.Add(this.lableCommon5);
            this.grbMargin.Controls.Add(this.txtCommissionRate);
            this.grbMargin.Controls.Add(this.lableCommon3);
            this.grbMargin.Controls.Add(this.lableCommon2);
            this.grbMargin.Controls.Add(this.lableCommon4);
            this.grbMargin.Controls.Add(this.txtRemark);
            this.grbMargin.Controls.Add(this.chkActive);
            this.grbMargin.Controls.Add(this.txtSalesmanDescription);
            this.grbMargin.Controls.Add(this.lableCommon1);
            this.grbMargin.Controls.Add(this.txtSalesmanCode);
            this.grbMargin.Controls.Add(this.btnNew);
            this.grbMargin.Size = new System.Drawing.Size(498, 221);
            this.grbMargin.Controls.SetChildIndex(this.groupBox1, 0);
            this.grbMargin.Controls.SetChildIndex(this.groupBox2, 0);
            this.grbMargin.Controls.SetChildIndex(this.btnNew, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtSalesmanCode, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon1, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtSalesmanDescription, 0);
            this.grbMargin.Controls.SetChildIndex(this.chkActive, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtRemark, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon4, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon2, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon3, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtCommissionRate, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon5, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(4, 169);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(296, 169);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(270, 19);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(50, 23);
            this.btnNew.TabIndex = 5;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtSalesmanCode
            // 
            this.txtSalesmanCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesmanCode.Location = new System.Drawing.Point(133, 21);
            this.txtSalesmanCode.MaxLength = 10;
            this.txtSalesmanCode.Name = "txtSalesmanCode";
            this.txtSalesmanCode.Size = new System.Drawing.Size(131, 21);
            this.txtSalesmanCode.TabIndex = 6;
            this.txtSalesmanCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSalesmanCode_KeyDown);
            this.txtSalesmanCode.Leave += new System.EventHandler(this.txtSalesmanCode_Leave);
            // 
            // lableCommon1
            // 
            this.lableCommon1.AutoSize = true;
            this.lableCommon1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon1.Location = new System.Drawing.Point(9, 24);
            this.lableCommon1.Name = "lableCommon1";
            this.lableCommon1.Size = new System.Drawing.Size(108, 13);
            this.lableCommon1.TabIndex = 7;
            this.lableCommon1.Text = "Salesman Code *";
            // 
            // lableCommon2
            // 
            this.lableCommon2.AutoSize = true;
            this.lableCommon2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon2.Location = new System.Drawing.Point(9, 51);
            this.lableCommon2.Name = "lableCommon2";
            this.lableCommon2.Size = new System.Drawing.Size(110, 13);
            this.lableCommon2.TabIndex = 8;
            this.lableCommon2.Text = "Salesman  Desc *";
            // 
            // txtSalesmanDescription
            // 
            this.txtSalesmanDescription.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesmanDescription.Location = new System.Drawing.Point(133, 48);
            this.txtSalesmanDescription.Name = "txtSalesmanDescription";
            this.txtSalesmanDescription.Size = new System.Drawing.Size(353, 21);
            this.txtSalesmanDescription.TabIndex = 9;
            this.txtSalesmanDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSalesmanDescription_KeyDown);
            this.txtSalesmanDescription.Leave += new System.EventHandler(this.txtSalesmanDescription_Leave);
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(326, 23);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(61, 17);
            this.chkActive.TabIndex = 22;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Location = new System.Drawing.Point(133, 106);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(353, 65);
            this.txtRemark.TabIndex = 23;
            this.txtRemark.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRemark_KeyDown);
            // 
            // lableCommon4
            // 
            this.lableCommon4.AutoSize = true;
            this.lableCommon4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon4.Location = new System.Drawing.Point(9, 109);
            this.lableCommon4.Name = "lableCommon4";
            this.lableCommon4.Size = new System.Drawing.Size(52, 13);
            this.lableCommon4.TabIndex = 24;
            this.lableCommon4.Text = "Remark";
            // 
            // lableCommon3
            // 
            this.lableCommon3.AutoSize = true;
            this.lableCommon3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon3.Location = new System.Drawing.Point(9, 79);
            this.lableCommon3.Name = "lableCommon3";
            this.lableCommon3.Size = new System.Drawing.Size(107, 13);
            this.lableCommon3.TabIndex = 25;
            this.lableCommon3.Text = "Commission Rate";
            // 
            // txtCommissionRate
            // 
            this.txtCommissionRate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtCommissionRate.Location = new System.Drawing.Point(133, 76);
            this.txtCommissionRate.Name = "txtCommissionRate";
            this.txtCommissionRate.Size = new System.Drawing.Size(90, 21);
            this.txtCommissionRate.TabIndex = 129;
            this.txtCommissionRate.TabStop = false;
            this.txtCommissionRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCommissionRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCommissionRate_KeyDown);
            // 
            // lableCommon5
            // 
            this.lableCommon5.AutoSize = true;
            this.lableCommon5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon5.Location = new System.Drawing.Point(229, 79);
            this.lableCommon5.Name = "lableCommon5";
            this.lableCommon5.Size = new System.Drawing.Size(19, 13);
            this.lableCommon5.TabIndex = 130;
            this.lableCommon5.Text = "%";
            // 
            // FrmSalesman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 218);
            this.Name = "FrmSalesman";
            this.Text = "FrmSalesman";
            this.grbMargin.ResumeLayout(false);
            this.grbMargin.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Custom_Controllers.ButtonNew btnNew;
        private Custom_Controllers.TextBoxMasterCode txtSalesmanCode;
        private Custom_Controllers.LableCommon lableCommon1;
        private Custom_Controllers.TextBoxDescription txtSalesmanDescription;
        private Custom_Controllers.LableCommon lableCommon2;
        private System.Windows.Forms.CheckBox chkActive;
        private Custom_Controllers.TextBoxDescription txtRemark;
        private Custom_Controllers.LableCommon lableCommon4;
        private Custom_Controllers.LableCommon lableCommon3;
        private Custom_Controllers.TextBoxCurrency txtCommissionRate;
        private Custom_Controllers.LableCommon lableCommon5;
    }
}