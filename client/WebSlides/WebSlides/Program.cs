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

namespace WebSlides
{
    static class Program
    {

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            

            

            Console.Write("Vérification de la connexion Internet : ");

            int Desc;
            if (InternetGetConnectedState(out Desc, 0))
            {
                // connexion internet OK
                Console.Write("OK \n");
            }
            else
            {
                // pas de connexion internet
                Console.Write("Pas de connexion ! \n");
            }


            Console.ReadLine();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());


        }

        
    }
}
