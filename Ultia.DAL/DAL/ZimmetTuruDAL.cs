﻿using AdoSample.Provider;
using System.Collections.Generic;
using System.Data.SqlClient;
using Ultia.DAL.IRepositories;
using Ultia.DTO.DTOs;

namespace Ultia.DAL.DAL
{
    public class ZimmetTuruDAL : IVeriCek<ZimmetTuruDTO>
    {
        List<ZimmetTuruDTO> zimmetTuruListe;
        /// <summary>
        /// Veritabanından ZimmetTürü tablosunu çeken fonksiyon.
        /// </summary>
        /// <returns></returns>
        public List<ZimmetTuruDTO> VeriCek()
        {
            string sorgu = "select ZimmetTuruID,ZimmetTuru from ZimmetTuru where AktifMi = 'true'";
            SqlProvider provider = new SqlProvider(sorgu);
            SqlDataReader veriOkuyucu = provider.ExecuteReaderOlustur();
            if (veriOkuyucu.HasRows)
            {
                zimmetTuruListe = new List<ZimmetTuruDTO>();
                while (veriOkuyucu.Read())
                {
                    zimmetTuruListe.Add(new ZimmetTuruDTO()
                    {
                        ZimmetTuruID = veriOkuyucu.GetInt32(0),
                        ZimmetTuru = veriOkuyucu.GetString(1)
                    });
                }
                return zimmetTuruListe;
            }
            else
            {
                return null;
            }
        }
    }
}
