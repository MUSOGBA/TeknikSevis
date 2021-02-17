using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikSevis
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            var sorgu = from x in db.TBLADMIN
                        where x.KULLANICIAD == TxtKullaniciAdi.Text && x.SIFRE == TxtSifre.Text
                        select x;

            if (sorgu.Any())
            {
                Form1 fr = new Form1();
                fr.Show();
                this.Hide();
            }
            else
            {
                LblHata.Visible = true;
                LblHata.Text = "Kullanıcı Adı veya Şifre Yanlış";
            }
        }
    }
}
