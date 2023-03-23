namespace Ultia.DTO.DTOs
{
    public class MarkaDTO : UstDTO
    {
        public int MarkaID { get; set; }
        public string MarkaAdi { get; set; }
        public override string ToString()
        {
            return MarkaAdi;
        }
    }
}
