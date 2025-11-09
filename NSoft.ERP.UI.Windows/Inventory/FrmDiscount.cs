using NSoft.ERP.Service.Inventory;
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
    public partial class FrmDiscount : Form
    {
        public FrmDiscount()
        {
            InitializeComponent();
        }

        int formType = 0;
        public decimal discountPercentage = 0;
        public decimal discountAmount = 0;
        public decimal totalAmount = 0;
        public int discountType = 0; // 1-Item 2-SubTotal
        public FrmDiscount(int formType, decimal totalAmount, int discountType)
        {
            //1 - Discount Percentage
            //2 - Discount Amount
            this.formType = formType;
            this.totalAmount = totalAmount;
            this.discountType = discountType;
            InitializeComponent();
        }

        private void FrmDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnEnter.PerformClick();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    discountPercentage = 0;
                    discountAmount = 0;
                    this.Close();
                }
                else if (e.KeyCode == Keys.NumPad9 || e.KeyCode == Keys.D9)
                {
                    btn9.PerformClick();
                }
                else if (e.KeyCode == Keys.NumPad8 || e.KeyCode == Keys.D8)
                {
                    btn8.PerformClick();
                }
                else if (e.KeyCode == Keys.NumPad7 || e.KeyCode == Keys.D7)
                {
                    btn7.PerformClick();
                }
                else if (e.KeyCode == Keys.NumPad6 || e.KeyCode == Keys.D6)
                {
                    btn6.PerformClick();
                }
                else if (e.KeyCode == Keys.NumPad5 || e.KeyCode == Keys.D5)
                {
                    btn5.PerformClick();
                }
                else if (e.KeyCode == Keys.NumPad4 || e.KeyCode == Keys.D4)
                {
                    btn4.PerformClick();
                }
                else if (e.KeyCode == Keys.NumPad3 || e.KeyCode == Keys.D3)
                {
                    btn3.PerformClick();
                }
                else if (e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.D2)
                {
                    btn2.PerformClick();
                }
                else if (e.KeyCode == Keys.NumPad1 || e.KeyCode == Keys.D1)
                {
                    btn1.PerformClick();
                }
                else if (e.KeyCode == Keys.NumPad0 || e.KeyCode == Keys.D0)
                {
                    btnZero.PerformClick();
                }
                else if (e.KeyCode == Keys.Decimal)
                {
                    btnDot.PerformClick();
                }
                else if (e.KeyCode == Keys.Back)
                {
                    btnClear.PerformClick();
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void FrmDiscount_Load(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = txtDiscount;
                txtDiscount.Focus();

                if (formType == 1)
                {
                    lblDiscount.Text = "Discount Percentage (%)";
                }
                else
                {
                    lblDiscount.Text = "Discount Amount";
                }
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                string amountText = string.Empty;

                amountText = txtDiscount.Text.Trim();

                if (amountText.Length > 1)
                {
                    amountText = amountText.Substring(0, amountText.Length - 1);
                }
                else
                {
                    amountText = string.Empty;
                }
                txtDiscount.Text = amountText;
                btnEnter.Focus();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }
        private decimal CheckCashierPrivilegesValue(string functionName)
        {
            try
            {
                decimal maxValue = 0;

                CashierService cashierService = new CashierService();
                maxValue = cashierService.GetCashierPrivilegesValueByFunctionNameAndCashierID(functionName, Common.LoggedUserID);

                return maxValue;
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
                return 0;
            }
        }
        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDiscount.Text.Trim() != string.Empty)
                {
                    discountPercentage = Common.ConvertStringToDecimal(txtDiscount.Text.Trim());
                    if (this.formType == 1)
                    {
                        if (discountPercentage > 100)
                        {
                            MessageBox.Show("Invalid Discount Percentage.");
                            return;
                        }

                        decimal maxValue = 0;

                        if (discountType == 1)
                        {
                            maxValue = CheckCashierPrivilegesValue("Item Discount Percentage");

                        }
                        else
                        {
                            maxValue = CheckCashierPrivilegesValue("SubTotal  Discount Percentage");

                        }

                        if (discountPercentage > maxValue)
                        {
                            discountPercentage = 0;
                            FrmLimitExceed frmLimitExceed = new FrmLimitExceed("Discount");
                            frmLimitExceed.ShowDialog();
                            return;
                        }

                        discountAmount = Common.GetDiscountAmount(totalAmount, discountPercentage);

                    }
                    else
                    {
                        decimal maxValue = 0;

                        if (discountType == 1)
                        {
                            maxValue = CheckCashierPrivilegesValue("Item Discount Amount");
                            if (discountPercentage > maxValue)
                            {
                                FrmLimitExceed frmLimitExceed = new FrmLimitExceed("Discount");
                                frmLimitExceed.ShowDialog();
                                return;
                            }
                        }
                        else
                        {
                            maxValue = CheckCashierPrivilegesValue("SubTotal Discount Amount");

                            discountPercentage = 0;
                            discountAmount = Common.ConvertStringToDecimal(txtDiscount.Text.Trim());

                            if (discountAmount > maxValue)
                            {
                                FrmLimitExceed frmLimitExceed = new FrmLimitExceed("Discount");
                                frmLimitExceed.ShowDialog();
                                return;
                            }
                        }

                    }

                }
                else
                {
                    discountPercentage = 0;
                    discountAmount = 0;
                }
                this.Close();
            }
            catch (Exception ex)
            {
                LogWritter.WriteErrorLog(this.Name, MethodInfo.GetCurrentMethod().ToString(), ex.GetType().ToString(), ex.Message.ToString());
                SysMessage.ShowMessage(SysMessage.MessageAction.Exception, SysMessage.MessageType.Error, this.Text, ex.Message.ToString());
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtDiscount.Text += btn1.Text.Trim();
            btnEnter.Focus();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtDiscount.Text += btn2.Text.Trim();
            btnEnter.Focus();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtDiscount.Text += btn3.Text.Trim();
            btnEnter.Focus();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtDiscount.Text += btn4.Text.Trim();
            btnEnter.Focus();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtDiscount.Text += btn5.Text.Trim();
            btnEnter.Focus();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtDiscount.Text += btn6.Text.Trim();
            btnEnter.Focus();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtDiscount.Text += btn7.Text.Trim();
            btnEnter.Focus();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtDiscount.Text += btn8.Text.Trim();
            btnEnter.Focus();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtDiscount.Text += btn9.Text.Trim();
            btnEnter.Focus();
        }

        private void btnDoubleZero_Click(object sender, EventArgs e)
        {
            txtDiscount.Text += btnDoubleZero.Text.Trim();
            btnEnter.Focus();
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            txtDiscount.Text += btnZero.Text.Trim();
            btnEnter.Focus();
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            txtDiscount.Text += btnDot.Text.Trim();
            btnEnter.Focus();
        }
    }
}
