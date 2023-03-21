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
    public class VarlikDAL : IVeriCek<VarlikDTO>, ISil<VarlikDTO>,IVeriCekID<VarlikDTO>
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
            string sorgu = "select v.VarlikID ,v.Barkod,ut.UrunTipi,fiyat.ParaMiktari, marka.MarkaAdi,model.ModelAd from Varlik as v join UrunTipi ut on v.UrunTipiID = ut.UrunTipiID join Model model on v.ModelID = model.ModelID join Marka marka on model.MarkaID = marka.MarkaID join Fiyat fiyat on v.VarlikID = fiyat.VarlikID where v.AktifMi = 'True'";
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

        public List<VarlikDTO> VeriCek(int id)
        {
            throw new NotImplementedException();
        }
    }
}
