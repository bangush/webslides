using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebSlides
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            String[] arguments = Environment.GetCommandLineArgs();
            string action = arguments[1].Substring(0, 2);

            if (action == "/s")
            {
                Application.Run(new MainFrm());
            }
            else
            {
                Application.Run(new Splash());
            }
                
        }
    }
}
