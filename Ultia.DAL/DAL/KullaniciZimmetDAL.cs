using AdoSample.Provider;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Ultia.DAL.IRepositories;
using Ultia.DTO;
using Ultia.DTO.DTOs;

namespace Ultia.DAL.DAL
{
    public class KullaniciZimmetDAL : IVeriCekID<KullaniciZimmetDTO>, IEkle<KullaniciZimmetDTO>
    {
        List<KullaniciZimmetDTO> Zimmetler;

        /// <summary>
        /// Kullanıcıya zimmet atan fonksiyon.
        /// </summary>
        /// <param name="eklenecekVeri"></param>
        /// <returns></returns>
        public DonenSonuc Ekle(KullaniciZimmetDTO eklenecekVeri)
        {
            string sorgu = "insert into KullaniciZimmet(KullaniciID,ZimmetID,AktifMi)values(@kullaniciID,@zimmetID,@aktifMi)";
            SqlProvider provider = new SqlProvider(sorgu);
            SqlParameter[] sqlParameters = new SqlParameter[3];

            sqlParameters[0] = new SqlParameter("@kullaniciID", eklenecekVeri.Kullanici.KullaniciID);
            sqlParameters[1] = new SqlParameter("@zimmetID", eklenecekVeri.Zimmet.ZimmetID);
            sqlParameters[2] = new SqlParameter("@aktifMi", true);
            provider.ParametreEkle(sqlParameters);

            int etkilenenSatirSayisi = provider.ExecuteNonQueryOlustur();
            return new DonenSonuc()
            {
                Sonuc = etkilenenSatirSayisi,
                DonusMesaji = etkilenenSatirSayisi > 0 ? "Zimmet Atama İşlemi Başarıyla Gerçekleştirildi." : "Zimmet Atama İşlemi Yapılırken Hata Oluştu.",
                DonusTipi = etkilenenSatirSayisi > 0,
            };
        }

        /// <summary>
        /// Veritabanından KullanıcıZimmet tablosunu çeken fonksiyon.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<KullaniciZimmetDTO> VeriCek(int id)
        {
            string sorgu = $"select kz.KullaniciZimmetID as [Kayıt Numarası], v.Barkod, ut.UrunTipi, fy.ParaMiktari as Fiyat , marka.MarkaAdi as Marka , Model.ModelAd as Model, v.VarlikID from KullaniciZimmet kz join Kullanici k on kz.KullaniciID = k.KullaniciID join Zimmet z on kz.ZimmetID = z.ZimmetID join VarlikDepo vd on z.VarlikDepoID = vd.VarlikDepoID join Varlik v on vd.VarlikID = v.VarlikID join UrunTipi ut on v.UrunTipiID = ut.UrunTipiID join Fiyat fy on fy.VarlikID = v.VarlikID join Model model on v.ModelID = model.ModelID join Marka marka on model.MarkaID = marka.MarkaID where kz.KullaniciID = {id} and kz.AktifMi= 'True' and fy.AktifMi = 'True'";
            SqlProvider provider = new SqlProvider(sorgu);
            SqlDataReader veriOkuyucu = provider.ExecuteReaderOlustur();
            if (veriOkuyucu.HasRows)
            {
                Zimmetler = new List<KullaniciZimmetDTO>();
                while (veriOkuyucu.Read())
                {
                    UrunTipiDTO urunTipi = new UrunTipiDTO() { UrunTipiAdi = veriOkuyucu.GetString(2) };
                    ModelDTO model = new ModelDTO() { ModelAdi = veriOkuyucu.GetString(5), Marka = new MarkaDTO() { MarkaAdi = veriOkuyucu.GetString(4) } };
                    VarlikDTO varlik = new VarlikDTO() { VarlikID = veriOkuyucu.GetInt32(6), Barkod = Guid.Empty, UrunTipi = urunTipi, Model = model, GuncelFiyat = veriOkuyucu.GetDecimal(3) };
                    ZimmetDTO zimmet = new ZimmetDTO() { ZimmetID = veriOkuyucu.GetInt32(0), Varlik = varlik };
                    KullaniciZimmetDTO kullaniciZimmet = new KullaniciZimmetDTO() { KullaniciZimmetID = veriOkuyucu.GetInt32(0), Zimmet = zimmet };
                    try
                    {
                        kullaniciZimmet.Zimmet.Varlik.Barkod = veriOkuyucu.GetGuid(1);
                    }
                    catch (Exception ex)
                    {
                    }
                    Zimmetler.Add(kullaniciZimmet);
                }
            }
            return Zimmetler;
        }
    }
}