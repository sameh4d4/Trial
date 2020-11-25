using ClassLibrary1;
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
        public User u=null;
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

    
        private void FormUtama_Load_1(object sender, EventArgs e)
        {
            labelUser.Text = "root";
            WindowState = FormWindowState.Maximized;
            IsMdiContainer = true;
            FormLogin login = new FormLogin();
            login.Owner = this;
            login.Show();
            Enabled = false;
        }

        private void penjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form = Application.OpenForms["FormTambahNotaJual"];
            if (form == null)
            {
                FormTambahNotaJual laporanPenjualan = new FormTambahNotaJual();
                laporanPenjualan.MdiParent = this;
                laporanPenjualan.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void penjualanToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            form = Application.OpenForms["FormLaporanPenjualan"];
            if (form == null)
            {
                FormLaporanPenjualan laporanPenjualan = new FormLaporanPenjualan();
                laporanPenjualan.MdiParent = this;
                laporanPenjualan.Show();
                //comment
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void pegawaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form = Application.OpenForms["FormDaftarPegawai"];
            if (form == null)
            {
                FormDaftarPegawai formDaftarPegawai = new FormDaftarPegawai();
                formDaftarPegawai.MdiParent = this;
                formDaftarPegawai.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }
    }
}
