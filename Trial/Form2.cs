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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //comment
            //apa

            //testing123 x 123
            buttonh1.Visible = false;
            buttonh2.Visible = false;
            buttonh3.Visible = false;

            buttonMP1.Visible = false;
            buttonMP2.Visible = false;
            buttonMP3.Visible = false;
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (buttonh1.Visible == false)
            {
                buttonh1.Visible = true;
                buttonh2.Visible = true;
                buttonh3.Visible = true;
            }
            else
            {
                buttonh1.Visible = false;
                buttonh2.Visible = false;
                buttonh3.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (buttonMP1.Visible == false)
            {
                buttonMP1.Visible = true;
                buttonMP2.Visible = true;
                buttonMP3.Visible = true;
            }
            else
            {
                buttonMP1.Visible = false;
                buttonMP2.Visible = false;
                buttonMP3.Visible = false;
            }
        }

        private void buttonMP1_Click(object sender, EventArgs e)
        {
            FormTambahProduk frm = new FormTambahProduk();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonMP2_Click(object sender, EventArgs e)
        {
            FormUbahProduk frm = new FormUbahProduk();
            frm.Owner = this;
            frm.Show();
        }

        private void buttonMP3_Click(object sender, EventArgs e)
        {
            FormHapusProduk frm = new FormHapusProduk();
            frm.Owner = this;
            frm.Show();
        }
    }
}
