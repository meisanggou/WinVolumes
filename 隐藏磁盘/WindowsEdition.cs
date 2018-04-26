using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 隐藏磁盘
{
    //windows版本
    class WindowsEdition
    {
        public static string GetEdition()
        {
            string edi  = Environment.OSVersion.ToString();
            int major = Environment.OSVersion.Version.Major;
            int minor=Environment.OSVersion.Version.Minor;
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Win32Windows:
                    if (major == 4 && minor == 0)
                        edi = "Windows 95";
                    else if (major == 4 && minor == 10)
                        edi = "Windows 98";
                    else if (major == 4 && minor == 90)
                        edi = " Windows Me";
                    break;
                case PlatformID.Win32NT:
                    if (major == 4 && minor == 0)
                        edi = "Windows NT 4.0";
                    else if (major == 5 && minor == 0)
                        edi = "Windows 2000";
                    else if (major == 5 && minor == 1)
                        edi = "Windows XP";
                    else if (major == 6 && minor == 0)
                        edi = "Windows Vista";
                    else if (major == 6 && minor == 1)
                        edi = "Windows 7";
                    break;
                default:
                    break;
            }
            return edi;
        }
    }
}
