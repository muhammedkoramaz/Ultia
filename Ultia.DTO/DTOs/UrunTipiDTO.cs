using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ultia.DTO.DTOs
{
    public class UrunTipiDTO : UstDTO
    {
        public int UrunTipiID { get; set; }
        public string UrunTipiAdi { get; set; }
        public override string ToString()
        {
            return UrunTipiAdi;
        }
    }
}
