using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ultia.DTO.DTOs
{
    public class SirketDTO:UstDTO
    {
        public int SirketID { get; set; }
        public string SirketAdi { get; set; }
        public bool? AktifMi { get; set; }

    }
}
