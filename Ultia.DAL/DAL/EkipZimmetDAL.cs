using AdoSample.Provider;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Ultia.DAL.IRepositories;
using Ultia.DTO;
using Ultia.DTO.DTOs;

namespace Ultia.DAL.DAL
{
    public class EkipZimmetDAL : IVeriCekID<EkipZimmetDTO>,IEkle<EkipZimmetDTO>
    {
        List<EkipZimmetDTO> ekipZimmetler;

        /// <summary>
        /// Bir ekibe zimmet atıldığında insert yapacak fonksiyon.
        /// </summary>
        /// <param name="eklenecekVeri"></param>
        /// <returns></returns>
        public DonenSonuc Ekle(EkipZimmetDTO eklenecekVeri)
        {
            string sorgu = "insert into EkipZimmet(EkipID,ZimmetID,AktifMi) values (@ekipID,@zimmetID,@aktifMi)\r\n";
            SqlProvider provider = new SqlProvider(sorgu);
            SqlParameter[] sqlParameters = new SqlParameter[3];

            sqlParameters[0] = new SqlParameter("@kullaniciID", eklenecekVeri.Ekip.EkipID);
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

        public List<EkipZimmetDTO> VeriCek(int id)
        {
            string sorgu = $"select ez.EkipZimmetID as [Kayıt Numarası], v.Barkod, ut.UrunTipi as [Ürün Tipi], fy.ParaMiktari as Fiyat, marka.MarkaAdi as Marka , Model.ModelAd as Model , v.VarlikID from  EkipZimmet ez join Ekip e on ez.EkipID = e.EkipID join Zimmet z on ez.ZimmetID = z.ZimmetID join VarlikDepo vd on z.VarlikDepoID = vd.VarlikDepoID join Varlik v on vd.VarlikID = v.VarlikID join UrunTipi ut on v.UrunTipiID = ut.UrunTipiID join Fiyat fy on fy.VarlikID = v.VarlikID join Model model on v.ModelID = model.ModelID join Marka marka on model.MarkaID = marka.MarkaID where ez.EkipID = {id} and ez.AktifMi = 'True' and fy.AktifMi = 'True'";
            SqlProvider provider = new SqlProvider(sorgu);
            SqlDataReader veriOkuyucu = provider.ExecuteReaderOlustur();
            if (veriOkuyucu.HasRows)
            {
                ekipZimmetler = new List<EkipZimmetDTO>();
                while (veriOkuyucu.Read())
                {
                    UrunTipiDTO urunTipi = new UrunTipiDTO() { UrunTipiAdi = veriOkuyucu.GetString(2) };
                    ModelDTO model = new ModelDTO() { ModelAdi = veriOkuyucu.GetString(5), Marka = new MarkaDTO() { MarkaAdi = veriOkuyucu.GetString(4) } };
                    VarlikDTO varlik = new VarlikDTO() { VarlikID = veriOkuyucu.GetInt32(6),Barkod = Guid.Empty, UrunTipi = urunTipi, Model = model, GuncelFiyat = veriOkuyucu.GetDecimal(3) };
                    ZimmetDTO zimmet = new ZimmetDTO() { ZimmetID = veriOkuyucu.GetInt32(0), Varlik = varlik };
                    EkipZimmetDTO ekipZimmet = new EkipZimmetDTO() { EkipZimmetID = veriOkuyucu.GetInt32(0), Zimmet = zimmet };
                    try
                    {
                        ekipZimmet.Zimmet.Varlik.Barkod = veriOkuyucu.GetGuid(1);
                    }
                    catch (Exception ex)
                    {
                    }
                    ekipZimmetler.Add(ekipZimmet);
                }
            }
            return ekipZimmetler;
        }
    }
}
