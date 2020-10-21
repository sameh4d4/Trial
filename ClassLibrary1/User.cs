using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ClassLibrary1
{
    public class User
    {
        private int id;
        private string username;
        private string password;
        private string role;
        private string name;

        public User(int id, string username, string password, string role, string name)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.Role = role;
            this.Name = name;
        }

        public User(string username, string role)
        {
            this.Id = id;
            this.Username = username;
            this.Role = role;
        }

        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Role { get => role; set => role = value; }
        public string Name { get => name; set => name = value; }

        public static void BuatUserBaru(User user, string namaServer)
        {
            using (TransactionScope transcope = new TransactionScope())
            {
                try
                {
                    string sql = "create user '" + user.Username + "'@'" + namaServer + "' identified by '" +
                    user.Password + "'";
                    Koneksi.JalankanPerintahDML(sql);
                    transcope.Complete();
                }
                catch (Exception ex)
                {
                    transcope.Dispose();
                    throw new Exception(ex.Message);
                }
            }
        }

        public static void BeriHakAkses(User user, string namaServer, string namaDatabase)
        {
            using (TransactionScope transcope = new TransactionScope())
            {
                try
                {
                    string sql = "grant all privileges on " + namaDatabase + ".* to '" + user.Username +
                    "'@'" + namaServer + "'";
                    Koneksi.JalankanPerintahDML(sql);
                    transcope.Complete();
                }
                catch (Exception ex)
                {
                    transcope.Dispose();
                    throw new Exception(ex.Message);
                }
            }
        }

        public static void ManajemenUser(User u)
        {
            string namaServer = Koneksi.GetNamaServer();
            string namaDatabase = Koneksi.GetNamaDatabase();

            User.BuatUserBaru(u, namaServer);
            User.BeriHakAkses(u, namaServer, namaDatabase);
        }

        public static List<User> BacaData(string pUsername, string nilaiKriteria)
        {
            string sql = "";

            if (pUsername == "")
            {
                sql = "SELECT * from user";
            }
            else
            {
                sql = "SELECT * from user where " + pUsername + " like '%" + nilaiKriteria + "%'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<User> listUser = new List<User>();
            while (hasil.Read() == true)
            {
                User u = new User(int.Parse(hasil.GetValue(0).ToString()), hasil.GetValue(1).ToString(), hasil.GetValue(2).ToString(),
                    hasil.GetValue(3).ToString(), hasil.GetValue(4).ToString());
                listUser.Add(u);
            }
            return listUser;
        }
        public static bool cekUser(string username)
        {
            List<User> users = new List<User>();
            users = BacaData("username", username);
            bool duplikat = false;
            if (users.Count() > 0)
                duplikat = true;

            return duplikat;
        }
        public static int getRegisterId()
        {
            List<User> users = new List<User>();
            users = BacaData("username", "");
            return users.Count() + 1;
        }
    }
}
