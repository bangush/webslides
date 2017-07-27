using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlideShow
{
    public partial class MainFrm : Form
    {
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
    }
}
