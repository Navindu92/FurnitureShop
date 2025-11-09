using NSoft.ERP.Domain.General;
using NSoft.ERP.Service.General;
using NSoft.ERP.UI.Windows.Device;
using NSoft.ERP.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSoft.ERP.UI.Windows.Inventory
{
    public partial class FrmPOSCounterTransaction : Form
    {
        int transactionType; // 1-Counter Open /2-Counter Close /3-X Reading
        public int transactionStatus = 1; //1-Log Off 2-Log On
        CounterTransaction counterTransaction;
        Counter counter;
        List<FloatMaster> floatMasterList = new List<FloatMaster>();
        public FrmPOSCounterTransaction()
        {
            InitializeComponent();
        }
        public FrmPOSCounterTransaction(int transactionType)
        {
            try
            {
                this.transactionType = transactionType;
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void FrmPOSCounterTransaction_Load(object sender, EventArgs e)
        {
            try
            {
                if (transactionType == 1)
                {
                    this.Text = "Counter Open";
                    lblMessage.Text = "Enter Counter Open";

                    POSPrinter.PrintText(POSPrinter.eInitialize + POSPrinter.eDrawer);
                }
                else if (transactionType == 2)
                {
                    this.Text = "Z Reading";
                    lblMessage.Text = "Enter Cash In Hand";
                }
                else if (transactionType == 3)
                {
                    this.Text = "X Reading";
                    lblMessage.Text = "Enter Cash In Hand";
                }

                dgvFloat.AutoGenerateColumns = false;

                FloatService floatService = new FloatService();

                floatMasterList = floatService.GetAllActiveFloatMaster();

                dgvFloat.DataSource = floatMasterList.ToList();
                dgvFloat.Refresh();

                this.ActiveControl = dgvFloat;
                dgvFloat.Focus();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {


            if (dgvFloat.RowCount > 0)
            {
                if (dgvFloat["Float", dgvFloat.CurrentCell.RowIndex].Value.ToString() == string.Empty) { return; }
                dgvFloat["Count", dgvFloat.CurrentCell.RowIndex].Value += btn1.Text.Trim();
                CalculateAmount();
            }
            //  txtAmount.Text += btn1.Text.Trim();



        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (dgvFloat.RowCount > 0)
            {
                if (dgvFloat["Float", dgvFloat.CurrentCell.RowIndex].Value.ToString() == string.Empty) { return; }
                dgvFloat["Count", dgvFloat.CurrentCell.RowIndex].Value += btn2.Text.Trim();
                CalculateAmount();
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (dgvFloat.RowCount > 0)
            {
                if (dgvFloat["Float", dgvFloat.CurrentCell.RowIndex].Value.ToString() == string.Empty) { return; }
                dgvFloat["Count", dgvFloat.CurrentCell.RowIndex].Value += btn3.Text.Trim();
                CalculateAmount();
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (dgvFloat.RowCount > 0)
            {
                if (dgvFloat["Float", dgvFloat.CurrentCell.RowIndex].Value.ToString() == string.Empty) { return; }
                dgvFloat["Count", dgvFloat.CurrentCell.RowIndex].Value += btn4.Text.Trim();
                CalculateAmount();
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (dgvFloat.RowCount > 0)
            {
                if (dgvFloat["Float", dgvFloat.CurrentCell.RowIndex].Value.ToString() == string.Empty) { return; }
                dgvFloat["Count", dgvFloat.CurrentCell.RowIndex].Value += btn5.Text.Trim();
                CalculateAmount();
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (dgvFloat.RowCount > 0)
            {
                if (dgvFloat["Float", dgvFloat.CurrentCell.RowIndex].Value.ToString() == string.Empty) { return; }
                dgvFloat["Count", dgvFloat.CurrentCell.RowIndex].Value += btn6.Text.Trim();
                CalculateAmount();
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (dgvFloat.RowCount > 0)
            {
                if (dgvFloat["Float", dgvFloat.CurrentCell.RowIndex].Value.ToString() == string.Empty) { return; }
                dgvFloat["Count", dgvFloat.CurrentCell.RowIndex].Value += btn7.Text.Trim();
                CalculateAmount();
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (dgvFloat.RowCount > 0)
            {
                if (dgvFloat["Float", dgvFloat.CurrentCell.RowIndex].Value.ToString() == string.Empty) { return; }
                dgvFloat["Count", dgvFloat.CurrentCell.RowIndex].Value += btn8.Text.Trim();
                CalculateAmount();
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (dgvFloat.RowCount > 0)
            {
                if (dgvFloat["Float", dgvFloat.CurrentCell.RowIndex].Value.ToString() == string.Empty) { return; }
                dgvFloat["Count", dgvFloat.CurrentCell.RowIndex].Value += btn9.Text.Trim();
                CalculateAmount();
            }
        }

        private void btnDoubleZero_Click(object sender, EventArgs e)
        {
            if (dgvFloat.RowCount > 0)
            {
                if (dgvFloat["Float", dgvFloat.CurrentCell.RowIndex].Value.ToString() == string.Empty) { return; }
                dgvFloat["Count", dgvFloat.CurrentCell.RowIndex].Value += btnDoubleZero.Text.Trim();
                CalculateAmount();
            }
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            if (dgvFloat.RowCount > 0)
            {
                if (dgvFloat["Float", dgvFloat.CurrentCell.RowIndex].Value.ToString() == string.Empty) { return; }
                dgvFloat["Count", dgvFloat.CurrentCell.RowIndex].Value += btnZero.Text.Trim();
                CalculateAmount();
            }
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (dgvFloat.RowCount > 0)
            {
                if (dgvFloat["Float", dgvFloat.CurrentCell.RowIndex].Value.ToString() == string.Empty) { return; }
                if (dgvFloat["Float", dgvFloat.CurrentCell.RowIndex].Value.ToString().Contains('.')) { return; }
                //dgvFloat["Count", dgvFloat.CurrentCell.RowIndex].Value += btnDot.Text.Trim();
                CalculateAmount();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            transactionStatus = 1;
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                string amountText = string.Empty;

                if (dgvFloat.RowCount > 0)
                {
                    if (dgvFloat["Float", dgvFloat.CurrentCell.RowIndex].Value.ToString() == string.Empty) { return; }
                    amountText = dgvFloat["Count", dgvFloat.CurrentCell.RowIndex].Value.ToString();
                }

                if (amountText.Length > 1)
                {
                    amountText = amountText.Substring(0, amountText.Length - 1);
                }
                else
                {
                    amountText = "0";
                }

                dgvFloat["Count", dgvFloat.CurrentCell.RowIndex].Value = amountText;
                lblMessage.Select();

                lblMessage.ForeColor = Color.Black;

                if (transactionType == 1)
                {
                    lblMessage.Text = "Enter Counter Open";
                }
                else if (transactionType == 2)
                {
                    lblMessage.Text = "Enter Cash In Hand";
                }
                if (transactionType == 3)
                {
                    lblMessage.Text = "Enter Cash In Hand";
                }

                CalculateAmount();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void FrmPOSCounterTransaction_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    btnClose.PerformClick();
                }
                else if (e.KeyCode == Keys.NumPad9 || e.KeyCode == Keys.D9)
                {
                    btn9.PerformClick();
                }
                else if (e.KeyCode == Keys.NumPad8 || e.KeyCode == Keys.D8)
                {
                    btn8.PerformClick();
                }
                else if (e.KeyCode == Keys.NumPad7 || e.KeyCode == Keys.D7)
                {
                    btn7.PerformClick();
                }
                else if (e.KeyCode == Keys.NumPad6 || e.KeyCode == Keys.D6)
                {
                    btn6.PerformClick();
                }
                else if (e.KeyCode == Keys.NumPad5 || e.KeyCode == Keys.D5)
                {
                    btn5.PerformClick();
                }
                else if (e.KeyCode == Keys.NumPad4 || e.KeyCode == Keys.D4)
                {
                    btn4.PerformClick();
                }
                else if (e.KeyCode == Keys.NumPad3 || e.KeyCode == Keys.D3)
                {
                    btn3.PerformClick();
                }
                else if (e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.D2)
                {
                    btn2.PerformClick();
                }
                else if (e.KeyCode == Keys.NumPad1 || e.KeyCode == Keys.D1)
                {
                    btn1.PerformClick();
                }
                else if (e.KeyCode == Keys.NumPad0 || e.KeyCode == Keys.D0)
                {
                    btnZero.PerformClick();
                }
                else if (e.KeyCode == Keys.Decimal)
                {
                    btnDot.PerformClick();
                }
                else if (e.KeyCode == Keys.Back)
                {
                    btnClear.PerformClick();
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    btnEnter.PerformClick();
                }
                else if (e.KeyCode == Keys.Delete)
                {
                    if (dgvFloat.RowCount > 0)
                    {
                        if (dgvFloat["Float", dgvFloat.CurrentCell.RowIndex].Value.ToString() == string.Empty) { return; }
                        dgvFloat["Count", dgvFloat.CurrentCell.RowIndex].Value = "0";
                        CalculateAmount();
                    }
                }
                else if (e.KeyCode == Keys.Back)
                {
                    btnClear.PerformClick();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAmount.Text == string.Empty)
                {
                    lblMessage.Text = "Invalid Amount";
                    lblMessage.ForeColor = Color.Red;
                    return;
                }

                FrmPOSTransactionConfirmation frmPOSTransactionConfirmation = new FrmPOSTransactionConfirmation();
                frmPOSTransactionConfirmation.ShowDialog();

                if (!frmPOSTransactionConfirmation.isConfirm)
                {
                    return;
                }

                string printerStaus = "";
                bool isPrinterAvailable = POSPrinter.CheckPrinterAvailability(out printerStaus);

                if (isPrinterAvailable)
                {
                    SaveCounterTransaction();
                }
                else
                {
                    FrmNoPrinter frmNoPrinter = new FrmNoPrinter(printerStaus);
                    frmNoPrinter.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void SaveCounterTransaction()
        {
            try
            {
                CounterService counterService = new CounterService();
                counter = new Counter();
                counter = counterService.GetCounterByCounterNoAndLocationID(Common.CounterNo, Common.LoggedLocationID);

                if (counterTransaction == null)
                {
                    counterTransaction = new CounterTransaction();
                }

                counterTransaction.LocationID = Common.LoggedLocationID;
                counterTransaction.TransactionDate = DateTime.Now.Date;
                counterTransaction.TransactionTypeID = transactionType;
                counterTransaction.CounterNo = Common.CounterNo;
                counterTransaction.Amount = Common.ConvertStringToDecimal(txtAmount.Text.Trim().ToString());
                counterTransaction.UserID = Common.LoggedUserID;
                counterTransaction.Zno = counter.Zno;
                counterTransaction.ZDate = DateTime.Now.Date;

                counterService.AddCounterTransaction(counterTransaction, floatMasterList);

                if (transactionType == 1)
                {
                    PrintCounterOpen();
                    transactionStatus = 2;
                }
                else if (transactionType == 2)
                {
                    PrintXReading();
                    transactionStatus = 1;
                }
                else if (transactionType == 3)
                {
                    PrintXReading();
                    transactionStatus = 2;
                }

                this.Close();

                LogWritter.WriteEventLog(this.Name, this.Text, LogWritter.EventType.Save);

            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void pd_PrintCounterOpen(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            float startX = 0;
            float startY = 20;
            float marginX = 0;

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
            float textHeight = 0;
            float printWidth = 0;

            pageWidth = POSPrinter.printerWidth;
            marginX = POSPrinter.marginX;

            printWidth = pageWidth - (marginX * 2);

            if (POSPrinter.header1 != string.Empty)
            {
                textWidth = e.Graphics.MeasureString(POSPrinter.header1.Trim(), fontDoubleHeight).Width;
                startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                graphics.DrawString(POSPrinter.header1.Trim(), fontDoubleHeight, brush, startX, startY);
                startY += lineHeightDoubleHeight;
            }

            if (POSPrinter.header2 != string.Empty)
            {
                textWidth = e.Graphics.MeasureString(POSPrinter.header2.Trim(), fontNormal).Width;
                startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                graphics.DrawString(POSPrinter.header2.Trim(), fontNormal, brush, startX, startY);
                startY += lineHeightNormal;
            }

            if (POSPrinter.header3 != string.Empty)
            {
                textWidth = e.Graphics.MeasureString(POSPrinter.header3.Trim(), fontNormal).Width;
                startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                graphics.DrawString(POSPrinter.header3.Trim(), fontNormal, brush, startX, startY);
                startY += lineHeightNormal;
            }

            if (POSPrinter.header4 != string.Empty)
            {
                textWidth = e.Graphics.MeasureString(POSPrinter.header4.Trim(), fontNormal).Width;
                startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                graphics.DrawString(POSPrinter.header4.Trim(), fontNormal, brush, startX, startY);
                startY += lineHeightNormal;
            }

            if (POSPrinter.header5 != string.Empty)
            {
                textWidth = e.Graphics.MeasureString(POSPrinter.header5.Trim(), fontNormal).Width;
                startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                graphics.DrawString(POSPrinter.header5.Trim(), fontNormal, brush, startX, startY);
                startY += lineHeightNormal;
            }


            string dashLine = new string('-', POSPrinter.dashWidth);

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

            DataTable dtCounterFloat = new DataTable();
            CounterService counterService = new CounterService();

            dtCounterFloat = counterService.GetCounterFloatForCounterOpen(counter, Common.LoggedUserID);

            if (dtCounterFloat != null && dtCounterFloat.Rows.Count > 0)
            {
                foreach (DataRow row in dtCounterFloat.Rows)
                {
                    startX = marginX;

                    string floatValue = row["FloatValue"].ToString();
                    string floatCount = row["FloatCount"].ToString();
                    string floatAmount = Common.ConvertToStringCurrancy(row["FloatAmount"].ToString());

                    float floatCountX = 130;

                    graphics.DrawString(floatValue, fontNormal, brush, startX, startY);

                    textWidth = e.Graphics.MeasureString(floatAmount, fontNormal).Width;
                    startX = pageWidth - (marginX * 2) - textWidth;
                    graphics.DrawString(floatAmount, fontNormal, brush, startX, startY);

                    textWidth = e.Graphics.MeasureString(floatCount, fontNormal).Width;
                    startX = pageWidth - (marginX * 2) - floatCountX - textWidth;
                    graphics.DrawString(floatCount, fontNormal, brush, startX, startY);

                    startY += lineHeightNormal;

                }
            }

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

        }
        private void pd_PrintXReding(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
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

            pageWidth = POSPrinter.printerWidth;
            marginX = POSPrinter.marginX;

            printWidth = pageWidth - (marginX * 2);


            if (POSPrinter.header1 != string.Empty)
            {
                textWidth = e.Graphics.MeasureString(POSPrinter.header1.Trim(), fontDoubleHeight).Width;
                startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                graphics.DrawString(POSPrinter.header1.Trim(), fontDoubleHeight, brush, startX, startY);
                startY += lineHeightDoubleHeight;
            }

            if (POSPrinter.header2 != string.Empty)
            {
                textWidth = e.Graphics.MeasureString(POSPrinter.header2.Trim(), fontNormal).Width;
                startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                graphics.DrawString(POSPrinter.header2.Trim(), fontNormal, brush, startX, startY);
                startY += lineHeightNormal;
            }

            if (POSPrinter.header3 != string.Empty)
            {
                textWidth = e.Graphics.MeasureString(POSPrinter.header3.Trim(), fontNormal).Width;
                startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                graphics.DrawString(POSPrinter.header3.Trim(), fontNormal, brush, startX, startY);
                startY += lineHeightNormal;
            }

            if (POSPrinter.header4 != string.Empty)
            {
                textWidth = e.Graphics.MeasureString(POSPrinter.header4.Trim(), fontNormal).Width;
                startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                graphics.DrawString(POSPrinter.header4.Trim(), fontNormal, brush, startX, startY);
                startY += lineHeightNormal;
            }

            if (POSPrinter.header5 != string.Empty)
            {
                textWidth = e.Graphics.MeasureString(POSPrinter.header5.Trim(), fontNormal).Width;
                startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                graphics.DrawString(POSPrinter.header5.Trim(), fontNormal, brush, startX, startY);
                startY += lineHeightNormal;
            }


            string dashLine = new string('-', POSPrinter.dashWidth);

            textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
            startX = marginX;
            graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
            startY += lineHeightNormal;

            string header = string.Empty;

            if (transactionType == 2)
            {
                header = "Z Reading";
            }
            else if (transactionType == 3)
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

            if (transactionType == 2)
            {
                graphics.DrawString("ZNo : " + counter.Zno, fontNormal, brush, startX, startY);
                startY += lineHeightNormal;
            }
            else if (transactionType == 3)
            {
                graphics.DrawString("XNo : " + counter.Xno, fontNormal, brush, startX, startY);
                startY += lineHeightNormal;
            }

            textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
            startX = marginX;
            graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
            startY += lineHeightNormal;

            CounterService counterService = new CounterService();

            DataSet dtReport = counterService.GetCounterSummary(counter.LocationID, counter.CounterNo, transactionType, DateTime.Now.Date, DateTime.Now.Date, counterTransaction.Amount);

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
                    startY += 2*lineHeightNormal;
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

            DataTable dtSalesmanWise = dtReport.Tables[3];

            if (dtSalesmanWise != null && dtSalesmanWise.Rows.Count > 0)
            {
                header = "Salesman Wise Sale";
                decimal salesmanTotal = 0;

                textWidth = e.Graphics.MeasureString(header, fontNormal).Width;
                startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                graphics.DrawString(header, fontNormal, brush, startX, startY);
                startY += 2*lineHeightNormal;

                foreach (DataRow row in dtSalesmanWise.Rows)
                {
                    startX = marginX;
                    productDetailTailLeft = row["Salesmanname"].ToString();
                    productDetailTailRight = Common.ConvertToStringCurrancy(row["NetAmount"].ToString());

                    graphics.DrawString(productDetailTailLeft, fontNormal, brush, startX, startY);

                    textWidth = e.Graphics.MeasureString(productDetailTailRight, fontNormal).Width;
                    startX = pageWidth - (marginX * 2) - textWidth;
                    graphics.DrawString(productDetailTailRight, fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;

                    salesmanTotal += Common.ConvertStringToDecimal(row["NetAmount"].ToString());
                }

                textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
                startX = marginX;
                graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
                startY += lineHeightNormal;

                productDetailTailRight = Common.ConvertToStringCurrancy(salesmanTotal.ToString());

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
            startY += lineHeightNormal;

        }
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

        private void FrmPOSCounterTransaction_FormClosing(object sender, FormClosingEventArgs e)
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

        private void CalculateAmount()
        {
            try
            {
                if (dgvFloat.RowCount > 0)
                {
                    if (dgvFloat["Float", dgvFloat.CurrentCell.RowIndex].Value.ToString() == string.Empty) { return; }

                    long floatValue = Common.ConvertStringToLong(dgvFloat["Float", dgvFloat.CurrentCell.RowIndex].Value.ToString());
                    long floatCount = Common.ConvertStringToLong(dgvFloat["Count", dgvFloat.CurrentCell.RowIndex].Value.ToString());

                    long floatAmount = (floatValue * floatCount);

                    dgvFloat["FloatAmount", dgvFloat.CurrentCell.RowIndex].Value = floatAmount.ToString();

                    dgvFloat.Focus();

                    List<FloatMaster> floatMasterList = new List<FloatMaster>();
                    floatMasterList = (List<FloatMaster>)dgvFloat.DataSource;

                    long totalFloatAmount = floatMasterList.Sum(s => s.FloatAmount);

                    txtAmount.Text = totalFloatAmount.ToString();
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
