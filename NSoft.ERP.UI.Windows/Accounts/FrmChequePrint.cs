using NSoft.ERP.Domain.General;
using NSoft.ERP.Service.General;
using NSoft.ERP.UI.Windows.General;
using NSoft.ERP.Service.Accounts;
using NSoft.ERP.Domain.Accounts;
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
using System.Threading;
using System.Drawing.Printing;
using NSoft.ERP.Service.Inventory;
using NSoft.ERP.Domain.Inventory;

namespace NSoft.ERP.UI.Windows.Accounts
{
    public partial class FrmChequePrint : FrmBasePrint
    {

        FormInfo formInfo;
        UserPrivileges userPrivileges;
        UserService userService = new UserService();
        ChequeBookEntry chequeBookEntry = new ChequeBookEntry();
        public FrmChequePrint()
        {
            InitializeComponent();
        }

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
                crystalReportViewer1.Visible = false;
                Common.EnableButton(false, btnView, btnPrint);
                rdbCash.Checked = true;
                Common.ReadOnlyTextBox(true, txtPayee);
                Common.EnableTextBox(true, txtChequeNo);
                txtPayee.Text = "CASH";

                chequeBookEntry = new ChequeBookEntry();

                this.ActiveControl = txtChequeNo;

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
                if (!ValidateControls())
                {
                    return;
                }
                ShowCheque();
                Common.EnableButton(true, btnPrint);
                base.View();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        public override void Print()
        {
            try
            {
                if (!ValidateControls())
                {
                    return;
                }
                ShowCheque();

                PrinterSettings settings = new PrinterSettings();
                reportDocument1.PrintOptions.PrinterName = settings.PrinterName;
                reportDocument1.PrintToPrinter(1, true, 0, 0);

                ChequeBookEntryService chequeBookEntryService = new ChequeBookEntryService();

                chequeBookEntry.Amount = Common.ConvertStringToDecimal(txtAmount.Text);
                chequeBookEntry.ChequeDate = dtpChequeDate.Value.Date;
                chequeBookEntry.PayeeName = txtPayee.Text.Trim();
                chequeBookEntry.IsCrossed = chkCrossed.Checked;
                chequeBookEntry.IsPrint = true;

                chequeBookEntryService.UpdateCheque(chequeBookEntry);

                Initialize();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
            base.Print();
        }
        #endregion

        #region Private Methods
        private void ShowCheque()
        {
            try
            {
                crystalReportViewer1.Visible = true;
                reportDocument1.Load(Common.binPath + "/Reports/Accounts/RptCheque.rpt");

                string day = dtpChequeDate.Value.Day.ToString("D2");
                string month = dtpChequeDate.Value.Month.ToString("D2");
                string year = dtpChequeDate.Value.Year.ToString();

                reportDocument1.DataDefinition.FormulaFields["D1"].Text = "'" + day.Substring(0, 1) + "'";
                reportDocument1.DataDefinition.FormulaFields["D2"].Text = "'" + day.Substring(1, 1) + "'";
                reportDocument1.DataDefinition.FormulaFields["M1"].Text = "'" + month.Substring(0, 1) + "'";
                reportDocument1.DataDefinition.FormulaFields["M2"].Text = "'" + month.Substring(1, 1) + "'";
                reportDocument1.DataDefinition.FormulaFields["Y1"].Text = "'" + year.Substring(0, 1) + "'";
                reportDocument1.DataDefinition.FormulaFields["Y2"].Text = "'" + year.Substring(1, 1) + "'";
                reportDocument1.DataDefinition.FormulaFields["Y3"].Text = "'" + year.Substring(2, 1) + "'";
                reportDocument1.DataDefinition.FormulaFields["Y4"].Text = "'" + year.Substring(3, 1) + "'";
                reportDocument1.DataDefinition.FormulaFields["Payee"].Text = "'" + txtPayee.Text.Trim() + "'";

                reportDocument1.DataDefinition.FormulaFields["AmountInWord"].Text = "'" + Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(Common.ConvertNumberToWords(txtAmount.Text.Trim(), true).ToLower()) + "'";
                reportDocument1.DataDefinition.FormulaFields["Amount"].Text = "'" + "****" + Common.ConvertToStringCurrancy(txtAmount.Text.Trim()) + "'";

                if (chkCrossed.Checked)
                {
                    reportDocument1.DataDefinition.FormulaFields["Crossed"].Text = "'" + "ACCOUNT PAYEE ONLY" + "'";
                }
                else
                {
                    reportDocument1.DataDefinition.FormulaFields["Crossed"].Text = "'" + " " + "'";
                }

                crystalReportViewer1.ReportSource = reportDocument1;
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void SetCashStatus()
        {
            try
            {
                if (rdbCash.Checked)
                {
                    Common.ReadOnlyTextBox(true, txtPayee);
                    txtPayee.Text = "CASH";
                }
                else if (rdbPayee.Checked)
                {
                    LoadActiveSuppliers();
                    Common.ReadOnlyTextBox(false, txtPayee);
                    txtPayee.Text = string.Empty;
                }

            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private bool ValidateControls()
        {
            return Validater.ValidateTextBox(errorProvider1, ValidateType.Empty, txtChequeNo, txtAmount, txtPayee);
        }

        private void LoadActiveSuppliers()
        {
            try
            {
                SupplierService supplierService = new SupplierService();
                Common.SetAutoComplete(txtPayee, supplierService.GetAllActiveSupplierNames());
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        #endregion

        #region Other

        private void rdbCash_CheckedChanged(object sender, EventArgs e)
        {
            SetCashStatus();
        }

        private void rdbPayee_CheckedChanged(object sender, EventArgs e)
        {
            SetCashStatus();
        }
        private void txtChequeNo_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblChequeNo);
        }
        private void dtpChequeDate_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblChequeDate);
        }
        private void txtAmount_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblAmount);
        }

        #endregion

        #region Keydown And Leave

        private void txtChequeNo_Leave(object sender, EventArgs e)
        {
            try
            {
                Common.UnHighlightLable(lblChequeNo);

                if (txtChequeNo.Text == string.Empty)
                {
                    return;
                }

                ChequeBookEntryService chequeBookEntryService = new ChequeBookEntryService();
                chequeBookEntry = new ChequeBookEntry();

                chequeBookEntry = chequeBookEntryService.GetNonPrintChequeByChequeNo(txtChequeNo.Text.Trim());

                if (chequeBookEntry != null)
                {
                    if (userPrivileges == null ? false : userPrivileges.IsSave) { Common.EnableButton(true, btnView); }
                    Common.EnableTextBox(false, txtChequeNo);
                }
                else
                {
                    SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Error, this.Text, "Invalid ChequeNo.");
                    txtChequeNo.Text = string.Empty;
                    return;
                }
            }

            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtChequeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpChequeDate.Focus();
            }
        }

        private void dtpChequeDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAmount.Focus();
            }
        }
        private void dtpChequeDate_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightLable(lblChequeDate);
        }
        private void txtAmount_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightLable(lblAmount);
        }
        private void txtPayee_Leave(object sender, EventArgs e)
        {
            try
            {
                SupplierService supplierService = new SupplierService();
                Supplier supplier = new Supplier();

                supplier = supplierService.GetActiveSupplierByName(txtPayee.Text.Trim());

                if (supplier == null)
                {
                    Common.ClearTextBox(txtPayee);
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
