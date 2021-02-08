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
    public partial class FrmKategori : Form
    {
        public FrmKategori()
        {
            InitializeComponent();
        }
        DBTeknikServisEntities db = new DBTeknikServisEntities();

        private void FrmKategori_Load(object sender, EventArgs e)
        {
            var degerler = from k in db.TBLKategori
                           select new
                           {
                               k.ID,
                               k.AD
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            TBLKategori t = new TBLKategori();
            t.AD = txt_ad.Text;
            db.TBLKategori.Add(t);
            db.SaveChanges();
            MessageBox.Show("Kategori Başarı ile Kaydedildi");

        }

        private void btn_listele_Click(object sender, EventArgs e)
        {
            var degerler = from k in db.TBLKategori
                           select new
                           {
                               k.ID,
                               k.AD
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txt_id.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txt_ad.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txt_id.Text);
            var deger = db.TBLKategori.Find(id);
            db.TBLKategori.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Kategori Başarı ile Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btn_guncellle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txt_id.Text);
            var deger = db.TBLKategori.Find(id);
            deger.AD = txt_ad.Text;
            db.SaveChanges();
            MessageBox.Show("Kategori Başarı ile Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
