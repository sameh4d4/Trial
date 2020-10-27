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
                User u = new User("al","admin");
                Barang b = new Barang(int.Parse(textBoxIDBarang.Text), /*textBoxIDPenjual.Text*/u, textBoxJenisBarang.Text, textBoxNama.Text,  int.Parse(textBoxStok.Text), int.Parse(textBoxHarga.Text), richTextBoxDeskripsi.Text);
                //Barang.TambahData(b);
                FormDaftarProduk own = (FormDaftarProduk)this.Owner;
                own.daftarBarang.Add(b);
                own.UpdateDG(own.daftarBarang);
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
