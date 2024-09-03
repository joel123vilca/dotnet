using ElectionResultsApp.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace crudNet.Models
{
    public class VotingTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Cambia esto a la propiedad que corresponde
        public string CentroCode { get; set; }

        [ForeignKey("VotingCenter")]
        public int VotingCenterId { get; set; }
        public VotingCenter VotingCenter { get; set; }

        public int Number { get; set; }
        public int VotosValidos { get; set; }
        public int VotosNulos { get; set; }
        public string URL { get; set; }

        public ICollection<CandidateVote> CandidateVotes { get; set; }
    }
}
