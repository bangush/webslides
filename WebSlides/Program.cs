using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebSlides
{
    static class Program
    {

        // 
        public static string action;
        

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            String[] arguments = Environment.GetCommandLineArgs();
            action = arguments[1].Substring(0, 2);
            
            

            if (action == "/s")
            {
                // Mode Show, on lance le slideshow
                Application.Run(new MainFrm());
            }
            else if (action == "/c")
            {
                // Page de configuration
                MessageBox.Show(
                    "Cet écran de veille n'est pas configurable.",
                    "WebSlides", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Asterisk);
            }

            else
            {
                // Sinon on ferme l'application
                Application.Exit();    
            }
                
        }
    }
}
