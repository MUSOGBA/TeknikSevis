﻿using System;
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
    public partial class FrmUrunListesi : Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        void temizle()
        {
            TxtId.Text = "";
            TxtUrunAdi.Text = "";
            TxtMarka.Text = "";
            TxtAlisFiyat.Text = "";
            TxtSatisFiyat.Text = "";
            lookUpEdit1.EditValue = " ";
            TxtStok.Text = "";
        }

        void metot1()
        {
            var degerler = from u in db.TBLURUN
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.MARKA,
                               u.STOK,
                               KATEGORI = u.TBLKATEGORI.AD,
                               u.ALISFIYAT,
                               u.SATISFIYAT

                           };
            gridControl1.DataSource = degerler.ToList();
            lookUpEdit1.Properties.DataSource = (from x in db.TBLKATEGORI
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.AD,
                                                 }).ToList();

            
        }

        private void FrmUrunListesi_Load(object sender, EventArgs e)
        {
            // Listele ToList Add Remove

            metot1();



        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                TBLURUN t = new TBLURUN();
                t.AD = TxtUrunAdi.Text.ToUpper();
                t.MARKA = TxtMarka.Text;
                t.ALISFIYAT = decimal.Parse(TxtAlisFiyat.Text.ToUpper());
                t.SATISFIYAT = decimal.Parse(TxtSatisFiyat.Text.ToUpper());
                t.STOK = short.Parse(TxtStok.Text.ToUpper());
                t.DURUM = false;
                t.KATEGORI = byte.Parse(lookUpEdit1.EditValue.ToString().ToUpper());
                db.TBLURUN.Add(t);
                db.SaveChanges();
                MessageBox.Show("Ürün ekleme İşleminiz Başarıyla Gerçekleştirilmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                metot1();
            }
            catch (Exception)
            {
                MessageBox.Show("Ürün ekleme İşleminiz İçin Gerekli Yerleri Doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
         

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {

            metot1();
           

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                TxtId.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                TxtUrunAdi.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
                TxtMarka.Text = gridView1.GetFocusedRowCellValue("MARKA").ToString();
                TxtAlisFiyat.Text = gridView1.GetFocusedRowCellValue("ALISFIYAT").ToString();
                TxtSatisFiyat.Text = gridView1.GetFocusedRowCellValue("SATISFIYAT").ToString();
                TxtStok.Text = gridView1.GetFocusedRowCellValue("STOK").ToString();
                lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("KATEGORI").ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("HATA", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var deger = db.TBLURUN.Find(id);
            db.TBLURUN.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Ürün silme işlemi başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            metot1();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var deger = db.TBLURUN.Find(id);
            deger.AD = TxtUrunAdi.Text;
            deger.MARKA = TxtMarka.Text;
            deger.ALISFIYAT = decimal.Parse(TxtAlisFiyat.Text);
            deger.SATISFIYAT = decimal.Parse(TxtSatisFiyat.Text);
            deger.STOK = short.Parse(TxtStok.Text);
            deger.KATEGORI = byte.Parse(lookUpEdit1.EditValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Ürün güncelleme işlemi başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            metot1();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
