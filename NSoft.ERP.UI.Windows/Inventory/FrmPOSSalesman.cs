using NSoft.ERP.Service.Inventory;
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
    public partial class FrmPOSSalesman : Form
    {
        public FrmPOSSalesman()
        {
            InitializeComponent();
        }

        public string salesmanCode = string.Empty;
        public bool isItemSelected = false;
        private void FrmPOSSalesman_Load(object sender, EventArgs e)
        {
            try
            {
                dgvSalesmanSearch.AutoGenerateColumns = false;
                SalesmanService salesmanService = new SalesmanService();
                dgvSalesmanSearch.DataSource = salesmanService.GetActiveSalesmanDataTableForSearch();
                dgvSalesmanSearch.Refresh();

                this.ActiveControl = txtCommon;
                txtCommon.Focus();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }

        private void FrmPOSSalesman_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    isItemSelected = false;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtCommon_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (dgvSalesmanSearch.Rows.Count > 0)
                {

                    int currentrow = dgvSalesmanSearch.CurrentCell.RowIndex;

                    if (e.KeyCode == Keys.Enter)
                    {
                        if (currentrow < dgvSalesmanSearch.Rows.Count && currentrow >= 0)
                        {
                            DataGridViewRow selectedRow = dgvSalesmanSearch.Rows[currentrow];
                            salesmanCode = dgvSalesmanSearch.Rows[currentrow].Cells["SalesmanCode"].Value.ToString();
                            isItemSelected = true;
                            this.Dispose();
                        }
                    }
                    else if (e.KeyCode == Keys.Down)
                    {
                        currentrow++;
                        if (currentrow < dgvSalesmanSearch.Rows.Count && currentrow >= 0)
                        {
                            dgvSalesmanSearch.CurrentCell = dgvSalesmanSearch.Rows[currentrow].Cells[0];
                        }
                    }
                    else if (e.KeyCode == Keys.Up)
                    {
                        currentrow--;
                        if (currentrow < dgvSalesmanSearch.Rows.Count && currentrow >= 0)
                        {
                            dgvSalesmanSearch.CurrentCell = dgvSalesmanSearch.Rows[currentrow].Cells[0];
                        }
                    }
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
