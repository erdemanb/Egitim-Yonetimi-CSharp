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

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string c = "";
            if (rBErkek.Checked == true)
            {
                rbKiz.Checked = false;
                c = rBErkek.Text;
            }
            if (rbKiz.Checked == true)
            {
                rBErkek.Checked = false;
                c = rbKiz.Text;
            }
            ds.OgrenciEkle(txtOgrenciAd.Text,txtOgrenciSoyad.Text,byte.Parse(cmbOgrenciKulup.Text),c);
            MessageBox.Show("Öğrenci eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=OgrUygulama;Integrated Security=True");

        private void FrmOgrenciler_Load(object sender, EventArgs e)
        {
            cmbOgrenciKulup.DropDownStyle = ComboBoxStyle.DropDownList;
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
        }


        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource=ds.OgrenciListesi();
        }
    }
}
