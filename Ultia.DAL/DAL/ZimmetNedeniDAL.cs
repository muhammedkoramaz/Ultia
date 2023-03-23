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
    public class ZimmetNedeniDAL : IVeriCek<ZimmetNedeniDTO>
    {
        List<ZimmetNedeniDTO> zimmetNedeniList; 
        public List<ZimmetNedeniDTO> VeriCek()
        {
            string sorgu = $"select ZimmetNedeniID,ZimmetNedeni from ZimmetNedeni where AktifMi = 'true'";
            SqlProvider provider = new SqlProvider(sorgu);
            SqlDataReader veriOkuyucu = provider.ExecuteReaderOlustur();
            if (veriOkuyucu.HasRows)
            {
                zimmetNedeniList = new List<ZimmetNedeniDTO>();
                while (veriOkuyucu.Read())
                {
                    zimmetNedeniList.Add(new ZimmetNedeniDTO()
                    {
                        ZimmetNedeniID = veriOkuyucu.GetInt32(0),
                        ZimmetNedeni = veriOkuyucu.GetString(1)
                    });
                }
                return zimmetNedeniList;
            }
            else
            {
                return null;
            }
        }
    }
}
