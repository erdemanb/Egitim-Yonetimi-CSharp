﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OgrUygulama
{
    public partial class FrmKulupler : Form
    {
        public FrmKulupler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=OgrUygulama;Integrated Security=True");
        private void FrmKulupler_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void Listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_kulupler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
            
                baglanti.Open();
                SqlCommand cmd = new SqlCommand("Insert into Tbl_Kulupler (KulupAd) values (@p1)", baglanti);
                if (!string.IsNullOrWhiteSpace(txtKulupAd.Text))
                {
                    cmd.Parameters.AddWithValue("@p1", txtKulupAd.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Yeni Kulüp Başarıyla Eklendi!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Listele();
                }
                else
                    MessageBox.Show("Kulüp adı boş olamaz!", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Oluştu!: " + ex.ToString(), "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { baglanti.Close(); }

        }
    }
}
