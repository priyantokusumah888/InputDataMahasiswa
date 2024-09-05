using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TugasBesarPBO
{
    public partial class Menu : Form
    {
        System.Data.SqlClient.SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-4RNVN6O\SQLEXPRESS;Initial Catalog=DBMAHASISWA;Integrated Security=True");

        public Menu()
        {
            InitializeComponent();
        }
        string Jenis_Kelamin;
        string imglocation = "";

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            byte[] images = null;
            FileStream streem = new FileStream(imglocation, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(streem);
            images = brs.ReadBytes((int)streem.Length);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into [mahasiswa] (NPM,Nama,Kelas,Prodi,Jenis_Kelamin,Alamat,Foto) values ('"+textBox1.Text+ "','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+Jenis_Kelamin+"','"+textBox5.Text+"',@images)";
            cmd.Parameters.Add(new SqlParameter("@images", images));
            cmd.ExecuteNonQuery();
            conn.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            pictureBox1.ImageLocation = null;
            display_data();
            MessageBox.Show("Data Insert Successfully");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from [mahasiswa] where Npm = '" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            conn.Close();
            textBox1.Text = "";
            display_data();
            MessageBox.Show("Data delete successfully");
        }

        private void button8_Click(object sender, EventArgs e)
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Jenis_Kelamin = "Laki_Laki";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Jenis_Kelamin = "Perempuan";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imglocation = dialog.FileName.ToString();
                pictureBox2.ImageLocation = imglocation;
            }
        }
        public void display_data()
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [mahasiswa]";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();






            SqlDataAdapter datadp = new SqlDataAdapter(cmd);
            datadp.Fill(dta);
            dataGridView1.DataSource = dta;
            conn.Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            display_data();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            byte[] images = null;
            FileStream streem = new FileStream(imglocation, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(streem);
            images = brs.ReadBytes((int)streem.Length);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = " update [mahasiswa] set NPM = '" + this.textBox1.Text + "',Nama = '" + this.textBox2.Text + "',Kelas = '" + this.textBox3.Text + "',Prodi = '" + this.textBox4.Text + "',Jenis_Kelamin = '" + this.Jenis_Kelamin + "',Alamat = '" + this.textBox5.Text + "',Foto = @images where NPM = '" + this.textBox1.Text + "'";
            cmd.Parameters.Add(new SqlParameter("@images", images));
            cmd.ExecuteNonQuery();
            conn.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            pictureBox1.ImageLocation = null;
            display_data();
            MessageBox.Show("Data update Successfully");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [mahasiswa] where Nama = '" + textBox6.Text + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
            textBox6.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            pictureBox2.ImageLocation = null;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
