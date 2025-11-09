using NSoft.ERP.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSoft.ERP.UI.Windows.Custom_Controllers
{
    public partial class TextBoxQty : TextBox
    {
        public TextBoxQty()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void TextBoxQty_Leave(object sender, EventArgs e)
        {
            if (this.Text.Equals(string.Empty)) { return; }
            if (this.Text.Equals(".")) { this.Text = string.Empty; return; }
            string formatString = String.Concat("{0:F", Common.QtyDecimalPlaces, "}");
            this.Text = String.Format(formatString, Math.Round(double.Parse(this.Text), Common.QtyDecimalPlaces));
        }

        private void TextBoxQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }

        }
    }
}
