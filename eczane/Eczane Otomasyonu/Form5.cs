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
    public partial class Form5 : Form
    {

        SqlConnection con;
        SqlDataAdapter da;
        SqlDataReader dr;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        public static string SqlCon = @"Data Source=DESKTOP-AJVESGS\SQLEXPRESS;Initial Catalog=202503021;Integrated Security=True";
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı '_202503021DataSet.login' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            //this.loginTableAdapter.Fill(this._202503021DataSet.login);
           

            Class1.griddoldur(dataGridView2, "select * from islem_gecmisi");
            Class1.griddoldur(dataGridView1, "select * from ilac_listesi");



        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void kaydetToolStripButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 a = new Form3();
            a.Show();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();          
            txt_fiyat.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sorgu = "select fiyat from ilac_listesi where ilac_adi=@ad";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@ad", textBox2.Text);

            string sql = "update ilac_listesi set fiyat='" + maskedTextBox1.Text + "'";
            Class1.kosulekleme(sql);
            MessageBox.Show("Fiyat Degistirme Islemi Basarili.");
            
            Class1.griddoldur(dataGridView1, "select * from ilac_listesi");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 a = new Form7();
            a.Show();


        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 a = new Form3();
            a.Show();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(SqlCon);
            string sql = "delete from login where id=@kid and kullaniciadi=@user";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@kid", int.Parse(textBox8.Text));
            cmd.Parameters.AddWithValue("@user", txtkullanici.Text);           
            con.Open();            
            cmd.ExecuteNonQuery();
            con.Close();
        }
        /*
        con = new SqlConnection(SqlCon);
        string sql = "delete from login where id=@kid and kullaniciadi=@user";
        cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@kid", int.Parse(textBox8.Text));
            cmd.Parameters.AddWithValue("@user", txtkullanici.Text);           
            con.Open();            
            cmd.ExecuteNonQuery();
            con.Close();
        */
        private void button3_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(SqlCon);           
            string sql = "delete from ilac_listesi where id=@kid";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@kid", Convert.ToInt32(textBox3.Text));                          
            con.Open();           
            cmd.ExecuteNonQuery();
            con.Close();
            Class1.griddoldur(dataGridView1, "select * from ilac_listesi");
        }

        private void bindingNavigatorAddNewItem_Click_1(object sender, EventArgs e)
        {

            this.Hide();
            Form3 a = new Form3();
            a.Show();
        }

        private void bindingNavigatorDeleteItem_Click_1(object sender, EventArgs e)
        {
            con = new SqlConnection(SqlCon);
            string sql = "delete from login where id=@kid and kullaniciadi=@user";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@kid", int.Parse(textBox8.Text));
            cmd.Parameters.AddWithValue("@user", txtkullanici.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
