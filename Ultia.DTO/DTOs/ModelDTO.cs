namespace Ultia.DTO.DTOs
{
    public class ModelDTO : UstDTO
    {
        public int ModelID { get; set; }
        public MarkaDTO Marka { get; set; }
        public string ModelAdi { get; set; }

        public override string ToString()
        {
            return ModelAdi;
        }
    }
}
