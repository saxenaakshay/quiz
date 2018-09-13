using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO QUIT?", "QUIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 r = new Form5();
            r.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
           /* Form3 f3 = new Form3();
            f3.Show();
            this.Hide();*/
        }
    }
}
