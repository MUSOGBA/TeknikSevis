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
    public partial class FrmArizaDetaylar : Form
    {
        public FrmArizaDetaylar()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void pictureEdit8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            TBLURUNTAKIP g = new TBLURUNTAKIP();
            g.SERINO = TxtSeriNo.Text;
            g.ACIKLAMA = richTextBox1.Text;
            g.TARIH = DateTime.Parse(TxtTarih.Text);
            db.TBLURUNTAKIP.Add(g);
            db.SaveChanges();


            TBLURUNKABUL g1 = new TBLURUNKABUL();
            int urunid =int.Parse( id);
            var deger = db.TBLURUNKABUL.Find(urunid);
            deger.URUNDURUMDETAY = comboBox1.Text;
            db.SaveChanges();
            MessageBox.Show("Ürün Arıza Detayı Güncellendi");

        }

      

        private void TxtTarih_Click(object sender, EventArgs e)
        {
            TxtTarih.Text = DateTime.Now.ToShortDateString();
        }

        private void TxtSeriNo_Click(object sender, EventArgs e)
        {
            TxtSeriNo.Text = "";
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string id,serino;
        private void FrmArizaDetaylar_Load(object sender, EventArgs e)
        {
            TxtSeriNo.Text = serino;
        }
    }
}
