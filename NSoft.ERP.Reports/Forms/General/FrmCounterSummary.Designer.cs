namespace NSoft.ERP.Reports.Forms.General
{
    partial class FrmCounterSummary
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
            this.cmbCounter = new NSoft.ERP.Reports.Custom_Controllers.ComboBoxDropDown();
            this.lableCommon4 = new NSoft.ERP.Reports.Custom_Controllers.LableCommon();
            this.chkAllCounter = new System.Windows.Forms.CheckBox();
            this.cmbLocation = new NSoft.ERP.Reports.Custom_Controllers.ComboBoxDropDown();
            this.lableCommon3 = new NSoft.ERP.Reports.Custom_Controllers.LableCommon();
            this.lableCommon1 = new NSoft.ERP.Reports.Custom_Controllers.LableCommon();
            this.dtpDateTo = new NSoft.ERP.Reports.Custom_Controllers.DateTimePickerCommon();
            this.chkAllLocations = new System.Windows.Forms.CheckBox();
            this.dtpDateFrom = new NSoft.ERP.Reports.Custom_Controllers.DateTimePickerCommon();
            this.lableCommon2 = new NSoft.ERP.Reports.Custom_Controllers.LableCommon();
            this.grbMargin.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // grbMargin
            // 
            this.grbMargin.Controls.Add(this.cmbCounter);
            this.grbMargin.Controls.Add(this.lableCommon4);
            this.grbMargin.Controls.Add(this.chkAllCounter);
            this.grbMargin.Controls.Add(this.cmbLocation);
            this.grbMargin.Controls.Add(this.lableCommon3);
            this.grbMargin.Controls.Add(this.lableCommon1);
            this.grbMargin.Controls.Add(this.dtpDateTo);
            this.grbMargin.Controls.Add(this.chkAllLocations);
            this.grbMargin.Controls.Add(this.dtpDateFrom);
            this.grbMargin.Controls.Add(this.lableCommon2);
            this.grbMargin.Location = new System.Drawing.Point(3, -3);
            this.grbMargin.Size = new System.Drawing.Size(506, 165);
            this.grbMargin.Controls.SetChildIndex(this.groupBox1, 0);
            this.grbMargin.Controls.SetChildIndex(this.groupBox2, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon2, 0);
            this.grbMargin.Controls.SetChildIndex(this.dtpDateFrom, 0);
            this.grbMargin.Controls.SetChildIndex(this.chkAllLocations, 0);
            this.grbMargin.Controls.SetChildIndex(this.dtpDateTo, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon1, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon3, 0);
            this.grbMargin.Controls.SetChildIndex(this.cmbLocation, 0);
            this.grbMargin.Controls.SetChildIndex(this.chkAllCounter, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon4, 0);
            this.grbMargin.Controls.SetChildIndex(this.cmbCounter, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(298, 109);
            this.groupBox2.Size = new System.Drawing.Size(204, 52);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(105, 11);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(4, 11);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(4, 109);
            this.groupBox1.Size = new System.Drawing.Size(203, 52);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(104, 12);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(3, 12);
            // 
            // cmbCounter
            // 
            this.cmbCounter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCounter.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCounter.FormattingEnabled = true;
            this.cmbCounter.Location = new System.Drawing.Point(105, 46);
            this.cmbCounter.Name = "cmbCounter";
            this.cmbCounter.Size = new System.Drawing.Size(286, 21);
            this.cmbCounter.TabIndex = 22;
            // 
            // lableCommon4
            // 
            this.lableCommon4.AutoSize = true;
            this.lableCommon4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon4.Location = new System.Drawing.Point(9, 49);
            this.lableCommon4.Name = "lableCommon4";
            this.lableCommon4.Size = new System.Drawing.Size(53, 13);
            this.lableCommon4.TabIndex = 23;
            this.lableCommon4.Text = "Counter";
            // 
            // chkAllCounter
            // 
            this.chkAllCounter.AutoSize = true;
            this.chkAllCounter.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllCounter.Location = new System.Drawing.Point(407, 48);
            this.chkAllCounter.Name = "chkAllCounter";
            this.chkAllCounter.Size = new System.Drawing.Size(96, 17);
            this.chkAllCounter.TabIndex = 24;
            this.chkAllCounter.Text = "All Counters";
            this.chkAllCounter.UseVisualStyleBackColor = true;
            this.chkAllCounter.CheckedChanged += new System.EventHandler(this.chkAllCounter_CheckedChanged);
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(105, 13);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(286, 21);
            this.cmbLocation.TabIndex = 15;
            // 
            // lableCommon3
            // 
            this.lableCommon3.AutoSize = true;
            this.lableCommon3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon3.Location = new System.Drawing.Point(243, 85);
            this.lableCommon3.Name = "lableCommon3";
            this.lableCommon3.Size = new System.Drawing.Size(13, 13);
            this.lableCommon3.TabIndex = 21;
            this.lableCommon3.Text = "-";
            // 
            // lableCommon1
            // 
            this.lableCommon1.AutoSize = true;
            this.lableCommon1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon1.Location = new System.Drawing.Point(9, 16);
            this.lableCommon1.Name = "lableCommon1";
            this.lableCommon1.Size = new System.Drawing.Size(54, 13);
            this.lableCommon1.TabIndex = 16;
            this.lableCommon1.Text = "Location";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateTo.Location = new System.Drawing.Point(261, 81);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(130, 21);
            this.dtpDateTo.TabIndex = 20;
            // 
            // chkAllLocations
            // 
            this.chkAllLocations.AutoSize = true;
            this.chkAllLocations.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllLocations.Location = new System.Drawing.Point(407, 15);
            this.chkAllLocations.Name = "chkAllLocations";
            this.chkAllLocations.Size = new System.Drawing.Size(97, 17);
            this.chkAllLocations.TabIndex = 17;
            this.chkAllLocations.Text = "All Locations";
            this.chkAllLocations.UseVisualStyleBackColor = true;
            this.chkAllLocations.CheckedChanged += new System.EventHandler(this.chkAllLocations_CheckedChanged);
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFrom.Location = new System.Drawing.Point(105, 81);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(130, 21);
            this.dtpDateFrom.TabIndex = 19;
            // 
            // lableCommon2
            // 
            this.lableCommon2.AutoSize = true;
            this.lableCommon2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon2.Location = new System.Drawing.Point(9, 84);
            this.lableCommon2.Name = "lableCommon2";
            this.lableCommon2.Size = new System.Drawing.Size(74, 13);
            this.lableCommon2.TabIndex = 18;
            this.lableCommon2.Text = "Date Range";
            // 
            // FrmCounterSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 164);
            this.Name = "FrmCounterSummary";
            this.Text = "FrmCounterSummary";
            this.grbMargin.ResumeLayout(false);
            this.grbMargin.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Custom_Controllers.ComboBoxDropDown cmbCounter;
        private Custom_Controllers.LableCommon lableCommon4;
        private System.Windows.Forms.CheckBox chkAllCounter;
        private Custom_Controllers.ComboBoxDropDown cmbLocation;
        private Custom_Controllers.LableCommon lableCommon3;
        private Custom_Controllers.LableCommon lableCommon1;
        private Custom_Controllers.DateTimePickerCommon dtpDateTo;
        private System.Windows.Forms.CheckBox chkAllLocations;
        private Custom_Controllers.DateTimePickerCommon dtpDateFrom;
        private Custom_Controllers.LableCommon lableCommon2;
    }
}