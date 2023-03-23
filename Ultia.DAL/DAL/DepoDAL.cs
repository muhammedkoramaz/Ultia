using AdoSample.Provider;
using System.Collections.Generic;
using System.Data.SqlClient;
using Ultia.DAL.IRepositories;
using Ultia.DTO;
using Ultia.DTO.DTOs;

namespace Ultia.DAL.DAL
{
    public class DepoDAL : IVeriCek<DepoDTO>
    {
        List<DepoDTO> depoListe;
        /// <summary>
        /// Veritabanından depo tablosunu çeken fonksiyon.
        /// </summary>
        /// <returns></returns>
        public List<DepoDTO> VeriCek()
        {
            string sorgu = $"select DepoID,DepoAdi,SirketID from Depo where AktifMi = 'true'";
            SqlProvider provider = new SqlProvider(sorgu);
            SqlDataReader veriOkuyucu = provider.ExecuteReaderOlustur();
            if (veriOkuyucu.HasRows)
            {
                depoListe = new List<DepoDTO>();
                while (veriOkuyucu.Read())
                {
                    depoListe.Add(new DepoDTO()
                    {
                        DepoID = veriOkuyucu.GetInt32(0),
                        DepoAdi = veriOkuyucu.GetString(1),
                        Sirket = new SirketDTO() { SirketID = veriOkuyucu.GetInt32(2) }
                    });
                }
                return depoListe;
            }
            else
            {
                return null;
            }
        }
    }
}
