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
    public partial class FrmFastMoving : FrmBaseReport
    {
        public FrmFastMoving()
        {
            InitializeComponent();
        }

        FormInfo formInfo;
        UserPrivileges userPrivileges;

        UserService userService = new UserService();

        #region Override Methods
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
                Common.SetAutoCompleteWithoutAppend(txtItemCodeFrom, itemService.GetAllActiveReferenceCodes());
                Common.SetAutoCompleteWithoutAppend(txtItemCodeTo, itemService.GetAllActiveReferenceCodes());
                Common.SetAutoCompleteWithoutAppend(txtItemNameFrom, itemService.GetAllActiveItemNames());
                Common.SetAutoCompleteWithoutAppend(txtItemNameTo, itemService.GetAllActiveItemNames());

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

                if (dateFrom > dateTo)
                {
                    SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Error, this.Text, "Invalid Date Range.");
                    return;
                }

                if (chkAllLocations.Checked == true) { locationId = 0; }
                else
                {
                    if (!ValidateComboBox())
                    {
                        return;
                    }

                    if (cmbLocation.SelectedValue != null)
                    {
                        locationId = Common.ConvertStringToInt(cmbLocation.SelectedValue.ToString());
                    }

                }

                SalesService salesService = new SalesService();

                FrmReportViewer frmReportViewer = new FrmReportViewer();
                RptItemWiseFastMoving rptItemWiseFastMoving = new RptItemWiseFastMoving();
                if (txtItemCodeFrom.Text == string.Empty && txtItemCodeTo.Text == string.Empty)
                {
                    rptItemWiseFastMoving.SetDataSource(salesService.GetItemWiseFastMovingDetails(locationId, dateFrom, dateTo));
                }
                else
                {
                    rptItemWiseFastMoving.SetDataSource(salesService.GetItemWiseFastMovingDetails(locationId, dateFrom, dateTo, codeFrom, codeTo));
                }
                rptItemWiseFastMoving.SummaryInfo.ReportTitle = this.Text;
                if (chkAllLocations.Checked)
                { rptItemWiseFastMoving.DataDefinition.FormulaFields["Location"].Text = "'All Locations'"; }
                else
                { rptItemWiseFastMoving.DataDefinition.FormulaFields["Location"].Text = "'" + cmbLocation.Text.Trim() + "'"; }
                rptItemWiseFastMoving.DataDefinition.FormulaFields["DateFrom"].Text = "'" + dtpDateFrom.Text + "'";
                rptItemWiseFastMoving.DataDefinition.FormulaFields["DateTo"].Text = "'" + dtpDateTo.Text + "'";
                rptItemWiseFastMoving.DataDefinition.FormulaFields["LoginUsername"].Text = "'" + Common.LoggedUserName + "'";
                rptItemWiseFastMoving.DataDefinition.FormulaFields["LoginLocation"].Text = "'" + Common.LoggedLocation + "'";
                rptItemWiseFastMoving.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.CompanyName + "'";
                rptItemWiseFastMoving.DataDefinition.FormulaFields["Address"].Text = "'" + Common.Address + "'";
                frmReportViewer.crystalReportViewer.ReportSource = rptItemWiseFastMoving;
                frmReportViewer.Show();

                base.View();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());

            }
        }
        #endregion

        #region Keydown and Leave

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

        #endregion

        #region Other
        private bool ValidateComboBox()
        {
            return Validater.ValidateComboBox(errorProvider1, ValidateType.Empty, cmbLocation);
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
                    item = itemService.GetActiveItemByAllCodes(str);
                }
                else
                {
                    item = itemService.GetActiveItemByName(str);
                }

                if (item != null)
                {
                    if (isFrom)
                    {
                        txtItemCodeFrom.Text = item.ReferenceCode1.Trim();
                        txtItemNameFrom.Text = item.ItemName.Trim();
                    }
                    else
                    {
                        txtItemCodeTo.Text = item.ReferenceCode1.Trim();
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

        #endregion
    }
}
