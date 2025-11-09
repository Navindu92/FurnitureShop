namespace NSoft.ERP.UI.Windows.Inventory
{
    partial class FrmItemSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmItemSearch));
            this.dgvItemSearch = new System.Windows.Forms.DataGridView();
            this.ItemCodeSearch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SellingPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSellingPrice = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lblItemName = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lblItemCode = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lblNoOfProducts = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lableCommon2 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lableCommon1 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.groupBoxCommon1 = new NSoft.ERP.UI.Windows.Custom_Controllers.GroupBoxCommon();
            this.rdbSMEnd = new System.Windows.Forms.RadioButton();
            this.rdbSMStartWith = new System.Windows.Forms.RadioButton();
            this.rdbSMContains = new System.Windows.Forms.RadioButton();
            this.grpSaerchField = new NSoft.ERP.UI.Windows.Custom_Controllers.GroupBoxCommon();
            this.rdbSFSellingPrice = new System.Windows.Forms.RadioButton();
            this.rdbSFItemName = new System.Windows.Forms.RadioButton();
            this.rdbSFItemCode = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pbItem = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCommon = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemSearch)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBoxCommon1.SuspendLayout();
            this.grpSaerchField.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbItem)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvItemSearch
            // 
            this.dgvItemSearch.AllowUserToAddRows = false;
            this.dgvItemSearch.AllowUserToDeleteRows = false;
            this.dgvItemSearch.AllowUserToResizeRows = false;
            this.dgvItemSearch.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItemSearch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItemSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemCodeSearch,
            this.ProductName,
            this.SellingPrice,
            this.Stock});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItemSearch.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvItemSearch.Location = new System.Drawing.Point(6, 65);
            this.dgvItemSearch.Name = "dgvItemSearch";
            this.dgvItemSearch.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItemSearch.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvItemSearch.RowHeadersVisible = false;
            this.dgvItemSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItemSearch.Size = new System.Drawing.Size(708, 324);
            this.dgvItemSearch.TabIndex = 1;
            this.dgvItemSearch.SelectionChanged += new System.EventHandler(this.dgvItemSearch_SelectionChanged);
            this.dgvItemSearch.DoubleClick += new System.EventHandler(this.dgvItemSearch_DoubleClick);
            this.dgvItemSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvItemSearch_KeyDown);
            // 
            // ItemCodeSearch
            // 
            this.ItemCodeSearch.DataPropertyName = "ItemCode";
            this.ItemCodeSearch.HeaderText = "Item Code";
            this.ItemCodeSearch.Name = "ItemCodeSearch";
            this.ItemCodeSearch.ReadOnly = true;
            this.ItemCodeSearch.Width = 120;
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "ItemName";
            this.ProductName.HeaderText = "Item Name";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            this.ProductName.Width = 275;
            // 
            // SellingPrice
            // 
            this.SellingPrice.DataPropertyName = "SellingPrice";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.SellingPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.SellingPrice.HeaderText = "Selling Price";
            this.SellingPrice.Name = "SellingPrice";
            this.SellingPrice.ReadOnly = true;
            this.SellingPrice.Width = 120;
            // 
            // Stock
            // 
            this.Stock.DataPropertyName = "Stock";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Stock.DefaultCellStyle = dataGridViewCellStyle3;
            this.Stock.HeaderText = "Stock";
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            this.Stock.Width = 120;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.lblSellingPrice);
            this.groupBox1.Controls.Add(this.lblItemName);
            this.groupBox1.Controls.Add(this.lblItemCode);
            this.groupBox1.Controls.Add(this.lblNoOfProducts);
            this.groupBox1.Controls.Add(this.lableCommon2);
            this.groupBox1.Controls.Add(this.lableCommon1);
            this.groupBox1.Controls.Add(this.groupBoxCommon1);
            this.groupBox1.Controls.Add(this.dgvItemSearch);
            this.groupBox1.Controls.Add(this.grpSaerchField);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Location = new System.Drawing.Point(5, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(722, 548);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // lblSellingPrice
            // 
            this.lblSellingPrice.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSellingPrice.ForeColor = System.Drawing.Color.Black;
            this.lblSellingPrice.Location = new System.Drawing.Point(569, 436);
            this.lblSellingPrice.Name = "lblSellingPrice";
            this.lblSellingPrice.Size = new System.Drawing.Size(134, 20);
            this.lblSellingPrice.TabIndex = 99;
            this.lblSellingPrice.Text = "SellingPrice";
            this.lblSellingPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblItemName
            // 
            this.lblItemName.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.ForeColor = System.Drawing.Color.Black;
            this.lblItemName.Location = new System.Drawing.Point(184, 436);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(376, 20);
            this.lblItemName.TabIndex = 98;
            this.lblItemName.Text = "ItemName";
            this.lblItemName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblItemCode
            // 
            this.lblItemCode.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemCode.ForeColor = System.Drawing.Color.Black;
            this.lblItemCode.Location = new System.Drawing.Point(184, 404);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(191, 20);
            this.lblItemCode.TabIndex = 97;
            this.lblItemCode.Text = "ItemCode";
            this.lblItemCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNoOfProducts
            // 
            this.lblNoOfProducts.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoOfProducts.ForeColor = System.Drawing.Color.DarkMagenta;
            this.lblNoOfProducts.Location = new System.Drawing.Point(225, 484);
            this.lblNoOfProducts.Name = "lblNoOfProducts";
            this.lblNoOfProducts.Size = new System.Drawing.Size(413, 20);
            this.lblNoOfProducts.TabIndex = 9;
            this.lblNoOfProducts.Text = "No Of Products";
            this.lblNoOfProducts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lableCommon2
            // 
            this.lableCommon2.AutoSize = true;
            this.lableCommon2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon2.ForeColor = System.Drawing.Color.DarkMagenta;
            this.lableCommon2.Location = new System.Drawing.Point(535, 38);
            this.lableCommon2.Name = "lableCommon2";
            this.lableCommon2.Size = new System.Drawing.Size(186, 13);
            this.lableCommon2.TabIndex = 8;
            this.lableCommon2.Text = "Shift - Change Search Mode";
            // 
            // lableCommon1
            // 
            this.lableCommon1.AutoSize = true;
            this.lableCommon1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon1.ForeColor = System.Drawing.Color.DarkMagenta;
            this.lableCommon1.Location = new System.Drawing.Point(535, 18);
            this.lableCommon1.Name = "lableCommon1";
            this.lableCommon1.Size = new System.Drawing.Size(177, 13);
            this.lableCommon1.TabIndex = 7;
            this.lableCommon1.Text = "Ctrl - Change Search Field";
            // 
            // groupBoxCommon1
            // 
            this.groupBoxCommon1.Controls.Add(this.rdbSMEnd);
            this.groupBoxCommon1.Controls.Add(this.rdbSMStartWith);
            this.groupBoxCommon1.Controls.Add(this.rdbSMContains);
            this.groupBoxCommon1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCommon1.Location = new System.Drawing.Point(287, 8);
            this.groupBoxCommon1.Name = "groupBoxCommon1";
            this.groupBoxCommon1.Size = new System.Drawing.Size(245, 48);
            this.groupBoxCommon1.TabIndex = 6;
            this.groupBoxCommon1.TabStop = false;
            this.groupBoxCommon1.Text = "Search Mode";
            // 
            // rdbSMEnd
            // 
            this.rdbSMEnd.AutoSize = true;
            this.rdbSMEnd.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbSMEnd.Location = new System.Drawing.Point(163, 21);
            this.rdbSMEnd.Name = "rdbSMEnd";
            this.rdbSMEnd.Size = new System.Drawing.Size(81, 17);
            this.rdbSMEnd.TabIndex = 5;
            this.rdbSMEnd.TabStop = true;
            this.rdbSMEnd.Text = "Ends With";
            this.rdbSMEnd.UseVisualStyleBackColor = true;
            this.rdbSMEnd.CheckedChanged += new System.EventHandler(this.rdbSMEnd_CheckedChanged);
            // 
            // rdbSMStartWith
            // 
            this.rdbSMStartWith.AutoSize = true;
            this.rdbSMStartWith.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbSMStartWith.Location = new System.Drawing.Point(83, 21);
            this.rdbSMStartWith.Name = "rdbSMStartWith";
            this.rdbSMStartWith.Size = new System.Drawing.Size(82, 17);
            this.rdbSMStartWith.TabIndex = 4;
            this.rdbSMStartWith.TabStop = true;
            this.rdbSMStartWith.Text = "Start With";
            this.rdbSMStartWith.UseVisualStyleBackColor = true;
            this.rdbSMStartWith.CheckedChanged += new System.EventHandler(this.rdbSMStartWith_CheckedChanged);
            // 
            // rdbSMContains
            // 
            this.rdbSMContains.AutoSize = true;
            this.rdbSMContains.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbSMContains.Location = new System.Drawing.Point(7, 21);
            this.rdbSMContains.Name = "rdbSMContains";
            this.rdbSMContains.Size = new System.Drawing.Size(75, 17);
            this.rdbSMContains.TabIndex = 3;
            this.rdbSMContains.TabStop = true;
            this.rdbSMContains.Text = "Contains";
            this.rdbSMContains.UseVisualStyleBackColor = true;
            this.rdbSMContains.CheckedChanged += new System.EventHandler(this.rdbSMContains_CheckedChanged);
            // 
            // grpSaerchField
            // 
            this.grpSaerchField.Controls.Add(this.rdbSFSellingPrice);
            this.grpSaerchField.Controls.Add(this.rdbSFItemName);
            this.grpSaerchField.Controls.Add(this.rdbSFItemCode);
            this.grpSaerchField.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSaerchField.Location = new System.Drawing.Point(4, 8);
            this.grpSaerchField.Name = "grpSaerchField";
            this.grpSaerchField.Size = new System.Drawing.Size(282, 48);
            this.grpSaerchField.TabIndex = 2;
            this.grpSaerchField.TabStop = false;
            this.grpSaerchField.Text = "Search Field";
            // 
            // rdbSFSellingPrice
            // 
            this.rdbSFSellingPrice.AutoSize = true;
            this.rdbSFSellingPrice.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbSFSellingPrice.Location = new System.Drawing.Point(186, 21);
            this.rdbSFSellingPrice.Name = "rdbSFSellingPrice";
            this.rdbSFSellingPrice.Size = new System.Drawing.Size(95, 17);
            this.rdbSFSellingPrice.TabIndex = 5;
            this.rdbSFSellingPrice.TabStop = true;
            this.rdbSFSellingPrice.Text = "Selling Price";
            this.rdbSFSellingPrice.UseVisualStyleBackColor = true;
            this.rdbSFSellingPrice.CheckedChanged += new System.EventHandler(this.rdbSFSellingPrice_CheckedChanged);
            // 
            // rdbSFItemName
            // 
            this.rdbSFItemName.AutoSize = true;
            this.rdbSFItemName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbSFItemName.Location = new System.Drawing.Point(95, 21);
            this.rdbSFItemName.Name = "rdbSFItemName";
            this.rdbSFItemName.Size = new System.Drawing.Size(89, 17);
            this.rdbSFItemName.TabIndex = 4;
            this.rdbSFItemName.TabStop = true;
            this.rdbSFItemName.Text = "Item Name";
            this.rdbSFItemName.UseVisualStyleBackColor = true;
            this.rdbSFItemName.CheckedChanged += new System.EventHandler(this.rdbSFItemName_CheckedChanged);
            // 
            // rdbSFItemCode
            // 
            this.rdbSFItemCode.AutoSize = true;
            this.rdbSFItemCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbSFItemCode.Location = new System.Drawing.Point(7, 21);
            this.rdbSFItemCode.Name = "rdbSFItemCode";
            this.rdbSFItemCode.Size = new System.Drawing.Size(86, 17);
            this.rdbSFItemCode.TabIndex = 3;
            this.rdbSFItemCode.TabStop = true;
            this.rdbSFItemCode.Text = "Item Code";
            this.rdbSFItemCode.UseVisualStyleBackColor = true;
            this.rdbSFItemCode.CheckedChanged += new System.EventHandler(this.rdbSFItemCode_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pbItem);
            this.groupBox3.Location = new System.Drawing.Point(6, 386);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(156, 158);
            this.groupBox3.TabIndex = 96;
            this.groupBox3.TabStop = false;
            // 
            // pbItem
            // 
            this.pbItem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbItem.Location = new System.Drawing.Point(4, 11);
            this.pbItem.Name = "pbItem";
            this.pbItem.Size = new System.Drawing.Size(149, 143);
            this.pbItem.TabIndex = 95;
            this.pbItem.TabStop = false;
            this.pbItem.Click += new System.EventHandler(this.pbItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(5, 427);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(722, 54);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // txtCommon
            // 
            this.txtCommon.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommon.Location = new System.Drawing.Point(170, 507);
            this.txtCommon.Name = "txtCommon";
            this.txtCommon.Size = new System.Drawing.Size(550, 31);
            this.txtCommon.TabIndex = 6;
            this.txtCommon.TabStop = false;
            this.txtCommon.TextChanged += new System.EventHandler(this.txtCommon_TextChanged);
            this.txtCommon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCommon_KeyDown);
            // 
            // FrmItemSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(733, 553);
            this.Controls.Add(this.txtCommon);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmItemSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item Search";
            this.Load += new System.EventHandler(this.FrmItemSearch_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmItemSearch_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemSearch)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxCommon1.ResumeLayout(false);
            this.groupBoxCommon1.PerformLayout();
            this.grpSaerchField.ResumeLayout(false);
            this.grpSaerchField.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvItemSearch;
        private Custom_Controllers.TextBoxDescription txtCommon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCodeSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellingPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Custom_Controllers.GroupBoxCommon grpSaerchField;
        private System.Windows.Forms.RadioButton rdbSFItemCode;
        private System.Windows.Forms.RadioButton rdbSFItemName;
        private System.Windows.Forms.RadioButton rdbSFSellingPrice;
        private Custom_Controllers.GroupBoxCommon groupBoxCommon1;
        private System.Windows.Forms.RadioButton rdbSMEnd;
        private System.Windows.Forms.RadioButton rdbSMStartWith;
        private System.Windows.Forms.RadioButton rdbSMContains;
        private Custom_Controllers.LableCommon lableCommon1;
        private Custom_Controllers.LableCommon lableCommon2;
        private Custom_Controllers.LableCommon lblNoOfProducts;
        private System.Windows.Forms.PictureBox pbItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private Custom_Controllers.LableCommon lblItemCode;
        private Custom_Controllers.LableCommon lblItemName;
        private Custom_Controllers.LableCommon lblSellingPrice;
    }
}