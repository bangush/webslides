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
                    imgExist = webClient.DownloadString(imgFileURL); // a modifier !!!!
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

                    // CheckSlidesTxt -> contenu du fichier slides.txt
                    // vérifie le fichier contient le nombre de slides

                    // vérifie si le fichier local existe
                    /*
                     * 
                    *CheckLocalSlidesTxt();
                    * 
                    */

                    if (CheckLocalSlidesTxt()==CheckRemoteSlidesTxt())
                    {
                        // fichier slides.txt identique local/distant
                        Console.Write("\nFichiers slides.txt identiques\n");
                    }
                    else
                    {
                        // fichier slides.txt identique local/distant
                        Console.Write("\nFichiers slides.txt différents\n");
                        System.IO.Directory.CreateDirectory(ConfigurationManager.AppSettings["slidesPath"]);
                        File.WriteAllText(@"slides/slides.txt", CheckRemoteSlidesTxt());
                        Console.Write("Fichier slides.txt créé \n");
                    }

                    /*
                    if (File.Exists(ConfigurationManager.AppSettings["slidesPath"]+"slides.txt"))
                    {
                        // Le fichier existe en local
                        Console.Write("slides.txt existe en local \n");

                        // On le compare au fichier distant
                        Console.Write("Contenu du fichier slides.txt LOCAL : "+CheckLocalSlidesTxt()+"\n");
                        Console.Write("Contenu du fichier slides.txt DISTANT : " + CheckRemoteSlidesTxt()+"\n");
                    }
                    else
                    {
                        // Le fichier n'existe pas en local
                        Console.Write("slides.txt n'existe pas en local \n");

                        // On le crée
                        System.IO.Directory.CreateDirectory(ConfigurationManager.AppSettings["slidesPath"]);
                        File.WriteAllText(@"slides/slides.txt", CheckRemoteSlidesTxt());
                        Console.Write("Fichier slides.txt créé \n");
                    }*/

                    try
                    {
                        //int nbSlidesRemote = Int32.Parse(CheckRemoteSlidesTxt().Substring(0, CheckRemoteSlidesTxt().IndexOf(";")));
                        //Console.Write("Nombre de slides indiqués dans le fichier slides.txt : " + nbSlidesRemote + "\n");

                        // compte combien de fichier 'slide_xxx.jpg' en local (idem slidesPath)
                        // compte de 1 à xxx
                        for (int j = 1; j < Int32.Parse(ConfigurationManager.AppSettings["nbMaxSlides"])+1; ++j)
                        {
                            if (CheckSlidesPicture(j)==true)
                            {
                                Console.Write(j + " OK" + "\n");
                            }
                            else
                            {
                                Console.Write(j + " not ok" + "\n");
                            }
                            //string slidesFileName = "slide_" + j.ToString("000") + ".jpg";
                            //Console.Write(slidesFileName + "\n");
                        }
                    }
                    catch
                    {
                        // fichier slides.txt invalide
                        Console.Write("Fichier slides.txt invalide ! \n");
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
            Console.Write("\nPressez ENTER pour terminer... \n");
            Console.ResetColor();
            Console.ReadLine();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
    }
}
