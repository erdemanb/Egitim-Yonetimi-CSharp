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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKulupID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtKulupAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            try
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("DELETE FROM Tbl_Kulupler WHERE KulupID = @p1", baglanti);

                if (!string.IsNullOrWhiteSpace(txtKulupID.Text))
                {
                    komut.Parameters.AddWithValue("@p1", txtKulupID.Text);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kulüp Silindi!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Listele();
                }
                else
                {
                    MessageBox.Show("SİLİNEMEDİ, Kulüp ID boş olamaz!", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Oluştu!: " + ex.ToString(), "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand komut1 = new SqlCommand("UPDATE Tbl_kulupler SET Kulupad=@p1 where KulupID=@p2", baglanti);

                if (!string.IsNullOrWhiteSpace(txtKulupID.Text))
                {
                    komut1.Parameters.AddWithValue("@p1", txtKulupAd.Text);
                    komut1.Parameters.AddWithValue("@p2", txtKulupID.Text);
                    komut1.ExecuteNonQuery();
                    MessageBox.Show("Kulüp Güncellendi!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Listele();
                }
                else
                {
                    MessageBox.Show("Kulüp ID boş olamaz!", "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Oluştu!: " + ex.ToString(), "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglanti.Close();
            }
        }
    }
}
