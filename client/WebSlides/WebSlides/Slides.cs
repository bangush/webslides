using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

namespace WebSlides
{
    public partial class Slides : Form
    {
        public Slides()
        {
            InitializeComponent();
        }

        private void Slides_Load(object sender, EventArgs e)
        {
            Cursor.Hide();
        }

        private void Slides_KeyPress(object sender, KeyPressEventArgs e)
        {
            Application.Exit();
        }

        private void Slides_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }
    }
}
