using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crudNet.Models
{
    public class Parish
    {
        [Key]
        public int CodPar { get; set; }
        public string Name { get; set; }

        [ForeignKey("Municipality")]
        public int CodMun { get; set; }
        public Municipality Municipality { get; set; }

        public ICollection<VotingCenter> VotingCenters { get; set; }
    }
}
