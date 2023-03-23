namespace Ultia.DTO.DTOs
{
    public class EkipZimmetDTO:UstDTO
    {
        public int EkipZimmetID { get; set; }
        public EkipDTO Ekip { get; set; }
        public ZimmetDTO Zimmet { get; set; }
    }

}
