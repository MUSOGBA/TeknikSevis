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
            TxtUrunId.Text = "Ürün ID";
            TxtMusteri.Text = "Müşteri";
            TxtPersonel.Text = "Personel";
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
            k.URUN = int.Parse(TxtUrunId.Text);
            k.MUSTERI = int.Parse(TxtMusteri.Text);
            k.PERSONEL = short.Parse(TxtPersonel.Text);
            k.TARIH =DateTime.Parse( TxtTarih.Text);
            k.ADET = short.Parse(TxtAdet.Text);
            k.FIYAT = decimal.Parse(TxtSatisFiyati.Text);
            k.URUNSERINO = TxtSeriNo.Text;
            db.TBLURUNHAREKET.Add(k);
            db.SaveChanges();
            MessageBox.Show("Satış İşlemi Başarılı","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
            temizle();


        }
    }
}
