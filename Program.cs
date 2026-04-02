using System;
using System.Windows.Forms;

namespace Password_generator
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                var ex = e.ExceptionObject as Exception;
                AppLog.Write("CRASH",
                    ex?.Message ?? "Unknown exception",
                    ex?.ToString() ?? string.Empty);
            };

            Application.ThreadException += (s, e) =>
            {
                AppLog.Write("THREAD_EXCEPTION",
                    e.Exception.Message,
                    e.Exception.ToString());
                throw e.Exception;
            };

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}