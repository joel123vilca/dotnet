using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace crudNet.Models
{
    public class VotingCenter
    {
        [Key]
        public string CentroCode { get; set; }
        public string Name { get; set; }

        [ForeignKey("Parish")]
        public int CodPar { get; set; }
        public Parish Parish { get; set; }

        public ICollection<VotingTable> VotingTables { get; set; }
    }
}
