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
    public partial class FrmFaturaKalem : Form
    {
        public FrmFaturaKalem()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        void listele()
        {
            var deger = from x in db.TBLFATURADETAY
                        select new
                        {
                            x.FATURADETAYID,
                            x.URUN,
                            x.ADET,
                            x.FIYAT,
                            x.TUTAR,
                            x.FATURAID
                        };
            gridControl1.DataSource = deger.ToList();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                TBLFATURADETAY k = new TBLFATURADETAY();
                k.URUN = TxtUrun.Text;
                k.ADET = short.Parse(TxtAdet.Text);
                k.FIYAT = decimal.Parse(TxtFiyat.Text);
                k.TUTAR = (k.ADET * k.FIYAT);
                k.FATURAID = int.Parse(TxtFaturaId.Text);
                db.TBLFATURADETAY.Add(k);
                db.SaveChanges();
                MessageBox.Show("Kalem Kayıt İşlemi Başarılı", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
            catch (Exception)
            {

                MessageBox.Show("Kalem Kayıt İşlemi İçin Gerekli Yerleri Doldurunuz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            

        }

        private void FrmFaturaKalem_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtDetayId.Text = gridView1.GetFocusedRowCellValue("FATURADETAYID").ToString();
            TxtUrun.Text = gridView1.GetFocusedRowCellValue("URUN").ToString();
            TxtAdet.Text = gridView1.GetFocusedRowCellValue("ADET").ToString();
            TxtFiyat.Text = gridView1.GetFocusedRowCellValue("FIYAT").ToString();
            TxtTutar.Text = gridView1.GetFocusedRowCellValue("TUTAR").ToString();
            TxtFaturaId.Text = gridView1.GetFocusedRowCellValue("FATURAID").ToString();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtDetayId.Text = "";
            TxtUrun.Text = "";
            TxtAdet.Text = "";
            TxtFiyat.Text = "";
            TxtTutar.Text = "";
            TxtFaturaId.Text = "";
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtDetayId.Text);
            var deger = db.TBLFATURADETAY.Find(id);
            deger.URUN = TxtUrun.Text;
            deger.ADET =short.Parse( TxtAdet.Text);
            deger.FIYAT =decimal.Parse( TxtFiyat.Text);
            deger.TUTAR = (deger.ADET * deger.FIYAT);
            deger.FATURAID =int.Parse( TxtFaturaId.Text);
            db.SaveChanges();
            MessageBox.Show("Kalem Güncelleme İşlemi Başarılı", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtDetayId.Text);
            var deger = db.TBLFATURADETAY.Find(id);
            db.TBLFATURADETAY.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Kalem Silme İşlemi Başarılı", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }
    }
}
