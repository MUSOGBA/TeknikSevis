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
    public partial class FrmYeniUrun : Form
    {
        public FrmYeniUrun()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {

            TBLURUN t = new TBLURUN();
            t.AD = TxtUrunAd.Text.ToUpper();
            t.MARKA = TxtMarka.Text.ToUpper();
            t.ALISFIYAT = decimal.Parse(TxtAlisFiyat.Text);
            t.SATISFIYAT = decimal.Parse(TxtSatisFiyat.Text);
            t.STOK = short.Parse(TxtStok.Text);
            t.KATEGORI = byte.Parse(lookUpEdit1.EditValue.ToString());
            db.TBLURUN.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Ekleme İşlemi Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }



        private void pictureEdit8_EditValueChanged(object sender, EventArgs e)
        {
            FrmYeniUrun c = new FrmYeniUrun();
            c.Hide();
        }

        private void pictureEdit8_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void TxtUrunAd_EditValueChanged(object sender, EventArgs e)
        {
           
            TxtUrunAd.Focus();
        }

        private void FrmYeniUrun_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.DataSource = (from x in db.TBLKATEGORI
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.AD
                                                 }).ToList();
        }
    }
}
