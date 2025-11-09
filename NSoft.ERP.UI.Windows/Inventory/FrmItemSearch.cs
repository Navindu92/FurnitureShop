using NSoft.ERP.Domain.Inventory;
using NSoft.ERP.Service.Inventory;
using NSoft.ERP.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSoft.ERP.UI.Windows.Inventory
{
    public partial class FrmItemSearch : Form
    {
        public FrmItemSearch()
        {
            InitializeComponent();
        }

        DataTable dtSearchItem;
        DataView dataView = new DataView();
        string query;
        string searchName;
        public string itemCode = string.Empty;
        public bool isItemSelected = false;
        string searchFieldName = "ItemName";
        int searchMode = 0; // 0-Contains 1-Start With 2-Ends With
        public FrmItemSearch(DataTable dtSearchItem, string searchName)
        {
            InitializeComponent();
            this.dtSearchItem = dtSearchItem;
            this.searchName = searchName.Trim();
        }

        private void txtCommon_TextChanged(object sender, EventArgs e)
        {
            try
            {
                switch (searchMode)
                {
                    case 0:
                        query = searchFieldName + " LIKE '%" + txtCommon.Text.Trim().Replace("*", "").Replace("%", "") + "%'";
                        break;
                    case 1:
                        query = searchFieldName + " LIKE '" + txtCommon.Text.Trim().Replace("*", "").Replace("%", "") + "*'";
                        break;
                    case 2:
                        query = searchFieldName + " LIKE '*" + txtCommon.Text.Trim().Replace("*", "").Replace("%", "") + "'";
                        break;
                    default:
                        break;
                }

                dataView.RowFilter = query;
                dgvItemSearch.Refresh();

                RefershNoOfProducts();

            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void RefershNoOfProducts()
        {
            long noOfProducts = Common.ConvertStringToLong(dataView.Count.ToString().Trim());

            if (noOfProducts > 1)
            {
                lblNoOfProducts.Text = noOfProducts + "  Products  Found";
            }
            else if (noOfProducts == 1)
            {
                lblNoOfProducts.Text = noOfProducts + "  Product  Found";
            }
            else if (noOfProducts == 0)
            {
                lblNoOfProducts.Text = "No  Products  Found";
            }
            else
            {
                lblNoOfProducts.Text = string.Empty;
            }
        }
        private void FrmItemSearch_Load(object sender, EventArgs e)
        {
            try
            {
                dgvItemSearch.AutoGenerateColumns = false;
                dataView.Table = dtSearchItem;
                dgvItemSearch.DataSource = dataView;
                query = searchFieldName + " LIKE '%" + searchName.Trim().Replace("*", "").Replace("%", "") + "%'";
                dataView.RowFilter = query;
                dgvItemSearch.Refresh();

                this.ActiveControl = txtCommon;
                txtCommon.Focus();
                txtCommon.Text = searchName;
                txtCommon.Select(searchName.Length, 1);

                rdbSFItemName.Checked = true;
                rdbSMContains.Checked = true;

                RefershNoOfProducts();
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
                if (dgvItemSearch.Rows.Count > 0)
                {

                    int currentrow = dgvItemSearch.CurrentCell.RowIndex;

                    if (e.KeyCode == Keys.Enter)
                    {
                        if (currentrow < dgvItemSearch.Rows.Count && currentrow >= 0)
                        {
                            DataGridViewRow selectedRow = dgvItemSearch.Rows[currentrow];
                            itemCode = dgvItemSearch.Rows[currentrow].Cells["ItemCodeSearch"].Value.ToString();
                            isItemSelected = true;
                            this.Dispose();
                        }
                    }
                    else if (e.KeyCode == Keys.Down)
                    {
                        currentrow++;
                        if (currentrow < dgvItemSearch.Rows.Count && currentrow >= 0)
                        {
                            dgvItemSearch.CurrentCell = dgvItemSearch.Rows[currentrow].Cells[0];
                        }
                    }
                    else if (e.KeyCode == Keys.Up)
                    {
                        currentrow--;
                        if (currentrow < dgvItemSearch.Rows.Count && currentrow >= 0)
                        {
                            dgvItemSearch.CurrentCell = dgvItemSearch.Rows[currentrow].Cells[0];
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

        private void FrmItemSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
                else if (e.KeyCode == Keys.ControlKey)
                {
                    if (rdbSFItemCode.Checked)
                    {
                        rdbSFItemName.Checked = true;
                    }
                    else if (rdbSFItemName.Checked)
                    {
                        rdbSFSellingPrice.Checked = true;

                    }
                    else if (rdbSFSellingPrice.Checked)
                    {
                        rdbSFItemCode.Checked = true;

                    }

                    txtCommon.Focus();
                }
                else if (e.KeyCode == Keys.ShiftKey)
                {
                    if (rdbSMContains.Checked)
                    {
                        rdbSMStartWith.Checked = true;
                    }
                    else if (rdbSMStartWith.Checked)
                    {
                        rdbSMEnd.Checked = true;
                    }
                    else if (rdbSMEnd.Checked)
                    {
                        rdbSMContains.Checked = true;
                    }
                    txtCommon.Focus();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void rdbSFItemName_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbSFItemName.Checked)
                {
                    searchFieldName = "ItemName";
                    RefreshText();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void rdbSFItemCode_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbSFItemCode.Checked)
                {
                    searchFieldName = "ItemCode";
                    RefreshText();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void rdbSFSellingPrice_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbSFSellingPrice.Checked)
                {
                    searchFieldName = "SellingPrice";
                    RefreshText();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void rdbSMContains_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbSMContains.Checked)
                {
                    searchMode = 0;
                    RefreshText();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void rdbSMStartWith_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbSMStartWith.Checked)
                {
                    searchMode = 1;
                    RefreshText();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void rdbSMEnd_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbSMEnd.Checked)
                {
                    searchMode = 2;
                    RefreshText();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void RefreshText()
        {
            txtCommon_TextChanged(this, null);
            txtCommon.Focus();
        }

        private void dgvItemSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (dgvItemSearch.Rows.Count > 0)
                {
                    int currentrow = dgvItemSearch.CurrentCell.RowIndex;
                    if (currentrow < dgvItemSearch.Rows.Count && currentrow >= 0)
                    {
                        DataGridViewRow selectedRow = dgvItemSearch.Rows[currentrow];
                        itemCode = dgvItemSearch.Rows[currentrow].Cells["ItemCodeSearch"].Value.ToString();

                        ItemService ItemService = new ItemService();
                        RetreveImage(ItemService.GetActiveItemByCode(itemCode).ItemImage);
                    }
                }

                if (e.KeyCode == Keys.Enter)
                {
                    txtCommon_KeyDown(sender, e);
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }

        private void dgvItemSearch_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                KeyEventArgs enterKey = new KeyEventArgs(Keys.Enter);
                txtCommon_KeyDown(sender, enterKey);

            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void RetreveImage(byte[] pic)
        {
            try
            {
                if (pic.Length > 0)
                {
                    Stream stream = new MemoryStream(pic);
                    Image returnImage = Image.FromStream(stream);
                    pbItem.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbItem.Image = returnImage;
                    pbItem.Visible = true;
                }
                else
                {
                    pbItem.Image = null;
                    pbItem.Visible = false;
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }

        private void dgvItemSearch_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvItemSearch.SelectedRows.Count > 0)
                {
                    int currentrow = dgvItemSearch.SelectedCells[0].RowIndex;

                    DataGridViewRow selectedRow = dgvItemSearch.Rows[currentrow];
                    itemCode = dgvItemSearch.Rows[currentrow].Cells["ItemCodeSearch"].Value.ToString();

                    Item item = new Item();
                    ItemService ItemService = new ItemService();
                    item = ItemService.GetActiveItemByCode(itemCode);
                    if (item!=null)
                    {
                        RetreveImage(item.ItemImage);
                        lblItemCode.Text = item.ItemCode.Trim();
                        lblItemName.Text = item.ItemName.Trim();
                        lblSellingPrice.Text = Common.ConvertToStringCurrancy(item.SellingPrice.ToString());
                    }
                 

                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }

        private void pbItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmShowImage frmShowImage = new FrmShowImage(pbItem.Image);
                frmShowImage.ShowDialog();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
    }
}
