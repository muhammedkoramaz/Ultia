using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ultia.DTO.DTOs
{
    public class ModelDTO:UstDTO
    {
        public int ModelID { get; set; }
        public MarkaDTO Marka { get; set; }
        public string ModelAdi { get; set; }
        public bool? AktifMi { get; set; }

        public override string ToString()
        {
            return ModelAdi;
        }
    }
}
