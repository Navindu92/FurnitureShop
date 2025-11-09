using NSoft.ERP.Domain.General;
using NSoft.ERP.Reports.Reports.General.Transaction;
using NSoft.ERP.Service.General;
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
using static NSoft.ERP.Utility.Validater;

namespace NSoft.ERP.Reports.Forms.General
{
    public partial class FrmPaidInPaidOutReport : FrmBaseReport
    {
        public FrmPaidInPaidOutReport()
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

                CounterService counterService = new CounterService();
                cmbCounter.DataSource = counterService.GetAllActiveCounters();
                cmbCounter.DisplayMember = "CounterName";
                cmbCounter.ValueMember = "CounterNo";
                cmbCounter.SelectedIndex = -1;
                cmbCounter.Refresh();

                PaidInPaidOutService paidInPaidOutService = new PaidInPaidOutService();

                var paidInList = paidInPaidOutService.GetAllActivePaidInTypes();

                lstPaidIn.Clear();
                foreach (var item in paidInList)
                {
                    lstPaidIn.Items.Add(item.PaidInTypeName.ToString());
                }

                var paidOutList = paidInPaidOutService.GetAllActivePaidOutTypes();

                lstPaidOut.Clear();
                foreach (var item in paidOutList)
                {
                    lstPaidOut.Items.Add(item.PaidOutTypeName.ToString());
                }

                chkAllLocations.Checked = true;
                chkAllCounter.Checked = true;

                chkAllPaidIn.Checked = true;
                chkAllPaidOut.Checked = true;

                CheckAllPaidIn(chkAllPaidIn.Checked);
                CheckAllPaidOut(chkAllPaidOut.Checked);

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
                int counterId = 0;
                bool isPaidIn = false;

                DateTime dateFrom = dtpDateFrom.Value.Date;
                DateTime dateTo = dtpDateTo.Value.Date;

                if (rdbIsPaidIn.Checked)
                {
                    isPaidIn = true;
                }

                if (dateFrom > dateTo)
                {
                    SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Error, this.Text, "Invalid Date Range.");
                    return;
                }

                if (chkAllLocations.Checked == true) { locationId = 0; }
                else
                {
                    if (!ValidateComboBoxLocation())
                    {
                        return;
                    }

                    if (cmbLocation.SelectedValue != null)
                    {
                        locationId = Common.ConvertStringToInt(cmbLocation.SelectedValue.ToString());
                    }

                }

                if (chkAllCounter.Checked == true) { counterId = 0; }
                else
                {
                    if (!ValidateComboBoxCounter())
                    {
                        return;
                    }

                    if (cmbCounter.SelectedValue != null)
                    {
                        counterId = Common.ConvertStringToInt(cmbCounter.SelectedValue.ToString());
                    }

                }

                FrmReportViewer frmReportViewer = new FrmReportViewer();
                PaidInPaidOutService paidInPaidOutService = new PaidInPaidOutService();

                if (Common.GroupOfCompanyID == 2)
                {
                    RptPaidInPaidOutDetailsHeladiwa rptPaidInPaidOutDetails = new RptPaidInPaidOutDetailsHeladiwa();

                    rptPaidInPaidOutDetails.SetDataSource(paidInPaidOutService.GetPaidInPaidOutDetails(locationId, counterId, dateFrom, dateTo, isPaidIn).Tables[0]);
                    if (rdbIsPaidIn.Checked)
                    {
                        rptPaidInPaidOutDetails.SummaryInfo.ReportTitle = "Paid In Details";
                    }
                    else
                    {
                        rptPaidInPaidOutDetails.SummaryInfo.ReportTitle = "Paid Out Details";
                    }
                    if (chkAllLocations.Checked)
                    { rptPaidInPaidOutDetails.DataDefinition.FormulaFields["Location"].Text = "'All Locations'"; }
                    else
                    { rptPaidInPaidOutDetails.DataDefinition.FormulaFields["Location"].Text = "'" + cmbLocation.Text.Trim() + "'"; }
                    if (chkAllCounter.Checked)
                    { rptPaidInPaidOutDetails.DataDefinition.FormulaFields["Counter"].Text = "'All Counters'"; }
                    else
                    { rptPaidInPaidOutDetails.DataDefinition.FormulaFields["Counter"].Text = "'" + cmbCounter.Text.Trim() + "'"; }
                    rptPaidInPaidOutDetails.DataDefinition.FormulaFields["DateFrom"].Text = "'" + dtpDateFrom.Text + "'";
                    rptPaidInPaidOutDetails.DataDefinition.FormulaFields["DateTo"].Text = "'" + dtpDateTo.Text + "'";
                    rptPaidInPaidOutDetails.DataDefinition.FormulaFields["LoginUsername"].Text = "'" + Common.LoggedUserName + "'";
                    rptPaidInPaidOutDetails.DataDefinition.FormulaFields["LoginLocation"].Text = "'" + Common.LoggedLocation + "'";
                    rptPaidInPaidOutDetails.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.CompanyName + "'";
                    rptPaidInPaidOutDetails.DataDefinition.FormulaFields["Address"].Text = "'" + Common.Address + "'";

                    frmReportViewer.crystalReportViewer.ReportSource = rptPaidInPaidOutDetails;
                    frmReportViewer.Show();
                }
                else
                {
                    RptPaidInPaidOutDetails rptPaidInPaidOutDetails = new RptPaidInPaidOutDetails();

                    rptPaidInPaidOutDetails.SetDataSource(paidInPaidOutService.GetPaidInPaidOutDetails(locationId, counterId, dateFrom, dateTo, isPaidIn).Tables[0]);
                    rptPaidInPaidOutDetails.SummaryInfo.ReportTitle = this.Text;
                    if (chkAllLocations.Checked)
                    { rptPaidInPaidOutDetails.DataDefinition.FormulaFields["Location"].Text = "'All Locations'"; }
                    else
                    { rptPaidInPaidOutDetails.DataDefinition.FormulaFields["Location"].Text = "'" + cmbLocation.Text.Trim() + "'"; }
                    if (chkAllCounter.Checked)
                    { rptPaidInPaidOutDetails.DataDefinition.FormulaFields["Counter"].Text = "'All Counters'"; }
                    else
                    { rptPaidInPaidOutDetails.DataDefinition.FormulaFields["Counter"].Text = "'" + cmbCounter.Text.Trim() + "'"; }
                    rptPaidInPaidOutDetails.DataDefinition.FormulaFields["DateFrom"].Text = "'" + dtpDateFrom.Text + "'";
                    rptPaidInPaidOutDetails.DataDefinition.FormulaFields["DateTo"].Text = "'" + dtpDateTo.Text + "'";
                    rptPaidInPaidOutDetails.DataDefinition.FormulaFields["LoginUsername"].Text = "'" + Common.LoggedUserName + "'";
                    rptPaidInPaidOutDetails.DataDefinition.FormulaFields["LoginLocation"].Text = "'" + Common.LoggedLocation + "'";
                    rptPaidInPaidOutDetails.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.CompanyName + "'";
                    rptPaidInPaidOutDetails.DataDefinition.FormulaFields["Address"].Text = "'" + Common.Address + "'";

                    frmReportViewer.crystalReportViewer.ReportSource = rptPaidInPaidOutDetails;
                    frmReportViewer.Show();
                }
                base.View();

                Cursor.Current = Cursors.Default;
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
            return Validater.ValidateComboBox(errorProvider1, ValidateType.Empty, cmbLocation, cmbCounter);
        }
        private bool ValidateComboBoxLocation()
        {
            return Validater.ValidateComboBox(errorProvider1, ValidateType.Empty, cmbLocation);
        }
        private bool ValidateComboBoxCounter()
        {
            return Validater.ValidateComboBox(errorProvider1, ValidateType.Empty, cmbCounter);
        }
        private void chkAllLocations_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllLocations.Checked)
            {
                cmbLocation.SelectedIndex = -1;
            }

        }
        private void chkAllCounter_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllCounter.Checked)
            {
                cmbCounter.SelectedIndex = -1;
            }
        }
        private void cmbLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkAllLocations.Checked = false;
        }

        private void cmbCounter_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkAllCounter.Checked = false;
        }

        private void CheckAllPaidIn(bool chkStatus)
        {
            try
            {
                foreach (ListViewItem dr in lstPaidIn.Items)
                {
                    dr.Checked = chkStatus;
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void CheckAllPaidOut(bool chkStatus)
        {
            try
            {
                foreach (ListViewItem dr in lstPaidOut.Items)
                {
                    dr.Checked = chkStatus;
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void chkAllPaidIn_CheckedChanged(object sender, EventArgs e)
        {
            CheckAllPaidIn(chkAllPaidIn.Checked);
        }
        private void chkAllPaidOut_CheckedChanged(object sender, EventArgs e)
        {
            CheckAllPaidOut(chkAllPaidIn.Checked);
        }

        #endregion
    }
}
