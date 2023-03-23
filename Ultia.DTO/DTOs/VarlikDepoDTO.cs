namespace Ultia.DTO.DTOs
{
    public class VarlikDepoDTO : UstDTO
    {
        public int VarlikDepoID { get; set; }
        public VarlikDTO Varlik { get; set; }
        public DepoDTO Depo { get; set; }
        public string Aciklama { get; set; }
    }
}
