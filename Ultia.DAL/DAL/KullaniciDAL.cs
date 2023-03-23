using AdoSample.Provider;
using System.Collections.Generic;
using System.Data.SqlClient;
using Ultia.DAL.IRepositories;
using Ultia.DTO;
using Ultia.DTO.DTOs;

namespace Ultia.DAL.DAL
{
    public class KullaniciDAL : IVeriCekKullanici<KullaniciDTO>, IVeriCek<KullaniciDTO>
    {
        List<KullaniciDTO> kullaniciListe;
        /// <summary>
        /// Giriş yapacak kullanıcının bilgileri veritabanındaki kullanıcılar ile karşılaştırtılıyor ve eğer var ise kullanıcı classı dolduruluyor. Yok ise null dönüyor.
        /// </summary>
        /// <param name="kullaniciAdi"></param>
        /// <param name="sifre"></param>
        /// <returns></returns>
        public KullaniciDTO VeriCek(string kullaniciAdi, string sifre)
        {

            KullaniciDTO kullanici;
            string sorgu = $"SELECT k.KullaniciID,k.KullaniciAdi,k.AdSoyad, rol.RolAdi, ekip.EkipAdi,ekip.EkipID FROM Kullanici k join Rol rol on rol.RolID = k.RoleID join Ekip ekip on ekip.EkipID = k.EkipID where k.KullaniciAdi = '{kullaniciAdi}' AND k.Sifre = '{sifre}' AND k.AktifMi = 'True'";
            SqlProvider provider = new SqlProvider(sorgu);
            SqlDataReader veriOkuyucu = provider.ExecuteReaderOlustur();
            if (veriOkuyucu.HasRows)
            {
                kullanici = new KullaniciDTO();
                while (veriOkuyucu.Read())
                {
                    kullanici = new KullaniciDTO()
                    {
                        KullaniciID = veriOkuyucu.GetInt32(0),
                        KullaniciAdi = veriOkuyucu.GetString(1),
                        AdSoyad = veriOkuyucu.GetString(2),
                        Rol = new RolDTO() { RolAdi = veriOkuyucu.GetString(3) },
                        Ekip = new EkipDTO() { EkipAdi = veriOkuyucu.GetString(4), EkipID = veriOkuyucu.GetInt32(5) },
                    };
                }
                return kullanici;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Veritabanından Kullanıcı tablosunu çeken fonksiyon.
        /// </summary>
        /// <returns></returns>
        public List<KullaniciDTO> VeriCek()
        {
            string sorgu = "select KullaniciID,KullaniciAdi,AdSoyad,Email,RoleID,EkipID from Kullanici where AktifMi = 'true'";
            SqlProvider provider = new SqlProvider(sorgu);
            SqlDataReader veriOkuyucu = provider.ExecuteReaderOlustur();
            if (veriOkuyucu.HasRows)
            {
                kullaniciListe = new List<KullaniciDTO>();
                while (veriOkuyucu.Read())
                {
                    kullaniciListe.Add(new KullaniciDTO()
                    {
                        KullaniciID = veriOkuyucu.GetInt32(0),
                        KullaniciAdi = veriOkuyucu.GetString(1),
                        AdSoyad = veriOkuyucu.GetString(2),
                        Email = veriOkuyucu.GetString(3),
                        Rol = new RolDTO() { RolID = veriOkuyucu.GetInt32(4), },
                        Ekip = new EkipDTO() { EkipID = veriOkuyucu.GetInt32(5) },
                    });
                }
                return kullaniciListe;
            }
            else
            {
                return null;
            }
        }
    }
}

