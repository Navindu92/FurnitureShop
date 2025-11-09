using NSoft.ERP.Domain.Inventory;
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
    public partial class FrmVoid : Form
    {
        public FrmVoid()
        {
            InitializeComponent();
        }

        public List<SalesTemp> salesTempList;
        SalesTemp salesTempVoid=new SalesTemp();
        public FrmVoid(List<SalesTemp> salesTempList, SalesTemp salesTemp)
        {
            InitializeComponent();
            this.salesTempList = salesTempList;
            this.salesTempVoid = salesTemp;
        }
        private void FrmVoid_Load(object sender, EventArgs e)
        {
            try
            {
                dgvInvoice.AutoGenerateColumns = false;
                dgvInvoice.DataSource = this.salesTempList;
                dgvInvoice.Refresh();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void FrmVoid_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    btnDel.PerformClick();
                }

                else if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                SalesService salesService = new SalesService();
                SalesTemp salesTemp = new SalesTemp();

                if (dgvInvoice.Rows.Count > 0)
                {
                    if (dgvInvoice["ItemCode", dgvInvoice.CurrentCell.RowIndex].Value.ToString() == string.Empty) { return; }

                   // if (SysMessage.ShowMessage(SysMessage.MessageAction.Delete, SysMessage.MessageType.Question, this.Text, dgvInvoice["ItemCode", dgvInvoice.CurrentCell.RowIndex].Value.ToString() + " - " + dgvInvoice["ItemName", dgvInvoice.CurrentCell.RowIndex].Value.ToString()).Equals(DialogResult.No)) { return; };

                    salesTemp.ItemCode = dgvInvoice["ItemCode", dgvInvoice.CurrentCell.RowIndex].Value.ToString().Trim();
                    salesTemp.SellingPrice = Common.ConvertStringToDecimal(dgvInvoice["SellingPrice", dgvInvoice.CurrentCell.RowIndex].Value.ToString().Trim());
                }

                salesTemp.LocationID = salesTempVoid.LocationID;
                salesTemp.CounterNo = salesTempVoid.CounterNo;
                salesTemp.DocumentNo = salesTempVoid.DocumentNo;

                salesService.GetUpdatedSalesTempListVoid(salesTempList, salesTemp);

                salesTempList = salesService.GetSalesTempByDocumentNoAndLocationAndCounter(salesTempVoid.DocumentNo, salesTempVoid.LocationID, salesTempVoid.CounterNo);

                dgvInvoice.DataSource = salesTempList;
                dgvInvoice.Refresh();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
    }
}
