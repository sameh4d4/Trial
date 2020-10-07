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
    public partial class FormDaftarProduk : Form
    {
        public List<Barang> daftarBarang = new List<Barang>();
        public FormDaftarProduk()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahProduk frm = new FormTambahProduk();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            FormUbahProduk frm = new FormUbahProduk();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormHapusProduk frm = new FormHapusProduk();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void UpdateDG(List<Barang> i)
        {
            dataGridView1.Columns.Clear();
            if (i.Count > 0)
            {
                dataGridView1.Columns.Add("IdBarang", "ID Barang");
                dataGridView1.Columns.Add("IdPenjual", "Penjual");
                dataGridView1.Columns.Add("JenisBarang", "Jenis Barang");
                dataGridView1.Columns.Add("NamaBarang", "Nama Barang");
                dataGridView1.Columns.Add("Stok", "Stok");
                dataGridView1.Columns.Add("Harga", "Harga");
                dataGridView1.Columns.Add("Deskripsi", "Deskripsi");
                TampilDG(i);
                for (int a = 0; a < dataGridView1.Columns.Count; a++)
                {
                    if (dataGridView1.Columns[a].Name == "Id")
                    {
                        dataGridView1.Columns[a].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                    else
                    {
                        dataGridView1.Columns[a].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        if (dataGridView1.Columns[a].Name == "Harga" || dataGridView1.Columns[a].Name == "Stok")
                        {
                            dataGridView1.Columns[a].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                    }
                }
                dataGridView1.Columns["Harga"].DefaultCellStyle.Format = "#,###";
            }
            else
            {
                dataGridView1.Columns.Add("noData", "Tidak ada data");
                dataGridView1.Columns["noData"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dataGridView1.AllowUserToAddRows = false;
        }
        public void TampilDG(List<Barang> i)
        {
            foreach (Barang b in i)
            {
                dataGridView1.Rows.Add(b.IdBarang, b.IdPenjual, b.JenisBarang, b.NamaBarang, b.Stok, b.Harga, b.Deskripsi);
            }
        }

        private void FormDaftarProduk_Load(object sender, EventArgs e)
        {
            UpdateDG(daftarBarang);
        }
    }
}
