using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using System.IO;

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
            //action = arguments[1].Substring(0, 2);
            
            // nombre d'arguments envoyé à l'éxécutable
            int nbArguments = arguments.Length;

            if (nbArguments > 1)
            {
                action = arguments[1].Substring(0, 2);
            }
            else
            {
                string dateActuelle = System.DateTime.Now.ToShortDateString();
                string anneeActuelle = dateActuelle.Substring(6, 4);

            
                MessageBox.Show("(c) Copyright "+anneeActuelle+", Frédéric Schwartz ");
                Application.Exit();
            }

            //MessageBox.Show(Convert.ToString(nbArguments)+" ["+action+"]");

            if (action == "/s" || action == "/S")
            {
                // Mode Show, on lance le slideshow
                Application.Run(new MainFrm());
            }
            else if (action == "/c")
            {
                // Page de configuration

                /*
                SetupFrm frm = new SetupFrm();
                frm.ShowDialog();
                */
                MessageBox.Show(
                    "Cet écran de veille n'est pas configurable actuellement.",
                    "WebSlides", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Asterisk);
            }

            else
            {
                // Sinon on crée le fichier de config et on ferme l'appli.
                //StreamWriter file = new StreamWriter(@"WebSlides.ini");

                // vérifie si le fichier de config existe déjà


                //MessageBox.Show("Le fichier a bien été créé dans l'emplacement spécifié!", "ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                /*file.Write("http://webslides.chiwawaweb.com");
                file.Close();*/

                // fermeture de l'application
                Application.Exit();    
            }


                
        }


    }
}
