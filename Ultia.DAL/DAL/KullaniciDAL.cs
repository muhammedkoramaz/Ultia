using AdoSample.Provider;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Ultia.DAL.IRepositories;
using Ultia.DTO;
using Ultia.DTO.DTOs;

namespace Ultia.DAL.DAL
{
    public class KullaniciDAL : IVeriCekKullanici<KullaniciDTO>
    {
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
                        Ekip = new EkipDTO() { EkipAdi = veriOkuyucu.GetString(4), EkipID=veriOkuyucu.GetInt32(5)},
                    };
                }
                return kullanici;
            }
            else
            {
                return null;
            }
        }
    }
}

