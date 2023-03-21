using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ultia.DTO.DTOs
{
    public class RolDTO:UstDTO
    {
        public int RolID { get; set; }
        public string RolAdi { get; set; }
        public bool? AktifMi { get; set; }

    }
}
