namespace Ultia.DTO.DTOs
{
    public class KullaniciDTO : UstDTO
    {
        public int KullaniciID { get; set; }
        public string KullaniciAdi { get; set; }
        public string AdSoyad { get; set; }
        public string Email { get; set; }
        public KullaniciDTO Yonetici { get; set; } = null;
        public RolDTO Rol { get; set; }
        public EkipDTO Ekip { get; set; }
        public override string ToString()
        {
            return AdSoyad;
        }
    }
}
