﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ultia.DTO.DTOs
{
    public class ParaBirimiDTO : UstDTO
    {
        public int ParaBirimiID { get; set; }
        public string ParaBirimi { get; set; }
        public bool? AktifMi { get; set; }
    }
}
