using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ultia.DAL.DAL;
using Ultia.DTO.DTOs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ultia.UI
{
    public partial class FrmVarlikListe : Form
    {
        private KullaniciDTO kullanici;
        List<EkipZimmetDTO> ekipZimmetler;
        List<VarlikDTO> kullaniciVarliklar;
        List<KullaniciZimmetDTO> kullaniciZimmetler;
        public FrmVarlikListe()
        {
            InitializeComponent();
        }

        public FrmVarlikListe(KullaniciDTO kullaniciDTO) : this()
        {
            this.kullanici = kullaniciDTO;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void FrmVarlikListe_Load(object sender, EventArgs e)
        {
            if (kullanici.Rol.RolAdi == "Poweruser" || kullanici.Rol.RolAdi == "Depo Admin")
            {
                lblTumVarlik.Enabled = true;
            }
        }
        /// <summary>
        /// Sadece giriş yapan kullanıcının zimmetli varlıkları gelecek. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblVarliklarim_Click(object sender, EventArgs e)
        {
            LabelRenkDegistir((Label)sender);
            KullaniciZimmetDAL kullaniciZimmetDAL = new KullaniciZimmetDAL();
            kullaniciZimmetler = kullaniciZimmetDAL.VeriCek(kullanici.KullaniciID); // TODO : Burada giriş yapan kullanıcının id'si gönderilecek. 
            lvVarliklar.Items.Clear();
            foreach (KullaniciZimmetDTO kullaniciZimmet in kullaniciZimmetler)
            {
                ListViewItem listViewItem = new ListViewItem(kullaniciZimmet.KullaniciZimmetID.ToString());
                listViewItem.SubItems.Add(kullaniciZimmet.Zimmet.Varlik.Barkod.ToString());
                listViewItem.SubItems.Add(kullaniciZimmet.Zimmet.Varlik.UrunTipi.UrunTipiAdi.ToString());
                listViewItem.SubItems.Add(kullaniciZimmet.Zimmet.Varlik.GuncelFiyat.ToString());
                listViewItem.SubItems.Add(kullaniciZimmet.Zimmet.Varlik.Model.Marka.MarkaAdi.ToString());
                listViewItem.SubItems.Add(kullaniciZimmet.Zimmet.Varlik.Model.ToString());

                lvVarliklar.Items.Add(listViewItem);
            }

        }
        /// <summary>
        /// Tüm varlıkların görüntülendiği liste oluşturuluyor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblTumVarlik_Click(object sender, EventArgs e)
        {
            LabelRenkDegistir((Label)sender);
            VarlikDAL varlikDAL = new VarlikDAL();
            List<VarlikDTO> varliklar = varlikDAL.VeriCek();
            lvVarliklar.Items.Clear();
            foreach (VarlikDTO varlik in varliklar)
            {
                ListViewItem listViewItem = new ListViewItem(varlik.VarlikID.ToString());
                listViewItem.SubItems.Add(varlik.Barkod.ToString());
                listViewItem.SubItems.Add(varlik.UrunTipi.ToString());
                listViewItem.SubItems.Add(varlik.GuncelFiyat.ToString());
                listViewItem.SubItems.Add(varlik.Model.Marka.MarkaAdi.ToString());
                listViewItem.SubItems.Add(varlik.Model.ToString());

                lvVarliklar.Items.Add(listViewItem);


            }
        }
        /// <summary>
        /// Ekibin varlıkları çekiliyor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblEkipVarlik_Click(object sender, EventArgs e)
        {
            lvVarliklar.FullRowSelect = false;
            LabelRenkDegistir((Label)sender);
            EkipZimmetDAL ekipZimmetDAL = new EkipZimmetDAL();
            ekipZimmetler = ekipZimmetDAL.VeriCek(kullanici.Ekip.EkipID); // TODO : Burada giriş yapan kullanıcının id'si gönderilecek. 
            lvVarliklar.Items.Clear();
            foreach (EkipZimmetDTO ekipZimmet in ekipZimmetler)
            {
                ListViewItem listViewItem = new ListViewItem(ekipZimmet.EkipZimmetID.ToString());
                listViewItem.SubItems.Add(ekipZimmet.Zimmet.Varlik.Barkod.ToString());
                listViewItem.SubItems.Add(ekipZimmet.Zimmet.Varlik.UrunTipi.UrunTipiAdi.ToString());
                listViewItem.SubItems.Add(ekipZimmet.Zimmet.Varlik.GuncelFiyat.ToString());
                listViewItem.SubItems.Add(ekipZimmet.Zimmet.Varlik.Model.Marka.MarkaAdi.ToString());
                listViewItem.SubItems.Add(ekipZimmet.Zimmet.Varlik.Model.ToString());

                lvVarliklar.Items.Add(listViewItem);
            }
        }

        /// <summary>
        /// Tıklanılan labelin rengini değiştiren fonksiyon.
        /// </summary>
        /// <param name="label"></param>
        public void LabelRenkDegistir(Label label)
        {
            foreach (Control c in Controls)
            {
                if (c is Label && ((Label)c).Text == label.Text)
                {
                    ((Label)c).ForeColor = Color.Aqua;
                }
                else if (c is Label)
                {
                    ((Label)c).ForeColor = Color.Black;
                }
            }
        }
        VarlikDTO varlik;
        private void lvVarliklar_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SelectedItems[0] yani seçtiğimiz itemsin indeksini bize döndürür. Bir adet değer seçtiğimizden dolayı 0 veririz.
            //SubItems ise bize hangi sütunu seçtiğimizi belirtir. 1 ile adı soyadı bilgisini geri döndürür.
            string kullaniciZimmetID = lvVarliklar.SelectedItems[0].SubItems[0].Text.ToString();
            foreach (KullaniciZimmetDTO kullaniciZimmet in kullaniciZimmetler)
            {
                if (kullaniciZimmet.KullaniciZimmetID == int.Parse(kullaniciZimmetID))
                {
                    varlik = kullaniciZimmet.Zimmet.Varlik;
                    //VarlikDTO varlik = new VarlikDTO()
                    //                    {
                    //                        int VarlikID = ekipZimmet.Zimmet.Varlik.VarlikID,

                    //                    };
                }
            }
            FrmVarlikGuncelle frmVarlikGuncelle = new FrmVarlikGuncelle(varlik);
            frmVarlikGuncelle.Show();
        }
    }
}
