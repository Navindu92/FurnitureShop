using NSoft.ERP.UI.Windows.Device;
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
    public partial class FrmDualDisplay : Form
    {
        public FrmDualDisplay()
        {
            InitializeComponent();
        }

        private void FrmDualDisplay_Load(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = true;
                axWindowsMediaPlayer1.URL = DualDisplay.VideoPath;
                axWindowsMediaPlayer1.settings.autoStart = true;
                axWindowsMediaPlayer1.settings.setMode("loop", true);
                axWindowsMediaPlayer1.uiMode = "none";
                axWindowsMediaPlayer1.stretchToFit = true;
                axWindowsMediaPlayer1.Dock = DockStyle.Fill;
                axWindowsMediaPlayer1.settings.mute = false;
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (lblHeader.ForeColor == Color.White)
                    lblHeader.ForeColor = Color.Black;
                else
                    lblHeader.ForeColor = Color.White;
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
    }
}
