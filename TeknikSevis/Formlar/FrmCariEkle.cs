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
    public partial class FrmCariEkle : Form
    {
        public FrmCariEkle()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        int secilen;

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                TBLCARI t = new TBLCARI();
                t.AD = TxtAd.Text.ToUpper();
                t.SOYAD = TxtSoyad.Text.ToUpper();
                t.TELEFON = TxtTelefon.Text.ToUpper();
                t.MAIL = TxtMail.Text.ToUpper();
                t.IL = lookUpEdit1.Text.ToUpper();
                t.ILCE = lookUpEdit2.Text.ToUpper();
                t.BANKA = TxtBanka.Text.ToUpper();
                t.VERGIDAIRESI = TxtVergiDairesi.Text.ToUpper();
                t.VERGINO = TxtVergiNo.Text.ToUpper();
                t.STATU = TxtStatu.Text.ToUpper();
                t.ADRES = TxtAdres.Text.ToUpper();
                db.TBLCARI.Add(t);
                db.SaveChanges();
                MessageBox.Show("Cari ekleme işlemi başarılı", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Cari ekleme işlemi için gerekli yerleri doldurunuz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            

        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureEdit14_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void FrmCariEkle_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.DataSource = (from x in db.TBLILLER
                                                 select new
                                                 {
                                                     x.id,
                                                     x.sehir

                                                 }).ToList();
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            secilen = int.Parse(lookUpEdit1.EditValue.ToString());
            lookUpEdit2.Properties.DataSource = (from y in db.TBLILCELER.Where(z=>z.sehir==secilen)
                                                select new
                                                {

                                                    y.id,
                                                    y.ilce

                                                }).ToList();
        }
    }
}
