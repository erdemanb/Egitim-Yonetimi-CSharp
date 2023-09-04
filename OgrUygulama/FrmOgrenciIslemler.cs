using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OgrUygulama
{
    public partial class FrmOgrenciler : Form
    {
        public FrmOgrenciler()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.Tbl_OgrenciTableAdapter ds = new DataSet1TableAdapters.Tbl_OgrenciTableAdapter();
        string c = "";
        private void btnEkle_Click(object sender, EventArgs e)
        {
           
           
            ds.OgrenciEkle(txtOgrenciAd.Text,txtOgrenciSoyad.Text,byte.Parse(cmbOgrenciKulup.SelectedValue.ToString()),c);
            MessageBox.Show("Öğrenci eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=OgrUygulama;Integrated Security=True");

        private void FrmOgrenciler_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * FROM TBL_KULUPLER", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbOgrenciKulup.DisplayMember = "KulupAd";
            cmbOgrenciKulup.ValueMember = "KulupID";
            cmbOgrenciKulup.DataSource = dt;
            baglanti.Close();
            dataGridView1.ReadOnly = true;
        }


        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource=ds.OgrenciListesi();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(txtOgrenciID.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                txtOgrenciAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtOgrenciSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtOgrenciID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                string kulupAd = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                cmbOgrenciKulup.Text = kulupAd;
                if (rBErkek.Text == dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString())
                {
                    rBErkek.Checked = true;
                    c = rBErkek.Text;
                }
                else
                {
                    rbKiz.Checked = true;
                    c= rbKiz.Text;
                }
            }
            catch (Exception ex)
            {

                    MessageBox.Show("HATA!" + ex.Message);
            }
           



        }

        private void cmbOgrenciKulup_KeyPress(object sender, KeyPressEventArgs e)
        {
                e.Handled = true; // Klavye girişini engelle

        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true; // Klavye girişini engelle

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ds.OgrenciGuncelle(txtOgrenciAd.Text,txtOgrenciSoyad.Text,Byte.Parse(cmbOgrenciKulup.SelectedValue.ToString()),c,Convert.ToInt32(txtOgrenciID.Text));
        }

        private void rbKiz_CheckedChanged(object sender, EventArgs e)
        {

            if (rbKiz.Checked == true)
            {
                rBErkek.Checked = false;
                c = rbKiz.Text;
            }
        }

        private void rBErkek_CheckedChanged(object sender, EventArgs e)
        {
            if (rBErkek.Checked == true)
            {
                rbKiz.Checked = false;
                c = rBErkek.Text;
            }

        }
    }
}
