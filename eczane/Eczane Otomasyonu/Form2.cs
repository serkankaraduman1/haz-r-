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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;

        public static string SqlCon = @"Data Source=DESKTOP-AJVESGS\SQLEXPRESS;Initial Catalog=202503021;Integrated Security=True";
        

        private void Form2_Load(object sender, EventArgs e)
        {
            
            
            textBox3.Text = Form1.kullanici;
            textBox7.Text = Form1.kullanici;
            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter("select * from login where kullaniciadi='"+textBox3.Text+"'",con);          
            DataTable tablo = new DataTable();
            con.Open();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            con.Close();

            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter("select * from ilac_listesi", con);
            DataTable tablo1 = new DataTable();
            con.Open();
            da.Fill(tablo1);
            dataGridView2.DataSource = tablo1;
            con.Close();

            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter("select * from islem_gecmisi  where musteri='" + textBox7.Text + "'", con);
            DataTable tablo2 = new DataTable();
            con.Open();
            da.Fill(tablo2);
            dataGridView3.DataSource = tablo2;
            con.Close();


            dataGridView1.Columns[0].Visible = false;
            dataGridView2.Columns[0].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView3.Columns[0].Visible = false;

            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        
        
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtkullanici.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtparola.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtTC.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtGuvence.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtTel.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();



        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {               
            //textBox1.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            //txt_kutu.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            txt_fiyat.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            textBox6.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            
        }

       
        int toplam;
        string ad = "", adet = "";
        int fiyat;

        int kontrol = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (kontrol == 0)
            {
                kontrol = 1;
                string a = textBox1.Text + "," + textBox2.Text;
                textBox1.Text = a.Substring(1);
                
            }
            else
            {
                textBox1.Text= textBox1.Text + "," + textBox2.Text;
                
            }

            toplam = int.Parse(txt_toplam.Text);
            toplam = toplam + int.Parse(txt_fiyat.Text) * int.Parse(maskedTextBox1.Text);
            txt_toplam.Text = toplam.ToString();
            adet = maskedTextBox1.Text;
            if(int.Parse(adet)>0)
            {
                try
                {
                    ad = textBox2.Text;

                    fiyat = int.Parse(txt_fiyat.Text) * int.Parse(maskedTextBox1.Text);
                    string[] bilgiler = { ad, adet, fiyat.ToString() };
                    ListViewItem lst = new ListViewItem(bilgiler);
                    listView1.Items.Add(lst);

                }
                catch (Exception)
                {
                    MessageBox.Show("Hatali Islem Yaptiniz!");

                }

            }
            else
            {
                MessageBox.Show("Hatali Islem Yaptiniz!");
            }
           
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_toplam_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(SqlCon);
            string sql = "insert into islem_gecmisi(musteri,alinan_urunler,toplam_fiyat,alim_tarihi) values (@user,@urun,@toplam,@tarih)";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@user", Form1.kullanici);
            cmd.Parameters.AddWithValue("@urun",textBox1.Text);
            cmd.Parameters.AddWithValue("@toplam", txt_toplam.Text);
            cmd.Parameters.AddWithValue("@tarih", dateTimePicker1.Value);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Satın Alım Basarı ile Gerçekleşti.");


            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter("select * from islem_gecmisi  where musteri='" + textBox7.Text + "'", con);
            DataTable tablo2 = new DataTable();
            con.Open();
            da.Fill(tablo2);
            dataGridView3.DataSource = tablo2;
            con.Close();

            listView1.Items.Clear();
            txt_toplam.Text = "0";
            textBox1.Text = "";
            maskedTextBox1.Text = "1";
            kontrol = 0;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 a = new Form6();
            a.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            txt_toplam.Text = "0";
            textBox1.Text = "";
            maskedTextBox1.Text = "1";
            kontrol = 0;

        }
    }
}


            