using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NSoft.ERP.Service.General;
using NSoft.ERP.Utility;
using System.Reflection;

namespace NSoft.ERP.UI.Windows.General.SystemConfiguration
{
    public partial class UsrCounter : UserControl
    {
        public UsrCounter()
        {
            InitializeComponent();
        }

        public bool isCounterChange = false;
        private void UsrCounter_Load(object sender, EventArgs e)
        {
           
        }

        private void cmbCounter_SelectedIndexChanged(object sender, EventArgs e)
        {
            isCounterChange = true;
        }
    }
}
