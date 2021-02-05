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
                               x.TELEFON,
                               x.MAIL,
                               x.IL,
                               x.ILCE,
                               x.BANKA,
                               x.VERGIDAIRESI,
                               x.VERGINO,
                               x.STATU,
                               x.ADRES


                           };
            gridControl1.DataSource = degerler.ToList();
            //lookUpEdit3.Properties.DataSource=db.tb
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
            TBLCARI k = new TBLCARI();
            k.AD = TxtAdi.Text;
            k.SOYAD = TxtSoyadi.Text;
            k.TELEFON = TxtTelefon.Text;
            k.MAIL = TxtMail.Text;
            k.BANKA = TxtBanka.Text;
            k.VERGIDAIRESI = TxtVDairesi.Text;
            k.VERGINO = TxtVergiNo.Text;
            k.STATU = TxtStatü.Text;
            k.ADRES = TxtAdres.Text;
            db.TBLCARI.Add(k);
            db.SaveChanges();
            MessageBox.Show("Cari Ekleme İşlemi BAşarılı","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
          
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtCariId.Text);
            var deger = db.TBLCARI.Find(id);
            db.TBLCARI.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Cari Silme İşlemi Başarılı","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtCariId.Text);
            var deger = db.TBLCARI.Find(id);
            deger.AD = TxtAdi.Text;
            deger.SOYAD = TxtSoyadi.Text;
            deger.TELEFON = TxtTelefon.Text;
            deger.MAIL = TxtMail.Text;
            deger.BANKA = TxtBanka.Text;
            deger.VERGIDAIRESI = TxtVDairesi.Text;
            deger.VERGINO = TxtVergiNo.Text;
            deger.STATU = TxtStatü.Text;
            deger.ADRES = TxtAdres.Text;
            db.SaveChanges();
            MessageBox.Show("Cari Güncelleme İşlemi Başarılı","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            metot1();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
