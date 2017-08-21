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

        public Uploader()
        {
            InitializeComponent();
        }

        private void Uploader_Load(object sender, EventArgs e)
        {


            DirectoryInfo dir = new DirectoryInfo(tmpSlidesPath);
            FileInfo[] fichiers = dir.GetFiles();

            //DirectoryInfo dir = new DirectoryInfo(@"c:\pics");
            this.listView1.View = View.LargeIcon;
            
            this.imageList1.ImageSize = new Size(135, 76);
            this.listView1.LargeImageList = this.imageList1;
            int j = 0;
            foreach (FileInfo file in dir.GetFiles())
            {
                try
                {
                    //this.imageList1.Images.Add(Image.FromFile(file.FullName));
                    imageList1.Images.Add(file.Name, Image.FromFile(file.FullName));
                    ListViewItem item = new ListViewItem(file.Name);
                    item.Tag = file.Name;
                    item.ImageIndex = j;
                    this.listView1.Items.Add(item);
                    j++;
                }
                catch
                {
                    Console.WriteLine("This is not an image file");
                }
            }
        }

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
