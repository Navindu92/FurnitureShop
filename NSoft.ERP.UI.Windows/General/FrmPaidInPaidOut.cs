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
using NSoft.ERP.UI.Windows.Device;
using System.Drawing.Printing;
using NSoft.ERP.UI.Windows.Inventory;

namespace NSoft.ERP.UI.Windows.General
{
    public partial class FrmPaidInPaidOut : FrmBaseTransation
    {

        /// <summary>
        /// Developed by Navindu
        /// 2017-08-14
        /// </summary>

        int tranasactionType; // 1-PaidIn /2-PaidOut
        long counterNo;
        string name;

        FormInfo formInfo;
        UserPrivileges userPrivileges;
        UserService userService = new UserService();
        PaidInPaidOutTemp paidInPaidOutTemp;
        PaidInType paidInType;
        PaidOutType paidOutType;
        List<PaidInPaidOutTemp> paidInPaidOutTempList = new List<PaidInPaidOutTemp>();
        PaidInPaidOutMain paidInPaidOutMain;
        Counter counter;
        bool isRecall = false;

        string documentNo;

        public FrmPaidInPaidOut()
        {
            InitializeComponent();
        }
        public FrmPaidInPaidOut(int tranasactionType, long counterNo, string name)
        {
            try
            {
                this.tranasactionType = tranasactionType;
                this.counterNo = counterNo;
                this.name = name;
                InitializeComponent();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        #region Override Method
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
                        this.Text = " Paid In - " + counterService.GetCounterByCounterNoAndLocationID(counterNo, Common.LoggedLocationID).CounterName.Trim();
                    }
                    else
                    {
                        this.Text = " Paid Out - " + counterService.GetCounterByCounterNoAndLocationID(counterNo, Common.LoggedLocationID).CounterName.Trim();
                    }

                }

                //userPrivileges = new UserPrivileges();
                //userPrivileges = userService.GetUserPrivilegesByUserIDAndForm(Common.LoggedUserID, formInfo);
                dtpDocumentDate.MinDate = DateTime.Now.Date;

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
                PaidInPaidOutService paidInPaidOutService = new PaidInPaidOutService();
                if (tranasactionType == 1)
                {
                    Common.SetAutoComplete(txtPaidInPaidOutCode, paidInPaidOutService.GetAllActivePaidInCodes());
                    Common.SetAutoComplete(txtPaidInPaidOutName, paidInPaidOutService.GetAllActivePaidInNames());
                }
                else
                {
                    Common.SetAutoComplete(txtPaidInPaidOutCode, paidInPaidOutService.GetAllActivePaidOutCodes());
                    Common.SetAutoComplete(txtPaidInPaidOutName, paidInPaidOutService.GetAllActivePaidOutNames());
                }

                paidInPaidOutTempList = new List<PaidInPaidOutTemp>();
                dgvPaidInPaidOut.DataSource = null;
                dgvPaidInPaidOut.DataSource = paidInPaidOutTempList;
                dgvPaidInPaidOut.Refresh();

                Common.EnableButton(true, btnSave);
                EnableFooter(false);

                this.ActiveControl = txtPerson;
                txtPerson.Focus();

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
                Summarize();
                SavePaidInPaidOut();
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
        private bool ValidateControles()
        {
            try
            {
                if (!Validater.ValidateTextBox(errorProvider1, Validater.ValidateType.Empty, txtPerson))
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

        private void EnableFooter(bool enable)
        {
            try
            {
                Common.EnableTextBox(enable, txtPaidInPaidOutCode, txtPaidInPaidOutName, txtAmount);
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void ClearLine()
        {
            try
            {
                Common.ClearTextBox(txtPaidInPaidOutCode, txtPaidInPaidOutName, txtAmount);
                txtPaidInPaidOutCode.Focus();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void LoadPaidInDetails(bool isCode, string str)
        {
            try
            {
                PaidInPaidOutService paidInPaidOutService = new PaidInPaidOutService();
                paidInType = new PaidInType();
                if (isCode)
                {
                    paidInType = paidInPaidOutService.GetActivePaidInTypeByCode(str);
                }
                else
                {
                    paidInType = paidInPaidOutService.GetActivePaidInTypeByName(str);
                }
                if (paidInType != null)
                {
                    txtPaidInPaidOutCode.Text = paidInType.PaidInTypeCode.Trim();
                    txtPaidInPaidOutName.Text = paidInType.PaidInTypeName.Trim();
                    txtAmount.Text = Common.ConvertToStringCurrancy(paidInType.Amount.ToString());
                }
                else
                {
                    ClearLine();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void LoadPaidOutDetails(bool isCode, string str)
        {
            try
            {
                PaidInPaidOutService paidInPaidOutService = new PaidInPaidOutService();
                paidOutType = new PaidOutType();
                if (isCode)
                {
                    paidOutType = paidInPaidOutService.GetActivePaidOutTypeByCode(str);
                }
                else
                {
                    paidOutType = paidInPaidOutService.GetActivePaidOutTypeByName(str);
                }
                if (paidOutType != null)
                {
                    txtPaidInPaidOutCode.Text = paidOutType.PaidOutTypeCode.Trim();
                    txtPaidInPaidOutName.Text = paidOutType.PaidOutTypeName.Trim();
                    txtAmount.Text = Common.ConvertToStringCurrancy(paidOutType.Amount.ToString());
                }
                else
                {
                    ClearLine();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void SavePaidInPaidOut()
        {
            try
            {
                counter = new Counter();
                CounterService counterService = new CounterService();
                counter = counterService.GetCounterByCounterNoAndLocationID(Common.CounterNo, Common.LoggedLocationID);

                paidInPaidOutMain = new PaidInPaidOutMain();
                paidInPaidOutMain.DocumentDate = dtpDocumentDate.Value.Date;
                paidInPaidOutMain.Person = txtPerson.Text.Trim();
                paidInPaidOutMain.CounterNo = counterNo;
                paidInPaidOutMain.LocationID = Common.LoggedLocationID;
                paidInPaidOutMain.PaidInPaidOutType = tranasactionType;
                paidInPaidOutMain.TotalAmount = Common.ConvertStringToDecimal(txtTotalAmount.Text.Trim());
                paidInPaidOutMain.Zno = counter.Zno;
                paidInPaidOutMain.ZDate = DateTime.Now.Date;

                PaidInPaidOutService paidInPaidOutService = new PaidInPaidOutService();

                string printerStaus = "";
                bool isPrinterAvailable = POSPrinter.CheckPrinterAvailability(out printerStaus);

                if (isPrinterAvailable)
                {
                    if (paidInPaidOutService.Save(formInfo, paidInPaidOutMain, paidInPaidOutTempList, out documentNo))
                    {
                        PrintPaidInPaidOut();
                        Clear();
                        this.Close();
                    }
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
        #endregion

        #region Keydown and Leave

        private void txtPerson_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    EnableFooter(true);
                    txtPaidInPaidOutCode.Focus();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtPaidInPaidOutCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPaidInPaidOutName.Focus();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }

        private void txtPaidInPaidOutName_KeyDown(object sender, KeyEventArgs e)
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
                    if (tranasactionType == 1)
                    {
                        if (paidInType == null) { return; }

                    }
                    else
                    {
                        if (paidOutType == null) { return; }

                    }
                    if (txtAmount.Text.Trim() == string.Empty) { btnSave.Focus(); return; }
                    if (Common.ConvertStringToDecimal(txtAmount.Text.Trim()) == 0) { return; }
                    paidInPaidOutTemp = new PaidInPaidOutTemp();
                    UpdateGrid(paidInPaidOutTemp);
                    Summarize();
                    ClearLine();
                    //if (userPrivileges == null ? false : userPrivileges.IsSave) { Common.EnableButton(true, btnSave); }
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void txtPaidInPaidOutCode_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtPaidInPaidOutCode.Text != string.Empty)
                {
                    if (tranasactionType == 1)
                    {
                        LoadPaidInDetails(true, txtPaidInPaidOutCode.Text);
                    }
                    else
                    {
                        LoadPaidOutDetails(true, txtPaidInPaidOutCode.Text);
                    }

                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }

        private void txtPaidInPaidOutName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtPaidInPaidOutName.Text != string.Empty)
                {
                    if (tranasactionType == 1)
                    {
                        LoadPaidInDetails(false, txtPaidInPaidOutName.Text);
                    }
                    else
                    {
                        LoadPaidOutDetails(false, txtPaidInPaidOutName.Text);
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

        #region Other

        private void Summarize()
        {
            try
            {
                decimal totalAmount = 0;

                totalAmount = paidInPaidOutTempList.Sum(x => x.Amount);

                txtTotalAmount.Text = Common.ConvertToStringCurrancy(totalAmount.ToString());

            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private void UpdateGrid(PaidInPaidOutTemp paidInPaidOutTemp)
        {
            try
            {
                if (tranasactionType == 1)
                {
                    paidInPaidOutTemp.PaidInPaidOutID = paidInType.PaidInTypeID;
                    paidInPaidOutTemp.PaidInPaidOutCode = paidInType.PaidInTypeCode.Trim();
                    paidInPaidOutTemp.PaidInPaidOutName = paidInType.PaidInTypeName.Trim();
                    paidInPaidOutTemp.Amount = Common.ConvertStringToDecimal(Common.ConvertToStringCurrancy(txtAmount.Text.Trim()));
                }
                else
                {
                    paidInPaidOutTemp.PaidInPaidOutID = paidOutType.PaidOutTypeID;
                    paidInPaidOutTemp.PaidInPaidOutCode = paidOutType.PaidOutTypeCode.Trim();
                    paidInPaidOutTemp.PaidInPaidOutName = paidOutType.PaidOutTypeName.Trim();
                    paidInPaidOutTemp.Amount = Common.ConvertStringToDecimal(Common.ConvertToStringCurrancy(txtAmount.Text.Trim()));
                }

                PaidInPaidOutService paidInPaidOutService = new PaidInPaidOutService();
                paidInPaidOutTempList = paidInPaidOutService.GetUpdatedPaidInPaidOutList(paidInPaidOutTempList, paidInPaidOutTemp);
                dgvPaidInPaidOut.DataSource = paidInPaidOutTempList.ToList();
                dgvPaidInPaidOut.Refresh();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void dgvPaidInPaidOut_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvPaidInPaidOut.RowCount > 0)
                {
                    if (dgvPaidInPaidOut["PaidInPaidOutCode", dgvPaidInPaidOut.CurrentCell.RowIndex].Value.ToString() == string.Empty) { return; }
                    PaidInPaidOutService paidInPaidOutService = new PaidInPaidOutService();

                    if (tranasactionType == 1)
                    {
                        LoadPaidInDetails(true, dgvPaidInPaidOut["PaidInPaidOutCode", dgvPaidInPaidOut.CurrentCell.RowIndex].Value.ToString());

                    }
                    else
                    {
                        LoadPaidOutDetails(true, dgvPaidInPaidOut["PaidInPaidOutCode", dgvPaidInPaidOut.CurrentCell.RowIndex].Value.ToString());
                    }
                    txtAmount.Text = Common.ConvertToStringCurrancy(dgvPaidInPaidOut["Amount", dgvPaidInPaidOut.CurrentCell.RowIndex].Value.ToString());
                    txtAmount.Focus();
                    txtAmount.SelectAll();

                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void dgvPaidInPaidOut_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (isRecall) { return; }
                    PaidInPaidOutService paidInPaidOutService = new PaidInPaidOutService();

                    if (dgvPaidInPaidOut.Rows.Count > 0)
                    {
                        if (dgvPaidInPaidOut["PaidInPaidOutCode", dgvPaidInPaidOut.CurrentCell.RowIndex].Value.ToString() == string.Empty) { return; }
                        if (tranasactionType == 1)
                        {
                            paidInType = new PaidInType();
                            paidInType = paidInPaidOutService.GetActivePaidInTypeByCode(dgvPaidInPaidOut["PaidInPaidOutCode", dgvPaidInPaidOut.CurrentCell.RowIndex].Value.ToString());
                            if (paidInType != null)
                            {
                                paidInPaidOutTemp = new PaidInPaidOutTemp();
                                paidInPaidOutTemp.PaidInPaidOutID = paidInType.PaidInTypeID;
                            }
                        }
                        else
                        {
                            paidOutType = new PaidOutType();
                            paidOutType = paidInPaidOutService.GetActivePaidOutTypeByCode(dgvPaidInPaidOut["PaidInPaidOutCode", dgvPaidInPaidOut.CurrentCell.RowIndex].Value.ToString());
                            if (paidOutType != null)
                            {
                                paidInPaidOutTemp = new PaidInPaidOutTemp();
                                paidInPaidOutTemp.PaidInPaidOutID = paidOutType.PaidOutTypeID;
                            }
                        }

                        if (SysMessage.ShowMessage(SysMessage.MessageAction.Delete, SysMessage.MessageType.Question, this.Text, dgvPaidInPaidOut["PaidInPaidOutCode", dgvPaidInPaidOut.CurrentCell.RowIndex].Value.ToString() + " - " + dgvPaidInPaidOut["PaidInPaidOutName", dgvPaidInPaidOut.CurrentCell.RowIndex].Value.ToString()).Equals(DialogResult.No)) { return; };


                        paidInPaidOutTempList = paidInPaidOutService.GetUpdatedInvestigationListWithDelete(paidInPaidOutTempList, paidInPaidOutTemp);
                        dgvPaidInPaidOut.DataSource = paidInPaidOutTempList;
                        dgvPaidInPaidOut.Refresh();
                        Summarize();


                    }
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void pd_PrintPaidInPaidOut(object sender, PrintPageEventArgs e)
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
            }

            string dashLine = new string('-', (int)counter.DashWidth);

            textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
            startX = marginX;
            graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
            startY += lineHeightNormal;

            string header = "";

            if (tranasactionType == 1)
            {
                header = "Paid In";
            }
            else if (tranasactionType == 2)
            {
                header = "Paid Out";
            }

            textWidth = e.Graphics.MeasureString(header, fontDoubleHeight).Width;
            startX = (pageWidth - (marginX * 2) - textWidth) / 2;
            graphics.DrawString(header, fontDoubleHeight, brush, startX, startY);
            startY += lineHeightDoubleHeight;

            textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
            startX = marginX;
            graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
            startY += lineHeightNormal;

            startX = marginX;
            graphics.DrawString("Date :" + DateTime.Now.Date.ToString("dd-MMM-yyyy"), fontNormal, brush, startX, startY);
            startY += lineHeightNormal;

            startX = marginX;
            graphics.DrawString("Location : " + Common.LoggedLocation.Trim(), fontNormal, brush, startX, startY);
            startY += lineHeightNormal;

            graphics.DrawString("Staff : " + Common.LoggedUserName.Trim(), fontNormal, brush, startX, startY);
            startY += lineHeightNormal;

            PaidInPaidOutService paidInPaidOutService = new PaidInPaidOutService();
            paidInPaidOutMain = new PaidInPaidOutMain();
            paidInPaidOutMain = paidInPaidOutService.GetAllPaidInPaidOutByDocumentNoAndTypeAndCounterID(documentNo, tranasactionType, Common.CounterNo, formInfo.DocumentID);

            if (paidInPaidOutMain != null)
            {
                startX = marginX;
                graphics.DrawString("Document No :  " + documentNo.Trim(), fontNormal, brush, startX, startY);
                startY += lineHeightNormal;

                startX = marginX;
                graphics.DrawString("Person :  " + paidInPaidOutMain.Person.Trim(), fontNormal, brush, startX, startY);
                startY += lineHeightNormal;

                textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
                startX = marginX;
                graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
                startY += lineHeightNormal;

                DataTable dtPaidInPaidOutSub = paidInPaidOutService.GetAllPaidInPaidOutSubByPaidInPaidOutMainID(paidInPaidOutMain.PaidInPaidOutMainID, tranasactionType);

                if (dtPaidInPaidOutSub != null && dtPaidInPaidOutSub.Rows.Count > 0)
                {
                    foreach (DataRow row in dtPaidInPaidOutSub.Rows)
                    {
                        startX = marginX;
                        string productDetailLeft = row["PaidInPaidOutTypeName"].ToString();
                        string productDetailRight = Common.ConvertToStringCurrancy(row["Amount"].ToString());

                        graphics.DrawString(productDetailLeft, fontNormal, brush, startX, startY);

                        textWidth = e.Graphics.MeasureString(productDetailRight, fontNormal).Width;
                        startX = pageWidth - (marginX * 2) - textWidth;
                        graphics.DrawString(productDetailRight, fontNormal, brush, startX, startY);
                        startY += lineHeightNormal;
                    }
                }

                textWidth = e.Graphics.MeasureString(dashLine, fontNormal).Width;
                startX = marginX;
                graphics.DrawString(dashLine, fontNormal, brush, startX, startY);
                startY += lineHeightNormal;

                startX = marginX;
                graphics.DrawString("Unit : " + counter.CounterCode.Trim(), fontNormal, brush, startX, startY);
                startY += lineHeightNormal;

                startX = marginX;
                graphics.DrawString("End Time : " + paidInPaidOutMain.CreatedDate.ToString("hh:mm:ss tt"), fontNormal, brush, startX, startY);
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
        }

        public void PrintPaidInPaidOut()
        {
            PrintDocument printPaidInPaidOut = new PrintDocument();
            printPaidInPaidOut.PrinterSettings.PrinterName = POSPrinter.printerName;

            printPaidInPaidOut.PrintPage += new PrintPageEventHandler(pd_PrintPaidInPaidOut);

            PrintController printController = new StandardPrintController();
            printPaidInPaidOut.PrintController = printController;

            printPaidInPaidOut.Print();
        }
        #endregion
    }
}
