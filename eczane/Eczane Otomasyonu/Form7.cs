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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlDataAdapter da;
        SqlDataReader dr;
        SqlCommand cmd;
        DataSet ds;

        public static string SqlCon = @"Data Source=DESKTOP-AJVESGS\SQLEXPRESS;Initial Catalog=202503021;Integrated Security=True";

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && checkBox1.Checked == true)
            {

                con = new SqlConnection(SqlCon);
                string sql = "insert into ilac_listesi(ilac_adi,uretici_firma,fiyat,kullanım_nedeni,yan_etkileri) values (@ad,@fad,@fiyat,@kul,@etki)";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ad", textBox1.Text);
                cmd.Parameters.AddWithValue("@fad", textBox2.Text);
                cmd.Parameters.AddWithValue("@fiyat", textBox3.Text);
                cmd.Parameters.AddWithValue("@kul", textBox5.Text);
                cmd.Parameters.AddWithValue("@etki", textBox4.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Ilac Basari Ile Eklendi.");
                this.Close();
                Form5 a = new Form5();
                a.Show();

            }
            else
            {
                MessageBox.Show("Hatali bir islem yaptiniz");
            }
            }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form5 a = new Form5();
            a.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
