namespace Ultia.DTO.DTOs
{
    public class BirimDTO : UstDTO
    {
        public int? BirimID { get; set; }
        public string BirimAdi { get; set; } = string.Empty;
        public override string ToString()
        {
            return BirimAdi;
        }
    }
}
