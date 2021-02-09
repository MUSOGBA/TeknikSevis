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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Formlar.FrmUrunListesi fr1;
        private void BtnUrunListesiFormu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr1 == null || fr1.IsDisposed)
            {
                fr1 = new Formlar.FrmUrunListesi();
                fr1.MdiParent = this;
                fr1.Show();
            }
        }
        Formlar.FrmYeniUrun fr2;
        private void BtnYeniUrun_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr2 == null || fr2.IsDisposed)
            {
                fr2 = new Formlar.FrmYeniUrun();
                fr2.Show();
            }
        }
        Formlar.FrmKategoriListesi fr3;
        private void BtnKategoriListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr3 == null || fr3.IsDisposed)
            {
                fr3 = new Formlar.FrmKategoriListesi();
                fr3.MdiParent = this;
                fr3.Show();
            }
        }
        Formlar.FrmYeniKategori fr4;
        private void BtnYeniKategori_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr4 == null || fr4.IsDisposed)
            {
                fr4 = new Formlar.FrmYeniKategori();
                fr4.Show();
            }
        }
        Formlar.FrmIstatistik fr5;
        private void BtnIstatistik_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr5 == null || fr5.IsDisposed)
            {
                fr5 = new Formlar.FrmIstatistik();
                fr5.MdiParent = this;
                fr5.Show();
            }
        }
        Formlar.FrmMarkalar fr6;
        private void BtnMarkaIstatistik_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr6 == null || fr6.IsDisposed)
            {
                fr6 = new Formlar.FrmMarkalar();
                fr6.MdiParent = this;
                fr6.Show();
            }
        }
        Formlar.FrmCariListesi fr7;
        private void BtnCariListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr7 == null || fr7.IsDisposed)
            {
                fr7 = new Formlar.FrmCariListesi();
                fr7.MdiParent = this;
                fr7.Show();
            }
        }
        Formlar.FrmCariIller fr8;
        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr8 == null || fr8.IsDisposed)
            {
                fr8 = new Formlar.FrmCariIller();
                fr8.MdiParent = this;
                fr8.Show();
            }
        }
        Formlar.FrmCariEkle fr9;
        private void BtnYeniCari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr9 == null || fr9.IsDisposed)
            {
                fr9 = new Formlar.FrmCariEkle();

                fr9.Show();
            }
        }
        Formlar.FrmDepartman fr10;
        private void BtnDepartmanListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr10 == null || fr10.IsDisposed)
            {
                fr10 = new Formlar.FrmDepartman();
                fr10.MdiParent = this;
                fr10.Show();
            }
        }
        Formlar.FrmYeniDepartman fr11;
        private void BtnYeniDepartman_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr11 == null || fr11.IsDisposed)
            {
                fr11 = new Formlar.FrmYeniDepartman();
                fr11.Show();
            }
        }
        Formlar.FrmPersonel fr12;
        private void BtnPersonelListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr12 == null || fr12.IsDisposed)
            {
                fr12 = new Formlar.FrmPersonel();
                fr12.MdiParent = this;
                fr12.Show();
            }
        }

        private void BtnHesapMakinesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void BtnYeniNot_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        Formlar.FrmKurlar fr13;
        private void BtnKurlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr13 == null || fr13.IsDisposed)
                fr13 = new Formlar.FrmKurlar();
            fr13.MdiParent = this;
            fr13.Show();
        }

        private void BtnWord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("winword");
        }

        private void BtnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("excel");
        }
        Formlar.FrmYouTube fr14;
        private void BtnYouTube_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr14 == null || fr14.IsDisposed)
            {
                fr14 = new Formlar.FrmYouTube();
                fr14.MdiParent = this;
                fr14.Show();

            }
        }
        Formlar.FrmNotlar fr15;
        private void BtnNotListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr15 == null || fr15.IsDisposed)
            {
                fr15 = new Formlar.FrmNotlar();
                fr15.MdiParent = this;
                fr15.Show();
            }
        }

        Formlar.FrmArizaListesi fr16;
        private void BtnArizaListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr16 == null || fr16.IsDisposed)
            {
                fr16 = new Formlar.FrmArizaListesi();
                fr16.MdiParent = this;
                fr16.Show();
            }
        }

        Formlar.FrmUrunSatis fr17;
        private void BtnYeniUrunSatisi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr17 == null || fr17.IsDisposed)
            {
                fr17 = new Formlar.FrmUrunSatis();

                fr17.Show();
            }
        }

        Formlar.FrmSatisListesi fr18;
        private void BtnSatisListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr18 == null || fr18.IsDisposed)
            {
                fr18 = new Formlar.FrmSatisListesi();
                fr18.MdiParent = this;
                fr18.Show();
            }
        }

        Formlar.FrmArizaliUrunKaydi fr19;
        private void BtnYeniArizaliUrunKaydi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr19 == null || fr19.IsDisposed)
            {
                fr19 = new Formlar.FrmArizaliUrunKaydi();
                fr19.Show();
            }
        }

        Formlar.FrmArizaDetaylar fr20;
        private void BtnArizalıUrunAciklama_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr20 == null || fr20.IsDisposed)
            {
                fr20 = new Formlar.FrmArizaDetaylar();
                fr20.Show();
            }
        }

        Formlar.FrmArizaliUrunDetayListesi fr21;
        private void BtnArizaliDetay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr21 == null || fr21.IsDisposed)
            {
                fr21 = new Formlar.FrmArizaliUrunDetayListesi();
                fr21.MdiParent = this;
                fr21.Show();
            }
        }

        Formlar.FrmQRCode fr22;
        private void BtnQRCodeOlustur_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (fr22 == null || fr22.IsDisposed)
            {
                fr22 = new Formlar.FrmQRCode();
                fr22.Show();
            }

        }
        Formlar.FrmFaturaListesi fr23;
        private void BtnFaturaListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr23 == null || fr23.IsDisposed)
            {
                fr23 = new Formlar.FrmFaturaListesi();
                fr23.MdiParent = this;
                fr23.Show();
            }
        }

        Formlar.FrmFaturaKalem fr24;
        private void BtnFaturaKalem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr24 == null || fr24.IsDisposed)
            {
                fr24 = new Formlar.FrmFaturaKalem();
                fr24.MdiParent = this;
                fr24.Show();
            }
        }

        Formlar.FrmFaturaDetaySorgulama fr25;
        private void BtnDetayliFaturaSorgulama_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr25 == null || fr25.IsDisposed)
            {
                fr25 = new Formlar.FrmFaturaDetaySorgulama();
                fr25.MdiParent = this;
                fr25.Show();
            }
        }

        Formlar.FrmGauge fr26;
        private void BtnGauge_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr26==null||fr26.IsDisposed)
            {
                fr26 = new Formlar.FrmGauge();
                fr26.MdiParent = this;
                fr26.Show();
            }
        }

        Formlar.FrmHaritalar fr27;
        private void BtnHaritalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr27==null||fr27.IsDisposed)
            {
                fr27 = new Formlar.FrmHaritalar();
                fr27.MdiParent = this;
                fr27.Show();
            }


        }
    }
}
