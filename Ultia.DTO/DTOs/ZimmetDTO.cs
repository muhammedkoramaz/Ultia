﻿using System;

namespace Ultia.DTO.DTOs
{
    public class ZimmetDTO : UstDTO
    {
        public int ZimmetID { get; set; }
        public VarlikDTO Varlik { get; set; }
        public VarlikDepoDTO VarlikDepo { get; set; }
        public ZimmetNedeniDTO ZimmetNedeni { get; set; }
        public ZimmetTuruDTO ZimmetTuru { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public string Aciklama { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime DuzenlemeTarihi { get; set; }
        public int? OlusturanKisiID { get; set; }

    }
}
