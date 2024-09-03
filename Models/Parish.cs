using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crudNet.Models
{
    public class Parish
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CodPar { get; set; }
        public string Name { get; set; }

        // Clave foránea a Municipality
        [ForeignKey("Municipality")]
        public int MunicipalityId { get; set; }
        public Municipality Municipality { get; set; }

        public ICollection<VotingCenter> VotingCenters { get; set; }
    }
}
