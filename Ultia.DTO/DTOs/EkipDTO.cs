namespace Ultia.DTO.DTOs
{
    public class EkipDTO : UstDTO
    {
        public int EkipID { get; set; }
        public string EkipAdi { get; set; }
        public SirketDTO Sirket { get; set; }
        public override string ToString()
        {
            return EkipAdi;
        }
    }

}
