﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ultia.DTO.DTOs
{
    public class BirimDTO: UstDTO
    {
        public int BirimID { get; set; }
        public string BirimAdi { get; set; }
        public bool? AktifMi { get; set; }
    }
}