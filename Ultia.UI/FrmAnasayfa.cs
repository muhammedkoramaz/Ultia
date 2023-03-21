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
    public partial class FrmAnasayfa : Form
    {
        private Form aktifForm;
        public FrmAnasayfa()
        {
            InitializeComponent();
        }

        private void Anasayfa_Load(object sender, EventArgs e)
        {

        }

        private void btnDepo_Click(object sender, EventArgs e)
        {
            PanelFormAc(new FrmVarlikListe(lblKullanici.Tag as KullaniciDTO));
            //FrmVarlikListe frmVarlikListe = new FrmVarlikListe(lblKullanici.Tag as KullaniciDTO);
            //frmVarlikListe.Show();
        }

        /// <summary>
        /// Ekran ortasındaki panelde ekranlar açma fonksiyonu.
        /// </summary>
        public void PanelFormAc(Form form)
        {
            if (aktifForm != null)
            {
                aktifForm.Close();
            }
            aktifForm = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            this.panelForm.Controls.Add(form);
            this.panelForm.Tag = form;
            form.BringToFront();
            form.Show();
        }

        private void btnSss_Click(object sender, EventArgs e)
        {
            PanelFormAc(new FrmSss());

        }

        private void btnDuyuru_Click(object sender, EventArgs e)
        {
            PanelFormAc(new FrmDuyurular());
        }
        //public static void PanelFormAc(Form form, Panel panel)
        //{
        //    if (panel.Controls.Count > 0)
        //    {
        //        panel.Controls.RemoveAt(0);
        //    }
        //    form.TopLevel = false;
        //    form.FormBorderStyle = FormBorderStyle.None;
        //    form.Dock = DockStyle.Fill;
        //    panel.Controls.Add(form);
        //    panel.Tag = form;
        //    form.BringToFront();
        //    form.Show();
        //}

    }
}
