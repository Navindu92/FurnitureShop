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
using Microsoft.Win32;

using NSoft.ERP.Domain.General;
using NSoft.ERP.Service.General;
using NSoft.ERP.Utility;

namespace NSoft.ERP.UI.Windows.General
{
    public partial class FrmSplash : Form
    {
        public FrmSplash()
        {
            InitializeComponent();
            lblStatus.Text = string.Empty;
            lblVersion.Text = string.Empty;
            lblDayRange.Text = string.Empty;
            lblCompany.Text = string.Empty;
            timer1.Interval = 100;
            timer1.Start();
        }

        RegistryKey ERP_Registry_Info;
        RegistryKey conncetionInfo = null;

        bool isPressedCTRL = false, isPressedD = false;
        private void FrmSplash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void GetCompanyDetails()
        {
            try
            {
                GroupOfCompanyService groupOfCompanyService = new GroupOfCompanyService();
                GroupOfCompany groupOfCompany = new GroupOfCompany();
                groupOfCompany = groupOfCompanyService.GetActiveGroupOfCompany();
                if (groupOfCompany != null)
                {
                    Common.GroupOfCompanyID = groupOfCompany.GroupOfCompanyID;
                    Common.CompanyName = groupOfCompany.GroupOfCompanyName;
                    Common.Address1 = groupOfCompany.Address1.Trim();
                    Common.Address2 = groupOfCompany.Address2.Trim();
                    Common.SetModule(groupOfCompany.GroupOfCompanyID);
                    Common.SetSpecialFeatures(groupOfCompany.GroupOfCompanyID);
                }
            }
            catch (Exception ex)
            {
                timer1.Stop();
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.ConnectionFaild, SysMessage.MessageType.Error, this.Text, "Please contact System Administrator for more details.");
                Application.Exit();
            }
        }

        private void CheckIsValidCounter()
        {
            try
            {
                Common.LoggedLocationID = long.Parse(Environment.GetEnvironmentVariable("INVENTORYLocationID"));
                Common.CounterNo = long.Parse(Environment.GetEnvironmentVariable("INVENTORYCounterNo"));
            }
            catch (Exception ex)
            {
                timer1.Stop();
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.CounterNotFound, SysMessage.MessageType.Error, this.Text, "Please contact System Administrator for more details.");
                FrmSystemConfiguration frmSystemConfiguration = new FrmSystemConfiguration();
                frmSystemConfiguration.ShowDialog();
                Application.Exit();
            }
        }

        private void CheckConnectionString()
        {
            try
            {
                conncetionInfo = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\NSOFT\INVENTORY");

                if (conncetionInfo != null)
                {
                    Object connectionString = conncetionInfo.GetValue("Connection");
                    //Object isPosCounter = conncetionInfo.GetValue("isPosCounter");

                    //Common.IsPosCounter = Common.ConvertStringToBool(System.Configuration.ConfigurationManager.AppSettings["IsPosCounter"]);

                    if (connectionString != null)
                    {
                        Common.connectionString = Common.DecryptString(connectionString.ToString());
                    }
                    else
                    {
                        timer1.Stop();
                        this.Hide();
                        FrmConnection connection = new FrmConnection();
                        connection.ShowDialog();

                    }

                    //if (isPosCounter != null)
                    //{
                    //    if (isPosCounter.ToString() == "True")
                    //    {
                    //        Common.IsPosCounter = true;
                    //    }
                    //    else
                    //    {
                    //        Common.IsPosCounter = false;
                    //    }

                    //}

                }
                else
                {
                    timer1.Stop();
                    this.Hide();
                    FrmConnection connection = new FrmConnection();
                    connection.ShowDialog();

                }
            }
            catch (Exception ex)
            {
                timer1.Stop();
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.CounterNotFound, SysMessage.MessageType.Error, this.Text, "Please contact System Administrator for more details.");
                Application.Exit();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                progressBar.Increment(5);
                if (progressBar.Value == 15)
                {

                    lblStatus.Text = "Reading Files...";
                    timer1.Interval = 500;
                    ERP_Registry_Info = Registry.CurrentUser.OpenSubKey("NSoft.ERP");
                    CheckConnectionString();
                    //if (ERP_Registry_Info == null)
                    //{
                    //    timer1.Stop();
                    //    Toatos.Show(Toatos.MessageType.Warning, Toatos.MessageAction.General, "Registration", "ERP Registration Failed,\n Please Contact System Administrator.");
                    //    this.Close();
                    //    return;
                    //}
                }

                if (progressBar.Value == 25)
                {
                    lblStatus.Text = "Reading Preference...";
                    timer1.Interval = 500;
                }
                if (progressBar.Value == 35)
                {
                    lblStatus.Text = "Initializing Components...";
                    timer1.Interval = 500;
                }
                if (progressBar.Value == 45)
                {
                    lblStatus.Text = "Loading Company...";
                }
                if (progressBar.Value == 55)
                {
                    if (Common.IsPosCounter)
                    {
                        CheckIsValidCounter();
                    }

                    GetCompanyDetails();
                    lblVersion.Text = Common.Version;
                    lblCompany.Text = Common.CompanyName;

                }
                if (progressBar.Value == 65)
                {
                    lblStatus.Text = "Activating Modules...";
                }
                if (progressBar.Value == 70) { timer1.Interval = 600; if (Common.ModuleType.Inventory) { pbInventory.Image = Properties.Resources.Right; } else { pbInventory.Image = Properties.Resources.Wrong; } }
                if (progressBar.Value == 75) { timer1.Interval = 600; if (Common.ModuleType.Account) { pbAccounts.Image = Properties.Resources.Right; } else { pbAccounts.Image = Properties.Resources.Wrong; } }

                if (progressBar.Value == 100)
                {
                    timer1.Stop();
                    this.Hide();
                    if (Common.IsPosCounter)
                    {
                        FrmPOSLogin frmLogin = new FrmPOSLogin();
                        frmLogin.ShowDialog();
                    }
                    else
                    {
                        Program.ShowLogin();
                    }
                }
            }
            catch (Exception ex)
            {
                timer1.Stop();
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
            }
        }

        private void FrmSplash_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.ControlKey)
                    isPressedCTRL = true;

                if (e.KeyCode == Keys.D)
                    isPressedD = true;

                if (isPressedCTRL && isPressedD)
                {
                    timer1.Stop();
                    this.Hide();
                    FrmConnection connection = new FrmConnection();
                    connection.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                timer1.Stop();
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
            }
        }
    }
}
