using NSoft.ERP.Domain.Inventory;
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
    public partial class FrmPriceList : Form
    {
        public FrmPriceList()
        {
            InitializeComponent();
        }

        List<ItemPrice> priceList = new List<ItemPrice>();
        public decimal selectedPrice = 0;
        public decimal selectedCostPrice = 0;
        public bool isPriceSelected = false;
        public FrmPriceList(List<ItemPrice> priceList)
        {
            InitializeComponent();
            this.priceList = priceList;
        }

        private void FrmPriceList_Load(object sender, EventArgs e)
        {
            try
            {
                dgvItemPrice.AutoGenerateColumns = false;
                dgvItemPrice.DataSource = priceList.ToList();
                dgvItemPrice.Refresh();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void FrmPriceList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                int selectedrowindex = dgvItemPrice.SelectedCells[1].RowIndex;

                DataGridViewRow selectedRow = dgvItemPrice.Rows[selectedrowindex];

                if (e.KeyCode == Keys.Escape)
                {
                    isPriceSelected = false;
                    this.Close();
                }

                if (e.KeyCode == Keys.Enter)
                {
                    selectedPrice = Common.ConvertStringToDecimal(dgvItemPrice.Rows[selectedrowindex].Cells["SellingPrice"].Value.ToString());
                    selectedCostPrice = Common.ConvertStringToDecimal(dgvItemPrice.Rows[selectedrowindex].Cells["CostPrice"].Value.ToString());
                    isPriceSelected = true;
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
