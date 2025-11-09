using NSoft.ERP.Domain.General;
using NSoft.ERP.Domain.Inventory;
using NSoft.ERP.Reports.Forms.General;
using NSoft.ERP.Reports.Reports.Inventory.Transaction;
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
using static NSoft.ERP.Utility.Validater;

namespace NSoft.ERP.Reports.Forms.Inventory
{
    public partial class FrmSalesSummary : FrmBaseReport
    {
        public FrmSalesSummary()
        {
            InitializeComponent();
        }

        FormInfo formInfo;
        UserPrivileges userPrivileges;

        UserService userService = new UserService();

        public override void FormLoad()
        {
            try
            {
                formInfo = new FormInfo();
                formInfo = FormInfoService.GetFormInfoByName(this.Name);
                if (formInfo != null)
                {
                    this.Text = formInfo.FormText.Trim();
                }
                userPrivileges = new UserPrivileges();
                userPrivileges = userService.GetUserPrivilegesByUserIDAndForm(Common.LoggedUserID, formInfo);

                LogWritter.WriteEventLog(this.Name, this.Text, LogWritter.EventType.Access);

                base.FormLoad();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        public override void Initialize()
        {
            try
            {
                LocationService locationService = new LocationService();
                cmbLocation.DataSource = locationService.GetAllActiveLocations();
                cmbLocation.DisplayMember = "LocationName";
                cmbLocation.ValueMember = "LocationID";
                cmbLocation.SelectedIndex = -1;
                cmbLocation.Refresh();

                ItemService itemService = new ItemService();
                Common.SetAutoCompleteWithoutAppend(txtItemCodeFrom, itemService.GetAllActiveCountableItemCodes());
                Common.SetAutoCompleteWithoutAppend(txtItemCodeTo, itemService.GetAllActiveCountableItemCodes());
                Common.SetAutoCompleteWithoutAppend(txtItemNameFrom, itemService.GetAllActiveCountableItemNames());
                Common.SetAutoCompleteWithoutAppend(txtItemNameTo, itemService.GetAllActiveCountableItemNames());

                base.Initialize();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        public override void View()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                int locationId = 0;

                DateTime dateFrom = dtpDateFrom.Value.Date;
                DateTime dateTo = dtpDateTo.Value.Date;

                string codeFrom = txtItemCodeFrom.Text.Trim();
                string codeTo = txtItemCodeTo.Text.Trim();


                if (txtItemCodeFrom.Text == string.Empty && txtItemCodeTo.Text == string.Empty)
                {
                    codeFrom = "0";
                    codeTo = "z";
                }

                if (dateFrom > dateTo)
                {
                    SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Error, this.Text, "Invalid Date Range.");
                    return;
                }

                if (!ValidateComboBox())
                {
                    return;
                }

                if (cmbLocation.SelectedValue != null)
                {
                    locationId = Common.ConvertStringToInt(cmbLocation.SelectedValue.ToString());
                }

                SalesService salesService = new SalesService();

                FrmReportViewer frmReportViewer = new FrmReportViewer();
                RptItemWiseSalesSummary rptItemWiseSalesSummary = new RptItemWiseSalesSummary();
                rptItemWiseSalesSummary.SummaryInfo.ReportTitle = this.Text;
                DataSet dtSalesSummary = salesService.GetSalesSummary(locationId, dateFrom, dateTo, codeFrom, codeTo);
                rptItemWiseSalesSummary.SetDataSource(dtSalesSummary.Tables[0]);

                decimal subTotalDiscountAmount = 0, netAmount = 0;
                if (dtSalesSummary.Tables[1] != null && dtSalesSummary.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow row in dtSalesSummary.Tables[1].Rows)
                    {
                        subTotalDiscountAmount = Common.ConvertStringToDecimal(row["SubTotalDiscountAmount"].ToString());
                        netAmount = Common.ConvertStringToDecimal(row["NetAmount"].ToString());
                    }
                }

                rptItemWiseSalesSummary.DataDefinition.FormulaFields["SubTotalDiscountAmount"].Text = "'" + subTotalDiscountAmount + "'";
                rptItemWiseSalesSummary.DataDefinition.FormulaFields["NetAmount"].Text = "'" + netAmount + "'";

                rptItemWiseSalesSummary.DataDefinition.FormulaFields["Location"].Text = "'" + cmbLocation.Text.Trim() + "'";
                rptItemWiseSalesSummary.DataDefinition.FormulaFields["DateFrom"].Text = "'" + dtpDateFrom.Text + "'";
                rptItemWiseSalesSummary.DataDefinition.FormulaFields["DateTo"].Text = "'" + dtpDateTo.Text + "'";
                rptItemWiseSalesSummary.DataDefinition.FormulaFields["LoginUsername"].Text = "'" + Common.LoggedUserName + "'";
                rptItemWiseSalesSummary.DataDefinition.FormulaFields["LoginLocation"].Text = "'" + Common.LoggedLocation + "'";
                rptItemWiseSalesSummary.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.CompanyName + "'";
                rptItemWiseSalesSummary.DataDefinition.FormulaFields["Address"].Text = "'" + Common.Address + "'";
                frmReportViewer.crystalReportViewer.ReportSource = rptItemWiseSalesSummary;
                frmReportViewer.Show();


                base.View();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void txtItemCodeFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtItemNameFrom.Focus();
            }
        }

        private void txtItemNameFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtItemCodeTo.Focus();
            }
        }

        private void txtItemCodeTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtItemNameTo.Focus();
            }
        }

        private void txtItemNameTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnView.Focus();
            }
        }

        private void LoadItem(bool isCode, bool isFrom, string str)
        {
            try
            {
                ItemService itemService = new ItemService();
                Item item = new Item();

                if (string.IsNullOrEmpty(str))
                {
                    return;
                }

                if (isCode)
                {
                    item = itemService.GetActiveCountableItemByAllCodes(str);
                }
                else
                {
                    item = itemService.GetActiveCountableItemByName(str);
                }

                if (item != null)
                {
                    if (isFrom)
                    {
                        txtItemCodeFrom.Text = item.ItemCode.Trim();
                        txtItemNameFrom.Text = item.ItemName.Trim();
                    }
                    else
                    {
                        txtItemCodeTo.Text = item.ItemCode.Trim();
                        txtItemNameTo.Text = item.ItemName.Trim();
                    }
                }
                else
                {
                    if (isFrom)
                    {
                        txtItemCodeFrom.Text = string.Empty;
                        txtItemNameFrom.Text = string.Empty;
                    }
                    else
                    {
                        txtItemCodeTo.Text = string.Empty;
                        txtItemNameTo.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private bool ValidateComboBox()
        {
            return Validater.ValidateComboBox(errorProvider1, ValidateType.Empty, cmbLocation);
        }

        private void txtItemCodeFrom_Leave(object sender, EventArgs e)
        {
            try
            {
                LoadItem(true, true, txtItemCodeFrom.Text.Trim());
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtItemNameFrom_Leave(object sender, EventArgs e)
        {
            try
            {
                LoadItem(false, true, txtItemNameFrom.Text.Trim());
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtItemCodeTo_Leave(object sender, EventArgs e)
        {
            try
            {
                LoadItem(true, false, txtItemCodeTo.Text.Trim());
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtItemNameTo_Leave(object sender, EventArgs e)
        {
            try
            {
                LoadItem(false, false, txtItemNameTo.Text.Trim());
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
    }
}
