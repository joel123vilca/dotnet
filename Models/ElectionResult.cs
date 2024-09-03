using System.ComponentModel.DataAnnotations;

namespace crudNet.Models
{
    public class ElectionResult
    {
        [Key]
        public int Id { get; set; }

        public int CodEdo { get; set; }
        public string Edo { get; set; }
        public int CodMun { get; set; }
        public string Mun { get; set; }
        public int CodPar { get; set; }
        public string Par { get; set; }
        public string Centro { get; set; }
        public int Mesa { get; set; }
        public int VotosValidos { get; set; }
        public int VotosNulos { get; set; }
        public int EG { get; set; }
        public int NM { get; set; }
        public int LM { get; set; }
        public int JABE { get; set; }
        public int JOBR { get; set; }
        public int AE { get; set; }
        public int CF { get; set; }
        public int DC { get; set; }
        public int EM { get; set; }
        public int BERA { get; set; }
        public string URL { get; set; }
    }
}
