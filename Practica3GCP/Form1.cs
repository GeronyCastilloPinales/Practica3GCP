using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica3GCP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 fn2 = new Form2();
            fn2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 fn3 = new Form3();
            fn3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 fn4 = new Form4();
            fn4.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 fn5 = new Form5();
            fn5.Show();
        }
    }
}
