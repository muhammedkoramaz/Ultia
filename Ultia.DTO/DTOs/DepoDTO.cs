using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultia.DTO.DTOs;

namespace Ultia.DTO
{
    public class DepoDTO:UstDTO
    {
        public int DepoID { get; set; }
        public string DepoAdi { get; set; }
        public SirketDTO Sirket { get; set; }
    }
}
