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
        const int nbMaxImportSlides = 100;

        static int imgNumber = 1;

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

        private string CheckRemoteSlidesTxt()
        {
            string slidesTxtRemoteURL = slidesURL + slidesPath + "slides.txt";
            string contentRemoteSlidesTxt;
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

        // importation des slides distants
        private static void ImportRemoteSlides(int imgNumber)
        {
            string imgFileURL = slidesURL + slidesPath + "slide_" + imgNumber.ToString("000") + ".jpg";
            var imgExist = string.Empty;
            using (var webClient = new System.Net.WebClient())
            {
                try
                {
                    webClient.DownloadFile(imgFileURL, slidesLocalPath + "slide_" + imgNumber.ToString("000") + ".jpg");
                }
                catch
                {
                    // erreur, on ne fait rien...
                }
            }
        }

        // compte combien de slides sont présents dans le dossier slideLocalPath
        private int compteNbSlidesLocal()
        {

            try
            {
                var files = from file in Directory.EnumerateFiles(slidesLocalPath, "slide_*.jpg", SearchOption.AllDirectories)
                            select new
                            {
                                File = file,
                            };
                // renvoie le nombre de slides trouvés
                return files.Count();
            }
            catch
            {
                return 0;
            }
        }

        private void runSlideShow()
        {
            timer.Enabled = false;

            // vérifie la connexion internet
            if (CheckInternetConnection() == true)
            {
                // indicateur connexin internet
                this.internetConnection.Visible = false;

                // vérifie si le fichier slides.txt existe
                if (CheckRemoteSlidesTxt() != null)
                {
                    // fichier existant
                    if (CheckLocalSlidesTxt() == CheckRemoteSlidesTxt())
                    {
                        // fichier slides.txt identique local/distant
                    }
                    else
                    {
                        // fichier slides.txt différent local/distant
                        // effacement du dossier
                        try
                        {
                            Directory.Delete(slidesLocalPath, true);
                        }
                        catch
                        {
                            // si erreur, on ne fait rien
                        }

                        // création du dossier
                        Directory.CreateDirectory(slidesLocalPath);

                        // création du fichier
                        File.WriteAllText(slidesLocalPath + "slides.txt", CheckRemoteSlidesTxt());

                        // importation des slides
                        int coeffProgressBar = 100 / nbMaxImportSlides;
                        progressBar.Visible = true;

                        for (int slideNumber = 1; slideNumber < nbMaxImportSlides + 1; ++slideNumber)
                        {
                            // importation de chaque slide
                            ImportRemoteSlides(slideNumber);
                            // mise à jour de la barre de progression
                            progressBar.Value += coeffProgressBar;
                        }
                    }
                }
                else
                {
                    // fichier slides.txt distant introuvable
                }
            }
            else
            {
                // pas de connexion internet
                this.internetConnection.Visible = true;
            }
            // barre de progression invisible
            progressBar.Visible = false;

            // lance le premier slide
            showSlide();
            timer.Enabled = true;
        }

        public Slides()
        {
            InitializeComponent();
        }

        private void Slides_Load(object sender, EventArgs e)
        {
            // masque le curseur
            Cursor.Hide();

            // lance le processus
            runSlideShow();
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
            showSlide();
        }

        private void showSlide()
        {
            if (imgNumber > compteNbSlidesLocal()) { imgNumber = 1; }
            string slideCompletePath = slidesLocalPath + "slide_" + imgNumber.ToString("000") + ".jpg";
            if (File.Exists(slideCompletePath))
            {
                Image slide = new Bitmap(slideCompletePath);
                this.BackgroundImage = slide;
                imgNumber++;
            }
            else
            {
                imgNumber++;
            }
        }
    }
}
