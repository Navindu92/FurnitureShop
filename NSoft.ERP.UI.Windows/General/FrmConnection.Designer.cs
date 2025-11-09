namespace NSoft.ERP.UI.Windows.General
{
    partial class FrmConnection
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
            this.lableCommon1 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lableCommon2 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lableCommon3 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lableCommon4 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.chkIsPosCounter = new System.Windows.Forms.CheckBox();
            this.grbMargin.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // grbMargin
            // 
            this.grbMargin.Controls.Add(this.chkIsPosCounter);
            this.grbMargin.Controls.Add(this.txtDatabase);
            this.grbMargin.Controls.Add(this.txtServer);
            this.grbMargin.Controls.Add(this.txtUsername);
            this.grbMargin.Controls.Add(this.txtPassword);
            this.grbMargin.Controls.Add(this.lableCommon4);
            this.grbMargin.Controls.Add(this.lableCommon3);
            this.grbMargin.Controls.Add(this.lableCommon2);
            this.grbMargin.Controls.Add(this.lableCommon1);
            this.grbMargin.Size = new System.Drawing.Size(466, 190);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon1, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon2, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon3, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon4, 0);
            this.grbMargin.Controls.SetChildIndex(this.groupBox1, 0);
            this.grbMargin.Controls.SetChildIndex(this.groupBox2, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtPassword, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtUsername, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtServer, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtDatabase, 0);
            this.grbMargin.Controls.SetChildIndex(this.chkIsPosCounter, 0);
            // 
            // btnClear
            // 
            this.btnClear.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(4, 138);
            this.groupBox1.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(258, 138);
            this.groupBox2.TabIndex = 6;
            // 
            // btnDelete
            // 
            this.btnDelete.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 1;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lableCommon1
            // 
            this.lableCommon1.AutoSize = true;
            this.lableCommon1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon1.Location = new System.Drawing.Point(29, 24);
            this.lableCommon1.Name = "lableCommon1";
            this.lableCommon1.Size = new System.Drawing.Size(46, 13);
            this.lableCommon1.TabIndex = 1;
            this.lableCommon1.Text = "Server";
            // 
            // lableCommon2
            // 
            this.lableCommon2.AutoSize = true;
            this.lableCommon2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon2.Location = new System.Drawing.Point(29, 51);
            this.lableCommon2.Name = "lableCommon2";
            this.lableCommon2.Size = new System.Drawing.Size(65, 13);
            this.lableCommon2.TabIndex = 2;
            this.lableCommon2.Text = "Username";
            // 
            // lableCommon3
            // 
            this.lableCommon3.AutoSize = true;
            this.lableCommon3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon3.Location = new System.Drawing.Point(29, 78);
            this.lableCommon3.Name = "lableCommon3";
            this.lableCommon3.Size = new System.Drawing.Size(61, 13);
            this.lableCommon3.TabIndex = 3;
            this.lableCommon3.Text = "Password";
            // 
            // lableCommon4
            // 
            this.lableCommon4.AutoSize = true;
            this.lableCommon4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon4.Location = new System.Drawing.Point(29, 105);
            this.lableCommon4.Name = "lableCommon4";
            this.lableCommon4.Size = new System.Drawing.Size(61, 13);
            this.lableCommon4.TabIndex = 4;
            this.lableCommon4.Text = "Database";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(108, 75);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(185, 21);
            this.txtPassword.TabIndex = 2;
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(108, 48);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(185, 21);
            this.txtUsername.TabIndex = 1;
            // 
            // txtServer
            // 
            this.txtServer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServer.Location = new System.Drawing.Point(108, 21);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(185, 21);
            this.txtServer.TabIndex = 0;
            // 
            // txtDatabase
            // 
            this.txtDatabase.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatabase.Location = new System.Drawing.Point(108, 102);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(185, 21);
            this.txtDatabase.TabIndex = 3;
            // 
            // chkIsPosCounter
            // 
            this.chkIsPosCounter.AutoSize = true;
            this.chkIsPosCounter.Location = new System.Drawing.Point(335, 63);
            this.chkIsPosCounter.Name = "chkIsPosCounter";
            this.chkIsPosCounter.Size = new System.Drawing.Size(96, 17);
            this.chkIsPosCounter.TabIndex = 7;
            this.chkIsPosCounter.Text = "Pos Counter";
            this.chkIsPosCounter.UseVisualStyleBackColor = true;
            // 
            // FrmConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 191);
            this.Name = "FrmConnection";
            this.Text = "Databse Connection";
            this.grbMargin.ResumeLayout(false);
            this.grbMargin.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Custom_Controllers.LableCommon lableCommon3;
        private Custom_Controllers.LableCommon lableCommon2;
        private Custom_Controllers.LableCommon lableCommon1;
        private Custom_Controllers.LableCommon lableCommon4;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.CheckBox chkIsPosCounter;
    }
}