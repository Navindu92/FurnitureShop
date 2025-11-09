using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

using NSoft.ERP.Service.General;
using NSoft.ERP.Domain;
using NSoft.ERP.Utility;
using NSoft.ERP.Domain.General;
using NSoft.ERP.UI.Windows.Inventory;
using NSoft.ERP.UI.Windows.Device;

namespace NSoft.ERP.UI.Windows.General
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        public FrmLogin(MdiMain mdiMain)
        {
            InitializeComponent();
            this.mdiMain = mdiMain;
        }
        private MdiMain mdiMain;
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;
                cmbLocation.Text = string.Empty;
                cmbLocation.SelectedIndex = -1;
                cmbLocation.DataSource = null;
                txtUsername.Focus();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                bool isValid = false;
                UserService userService = new UserService();
                User user = new User();
                user = userService.CheckUserLogin(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                if (user != null)
                {
                    isValid = userService.CheckUserLoginLocation(txtUsername.Text.Trim(), cmbLocation.Text.Trim());
                    if (isValid)
                    {
                        Common.LoggedUserID = user.UserID;
                        Common.LoggedUserName = user.Username.Trim();
                        Common.LoggedLocation = cmbLocation.Text;
                        Common.IsDeveloper = user.IsDeveloper;

                        if (Common.IsPosCounter)
                        {
                            this.Hide();

                            CounterService counterService = new CounterService();
                            CounterTransaction counterTransaction = new CounterTransaction();
                            Counter counter = counterService.GetCounterByCounterNoAndLocationID(Common.CounterNo, Common.LoggedLocationID);
                            counterTransaction = counterService.GetCounterTransactionByLocationCounterAndDateAndZno(Common.LoggedLocationID, Common.CounterNo, 1, DateTime.Now.Date, counter.Zno);
                            if (counterTransaction != null)
                            {
                                FrmInvoice frmInvoice = new FrmInvoice();
                                frmInvoice.ShowDialog();
                            }

                            else
                            {
                                SysMessage.ShowMessage(SysMessage.MessageAction.CounterNotOpen, SysMessage.MessageType.Error, this.Text);
                                FrmCounterTranasaction frmCounterTranasaction = new FrmCounterTranasaction(1,"CounterOpenInventory");
                                frmCounterTranasaction.ShowDialog();
                                return;
                            }
                        }
                        else
                        {
                            mdiMain.GetUserPrivileges(user.Username);
                            SetLoggedStatus();
                            SetLocationAddress();
                        }
                        this.Dispose();
                    }
                    else
                    {
                        SysMessage.ShowMessage(SysMessage.MessageAction.LoginLocationNotFound, SysMessage.MessageType.Error, this.Text);
                        txtUsername.Focus();
                    }

                }
                else
                {
                    SysMessage.ShowMessage(SysMessage.MessageAction.LoginNotFound, SysMessage.MessageType.Error, this.Text);
                    txtUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = txtUsername;
                //mdiMain.timer1.Enabled = true;
                //mdiMain.lblStatusUser.Text = string.Empty;
                //mdiMain.lblDisplayUsername.Text = string.Empty;
                //mdiMain.lblStatusLocation.Text = string.Empty;
                //mdiMain.lblDisplayLocation.Text = string.Empty;


                txtUsername.Focus();


                //temp login
                //txtUsername.Text = "admin";
                //txtPassword.Text = "12345";
                //cmbLocation.Focus();

            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtPassword.Focus();
                    e.SuppressKeyPress = true;
                }

            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }

        private void LoadLocations()
        {
            try
            {
                UserService userService = new UserService();
                List<Location> allowLocationList = new List<Location>();
                cmbLocation.DataSource = null;
                allowLocationList = userService.GetUserAllowLocations(txtUsername.Text.Trim());
                if (allowLocationList.Count > 0)
                {
                    cmbLocation.DataSource = allowLocationList;
                    cmbLocation.ValueMember = "LocationID";
                    cmbLocation.DisplayMember = "LocationName";
                    cmbLocation.SelectedIndex = 0;
                }

                //if (true)
                //{
                //    cmbLocation.SelectedValue = Common.LoggedLocationID;
                //}
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            LoadLocations();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (Common.IsPosCounter)
                    {
                        btnLogin.Focus();
                    }
                    else
                    {
                        cmbLocation.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void cmbLocation_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnLogin.PerformClick();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        public void SetLoggedStatus()
        {
            //mdiMain.lblStatusLocation.Font = new Font(mdiMain.lblStatusLocation.Font, FontStyle.Bold);
            //mdiMain.lblDisplayLocation.Font = new Font(mdiMain.lblDisplayLocation.Font, FontStyle.Bold);
            //mdiMain.lblStatusUser.Font = new Font(mdiMain.lblStatusUser.Font, FontStyle.Bold);
            //mdiMain.lblDisplayUsername.Font = new Font(mdiMain.lblDisplayUsername.Font, FontStyle.Bold);
            //mdiMain.lblStatusDate.Font = new Font(mdiMain.lblStatusDate.Font, FontStyle.Bold);
            //mdiMain.lblDispalyDate.Font = new Font(mdiMain.lblDispalyDate.Font, FontStyle.Bold);
            //mdiMain.lblStatusTime.Font = new Font(mdiMain.lblStatusTime.Font, FontStyle.Bold);
            //mdiMain.lblDispalyTime.Font = new Font(mdiMain.lblDispalyTime.Font, FontStyle.Bold);

            //mdiMain.lblStatusUser.Text = "Username  :: ";
            //mdiMain.lblDisplayUsername.Text = Common.LoggedUserName.First().ToString().ToUpper() + String.Join("", Common.LoggedUserName.ToLower().Skip(1))+"     ";
            //mdiMain.lblStatusLocation.Text = "Logged Location  :: ";
            //mdiMain.lblDisplayLocation.Text = Common.LoggedLocation + "     ";
            //mdiMain.lblStatusDate.Text = "Date :: ";
            //mdiMain.lblStatusTime.Text = "Time :: ";

            try
            {
                mdiMain.lblStatusLocation.Font = new Font(mdiMain.lblStatusLocation.Font, FontStyle.Bold);
                mdiMain.lblStatusUser.Font = new Font(mdiMain.lblStatusUser.Font, FontStyle.Bold);
                mdiMain.lblStatusDate.Font = new Font(mdiMain.lblStatusDate.Font, FontStyle.Bold);
                mdiMain.lblStatusTime.Font = new Font(mdiMain.lblStatusTime.Font, FontStyle.Bold);
                mdiMain.lblStatusServer.Font = new Font(mdiMain.lblStatusServer.Font, FontStyle.Bold);

                mdiMain.lblStatusUser.Text = "Logged User :: " + Common.LoggedUserName;
                mdiMain.lblStatusLocation.Text = "Logged Location :: " + Common.LoggedLocation;
                mdiMain.lblStatusDate.Text = "Date :: " + DateTime.Now.ToLongDateString() + "  ";
                mdiMain.lblStatusTime.Text = "Time :: " + DateTime.Now.ToLongTimeString() + "  ";
                mdiMain.lblStatus.Text = " :: Ready √ ";
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }
        public void SetLocationAddress()
        {
            try
            {
                LocationService locationService = new LocationService();
                Common.Address = locationService.GetActiveLocationByName(Common.LoggedLocation).Address;
                Common.LoggedLocationID = locationService.GetActiveLocationByName(Common.LoggedLocation).LocationID;
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

    }
}
