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
    public class ZimmetDAL : ITekVeriCek<ZimmetDTO>, IEkle<ZimmetDTO>
    {
        public DonenSonuc Ekle(ZimmetDTO eklenecekVeri)
        {
            string sorgu = "insert into Zimmet(ZimmetNedeniID,ZimmetTuruID,BaslangicTarihi,Aciklama,OlusturanKisiID,VarlikDepoID,AktifMi,BitisTarihi)" +
                "values(@zimmetNedeniID,@zimmetTuruID,@baslangicTarihi,@aciklama,@olusturanID,@varlikDepoID,@aktifMi,@BitisTarihi)";
            SqlProvider provider = new SqlProvider(sorgu);
            SqlParameter[] sqlParameters = new SqlParameter[8];

            sqlParameters[0] = new SqlParameter("@zimmetNedeniID", eklenecekVeri.ZimmetNedeni.ZimmetNedeniID);
            sqlParameters[1] = new SqlParameter("@zimmetTuruID", eklenecekVeri.ZimmetTuru.ZimmetTuruID);
            sqlParameters[2] = new SqlParameter("@baslangicTarihi", eklenecekVeri.BaslangicTarihi);
            sqlParameters[3] = new SqlParameter("@aciklama", eklenecekVeri.Aciklama);
            sqlParameters[4] = new SqlParameter("@olusturanID", eklenecekVeri.OlusturanKisiID);
            sqlParameters[5] = new SqlParameter("@varlikDepoID", eklenecekVeri.VarlikDepo.VarlikDepoID);
            sqlParameters[6] = new SqlParameter("@aktifMi", eklenecekVeri.AktifMi);
            sqlParameters[7] = new SqlParameter("@BitisTarihi", eklenecekVeri.BitisTarihi);

            provider.ParametreEkle(sqlParameters);

            int etkilenenSatirSayisi = provider.ExecuteNonQueryOlustur();
            return new DonenSonuc()
            {
                Sonuc = etkilenenSatirSayisi,
                DonusMesaji = etkilenenSatirSayisi > 0 ? "Varlık Başarıyla Tüketildi." : "Varlık Tüketilirken Hata Oluştu.",
                DonusTipi = etkilenenSatirSayisi > 0,
            };
        }

        public ZimmetDTO TekVeriCek(int id)
        {
            string sorgu = $"select  ZimmetID from Zimmet where VarlikDepoID = {id} and AktifMi = 'true'";
            SqlProvider provider = new SqlProvider(sorgu);
            SqlDataReader veriOkuyucu = provider.ExecuteReaderOlustur();

            ZimmetDTO zimmet = new ZimmetDTO();
            if (veriOkuyucu.HasRows)
            {
                while (veriOkuyucu.Read())
                {
                    zimmet.ZimmetID = veriOkuyucu.GetInt32(0);
                    
                }
            }
            return zimmet;
        }
    }
}
