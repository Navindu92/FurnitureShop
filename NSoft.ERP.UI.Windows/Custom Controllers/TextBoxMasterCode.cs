using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NSoft.ERP.Utility;
namespace NSoft.ERP.UI.Windows.Custom_Controllers
{
    public partial class TextBoxMasterCode : TextBox
    {
        public TextBoxMasterCode()
        {
            InitializeComponent();
            this.MaxLength = Common.MasterCodeMaxLength;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void TextBoxMasterCode_Leave(object sender, EventArgs e)
        {
            this.Text=this.Text.ToUpper();
        }

    }
}
