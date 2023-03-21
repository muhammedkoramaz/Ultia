using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ultia.DTO.DTOs;

namespace Ultia.UI
{
    public partial class FrmVarlikGuncelle : Form
    {
        private int varlikID;
        private VarlikDTO varlik;

        public FrmVarlikGuncelle()
        {
            InitializeComponent();
        }

        public FrmVarlikGuncelle(VarlikDTO varlik) : this()
        {
            this.varlik = varlik;
            txtBarkod.Text = varlik.Barkod.ToString();

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

        private void FrmVarlikGuncelle_Load(object sender, EventArgs e)
        {
        }
    }
}
