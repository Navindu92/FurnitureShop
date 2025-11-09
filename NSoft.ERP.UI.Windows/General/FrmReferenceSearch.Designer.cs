namespace NSoft.ERP.UI.Windows.General
{
    partial class FrmReferenceSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReferenceSearch));
            this.groupBoxCommon3 = new NSoft.ERP.UI.Windows.Custom_Controllers.GroupBoxCommon();
            this.txtSearch = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCommon();
            this.groupBoxCommon1 = new NSoft.ERP.UI.Windows.Custom_Controllers.GroupBoxCommon();
            this.lblSearchField = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.groupBoxCommon2 = new NSoft.ERP.UI.Windows.Custom_Controllers.GroupBoxCommon();
            this.rdbSMEnd = new System.Windows.Forms.RadioButton();
            this.rdbSMStartWith = new System.Windows.Forms.RadioButton();
            this.rdbSMContains = new System.Windows.Forms.RadioButton();
            this.groupBoxCommon4 = new NSoft.ERP.UI.Windows.Custom_Controllers.GroupBoxCommon();
            this.dgvSearchDetails = new System.Windows.Forms.DataGridView();
            this.groupBoxCommon3.SuspendLayout();
            this.groupBoxCommon1.SuspendLayout();
            this.groupBoxCommon2.SuspendLayout();
            this.groupBoxCommon4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxCommon3
            // 
            this.groupBoxCommon3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCommon3.Controls.Add(this.txtSearch);
            this.groupBoxCommon3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCommon3.Location = new System.Drawing.Point(427, -4);
            this.groupBoxCommon3.Name = "groupBoxCommon3";
            this.groupBoxCommon3.Size = new System.Drawing.Size(223, 37);
            this.groupBoxCommon3.TabIndex = 2;
            this.groupBoxCommon3.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(3, 11);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(216, 21);
            this.txtSearch.TabIndex = 8;
            // 
            // groupBoxCommon1
            // 
            this.groupBoxCommon1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCommon1.Controls.Add(this.lblSearchField);
            this.groupBoxCommon1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCommon1.Location = new System.Drawing.Point(2, -4);
            this.groupBoxCommon1.Name = "groupBoxCommon1";
            this.groupBoxCommon1.Size = new System.Drawing.Size(177, 37);
            this.groupBoxCommon1.TabIndex = 0;
            this.groupBoxCommon1.TabStop = false;
            // 
            // lblSearchField
            // 
            this.lblSearchField.AutoSize = true;
            this.lblSearchField.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchField.Location = new System.Drawing.Point(23, 15);
            this.lblSearchField.Name = "lblSearchField";
            this.lblSearchField.Size = new System.Drawing.Size(100, 13);
            this.lblSearchField.TabIndex = 1;
            this.lblSearchField.Text = "lblSearchField";
            // 
            // groupBoxCommon2
            // 
            this.groupBoxCommon2.Controls.Add(this.rdbSMEnd);
            this.groupBoxCommon2.Controls.Add(this.rdbSMStartWith);
            this.groupBoxCommon2.Controls.Add(this.rdbSMContains);
            this.groupBoxCommon2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCommon2.Location = new System.Drawing.Point(181, -4);
            this.groupBoxCommon2.Name = "groupBoxCommon2";
            this.groupBoxCommon2.Size = new System.Drawing.Size(245, 37);
            this.groupBoxCommon2.TabIndex = 7;
            this.groupBoxCommon2.TabStop = false;
            // 
            // rdbSMEnd
            // 
            this.rdbSMEnd.AutoSize = true;
            this.rdbSMEnd.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbSMEnd.Location = new System.Drawing.Point(163, 14);
            this.rdbSMEnd.Name = "rdbSMEnd";
            this.rdbSMEnd.Size = new System.Drawing.Size(81, 17);
            this.rdbSMEnd.TabIndex = 5;
            this.rdbSMEnd.Text = "Ends With";
            this.rdbSMEnd.UseVisualStyleBackColor = true;
            // 
            // rdbSMStartWith
            // 
            this.rdbSMStartWith.AutoSize = true;
            this.rdbSMStartWith.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbSMStartWith.Location = new System.Drawing.Point(83, 14);
            this.rdbSMStartWith.Name = "rdbSMStartWith";
            this.rdbSMStartWith.Size = new System.Drawing.Size(82, 17);
            this.rdbSMStartWith.TabIndex = 4;
            this.rdbSMStartWith.Text = "Start With";
            this.rdbSMStartWith.UseVisualStyleBackColor = true;
            // 
            // rdbSMContains
            // 
            this.rdbSMContains.AutoSize = true;
            this.rdbSMContains.Checked = true;
            this.rdbSMContains.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbSMContains.Location = new System.Drawing.Point(7, 14);
            this.rdbSMContains.Name = "rdbSMContains";
            this.rdbSMContains.Size = new System.Drawing.Size(75, 17);
            this.rdbSMContains.TabIndex = 3;
            this.rdbSMContains.TabStop = true;
            this.rdbSMContains.Text = "Contains";
            this.rdbSMContains.UseVisualStyleBackColor = true;
            // 
            // groupBoxCommon4
            // 
            this.groupBoxCommon4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCommon4.Controls.Add(this.dgvSearchDetails);
            this.groupBoxCommon4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCommon4.Location = new System.Drawing.Point(2, 27);
            this.groupBoxCommon4.Name = "groupBoxCommon4";
            this.groupBoxCommon4.Size = new System.Drawing.Size(649, 395);
            this.groupBoxCommon4.TabIndex = 2;
            this.groupBoxCommon4.TabStop = false;
            // 
            // dgvSearchDetails
            // 
            this.dgvSearchDetails.AllowUserToAddRows = false;
            this.dgvSearchDetails.AllowUserToDeleteRows = false;
            this.dgvSearchDetails.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            this.dgvSearchDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearchDetails.Location = new System.Drawing.Point(4, 11);
            this.dgvSearchDetails.Name = "dgvSearchDetails";
            this.dgvSearchDetails.ReadOnly = true;
            this.dgvSearchDetails.RowHeadersVisible = false;
            this.dgvSearchDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSearchDetails.Size = new System.Drawing.Size(641, 378);
            this.dgvSearchDetails.TabIndex = 8;
            // 
            // FrmReferenceSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 425);
            this.Controls.Add(this.groupBoxCommon3);
            this.Controls.Add(this.groupBoxCommon1);
            this.Controls.Add(this.groupBoxCommon2);
            this.Controls.Add(this.groupBoxCommon4);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmReferenceSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmReferenceSearch";
            this.Load += new System.EventHandler(this.FrmReferenceSearch_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmReferenceSearch_KeyDown);
            this.groupBoxCommon3.ResumeLayout(false);
            this.groupBoxCommon3.PerformLayout();
            this.groupBoxCommon1.ResumeLayout(false);
            this.groupBoxCommon1.PerformLayout();
            this.groupBoxCommon2.ResumeLayout(false);
            this.groupBoxCommon2.PerformLayout();
            this.groupBoxCommon4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Custom_Controllers.GroupBoxCommon groupBoxCommon1;
        private Custom_Controllers.LableCommon lblSearchField;
        private Custom_Controllers.GroupBoxCommon groupBoxCommon2;
        private System.Windows.Forms.RadioButton rdbSMEnd;
        private System.Windows.Forms.RadioButton rdbSMStartWith;
        private System.Windows.Forms.RadioButton rdbSMContains;
        private Custom_Controllers.GroupBoxCommon groupBoxCommon3;
        private Custom_Controllers.TextBoxCommon txtSearch;
        private System.Windows.Forms.DataGridView dgvSearchDetails;
        private Custom_Controllers.GroupBoxCommon groupBoxCommon4;
    }
}