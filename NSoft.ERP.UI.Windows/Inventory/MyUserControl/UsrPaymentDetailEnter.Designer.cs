namespace NSoft.ERP.UI.Windows.Inventory.MyUserControl
{
    partial class UsrPaymentDetailEnter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lableCommon1 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.lblReferenceNo = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtReferenceNo = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCommon();
            this.txtPayAmount = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCurrency();
            this.lableCommon2 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.txtPayType = new NSoft.ERP.UI.Windows.Custom_Controllers.TextBoxCommon();
            this.lblValidation = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.SuspendLayout();
            // 
            // lableCommon1
            // 
            this.lableCommon1.AutoSize = true;
            this.lableCommon1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon1.Location = new System.Drawing.Point(7, 46);
            this.lableCommon1.Name = "lableCommon1";
            this.lableCommon1.Size = new System.Drawing.Size(96, 16);
            this.lableCommon1.TabIndex = 134;
            this.lableCommon1.Text = "Pay Amount";
            // 
            // lblReferenceNo
            // 
            this.lblReferenceNo.AutoSize = true;
            this.lblReferenceNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReferenceNo.Location = new System.Drawing.Point(7, 75);
            this.lblReferenceNo.Name = "lblReferenceNo";
            this.lblReferenceNo.Size = new System.Drawing.Size(104, 16);
            this.lblReferenceNo.TabIndex = 132;
            this.lblReferenceNo.Text = "Reference No";
            // 
            // txtReferenceNo
            // 
            this.txtReferenceNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReferenceNo.Location = new System.Drawing.Point(119, 72);
            this.txtReferenceNo.Name = "txtReferenceNo";
            this.txtReferenceNo.Size = new System.Drawing.Size(323, 23);
            this.txtReferenceNo.TabIndex = 132;
            this.txtReferenceNo.TabStop = false;
            this.txtReferenceNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReferenceNo_KeyDown);
            // 
            // txtPayAmount
            // 
            this.txtPayAmount.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPayAmount.Location = new System.Drawing.Point(119, 43);
            this.txtPayAmount.Name = "txtPayAmount";
            this.txtPayAmount.Size = new System.Drawing.Size(161, 23);
            this.txtPayAmount.TabIndex = 133;
            this.txtPayAmount.TabStop = false;
            this.txtPayAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPayAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPayAmount_KeyDown);
            // 
            // lableCommon2
            // 
            this.lableCommon2.AutoSize = true;
            this.lableCommon2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon2.Location = new System.Drawing.Point(7, 17);
            this.lableCommon2.Name = "lableCommon2";
            this.lableCommon2.Size = new System.Drawing.Size(74, 16);
            this.lableCommon2.TabIndex = 135;
            this.lableCommon2.Text = "Pay Type";
            // 
            // txtPayType
            // 
            this.txtPayType.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtPayType.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPayType.Location = new System.Drawing.Point(119, 14);
            this.txtPayType.Name = "txtPayType";
            this.txtPayType.ReadOnly = true;
            this.txtPayType.Size = new System.Drawing.Size(161, 23);
            this.txtPayType.TabIndex = 136;
            this.txtPayType.TabStop = false;
            this.txtPayType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblValidation
            // 
            this.lblValidation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValidation.ForeColor = System.Drawing.Color.Red;
            this.lblValidation.Location = new System.Drawing.Point(7, 123);
            this.lblValidation.Name = "lblValidation";
            this.lblValidation.Size = new System.Drawing.Size(435, 62);
            this.lblValidation.TabIndex = 137;
            this.lblValidation.Text = "Validation";
            this.lblValidation.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // UsrPaymentDetailEnter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblValidation);
            this.Controls.Add(this.txtPayType);
            this.Controls.Add(this.lableCommon2);
            this.Controls.Add(this.lableCommon1);
            this.Controls.Add(this.lblReferenceNo);
            this.Controls.Add(this.txtReferenceNo);
            this.Controls.Add(this.txtPayAmount);
            this.Name = "UsrPaymentDetailEnter";
            this.Size = new System.Drawing.Size(456, 201);
            this.VisibleChanged += new System.EventHandler(this.UsrPaymentDetailEnter_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Custom_Controllers.LableCommon lblReferenceNo;
        public Custom_Controllers.TextBoxCommon txtReferenceNo;
        public Custom_Controllers.TextBoxCurrency txtPayAmount;
        private Custom_Controllers.LableCommon lableCommon1;
        private Custom_Controllers.LableCommon lableCommon2;
        public Custom_Controllers.TextBoxCommon txtPayType;
        public Custom_Controllers.LableCommon lblValidation;
    }
}
