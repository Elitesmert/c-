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
    public partial class FrmMusteri : Form
    {
        public FrmMusteri()
        {
            InitializeComponent();
        }
        DBTeknikServisEntities db = new DBTeknikServisEntities();
        void method1()
        {
            var degerler = from m in db.TBLMusteri
                           select new
                           {
                               m.ID,
                               m.AD,
                               m.SOYAD,
                               m.TELEFON,
                               m.IL,
                               m.STATU,
                               m.BANKA,
                               m.ADRES
                           };
            gridControl1.DataSource = degerler.ToList();
        }
        private void FrmMusteri_Load(object sender, EventArgs e)
        {
            //gridControl1.DataSource = db.TBLMusteri.ToList();
            method1();
            labelControl15.Text = db.TBLMusteri.Count().ToString();
            //labelControl5.Text = db.TBLMusteri.Count().ToString();
            labelControl13.Text = (from x in db.TBLMusteri
                                   select x.IL).Distinct().Count().ToString();
           
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            TBLMusteri t = new TBLMusteri();
            t.AD = txt_ad.Text;
            t.SOYAD = txt_soyad.Text;
            t.TELEFON = txt_tel.Text;
            t.IL = txt_il.Text;
            t.STATU = txt_statu.Text;
            t.BANKA = txt_banka.Text;
            t.ADRES = txt_adres.Text;
            
            db.TBLMusteri.Add(t);
            db.SaveChanges();
            MessageBox.Show("Müşteri Başarılı ile Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_listele_Click(object sender, EventArgs e)
        {
            method1();
        }

        private void btn_guncellle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txt_id.Text);
            var deger = db.TBLMusteri.Find(id);
            deger.AD = txt_ad.Text;
            deger.SOYAD = txt_soyad.Text;
            deger.TELEFON = txt_tel.Text;
            deger.IL = txt_il.Text;
            deger.STATU = txt_statu.Text;
            deger.BANKA = txt_banka.Text;
            deger.ADRES = txt_adres.Text;
            db.SaveChanges();
            MessageBox.Show("Müşteri Başarı ile Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txt_id.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txt_ad.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            txt_soyad.Text = gridView1.GetFocusedRowCellValue("SOYAD").ToString();
            txt_tel.Text = gridView1.GetFocusedRowCellValue("TELEFON").ToString();
            txt_il.Text = gridView1.GetFocusedRowCellValue("IL").ToString();
            txt_statu.Text = gridView1.GetFocusedRowCellValue("STATU").ToString();
            txt_banka.Text = gridView1.GetFocusedRowCellValue("BANKA").ToString();
            txt_adres.Text = gridView1.GetFocusedRowCellValue("ADRES").ToString();
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txt_id.Text);
            var deger = db.TBLMusteri.Find(id);
            db.TBLMusteri.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Müşteri Başarı ile Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }
}
