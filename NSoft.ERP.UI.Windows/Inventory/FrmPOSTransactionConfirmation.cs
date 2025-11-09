using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSoft.ERP.UI.Windows.Inventory
{
    public partial class FrmPOSTransactionConfirmation : Form
    {
        public FrmPOSTransactionConfirmation()
        {
            InitializeComponent();
        }

        public bool isConfirm = false;
        private void FrmPOSTransactionConfirmation_Load(object sender, EventArgs e)
        {
            this.ActiveControl = btnYes;
            btnYes.Focus();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            isConfirm = true;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            isConfirm = false;
            this.Close();
        }

        private void FrmPOSTransactionConfirmation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
