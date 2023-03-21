using AdoSample.Provider;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultia.DAL.IRepositories;
using Ultia.DTO.DTOs;

namespace Ultia.DAL.DAL
{
    public class UrunTipiDAL : IVeriCek<UrunTipiDTO>
    {
        List<UrunTipiDTO> urunTipiList;
        public List<UrunTipiDTO> VeriCek()
        {
            string sorgu = $"select UrunTipiID,UrunTipi from UrunTipi where AktifMi = 'True'";
            SqlProvider provider = new SqlProvider(sorgu);
            SqlDataReader veriOkuyucu = provider.ExecuteReaderOlustur();
            if (veriOkuyucu.HasRows)
            {
                urunTipiList = new List<UrunTipiDTO>();
                while (veriOkuyucu.Read())
                {
                    urunTipiList.Add(new UrunTipiDTO()
                    {
                        UrunTipiID = veriOkuyucu.GetInt32(0),
                        UrunTipiAdi = veriOkuyucu.GetString(1),
                    });
                }
                return urunTipiList;
            }
            else
            {
                return null;
            }
        }
    }
}
