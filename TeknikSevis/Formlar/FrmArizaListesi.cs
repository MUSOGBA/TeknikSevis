﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TeknikSevis.Formlar
{
    public partial class FrmArizaListesi : Form
    {
        public FrmArizaListesi()
        {
            InitializeComponent();
        }

        DbTeknikServisEntities db = new DbTeknikServisEntities();

        private void FrmArizaListesi_Load(object sender, EventArgs e)
        {
            var degerler = from x in db.TBLURUNKABUL
                           select new
                           {
                               x.ISLEMID,
                               CARİ = x.TBLCARI.AD +" "+ x.TBLCARI.SOYAD,
                               PERSONEL = x.TBLPERSONEL.AD +" "+ x.TBLPERSONEL.SOYAD,
                               x.GELISTARIH,
                               x.CIKISTARIH,
                               x.URUNSERINO
                              
                           };
            gridControl1.DataSource = degerler.ToList();
            labelControl7.Text = db.TBLURUNKABUL.Count(x => x.URUNDURUM == true).ToString();
            labelControl3.Text = db.TBLURUNKABUL.Count(x => x.URUNDURUM == false).ToString();
            labelControl5.Text = db.TBLURUNKABUL.Count(x => x.URUNDURUMDETAY == "Parça Bekliyor").ToString();
            labelControl13.Text = db.TBLURUNKABUL.Count(x => x.URUNDURUMDETAY == "Mesaj Bekliyor").ToString();
            labelControl11.Text = db.TBLURUNKABUL.Count(x => x.URUNDURUMDETAY == "İptal Bekliyor").ToString();
            labelControl15.Text = db.TBLURUN.Count().ToString();

            
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-N5F5PJT;Initial Catalog=DbTeknikServis;Integrated Security=True");

            baglanti.Open();

            SqlCommand komut = new SqlCommand("SELECT URUNDURUMDETAY,COUNT(*) FROM TBLURUNKABUL GROUP BY URUNDURUMDETAY", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            baglanti.Close();
            
        }
    }
}
