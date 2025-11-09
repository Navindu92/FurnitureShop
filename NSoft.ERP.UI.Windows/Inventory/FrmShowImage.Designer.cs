namespace NSoft.ERP.UI.Windows.Inventory
{
    partial class FrmShowImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShowImage));
            this.pbShowImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbShowImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbShowImage
            // 
            this.pbShowImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbShowImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbShowImage.Location = new System.Drawing.Point(5, 6);
            this.pbShowImage.Name = "pbShowImage";
            this.pbShowImage.Size = new System.Drawing.Size(624, 485);
            this.pbShowImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbShowImage.TabIndex = 0;
            this.pbShowImage.TabStop = false;
            // 
            // FrmShowImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 497);
            this.Controls.Add(this.pbShowImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmShowImage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show Image";
            this.Load += new System.EventHandler(this.FrmShowImage_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmShowImage_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbShowImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbShowImage;
    }
}