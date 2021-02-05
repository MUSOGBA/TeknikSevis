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
    public partial class FrmArizaliUrunKaydi : Form
    {
        public FrmArizaliUrunKaydi()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureEdit8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGetir_Click(object sender, EventArgs e)
        {
            var getir = db.TBLURUNHAREKET.SingleOrDefault(x => x.URUNSERINO == TxtSeriNo.Text);

            if (getir != null)
            {
                TxtMusteriId.Text = getir.TBLCARI.ID.ToString();
                TxtPersonel.Text = getir.TBLPERSONEL.ID.ToString();
                TxtTarih.Text = getir.TARIH.ToString();
            }
            else
            {
                MessageBox.Show("Girmiş Olduğunuz Seir Numarası Herhangi Bir Ürün İle İlişkilendirlemedi.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void BtnKayitOlustur_Click(object sender, EventArgs e)
        {
            TBLURUNKABUL k = new TBLURUNKABUL();
            k.CARI = int.Parse(TxtMusteriId.Text);
            k.PERSONEL = short.Parse(TxtPersonel.Text);
            k.GELISTARIH =DateTime.Parse( TxtTarih.Text);
            k.URUNSERINO = TxtSeriNo.Text;
            db.TBLURUNKABUL.Add(k);
            db.SaveChanges();
            MessageBox.Show("Arıza Kayıt İşleminiz Başarılı Bir Şekilde Gerçekleştirilmiştir","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }
    }
}
