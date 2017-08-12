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
using System.Reflection;
using System.Threading;

namespace WebSlides
{
    public partial class Slides : Form
    {
        const string slidesURL = "http://webslides.chiwawaweb.com/hifi/";
        const string slidesPath = "slides/";
        static String slidesLocalPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6) + @"\slides\";
        const int nbMaxSlides = 50;
        
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        private static bool CheckInternetConnection()
        {
            int Desc;
            if (InternetGetConnectedState(out Desc, 0))
            {
                // connexion internet OK
                //MessageBox.Show("connexion internet ok");
                return true;
            }
            else
            {
                // pas de connexion internet
                return false;
            }
        }

        private string CheckRemoteSlidesTxt()
        {
            string slidesTxtRemoteURL = slidesURL + slidesPath + "slides.txt";
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
            string slidesTxtLocalPath = slidesLocalPath + "slides.txt";
            if (File.Exists(slidesTxtLocalPath) == true)
            {
                string contentLocalSlidesTxt = File.ReadAllText(slidesTxtLocalPath);
                return contentLocalSlidesTxt;
            }
            else
            {
                return "";
            }
        }

        private static bool CheckSlidesPicture(int imgNumber)
        {
            string imgFileURL = slidesURL + slidesPath + "slide_" + imgNumber.ToString("000") + ".jpg";
            var imgExist = string.Empty;
            using (var webClient = new System.Net.WebClient())
            {
                try
                {
                    webClient.DownloadFile(imgFileURL, slidesLocalPath + "slide_" + imgNumber.ToString("000") + ".jpg");
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public Slides()
        {
            InitializeComponent();
        }

        private void Slides_Load(object sender, EventArgs e)
        {
            Cursor.Hide();
            

            if (CheckInternetConnection() == true)
            {
                // vérifie si le fichier slides.txt existe
                if (CheckRemoteSlidesTxt() != null)
                {
                    // fichier existant
                   
                    Console.Write("Contenu du fichier slides.txt local   : " + CheckLocalSlidesTxt() + " \n");

                    if (CheckLocalSlidesTxt() == CheckRemoteSlidesTxt())
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
                            Directory.Delete(slidesLocalPath, true);
                        }
                        catch 
                        {
                           // MessageBox.Show("erreur");
                        }

                        // création du dossier
                        Directory.CreateDirectory(slidesLocalPath);

                        File.WriteAllText(slidesLocalPath + "slides.txt", CheckRemoteSlidesTxt());


                        Console.Write("Fichier slides.txt créé/remplacé \n");

                        // importation des slides
                        try
                        {
                            // compte combien de fichier 'slide_xxx.jpg' importés en local
                            // compte de 1 à nbMaxSlides
                            int nbLocalSlides = 0;
                            double coeffProgressBar = 100 / nbMaxSlides;
                            
                            for (int slideNumber = 1; slideNumber < nbMaxSlides+1; ++slideNumber)
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
                                progressBar.Value += Int32.Parse(coeffProgressBar.ToString());
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

            progressBar.Visible = false;

            // démarrage du diaporama
            // affiche le premier fichier
            //Image myimage = new Bitmap(@"slides\slide_001.jpg");
            //this.BackgroundImage = myimage;
            for (int i = 1; i < 15; i++)
            {
                showSlide(i);
                MessageBox.Show("+");
            }
        }

        private void Slides_KeyPress(object sender, KeyPressEventArgs e)
        {
            Application.Exit();
        }

        private void Slides_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            
        }

        private void showSlide(int imgNumber)
        {
            Image slide = new Bitmap(slidesLocalPath + "slide_"+imgNumber.ToString("000")+".jpg");
            this.BackgroundImage = slide;
        }
    }
}
