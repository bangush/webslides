using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebSlidesUploader
{
    public partial class MyListView : UserControl
    {
        #region Membres et constructeur

        private ImageList imgList;
        private const int thumbWidth = 100;
        private const int thumbHeight = 56;
        private int packetSize = 20;
        private Uploader parent;

        private string currentFileName;
        private string[] newFileName;
        private int nbOfFilesToAdd = 0;
        delegate void AddImagesCallBack(int ind);

        // constructeur
        public MyListView(Uploader parent)
        {
            InitializeComponent();
            imgList = new ImageList();
            imgList.ImageSize = new Size(thumbWidth, thumbHeight);
            imgList.ColorDepth = ColorDepth.Depth16Bit;

            lsv_thumbnails.LargeImageList = imgList;
            lsv_thumbnails.Alignment = ListViewAlignment.Default;
            lsv_thumbnails.HideSelection = false;
            this.parent = parent;
        }

        // nombre d'éléments dans la listview
        public int Count
        {
            get { return lsv_thumbnails.Items.Count; }
        }

        // nom du fichier courant
        public string CurrentName
        {
            get { return currentFileName; }
        }
        #endregion

        #region Add/get files

        // filtre les fichiers à ajouter and appelle le backgroundworker en charge d'ajouter les vignettes
        public void AddFiles(string[] filenames)
        {
            nbOfFilesToAdd = 0;

            newFileName = new string[filenames.Length];
            for (int i = 0; i < filenames.Length; i++)
            {
                // ajoute seulement les fichiers avec la bonne extension et qui ne sont pas déjà présents dans liste
                if (MyFormater.IsPictureFile(filenames[i]) && !imgList.Images.ContainsKey(filenames[i]))
                    newFileName[nbOfFilesToAdd++] = filenames[i];
            }

            if (nbOfFilesToAdd == 0) { return; }

            if (nbOfFilesToAdd < 30)
                packetSize = 10;
            else if (nbOfFilesToAdd < 100)
                packetSize = 20;
            else if (nbOfFilesToAdd < 200)
                packetSize = 30;
            else packetSize = 40;

            progressBar.Show();
            progressBar.Maximum = nbOfFilesToAdd / packetSize + 1;
            progressBar.Value = 0;
            bkgwk_openfiles.RunWorkerAsync();
        }
        
        



        #endregion

    }
}
