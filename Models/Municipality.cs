using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crudNet.Models
{
    public class Municipality
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CodMun { get; set; }
        public string Name { get; set; }

        // Clave foránea a State
        [ForeignKey("State")]
        public int CodEdo { get; set; }
        public State State { get; set; }

        public ICollection<Parish> Parishes { get; set; }
    }
}
