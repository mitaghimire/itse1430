//using directive - imports all identifiers from a namespace
using System;
using System.Windows.Forms;
//using System.Windows.Forms;

namespace MovieLibrary.WindformsHost
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           // System.Windows.Forms.Application.SetHighDp1Mode(HighDpiMode.SystemAware);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
           // Application.Run(new MovieLibrary.WindformsHost.MainForm());
        }
    }
}
