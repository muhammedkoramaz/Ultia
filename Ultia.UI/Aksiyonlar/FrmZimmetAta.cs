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
        public void FormuDoldur()
        {
            ZimmetNedeniDAL zimmetNedeniDAL = new ZimmetNedeniDAL();
            ZimmetTuruDAL zimmetTuruDAL = new ZimmetTuruDAL();

            cmbZimmetNedeni.Items.AddRange(zimmetNedeniDAL.VeriCek().ToArray());
            cmbZimmetTuru.Items.AddRange(zimmetTuruDAL.VeriCek().ToArray());
        }
        private void btnZimmetAta_Click(object sender, EventArgs e)
        {
            ZimmetNedeniDTO secilenZimmetNedeni = cmbZimmetNedeni.SelectedItem as ZimmetNedeniDTO;
            ZimmetTuruDTO secilenZimmetTuru = cmbZimmetTuru.SelectedItem as ZimmetTuruDTO;
            KullaniciDTO secilenKullanici = cmbZimmetSahibi.SelectedItem as KullaniciDTO;
            KullaniciDAL kullaniciDAL = new KullaniciDAL();
            VarlikDepoDAL varlikDepoDAL = new VarlikDepoDAL();
            ZimmetDAL zimmetDAL = new ZimmetDAL();

            List<KullaniciDTO> kullaniciListe = kullaniciDAL.VeriCek();

            VarlikDepoDTO cekilenDepoVeri = varlikDepoDAL.TekVeriCek(varlik.VarlikID);
            //todo ekibe göre 
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
            ZimmetDTO zimmett = zimmetDAL.TekVeriCek(cekilenDepoVeri.VarlikDepoID);
            MessageBox.Show(zimmett.ZimmetID.ToString());

        }

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
