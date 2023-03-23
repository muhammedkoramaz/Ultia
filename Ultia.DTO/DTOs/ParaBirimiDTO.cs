namespace Ultia.DTO.DTOs
{
    public class ParaBirimiDTO : UstDTO
    {
        public int ParaBirimiID { get; set; }
        public string ParaBirimi { get; set; }
        public override string ToString()
        {
            return ParaBirimi;
        }
    }
}