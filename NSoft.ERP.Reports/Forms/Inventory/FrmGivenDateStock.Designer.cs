namespace NSoft.ERP.Reports.Forms.Inventory
{
    partial class FrmGivenDateStock
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
            this.lableCommon2 = new NSoft.ERP.Reports.Custom_Controllers.LableCommon();
            this.dtpGivenDate = new NSoft.ERP.Reports.Custom_Controllers.DateTimePickerCommon();
            this.chkAllLocations = new System.Windows.Forms.CheckBox();
            this.txtItemCodeFrom = new NSoft.ERP.Reports.Custom_Controllers.TextBoxMasterCode();
            this.txtItemCodeTo = new NSoft.ERP.Reports.Custom_Controllers.TextBoxMasterCode();
            this.lableCommon4 = new NSoft.ERP.Reports.Custom_Controllers.LableCommon();
            this.lableCommon1 = new NSoft.ERP.Reports.Custom_Controllers.LableCommon();
            this.lableCommon5 = new NSoft.ERP.Reports.Custom_Controllers.LableCommon();
            this.txtItemNameFrom = new NSoft.ERP.Reports.Custom_Controllers.TextBoxDescription();
            this.cmbLocation = new NSoft.ERP.Reports.Custom_Controllers.ComboBoxDropDown();
            this.txtItemNameTo = new NSoft.ERP.Reports.Custom_Controllers.TextBoxDescription();
            this.chkWithoutZero = new System.Windows.Forms.CheckBox();
            this.grbMargin.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // grbMargin
            // 
            this.grbMargin.Controls.Add(this.chkWithoutZero);
            this.grbMargin.Controls.Add(this.txtItemNameTo);
            this.grbMargin.Controls.Add(this.cmbLocation);
            this.grbMargin.Controls.Add(this.txtItemNameFrom);
            this.grbMargin.Controls.Add(this.lableCommon5);
            this.grbMargin.Controls.Add(this.lableCommon2);
            this.grbMargin.Controls.Add(this.lableCommon1);
            this.grbMargin.Controls.Add(this.dtpGivenDate);
            this.grbMargin.Controls.Add(this.lableCommon4);
            this.grbMargin.Controls.Add(this.chkAllLocations);
            this.grbMargin.Controls.Add(this.txtItemCodeTo);
            this.grbMargin.Controls.Add(this.txtItemCodeFrom);
            this.grbMargin.Size = new System.Drawing.Size(567, 215);
            this.grbMargin.Controls.SetChildIndex(this.txtItemCodeFrom, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtItemCodeTo, 0);
            this.grbMargin.Controls.SetChildIndex(this.chkAllLocations, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon4, 0);
            this.grbMargin.Controls.SetChildIndex(this.dtpGivenDate, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon1, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon2, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon5, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtItemNameFrom, 0);
            this.grbMargin.Controls.SetChildIndex(this.cmbLocation, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtItemNameTo, 0);
            this.grbMargin.Controls.SetChildIndex(this.groupBox1, 0);
            this.grbMargin.Controls.SetChildIndex(this.groupBox2, 0);
            this.grbMargin.Controls.SetChildIndex(this.chkWithoutZero, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(359, 163);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(4, 163);
            // 
            // lableCommon2
            // 
            this.lableCommon2.AutoSize = true;
            this.lableCommon2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon2.Location = new System.Drawing.Point(12, 63);
            this.lableCommon2.Name = "lableCommon2";
            this.lableCommon2.Size = new System.Drawing.Size(41, 13);
            this.lableCommon2.TabIndex = 8;
            this.lableCommon2.Text = "Date ";
            // 
            // dtpGivenDate
            // 
            this.dtpGivenDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpGivenDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpGivenDate.Location = new System.Drawing.Point(108, 57);
            this.dtpGivenDate.Name = "dtpGivenDate";
            this.dtpGivenDate.Size = new System.Drawing.Size(130, 21);
            this.dtpGivenDate.TabIndex = 9;
            // 
            // chkAllLocations
            // 
            this.chkAllLocations.AutoSize = true;
            this.chkAllLocations.Enabled = false;
            this.chkAllLocations.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllLocations.Location = new System.Drawing.Point(400, 23);
            this.chkAllLocations.Name = "chkAllLocations";
            this.chkAllLocations.Size = new System.Drawing.Size(97, 17);
            this.chkAllLocations.TabIndex = 7;
            this.chkAllLocations.Text = "All Locations";
            this.chkAllLocations.UseVisualStyleBackColor = true;
            // 
            // txtItemCodeFrom
            // 
            this.txtItemCodeFrom.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCodeFrom.Location = new System.Drawing.Point(108, 94);
            this.txtItemCodeFrom.MaxLength = 20;
            this.txtItemCodeFrom.Name = "txtItemCodeFrom";
            this.txtItemCodeFrom.Size = new System.Drawing.Size(130, 21);
            this.txtItemCodeFrom.TabIndex = 20;
            this.txtItemCodeFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemCodeFrom_KeyDown);
            this.txtItemCodeFrom.Leave += new System.EventHandler(this.txtItemCodeFrom_Leave);
            // 
            // txtItemCodeTo
            // 
            this.txtItemCodeTo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCodeTo.Location = new System.Drawing.Point(108, 121);
            this.txtItemCodeTo.MaxLength = 20;
            this.txtItemCodeTo.Name = "txtItemCodeTo";
            this.txtItemCodeTo.Size = new System.Drawing.Size(130, 21);
            this.txtItemCodeTo.TabIndex = 21;
            this.txtItemCodeTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemCodeTo_KeyDown);
            this.txtItemCodeTo.Leave += new System.EventHandler(this.txtItemCodeTo_Leave);
            // 
            // lableCommon4
            // 
            this.lableCommon4.AutoSize = true;
            this.lableCommon4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon4.Location = new System.Drawing.Point(12, 97);
            this.lableCommon4.Name = "lableCommon4";
            this.lableCommon4.Size = new System.Drawing.Size(76, 13);
            this.lableCommon4.TabIndex = 22;
            this.lableCommon4.Text = "Item From";
            // 
            // lableCommon1
            // 
            this.lableCommon1.AutoSize = true;
            this.lableCommon1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon1.Location = new System.Drawing.Point(12, 22);
            this.lableCommon1.Name = "lableCommon1";
            this.lableCommon1.Size = new System.Drawing.Size(62, 13);
            this.lableCommon1.TabIndex = 6;
            this.lableCommon1.Text = "Location";
            // 
            // lableCommon5
            // 
            this.lableCommon5.AutoSize = true;
            this.lableCommon5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon5.Location = new System.Drawing.Point(12, 124);
            this.lableCommon5.Name = "lableCommon5";
            this.lableCommon5.Size = new System.Drawing.Size(54, 13);
            this.lableCommon5.TabIndex = 23;
            this.lableCommon5.Text = "ItemTo";
            // 
            // txtItemNameFrom
            // 
            this.txtItemNameFrom.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemNameFrom.Location = new System.Drawing.Point(244, 94);
            this.txtItemNameFrom.Name = "txtItemNameFrom";
            this.txtItemNameFrom.Size = new System.Drawing.Size(313, 21);
            this.txtItemNameFrom.TabIndex = 24;
            this.txtItemNameFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemNameFrom_KeyDown);
            this.txtItemNameFrom.Leave += new System.EventHandler(this.txtItemNameFrom_Leave);
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(108, 19);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(286, 21);
            this.cmbLocation.TabIndex = 5;
            // 
            // txtItemNameTo
            // 
            this.txtItemNameTo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemNameTo.Location = new System.Drawing.Point(244, 121);
            this.txtItemNameTo.Name = "txtItemNameTo";
            this.txtItemNameTo.Size = new System.Drawing.Size(313, 21);
            this.txtItemNameTo.TabIndex = 25;
            this.txtItemNameTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemNameTo_KeyDown);
            this.txtItemNameTo.Leave += new System.EventHandler(this.txtItemNameTo_Leave);
            // 
            // chkWithoutZero
            // 
            this.chkWithoutZero.AutoSize = true;
            this.chkWithoutZero.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkWithoutZero.Location = new System.Drawing.Point(457, 148);
            this.chkWithoutZero.Name = "chkWithoutZero";
            this.chkWithoutZero.Size = new System.Drawing.Size(100, 17);
            this.chkWithoutZero.TabIndex = 26;
            this.chkWithoutZero.Text = "Without Zero";
            this.chkWithoutZero.UseVisualStyleBackColor = true;
            // 
            // FrmGivenDateStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 217);
            this.Name = "FrmGivenDateStock";
            this.Text = "FrmGivenDateStock";
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
        private Custom_Controllers.LableCommon lableCommon5;
        private Custom_Controllers.LableCommon lableCommon2;
        private Custom_Controllers.LableCommon lableCommon1;
        private Custom_Controllers.DateTimePickerCommon dtpGivenDate;
        private Custom_Controllers.LableCommon lableCommon4;
        private System.Windows.Forms.CheckBox chkAllLocations;
        private Custom_Controllers.TextBoxMasterCode txtItemCodeTo;
        private Custom_Controllers.TextBoxMasterCode txtItemCodeFrom;
        private System.Windows.Forms.CheckBox chkWithoutZero;
    }
}