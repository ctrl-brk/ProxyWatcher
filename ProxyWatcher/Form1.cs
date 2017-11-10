using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Management;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

namespace ProxyWatcher
{
    public partial class Form1 : Form
    {
        private ManagementEventWatcher _watcher;
        private Thread _thread;
        private static bool _ignoreChange;

        private static string _proxyUrl;
        private static string ProxyUrl
        {
            get => _proxyUrl;
            set => _proxyUrl = value.StartsWith("http", StringComparison.OrdinalIgnoreCase) ? value : $"http://{value}";
        }

        public Form1(IReadOnlyList<string> args)
        {
            ProxyUrl = args.Count > 0 ? args[0] : "http://pac.hannover-re.grp/proxy.pac";
            InitializeComponent();
            //StartThreadWatcher();
            StartWqlWatcher();
        }

        private void StartWqlWatcher()
        {
            Proxy.SetAutoConfig(ProxyUrl);
            var query = new WqlEventQuery($"select * from RegistryValueChangeEvent where Hive='HKEY_USERS' AND KeyPath='{WindowsIdentity.GetCurrent().User.Value}\\\\Software\\\\Microsoft\\\\Windows\\\\CurrentVersion\\\\Internet Settings' and ValueName='AutoConfigURL'");
            _watcher = new ManagementEventWatcher(query);
            _watcher.EventArrived += (sender, args) => ProxyChanged();
            _watcher.Start();
        }

        private void ProxyChanged()
        {
            if (_ignoreChange)
            {
                _ignoreChange = false;
                return;
            }
            Thread.Sleep(3000);
            SyncProxy(notifyIcon);
        }

        //private void StartThreadWatcher()
        //{
        //    _thread = new Thread(SyncProxy);
        //    _thread.Start(notifyIcon);
        //}

        private static void SyncProxy(object notifyIcon)
        {
            var icon = (NotifyIcon)notifyIcon;

            //while (true)
            {
                if (Proxy.SetAutoConfig(ProxyUrl) && icon.Visible)
                {
                    var oldText = icon.BalloonTipText;
                    icon.BalloonTipText = $"Proxy set to {ProxyUrl}";
                    icon.ShowBalloonTip(0);
                    icon.BalloonTipText = oldText;
                }
                //Thread.Sleep(30 * 1000);
            }
            // ReSharper disable once FunctionNeverReturns
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            WindowState = FormWindowState.Minimized;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            ShowInTaskbar = false;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _watcher?.Stop();
            _thread?.Abort();
            base.OnClosing(e);
        }

        private void toolStripMenuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ProxySelected(object sender, EventArgs e)
        {
            var menuItem = (ToolStripItem) sender;

            foreach (ToolStripItem item in contextMenu.Items)
                if (item.Font.Bold)
                    item.Font = new Font(item.Font, FontStyle.Regular);

            menuItem.Font = new Font(menuItem.Font, FontStyle.Bold);
            ProxyUrl = menuItem.Text;
            _ignoreChange = true;
            Proxy.SetAutoConfig(ProxyUrl);
        }
    }
}
