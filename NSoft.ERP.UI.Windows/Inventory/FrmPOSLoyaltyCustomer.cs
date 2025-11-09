using NSoft.ERP.Domain.CRM;
using NSoft.ERP.Service.CRM;
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
    public partial class FrmPOSLoyaltyCustomer : Form
    {
        public FrmPOSLoyaltyCustomer()
        {
            InitializeComponent();
        }

        public FrmPOSLoyaltyCustomer(bool isSelectOnly)
        {
            InitializeComponent();
            this.isSelectOnly = isSelectOnly;
        }

        bool isLoyaltyFound = false;
        bool isSelectOnly = false;
        public LoyaltyCustomer loyaltyCustomer = null;
        private void FrmPOSLoyaltyCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    if (isLoyaltyFound)
                    {
                        this.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void FrmPOSLoyaltyCustomer_Load(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = txtCommon;
                txtCommon.Focus();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtCommon_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtCommon.Text.Trim() != string.Empty)
                    {
                        LoadLoyaltyCustomer(txtCommon.Text.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }
        private void LoadLoyaltyCustomer(string strSearch)
        {
            try
            {
                LoyaltyCustomer loyaltyCustomer = new LoyaltyCustomer();
                LoyaltyCustomerService loyaltyCustomerService = new LoyaltyCustomerService();
                loyaltyCustomer = loyaltyCustomerService.GetLoyaltyCustomerByReference(strSearch);
                if (loyaltyCustomer != null)
                {
                    txtCardNo.Text = loyaltyCustomer.CardNo.Trim();
                    txtCustomerName.Text = loyaltyCustomer.LoyaltyCustomerName.Trim();
                    txtMobileNo.Text = loyaltyCustomer.MobileNo.Trim();
                    txtNIC.Text = loyaltyCustomer.NICNo.Trim();
                    lblCurrentPoints.Text = loyaltyCustomer.CurrentPoints.ToString();

                    isLoyaltyFound = true;

                    this.loyaltyCustomer = loyaltyCustomer;
                }
                else
                {
                    if (isSelectOnly)
                    {

                    }
                    else
                    {
                        if (SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Question, this.Text, "Loyalty Customer Not Found.Do You Want To Create New Customer?") == DialogResult.Yes)
                        {
                            Common.ReadOnlyTextBox(true, txtCommon);
                            Common.ReadOnlyTextBox(false, txtCardNo);
                            Common.ClearTextBox(txtCommon);
                            txtCardNo.Focus();
                        }
                        else
                        {
                            Common.ClearTextBox(txtCommon);
                            txtCommon.Focus();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtCardNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtCardNo.Text.Length != Common.LoyaltyCardLength)
                    {
                        SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Error, this.Text, "Invalid Loyalty Card No.");
                        txtCardNo.Focus();
                        return;
                    }
                    else
                    {
                        if (txtCardNo.Text.Trim() != string.Empty)
                        {
                            LoyaltyCustomerService loyaltyCustomerService = new LoyaltyCustomerService();
                            if (loyaltyCustomerService.CheckLoyaltyCardNo(txtCardNo.Text.Trim()))
                            {
                                SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Error, this.Text, "Loyalty Phone No Already Exit.");
                                txtCardNo.Focus();
                                return;
                            }
                            else
                            {
                                Common.ReadOnlyTextBox(true, txtCardNo);
                                Common.ReadOnlyTextBox(false, txtCustomerName);
                                Common.ClearTextBox(txtCustomerName);
                                txtCustomerName.Focus();
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtCustomerName.Text.Trim() == string.Empty)
                    {
                        SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Error, this.Text, "Invalid Cutomer Name");
                        txtCustomerName.Focus();
                        return;
                    }
                    else
                    {
                        Common.ReadOnlyTextBox(true, txtCustomerName);
                        Common.ReadOnlyTextBox(false, txtMobileNo);
                        txtMobileNo.Focus();
                    }

                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }

        private void txtMobileNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtMobileNo.Text.Length != 10)
                    {
                        SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Error, this.Text, "Invalid Mobile No.");
                        txtMobileNo.Focus();
                        return;
                    }
                    else
                    {
                        if (txtMobileNo.Text.Trim() != string.Empty)
                        {
                            LoyaltyCustomerService loyaltyCustomerService = new LoyaltyCustomerService();
                            if (loyaltyCustomerService.CheckLoyaltyPhoneNo(txtMobileNo.Text.Trim()))
                            {
                                SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Error, this.Text, "Loyalty Phone No Already Exit.");
                                txtMobileNo.Focus();
                                return;
                            }
                            else
                            {
                                Common.ReadOnlyTextBox(true, txtMobileNo);
                                Common.ReadOnlyTextBox(false, txtNIC);
                                txtNIC.Focus();
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtNIC_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    if (txtNIC.Text.Trim() != string.Empty)
                    {
                        LoyaltyCustomerService loyaltyCustomerService = new LoyaltyCustomerService();
                        if (loyaltyCustomerService.CheckLoyaltyNicNo(txtNIC.Text.Trim()))
                        {
                            SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Error, this.Text, "NIC No Already Exit.");
                            txtNIC.Focus();
                            return;
                        }
                        else
                        {
                            SaveLoyaltyCustomer();
                            this.Close();
                        }

                    }
                    else
                    {
                        SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Error, this.Text, "Invalid NIC No");
                        txtNIC.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void SaveLoyaltyCustomer()
        {
            try
            {
                LoyaltyCustomer loyaltyCustomer = new LoyaltyCustomer();
                loyaltyCustomer.CardNo = txtCardNo.Text.Trim();
                loyaltyCustomer.LoyaltyCustomerName = txtCustomerName.Text.Trim();
                loyaltyCustomer.NICNo = txtNIC.Text.Trim();
                loyaltyCustomer.MobileNo = txtMobileNo.Text.Trim();
                loyaltyCustomer.DateOfBirth = new DateTime(1900, 1, 1);
                loyaltyCustomer.Address = string.Empty;
                loyaltyCustomer.LoyaltyCardID = 1;
                loyaltyCustomer.IsActive = true;
                loyaltyCustomer.IsBlackList = false;
                loyaltyCustomer.IsDelete = false;
                loyaltyCustomer.ExpiryDate = DateTime.Now.Date.AddYears(4);
                loyaltyCustomer.EarnPoints = 0;
                loyaltyCustomer.RedeemPoints = 0;
                loyaltyCustomer.CurrentPoints = 0;

                LoyaltyCustomerService loyaltyCustomerService = new LoyaltyCustomerService();
                loyaltyCustomerService.AddLoyaltyCustomer(loyaltyCustomer);

            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

      
    }
}
