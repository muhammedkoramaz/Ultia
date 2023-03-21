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
    public partial class FrmGirisEkrani : Form
    {

        public FrmGirisEkrani()
        {
            InitializeComponent();

        }
        private void GirisEkrani_Load(object sender, EventArgs e)
        {
            SifreGoster();

        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            KullaniciDAL kullanici = new KullaniciDAL();
            KullaniciDTO sonuc = kullanici.VeriCek(txtKullaniciAd.Text, txtSifre.Text);
            if (sonuc is null)
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış.");
            }
            else
            {
                FrmAnasayfa frm = new FrmAnasayfa();
                frm.lblKullanici.Text = sonuc.AdSoyad;
                frm.lblKullanici.Tag = sonuc;
                this.Hide();
                frm.Show();
            }
        }

        private void cbSifreGoster_CheckedChanged(object sender, EventArgs e)
        {
            SifreGoster();
        }
        /// <summary>
        /// Şifreyi gösterip gizleme fonksiyonu.
        /// </summary>
        public void SifreGoster()
        {
            if (!cbSifreGoster.Checked)
                txtSifre.PasswordChar = '\0';
            else
                txtSifre.PasswordChar = '●';
        }
    }
}
