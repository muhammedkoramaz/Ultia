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
    public class EkipDAL : IVeriCek<EkipDTO>
    {
        List<EkipDTO> ekipListe;   
        public List<EkipDTO> VeriCek()
        {

            string sorgu = $"select EkipID,EkipAdi,SirketID from Ekip where AktifMi = 'true'";
            SqlProvider provider = new SqlProvider(sorgu);
            SqlDataReader veriOkuyucu = provider.ExecuteReaderOlustur();
            if (veriOkuyucu.HasRows)
            {
                ekipListe = new List<EkipDTO>();
                while (veriOkuyucu.Read())
                {
                    ekipListe.Add(new EkipDTO()
                    {
                        EkipID = veriOkuyucu.GetInt32(0),
                        EkipAdi = veriOkuyucu.GetString(1),
                        Sirket = new SirketDTO() { SirketID = veriOkuyucu.GetInt32(2)}
                    });
                }
                return ekipListe;
            }
            else
            {
                return null;
            }
        }
    }
}
