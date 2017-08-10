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

namespace WebSlides
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        private static bool CheckInternetConnection()
        {
            int Desc;
            if (InternetGetConnectedState(out Desc, 0))
            {
                // connexion internet OK
                return true;
            }
            else
            {
                // pas de connexion internet
                return false;
            }
        }

        private static string CheckSlidesTxt(string url)
        {
            var slideExist = string.Empty;
            using (var webClient = new System.Net.WebClient())
            {
                try
                {
                    slideExist = webClient.DownloadString(url);
                    return slideExist;
                }
                catch
                {
                    return null;
                }
            }
            
        }

        private static bool CheckSlidesPicture(string url)
        {
            return true;
        }


        [STAThread]
        static void Main()
        {
            // vérifie la connexion internet
            Console.Write("Vérification de la connexion Internet : ");

            if (CheckInternetConnection()==true)
            {
                Console.Write("OK \n");
                // vérifie si le fichier slides.txt existe
                if (CheckSlidesTxt("http://webslides.chiwawaweb.com/hifi/slides/slides.txt")!=null)
                {
                    Console.Write("Contenu du fichier slides.txt : " + CheckSlidesTxt() + " \n");
                }
                else
                {
                    Console.Write("Pas de fichier slides.txt");
                }
            }
            else
            {
                Console.Write("Pas de connexion ! \n");
            }

            Console.ReadLine();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());


        }

        
    }
}
