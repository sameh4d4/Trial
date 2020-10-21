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
    public partial class FormLaporanPenjualan : Form
    {
        public FormLaporanPenjualan()
        {
            InitializeComponent();
        }

        public List<Transaksi> listTransaksi = new List<Transaksi>();


        private void buttonCari_Click(object sender, EventArgs e)
        {

        }

        private void FormatDataGrid()
        {
            dataGridViewLaporan.Columns.Clear();

            dataGridViewLaporan.Columns.Add("NoNota", "No Nota");
            dataGridViewLaporan.Columns.Add("Tanggal", "Tanggal");
            dataGridViewLaporan.Columns.Add("Total", "Total");
            dataGridViewLaporan.Columns.Add("PPN", "PPN");
            dataGridViewLaporan.Columns.Add("GrandTotal", "Grand Total");

            dataGridViewLaporan.Columns["NoNota"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewLaporan.Columns["Tanggal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewLaporan.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewLaporan.Columns["PPN"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewLaporan.Columns["GrandTotal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewLaporan.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewLaporan.Columns["PPN"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewLaporan.Columns["GrandTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridViewLaporan.Columns["Total"].DefaultCellStyle.Format = "#,###";
            dataGridViewLaporan.Columns["PPN"].DefaultCellStyle.Format = "#,###";
            dataGridViewLaporan.Columns["GrandTotal"].DefaultCellStyle.Format = "#,###";

            dataGridViewLaporan.AllowUserToAddRows = false;
            dataGridViewLaporan.ReadOnly = true;
        }
        private void TampilDataGrid()
        {
            dataGridViewLaporan.Rows.Clear();
            if (listTransaksi.Count > 0)
            {
                foreach (Transaksi t in listTransaksi)
                {
                    dataGridViewLaporan.Rows.Add(t.NoNota, t.Tanggal.ToString("dd/MM/yyyy"), t.Total, t.Ppn, t.GrandTotal);
                }
            }
            else
            {
                dataGridViewLaporan.DataSource = null;
            }
        }

        private void buttonCetak_Click(object sender, EventArgs e)
        {
            try
            {
                Transaksi.CetakLaporan(dateTimePickerStart.Value,
                    dateTimePickerEnd.Value, "laporan.txt", new Font("Courier New", 11));
                MessageBox.Show("Laporan telah tercetak");
            }
            catch (NullReferenceException exNull)
            {
                FormLaporanPenjualan_Load(this, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Laporan gagal dicetak. Pesan kesalahan: " + ex.Message);
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {

        }

        private void FormLaporanPenjualan_Load(object sender, EventArgs e)
        {
            try
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.Dock = DockStyle.Fill;

                listTransaksi = Transaksi.BacaData("", "");
                FormatDataGrid();
                TampilDataGrid();
            }
            catch (NullReferenceException exNull)
            {
                FormLaporanPenjualan_Load(this, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pesan kesalahan: " + ex.Message);
            }
        }
    }
}
