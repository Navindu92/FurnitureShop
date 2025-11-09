using NSoft.ERP.Service.Inventory;
using NSoft.ERP.UI.Windows.General;
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
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        public string menuCode;

        private void FrmMenu_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    int selectedrowindex = dgvMenu.SelectedCells[1].RowIndex;

                    DataGridViewRow selectedRow = dgvMenu.Rows[selectedrowindex];
                    menuCode = dgvMenu.Rows[selectedrowindex].Cells["MenuCode"].Value.ToString();
                    if (menuCode == "001")
                    {
                        this.Hide();
                        FrmPaidInPaidOut frmPaidInPaidOut = new FrmPaidInPaidOut(1, Common.CounterNo, "PaidInInventory");
                        frmPaidInPaidOut.ShowDialog();
                    }
                    else if (menuCode == "002")
                    {
                        this.Hide();
                        FrmPaidInPaidOut frmPaidInPaidOut = new FrmPaidInPaidOut(2, Common.CounterNo, "PaidOutInventory");
                        frmPaidInPaidOut.ShowDialog();
                    }
                    else if (menuCode == "003")
                    {
                        this.Hide();
                        FrmPOSCounterTransaction frmPOSCounterTransaction = new FrmPOSCounterTransaction(3);
                        frmPOSCounterTransaction.ShowDialog();
                    }
                    else if (menuCode == "004")
                    {
                        this.Hide();
                        FrmPOSCounterTransaction frmPOSCounterTransaction = new FrmPOSCounterTransaction(2);
                        frmPOSCounterTransaction.ShowDialog();
                        Application.Restart();
                    }
                    else if (menuCode == "005")
                    {
                        this.Hide();
                    }

                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            try
            {
                MenuService menuService = new MenuService();
                dgvMenu.AutoGenerateColumns = false;
                dgvMenu.DataSource = menuService.GetAllActiveMenu();
                dgvMenu.Refresh();

            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
    }
}
