namespace NSoft.ERP.UI.Windows.Inventory
{
    partial class FrmPOSSalesman
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPOSSalesman));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvSalesmanSearch = new System.Windows.Forms.DataGridView();
            this.SalesmanCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesmanName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCommon = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesmanSearch)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvSalesmanSearch);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(5, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 392);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // dgvSalesmanSearch
            // 
            this.dgvSalesmanSearch.AllowUserToAddRows = false;
            this.dgvSalesmanSearch.AllowUserToDeleteRows = false;
            this.dgvSalesmanSearch.AllowUserToResizeRows = false;
            this.dgvSalesmanSearch.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalesmanSearch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSalesmanSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesmanSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SalesmanCode,
            this.SalesmanName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSalesmanSearch.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSalesmanSearch.Location = new System.Drawing.Point(7, 12);
            this.dgvSalesmanSearch.Name = "dgvSalesmanSearch";
            this.dgvSalesmanSearch.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalesmanSearch.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSalesmanSearch.RowHeadersVisible = false;
            this.dgvSalesmanSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalesmanSearch.Size = new System.Drawing.Size(466, 324);
            this.dgvSalesmanSearch.TabIndex = 136;
            // 
            // SalesmanCode
            // 
            this.SalesmanCode.DataPropertyName = "SalesmanCode";
            this.SalesmanCode.HeaderText = "Salesman Code";
            this.SalesmanCode.Name = "SalesmanCode";
            this.SalesmanCode.ReadOnly = true;
            this.SalesmanCode.Width = 140;
            // 
            // SalesmanName
            // 
            this.SalesmanName.DataPropertyName = "SalesmanName";
            this.SalesmanName.HeaderText = "Salesman Name";
            this.SalesmanName.Name = "SalesmanName";
            this.SalesmanName.ReadOnly = true;
            this.SalesmanName.Width = 275;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCommon);
            this.groupBox2.Location = new System.Drawing.Point(7, 333);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(466, 54);
            this.groupBox2.TabIndex = 135;
            this.groupBox2.TabStop = false;
            // 
            // txtCommon
            // 
            this.txtCommon.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommon.Location = new System.Drawing.Point(6, 14);
            this.txtCommon.Name = "txtCommon";
            this.txtCommon.ReadOnly = true;
            this.txtCommon.Size = new System.Drawing.Size(454, 31);
            this.txtCommon.TabIndex = 135;
            this.txtCommon.TabStop = false;
            this.txtCommon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCommon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCommon_KeyDown);
            // 
            // FrmPOSSalesman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 394);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPOSSalesman";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Salesman";
            this.Load += new System.EventHandler(this.FrmPOSSalesman_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPOSSalesman_KeyDown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesmanSearch)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Custom_Controllers.TextBoxDescription txtCommon;
        private System.Windows.Forms.DataGridView dgvSalesmanSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesmanCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesmanName;
    }
}