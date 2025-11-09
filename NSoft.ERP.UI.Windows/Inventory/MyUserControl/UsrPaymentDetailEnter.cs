using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NSoft.ERP.Utility;
using NSoft.ERP.Domain.Inventory;
using NSoft.ERP.Domain.General;
using NSoft.ERP.Service.Inventory;

namespace NSoft.ERP.UI.Windows.Inventory.MyUserControl
{
    public partial class UsrPaymentDetailEnter : UserControl
    {
        public UsrPaymentDetailEnter()
        {
            InitializeComponent();
        }

        public Control control1;
        public FrmPayment control2;
        public SalesPayment salesPayment;
        public PayType payType;

        public void ClearLine()
        {
            Common.ReadOnlyTextBox(true, txtPayAmount, txtReferenceNo);
            Common.ClearTextBox(txtPayAmount, txtReferenceNo);
        }

        private void txtPayAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (txtPayAmount.Text == string.Empty || Common.ConvertStringToDecimal(txtPayAmount.Text.Trim()) == 0)
                {
                    lblValidation.Text = "Please Enter Valid Amount.";
                    return;
                }

                if (payType.PayTypeID!=1)
                {
                    if (Common.ConvertStringToDecimal(txtPayAmount.Text.Trim()) > Common.ConvertStringToDecimal(control2.lblDueAmount.Text.Trim()))
                    {
                        lblValidation.Text = "Invalid Payment Amount By " + payType.PayTypeName.Trim() + ".";
                        return;
                    }
                }

                if (payType.PayTypeID==6)
                {
                    decimal existLoyaltyPaymentAmount = 0;

                    SalesService salesService = new SalesService();

                    existLoyaltyPaymentAmount = salesService.GetExistPaidAmountByPayTypeID(6,control2.salesPaymentList);

                    if (Common.ConvertStringToDecimal(txtPayAmount.Text.Trim()) > (control2.loyaltyCustomer.CurrentPoints)- existLoyaltyPaymentAmount)
                    {
                        lblValidation.Text = "Invalid Payment Amount By " + payType.PayTypeName.Trim() + ".";
                        return;
                    }
                    
                }

                salesPayment.Reference = txtReferenceNo.Text.Trim();

                salesPayment.Amount = Common.ConvertStringToDecimal(Common.ConvertToStringCurrancy(txtPayAmount.Text.Trim()));

                salesPayment.Balance = Common.ConvertStringToDecimal(control2.lblDueAmount.Text.Trim()) - salesPayment.Amount;

                control2.UpdatePaymentGrid(salesPayment);
                this.Visible = false;
                control1.Visible = true;
                control2.grpPayTypes.Enabled = true;
                control2.btnCash.Focus();


            }
        }

        private void txtReferenceNo_KeyDown(object sender, KeyEventArgs e)
        {
            lblValidation.Text = string.Empty;

            if (e.KeyCode == Keys.Enter)
            {

                if (payType != null)
                {
                    if (txtReferenceNo.Text.Length != payType.ReferenceNoLength)
                    {
                        lblValidation.Text = "Invalid Reference No";
                        return;
                    }
                }

                Common.ReadOnlyTextBox(false, txtPayAmount);
                Common.ReadOnlyTextBox(true, txtReferenceNo);
                txtPayAmount.Focus();


            }
        }

        private void UsrPaymentDetailEnter_VisibleChanged(object sender, EventArgs e)
        {
            
        }
    }
}
