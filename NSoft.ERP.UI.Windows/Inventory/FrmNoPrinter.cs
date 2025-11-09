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
    public partial class FrmNoPrinter : Form
    {
        public FrmNoPrinter()
        {
            InitializeComponent();
        }
        public FrmNoPrinter(string printerStaus)
        {
            InitializeComponent();
            lblPrinterStatus.Text = printerStaus;
        }

        private void FrmNoPrinter_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }

        private void FrmNoPrinter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblPrinterStatus_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
