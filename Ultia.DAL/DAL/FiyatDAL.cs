using AdoSample.Provider;
using System.Collections.Generic;
using System.Data.SqlClient;
using Ultia.DAL.IRepositories;
using Ultia.DTO;
using Ultia.DTO.DTOs;

namespace Ultia.DAL.DAL
{
    public class FiyatDAL : IVeriCek<FiyatDTO>, IEkle<FiyatDTO>
    {
        List<FiyatDTO> fiyatListe;

        public DonenSonuc Ekle(FiyatDTO eklenecekVeri)
        {
            string sorgu = "insert into Fiyat  (VarlikID,ParaMiktari,GuncellemeTarihi,ParaBirimiID) values(@VarlikID, @ParaMiktari ,@GuncellemeTarihi,@ParaBirimiID)";
            SqlProvider provider = new SqlProvider(sorgu);
            SqlParameter[] sqlParameters = new SqlParameter[4];

            sqlParameters[0] = new SqlParameter("@VarlikID", eklenecekVeri.Varlik.VarlikID);
            sqlParameters[1] = new SqlParameter("@ParaMiktari", eklenecekVeri.ParaMiktari);
            sqlParameters[2] = new SqlParameter("@GuncellemeTarihi", eklenecekVeri.GuncellemeTarihi);
            sqlParameters[3] = new SqlParameter("@ParaBirimiID", eklenecekVeri.ParaBirimi.ParaBirimiID);

            provider.ParametreEkle(sqlParameters);

            int etkilenenSatirSayisi = provider.ExecuteNonQueryOlustur();
            return new DonenSonuc()
            {
                Sonuc = etkilenenSatirSayisi,
                DonusMesaji = etkilenenSatirSayisi > 0 ? "Fiyat Başarıyla Eklendi." : "Fiyat Eklenirken Hata Oluştu.",
                DonusTipi = etkilenenSatirSayisi > 0,
            };
        }

        /// <summary>
        /// Veritabanından Fiyat tablosunu çeken fonksiyon.
        /// </summary>
        /// <returns></returns>
        public List<FiyatDTO> VeriCek()
        {
            string sorgu = $"select f.FiyatID, f.ParaMiktari, f.GuncellemeTarihi, pb.ParaBirimi from Fiyat f join ParaBirimi pb on pb.ParaBirimiID= f.ParaBirimiID where f.AktifMi = 'True' and pb.AktifMi = 'True'";
            SqlProvider provider = new SqlProvider(sorgu);
            SqlDataReader veriOkuyucu = provider.ExecuteReaderOlustur();
            if (veriOkuyucu.HasRows)
            {
                fiyatListe = new List<FiyatDTO>();
                while (veriOkuyucu.Read())
                {
                    fiyatListe.Add(new FiyatDTO()
                    {
                        FiyatID = veriOkuyucu.GetInt32(0),
                        ParaMiktari = veriOkuyucu.GetDecimal(1),
                        GuncellemeTarihi = veriOkuyucu.GetDateTime(2),
                        ParaBirimi = new ParaBirimiDTO()
                        {
                            ParaBirimi = veriOkuyucu.GetString(3)
                        }
                    });
                }
                return fiyatListe;
            }
            else
            {
                return null;
            }
        }
    }
}

