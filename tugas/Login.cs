using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace tugas
{
   
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
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

            SqlConnection koneksi = new SqlConnection(@"Data Source=DESKTOP-UH1K7RG\MSSQLSERVER01;Initial Catalog=Hotel_system;Integrated Security=True;");
            string query = "SELECT COUNT(*) as Count, ISNULL(Admin, 0) as Admin FROM Login WHERE Username = @Username AND Password = @Password GROUP BY Admin";

            SqlCommand cmd = new SqlCommand(query, koneksi);
            cmd.Parameters.AddWithValue("@Username", textBox1.Text);
            cmd.Parameters.AddWithValue("@Password", textBox2.Text);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                koneksi.Open();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    int count = Convert.ToInt32(dt.Rows[0]["Count"]);
                    bool Admin = dt.Rows[0]["Admin"] != DBNull.Value && Convert.ToBoolean(dt.Rows[0]["Admin"]);

                    if (count == 1)
                    {
                        this.Hide();
                        //menampilkan Home admin atau bukan
                        if (Admin)
                        {
                            HomeMaster panggil = new HomeMaster();
                            panggil.Show();
                        }
                        else
                        {
                            Home homeForm = new Home();
                            homeForm.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username atau Password salah!");
                    }
                }
                else
                {
                    MessageBox.Show("Username atau Password salah!");
                }
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



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
