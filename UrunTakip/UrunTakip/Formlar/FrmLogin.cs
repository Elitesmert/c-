using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrunTakip.Formlar
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        DBTeknikServisEntities db = new DBTeknikServisEntities();
        private void pictureEdit6_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.95;
        }

        private void pictureEdit6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var sorgu = from x in db.TBLAdmin where x.KULLANICIAD == txt_ka.Text & x.SIFRE == txt_s.Text select x;
            if (sorgu.Any())
            {
                Form1 frm = new Form1();
                this.Hide();
                frm.Show();

            }
            else
            {
                MessageBox.Show("Hatalı Giriş");
            }
        }
    }
}
