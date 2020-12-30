using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;


namespace VeriTabani
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        NpgsqlConnection connection = new NpgsqlConnection("server=localhost; port=5432; Database=VeriTabaniProje; user ID=postgres; password=yuma12");
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void VerileriGoruntule()
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from kiyafetler";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, connection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {

            connection.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into kiyafetler (kiyafet_no, fiyat, kiyafet_beden, kiyafet_modeli, kiyafet_rengi, kiyafet_sayisi) values (@p1,@p2,@p3,@p4,@p5,@p6)", connection);
            komut.Parameters.AddWithValue("@p1", numericUpDown3.Value);
            komut.Parameters.AddWithValue("@p2", numericUpDown2.Value);
            komut.Parameters.AddWithValue("@p3", numericUpDown4.Value);
            komut.Parameters.AddWithValue("@p4", textBox3.Text);
            komut.Parameters.AddWithValue("@p5", textBox2.Text);
            komut.Parameters.AddWithValue("@p6", numericUpDown1.Value);
            komut.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Yeni Siparişler Verildi!");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand komutSil = new NpgsqlCommand("Delete from kiyafetler where kiyafet_no=@p1", connection);
            komutSil.Parameters.AddWithValue("@p1", numericUpDown3.Value);
            komutSil.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Bazı siparişler iptal edildi!");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            connection.Open();
            NpgsqlCommand komutGuncelle = new NpgsqlCommand("update kiyafetler set fiyat=@p1, kiyafet_beden=@p2, kiyafet_modeli=@p3, kiyafet_rengi=@p4, kiyafet_sayisi=@p5 where kiyafet_no=@p6", connection);
            komutGuncelle.Parameters.AddWithValue("@p6", numericUpDown3.Value);
            komutGuncelle.Parameters.AddWithValue("@p1", numericUpDown2.Value);
            komutGuncelle.Parameters.AddWithValue("@p2", numericUpDown4.Value);
            komutGuncelle.Parameters.AddWithValue("@p3", textBox3.Text);
            komutGuncelle.Parameters.AddWithValue("@p4", textBox2.Text);
            komutGuncelle.Parameters.AddWithValue("@p5", numericUpDown1.Value);
            komutGuncelle.ExecuteNonQuery();
            
            MessageBox.Show("Sipariş güncellendi!");

            connection.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }
    }
}
