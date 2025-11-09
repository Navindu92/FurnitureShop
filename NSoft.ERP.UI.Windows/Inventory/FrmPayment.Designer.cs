namespace NSoft.ERP.UI.Windows.Inventory
{
    partial class FrmPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPayment));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.usrPaymentDetail1 = new NSoft.ERP.UI.Windows.Inventory.MyUserControl.UsrPaymentDetail();
            this.usrPaymentDetailEnter1 = new NSoft.ERP.UI.Windows.Inventory.MyUserControl.UsrPaymentDetailEnter();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblPaidAmount = new System.Windows.Forms.Label();
            this.lblDiscountPercentage = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNetAmount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblDueAmount = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblTotal = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lblBalanceHeader = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lableCommon1 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lableCommon3 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.grpPayTypes = new System.Windows.Forms.GroupBox();
            this.btnOther = new System.Windows.Forms.Button();
            this.btnGiftVoucher = new System.Windows.Forms.Button();
            this.btnLoyaltyRedeem = new System.Windows.Forms.Button();
            this.btnCheque = new System.Windows.Forms.Button();
            this.btnAmex = new System.Windows.Forms.Button();
            this.btnMaster = new System.Windows.Forms.Button();
            this.btnVisa = new System.Windows.Forms.Button();
            this.btnCash = new System.Windows.Forms.Button();
            this.btnF6 = new System.Windows.Forms.Button();
            this.btnF5 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grpPayTypes.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.usrPaymentDetail1);
            this.groupBox2.Controls.Add(this.usrPaymentDetailEnter1);
            this.groupBox2.Location = new System.Drawing.Point(276, -3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(468, 219);
            this.groupBox2.TabIndex = 138;
            this.groupBox2.TabStop = false;
            // 
            // usrPaymentDetail1
            // 
            this.usrPaymentDetail1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.usrPaymentDetail1.Location = new System.Drawing.Point(6, 12);
            this.usrPaymentDetail1.Name = "usrPaymentDetail1";
            this.usrPaymentDetail1.Size = new System.Drawing.Size(456, 201);
            this.usrPaymentDetail1.TabIndex = 0;
            // 
            // usrPaymentDetailEnter1
            // 
            this.usrPaymentDetailEnter1.Location = new System.Drawing.Point(6, 12);
            this.usrPaymentDetailEnter1.Name = "usrPaymentDetailEnter1";
            this.usrPaymentDetailEnter1.Size = new System.Drawing.Size(456, 201);
            this.usrPaymentDetailEnter1.TabIndex = 1;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTotalAmount.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(187, 12);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(169, 23);
            this.lblTotalAmount.TabIndex = 143;
            this.lblTotalAmount.Text = "1500.00";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPaidAmount
            // 
            this.lblPaidAmount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPaidAmount.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaidAmount.Location = new System.Drawing.Point(186, 93);
            this.lblPaidAmount.Name = "lblPaidAmount";
            this.lblPaidAmount.Size = new System.Drawing.Size(168, 23);
            this.lblPaidAmount.TabIndex = 144;
            this.lblPaidAmount.Text = "1500.00";
            this.lblPaidAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDiscountPercentage
            // 
            this.lblDiscountPercentage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDiscountPercentage.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscountPercentage.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblDiscountPercentage.Location = new System.Drawing.Point(109, 39);
            this.lblDiscountPercentage.Name = "lblDiscountPercentage";
            this.lblDiscountPercentage.Size = new System.Drawing.Size(60, 23);
            this.lblDiscountPercentage.TabIndex = 90;
            this.lblDiscountPercentage.Text = "10%";
            this.lblDiscountPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 23);
            this.label5.TabIndex = 89;
            this.label5.Text = "Net Amount";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNetAmount
            // 
            this.lblNetAmount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblNetAmount.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetAmount.Location = new System.Drawing.Point(158, 66);
            this.lblNetAmount.Name = "lblNetAmount";
            this.lblNetAmount.Size = new System.Drawing.Size(199, 23);
            this.lblNetAmount.TabIndex = 88;
            this.lblNetAmount.Text = "1500.00";
            this.lblNetAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(16, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 23);
            this.label3.TabIndex = 87;
            this.label3.Text = "Discount";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDiscount
            // 
            this.lblDiscount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDiscount.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblDiscount.Location = new System.Drawing.Point(186, 39);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(169, 23);
            this.lblDiscount.TabIndex = 86;
            this.lblDiscount.Text = "1500.00";
            this.lblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDueAmount
            // 
            this.lblDueAmount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDueAmount.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueAmount.Location = new System.Drawing.Point(186, 120);
            this.lblDueAmount.Name = "lblDueAmount";
            this.lblDueAmount.Size = new System.Drawing.Size(168, 23);
            this.lblDueAmount.TabIndex = 146;
            this.lblDueAmount.Text = "1500.00";
            this.lblDueAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBalance
            // 
            this.lblBalance.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblBalance.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.ForeColor = System.Drawing.Color.Red;
            this.lblBalance.Location = new System.Drawing.Point(189, 147);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(168, 23);
            this.lblBalance.TabIndex = 148;
            this.lblBalance.Text = "1500.00";
            this.lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblBalance);
            this.groupBox3.Controls.Add(this.lblTotal);
            this.groupBox3.Controls.Add(this.lblPaidAmount);
            this.groupBox3.Controls.Add(this.lblBalanceHeader);
            this.groupBox3.Controls.Add(this.lblNetAmount);
            this.groupBox3.Controls.Add(this.lblDiscount);
            this.groupBox3.Controls.Add(this.lableCommon1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.lblDiscountPercentage);
            this.groupBox3.Controls.Add(this.lblTotalAmount);
            this.groupBox3.Controls.Add(this.lableCommon3);
            this.groupBox3.Controls.Add(this.lblDueAmount);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(374, 212);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(370, 176);
            this.groupBox3.TabIndex = 149;
            this.groupBox3.TabStop = false;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(15, 12);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(137, 23);
            this.lblTotal.TabIndex = 130;
            this.lblTotal.Text = "Total Amount";
            // 
            // lblBalanceHeader
            // 
            this.lblBalanceHeader.AutoSize = true;
            this.lblBalanceHeader.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalanceHeader.ForeColor = System.Drawing.Color.Red;
            this.lblBalanceHeader.Location = new System.Drawing.Point(16, 147);
            this.lblBalanceHeader.Name = "lblBalanceHeader";
            this.lblBalanceHeader.Size = new System.Drawing.Size(84, 23);
            this.lblBalanceHeader.TabIndex = 147;
            this.lblBalanceHeader.Text = "Balance";
            // 
            // lableCommon1
            // 
            this.lableCommon1.AutoSize = true;
            this.lableCommon1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon1.Location = new System.Drawing.Point(16, 123);
            this.lableCommon1.Name = "lableCommon1";
            this.lableCommon1.Size = new System.Drawing.Size(46, 18);
            this.lableCommon1.TabIndex = 145;
            this.lableCommon1.Text = "Due ";
            // 
            // lableCommon3
            // 
            this.lableCommon3.AutoSize = true;
            this.lableCommon3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon3.Location = new System.Drawing.Point(16, 98);
            this.lableCommon3.Name = "lableCommon3";
            this.lableCommon3.Size = new System.Drawing.Size(43, 18);
            this.lableCommon3.TabIndex = 137;
            this.lableCommon3.Text = "Paid";
            // 
            // grpPayTypes
            // 
            this.grpPayTypes.Controls.Add(this.btnOther);
            this.grpPayTypes.Controls.Add(this.btnGiftVoucher);
            this.grpPayTypes.Controls.Add(this.btnLoyaltyRedeem);
            this.grpPayTypes.Controls.Add(this.btnCheque);
            this.grpPayTypes.Controls.Add(this.btnAmex);
            this.grpPayTypes.Controls.Add(this.btnMaster);
            this.grpPayTypes.Controls.Add(this.btnVisa);
            this.grpPayTypes.Controls.Add(this.btnCash);
            this.grpPayTypes.Location = new System.Drawing.Point(4, -2);
            this.grpPayTypes.Name = "grpPayTypes";
            this.grpPayTypes.Size = new System.Drawing.Size(268, 386);
            this.grpPayTypes.TabIndex = 135;
            this.grpPayTypes.TabStop = false;
            // 
            // btnOther
            // 
            this.btnOther.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOther.BackgroundImage")));
            this.btnOther.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOther.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOther.Location = new System.Drawing.Point(8, 341);
            this.btnOther.Name = "btnOther";
            this.btnOther.Size = new System.Drawing.Size(254, 41);
            this.btnOther.TabIndex = 7;
            this.btnOther.Text = "Other";
            this.btnOther.UseVisualStyleBackColor = true;
            this.btnOther.Enter += new System.EventHandler(this.btnOther_Enter);
            this.btnOther.Leave += new System.EventHandler(this.btnOther_Leave);
            // 
            // btnGiftVoucher
            // 
            this.btnGiftVoucher.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGiftVoucher.BackgroundImage")));
            this.btnGiftVoucher.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGiftVoucher.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGiftVoucher.Location = new System.Drawing.Point(8, 296);
            this.btnGiftVoucher.Name = "btnGiftVoucher";
            this.btnGiftVoucher.Size = new System.Drawing.Size(254, 41);
            this.btnGiftVoucher.TabIndex = 6;
            this.btnGiftVoucher.Text = "   Gift Voucher";
            this.btnGiftVoucher.UseVisualStyleBackColor = true;
            this.btnGiftVoucher.Enter += new System.EventHandler(this.btnGiftVoucher_Enter);
            this.btnGiftVoucher.Leave += new System.EventHandler(this.btnGiftVoucher_Leave);
            // 
            // btnLoyaltyRedeem
            // 
            this.btnLoyaltyRedeem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLoyaltyRedeem.BackgroundImage")));
            this.btnLoyaltyRedeem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoyaltyRedeem.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoyaltyRedeem.Location = new System.Drawing.Point(8, 249);
            this.btnLoyaltyRedeem.Name = "btnLoyaltyRedeem";
            this.btnLoyaltyRedeem.Size = new System.Drawing.Size(254, 41);
            this.btnLoyaltyRedeem.TabIndex = 5;
            this.btnLoyaltyRedeem.Text = "     Loyalty Redeem";
            this.btnLoyaltyRedeem.UseVisualStyleBackColor = true;
            this.btnLoyaltyRedeem.Click += new System.EventHandler(this.btnLoyaltyRedeem_Click);
            this.btnLoyaltyRedeem.Enter += new System.EventHandler(this.btnLoyaltyRedeem_Enter);
            this.btnLoyaltyRedeem.Leave += new System.EventHandler(this.btnLoyaltyRedeem_Leave);
            // 
            // btnCheque
            // 
            this.btnCheque.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCheque.BackgroundImage")));
            this.btnCheque.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCheque.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheque.Location = new System.Drawing.Point(8, 202);
            this.btnCheque.Name = "btnCheque";
            this.btnCheque.Size = new System.Drawing.Size(254, 41);
            this.btnCheque.TabIndex = 4;
            this.btnCheque.Text = "Cheque";
            this.btnCheque.UseVisualStyleBackColor = true;
            this.btnCheque.Click += new System.EventHandler(this.btnCheque_Click);
            this.btnCheque.Enter += new System.EventHandler(this.btnCheque_Enter);
            this.btnCheque.Leave += new System.EventHandler(this.btnCheque_Leave);
            // 
            // btnAmex
            // 
            this.btnAmex.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAmex.BackgroundImage")));
            this.btnAmex.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAmex.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAmex.Location = new System.Drawing.Point(8, 155);
            this.btnAmex.Name = "btnAmex";
            this.btnAmex.Size = new System.Drawing.Size(254, 41);
            this.btnAmex.TabIndex = 3;
            this.btnAmex.Text = "Amex";
            this.btnAmex.UseVisualStyleBackColor = true;
            this.btnAmex.Click += new System.EventHandler(this.btnAmex_Click);
            this.btnAmex.Enter += new System.EventHandler(this.btnAmex_Enter);
            this.btnAmex.Leave += new System.EventHandler(this.btnAmex_Leave);
            // 
            // btnMaster
            // 
            this.btnMaster.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMaster.BackgroundImage")));
            this.btnMaster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMaster.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaster.Location = new System.Drawing.Point(8, 108);
            this.btnMaster.Name = "btnMaster";
            this.btnMaster.Size = new System.Drawing.Size(254, 41);
            this.btnMaster.TabIndex = 2;
            this.btnMaster.Text = "Master";
            this.btnMaster.UseVisualStyleBackColor = true;
            this.btnMaster.Click += new System.EventHandler(this.btnMaster_Click);
            this.btnMaster.Enter += new System.EventHandler(this.btnMaster_Enter);
            this.btnMaster.Leave += new System.EventHandler(this.btnMaster_Leave);
            // 
            // btnVisa
            // 
            this.btnVisa.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVisa.BackgroundImage")));
            this.btnVisa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVisa.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVisa.Location = new System.Drawing.Point(8, 61);
            this.btnVisa.Name = "btnVisa";
            this.btnVisa.Size = new System.Drawing.Size(254, 41);
            this.btnVisa.TabIndex = 1;
            this.btnVisa.Text = "Visa";
            this.btnVisa.UseVisualStyleBackColor = true;
            this.btnVisa.Click += new System.EventHandler(this.btnVisa_Click);
            this.btnVisa.Enter += new System.EventHandler(this.btnVisa_Enter);
            this.btnVisa.Leave += new System.EventHandler(this.btnVisa_Leave);
            // 
            // btnCash
            // 
            this.btnCash.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCash.BackgroundImage")));
            this.btnCash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCash.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCash.Location = new System.Drawing.Point(8, 14);
            this.btnCash.Name = "btnCash";
            this.btnCash.Size = new System.Drawing.Size(254, 41);
            this.btnCash.TabIndex = 0;
            this.btnCash.Text = "Cash";
            this.btnCash.UseVisualStyleBackColor = true;
            this.btnCash.Click += new System.EventHandler(this.btnCash_Click);
            this.btnCash.Enter += new System.EventHandler(this.btnCash_Enter);
            this.btnCash.Leave += new System.EventHandler(this.btnCash_Leave);
            // 
            // btnF6
            // 
            this.btnF6.BackColor = System.Drawing.Color.LightGray;
            this.btnF6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnF6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF6.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnF6.Location = new System.Drawing.Point(282, 305);
            this.btnF6.Name = "btnF6";
            this.btnF6.Size = new System.Drawing.Size(80, 80);
            this.btnF6.TabIndex = 151;
            this.btnF6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnF6.UseVisualStyleBackColor = false;
            this.btnF6.Click += new System.EventHandler(this.btnF6_Click);
            // 
            // btnF5
            // 
            this.btnF5.BackColor = System.Drawing.Color.LightGray;
            this.btnF5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnF5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF5.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnF5.Location = new System.Drawing.Point(282, 221);
            this.btnF5.Name = "btnF5";
            this.btnF5.Size = new System.Drawing.Size(80, 80);
            this.btnF5.TabIndex = 150;
            this.btnF5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnF5.UseVisualStyleBackColor = false;
            this.btnF5.Click += new System.EventHandler(this.btnF5_Click);
            // 
            // FrmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(748, 391);
            this.Controls.Add(this.btnF6);
            this.Controls.Add(this.btnF5);
            this.Controls.Add(this.grpPayTypes);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment";
            this.Load += new System.EventHandler(this.FrmPayment_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPayment_KeyDown);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grpPayTypes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Custom_Controllers.LableCommon lblTotal;
        private Custom_Controllers.LableCommon lableCommon3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDiscountPercentage;
        private System.Windows.Forms.Label label3;
        private Custom_Controllers.LableCommon lableCommon1;
        private Custom_Controllers.LableCommon lblBalanceHeader;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnVisa;
        private System.Windows.Forms.Button btnMaster;
        private System.Windows.Forms.Button btnLoyaltyRedeem;
        private System.Windows.Forms.Button btnCheque;
        private System.Windows.Forms.Button btnAmex;
        private System.Windows.Forms.Button btnGiftVoucher;
        private System.Windows.Forms.Button btnOther;
        private MyUserControl.UsrPaymentDetailEnter usrPaymentDetailEnter1;
        private MyUserControl.UsrPaymentDetail usrPaymentDetail1;
        public System.Windows.Forms.Label lblTotalAmount;
        public System.Windows.Forms.Label lblPaidAmount;
        public System.Windows.Forms.Label lblNetAmount;
        public System.Windows.Forms.Label lblDiscount;
        public System.Windows.Forms.Label lblDueAmount;
        public System.Windows.Forms.Label lblBalance;
        public System.Windows.Forms.Button btnCash;
        public System.Windows.Forms.GroupBox grpPayTypes;
        private System.Windows.Forms.Button btnF6;
        private System.Windows.Forms.Button btnF5;
    }
}