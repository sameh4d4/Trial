using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trial
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string id = textBoxUid.Text;
                string pass = textBoxPwd.Text;

                Koneksi k = new Koneksi("localhost", "dbmtt", "root", "");
                //nah disini cek username pass yang diinput ntar
                //mau buat meth di class Koneksi juga gpp,meth buat cek userpass kek di pweb lul
                //imi aku ambil alih dulu
                List<User> lu = User.BacaData("","");
                bool cekUser = false;
                string passdb = "";
                foreach(User pengguna in lu)
                {
                    if(pengguna.Username==id)
                    {
                        cekUser = true;
                        passdb = pengguna.Password;
                        break;
                    }
                }
                if (cekUser == true)
                {
                    if (passdb == pass)
                    {
                        //ok lanjut aku nda tau
                        MessageBox.Show("berhasil login");
                        FormUtama formUtama = (FormUtama)this.Owner;
                        formUtama.Enabled = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("anda pembobol coba lagi!");
                    }
                }
                else
                {
                    MessageBox.Show("anda siapa?");
                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //dah bert ku tinggal bentar
        }
    }
}
