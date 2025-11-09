using Microsoft.Win32;
using NSoft.ERP.Domain.General;
using NSoft.ERP.Domain.Inventory;
using NSoft.ERP.Service.General;
using NSoft.ERP.Service.Inventory;
using NSoft.ERP.UI.Windows.Device;
using NSoft.ERP.UI.Windows.Inventory;
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

namespace NSoft.ERP.UI.Windows.General
{
    public partial class FrmPOSLogin : Form
    {
        public FrmPOSLogin()
        {
            InitializeComponent();
        }

        bool isPressedCTRL = false, isPressedD = false, isPressedS = false;

        Counter counter = new Counter();

        private void FrmPOSLogin_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Common.IsShowDeveloperLogo)
                {
                    pbDeveloperLogo.Visible = false;
                }

                lblServer.Text = "Server : " + CommonService.GetServerName(Common.connectionString);

                lblCompanyName.Text = Common.CompanyName.Trim();
                lblAddress1.Text = Common.Address1.Trim();
                lblAddress2.Text = Common.Address2.Trim();

                this.ActiveControl = txtPassword;
                txtPassword.Focus();

                timer1.Enabled = true;
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
            }
        }
        private void CheckIsValidCounter()
        {
            try
            {
                Common.LoggedLocationID = long.Parse(Environment.GetEnvironmentVariable("LocationID"));
                Common.CounterNo = long.Parse(Environment.GetEnvironmentVariable("CounterNo"));
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.CounterNotFound, SysMessage.MessageType.Error, this.Text, "Please contact System Administrator for more details.");
                FrmSystemConfiguration frmSystemConfiguration = new FrmSystemConfiguration();
                frmSystemConfiguration.ShowDialog();
                Application.Exit();
            }
        }

        public void CheckConnectionString()
        {
            try
            {
                RegistryKey conncetionInfo = null;
                conncetionInfo = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\NSOFT");

                if (conncetionInfo != null)
                {
                    Object connectionString = conncetionInfo.GetValue("Connection");

                    if (connectionString != null)
                    {
                        Common.connectionString = Common.DecryptString(connectionString.ToString());
                    }
                    else
                    {
                        this.Hide();
                        FrmConnection connection = new FrmConnection();
                        connection.ShowDialog();
                    }
                }
                else
                {
                    this.Hide();
                    FrmConnection connection = new FrmConnection();
                    connection.ShowDialog();

                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.CounterNotFound, SysMessage.MessageType.Error, this.Text, "Please contact System Administrator for more details.");
                Application.Exit();
            }
        }


        private void FrmPOSLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                timer1.Enabled = false;
                Application.Exit();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.CounterNotFound, SysMessage.MessageType.Error, this.Text, "Please contact System Administrator for more details.");
                Application.Exit();
            }
        }

        private void FrmPOSLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CustomerDisplay.isDisplayConnected)
            {
                CustomerDisplay.DisplayText(CustomerDisplay.eClear);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtPassword.Focus();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    CashierService cashierService = new CashierService();
                    Cashier cashier = new Cashier();
                    cashier = cashierService.CheckCashierLogin(txtPassword.Text.Trim());
                    if (cashier != null)
                    {

                        Common.LoggedUserID = cashier.CashierID;
                        Common.LoggedUserName = cashier.CashierName.Trim();
                        Common.IsDeveloper = cashier.IsDeveloper;
                        Common.IsLogin = true;

                        if (Common.IsPosCounter)
                        {
                            timer1.Enabled = false;
                            this.Hide();
                        }


                    }
                    else
                    {
                        FrmPOSLoginFaild frmPOSLoginFaild = new FrmPOSLoginFaild();
                        frmPOSLoginFaild.ShowDialog();

                        //SysMessage.ShowMessage(SysMessage.MessageAction.LoginNotFound, SysMessage.MessageType.Error, this.Text);
                        txtPassword.Focus();
                        txtPassword.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void FrmPOSLogin_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    Application.Exit();
                }

                if (e.KeyCode == Keys.ControlKey)
                    isPressedCTRL = true;

                if (e.KeyCode == Keys.D)
                    isPressedD = true;

                if (e.KeyCode == Keys.S)
                    isPressedS = true;

                if (isPressedCTRL && isPressedD)
                {
                    this.Hide();
                    FrmConnection connection = new FrmConnection();
                    connection.ShowDialog();
                }

                if (isPressedCTRL && isPressedS)
                {
                    this.Hide();
                    FrmPOSConfiguration frmPOSConfiguration = new FrmPOSConfiguration();
                    frmPOSConfiguration.ShowDialog();
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
