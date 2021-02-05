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
    public partial class FrmYeniKategori : Form
    {
        public FrmYeniKategori()
        {
            InitializeComponent();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            DbTeknikServisEntities db = new DbTeknikServisEntities();
            TBLKATEGORI k = new TBLKATEGORI();
            k.AD = TxtKategoriAd.Text;
            db.TBLKATEGORI.Add(k);
            db.SaveChanges();
            MessageBox.Show("Kategori Ekleme İşlemi Başarılı","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureEdit8_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}
