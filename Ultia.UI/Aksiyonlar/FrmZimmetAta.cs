using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ultia.DAL.DAL;
using Ultia.DTO;
using Ultia.DTO.DTOs;

namespace Ultia.UI
{
    public partial class FrmZimmetAta : Form
    {
        private VarlikDTO varlik;

        public FrmZimmetAta()
        {
            InitializeComponent();
        }

        public FrmZimmetAta(VarlikDTO varlik) : this()
        {
            this.varlik = varlik;
        }

        private void FrmZimmetAta_Load(object sender, EventArgs e)
        {
            FormuDoldur();
        }
        /// <summary>
        /// Form elementlerini dolduran fonksiyon.
        /// </summary>
        public void FormuDoldur()
        {
            ZimmetNedeniDAL zimmetNedeniDAL = new ZimmetNedeniDAL();
            ZimmetTuruDAL zimmetTuruDAL = new ZimmetTuruDAL();

            cmbZimmetNedeni.Items.AddRange(zimmetNedeniDAL.VeriCek().ToArray());
            cmbZimmetTuru.Items.AddRange(zimmetTuruDAL.VeriCek().ToArray());
        }
        /// <summary>
        /// Zimmet ata butonuna basıldığı zaman zimmet türüne göre kişi ya da ekibe zimmet atayan fonksiyon.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnZimmetAta_Click(object sender, EventArgs e)
        {
            ZimmetNedeniDTO secilenZimmetNedeni = cmbZimmetNedeni.SelectedItem as ZimmetNedeniDTO;
            ZimmetTuruDTO secilenZimmetTuru = cmbZimmetTuru.SelectedItem as ZimmetTuruDTO;
            KullaniciDTO secilenKullanici = cmbZimmetSahibi.SelectedItem as KullaniciDTO;
            KullaniciDAL kullaniciDAL = new KullaniciDAL();
            VarlikDepoDAL varlikDepoDAL = new VarlikDepoDAL();
            ZimmetDAL zimmetDAL = new ZimmetDAL();
            KullaniciZimmetDAL kullaniciZimmetDAL = new KullaniciZimmetDAL();
            EkipZimmetDAL ekipZimmetDAL = new EkipZimmetDAL();
            EkipDAL ekipDAL = new EkipDAL();
            List<KullaniciDTO> kullaniciListe = kullaniciDAL.VeriCek();

            VarlikDepoDTO cekilenDepoVeri = varlikDepoDAL.TekVeriCek(varlik.VarlikID);

            ZimmetDTO zimmet = new ZimmetDTO()
            {
                ZimmetNedeni = new ZimmetNedeniDTO() { ZimmetNedeniID = secilenZimmetNedeni.ZimmetNedeniID },
                ZimmetTuru = new ZimmetTuruDTO() { ZimmetTuruID = secilenZimmetTuru.ZimmetTuruID },
                BaslangicTarihi = dtpZimmetBaslangic.Value,
                Aciklama = txtAciklama.Text,
                OlusturanKisiID = 1,
                VarlikDepo = new VarlikDepoDTO() { VarlikDepoID = cekilenDepoVeri.VarlikDepoID },
                AktifMi = true,
                BitisTarihi = dtpZimmetBitis.Value
            };
            DonenSonuc sonuc = zimmetDAL.Ekle(zimmet);
            MessageBox.Show(sonuc.DonusMesaji);
            ZimmetDTO zimmetID = zimmetDAL.TekVeriCek(cekilenDepoVeri.VarlikDepoID);
            MessageBox.Show(zimmetID.ZimmetID.ToString());
            if (cmbZimmetTuru.SelectedItem.ToString() == "Kişi")
            {
                KullaniciZimmetDTO kullaniciZimmet = new KullaniciZimmetDTO() { Zimmet = zimmetID, Kullanici = cmbZimmetSahibi.SelectedItem as KullaniciDTO };
                DonenSonuc kullaniciSonuc = kullaniciZimmetDAL.Ekle(kullaniciZimmet);
                MessageBox.Show(kullaniciSonuc.DonusMesaji);
            }
            else
            {
                EkipZimmetDTO ekipZimmet = new EkipZimmetDTO() { Zimmet = zimmetID, Ekip = cmbZimmetSahibi.SelectedItem as EkipDTO };
                DonenSonuc ekipSonuc = ekipZimmetDAL.Ekle(ekipZimmet);
                MessageBox.Show(ekipSonuc.DonusMesaji);
            }

        }

        /// <summary>
        /// Zimmet türü değişince Kullanıcı ya da Ekibe göre zimmet atayan fonksiyon.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbZimmetTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbZimmetTuru.SelectedItem.ToString() == "Kişi")
            {
                KullaniciDAL kullaniciDAL = new KullaniciDAL();
                cmbZimmetSahibi.Items.AddRange(kullaniciDAL.VeriCek().ToArray());
            }
            else
            {
                EkipDAL ekipDAL = new EkipDAL();
                cmbZimmetSahibi.Items.AddRange(ekipDAL.VeriCek().ToArray());
            }
        }
    }
}
