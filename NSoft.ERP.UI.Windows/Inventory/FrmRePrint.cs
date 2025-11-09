using NSoft.ERP.Domain.General;
using NSoft.ERP.Service.General;
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
    public partial class FrmRePrint : Form
    {
        public FrmRePrint()
        {
            InitializeComponent();
        }

        DataView dataView = new DataView();
        string query;
        Counter counter;
        private void FrmRePrint_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
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

        private void FrmRePrint_Load(object sender, EventArgs e)
        {
            try
            {
                dgvInvoiceSearch.AutoGenerateColumns = false;

                SalesService salesService = new SalesService();
                DataTable dtInvoiceSearch = new DataTable();

                counter = new Counter();
                CounterService counterService = new CounterService();
                counter = counterService.GetCounterByCounterNoAndLocationID(Common.CounterNo, Common.LoggedLocationID);

                if (counter != null)
                {
                    dtInvoiceSearch = salesService.GetInvoiceNoForRePrint(Common.LoggedLocationID, Common.CounterNo, counter.Zno);
                }

                dtInvoiceSearch.TableName = "dtInvoiceSearch";

                dataView.Table = dtInvoiceSearch;
                dgvInvoiceSearch.DataSource = dataView;
                query = "DocumentNo LIKE '%" + txtInvoiceNo.Text.Trim().Replace("*", "").Replace("%", "") + "%'";
                dataView.RowFilter = query;
                dgvInvoiceSearch.Refresh();
                this.ActiveControl = txtInvoiceNo;
                txtInvoiceNo.Focus();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }

        private void txtInvoiceNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                query = "DocumentNo LIKE '%" + txtInvoiceNo.Text.Trim().Replace("*", "").Replace("%", "") + "%'";
                dataView.RowFilter = query;
                dgvInvoiceSearch.Refresh();

            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtInvoiceNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                {
                    dgvInvoiceSearch.Focus();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void dgvInvoiceSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int selectedrowindex = dgvInvoiceSearch.SelectedCells[0].RowIndex;

                    string documentNo = string.Empty;
                    long documentId = 0;

                    DataGridViewRow selectedRow = dgvInvoiceSearch.Rows[selectedrowindex];
                    documentNo = dgvInvoiceSearch.Rows[selectedrowindex].Cells["DocumentNo"].Value.ToString();
                    documentId = Common.ConvertStringToLong(dgvInvoiceSearch.Rows[selectedrowindex].Cells["DocumentID"].Value.ToString().Trim());

                    FormInfo formInfo = new FormInfo();
                    formInfo = FormInfoService.GetFormInfoByDocumentId(documentId);
                    FrmPayment frmPayment = new FrmPayment(documentNo, formInfo, counter);
                    frmPayment.PrintInvoice();

                    this.Dispose();
                }
                else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                {

                }
                else
                {
                    this.ActiveControl = txtInvoiceNo;
                    txtInvoiceNo.Focus();
                    txtInvoiceNo.Select(txtInvoiceNo.Text.Length, 1);
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
