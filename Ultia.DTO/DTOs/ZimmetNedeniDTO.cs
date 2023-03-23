namespace Ultia.DTO.DTOs
{
    public class ZimmetNedeniDTO : UstDTO
    {
        public int ZimmetNedeniID { get; set; }
        public string ZimmetNedeni { get; set; }
        public override string ToString()
        {
            return ZimmetNedeni;
        }
    }
}
