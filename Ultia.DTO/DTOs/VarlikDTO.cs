﻿using System;

namespace Ultia.DTO.DTOs
{
    public class VarlikDTO : UstDTO
    {
        public int VarlikID { get; set; }
        public Guid? Barkod { get; set; }
        public VarlikDurumuDTO VarlikDurumu { get; set; }
        public UrunTipiDTO UrunTipi { get; set; }
        public ModelDTO Model { get; set; }
        public bool? GarantiliMi { get; set; }
        public DateTime? OlusturulmaTarihi { get; set; }
        public DateTime? UrunEmeklilikTarihi { get; set; }
        public decimal UrunMaliyeti { get; set; }
        public decimal GuncelFiyat { get; set; }
        public ParaBirimiDTO UrunParaBirimi { get; set; }
        public string Aciklama { get; set; }
        public string DosyaYolu { get; set; }
        public BirimDTO Birim { get; set; } = null;
        public int? Miktar { get; set; }

    }
}
