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
    public partial class FrmBaseMaster : Form
    {
        public FrmBaseMaster()
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
            if (File.Exists(Common.binPath + "/Images/Delete.png"))
            {
                btnDelete.Image = Image.FromFile(Common.binPath + "/Images/Delete.png");
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
        public virtual void Delete()
        {
        }
        public virtual void Clear()
        {
            Common.ClearAllControls(this);
            errorProvider1.Clear();
            Initialize();
        }


        private void FrmBaseMaster_Load(object sender, EventArgs e)
        {
            FormLoad();
            Initialize();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (Common.SpecialFeatures.IsConfirmBeforeCloseMasterFiles)
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
            if (Common.SpecialFeatures.IsConfirmBeforeClearMasterFiles)
            {
                if (SysMessage.ShowMessage(SysMessage.MessageAction.ClearForm, SysMessage.MessageType.Question, "Clear Form").Equals(DialogResult.Yes))
                {
                    Clear();
                }
            }
            else
            { Clear(); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void FrmBaseMaster_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            { btnClose.PerformClick(); }
        }
    }
}
