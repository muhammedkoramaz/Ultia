using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ultia.DTO.DTOs
{
    public class EkipZimmetDTO:UstDTO
    {
        public int EkipZimmetID { get; set; }
        public EkipDTO Ekip { get; set; }
        public ZimmetDTO Zimmet { get; set; }
        public bool? AktifMi { get; set; }

    }

}
