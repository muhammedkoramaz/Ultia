using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ultia.DAL.DAL;
using Ultia.DTO.DTOs;

namespace Ultia.UI
{
    public partial class FrmVarlikGuncelle : Form
    {
        private int varlikID;
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

        private void gbKayitBilgileri_Enter(object sender, EventArgs e)
        {

        }

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

            // Textbox'lar dolduruluyor.
            txtBarkod.Text = varlik.Barkod.ToString();
            txtMaliyet.Text = varlik.UrunMaliyeti.ToString();
            txtAciklama.Text = varlik.Aciklama;

            //Combobox'lar dolduruluyor.
            cmbParaBirim.Items.AddRange(paraBirimiListe.ToArray());
            cmbMarka.Items.AddRange(markaListe.ToArray());
            cmbUrunTipi.Items.AddRange(urunTipiListe.ToArray());
        }

        private void FrmVarlikGuncelle_Load(object sender, EventArgs e)
        {
            FormuDoldur();
        }

        private void cmbMarka_SelectedIndexChanged(object sender, EventArgs e)
        {

            ModelDAL modelDAL = new ModelDAL();
            MarkaDTO seciliMarka = cmbMarka.SelectedItem as MarkaDTO;
            
            List<ModelDTO> modelListe = modelDAL.VeriCek(seciliMarka.MarkaID);
            cmbModel.Items.Clear();
            cmbModel.Items.AddRange(modelListe.ToArray());

        }
    }
}
