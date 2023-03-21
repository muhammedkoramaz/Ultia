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

    public class FiyatDAL : IVeriCek<FiyatDTO>
    {
        List<FiyatDTO> fiyatListe;
        public List<FiyatDTO> VeriCek()
        {

            string sorgu = $"select f.FiyatID, f.ParaMiktari, f.GuncellemeTarihi, pb.ParaBirimi from Fiyat f join ParaBirimi pb on pb.ParaBirimiID= f.ParaBirimiID where f.AktifMi = 'True' and pb.AktifMi = 'True'";
            SqlProvider provider = new SqlProvider(sorgu);
            SqlDataReader veriOkuyucu = provider.ExecuteReaderOlustur();
            if (veriOkuyucu.HasRows)
            {
                fiyatListe = new List<FiyatDTO>();
                while (veriOkuyucu.Read())
                {
                    fiyatListe.Add(new FiyatDTO()
                    {
                        FiyatID = veriOkuyucu.GetInt32(0),
                        ParaMiktari = veriOkuyucu.GetDecimal(1),
                        GuncellemeTarihi = veriOkuyucu.GetDateTime(2),
                        ParaBirimi = new ParaBirimiDTO()
                        {
                            ParaBirimi = veriOkuyucu.GetString(3)
                        }
                    });
                }
                return fiyatListe;
            }
            else
            {
                return null;
            }
        }
    }
}

