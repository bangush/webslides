using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlideShow
{
    public partial class Password : Form
    {
        public Password()
        {
            InitializeComponent();
        }

        private void Password_Load(object sender, EventArgs e)
        {
            this.ActiveControl = inputPassword;
            this.AcceptButton = btnOk;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // vérifie le mot de passe
            if (inputPassword.Text == "hifi")
            {
                this.Close();
            }
            
        }
    }
}
