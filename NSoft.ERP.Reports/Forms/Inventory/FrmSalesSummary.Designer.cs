namespace NSoft.ERP.Reports.Forms.Inventory
{
    partial class FrmSalesSummary
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
            this.txtItemNameTo = new NSoft.ERP.Reports.Custom_Controllers.TextBoxDescription();
            this.cmbLocation = new NSoft.ERP.Reports.Custom_Controllers.ComboBoxDropDown();
            this.txtItemNameFrom = new NSoft.ERP.Reports.Custom_Controllers.TextBoxDescription();
            this.lableCommon3 = new NSoft.ERP.Reports.Custom_Controllers.LableCommon();
            this.dtpDateTo = new NSoft.ERP.Reports.Custom_Controllers.DateTimePickerCommon();
            this.lableCommon5 = new NSoft.ERP.Reports.Custom_Controllers.LableCommon();
            this.lableCommon2 = new NSoft.ERP.Reports.Custom_Controllers.LableCommon();
            this.lableCommon1 = new NSoft.ERP.Reports.Custom_Controllers.LableCommon();
            this.dtpDateFrom = new NSoft.ERP.Reports.Custom_Controllers.DateTimePickerCommon();
            this.lableCommon4 = new NSoft.ERP.Reports.Custom_Controllers.LableCommon();
            this.txtItemCodeTo = new NSoft.ERP.Reports.Custom_Controllers.TextBoxMasterCode();
            this.txtItemCodeFrom = new NSoft.ERP.Reports.Custom_Controllers.TextBoxMasterCode();
            this.grbMargin.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // grbMargin
            // 
            this.grbMargin.Controls.Add(this.txtItemNameTo);
            this.grbMargin.Controls.Add(this.cmbLocation);
            this.grbMargin.Controls.Add(this.txtItemNameFrom);
            this.grbMargin.Controls.Add(this.lableCommon3);
            this.grbMargin.Controls.Add(this.dtpDateTo);
            this.grbMargin.Controls.Add(this.lableCommon5);
            this.grbMargin.Controls.Add(this.lableCommon2);
            this.grbMargin.Controls.Add(this.lableCommon1);
            this.grbMargin.Controls.Add(this.dtpDateFrom);
            this.grbMargin.Controls.Add(this.lableCommon4);
            this.grbMargin.Controls.Add(this.txtItemCodeTo);
            this.grbMargin.Controls.Add(this.txtItemCodeFrom);
            this.grbMargin.Size = new System.Drawing.Size(567, 199);
            this.grbMargin.Controls.SetChildIndex(this.groupBox1, 0);
            this.grbMargin.Controls.SetChildIndex(this.groupBox2, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtItemCodeFrom, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtItemCodeTo, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon4, 0);
            this.grbMargin.Controls.SetChildIndex(this.dtpDateFrom, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon1, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon2, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon5, 0);
            this.grbMargin.Controls.SetChildIndex(this.dtpDateTo, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon3, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtItemNameFrom, 0);
            this.grbMargin.Controls.SetChildIndex(this.cmbLocation, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtItemNameTo, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(359, 147);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(4, 147);
            // 
            // txtItemNameTo
            // 
            this.txtItemNameTo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemNameTo.Location = new System.Drawing.Point(243, 116);
            this.txtItemNameTo.Name = "txtItemNameTo";
            this.txtItemNameTo.Size = new System.Drawing.Size(313, 21);
            this.txtItemNameTo.TabIndex = 37;
            this.txtItemNameTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemNameTo_KeyDown);
            this.txtItemNameTo.Leave += new System.EventHandler(this.txtItemNameTo_Leave);
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(107, 14);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(286, 21);
            this.cmbLocation.TabIndex = 26;
            // 
            // txtItemNameFrom
            // 
            this.txtItemNameFrom.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemNameFrom.Location = new System.Drawing.Point(243, 89);
            this.txtItemNameFrom.Name = "txtItemNameFrom";
            this.txtItemNameFrom.Size = new System.Drawing.Size(313, 21);
            this.txtItemNameFrom.TabIndex = 36;
            this.txtItemNameFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemNameFrom_KeyDown);
            this.txtItemNameFrom.Leave += new System.EventHandler(this.txtItemNameFrom_Leave);
            // 
            // lableCommon3
            // 
            this.lableCommon3.AutoSize = true;
            this.lableCommon3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon3.Location = new System.Drawing.Point(245, 56);
            this.lableCommon3.Name = "lableCommon3";
            this.lableCommon3.Size = new System.Drawing.Size(13, 13);
            this.lableCommon3.TabIndex = 31;
            this.lableCommon3.Text = "-";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateTo.Location = new System.Drawing.Point(263, 52);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(130, 21);
            this.dtpDateTo.TabIndex = 30;
            // 
            // lableCommon5
            // 
            this.lableCommon5.AutoSize = true;
            this.lableCommon5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon5.Location = new System.Drawing.Point(11, 119);
            this.lableCommon5.Name = "lableCommon5";
            this.lableCommon5.Size = new System.Drawing.Size(54, 13);
            this.lableCommon5.TabIndex = 35;
            this.lableCommon5.Text = "ItemTo";
            // 
            // lableCommon2
            // 
            this.lableCommon2.AutoSize = true;
            this.lableCommon2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon2.Location = new System.Drawing.Point(11, 58);
            this.lableCommon2.Name = "lableCommon2";
            this.lableCommon2.Size = new System.Drawing.Size(81, 13);
            this.lableCommon2.TabIndex = 28;
            this.lableCommon2.Text = "Date Range";
            // 
            // lableCommon1
            // 
            this.lableCommon1.AutoSize = true;
            this.lableCommon1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon1.Location = new System.Drawing.Point(11, 17);
            this.lableCommon1.Name = "lableCommon1";
            this.lableCommon1.Size = new System.Drawing.Size(62, 13);
            this.lableCommon1.TabIndex = 27;
            this.lableCommon1.Text = "Location";
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFrom.Location = new System.Drawing.Point(107, 52);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(130, 21);
            this.dtpDateFrom.TabIndex = 29;
            // 
            // lableCommon4
            // 
            this.lableCommon4.AutoSize = true;
            this.lableCommon4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon4.Location = new System.Drawing.Point(11, 92);
            this.lableCommon4.Name = "lableCommon4";
            this.lableCommon4.Size = new System.Drawing.Size(76, 13);
            this.lableCommon4.TabIndex = 34;
            this.lableCommon4.Text = "Item From";
            // 
            // txtItemCodeTo
            // 
            this.txtItemCodeTo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCodeTo.Location = new System.Drawing.Point(107, 116);
            this.txtItemCodeTo.MaxLength = 20;
            this.txtItemCodeTo.Name = "txtItemCodeTo";
            this.txtItemCodeTo.Size = new System.Drawing.Size(130, 21);
            this.txtItemCodeTo.TabIndex = 33;
            this.txtItemCodeTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemCodeTo_KeyDown);
            this.txtItemCodeTo.Leave += new System.EventHandler(this.txtItemCodeTo_Leave);
            // 
            // txtItemCodeFrom
            // 
            this.txtItemCodeFrom.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCodeFrom.Location = new System.Drawing.Point(107, 89);
            this.txtItemCodeFrom.MaxLength = 20;
            this.txtItemCodeFrom.Name = "txtItemCodeFrom";
            this.txtItemCodeFrom.Size = new System.Drawing.Size(130, 21);
            this.txtItemCodeFrom.TabIndex = 32;
            this.txtItemCodeFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemCodeFrom_KeyDown);
            this.txtItemCodeFrom.Leave += new System.EventHandler(this.txtItemCodeFrom_Leave);
            // 
            // FrmSalesSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 201);
            this.Name = "FrmSalesSummary";
            this.Text = "FrmSalesSummary";
            this.grbMargin.ResumeLayout(false);
            this.grbMargin.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Custom_Controllers.TextBoxDescription txtItemNameTo;
        private Custom_Controllers.ComboBoxDropDown cmbLocation;
        private Custom_Controllers.TextBoxDescription txtItemNameFrom;
        private Custom_Controllers.LableCommon lableCommon3;
        private Custom_Controllers.DateTimePickerCommon dtpDateTo;
        private Custom_Controllers.LableCommon lableCommon5;
        private Custom_Controllers.LableCommon lableCommon2;
        private Custom_Controllers.LableCommon lableCommon1;
        private Custom_Controllers.DateTimePickerCommon dtpDateFrom;
        private Custom_Controllers.LableCommon lableCommon4;
        private Custom_Controllers.TextBoxMasterCode txtItemCodeTo;
        private Custom_Controllers.TextBoxMasterCode txtItemCodeFrom;
    }
}