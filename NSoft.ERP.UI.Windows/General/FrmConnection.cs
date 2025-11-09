using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NSoft.ERP.Utility;

namespace NSoft.ERP.UI.Windows.General
{
    public partial class FrmConnection : FrmBaseMaster
    {
        public FrmConnection()
        {
            InitializeComponent();
        }

        RegistryKey connectionInfo = null;
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public override void Save()
        {
            connectionInfo = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\NSOFT\INVENTORY");

            string server = txtServer.Text.Trim();
            string dbName = txtDatabase.Text.Trim();
            string user = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            string connectionString = Common.EncryptString("Data Source=" + server + ";Initial Catalog=" + dbName + ";Integrated Security=false;Persist Security Info=true;User ID=" + user + ";Password=" + password + ";MultipleActiveResultSets=True");

            connectionInfo = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\NSOFT\INVENTORY");
            connectionInfo.SetValue("Connection", connectionString);
            connectionInfo.SetValue("IsPosCounter", chkIsPosCounter.Checked);
            connectionInfo.Close();

            Application.Restart();
            base.Save();
        }
        public override void Delete()
        {
            connectionInfo= Registry.CurrentUser.OpenSubKey(@"SOFTWARE", true);
            connectionInfo.DeleteSubKeyTree(@"NSOFT\INVENTORY", true);
            connectionInfo.Close();
            Application.Restart();
            base.Delete();  
        }
        public override void FormLoad()
        {
            base.FormLoad();

        }
    }
}
