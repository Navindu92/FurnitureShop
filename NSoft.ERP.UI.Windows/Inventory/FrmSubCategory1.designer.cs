namespace NSoft.ERP.UI.Windows.Inventory
{
    partial class FrmSubCategory1
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
            this.txtSubCategory1Code = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxMasterCode();
            this.lblSubCategory1Code = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lblSubCategory1Description = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtSubCategory1Description = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxDescription();
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
            this.grbMargin.Controls.Add(this.lblSubCategory1Description);
            this.grbMargin.Controls.Add(this.lableCommon4);
            this.grbMargin.Controls.Add(this.txtRemark);
            this.grbMargin.Controls.Add(this.chkActive);
            this.grbMargin.Controls.Add(this.txtSubCategory1Description);
            this.grbMargin.Controls.Add(this.lblSubCategory1Code);
            this.grbMargin.Controls.Add(this.txtSubCategory1Code);
            this.grbMargin.Controls.Add(this.btnNew);
            this.grbMargin.Size = new System.Drawing.Size(496, 198);
            this.grbMargin.Controls.SetChildIndex(this.groupBox1, 0);
            this.grbMargin.Controls.SetChildIndex(this.groupBox2, 0);
            this.grbMargin.Controls.SetChildIndex(this.btnNew, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtSubCategory1Code, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblSubCategory1Code, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtSubCategory1Description, 0);
            this.grbMargin.Controls.SetChildIndex(this.chkActive, 0);
            this.grbMargin.Controls.SetChildIndex(this.txtRemark, 0);
            this.grbMargin.Controls.SetChildIndex(this.lableCommon4, 0);
            this.grbMargin.Controls.SetChildIndex(this.lblSubCategory1Description, 0);
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
            // txtSubCategory1Code
            // 
            this.txtSubCategory1Code.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubCategory1Code.Location = new System.Drawing.Point(133, 21);
            this.txtSubCategory1Code.MaxLength = 10;
            this.txtSubCategory1Code.Name = "txtSubCategory1Code";
            this.txtSubCategory1Code.Size = new System.Drawing.Size(131, 21);
            this.txtSubCategory1Code.TabIndex = 6;
            this.txtSubCategory1Code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSubCategory1Code_KeyDown);
            this.txtSubCategory1Code.Leave += new System.EventHandler(this.txtSubCategory1Code_Leave);
            // 
            // lblSubCategory1Code
            // 
            this.lblSubCategory1Code.AutoSize = true;
            this.lblSubCategory1Code.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubCategory1Code.Location = new System.Drawing.Point(9, 24);
            this.lblSubCategory1Code.Name = "lblSubCategory1Code";
            this.lblSubCategory1Code.Size = new System.Drawing.Size(138, 13);
            this.lblSubCategory1Code.TabIndex = 7;
            this.lblSubCategory1Code.Text = "SubCategory1 Code *";
            // 
            // lblSubCategory1Description
            // 
            this.lblSubCategory1Description.AutoSize = true;
            this.lblSubCategory1Description.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubCategory1Description.Location = new System.Drawing.Point(9, 51);
            this.lblSubCategory1Description.Name = "lblSubCategory1Description";
            this.lblSubCategory1Description.Size = new System.Drawing.Size(141, 13);
            this.lblSubCategory1Description.TabIndex = 8;
            this.lblSubCategory1Description.Text = "SubCategory1  Desc *";
            // 
            // txtSubCategory1Description
            // 
            this.txtSubCategory1Description.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubCategory1Description.Location = new System.Drawing.Point(133, 48);
            this.txtSubCategory1Description.Name = "txtSubCategory1Description";
            this.txtSubCategory1Description.Size = new System.Drawing.Size(353, 21);
            this.txtSubCategory1Description.TabIndex = 9;
            this.txtSubCategory1Description.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSubCategory1Description_KeyDown);
            this.txtSubCategory1Description.Leave += new System.EventHandler(this.txtSubCategory1Description_Leave);
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
            // FrmSubCategory1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 199);
            this.Name = "FrmSubCategory1";
            this.Text = "FrmSubCategory1";
            this.grbMargin.ResumeLayout(false);
            this.grbMargin.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Custom_Controllers.ButtonNew btnNew;
        private Custom_Controllers.TextBoxMasterCode txtSubCategory1Code;
        private Custom_Controllers.LableCommon lblSubCategory1Code;
        private Custom_Controllers.TextBoxDescription txtSubCategory1Description;
        private Custom_Controllers.LableCommon lblSubCategory1Description;
        private System.Windows.Forms.CheckBox chkActive;
        private Custom_Controllers.TextBoxDescription txtRemark;
        private Custom_Controllers.LableCommon lableCommon4;
    }
}