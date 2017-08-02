using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebSlides
{
    public partial class SetupFrm : Form
    {
        public SetupFrm()
        {
            InitializeComponent();
        }

        private void SetupFrm_Load(object sender, EventArgs e)
        {
            var version = Application.ProductVersion;
            VersionLbl.Text = version;

        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
