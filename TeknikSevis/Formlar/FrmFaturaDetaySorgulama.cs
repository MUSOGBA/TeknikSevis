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
    public partial class FrmFaturaDetaySorgulama : Form
    {
        public FrmFaturaDetaySorgulama()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void BtnAra_Click(object sender, EventArgs e)
        {
              int id = Convert.ToInt32(TxtFaturaID.Text);

            var degerler = (from i in db.TBLFATURADETAY.Where(y => y.TBLFATURABILGI.SERI == TxtSeriNo.Text & y.TBLFATURABILGI.SIRANO == TxtSiraNo.Text | y.FATURAID == id)

                            select new
                            {
                                i.FATURADETAYID,
                                i.URUN,
                                i.ADET,
                                i.FIYAT,
                                i.TUTAR,
                                i.FATURAID

                            });
            gridControl1.DataSource = degerler.ToList();
        }

        private void FrmFaturaDetay_Load(object sender, EventArgs e)
        {

        }
    }
}
