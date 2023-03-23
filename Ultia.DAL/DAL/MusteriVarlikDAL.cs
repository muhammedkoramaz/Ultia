using AdoSample.Provider;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Ultia.DAL.IRepositories;
using Ultia.DTO;
using Ultia.DTO.DTOs;

namespace Ultia.DAL.DAL
{
    public class MusteriVarlikDAL : IEkle<MusteriVarlikDTO>, IVeriCek<MusteriVarlikDTO>
    {
        List<MusteriVarlikDTO> musteriVarlikListe;
        public DonenSonuc Ekle(MusteriVarlikDTO eklenecekVeri)
        {
            string sorgu = "insert into MusteriVarlik  (MusteriID,VarlikID,Aciklama,AktifMi) values(@MusteriID, @VarlikID ,@Aciklama,@AktifMi)";
            SqlProvider provider = new SqlProvider(sorgu);
            SqlParameter[] sqlParameters = new SqlParameter[4];

            sqlParameters[0] = new SqlParameter("@MusteriID", eklenecekVeri.Musteri.MusteriID);
            sqlParameters[1] = new SqlParameter("@VarlikID", eklenecekVeri.Varlik.VarlikID);
            sqlParameters[2] = new SqlParameter("@Aciklama", eklenecekVeri.Aciklama);
            sqlParameters[3] = new SqlParameter("@AktifMi", eklenecekVeri.AktifMi);

            provider.ParametreEkle(sqlParameters);

            int etkilenenSatirSayisi = provider.ExecuteNonQueryOlustur();
            return new DonenSonuc()
            {
                Sonuc = etkilenenSatirSayisi,
                DonusMesaji = etkilenenSatirSayisi > 0 ? "Varlık Başarıyla Tüketildi." : "Varlık Tüketilirken Hata Oluştu.",
                DonusTipi = etkilenenSatirSayisi > 0,
            };
        }

        /// <summary>
        /// Veritabanından MüşteriVarlık tablosunu çeken fonksiyon.
        /// </summary>
        /// <returns></returns>
        public List<MusteriVarlikDTO> VeriCek()
        {
            string sorgu = $"select m.MusteriID,m.MusteriAdSoyad,m.MusteriTel,v.Barkod,marka.MarkaAdi,model.ModelAd,f.ParaMiktari, pb.ParaBirimi from MusteriVarlik mv join Musteri m on mv.MusteriID = m.MusteriID join Varlik v on v.VarlikID = mv.VarlikID left join Fiyat f on f.VarlikID = mv.VarlikID join Model model on model.ModelID = v.ModelID join Marka marka on model.MarkaID = marka.MarkaID join ParaBirimi pb on f.ParaBirimiID = pb.ParaBirimiID where f.AktifMi = 'true'";
            SqlProvider provider = new SqlProvider(sorgu);
            SqlDataReader veriOkuyucu = provider.ExecuteReaderOlustur();
            if (veriOkuyucu.HasRows)
            {
                musteriVarlikListe = new List<MusteriVarlikDTO>();
                while (veriOkuyucu.Read())
                {

                    musteriVarlikListe.Add(new MusteriVarlikDTO()
                    {
                        Musteri = new MusteriDTO() { MusteriID = veriOkuyucu.GetInt32(0), MusteriAdSoyad = veriOkuyucu.GetString(1), MusteriTel = veriOkuyucu.GetString(2) },
                        Varlik = new VarlikDTO()
                        {
                            Barkod = new Guid(),

                            Model = new ModelDTO() { ModelAdi = veriOkuyucu.GetString(5), Marka = new MarkaDTO() { MarkaAdi = veriOkuyucu.GetString(4) } },
                            GuncelFiyat = veriOkuyucu.GetDecimal(6),
                            UrunParaBirimi = new ParaBirimiDTO() { ParaBirimi = veriOkuyucu.GetString(7) }
                        },

                    });
                }
                return musteriVarlikListe;
            }
            else
            {
                return null;
            }
        }
    }
}
