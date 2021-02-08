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
    public partial class FrmMusteriIller : Form
    {
        public FrmMusteriIller()
        {
            InitializeComponent();
        }
        DBTeknikServisEntities db = new DBTeknikServisEntities();
        SqlConnection Conn = new SqlConnection(@"Data Source=DESKTOP-MJCEVO3;Initial Catalog=DBTeknikServis;Integrated Security=True");
        private void FrmMusteriIller_Load(object sender, EventArgs e)
        {
            //chartControl1.Series["Series 1"].Points.AddPoint("Ankara", 6);
            //chartControl1.Series["Series 1"].Points.AddPoint("İzmir", 35);
            //chartControl1.Series["Series 1"].Points.AddPoint("İstanbul", 34);
            //chartControl1.Series["Series 1"].Points.AddPoint("Adana", 1);

            gridControl1.DataSource = db.TBLMusteri.OrderBy(x => x.IL).GroupBy(y => y.IL).Select(z => new { İL = z.Key, TOPLAM = z.Count() }).ToList();
            Conn.Open();
            SqlCommand komut = new SqlCommand("select IL,COUNT(*) FROM TBLMusteri group by IL",Conn);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read()){
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]),int.Parse(dr[1].ToString()));

            }
            Conn.Close();
        }
    }
}
