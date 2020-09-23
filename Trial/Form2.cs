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
            buttonh1.Visible = false;
            buttonh2.Visible = false;
            buttonh3.Visible = false;
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
    }
}
