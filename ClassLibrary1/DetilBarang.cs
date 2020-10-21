using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class DetilBarang
    {
        private User user;
        private Barang barang;
        private int jumlah;
        private double subtotal;
        private string keterangan;

        public DetilBarang()
        {
            this.Jumlah = 0;
            this.Subtotal = 0;
            this.Keterangan = "";
        }

        public DetilBarang(User user, Barang barang, int jumlah, double subtotal, string keterangan)
        {
            this.User = user;
            this.Barang = barang;
            this.Jumlah = jumlah;
            this.Subtotal = subtotal;
            this.Keterangan = keterangan;
        }

        public User User { get => user; set => user = value; }
        public Barang Barang { get => barang; set => barang = value; }
        public int Jumlah { get => jumlah; set => jumlah = value; }
        public double Subtotal { get => subtotal; set => subtotal = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }
    }
}
