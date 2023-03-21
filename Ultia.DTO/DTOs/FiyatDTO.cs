using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ultia.DTO.DTOs
{
    public class FiyatDTO : UstDTO
    {
        public int FiyatID { get; set; }
        public VarlikDTO Varlik { get; set; }
        public decimal ParaMiktari { get; set; }
        public DateTime GuncellemeTarihi { get; set; }
        public ParaBirimiDTO ParaBirimi { get; set; }
        public bool? AktifMi { get; set; }

    }
}
