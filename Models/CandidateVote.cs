using crudNet.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ElectionResultsApp.Models
{
    public class CandidateVote
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("VotingTable")]
        public int VotingTableId { get; set; }
        public VotingTable VotingTable { get; set; }

        public string CandidateCode { get; set; }
        public int Votes { get; set; }
    }
}
