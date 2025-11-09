using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NSoft.ERP.UI.Windows.Device
{
    public static class CustomerDisplay
    {

        // **********************************************
        [DllImport("kernel32", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern void Sleep(int dwMilliseconds);


        // **********************************************
        // Posiflex usbpd.dll DLL
        // **********************************************
        [DllImport("usbpd.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int WritePD(string data, int length);

        [DllImport("usbpd.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int PdState();

        [DllImport("usbpd.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int OpenUSBpd();

        [DllImport("usbpd.dll", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int CloseUSBpd();

        static short Now_MODE;
        const int NORITAKE_Mode = 1;
        const int EPSON_Mode = 2;



        public static string displayComPort = string.Empty;
        public static int displayLength = 20;

        public static string eClear = Convert.ToString((char)12);
        public static string eBlinkOn = Convert.ToString((char)31) + Convert.ToString((char)69) + Convert.ToString((char)10);
        public static string eBlinkOff = Convert.ToString((char)31) + Convert.ToString((char)69) + Convert.ToString((char)0);
        public static string eLF = Convert.ToString((char)10);

        public enum DisplayAlignment
        {
            Left,
            Center,
            Right
        }
        public static void DisplayText(string text, DisplayAlignment alignment = DisplayAlignment.Left)
        {
            int mOpenUSBPD;
            mOpenUSBPD = OpenUSBpd();
            string tempText = string.Empty;
            if (mOpenUSBPD == 0)
            {
                switch (alignment)
                {
                    case DisplayAlignment.Left:
                        text = text;
                        break;
                    case DisplayAlignment.Center:
                        tempText = text.Trim();
                        text = new string(' ', (displayLength - tempText.Length) / 2) + tempText + new string(' ', (displayLength - tempText.Length) / 2);
                        break;
                    case DisplayAlignment.Right:
                        tempText = text.Trim();
                        text = new string(' ', (displayLength - tempText.Length)) + tempText;
                        break;
                    default:
                        break;
                }

                mWritePD(text, text.Length);
                CloseUSBpd();
            }
            else
            {
                SerialPort comport = new SerialPort(displayComPort, 19200, Parity.None, 8, StopBits.One);
                comport.Open();
                comport.Write(text);
                comport.Close();
            }
        }


        private static string getScrolling(short mMode)
        {
            string returnValue;
            if (mMode == EPSON_Mode)
            {
                returnValue = "";
            }
            else
            {
                returnValue = "** Welcome to POSIFLEX Chain Store...";
            }
            return returnValue;
        }

        public static int mWritePD(string mdata, int mLength)
        {
            int returnValue;
            returnValue = WritePD(mdata, mLength);
            return returnValue;
        }

        public static string displayCounterClosed = "COUNTER CLOSED";
        public static bool isDisplayConnected = false;
        public static string displayText1 = "";
        public static string displayText2 = "";

    }
}
