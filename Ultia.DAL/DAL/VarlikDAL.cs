using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultia.DAL.IRepositories;
using Ultia.DTO;
using Ultia.DTO.DTOs;
using AdoSample.Provider;

namespace Ultia.DAL.DAL
{
    public class VarlikDAL : IVeriCek<VarlikDTO>, ISil<VarlikDTO>, ITekVeriCek<VarlikDTO>,IGuncelle<VarlikDTO>
    {
        public DonenSonuc Sil(int id)
        {
            string sorgu = $"update Varlik set AktifMi = 0 where VarlikID = {id}";
            SqlProvider provider = new SqlProvider(sorgu);
            SqlDataReader veriOkuyucu = provider.ExecuteReaderOlustur();
            //TODO BURADAN SONRASINI TAMAMLAAA
            List<VarlikDTO> varlikListe = null;
            if (veriOkuyucu.HasRows)
            {
                varlikListe = new List<VarlikDTO>();
                while (veriOkuyucu.Read())
                {
                    VarlikDTO varlik = new VarlikDTO();
                    varlik.VarlikID = veriOkuyucu.GetInt32(0);
                    try
                    {
                        varlik.Barkod = veriOkuyucu.GetGuid(1);

                    }
                    catch (Exception)
                    {
                        varlik.Barkod = Guid.Empty;
                    }
                    varlik.UrunTipi = new UrunTipiDTO() { UrunTipiAdi = veriOkuyucu.GetString(2) };
                    varlik.GuncelFiyat = veriOkuyucu.GetDecimal(3);
                    varlik.Model = new ModelDTO() { ModelAdi = veriOkuyucu.GetString(5), Marka = new MarkaDTO() { MarkaAdi = veriOkuyucu.GetString(4) } };

                    varlikListe.Add(varlik);
                }
            }
            return new DonenSonuc();
        }


        /// <summary>
        /// Veritabanından varlıkları çekme fonksiyonu. 
        /// </summary>
        /// <returns></returns>
        public List<VarlikDTO> VeriCek()
        {
            string sorgu = "select v.VarlikID ,v.Barkod,ut.UrunTipi,fiyat.ParaMiktari, marka.MarkaAdi,model.ModelAd from Varlik as v join UrunTipi ut on v.UrunTipiID = ut.UrunTipiID join Model model on v.ModelID = model.ModelID join Marka marka on model.MarkaID = marka.MarkaID join Fiyat fiyat on v.VarlikID = fiyat.VarlikID where v.AktifMi = 'True' and fiyat.AktifMi = 'True'";
            SqlProvider provider = new SqlProvider(sorgu);
            SqlDataReader veriOkuyucu = provider.ExecuteReaderOlustur();

            List<VarlikDTO> varlikListe = null;
            if (veriOkuyucu.HasRows)
            {
                varlikListe = new List<VarlikDTO>();
                while (veriOkuyucu.Read())
                {
                    VarlikDTO varlik = new VarlikDTO();
                    varlik.VarlikID = veriOkuyucu.GetInt32(0);
                    try
                    {
                        varlik.Barkod = veriOkuyucu.GetGuid(1);

                    }
                    catch (Exception)
                    {
                        varlik.Barkod = Guid.Empty;
                    }
                    varlik.UrunTipi = new UrunTipiDTO() { UrunTipiAdi = veriOkuyucu.GetString(2) };
                    varlik.GuncelFiyat = veriOkuyucu.GetDecimal(3);
                    varlik.Model = new ModelDTO() { ModelAdi = veriOkuyucu.GetString(5), Marka = new MarkaDTO() { MarkaAdi = veriOkuyucu.GetString(4) } };

                    varlikListe.Add(varlik);
                }
            }
            return varlikListe;
        }

        public VarlikDTO TekVeriCek(int id)
        {
            string sorgu = $"select v.VarlikID ,v.Barkod, birim.BirimAdi,v.Miktar, ut.UrunTipi,marka.MarkaAdi, model.ModelAd, marka.MarkaID,model.ModelID, v.GarantiliMi, v.Aciklama, v.OlusturulmaTarihi, v.UrunMaliyeti,pb.ParaBirimi,birim.BirimID,ut.UrunTipiID,pb.ParaBirimiID from Varlik as v join UrunTipi ut on v.UrunTipiID = ut.UrunTipiID join Model model on v.ModelID = model.ModelID join Marka marka on model.MarkaID = marka.MarkaID join Fiyat fiyat on v.VarlikID = fiyat.VarlikID join ParaBirimi pb on fiyat.ParaBirimiID = pb.ParaBirimiID left join Birim birim on v.BirimID = birim.BirimID where v.AktifMi = 'True' and v.VarlikID ={id}";
            SqlProvider provider = new SqlProvider(sorgu);
            SqlDataReader veriOkuyucu = provider.ExecuteReaderOlustur();

            VarlikDTO varlik = new VarlikDTO();
            if (veriOkuyucu.HasRows)
            {
                while (veriOkuyucu.Read())
                {
                    varlik.VarlikID = veriOkuyucu.GetInt32(0);
                    try
                    {
                        varlik.Barkod = veriOkuyucu.GetGuid(1);

                    }
                    catch (Exception)
                    {
                        varlik.Barkod = Guid.Empty;
                        varlik.Birim = new BirimDTO() { BirimAdi = veriOkuyucu.GetString(2), BirimID = veriOkuyucu.GetInt32(14) };
                        varlik.Miktar = veriOkuyucu.GetInt32(3);

                    }
                    varlik.UrunTipi = new UrunTipiDTO() { UrunTipiAdi = veriOkuyucu.GetString(4),UrunTipiID= veriOkuyucu.GetInt32(15) };
                    varlik.Model = new ModelDTO() { ModelAdi = veriOkuyucu.GetString(6), ModelID = veriOkuyucu.GetInt32(8), Marka = new MarkaDTO() { MarkaAdi = veriOkuyucu.GetString(5), MarkaID = veriOkuyucu.GetInt32(7) } };
                    varlik.GarantiliMi = veriOkuyucu.GetBoolean(9);
                    varlik.Aciklama = veriOkuyucu.GetString(10);
                    varlik.OlusturulmaTarihi = veriOkuyucu.GetDateTime(11);
                    varlik.UrunMaliyeti = veriOkuyucu.GetDecimal(12);
                    varlik.UrunParaBirimi = new ParaBirimiDTO() { ParaBirimi= veriOkuyucu.GetString(13) , ParaBirimiID =veriOkuyucu.GetInt32(16)};    
                }
            }
            return varlik;
        }

        public DonenSonuc Guncelle(VarlikDTO guncellenecekVeri)
        {
            string sorgu = "UPDATE Varlik SET GarantiliMi=@GarantiliMi,Aciklama=@Aciklama,DosyaYolu=@DosyaYolu WHERE VarlikID=@VarlikID";
            SqlProvider provider = new SqlProvider(sorgu);
            SqlParameter[] sqlParameters = new SqlParameter[4];

            sqlParameters[0] = new SqlParameter("@GarantiliMi", guncellenecekVeri.GarantiliMi);
            sqlParameters[1] = new SqlParameter("@Aciklama", guncellenecekVeri.Aciklama);
            sqlParameters[2] = new SqlParameter("@DosyaYolu", guncellenecekVeri.DosyaYolu);
            sqlParameters[3] = new SqlParameter("@VarlikID", guncellenecekVeri.VarlikID);

            provider.ParametreEkle(sqlParameters);

            int etkilenenSatirSayisi = provider.ExecuteNonQueryOlustur();
            return new DonenSonuc()
            {
                Sonuc = etkilenenSatirSayisi,
                DonusMesaji = etkilenenSatirSayisi > 0 ? "Varlık Başarıyla Güncellendi." : "Varlık Güncellenirken Hata Oluştu.",
                DonusTipi = etkilenenSatirSayisi > 0,
            };
        }

        //public DonenSonuc Guncelle(VarlikDTO guncellenecekVeri)
        //{
        //    string sorgu = "UPDATE Varlik SET Barkod=@Barkod ,UrunTipiID=@UrunTipiID,ModelID=@ModelID,GarantiliMi=@GarantiliMi,OlusturulmaTarihi=@OlusturulmaTarihi,UrunMaliyeti=@UrunMaliyeti,UrunParaBirimiID=@UrunParaBirimiID,Aciklama=@Aciklama,DosyaYolu=@DosyaYolu WHERE VarlikID=@VarlikID";
        //    SqlProvider provider = new SqlProvider(sorgu);
        //    SqlParameter[] sqlParameters = new SqlParameter[12];
        //    sqlParameters[0] = new SqlParameter("@Barkod", guncellenecekVeri.Barkod);
        //    sqlParameters[1] = new SqlParameter("@UrunTipiID", guncellenecekVeri.UrunTipi.UrunTipiID);
        //    sqlParameters[2] = new SqlParameter("@ModelID", guncellenecekVeri.Model.ModelID);
        //    sqlParameters[3] = new SqlParameter("@GarantiliMi", guncellenecekVeri.GarantiliMi);
        //    sqlParameters[4] = new SqlParameter("@OlusturulmaTarihi", guncellenecekVeri.OlusturulmaTarihi);
        //    sqlParameters[5] = new SqlParameter("@UrunMaliyeti", guncellenecekVeri.UrunMaliyeti);
        //    sqlParameters[6] = new SqlParameter("@UrunParaBirimiID", guncellenecekVeri.UrunParaBirimi.ParaBirimiID);
        //    sqlParameters[7] = new SqlParameter("@Aciklama", guncellenecekVeri.Aciklama);
        //    sqlParameters[8] = new SqlParameter("@DosyaYolu", guncellenecekVeri.DosyaYolu);
        //    //sqlParameters[9] = new SqlParameter("@Miktar", guncellenecekVeri.Miktar);
        //    provider.ParametreEkle(sqlParameters);

        //    int etkilenenSatirSayisi = provider.ExecuteNonQueryOlustur();
        //    return new DonenSonuc()
        //    {
        //        Sonuc = etkilenenSatirSayisi,
        //        DonusMesaji = etkilenenSatirSayisi > 0 ? "Varlık Başarıyla Güncellendi." : "Varlık Güncellenirken Hata Oluştu.",
        //        DonusTipi = etkilenenSatirSayisi > 0,
        //    };
        //}
    }
}
