using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikSevis.Formlar
{
    public partial class FrmMarkalar : Form
    {
        public FrmMarkalar()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

       

        private void FrmMarkalar_Load(object sender, EventArgs e)
        {
            var degerler = db.TBLURUN.OrderBy(x => x.MARKA).GroupBy(y => y.MARKA).Select(z => new
            {
                Marka = z.Key,
                Toplam_Ürün = z.Count()
            });
            gridControl1.DataSource = degerler.ToList();
            labelControl2.Text = db.TBLURUN.Count().ToString();
            labelControl3.Text = (from x in db.TBLURUN
                                  select x.MARKA).Distinct().Count().ToString();
            labelControl5.Text = (from x in db.TBLURUN
                                  orderby x.SATISFIYAT descending
                                  select x.MARKA).FirstOrDefault();
            labelControl7.Text = "BEKO";
            chartControl1.Series["Series 1"].Points.AddPoint("Beko", 4);
            chartControl1.Series["Series 1"].Points.AddPoint("Arçelik", 2);
            chartControl1.Series["Series 1"].Points.AddPoint("Lenovo", 1);
            chartControl1.Series["Series 1"].Points.AddPoint("Acer", 1);
            chartControl1.Series["Series 1"].Points.AddPoint("Casper", 1);
            chartControl1.Series["Series 1"].Points.AddPoint("Siemens", 2);
            chartControl1.Series["Series 1"].Points.AddPoint("LG", 4);

            chartControl2.Series["Kategoriler"].Points.AddPoint("Buzdolabı", 4);
            chartControl2.Series["Kategoriler"].Points.AddPoint("Laptop", 1);
            chartControl2.Series["Kategoriler"].Points.AddPoint("Su Isıtıcısı",3 );
            chartControl2.Series["Kategoriler"].Points.AddPoint("TV",5 );
            chartControl2.Series["Kategoriler"].Points.AddPoint("Çamaşır Makinası", 4);
            chartControl2.Series["Kategoriler"].Points.AddPoint("Utu", 3);
            chartControl2.Series["Kategoriler"].Points.AddPoint("Fırın", 4);
            

        }

      
    }
}
