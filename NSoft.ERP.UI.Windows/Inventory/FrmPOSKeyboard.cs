using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSoft.ERP.UI.Windows.Inventory
{
    public partial class FrmPOSKeyboard : Form
    {
        public FrmPOSKeyboard()
        {
            InitializeComponent();
        }

        bool isCapsLockOn = false;
        public bool isPressEnter = false;
        private void FrmPOSKeyboard_Load(object sender, EventArgs e)
        {
            ChangeCapsLock();
        }

        private void btnTild_Click(object sender, EventArgs e)
        {
            DisplayTypeText(btnTild.Text);
        }

        private void btnCaps_Click(object sender, EventArgs e)
        {
            ChangeCapsLock();
        }

        private void ChangeCapsLock()
        {
            if (isCapsLockOn)
            {
                isCapsLockOn = false;
                lblCapsLock.Text = "Caps Lock Off";
            }
            else
            {
                isCapsLockOn = true;
                lblCapsLock.Text = "Caps Lock On";
            }

            if (isCapsLockOn)
            {
                btnA.Text = btnA.Text.ToUpper();
                btnB.Text = btnB.Text.ToUpper();
                btnC.Text = btnC.Text.ToUpper();
                btnD.Text = btnD.Text.ToUpper();
                btnE.Text = btnE.Text.ToUpper();
                btnF.Text = btnF.Text.ToUpper();
                btnG.Text = btnG.Text.ToUpper();
                btnH.Text = btnH.Text.ToUpper();
                btnI.Text = btnI.Text.ToUpper();
                btnJ.Text = btnJ.Text.ToUpper();
                btnK.Text = btnK.Text.ToUpper();
                btnL.Text = btnL.Text.ToUpper();
                btnM.Text = btnM.Text.ToUpper();
                btnN.Text = btnN.Text.ToUpper();
                btnO.Text = btnO.Text.ToUpper();
                btnP.Text = btnP.Text.ToUpper();
                btnQ.Text = btnQ.Text.ToUpper();
                btnR.Text = btnR.Text.ToUpper();
                btnS.Text = btnS.Text.ToUpper();
                btnT.Text = btnT.Text.ToUpper();
                btnU.Text = btnU.Text.ToUpper();
                btnV.Text = btnV.Text.ToUpper();
                btnW.Text = btnW.Text.ToUpper();
                btnX.Text = btnX.Text.ToUpper();
                btnY.Text = btnY.Text.ToUpper();
                btnZ.Text = btnZ.Text.ToUpper();
            }
            else
            {
                btnA.Text = btnA.Text.ToLower();
                btnB.Text = btnB.Text.ToLower();
                btnC.Text = btnC.Text.ToLower();
                btnD.Text = btnD.Text.ToLower();
                btnE.Text = btnE.Text.ToLower();
                btnF.Text = btnF.Text.ToLower();
                btnG.Text = btnG.Text.ToLower();
                btnH.Text = btnH.Text.ToLower();
                btnI.Text = btnI.Text.ToLower();
                btnJ.Text = btnJ.Text.ToLower();
                btnK.Text = btnK.Text.ToLower();
                btnL.Text = btnL.Text.ToLower();
                btnM.Text = btnM.Text.ToLower();
                btnN.Text = btnN.Text.ToLower();
                btnO.Text = btnO.Text.ToLower();
                btnP.Text = btnP.Text.ToLower();
                btnQ.Text = btnQ.Text.ToLower();
                btnR.Text = btnR.Text.ToLower();
                btnS.Text = btnS.Text.ToLower();
                btnT.Text = btnT.Text.ToLower();
                btnU.Text = btnU.Text.ToLower();
                btnV.Text = btnV.Text.ToLower();
                btnW.Text = btnW.Text.ToLower();
                btnX.Text = btnX.Text.ToLower();
                btnY.Text = btnY.Text.ToLower();
                btnZ.Text = btnZ.Text.ToLower();
            }
        }
        public void DisplayTypeText(string typeText)
        {
            txtKeyboardText.Text += typeText;
        }
        private void btnQ_Click(object sender, EventArgs e)
        {
            DisplayTypeText(btnQ.Text);
        }

        private void btnW_Click(object sender, EventArgs e)
        {
            DisplayTypeText(btnW.Text);
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            DisplayTypeText(btnE.Text);
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            DisplayTypeText(btnR.Text);
        }

        private void btnT_Click(object sender, EventArgs e)
        {
            DisplayTypeText(btnT.Text);
        }

        private void btnY_Click(object sender, EventArgs e)
        {
            DisplayTypeText(btnY.Text);
        }

        private void btnU_Click(object sender, EventArgs e)
        {
            DisplayTypeText(btnU.Text);
        }

        private void btnI_Click(object sender, EventArgs e)
        {
            DisplayTypeText(btnI.Text);
        }

        private void btnO_Click(object sender, EventArgs e)
        {
            DisplayTypeText(btnO.Text);
        }

        private void btnP_Click(object sender, EventArgs e)
        {
            DisplayTypeText(btnP.Text);
        }

        private void btnBracketOpen_Click(object sender, EventArgs e)
        {
            if (isCapsLockOn)
            {
                DisplayTypeText("{");
            }
            else
            {
                DisplayTypeText("[");
            }

        }

        private void btnBracketClose_Click(object sender, EventArgs e)
        {
            if (isCapsLockOn)
            {
                DisplayTypeText("}");
            }
            else
            {
                DisplayTypeText("]");
            }
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            DisplayTypeText(btnA.Text);
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            DisplayTypeText(btnS.Text);
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            DisplayTypeText(btnD.Text);
        }

        private void btnF_Click(object sender, EventArgs e)
        {
            DisplayTypeText(btnF.Text);
        }

        private void btnG_Click(object sender, EventArgs e)
        {
            DisplayTypeText(btnG.Text);
        }

        private void btnH_Click(object sender, EventArgs e)
        {
            DisplayTypeText(btnH.Text);
        }

        private void btnJ_Click(object sender, EventArgs e)
        {
            DisplayTypeText(btnJ.Text);
        }

        private void btnK_Click(object sender, EventArgs e)
        {
            DisplayTypeText(btnK.Text);
        }

        private void btnL_Click(object sender, EventArgs e)
        {
            DisplayTypeText(btnL.Text);
        }

        private void btnSemi_Click(object sender, EventArgs e)
        {
            if (isCapsLockOn)
            {
                DisplayTypeText(":");
            }
            else
            {
                DisplayTypeText(";");
            }
        }

        private void btbComma_Click(object sender, EventArgs e)
        {
            if (isCapsLockOn)
            {
                DisplayTypeText("" + '"' + "");
            }
            else
            {
                DisplayTypeText("'");
            }
        }

        private void btnZ_Click(object sender, EventArgs e)
        {
            DisplayTypeText(btnZ.Text);
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            DisplayTypeText(btnX.Text);
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            DisplayTypeText(btnC.Text);
        }

        private void btnV_Click(object sender, EventArgs e)
        {
            DisplayTypeText(btnV.Text);
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            DisplayTypeText(btnB.Text);
        }

        private void btnN_Click(object sender, EventArgs e)
        {
            DisplayTypeText(btnN.Text);
        }

        private void btnM_Click(object sender, EventArgs e)
        {
            DisplayTypeText(btnM.Text);
        }

        private void btnLess_Click(object sender, EventArgs e)
        {
            if (isCapsLockOn)
            {
                DisplayTypeText("<");
            }
            else
            {
                DisplayTypeText(",");
            }
        }

        private void btnMore_Click(object sender, EventArgs e)
        {
            if (isCapsLockOn)
            {
                DisplayTypeText(">");
            }
            else
            {
                DisplayTypeText(".");
            }
        }

        private void btnQuestion_Click(object sender, EventArgs e)
        {
            if (isCapsLockOn)
            {
                DisplayTypeText("?");
            }
            else
            {
                DisplayTypeText("/");
            }
        }

        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            try
            {
                string deleteText = txtKeyboardText.Text;

                if (deleteText.Length > 1)
                {
                    deleteText = deleteText.Substring(0, deleteText.Length - 1);
                }
                else
                {
                    deleteText = "";
                }

                txtKeyboardText.Text = deleteText;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnSpace_Click(object sender, EventArgs e)
        {
            string space = "".PadRight(1);
            DisplayTypeText(space);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (isCapsLockOn)
            {
                DisplayTypeText("!");
            }
            else
            {
                DisplayTypeText("1");
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (isCapsLockOn)
            {
                DisplayTypeText("@");
            }
            else
            {
                DisplayTypeText("2");
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (isCapsLockOn)
            {
                DisplayTypeText("#");
            }
            else
            {
                DisplayTypeText("3");
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (isCapsLockOn)
            {
                DisplayTypeText("$");
            }
            else
            {
                DisplayTypeText("4");
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (isCapsLockOn)
            {
                DisplayTypeText("%");
            }
            else
            {
                DisplayTypeText("5");
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (isCapsLockOn)
            {
                DisplayTypeText("^");
            }
            else
            {
                DisplayTypeText("6");
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (isCapsLockOn)
            {
                DisplayTypeText("&");
            }
            else
            {
                DisplayTypeText("7");
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (isCapsLockOn)
            {
                DisplayTypeText("*");
            }
            else
            {
                DisplayTypeText("8");
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (isCapsLockOn)
            {
                DisplayTypeText("(");
            }
            else
            {
                DisplayTypeText("9");
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (isCapsLockOn)
            {
                DisplayTypeText(")");
            }
            else
            {
                DisplayTypeText("0");
            }
        }

        private void btnDash_Click(object sender, EventArgs e)
        {
            if (isCapsLockOn)
            {
                DisplayTypeText("_");
            }
            else
            {
                DisplayTypeText("-");
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (isCapsLockOn)
            {
                DisplayTypeText("+");
            }
            else
            {
                DisplayTypeText("=");
            }
        }

        private void btnBackSlash_Click(object sender, EventArgs e)
        {
            if (isCapsLockOn)
            {
                DisplayTypeText("|");
            }
            else
            {
                DisplayTypeText("'\'");
            }
        }

        private void btnEsc_Click(object sender, EventArgs e)
        {
            isPressEnter = false;
            this.Close();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            isPressEnter = true;
            this.Close();
        }
    }
}
