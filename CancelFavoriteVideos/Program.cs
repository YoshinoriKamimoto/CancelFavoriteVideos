using CancelFavoriteVideos.Views;
using System.Diagnostics;

namespace CancelFavoriteVideos
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // �O���[�o���G���[�n���h�����O
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new SetupForm());
        }

        // �O���[�o���G���[�n���h�����O
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            try
            {
                Exception ex = e.Exception;
                ShowErrorMessage(ex);
            }
            finally
            {
                Application.Exit();
            }
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = (Exception)e.ExceptionObject;
                ShowErrorMessage(ex);
            }
            finally
            {
                Application.Exit();
            }
        }

        private static void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            try
            {
                Exception ex = e.Exception;
                ShowErrorMessage(ex);
            }
            finally
            {
                Application.Exit();
            }
        }

        private static void ShowErrorMessage(Exception ex)
        {
            Debug.WriteLine($"�\�����Ȃ��G���[������\n{ex}");
            MessageBox.Show($"�\�����Ȃ��G���[���������܂���\n\n{ex}", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}