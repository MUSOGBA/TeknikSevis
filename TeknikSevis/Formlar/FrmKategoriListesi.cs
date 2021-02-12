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
    public partial class FrmKategoriListesi : Form
    {
        public FrmKategoriListesi()
        {
            InitializeComponent();
        }

        void temizle()
        {
            TxtId.Text = "";
            TxtKategoriAdi.Text = "";
        }

        void metot1()
        {
            var degerler = from k in db.TBLKATEGORI
                           select new
                           {
                               k.ID,
                               k.AD,
                           };

            gridControl1.DataSource = degerler.ToList();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void FrmKategori_Load(object sender, EventArgs e)
        {
            metot1();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtKategoriAdi.Text != "" && TxtKategoriAdi.Text.Length <= 30)
            {
                TBLKATEGORI k = new TBLKATEGORI();
                k.AD = TxtKategoriAdi.Text.ToUpper();
                db.TBLKATEGORI.Add(k);
                db.SaveChanges();
                MessageBox.Show("Kategori kayıt işlemi başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kategori Adı Boş ve Belirlenen Karakter Sayısından Fazla", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            metot1();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtId.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtKategoriAdi.Text = gridView1.GetFocusedRowCellValue("AD").ToString().ToUpper();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
          DialogResult secim=  MessageBox.Show("Kategori Silme İşlemi İçin Emin Misiniz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (secim==DialogResult.Yes)
            {
                int id = int.Parse(TxtId.Text.ToUpper());
                var deger = db.TBLKATEGORI.Find(id);
                db.TBLKATEGORI.Remove(deger);
                db.SaveChanges();
                MessageBox.Show("Kategori Silme İşlemi Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kategori Silme İşlemi İptal Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          
            
           
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var deger = db.TBLKATEGORI.Find(id);
            deger.AD = TxtKategoriAdi.Text.ToUpper();
            db.SaveChanges();
            MessageBox.Show("Kategori Güncelleme İşlemi Başarılı","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
           }
    }
}
