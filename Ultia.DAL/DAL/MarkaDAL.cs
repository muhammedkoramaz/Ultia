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

    public class MarkaDAL : IVeriCek<MarkaDTO>
    {
        List<MarkaDTO> markaListe;
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



    //public class MarkaDAL : IVeriCek<MarkaDTO>
    //{
    //    public List<MarkaDTO> markaListe = new List<MarkaDTO>();
    //    public List<MarkaDTO> VeriCek()
    //    {
    //        ModelDAL modelDAL = new ModelDAL();
    //        List<MarkaDTO> markaListe = modelDAL.VeriCek();

    //        foreach (MarkaDTO model in markaListe)
    //        {
    //            markaListe.Add(model.Marka);
    //        }
    //        return markaListe;
    //    }
    //}
}
