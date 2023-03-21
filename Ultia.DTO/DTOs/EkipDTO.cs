using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ultia.DTO.DTOs
{
    public class EkipDTO:UstDTO
    {
        public int EkipID { get; set; }
        public string EkipAdi { get; set; }
        public SirketDTO Sirket { get; set; }
    }

}
