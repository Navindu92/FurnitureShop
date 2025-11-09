namespace NSoft.ERP.UI.Windows.Inventory
{
    partial class FrmPOSMore
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
            this.groupBoxCommon1 = new NSoft.ERP.UI.Windows.Custom_Controllers.GroupBoxCommon();
            this.btnF2 = new System.Windows.Forms.Button();
            this.btnF1 = new System.Windows.Forms.Button();
            this.groupBoxCommon1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxCommon1
            // 
            this.groupBoxCommon1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCommon1.Controls.Add(this.btnF2);
            this.groupBoxCommon1.Controls.Add(this.btnF1);
            this.groupBoxCommon1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCommon1.Location = new System.Drawing.Point(5, -3);
            this.groupBoxCommon1.Name = "groupBoxCommon1";
            this.groupBoxCommon1.Size = new System.Drawing.Size(524, 354);
            this.groupBoxCommon1.TabIndex = 0;
            this.groupBoxCommon1.TabStop = false;
            // 
            // btnF2
            // 
            this.btnF2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnF2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnF2.Location = new System.Drawing.Point(146, 20);
            this.btnF2.Name = "btnF2";
            this.btnF2.Size = new System.Drawing.Size(115, 102);
            this.btnF2.TabIndex = 142;
            this.btnF2.Text = "Gift Vouch.\r\n\r\nF2";
            this.btnF2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnF2.UseVisualStyleBackColor = false;
            // 
            // btnF1
            // 
            this.btnF1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnF1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnF1.Location = new System.Drawing.Point(25, 20);
            this.btnF1.Name = "btnF1";
            this.btnF1.Size = new System.Drawing.Size(115, 102);
            this.btnF1.TabIndex = 141;
            this.btnF1.Text = "Loyalty\r\n\r\nF1";
            this.btnF1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnF1.UseVisualStyleBackColor = false;
            this.btnF1.Click += new System.EventHandler(this.btnF1_Click);
            // 
            // FrmPOSMore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(535, 356);
            this.Controls.Add(this.groupBoxCommon1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmPOSMore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPOSMore";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPOSMore_KeyDown);
            this.groupBoxCommon1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Custom_Controllers.GroupBoxCommon groupBoxCommon1;
        private System.Windows.Forms.Button btnF2;
        private System.Windows.Forms.Button btnF1;
    }
}