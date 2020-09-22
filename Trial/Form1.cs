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
    public partial class Form1 : Form
    {
        List<int> iniList = new List<int>();
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            double h = 1;
            while (h < 100)
            {
                listBox1.Items.Add(h + "");
                if (h % 20 == 0)
                {
                    break;
                }
                h++;
            }
        }
    }
}