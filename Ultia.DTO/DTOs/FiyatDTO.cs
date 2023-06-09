﻿using System;

namespace Ultia.DTO.DTOs
{
    public class FiyatDTO : UstDTO
    {
        public int FiyatID { get; set; }
        public VarlikDTO Varlik { get; set; }
        public decimal ParaMiktari { get; set; }
        public DateTime GuncellemeTarihi { get; set; }
        public ParaBirimiDTO ParaBirimi { get; set; }
    }
}
