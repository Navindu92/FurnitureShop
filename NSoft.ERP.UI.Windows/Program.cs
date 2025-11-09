using NSoft.ERP.UI.Windows.General;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NSoft.ERP.Utility;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using NSoft.ERP.Service.General;

namespace NSoft.ERP.UI.Windows
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //IsSystemFormat = CheckSystemDateFormat();
            //if (!IsSystemFormat) { return; }

            //EncryptFiles();
            //EncryptNew();

            Common.LoggedPCName = Environment.MachineName;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Common.IsPosCounter = Common.ConvertStringToBool(System.Configuration.ConfigurationManager.AppSettings["IsPosCounter"]);
            Common.IsShowDeveloperLogo = Common.ConvertStringToBool(System.Configuration.ConfigurationManager.AppSettings["IsShowDeveloperLogo"]);

            if (Common.IsPosCounter)
            {
                ConnectionService connectionService = new ConnectionService();

                if (connectionService.CheckConnectionString())
                {
                    if (connectionService.CheckIsValidCounter())
                    {
                        Application.Run(new NSoft.ERP.UI.Windows.Inventory.FrmInvoice());
                    }
                    else
                    {
                        Application.Run(new NSoft.ERP.UI.Windows.Inventory.FrmPOSConfiguration());
                    }

                }
                else
                {
                    Application.Run(new NSoft.ERP.UI.Windows.General.FrmConnection());
                }

            }
            else
            {
                Application.Run(new NSoft.ERP.UI.Windows.General.FrmSplash());
            }
        }

        public static FrmSplash splash = null;
        public static MdiMain mdi = null;
        public static FrmLogin frmLogin = null;
        public static bool IsSystemFormat = false;
        public static void ShowLogin()
        {
            mdi = new MdiMain();
            mdi.Show();
            frmLogin = new FrmLogin(mdi);
            frmLogin.MdiParent = mdi;
            frmLogin.Show();
        }

        public static bool CheckSystemDateFormat()
        {
            bool IsSystemFormat = true;
            string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
            string defaultFormat = "dd/MM/yyyy";
            if (sysFormat != defaultFormat)
            {
                SysMessage.ShowMessage(SysMessage.MessageAction.General, SysMessage.MessageType.Information, "Date Format", "Your System Date Format is " + sysFormat + ",\n Required Format is " + defaultFormat);
                IsSystemFormat = false;
            }
            return IsSystemFormat;
        }
        private static void EncryptFiles()
        {
            if (File.Exists("NSoft.ERP.UI.Windows.exe"))
            {
                EncryptConnectionString(true, "NSoft.ERP.UI.Windows.exe");
            }
            else
            {
                MessageBox.Show("File not exist");
            }

            if (File.Exists("NSoft.ERP.UI.Windows.vshost.exe"))
            {
                EncryptConnectionString(true, "NSoft.ERP.UI.Windows.vshost.exe");
            }
            else
            {
                MessageBox.Show("File not exist");
            }
        }
        public static void EncryptConnectionString(bool encrypt, string fileName)
        {
            Configuration configuration = null;
            try
            {
                // Open the configuration file and retrieve the connectionStrings section.
                configuration = ConfigurationManager.OpenExeConfiguration(fileName);
                ConnectionStringsSection configSection = configuration.GetSection("connectionStrings") as ConnectionStringsSection;
                if ((!(configSection.ElementInformation.IsLocked)) && (!(configSection.SectionInformation.IsLocked)))
                {
                    if (encrypt && !configSection.SectionInformation.IsProtected)
                    {
                        //this line will encrypt the file
                        configSection.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                    }

                    if (!encrypt && configSection.SectionInformation.IsProtected)//encrypt is true so encrypt
                    {
                        //this line will decrypt the file. 
                        configSection.SectionInformation.UnprotectSection();
                    }
                    //re-save the configuration file section
                    configSection.SectionInformation.ForceSave = true;
                    // Save the current configuration

                    configuration.Save();
                    //Process.Start("notepad.exe", configuration.FilePath);
                    //configFile.FilePath 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private static void EncryptNew()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration("NSoft.ERP.UI.Windows.exe");
            ConnectionStringsSection consection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            consection.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
            config.Save();

            config = ConfigurationManager.OpenExeConfiguration("NSoft.ERP.UI.Windows.vshost.exe");
            consection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            consection.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
            config.Save();
        }
    }
}
