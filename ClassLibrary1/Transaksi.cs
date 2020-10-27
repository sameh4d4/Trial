using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Transactions;
using System.IO;
using System.Drawing;

namespace ClassLibrary1
{
    public class Transaksi
    {
        private string noNota;
        private DateTime tanggal;
        private double total;
        private double ppn;
        private double grandTotal;
        private List<DetilBarang> listDetilBarang;

        public Transaksi(string noNota, DateTime tanggal, double total, double ppn, double grandTotal, List<DetilBarang> listDetilBarang)
        {
            this.noNota = noNota;
            this.tanggal = tanggal;
            this.total = total;
            this.ppn = ppn;
            this.grandTotal = grandTotal;
            this.listDetilBarang = listDetilBarang;
        }

        public Transaksi(string noNota, DateTime tanggal, double total, double ppn, double grandTotal)
        {
            this.noNota = noNota;
            this.tanggal = tanggal;
            this.total = total;
            this.ppn = ppn;
            this.grandTotal = grandTotal;
            this.listDetilBarang = new List<DetilBarang>();
        }


        public string NoNota { get => noNota; set => noNota = value; }
        public DateTime Tanggal { get => tanggal; set => tanggal = value; }
        public double Total { get => total; set => total = value; }
        public double Ppn { get => ppn; set => ppn = value; }
        public double GrandTotal { get => grandTotal; set => grandTotal = value; }
        public List<DetilBarang> ListDetilBarang { get => listDetilBarang; set => listDetilBarang = value; }

        public static string GenerateNoNota()
        {
            string sql = "select RIGHT(nonota, 3) as NoUrutTransaksi from transaksi " +
                            "where Date(tanggal) = Date(CURRENT_DATE) " +
                            "order by tanggal DESC limit 1";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            string hasilNoNota = "";
            if (hasil.Read() == true)
            {
                if (hasil.GetValue(0).ToString() != "")
                {
                    int noUrutTrans = int.Parse(hasil.GetValue(0).ToString()) + 1;
                    hasilNoNota = DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0') +
                                    DateTime.Now.Day.ToString().PadLeft(2, '0') +
                                    noUrutTrans.ToString().PadLeft(3, '0');
                }
                else
                {
                    hasilNoNota = DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0') +
                                        DateTime.Now.Day.ToString().PadLeft(2, '0') + "001";
                }
            }

            return hasilNoNota;
        }

        public void TambahDetailBarang(Barang barang, Transaksi noNota, int jumlah, double subtotal, string keterangan, User kasir)
        {
            DetilBarang detilBarang = new DetilBarang(barang, noNota, jumlah, subtotal, keterangan, kasir);
            ListDetilBarang.Add(detilBarang);
        }

        public void TambahDetailBarang(DetilBarang detilBarang)
        {
            ListDetilBarang.Add(detilBarang);
        }

        public static void TambahData(Transaksi transaksi)
        {
            using (TransactionScope transcope = new TransactionScope())
            {
                try
                {
                    string sql1 = "insert into transaksi(noNota, tanggal, total, PPN, grandtotal) values ('" +
                            transaksi.NoNota + "','" + transaksi.Tanggal.ToString("yyyy-MM-dd hh:mm:ss") + "','" +
                            transaksi.Total + "','" + transaksi.Ppn + "','" + transaksi.GrandTotal + "')";

                    Koneksi.JalankanPerintahDML(sql1);

                    foreach (DetilBarang detilBarang in transaksi.listDetilBarang)
                    {
                        string sql2 = "insert into detilbarang(idBarang, noNota, jumlah, subtotal, keterangan, kasir_id) values('" +
                            detilBarang.Barang.IdBarang + "','" +
                            detilBarang.NoNota + "','" +
                            detilBarang.Jumlah + "','" + detilBarang.Subtotal + "','" +
                            detilBarang.Keterangan + "','" + 
                            detilBarang.Kasir + "')";

                        Koneksi.JalankanPerintahDML(sql2);
                    }

                    transcope.Complete();
                }
                catch (Exception ex)
                {
                    transcope.Dispose();
                    throw new Exception(ex.Message);
                }
            }
        }

        public static List<Transaksi> BacaData(string pKriteria, string pNilaiKriteria)
        {
            List<Transaksi> transaksis = new List<Transaksi>();
            string sql1 = "";

            if (pKriteria == "")
            {
                sql1 = "select * from transaksi";
            }
            else
            {
                sql1 = "select * from transaksi where " + pKriteria + " like '%" + pNilaiKriteria + "%'";
            }

            MySqlDataReader hasil1 = Koneksi.JalankanPerintahQuery(sql1);
            while (hasil1.Read() == true)
            {
                string noNota = hasil1.GetValue(0).ToString();
                DateTime tgl = hasil1.GetDateTime(1);
                double total = double.Parse(hasil1.GetValue(2).ToString());
                double ppn = double.Parse(hasil1.GetValue(3).ToString());
                double grandTotal = double.Parse(hasil1.GetValue(4).ToString());

                List<DetilBarang> listDetil = new List<DetilBarang>();
                string sql2 = "select * from detilbarang where noNota='" + noNota + "'";
                Transaksi transaksi = new Transaksi(noNota, tgl, total, ppn, grandTotal);
                MySqlDataReader hasil2 = Koneksi.JalankanPerintahQuery(sql2);
                while (hasil2.Read() == true)
                {
                    Barang b = Barang.BacaData("idBarang", hasil2.GetValue(0).ToString())[0];
                    //Transaksi nota = BacaData("noNota", hasil2.GetValue(1).ToString())[0];
                    int jumlah = int.Parse(hasil2.GetValue(2).ToString());
                    double subTotal = double.Parse(hasil2.GetValue(3).ToString());
                    string keterangan = hasil2.GetValue(4).ToString();
                    User kasir = User.BacaData("id", hasil2.GetValue(5).ToString())[0];

                    transaksi.TambahDetailBarang(b, transaksi, jumlah, subTotal, keterangan, kasir);
                    DetilBarang detil = new DetilBarang(b, transaksi, jumlah, subTotal, keterangan, kasir);
                    listDetil.Add(detil);
                }
                Transaksi t = new Transaksi(noNota, tgl, total, ppn, grandTotal, listDetil);
                transaksis.Add(t);
            }
            return transaksis;
        }

        public static List<Transaksi> BacaDataLaporan(DateTime tglAwal, DateTime tglAkhir)
        {
            
            string sql1 = "";
            if (tglAwal.Date != tglAkhir.Date)
            {
                sql1 = "SELECT t.noNota, t.tanggal, t.total, t.ppn, t.grandTotal " +
                    "FROM transaksi t WHERE Date(tanggal) between '" + tglAwal.ToString("yyyy-MM-dd") + "' and '" +
                    tglAkhir.ToString("yyyy-MM-dd") + "'" +
                    " ORDER BY t.noNota DESC";
            }
            else
            {
                sql1 = "SELECT t.noNota, t.tanggal, t.total, t.ppn, t.grandTotal " +
                    "FROM transaksi t WHERE Date(tanggal)='" + tglAwal.ToString("yyyy-MM-dd") + "'" +
                    " ORDER BY t.noNota DESC";
            }

            MySqlDataReader hasilData1 = Koneksi.JalankanPerintahQuery(sql1);
            List<Transaksi> listHasilData = new List<Transaksi>();
            while (hasilData1.Read() == true)
            {
                string nomorNota = hasilData1.GetValue(0).ToString();
                DateTime tglNota = DateTime.Parse(hasilData1.GetValue(1).ToString());

                Transaksi transaksi = new Transaksi(nomorNota, tglNota, double.Parse(hasilData1.GetValue(2).ToString()),
                    double.Parse(hasilData1.GetValue(3).ToString()), double.Parse(hasilData1.GetValue(4).ToString()));

                string sql2 = "SELECT b.idBarang, dt.noNota, dt.jumlah, dt.subTotal, dt.keterangan, k.id " +
                              "FROM detilbarang dt inner join transaksi t on t.noNota=dt.noNota " +
                              "INNER join user k ON dt.kasir_id=k.id " +
                              "INNER JOIN barang b on b.idBarang=dt.idBarang " +
                              "WHERE t.noNota='" + nomorNota + "'";
                MySqlDataReader hasilData2 = Koneksi.JalankanPerintahQuery(sql2);

                while (hasilData2.Read() == true)
                {
                    List<Barang> listBarang = Barang.BacaData("idbarang", hasilData2.GetValue(0).ToString());
                    List<User> listKasir = User.BacaData("id", hasilData2.GetValue(5).ToString());
                    List<Transaksi> listTransaksi = Transaksi.BacaData("noNota", hasilData2.GetValue(1).ToString());

                    transaksi.TambahDetailBarang(listBarang[0], listTransaksi[0], int.Parse(hasilData2.GetValue(2).ToString()),
                        double.Parse(hasilData2.GetValue(3).ToString()), hasilData2.GetValue(4).ToString(), listKasir[0]);
                }
                listHasilData.Add(transaksi);
                hasilData2.Close();
            }
            hasilData1.Close();
            return listHasilData;
        }

        public static void CetakNotaBayar(string pKriteria, string pNilaiKriteria, string pNamaFile, Font pFont)
        {
            List<Transaksi> listTransaksi = new List<Transaksi>();
            listTransaksi = Transaksi.BacaData(pKriteria, pNilaiKriteria);

            // simpan dulu isi nota yg akan ditampilkan ke object file (Stream Writer)
            StreamWriter file = new StreamWriter(pNamaFile);

            foreach (Transaksi nota in listTransaksi)
            {
                // tampilkan info perusahaan
                file.WriteLine("");
                file.WriteLine("TOKOPEDIO");
                file.WriteLine("Jl. Ambyar");
                file.WriteLine("Telp. (031) - 12345678");
                file.WriteLine("=".PadRight(50, '='));

                // tampilkan header nota
                file.WriteLine("No. Nota  : " + nota.NoNota);
                file.WriteLine("Tanggal   : " + nota.Tanggal);
                file.WriteLine("");
                file.WriteLine("=".PadRight(50, '='));

                // tampilkan brg yg terjual
                double grandTotal = nota.GrandTotal;
                double total = nota.Total;
                double ppn = nota.Ppn;
                foreach (DetilBarang db in nota.ListDetilBarang)
                {
                    string namaKasir = db.Kasir.Name;
                    string namaBarang = db.Barang.NamaBarang;
                    string deskripsiBarang = db.Barang.Deskripsi;
                    // jika nama terlalu panjang maka tampilkan 30 karakter pertama saja
                    if (namaKasir.Length > 30)
                    {
                        namaKasir = namaKasir.Substring(0, 30);
                    }
                    if (namaBarang.Length > 30)
                    {
                        namaBarang = namaBarang.Substring(0, 30);
                    }
                    if (deskripsiBarang.Length > 30)
                    {
                        deskripsiBarang = deskripsiBarang.Substring(0, 30);
                    }
                    int jumlah = db.Jumlah;
                    double subtotal = db.Subtotal;
                    double harga = db.Barang.Harga;

                    file.Write(namaKasir.PadRight(30, ' '));
                    file.Write(namaBarang.PadRight(30, ' '));
                    file.Write(jumlah.ToString().PadRight(3, ' '));
                    file.Write(harga.ToString("#,###").PadLeft(7, ' '));
                    file.Write(subtotal.ToString("#,###").PadLeft(10, ' '));
                    file.WriteLine("");
                }
                file.WriteLine("=".PadRight(50, '='));
                file.WriteLine("Total      : " + total.ToString("#,###"));
                file.WriteLine("PPN        : " + ppn.ToString("#,###") + " %");
                file.WriteLine("GRAND TOTAL: " + grandTotal.ToString("#,###"));
                file.WriteLine("=".PadRight(50, '='));
                file.WriteLine("Terima kasih atas kunjungan Anda");
                file.WriteLine("");
            }
            file.Close();
            // cetak ke printer
            Cetak c = new Cetak(pNamaFile, pFont, 20, 10, 10, 10);
            c.CetakKePrinter("text");
        }

        public static void CetakLaporan(DateTime tglAwal, DateTime tglAkhir, string pNamaFile, Font pFont)
        {
            List<Transaksi> listTransaksi = new List<Transaksi>();
            listTransaksi = Transaksi.BacaDataLaporan(tglAwal, tglAkhir);

            StreamWriter file = new StreamWriter(pNamaFile);
            file.WriteLine("");
            file.WriteLine("TOKOPEDIO");
            file.WriteLine("LAPORAN PENJUALAN");
            file.WriteLine("Periode " + tglAwal.ToString("dd-MM-yyyy") + " - " + tglAkhir.ToString("dd-MM-yyyy"));
            file.WriteLine("");

            file.WriteLine("-".PadRight(86, '-'));
            file.WriteLine("Nomor Nota".PadLeft(12, ' ') + " " +
                    "Tanggal".PadLeft(12, ' ') + " " +
                    "Total".PadLeft(9, ' ') + " " +
                    "PPN".PadLeft(8, ' ') + "  " +
                    "GrandTotal".PadLeft(11, ' '));
            file.WriteLine("-".PadRight(86, '-'));

            double total_Total = 0;
            double total_PPN = 0;
            double total_GrandTotal = 0;

            foreach (Transaksi nota in listTransaksi)
            {
                file.WriteLine(nota.NoNota.ToString().PadLeft(12, ' ') + " " +
                    nota.Tanggal.ToString("dd/MM/yyyy").PadLeft(12, ' ') + " " +
                    nota.Total.ToString("#,###").PadLeft(9, ' ') + " " +
                    nota.Ppn.ToString("#,###").PadLeft(8, ' ') + "%  " +
                    nota.GrandTotal.ToString("#,###").PadLeft(11, ' '));

                total_Total += nota.Total;
                total_PPN += nota.Ppn;
                total_GrandTotal += nota.GrandTotal;
            }
            file.WriteLine("-".PadRight(86, '-'));
            file.WriteLine("TOTAL:".PadLeft(53, ' ') + " " +
                total_Total.ToString("#,###").PadLeft(9, ' ') + " " +
                total_PPN.ToString("#,###").PadLeft(8, ' ') + "%  " +
                total_GrandTotal.ToString("#,###").PadLeft(11, ' '));
            file.WriteLine("-".PadRight(86, '-'));
            file.Close();

            Cetak c = new Cetak(pNamaFile, pFont, 20, 10, 10, 10);
            c.CetakKePrinter("text");
        }
    }
}
