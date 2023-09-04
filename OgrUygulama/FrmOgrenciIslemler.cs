using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            //CMB'ye data ekle!!!
        }

        private void FrmOgrenciler_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }
    }
}
