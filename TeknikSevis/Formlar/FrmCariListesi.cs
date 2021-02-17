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
    public partial class FrmCariListesi : Form
    {
        public FrmCariListesi()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        int secilen;

        void temizle()
        {
            TxtCariId.Text = "";
            TxtAdi.Text = "";
            TxtSoyadi.Text = "";
            TxtTelefon.Text = "";
            TxtMail.Text = "";
            TxtBanka.Text = "";
            TxtVDairesi.Text = "";
            TxtVergiNo.Text = "";
            TxtAdres.Text = "";
        }

        void metot1()
        {
            var degerler = from x in db.TBLCARI
                           select new
                           {
                               x.ID,
                               x.AD,
                               x.SOYAD,
                               x.IL,
                               x.ILCE,

                           };
            gridControl1.DataSource = degerler.ToList();

            labelControl12.Text = db.TBLCARI.Count().ToString();


            lookUpEdit1.Properties.DataSource = (from x in db.TBLILLER
                                                 select new
                                                 {
                                                     x.id,
                                                     x.sehir,
                                                 }).ToList();

            labelControl16.Text = db.TBLCARI.Select(x => x.IL).Distinct().Count().ToString();
            labelControl14.Text = db.TBLCARI.Select(x => x.ILCE).Distinct().Count().ToString();
            labelControl18.Text = db.maksil().FirstOrDefault();

        }

        private void FrmCariListesi_Load(object sender, EventArgs e)
        {
           
            metot1();
        }





        private void gridView1_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtCariId.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtAdi.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            TxtSoyadi.Text = gridView1.GetFocusedRowCellValue("SOYAD").ToString();
            lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("IL").ToString();
            lookUpEdit2.Text = gridView1.GetFocusedRowCellValue("ILCE").ToString();
          
            /*   TxtTelefon.Text = gridView1.GetFocusedRowCellValue("TELEFON").ToString();
               TxtMail.Text = gridView1.GetFocusedRowCellValue("MAIL").ToString();
               TxtBanka.Text = gridView1.GetFocusedRowCellValue("BANKA").ToString();
               TxtVDairesi.Text = gridView1.GetFocusedRowCellValue("V.DAIRESI").ToString();
               TxtVergiNo.Text = gridView1.GetFocusedRowCellValue("VERGINO").ToString();
               TxtStatü.Text = gridView1.GetFocusedRowCellValue("STATU").ToString();
               TxtAdres.Text = gridView1.GetFocusedRowCellValue("ADRES").ToString();*/
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtAdi.Text != "" && TxtSoyadi.Text != "")
            {
                TBLCARI k = new TBLCARI();
                k.AD = TxtAdi.Text.ToUpper();
                k.SOYAD = TxtSoyadi.Text.ToUpper();
                k.TELEFON = TxtTelefon.Text.ToUpper();
                k.MAIL = TxtMail.Text.ToUpper();
                k.IL = lookUpEdit1.Text;
                k.ILCE = lookUpEdit2.Text;
                k.BANKA = TxtBanka.Text.ToUpper();
                k.VERGIDAIRESI = TxtVDairesi.Text.ToUpper();
                k.VERGINO = TxtVergiNo.Text.ToUpper();
                k.STATU = TxtStatü.Text.ToUpper();
                k.ADRES = TxtAdres.Text.ToUpper();
                db.TBLCARI.Add(k);
                db.SaveChanges();
                MessageBox.Show("Cari Ekleme İşlemi Başarılı", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                metot1();
            }
            else
            {
                MessageBox.Show("Cari Ekleme İşlemi İçin Gerekli Yerleri Doldurunuz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtCariId.Text);
            var deger = db.TBLCARI.Find(id);
            db.TBLCARI.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Cari Silme İşlemi Başarılı", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            metot1();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtCariId.Text);
            var deger = db.TBLCARI.Find(id);
            deger.AD = TxtAdi.Text;
            deger.SOYAD = TxtSoyadi.Text;
            deger.TELEFON = TxtTelefon.Text;
            deger.MAIL = TxtMail.Text;
            deger.IL = lookUpEdit1.Text;
            deger.ILCE = lookUpEdit2.Text;
            deger.BANKA = TxtBanka.Text;
            deger.VERGIDAIRESI = TxtVDairesi.Text;
            deger.VERGINO = TxtVergiNo.Text;
            deger.STATU = TxtStatü.Text;
            deger.ADRES = TxtAdres.Text;
            db.SaveChanges();
            MessageBox.Show("Cari Güncelleme İşlemi Başarılı", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            metot1();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            metot1();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            secilen = int.Parse(lookUpEdit1.EditValue.ToString());

            lookUpEdit2.Properties.DataSource = (from y in db.TBLILCELER
                                                select new
                                                {
                                                    y.id,
                                                    y.ilce,
                                                    y.sehir
                                                }).Where(z=>z.sehir==secilen).ToList();
        }
    }
}
