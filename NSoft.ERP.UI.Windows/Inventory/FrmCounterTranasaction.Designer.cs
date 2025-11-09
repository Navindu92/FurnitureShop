namespace NSoft.ERP.UI.Windows.Inventory
{
    partial class FrmCounterTranasaction
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
            this.lblLocation = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.cmbLocation = new NSoft.ERP.UI.Windows.Custom_Controllers.ComboBoxCommon();
            this.lblDate = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.dtpCounterDate = new NSoft.ERP.UI.Windows.Custom_Controllers.DateTimePickerCommon();
            this.lblUsername = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtAmount = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.lblAmount = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.cmbUsername = new NSoft.ERP.UI.Windows.Custom_Controllers.ComboBoxCommon();
            this.grbMargin.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // grbMargin
            // 
            this.grbMargin.Controls.Add(this.cmbUsername);
            this.grbMargin.Controls.Add(this.txtAmount);
            this.grbMargin.Controls.Add(this.lblAmount);
            this.grbMargin.Controls.Add(this.lblUsername);
            this.grbMargin.Controls.Add(this.dtpCounterDate);
            this.grbMargin.Controls.Add(this.lblDate);
            this.grbMargin.Controls.Add(this.cmbLocation);
            this.grbMargin.Controls.Add(this.lblLocation);
            this.grbMargin.Size = new System.Drawing.Size(509, 199);
            this.grbMargin.Controls.SetChildIndex(this.groupBox1, 0);
            this.grbMargin.Controls.SetChildIndex(this.groupBox2, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblLocation, 0);
            this.grbMargin.Controls.SetChildIndex(this.cmbLocation, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblDate, 0);
            this.grbMargin.Controls.SetChildIndex(this.dtpCounterDate, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblUsername, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblAmount, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtAmount, 0);
            this.grbMargin.Controls.SetChildIndex(this.cmbUsername, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(297, 145);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(7, 145);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocation.Location = new System.Drawing.Point(21, 27);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(54, 13);
            this.lblLocation.TabIndex = 92;
            this.lblLocation.Text = "Location";
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(113, 24);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(217, 21);
            this.cmbLocation.TabIndex = 94;
            this.cmbLocation.Enter += new System.EventHandler(this.cmbLocation_Enter);
            this.cmbLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLocation_KeyDown);
            this.cmbLocation.Leave += new System.EventHandler(this.cmbLocation_Leave);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(21, 62);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(34, 13);
            this.lblDate.TabIndex = 95;
            this.lblDate.Text = "Date";
            // 
            // dtpCounterDate
            // 
            this.dtpCounterDate.CustomFormat = "";
            this.dtpCounterDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCounterDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCounterDate.Location = new System.Drawing.Point(113, 56);
            this.dtpCounterDate.Name = "dtpCounterDate";
            this.dtpCounterDate.Size = new System.Drawing.Size(131, 21);
            this.dtpCounterDate.TabIndex = 96;
            this.dtpCounterDate.Enter += new System.EventHandler(this.dtpCounterDate_Enter);
            this.dtpCounterDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpCounterDate_KeyDown);
            this.dtpCounterDate.Leave += new System.EventHandler(this.dtpCounterDate_Leave);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(21, 88);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(65, 13);
            this.lblUsername.TabIndex = 98;
            this.lblUsername.Text = "Username";
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtAmount.Location = new System.Drawing.Point(113, 113);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(131, 21);
            this.txtAmount.TabIndex = 100;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Enter += new System.EventHandler(this.txtAmount_Enter);
            this.txtAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyDown);
            this.txtAmount.Leave += new System.EventHandler(this.txtAmount_Leave);
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(21, 116);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(51, 13);
            this.lblAmount.TabIndex = 99;
            this.lblAmount.Text = "Amount";
            // 
            // cmbUsername
            // 
            this.cmbUsername.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsername.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUsername.FormattingEnabled = true;
            this.cmbUsername.Location = new System.Drawing.Point(113, 85);
            this.cmbUsername.Name = "cmbUsername";
            this.cmbUsername.Size = new System.Drawing.Size(217, 21);
            this.cmbUsername.TabIndex = 101;
            this.cmbUsername.Enter += new System.EventHandler(this.cmbUsername_Enter);
            this.cmbUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbUsername_KeyDown);
            this.cmbUsername.Leave += new System.EventHandler(this.cmbUsername_Leave);
            // 
            // FrmCounterTranasaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 201);
            this.Name = "FrmCounterTranasaction";
            this.Text = "FrmCounterTranasaction";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCounterTranasaction_FormClosing);
            this.grbMargin.ResumeLayout(false);
            this.grbMargin.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Custom_Controllers.LableCommon lblLocation;
        private Custom_Controllers.ComboBoxCommon cmbLocation;
        private Custom_Controllers.LableCommon lblDate;
        private Custom_Controllers.DateTimePickerCommon dtpCounterDate;
        private Custom_Controllers.LableCommon lblUsername;
        private Custom_Controllers.TextBoxCurrency txtAmount;
        private Custom_Controllers.LableCommon lblAmount;
        private Custom_Controllers.ComboBoxCommon cmbUsername;
    }
}