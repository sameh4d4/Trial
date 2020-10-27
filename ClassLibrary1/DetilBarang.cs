using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class DetilBarang
    {
        private Barang barang;
        private Transaksi noNota;
        private int jumlah;
        private double subtotal;
        private string keterangan;
        private User kasir;

        public DetilBarang()
        {
            this.Jumlah = 0;
            this.Subtotal = 0;
            this.Keterangan = "";
        }

        public DetilBarang(Barang barang, Transaksi noNota, int jumlah, double subtotal, string keterangan, User kasir)
        {
            this.Barang = barang;
            this.NoNota = noNota;
            this.Jumlah = jumlah;
            this.Subtotal = subtotal;
            this.Keterangan = keterangan;
            this.Kasir = kasir;
        }

        public Barang Barang { get => barang; set => barang = value; }
        public Transaksi NoNota { get => noNota; set => noNota = value; }
        public int Jumlah { get => jumlah; set => jumlah = value; }
        public double Subtotal { get => subtotal; set => subtotal = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }
        public User Kasir { get => kasir; set => kasir = value; }
    }
}
