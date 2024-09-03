using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace crudNet.Models
{
    public class VotingCenter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string CentroCode { get; set; }
        public string Name { get; set; }

        // Clave foránea a Parish
        [ForeignKey("Parish")]
        public int ParishId { get; set; } // Cambiado a 'ParishId' en lugar de 'CodPar'
        public Parish Parish { get; set; }

        public ICollection<VotingTable> VotingTables { get; set; }
    }
}
