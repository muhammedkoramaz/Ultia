using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ultia.DTO.DTOs
{
    public class ZimmetTuruDTO : UstDTO
    {
        public int ZimmetTuruID { get; set; }
        public string ZimmetTuru { get; set; }
        public override string ToString()
        {
            return ZimmetTuru;
        }
    }
}
