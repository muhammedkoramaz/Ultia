using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ultia.DAL.DAL;
using Ultia.DTO;
using Ultia.DTO.DTOs;
using Ultia.UI.AksiyonEkranlar;

namespace Ultia.UI
{
    public partial class FrmVarlikGuncelle : Form
    {
        private VarlikDTO varlik;
        private KullaniciZimmetDTO secilenKullaniciZimmet;
        private VarlikDTO secilenVarlik;
        public FrmVarlikGuncelle()
        {
            InitializeComponent();
        }

        public FrmVarlikGuncelle(KullaniciZimmetDTO secilenKullaniciZimmet) : this()
        {
            this.secilenKullaniciZimmet = secilenKullaniciZimmet;
        }

        public FrmVarlikGuncelle(VarlikDTO secilenVarlik) : this()
        {
            this.secilenVarlik = secilenVarlik;
        }

        /// <summary>
        /// Ürünün barkodlu/barkodsuz oluşuna göre ilgili componentlerin görünümleri düzenleniyor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbBarkodlu_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBarkodlu.Checked)
            {
                cbBarkodlu.Text = "Barkodsuz Ürün";
                lblBirim.Visible = true;
                lblMiktar.Visible = true;
                nudMiktar.Visible = true;
                cmbBirim.Visible = true;
                txtBarkod.Enabled = false;
            }
        }
        /// <summary>
        /// Önceki formda seçilen varlığa ait veritabanındaki bilgilerini çekip ilgili alanlara dolduran fonksiyon.
        /// </summary>
        private void FormuDoldur()
        {
            VarlikDAL varlikDAL = new VarlikDAL();

            if (secilenVarlik == null)
            {
                varlik = varlikDAL.TekVeriCek(secilenKullaniciZimmet.Zimmet.Varlik.VarlikID);

            }
            else
            {
                varlik = varlikDAL.TekVeriCek(secilenVarlik.VarlikID);
            }
            ParaBirimiDAL paraBirimiDAL = new ParaBirimiDAL();
            List<ParaBirimiDTO> paraBirimiListe = paraBirimiDAL.VeriCek();


            MarkaDAL markaDAL = new MarkaDAL();
            List<MarkaDTO> markaListe = markaDAL.VeriCek();

            UrunTipiDAL urunTipiDAL = new UrunTipiDAL();
            List<UrunTipiDTO> urunTipiListe = urunTipiDAL.VeriCek();

            FiyatDAL fiyatDAL = new FiyatDAL();
            List<FiyatDTO> fiyatListe = fiyatDAL.VeriCek();

            BirimDAL birimDAL = new BirimDAL();
            List<BirimDTO> birimListe = birimDAL.VeriCek();

            // Barkodlu/Barkodsuz ürünlere göre ekran düzenleniyor.
            if (varlik.Barkod == Guid.Empty)
            {
                nudMiktar.Value = Convert.ToDecimal(varlik.Miktar);

                cmbBirim.Visible = true;
                cmbBirim.Items.AddRange(birimListe.ToArray());
                cmbBirim.SelectedItem = varlik.Birim;
                cmbBirim.SelectedText = varlik.Birim.ToString();

                cbBarkodlu.Checked = true;
            }
            else
            {
                txtBarkod.Text = varlik.Barkod.ToString();
            }

            txtMaliyet.Text = varlik.UrunMaliyeti.ToString();
            txtAciklama.Text = varlik.Aciklama;
            txtGuncelFiyat.Text = fiyatListe[0].ParaMiktari.ToString();

            //Combobox'lar dolduruluyor.
            cmbParaBirim.Items.AddRange(paraBirimiListe.ToArray());
            cmbGuncelParaBirimi.Items.AddRange(paraBirimiListe.ToArray());
            cmbMarka.Items.AddRange(markaListe.ToArray());

            cmbUrunTipi.Items.AddRange(urunTipiListe.ToArray());
            cmbUrunTipi.SelectedItem = varlik.UrunTipi;
            cmbUrunTipi.Text = varlik.UrunTipi.ToString();

            cmbMarka.SelectedItem = varlik.Model.Marka;
            cmbMarka.Text = varlik.Model.Marka.ToString();

            cmbModel.SelectedItem = varlik.Model;
            cmbModel.SelectedText = varlik.Model.ToString();

            cmbGaranti.Items.Add("Evet");
            cmbGaranti.Items.Add("Hayır");
            cmbGaranti.SelectedText = (bool)varlik.GarantiliMi ? "Evet" : "Hayır";

            cmbParaBirim.SelectedItem = varlik.UrunParaBirimi;
            cmbParaBirim.Text = varlik.UrunParaBirimi.ToString();

            cmbParaBirim.SelectedItem = varlik.UrunParaBirimi;
            cmbParaBirim.Text = varlik.UrunParaBirimi.ToString();

            cmbGuncelParaBirimi.SelectedItem = fiyatListe[0].ParaBirimi;
            cmbGuncelParaBirimi.Text = fiyatListe[0].ParaBirimi.ToString();
        }

        private void FrmVarlikGuncelle_Load(object sender, EventArgs e)
        {
            FormuDoldur();
        }

        /// <summary>
        /// Seçilen Markaya göre o markanın alt modellerini combobox'a listeleyen fonksiyon.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbMarka_SelectedIndexChanged(object sender, EventArgs e)
        {

            #region SecilenMarkayaGoreModelleriGetirme
            //ModelDAL modelDAL = new ModelDAL();
            //MarkaDTO seciliMarka = cmbMarka.SelectedItem as MarkaDTO;

            //List<ModelDTO> modelListe = modelDAL.VeriCek(seciliMarka.MarkaID);
            //cmbModel.Items.Clear();
            //cmbModel.Text = "";
            //cmbModel.Items.AddRange(modelListe.ToArray()); 
            #endregion

        }

        private void FrmVarlikGuncelle_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        /// <summary>
        /// İlgili componenetlerdeki verileri alıp veritabanında güncelleyen buton tıklama fonksiyonu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            bool garantiliMi = cmbGaranti.SelectedIndex == 0;
            VarlikDTO guncellenecekVarlik = new VarlikDTO()
            {
                VarlikID = varlik.VarlikID,
                Aciklama = txtAciklama.Text,
                GarantiliMi = garantiliMi,
                DosyaYolu = "yeni dosya",
            };

            FiyatDTO fiyatDTO = new FiyatDTO()
            {
                Varlik = varlik,
                GuncellemeTarihi = DateTime.Now,
                ParaBirimi = cmbParaBirim.SelectedItem as ParaBirimiDTO,
                ParaMiktari = decimal.Parse(txtGuncelFiyat.Text)
            };

            VarlikDAL varlikDAL = new VarlikDAL();
            FiyatDAL fiyatDAL = new FiyatDAL();

            DonenSonuc sonucVarlik = varlikDAL.Guncelle(guncellenecekVarlik);
            DonenSonuc sonucFiyat = fiyatDAL.Ekle(fiyatDTO);

            MessageBox.Show(sonucVarlik.DonusMesaji);
            MessageBox.Show(sonucFiyat.DonusMesaji);
        }

        /// <summary>
        /// Aksiyonların bulunduğu combooxtan seçilen aksiyona göre yeni form açan fonksiyon.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbAksiyonlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbAksiyonlar.SelectedItem.ToString())
            {
                case "Tüket":
                    FrmTuket frmTuket = new FrmTuket(varlik.VarlikID);
                    frmTuket.Show();
                    break;
                case "Zimmet Ata":
                    FrmZimmetAta frmZimmetAta = new FrmZimmetAta(varlik);
                    frmZimmetAta.Show();
                    break;
                default:
                    MessageBox.Show("Bu Hizmet Henüz Yapılamamaktadır.");
                    break;
            }
        }
    }
}
