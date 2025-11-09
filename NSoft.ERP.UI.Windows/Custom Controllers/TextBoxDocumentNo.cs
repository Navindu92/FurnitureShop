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
    public partial class TextBoxDocumentNo : TextBox
    {
        public TextBoxDocumentNo()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void TextBoxDocumentNo_Leave(object sender, EventArgs e)
        {
            this.Text = this.Text.ToUpper();
        }

    }
}
