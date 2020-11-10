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
                List<User> lii = User.BacaData("username", id);
                bool passOK = false;
                if (lii.Count > 0)
                {
                    User sss = null;
                    foreach(User u in lii)
                    {
                        if (u.Password == pass)
                        {
                            passOK = true;
                            sss = u;
                            break;
                        }
                    }
                    if (passOK)
                    {
                        MessageBox.Show("berhasil login", "information");
                        FormUtama formUtama = (FormUtama)this.Owner;
                        formUtama.u = sss;
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

                /*List<User> lu = User.BacaData("","");
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
                }*/
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBoxUid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(textBoxUid, e);
            }
        }

        private void textBoxPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(textBoxPwd, e);
            }
        }
    }
}
