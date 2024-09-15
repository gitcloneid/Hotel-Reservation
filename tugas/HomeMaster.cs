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
    public partial class HomeMaster : Form
    {
        public HomeMaster()
        {
            InitializeComponent();
        }

        private void masterHomeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void HomeMaster_Load(object sender, EventArgs e)
        {

        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tampilkan form login
            MasterEmployee ke = new MasterEmployee();

            // Tampilkan form login sebagai form utama
            ke.Show();

            // Tutup form saat ini (form utama)
            this.Close();
        }
    }
}
