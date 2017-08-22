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
        private string CurrentFileName = "";

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

    }
}
