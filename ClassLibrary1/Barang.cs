using MySql.Data.MySqlClient;
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
        string jenisBarang;
        string namaBarang;
        int stok;
        double harga;
        string deskripsi;

        public Barang(int idBr, string jB, string nB, int st, double hrg, string des)
        {
            idBarang = idBr;
            jenisBarang = jB;
            namaBarang = nB;
            stok = st;
            harga = hrg;
            deskripsi = des;
        }

        public int IdBarang { get => idBarang; set => idBarang = value; }
        public string JenisBarang { get => jenisBarang; set => jenisBarang = value; }
        public string NamaBarang { get => namaBarang; set => namaBarang = value; }
        public int Stok { get => stok; set => stok = value; }
        public double Harga { get => harga; set => harga = value; }
        public string Deskripsi { get => deskripsi; set => deskripsi = value; }

        public static void TambahData(Barang b)
        {
            string sql = "insert into barang(idBarang,jenisBarang,namaBarang,stok,harga,deskripsi) values('" + b.idBarang + "','" + b.jenisBarang.Replace("'", "\\'") + "','" + b.namaBarang.Replace("'", "\\'") + "','" + b.stok + "','" + b.harga + "','" + b.deskripsi + "')";

            Koneksi.JalankanPerintahDML(sql);
        }

        public static void UbahData(Barang b)
        {
            string sql = "update barang set jenisBarang='" + b.jenisBarang.Replace("'", "\\'") + "',namaBarang='" + b.namaBarang.Replace("'", "\\'") + "',stok='" + b.stok + "',harga='" + b.harga + "',deskripsi='" + b.deskripsi + "'where idBarang='" + b.idBarang + "'";

            Koneksi.JalankanPerintahDML(sql);
        }

        public static void HapusData(Barang b)
        {
            string sql = "delete from barang where idBarang='" + b.idBarang + "'";
            Koneksi.JalankanPerintahDML(sql);
        }

        public static List<Barang> BacaData(string kriteria, string nilaiKriteria)
        {
            List<Barang> barangs = new List<Barang>();
            string sql = "";

            if (kriteria == "")
            {
                sql = "SELECT idbarang, jenisbarang, namabarang, stok, harga, deskripsi from barang ";
            }
            else
            {
                sql = "SELECT idbarang, jenisbarang, namabarang, stok, harga, deskripsi from barang where " + kriteria + " like '%" + nilaiKriteria + "%'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            while (hasil.Read() == true)
            {
                Barang b = new Barang(int.Parse(hasil.GetValue(0).ToString()), hasil.GetValue(1).ToString(), hasil.GetValue(2).ToString(), int.Parse(hasil.GetValue(3).ToString()), double.Parse(hasil.GetValue(4).ToString()), hasil.GetValue(5).ToString());
                barangs.Add(b);
            }
            hasil.Close();
            return barangs;
        }
    }
}
