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

namespace OgrUygulama
{
    public partial class FrmOgrenciNotlar : Form
    {
        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=OgrUygulama;Integrated Security=True");
        public string numara;
        private void OgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("SELECT DersAd, Sinav1, Sinav2, Sinav3, Proje, Ortalama, Durum FROM Tbl_Notlar Inner JOIN Tbl_Dersler ON Tbl_Notlar.DersId = Tbl_Dersler.DersID where OgrID = @P1", baglanti);
            komut.Parameters.AddWithValue("@P1", numara);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("SELECT OgrenciAd from Tbl_Ogrenci where OgrenciId = @P2", baglanti);
            komut2.Parameters.AddWithValue("@P2", numara);
            SqlDataReader reader = komut2.ExecuteReader();
            if (reader.Read())
            {
                string ogrenciAdi = reader["OgrenciAd"].ToString();
                this.Text = "Öğrenci Adı: " + ogrenciAdi;
            }
            reader.Close();
            baglanti.Close();
        }
    }
}
