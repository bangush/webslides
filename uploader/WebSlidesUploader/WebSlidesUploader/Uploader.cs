using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security;
using System.Windows.Forms;

namespace WebSlidesUploader
{
    public partial class Uploader : Form
    {
        
        static String tmpSlidesPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6) + @"\slides-tmp\";

        #region Membres et constructeur

        private string currentFileName = "";
        private string lastModifiedFileName = "";
        private MyListView mylsv;
        private MyPictureBox mypcb;
        private bool showInfo;

        public Uploader(string[] args)
        {
            InitializeComponent();

            mylsv = new MyListView(this);
            tab_localImages.Controls.Add(mylsv);
            mylsv.Dock = DockStyle.Bottom;
            mylsv.Margin = new Padding(0, 0, 0, 0);
            mypcb = new MyPictureBox(this);
            Controls.Add(mypcb);
            mypcb.Location = new Point(408, 100);
            mypcb.Size = new Size(400, 308);
            showInfo = true;
            if (args != null)
                mylsv.AddFiles(args);
        }

        #endregion

        #region Evenement Ajoute des images

        private void Open_File_Click(object sender, EventArgs e)
        {
            OpenFileDialog opfd = new OpenFileDialog();
            opfd.Multiselect = true;
            opfd.Filter = "Images (*.JPG)|*.JPG;";
            opfd.Title = "Sélectionnez les images";
            if (opfd.ShowDialog() != DialogResult.OK)
                return;

            mylsv.AddFiles(opfd.FileNames);
        }

        #endregion

        #region Supprime les images

        // a faire

        #endregion

        // mise à jour de la picturebox et des informations de l'image
        public void UpdateMainPhoto()
        {
            currentFileName = mylsv.CurrentFileName;
            mypcb.UpdateImage(currentFileName); // redimensionne la picturebox

            // pas de fichier ouvert
            if (currentFileName == null || currentFileName == "")
            {
                // infos de l'image mise à zéro
            }
            // mise à jour des infos de l'image
            // taille
            // poids
            // etc.
        }

        private void tsb_addFiles_Click(object sender, EventArgs e)
        {
            Open_File_Click(sender, e);
        }

        private void btn_quitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }












        private void fichierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        
        private void tsb_delFiles_Click(object sender, EventArgs e)
        {
            mylsv.CloseOrDeleteSelectedFiles(false);

        }
    }
}
