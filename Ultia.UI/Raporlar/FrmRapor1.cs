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
using Ultia.DTO.DTOs;

namespace Ultia.UI.Raporlar
{
    public partial class FrmRapor1 : Form
    {
        decimal toplam = 0;

        public FrmRapor1()
        {
            InitializeComponent();
        }

        private void FrmRapor1_Load(object sender, EventArgs e)
        {
            FormDoldur();
        }
        /// <summary>
        /// Form Dolduran fonksiyon.
        /// </summary>
        private void FormDoldur()
        {
            MusteriVarlikDAL musteriVarlikDAL = new MusteriVarlikDAL();
            List<MusteriVarlikDTO> musteriVarlikListe = new List<MusteriVarlikDTO>();
            musteriVarlikListe = musteriVarlikDAL.VeriCek();
            foreach (MusteriVarlikDTO musteriVarlik in musteriVarlikListe)
            {
                ListViewItem listViewItem = new ListViewItem(musteriVarlik.Musteri.MusteriID.ToString());
                listViewItem.SubItems.Add(musteriVarlik.Musteri.MusteriAdSoyad);
                listViewItem.SubItems.Add(musteriVarlik.Musteri.MusteriTel);
                listViewItem.SubItems.Add(musteriVarlik.Varlik.Model.Marka.MarkaAdi);
                listViewItem.SubItems.Add(musteriVarlik.Varlik.Model.ModelAdi);
                listViewItem.SubItems.Add(musteriVarlik.Varlik.GuncelFiyat.ToString());
                listViewItem.SubItems.Add(musteriVarlik.Varlik.UrunParaBirimi.ParaBirimi);
                toplam += musteriVarlik.Varlik.GuncelFiyat;
                lvMusteriVarlik.Items.Add(listViewItem);
            }
            lblToplam.Text = toplam.ToString();

        }
    }
}
