using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Eczane_Otomasyonu
{
    public partial class Form6 : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlDataReader dr;
        SqlCommand cmd;
        DataSet ds;

        public static string SqlCon = @"Data Source=DESKTOP-AJVESGS\SQLEXPRESS;Initial Catalog=202503021;Integrated Security=True";

        public Form6()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        public  bool eskisifrekontrol()
        {
            string sorgu = "select parola from login where kullaniciadi=@kullanici and parola=@sifre";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@kullanici", Form1.kullanici);
            cmd.Parameters.AddWithValue("@sifre", Class1.MD5sifreleme(textBox1.Text));
            con.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                string sql = "update login set parola='" + Class1.MD5sifreleme(textBox2.Text) + "'";
                Class1.kosulekleme(sql);
                MessageBox.Show("Sifre Degistirme Islemi Basarili.");
                con.Close();
                this.Close();
                Form2 a = new Form2();
                a.Show();
                return true;


            }
            else
            {
                MessageBox.Show("Eski sifreniz hatali!");
                con.Close();
                return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            {
                if(textBox2.Text==textBox3.Text && textBox2.Text!="")
                {
                    eskisifrekontrol();
                }
                else
                {
                    MessageBox.Show("Yeni sifre ve tekrari ayni olmalidir!");
                }
            }
            else
            {
                MessageBox.Show("Checkbox isaretlenmelidir!");
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            label3.Text = Form1.kullanici;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 a = new Form2();
            a.Show();
        }
    }
}
