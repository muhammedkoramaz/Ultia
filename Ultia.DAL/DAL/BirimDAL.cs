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
    public class BirimDAL : IVeriCek<BirimDTO>
    {
        List<BirimDTO> birimListe;
        /// <summary>
        /// Veritabanından birim tablosundaki verileri çeken fonksiyon.
        /// </summary>
        /// <returns></returns>
        public List<BirimDTO> VeriCek()
        {
            string sorgu = "select BirimID, BirimAdi from Birim where AktifMi = 'true'";
            SqlProvider provider = new SqlProvider(sorgu);
            SqlDataReader veriOkuyucu = provider.ExecuteReaderOlustur();
            if (veriOkuyucu.HasRows)
            {
                birimListe = new List<BirimDTO>();
                while (veriOkuyucu.Read())
                {
                    birimListe.Add(new BirimDTO()
                    {
                        BirimID = veriOkuyucu.GetInt32(0),
                        BirimAdi = veriOkuyucu.GetString(1)

                    });
                }
                return birimListe;
            }
            else
            {
                return null;
            }
        }
    }
}
