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
    public partial class FormDaftarPegawai : Form
    {
        public FormDaftarPegawai()
        {
            InitializeComponent();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahPegawai frm = new FormTambahPegawai();
            frm.Owner = this;
            frm.Show();
        }
        List<User> pegawai = new List<User>();
        private void FormDaftarPegawai_Load(object sender, EventArgs e)
        {
            pegawai= User.BacaData("", "");
            UpdateDG(pegawai); 
        }

        public void UpdateDG(List<User> i)
        {
            dataGridView1.Columns.Clear();
            if (i.Count > 0)
            {
                dataGridView1.Columns.Add("IdPegawai", "ID Pegawai");

                dataGridView1.Columns.Add("Nama", "Nama");
                
              
                TampilDG(i);
                for (int a = 0; a < dataGridView1.Columns.Count; a++)
                {
                    if (dataGridView1.Columns[a].Name == "Id")
                    {
                        dataGridView1.Columns[a].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                    else
                    {
                        dataGridView1.Columns[a].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                       
                    }
                }
                
            }
            else
            {
                dataGridView1.Columns.Add("noData", "Tidak ada data");
                dataGridView1.Columns["noData"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dataGridView1.AllowUserToAddRows = false;
        }
        public void TampilDG(List<User> i)
        {
            foreach (User u in i)
            {
                dataGridView1.Rows.Add(u.Id,u.Name);
            }
        }

        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            FormUbahPegawai frm = new FormUbahPegawai();
            frm.Owner = this;
            frm.Show();
        }
    }
}
