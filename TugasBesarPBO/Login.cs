using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.Common;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TugasBesarPBO
{
    public partial class Login : Form
    {
        DbConfig db = new DbConfig();
        Mst_User dtuser = new Mst_User();

        public Login()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-4RNVN6O\\SQLEXPRESS;Initial Catalog=DBMAHASISWA;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Masukan Username dan Password",
                "Warning", MessageBoxButtons.OK);
                textBox1.Focus();
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Masukan Username", "Warning", MessageBoxButtons.OK);
                textBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Masukan Password", "Warning", MessageBoxButtons.OK);
                textBox2.Focus();
            }
            else
            {
                SqlDataReader reader = null;
                System.Data.SqlClient.SqlConnection conn = db.GetConn();
                try
                {
                    conn.Open();
                    dtuser.username = textBox1.Text;
                    dtuser.password = textBox2.Text;
                    reader = dtuser.GetDataUserLogin(conn);
                    if (reader.Read() == false)
                    {
                        MessageBox.Show("Username tidak ada",
                        "Error", MessageBoxButtons.OK);
                        textBox1.Focus();
                    }
                    else
                    {
                        if (textBox2.Text != reader["password"].ToString())
                        {
                            MessageBox.Show("Password Salah", "Error",
                            MessageBoxButtons.OK);
                            textBox2.Focus();
                        }
                        else
                        {
                            Menu mn = new Menu();
                            Hide();
                            mn.Show();
                        }
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure want to quit ?",
            "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }

        }
    }
}