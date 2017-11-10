using System;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace ProxyWatcher
{
    internal class Proxy
    {
        [DllImport("wininet.dll")]
        private static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);
        // ReSharper disable InconsistentNaming
        public const int INTERNET_OPTION_PROXY_SETTINGS_CHANGED = 95;
        public const int INTERNET_OPTION_SETTINGS_CHANGED = 39;
        public const int INTERNET_OPTION_REFRESH = 37;
        // ReSharper restore InconsistentNaming
        private const string KeyName = "HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings";
        private const string ValueName = "AutoConfigURL";


        public static void SetProxy(string proxyhost, bool proxyEnabled)
        {
            Registry.SetValue(KeyName, "ProxyServer", proxyhost);
            Registry.SetValue(KeyName, "ProxyEnable", proxyEnabled ? 1 : 0);

            // These lines implement the Interface in the beginning of program 
            // They cause the OS to refresh the settings, causing IP to realy update
            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0);
            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0);
        }

        public static bool SetAutoConfig(string configUrl)
        {
            var curUrl = GetAutoConfigUrl();
            if (string.IsNullOrEmpty(curUrl) || curUrl.Equals(configUrl, StringComparison.InvariantCultureIgnoreCase)) return false;

            Registry.SetValue(KeyName, ValueName, configUrl);

            // These lines implement the Interface in the beginning of program 
            // They cause the OS to refresh the settings, causing IP to realy update
            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_PROXY_SETTINGS_CHANGED, IntPtr.Zero, 0);
            //InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0);
            //InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0);

            return true;
        }

        public static string GetAutoConfigUrl()
        {
            return (string)Registry.GetValue(KeyName, ValueName, "");
        }
    }
}
