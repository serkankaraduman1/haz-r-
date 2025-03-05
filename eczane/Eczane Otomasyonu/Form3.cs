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
    public partial class Form3 : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlDataReader dr;
        SqlCommand cmd;
        DataSet ds;

        public static string SqlCon = @"Data Source=DESKTOP-AJVESGS\SQLEXPRESS;Initial Catalog=202503021;Integrated Security=True";
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox1.SelectedItem != "" && checkBox1.Checked==true)
            {
                
                con = new SqlConnection(SqlCon);
                string sql = "insert into login(kullaniciadi,parola,tc_no,tel_no,guvence,yetki) values (@user,@password,@tc,@tel,@guvence,@yetki)";
                cmd = new SqlCommand(sql,con);
                cmd.Parameters.AddWithValue("@user", textBox1.Text);
                cmd.Parameters.AddWithValue("@password", Class1.MD5sifreleme(textBox2.Text));
                cmd.Parameters.AddWithValue("@tc", textBox3.Text);
                cmd.Parameters.AddWithValue("@tel", textBox4.Text);
                cmd.Parameters.AddWithValue("@guvence", comboBox1.SelectedItem);
                cmd.Parameters.AddWithValue("yetki", comboBox2.Text);
                con.Open();
                //cmd.Connection = con;
                //cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Kayit Basari ile Olusturuldu.");
                if(comboBox2.Visible==true)
                {
                    this.Close();
                    Form5 a = new Form5();
                    a.Show();
                }
                else
                {
                    this.Close();
                    Form1 a = new Form1();
                    a.Show();
                }
                

                /*
                string sql = "insert into login(kullaniciadi,parola,tc_no,tel_no,guvence,yetki) values (@user,@password,@tc,@tel,@guvence,@yetki)";
                Class1.kosulekleme(sql);
                MessageBox.Show("Kayit Basari ile Olusturuldu.");
                this.Close();
                Form1 a = new Form1();
                a.Show();
                */
            }
            else
            {
                MessageBox.Show("Hicbir Alan Bos Birakilamaz");
            }
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox5.Visible = false;
            textBox5.Text = Form1.kullanici;
            comboBox2.Visible = false;
            label6.Visible = false;

            string sorgu = "select * from login where kullaniciadi=@kullanici";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@kullanici", Form1.kullanici);         
            con.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                if (dr["yetki"].ToString() == "Admin")
                {
                    comboBox2.Visible = true;
                    label6.Visible = true;
                }
                else
                {
                   
                }
                con.Close();
                
            }

            comboBox1.Items.Add("SSK");
            comboBox1.Items.Add("Emekli");
            comboBox1.Items.Add("Diger");
            comboBox2.Items.Add("Admin");
            comboBox2.Items.Add("Kullanici");

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.Visible == true)
            {
                this.Close();
                Form5 a = new Form5();
                a.Show();
            }
            else
            {
                this.Close();
                Form1 a = new Form1();
                a.Show();
            }
        }
    }
}
