using AdoSample.Provider;
using System.Collections.Generic;
using System.Data.SqlClient;
using Ultia.DAL.IRepositories;
using Ultia.DTO.DTOs;

namespace Ultia.DAL.DAL
{
    public class VarlikDepoDAL : ITekVeriCek<VarlikDepoDTO>, IVeriCekID<VarlikDepoDTO>
    {
        List<VarlikDepoDTO> varlikDepoListe;
        /// <summary>
        /// Liste değil tek bir nesne giren fonksiyon.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VarlikDepoDTO TekVeriCek(int id)
        {
            string sorgu = $"select VarlikDepoID, DepoID from VarlikDepo where VarlikID = {id} and AktifMi = 'true'";
            SqlProvider provider = new SqlProvider(sorgu);
            SqlDataReader veriOkuyucu = provider.ExecuteReaderOlustur();

            VarlikDepoDTO varlikDepo = new VarlikDepoDTO();
            if (veriOkuyucu.HasRows)
            {
                while (veriOkuyucu.Read())
                {
                    varlikDepo.VarlikDepoID = veriOkuyucu.GetInt32(0);
                }
            }
            return varlikDepo;
        }
        /// <summary>
        /// Veritabanından ValıkDepo tablosunu çeken fonksiyon.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<VarlikDepoDTO> VeriCek(int id)
        {
            string sorgu = $"select vd.VarlikDepoID, marka.MarkaAdi,model.ModelAd,f.ParaMiktari , pb.ParaBirimi from VarlikDepo vd inner join Varlik v on vd.VarlikID = v.VarlikID inner join Model model on v.ModelID = model.ModelID inner join Marka marka on model.MarkaID = marka.MarkaID  inner join Fiyat f on f.VarlikID = v.VarlikID  inner join ParaBirimi pb on f.ParaBirimiID = pb.ParaBirimiID where DepoID = {id} and f.AktifMi = 'True'";
            SqlProvider provider = new SqlProvider(sorgu);
            SqlDataReader veriOkuyucu = provider.ExecuteReaderOlustur();
            if (veriOkuyucu.HasRows)
            {
                varlikDepoListe = new List<VarlikDepoDTO>();
                while (veriOkuyucu.Read())
                {
                    varlikDepoListe.Add(new VarlikDepoDTO()
                    {
                        VarlikDepoID = veriOkuyucu.GetInt32(0),
                        Varlik = new VarlikDTO() { Model = new ModelDTO() { ModelAdi = veriOkuyucu.GetString(2), Marka = new MarkaDTO() { MarkaAdi = veriOkuyucu.GetString(1) } }, GuncelFiyat = veriOkuyucu.GetDecimal(3), UrunParaBirimi = new ParaBirimiDTO() { ParaBirimi = veriOkuyucu.GetString(4) } }
                    });
                }
                return varlikDepoListe;
            }
            else
            {
                return null;
            }
        }
    }
}
