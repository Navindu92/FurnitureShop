using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSoft.ERP.Utility
{
    public static class Validater
    {

        public enum ValidateType
        { 
            Empty,
        }
        public static bool ValidateTextBox(ErrorProvider errorProvider,ValidateType validateType,params TextBox[] textBox)
        {
            errorProvider.Clear();
            bool IsValid = true;
            foreach (TextBox t in textBox)
            {
                switch (validateType)
                {
                    case ValidateType.Empty:
                        if (string.IsNullOrEmpty(t.Text.Trim()))
                        {
                            errorProvider.SetError(t,"Data Required for this field");
                            errorProvider.SetIconAlignment(t, ErrorIconAlignment.MiddleLeft);
                            IsValid = false;
                        }
                        break;
                    default:
                        break;
                }
            }
            return IsValid;
        }
        public static bool ValidateComboBox(ErrorProvider errorProvider, ValidateType validateType, params ComboBox[] comboBox)
        {
            errorProvider.Clear();
            bool IsValid = true;
            foreach (ComboBox t in comboBox)
            {
                switch (validateType)
                {
                    case ValidateType.Empty:
                        if (string.IsNullOrEmpty(t.Text.Trim()))
                        {
                            errorProvider.SetError(t, "Data Required for this field");
                            errorProvider.SetIconAlignment(t, ErrorIconAlignment.MiddleLeft);
                            IsValid = false;
                        }
                        break;
                    default:
                        break;
                }
            }
            return IsValid;
        }
    }
}
