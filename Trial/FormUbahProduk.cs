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

        private void buttonUbah_Click(object sender, EventArgs e)
        {
            try
            {

                Barang b = new Barang(int.Parse(textBoxIDBarang.Text), textBoxIDPenjual.Text, textBoxJenisBarang.Text, textBoxNama.Text, int.Parse(textBoxStok.Text), int.Parse(textBoxHarga.Text), richTextBoxDeskripsi.Text);
                Barang.UbahData(b);
                MessageBox.Show("Data barang diubah.", "informasi");

            }
            catch (Exception ec)
            {
                MessageBox.Show("Data barang gagal diubah. Pesan Kesalahan: " + ec.Message, "kesalahan");
            }
        }
    }
}
