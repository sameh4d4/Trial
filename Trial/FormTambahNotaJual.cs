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
    public partial class FormTambahNotaJual : Form
    {

        #region meth Custom
        void FormatDG()
        {
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("IdBarang", "Id");
            dataGridView1.Columns.Add("NamaBarang", "Nama");
            dataGridView1.Columns.Add("HargaJual", "Harga");
            dataGridView1.Columns.Add("Jumlah", "Jumlah");
            dataGridView1.Columns.Add("Keterangan", "Keterangan");
            dataGridView1.Columns.Add("SubTotal", "SubTotal");

            dataGridView1.Columns["SubTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["SubTotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["IdBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["NamaBarang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["HargaJual"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["Jumlah"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["Keterangan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridView1.Columns["HargaJual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Jumlah"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridView1.Columns["HargaJual"].DefaultCellStyle.Format = "#,###";

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
        }
        int HitungTotal()
        {
            int tot = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                tot += int.Parse(dataGridView1.Rows[i].Cells["SubTotal"].Value.ToString());
            }
            return tot;
        }
        int HitungGrandTotal()
        {
            int grand = 0;
            grand = (int)(HitungTotal() + (HitungTotal() * 0.1));
            return grand;
        }

        #endregion

        public FormTambahNotaJual()
        {
            InitializeComponent();
        }
        FormUtama ut=null;
        User pegawai;
        private void FormTambahNotaJual_Load(object sender, EventArgs e)
        {
            ut = (FormUtama)this.MdiParent;
            FormatDG();
            textBoxNoNota.Text = Transaksi.GenerateNoNota();
            textBoxKet.Text = "-";
            textBoxId.Focus();
            labelKodePegawai.Text = ut.u.Id.ToString();
            labelNamaPegawai.Text = ut.u.Name;
            pegawai = ut.u;
            dateTimePickerTglNota.Value = DateTime.Now;
        }

        private void textBoxJumlah_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                int stok = Barang.BacaData("idbarang", textBoxId.Text)[0].Stok;
                if (stok > int.Parse(textBoxJumlah.Text))
                {
                    bool cek = false;
                    int index = 0;
                    int subTotal = int.Parse(labelHarga.Text) * int.Parse(textBoxJumlah.Text);
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        string asd = dataGridView1.Rows[i].Cells["IdBarang"].Value.ToString();
                        if (textBoxId.Text == asd && dataGridView1.Rows[i].Cells["Keterangan"].Value.ToString() == textBoxKet.Text)
                        {
                            cek = true;
                            index = i;
                        }
                    }
                    if (!cek)
                    {
                        dataGridView1.Rows.Add(textBoxId.Text, labelNamaBarang.Text, labelHarga.Text, textBoxJumlah.Text, textBoxKet.Text, subTotal);
                    }
                    else
                    {
                        int jumlah = int.Parse(textBoxJumlah.Text) + int.Parse(dataGridView1.Rows[index].Cells["Jumlah"].Value.ToString());
                        subTotal += int.Parse(dataGridView1.Rows[index].Cells["SubTotal"].Value.ToString());
                        dataGridView1.Rows[index].Cells["SubTotal"].Value = subTotal;
                        dataGridView1.Rows[index].Cells["Jumlah"].Value = jumlah;
                    }
                    //labelGrandTotal.Text = HitungGrandTotal().ToString("#,###");
                    textBoxKet.Text = "-";
                    textBoxId.Text = "";
                    labelNamaBarang.Text = "";
                    labelHarga.Text = "";
                    textBoxJumlah.Text = "";
                    textBoxId.Focus();
                }
                else
                {
                    MessageBox.Show("Stok tidak mencukupi");
                    textBoxJumlah.Clear();
                    textBoxJumlah.Focus();
                }
            }
        }

        private void textBoxKet_KeyDown(object sender, KeyEventArgs e)
        {
            textBoxJumlah_KeyDown(textBoxKet, e);
        }

        private void textBoxId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                List<Barang> li = Barang.BacaData("idbarang", int.Parse(textBoxId.Text).ToString());
                if (li.Count > 0)
                {
                    labelNamaBarang.Text = li[0].NamaBarang;
                    labelHarga.Text = li[0].Harga.ToString();
                    textBoxJumlah.Focus();
                }
                else
                {
                    MessageBox.Show("Item tidak ditemukan", "informasi");
                    textBoxId.Clear();
                    textBoxId.Focus();
                }
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {

            //teeeessss
            try
            {
                Transaksi notaJual = new Transaksi(textBoxNoNota.Text, dateTimePickerTglNota.Value, (double)HitungTotal(), 0.1, double.Parse(labelGrandTotal.Text));
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string kodebar = dataGridView1.Rows[i].Cells["IdBarang"].Value.ToString();
                    List<Barang> b = Barang.BacaData("idbarang", kodebar);
                    int harga, jumlah;
                    harga = int.Parse(dataGridView1.Rows[i].Cells["HargaJual"].Value.ToString());
                    jumlah = int.Parse(dataGridView1.Rows[i].Cells["Jumlah"].Value.ToString());
                    notaJual.TambahDetailBarang(b[0],notaJual,jumlah,(harga*jumlah), dataGridView1.Rows[i].Cells["Keterangan"].Value.ToString(),pegawai);

                }
                Transaksi.TambahData(notaJual);
                //FormDaftarNotaJual fdnj = (FormDaftarNotaJual)this.Owner;
                //fdnj.FormDaftarNotaJual_Load(buttonSimpan, e);
                MessageBox.Show("Input nota berhasil", "Informasi");
                //saved = true;
                textBoxKet.Text = "-";
                textBoxNoNota.Text = Transaksi.GenerateNoNota();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Input nota gagal, pesan kesalahan: " + ex.Message, "Kesalahan");
            }
        }
    }
}
