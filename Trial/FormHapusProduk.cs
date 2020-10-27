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
    public partial class FormHapusProduk : Form
    {
        FormDaftarProduk daftar;
        public FormHapusProduk()
        {
            InitializeComponent();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            try
            {

                Barang b = daftar.daftarBarang[idx];
                daftar.daftarBarang.Remove(b);
                daftar.UpdateDG(daftar.daftarBarang);
                MessageBox.Show("Data barang dihapus.", "informasi");

            }
            catch (Exception ec)
            {
                MessageBox.Show("Data barang gagal dihapus. Pesan Kesalahan: " + ec.Message, "kesalahan");
            }
        }
        
        int idx = 0;
        private void textBoxIDBarang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                for(int i = 0; i < daftar.daftarBarang.Count; i++)
                {
                    if (daftar.daftarBarang[i].IdBarang.ToString().Equals(textBoxIDBarang.Text))
                    {
                        idx = i;
                    }
                }
                Barang b= daftar.daftarBarang[idx];
                textBoxHarga.Text = b.Harga + "";
              
                textBoxJenisBarang.Text = b.JenisBarang;
                textBoxNama.Text = b.NamaBarang;
                textBoxStok.Text = b.Stok + "";
                richTextBoxDeskripsi.Text = b.Deskripsi;
                buttonHapus.Focus();
            }
        }

        private void FormHapusProduk_Load(object sender, EventArgs e)
        {
            daftar = (FormDaftarProduk)this.Owner;
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
