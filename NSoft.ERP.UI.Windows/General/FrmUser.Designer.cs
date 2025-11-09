namespace NSoft.ERP.UI.Windows.General.UI.Windows
{
    partial class FrmUser
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
            this.txtUsername = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxMasterCode();
            this.lableCommon1 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtPassword = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxPassword();
            this.lableCommon2 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.groupBoxCommon1 = new NSoft.ERP.UI.Windows.Custom_Controllers.GroupBoxCommon();
            this.chkIsDeveloper = new System.Windows.Forms.CheckBox();
            this.cmbUserGroup = new NSoft.ERP.UI.Windows.Custom_Controllers.ComboBoxCommon();
            this.lableCommon5 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.chkAllLocation = new System.Windows.Forms.CheckBox();
            this.chkAllRemove = new System.Windows.Forms.CheckBox();
            this.chkAllSave = new System.Windows.Forms.CheckBox();
            this.chkAllAccess = new System.Windows.Forms.CheckBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.dgvAllowLocations = new NSoft.ERP.UI.Windows.Custom_Controllers.GridViewCommon();
            this.LocationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsAllow = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvUserPrivileges = new NSoft.ERP.UI.Windows.Custom_Controllers.GridViewCommon();
            this.lableCommon4 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtConfirmPassword = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxPassword();
            this.txtFullName = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.lableCommon3 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.FormInfoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsAccess = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsSave = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsRemove = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ModuleType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbMargin.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBoxCommon1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllowLocations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserPrivileges)).BeginInit();
            this.SuspendLayout();
            // 
            // grbMargin
            // 
            this.grbMargin.Controls.Add(this.groupBoxCommon1);
            this.grbMargin.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.grbMargin.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.grbMargin.Size = new System.Drawing.Size(770, 473);
            this.grbMargin.Controls.SetChildIndex(this.groupBox1, 0);
            this.grbMargin.Controls.SetChildIndex(this.groupBox2, 0);
            this.grbMargin.Controls.SetChildIndex(this.groupBoxCommon1, 0);
            // 
            // btnClear
            // 
            this.btnClear.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(7, 419);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(556, 419);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            // 
            // btnDelete
            // 
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            // 
            // btnSave
            // 
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            // 
            // btnClose
            // 
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(153, 18);
            this.txtUsername.MaxLength = 10;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(192, 21);
            this.txtUsername.TabIndex = 5;
            this.txtUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsername_KeyDown);
            this.txtUsername.Leave += new System.EventHandler(this.txtUsername_Leave);
            // 
            // lableCommon1
            // 
            this.lableCommon1.AutoSize = true;
            this.lableCommon1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.lableCommon1.Location = new System.Drawing.Point(6, 21);
            this.lableCommon1.Name = "lableCommon1";
            this.lableCommon1.Size = new System.Drawing.Size(85, 13);
            this.lableCommon1.TabIndex = 6;
            this.lableCommon1.Text = "Username *";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(153, 44);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(192, 21);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // lableCommon2
            // 
            this.lableCommon2.AutoSize = true;
            this.lableCommon2.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.lableCommon2.Location = new System.Drawing.Point(6, 47);
            this.lableCommon2.Name = "lableCommon2";
            this.lableCommon2.Size = new System.Drawing.Size(81, 13);
            this.lableCommon2.TabIndex = 8;
            this.lableCommon2.Text = "Password *";
            // 
            // groupBoxCommon1
            // 
            this.groupBoxCommon1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCommon1.Controls.Add(this.chkIsDeveloper);
            this.groupBoxCommon1.Controls.Add(this.cmbUserGroup);
            this.groupBoxCommon1.Controls.Add(this.lableCommon5);
            this.groupBoxCommon1.Controls.Add(this.chkAllLocation);
            this.groupBoxCommon1.Controls.Add(this.chkAllRemove);
            this.groupBoxCommon1.Controls.Add(this.chkAllSave);
            this.groupBoxCommon1.Controls.Add(this.chkAllAccess);
            this.groupBoxCommon1.Controls.Add(this.chkActive);
            this.groupBoxCommon1.Controls.Add(this.dgvAllowLocations);
            this.groupBoxCommon1.Controls.Add(this.dgvUserPrivileges);
            this.groupBoxCommon1.Controls.Add(this.lableCommon4);
            this.groupBoxCommon1.Controls.Add(this.txtConfirmPassword);
            this.groupBoxCommon1.Controls.Add(this.txtFullName);
            this.groupBoxCommon1.Controls.Add(this.txtUsername);
            this.groupBoxCommon1.Controls.Add(this.lableCommon2);
            this.groupBoxCommon1.Controls.Add(this.lableCommon1);
            this.groupBoxCommon1.Controls.Add(this.lableCommon3);
            this.groupBoxCommon1.Controls.Add(this.txtPassword);
            this.groupBoxCommon1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCommon1.Location = new System.Drawing.Point(7, 9);
            this.groupBoxCommon1.Name = "groupBoxCommon1";
            this.groupBoxCommon1.Size = new System.Drawing.Size(755, 411);
            this.groupBoxCommon1.TabIndex = 9;
            this.groupBoxCommon1.TabStop = false;
            // 
            // chkIsDeveloper
            // 
            this.chkIsDeveloper.AutoSize = true;
            this.chkIsDeveloper.Location = new System.Drawing.Point(367, 46);
            this.chkIsDeveloper.Name = "chkIsDeveloper";
            this.chkIsDeveloper.Size = new System.Drawing.Size(85, 17);
            this.chkIsDeveloper.TabIndex = 23;
            this.chkIsDeveloper.Text = "Developer";
            this.chkIsDeveloper.UseVisualStyleBackColor = true;
            // 
            // cmbUserGroup
            // 
            this.cmbUserGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserGroup.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUserGroup.FormattingEnabled = true;
            this.cmbUserGroup.Location = new System.Drawing.Point(153, 123);
            this.cmbUserGroup.Name = "cmbUserGroup";
            this.cmbUserGroup.Size = new System.Drawing.Size(192, 21);
            this.cmbUserGroup.TabIndex = 22;
            // 
            // lableCommon5
            // 
            this.lableCommon5.AutoSize = true;
            this.lableCommon5.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.lableCommon5.Location = new System.Drawing.Point(7, 127);
            this.lableCommon5.Name = "lableCommon5";
            this.lableCommon5.Size = new System.Drawing.Size(92, 13);
            this.lableCommon5.TabIndex = 21;
            this.lableCommon5.Text = "User Group *";
            // 
            // chkAllLocation
            // 
            this.chkAllLocation.AutoSize = true;
            this.chkAllLocation.Location = new System.Drawing.Point(687, 15);
            this.chkAllLocation.Name = "chkAllLocation";
            this.chkAllLocation.Size = new System.Drawing.Size(15, 14);
            this.chkAllLocation.TabIndex = 20;
            this.chkAllLocation.UseVisualStyleBackColor = true;
            this.chkAllLocation.CheckedChanged += new System.EventHandler(this.chkAllLocation_CheckedChanged);
            // 
            // chkAllRemove
            // 
            this.chkAllRemove.AutoSize = true;
            this.chkAllRemove.Location = new System.Drawing.Point(399, 158);
            this.chkAllRemove.Name = "chkAllRemove";
            this.chkAllRemove.Size = new System.Drawing.Size(15, 14);
            this.chkAllRemove.TabIndex = 19;
            this.chkAllRemove.UseVisualStyleBackColor = true;
            this.chkAllRemove.CheckedChanged += new System.EventHandler(this.chkAllRemove_CheckedChanged);
            // 
            // chkAllSave
            // 
            this.chkAllSave.AutoSize = true;
            this.chkAllSave.Location = new System.Drawing.Point(338, 158);
            this.chkAllSave.Name = "chkAllSave";
            this.chkAllSave.Size = new System.Drawing.Size(15, 14);
            this.chkAllSave.TabIndex = 18;
            this.chkAllSave.UseVisualStyleBackColor = true;
            this.chkAllSave.CheckedChanged += new System.EventHandler(this.chkAllSave_CheckedChanged);
            // 
            // chkAllAccess
            // 
            this.chkAllAccess.AutoSize = true;
            this.chkAllAccess.Location = new System.Drawing.Point(276, 158);
            this.chkAllAccess.Name = "chkAllAccess";
            this.chkAllAccess.Size = new System.Drawing.Size(15, 14);
            this.chkAllAccess.TabIndex = 17;
            this.chkAllAccess.UseVisualStyleBackColor = true;
            this.chkAllAccess.CheckedChanged += new System.EventHandler(this.chkAllAccess_CheckedChanged);
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(367, 20);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(61, 17);
            this.chkActive.TabIndex = 16;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // dgvAllowLocations
            // 
            this.dgvAllowLocations.AllowUserToAddRows = false;
            this.dgvAllowLocations.AllowUserToDeleteRows = false;
            this.dgvAllowLocations.AllowUserToResizeColumns = false;
            this.dgvAllowLocations.AllowUserToResizeRows = false;
            this.dgvAllowLocations.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAllowLocations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAllowLocations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllowLocations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LocationID,
            this.dataGridViewTextBoxColumn2,
            this.IsAllow});
            this.dgvAllowLocations.Location = new System.Drawing.Point(472, 31);
            this.dgvAllowLocations.Name = "dgvAllowLocations";
            this.dgvAllowLocations.Size = new System.Drawing.Size(274, 373);
            this.dgvAllowLocations.TabIndex = 15;
            // 
            // LocationID
            // 
            this.LocationID.DataPropertyName = "LocationID";
            this.LocationID.HeaderText = "LocationID";
            this.LocationID.Name = "LocationID";
            this.LocationID.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "LocationName";
            this.dataGridViewTextBoxColumn2.HeaderText = "Location";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // IsAllow
            // 
            this.IsAllow.DataPropertyName = "IsAllow";
            this.IsAllow.FalseValue = "False";
            this.IsAllow.HeaderText = "Access";
            this.IsAllow.IndeterminateValue = "False";
            this.IsAllow.Name = "IsAllow";
            this.IsAllow.TrueValue = "True";
            this.IsAllow.Width = 62;
            // 
            // dgvUserPrivileges
            // 
            this.dgvUserPrivileges.AllowUserToAddRows = false;
            this.dgvUserPrivileges.AllowUserToDeleteRows = false;
            this.dgvUserPrivileges.AllowUserToResizeColumns = false;
            this.dgvUserPrivileges.AllowUserToResizeRows = false;
            this.dgvUserPrivileges.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUserPrivileges.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUserPrivileges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserPrivileges.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FormInfoID,
            this.FormName,
            this.IsAccess,
            this.IsSave,
            this.IsRemove,
            this.ModuleType});
            this.dgvUserPrivileges.Location = new System.Drawing.Point(10, 173);
            this.dgvUserPrivileges.Name = "dgvUserPrivileges";
            this.dgvUserPrivileges.Size = new System.Drawing.Size(447, 231);
            this.dgvUserPrivileges.TabIndex = 14;
            this.dgvUserPrivileges.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvUserPrivileges_RowPrePaint);
            // 
            // lableCommon4
            // 
            this.lableCommon4.AutoSize = true;
            this.lableCommon4.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.lableCommon4.Location = new System.Drawing.Point(6, 73);
            this.lableCommon4.Name = "lableCommon4";
            this.lableCommon4.Size = new System.Drawing.Size(136, 13);
            this.lableCommon4.TabIndex = 13;
            this.lableCommon4.Text = "Confirm Password *";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPassword.Location = new System.Drawing.Point(153, 70);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(192, 21);
            this.txtConfirmPassword.TabIndex = 12;
            this.txtConfirmPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtConfirmPassword_KeyDown);
            // 
            // txtFullName
            // 
            this.txtFullName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFullName.Location = new System.Drawing.Point(153, 96);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(304, 21);
            this.txtFullName.TabIndex = 11;
            this.txtFullName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFullName_KeyDown);
            // 
            // lableCommon3
            // 
            this.lableCommon3.AutoSize = true;
            this.lableCommon3.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.lableCommon3.Location = new System.Drawing.Point(7, 99);
            this.lableCommon3.Name = "lableCommon3";
            this.lableCommon3.Size = new System.Drawing.Size(84, 13);
            this.lableCommon3.TabIndex = 9;
            this.lableCommon3.Text = "Full Name *";
            // 
            // FormInfoID
            // 
            this.FormInfoID.DataPropertyName = "FormInfoID";
            this.FormInfoID.HeaderText = "FormID";
            this.FormInfoID.Name = "FormInfoID";
            this.FormInfoID.Visible = false;
            // 
            // FormName
            // 
            this.FormName.DataPropertyName = "FormText";
            this.FormName.HeaderText = "Form/Report";
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
            // IsSave
            // 
            this.IsSave.DataPropertyName = "IsSave";
            this.IsSave.FalseValue = "False";
            this.IsSave.HeaderText = "Save";
            this.IsSave.IndeterminateValue = "False";
            this.IsSave.Name = "IsSave";
            this.IsSave.TrueValue = "True";
            this.IsSave.Width = 62;
            // 
            // IsRemove
            // 
            this.IsRemove.DataPropertyName = "IsRemove";
            this.IsRemove.FalseValue = "False";
            this.IsRemove.HeaderText = "Delete";
            this.IsRemove.IndeterminateValue = "False";
            this.IsRemove.Name = "IsRemove";
            this.IsRemove.TrueValue = "True";
            this.IsRemove.Width = 62;
            // 
            // FormType
            // 
            this.ModuleType.DataPropertyName = "FormType";
            this.ModuleType.HeaderText = "FormType";
            this.ModuleType.Name = "FormType";
            this.ModuleType.ReadOnly = true;
            this.ModuleType.Visible = false;
            // 
            // FrmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 474);
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.Name = "FrmUser";
            this.Text = "FrmUser";
            this.grbMargin.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBoxCommon1.ResumeLayout(false);
            this.groupBoxCommon1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllowLocations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserPrivileges)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Custom_Controllers.TextBoxMasterCode txtUsername;
        private Custom_Controllers.LableCommon lableCommon1;
        private Custom_Controllers.LableCommon lableCommon2;
        private Custom_Controllers.TextBoxPassword txtPassword;
        private Custom_Controllers.GroupBoxCommon groupBoxCommon1;
        private Custom_Controllers.LableCommon lableCommon3;
        private Custom_Controllers.TextBoxDescription txtFullName;
        private Custom_Controllers.LableCommon lableCommon4;
        private Custom_Controllers.TextBoxPassword txtConfirmPassword;
        private Custom_Controllers.GridViewCommon dgvUserPrivileges;
        private Custom_Controllers.GridViewCommon dgvAllowLocations;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.CheckBox chkAllRemove;
        private System.Windows.Forms.CheckBox chkAllSave;
        private System.Windows.Forms.CheckBox chkAllAccess;
        private System.Windows.Forms.CheckBox chkAllLocation;
        private Custom_Controllers.LableCommon lableCommon5;
        private Custom_Controllers.ComboBoxCommon cmbUserGroup;
        private System.Windows.Forms.CheckBox chkIsDeveloper;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsAllow;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormInfoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsAccess;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsSave;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsRemove;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModuleType;
    }
}