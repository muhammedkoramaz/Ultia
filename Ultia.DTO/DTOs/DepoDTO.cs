using Ultia.DTO.DTOs;

namespace Ultia.DTO
{
    public class DepoDTO : UstDTO
    {
        public int DepoID { get; set; }
        public string DepoAdi { get; set; }
        public SirketDTO Sirket { get; set; }
        public override string ToString()
        {
            return DepoAdi;
        }
    }
}
