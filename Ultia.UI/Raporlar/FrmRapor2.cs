using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ultia.DAL.DAL;
using Ultia.DTO;
using Ultia.DTO.DTOs;

namespace Ultia.UI.Raporlar
{
    public partial class FrmRapor2 : Form
    {
        public FrmRapor2()
        {
            InitializeComponent();
        }

        private void FrmRapor2_Load(object sender, EventArgs e)
        {
            ComboboxDoldur();
        }
        /// <summary>
        /// Combobox'ın itemleri depo nesneleri ile dolduruluyor.
        /// </summary>
        public void ComboboxDoldur()
        {
            DepoDAL depoDAL = new DepoDAL();
            List<DepoDTO> depoListe = new List<DepoDTO>();
            depoListe = depoDAL.VeriCek();
            cmbDepolar.Items.AddRange(depoListe.ToArray());
        }

        /// <summary>
        /// Seçilen depoya göre içindeki itemler geliyor. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDepolar_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvDepoVarlik.Items.Clear();
            DepoDTO depo = new DepoDTO();
            depo = cmbDepolar.SelectedItem as DepoDTO;
            VarlikDepoDAL varlikDepoDAL = new VarlikDepoDAL();
            List<VarlikDepoDTO> varlikDepoListe = new List<VarlikDepoDTO>();
            varlikDepoListe = varlikDepoDAL.VeriCek(depo.DepoID);
            foreach (VarlikDepoDTO varlikDepo in varlikDepoListe)
            {
                ListViewItem listViewItem = new ListViewItem(varlikDepo.VarlikDepoID.ToString());
                listViewItem.SubItems.Add(varlikDepo.Varlik.Model.Marka.MarkaAdi);
                listViewItem.SubItems.Add(varlikDepo.Varlik.Model.ModelAdi);
                listViewItem.SubItems.Add(varlikDepo.Varlik.GuncelFiyat.ToString());
                listViewItem.SubItems.Add(varlikDepo.Varlik.UrunParaBirimi.ParaBirimi);
                lvDepoVarlik.Items.Add(listViewItem);
            }

        }
    }
}
