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
    public partial class FrmYeniDepartman : Form
    {
        public FrmYeniDepartman()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void pictureEdit8_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLDEPARTMAN d = new TBLDEPARTMAN();
            if (TxtDepartmanAd.Text.Length<=50 && TxtDepartmanAd.Text !=null )
            {
                d.AD = TxtDepartmanAd.Text;
                db.TBLDEPARTMAN.Add(d);
                db.SaveChanges();
                MessageBox.Show("Deparman Ekleme İşlemi Başarılı", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Deparman Alanınnı Lütfen Kontrol Ediniz!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
          

        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
