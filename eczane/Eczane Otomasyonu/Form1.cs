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
    public partial class Form1 : Form
    {

        SqlConnection con;
        SqlDataAdapter da;
        SqlDataReader dr;
        SqlCommand cmd;
        DataSet ds;

        public static string SqlCon = @"Data Source=DESKTOP-AJVESGS\SQLEXPRESS;Initial Catalog=202503021;Integrated Security=True";
        public static string kullanici = "";
        


        public Form1()
        {
            InitializeComponent();
            Class1.baglantidurum();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            if(Class1.login(textBox1.Text, textBox2.Text))
            {              
                //MessageBox.Show("giris basarılı");                   
                this.Hide();
                kullanici = textBox1.Text;
                
                if(Class1.yetki=="Admin")
                {
                    Form5 a = new Form5();
                    a.Show();
                }
                else
                {
                    Form2 a = new Form2();
                    a.Show();
                }


                
            }
            else
            {
                MessageBox.Show("Kullanici adi veya sifre hatali!");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 a = new Form3();
            a.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        
        private void textBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
