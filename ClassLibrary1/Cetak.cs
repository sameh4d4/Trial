using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;

namespace ClassLibrary1
{
    public class Cetak
    {
        private Font jenisFont;
        private StreamReader fileCetak;
        private float marginKiri, marginKanan, marginAtas, marginBawah;
        private Bitmap bitmap;

        #region Constructor
        public Cetak(string namaFile, Font jenisFont, float marginKiri, float marginKanan,
                        float marginAtas, float marginBawah)
        {
            this.jenisFont = jenisFont;
            this.fileCetak = new StreamReader(namaFile);
            this.marginKiri = marginKiri;
            this.marginKanan = marginKanan;
            this.marginAtas = marginAtas;
            this.marginBawah = marginBawah;
        }
        #endregion

        #region Properties
        public Font JenisFont { get => jenisFont; set => jenisFont = value; }
        public StreamReader FileCetak { get => fileCetak; set => fileCetak = value; }
        public float MarginKiri { get => marginKiri; set => marginKiri = value; }
        public float MarginKanan { get => marginKanan; set => marginKanan = value; }
        public float MarginAtas { get => marginAtas; set => marginAtas = value; }
        public float MarginBawah { get => marginBawah; set => marginBawah = value; }
        public Bitmap Bitmap { get => bitmap; set => bitmap = value; }
        #endregion

        #region Methods
        private void CetakTulisan(object sender, PrintPageEventArgs e)
        {
            // hitung jml baris maks yg dpt ditampilkan pd 1 halaman kertas
            int jumlahBarisPerHalaman = (int)((e.MarginBounds.Height - MarginBawah - MarginAtas) / JenisFont.GetHeight(e.Graphics));
            // utk menyimpan posisi y terakhir tulisan yg telah tercetak
            float y = MarginAtas;
            // utk menyimpan jml baris tulisan yg telah tercetak
            int jumlahBaris = 0;

            // utk menyimpan tulisan yg akan dicetak
            string tulisanCetak = FileCetak.ReadLine();

            // baca filestream utk mencetak tiap baris tulisan
            while (jumlahBaris < jumlahBarisPerHalaman && tulisanCetak != null)
            {
                y = MarginAtas + (jumlahBaris * JenisFont.GetHeight(e.Graphics));

                // cetak tulisan sesuai jenis font dan margin (warna tulisan hitam)
                e.Graphics.DrawString(tulisanCetak, JenisFont, Brushes.Black, MarginKiri, y);

                // jml baris yg tercetak ditambah 1
                jumlahBaris++;

                // baca baris file berikutnya
                tulisanCetak = FileCetak.ReadLine();
            }

            // jika masih blm selesai mencetak, cetak di halaman berikutnya
            if (tulisanCetak != null)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
        }

        public void CetakKePrinter(string pTipe)
        {
            // buat object utk mencetak
            PrintDocument p = new PrintDocument();

            if (pTipe == "text")
            {
                // tambahkan event handler utk mencetak tulisan
                p.PrintPage += new PrintPageEventHandler(CetakTulisan);
            }

            // cetak tulisan
            p.Print();

            FileCetak.Close();
        }
        #endregion
    }
}
