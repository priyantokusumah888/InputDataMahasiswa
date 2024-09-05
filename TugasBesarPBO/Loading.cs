using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TugasBesarPBO
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void Loading_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Login lgn = new Login();
            progressBar1.Value += 10;
            if (progressBar1.Value == 100)
            {
                timer1.Dispose();
                Hide();
                lgn.Show();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
    
        }
    }
}
