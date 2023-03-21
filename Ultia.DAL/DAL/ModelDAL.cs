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
    public class ModelDAL : IVeriCek<ModelDTO>
    {
        List<ModelDTO> modelList;
        public List<ModelDTO> VeriCek()
        {
            string sorgu = $"select model.ModelID,model.ModelAd,marka.MarkaID, marka.MarkaAdi from Model model join Marka marka on marka.MarkaID=model.MarkaID where model.AktifMi='true' and marka.AktifMi = 'true'";
            SqlProvider provider = new SqlProvider(sorgu);
            SqlDataReader veriOkuyucu = provider.ExecuteReaderOlustur();
            if (veriOkuyucu.HasRows)
            {
                modelList = new List<ModelDTO>();
                while (veriOkuyucu.Read())
                {
                    modelList.Add(new ModelDTO()
                    {
                        ModelID = veriOkuyucu.GetInt32(0),
                        ModelAdi = veriOkuyucu.GetString(1),
                        Marka = new MarkaDTO()
                        {
                            MarkaID = veriOkuyucu.GetInt32(2),
                            MarkaAdi = veriOkuyucu.GetString(3),
                        }
                    });
                }
                return modelList;
            }
            else
            {
                return null;
            }
        }
    }
}
