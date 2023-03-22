using AdoSample.Provider;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultia.DAL.IRepositories;
using Ultia.DTO;
using Ultia.DTO.DTOs;

namespace Ultia.DAL.DAL
{
    public class MusteriVarlikDAL : IEkle<MusteriVarlikDTO>
    {
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
    }
}
