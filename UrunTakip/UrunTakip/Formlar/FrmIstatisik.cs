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

namespace UrunTakip.Formlar
{
    public partial class FrmIstatisik : Form
    {
        public FrmIstatisik()
        {
            InitializeComponent();
        }
        DBTeknikServisEntities db = new DBTeknikServisEntities();
        SqlConnection Conn = new SqlConnection(@"Data Source=DESKTOP-MJCEVO3;Initial Catalog=DBTeknikServis;Integrated Security=True");
        private void FrmIstatisik_Load(object sender, EventArgs e)
        {
            labelControl2.Text = db.TBLUrun.Count().ToString();
            labelControl3.Text = db.TBLKategori.Count().ToString();
            labelControl5.Text = db.TBLUrun.Sum(x => x.STOK).ToString();
            labelControl11.Text = (from x in db.TBLUrun
                                   orderby x.STOK
                                   descending
                                   select x.AD).FirstOrDefault();
            labelControl19.Text = (from x in db.TBLUrun
                                   orderby x.SATISFİYAT
                                   descending
                                   select x.AD).FirstOrDefault();
            labelControl13.Text = (from x in db.TBLUrun
                                   orderby x.STOK
                                   descending
                                   select x.AD).FirstOrDefault();
            labelControl15.Text = (from x in db.TBLUrun
                                   orderby x.SATISFİYAT
                                   ascending
                                   select x.AD).FirstOrDefault();
            labelControl21.Text = (from x in db.TBLUrun
                                   select x.MARKA).Distinct().Count().ToString();
            labelControl29.Text = (from x in db.TBLUrun
                                   select x.KATEGORI).Distinct().Count().ToString();
            labelControl17.Text = db.makskategoriurun().FirstOrDefault();
        }
    }
}
