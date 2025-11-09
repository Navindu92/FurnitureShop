namespace NSoft.ERP.UI.Windows.Inventory
{
    partial class FrmRePrint
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtInvoiceNo = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.lblReferenceNo = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.grpInvoiceNo = new System.Windows.Forms.GroupBox();
            this.dgvInvoiceSearch = new System.Windows.Forms.DataGridView();
            this.DocumentNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpInvoiceNo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.lblReferenceNo);
            this.groupBox1.Controls.Add(this.grpInvoiceNo);
            this.groupBox1.Location = new System.Drawing.Point(4, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 394);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtInvoiceNo);
            this.groupBox2.Location = new System.Drawing.Point(6, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(262, 54);
            this.groupBox2.TabIndex = 134;
            this.groupBox2.TabStop = false;
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceNo.Location = new System.Drawing.Point(6, 14);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(250, 31);
            this.txtInvoiceNo.TabIndex = 135;
            this.txtInvoiceNo.TabStop = false;
            this.txtInvoiceNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInvoiceNo.TextChanged += new System.EventHandler(this.txtInvoiceNo_TextChanged);
            this.txtInvoiceNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInvoiceNo_KeyDown);
            // 
            // lblReferenceNo
            // 
            this.lblReferenceNo.AutoSize = true;
            this.lblReferenceNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReferenceNo.Location = new System.Drawing.Point(99, 16);
            this.lblReferenceNo.Name = "lblReferenceNo";
            this.lblReferenceNo.Size = new System.Drawing.Size(85, 16);
            this.lblReferenceNo.TabIndex = 133;
            this.lblReferenceNo.Text = "Invoice No";
            // 
            // grpInvoiceNo
            // 
            this.grpInvoiceNo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInvoiceNo.Controls.Add(this.dgvInvoiceSearch);
            this.grpInvoiceNo.Location = new System.Drawing.Point(6, 83);
            this.grpInvoiceNo.Name = "grpInvoiceNo";
            this.grpInvoiceNo.Size = new System.Drawing.Size(262, 303);
            this.grpInvoiceNo.TabIndex = 8;
            this.grpInvoiceNo.TabStop = false;
            // 
            // dgvInvoiceSearch
            // 
            this.dgvInvoiceSearch.AllowUserToAddRows = false;
            this.dgvInvoiceSearch.AllowUserToDeleteRows = false;
            this.dgvInvoiceSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInvoiceSearch.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoiceSearch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInvoiceSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoiceSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DocumentNo,
            this.DocumentID});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInvoiceSearch.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInvoiceSearch.Location = new System.Drawing.Point(6, 12);
            this.dgvInvoiceSearch.Name = "dgvInvoiceSearch";
            this.dgvInvoiceSearch.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoiceSearch.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInvoiceSearch.RowHeadersVisible = false;
            this.dgvInvoiceSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoiceSearch.Size = new System.Drawing.Size(248, 284);
            this.dgvInvoiceSearch.TabIndex = 1;
            this.dgvInvoiceSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvInvoiceSearch_KeyDown);
            // 
            // DocumentNo
            // 
            this.DocumentNo.DataPropertyName = "DocumentNo";
            this.DocumentNo.HeaderText = "Invoice No";
            this.DocumentNo.Name = "DocumentNo";
            this.DocumentNo.ReadOnly = true;
            this.DocumentNo.Width = 200;
            // 
            // DocumentID
            // 
            this.DocumentID.DataPropertyName = "DocumentID";
            this.DocumentID.HeaderText = "DocumentID";
            this.DocumentID.Name = "DocumentID";
            this.DocumentID.ReadOnly = true;
            this.DocumentID.Visible = false;
            // 
            // FrmRePrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 397);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRePrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Re Print";
            this.Load += new System.EventHandler(this.FrmRePrint_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmRePrint_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpInvoiceNo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Custom_Controllers.LableCommon lblReferenceNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private Custom_Controllers.TextBoxDescription txtInvoiceNo;
        private System.Windows.Forms.GroupBox grpInvoiceNo;
        private System.Windows.Forms.DataGridView dgvInvoiceSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentID;
    }
}