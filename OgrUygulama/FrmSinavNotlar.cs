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

namespace OgrUygulama
{
    public partial class FrmSinavNotlar : Form
    {
        public FrmSinavNotlar()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.Tbl_NotlarTableAdapter ds = new DataSet1TableAdapters.Tbl_NotlarTableAdapter();
        private void btnOgrenciBul_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NotListesi(int.Parse(txtOgrenciID.Text));

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=OgrUygulama;Integrated Security=True");

        private void FrmSinavNotlar_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * FROM TBL_DERSLER", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbDersListesi.DisplayMember = "DersAd";
            cmbDersListesi.ValueMember = "DersID";
            cmbDersListesi.DataSource = dt;
            baglanti.Close();
            dataGridView1.ReadOnly = true;

        }
        int notid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtOgrenciID.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSinav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSinav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtSinav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

        }
        int sinav1, sinav2, sinav3, proje;

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            try
            {
                double ort;
                sinav1 = Convert.ToInt16(txtSinav1.Text);
                sinav2 = Convert.ToInt16(txtSinav2.Text);
                sinav3 = Convert.ToInt16(txtSinav3.Text);
                proje = Convert.ToInt16(txtProje.Text);
                ort = (double)(sinav1 + sinav2 + sinav3 + proje) / 4;
                txtOrtalama.Text = ort.ToString();
                if (ort >= 50)
                    txtDurum.Text = "True";
                else
                {
                    txtDurum.Text = "False";
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Bütün notlar verilmediği için ortalama hesaplanmıyor!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            ds.NotGuncelle(byte.Parse(cmbDersListesi.SelectedValue.ToString()), byte.Parse(txtOgrenciID.Text),byte.Parse(txtSinav1.Text), byte.Parse(txtSinav2.Text), byte.Parse(txtSinav3.Text), byte.Parse(txtProje.Text), Decimal.Parse(txtOrtalama.Text), bool.Parse(txtDurum.Text),notid) ;
        }
    }
}
