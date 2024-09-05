namespace crudNet.DTOs
{
    public class StateDTO
    {
        public string CodEdo { get; set; }
        public string Name { get; set; }
        public List<MunicipalityDTO> Municipalities { get; set; }
    }
}
