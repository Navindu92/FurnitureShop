using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSoft.ERP.Reports.Forms.General;
using NSoft.ERP.Domain.General;
using NSoft.ERP.Utility;
using System.Collections;
using NSoft.ERP.Service.Inventory;
using System.Data;
using NSoft.ERP.Service.General;
using NSoft.ERP.Reports.Reports.Inventory.Transaction;

namespace NSoft.ERP.Reports.Reports.Inventory
{
    public class InvTransaction
    {
        public FrmTransactionViewer SetFormFields(FormInfo formInfo)
        {
            FrmTransactionViewer frmInventoryTransaction = new FrmTransactionViewer();
            List<Common.ReportDataStruct> reportDataStruct = new List<Common.ReportDataStruct>();

            switch (formInfo.FormName)
            {
                case "FrmGoodsReceivedNote":
                    reportDataStruct.Add(new Common.ReportDataStruct() { ReportFiled = "FieldString1", ReportFiledName = "GRN No", DbColumnName = "DocumentNo", IsCondtionField = true, IsSelectionField = true, ReportDataType = typeof(string) });
                    reportDataStruct.Add(new Common.ReportDataStruct() { ReportFiled = "FieldString2", ReportFiledName = "GRN Date", DbColumnName = "DocumentDate", IsCondtionField = true, IsSelectionField = true, ReportDataType = typeof(DateTime) });
                    reportDataStruct.Add(new Common.ReportDataStruct() { ReportFiled = "FieldString3", ReportFiledName = "Location", DbColumnName = "LocationID", DbJoinColumnName = "LocationName", IsCondtionField = true, IsSelectionField = true, IsJoinField = true, ReportDataType = typeof(int) });
                    reportDataStruct.Add(new Common.ReportDataStruct() { ReportFiled = "FieldString4", ReportFiledName = "Supplier", DbColumnName = "SupplierID", DbJoinColumnName = "SupplierName", IsCondtionField = true, IsSelectionField = true, IsJoinField = true, ReportDataType = typeof(int) });
                    reportDataStruct.Add(new Common.ReportDataStruct() { ReportFiled = "FieldString5", ReportFiledName = "Created User", DbColumnName = "CreatedUser", IsCondtionField = true, IsSelectionField = true, ReportDataType = typeof(string) });
                    frmInventoryTransaction = new FrmTransactionViewer(formInfo, reportDataStruct);
                    return frmInventoryTransaction;
                case "FrmInvoice":
                    reportDataStruct.Add(new Common.ReportDataStruct() { ReportFiled = "FieldString1", ReportFiledName = "Invoice No", DbColumnName = "DocumentNo", IsCondtionField = true, IsSelectionField = true, ReportDataType = typeof(string) });
                    reportDataStruct.Add(new Common.ReportDataStruct() { ReportFiled = "FieldString2", ReportFiledName = "Invoice Date", DbColumnName = "DocumentDate", IsCondtionField = true, IsSelectionField = true, ReportDataType = typeof(DateTime) });
                    reportDataStruct.Add(new Common.ReportDataStruct() { ReportFiled = "FieldString3", ReportFiledName = "Location", DbColumnName = "LocationID", DbJoinColumnName = "LocationName", IsCondtionField = true, IsSelectionField = true, IsJoinField = true, ReportDataType = typeof(int) });
                    reportDataStruct.Add(new Common.ReportDataStruct() { ReportFiled = "FieldString4", ReportFiledName = "Customer", DbColumnName = "CustomerID", DbJoinColumnName = "CustomerName", IsCondtionField = true, IsSelectionField = true, IsJoinField = true, ReportDataType = typeof(int) });
                    reportDataStruct.Add(new Common.ReportDataStruct() { ReportFiled = "FieldString5", ReportFiledName = "Created User", DbColumnName = "CreatedUser", IsCondtionField = true, IsSelectionField = true, ReportDataType = typeof(string) });
                    frmInventoryTransaction = new FrmTransactionViewer(formInfo, reportDataStruct, true);
                    return frmInventoryTransaction;
                default:
                    break;
            }
            return frmInventoryTransaction;
        }
        public ArrayList GetSelectionData(Common.ReportDataStruct reportDataStruct, FormInfo formInfo)
        {
            switch (formInfo.FormName)
            {
                case "FrmGoodsReceivedNote":
                    PurchaseService purchaseService = new PurchaseService();
                    return purchaseService.GetSelectionData(reportDataStruct);
                case "FrmInvoice":
                    SalesService salesService = new SalesService();
                    return salesService.GetSelectionData(reportDataStruct);
                default:
                    return null;
            }
        }
        public string GetConditionValue(Common.ReportDataStruct reportDataStruct, string value)
        {
            string condtionValue = string.Empty;
            switch (reportDataStruct.DbColumnName)
            {
                case "SupplierID":
                    SupplierService supplierService = new SupplierService();
                    condtionValue = supplierService.GetActiveSupplierByName(value).SupplierID.ToString();
                    break;
                case "LocationID":
                    LocationService locationService = new LocationService();
                    condtionValue = locationService.GetActiveLocationByName(value).LocationID.ToString();
                    break;
                case "CustomerID":
                    CustomerService customerService = new CustomerService();
                    condtionValue = customerService.GetActiveCustomerByName(value).CustomerID.ToString();
                    break;
                default:
                    return null;
            }
            return condtionValue;
        }

        public DataTable GetResultData(List<Common.ReportCondtionDataStruct> conditionReportDataStruct, List<Common.ReportDataStruct> reportDataStruct, FormInfo formInfo)
        {
            switch (formInfo.FormName)
            {
                case "FrmGoodsReceivedNote":
                    PurchaseService purchaseService = new PurchaseService();
                    return purchaseService.GetPurchaseDataTable(conditionReportDataStruct, reportDataStruct);
                case "FrmInvoice":
                    SalesService salesService = new SalesService();
                    return salesService.GetSalesDataTable(conditionReportDataStruct, reportDataStruct);

                default:
                    return null;
            }
        }
        public void GenerateTransactionReport(FormInfo formInfo, string documentNo, int documentStatus = 1)
        {
            FrmReportViewer frmReportViewer = new FrmReportViewer();
            switch (formInfo.FormName)
            {
                case "FrmGoodsReceivedNote":
                    PurchaseService purchaseService = new PurchaseService();
                    DataTable dtPurchase = purchaseService.GetPurchaseTransactionDataTable(documentNo);
                    RptGoodsReceivedNote rptGoodsReceivedNote = new RptGoodsReceivedNote();
                    rptGoodsReceivedNote.SetDataSource(dtPurchase);
                    rptGoodsReceivedNote.SummaryInfo.ReportTitle = formInfo.FormText.Trim();
                    rptGoodsReceivedNote.DataDefinition.FormulaFields["LoginUsername"].Text = "'" + Common.LoggedUserName + "'";
                    rptGoodsReceivedNote.DataDefinition.FormulaFields["LoginLocation"].Text = "'" + Common.LoggedLocation + "'";
                    rptGoodsReceivedNote.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.CompanyName + "'";
                    rptGoodsReceivedNote.DataDefinition.FormulaFields["Address"].Text = "'" + Common.Address + "'";
                    rptGoodsReceivedNote.DataDefinition.FormulaFields["DocumentStatus"].Text = "" + documentStatus + "";
                    frmReportViewer.crystalReportViewer.ReportSource = rptGoodsReceivedNote;
                    break;

                case "FrmStockAdjustment":
                    StockAdjustmentService stockAdjustmentService = new StockAdjustmentService();
                    DataTable dtStockAdjustment = stockAdjustmentService.GetStockAdjustmentTransactionDataTable(documentNo);
                    RptStockAdjustment rptStockAdjustment = new RptStockAdjustment();
                    rptStockAdjustment.SetDataSource(dtStockAdjustment);
                    rptStockAdjustment.SummaryInfo.ReportTitle = formInfo.FormText.Trim();
                    rptStockAdjustment.DataDefinition.FormulaFields["LoginUsername"].Text = "'" + Common.LoggedUserName + "'";
                    rptStockAdjustment.DataDefinition.FormulaFields["LoginLocation"].Text = "'" + Common.LoggedLocation + "'";
                    rptStockAdjustment.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.CompanyName + "'";
                    rptStockAdjustment.DataDefinition.FormulaFields["Address"].Text = "'" + Common.Address + "'";
                    rptStockAdjustment.DataDefinition.FormulaFields["DocumentStatus"].Text = "" + documentStatus + "";
                    frmReportViewer.crystalReportViewer.ReportSource = rptStockAdjustment;
                    break;

                case "FrmPurchaseOrder":
                    PurchaseOrderService purchaseOrderService = new PurchaseOrderService();
                    DataTable dtPurchaseOrder = purchaseOrderService.GetPurchaseOrderTransactionDataTable(documentNo);
                    RptPurchaseOrder rptPurchaseOrder = new RptPurchaseOrder();
                    rptPurchaseOrder.SetDataSource(dtPurchaseOrder);
                    rptPurchaseOrder.SummaryInfo.ReportTitle = formInfo.FormText.Trim();
                    rptPurchaseOrder.DataDefinition.FormulaFields["LoginUsername"].Text = "'" + Common.LoggedUserName + "'";
                    rptPurchaseOrder.DataDefinition.FormulaFields["LoginLocation"].Text = "'" + Common.LoggedLocation + "'";
                    rptPurchaseOrder.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.CompanyName + "'";
                    rptPurchaseOrder.DataDefinition.FormulaFields["Address"].Text = "'" + Common.Address + "'";
                    rptPurchaseOrder.DataDefinition.FormulaFields["DocumentStatus"].Text = "" + documentStatus + "";
                    frmReportViewer.crystalReportViewer.ReportSource = rptPurchaseOrder;
                    break;
                case "FrmPurchaseReturn":
                    purchaseService = new PurchaseService();
                    DataTable dtPurchaseReturn = purchaseService.GetPurchaseReturnTransactionDataTable(documentNo);
                    RptPurchaseReturn rptPurchaseReturn = new RptPurchaseReturn();
                    rptPurchaseReturn.SetDataSource(dtPurchaseReturn);
                    rptPurchaseReturn.SummaryInfo.ReportTitle = formInfo.FormText.Trim();
                    rptPurchaseReturn.DataDefinition.FormulaFields["LoginUsername"].Text = "'" + Common.LoggedUserName + "'";
                    rptPurchaseReturn.DataDefinition.FormulaFields["LoginLocation"].Text = "'" + Common.LoggedLocation + "'";
                    rptPurchaseReturn.DataDefinition.FormulaFields["CompanyName"].Text = "'" + Common.CompanyName + "'";
                    rptPurchaseReturn.DataDefinition.FormulaFields["Address"].Text = "'" + Common.Address + "'";
                    rptPurchaseReturn.DataDefinition.FormulaFields["DocumentStatus"].Text = "" + documentStatus + "";
                    frmReportViewer.crystalReportViewer.ReportSource = rptPurchaseReturn;
                    break;
            }

            frmReportViewer.Show();
        }
    }
}
