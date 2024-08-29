namespace crudNet.Models
{
    public class Location
    {
        public int Id { get; set; }
        public int StateCode { get; set; }
        public string StateName { get; set; }
        public int MunicipalityCode { get; set; }
        public string MunicipalityName { get; set; }

        public int ParishCode { get; set; }
        public string ParishName { get; set; }
    }
}
