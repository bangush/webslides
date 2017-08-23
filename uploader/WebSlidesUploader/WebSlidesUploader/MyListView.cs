using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Threading;

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
        private string[] newFileNames;
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
        public string CurrentFileName
        {
            get { return currentFileName; }
        }
        #endregion

        #region Add/get files

        // filtre les fichiers à ajouter and appelle le backgroundworker en charge d'ajouter les vignettes
        public void AddFiles(string[] filenames)
        {
            nbOfFilesToAdd = 0;

            newFileNames = new string[filenames.Length];
            for (int i = 0; i < filenames.Length; i++)
            {
                // ajoute seulement les fichiers avec la bonne extension et qui ne sont pas déjà présents dans liste
                if (MyFormater.IsPictureFile(filenames[i]) && !imgList.Images.ContainsKey(filenames[i]))
                    newFileNames[nbOfFilesToAdd++] = filenames[i];
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

        public string[] GetAllFilesNames()
        {
            string[] result = new string[lsv_thumbnails.Items.Count];
            int i = 0;
            foreach (ListViewItem lvi in lsv_thumbnails.Items)
            {
                result[i++] = lvi.Name;
            }
            return result;
        }

        public void CloseOrDeleteSelectedFiles(bool delete)
        {
            int count = lsv_thumbnails.SelectedIndices.Count;
            if (count == 0)
                return;

            if (delete == true) // confirmation message only if the files are to be deleted
            {
                string msg = "Are you sure you want to delete ";
                if (count == 1)
                    msg += "the file \"" + lsv_thumbnails.SelectedItems[0].Name + "\" ?";
                else msg += "the " + count + " selected files ?";

                DialogResult res = MessageBox.Show(msg, "Delete file(s)", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.No)
                    return;
            }

            try
            {
                int ind = lsv_thumbnails.SelectedIndices[0]; //Indice of the 1st file selected 
                lsv_thumbnails.BeginUpdate();
                foreach (ListViewItem lvi in lsv_thumbnails.SelectedItems)// Removes the selected items from the lsv
                {
                    imgList.Images.RemoveByKey(lvi.Name);
                    lsv_thumbnails.Items.RemoveByKey(lvi.Name);
                    if (delete == true)
                        File.Delete(lvi.Name);
                }

                //We will now try to select the item which was just before the 1st deleted one 
                if (ind >= lsv_thumbnails.Items.Count)
                    ind = lsv_thumbnails.Items.Count - 1;

                if (ind < 0)// we closed/deleted all the files
                {
                    currentFileName = null;
                }
                else
                {
                    lsv_thumbnails.Items[ind].Selected = true; // Restores the selected index (different file)
                    currentFileName = lsv_thumbnails.Items[ind].Name;
                }
                lsv_thumbnails.EndUpdate();
                parent.UpdateMainPhoto();
                UpdateOpenFilesCount();

            }
            catch (Exception e)
            {
                string title = "Close file(s)";
                if (delete == true)
                    title = "Delete file(s)";
                MessageBox.Show(e.Message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // mise à jour du label indiquant le nombre de fichiers ouverts
        private void UpdateOpenFilesCount()
        {
            if (lsv_thumbnails.Items.Count <= 1)
                lbl_counter.Text = lsv_thumbnails.Items.Count + " image ouverte";
            else lbl_counter.Text = lsv_thumbnails.Items.Count + " images ouvertes";
        }


        #endregion

        #region Supprime image


        #endregion

        #region Evénements Clavier et souris

        // l'utilisateur appuie sur un bouton de la souris
        private void lsv_thumbnails_MouseDown(object sender, MouseEventArgs e)
        {
            ListViewItem lvi = lvi = lsv_thumbnails.HitTest(e.X, e.Y).Item;

            if (e.Button == MouseButtons.Right)
            {
                if (lvi == null)
                    return;
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (lvi != null)
                    currentFileName = lvi.Name;
                parent.UpdateMainPhoto();
            }
        }

        #endregion

        #region Remplissage des vignettes dans la listview avec le Backgroundworker

        // crée des paquets de vignettes à ajouter. Annonce la progression après chaque ajout
        private void bkgwk_openfiles_DoWork(object sender, DoWorkEventArgs e)
        {
            int NbOfPackets = nbOfFilesToAdd / packetSize + 1;

            // pour chaque paquet
            for(int j = 0; j < NbOfPackets; j++)
            {
                if (lsv_thumbnails.InvokeRequired) // pour résoudre le problème "cross thread"
                {
                    try
                    {
                        AddImagesCallBack d = new AddImagesCallBack(AddImages);
                        Invoke(d, new object[] { j });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                // rapporte la progression après la préparation de chaque paquet
                bkgwk_openfiles.ReportProgress(j);

                if (j != NbOfPackets - 1) // si ce n'est pas le dernier paquet
                    Thread.Sleep(150); // pour que la méthode progressreport ait le temps de remplir la listview
            }
        }

        // ajoute packetSize thumbnails to imgList
        void AddImages(int ind)
        {
            for (int i = 0; i < packetSize && i + ind * packetSize < nbOfFilesToAdd; i++)
            {
                imgList.Images.Add(newFileNames[i + ind * packetSize], CreateThumbnail(newFileNames[i + ind * packetSize]));
            }
        }

        // appelé quand le backgroundworker rapporte une progression...
        private void bkgwk_openfiles_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int size = packetSize;
            int j = e.ProgressPercentage;
            try
            {
                size = nbOfFilesToAdd - j * packetSize;
                if (size > packetSize)
                    size = packetSize;

                ListViewItem[] lvi = new ListViewItem[size];

                lsv_thumbnails.BeginUpdate();

                for (int i = 0; i < packetSize && i + j * packetSize < nbOfFilesToAdd; i++)
                    lsv_thumbnails.Items.Add(newFileNames[i + j * packetSize], Path.GetFileName(newFileNames[i + j * packetSize]), newFileNames[i + j * packetSize]);
                progressBar.Value = j + 1;
                lsv_thumbnails.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            UpdateOpenFilesCount();
            if (j == 0) // premier paquet
            {
                // le fichier courant est le premier que l'utilisateur vient d'ouvrir
                currentFileName = lsv_thumbnails.Items[newFileNames[0]].Name;
                lsv_thumbnails.Items[currentFileName].Selected = true;
                lsv_thumbnails.Items[currentFileName].Focused = true;

                parent.UpdateMainPhoto();
            }
        }

        // appelé quand le backgroundworker a terminé de chargé les images
        private void bkgwk_openfiles_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Hide();
        }

        // crée la vignette d'une image. 
        private Image CreateThumbnail(string filename)
        {
            Image img;
            PropertyItem p = null;
            byte[] imageBytes;
            MemoryStream stream = null;

            Stream originalstream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            img = Image.FromStream(originalstream, false, false);

            img.Dispose();

            if (p != null)
            {
                imageBytes = p.Value;
                stream = new MemoryStream(imageBytes.Length);
                stream.Write(imageBytes, 0, imageBytes.Length);
                img = Image.FromStream(stream);
                stream.Close();
            }
            else
            {
                img = Image.FromStream(originalstream);
            }
            originalstream.Close();

            return img;
        }

        #endregion

    }
}
