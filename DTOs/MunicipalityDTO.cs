namespace crudNet.DTOs
{
    public class MunicipalityDTO
    {
        public string CodMun { get; set; }
        public string Name { get; set; }
        public List<ParishDTO> Parishes { get; set; }
    }
}
