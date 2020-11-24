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
    
    
    
    //test branch password
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