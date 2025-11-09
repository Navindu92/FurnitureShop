using NSoft.ERP.UI.Windows.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSoft.ERP.UI.Windows.Device
{
    public static class DualDisplay
    {
        public static bool IsDualDisplay = false;
        public static string VideoPath = string.Empty;

        static FrmDualDisplay frmDualDisplay;
        public static void ShowDualDisplay(Screen screen)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Name == "FrmDualDisplay")
                {
                    frmDualDisplay.Activate();
                    return;
                }
            }

            frmDualDisplay = new FrmDualDisplay();
            frmDualDisplay.StartPosition = FormStartPosition.Manual;
            frmDualDisplay.Location = screen.WorkingArea.Location;
            frmDualDisplay.Show();
            frmDualDisplay.Activate();
        }
        public static void ShowCounterClose()
        {
            frmDualDisplay.lblLeft1.Text = string.Empty;
            frmDualDisplay.lblRight1.Text = string.Empty;
            frmDualDisplay.lblLeft2.Text = string.Empty;
            frmDualDisplay.lblRight2.Text = string.Empty;
            frmDualDisplay.lblHeader.Text = "Counter Closed";
            frmDualDisplay.Activate();
        }
        public static void ShowNextCustomer()
        {
            frmDualDisplay.lblLeft1.Text = string.Empty;
            frmDualDisplay.lblRight1.Text = string.Empty;
            frmDualDisplay.lblLeft2.Text = string.Empty;
            frmDualDisplay.lblRight2.Text = string.Empty;
            frmDualDisplay.lblHeader.Text = "Next Customer";
            frmDualDisplay.Activate();
        }
        public static void ShowLine1(string left, string right)
        {
            frmDualDisplay.lblLeft1.Text = left;
            frmDualDisplay.lblRight1.Text = right;
            frmDualDisplay.lblHeader.Text = string.Empty;
        }

        public static void ShowLine2(string left, string right)
        {
            frmDualDisplay.lblLeft2.Text = left;
            frmDualDisplay.lblRight2.Text = right;
            frmDualDisplay.lblHeader.Text = string.Empty;
        }

        public static Screen GetSecondaryScreen()
        {
            if (Screen.AllScreens.Length == 1)
            {
                return null;
            }

            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.Primary == false)
                {
                    return screen;
                }
            }

            return null;
        }
    }
}
