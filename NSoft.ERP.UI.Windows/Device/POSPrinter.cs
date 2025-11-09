using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace NSoft.ERP.UI.Windows.Device
{
    public static class POSPrinter
    {
        public static string printerName = string.Empty;
        public static int printLength = 42;

        public static string ESC = Convert.ToString((char)27);
        public static string eInitialize = ESC + Convert.ToString((char)64);
        public static string eCenter = ESC + Convert.ToString((char)97) + Convert.ToString((char)1);
        public static string eLeft = ESC + Convert.ToString((char)97) + Convert.ToString((char)0);
        public static string eRight = ESC + Convert.ToString((char)97) + Convert.ToString((char)2);
        public static string eDrawer = ESC + Convert.ToString((char)112) + Convert.ToString((char)0) + Convert.ToString((char)25) + Convert.ToString((char)250);
        public static string eCut = ESC + Convert.ToString((char)105);

        public static string eFontANormal = ESC + Convert.ToString((char)33) + Convert.ToString((char)0);
        public static string eFontAEmphasized = ESC + Convert.ToString((char)33) + Convert.ToString((char)8);
        public static string eFontADoubleHeight = ESC + Convert.ToString((char)33) + Convert.ToString((char)16);
        public static string eFontAEmphasizedDoubleHeight = ESC + Convert.ToString((char)33) + Convert.ToString((char)24);
        public static string eFontADoubleWidth = ESC + Convert.ToString((char)33) + Convert.ToString((char)32);
        public static string eFontAEmphasizedDoubleWidth = ESC + Convert.ToString((char)33) + Convert.ToString((char)40);
        public static string eFontADoubleWidthDoubleHeight = ESC + Convert.ToString((char)33) + Convert.ToString((char)48);
        public static string eFontAEmphasizedDoubleWidthDoubleHeight = ESC + Convert.ToString((char)33) + Convert.ToString((char)56);

        public static string eFontBNormal = ESC + Convert.ToString((char)33) + Convert.ToString((char)129);
        public static string eFontBEmphasized = ESC + Convert.ToString((char)33) + Convert.ToString((char)137);
        public static string eFontBDoubleHeight = ESC + Convert.ToString((char)33) + Convert.ToString((char)145);
        public static string eFontBEmphasizedDoubleHeight = ESC + Convert.ToString((char)33) + Convert.ToString((char)153);
        public static string eFontBDoubleWidth = ESC + Convert.ToString((char)33) + Convert.ToString((char)161);
        public static string eFontBEmphasizedDoubleWidth = ESC + Convert.ToString((char)33) + Convert.ToString((char)169);
        public static string eFontBDoubleWidthDoubleHeight = ESC + Convert.ToString((char)33) + Convert.ToString((char)177);
        public static string eFontBEmphasizedDoubleWidthDoubleHeight = ESC + Convert.ToString((char)33) + Convert.ToString((char)185);

        public static string eLF = Convert.ToString((char)10);
        public static string eCR = Convert.ToString((char)13);

        public static string eLineSpaceDefault = ESC + Convert.ToString((char)50);

        public static string FS = Convert.ToString((char)28);

        //                                                                           Logo Posision
        public static string ePrintNVImage1 = FS + Convert.ToString((char)112) + Convert.ToString((char)1) + Convert.ToString((char)48);
        public static string ePrintNVImage2 = FS + Convert.ToString((char)112) + Convert.ToString((char)2) + Convert.ToString((char)48);
        public static string ePrintNVImage3 = FS + Convert.ToString((char)112) + Convert.ToString((char)3) + Convert.ToString((char)48);
        public static string ePrintNVImage4 = FS + Convert.ToString((char)112) + Convert.ToString((char)4) + Convert.ToString((char)48);
        public static string ePrintNVImage5 = FS + Convert.ToString((char)112) + Convert.ToString((char)5) + Convert.ToString((char)48);

        public static string GS = Convert.ToString((char)29);

        public static string PrintBarcode(string barcodeData)
        {
            byte length = (byte)barcodeData.Length;
            return System.Text.ASCIIEncoding.ASCII.GetString(new byte[] { 27, 97, 1 }) + System.Text.ASCIIEncoding.ASCII.GetString(new byte[] { 29, 104, 50 }) + System.Text.ASCIIEncoding.ASCII.GetString(new byte[] { 29, 119, 2 }) + System.Text.ASCIIEncoding.ASCII.GetString(new byte[] { 29, 72, 0 }) + System.Text.ASCIIEncoding.ASCII.GetString(new byte[] { 29, 107, 69, length }) + barcodeData + System.Text.ASCIIEncoding.ASCII.GetString(new byte[] { 0 });
        }

        public static string SetLineSpace(int lineSpace)
        {
            return ESC + Convert.ToString((char)51) + Convert.ToString((char)lineSpace);
        }
        public static string SetLineFeed(int lineFeed)
        {
            return ESC + Convert.ToString((char)100) + Convert.ToString((char)lineFeed);
        }
        public static string GetDashLine()
        {
            return new string('-', printLength);
        }
        public static void PrintText(string text)
        {
            RawPrinterHelper.SendStringToPrinter(printerName, text + eCR);
        }

        public static bool CheckPrinterAvailability(out string Status)
        {
            bool isAvailable = false;

            Status = "Printer name not found";

            ManagementScope scope = new ManagementScope(@"\root\cimv2");
            scope.Connect();

            ManagementObjectSearcher searcher = new
             ManagementObjectSearcher("SELECT * FROM Win32_Printer");

            string myPrinterName = "";
            foreach (ManagementObject printer in searcher.Get())
            {
                myPrinterName = printer["Name"].ToString().ToLower();

                if (myPrinterName.Equals(printerName.ToLower()))
                {
                    int printerStatus = 0;
                    printerStatus = Convert.ToInt16(printer["PrinterState"].ToString().ToLower());

                    switch (printerStatus)
                    {
                        case 0:
                            isAvailable = true;
                            Status = "Online";
                            break;

                        case 4096:
                            isAvailable = false;
                            Status = "Printer Offline";
                            break;

                        case 4194432:
                            isAvailable = false;
                            Status = "Lid open";
                            break;

                        case 144:
                            isAvailable = false;
                            Status = "Out of paper";
                            break;

                        case 4194448:
                            isAvailable = false;
                            Status = "Out of paper and lid open";
                            break;

                        case 1024:
                            isAvailable = false;
                            Status = "Printing";
                            break;

                        case 32768:
                            isAvailable = false;
                            Status = "Initializing";
                            break;

                        case 160:
                            isAvailable = false;
                            Status = "Manual feed in progress";
                            break;

                        default:
                            isAvailable = false;
                            Status = "Offline";
                            break;
                    }
                }
             
            }

            return isAvailable;
        }

        public static string header1;
        public static string header2;
        public static string header3;
        public static string header4;
        public static string header5;

        public static string tail1;
        public static string tail2;
        public static string tail3;
        public static string tail4;
        public static string tail5;

        public static float printerWidth;
        public static int marginX;
        public static int dashWidth;
    }
}
