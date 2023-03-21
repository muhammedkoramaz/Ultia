using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ultia.DTO.DTOs
{
    public class MusteriDTO: UstDTO
    {
        public int MusteriID { get; set; }
        public string MusteriAdSoyad { get; set; }
        public string MusteriTel { get; set; }
        public bool? AktifMi { get; set; }

    }
}
