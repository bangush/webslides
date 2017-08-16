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

                

                // Read the files
                foreach (String file in openFileDialog1.FileNames)
                {
                    // Create a PictureBox.
                    try
                    {
                        PictureBox pb = new PictureBox();
                        Image loadedImage = Image.FromFile(file);
                        pb.Height = loadedImage.Height;
                        pb.Width = loadedImage.Width;
                        pb.Image = loadedImage;
                        //flowLayoutPanel1.Controls.Add(pb);
                    }
                    catch (SecurityException ex)
                    {
                        // The user lacks appropriate permissions to read files, discover paths, etc.
                        MessageBox.Show("Security error. Please contact your administrator for details.\n\n" +
                            "Error message: " + ex.Message + "\n\n" +
                            "Details (send to Support):\n\n" + ex.StackTrace
                        );
                    }
                    catch (Exception ex)
                    {
                        // Could not load the image - probably related to Windows file system permissions.
                        MessageBox.Show("Cannot display the image: " + file.Substring(file.LastIndexOf('\\'))
                            + ". You may not have permission to read the file, or " +
                            "it may be corrupt.\n\nReported error: " + ex.Message);
                    }
                }
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

        private void test()
        {
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://www.contoso.com/test.htm");
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


        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeOpenFileDialog();

            DirectoryInfo dir = new DirectoryInfo(tmpSlidesPath);
            FileInfo[] fichiers = dir.GetFiles();

            foreach (FileInfo fichier in fichiers)
            {
                listView1.CheckBoxes = true;
                listView1.Tag = fichier.Name;
                
                imageList1.Images.Add(Image.FromFile(tmpSlidesPath+fichier.Name));
            }
            listView1.View = View.LargeIcon;
            imageList1.ImageSize = new Size(100, 60);
            
            listView1.LargeImageList = imageList1;

            ListView.CheckedListViewItemCollection checkedItems = listView1.CheckedItems;

            for (int j = 0; j < imageList1.Images.Count; j++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = j;
                listView1.Items.Add(item);
            }
        }

        private string msgtest = "";

        private void button1_Click(object sender, EventArgs e)
        {
            ListView.CheckedListViewItemCollection checkedItems = listView1.CheckedItems;
            int compteur = 0;
            
            foreach (ListViewItem item in checkedItems)
            {
                msgtest += item.Tag.ToString();
                compteur = compteur + 1;
            }
            MessageBox.Show(msgtest);

            listView1.Refresh();
        }
    }
}
