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
    public partial class FrmDepartman : Form
    {
        public FrmDepartman()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        void metot()
        {
            var degerler = from x in db.TBLDEPARTMAN
                           select new
                           {
                               x.ID,
                               x.AD,
                               x.ACIKLAMA,

                           };
            gridControl1.DataSource = degerler.ToList();
            labelControl12.Text = db.TBLDEPARTMAN.Count().ToString();
            labelControl14.Text = db.TBLPERSONEL.Count().ToString();
            labelControl16.Text = db.maksdepartman().FirstOrDefault();
            labelControl18.Text = db.mindepartman().FirstOrDefault();
        }

        private void FrmDepartman_Load(object sender, EventArgs e)
        {
            metot();
           
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            metot();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLDEPARTMAN k = new TBLDEPARTMAN();

            try
            {
                k.AD = TxtAdi.Text.ToUpper(); ;
                k.ACIKLAMA = RchAcıklama.Text.ToUpper();
                db.TBLDEPARTMAN.Add(k);
                db.SaveChanges();
                MessageBox.Show("Deparman Kayıt İşleminiz Başarılı", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                metot();
            }
            catch (Exception)
            {

                MessageBox.Show(" Departman Adını Düzenleyin", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
          
           
            
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtDepartmanId.Text);
            var deger = db.TBLDEPARTMAN.Find(id);
            db.TBLDEPARTMAN.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Departman Silme İşleminiz Başarılı","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
            metot();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtDepartmanId.Text);
            var deger = db.TBLDEPARTMAN.Find(id);
            deger.AD = TxtAdi.Text;
            deger.ACIKLAMA = RchAcıklama.Text;
            db.SaveChanges();
            MessageBox.Show("Güncelleme İşleminiz Başarılı","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
            metot();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtDepartmanId.Text = "";
            TxtAdi.Text = "";
            RchAcıklama.Text = "";
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtDepartmanId.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtAdi.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
           // RchAcıklama.Text = gridView1.GetFocusedRowCellValue("ACIKLAMA").ToString();

        }
    }
}
