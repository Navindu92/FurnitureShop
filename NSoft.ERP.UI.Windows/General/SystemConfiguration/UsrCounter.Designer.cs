namespace NSoft.ERP.UI.Windows.General.SystemConfiguration
{
    partial class UsrCounter
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
            this.lblCounter = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.cmbCounter = new NSoft.ERP.UI.Windows.Custom_Controllers.ComboBoxCommon();
            this.cmbLocation = new NSoft.ERP.UI.Windows.Custom_Controllers.ComboBoxCommon();
            this.lableCommon1 = new NSoft.ERP.UI.Windows.Custom_Controllers.LableCommon();
            this.SuspendLayout();
            // 
            // lblCounter
            // 
            this.lblCounter.AutoSize = true;
            this.lblCounter.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCounter.Location = new System.Drawing.Point(12, 58);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(53, 13);
            this.lblCounter.TabIndex = 95;
            this.lblCounter.Text = "Counter";
            // 
            // cmbCounter
            // 
            this.cmbCounter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCounter.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCounter.FormattingEnabled = true;
            this.cmbCounter.Location = new System.Drawing.Point(71, 55);
            this.cmbCounter.Name = "cmbCounter";
            this.cmbCounter.Size = new System.Drawing.Size(217, 21);
            this.cmbCounter.TabIndex = 96;
            this.cmbCounter.SelectedIndexChanged += new System.EventHandler(this.cmbCounter_SelectedIndexChanged);
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(71, 16);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(217, 21);
            this.cmbLocation.TabIndex = 98;
            // 
            // lableCommon1
            // 
            this.lableCommon1.AutoSize = true;
            this.lableCommon1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lableCommon1.Location = new System.Drawing.Point(12, 19);
            this.lableCommon1.Name = "lableCommon1";
            this.lableCommon1.Size = new System.Drawing.Size(54, 13);
            this.lableCommon1.TabIndex = 97;
            this.lableCommon1.Text = "Location";
            // 
            // UsrCounter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.lableCommon1);
            this.Controls.Add(this.cmbCounter);
            this.Controls.Add(this.lblCounter);
            this.Name = "UsrCounter";
            this.Size = new System.Drawing.Size(433, 288);
            this.Load += new System.EventHandler(this.UsrCounter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Custom_Controllers.LableCommon lblCounter;
        public Custom_Controllers.ComboBoxCommon cmbCounter;
        public Custom_Controllers.ComboBoxCommon cmbLocation;
        private Custom_Controllers.LableCommon lableCommon1;
    }
}
