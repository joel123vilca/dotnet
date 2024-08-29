namespace crudNet.ViewModels
{
    public class ElectionResultViewModel
    {
        public string State { get; set; }
        public string Municipality { get; set; }
        public string Parish { get; set; }
        public string VotingCenter { get; set; }
        public int TableNumber { get; set; }
        public int ValidVotes { get; set; }
        public int NullVotes { get; set; }
        public string URL { get; set; }
    }
}