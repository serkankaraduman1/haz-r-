using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;

namespace Eczane_Otomasyonu
{
    class Class1
    {

        public static bool baglantidurum()
        {
            using (con = new SqlConnection(SqlCon))
            {
                try
                {
                    con.Open();
                    return true;
                }
                catch(SqlException exp)
                {
                    MessageBox.Show(exp.Message);
                    return false;
                }
            }
        }

        public static string yetki = "";

        public static string SqlCon = @"Data Source=DESKTOP-AJVESGS\SQLEXPRESS;Initial Catalog=202503021;Integrated Security=True";

        static SqlConnection con;
        static SqlDataAdapter da;
        static SqlDataReader dr;
        static SqlCommand cmd;
        static DataSet ds;
        public static bool login(string kullanici,string sifre)
        {
            string sorgu = "select * from login where kullaniciadi=@kullanici and parola=@sifre";
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@kullanici", kullanici);
            cmd.Parameters.AddWithValue("@sifre", Class1.MD5sifreleme(sifre));
            con.Open();
            dr = cmd.ExecuteReader();
            
            if (dr.Read())
            {   
              if(dr["yetki"].ToString()=="Admin")
                {
                     yetki = "Admin";                   
                }
              else
                {
                    yetki = "kullanici";
                }
                con.Close();
                return true;
            }
            else
            {
                //MessageBox.Show("Kullanici adi veya sifre hatali!");
                con.Close();
                return false;

                
            }
            
        }

        public static DataGridView griddoldur(DataGridView grid, string sqlselectsorgu)
        {
            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter(sqlselectsorgu, con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, sqlselectsorgu);
            grid.DataSource = ds.Tables[sqlselectsorgu];
            con.Close();
            return grid;

        }


        public static string MD5sifreleme(string sifreleme)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] dizi = Encoding.UTF8.GetBytes(sifreleme);
            dizi = md5.ComputeHash(dizi);

            StringBuilder sb = new StringBuilder();

            foreach (byte item in dizi)
            {
                sb.Append(item.ToString("x2").ToLower());
            }

            return sb.ToString();


        }

        public static void kosulekleme(string sql)
        {
            con = new SqlConnection(SqlCon);
            cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        

    }

}


