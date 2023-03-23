using System;
using System.Windows.Forms;
using Ultia.DAL.DAL;
using Ultia.DTO;
using Ultia.DTO.DTOs;

namespace Ultia.UI.AksiyonEkranlar
{
    public partial class FrmTuket : Form
    {
        int varlikID;
        public FrmTuket()
        {
            InitializeComponent();
        }
        public FrmTuket(int varlikID) : this()
        {
            this.varlikID = varlikID;
        }

        private void FrmTuket_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Ürün satışı yapan fonksiyon.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDosyaEkle_Click(object sender, EventArgs e)
        {
            MusteriVarlikDAL musteriVarlikDAL = new MusteriVarlikDAL();

            MusteriVarlikDTO musteriVarlik = new MusteriVarlikDTO()
            {
                Aciklama = txtAciklama.Text,
                Varlik = new VarlikDTO() { VarlikID = varlikID },
                Musteri = new MusteriDTO() { MusteriID = int.Parse(txtAboneNo.Text) }
            };
            DonenSonuc sonuc = musteriVarlikDAL.Ekle(musteriVarlik);
            MessageBox.Show(sonuc.DonusMesaji);
        }
    }
}
