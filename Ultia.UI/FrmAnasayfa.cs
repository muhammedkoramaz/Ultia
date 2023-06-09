﻿using System;
using System.Windows.Forms;
using Ultia.DTO.DTOs;
using Ultia.UI.Raporlar;

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

        private void pbDepoYonetimi_Click(object sender, EventArgs e)
        {
            PanelFormAc(new FrmVarlikListe(lblKullanici.Tag as KullaniciDTO));
        }

        private void pbDuyuru_Click(object sender, EventArgs e)
        {
            PanelFormAc(new FrmDuyurular());

        }

        private void pbSSS_Click(object sender, EventArgs e)
        {
            PanelFormAc(new FrmSss());

        }

        private void btnRapor_Click(object sender, EventArgs e)
        {
            PanelFormAc(new FrmRapor1());

        }

        private void btnRaporIki_Click(object sender, EventArgs e)
        {
            PanelFormAc(new FrmRapor2());

        }
    }
}
