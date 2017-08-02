using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebSlides
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            String[] arguments = Environment.GetCommandLineArgs();
            string action = arguments[1].Substring(0,2);

            if (action == "/c")
            {
                // mode configuration
                MessageBox.Show("Aucune configuration possible pour cet écran de veille.");
                this.Close();
            }
            else if (action == "/p")
            {
                // mode aperçu
                // ferme le Splash
                this.Close();
            }
            else
            {
                // mode Show
                label1.Text = "Show "+action;
                

                // bascule sur le slideshow
                MainFrm frm = new MainFrm();
                frm.Show();

                // ferme la fenêtre
                this.Close();


            }


        }

    }
}
