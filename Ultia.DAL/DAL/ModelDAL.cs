﻿using AdoSample.Provider;
using System.Collections.Generic;
using System.Data.SqlClient;
using Ultia.DAL.IRepositories;
using Ultia.DTO.DTOs;

namespace Ultia.DAL.DAL
{
    public class ModelDAL : IVeriCekID<ModelDTO>
    {
        List<ModelDTO> modelListe;
        /// <summary>
        /// Veritabanından Model tablosunu çeken fonksiyon.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ModelDTO> VeriCek(int id)
        {
            string sorgu = $"select model.ModelID,model.ModelAd,marka.MarkaID, marka.MarkaAdi from Model model join Marka marka on marka.MarkaID=model.MarkaID where model.AktifMi='true' and marka.AktifMi = 'true' and model.MarkaID = {id}";
            SqlProvider provider = new SqlProvider(sorgu);
            SqlDataReader veriOkuyucu = provider.ExecuteReaderOlustur();
            if (veriOkuyucu.HasRows)
            {
                modelListe = new List<ModelDTO>();
                while (veriOkuyucu.Read())
                {
                    modelListe.Add(new ModelDTO()
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
                return modelListe;
            }
            else
            {
                return null;
            }
        }
    }
}
