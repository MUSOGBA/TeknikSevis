using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikSevis.İletişim
{
    public partial class FrmGelenMesajlar : Form
    {
        public FrmGelenMesajlar()
        {
            InitializeComponent();
        }

        void listele()
        {
            labelControl12.Text = db.TBLILETISIM.Count().ToString();
            labelControl14.Text = db.TBLILETISIM.Where(x => x.KONU == "TEŞEKKÜR").Count().ToString();
            labelControl16.Text = db.TBLILETISIM.Where(x => x.KONU == "ŞİKAYET").Count().ToString();
            labelControl18.Text = db.TBLILETISIM.Where(x => x.KONU == "İSTEK").Count().ToString();

            labelControl1.Text = db.TBLPERSONEL.Count().ToString();
            labelControl3.Text = db.TBLCARI.Count().ToString();
            labelControl5.Text = db.TBLKATEGORI.Count().ToString();
            labelControl7.Text = db.TBLURUN.Count().ToString();
            labelControl9.Text = db.TBLDEPARTMAN.Count().ToString();

            gridControl1.DataSource = (from x in db.TBLILETISIM
                                       select new
                                       {
                                           x.ID,
                                           x.ADSOYAD,
                                           x.MAIL,
                                           x.KONU,
                                           x.MESAJ
                                       }).ToList();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void FrmGelenMesajlar_Load(object sender, EventArgs e)
        {
            listele(); 
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
