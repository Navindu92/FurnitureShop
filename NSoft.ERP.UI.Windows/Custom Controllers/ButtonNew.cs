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
    public partial class ButtonNew : Button
    {
        public ButtonNew()
        {
            InitializeComponent();
            Size size = new Size(50,23);
            this.Size = size;
         
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            this.Text = "New";
            base.OnPaint(pe);
        }
    }
}
