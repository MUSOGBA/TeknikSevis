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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();

        void metot()
        {
            var degerler = from x in db.TBLPERSONEL
                           select new
                           {
                               x.ID,
                               x.AD,
                               x.SOYAD,
                               x.DEPARTMAN,
                               x.FOTOGRAF,
                               x.MAIL,
                               x.TELEFON,
                           };
            gridControl1.DataSource = degerler.ToList();

        }

        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            metot();

            lookUpEdit1.Properties.DataSource = (from x in db.TBLDEPARTMAN
                                                select new
                                                {
                                                    x.ID,
                                                    x.AD,
                                                }).ToList();

            string ad1, soyad1;
            ad1 = db.TBLPERSONEL.First(x => x.ID == 1).AD;
            soyad1 = db.TBLPERSONEL.First(x => x.ID == 1).SOYAD;
            labelControl3.Text = ad1 + " " + soyad1;
            labelControl5.Text = db.TBLPERSONEL.First(x => x.ID == 1).TBLDEPARTMAN.AD;
            labelControl8.Text = db.TBLPERSONEL.First(x => x.ID == 1).MAIL;

            string ad2, soyad2;
            ad2 = db.TBLPERSONEL.First(x => x.ID == 2).AD;
            soyad2 = db.TBLPERSONEL.First(x => x.ID == 2).SOYAD;
            labelControl11.Text = ad2 + " " + soyad2;
            labelControl10.Text = db.TBLPERSONEL.First(x => x.ID == 2).TBLDEPARTMAN.AD;
            labelControl9.Text = db.TBLPERSONEL.First(x => x.ID == 2).MAIL;

            string ad3, soyad3;
            ad3 = db.TBLPERSONEL.First(x => x.ID == 3).AD;
            soyad3 = db.TBLPERSONEL.First(x => x.ID == 3).SOYAD;
            labelControl18.Text = ad3 + " " + soyad3;
            labelControl17.Text = db.TBLPERSONEL.First(x => x.ID == 3).TBLDEPARTMAN.AD;
            labelControl16.Text = db.TBLPERSONEL.First(x => x.ID == 3).MAIL;

            string ad4, soyad4;
            ad4 = db.TBLPERSONEL.First(x => x.ID == 4).AD;
            soyad4 = db.TBLPERSONEL.First(x => x.ID == 4).SOYAD;
            labelControl24.Text = ad4 + " " + soyad4;
            labelControl23.Text = db.TBLPERSONEL.First(x => x.ID == 4).TBLDEPARTMAN.AD;
            labelControl22.Text = db.TBLPERSONEL.First(x => x.ID == 4).MAIL;

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLPERSONEL k = new TBLPERSONEL();
            k.AD = TxtAdi.Text.ToUpper() ;
            k.SOYAD = TxtSoyadi.Text.ToUpper();
            k.DEPARTMAN = byte.Parse(lookUpEdit1.EditValue.ToString());
            k.FOTOGRAF = TxtFotograf.Text.ToUpper();
            k.MAIL = TxtMail.Text.ToUpper();
            k.TELEFON = TxtTelefon.Text.ToUpper();
            db.TBLPERSONEL.Add(k);
            db.SaveChanges();
            MessageBox.Show("Personel Ekleme İşlemi Başarılı","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            metot();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtPersonelId.Text);
            var deger = db.TBLPERSONEL.Find(id);
            db.TBLPERSONEL.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Personel Silme İşlemi Başarılı","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtPersonelId.Text);
            var deger = db.TBLPERSONEL.Find(id);
            deger.AD = TxtAdi.Text;
            deger.SOYAD = TxtSoyadi.Text;
            deger.DEPARTMAN = byte.Parse(lookUpEdit1.EditValue.ToString());
            deger.FOTOGRAF = TxtFotograf.Text;
            deger.MAIL = TxtMail.Text;
            deger.TELEFON = TxtTelefon.Text;
            db.SaveChanges();
            MessageBox.Show("Personel GÜncelleme İşlemi Başarılı", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtAdi.Text = "";
            TxtSoyadi.Text = "";
            TxtFotograf.Text = "";
            lookUpEdit1.EditValue = "";
            TxtMail.Text = "";
            TxtTelefon.Text = "";
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtPersonelId.Text =gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtAdi.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
            TxtSoyadi.Text = gridView1.GetFocusedRowCellValue("SOYAD").ToString();
           // lookUpEdit1 = gridView1.GetFocusedRowCellValue("DEPARTMAN").ToString();
          //  TxtFotograf.Text = gridView1.GetFocusedRowCellValue("FOTOGRAF").ToString();
           TxtMail.Text = gridView1.GetFocusedRowCellValue("MAIL").ToString();
           // TxtTelefon.Text = gridView1.GetFocusedRowCellValue("TELEFON").ToString();
        }
    }
}
