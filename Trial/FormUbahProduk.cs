using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;
namespace Trial
{
    public partial class FormUbahProduk : Form
    {
        public FormUbahProduk()
        {
            InitializeComponent();

        }
        FormDaftarProduk daftar;

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            try
            {
                Barang b = new Barang(int.Parse(textBoxIDBarang.Text), textBoxIDPenjual.Text, textBoxJenisBarang.Text, textBoxNama.Text, int.Parse(textBoxStok.Text), int.Parse(textBoxHarga.Text), richTextBoxDeskripsi.Text);
                daftar.daftarBarang[idx]=b;
                daftar.UpdateDG(daftar.daftarBarang);
                MessageBox.Show("Data barang diubah.", "informasi");

            }
            catch (Exception ec)
            {
                MessageBox.Show("Data barang gagal diubah. Pesan Kesalahan: " + ec.Message, "kesalahan");
            }
        }
        int idx;
        private void textBoxIDBarang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                for (int i = 0; i < daftar.daftarBarang.Count; i++)
                {
                    if (daftar.daftarBarang[i].IdBarang.ToString().Equals(textBoxIDBarang.Text))
                    {
                        idx = i;
                    }
                }
                Barang b = daftar.daftarBarang[idx];
                textBoxHarga.Text = b.Harga + "";
                textBoxIDPenjual.Text = b.IdPenjual;
                textBoxJenisBarang.Text = b.JenisBarang;
                textBoxNama.Text = b.NamaBarang;
                richTextBoxDeskripsi.Text = b.Deskripsi;
                textBoxStok.Text = b.Stok + "";
                buttonUbah.Focus();
            }
        }

        private void FormUbahProduk_Load(object sender, EventArgs e)
        {
            daftar = (FormDaftarProduk)this.Owner;
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
