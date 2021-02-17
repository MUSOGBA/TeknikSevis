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
    public partial class FrmFaturaListesi : Form
    {
        public FrmFaturaListesi()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        void temizle()
        {
            TxtFaturaId.Text = "";
            TxtSeri.Text = "";
            TxtSiraNo.Text = "";
            TxtTarih.Text = "";
            TxtVergiDairesi.Text = "";
            lookUpEdit1.Text = "";
            lookUpEdit2.Text = "";
       
        }

        void listele()
        {
            var deger = from x in db.TBLFATURABILGI
                        select new
                        {
                            x.ID,
                            x.SERI,
                            x.SIRANO,
                            x.TARIH,
                            x.VERGIDAIRE,
                            CARI = x.TBLCARI.AD + " " + x.TBLCARI.SOYAD,
                            PERSONEL = x.TBLPERSONEL.AD + " " + x.TBLPERSONEL.SOYAD
                        };
            gridControl1.DataSource = deger.ToList();

            lookUpEdit1.Properties.DataSource = (from x in db.TBLCARI
                                                 select new
                                                 {
                                                     x.ID,
                                                     ADI = x.AD + " " + x.SOYAD,
                                                 }).ToList();

            lookUpEdit2.Properties.DataSource = (from x in db.TBLPERSONEL
                                                 select new
                                                 {
                                                     x.ID,
                                                     ADI = x.AD + " " + x.SOYAD,
                                                 }).ToList();
        }

    
        private void FrmFaturaListesi_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {

            listele();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                TBLFATURABILGI t = new TBLFATURABILGI();
                t.SERI = TxtSeri.Text;
                t.SIRANO = TxtSiraNo.Text;
                t.TARIH = DateTime.Parse(TxtTarih.Text);
                t.VERGIDAIRE = TxtVergiDairesi.Text;
                t.CARI = int.Parse(lookUpEdit1.EditValue.ToString());
                t.PERSONEL = short.Parse(lookUpEdit1.EditValue.ToString());
                db.TBLFATURABILGI.Add(t);
                db.SaveChanges();
                MessageBox.Show("Fatura Kayıt İşlemi Başarılı", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
            catch (Exception)
            {

                MessageBox.Show("Fatura Kayıt İşlemi İçin Gerekli YErleri Doldurunuz!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            

        }

        

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtFaturaId.Text);
            var deger = db.TBLFATURABILGI.Find(id);
            deger.SERI = TxtSeri.Text;
            deger.SIRANO = TxtSiraNo.Text;
            deger.TARIH = DateTime.Parse(TxtTarih.Text);
            deger.VERGIDAIRE = TxtVergiDairesi.Text;
            deger.CARI = int.Parse(lookUpEdit1.EditValue.ToString());
            deger.PERSONEL = short.Parse(lookUpEdit2.EditValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Fatura Güncellemesi Gerçekleştirildi","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtFaturaId.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtSeri.Text = gridView1.GetFocusedRowCellValue("SERI").ToString();
            TxtSiraNo.Text = gridView1.GetFocusedRowCellValue("SIRANO").ToString();
            TxtTarih.Text = gridView1.GetFocusedRowCellValue("TARIH").ToString();
            TxtVergiDairesi.Text = gridView1.GetFocusedRowCellValue("VERGIDAIRE").ToString();
            lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("CARI").ToString();
            lookUpEdit2.Text = gridView1.GetFocusedRowCellValue("PERSONEL").ToString();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaKalemPopup fr = new FrmFaturaKalemPopup();
            fr.id =int.Parse( gridView1.GetFocusedRowCellValue("ID").ToString());
            fr.Show();
        }
    }
}
