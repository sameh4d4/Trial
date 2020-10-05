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
    public partial class FormTambahProduk : Form
    {
        public FormTambahProduk()
        {
            InitializeComponent();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                
               Barang b = new Barang(int.Parse(textBoxIDBarang.Text), int.Parse(textBoxIDPenjual.Text), textBoxJenisBarang.Text, textBoxNama.Text,  int.Parse(textBoxStok.Text), int.Parse(textBoxHarga.Text), richTextBoxDeskripsi.Text);
               Barang.TambahData(b);
               MessageBox.Show("Data barang ditambahkan.", "informasi");

            }
            catch (Exception ec)
            {
                MessageBox.Show("Data barang gagal ditambahkan. Pesan Kesalahan: " + ec.Message, "kesalahan");
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
