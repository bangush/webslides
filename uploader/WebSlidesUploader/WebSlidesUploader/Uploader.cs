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

        private string CurrentFileName = "";
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

        private void tsb_addFiles_Click(object sender, EventArgs e)
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


        #endregion

        private void btn_quitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }










        // test de SUPPRESSION de la sélection...
        string msg = "";

        private void button1_Click(object sender, EventArgs e)
        {

            ListView.SelectedListViewItemCollection selectedItems = listView1.SelectedItems;

            foreach (ListViewItem item in selectedItems)
            {
                // affectation du tableau contenant les noms de fichiers


                // supprime les fichiers sélectionnés
                //File.Delete(tmpSlidesPath+item.Tag.ToString());
                
                

                // concaténation des noms des fichiers sélectionnés
                msg += "- " +tmpSlidesPath+item.Tag.ToString()+"\n";
                
            }

            // TMP : affiche la concatenation
            MessageBox.Show(msg.ToString());

            // deselectionne les fichiers
            if (this.listView1.SelectedIndices.Count > 0)
                for (int i = 0; i < this.listView1.SelectedIndices.Count; i++)
                {
                    this.listView1.Items[this.listView1.SelectedIndices[i]].Selected = false;
                    
                    this.listView1.Update();
                }


            msg = "";



        }

        private void fichierToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        
    }
}
