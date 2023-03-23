namespace Ultia.DTO.DTOs
{
    public class UrunTipiDTO : UstDTO
    {
        public int UrunTipiID { get; set; }
        public string UrunTipiAdi { get; set; }
        public override string ToString()
        {
            return UrunTipiAdi;
        }
    }
}
