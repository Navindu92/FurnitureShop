using NSoft.ERP.Domain.General;
using NSoft.ERP.Reports.Forms.General;
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
    public partial class FrmCounterSummary : FrmBaseReport
    {
        public FrmCounterSummary()
        {
            InitializeComponent();
        }

        FormInfo formInfo;
        UserPrivileges userPrivileges;
        Counter counter;

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

                Common.EnableComboBox(true, cmbCounter, cmbLocation);

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

                DateTime dateFrom = dtpDateFrom.Value.Date;
                DateTime dateTo = dtpDateTo.Value.Date;

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
                CounterService counterService = new CounterService();
                RptCounterSummary rptCounterSummary = new RptCounterSummary();

                DataSet dtReport = counterService.GetCounterSummary(locationId, counterId, 1, dtpDateFrom.Value.Date, dtpDateTo.Value.Date);

                rptCounterSummary.SetDataSource(dtReport.Tables[0]);

                if (dtReport.Tables[1].Rows.Count > 0)
                {
                    rptCounterSummary.Subreports[0].SetDataSource(dtReport.Tables[1]);
                }
                else
                {
                    rptCounterSummary.ReportDefinition.Sections[5].SectionFormat.EnableSuppress = true;
                }

                if (dtReport.Tables[2].Rows.Count > 0)
                {
                    rptCounterSummary.Subreports[1].SetDataSource(dtReport.Tables[2]);
                }
                else
                {
                    rptCounterSummary.ReportDefinition.Sections[6].SectionFormat.EnableSuppress = true;
                }

                if (dtReport.Tables[3].Rows.Count > 0)
                {
                    rptCounterSummary.Subreports[2].SetDataSource(dtReport.Tables[3]);
                }
                else
                {
                    rptCounterSummary.ReportDefinition.Sections[7].SectionFormat.EnableSuppress = true;
                }

                rptCounterSummary.SummaryInfo.ReportTitle = this.Text;
                if (chkAllLocations.Checked)
                { rptCounterSummary.DataDefinition.FormulaFields["Location"].Text = "'All Locations'"; }
                else
                { rptCounterSummary.DataDefinition.FormulaFields["Location"].Text = "'" + cmbLocation.Text.Trim() + "'"; }
                if (chkAllCounter.Checked)
                { rptCounterSummary.DataDefinition.FormulaFields["Counter"].Text = "'All Counters'"; }
                else
                { rptCounterSummary.DataDefinition.FormulaFields["Counter"].Text = "'" + cmbCounter.Text.Trim() + "'"; }
                rptCounterSummary.DataDefinition.FormulaFields["DateFrom"].Text = "'" + dtpDateFrom.Text + "'";
                rptCounterSummary.DataDefinition.FormulaFields["DateTo"].Text = "'" + dtpDateTo.Text + "'";
                rptCounterSummary.DataDefinition.FormulaFields["LoginUsername"].Text = "'" + Common.LoggedUserName + "'";
                rptCounterSummary.DataDefinition.FormulaFields["LoginLocation"].Text = "'" + Common.LoggedLocation + "'";
                rptCounterSummary.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.CompanyName + "'";
                rptCounterSummary.DataDefinition.FormulaFields["Address"].Text = "'" + Common.Address + "'";


                frmReportViewer.crystalReportViewer.ReportSource = rptCounterSummary;
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

        #endregion

        #region Keydown and Leave

        private void cmbLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbCounter.Focus();
                }

            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void dtpDateFrom_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    dtpDateTo.Focus();
                }

            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void dtpDateTo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnView.Focus();
                }

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

        private void ViewReport()
        {
            try
            {

            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }

        #endregion

        private void chkAllLocations_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllLocations.Checked)
            {
                cmbLocation.SelectedIndex = -1;
                Common.EnableComboBox(false, cmbLocation);
            }
            else
            {
                cmbLocation.SelectedIndex = -1;
                Common.EnableComboBox(true, cmbLocation);
            }
        }

        private void chkAllCounter_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllCounter.Checked)
            {
                cmbCounter.SelectedIndex = -1;
                Common.EnableComboBox(false, cmbCounter);
            }
            else
            {
                cmbCounter.SelectedIndex = -1;
                Common.EnableComboBox(true, cmbCounter);
            }
        }
    }
}
