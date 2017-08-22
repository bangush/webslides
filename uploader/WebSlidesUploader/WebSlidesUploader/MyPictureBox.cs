using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WebSlidesUploader
{
    public partial class MyPictureBox : UserControl
    {
        #region Membres et constructeur

        float zoomFactor;
        float oldZoomFactor = 1;
        private const int maxWidth = 12000;
        private const int maxHeight = 12000;
        private string currentFileName = "";

        Point middle;

        Uploader parent;

        public Image Image
        {
            get { return pctbox.Image; }
        }

        // constructeur
        public MyPictureBox(Uploader parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        public void MyDispose(bool nul)
        {
            pctbox.Image.Dispose();
            if (nul)
                pctbox.Image = null;
        }

        #endregion

        #region Affichage

        // mise à jour de l'image dans la picturebox
        public void UpdateImage(string fileName)
        {
            pctbox.Cursor = Cursors.Arrow;
            currentFileName = fileName;
            if (pctbox.Image != null)
                pctbox.Image.Dispose();

            if (currentFileName == null || currentFileName == "")
            {
                pctbox.Image = null;
                return;
            }

            // affiche le fichier courant et ses infos
            FileStream stream = new FileStream(currentFileName, FileMode.Open, FileAccess.Read);
            pctbox.Image = Image.FromStream(stream);
            stream.Close();

            ResizePctb();

        }

        // retaille la picturebox à sa taille normale. Si l'image est plus petite, la picturebox est rétrécie.
        public void ResizePctb()
        {
            float imgRatio = 1;
            if (pctbox.Image==null) // pas d'image
            {
                return;
            }
            int width = pctbox.Image.Size.Width;
            int height = pctbox.Image.Size.Height;

            pctbox.Hide();
            imgRatio = (float)width / height; // ratio de l'image
            int maxHeight = Height;
            int maxWidth = Width;
            if (imgRatio >= 1) // largeur > hauteur
            {
                if (width > maxWidth) // l'image est plus large que le panneau
                {
                    if ((maxWidth / imgRatio) < maxHeight)
                        pctbox.Size = new Size(maxWidth, (int)(maxWidth / imgRatio));
                    else
                        pctbox.Size = new Size((int)(maxHeight * imgRatio), maxHeight);
                }
                else // largeur <= largeur max
                {
                    if (width / imgRatio < maxHeight)
                        pctbox.Size = new Size(width, (int)(width / imgRatio));
                    else pctbox.Size = new Size((int)(maxHeight * imgRatio), maxHeight);
                }
            }
            else // imgRatio < 1 donc hauteur > largeur
            {
                if (height > maxHeight)
                {
                    if (maxHeight * imgRatio < maxWidth)
                        pctbox.Size = new Size((int)(maxHeight * imgRatio), maxHeight);
                    else pctbox.Size = new Size(maxWidth, (int)(maxWidth / imgRatio));
                }
                else
                {
                    if (height * imgRatio < maxWidth)
                        pctbox.Size = new Size((int)(height * imgRatio), height);
                    else pctbox.Size = new Size(maxWidth, (int)(maxWidth / imgRatio));
                }
            }
            zoomFactor = (float)pctbox.Size.Width / pctbox.Image.Size.Width;
            oldZoomFactor = zoomFactor;
            Reposition();
            pctbox.Show();
        }

        // repositionne la picturebox et la scrollbar
        private void Reposition()
        {
            if (pctbox.Size.Width <= Size.Width && pctbox.Size.Height <= Size.Height)
            {
                pctbox.Location = new Point((Width - pctbox.Width) / 2, (Height - pctbox.Height) / 2);
                pctbox.Cursor = Cursors.Default;
            }
            else // si picturebox est plus grand que le panneau
            {
                pctbox.Cursor = Cursors.Hand;
                pctbox.Location = new Point(AutoScrollPosition.X, AutoScrollPosition.Y);
                int newX = (int)(middle.X * (zoomFactor / oldZoomFactor));
                int newY = (int)(middle.Y * (zoomFactor / oldZoomFactor));

                int x = -(Size.Width / 2 - newX);
                int y = -(Size.Height / 2 - newY);
                AutoScrollPosition = new Point(x, y);

            }
        }



        #endregion



    }
}
