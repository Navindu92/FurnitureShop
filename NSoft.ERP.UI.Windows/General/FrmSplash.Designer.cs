namespace NSoft.ERP.UI.Windows.General
{
    partial class FrmSplash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSplash));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlMargin = new System.Windows.Forms.Panel();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblDayRange = new System.Windows.Forms.Label();
            this.lblAccounts = new System.Windows.Forms.Label();
            this.lblInventory = new System.Windows.Forms.Label();
            this.pbInventory = new System.Windows.Forms.PictureBox();
            this.pbAccounts = new System.Windows.Forms.PictureBox();
            this.pbSqlServer = new System.Windows.Forms.PictureBox();
            this.pbVisualStudio = new System.Windows.Forms.PictureBox();
            this.pbDotNet = new System.Windows.Forms.PictureBox();
            this.lblLicence = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pbCompanyLogo = new System.Windows.Forms.PictureBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblPowerdBy = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.pnlMargin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAccounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSqlServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVisualStudio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDotNet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompanyLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnlMargin
            // 
            this.pnlMargin.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlMargin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMargin.Controls.Add(this.lblCompany);
            this.pnlMargin.Controls.Add(this.lblDayRange);
            this.pnlMargin.Controls.Add(this.lblAccounts);
            this.pnlMargin.Controls.Add(this.lblInventory);
            this.pnlMargin.Controls.Add(this.pbInventory);
            this.pnlMargin.Controls.Add(this.pbAccounts);
            this.pnlMargin.Controls.Add(this.pbSqlServer);
            this.pnlMargin.Controls.Add(this.pbVisualStudio);
            this.pnlMargin.Controls.Add(this.pbDotNet);
            this.pnlMargin.Controls.Add(this.lblLicence);
            this.pnlMargin.Controls.Add(this.lblStatus);
            this.pnlMargin.Controls.Add(this.pbCompanyLogo);
            this.pnlMargin.Controls.Add(this.lblVersion);
            this.pnlMargin.Controls.Add(this.lblHeader);
            this.pnlMargin.Controls.Add(this.lblPowerdBy);
            this.pnlMargin.Location = new System.Drawing.Point(12, 13);
            this.pnlMargin.Name = "pnlMargin";
            this.pnlMargin.Size = new System.Drawing.Size(545, 324);
            this.pnlMargin.TabIndex = 2;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.Location = new System.Drawing.Point(300, 295);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(68, 16);
            this.lblCompany.TabIndex = 27;
            this.lblCompany.Text = "Company";
            // 
            // lblDayRange
            // 
            this.lblDayRange.AutoSize = true;
            this.lblDayRange.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDayRange.ForeColor = System.Drawing.Color.Red;
            this.lblDayRange.Location = new System.Drawing.Point(17, 103);
            this.lblDayRange.Name = "lblDayRange";
            this.lblDayRange.Size = new System.Drawing.Size(70, 13);
            this.lblDayRange.TabIndex = 23;
            this.lblDayRange.Text = "Day Range";
            // 
            // lblAccounts
            // 
            this.lblAccounts.AutoSize = true;
            this.lblAccounts.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccounts.Location = new System.Drawing.Point(168, 130);
            this.lblAccounts.Name = "lblAccounts";
            this.lblAccounts.Size = new System.Drawing.Size(66, 13);
            this.lblAccounts.TabIndex = 22;
            this.lblAccounts.Text = "Accounts";
            // 
            // lblInventory
            // 
            this.lblInventory.AutoSize = true;
            this.lblInventory.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInventory.Location = new System.Drawing.Point(168, 107);
            this.lblInventory.Name = "lblInventory";
            this.lblInventory.Size = new System.Drawing.Size(72, 13);
            this.lblInventory.TabIndex = 21;
            this.lblInventory.Text = "Inventory";
            // 
            // pbInventory
            // 
            this.pbInventory.Location = new System.Drawing.Point(143, 103);
            this.pbInventory.Name = "pbInventory";
            this.pbInventory.Size = new System.Drawing.Size(24, 20);
            this.pbInventory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbInventory.TabIndex = 16;
            this.pbInventory.TabStop = false;
            // 
            // pbAccounts
            // 
            this.pbAccounts.Location = new System.Drawing.Point(143, 126);
            this.pbAccounts.Name = "pbAccounts";
            this.pbAccounts.Size = new System.Drawing.Size(24, 20);
            this.pbAccounts.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAccounts.TabIndex = 15;
            this.pbAccounts.TabStop = false;
            // 
            // pbSqlServer
            // 
            this.pbSqlServer.Image = ((System.Drawing.Image)(resources.GetObject("pbSqlServer.Image")));
            this.pbSqlServer.Location = new System.Drawing.Point(141, 205);
            this.pbSqlServer.Name = "pbSqlServer";
            this.pbSqlServer.Size = new System.Drawing.Size(82, 62);
            this.pbSqlServer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSqlServer.TabIndex = 14;
            this.pbSqlServer.TabStop = false;
            // 
            // pbVisualStudio
            // 
            this.pbVisualStudio.Image = ((System.Drawing.Image)(resources.GetObject("pbVisualStudio.Image")));
            this.pbVisualStudio.Location = new System.Drawing.Point(37, 205);
            this.pbVisualStudio.Name = "pbVisualStudio";
            this.pbVisualStudio.Size = new System.Drawing.Size(85, 62);
            this.pbVisualStudio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbVisualStudio.TabIndex = 13;
            this.pbVisualStudio.TabStop = false;
            // 
            // pbDotNet
            // 
            this.pbDotNet.Image = ((System.Drawing.Image)(resources.GetObject("pbDotNet.Image")));
            this.pbDotNet.Location = new System.Drawing.Point(404, 12);
            this.pbDotNet.Name = "pbDotNet";
            this.pbDotNet.Size = new System.Drawing.Size(124, 85);
            this.pbDotNet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDotNet.TabIndex = 12;
            this.pbDotNet.TabStop = false;
            // 
            // lblLicence
            // 
            this.lblLicence.AutoSize = true;
            this.lblLicence.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicence.ForeColor = System.Drawing.Color.Black;
            this.lblLicence.Location = new System.Drawing.Point(81, 295);
            this.lblLicence.Name = "lblLicence";
            this.lblLicence.Size = new System.Drawing.Size(209, 16);
            this.lblLicence.TabIndex = 5;
            this.lblLicence.Text = "This Product is Liceneced To :";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(17, 75);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(50, 16);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "status";
            // 
            // pbCompanyLogo
            // 
            this.pbCompanyLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbCompanyLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbCompanyLogo.Image")));
            this.pbCompanyLogo.Location = new System.Drawing.Point(392, 155);
            this.pbCompanyLogo.Name = "pbCompanyLogo";
            this.pbCompanyLogo.Size = new System.Drawing.Size(136, 124);
            this.pbCompanyLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCompanyLogo.TabIndex = 3;
            this.pbCompanyLogo.TabStop = false;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(17, 48);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(81, 16);
            this.lblVersion.TabIndex = 2;
            this.lblVersion.Text = "Version 1.0";
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(15, 12);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(200, 29);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "E R P Solution";
            // 
            // lblPowerdBy
            // 
            this.lblPowerdBy.AutoSize = true;
            this.lblPowerdBy.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPowerdBy.Location = new System.Drawing.Point(17, 168);
            this.lblPowerdBy.Name = "lblPowerdBy";
            this.lblPowerdBy.Size = new System.Drawing.Size(85, 16);
            this.lblPowerdBy.TabIndex = 0;
            this.lblPowerdBy.Text = "Powerd By";
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.progressBar.Location = new System.Drawing.Point(12, 341);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(545, 5);
            this.progressBar.TabIndex = 3;
            // 
            // FrmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(569, 351);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.pnlMargin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmSplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSplash";
            this.Load += new System.EventHandler(this.FrmSplash_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSplash_KeyDown);
            this.pnlMargin.ResumeLayout(false);
            this.pnlMargin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAccounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSqlServer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVisualStudio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDotNet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompanyLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnlMargin;
        private System.Windows.Forms.Label lblDayRange;
        private System.Windows.Forms.Label lblAccounts;
        private System.Windows.Forms.Label lblInventory;
        private System.Windows.Forms.PictureBox pbInventory;
        private System.Windows.Forms.PictureBox pbAccounts;
        private System.Windows.Forms.PictureBox pbSqlServer;
        private System.Windows.Forms.PictureBox pbVisualStudio;
        private System.Windows.Forms.PictureBox pbDotNet;
        private System.Windows.Forms.Label lblLicence;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.PictureBox pbCompanyLogo;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblPowerdBy;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblCompany;
    }
}