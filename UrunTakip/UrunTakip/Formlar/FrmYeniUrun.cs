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
    public partial class FrmYeniUrun : Form
    {
        public FrmYeniUrun()
        {
            InitializeComponent();
        }
            DBTeknikServisEntities db = new DBTeknikServisEntities();

        private void pictureEdit6_Click(object sender, EventArgs e)
        {
            FrmYeniUrun fr = new FrmYeniUrun();
            this.Close();
        }
        private void btn_vazgec_Click(object sender, EventArgs e)
        {
            //  FrmYeniUrun fr = new FrmYeniUrun();
            // fr.Close();
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
           

            TBLUrun t = new TBLUrun();
            t.AD = txt_urunad.Text;
            t.MARKA = txt_marka.Text;
            t.DURUM = false;
            t.KATEGORI = 0;
            if (txt_satis.Text == "Satış Fiyatı" || txt_stok.Text == "Stok" || txt_alis.Text == "Alış Fiyatı")
            {
                if (txt_satis.Text == "Satış Fiyatı")
                    t.SATISFİYAT = decimal.Parse(txt_satis.Text = "0");
                else
                    t.SATISFİYAT = decimal.Parse(txt_satis.Text);


                if (txt_stok.Text == "Stok")
                    t.STOK = short.Parse(txt_stok.Text = "0");
                else
                    t.STOK = short.Parse(txt_stok.Text);


                if (txt_alis.Text == "Alış Fiyatı")
                    t.ALISFIYAT = decimal.Parse(txt_alis.Text = "0");
                else
                    t.ALISFIYAT = decimal.Parse(txt_alis.Text);
            }
            else
            {
                t.STOK = short.Parse(txt_stok.Text);
                t.ALISFIYAT = decimal.Parse(txt_alis.Text);
                t.SATISFİYAT = decimal.Parse(txt_satis.Text);
            }
            db.TBLUrun.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürünler Başarı ile Kaydedildi");
        }

    }
}
