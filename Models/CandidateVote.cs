using crudNet.Models;

namespace ElectionResultsApp.Models
{
    public class CandidateVote
    {
        public int Id { get; set; }
        public string CandidateName { get; set; }
        public int Votes { get; set; }
        public int ElectionResultId { get; set; }
        public ElectionResult ElectionResult { get; set; }
    }
}
