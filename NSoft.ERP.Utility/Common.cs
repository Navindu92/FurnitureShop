using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSoft.ERP.Utility
{
    public static class Common
    {
        public static int GroupOfCompanyID = 0;
        public static long LoggedUserID = 0;
        public static long LoggedLocationID = 0;
        public static long CounterNo = 0;
        public static string CompanyName = "Navindu";
        public static string Address1 = "";
        public static string Address2 = "";
        public static string LoggedUserName = "Admin";
        public static string LoggedLocation = "Matara";
        public static string LoggedPCName = "Navindu-PC";
        public static string Address = "Samadhi,Walpita Road,Telijjawila";
        public static bool IsAutoSignOut = false;
        public static int AutoSignOutTimeDuration = 100000; // ms
        public static bool IsAllowMinusStock = true;
        public static bool IsLocationCodePrefix = true;
        public static string binPath = AppDomain.CurrentDomain.BaseDirectory;
        public static string Version = "1.0";
        public static bool IsDeveloper = false;
        public static int posPrinterConnectionType = 1;
        public static string DateFormat = "dd/MM/yyyy";
        public static string CurrenyFormat;
        public static bool IsPosCounter = false;
        public static bool IsShowDeveloperLogo = true;
        public static int LoyaltyCardLength = 6;

        static string[] ones = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        static string[] tens = { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        static string[] thou = { "", "thousand", "million", "billion", "trillion", "quadrillion", "quintillion" };

        //SMS Portal

        public static string SMSSenderUsername = "heladiwa";
        public static string SMSSenderPassword = "Hd94dwa";
        public static string SMSSenderID = "Heladiwa";
        public static string SMSSenderIP = "http://203.153.222.25:5000";

        //Encrypt Decrypt

        public static readonly string PasswordHash = "P@@Sw0rd";
        public static readonly string SaltKey = "S@LT&NSOFT";
        public static readonly string VIKey = "@1B2c3D4e5F6g7H8";

        public static string connectionString = "";
        public static string printerName;

        public static bool IsLogin = false;

        #region Pre initialization
        public static int MasterCodeMaxLength = 10;
        public static int CurrencyDecimalPlaces = 2;
        public static byte QtyDecimalPlaces = 0;
        #endregion

        enum Action
        {
            Save,
            Update,
            Delete
        }

        public enum ReferenceType
        {
            Gender = 1,
            Title = 2,
            RoomType = 3,
            Days = 4,
            SerialVisibility = 5,
            AppointmentStatus = 6,
            CancelStatus = 7,
            AgeType = 8,
            AdjustmentType = 9,
            ChequeBookPageCount = 10,
            OPDNoOfTime = 11
        }

        public enum PosPrinterConnectionType
        {
            PrinterDriver = 1,
            ComPort = 2,
            LpPort = 3,
            Ethernet = 4,
            OPOS = 5
        }

        #region Module Type
        public struct ModuleType
        {
            public static bool General;
            public static bool Inventory;
            public static bool Automobile;
            public static bool Hospital;
            public static bool Restaurant;
            public static bool Account;
            public static bool Payroll;
            public static bool GiftVoucher;
        }

        public struct ReportDataStruct
        {
            public string ReportFiled;
            public string ReportFiledName;
            public object ReportDataType;
            public string DbColumnName;
            public bool IsCondtionField;
            public bool IsSelectionField;
            public string DbJoinColumnName;
            public bool IsJoinField;
        }

        public struct ReportCondtionDataStruct
        {
            public ReportDataStruct ReportDataStruct;
            public string ConditionFrom;
            public string ConditionTo;
        }

        public static void SetModule(int groupOfCompanyID)
        {
            switch (groupOfCompanyID)
            {
                case 1: // ABC Super City
                    ModuleType.General = true;
                    ModuleType.Inventory = true;
                    ModuleType.Account = true;
                    ModuleType.Automobile = false;
                    ModuleType.Hospital = true;
                    ModuleType.Restaurant = true;
                    ModuleType.Payroll = false;
                    ModuleType.GiftVoucher = true;
                    break;


                default:
                    break;
            }

        }

        public static void SetSpecialFeatures(int groupOfCompanyID)
        {
            switch (groupOfCompanyID)
            {
                case 1: // ABC Super City
                    SpecialFeatures.IsConfirmBeforeSaveMasterFiles = false;
                    SpecialFeatures.IsConfirmBeforeSaveTransaction = false;
                    SpecialFeatures.IsConfirmBeforeUpdateMasterFiles = true;
                    SpecialFeatures.IsConfirmBeforeDeleteMasterFiles = true;
                    SpecialFeatures.IsConfirmBeforeCloseMasterFiles = true;
                    SpecialFeatures.IsConfirmBeforeCloseTransaction = true;
                    SpecialFeatures.IsConfirmBeforeClearMasterFiles = false;
                    SpecialFeatures.IsConfirmBeforeClearTransaction = false;
                    SpecialFeatures.LabReferenceNoLength = 6;
                    SpecialFeatures.LabReferenceNoPrefix = "";
                    SpecialFeatures.IsBarcodeScanProcess = true;
                    SpecialFeatures.PosPrinterName = "EPSON TM-U220 Receipt";
                    SpecialFeatures.IsAutoCompleteItemsOnInvoice = false;
                    SpecialFeatures.IsServiceChargeOnInvoice = false;
                    SpecialFeatures.ServiceChargePercentage = 0;
                    SpecialFeatures.IsThermalPrinter = false;
                    break;


                default:
                    break;
            }

        }
        #endregion

        #region SpecialFeatures
        public struct SpecialFeatures
        {
            public static bool IsConfirmBeforeSaveMasterFiles;
            public static bool IsConfirmBeforeSaveTransaction;
            public static bool IsConfirmBeforeUpdateMasterFiles;
            public static bool IsConfirmBeforeDeleteMasterFiles;
            public static bool IsConfirmBeforeClearMasterFiles;
            public static bool IsConfirmBeforeClearTransaction;
            public static bool IsConfirmBeforeCloseMasterFiles;
            public static bool IsConfirmBeforeCloseTransaction;
            public static int LabReferenceNoLength;
            public static string LabReferenceNoPrefix;
            public static bool IsBarcodeScanProcess;
            public static string PosPrinterName;
            public static bool IsAutoCompleteItemsOnInvoice;
            public static bool IsServiceChargeOnInvoice;
            public static decimal ServiceChargePercentage;
            public static bool IsThermalPrinter;
        }

        #endregion

        #region Clear Controls
        public static void ClearAllControls(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();
                else if (c is ComboBox)
                {
                    ((ComboBox)c).SelectedIndex = -1;
                    if (((ComboBox)c).SelectedValue != null) { ((ComboBox)c).SelectedValue = 0; }
                    ((ComboBox)c).Text = string.Empty;
                }
                else if (c is CheckBox)
                {
                    if (c.Name != "chkActive")
                        ((CheckBox)c).Checked = false;
                }
                else if (c is RadioButton)
                    ((RadioButton)c).Checked = false;
                else if (c is DateTimePicker)
                    ((DateTimePicker)c).Value = DateTime.Now;
                else
                    ClearAllControls(c);
            }
        }
        public static void ClearTextBox(params TextBox[] textBox)
        {
            foreach (TextBox t in textBox)
                t.Text = string.Empty;
        }
        public static void ClearComboBox(params ComboBox[] comboBox)
        {
            foreach (ComboBox c in comboBox)
                c.Text = string.Empty;
        }
        #endregion

        #region Convert
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        public static DataTable PropertiesToDataTable<T>(this IEnumerable<T> source)
        {
            DataTable dt = new DataTable();
            var props = TypeDescriptor.GetProperties(typeof(T));
            foreach (PropertyDescriptor prop in props)
            {
                DataColumn dc = dt.Columns.Add(prop.Name, prop.PropertyType);
                dc.Caption = prop.DisplayName;
                dc.ReadOnly = prop.IsReadOnly;
            }
            foreach (T item in source)
            {
                DataRow dr = dt.NewRow();
                foreach (PropertyDescriptor prop in props)
                {
                    dr[prop.Name] = prop.GetValue(item);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public static int ConvertStringToInt(string text)
        {
            return Convert.ToInt16(text);
        }
        public static long ConvertStringToLong(string text)
        {
            return Convert.ToInt64(text);
        }

        public static bool ConvertStringToBool(string text)
        {
            return Convert.ToBoolean(text);
        }
        public static decimal ConvertStringToDecimal(string text)
        {
            return Convert.ToDecimal(text);
        }
        public static string ConvertToStringCurrancy(string value)
        {
            string formatString = String.Concat("{0:n", Common.CurrencyDecimalPlaces, "}");
            return String.Format(formatString, Math.Round(double.Parse(value), Common.CurrencyDecimalPlaces));
        }
        public static string ConvertToStringQty(string value)
        {
            string formatString = String.Concat("{0:F", Common.QtyDecimalPlaces, "}");
            return String.Format(formatString, Math.Round(double.Parse(value), Common.QtyDecimalPlaces));
        }
        public static string ConvertToStringQty(string value, int decimalPalces)
        {
            string formatString = String.Concat("{0:F", decimalPalces, "}");
            return String.Format(formatString, Math.Round(double.Parse(value), decimalPalces));
        }
        public static string ConvertNumberToWords(string rawnumber, bool isCurrency)
        {
            int inputNum = 0;
            int dig1, dig2, dig3, level = 0, lasttwo, threeDigits;
            string rupees, cents;
            try
            {
                string[] Splits = new string[2];
                Splits = rawnumber.Split('.');   //notice that it is ' and not "
                inputNum = Convert.ToInt32(Splits[0]);
                rupees = "";
                cents = Splits[1];
                if (cents.Length == 1)
                {
                    cents += "0";   // 12.5 is twelve and 50/100, not twelve and 5/100
                }
            }
            catch
            {
                cents = "00";
                inputNum = Convert.ToInt32(rawnumber);
                rupees = "";
            }

            string x = "";

            bool isNegative = false;
            if (inputNum < 0)
            {
                isNegative = true;
                inputNum *= -1;
            }
            if (inputNum == 0)
            {
                if (isCurrency)
                {
                    return "zero " + Common.CurrenyFormat + " and " + ConvertCentsToWords(Convert.ToInt32(cents)) + " only.";
                }
                else
                {
                    return "zero and " + ConvertCentsToWords(Convert.ToInt32(cents)) + " only.";
                }
            }

            string s = inputNum.ToString();

            while (s.Length > 0)
            {
                //Get the three rightmost characters
                x = (s.Length < 3) ? s : s.Substring(s.Length - 3, 3);

                // Separate the three digits
                threeDigits = int.Parse(x);
                lasttwo = threeDigits % 100;
                dig1 = threeDigits / 100;
                dig2 = lasttwo / 10;
                dig3 = (threeDigits % 10);

                // append a "thousand" where appropriate
                if (level > 0 && dig1 + dig2 + dig3 > 0)
                {
                    rupees = thou[level] + " " + rupees;
                    rupees = rupees.Trim();
                }

                // check that the last two digits is not a zero
                if (lasttwo > 0)
                {
                    if (lasttwo < 20)
                    {
                        // if less than 20, use "ones" only
                        rupees = ones[lasttwo] + " " + rupees;
                    }
                    else
                    {
                        // otherwise, use both "tens" and "ones" array
                        rupees = tens[dig2] + " " + ones[dig3] + " " + rupees;
                    }
                    if (s.Length < 3)
                    {
                        if (isCurrency)
                        {
                            if (isNegative) { rupees = " negative " + rupees; }
                            return rupees + " " + Common.CurrenyFormat + " and " + ConvertCentsToWords(Convert.ToInt32(cents)) + " only.";
                        }
                        else
                        {
                            if (isNegative) { rupees = " negative " + rupees; }
                            return rupees + " and " + ConvertCentsToWords(Convert.ToInt32(cents)) + " only.";
                        }
                    }
                }

                // if a hundreds part is there, translate it
                if (dig1 > 0)
                {
                    rupees = ones[dig1] + " hundred " + rupees;
                    s = (s.Length - 3) > 0 ? s.Substring(0, s.Length - 3) : "";
                    level++;
                }
                else
                {
                    if (s.Length > 3)
                    {
                        s = s.Substring(0, s.Length - 3);
                        level++;
                    }
                }
            }
            if (isCurrency)
            {
                if (isNegative) { rupees = " negative " + rupees; }
                return (rupees + " " + Common.CurrenyFormat + "and " + ConvertCentsToWords(Convert.ToInt32(cents)) + " only.");
            }
            else
            {
                if (isNegative) { rupees = " negative " + rupees; }
                return (rupees + "and " + ConvertCentsToWords(Convert.ToInt32(cents)) + " only.");
            }
        }

        private static string ConvertCentsToWords(int cents)
        {
            char[] centsArr = cents.ToString().ToCharArray();
            string stringValue = string.Empty;

            if (cents > 0)
            {
                if (cents < 20)
                {
                    // if less than 20, use "ones" only
                    stringValue = ones[cents] + " cent(s)";
                }
                else
                {
                    // otherwise, use both "tens" and "ones" array
                    stringValue = tens[Convert.ToInt32(centsArr[0].ToString())] + " " + ones[Convert.ToInt32(centsArr[1].ToString())] + " cents";
                }
            }
            else if (cents == 0)
            {
                stringValue = "zero cents";
            }
            return stringValue;
        }

        #endregion

        #region AutoComplete
        public static void SetAutoComplete(TextBox textBox, string[] stringCollection)
        {
            textBox.AutoCompleteCustomSource = null;
            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(stringCollection);
            textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox.AutoCompleteCustomSource = autoComplete;
            textBox.Refresh();
        }
        public static void SetAutoCompleteWithoutAppend(TextBox textBox, string[] stringCollection)
        {
            textBox.AutoCompleteCustomSource = null;
            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(stringCollection);
            textBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox.AutoCompleteCustomSource = autoComplete;
            textBox.Refresh();
        }
        public static void SetAutoComplete(ComboBox comboBox, string[] stringCollection)
        {
            comboBox.AutoCompleteCustomSource = null;
            AutoCompleteStringCollection autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(stringCollection);
            comboBox.DataSource = autoComplete;
            comboBox.FormattingEnabled = true;
            // comboBox.Text = string.Empty;
            comboBox.Refresh();
        }
        #endregion

        #region Enable Controls
        public static void EnableTextBox(bool enable, params TextBox[] textBox)
        {
            foreach (TextBox t in textBox)
                t.Enabled = enable;
        }
        public static void EnableComboBox(bool enable, params ComboBox[] comboBox)
        {
            foreach (ComboBox c in comboBox)
                c.Enabled = enable;
        }
        public static void EnableButton(bool enable, params Button[] button)
        {
            foreach (Button b in button)
                b.Enabled = enable;
        }

        public static void ReadOnlyTextBox(bool enable, params TextBox[] textBox)
        {
            foreach (TextBox t in textBox)
                t.ReadOnly = enable;
        }
        public static void EnableDateTimePicker(bool enable, params DateTimePicker[] dateTimePicker)
        {
            foreach (DateTimePicker d in dateTimePicker)
                d.Enabled = enable;
        }
        #endregion

        #region Visible Controls
        public static void VisibleCheckBox(bool visible, params CheckBox[] checkBox)
        {
            foreach (CheckBox c in checkBox)
                c.Visible = visible;
        }
        public static void VisibleComboBox(bool visible, params ComboBox[] comboBox)
        {
            foreach (ComboBox c in comboBox)
                c.Visible = visible;
        }
        public static void VisibleLable(bool visible, params Label[] lable)
        {
            foreach (Label l in lable)
                l.Visible = visible;
        }

        public static void VisibleUserControl(bool visible, params UserControl[] userControl)
        {
            foreach (UserControl u in userControl)
                u.Visible = visible;
        }
        public static void VisibleTextBox(bool visible, params TextBox[] textBox)
        {
            foreach (TextBox t in textBox)
                t.Visible = visible;
        }
        #endregion

        #region Close Child Forms

        public static void CloseChildForms(Form mdiForm)
        {
            foreach (Form f in mdiForm.MdiChildren)
            {
                f.Close();
                f.Dispose();
            }

        }

        #endregion

        #region Set Form

        public static void SetForm(Form form, Form mdiForm)
        {
            bool isChild = false;
            foreach (Form f in mdiForm.MdiChildren)
            {
                if (f.Name.Equals(form.Name))
                {
                    isChild = true;
                    break;
                }
            }
            if (isChild)
            {
                form.Focus();
            }
            else
            {
                form.MdiParent = mdiForm;
                form.Show();
                form.Focus();
            }

        }
        #endregion

        #region Calculate
        public static decimal GetDiscountAmount(decimal grossAmount, decimal discPercentage)
        {
            return (grossAmount * discPercentage) / 100;
        }

        public static decimal GetServiceChargeAmount(decimal amount)
        {
            return (amount * Common.SpecialFeatures.ServiceChargePercentage) / 100;
        }
        #endregion

        #region Highlight Lable
        public static void HighlightLable(Label lable)
        {
            lable.Font = new Font(lable.Font, FontStyle.Bold);
        }
        public static void UnHighlightLable(Label lable)
        {
            lable.Font = new Font(lable.Font, FontStyle.Regular);
        }
        #endregion

        #region Encrypt String
        public static string EncryptString(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);
        }

        #endregion

        #region Decrypt String
        public static string DecryptString(string encryptedText)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }

        #endregion

        public static bool CheckIsNumeric(string value)
        {
            try
            {
                decimal n;
                bool isNumeric = decimal.TryParse(value, out n);

                if (isNumeric)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
