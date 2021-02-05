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

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLCARI t = new TBLCARI();
            t.AD = TxtAd.Text.ToUpper();
            t.SOYAD = TxtSoyad.Text.ToUpper();
            t.TELEFON = TxtTelefon.Text.ToUpper();
            t.MAIL = TxtMail.Text.ToUpper();
            t.IL = TxtIl.Text.ToUpper();
            t.ILCE = TxtIlce.Text.ToUpper();
            t.BANKA = TxtBanka.Text.ToUpper();
            t.VERGIDAIRESI = TxtVergiDairesi.Text.ToUpper();
            t.VERGINO = TxtVergiNo.Text.ToUpper();
            t.STATU = TxtStatu.Text.ToUpper();
            t.ADRES = TxtAdres.Text.ToUpper();
            db.TBLCARI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Cari ekleme işlemi başarılı","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
            
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureEdit14_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}
