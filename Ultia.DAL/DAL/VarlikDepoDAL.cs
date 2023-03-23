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
    public class VarlikDepoDAL : ITekVeriCek<VarlikDepoDTO>
    {
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
    }
}
