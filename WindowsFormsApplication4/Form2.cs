using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace WindowsFormsApplication4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            button9.MouseEnter += new EventHandler(button9_MouseEnter);
            button9.MouseLeave += new EventHandler(button9_MouseLeave);
            connect1();
            button11.Hide();
            button12.Hide();
            button13.Hide();


        }

        OracleConnection conn;
       
        public void connect1()
        {
            string oradb = "Data Source=AKSHAY; User ID=system; Password=welcome;  ";
            conn = new OracleConnection(oradb);
            conn.Open();
        }

        public void login()
        {
            connect1();
            OracleCommand cm = new OracleCommand();
            string us, pw;
            us = textBox1.Text;
            pw = textBox2.Text;
            cm.Connection = conn;
            cm.CommandText = "select * from regs" ;
            cm.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cm.CommandText, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "regs");
            DataTable dt = ds.Tables["regs"];
           // int tr = dt.Rows.Count;
            DataRow dr;
            int i=0, flag =0;
            while (i < dt.Rows.Count)
            {   dr = dt.Rows[i];
                if (us == dr["usn"].ToString())
                {
                    flag = 1;
                    if (pw == dr["pwd"].ToString())
                    {
                        MessageBox.Show("WELCOME " + dr["name"].ToString());
                        string nam = dr["name"].ToString();
                        Form3 f1 = new Form3(us, nam);
                        f1.Show();
                        this.Hide();
                        break;
                    }
                    else
                        MessageBox.Show("WRONG PASSWORD");
                }
                i++;
            }
            if (flag == 0)
                MessageBox.Show("USERNAME NOT FOUND");






        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            registration f = new registration();
            f.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.textBox2.PasswordChar = '*';
        }
        private void button9_MouseEnter(object sender, EventArgs e)
        {
            button13.Show();
            button11.Show();
            button12.Show();



        }
        int ti;
        private void button9_MouseLeave(object sender, EventArgs e)
        {
            int ti = 0;

            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ti++;
            if (ti > 3)
            {
                button12.Hide();
                button11.Hide();
                button13.Hide();
                timer1.Stop();
            }
        }
      
    }
}
