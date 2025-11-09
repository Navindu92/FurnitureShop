using NSoft.ERP.Domain.CRM;
using NSoft.ERP.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSoft.ERP.UI.Windows.Inventory
{
    public partial class FrmPOSMore : Form
    {
        public FrmPOSMore()
        {
            InitializeComponent();
        }

        public LoyaltyCustomer loyaltyCustomer = null;

        private void FrmPOSMore_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
                if (e.KeyCode == Keys.F1)
                {
                    this.Hide();
                    FrmPOSLoyaltyCustomer frmPOSLoyaltyCustomer = new FrmPOSLoyaltyCustomer();
                    frmPOSLoyaltyCustomer.ShowDialog();
                    loyaltyCustomer = frmPOSLoyaltyCustomer.loyaltyCustomer;
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void btnF1_Click(object sender, EventArgs e)
        {
            btnF1.PerformClick();
        }
    }
}
