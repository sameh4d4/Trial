using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Barang
    {
        int idBarang;
        int idPenjual;
        string jenisBarang;
        string namaBarang;
        int stok;
        double harga;
        string deskripsi;

        public Barang(int idBr, int idPj, string jB, string nB, int st, double hrg, string des)
        {
            idBarang = idBr;
            idPenjual = idPj;
            jenisBarang = jB;
            namaBarang = nB;
            stok = st;
            harga = hrg;
            deskripsi = des;
        }

        public int IdBarang { get => idBarang; set => idBarang = value; }
        public int IdPenjual { get => idPenjual; set => idPenjual = value; }
        public string JenisBarang { get => jenisBarang; set => jenisBarang = value; }
        public string NamaBarang { get => namaBarang; set => namaBarang = value; }
        public int Stok { get => stok; set => stok = value; }
        public double Harga { get => harga; set => harga = value; }
        public string Deskripsi { get => deskripsi; set => deskripsi = value; }

        public static void TambahData(Barang b)
        {
            string sql = "insert into barang(idBarang,idPenjual,jenisBarang,namaBarang,stok,harga,deskripsi) values('" + b.idBarang + "','" + b.idPenjual + "','" + b.jenisBarang.Replace("'", "\\'") + "','" + b.namaBarang.Replace("'", "\\'") + "','" + b.stok + "','" + b.harga + "','" + b.deskripsi + "')";

            Koneksi.JalankanPerintahDML(sql);

        }
    }
}
