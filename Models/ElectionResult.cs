using CsvHelper.Configuration.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crudNet.Models
{
    public class ElectionResult
    {
        public int Id { get; set; }

        [Name("COD_EDO")]
        public int StateCode { get; set; }

        [Name("EDO")]
        public string StateName { get; set; }

        [Name("COD_MUN")]
        public int MunicipalityCode { get; set; }

        [Name("MUN")]
        public string MunicipalityName { get; set; }

        [Name("COD_PAR")]
        public int ParishCode { get; set; }

        [Name("PAR")]
        public string ParishName { get; set; }

        [Name("CENTRO")]
        public string VotingCenter { get; set; }

        [Name("MESA")]
        public string VotingTable { get; set; }

        [Name("VOTOS_VALIDOS")]
        public int ValidVotes { get; set; }

        [Name("VOTOS_NULOS")]
        public int NullVotes { get; set; }

        [Name("URL")]
        public string ActaUrl { get; set; }

        [NotMapped]
        public Dictionary<string, int> CandidateVotes { get; set; }
    }
}
