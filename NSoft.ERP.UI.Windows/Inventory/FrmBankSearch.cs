using NSoft.ERP.Service.General;
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
    public partial class FrmBankSearch : Form
    {
        public FrmBankSearch()
        {
            InitializeComponent();
        }

        public bool isBankSelected = false;
        public long selectedBankId = 0;
        private void FrmBankSearch_Load(object sender, EventArgs e)
        {
            try
            {
                BankService bankService = new BankService();
                dgvBank.AutoGenerateColumns = false;
                dgvBank.DataSource = bankService.GetAllActiveBank();
                dgvBank.Refresh();
                dgvBank.Focus();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void FrmBankSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                int selectedrowindex = dgvBank.SelectedCells[1].RowIndex;

                DataGridViewRow selectedRow = dgvBank.Rows[selectedrowindex];

                if (e.KeyCode == Keys.Escape)
                {
                    isBankSelected = false;
                    this.Close();
                }

                if (e.KeyCode == Keys.Enter)
                {
                    selectedBankId = Common.ConvertStringToLong(dgvBank.Rows[selectedrowindex].Cells["BankID"].Value.ToString());
                    isBankSelected = true;
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }
    }
}
