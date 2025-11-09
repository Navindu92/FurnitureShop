namespace NSoft.ERP.UI.Windows.General
{
    partial class FrmLocation
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
            this.txtLocationCode = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxMasterCode();
            this.lblLocaCode = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lblLocationName = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtLocationName = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.lableCommon1 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtAddress = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCommon();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.chkStockLocation = new System.Windows.Forms.CheckBox();
            this.chkHeadOffice = new System.Windows.Forms.CheckBox();
            this.grbMargin.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // grbMargin
            // 
            this.grbMargin.Controls.Add(this.chkHeadOffice);
            this.grbMargin.Controls.Add(this.chkStockLocation);
            this.grbMargin.Controls.Add(this.chkActive);
            this.grbMargin.Controls.Add(this.txtAddress);
            this.grbMargin.Controls.Add(this.lableCommon1);
            this.grbMargin.Controls.Add(this.txtLocationName);
            this.grbMargin.Controls.Add(this.lblLocationName);
            this.grbMargin.Controls.Add(this.lblLocaCode);
            this.grbMargin.Controls.Add(this.txtLocationCode);
            this.grbMargin.Controls.Add(this.btnNew);
            this.grbMargin.Size = new System.Drawing.Size(480, 236);
            this.grbMargin.Controls.SetChildIndex(this.groupBox1, 0);
            this.grbMargin.Controls.SetChildIndex(this.groupBox2, 0);
            this.grbMargin.Controls.SetChildIndex(this.btnNew, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtLocationCode, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblLocaCode, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblLocationName, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtLocationName, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon1, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtAddress, 0);
            this.grbMargin.Controls.SetChildIndex(this.chkActive, 0);
            this.grbMargin.Controls.SetChildIndex(this.chkStockLocation, 0);
            this.grbMargin.Controls.SetChildIndex(this.chkHeadOffice, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(4, 184);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(272, 184);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(262, 18);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(50, 23);
            this.btnNew.TabIndex = 5;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtLocationCode
            // 
            this.txtLocationCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocationCode.Location = new System.Drawing.Point(113, 20);
            this.txtLocationCode.MaxLength = 10;
            this.txtLocationCode.Name = "txtLocationCode";
            this.txtLocationCode.Size = new System.Drawing.Size(143, 21);
            this.txtLocationCode.TabIndex = 6;
            this.txtLocationCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLocationCode_KeyDown);
            this.txtLocationCode.Leave += new System.EventHandler(this.txtLocationCode_Leave);
            // 
            // lblLocaCode
            // 
            this.lblLocaCode.AutoSize = true;
            this.lblLocaCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocaCode.Location = new System.Drawing.Point(9, 23);
            this.lblLocaCode.Name = "lblLocaCode";
            this.lblLocaCode.Size = new System.Drawing.Size(85, 13);
            this.lblLocaCode.TabIndex = 7;
            this.lblLocaCode.Text = "Loca.Code *";
            // 
            // lblLocationName
            // 
            this.lblLocationName.AutoSize = true;
            this.lblLocationName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocationName.Location = new System.Drawing.Point(9, 55);
            this.lblLocationName.Name = "lblLocationName";
            this.lblLocationName.Size = new System.Drawing.Size(90, 13);
            this.lblLocationName.TabIndex = 8;
            this.lblLocationName.Text = "Loca.Name *";
            // 
            // txtLocationName
            // 
            this.txtLocationName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocationName.Location = new System.Drawing.Point(113, 52);
            this.txtLocationName.Name = "txtLocationName";
            this.txtLocationName.Size = new System.Drawing.Size(356, 21);
            this.txtLocationName.TabIndex = 9;
            this.txtLocationName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLocationName_KeyDown);
            this.txtLocationName.Leave += new System.EventHandler(this.txtLocationName_Leave);
            // 
            // lableCommon1
            // 
            this.lableCommon1.AutoSize = true;
            this.lableCommon1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon1.Location = new System.Drawing.Point(9, 84);
            this.lableCommon1.Name = "lableCommon1";
            this.lableCommon1.Size = new System.Drawing.Size(60, 13);
            this.lableCommon1.TabIndex = 10;
            this.lableCommon1.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(113, 81);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(356, 66);
            this.txtAddress.TabIndex = 11;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(318, 22);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(61, 17);
            this.chkActive.TabIndex = 21;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // chkStockLocation
            // 
            this.chkStockLocation.AutoSize = true;
            this.chkStockLocation.Checked = true;
            this.chkStockLocation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStockLocation.Location = new System.Drawing.Point(113, 162);
            this.chkStockLocation.Name = "chkStockLocation";
            this.chkStockLocation.Size = new System.Drawing.Size(109, 17);
            this.chkStockLocation.TabIndex = 22;
            this.chkStockLocation.Text = "Stock Location";
            this.chkStockLocation.UseVisualStyleBackColor = true;
            // 
            // chkHeadOffice
            // 
            this.chkHeadOffice.AutoSize = true;
            this.chkHeadOffice.Checked = true;
            this.chkHeadOffice.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHeadOffice.Location = new System.Drawing.Point(228, 161);
            this.chkHeadOffice.Name = "chkHeadOffice";
            this.chkHeadOffice.Size = new System.Drawing.Size(92, 17);
            this.chkHeadOffice.TabIndex = 23;
            this.chkHeadOffice.Text = "Head Office";
            this.chkHeadOffice.UseVisualStyleBackColor = true;
            // 
            // FrmLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 237);
            this.Name = "FrmLocation";
            this.Text = "FrmLocation";
            this.grbMargin.ResumeLayout(false);
            this.grbMargin.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Custom_Controllers.TextBoxMasterCode txtLocationCode;
        private Custom_Controllers.ButtonNew btnNew;
        private Custom_Controllers.LableCommon lblLocaCode;
        private Custom_Controllers.LableCommon lblLocationName;
        private Custom_Controllers.TextBoxDescription txtLocationName;
        private Custom_Controllers.LableCommon lableCommon1;
        private Custom_Controllers.TextBoxCommon txtAddress;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.CheckBox chkStockLocation;
        private System.Windows.Forms.CheckBox chkHeadOffice;
    }
}