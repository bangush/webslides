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
            InitializeOpenFileDialog();

            DirectoryInfo dir = new DirectoryInfo(tmpSlidesPath);
            FileInfo[] fichiers = dir.GetFiles();

            //DirectoryInfo dir = new DirectoryInfo(@"c:\pics");
            this.listView1.View = View.LargeIcon;
            
            this.imageList1.ImageSize = new Size(100, 56);
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

        private void btn_upload_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                // copie les fichiers sur le disque dur, dossier slides-tmp

                

                
            }
        }



        private void InitializeOpenFileDialog()
        {
            // Set the file dialog to filter for graphics files.
            this.openFileDialog1.Filter =
                "Images (*.JPG)|*.JPG";

            // Allow the user to select multiple images.
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Chosissez les images à intégrer";
        }

        /* TEST d'envoi en FTP */
        private void test()
        {
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://ftp.chiwawaweb.com");
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential("anonymous", "janeDoe@contoso.com");

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            Console.WriteLine(reader.ReadToEnd());

            Console.WriteLine("Download Complete, status {0}", response.StatusDescription);

            reader.Close();
            response.Close();
        }


        // test de SUPPRESSION de la sélection...
        string msg = "";

        private void button1_Click(object sender, EventArgs e)
        {

            ListView.SelectedListViewItemCollection selectedItems = listView1.SelectedItems;

            foreach (ListViewItem item in selectedItems)
            {
                // affectation du tableau contenant les noms de fichiers

                // affiche les noms des fichiers sélectionnés
                msg += "- " +item.Tag.ToString()+"\n";
                
            }


            MessageBox.Show(msg.ToString());

            if (this.listView1.SelectedIndices.Count > 0)
                for (int i = 0; i < this.listView1.SelectedIndices.Count; i++)
                {
                    this.listView1.Items[this.listView1.SelectedIndices[i]].Selected = false;
                    
                    
                    
                    
                    this.listView1.Update();
                }


            msg = "";



        }


    }
}
