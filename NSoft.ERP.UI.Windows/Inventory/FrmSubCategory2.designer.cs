namespace NSoft.ERP.UI.Windows.Inventory
{
    partial class FrmSubCategory2
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
            this.btnNew = new NSoft.ERP.UI.Windows.Custom_Controllers.ButtonNew();
            this.txtSubCategory2Code = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxMasterCode();
            this.lblSubCategory2Code = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lblSubCategory2Description = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtSubCategory2Description = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.txtRemark = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
            this.lableCommon4 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.grbMargin.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // grbMargin
            // 
            this.grbMargin.Controls.Add(this.lblSubCategory2Description);
            this.grbMargin.Controls.Add(this.lableCommon4);
            this.grbMargin.Controls.Add(this.txtRemark);
            this.grbMargin.Controls.Add(this.chkActive);
            this.grbMargin.Controls.Add(this.txtSubCategory2Description);
            this.grbMargin.Controls.Add(this.lblSubCategory2Code);
            this.grbMargin.Controls.Add(this.txtSubCategory2Code);
            this.grbMargin.Controls.Add(this.btnNew);
            this.grbMargin.Size = new System.Drawing.Size(496, 198);
            this.grbMargin.Controls.SetChildIndex(this.groupBox1, 0);
            this.grbMargin.Controls.SetChildIndex(this.groupBox2, 0);
            this.grbMargin.Controls.SetChildIndex(this.btnNew, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtSubCategory2Code, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblSubCategory2Code, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtSubCategory2Description, 0);
            this.grbMargin.Controls.SetChildIndex(this.chkActive, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtRemark, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon4, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblSubCategory2Description, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(4, 146);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(288, 146);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(270, 19);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(50, 23);
            this.btnNew.TabIndex = 5;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtSubCategory2Code
            // 
            this.txtSubCategory2Code.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubCategory2Code.Location = new System.Drawing.Point(133, 21);
            this.txtSubCategory2Code.MaxLength = 10;
            this.txtSubCategory2Code.Name = "txtSubCategory2Code";
            this.txtSubCategory2Code.Size = new System.Drawing.Size(131, 21);
            this.txtSubCategory2Code.TabIndex = 6;
            this.txtSubCategory2Code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSubCategory2Code_KeyDown);
            this.txtSubCategory2Code.Leave += new System.EventHandler(this.txtSubCategory2Code_Leave);
            // 
            // lblSubCategory2Code
            // 
            this.lblSubCategory2Code.AutoSize = true;
            this.lblSubCategory2Code.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubCategory2Code.Location = new System.Drawing.Point(9, 24);
            this.lblSubCategory2Code.Name = "lblSubCategory2Code";
            this.lblSubCategory2Code.Size = new System.Drawing.Size(138, 13);
            this.lblSubCategory2Code.TabIndex = 7;
            this.lblSubCategory2Code.Text = "SubCategory2 Code *";
            // 
            // lblSubCategory2Description
            // 
            this.lblSubCategory2Description.AutoSize = true;
            this.lblSubCategory2Description.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubCategory2Description.Location = new System.Drawing.Point(9, 51);
            this.lblSubCategory2Description.Name = "lblSubCategory2Description";
            this.lblSubCategory2Description.Size = new System.Drawing.Size(141, 13);
            this.lblSubCategory2Description.TabIndex = 8;
            this.lblSubCategory2Description.Text = "SubCategory2  Desc *";
            // 
            // txtSubCategory2Description
            // 
            this.txtSubCategory2Description.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubCategory2Description.Location = new System.Drawing.Point(133, 48);
            this.txtSubCategory2Description.Name = "txtSubCategory2Description";
            this.txtSubCategory2Description.Size = new System.Drawing.Size(353, 21);
            this.txtSubCategory2Description.TabIndex = 9;
            this.txtSubCategory2Description.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSubCategory2Description_KeyDown);
            this.txtSubCategory2Description.Leave += new System.EventHandler(this.txtSubCategory2Description_Leave);
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(326, 23);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(61, 17);
            this.chkActive.TabIndex = 22;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Location = new System.Drawing.Point(133, 75);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(353, 65);
            this.txtRemark.TabIndex = 23;
            this.txtRemark.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRemark_KeyDown);
            // 
            // lableCommon4
            // 
            this.lableCommon4.AutoSize = true;
            this.lableCommon4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon4.Location = new System.Drawing.Point(9, 78);
            this.lableCommon4.Name = "lableCommon4";
            this.lableCommon4.Size = new System.Drawing.Size(57, 13);
            this.lableCommon4.TabIndex = 24;
            this.lableCommon4.Text = "Remark";
            // 
            // FrmSubCategory2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 199);
            this.Name = "FrmSubCategory2";
            this.Text = "FrmSubCategory2";
            this.grbMargin.ResumeLayout(false);
            this.grbMargin.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Custom_Controllers.ButtonNew btnNew;
        private Custom_Controllers.TextBoxMasterCode txtSubCategory2Code;
        private Custom_Controllers.LableCommon lblSubCategory2Code;
        private Custom_Controllers.TextBoxDescription txtSubCategory2Description;
        private Custom_Controllers.LableCommon lblSubCategory2Description;
        private System.Windows.Forms.CheckBox chkActive;
        private Custom_Controllers.TextBoxDescription txtRemark;
        private Custom_Controllers.LableCommon lableCommon4;
    }
}