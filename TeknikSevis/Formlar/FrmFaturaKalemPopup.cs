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
    public partial class FrmFaturaKalemPopup : Form
    {
        public FrmFaturaKalemPopup()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        public int id;
        private void FrmFaturaKalemPopup_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TBLFATURADETAY
                                      select new
                                      {
                                          x.FATURADETAYID,
                                          x.URUN,
                                          x.ADET,
                                          x.FIYAT,
                                          x.TUTAR,
                                          x.FATURAID
                                      }).Where(y=>y.FATURAID==id).ToList();

            gridControl2.DataSource = (from z in db.TBLFATURABILGI.Where(y => y.ID== id)
                                       select new
                                      {
                                         z.ID,
                                         z.PERSONEL,
                                         z.SERI,
                                         z.SIRANO,
                                         z.TARIH,
                                         z.VERGIDAIRE,
                                         z.CARI
                                         
                                      }).ToList();
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureEdit4_Click(object sender, EventArgs e)
        {
            string path = "C:/Users/MOBAK/source/repos/TeknikSevis/export/Pdf/Dosya1.pdf";
            gridControl1.ExportToPdf(path);
        }

        private void pictureEdit2_Click(object sender, EventArgs e)
        {
            string path = "C:/Users/MOBAK/source/repos/TeknikSevis/export/Excel/Dosya1.xls";
            gridControl1.ExportToXls(path);
        }

        private void pictureEdit3_Click(object sender, EventArgs e)
        {
            string path = "C:/Users/MOBAK/source/repos/TeknikSevis/export/Word/Dosya1.docx";
            gridControl1.ExportToDocx(path);
           
        }

        private void pictureEdit5_Click(object sender, EventArgs e)
        {
            string path = "C:/Users/MOBAK/source/repos/TeknikSevis/export/Html/Dosya1.html";
            gridControl1.ExportToHtml(path);
        }
    }
}
