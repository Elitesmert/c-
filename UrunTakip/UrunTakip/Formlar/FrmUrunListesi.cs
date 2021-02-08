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
    public partial class FrmUrunListesi : Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }

        DBTeknikServisEntities db = new DBTeknikServisEntities();
        void method1()
        {
            var degerler = from u in db.TBLUrun
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.MARKA,
                               KATEGORİ = u.TBLKategori.AD,
                               u.STOK,
                               u.ALISFIYAT,
                               u.SATISFİYAT
                           };
            gridControl1.DataSource = degerler.ToList();
        }
        private void FrmUrunListesi_Load(object sender, EventArgs e)
        {
            //var degerler = db.TBLUrun.ToList();
            method1();

            lookUpEdit1.Properties.DataSource = db.TBLKategori.ToList();

        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            TBLUrun t = new TBLUrun();
            t.AD = txt_ad.Text;
            t.MARKA = txt_marka.Text;
            t.DURUM = false;
            t.KATEGORI = byte.Parse(lookUpEdit1.EditValue.ToString());
            if (txt_satis.Text == "" || txt_stok.Text == "" || txt_alis.Text == "")
            {
                if (txt_satis.Text == "")
                    t.SATISFİYAT = decimal.Parse(txt_satis.Text = "0");
                else
                    t.SATISFİYAT = decimal.Parse(txt_satis.Text);


                if (txt_stok.Text == "")
                    t.STOK = short.Parse(txt_stok.Text = "0");
                else
                    t.STOK = short.Parse(txt_stok.Text);


                if (txt_alis.Text == "")
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
            MessageBox.Show("Ürün Başarılı ile Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_listele_Click(object sender, EventArgs e)
        {
            method1();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txt_id.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txt_ad.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            txt_marka.Text = gridView1.GetFocusedRowCellValue("MARKA").ToString();
            txt_alis.Text = gridView1.GetFocusedRowCellValue("ALISFIYAT").ToString();
            txt_satis.Text = gridView1.GetFocusedRowCellValue("SATISFİYAT").ToString();
            txt_stok.Text = gridView1.GetFocusedRowCellValue("STOK").ToString();
            lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("KATEGORİ").ToString();
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txt_id.Text);
            var deger = db.TBLUrun.Find(id);
            db.TBLUrun.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Ürün Başarı ile Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btn_guncellle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txt_id.Text);
            var deger = db.TBLUrun.Find(id);
            deger.AD = txt_ad.Text;
            deger.MARKA = txt_marka.Text;
            deger.STOK = short.Parse(txt_stok.Text);
            deger.ALISFIYAT = decimal.Parse(txt_alis.Text);
            deger.SATISFİYAT = decimal.Parse(txt_satis.Text);
            deger.KATEGORI = byte.Parse(lookUpEdit1.EditValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Ürün Başarı ile Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
