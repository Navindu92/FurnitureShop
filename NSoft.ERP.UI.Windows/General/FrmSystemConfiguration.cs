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
using System.Diagnostics;
using NSoft.ERP.Service.General;

namespace NSoft.ERP.UI.Windows.General
{
    public partial class FrmSystemConfiguration : FrmBaseMaster
    {
        public FrmSystemConfiguration()
        {
            InitializeComponent();
        }
        FormInfo formInfo;
        Location location;
        UserPrivileges userPrivileges;
        UserService userService = new UserService();
        bool isAutogenerate = false;

        public override void FormLoad()
        {
            try
            {
                formInfo = new FormInfo();
                formInfo = FormInfoService.GetFormInfoByName(this.Name);
                if (formInfo != null)
                {
                    this.Text = formInfo.FormText.Trim();
                    isAutogenerate = formInfo.IsAutoGenerate;
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
                ClearUserControles();
                treeView1.CollapseAll();

                CounterService counterService = new CounterService();
                usrCounter1.cmbCounter.DataSource = counterService.GetAllActiveCounters();
                usrCounter1.cmbCounter.DisplayMember = "CounterName";
                usrCounter1.cmbCounter.ValueMember = "CounterNo";
                usrCounter1.cmbCounter.SelectedIndex = -1;
                usrCounter1.cmbCounter.Refresh();

                LocationService locationService = new LocationService();
                usrCounter1.cmbLocation.DataSource = locationService.GetAllActiveLocations();
                usrCounter1.cmbLocation.DisplayMember = "LocationName";
                usrCounter1.cmbLocation.ValueMember = "LocationID";
                usrCounter1.cmbLocation.SelectedIndex = -1;
                usrCounter1.cmbLocation.Refresh();

                base.Initialize();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }

        }
        private void ClearUserControles()
        {
            Common.VisibleUserControl(false, usrCounter1);
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            if (node.Name == "CounterTreeNode")
            {
                Common.VisibleUserControl(true, usrCounter1);
                if (Common.CounterNo != 0)
                {
                    usrCounter1.cmbCounter.SelectedValue = Common.CounterNo;
                }
            }

        }
        public override void Save()
        {
            try
            {
                if (usrCounter1.isCounterChange)
                {
                    SaveCounter();
                }
                base.Save();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void SaveCounter()
        {
            Environment.SetEnvironmentVariable("LocationID", usrCounter1.cmbLocation.SelectedValue.ToString(), EnvironmentVariableTarget.User);
            Environment.SetEnvironmentVariable("CounterNo", usrCounter1.cmbCounter.SelectedValue.ToString(), EnvironmentVariableTarget.User);
            Process.Start("shutdown", "/r /t 0");
        }
    }

}
