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

        private static string CheckRemoteSlidesTxt()
        {
            string slidesTxtRemoteURL = ConfigurationManager.AppSettings["slidesURL"]+ ConfigurationManager.AppSettings["slidesPath"]+"slides.txt";
            string contentRemoteSlidesTxt;// = string.Empty;
            using (var webClient = new System.Net.WebClient())
            {
                try
                {
                    contentRemoteSlidesTxt = webClient.DownloadString(slidesTxtRemoteURL);
                    return contentRemoteSlidesTxt;
                }
                catch
                {
                    return null;
                }
            }
            
        }

        private static string CheckLocalSlidesTxt()
        {
            string slidesTxtLocalPath = ConfigurationManager.AppSettings["slidesPath"] + "slides.txt";
            if (File.Exists(slidesTxtLocalPath) == true)
            {
                string contentLocalSlidesTxt = File.ReadAllText(slidesTxtLocalPath);
                return contentLocalSlidesTxt;
            }
            else
            {
                return null;
            }
            
        }

        private static bool CheckSlidesPicture(int imgNumber)
        {
            string imgFileURL = ConfigurationManager.AppSettings["slidesURL"] + ConfigurationManager.AppSettings["slidesPath"] + "slide_" + imgNumber.ToString("000") +".jpg";
            var imgExist = string.Empty;
            using (var webClient = new System.Net.WebClient())
            {
                try
                {
                    webClient.DownloadFile(imgFileURL, @"slides\slide_"+imgNumber.ToString("000")+".jpg"); // a modifier !!!!
                    return true; 
                }
                catch
                {
                    return false;
                }
            }
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
                if (CheckRemoteSlidesTxt()!=null)
                {
                    // fichier existant
                    Console.Write("Contenu du fichier slides.txt distant : " + CheckRemoteSlidesTxt()+" \n");
                    Console.Write("Contenu du fichier slides.txt local   : " + CheckLocalSlidesTxt() + " \n");

                    if (CheckLocalSlidesTxt()==CheckRemoteSlidesTxt())
                    {
                        // fichier slides.txt identique local/distant
                        Console.Write("\nFichiers slides.txt identiques\n");
                    }
                    else
                    {
                        // fichier slides.txt différent local/distant
                        Console.Write("\nFichiers slides.txt différents\n");

                        // effacement du dossier
                        try
                        {
                            Directory.Delete(@ConfigurationManager.AppSettings["slidesPath"], true);
                        }
                        catch (IOException e)
                        {
                            MessageBox.Show(e.Message);
                        }
                        

                        // création du dossier
                        Directory.CreateDirectory(ConfigurationManager.AppSettings["slidesPath"]);
                        File.WriteAllText(@ConfigurationManager.AppSettings["slidesPath"] +"/slides.txt", CheckRemoteSlidesTxt());
                        Console.Write("Fichier slides.txt créé/remplacé \n");

                        // importation des slides
                        try
                        {
                            // compte combien de fichier 'slide_xxx.jpg' importés en local
                            // compte de 1 à nbMaxSlides
                            int nbLocalSlides = 0;
                            for (int slideNumber = 1; slideNumber < Int32.Parse(ConfigurationManager.AppSettings["nbMaxSlides"]) + 1; ++slideNumber)
                            {
                                if (CheckSlidesPicture(slideNumber) == true)
                                {
                                    Console.Write(".");
                                    nbLocalSlides++;
                                }
                                else
                                {
                                    Console.Write("x");
                                }
                            }
                            Console.Write("\nNombre de slides importés local : " + nbLocalSlides + " \n");
                        }
                        catch
                        {
                            // fichier slides.txt invalide
                            Console.Write("Erreur importation ! \n");
                        }
                    }
                }
                else
                {
                    // fichier slides.txt introuvable
                    Console.Write("Pas de fichier slides.txt \n");
                }
            }
            else
            {
                // pas de connexion internet
                Console.Write("Pas de connexion ! \n");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n\nPressez ENTER pour terminer... \n");
            Console.ResetColor();
            Console.ReadLine();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // lancement du diaporama
            Application.Run(new Slides());
        }
    }
}
