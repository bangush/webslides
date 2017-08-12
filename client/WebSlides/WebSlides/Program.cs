using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime;
using System.Runtime.InteropServices;
using System.IO.Compression;
using System.IO;
using System.Configuration;

namespace WebSlides
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static string action;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            String[] arguments = Environment.GetCommandLineArgs();
            int nbArguments = arguments.Length;

            if (nbArguments>1)
            {
                action = arguments[1].Substring(0, 2);
            }
            else
            {
                //MessageBox.Show("STOP");
                Application.Exit();
            }

            MessageBox.Show("Action : "+action);

            // lancement du diaporama
            if (action=="/s"||action=="/S")
            {
                Application.Run(new Slides());
            }
            
        }
    }
}
