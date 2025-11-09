using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using NSoft.ERP.Utility;
namespace NSoft.ERP.UI.Windows.General
{
    public partial class FrmBaseTransation : Form
    {
        public FrmBaseTransation()
        {
            InitializeComponent();

            if (File.Exists(Common.binPath + "/Images/Clear.png"))
            {
                btnClear.Image = Image.FromFile(Common.binPath + "/Images/Clear.png");
            }
            if (File.Exists(Common.binPath + "/Images/Close.png"))
            {
                btnClose.Image = Image.FromFile(Common.binPath + "/Images/Close.png");
            }
            if (File.Exists(Common.binPath + "/Images/View.png"))
            {
                btnView.Image = Image.FromFile(Common.binPath + "/Images/View.png");
            }
            if (File.Exists(Common.binPath + "/Images/Save.png"))
            {
                btnSave.Image = Image.FromFile(Common.binPath + "/Images/Save.png");
            }
        }
        public virtual void FormLoad()
        {
        }
        public virtual void Initialize()
        {
        }
        public virtual void Save()
        {
        }
        public virtual void View()
        {
        }
        public virtual void Clear()
        {
            Common.ClearAllControls(this);
            errorProvider1.Clear();
            Initialize();
        }

        private void FrmBaseTransation_Load(object sender, EventArgs e)
        {
            FormLoad();
            Initialize();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (Common.SpecialFeatures.IsConfirmBeforeCloseTransaction)
            {
                if (SysMessage.ShowMessage(SysMessage.MessageAction.Close, SysMessage.MessageType.Question, "Close Form").Equals(DialogResult.Yes))
                {
                    this.Close();
                    this.Dispose();
                }
            }
            else
            {
                this.Close();
                this.Dispose();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (Common.SpecialFeatures.IsConfirmBeforeClearTransaction)
            {
                if (SysMessage.ShowMessage(SysMessage.MessageAction.ClearForm, SysMessage.MessageType.Question, "Clear Form").Equals(DialogResult.Yes))
                {
                    Clear();
                }
            }
            else
            { Clear(); }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            View();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void FrmBaseTransation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            { btnClose.PerformClick(); }
        }
    }
}
