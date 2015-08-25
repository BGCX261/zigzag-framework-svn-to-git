using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Zigzag.Loader
{
    static class MainStart
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string [] argv)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ZigzagWin(argv));
        }
    }
}