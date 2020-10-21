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
        User user;
        string jenisBarang;
        string namaBarang;
        int stok;
        double harga;
        string deskripsi;

        public Barang(int idBr, User pUser, string jB, string nB, int st, double hrg, string des)
        {
            idBarang = idBr;
            user = pUser;
            jenisBarang = jB;
            namaBarang = nB;
            stok = st;
            harga = hrg;
            deskripsi = des;
        }

        public int IdBarang { get => idBarang; set => idBarang = value; }
        public User User { get => user; set => user = value; }
        public string JenisBarang { get => jenisBarang; set => jenisBarang = value; }
        public string NamaBarang { get => namaBarang; set => namaBarang = value; }
        public int Stok { get => stok; set => stok = value; }
        public double Harga { get => harga; set => harga = value; }
        public string Deskripsi { get => deskripsi; set => deskripsi = value; }

        public static void TambahData(Barang b)
        {
            string sql = "insert into barang(idBarang,idPenjual,jenisBarang,namaBarang,stok,harga,deskripsi) values('" + b.idBarang + "','" + b.user + "','" + b.jenisBarang.Replace("'", "\\'") + "','" + b.namaBarang.Replace("'", "\\'") + "','" + b.stok + "','" + b.harga + "','" + b.deskripsi + "')";

            Koneksi.JalankanPerintahDML(sql);
        }

        public static void UbahData(Barang b)
        {
            string sql = "update barang set idPenjual='" + b.user + "',jenisBarang='" + b.jenisBarang.Replace("'", "\\'") + "',namaBarang='" + b.namaBarang.Replace("'", "\\'") + "',stok='" + b.stok + "',harga='" + b.harga + "',deskripsi='" + b.deskripsi + "'where idBarang='" + b.idBarang + "'";

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
                sql = "SELECT b.idbarang, u.name, b.jenisbarang, b.namabarang, b.stok, b.harga, b.deskripsi from barang " +
                    "b inner join user u on b.idpenjual=u.id";
            }
            else
            {
                sql = "SELECT b.idbarang, u.name, b.jenisbarang, b.namabarang, b.stok, b.harga, b.deskripsi from barang " +
                    "b inner join user u on b.idpenjual=u.id where " + kriteria + " like '%" + nilaiKriteria + "%'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            while (hasil.Read() == true)
            {
                User u = User.BacaData("name", hasil.GetValue(1).ToString())[0];
                Barang b = new Barang(int.Parse(hasil.GetValue(0).ToString()), u, hasil.GetValue(2).ToString(), hasil.GetValue(3).ToString(), int.Parse(hasil.GetValue(4).ToString()), int.Parse(hasil.GetValue(5).ToString()), hasil.GetValue(6).ToString());
                barangs.Add(b);
            }
            hasil.Close();
            return barangs;
        }
    }
}
