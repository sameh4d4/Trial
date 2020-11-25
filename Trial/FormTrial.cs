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
    //testing
    //testing2
    public partial class FormTrial : Form
    {
        List<int> iniList = new List<int>();
        public FormTrial()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            double h = 1;
            while (h < 100)
            {
                //asdasdasdas
                listBox1.Items.Add(h + "");
                listBox1.Items.Add("lsasasa");
                if (h % 20 == 0)
                {
                    break;
                }
                h++;
            }
        }
    }
}