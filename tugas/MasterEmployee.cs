using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;

namespace tugas
{
    public partial class MasterEmployee : Form
    {
        SqlConnection koneksi = new SqlConnection(@"Data Source=DESKTOP-UH1K7RG\MSSQLSERVER01;Initial Catalog=Hotel_system;Integrated Security=True;");
        string imgLocation = "";
        SqlCommand cmd;
        public MasterEmployee()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] images = null;
            FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(stream);
            images = br.ReadBytes((int)stream.Length);

            try
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "INSERT INTO [Login] (Username, Password, Email, Tanggal_Lahir, Job, Alamat, Foto) VALUES (@Username, @Password, @Email, @Tanggal_Lahir, @Job, @Alamat, @images)";

                cmd.Parameters.AddWithValue("@Username", textBox1.Text);
                cmd.Parameters.AddWithValue("@Password", textBox2.Text);
                cmd.Parameters.AddWithValue("@Email", textBox3.Text);
                cmd.Parameters.AddWithValue("@Tanggal_Lahir", textBox4.Text);
                cmd.Parameters.AddWithValue("@Job", textBox5.Text);
                cmd.Parameters.AddWithValue("@Alamat", textBox6.Text);
                cmd.Parameters.AddWithValue("@images", images);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Berhasil Ditambahkan");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                koneksi.Close();
            }
        }


        private void MasterEmployee_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files (*.png)|*.png| jpg files(*.jpg)|*.jpg| all files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imgLocation;

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Tampilkan form login
            HomeMaster ke = new HomeMaster();

            // Tampilkan form login sebagai form utama
            ke.Show();

            // Tutup form saat ini (form utama)
            this.Close();
        }
    }
}
