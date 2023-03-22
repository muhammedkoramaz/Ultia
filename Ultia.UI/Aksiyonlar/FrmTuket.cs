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
