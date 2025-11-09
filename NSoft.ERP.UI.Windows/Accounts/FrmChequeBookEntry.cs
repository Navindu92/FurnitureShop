using NSoft.ERP.Domain.General;
using NSoft.ERP.Service.General;
using NSoft.ERP.UI.Windows.General;
using NSoft.ERP.Service.Accounts;
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
using NSoft.ERP.Domain.Accounts;

namespace NSoft.ERP.UI.Windows.Accounts
{
    public partial class FrmChequeBookEntry : FrmBaseMaster
    {
        FormInfo formInfo;
        UserPrivileges userPrivileges;
        UserService userService = new UserService();
        List<ChequeBookEntry> chequeBookEntryList = new List<ChequeBookEntry>();

        public FrmChequeBookEntry()
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
                ReferenceInfoService referenceInfoService = new ReferenceInfoService();
                cmbNoOfPages.DataSource = referenceInfoService.GetReferenceValuesByID((int)Common.ReferenceType.ChequeBookPageCount);
                cmbNoOfPages.DisplayMember = "ReferenceValue";
                cmbNoOfPages.ValueMember = "SubNo";
                cmbNoOfPages.SelectedIndex = -1;
                cmbNoOfPages.Refresh();

                chequeBookEntryList = new List<ChequeBookEntry>();
                dgvChequeNumbers.DataSource = null;
                dgvChequeNumbers.Refresh();

                Common.EnableButton(false, btnSave,btnDelete);

                this.ActiveControl = cmbNoOfPages;
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
                if (chequeBookEntryList.Count > 0)
                {
                    ChequeBookEntryService chequeBookEntryService = new ChequeBookEntryService();
                    if (chequeBookEntryService.Save(chequeBookEntryList))
                    {
                        Initialize();
                    }
                }
                base.Save();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        #endregion

        #region Private Methods

        private bool ValidateControls()
        {
            bool isValidate = true;

            if (!Validater.ValidateTextBox(errorProvider1, ValidateType.Empty, txtStartingNo))
            {
                isValidate = false;
            }
            else if (!Validater.ValidateComboBox(errorProvider1, ValidateType.Empty, cmbNoOfPages))
            {
                isValidate = false;
            }

            return isValidate;
        }

        #endregion

        #region KeyDown and Leave

        private void cmbNoOfPages_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtStartingNo.Focus();
            }
        }
        private void txtStartingNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGenerate.Focus();
            }
        }
        private void cmbNoOfPages_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightLable(lblNoOfPages);
        }
        private void txtStartingNo_Leave(object sender, EventArgs e)
        {
            Common.UnHighlightLable(lblStartingNo);
        }

        #endregion

        #region Other

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (ValidateControls())
            {
                ChequeBookEntryService chequeBookEntryService = new ChequeBookEntryService();

                if (!chequeBookEntryService.CheckExistChequeNumbers(txtStartingNo.Text.Trim(), Common.ConvertStringToInt(cmbNoOfPages.Text.Trim())))
                {
                    SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Error, this.Text, "Cheque Serial Already Exists.");
                    return;
                }
             
                chequeBookEntryList = chequeBookEntryService.GenerateChequeNumbers(txtStartingNo.Text.Trim(), Common.ConvertStringToInt(cmbNoOfPages.Text.Trim()));
                dgvChequeNumbers.DataSource = chequeBookEntryList;
                dgvChequeNumbers.Refresh();

                if (userPrivileges == null ? false : userPrivileges.IsSave) { Common.EnableButton(true, btnSave); }
            }
        }

        private void cmbNoOfPages_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblNoOfPages);
        }

        private void txtStartingNo_Enter(object sender, EventArgs e)
        {
            Common.HighlightLable(lblStartingNo);
        }

        #endregion

    }
}
