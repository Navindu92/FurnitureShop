using Microsoft.Win32;
using NSoft.ERP.Domain.General;
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
    public partial class FrmPOSConfiguration : Form
    {
        public FrmPOSConfiguration()
        {
            InitializeComponent();
        }

        RegistryKey counterInfo = null;
        Counter counter;
        private void FrmPOSConfiguration_Load(object sender, EventArgs e)
        {
            try
            {
                LocationService locationService = new LocationService();
                cmbLocation.DataSource = locationService.GetAllActiveLocations();
                cmbLocation.DisplayMember = "LocationName";
                cmbLocation.ValueMember = "LocationID";
                cmbLocation.SelectedIndex = -1;
                cmbLocation.Refresh();

                cmbLocation.SelectedValue = Common.LoggedLocationID;

                CounterService counterService = new CounterService();
                counter = new Counter();
                counter = counterService.GetCounterByCounterNoAndLocationID(Common.CounterNo, Common.LoggedLocationID);

                if (counter != null)
                {
                    txtCounterNo.Text = counter.CounterNo.ToString();
                    txtCounterCode.Text = counter.CounterCode.Trim();
                    txtCounterName.Text = counter.CounterName.Trim();
                    txtXNo.Text = counter.Xno.ToString();
                    txtZNo.Text = counter.Zno.ToString();
                    txtInvoiceNo.Text = counter.InvoiceNo.ToString();
                    txtHoldNo.Text = counter.HoldNo.ToString();

                    txtPrinterName.Text = counter.PrinterName.Trim();
                    txtPrinterWidth.Text = counter.PrinterWidth.ToString();
                    txtDashWidth.Text = counter.DashWidth.ToString();
                    txtMarginX.Text = counter.MarginX.ToString();
                    txtLogoPath.Text = counter.LogoPath.ToString();

                    chkIsPrintLogo.Checked = counter.IsPrintLogo;
                    chkIsPrintSinhala.Checked = counter.IsPrintSinhala;

                    txtHeader1.Text = counter.Header1.Trim();
                    txtHeader2.Text = counter.Header2.Trim();
                    txtHeader3.Text = counter.Header3.Trim();
                    txtHeader4.Text = counter.Header4.Trim();
                    txtHeader5.Text = counter.Header5.Trim();

                    txtTail1.Text = counter.Tail1.Trim();
                    txtTail2.Text = counter.Tail2.Trim();
                    txtTail3.Text = counter.Tail3.Trim();
                    txtTail4.Text = counter.Tail4.Trim();
                    txtTail5.Text = counter.Tail5.Trim();

                    chkIsDisplayConnected.Checked = counter.IsDisplayConnected;
                    rdbUSBDisplay.Checked = counter.IsUSBDisplay;
                    rdbCOMDisplay.Checked = counter.IsCOMDisplay;

                    cmbDisplayComPort.Text = counter.DisplayComPort.Trim();
                    txtDisplayText1.Text = counter.DisplayText1.Trim();
                    txtDisplayText2.Text = counter.DisplayText2.Trim();

                    chkIsDualDisplay.Checked = counter.IsDualDisplay;
                    txtVideoPath.Text = counter.VideoPath.Trim();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                counterInfo = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\NSOFT\INVENTORY");
                counterInfo = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\NSOFT\INVENTORY");
                counterInfo.SetValue("INVENTORYLocationID", cmbLocation.SelectedValue);
                counterInfo.SetValue("INVENTORYCounterNo", txtCounterNo.Text.Trim());
                counterInfo.Close();

                CounterService counterService = new CounterService();
                counter = new Counter();
                counter = counterService.GetCounterByCounterNoAndLocationID(Common.ConvertStringToLong(txtCounterNo.Text.Trim()), Common.LoggedLocationID);

                if (counter == null)
                {
                    counter = new Counter();
                }

                counter.LocationID = Common.ConvertStringToLong(cmbLocation.SelectedValue.ToString());
                counter.CounterNo = Common.ConvertStringToLong(txtCounterNo.Text.Trim());
                counter.CounterCode = txtCounterCode.Text.Trim();
                counter.CounterName = txtCounterName.Text.Trim();
                counter.Xno = Common.ConvertStringToLong(txtXNo.Text.Trim());
                counter.Zno = Common.ConvertStringToLong(txtZNo.Text.Trim());
                counter.InvoiceNo = Common.ConvertStringToLong(txtInvoiceNo.Text.Trim());
                counter.HoldNo = Common.ConvertStringToLong(txtHoldNo.Text.Trim());

                counter.PrinterName = txtPrinterName.Text.Trim();
                counter.PrinterWidth = Common.ConvertStringToLong(txtPrinterWidth.Text.Trim());
                counter.DashWidth = Common.ConvertStringToInt(txtDashWidth.Text.Trim());
                counter.MarginX = Common.ConvertStringToInt(txtMarginX.Text.Trim());
                counter.LogoPath = txtLogoPath.Text.Trim();

                counter.IsPrintLogo = chkIsPrintLogo.Checked;
                counter.IsPrintSinhala = chkIsPrintSinhala.Checked;

                counter.Header1 = txtHeader1.Text.Trim();
                counter.Header2 = txtHeader2.Text.Trim();
                counter.Header3 = txtHeader3.Text.Trim();
                counter.Header4 = txtHeader4.Text.Trim();
                counter.Header5 = txtHeader5.Text.Trim();

                counter.Tail1 = txtTail1.Text.Trim();
                counter.Tail2 = txtTail2.Text.Trim();
                counter.Tail3 = txtTail3.Text.Trim();
                counter.Tail4 = txtTail4.Text.Trim();
                counter.Tail5 = txtTail5.Text.Trim();

                counter.IsDisplayConnected = chkIsDisplayConnected.Checked;
                counter.IsUSBDisplay = rdbUSBDisplay.Checked;
                counter.IsCOMDisplay = rdbCOMDisplay.Checked;

                counter.DisplayComPort = cmbDisplayComPort.Text.Trim();
                counter.DisplayText1 = txtDisplayText1.Text.Trim();
                counter.DisplayText2 = txtDisplayText2.Text.Trim();

                counter.IsDualDisplay = chkIsDualDisplay.Checked;
                counter.VideoPath = txtVideoPath.Text.Trim();

                if (counter.CounterID == 0)
                {
                    counterService.AddCounter(counter);
                }
                else
                {
                    counterService.UpdateCounter(counter);
                }

                Application.Restart();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtCounterNo_Leave(object sender, EventArgs e)
        {
            try
            {
                LocationService locationService = new LocationService();
                cmbLocation.DataSource = locationService.GetAllActiveLocations();
                cmbLocation.DisplayMember = "LocationName";
                cmbLocation.ValueMember = "LocationID";
               /// cmbLocation.SelectedIndex = -1;
                cmbLocation.Refresh();

               // cmbLocation.SelectedValue = Common.LoggedLocationID;

                CounterService counterService = new CounterService();
                counter = new Counter();
                counter = counterService.GetCounterByCounterNoAndLocationID(Common.ConvertStringToLong(txtCounterNo.Text.Trim()),Common.ConvertStringToLong(cmbLocation.SelectedValue.ToString()));

                if (counter != null)
                {
                    txtCounterNo.Text = counter.CounterNo.ToString();
                    txtCounterCode.Text = counter.CounterCode.Trim();
                    txtCounterName.Text = counter.CounterName.Trim();
                    txtXNo.Text = counter.Xno.ToString();
                    txtZNo.Text = counter.Zno.ToString();
                    txtInvoiceNo.Text = counter.InvoiceNo.ToString();
                    txtHoldNo.Text = counter.HoldNo.ToString();

                    txtPrinterName.Text = counter.PrinterName.Trim();
                    txtPrinterWidth.Text = counter.PrinterWidth.ToString();
                    txtDashWidth.Text = counter.DashWidth.ToString();
                    txtMarginX.Text = counter.MarginX.ToString();
                    txtLogoPath.Text = counter.LogoPath.ToString();

                    chkIsPrintLogo.Checked = counter.IsPrintLogo;
                    chkIsPrintSinhala.Checked = counter.IsPrintSinhala;

                    txtHeader1.Text = counter.Header1.Trim();
                    txtHeader2.Text = counter.Header2.Trim();
                    txtHeader3.Text = counter.Header3.Trim();
                    txtHeader4.Text = counter.Header4.Trim();
                    txtHeader5.Text = counter.Header5.Trim();

                    txtTail1.Text = counter.Tail1.Trim();
                    txtTail2.Text = counter.Tail2.Trim();
                    txtTail3.Text = counter.Tail3.Trim();
                    txtTail4.Text = counter.Tail4.Trim();
                    txtTail5.Text = counter.Tail5.Trim();

                    chkIsDisplayConnected.Checked = counter.IsDisplayConnected;
                    rdbUSBDisplay.Checked = counter.IsUSBDisplay;
                    rdbCOMDisplay.Checked = counter.IsCOMDisplay;

                    cmbDisplayComPort.Text = counter.DisplayComPort.Trim();
                    txtDisplayText1.Text = counter.DisplayText1.Trim();
                    txtDisplayText2.Text = counter.DisplayText2.Trim();

                    chkIsDualDisplay.Checked = counter.IsDualDisplay;
                    txtVideoPath.Text = counter.VideoPath.Trim();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
