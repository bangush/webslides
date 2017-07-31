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

namespace SlideShow
{
    public partial class MainFrm : Form
    {
        [DllImport("wininet.dll")]

        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        public MainFrm()
        {
            InitializeComponent();
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Détecte la fermeture et demande un mot de passe
            if (MessageBox.Show("Souhaitez-vous vraiment quitter le diaporama ?", "Quitter ?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            // vérifie la présence d'une connexion Internet
            int Desc;
            if (InternetGetConnectedState(out Desc,0))
            {
                // connexion internet ok
                
            }
            else
            {
                // pas de connexion internet
                // on affiche une image de remplacement
                webBrowser.Visible = false;
            }

            this.webBrowser.Navigate("http://slideshow.chiwawaweb.com");
        }

        private void MainFrm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Q)
            {
                Application.Exit();
            }
        }

        private void webBrowser_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Q)
            {
                Application.Exit();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.webBrowser.Navigate("http://www.chiwawaweb.com/slideshow");
        }
    }
}
