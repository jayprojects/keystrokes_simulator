using System;
using System.Runtime.InteropServices;

namespace ConsoleAppSendKeys
{
   
    class Program
    {
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        
        const uint KEYEVENTF_KEYUP = 0x0002;
        public static int ConvertCharToVirtualKey(char ch)
        {
            return (int)ch;
        }
        
        static void Main(string[] args)
        {
            if((null !=args) && (args.Length>0))
            {
                System.Threading.Thread.Sleep(2000);
                foreach (char c in args[0].ToCharArray())
                {
                    String s = "A"+c.ToString();
                    ConsoleKey ck = (ConsoleKey)Enum.Parse(typeof(ConsoleKey), s, true);
                    if (c.ToString().ToLower().Equals(c.ToString()))
                    {
                        keybd_event((byte)ck, 0, 0, 0);
                        keybd_event((byte)ck, 0, KEYEVENTF_KEYUP, 0);
                    }
                    else //for capital letters
                    {
                        keybd_event(0xA1, 0, 0, 0);
                        keybd_event((byte)ck, 0, 0, 0);
                        keybd_event((byte)ck, 0, KEYEVENTF_KEYUP, 0);
                        keybd_event(0xA1, 0, KEYEVENTF_KEYUP, 0);
                    }
                }
            }
        }


        public enum ConsoleKey
        {
            AA = 0x41,
            AB = 0x42,
            AC = 0x43,
            AD = 0x44,
            AE = 0x45,
            AF = 0x46,
            AG = 0x47,
            AH = 0x48,
            AI = 0x49,
            AJ = 0x4A,
            AK = 0x4B,
            AL = 0x4C,
            AM = 0x4D,
            AN = 0x4E,
            AO = 0x4F,
            AP = 0x50,
            AQ = 0x51,
            AR = 0x52,
            AS = 0x53,
            AT = 0x54,
            AU = 0x55,
            AV = 0x56,
            AW = 0x57,
            AX = 0x58,
            AY = 0x59,
            AZ = 0x5A,
            A0 = 0x30,  // 0 through 9
            A1 = 0x31,
            A2 = 0x32,
            A3 = 0x33,
            A4 = 0x34,
            A5 = 0x35,
            A6 = 0x36,
            A7 = 0x37,
            A8 = 0x38,
            A9 = 0x39,
            
            //to do add special chars
        }
    }
}
