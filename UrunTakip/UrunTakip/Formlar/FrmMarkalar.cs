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
    public partial class FrmMarkalar : Form
    {
        public FrmMarkalar()
        {
            InitializeComponent();
        }
        DBTeknikServisEntities db = new DBTeknikServisEntities();
        private void FrmMarkalar_Load(object sender, EventArgs e)
        {
            var degerler = db.TBLUrun.OrderBy(x => x.MARKA).GroupBy(y => y.MARKA).Select(z => new {

                Marka = z.Key,
                Toplam = z.Count()

            }) ;
            gridControl1.DataSource = degerler.ToList();
            labelControl7.Text = db.TBLUrun.Count().ToString();
            labelControl1.Text = (from x in db.TBLUrun select x.MARKA).Distinct().Count().ToString();
            labelControl5.Text = (from x in db.TBLUrun
                                  orderby x.SATISFİYAT descending
                                  select x.MARKA).FirstOrDefault();
            
        }
    }
}
