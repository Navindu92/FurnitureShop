using NSoft.ERP.Domain.General;
using NSoft.ERP.Service.General;
using NSoft.ERP.UI.Windows.General;
using NSoft.ERP.UI.Windows.Device;
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
using System.Drawing.Printing;

namespace NSoft.ERP.UI.Windows.Inventory
{
    public partial class FrmCounterTranasaction : FrmBaseTransation
    {
        /// <summary>
        /// Developed by Navindu
        /// 2017-08-09
        /// </summary>

        int tranasactionType; // 1-Counter Open /2-Counter Close /3-X Reading
        string name;

        FormInfo formInfo;
        UserPrivileges userPrivileges;
        UserService userService = new UserService();
        CounterTransaction counterTransaction;
        Counter counter;
        public FrmCounterTranasaction()
        {
            InitializeComponent();
        }

        public FrmCounterTranasaction(int tranasactionType, string name)
        {
            try
            {
                this.tranasactionType = tranasactionType;
                this.name = name;
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        #region Override Methods
        public override void FormLoad()
        {
            try
            {
                formInfo = new FormInfo();
                formInfo = FormInfoService.GetFormInfoByName(name);
                if (formInfo != null)
                {
                    CounterService counterService = new CounterService();

                    if (tranasactionType == 1)
                    {
                        this.Text = " Counter Opening - " + counterService.GetCounterByCounterNoAndLocationID(Common.CounterNo, Common.LoggedLocationID).CounterName.Trim();
                    }
                    else if (tranasactionType == 2)
                    {
                        this.Text = " Counter Close - " + counterService.GetCounterByCounterNoAndLocationID(Common.CounterNo, Common.LoggedLocationID).CounterName.Trim();
                        Common.EnableDateTimePicker(false, dtpCounterDate);
                    }
                    else
                    {
                        this.Text = " X Reading - " + counterService.GetCounterByCounterNoAndLocationID(Common.CounterNo, Common.LoggedLocationID).CounterName.Trim();
                        Common.EnableDateTimePicker(false, dtpCounterDate);
                    }
                }

                dtpCounterDate.MinDate = DateTime.Now.Date;

                Common.EnableButton(false, btnView);

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

                UserService userService = new UserService();
                cmbUsername.DataSource = userService.GetAllActiveUsers();
                cmbUsername.DisplayMember = "Username";
                cmbUsername.ValueMember = "UserID";
                cmbUsername.SelectedIndex = -1;
                cmbUsername.Refresh();

                cmbLocation.SelectedValue = Common.LoggedLocationID;
                cmbUsername.SelectedValue = Common.LoggedUserID;

                Common.EnableComboBox(false, cmbLocation, cmbUsername);
                Common.EnableDateTimePicker(false, dtpCounterDate);
                this.ActiveControl = txtAmount;
                txtAmount.Focus();

                Common.EnableButton(false, btnSave);
                userPrivileges = new UserPrivileges();
                userPrivileges = userService.GetUserPrivilegesByUserIDAndForm(Common.LoggedUserID, formInfo);

                if (userPrivileges == null ? false : userPrivileges.IsSave)
                { Common.EnableButton(true, btnSave); }

                counterTransaction = new CounterTransaction();

                base.Initialize();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        public override void Save()
        {
            try
            {
                if (!ValidateControles()) { return; }
                CounterService counterService = new CounterService();

                counter = new Counter();
                counter = counterService.GetCounterByCounterNoAndLocationID(Common.CounterNo, Common.LoggedLocationID);

                if (tranasactionType == 1)
                {
                    if (counterService.GetCounterTransactionByLocationCounterAndDateAndZno(Common.ConvertStringToLong(cmbLocation.SelectedValue.ToString()), Common.CounterNo, 1, dtpCounterDate.Value.Date, counter.Zno) != null)
                    {
                        SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Error, this.Text, "Counter Open already done.");
                        return;
                    }
                }
                else
                {
                    if (counterService.GetCounterTransactionByLocationCounterAndDateAndZno(Common.ConvertStringToLong(cmbLocation.SelectedValue.ToString()), Common.CounterNo, 1, dtpCounterDate.Value.Date, counter.Zno) == null)
                    {
                        SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Error, this.Text, "Counter Open not found.");
                        return;
                    }
                }
                SaveCounterTransaction();
                base.Save();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        #endregion

        #region Other
        private void cmbLocation_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblLocation);
        }

        private void dtpCounterDate_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblDate);
        }

        private void cmbUsername_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblUsername);
        }

        private void txtAmount_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblAmount);
        }
        private void SaveCounterTransaction()
        {
            try
            {
                if (counterTransaction == null)
                {
                    counterTransaction = new CounterTransaction();
                }

                counterTransaction.LocationID = Common.ConvertStringToLong(cmbLocation.SelectedValue.ToString());
                counterTransaction.TransactionDate = dtpCounterDate.Value.Date;
                counterTransaction.TransactionTypeID = tranasactionType;
                counterTransaction.CounterNo = Common.CounterNo;
                counterTransaction.Amount = Common.ConvertStringToDecimal(txtAmount.Text.Trim().ToString());
                counterTransaction.UserID = Common.ConvertStringToLong(cmbUsername.SelectedValue.ToString());
                counterTransaction.Zno = counter.Zno;
                counterTransaction.ZDate = DateTime.Now.Date;

                CounterService counterService = new CounterService();
                counterService.AddCounterTransaction(counterTransaction,new List<FloatMaster>());

                if (tranasactionType == 1)
                {
                    PrintCounterOpen();
                    Application.Restart();
                }
                else if (tranasactionType == 2)
                {
                    PrintXReading();
                    Application.Restart();
                }
                else if (tranasactionType == 3)
                {
                    PrintXReading();
                    this.Close();
                }
                LogWritter.WriteEventLog(this.Name, this.Text, LogWritter.EventType.Save);

            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private bool ValidateControles()
        {
            try
            {
                if (!Validater.ValidateTextBox(errorProvider1, Validater.ValidateType.Empty, txtAmount))
                { return false; }
                if (!Validater.ValidateComboBox(errorProvider1, Validater.ValidateType.Empty, cmbLocation, cmbUsername))
                { return false; }
                return true;
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
                return false;
            }
        }

        private DataSet DayEnd()
        {
            try
            {
                int locationId = 0;

                if (cmbLocation.SelectedValue != null)
                {
                    locationId = Common.ConvertStringToInt(cmbLocation.SelectedValue.ToString());
                }

                CounterService counterService = new CounterService();
                return counterService.GetCounterSummary(locationId, Common.CounterNo, tranasactionType, dtpCounterDate.Value.Date, dtpCounterDate.Value.Date, counterTransaction.Amount);
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
                return null;
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
                    dtpCounterDate.Focus();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }

        private void dtpCounter_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void cmbUsername_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtAmount.Focus();
                }

            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSave.PerformClick();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void dtpCounterDate_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cmbUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void cmbLocation_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightLable(lblLocation);
        }

        private void dtpCounterDate_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightLable(lblDate);
        }

        private void cmbUsername_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightLable(lblUsername);
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightLable(lblAmount);
        }

        #endregion

        public void PrintCounterOpen()
        {

            POSPrinter.PrintText(POSPrinter.eInitialize + POSPrinter.eDrawer);

            PrintDocument printCounterOpen = new PrintDocument();
            printCounterOpen.PrinterSettings.PrinterName = POSPrinter.printerName;

            printCounterOpen.PrintPage += new PrintPageEventHandler(pd_PrintCounterOpen);

            PrintController printController = new StandardPrintController();
            printCounterOpen.PrintController = printController;

            printCounterOpen.Print();
        }

        public void PrintXReading()
        {
            PrintDocument printXReading = new PrintDocument();
            printXReading.PrinterSettings.PrinterName = POSPrinter.printerName;

            printXReading.PrintPage += new PrintPageEventHandler(pd_PrintXReding);

            PrintController printController = new StandardPrintController();
            printXReading.PrintController = printController;

            printXReading.Print();
        }

        private void pd_PrintCounterOpen(object sender, PrintPageEventArgs e)
        {
          /*  Graphics graphics = e.Graphics;
            float startX = 0;
            float startY = 20;
            float marginX = 0;
            float printWidth = 0;

            Font fontHeader = new Font("POSNormal", 12.5f, FontStyle.Bold);
            Font fontNormal = new Font("POSNormal", 9.5f, FontStyle.Bold);
            Font fontNormalSinhala = new Font("POSNormal", 9.5f, FontStyle.Bold);
            Font fontDoubleHeight = new Font("POSDouble", 9.5f, FontStyle.Bold);

            float lineHeightHeader = fontHeader.GetHeight();
            float lineHeightNormal = fontNormal.GetHeight();
            float lineHeightNormalSinhala = fontNormalSinhala.GetHeight();
            float lineHeightDoubleHeight = fontDoubleHeight.GetHeight() + 2;

            Brush brush = Brushes.Black;

            float pageWidth = 0;
            float textWidth = 0;

            CounterConfiguration counterConfiguration = new CounterConfiguration();
            counterConfiguration = CommonService.GetCounterConfiguration(Common.LoggedLocationID, Common.CounterNo);

            if (counterConfiguration != null)
            {
                //pageWidth = e.PageSettings.PrintableArea.Width + counterConfiguration.PrinterWidth;

                pageWidth = counterConfiguration.PrinterWidth;
                marginX = counterConfiguration.MarginX;

                if (counterConfiguration.Header1 != string.Empty)
                {
                    textWidth = e.Graphics.MeasureString(counterConfiguration.Header1.Trim(), fontDoubleHeight).Width;
                    startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                    graphics.DrawString(counterConfiguration.Header1.Trim(), fontDoubleHeight, brush, startX, startY);
                    startY += lineHeightDoubleHeight;
                }

                if (counterConfiguration.Header2 != string.Empty)
                {
                    textWidth = e.Graphics.MeasureString(counterConfiguration.Header2.Trim(), fontNormal).Width;
                    startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                    graphics.DrawString(counterConfiguration.Header2.Trim(), fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;
                }

                if (counterConfiguration.Header3 != string.Empty)
                {
                    textWidth = e.Graphics.MeasureString(counterConfiguration.Header3.Trim(), fontNormal).Width;
                    startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                    graphics.DrawString(counterConfiguration.Header3.Trim(), fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;
                }

                if (counterConfiguration.Header4 != string.Empty)
                {
                    textWidth = e.Graphics.MeasureString(counterConfiguration.Header4.Trim(), fontNormal).Width;
                    startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                    graphics.DrawString(counterConfiguration.Header4.Trim(), fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;
                }

                if (counterConfiguration.Header5 != string.Empty)
                {
                    textWidth = (int)e.Graphics.MeasureString(counterConfiguration.Header5.Trim(), fontNormal).Width;
                    startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                    graphics.DrawString(counterConfiguration.Header5.Trim(), fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;
                }
            }

            string dashLine = new string('-', counterConfiguration.DashWidth);

            textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
            startX = marginX;
            graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
            startY += lineHeightNormal;

            string header = "Counter Open";

            textWidth = e.Graphics.MeasureString(header, fontDoubleHeight).Width;
            startX = (pageWidth - (marginX * 2) - textWidth) / 2;
            graphics.DrawString(header, fontDoubleHeight, brush, startX, startY);
            startY += lineHeightDoubleHeight;

            textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
            startX = marginX;
            graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
            startY += lineHeightNormal;

            startX = marginX;
            graphics.DrawString("Date :" + counterTransaction.TransactionDate.ToString("dd-MMM-yyyy"), fontNormal, brush, startX, startY);
            startY += lineHeightNormal;

            startX = marginX;
            graphics.DrawString("Location : " + Common.LoggedLocation.Trim(), fontNormal, brush, startX, startY);
            startY += lineHeightNormal;

            startX = marginX;
            graphics.DrawString("Unit : " + counter.CounterCode.Trim(), fontNormal, brush, startX, startY);
            startY += lineHeightNormal;

            graphics.DrawString("Staff : " + Common.LoggedUserName.Trim(), fontNormal, brush, startX, startY);
            startY += lineHeightNormal;


            textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
            startX = marginX;
            graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
            startY += lineHeightNormal;

            startX = marginX;
            string productDetailTailLeft = "Counter Opening";
            string productDetailTailRight = Common.ConvertToStringCurrancy(counterTransaction.Amount.ToString());

            graphics.DrawString(productDetailTailLeft, fontNormal, brush, startX, startY);

            textWidth = e.Graphics.MeasureString(productDetailTailRight, fontNormal).Width;
            startX = pageWidth - (marginX * 2) - textWidth;
            graphics.DrawString(productDetailTailRight, fontNormal, brush, startX, startY);
            startY += lineHeightNormal;

            textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
            startX = marginX;
            graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
            startY += lineHeightNormal;

            textWidth = e.Graphics.MeasureString("System By NSoft", fontNormal).Width;
            startX = (pageWidth - (marginX * 2) - textWidth) / 2;
            graphics.DrawString("System By NSoft", fontNormal, brush, startX, startY);
            startY += lineHeightNormal;
            */
        }

        private void pd_PrintXReding(object sender, PrintPageEventArgs e)
        {
           /* Graphics graphics = e.Graphics;
            float startX = 0;
            float startY = 20;
            float marginX = 0;
            float printWidth = 0;

            Font fontHeader = new Font("POSNormal", 12.5f, FontStyle.Bold);
            Font fontNormal = new Font("POSNormal", 9.5f, FontStyle.Bold);
            Font fontNormalSinhala = new Font("POSNormal", 9.5f, FontStyle.Bold);
            Font fontDoubleHeight = new Font("POSDouble", 9.5f, FontStyle.Bold);

            float lineHeightHeader = fontHeader.GetHeight();
            float lineHeightNormal = fontNormal.GetHeight();
            float lineHeightNormalSinhala = fontNormalSinhala.GetHeight();
            float lineHeightDoubleHeight = fontDoubleHeight.GetHeight() + 2;

            Brush brush = Brushes.Black;

            float pageWidth = 0;
            float textWidth = 0;

            CounterConfiguration counterConfiguration = new CounterConfiguration();
            counterConfiguration = CommonService.GetCounterConfiguration(Common.LoggedLocationID, Common.CounterNo);

            if (counterConfiguration != null)
            {
                pageWidth = counterConfiguration.PrinterWidth;
                marginX = counterConfiguration.MarginX;

                printWidth = pageWidth - (marginX * 2);

                if (counterConfiguration.Header1 != string.Empty)
                {
                    textWidth = e.Graphics.MeasureString(counterConfiguration.Header1.Trim(), fontDoubleHeight).Width;
                    startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                    graphics.DrawString(counterConfiguration.Header1.Trim(), fontDoubleHeight, brush, startX, startY);
                    startY += lineHeightDoubleHeight;
                }

                if (counterConfiguration.Header2 != string.Empty)
                {
                    textWidth = e.Graphics.MeasureString(counterConfiguration.Header2.Trim(), fontNormal).Width;
                    startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                    graphics.DrawString(counterConfiguration.Header2.Trim(), fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;
                }

                if (counterConfiguration.Header3 != string.Empty)
                {
                    textWidth = e.Graphics.MeasureString(counterConfiguration.Header3.Trim(), fontNormal).Width;
                    startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                    graphics.DrawString(counterConfiguration.Header3.Trim(), fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;
                }

                if (counterConfiguration.Header4 != string.Empty)
                {
                    textWidth = e.Graphics.MeasureString(counterConfiguration.Header4.Trim(), fontNormal).Width;
                    startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                    graphics.DrawString(counterConfiguration.Header4.Trim(), fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;
                }

                if (counterConfiguration.Header5 != string.Empty)
                {
                    textWidth = e.Graphics.MeasureString(counterConfiguration.Header5.Trim(), fontNormal).Width;
                    startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                    graphics.DrawString(counterConfiguration.Header5.Trim(), fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;
                }
            }

            string dashLine = new string('-', counterConfiguration.DashWidth);

            textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
            startX = marginX;
            graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
            startY += lineHeightNormal;

            string header = string.Empty;

            if (tranasactionType == 2)
            {
                header = "Z Reading";
            }
            else if (tranasactionType == 3)
            {
                header = "X Reading";
            }

            textWidth = e.Graphics.MeasureString(header, fontDoubleHeight).Width;
            startX = (pageWidth - (marginX * 2) - textWidth) / 2;
            graphics.DrawString(header, fontDoubleHeight, brush, startX, startY);
            startY += lineHeightDoubleHeight;

            textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
            startX = marginX;
            graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
            startY += lineHeightNormal;

            startX = 10;
            graphics.DrawString("Date : " + counterTransaction.TransactionDate.ToString("dd-MMM-yyyy"), fontNormal, brush, startX, startY);
            startY += lineHeightNormal;

            startX = 10;
            graphics.DrawString("Location : " + Common.LoggedLocation.Trim(), fontNormal, brush, startX, startY);
            startY += lineHeightNormal;

            startX = 10;
            graphics.DrawString("Unit : " + counter.CounterCode.Trim(), fontNormal, brush, startX, startY);
            startY += lineHeightNormal;

            graphics.DrawString("Staff : " + Common.LoggedUserName.Trim(), fontNormal, brush, startX, startY);
            startY += lineHeightNormal;

            if (tranasactionType == 2)
            {
                graphics.DrawString("ZNo : " + counter.Zno, fontNormal, brush, startX, startY);
                startY += lineHeightNormal;
            }
            else if (tranasactionType == 3)
            {
                graphics.DrawString("XNo : " + counter.Xno, fontNormal, brush, startX, startY);
                startY += lineHeightNormal;
            }

            textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
            startX = marginX;
            graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
            startY += lineHeightNormal;

            CounterService counterService = new CounterService();

            DataSet dtReport = counterService.GetCounterSummary(counter.LocationID, counter.CounterNo, tranasactionType, dtpCounterDate.Value.Date, dtpCounterDate.Value.Date, counterTransaction.Amount);

            DataTable dtSalesSummary = dtReport.Tables[0];

            string productDetailTailLeft = string.Empty;
            string productDetailTailRight = string.Empty;

            header = "Sales Summary";

            textWidth = e.Graphics.MeasureString(header, fontDoubleHeight).Width;
            startX = (pageWidth - (marginX * 2) - textWidth) / 2;
            graphics.DrawString(header, fontDoubleHeight, brush, startX, startY);
            startY += lineHeightDoubleHeight + 4;

            if (dtSalesSummary != null && dtSalesSummary.Rows.Count > 0)
            {
                foreach (DataRow row in dtSalesSummary.Rows)
                {
                    startX = marginX;
                    productDetailTailLeft = "Gross Sale";
                    productDetailTailRight = Common.ConvertToStringCurrancy(row["GrossSale"].ToString());

                    graphics.DrawString(productDetailTailLeft, fontNormal, brush, startX, startY);

                    textWidth = e.Graphics.MeasureString(productDetailTailRight, fontNormal).Width;
                    startX = pageWidth - (marginX * 2) - textWidth;
                    graphics.DrawString(productDetailTailRight, fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;

                    startX = marginX;
                    productDetailTailLeft = "Refund *";
                    productDetailTailRight = Common.ConvertToStringCurrancy(row["Refund"].ToString());

                    graphics.DrawString(productDetailTailLeft, fontNormal, brush, startX, startY);

                    textWidth = e.Graphics.MeasureString(productDetailTailRight, fontNormal).Width;
                    startX = pageWidth - (marginX * 2) - textWidth;
                    graphics.DrawString(productDetailTailRight, fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;


                    startX = marginX;
                    productDetailTailLeft = "Item Discount *";
                    productDetailTailRight = Common.ConvertToStringCurrancy(row["ItemDiscount"].ToString());

                    graphics.DrawString(productDetailTailLeft, fontNormal, brush, startX, startY);

                    textWidth = e.Graphics.MeasureString(productDetailTailRight, fontNormal).Width;
                    startX = pageWidth - (marginX * 2) - textWidth;
                    graphics.DrawString(productDetailTailRight, fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;

                    startX = marginX;
                    productDetailTailLeft = "Sub Total Discount *";
                    productDetailTailRight = Common.ConvertToStringCurrancy(row["SubTotalDiscount"].ToString());

                    graphics.DrawString(productDetailTailLeft, fontNormal, brush, startX, startY);

                    textWidth = e.Graphics.MeasureString(productDetailTailRight, fontNormal).Width;
                    startX = pageWidth - (marginX * 2) - textWidth;
                    graphics.DrawString(productDetailTailRight, fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;

                    startX = marginX;
                    productDetailTailLeft = "Item Return Discount";
                    productDetailTailRight = Common.ConvertToStringCurrancy(row["ItemReturnDiscount"].ToString());

                    graphics.DrawString(productDetailTailLeft, fontNormal, brush, startX, startY);

                    textWidth = e.Graphics.MeasureString(productDetailTailRight, fontNormal).Width;
                    startX = pageWidth - (marginX * 2) - textWidth;
                    graphics.DrawString(productDetailTailRight, fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;

                    startX = marginX;
                    productDetailTailLeft = "Sub Tot.Return Dis.";
                    productDetailTailRight = Common.ConvertToStringCurrancy(row["SubTotalReturnDiscount"].ToString());

                    graphics.DrawString(productDetailTailLeft, fontNormal, brush, startX, startY);

                    textWidth = e.Graphics.MeasureString(productDetailTailRight, fontNormal).Width;
                    startX = pageWidth - (marginX * 2) - textWidth;
                    graphics.DrawString(productDetailTailRight, fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;


                    textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
                    startX = marginX;
                    graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;

                    decimal netSale = Common.ConvertStringToDecimal(row["GrossSale"].ToString()) - Common.ConvertStringToDecimal(row["Refund"].ToString())
                                    - Common.ConvertStringToDecimal(row["ItemDiscount"].ToString()) - Common.ConvertStringToDecimal(row["SubTotalDiscount"].ToString())
                                    + Common.ConvertStringToDecimal(row["ItemReturnDiscount"].ToString()) + Common.ConvertStringToDecimal(row["SubTotalReturnDiscount"].ToString());

                    startX = marginX;
                    productDetailTailLeft = "Net Sale";
                    productDetailTailRight = Common.ConvertToStringCurrancy(netSale.ToString());

                    graphics.DrawString(productDetailTailLeft, fontNormal, brush, startX, startY);

                    textWidth = e.Graphics.MeasureString(productDetailTailRight, fontNormal).Width;
                    startX = pageWidth - (marginX * 2) - textWidth;
                    graphics.DrawString(productDetailTailRight, fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;

                    textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
                    startX = marginX;
                    graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;

                    header = "Counter Cash Summary";

                    textWidth = e.Graphics.MeasureString(header, fontDoubleHeight).Width;
                    startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                    graphics.DrawString(header, fontDoubleHeight, brush, startX, startY);
                    startY += lineHeightDoubleHeight + 4;

                    startX = marginX;
                    productDetailTailLeft = "Counter Open";
                    productDetailTailRight = Common.ConvertToStringCurrancy(row["CounterOpen"].ToString());

                    graphics.DrawString(productDetailTailLeft, fontNormal, brush, startX, startY);

                    textWidth = e.Graphics.MeasureString(productDetailTailRight, fontNormal).Width;
                    startX = pageWidth - (marginX * 2) - textWidth;
                    graphics.DrawString(productDetailTailRight, fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;

                    startX = marginX;
                    productDetailTailLeft = "Cash Sale";
                    productDetailTailRight = Common.ConvertToStringCurrancy(row["CashSale"].ToString());

                    graphics.DrawString(productDetailTailLeft, fontNormal, brush, startX, startY);

                    textWidth = e.Graphics.MeasureString(productDetailTailRight, fontNormal).Width;
                    startX = pageWidth - (marginX * 2) - textWidth;
                    graphics.DrawString(productDetailTailRight, fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;

                    startX = marginX;
                    productDetailTailLeft = "Cash Refund *";
                    productDetailTailRight = Common.ConvertToStringCurrancy(row["Cashrefund"].ToString());

                    graphics.DrawString(productDetailTailLeft, fontNormal, brush, startX, startY);

                    textWidth = e.Graphics.MeasureString(productDetailTailRight, fontNormal).Width;
                    startX = pageWidth - (marginX * 2) - textWidth;
                    graphics.DrawString(productDetailTailRight, fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;

                    startX = marginX;
                    productDetailTailLeft = "Paid In Cash";
                    productDetailTailRight = Common.ConvertToStringCurrancy(row["PaidInCash"].ToString());

                    graphics.DrawString(productDetailTailLeft, fontNormal, brush, startX, startY);

                    textWidth = e.Graphics.MeasureString(productDetailTailRight, fontNormal).Width;
                    startX = pageWidth - (marginX * 2) - textWidth;
                    graphics.DrawString(productDetailTailRight, fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;

                    startX = marginX;
                    productDetailTailLeft = "Paid Out Cash *";
                    productDetailTailRight = Common.ConvertToStringCurrancy(row["PaidOutCash"].ToString());

                    graphics.DrawString(productDetailTailLeft, fontNormal, brush, startX, startY);

                    textWidth = e.Graphics.MeasureString(productDetailTailRight, fontNormal).Width;
                    startX = pageWidth - (marginX * 2) - textWidth;
                    graphics.DrawString(productDetailTailRight, fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;

                    decimal cashInHand = Common.ConvertStringToDecimal(row["CounterOpen"].ToString()) + Common.ConvertStringToDecimal(row["CashSale"].ToString())
                        - Common.ConvertStringToDecimal(row["CashRefund"].ToString()) + Common.ConvertStringToDecimal(row["PaidInCash"].ToString())
                        - Common.ConvertStringToDecimal(row["PaidOutCash"].ToString());


                    textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
                    startX = marginX;
                    graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;

                    startX = marginX;
                    productDetailTailLeft = "Cash In Hand";
                    productDetailTailRight = Common.ConvertToStringCurrancy(cashInHand.ToString());

                    graphics.DrawString(productDetailTailLeft, fontNormal, brush, startX, startY);

                    textWidth = e.Graphics.MeasureString(productDetailTailRight, fontNormal).Width;
                    startX = pageWidth - (marginX * 2) - textWidth;
                    graphics.DrawString(productDetailTailRight, fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;

                    startX = marginX;
                    productDetailTailLeft = "Declare Amount";
                    productDetailTailRight = Common.ConvertToStringCurrancy(row["DeclareAmount"].ToString());

                    graphics.DrawString(productDetailTailLeft, fontNormal, brush, startX, startY);

                    textWidth = e.Graphics.MeasureString(productDetailTailRight, fontNormal).Width;
                    startX = pageWidth - (marginX * 2) - textWidth;
                    graphics.DrawString(productDetailTailRight, fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;

                    decimal variance = Common.ConvertStringToDecimal(row["DeclareAmount"].ToString()) - cashInHand;

                    startX = 10;
                    if (variance > 0)
                    {
                        productDetailTailLeft = "Cash Excess";
                    }
                    else if (variance < 0)
                    {
                        productDetailTailLeft = "Cash Shortage";
                        variance = variance * -1;
                    }
                    else
                    {
                        productDetailTailLeft = "Cash Balance";
                    }

                    productDetailTailRight = Common.ConvertToStringCurrancy(variance.ToString());

                    graphics.DrawString(productDetailTailLeft, fontNormal, brush, startX, startY);

                    textWidth = e.Graphics.MeasureString(productDetailTailRight, fontNormal).Width;
                    startX = pageWidth - (marginX * 2) - textWidth;
                    graphics.DrawString(productDetailTailRight, fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;
                }
            }

            if (dtReport.Tables[1].Rows.Count > 0 || dtReport.Tables[2].Rows.Count > 0)
            {
                textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
                startX = marginX;
                graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
                startY += lineHeightNormal;

                header = "Non Cash Sale";

                textWidth = e.Graphics.MeasureString(header, fontDoubleHeight).Width;
                startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                graphics.DrawString(header, fontDoubleHeight, brush, startX, startY);
                startY += lineHeightDoubleHeight + 4;

            }

            DataTable dtNonCash = dtReport.Tables[1];

            if (dtNonCash != null && dtNonCash.Rows.Count > 0)
            {
                header = "Card Sale";
                decimal bankTotal = 0;

                textWidth = e.Graphics.MeasureString(header, fontNormal).Width;
                startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                graphics.DrawString(header, fontNormal, brush, startX, startY);
                startY += lineHeightNormal;

                foreach (DataRow row in dtNonCash.Rows)
                {
                    startX = marginX;
                    productDetailTailLeft = row["BankName"].ToString();
                    productDetailTailRight = Common.ConvertToStringCurrancy(row["Amount"].ToString());

                    graphics.DrawString(productDetailTailLeft, fontNormal, brush, startX, startY);

                    textWidth = e.Graphics.MeasureString(productDetailTailRight, fontNormal).Width;
                    startX = pageWidth - (marginX * 2) - textWidth;
                    graphics.DrawString(productDetailTailRight, fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;

                    bankTotal += Common.ConvertStringToDecimal(row["Amount"].ToString());
                }

                textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
                startX = marginX;
                graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
                startY += lineHeightNormal;

                productDetailTailRight = Common.ConvertToStringCurrancy(bankTotal.ToString());

                textWidth = e.Graphics.MeasureString(productDetailTailRight, fontNormal).Width;
                startX = pageWidth - (marginX * 2) - textWidth;
                graphics.DrawString(productDetailTailRight, fontNormal, brush, startX, startY);
                startY += lineHeightNormal;
            }

            DataTable dtOther = dtReport.Tables[2];

            if (dtOther != null && dtOther.Rows.Count > 0)
            {
                header = "Other Sale";
                decimal otherTotal = 0;

                textWidth = e.Graphics.MeasureString(header, fontNormal).Width;
                startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                graphics.DrawString(header, fontNormal, brush, startX, startY);
                startY += lineHeightNormal;

                foreach (DataRow row in dtOther.Rows)
                {
                    startX = marginX;
                    productDetailTailLeft = row["PayTypeName"].ToString();
                    productDetailTailRight = Common.ConvertToStringCurrancy(row["Amount"].ToString());

                    graphics.DrawString(productDetailTailLeft, fontNormal, brush, startX, startY);

                    textWidth = e.Graphics.MeasureString(productDetailTailRight, fontNormal).Width;
                    startX = pageWidth - (marginX * 2) - textWidth;
                    graphics.DrawString(productDetailTailRight, fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;

                    otherTotal += Common.ConvertStringToDecimal(row["Amount"].ToString());
                }

                textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
                startX = marginX;
                graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
                startY += lineHeightNormal;

                productDetailTailRight = Common.ConvertToStringCurrancy(otherTotal.ToString());

                textWidth = e.Graphics.MeasureString(productDetailTailRight, fontNormal).Width;
                startX = pageWidth - (marginX * 2) - textWidth;
                graphics.DrawString(productDetailTailRight, fontNormal, brush, startX, startY);
                startY += lineHeightNormal;
            }


            textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
            startX = marginX;
            graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
            startY += lineHeightNormal;

            textWidth = e.Graphics.MeasureString("System By NSoft", fontNormal).Width;
            startX = (pageWidth - (marginX * 2) - textWidth) / 2;
            graphics.DrawString("System By NSoft", fontNormal, brush, startX, startY);
            startY += lineHeightNormal;*/

        }

        private void FrmCounterTranasaction_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tranasactionType == 1)
            {
                Application.Exit();
            }

        }
    }
}
