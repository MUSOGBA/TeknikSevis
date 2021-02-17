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
    public partial class FrmUrunSatis : Form
    {
        public FrmUrunSatis()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        void temizle()
        {
            LkpId.Text = "Ürün ID";
            LkpMusteri.Text = "Müşteri";
            LkpMusteri.Text = "Personel";
            TxtTarih.Text = "TArih";
            TxtAdet.Text = "Adet";
            TxtSatisFiyati.Text = "Satış Fiyatı";
            TxtSeriNo.Text = "Seri No";
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureEdit8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSatisYap_Click(object sender, EventArgs e)
        {
            TBLURUNHAREKET k = new TBLURUNHAREKET();
            k.URUN = int.Parse(LkpId.EditValue.ToString());
            k.MUSTERI = int.Parse(LkpMusteri.EditValue.ToString());
            k.PERSONEL = short.Parse(LkpPersonel.EditValue.ToString());
            k.TARIH = DateTime.Parse(TxtTarih.Text);
            k.ADET = short.Parse(TxtAdet.Text);
            k.FIYAT = decimal.Parse(TxtSatisFiyati.Text);
            k.URUNSERINO = TxtSeriNo.Text;
            db.TBLURUNHAREKET.Add(k);
            db.SaveChanges();
            MessageBox.Show("Satış İşlemi Başarılı", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            temizle();


        }

        private void FrmUrunSatis_Load(object sender, EventArgs e)
        {
            LkpId.Properties.DataSource = (from x in db.TBLURUN
                                           select new
                                           {
                                               x.ID,
                                               x.AD,
                                           }).ToList();

            LkpMusteri.Properties.DataSource = (from x in db.TBLCARI
                                                select new
                                                {
                                                    x.ID,
                                                    AD = x.AD + " " + x.SOYAD

                                                }).ToList();

            LkpPersonel.Properties.DataSource = (from x in db.TBLPERSONEL
                                                select new
                                                {
                                                    x.ID,
                                                    AD = x.AD + " " + x.SOYAD

                                                }).ToList();
        }

       
    }
}
