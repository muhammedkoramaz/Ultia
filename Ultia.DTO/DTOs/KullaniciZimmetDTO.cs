namespace Ultia.DTO.DTOs
{
    public class KullaniciZimmetDTO : UstDTO
    {
        public int KullaniciZimmetID { get; set; }
        public KullaniciDTO Kullanici { get; set; }
        public ZimmetDTO Zimmet { get; set; }
    }
}
