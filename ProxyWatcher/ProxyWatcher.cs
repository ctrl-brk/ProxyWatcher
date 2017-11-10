using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

namespace ProxyWatcher
{
    internal static class ProxyWatcher
    {
        [STAThread]
        private static void Main(string[] args)
        {
            // get application GUID as defined in AssemblyInfo.cs
            var appGuid = ((GuidAttribute)Assembly.GetExecutingAssembly(). GetCustomAttributes(typeof(GuidAttribute), false).GetValue(0)).Value;
            // unique id for global mutex - Global prefix means it is global to the machine
            var mutexId = $"Global\\{{{appGuid}}}";
            
            // edited by Jeremy Wiebe to add example of setting up security for multi-user usage
            // edited by 'Marc' to work also on localized systems (don't use just "Everyone") 
            var allowEveryoneRule =
                new MutexAccessRule(
                    new SecurityIdentifier(WellKnownSidType.WorldSid, null),
                    MutexRights.FullControl, AccessControlType.Allow);

            var securitySettings = new MutexSecurity();
            securitySettings.AddAccessRule(allowEveryoneRule);

            // edited by MasonGZhwiti to prevent race condition on security settings via VanNguyen
            using (var mutex = new Mutex(false, mutexId, out bool _, securitySettings))
            {
                // edited by acidzombie24
                var hasHandle = false;

                try
                {
                    try
                    {
                        // note, you may want to time out here instead of waiting forever
                        // edited by acidzombie24
                        // mutex.WaitOne(Timeout.Infinite, false);
                        hasHandle = mutex.WaitOne(0, false);
                        if (hasHandle == false)
                        {
                            MessageBox.Show("The application is already running");
                            //throw new TimeoutException("Timeout waiting for exclusive access");
                            return;
                        }
                    }
                    catch (AbandonedMutexException)
                    {
                        // Log the fact that the mutex was abandoned in another process,
                        // it will still get acquired
                        hasHandle = true;
                    }

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    Application.Run(new Form1(args));
                }
                finally
                {
                    // edited by acidzombie24, added if statement
                    if (hasHandle)
                        mutex.ReleaseMutex();
                }
            }
        }
    }
}
