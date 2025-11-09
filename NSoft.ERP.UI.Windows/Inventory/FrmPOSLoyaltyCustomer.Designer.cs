namespace NSoft.ERP.UI.Windows.Inventory
{
    partial class FrmPOSLoyaltyCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPOSLoyaltyCustomer));
            this.groupBoxCommon1 = new NSoft.ERP.UI.Windows.Custom_Controllers.GroupBoxCommon();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblCurrentPoints = new System.Windows.Forms.Label();
            this.txtCommon = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.lableCommon4 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lblCustomerCode = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtCardNo = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.txtNIC = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.lableCommon1 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lableCommon3 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtCustomerName = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.lableCommon2 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtMobileNo = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBoxCommon1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxCommon1
            // 
            this.groupBoxCommon1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCommon1.Controls.Add(this.pictureBox3);
            this.groupBoxCommon1.Controls.Add(this.lblCurrentPoints);
            this.groupBoxCommon1.Controls.Add(this.txtCommon);
            this.groupBoxCommon1.Controls.Add(this.lableCommon4);
            this.groupBoxCommon1.Controls.Add(this.lblCustomerCode);
            this.groupBoxCommon1.Controls.Add(this.txtCardNo);
            this.groupBoxCommon1.Controls.Add(this.txtNIC);
            this.groupBoxCommon1.Controls.Add(this.lableCommon1);
            this.groupBoxCommon1.Controls.Add(this.lableCommon3);
            this.groupBoxCommon1.Controls.Add(this.txtCustomerName);
            this.groupBoxCommon1.Controls.Add(this.lableCommon2);
            this.groupBoxCommon1.Controls.Add(this.txtMobileNo);
            this.groupBoxCommon1.Controls.Add(this.pictureBox1);
            this.groupBoxCommon1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCommon1.Location = new System.Drawing.Point(3, -4);
            this.groupBoxCommon1.Name = "groupBoxCommon1";
            this.groupBoxCommon1.Size = new System.Drawing.Size(547, 252);
            this.groupBoxCommon1.TabIndex = 126;
            this.groupBoxCommon1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(394, 204);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(151, 40);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 162;
            this.pictureBox3.TabStop = false;
            // 
            // lblCurrentPoints
            // 
            this.lblCurrentPoints.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCurrentPoints.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPoints.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblCurrentPoints.Location = new System.Drawing.Point(127, 182);
            this.lblCurrentPoints.Name = "lblCurrentPoints";
            this.lblCurrentPoints.Size = new System.Drawing.Size(151, 23);
            this.lblCurrentPoints.TabIndex = 157;
            this.lblCurrentPoints.Text = "0";
            this.lblCurrentPoints.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCommon
            // 
            this.txtCommon.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommon.Location = new System.Drawing.Point(6, 16);
            this.txtCommon.Name = "txtCommon";
            this.txtCommon.Size = new System.Drawing.Size(491, 31);
            this.txtCommon.TabIndex = 31;
            this.txtCommon.TabStop = false;
            this.txtCommon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCommon_KeyDown);
            // 
            // lableCommon4
            // 
            this.lableCommon4.AutoSize = true;
            this.lableCommon4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon4.Location = new System.Drawing.Point(8, 185);
            this.lableCommon4.Name = "lableCommon4";
            this.lableCommon4.Size = new System.Drawing.Size(112, 16);
            this.lableCommon4.TabIndex = 125;
            this.lableCommon4.Text = "Current Points";
            // 
            // lblCustomerCode
            // 
            this.lblCustomerCode.AutoSize = true;
            this.lblCustomerCode.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerCode.Location = new System.Drawing.Point(8, 58);
            this.lblCustomerCode.Name = "lblCustomerCode";
            this.lblCustomerCode.Size = new System.Drawing.Size(60, 16);
            this.lblCustomerCode.TabIndex = 25;
            this.lblCustomerCode.Text = "Card No";
            // 
            // txtCardNo
            // 
            this.txtCardNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardNo.Location = new System.Drawing.Point(132, 55);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.ReadOnly = true;
            this.txtCardNo.Size = new System.Drawing.Size(222, 23);
            this.txtCardNo.TabIndex = 26;
            this.txtCardNo.TabStop = false;
            this.txtCardNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCardNo_KeyDown);
            // 
            // txtNIC
            // 
            this.txtNIC.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNIC.Location = new System.Drawing.Point(132, 142);
            this.txtNIC.Name = "txtNIC";
            this.txtNIC.ReadOnly = true;
            this.txtNIC.Size = new System.Drawing.Size(222, 23);
            this.txtNIC.TabIndex = 33;
            this.txtNIC.TabStop = false;
            this.txtNIC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNIC_KeyDown);
            // 
            // lableCommon1
            // 
            this.lableCommon1.AutoSize = true;
            this.lableCommon1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon1.Location = new System.Drawing.Point(8, 87);
            this.lableCommon1.Name = "lableCommon1";
            this.lableCommon1.Size = new System.Drawing.Size(111, 16);
            this.lableCommon1.TabIndex = 27;
            this.lableCommon1.Text = "Customer Name";
            // 
            // lableCommon3
            // 
            this.lableCommon3.AutoSize = true;
            this.lableCommon3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon3.Location = new System.Drawing.Point(8, 145);
            this.lableCommon3.Name = "lableCommon3";
            this.lableCommon3.Size = new System.Drawing.Size(50, 16);
            this.lableCommon3.TabIndex = 32;
            this.lableCommon3.Text = "Nic No";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(132, 84);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(372, 23);
            this.txtCustomerName.TabIndex = 28;
            this.txtCustomerName.TabStop = false;
            this.txtCustomerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerName_KeyDown);
            // 
            // lableCommon2
            // 
            this.lableCommon2.AutoSize = true;
            this.lableCommon2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon2.Location = new System.Drawing.Point(8, 116);
            this.lableCommon2.Name = "lableCommon2";
            this.lableCommon2.Size = new System.Drawing.Size(71, 16);
            this.lableCommon2.TabIndex = 29;
            this.lableCommon2.Text = "Mobile No";
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobileNo.Location = new System.Drawing.Point(132, 113);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.ReadOnly = true;
            this.txtMobileNo.Size = new System.Drawing.Size(222, 23);
            this.txtMobileNo.TabIndex = 30;
            this.txtMobileNo.TabStop = false;
            this.txtMobileNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMobileNo_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(406, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(151, 143);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 158;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // FrmPOSLoyaltyCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(554, 251);
            this.Controls.Add(this.groupBoxCommon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPOSLoyaltyCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "POS - Loyalty Customer";
            this.Load += new System.EventHandler(this.FrmPOSLoyaltyCustomer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPOSLoyaltyCustomer_KeyDown);
            this.groupBoxCommon1.ResumeLayout(false);
            this.groupBoxCommon1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Custom_Controllers.LableCommon lblCustomerCode;
        private Custom_Controllers.TextBoxDescription txtCardNo;
        private Custom_Controllers.TextBoxDescription txtCustomerName;
        private Custom_Controllers.LableCommon lableCommon1;
        private Custom_Controllers.TextBoxDescription txtMobileNo;
        private Custom_Controllers.LableCommon lableCommon2;
        private Custom_Controllers.TextBoxDescription txtCommon;
        private Custom_Controllers.TextBoxDescription txtNIC;
        private Custom_Controllers.LableCommon lableCommon3;
        private Custom_Controllers.LableCommon lableCommon4;
        private Custom_Controllers.GroupBoxCommon groupBoxCommon1;
        public System.Windows.Forms.Label lblCurrentPoints;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}