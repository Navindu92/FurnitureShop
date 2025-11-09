namespace NSoft.ERP.UI.Windows.Inventory
{
    partial class FrmCashier
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
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.txtCashierName = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxMasterCode();
            this.lableCommon2 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lableCommon1 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtPassword = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxPassword();
            this.chkAllAccess = new System.Windows.Forms.CheckBox();
            this.dgvCashierPrivileges = new NSoft.ERP.UI.Windows.Custom_Controllers.GridViewCommon();
            this.lableCommon3 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtEncode = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxPassword();
            this.CashierFunctionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsAccess = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MaxValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbMargin.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashierPrivileges)).BeginInit();
            this.SuspendLayout();
            // 
            // grbMargin
            // 
            this.grbMargin.Controls.Add(this.lableCommon3);
            this.grbMargin.Controls.Add(this.txtEncode);
            this.grbMargin.Controls.Add(this.chkAllAccess);
            this.grbMargin.Controls.Add(this.dgvCashierPrivileges);
            this.grbMargin.Controls.Add(this.chkActive);
            this.grbMargin.Controls.Add(this.txtCashierName);
            this.grbMargin.Controls.Add(this.lableCommon2);
            this.grbMargin.Controls.Add(this.lableCommon1);
            this.grbMargin.Controls.Add(this.txtPassword);
            this.grbMargin.Size = new System.Drawing.Size(478, 370);
            this.grbMargin.Controls.SetChildIndex(this.groupBox1, 0);
            this.grbMargin.Controls.SetChildIndex(this.groupBox2, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtPassword, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon1, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon2, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtCashierName, 0);
            this.grbMargin.Controls.SetChildIndex(this.chkActive, 0);
            this.grbMargin.Controls.SetChildIndex(this.dgvCashierPrivileges, 0);
            this.grbMargin.Controls.SetChildIndex(this.chkAllAccess, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtEncode, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon3, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(4, 318);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(277, 318);
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(316, 15);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(61, 17);
            this.chkActive.TabIndex = 21;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // txtCashierName
            // 
            this.txtCashierName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCashierName.Location = new System.Drawing.Point(110, 13);
            this.txtCashierName.MaxLength = 10;
            this.txtCashierName.Name = "txtCashierName";
            this.txtCashierName.Size = new System.Drawing.Size(192, 21);
            this.txtCashierName.TabIndex = 17;
            this.txtCashierName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCashierName_KeyDown);
            this.txtCashierName.Leave += new System.EventHandler(this.txtCashierName_Leave);
            // 
            // lableCommon2
            // 
            this.lableCommon2.AutoSize = true;
            this.lableCommon2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon2.Location = new System.Drawing.Point(5, 43);
            this.lableCommon2.Name = "lableCommon2";
            this.lableCommon2.Size = new System.Drawing.Size(72, 13);
            this.lableCommon2.TabIndex = 20;
            this.lableCommon2.Text = "Password *";
            // 
            // lableCommon1
            // 
            this.lableCommon1.AutoSize = true;
            this.lableCommon1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon1.Location = new System.Drawing.Point(5, 16);
            this.lableCommon1.Name = "lableCommon1";
            this.lableCommon1.Size = new System.Drawing.Size(99, 13);
            this.lableCommon1.TabIndex = 18;
            this.lableCommon1.Text = "Cashier Name *";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(110, 40);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(192, 21);
            this.txtPassword.TabIndex = 19;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // chkAllAccess
            // 
            this.chkAllAccess.AutoSize = true;
            this.chkAllAccess.Location = new System.Drawing.Point(271, 97);
            this.chkAllAccess.Name = "chkAllAccess";
            this.chkAllAccess.Size = new System.Drawing.Size(15, 14);
            this.chkAllAccess.TabIndex = 19;
            this.chkAllAccess.UseVisualStyleBackColor = true;
            this.chkAllAccess.CheckedChanged += new System.EventHandler(this.chkAllAccess_CheckedChanged);
            // 
            // dgvCashierPrivileges
            // 
            this.dgvCashierPrivileges.AllowUserToAddRows = false;
            this.dgvCashierPrivileges.AllowUserToDeleteRows = false;
            this.dgvCashierPrivileges.AllowUserToResizeColumns = false;
            this.dgvCashierPrivileges.AllowUserToResizeRows = false;
            this.dgvCashierPrivileges.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCashierPrivileges.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCashierPrivileges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCashierPrivileges.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CashierFunctionID,
            this.FormName,
            this.IsAccess,
            this.MaxValue});
            this.dgvCashierPrivileges.Location = new System.Drawing.Point(6, 114);
            this.dgvCashierPrivileges.Name = "dgvCashierPrivileges";
            this.dgvCashierPrivileges.Size = new System.Drawing.Size(467, 206);
            this.dgvCashierPrivileges.TabIndex = 18;
            // 
            // lableCommon3
            // 
            this.lableCommon3.AutoSize = true;
            this.lableCommon3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon3.Location = new System.Drawing.Point(5, 71);
            this.lableCommon3.Name = "lableCommon3";
            this.lableCommon3.Size = new System.Drawing.Size(48, 13);
            this.lableCommon3.TabIndex = 23;
            this.lableCommon3.Text = "Encode";
            // 
            // txtEncode
            // 
            this.txtEncode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEncode.Location = new System.Drawing.Point(110, 68);
            this.txtEncode.Name = "txtEncode";
            this.txtEncode.PasswordChar = '*';
            this.txtEncode.Size = new System.Drawing.Size(192, 21);
            this.txtEncode.TabIndex = 22;
            // 
            // CashierFunctionID
            // 
            this.CashierFunctionID.DataPropertyName = "CashierFunctionID";
            this.CashierFunctionID.HeaderText = "CashierFunctionID";
            this.CashierFunctionID.Name = "CashierFunctionID";
            this.CashierFunctionID.Visible = false;
            // 
            // FormName
            // 
            this.FormName.DataPropertyName = "CashierFunctionName";
            this.FormName.HeaderText = "Function";
            this.FormName.Name = "FormName";
            this.FormName.Width = 200;
            // 
            // IsAccess
            // 
            this.IsAccess.DataPropertyName = "IsAccess";
            this.IsAccess.FalseValue = "False";
            this.IsAccess.HeaderText = "Access";
            this.IsAccess.IndeterminateValue = "False";
            this.IsAccess.Name = "IsAccess";
            this.IsAccess.TrueValue = "True";
            this.IsAccess.Width = 62;
            // 
            // MaxValue
            // 
            this.MaxValue.DataPropertyName = "MaxValue";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.MaxValue.DefaultCellStyle = dataGridViewCellStyle2;
            this.MaxValue.HeaderText = "Value";
            this.MaxValue.Name = "MaxValue";
            // 
            // FrmCashier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 368);
            this.Name = "FrmCashier";
            this.Text = "FrmCashier";
            this.grbMargin.ResumeLayout(false);
            this.grbMargin.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashierPrivileges)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkActive;
        private Custom_Controllers.TextBoxMasterCode txtCashierName;
        private Custom_Controllers.LableCommon lableCommon2;
        private Custom_Controllers.LableCommon lableCommon1;
        private Custom_Controllers.TextBoxPassword txtPassword;
        private System.Windows.Forms.CheckBox chkAllAccess;
        private Custom_Controllers.GridViewCommon dgvCashierPrivileges;
        private Custom_Controllers.LableCommon lableCommon3;
        private Custom_Controllers.TextBoxPassword txtEncode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CashierFunctionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsAccess;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxValue;
    }
}