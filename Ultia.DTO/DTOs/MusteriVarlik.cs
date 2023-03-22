using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ultia.DTO.DTOs
{
    public class MusteriVarlikDTO : UstDTO
    {
        public int MusteriVarlikID { get; set; }
        public MusteriDTO Musteri { get; set; }
        public VarlikDTO Varlik { get; set; }
        public string Aciklama { get; set; }
    }
}
