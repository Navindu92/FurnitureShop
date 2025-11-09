namespace NSoft.ERP.Reports.Forms.General
{
    partial class FrmPaidInPaidOutReport
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
            this.chkAllCounter = new System.Windows.Forms.CheckBox();
            this.chkAllLocations = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstPaidIn = new System.Windows.Forms.ListView();
            this.chkAllPaidIn = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lstPaidOut = new System.Windows.Forms.ListView();
            this.chkAllPaidOut = new System.Windows.Forms.CheckBox();
            this.cmbCounter = new NSoft.ERP.Reports.Custom_Controllers.ComboBoxDropDown();
            this.lableCommon4 = new NSoft.ERP.Reports.Custom_Controllers.LableCommon();
            this.cmbLocation = new NSoft.ERP.Reports.Custom_Controllers.ComboBoxDropDown();
            this.lableCommon2 = new NSoft.ERP.Reports.Custom_Controllers.LableCommon();
            this.lableCommon3 = new NSoft.ERP.Reports.Custom_Controllers.LableCommon();
            this.dtpDateFrom = new NSoft.ERP.Reports.Custom_Controllers.DateTimePickerCommon();
            this.lableCommon1 = new NSoft.ERP.Reports.Custom_Controllers.LableCommon();
            this.dtpDateTo = new NSoft.ERP.Reports.Custom_Controllers.DateTimePickerCommon();
            this.rdbIsPaidIn = new System.Windows.Forms.RadioButton();
            this.rdbPaidOut = new System.Windows.Forms.RadioButton();
            this.grbMargin.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbMargin
            // 
            this.grbMargin.Controls.Add(this.rdbPaidOut);
            this.grbMargin.Controls.Add(this.rdbIsPaidIn);
            this.grbMargin.Controls.Add(this.groupBox4);
            this.grbMargin.Controls.Add(this.groupBox3);
            this.grbMargin.Controls.Add(this.cmbCounter);
            this.grbMargin.Controls.Add(this.lableCommon4);
            this.grbMargin.Controls.Add(this.chkAllCounter);
            this.grbMargin.Controls.Add(this.cmbLocation);
            this.grbMargin.Controls.Add(this.lableCommon2);
            this.grbMargin.Controls.Add(this.lableCommon3);
            this.grbMargin.Controls.Add(this.dtpDateFrom);
            this.grbMargin.Controls.Add(this.lableCommon1);
            this.grbMargin.Controls.Add(this.chkAllLocations);
            this.grbMargin.Controls.Add(this.dtpDateTo);
            this.grbMargin.Size = new System.Drawing.Size(507, 346);
            this.grbMargin.Controls.SetChildIndex(this.dtpDateTo, 0);
            this.grbMargin.Controls.SetChildIndex(this.chkAllLocations, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon1, 0);
            this.grbMargin.Controls.SetChildIndex(this.dtpDateFrom, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon3, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon2, 0);
            this.grbMargin.Controls.SetChildIndex(this.cmbLocation, 0);
            this.grbMargin.Controls.SetChildIndex(this.chkAllCounter, 0);
            this.grbMargin.Controls.SetChildIndex(this.groupBox1, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon4, 0);
            this.grbMargin.Controls.SetChildIndex(this.groupBox2, 0);
            this.grbMargin.Controls.SetChildIndex(this.cmbCounter, 0);
            this.grbMargin.Controls.SetChildIndex(this.groupBox3, 0);
            this.grbMargin.Controls.SetChildIndex(this.groupBox4, 0);
            this.grbMargin.Controls.SetChildIndex(this.rdbIsPaidIn, 0);
            this.grbMargin.Controls.SetChildIndex(this.rdbPaidOut, 0);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(299, 294);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(4, 294);
            // 
            // chkAllCounter
            // 
            this.chkAllCounter.AutoSize = true;
            this.chkAllCounter.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllCounter.Location = new System.Drawing.Point(400, 50);
            this.chkAllCounter.Name = "chkAllCounter";
            this.chkAllCounter.Size = new System.Drawing.Size(96, 17);
            this.chkAllCounter.TabIndex = 24;
            this.chkAllCounter.Text = "All Counters";
            this.chkAllCounter.UseVisualStyleBackColor = true;
            this.chkAllCounter.CheckedChanged += new System.EventHandler(this.chkAllCounter_CheckedChanged);
            // 
            // chkAllLocations
            // 
            this.chkAllLocations.AutoSize = true;
            this.chkAllLocations.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllLocations.Location = new System.Drawing.Point(400, 23);
            this.chkAllLocations.Name = "chkAllLocations";
            this.chkAllLocations.Size = new System.Drawing.Size(97, 17);
            this.chkAllLocations.TabIndex = 17;
            this.chkAllLocations.Text = "All Locations";
            this.chkAllLocations.UseVisualStyleBackColor = true;
            this.chkAllLocations.CheckedChanged += new System.EventHandler(this.chkAllLocations_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstPaidIn);
            this.groupBox3.Controls.Add(this.chkAllPaidIn);
            this.groupBox3.Enabled = false;
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(16, 124);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(236, 168);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Paid In";
            // 
            // lstPaidIn
            // 
            this.lstPaidIn.CheckBoxes = true;
            this.lstPaidIn.Location = new System.Drawing.Point(6, 41);
            this.lstPaidIn.Name = "lstPaidIn";
            this.lstPaidIn.Size = new System.Drawing.Size(224, 121);
            this.lstPaidIn.TabIndex = 29;
            this.lstPaidIn.UseCompatibleStateImageBehavior = false;
            this.lstPaidIn.View = System.Windows.Forms.View.List;
            // 
            // chkAllPaidIn
            // 
            this.chkAllPaidIn.AutoSize = true;
            this.chkAllPaidIn.Checked = true;
            this.chkAllPaidIn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllPaidIn.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllPaidIn.Location = new System.Drawing.Point(6, 19);
            this.chkAllPaidIn.Name = "chkAllPaidIn";
            this.chkAllPaidIn.Size = new System.Drawing.Size(84, 17);
            this.chkAllPaidIn.TabIndex = 27;
            this.chkAllPaidIn.Text = "All Paid In";
            this.chkAllPaidIn.UseVisualStyleBackColor = true;
            this.chkAllPaidIn.CheckedChanged += new System.EventHandler(this.chkAllPaidIn_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lstPaidOut);
            this.groupBox4.Controls.Add(this.chkAllPaidOut);
            this.groupBox4.Enabled = false;
            this.groupBox4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(258, 124);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(236, 168);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Paid Out";
            // 
            // lstPaidOut
            // 
            this.lstPaidOut.CheckBoxes = true;
            this.lstPaidOut.Location = new System.Drawing.Point(6, 41);
            this.lstPaidOut.Name = "lstPaidOut";
            this.lstPaidOut.Size = new System.Drawing.Size(224, 121);
            this.lstPaidOut.TabIndex = 30;
            this.lstPaidOut.UseCompatibleStateImageBehavior = false;
            this.lstPaidOut.View = System.Windows.Forms.View.List;
            // 
            // chkAllPaidOut
            // 
            this.chkAllPaidOut.AutoSize = true;
            this.chkAllPaidOut.Checked = true;
            this.chkAllPaidOut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAllPaidOut.Enabled = false;
            this.chkAllPaidOut.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllPaidOut.Location = new System.Drawing.Point(6, 19);
            this.chkAllPaidOut.Name = "chkAllPaidOut";
            this.chkAllPaidOut.Size = new System.Drawing.Size(92, 17);
            this.chkAllPaidOut.TabIndex = 28;
            this.chkAllPaidOut.Text = "All Paid Out";
            this.chkAllPaidOut.UseVisualStyleBackColor = true;
            this.chkAllPaidOut.CheckedChanged += new System.EventHandler(this.chkAllPaidOut_CheckedChanged);
            // 
            // cmbCounter
            // 
            this.cmbCounter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCounter.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCounter.FormattingEnabled = true;
            this.cmbCounter.Location = new System.Drawing.Point(108, 46);
            this.cmbCounter.Name = "cmbCounter";
            this.cmbCounter.Size = new System.Drawing.Size(286, 21);
            this.cmbCounter.TabIndex = 22;
            this.cmbCounter.SelectedIndexChanged += new System.EventHandler(this.cmbCounter_SelectedIndexChanged);
            // 
            // lableCommon4
            // 
            this.lableCommon4.AutoSize = true;
            this.lableCommon4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon4.Location = new System.Drawing.Point(12, 49);
            this.lableCommon4.Name = "lableCommon4";
            this.lableCommon4.Size = new System.Drawing.Size(53, 13);
            this.lableCommon4.TabIndex = 23;
            this.lableCommon4.Text = "Counter";
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(108, 19);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(286, 21);
            this.cmbLocation.TabIndex = 15;
            this.cmbLocation.SelectedIndexChanged += new System.EventHandler(this.cmbLocation_SelectedIndexChanged);
            // 
            // lableCommon2
            // 
            this.lableCommon2.AutoSize = true;
            this.lableCommon2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon2.Location = new System.Drawing.Point(12, 77);
            this.lableCommon2.Name = "lableCommon2";
            this.lableCommon2.Size = new System.Drawing.Size(74, 13);
            this.lableCommon2.TabIndex = 18;
            this.lableCommon2.Text = "Date Range";
            // 
            // lableCommon3
            // 
            this.lableCommon3.AutoSize = true;
            this.lableCommon3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon3.Location = new System.Drawing.Point(246, 78);
            this.lableCommon3.Name = "lableCommon3";
            this.lableCommon3.Size = new System.Drawing.Size(13, 13);
            this.lableCommon3.TabIndex = 21;
            this.lableCommon3.Text = "-";
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFrom.Location = new System.Drawing.Point(108, 74);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(130, 21);
            this.dtpDateFrom.TabIndex = 19;
            // 
            // lableCommon1
            // 
            this.lableCommon1.AutoSize = true;
            this.lableCommon1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon1.Location = new System.Drawing.Point(12, 22);
            this.lableCommon1.Name = "lableCommon1";
            this.lableCommon1.Size = new System.Drawing.Size(54, 13);
            this.lableCommon1.TabIndex = 16;
            this.lableCommon1.Text = "Location";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateTo.Location = new System.Drawing.Point(264, 74);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(130, 21);
            this.dtpDateTo.TabIndex = 20;
            // 
            // rdbIsPaidIn
            // 
            this.rdbIsPaidIn.AutoSize = true;
            this.rdbIsPaidIn.Checked = true;
            this.rdbIsPaidIn.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbIsPaidIn.Location = new System.Drawing.Point(110, 102);
            this.rdbIsPaidIn.Name = "rdbIsPaidIn";
            this.rdbIsPaidIn.Size = new System.Drawing.Size(65, 17);
            this.rdbIsPaidIn.TabIndex = 27;
            this.rdbIsPaidIn.TabStop = true;
            this.rdbIsPaidIn.Text = "Paid In";
            this.rdbIsPaidIn.UseVisualStyleBackColor = true;
            // 
            // rdbPaidOut
            // 
            this.rdbPaidOut.AutoSize = true;
            this.rdbPaidOut.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbPaidOut.Location = new System.Drawing.Point(188, 102);
            this.rdbPaidOut.Name = "rdbPaidOut";
            this.rdbPaidOut.Size = new System.Drawing.Size(73, 17);
            this.rdbPaidOut.TabIndex = 28;
            this.rdbPaidOut.TabStop = true;
            this.rdbPaidOut.Text = "Paid Out";
            this.rdbPaidOut.UseVisualStyleBackColor = true;
            // 
            // FrmPaidInPaidOutReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 348);
            this.Name = "FrmPaidInPaidOutReport";
            this.Text = "FrmPaidInPaidOutReport";
            this.grbMargin.ResumeLayout(false);
            this.grbMargin.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private Custom_Controllers.ComboBoxDropDown cmbCounter;
        private Custom_Controllers.LableCommon lableCommon4;
        private System.Windows.Forms.CheckBox chkAllCounter;
        private Custom_Controllers.ComboBoxDropDown cmbLocation;
        private Custom_Controllers.LableCommon lableCommon2;
        private Custom_Controllers.LableCommon lableCommon3;
        private Custom_Controllers.DateTimePickerCommon dtpDateFrom;
        private Custom_Controllers.LableCommon lableCommon1;
        private System.Windows.Forms.CheckBox chkAllLocations;
        private Custom_Controllers.DateTimePickerCommon dtpDateTo;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkAllPaidOut;
        private System.Windows.Forms.CheckBox chkAllPaidIn;
        private System.Windows.Forms.ListView lstPaidOut;
        private System.Windows.Forms.ListView lstPaidIn;
        private System.Windows.Forms.RadioButton rdbIsPaidIn;
        private System.Windows.Forms.RadioButton rdbPaidOut;
    }
}