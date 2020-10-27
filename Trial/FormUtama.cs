using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trial
{
    public partial class FormUtama : Form
    {
        public FormUtama()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    
        Form form;


        private void barangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form = Application.OpenForms["FormDaftarProduk"];
            if (form == null)
            {
                FormDaftarProduk daftarBarang = new FormDaftarProduk();
                daftarBarang.MdiParent = this;
                daftarBarang.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void penjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pembelianToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void labaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    
        private void FormUtama_Load_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            IsMdiContainer = true;
            FormLogin login = new FormLogin();
            login.Owner = this;
            login.Show();
            Enabled = false;
        }
    }
}
