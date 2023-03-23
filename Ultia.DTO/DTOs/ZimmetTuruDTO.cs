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
