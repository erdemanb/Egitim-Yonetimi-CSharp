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
        public string numara;
        private void OgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=.\\MSSQLSERVER01;Initial Catalog=OgrUygulama;Integrated Security=True");
            SqlCommand komut = new SqlCommand("Select * From Tbl_Notlar Where OgrenciId = @P1", baglanti);
            komut.Parameters.AddWithValue("@P1", numara);
            this.Text = numara.ToString();
            
        }
    }
}
