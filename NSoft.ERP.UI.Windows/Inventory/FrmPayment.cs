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
using NSoft.ERP.Service.General;
using NSoft.ERP.Domain.General;
using NSoft.ERP.Domain.Inventory;
using NSoft.ERP.Service.Inventory;
using System.Drawing.Printing;
using NSoft.ERP.UI.Windows.Device;
using NSoft.ERP.Domain.CRM;
using NSoft.ERP.Service.CRM;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace NSoft.ERP.UI.Windows.Inventory
{
    public partial class FrmPayment : Form
    {
        public FrmPayment()
        {
            InitializeComponent();
        }

        string totalAmount = string.Empty;


        public List<SalesPayment> salesPaymentList;


        FormInfo formInfo;
        SalesMain salesMain;
        List<SalesTemp> salesSubList;
        string documentNo;
        Counter counter;

        bool isEnterPayment = false;

        public bool isPaymentComplete = false;
        private bool isRePrint = false;
        public LoyaltyCustomer loyaltyCustomer = null;
        public Salesman salesman = null;
        public FrmPayment(string totalAmount, FormInfo formInfo, SalesMain salesMain, List<SalesTemp> salesSubList, Counter counter, LoyaltyCustomer loyaltyCustomer, Salesman salesman)
        {
            InitializeComponent();
            this.totalAmount = totalAmount.ToString();
            this.formInfo = formInfo;
            this.salesMain = salesMain;
            this.salesSubList = salesSubList;
            this.counter = counter;
            this.isEnterPayment = false;
            this.isRePrint = false;
            this.loyaltyCustomer = loyaltyCustomer;
            this.salesman = salesman;
        }
        public FrmPayment(string documentNo, FormInfo formInfo, Counter counter)
        {
            this.formInfo = formInfo;
            this.documentNo = documentNo;
            this.counter = counter;
            this.isRePrint = true;
        }

        private void FrmPayment_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    if (usrPaymentDetailEnter1.Visible)
                    {
                        usrPaymentDetail1.Visible = true;
                        usrPaymentDetailEnter1.Visible = false;
                        grpPayTypes.Enabled = true;
                        btnCash.Focus();
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else if (e.KeyCode == Keys.F5)
                {
                    if (usrPaymentDetail1.dgvPayment.RowCount != 0 && isEnterPayment == true)
                    {
                        return;
                    }
                    FrmDiscount frmDiscount = new FrmDiscount(1, Common.ConvertStringToDecimal(lblTotalAmount.Text.Trim()), 2);
                    frmDiscount.ShowDialog();
                    lblDiscount.Text = Common.ConvertToStringCurrancy(frmDiscount.discountAmount.ToString());
                    lblDiscountPercentage.Text = Common.ConvertToStringCurrancy(frmDiscount.discountPercentage.ToString());
                    Summarize();
                }
                else if (e.KeyCode == Keys.F6)
                {
                    if (usrPaymentDetail1.dgvPayment.RowCount != 0 && isEnterPayment == true)
                    {
                        return;
                    }
                    FrmDiscount frmDiscount = new FrmDiscount(2, Common.ConvertStringToDecimal(lblTotalAmount.Text.Trim()), 2);
                    frmDiscount.ShowDialog();
                    lblDiscount.Text = Common.ConvertToStringCurrancy(frmDiscount.discountAmount.ToString());
                    lblDiscountPercentage.Text = Common.ConvertToStringCurrancy(frmDiscount.discountPercentage.ToString());
                    Summarize();
                }
                if (isPaymentComplete)
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

        private void FrmPayment_Load(object sender, EventArgs e)
        {
            try
            {
                btnF5.BackgroundImage = Properties.Resources.l1F5;
                btnF6.BackgroundImage = Properties.Resources.l1F6;

                usrPaymentDetail1.dgvPayment.AutoGenerateColumns = false;

                salesPaymentList = new List<SalesPayment>();

                lblTotalAmount.Text = totalAmount.ToString();
                lblDueAmount.Text = totalAmount.ToString();
                lblNetAmount.Text = totalAmount.ToString();
                lblDiscountPercentage.Text = Common.ConvertToStringCurrancy("0");
                lblDiscount.Text = Common.ConvertToStringCurrancy("0");
                lblPaidAmount.Text = Common.ConvertToStringCurrancy("0");
                lblBalance.Text = Common.ConvertToStringCurrancy("0");

                Common.ReadOnlyTextBox(true, usrPaymentDetailEnter1.txtPayAmount, usrPaymentDetailEnter1.txtReferenceNo);

                if (CustomerDisplay.isDisplayConnected)
                {
                    string tempSpace;
                    string subtotalAmount = Common.ConvertToStringCurrancy(lblTotalAmount.Text.Trim());
                    string totalheader = "SUB TOTAL";
                    tempSpace = new string(' ', CustomerDisplay.displayLength - (subtotalAmount.Length + totalheader.Length));

                    CustomerDisplay.DisplayText(CustomerDisplay.eClear);
                    CustomerDisplay.DisplayText(totalheader + tempSpace + subtotalAmount, CustomerDisplay.DisplayAlignment.Left);
                }

                usrPaymentDetail1.Visible = true;
                usrPaymentDetailEnter1.Visible = false;

                this.ActiveControl = btnCash;
                btnCash.Focus();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void Summarize()
        {
            try
            {
                decimal total = 0;
                decimal dueAmount = 0;
                decimal paidAmount = 0;
                decimal balanceAmount = 0;

                decimal discountAmount = 0;

                discountAmount = Common.ConvertStringToDecimal(lblDiscount.Text.Trim());

                total = Common.ConvertStringToDecimal(lblTotalAmount.Text.Trim()) - discountAmount;
                paidAmount = salesPaymentList.Sum(x => x.Amount);

                dueAmount = (total - paidAmount);

                balanceAmount = (paidAmount - total);

                lblPaidAmount.Text = Common.ConvertToStringCurrancy(paidAmount.ToString());
                lblNetAmount.Text = Common.ConvertToStringCurrancy(total.ToString());


                if (CustomerDisplay.isDisplayConnected)
                {
                    string tempSpace;

                    string subtotalAmount = Common.ConvertToStringCurrancy(lblTotalAmount.Text.Trim());
                    string totalheader = "SUB TOTAL";
                    tempSpace = new string(' ', CustomerDisplay.displayLength - (subtotalAmount.Length + totalheader.Length));

                    CustomerDisplay.DisplayText(CustomerDisplay.eClear);
                    CustomerDisplay.DisplayText(totalheader + tempSpace + subtotalAmount, CustomerDisplay.DisplayAlignment.Left);

                    string displayPaidAmount = Common.ConvertToStringCurrancy(lblPaidAmount.Text.Trim());
                    string paidHeader = "PAID";
                    tempSpace = new string(' ', CustomerDisplay.displayLength - (displayPaidAmount.Length + paidHeader.Length));

                    CustomerDisplay.DisplayText(paidHeader + tempSpace + displayPaidAmount, CustomerDisplay.DisplayAlignment.Left);
                }


                if (dueAmount >= 0)
                {
                    lblDueAmount.Text = Common.ConvertToStringCurrancy(dueAmount.ToString());
                }
                else
                {
                    lblDueAmount.Text = Common.ConvertToStringCurrancy("0");
                }

                if (balanceAmount >= 0)
                {
                    lblBalance.Text = Common.ConvertToStringCurrancy(balanceAmount.ToString());

                    salesMain.DiscountAmount = Common.ConvertStringToDecimal(lblDiscount.Text.Trim());
                    salesMain.DiscountPercentage = Common.ConvertStringToDecimal(lblDiscountPercentage.Text.Trim());
                    salesMain.NetAmount = Common.ConvertStringToDecimal(lblNetAmount.Text.Trim());
                    salesMain.BalanceAmount = Common.ConvertStringToDecimal(lblBalance.Text.Trim());

                    if (salesman != null)
                    {
                        salesMain.SalesmanID = this.salesman.SalesmanID;
                        salesMain.CommissionRate = this.salesman.CommissionRate;
                        salesMain.CommissionAmount = (salesMain.NetAmount * salesman.CommissionRate) / 100;
                    }

                    SalesService salesService = new SalesService();

                    //string printerStaus = "";
                    //bool isPrinterAvailable = POSPrinter.CheckPrinterAvailability(out printerStaus);

                    //if (isPrinterAvailable)
                    //{
                        if (salesService.Save(formInfo, salesMain, salesSubList, salesPaymentList, loyaltyCustomer, out documentNo, counter))
                        {
                            isPaymentComplete = true;

                            PrintInvoice();

                            if (CustomerDisplay.isDisplayConnected)
                            {
                                string tempSpace;

                                string subtotalAmount = Common.ConvertToStringCurrancy(lblTotalAmount.Text.Trim());
                                string totalheader = "SUB TOTAL";
                                tempSpace = new string(' ', CustomerDisplay.displayLength - (subtotalAmount.Length + totalheader.Length));

                                CustomerDisplay.DisplayText(CustomerDisplay.eClear);
                                CustomerDisplay.DisplayText(totalheader + tempSpace + subtotalAmount, CustomerDisplay.DisplayAlignment.Left);

                                string displayBalanceAmount = Common.ConvertToStringCurrancy(lblBalance.Text.Trim());
                                string balanceHeader = "BALANCE";
                                tempSpace = new string(' ', CustomerDisplay.displayLength - (displayBalanceAmount.Length + balanceHeader.Length));

                                CustomerDisplay.DisplayText(balanceHeader + tempSpace + displayBalanceAmount, CustomerDisplay.DisplayAlignment.Left);
                            }

                    }
                    //}
                    //else
                    //{
                    //    FrmNoPrinter frmNoPrinter = new FrmNoPrinter(printerStaus);
                    //    frmNoPrinter.ShowDialog();
                    //}
                }
                else
                {
                    lblBalance.Text = Common.ConvertToStringCurrancy("0");
                }

            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        //private void cmbPayType_KeyDown(object sender, KeyEventArgs e)
        //{
        //    try
        //    {
        //        if (e.KeyCode == Keys.Enter)
        //        {
        //            Common.EnableComboBox(false, cmbPayType);

        //            if (cmbPayType.SelectedIndex == 0)
        //            {
        //                Common.ReadOnlyTextBox(false, txtPayAmount);
        //                txtPayAmount.Text = lblDueAmount.Text;
        //                txtPayAmount.Focus();
        //                txtPayAmount.SelectAll();
        //            }
        //            else if (cmbPayType.SelectedIndex == 1)
        //            {
        //                txtPayAmount.Text = lblDueAmount.Text;
        //                FrmBankSearch frmBankSearch = new FrmBankSearch();
        //                frmBankSearch.ShowDialog();

        //                if (frmBankSearch.isBankSelected)
        //                {
        //                    bankId = frmBankSearch.selectedBankId;
        //                    Common.ReadOnlyTextBox(false, txtReferenceNo);
        //                    txtReferenceNo.Focus();
        //                }
        //            }
        //            else if (cmbPayType.SelectedIndex == 2)
        //            {
        //                txtPayAmount.Text = lblDueAmount.Text;
        //                Common.ReadOnlyTextBox(false, txtReferenceNo);
        //                txtReferenceNo.Focus();
        //            }
        //        }
        //        else
        //        {
        //            cmbPayType.Focus();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
        //        SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
        //    }
        //}

        public void UpdatePaymentGrid(SalesPayment salesPaymentTemp)
        {
            try
            {
                SalesService salesService = new SalesService();
                salesPaymentList = salesService.GetUpdatedSalesPaymentTempList(salesPaymentList, salesPaymentTemp);
                usrPaymentDetail1.dgvPayment.DataSource = salesPaymentList.ToList();
                usrPaymentDetail1.dgvPayment.Refresh();

                Summarize();
                usrPaymentDetailEnter1.ClearLine();
                isEnterPayment = true;

            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtPayAmount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if (e.KeyCode == Keys.Enter)
                //{
                //    if (cmbPayType.SelectedIndex == 1)
                //    {
                //        if (Common.ConvertStringToDecimal(txtPayAmount.Text.Trim()) > Common.ConvertStringToDecimal(lblDueAmount.Text.Trim()))
                //        {
                //            SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Error, this.Text, "Invalid Payment Amount By Credit Card.");
                //            txtPayAmount.Focus();
                //            return;
                //        }
                ////    }
                //    salesPayment = new SalesPayment();
                //    UpdatePaymentGrid(salesPayment);
                //}

            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        public void PrintInvoice()
        {
            //if (!isRePrint)
            //{
            //    POSPrinter.PrintText(POSPrinter.eInitialize + POSPrinter.eDrawer);
            //}

            //if (counter.IsPopupPrintconfirmationConfirmation)
            //{
            //    FrmPOSPrintConfirmation frmPOSPrintConfirmation = new FrmPOSPrintConfirmation();
            //    frmPOSPrintConfirmation.ShowDialog();

            //    if (!frmPOSPrintConfirmation.isConfirm)
            //    {
            //        return;
            //    }
            //}
            //PrintDocument printInvoice = new PrintDocument();
            //printInvoice.PrinterSettings.PrinterName = POSPrinter.printerName;

            //printInvoice.PrintPage += new PrintPageEventHandler(pd_PrintInvoice);

            //PrintController printController = new StandardPrintController();
            //printInvoice.PrintController = printController;

            //printInvoice.Print();

            ReportDocument rpt = new ReportDocument();

            string rptPath = Path.Combine(Application.StartupPath, "Reports", "RptInvoice.rpt");

            rpt.Load(rptPath);

            DataTable dtInvoiceDetails = new DataTable();
            SalesService salesService = new SalesService();

            dtInvoiceDetails = salesService.GetInvoicePrint(documentNo);
            rpt.SetDataSource(dtInvoiceDetails);

            if (isRePrint)
            {
                rpt.DataDefinition.FormulaFields["DocumentStatus"].Text = "" + 0 + "";
            }

            string defaultPrinter = new PrinterSettings().PrinterName;

            rpt.PrintOptions.PrinterName = defaultPrinter;
            rpt.PrintToPrinter(1, false, 0, 0);
        }

        private void pd_PrintInvoice(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            float startX = 0;
            float startY = 20;
            float marginX = 0;
            float printWidth = 0;

            Font fontHeader = new Font("POSNormal", 12.5f, FontStyle.Bold);
            Font fontNormal = new Font("POSNormal", 9.5f, FontStyle.Bold);
            // Font fontNormalSinhala = new Font("POSNormal", 7.5f, FontStyle.Bold);
            Font fontNormalSinhala = new Font("FMDerana", 12.5f, FontStyle.Regular);
            Font fontDoubleHeight = new Font("POSDouble", 9.5f, FontStyle.Bold);

            float lineHeightHeader = fontHeader.GetHeight();
            float lineHeightNormal = fontNormal.GetHeight();
            float lineHeightNormalSinhala = fontNormalSinhala.GetHeight();
            float lineHeightDoubleHeight = fontDoubleHeight.GetHeight() + 2;

            Brush brush = Brushes.Black;

            float pageWidth = 0;//e.PageSettings.PrintableArea.Width;
            float textWidth = 0;
            float textHeight = 0;

            decimal totalDiscount = 0;

            int noOfLines = 0;


            if (counter != null)
            {
                pageWidth = POSPrinter.printerWidth;
                marginX = POSPrinter.marginX;
                printWidth = pageWidth - (marginX * 2);

                if (counter.IsPrintLogo)
                {
                    Image img = Image.FromFile(counter.LogoPath.Trim());
                    e.Graphics.DrawImage(img, (pageWidth - 250) / 2, startY, 250, 100);
                    startY += 100;
                }

                if (counter.Header1 != string.Empty)
                {
                    textWidth = e.Graphics.MeasureString(counter.Header1.Trim(), fontHeader).Width;
                    startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                    graphics.DrawString(counter.Header1.Trim(), fontHeader, brush, startX, startY);
                    startY += lineHeightHeader;
                }

                if (counter.Header2 != string.Empty)
                {
                    textWidth = e.Graphics.MeasureString(counter.Header2.Trim(), fontNormal).Width;
                    startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                    graphics.DrawString(counter.Header2.Trim(), fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;
                }

                if (counter.Header3 != string.Empty)
                {
                    textWidth = e.Graphics.MeasureString(counter.Header3.Trim(), fontNormal).Width;
                    startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                    graphics.DrawString(counter.Header3.Trim(), fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;
                }

                if (counter.Header4 != string.Empty)
                {
                    textWidth = e.Graphics.MeasureString(counter.Header4.Trim(), fontNormal).Width;
                    startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                    graphics.DrawString(counter.Header4.Trim(), fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;
                }

                if (counter.Header5 != string.Empty)
                {
                    textWidth = e.Graphics.MeasureString(counter.Header5.Trim(), fontNormal).Width;
                    startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                    graphics.DrawString(counter.Header5.Trim(), fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;
                }

                string dashLine = new string('-', (int)counter.DashWidth);

                textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
                startX = marginX;
                graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
                startY += lineHeightNormal;

                SalesService salesService = new SalesService();
                salesMain = new SalesMain();

                salesMain = salesService.GetAllSalesMainByDocumentNo(documentNo);
                if (salesMain != null)
                {
                    string documentNoHeader = string.Empty;

                    if (salesMain.DocumentID == formInfo.DocumentID)
                    {
                        documentNoHeader = "Invoice No :  ";
                    }
                    else
                    {
                        documentNoHeader = "Return No :  ";
                    }

                    startX = marginX;
                    graphics.DrawString(documentNoHeader + documentNo.Trim(), fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;

                    graphics.DrawString("Date : " + salesMain.DocumentDate.ToString("dd-MMM-yyyy"), fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;

                    graphics.DrawString("Staff : " + Common.LoggedUserName.Trim(), fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;

                    graphics.DrawString("Location : " + Common.LoggedLocation.Trim(), fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;

                    textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
                    startX = marginX;
                    graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;

                    if (salesMain.DocumentID != formInfo.DocumentID)
                    {
                        textWidth = e.Graphics.MeasureString("Sale Return", fontHeader).Width;
                        startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                        graphics.DrawString("Sale Return", fontHeader, brush, startX, startY);
                        startY += lineHeightHeader;

                        textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
                        startX = marginX;
                        graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
                        startY += lineHeightNormal;
                    }

                    string reprint = "Reprinted";

                    if (isRePrint)
                    {
                        textWidth = e.Graphics.MeasureString(reprint.Trim(), fontHeader).Width;
                        startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                        graphics.DrawString(reprint.Trim(), fontHeader, brush, startX, startY);
                        startY += lineHeightHeader;

                        textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
                        startX = marginX;
                        graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
                        startY += lineHeightNormal;
                    }

                    startX = marginX;

                    string productDetailTailLeft = "#Item   Price   Qty";
                    string productDetailTailRight = "Amount";

                    graphics.DrawString(productDetailTailLeft, fontNormal, brush, startX, startY);

                    textWidth = e.Graphics.MeasureString(productDetailTailRight, fontNormal).Width;
                    startX = pageWidth - (marginX * 2) - textWidth;
                    graphics.DrawString(productDetailTailRight, fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;

                    textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
                    startX = marginX;
                    graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;

                    DataTable dtSubDetails = new DataTable();
                    dtSubDetails = salesService.GetAllSalesSubBySalesMainID(salesMain.SalesMainID);

                    DataRow lastRow = dtSubDetails.Rows[dtSubDetails.Rows.Count - 1];

                    if (dtSubDetails != null && dtSubDetails.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtSubDetails.Rows)
                        {
                            startX = marginX;

                            string itemName = string.Empty;

                            if (counter.IsPrintSinhala)
                            {
                                if (row["SinhalaName"].ToString() != string.Empty)
                                {
                                    //itemName = row["LineNo"].ToString() + "." + row["SinhalaName"].ToString();

                                    itemName = row["LineNo"].ToString() + " ' " + row["SinhalaName"].ToString();

                                    textWidth = e.Graphics.MeasureString(itemName, fontNormalSinhala).Width;

                                    noOfLines = (int)(textWidth / printWidth);

                                    textHeight = lineHeightNormalSinhala * (1 + noOfLines);

                                    RectangleF rectItemName = new RectangleF(marginX, startY, printWidth, textHeight);

                                    e.Graphics.DrawString(itemName, fontNormalSinhala, Brushes.Black, rectItemName);
                                    startY += textHeight;
                                }
                                else
                                {

                                    itemName = row["LineNo"].ToString() + "." + row["NameOnInvoice"].ToString();

                                    textWidth = e.Graphics.MeasureString(itemName, fontNormal).Width;

                                    noOfLines = (int)(textWidth / printWidth);

                                    textHeight = lineHeightNormal * (1 + noOfLines);

                                    RectangleF rectItemName = new RectangleF(marginX, startY, printWidth, textHeight);

                                    e.Graphics.DrawString(itemName, fontNormal, Brushes.Black, rectItemName);
                                    startY += textHeight;
                                }
                            }
                            else
                            {
                                itemName = row["LineNo"].ToString() + "." + row["NameOnInvoice"].ToString();

                                textWidth = e.Graphics.MeasureString(itemName, fontNormal).Width;

                                noOfLines = (int)(textWidth / printWidth);

                                textHeight = lineHeightNormal * (1 + noOfLines);

                                RectangleF rectItemName = new RectangleF(marginX, startY, printWidth, textHeight);

                                e.Graphics.DrawString(itemName, fontNormal, Brushes.Black, rectItemName);
                                startY += textHeight;
                            }



                            string productDetailLeft = row["ItemCode"].ToString() + " " + Common.ConvertToStringCurrancy(row["SellingPrice"].ToString()) + "    " + Common.ConvertToStringQty(row["Qty"].ToString());
                            string productDetailRight = (salesMain.DocumentID != formInfo.DocumentID ? "-" : "") + Common.ConvertToStringCurrancy(row["TotalAmount"].ToString());

                            graphics.DrawString(productDetailLeft, fontNormal, brush, startX, startY);

                            textWidth = e.Graphics.MeasureString(productDetailRight, fontNormal).Width;
                            startX = pageWidth - (marginX * 2) - textWidth;
                            graphics.DrawString(productDetailRight, fontNormal, brush, startX, startY);

                            if (Common.ConvertStringToDecimal(row["DiscountPercentage"].ToString()) > 0 || Common.ConvertStringToDecimal(row["DiscountAmount"].ToString()) > 0)
                            {
                                startY += lineHeightNormal;

                                string discountLeft = string.Empty;
                                string discountRight = string.Empty;

                                if (Common.ConvertStringToDecimal(row["DiscountPercentage"].ToString()) > 0)
                                {
                                    discountLeft = "Discount " + Common.ConvertToStringCurrancy(row["DiscountPercentage"].ToString()) + "%";
                                    discountRight = (salesMain.DocumentID == formInfo.DocumentID ? "-" : "") + Common.ConvertToStringCurrancy(row["DiscountAmount"].ToString());
                                }
                                else if (Common.ConvertStringToDecimal(row["DiscountAmount"].ToString()) > 0)
                                {
                                    discountLeft = "Discount";
                                    discountRight = (salesMain.DocumentID == formInfo.DocumentID ? "-" : "") + Common.ConvertToStringCurrancy(row["DiscountAmount"].ToString());
                                }

                                startX = marginX;
                                graphics.DrawString(discountLeft, fontNormal, brush, startX, startY);


                                textWidth = e.Graphics.MeasureString(discountRight, fontNormal).Width;
                                startX = pageWidth - (marginX * 2) - textWidth;
                                graphics.DrawString(discountRight, fontNormal, brush, startX, startY);

                            }

                            if (lastRow.Field<Int64>("LineNo") != Common.ConvertStringToLong(row["LineNo"].ToString()))
                            {
                                startY += lineHeightNormal + 10;
                            }
                            else
                            {
                                startY += lineHeightNormal;
                            }

                            totalDiscount += Common.ConvertStringToDecimal(row["DiscountAmount"].ToString());
                        }
                    }

                    textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
                    startX = marginX;
                    graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;

                    startX = marginX;
                    graphics.DrawString("Gross Amount", fontDoubleHeight, brush, startX, startY);


                    string grossAmount = (salesMain.DocumentID != formInfo.DocumentID ? "-" : "") + Common.ConvertToStringCurrancy(salesMain.TotalAmount.ToString());
                    textWidth = e.Graphics.MeasureString(grossAmount, fontDoubleHeight).Width;
                    startX = pageWidth - (marginX * 2) - textWidth;
                    graphics.DrawString(grossAmount, fontDoubleHeight, brush, startX, startY);
                    startY += lineHeightDoubleHeight;

                    if (salesMain.DiscountPercentage > 0 || salesMain.DiscountAmount > 0)
                    {
                        startX = marginX;
                        if (salesMain.DiscountPercentage > 0)
                        {
                            graphics.DrawString("Discount " + salesMain.DiscountPercentage + "%", fontNormal, brush, startX, startY);
                        }
                        else
                        {
                            graphics.DrawString("Discount", fontNormal, brush, startX, startY);
                        }

                        string subTotalDiscount = (salesMain.DocumentID == formInfo.DocumentID ? "-" : "") + Common.ConvertToStringCurrancy(salesMain.DiscountAmount.ToString());

                        textWidth = e.Graphics.MeasureString(subTotalDiscount, fontNormal).Width;
                        startX = pageWidth - (marginX * 2) - textWidth;
                        graphics.DrawString(subTotalDiscount, fontNormal, brush, startX, startY);
                        startY += lineHeightNormal;

                        totalDiscount += Common.ConvertStringToDecimal(salesMain.DiscountAmount.ToString());

                        startX = marginX;
                        graphics.DrawString("Net Amount", fontDoubleHeight, brush, startX, startY);

                        string netAmount = (salesMain.DocumentID != formInfo.DocumentID ? "-" : "") + Common.ConvertToStringCurrancy(salesMain.NetAmount.ToString());

                        textWidth = e.Graphics.MeasureString(netAmount, fontDoubleHeight).Width;
                        startX = pageWidth - (marginX * 2) - textWidth;
                        graphics.DrawString(netAmount, fontDoubleHeight, brush, startX, startY);
                        startY += lineHeightDoubleHeight;
                    }

                    DataTable dtPosPayment = new DataTable();
                    dtPosPayment = salesService.GetAllSalesPaymentBySalesMainID(salesMain.SalesMainID);

                    if (dtPosPayment != null && dtPosPayment.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtPosPayment.Rows)
                        {
                            startX = marginX;
                            graphics.DrawString(row["PayTypeName"].ToString() + " " + row["Reference"].ToString(), fontNormal, brush, startX, startY);

                            string payAmount = (salesMain.DocumentID != formInfo.DocumentID ? "-" : "") + Common.ConvertToStringCurrancy(row["Amount"].ToString());

                            textWidth = e.Graphics.MeasureString(payAmount, fontNormal).Width;
                            startX = pageWidth - (marginX * 2) - textWidth;
                            graphics.DrawString(payAmount, fontNormal, brush, startX, startY);
                            startY += lineHeightNormal;
                        }
                    }

                    startX = marginX;

                    if (salesMain.BalanceAmount > 0)
                    {
                        graphics.DrawString("Balance", fontDoubleHeight, brush, startX, startY);

                        textWidth = e.Graphics.MeasureString(Common.ConvertToStringCurrancy(salesMain.BalanceAmount.ToString()), fontDoubleHeight).Width;
                        startX = pageWidth - (marginX * 2) - textWidth;
                        graphics.DrawString(Common.ConvertToStringCurrancy(salesMain.BalanceAmount.ToString()), fontDoubleHeight, brush, startX, startY);
                        startY += lineHeightDoubleHeight;
                    }

                    textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
                    startX = marginX;
                    graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;

                    startX = marginX;
                    graphics.DrawString("Unit : " + counter.CounterCode.Trim(), fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;

                    startX = marginX;
                    graphics.DrawString("End Time : " + salesMain.CreatedDate.ToString("hh:mm:ss tt"), fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;

                    startX = marginX;
                    graphics.DrawString("No Of Pieces : " + Common.ConvertToStringQty(salesMain.NoOfPieces.ToString()), fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;

                    startX = marginX;
                    graphics.DrawString("No Of Items : " + Common.ConvertToStringQty(salesMain.NoOfQty.ToString(), 0), fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;


                    if (salesMain.SalesmanID != 0)
                    {
                        SalesmanService salesmanService = new SalesmanService();
                        Salesman salesmanPrint = new Salesman();

                        salesmanPrint = salesmanService.GetSalesmanByID(salesMain.SalesmanID);
                        if (salesmanPrint != null)
                        {
                            startX = marginX;
                            graphics.DrawString("Salesman : " + salesmanPrint.SalesmanName.Trim(), fontNormal, brush, startX, startY);
                            startY += lineHeightNormal;
                        }
                    }

                    textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
                    startX = marginX;
                    graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
                    startY += lineHeightNormal;

                    if (totalDiscount > 0)
                    {
                        if (salesMain.DocumentID == formInfo.DocumentID)
                        {
                            startY += lineHeightNormal;

                            string stars = "*  *  *  *  *  *  *  *  *  *";
                            textWidth = e.Graphics.MeasureString(stars, fontDoubleHeight).Width;

                            startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                            graphics.DrawString(stars, fontDoubleHeight, brush, startX, startY);

                            startY += lineHeightDoubleHeight + 2;

                            string strTotalDiscount = "Total Discount - " + Common.ConvertToStringCurrancy(totalDiscount.ToString());
                            textWidth = e.Graphics.MeasureString(strTotalDiscount, fontDoubleHeight).Width;
                            startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                            graphics.DrawString(strTotalDiscount, fontDoubleHeight, brush, startX, startY);
                            startY += lineHeightDoubleHeight + 4;

                            textWidth = e.Graphics.MeasureString(stars, fontDoubleHeight).Width;
                            startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                            graphics.DrawString(stars, fontDoubleHeight, brush, startX, startY);

                            startY += lineHeightDoubleHeight;

                            textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
                            startX = marginX;
                            graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
                            startY += lineHeightNormal;
                        }
                    }

                    if (salesMain.LoyaltyCustomerID != 0)
                    {
                        LoyaltyCustomerService LoyaltyCustomerService = new LoyaltyCustomerService();
                        LoyaltyCustomer loyaltyPrint = new LoyaltyCustomer();

                        loyaltyPrint = LoyaltyCustomerService.GetLoyaltyCustomerByID(salesMain.LoyaltyCustomerID);

                        if (loyaltyPrint != null)
                        {
                            string header = "Loyalty Details";
                            textWidth = e.Graphics.MeasureString(header.Trim(), fontNormal).Width;
                            startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                            graphics.DrawString(header.Trim(), fontNormal, brush, startX, startY);
                            startY += lineHeightNormal;

                            startX = marginX;
                            graphics.DrawString("Customer : " + loyaltyPrint.LoyaltyCustomerName.Trim(), fontNormal, brush, startX, startY);
                            startY += lineHeightNormal;

                            if (salesMain.EPoints != 0)
                            {
                                startX = marginX;
                                graphics.DrawString("Earn Points : " + salesMain.EPoints, fontNormal, brush, startX, startY);
                                startY += lineHeightNormal;
                            }
                            if (salesMain.RPoints != 0)
                            {
                                startX = marginX;
                                graphics.DrawString("Redeem Points : " + salesMain.RPoints, fontNormal, brush, startX, startY);
                                startY += lineHeightNormal;
                            }
                            startX = marginX;
                            graphics.DrawString("Current Points : " + salesMain.CPoints, fontNormal, brush, startX, startY);
                            startY += lineHeightNormal;
                        }

                        textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
                        startX = marginX;
                        graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
                        startY += lineHeightNormal;

                    }


                    if (isRePrint)
                    {
                        textWidth = e.Graphics.MeasureString(reprint.Trim(), fontHeader).Width;
                        startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                        graphics.DrawString(reprint.Trim(), fontHeader, brush, startX, startY);
                        startY += lineHeightHeader;

                        textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
                        startX = marginX;
                        graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
                        startY += lineHeightNormal;
                    }

                    if (POSPrinter.tail1 != string.Empty)
                    {
                        textWidth = e.Graphics.MeasureString(POSPrinter.tail1.Trim(), fontNormal).Width;
                        startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                        graphics.DrawString(POSPrinter.tail1.Trim(), fontNormal, brush, startX, startY);
                        startY += lineHeightNormal;
                    }

                    if (POSPrinter.tail2 != string.Empty)
                    {
                        textWidth = e.Graphics.MeasureString(POSPrinter.tail2.Trim(), fontNormal).Width;
                        startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                        graphics.DrawString(POSPrinter.tail2.Trim(), fontNormal, brush, startX, startY);
                        startY += lineHeightNormal;
                    }

                    if (POSPrinter.tail3 != string.Empty)
                    {
                        textWidth = e.Graphics.MeasureString(POSPrinter.tail3.Trim(), fontNormal).Width;
                        startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                        graphics.DrawString(POSPrinter.tail3.Trim(), fontNormal, brush, startX, startY);
                        startY += lineHeightNormal;
                    }

                    //textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
                    //startX = marginX;
                    //graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
                    //startY += lineHeightNormal;

                    //textWidth = e.Graphics.MeasureString("System By NSoft", fontNormal).Width;
                    //startX = (pageWidth - (marginX * 2) - textWidth) / 2;
                    //graphics.DrawString("System By NSoft", fontNormal, brush, startX, startY);
                    //startY += lineHeightNormal;
                }
            }

        }

        private void txtReferenceNo_KeyDown(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.KeyCode == Keys.Enter)
            //    {
            //        if (cmbPayType.SelectedIndex == 1)
            //        {
            //            if (txtReferenceNo.Text.Length < 4)
            //            {
            //                SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Error, this.Text, "Invalid Credit Card Number.");
            //                txtReferenceNo.Focus();
            //                return;
            //            }
            //        }

            //        Common.ReadOnlyTextBox(false, txtPayAmount);
            //        Common.ReadOnlyTextBox(true, txtReferenceNo);
            //        txtPayAmount.Focus();
            //        txtPayAmount.SelectAll();
            //    }

            //}
            //catch (Exception ex)
            //{
            //    LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
            //    SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            //}
        }

        private void cmbPayType_Leave(object sender, EventArgs e)
        {

        }
        private void ChangeButtonTextColor(Button button, int color = 1)
        {
            switch (color)
            {
                case 1:
                    button.ForeColor = Color.Black;
                    break;
                case 2:
                    button.ForeColor = Color.Red;
                    break;
                default:
                    break;
            }
        }
        private void btnCash_Enter(object sender, EventArgs e)
        {
            ChangeButtonTextColor(btnCash, 2);
        }

        private void btnCash_Leave(object sender, EventArgs e)
        {
            ChangeButtonTextColor(btnCash, 1);
        }

        private void btnVisa_Enter(object sender, EventArgs e)
        {
            ChangeButtonTextColor(btnVisa, 2);
        }

        private void btnVisa_Leave(object sender, EventArgs e)
        {
            ChangeButtonTextColor(btnVisa, 1);
        }

        private void btnMaster_Enter(object sender, EventArgs e)
        {
            ChangeButtonTextColor(btnMaster, 2);
        }

        private void btnMaster_Leave(object sender, EventArgs e)
        {
            ChangeButtonTextColor(btnMaster, 1);
        }

        private void btnAmex_Enter(object sender, EventArgs e)
        {
            ChangeButtonTextColor(btnAmex, 2);
        }

        private void btnAmex_Leave(object sender, EventArgs e)
        {
            ChangeButtonTextColor(btnAmex, 1);
        }

        private void btnCheque_Enter(object sender, EventArgs e)
        {
            ChangeButtonTextColor(btnCheque, 2);
        }

        private void btnCheque_Leave(object sender, EventArgs e)
        {
            ChangeButtonTextColor(btnCheque, 1);
        }

        private void btnLoyaltyRedeem_Enter(object sender, EventArgs e)
        {
            ChangeButtonTextColor(btnLoyaltyRedeem, 2);
        }

        private void btnLoyaltyRedeem_Leave(object sender, EventArgs e)
        {
            ChangeButtonTextColor(btnLoyaltyRedeem, 1);
        }

        private void btnGiftVoucher_Enter(object sender, EventArgs e)
        {
            ChangeButtonTextColor(btnGiftVoucher, 2);
        }

        private void btnGiftVoucher_Leave(object sender, EventArgs e)
        {
            ChangeButtonTextColor(btnGiftVoucher, 1);
        }

        private void btnOther_Enter(object sender, EventArgs e)
        {
            ChangeButtonTextColor(btnOther, 2);
        }

        private void btnOther_Leave(object sender, EventArgs e)
        {
            ChangeButtonTextColor(btnOther, 1);
        }

        private void usrPaymentDetail1_Load(object sender, EventArgs e)
        {

        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            GotoPayment(1);
        }

        private void GotoPayment(int paytypeID)
        {
            try
            {
                if (isPaymentComplete)
                {
                    this.Close();
                    return;
                }

                PayType payType = new PayType();
                PayTypeService payTypeService = new PayTypeService();

                payType = payTypeService.GetActivePayTypeByID(paytypeID);

                if (payType != null)
                {
                    SalesPayment salesPayment = new SalesPayment();
                    salesPayment.PayTypeID = payType.PayTypeID;
                    salesPayment.PayType = payType.PayTypeName.Trim();

                    if (payType.IsPopupBank)
                    {
                        FrmBankSearch frmBankSearch = new FrmBankSearch();
                        frmBankSearch.ShowDialog();

                        if (frmBankSearch.isBankSelected)
                        {
                            salesPayment.BankID = frmBankSearch.selectedBankId;
                        }
                    }

                    usrPaymentDetailEnter1.Visible = true;
                    usrPaymentDetail1.Visible = false;
                    usrPaymentDetailEnter1.txtPayAmount.Text = lblDueAmount.Text.Trim();
                    usrPaymentDetailEnter1.txtPayType.Text = payType.PayTypeName.Trim();
                    usrPaymentDetailEnter1.control1 = usrPaymentDetail1;
                    usrPaymentDetailEnter1.control2 = this;
                    usrPaymentDetailEnter1.salesPayment = salesPayment;
                    usrPaymentDetailEnter1.payType = payType;
                    grpPayTypes.Enabled = false;

                    usrPaymentDetailEnter1.lblValidation.Text = string.Empty;

                    if (payType.IsUsedReferenceNo)
                    {
                        if (paytypeID == 6)
                        {
                            usrPaymentDetailEnter1.txtReferenceNo.Text = loyaltyCustomer.CardNo.Trim();
                            Common.ReadOnlyTextBox(true, usrPaymentDetailEnter1.txtReferenceNo);
                            Common.ReadOnlyTextBox(false, usrPaymentDetailEnter1.txtPayAmount);
                            usrPaymentDetailEnter1.txtPayAmount.Focus();
                        }
                        else
                        {
                            Common.ReadOnlyTextBox(false, usrPaymentDetailEnter1.txtReferenceNo);
                            usrPaymentDetailEnter1.txtReferenceNo.Focus();
                        }
                    }
                    else
                    {
                        Common.ReadOnlyTextBox(false, usrPaymentDetailEnter1.txtPayAmount);
                        usrPaymentDetailEnter1.txtPayAmount.Focus();
                    }

                }
                else
                {
                    MessageBox.Show("Payment Not Registerd.");
                    return;
                }



            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void btnVisa_Click(object sender, EventArgs e)
        {
            GotoPayment(2);
        }

        private void btnMaster_Click(object sender, EventArgs e)
        {
            GotoPayment(3);
        }

        private void btnAmex_Click(object sender, EventArgs e)
        {
            GotoPayment(4);
        }

        private void btnCheque_Click(object sender, EventArgs e)
        {
            GotoPayment(5);
        }

        private void btnLoyaltyRedeem_Click(object sender, EventArgs e)
        {
            if (loyaltyCustomer == null)
            {
                FrmPOSLoyaltyCustomer frmPOSLoyaltyCustomer = new FrmPOSLoyaltyCustomer(true);
                frmPOSLoyaltyCustomer.ShowDialog();
                loyaltyCustomer = frmPOSLoyaltyCustomer.loyaltyCustomer;
                if (loyaltyCustomer != null)
                {
                    btnLoyaltyRedeem.PerformClick();
                }
                return;
            }
            GotoPayment(6);
        }

        private void btnF6_Click(object sender, EventArgs e)
        {
            FrmPayment_KeyDown(this, new KeyEventArgs(Keys.F6));
        }

        private void btnF5_Click(object sender, EventArgs e)
        {
            FrmPayment_KeyDown(this, new KeyEventArgs(Keys.F5));
        }
    }
}
