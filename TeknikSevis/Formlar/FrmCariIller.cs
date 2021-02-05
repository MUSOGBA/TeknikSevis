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

namespace TeknikSevis.Formlar
{
    public partial class FrmCariIller : Form
    {
        public FrmCariIller()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();

        SqlConnection baglati = new SqlConnection(@"Data Source=DESKTOP-N5F5PJT;Initial Catalog=DbTeknikServis;Integrated Security=True");

        private void FrmCariIller_Load(object sender, EventArgs e)
        {
           /* chartControl1.Series["Series 1"].Points.AddPoint("Ankara",22);
            chartControl1.Series["Series 1"].Points.AddPoint("İstanbul",12);
            chartControl1.Series["Series 1"].Points.AddPoint("İzmir",8);
            chartControl1.Series["Series 1"].Points.AddPoint("Bursa",14);
            chartControl1.Series["Series 1"].Points.AddPoint("Antalya",22); */

            gridControl1.DataSource = db.TBLCARI.OrderBy(x => x.IL).
                GroupBy(y => y.IL).Select(z => new
                { İL = z.Key, TOPLAM = z.Count() }).ToList();

            baglati.Open();
            SqlCommand komut = new SqlCommand("select IL,COUNT(*) FROM TBLCARI group by IL",baglati);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString( dr[0]),int.Parse( dr[1].ToString()));
            }
            baglati.Close();
        }
    }
}
