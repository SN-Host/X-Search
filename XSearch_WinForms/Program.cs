using XSearch_Lib;

namespace XSearch_WinForms
{
    internal static class Program
    {
        /// <summary>
        /// Gets the current session used by the WinForms application.
        /// </summary>
        public static Session CurrentSession
        {
            get
            {
                if (_currentSession != null)
                {
                    return _currentSession;
                }
                _currentSession = new Session();
                return _currentSession;
            }
            set
            {
                _currentSession = value;
            }
        }
        private static Session? _currentSession;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
            // Test
        }
    }
}