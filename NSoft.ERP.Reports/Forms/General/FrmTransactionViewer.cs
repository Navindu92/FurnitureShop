using NSoft.ERP.Domain.General;
using NSoft.ERP.Domain.Inventory;
using NSoft.ERP.Reports.Reports.Inventory;
using NSoft.ERP.Service.General;
using NSoft.ERP.Service.Inventory;
using NSoft.ERP.Utility;
using System;
using System.Collections;
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

namespace NSoft.ERP.Reports.Forms.General
{
    public partial class FrmTransactionViewer : Form
    {
        ArrayList condtionField = new ArrayList();
        List<Common.ReportDataStruct> reportDataStruct = new List<Common.ReportDataStruct>();
        FormInfo formInfo = new FormInfo();
        bool isReceiptViewer = false;
        public FrmTransactionViewer()
        {
            InitializeComponent();
            if (File.Exists(Common.binPath + "/Images/Clear.png"))
            {
                btnClear.Image = Image.FromFile(Common.binPath + "/Images/Clear.png");
            }
            if (File.Exists(Common.binPath + "/Images/Close.png"))
            {
                btnClose.Image = Image.FromFile(Common.binPath + "/Images/Close.png");
            }

        }

        public FrmTransactionViewer(FormInfo formInfo, List<Common.ReportDataStruct> reportDataStruct, bool isReceiptViewer = false)
        {
            InitializeComponent();

            if (File.Exists(Common.binPath + "/Images/Clear.png"))
            {
                btnClear.Image = Image.FromFile(Common.binPath + "/Images/Clear.png");
            }
            if (File.Exists(Common.binPath + "/Images/Close.png"))
            {
                btnClose.Image = Image.FromFile(Common.binPath + "/Images/Close.png");
            }
            if (File.Exists(Common.binPath + "/Images/Print.png"))
            {
                btnPrint.Image = Image.FromFile(Common.binPath + "/Images/Print.png");
            }

            for (int i = 0; i < reportDataStruct.Count; i++)
            {
                if (reportDataStruct[i].IsCondtionField.Equals(true))
                {
                    condtionField.Add(reportDataStruct[i].ReportFiledName);
                }
            }

            this.reportDataStruct = reportDataStruct;
            this.formInfo = formInfo;

            cmbConditionField.DataSource = condtionField;
            cmbConditionField.Refresh();

            this.Text = formInfo.FormText.Trim() + " Details";
            this.isReceiptViewer = isReceiptViewer;

            if (this.isReceiptViewer)
            {
                Size formSize = new Size(1023, 517);
                this.Size = formSize;
                grpPrint.Visible = true;
            }
            else
            {
                Size formSize = new Size(704, 563);
                this.Size = formSize;
                grpPrint.Visible = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (SysMessage.ShowMessage(SysMessage.MessageAction.Close, SysMessage.MessageType.Question, "Close Form").Equals(DialogResult.Yes))
            {
                this.Close();
                this.Dispose();
            }
        }

        private void cmbConditionField_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbConditionField.SelectedIndex < 0)
                {
                    return;
                }

                LoadSelectionData();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void LoadSelectionData()
        {
            cmbConditionFrom.DataSource = null;
            cmbConditionTo.DataSource = null;

            if (GetSelecttedReportDataStruct(cmbConditionField.SelectedItem.ToString()).ReportDataType.Equals(typeof(DateTime)))
            {
                cmbConditionFrom.SendToBack();
                cmbConditionTo.SendToBack();

                dtpConditionFrom.BringToFront();
                dtpConditionTo.BringToFront();
            }
            else
            {
                dtpConditionFrom.SendToBack();
                dtpConditionTo.SendToBack();

                cmbConditionFrom.BringToFront();
                cmbConditionTo.BringToFront();
            }

            switch (formInfo.ModuleType)
            {
                case 2://Inventory
                    InvTransaction invTransaction = new InvTransaction();
                    cmbConditionFrom.DataSource = invTransaction.GetSelectionData(GetSelecttedReportDataStruct(cmbConditionField.SelectedItem.ToString()), formInfo);
                    cmbConditionTo.DataSource = invTransaction.GetSelectionData(GetSelecttedReportDataStruct(cmbConditionField.SelectedItem.ToString()), formInfo);
                    break;

                default:
                    break;
            }


        }

        private Common.ReportDataStruct GetSelecttedReportDataStruct(string selectFiledName)
        {
            Common.ReportDataStruct reportDataStructreturn = new Common.ReportDataStruct();

            foreach (Common.ReportDataStruct reportDataStructItem in reportDataStruct)
            {
                if (reportDataStructItem.ReportFiledName.Equals(selectFiledName))
                {
                    reportDataStructreturn = reportDataStructItem;
                    return reportDataStructreturn;
                }
            }

            return reportDataStructreturn;
        }
        private void AddCondition()
        {
            foreach (DataGridViewRow dr in dgvCondition.Rows)
            {
                if (cmbConditionField.Text.Equals(dr.Cells["Field"].Value.ToString().Trim()))
                {
                    dgvCondition.Rows.Remove(dr);
                }
            }
            dgvCondition.Rows.Add();
            int row = dgvCondition.Rows.Count - 1;
            if (GetSelecttedReportDataStruct(cmbConditionField.SelectedItem.ToString()).ReportDataType.Equals(typeof(DateTime)))
            {
                dgvCondition.Rows[row].Cells["Field"].Value = cmbConditionField.Text.Trim();
                dgvCondition.Rows[row].Cells["ConditionFrom"].Value = dtpConditionFrom.Value.ToShortDateString();
                dgvCondition.Rows[row].Cells["ConditionTo"].Value = dtpConditionTo.Value.ToShortDateString();
            }
            else
            {
                dgvCondition.Rows[row].Cells["Field"].Value = cmbConditionField.Text.Trim();
                dgvCondition.Rows[row].Cells["ConditionFrom"].Value = cmbConditionFrom.SelectedValue;
                dgvCondition.Rows[row].Cells["ConditionTo"].Value = cmbConditionTo.SelectedValue;
            }
        }
        private List<Common.ReportCondtionDataStruct> GetReportCondition()
        {
            List<Common.ReportCondtionDataStruct> conditionReportDataStruct = new List<Common.ReportCondtionDataStruct>();
            string conditionFrom = "";
            string conditionTo = "";
            foreach (DataGridViewRow dr in dgvCondition.Rows)
            {
                Common.ReportDataStruct reportDataStruct = GetSelecttedReportDataStruct(dr.Cells["Field"].Value.ToString().Trim());

                switch (formInfo.ModuleType)
                {
                    case 2://Inventory
                        InvTransaction invTransaction = new InvTransaction();
                        conditionFrom = reportDataStruct.IsJoinField == true ? invTransaction.GetConditionValue(reportDataStruct, dr.Cells["ConditionFrom"].Value.ToString().Trim()) : dr.Cells["ConditionFrom"].Value.ToString().Trim();
                        conditionTo = reportDataStruct.IsJoinField == true ? invTransaction.GetConditionValue(reportDataStruct, dr.Cells["ConditionTo"].Value.ToString().Trim()) : dr.Cells["ConditionTo"].Value.ToString().Trim();
                        break;

                    default:
                        break;
                }




                conditionReportDataStruct.Add(new Common.ReportCondtionDataStruct { ReportDataStruct = reportDataStruct, ConditionFrom = conditionFrom, ConditionTo = conditionTo });
            }

            return conditionReportDataStruct;
        }
        private void LoadResult()
        {
            try
            {
                List<Common.ReportCondtionDataStruct> conditionReportDataStruct = new List<Common.ReportCondtionDataStruct>();
                List<Common.ReportDataStruct> reportDataStruct = new List<Common.ReportDataStruct>();
                conditionReportDataStruct = GetReportCondition();
                dgvResult.DataSource = null;
                dgvResult.Refresh();

                switch (formInfo.ModuleType)
                {
                    case 2://Inventory
                        InvTransaction invTransaction = new InvTransaction();
                        dgvResult.DataSource = invTransaction.GetResultData(conditionReportDataStruct, reportDataStruct, formInfo);
                        break;
                    default:
                        break;
                }

                SetResultGrid();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddCondition();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                dgvResult.DataSource = null;
                dgvResult.Refresh();

                if (dgvCondition.RowCount == 0)
                {
                    return;
                }
                LoadResult();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                dgvCondition.Rows.Clear();
                dgvResult.DataSource = null;
                cmbConditionField.SelectedIndex = 0;
                rctReceipt.Text = string.Empty;
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void SetResultGrid()
        {
            foreach (DataGridViewColumn column in dgvResult.Columns)
            {
                DataTable dtResult = (DataTable)dgvResult.DataSource;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                if (dtResult.Columns[column.Name].DataType == typeof(decimal))
                {
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        private void dgvResult_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvResult.RowCount > 0)
                {
                    string documentNo = dgvResult["DocumentNo", dgvResult.CurrentCell.RowIndex].Value.ToString();

                    if (this.isReceiptViewer)
                    {
                        DisplayReceipt(documentNo);
                    }
                    else
                    {
                        InvTransaction invTransaction = new InvTransaction();
                        invTransaction.GenerateTransactionReport(formInfo, documentNo, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void DisplayReceipt(string documentNo)
        {
            rctReceipt.Clear();

            int printLength = 34;
            string tempSpace;
            Counter counter;

            Font fontHeader = new Font("POSNormal", 12.5f, FontStyle.Bold);
            Font fontNormal = new Font("POSNormal", 9.5f, FontStyle.Bold);
            // Font fontNormalSinhala = new Font("POSNormal", 7.5f, FontStyle.Bold);
            Font fontNormalSinhala = new Font("FMDerana", 12.5f, FontStyle.Regular);
            Font fontDoubleHeight = new Font("POSDouble", 9.5f, FontStyle.Bold);

            switch (formInfo.FormName)
            {
                case "FrmInvoice":

                    FormInfo formInfoInvoice = new FormInfo();
                    formInfoInvoice = FormInfoService.GetFormInfoByName(formInfo.FormName);

                    SalesService salesService = new SalesService();
                    SalesMain salesMain = new SalesMain();

                    salesMain = salesService.GetAllSalesMainByDocumentNo(documentNo);

                    counter = new Counter();
                    CounterService counterService = new CounterService();
                    counter = counterService.GetCounterByCounterNoAndLocationID(salesMain.CounterNo, salesMain.LocationID);

                    string dashLine = new string('-', printLength);

                    decimal totalDiscount = 0;

                    if (counter.Header1 != string.Empty)
                    {
                        DisplayText(counter.Header1, fontHeader, TextAlgnment.Center);

                    }
                    if (counter.Header2 != string.Empty)
                    {
                        DisplayText(counter.Header2, fontNormal, TextAlgnment.Center);

                    }
                    if (counter.Header3 != string.Empty)
                    {
                        DisplayText(counter.Header3, fontNormal, TextAlgnment.Center);

                    }

                    if (counter.Header4 != string.Empty)
                    {
                        DisplayText(counter.Header4, fontNormal, TextAlgnment.Center);

                    }

                    if (counter.Header4 != string.Empty)
                    {
                        DisplayText(counter.Header4, fontNormal, TextAlgnment.Center);

                    }

                    DisplayText(dashLine, fontNormal, TextAlgnment.Center);

                    if (salesMain != null)
                    {
                        string documentNoHeader = string.Empty;

                        if (salesMain.DocumentID == formInfo.DocumentID)
                        {
                            documentNoHeader = " Invoice No :  ";
                        }
                        else
                        {
                            documentNoHeader = " Return No :  ";
                        }


                        DisplayText(documentNoHeader + documentNo, fontNormal, TextAlgnment.Left);
                        DisplayText(" Date : " + salesMain.DocumentDate.ToString("dd-MMM-yyyy"), fontNormal, TextAlgnment.Left);
                        DisplayText(" Staff : " + salesMain.CreatedUser.Trim(), fontNormal, TextAlgnment.Left);

                        Location location = new Location();
                        LocationService locationService = new LocationService();

                        location = locationService.GetLocationByID(salesMain.LocationID);
                        if (location != null)
                        {
                            DisplayText(" Location : " + location.LocationName.Trim(), fontNormal, TextAlgnment.Left);
                        }

                        DisplayText(dashLine, fontNormal, TextAlgnment.Center);

                        if (salesMain.DocumentID != formInfoInvoice.DocumentID)
                        {
                            DisplayText("Sale Return", fontHeader, TextAlgnment.Center);
                            DisplayText(dashLine, fontNormal, TextAlgnment.Center);
                        }


                        string productDetailTailLeft = "#Item   Price   Qty";
                        string productDetailTailRight = "Amount";

                        tempSpace = new string(' ', (printLength - productDetailTailLeft.Length) - productDetailTailRight.Length);
                        DisplayText(" " + productDetailTailLeft + tempSpace + productDetailTailRight, fontNormal, TextAlgnment.Left, false, true);

                        DisplayText(dashLine, fontNormal, TextAlgnment.Center);


                        DataTable dtSubDetails = new DataTable();
                        dtSubDetails = salesService.GetAllSalesSubBySalesMainID(salesMain.SalesMainID);

                        DataRow lastRow = dtSubDetails.Rows[dtSubDetails.Rows.Count - 1];

                        if (dtSubDetails != null && dtSubDetails.Rows.Count > 0)
                        {
                            foreach (DataRow row in dtSubDetails.Rows)
                            {
                                string itemName = string.Empty;

                                if (counter.IsPrintSinhala)
                                {
                                    if (row["SinhalaName"].ToString() != string.Empty)
                                    {
                                        itemName = row["LineNo"].ToString() + " ' " + row["SinhalaName"].ToString();
                                        DisplayText(itemName, fontNormalSinhala, TextAlgnment.Left);
                                    }
                                    else
                                    {
                                        itemName = row["LineNo"].ToString() + "." + row["NameOnInvoice"].ToString();
                                        DisplayText(itemName, fontNormal, TextAlgnment.Left);
                                    }

                                   
                                }
                                else
                                {
                                    itemName = row["LineNo"].ToString() + "." + row["NameOnInvoice"].ToString();

                                    DisplayText(itemName, fontNormal, TextAlgnment.Left);

                                }
                               

                                string productDetailLeft = row["ItemCode"].ToString() + " " + Common.ConvertToStringCurrancy(row["SellingPrice"].ToString()) + "    " + Common.ConvertToStringQty(row["Qty"].ToString());
                                string productDetailRight = (salesMain.DocumentID != formInfo.DocumentID ? "-" : "") + Common.ConvertToStringCurrancy(row["TotalAmount"].ToString());

                                tempSpace = new string(' ', (printLength - productDetailTailLeft.Length) - productDetailTailRight.Length);
                                DisplayText(" " + productDetailLeft + tempSpace + productDetailRight, fontNormal, TextAlgnment.Left, false, true);

                                if (Common.ConvertStringToDecimal(row["DiscountPercentage"].ToString()) > 0 || Common.ConvertStringToDecimal(row["DiscountAmount"].ToString()) > 0)
                                {
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

                                    DisplayText(" " + discountLeft + tempSpace + discountRight, fontNormal, TextAlgnment.Left, false, true);

                                    totalDiscount += Common.ConvertStringToDecimal(row["DiscountAmount"].ToString());
                                }

                            }

                            DisplayText(dashLine, fontNormal, TextAlgnment.Center);

                            string netAmountLeft = "Net Amount";
                            string netAmountRight = (salesMain.DocumentID != formInfo.DocumentID ? "-" : "") + Common.ConvertToStringCurrancy(salesMain.NetAmount.ToString());

                            tempSpace = new string(' ', (printLength - netAmountLeft.Length) - netAmountRight.Length);
                            DisplayText(" " + netAmountLeft + tempSpace + netAmountRight, fontDoubleHeight, TextAlgnment.Left, false, true);

                            DataTable dtPosPayment = new DataTable();
                            dtPosPayment = salesService.GetAllSalesPaymentBySalesMainID(salesMain.SalesMainID);

                            if (dtPosPayment != null && dtPosPayment.Rows.Count > 0)
                            {
                                foreach (DataRow row in dtPosPayment.Rows)
                                {
                                    string payTypeHeader = row["PayTypeName"].ToString() + " " + row["Reference"].ToString();

                                    string payAmount = (salesMain.DocumentID != formInfo.DocumentID ? "-" : "") + Common.ConvertToStringCurrancy(row["Amount"].ToString());
                                    tempSpace = new string(' ', (printLength - payTypeHeader.Length) - payAmount.Length);
                                    DisplayText(" " + payTypeHeader + tempSpace + payAmount, fontNormal, TextAlgnment.Left, false, true);
                                }
                            }

                            if (salesMain.BalanceAmount > 0)
                            {
                                string balanceHeader = "Balance";
                                string balanceAmount = Common.ConvertToStringCurrancy(salesMain.BalanceAmount.ToString());

                                tempSpace = new string(' ', (printLength - balanceHeader.Length) - balanceAmount.Length);
                                DisplayText(" " + balanceHeader + tempSpace + balanceAmount, fontNormal, TextAlgnment.Left, false, true);
                            }

                            DisplayText(dashLine, fontNormal, TextAlgnment.Center);

                            DisplayText(" Unit : " + counter.CounterCode.Trim(), fontNormal, TextAlgnment.Left);
                            DisplayText(" End Time : " + salesMain.CreatedDate.ToString("hh:mm:ss tt"), fontNormal, TextAlgnment.Left);
                            DisplayText(" No Of Pieces : " + Common.ConvertToStringQty(salesMain.NoOfPieces.ToString()), fontNormal, TextAlgnment.Left);
                            DisplayText(" No Of Items : " + Common.ConvertToStringQty(salesMain.NoOfQty.ToString(), 0), fontNormal, TextAlgnment.Left);

                           

                            if (salesMain.SalesmanID != 0)
                            {
                                SalesmanService salesmanService = new SalesmanService();
                                Salesman salesmanPrint = new Salesman();

                                salesmanPrint = salesmanService.GetSalesmanByID(salesMain.SalesmanID);
                                if (salesmanPrint != null)
                                {
                                    DisplayText(" Salesman : " + salesmanPrint.SalesmanName.Trim(), fontNormal, TextAlgnment.Left);
                                }
                            }

                            DisplayText(dashLine, fontNormal, TextAlgnment.Center);

                            if (totalDiscount > 0)
                            {
                                if (salesMain.DocumentID == formInfo.DocumentID)
                                {
  
                                    string stars = "*  *  *  *  *  *  *  *  *  *";

                                    DisplayText(stars,fontNormal, TextAlgnment.Center);

                                    string strTotalDiscount = "Total Discount - " + Common.ConvertToStringCurrancy(totalDiscount.ToString());
                                    DisplayText(strTotalDiscount, fontNormal, TextAlgnment.Center);

                                    DisplayText(dashLine, fontNormal, TextAlgnment.Center);
                                }
                            }

                            if (counter.Tail1 != string.Empty)
                            {
                                DisplayText(counter.Tail1, fontNormal, TextAlgnment.Center);
                            }

                            if (counter.Tail2 != string.Empty)
                            {
                                DisplayText(counter.Tail2, fontNormal, TextAlgnment.Center);
                            }

                            if (counter.Tail3 != string.Empty)
                            {
                                DisplayText(counter.Tail3, fontNormal, TextAlgnment.Center);
                            }

                        }
                    }
                    break;

                default:
                    break;
            }
        }
        private enum TextAlgnment
        {
            Center,
            Left,
            Right
        }
        private void DisplayText(string text, Font font, TextAlgnment textAlgnment = TextAlgnment.Left, bool isBold = false, bool isNewLine = true)
        {
            try
            {
                switch (textAlgnment)
                {
                    case TextAlgnment.Center:
                        rctReceipt.SelectionAlignment = HorizontalAlignment.Center;
                        break;
                    case TextAlgnment.Left:
                        rctReceipt.SelectionAlignment = HorizontalAlignment.Left;
                        break;
                    case TextAlgnment.Right:
                        rctReceipt.SelectionAlignment = HorizontalAlignment.Right;
                        break;
                    default:
                        break;
                }


                rctReceipt.SelectionFont = font;

                if (isNewLine)
                {
                    rctReceipt.AppendText(text + Environment.NewLine);
                }
                else
                {
                    rctReceipt.AppendText(text);
                }
                rctReceipt.Refresh();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
    }
}
