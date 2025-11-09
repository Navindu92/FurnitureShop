namespace NSoft.ERP.Reports.Forms.General
{
    partial class FrmTransactionViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTransactionViewer));
            this.grpMargin = new System.Windows.Forms.GroupBox();
            this.rctReceipt = new System.Windows.Forms.RichTextBox();
            this.grpPrint = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvCondition = new System.Windows.Forms.DataGridView();
            this.Field = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConditionFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConditionTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.cmbConditionTo = new NSoft.ERP.Reports.Custom_Controllers.ComboBoxCommonDropDown();
            this.lableCommon3 = new NSoft.ERP.Reports.Custom_Controllers.LableCommon();
            this.cmbConditionFrom = new NSoft.ERP.Reports.Custom_Controllers.ComboBoxCommonDropDown();
            this.lableCommon2 = new NSoft.ERP.Reports.Custom_Controllers.LableCommon();
            this.cmbConditionField = new NSoft.ERP.Reports.Custom_Controllers.ComboBoxDropDown();
            this.lableCommon1 = new NSoft.ERP.Reports.Custom_Controllers.LableCommon();
            this.dtpConditionFrom = new NSoft.ERP.Reports.Custom_Controllers.DateTimePickerCommon();
            this.dtpConditionTo = new NSoft.ERP.Reports.Custom_Controllers.DateTimePickerCommon();
            this.grpMargin.SuspendLayout();
            this.grpPrint.SuspendLayout();
            this.grpDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCondition)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMargin
            // 
            this.grpMargin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMargin.Controls.Add(this.rctReceipt);
            this.grpMargin.Controls.Add(this.grpPrint);
            this.grpMargin.Controls.Add(this.btnLoad);
            this.grpMargin.Controls.Add(this.grpDetails);
            this.grpMargin.Controls.Add(this.groupBox1);
            this.grpMargin.Controls.Add(this.groupBox2);
            this.grpMargin.Location = new System.Drawing.Point(4, -3);
            this.grpMargin.Name = "grpMargin";
            this.grpMargin.Size = new System.Drawing.Size(999, 478);
            this.grpMargin.TabIndex = 0;
            this.grpMargin.TabStop = false;
            // 
            // rctReceipt
            // 
            this.rctReceipt.BackColor = System.Drawing.Color.White;
            this.rctReceipt.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rctReceipt.Location = new System.Drawing.Point(682, 14);
            this.rctReceipt.Name = "rctReceipt";
            this.rctReceipt.ReadOnly = true;
            this.rctReceipt.Size = new System.Drawing.Size(311, 411);
            this.rctReceipt.TabIndex = 14;
            this.rctReceipt.Text = "";
            // 
            // grpPrint
            // 
            this.grpPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpPrint.Controls.Add(this.btnPrint);
            this.grpPrint.Location = new System.Drawing.Point(678, 422);
            this.grpPrint.Name = "grpPrint";
            this.grpPrint.Size = new System.Drawing.Size(104, 49);
            this.grpPrint.TabIndex = 13;
            this.grpPrint.TabStop = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(4, 10);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(95, 36);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "Print ";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Location = new System.Drawing.Point(6, 258);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(666, 35);
            this.btnLoad.TabIndex = 11;
            this.btnLoad.Text = "L o a d";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // grpDetails
            // 
            this.grpDetails.Controls.Add(this.dgvResult);
            this.grpDetails.Location = new System.Drawing.Point(6, 291);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(666, 182);
            this.grpDetails.TabIndex = 12;
            this.grpDetails.TabStop = false;
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.AllowUserToResizeRows = false;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Location = new System.Drawing.Point(11, 11);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.RowHeadersVisible = false;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResult.Size = new System.Drawing.Size(642, 164);
            this.dgvResult.TabIndex = 13;
            this.dgvResult.DoubleClick += new System.EventHandler(this.dgvResult_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvCondition);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.cmbConditionTo);
            this.groupBox1.Controls.Add(this.lableCommon3);
            this.groupBox1.Controls.Add(this.cmbConditionFrom);
            this.groupBox1.Controls.Add(this.lableCommon2);
            this.groupBox1.Controls.Add(this.cmbConditionField);
            this.groupBox1.Controls.Add(this.lableCommon1);
            this.groupBox1.Controls.Add(this.dtpConditionFrom);
            this.groupBox1.Controls.Add(this.dtpConditionTo);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(666, 247);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Condition";
            // 
            // dgvCondition
            // 
            this.dgvCondition.AllowUserToAddRows = false;
            this.dgvCondition.AllowUserToResizeColumns = false;
            this.dgvCondition.AllowUserToResizeRows = false;
            this.dgvCondition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCondition.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Field,
            this.ConditionFrom,
            this.ConditionTo});
            this.dgvCondition.Location = new System.Drawing.Point(11, 71);
            this.dgvCondition.Name = "dgvCondition";
            this.dgvCondition.ReadOnly = true;
            this.dgvCondition.RowHeadersVisible = false;
            this.dgvCondition.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCondition.Size = new System.Drawing.Size(642, 169);
            this.dgvCondition.TabIndex = 12;
            // 
            // Field
            // 
            this.Field.HeaderText = "Field";
            this.Field.Name = "Field";
            this.Field.ReadOnly = true;
            this.Field.Width = 200;
            // 
            // ConditionFrom
            // 
            this.ConditionFrom.HeaderText = "Condition From";
            this.ConditionFrom.Name = "ConditionFrom";
            this.ConditionFrom.ReadOnly = true;
            this.ConditionFrom.Width = 200;
            // 
            // ConditionTo
            // 
            this.ConditionTo.HeaderText = "Condition To";
            this.ConditionTo.Name = "ConditionTo";
            this.ConditionTo.ReadOnly = true;
            this.ConditionTo.Width = 200;
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.BackgroundImage")));
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.Location = new System.Drawing.Point(624, 42);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(29, 23);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Location = new System.Drawing.Point(786, 423);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(204, 48);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(105, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 35);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close  ";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(4, 10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(95, 35);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear  ";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cmbConditionTo
            // 
            this.cmbConditionTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbConditionTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbConditionTo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConditionTo.FormattingEnabled = true;
            this.cmbConditionTo.Location = new System.Drawing.Point(422, 44);
            this.cmbConditionTo.Name = "cmbConditionTo";
            this.cmbConditionTo.Size = new System.Drawing.Size(196, 21);
            this.cmbConditionTo.TabIndex = 6;
            // 
            // lableCommon3
            // 
            this.lableCommon3.AutoSize = true;
            this.lableCommon3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon3.Location = new System.Drawing.Point(329, 47);
            this.lableCommon3.Name = "lableCommon3";
            this.lableCommon3.Size = new System.Drawing.Size(88, 13);
            this.lableCommon3.TabIndex = 5;
            this.lableCommon3.Text = "Condition To";
            // 
            // cmbConditionFrom
            // 
            this.cmbConditionFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbConditionFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbConditionFrom.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConditionFrom.FormattingEnabled = true;
            this.cmbConditionFrom.Location = new System.Drawing.Point(118, 44);
            this.cmbConditionFrom.Name = "cmbConditionFrom";
            this.cmbConditionFrom.Size = new System.Drawing.Size(196, 21);
            this.cmbConditionFrom.TabIndex = 4;
            // 
            // lableCommon2
            // 
            this.lableCommon2.AutoSize = true;
            this.lableCommon2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon2.Location = new System.Drawing.Point(8, 47);
            this.lableCommon2.Name = "lableCommon2";
            this.lableCommon2.Size = new System.Drawing.Size(106, 13);
            this.lableCommon2.TabIndex = 3;
            this.lableCommon2.Text = "Condition From";
            // 
            // cmbConditionField
            // 
            this.cmbConditionField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConditionField.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConditionField.FormattingEnabled = true;
            this.cmbConditionField.Location = new System.Drawing.Point(118, 17);
            this.cmbConditionField.Name = "cmbConditionField";
            this.cmbConditionField.Size = new System.Drawing.Size(196, 21);
            this.cmbConditionField.TabIndex = 0;
            this.cmbConditionField.SelectedIndexChanged += new System.EventHandler(this.cmbConditionField_SelectedIndexChanged);
            // 
            // lableCommon1
            // 
            this.lableCommon1.AutoSize = true;
            this.lableCommon1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon1.Location = new System.Drawing.Point(8, 20);
            this.lableCommon1.Name = "lableCommon1";
            this.lableCommon1.Size = new System.Drawing.Size(104, 13);
            this.lableCommon1.TabIndex = 1;
            this.lableCommon1.Text = "Condition Field";
            // 
            // dtpConditionFrom
            // 
            this.dtpConditionFrom.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpConditionFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpConditionFrom.Location = new System.Drawing.Point(118, 44);
            this.dtpConditionFrom.Name = "dtpConditionFrom";
            this.dtpConditionFrom.Size = new System.Drawing.Size(196, 21);
            this.dtpConditionFrom.TabIndex = 13;
            // 
            // dtpConditionTo
            // 
            this.dtpConditionTo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpConditionTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpConditionTo.Location = new System.Drawing.Point(422, 44);
            this.dtpConditionTo.Name = "dtpConditionTo";
            this.dtpConditionTo.Size = new System.Drawing.Size(196, 21);
            this.dtpConditionTo.TabIndex = 14;
            // 
            // FrmTransactionViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 478);
            this.ControlBox = false;
            this.Controls.Add(this.grpMargin);
            this.Name = "FrmTransactionViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTransactionViewer";
            this.grpMargin.ResumeLayout(false);
            this.grpPrint.ResumeLayout(false);
            this.grpDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCondition)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMargin;
        private Custom_Controllers.LableCommon lableCommon1;
        private Custom_Controllers.ComboBoxDropDown cmbConditionField;
        private System.Windows.Forms.GroupBox groupBox1;
        private Custom_Controllers.LableCommon lableCommon2;
        private Custom_Controllers.ComboBoxCommonDropDown cmbConditionFrom;
        private Custom_Controllers.ComboBoxCommonDropDown cmbConditionTo;
        private Custom_Controllers.LableCommon lableCommon3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvCondition;
        private System.Windows.Forms.DataGridViewTextBoxColumn Field;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConditionFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConditionTo;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.GroupBox grpDetails;
        protected System.Windows.Forms.GroupBox groupBox2;
        protected System.Windows.Forms.Button btnClose;
        protected System.Windows.Forms.Button btnClear;
        private Custom_Controllers.DateTimePickerCommon dtpConditionFrom;
        private Custom_Controllers.DateTimePickerCommon dtpConditionTo;
        protected System.Windows.Forms.GroupBox grpPrint;
        protected System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.RichTextBox rctReceipt;
    }
}