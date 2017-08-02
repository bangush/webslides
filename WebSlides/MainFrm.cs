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
    public partial class MainFrm : Form
    {
        [DllImport("wininet.dll")]

        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        public MainFrm()
        {
            InitializeComponent();
            
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            
            
            
            
                // vérifie la présence d'une connexion Internet
                CheckInternetConnection();

                // supprime le curseur
                Cursor.Hide();
            


        }

        private void MainFrm_KeyUp(object sender, KeyEventArgs e)
        {
            Application.Exit();
        }

        private void webBrowser_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            Application.Exit();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // vérifie si connexion internet active à intervalles réguliers
            CheckInternetConnection();
        }

        public void CheckInternetConnection()
        {
            int Desc;
            if (InternetGetConnectedState(out Desc, 0))
            {
                // connexion internet ok
                webBrowser.Visible = true;
                webBrowser.Navigate("http://slideshow.chiwawaweb.com");
            }
            else
            {
                // pas de connexion internet
                webBrowser.Visible = false;
            }
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }

    
}
