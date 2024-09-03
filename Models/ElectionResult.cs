using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crudNet.Models
{
    public class ElectionResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Name("COD_EDO")]
        public string CodEdo { get; set; }
   
        [Name("EDO")]
        public string Edo { get; set; }

        [Name("COD_MUN")]
        public string CodMun { get; set; }

        [Name("MUN")]
        public string Mun { get; set; }

        [Name("COD_PAR")]
        public string CodPar { get; set; }

        [Name("PAR")]
        public string Par { get; set; }

        [Name("CENTRO")]
        public string Centro { get; set; }

        [Name("MESA")]
        public int Mesa { get; set; }

        [Name("VOTOS_VALIDOS")]
        public int VotosValidos { get; set; }

        [Name("VOTOS_NULOS")]
        public int VotosNulos { get; set; }

        [Name("EG")]
        public int EG { get; set; }

        [Name("NM")]
        public int NM { get; set; }

        [Name("LM")]
        public int LM { get; set; }

        [Name("JABE")]
        public int JABE { get; set; }

        [Name("JOBR")]
        public int JOBR { get; set; }

        [Name("AE")]
        public int AE { get; set; }

        [Name("CF")]
        public int CF { get; set; }

        [Name("DC")]
        public int DC { get; set; }

        [Name("EM")]
        public int EM { get; set; }

        [Name("BERA")]
        public int BERA { get; set; }

        [Name("URL")]
        public string URL { get; set; }
    }
}
