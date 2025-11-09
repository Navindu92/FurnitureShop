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
    public partial class ComboBoxCommonDropDown : ComboBox
    {
        public ComboBoxCommonDropDown()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void ComboBoxCommonDropDown_Leave(object sender, EventArgs e)
        {
            this.Text = this.Text.ToUpper();
        }
    }
}
