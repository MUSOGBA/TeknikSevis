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
            g.SERINO = TxtSerino.Text;
            g.ACIKLAMA = richTextBox1.Text;
            g.TARIH = DateTime.Parse(Txttarih.Text);
            db.TBLURUNTAKIP.Add(g);
            db.SaveChanges();
            MessageBox.Show("Ürün Arıza Detayı Güncellendi");

        }
    }
}
