using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ultia.DTO.DTOs
{
    public class MarkaDTO:UstDTO
    {
        public int MarkaID { get; set; }
        public string MarkaAdi { get; set; }
        public bool? AktifMi { get; set; }

        public override string ToString()
        {
            return MarkaAdi;
        }
    }
}
