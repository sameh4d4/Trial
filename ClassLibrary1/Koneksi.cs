using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ClassLibrary1
{
    public class Koneksi
    {
        private MySqlConnection koneksiDB;

        public MySqlConnection KoneksiDB { get => koneksiDB; private set => koneksiDB = value; }

        #region METHODS

        public void Connect()
        {
            if (KoneksiDB.State == System.Data.ConnectionState.Open)
            {
                KoneksiDB.Close();
            }
            KoneksiDB.Open();
        }

        public void UpdateAppConfig(string con)
        {
            //buka konfigurasi app.config
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            //set app.config pada section namakoneksi yang telah dibuat sebelumnya sesuai parameter
            config.ConnectionStrings.ConnectionStrings["namakoneksi"].ConnectionString = con;

            //simpan app.config yang telah diupdate
            config.Save(ConfigurationSaveMode.Modified, true);

            //reload app.config dengan peraturan yang baru
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        public static void JalankanPerintahDML(string pSql)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            //Buat mysqlcommand
            MySqlCommand c = new MySqlCommand(pSql, k.KoneksiDB);

            //gunakan executenonquery untuk menjalankan perintah insert update delete
            c.ExecuteNonQuery();
        }

        public static MySqlDataReader JalankanPerintahQuery(string sql)
        {
            Koneksi k = new Koneksi();
            MySqlCommand c = new MySqlCommand(sql,k.KoneksiDB);
            //bentar
            MySqlDataReader hasil = c.ExecuteReader();
            return hasil;
        }


        public static string GetNamaServer()
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["namakoneksi"].ConnectionString;
            return con.DataSource;
        }

        public static string GetNamaDatabase()
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["namakoneksi"].ConnectionString;
            return con.Database;
        }

        #endregion

        #region CONSTRUCTORS

        public Koneksi()
        {
            koneksiDB = new MySqlConnection();

            //set connection string sesua app config
            koneksiDB.ConnectionString = ConfigurationManager.ConnectionStrings["namakoneksi"].ConnectionString;

            //panggil method connect
            Connect();
        }


        public Koneksi(string pServer, string pDatabase, string pUsername, string pPassword)
        {
            string strCon = "server=" + pServer + ";database=" + pDatabase + ";uid=" + pUsername + ";password=" + pPassword;
            //string strCon = "server=" + pServer + ";database=" + pDatabase + ";uid=" + pUsername + ";password=" + pPassword+";CharSet=utf8";
            KoneksiDB = new MySqlConnection();
            KoneksiDB.ConnectionString = strCon;
            Connect();
            UpdateAppConfig(strCon);
        }

        #endregion
    }
}
