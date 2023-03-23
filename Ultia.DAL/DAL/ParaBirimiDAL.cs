using AdoSample.Provider;
using System.Collections.Generic;
using System.Data.SqlClient;
using Ultia.DAL.IRepositories;
using Ultia.DTO.DTOs;

namespace Ultia.DAL.DAL
{
    public class ParaBirimiDAL : IVeriCek<ParaBirimiDTO>
    {
        List<ParaBirimiDTO> paraBirimiList;
        /// <summary>
        /// Veritabanından ParaBirimi tablosunu çeken fonksiyon.
        /// </summary>
        /// <returns></returns>
        public List<ParaBirimiDTO> VeriCek()
        {
            string sorgu = $"select ParaBirimiID, ParaBirimi from ParaBirimi where AktifMi = 'True'";
            SqlProvider provider = new SqlProvider(sorgu);
            SqlDataReader veriOkuyucu = provider.ExecuteReaderOlustur();
            if (veriOkuyucu.HasRows)
            {
                paraBirimiList = new List<ParaBirimiDTO>();
                while (veriOkuyucu.Read())
                {
                    paraBirimiList.Add(new ParaBirimiDTO()
                    {
                        ParaBirimiID = veriOkuyucu.GetInt32(0),
                        ParaBirimi = veriOkuyucu.GetString(1),
                    });
                }
                return paraBirimiList;
            }
            else
            {
                return null;
            }
        }
    }
}
