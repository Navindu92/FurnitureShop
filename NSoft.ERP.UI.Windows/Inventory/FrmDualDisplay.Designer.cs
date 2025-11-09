namespace NSoft.ERP.UI.Windows.Inventory
{
    partial class FrmDualDisplay
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDualDisplay));
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblLeft1 = new System.Windows.Forms.Label();
            this.lblRight1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblRight2 = new System.Windows.Forms.Label();
            this.lblLeft2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeader.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(111, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(665, 59);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Next Customer";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblLeft1
            // 
            this.lblLeft1.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeft1.ForeColor = System.Drawing.Color.White;
            this.lblLeft1.Location = new System.Drawing.Point(5, 19);
            this.lblLeft1.Name = "lblLeft1";
            this.lblLeft1.Size = new System.Drawing.Size(418, 35);
            this.lblLeft1.TabIndex = 1;
            this.lblLeft1.Text = "Next Customer";
            this.lblLeft1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRight1
            // 
            this.lblRight1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRight1.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRight1.ForeColor = System.Drawing.Color.White;
            this.lblRight1.Location = new System.Drawing.Point(602, 19);
            this.lblRight1.Name = "lblRight1";
            this.lblRight1.Size = new System.Drawing.Size(300, 35);
            this.lblRight1.TabIndex = 2;
            this.lblRight1.Text = "Next Customer";
            this.lblRight1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            this.timer1.Interval = 750;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblRight2
            // 
            this.lblRight2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRight2.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRight2.ForeColor = System.Drawing.Color.Yellow;
            this.lblRight2.Location = new System.Drawing.Point(600, 55);
            this.lblRight2.Name = "lblRight2";
            this.lblRight2.Size = new System.Drawing.Size(300, 35);
            this.lblRight2.TabIndex = 4;
            this.lblRight2.Text = "Next Customer";
            this.lblRight2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLeft2
            // 
            this.lblLeft2.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeft2.ForeColor = System.Drawing.Color.Yellow;
            this.lblLeft2.Location = new System.Drawing.Point(3, 55);
            this.lblLeft2.Name = "lblLeft2";
            this.lblLeft2.Size = new System.Drawing.Size(418, 35);
            this.lblLeft2.TabIndex = 3;
            this.lblLeft2.Text = "Next Customer";
            this.lblLeft2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Controls.Add(this.axWindowsMediaPlayer1);
            this.panel1.Location = new System.Drawing.Point(12, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(879, 385);
            this.panel1.TabIndex = 5;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(0, 0);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(879, 385);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            // 
            // FrmDualDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(903, 554);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblRight2);
            this.Controls.Add(this.lblLeft2);
            this.Controls.Add(this.lblRight1);
            this.Controls.Add(this.lblLeft1);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDualDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDualDisplay";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDualDisplay_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lblHeader;
        public System.Windows.Forms.Label lblLeft1;
        public System.Windows.Forms.Label lblRight1;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label lblRight2;
        public System.Windows.Forms.Label lblLeft2;
        private System.Windows.Forms.Panel panel1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
    }
}