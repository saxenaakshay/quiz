using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;




namespace WindowsFormsApplication4
{   public partial class Form3 : Form
    {   OracleConnection conn;
        OracleCommand cm = new OracleCommand();
        int i = 0;
        DataRow dr;
        String corr, hint, fif;
        int[] sum = { 0, 1000, 5000, 10000, 25000, 50000 };

        int tim1 = 15;
        int tim, tb = 0;
        string usn,nam;
        SKYPE4COMLib.Skype osk = new SKYPE4COMLib.Skype();
    
        public Form3 (string us, string pw)
        {
            
            usn = us;
            nam = pw;
            InitializeComponent();
            ret();
           
            



        }
        

        public void connect1()
        {
            string oradb = "Data Source=AKSHAY; User ID=system; Password=welcome;  ";
            conn = new OracleConnection(oradb);
            conn.Open();
        }

        public void ret()
        {
            connect1();
            timer2.Stop();
            textBox1.Hide();
            button6.Hide();
            label12.Hide();
            label13.Hide();
            cm.CommandText = "select * from level1";
            cm.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cm.CommandText, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "level1");
            DataTable dt = ds.Tables["level1"];
            int tr = dt.Rows.Count;

            if (i >= dt.Rows.Count)
                i = 0;


            dr = dt.Rows[i];
            linkLabel4.Show();
            linkLabel3.Show();
            linkLabel2.Show();
            linkLabel1.Show();
            label11.Text = "Player: "+ nam;            
            label9.Text = (i + 1).ToString();
            label1.Text = dr["question"].ToString();
            linkLabel1.Text = dr["OP1"].ToString();
            linkLabel2.Text = dr["OP2"].ToString();
            linkLabel3.Text = dr["OP3"].ToString();
            linkLabel4.Text = dr["OP4"].ToString();
            corr = dr["ANS"].ToString();
            hint = dr["hint"].ToString();
            fif = dr["fifty"].ToString();
            label19.Text = tb.ToString();
            label10.Hide();
            i++;
            
            tim1 += 15;
            tim = tim1;
            timer1.Start();
            label18.Text = sum[i-1].ToString();
            label20.Text = sum[i].ToString();
           

        }
        public Form3()
        {
            InitializeComponent();
            ret();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (tim == 0)
                Application.Exit();

            tim--;

            label2.Text = tim.ToString();
            if (tim <= 10)
            {
                label2.ForeColor = Color.Red;

            }

            else
                label2.ForeColor = Color.Green;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (corr == "1")
            {
                tb += tim;
                timer1.Stop();
                MessageBox.Show("CORRECT ANSWER!");
                ret();
            }
            else
            {
                MessageBox.Show("WRONG ANSWER");
                Application.Exit();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (corr == "2")
            {
                tb += tim;
                timer1.Stop();
                MessageBox.Show("CORRECT ANSWER");
                ret();
            }
            else
            {
                MessageBox.Show("WRONG ANSWER");
                Application.Exit();
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (corr == "3")
            {
                tb += tim;
                timer1.Stop();
                MessageBox.Show("CORRECT ANSWER");
                ret();
            }
            else
            {
                MessageBox.Show("WRONG ANSWER");
                Application.Exit();
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (corr == "4")
            {
                tb += tim;
                timer1.Stop();
                MessageBox.Show("CORRECT ANSWER");
                ret();
            }
            else
            {
                MessageBox.Show("WRONG ANSWER");
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label10.Text = hint.ToString();
            label10.Show();
            button3.Hide();

           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ret();
            button4.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (fif!="1" && corr!="1")
                linkLabel1.Hide();
          
            if (fif!="2" && corr!="2")
                linkLabel2.Hide() ;
            if (fif!="3" && corr!="3")
                linkLabel3.Hide();
            if (fif != "4" && corr != "4")
                linkLabel4.Hide();

            button1.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO QUIT?", "QUIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("U win " + sum[i-1] + "! ");
                Application.Exit();
            }
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SpeechSynthesizer ss = new SpeechSynthesizer();
            ss.Speak(label1.Text);
        }
        int k;
        private void button6_Click(object sender, EventArgs e)
        {
            osk.PlaceCall(textBox1.Text);
            k = 30;
            timer1.Stop();
            timer2.Start();
            label12.Show();
            
        
}
    
        private void timer2_Tick(object sender, EventArgs e)
        {
            k--;
            label12.Text = k.ToString() + " s";
            if (k <= 10)
            label12.ForeColor = Color.Red;

            if (k == 0)
            {
                 osk.SendMessage(textBox1.Text, "callclose");
                timer1.Start();
                timer2.Stop();

                
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {//tton7.
            button7.Hide();
            label13.Show();

            textBox1.Show();
            button6.Show();
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
       

       
        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

    }
}
