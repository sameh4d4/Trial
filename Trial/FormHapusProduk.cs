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
        public FormHapusProduk()
        {
            InitializeComponent();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            try
            {

                Barang b = new Barang(int.Parse(textBoxIDBarang.Text), textBoxIDPenjual.Text, textBoxJenisBarang.Text, textBoxNama.Text, int.Parse(textBoxStok.Text), int.Parse(textBoxHarga.Text), richTextBoxDeskripsi.Text);
                Barang.HapusData(b);
                MessageBox.Show("Data barang dihapus.", "informasi");

            }
            catch (Exception ec)
            {
                MessageBox.Show("Data barang gagal dihapus. Pesan Kesalahan: " + ec.Message, "kesalahan");
            }
        }
    }
}
