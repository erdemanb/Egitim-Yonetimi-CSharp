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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmOgrenciNotlar frm = new FrmOgrenciNotlar();
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Lütfen Öğrenci Numarası Giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                frm.numara = textBox1.Text.Trim();
                frm.Show();
            }
        }
    }
}
