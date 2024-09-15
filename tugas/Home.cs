using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace tugas
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {
            SqlConnection koneksi = new SqlConnection(@"Data Source=DESKTOP-UH1K7RG\MSSQLSERVER01;Initial Catalog=Hotel_system;Integrated Security=True;");
            string query = "SELECT Username FROM Hotel_system WHERE Username = @Username";
            SqlCommand cmd = new SqlCommand(query, koneksi);
            cmd.Parameters.AddWithValue("@Username", Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void toolStripComboBox3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripDropDownButton3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripDropDownButton2_Click(object sender, EventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tampilkan form login
            Login ke = new Login();

            // Tampilkan form login sebagai form utama
            ke.Show();

            // Tutup form saat ini (form utama)
            this.Close();
        }
    }
}
