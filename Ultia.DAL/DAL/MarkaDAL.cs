using AdoSample.Provider;
using System.Collections.Generic;
using System.Data.SqlClient;
using Ultia.DAL.IRepositories;
using Ultia.DTO.DTOs;

namespace Ultia.DAL.DAL
{

    public class MarkaDAL : IVeriCek<MarkaDTO>
    {
        List<MarkaDTO> markaListe;
        /// <summary>
        /// Veritabanından Marka tablosunu çeken fonksiyon.
        /// </summary>
        /// <returns></returns>
        public List<MarkaDTO> VeriCek()
        {
            string sorgu = $"select MarkaID, MarkaAdi from Marka where AktifMi = 'true'";
            SqlProvider provider = new SqlProvider(sorgu);
            SqlDataReader veriOkuyucu = provider.ExecuteReaderOlustur();
            if (veriOkuyucu.HasRows)
            {
                markaListe = new List<MarkaDTO>();
                while (veriOkuyucu.Read())
                {
                    markaListe.Add(new MarkaDTO()
                    {
                        MarkaID = veriOkuyucu.GetInt32(0),
                        MarkaAdi = veriOkuyucu.GetString(1)
                    });
                }
                return markaListe;
            }
            else
            {
                return null;
            }
        }
    }
}
