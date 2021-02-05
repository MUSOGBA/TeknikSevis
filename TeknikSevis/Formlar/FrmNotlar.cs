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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void FrmNotlar_Load(object sender, EventArgs e)
        {

            gridControl1.DataSource = db.TBLNOTLARIM.Where(x => x.DURUM == false).ToList();
            gridControl2.DataSource = db.TBLNOTLARIM.Where(y => y.DURUM == true).ToList();

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtNotId.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtBaslik.Text = gridView1.GetFocusedRowCellValue("BASLIK").ToString();
            Txtİcerik.Text = gridView1.GetFocusedRowCellValue("ICERIK").ToString();

        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtNotId.Text = gridView2.GetFocusedRowCellValue("ID").ToString();
            TxtBaslik.Text = gridView2.GetFocusedRowCellValue("BASLIK").ToString();
            Txtİcerik.Text = gridView2.GetFocusedRowCellValue("ICERIK").ToString();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLNOTLARIM k = new TBLNOTLARIM();
            k.BASLIK = TxtBaslik.Text.ToUpper();
            k.ICERIK = Txtİcerik.Text.ToUpper();
            k.DURUM = false;
            db.TBLNOTLARIM.Add(k);
            db.SaveChanges();
            MessageBox.Show("Not Kayıt İşlemi BAşarılı", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtNotId.Text = "";
            TxtBaslik.Text = "";
            Txtİcerik.Text = "";
            checkEdit1.Checked = false;
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.TBLNOTLARIM.Where(x => x.DURUM == false).ToList();
            gridControl2.DataSource = db.TBLNOTLARIM.Where(y => y.DURUM == true).ToList();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (checkEdit1.Checked == true)
            {
                int id = int.Parse(TxtNotId.Text);
                var deger = db.TBLNOTLARIM.Find(id);
                deger.DURUM = true;
                deger.BASLIK = TxtBaslik.Text;
                deger.ICERIK = Txtİcerik.Text;
                db.SaveChanges();
                MessageBox.Show("Not Durumu Değiştirildi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtNotId.Text);
            var deger = db.TBLNOTLARIM.Find(id);
            db.TBLNOTLARIM.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Not Silme İşlemi Başarılı","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }

}

