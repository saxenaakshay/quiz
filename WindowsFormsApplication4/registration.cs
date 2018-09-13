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
    public partial class registration : Form
    {
        OracleConnection conn;
        OracleCommand cm;
        public registration()
        {
            InitializeComponent();
            connect1();
        }
        
        public void connect1()
        {

            string oradb = "Data Source=AKSHAY; User ID=system; Password=welcome;  ";
            conn = new OracleConnection(oradb);
            conn.Open();
        }

        public void reg()
        {
            connect1();
            cm = new OracleCommand();
            string name, usn, pwd;
            string age;
            name = textBox1.Text;
            age = textBox2.Text;
            usn = textBox3.Text;
            pwd = textBox4.Text;
            cm.Connection = conn;
            cm.CommandText = "insert into regs values (:pa1, :pa2, :pa3, :pa4)";
            
            OracleParameter p1 = new OracleParameter();
            
            p1.DbType = DbType.String;
            p1.ParameterName = "pa1";
            p1.Value = name;

            OracleParameter p2 = new OracleParameter();
            p2.DbType = DbType.String;
            p2.ParameterName = "pa2";
            p2.Value = age;
          
            OracleParameter p3 = new OracleParameter();
            p3.DbType = DbType.String;
            p3.ParameterName = "pa3";
            p3.Value = usn;

            OracleParameter p4 = new OracleParameter();
            p4.DbType = DbType.String;
            p4.ParameterName = "pa4";
            p4.Value = pwd;
            
            
            cm.Parameters.Add(p1);
            cm.Parameters.Add(p2);
            cm.Parameters.Add(p3);
            cm.Parameters.Add(p4);
            cm.ExecuteNonQuery();
            MessageBox.Show("REGISTERED");
            conn.Close();
            Form2 f = new Form2();
            f.Show();
            this.Hide();






        }


        private void registration_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            reg();
        }
    }
}
