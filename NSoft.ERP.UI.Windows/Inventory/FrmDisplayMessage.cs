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
    public partial class FrmDisplayMessage : Form
    {
        public FrmDisplayMessage()
        {
            InitializeComponent();
        }
        public FrmDisplayMessage(string messageText,string description)
        {
            InitializeComponent();
            lblMessage.Text = messageText;
            this.Text = messageText;
            lblMessageDescription.Text = description;
        }

        private void FrmDisplayMessage_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }

        private void FrmDisplayMessage_Click(object sender, EventArgs e)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this.Close();
     
        }

        private void FrmDisplayMessage_Load(object sender, EventArgs e)
        {
            timer1.Enabled=true;
        }
    }
}
