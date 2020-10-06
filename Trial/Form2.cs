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

            buttonMProduk.Visible = false;
            buttonMPegawai.Visible = false;
            buttonMNota.Visible = false;
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
            if (buttonMProduk.Visible == false)
            {
                buttonMProduk.Visible = true;
                buttonMPegawai.Visible = true;
                buttonMNota.Visible = true;
            }
            else
            {
                buttonMProduk.Visible = false;
                buttonMPegawai.Visible = false;
                buttonMNota.Visible = false;
            }
        }
        Form fo = null;
        private void buttonMP1_Click(object sender, EventArgs e)
        {
            fo = Application.OpenForms["FormDaftarBarang"];
            if (fo == null)
            {
                FormDaftarProduk fdp = new FormDaftarProduk();
                fdp.Owner = this;
                fdp.Show();
            }
            else
            {
                fo.Show();
                fo.BringToFront();
            }
        }

        private void buttonMP2_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonMP3_Click(object sender, EventArgs e)
        {
            
            //tes
        }
    }
}
