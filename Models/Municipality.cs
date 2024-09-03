using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crudNet.Models
{
    public class Municipality
    {
        [Key]
        public int CodMun { get; set; }
        public string Name { get; set; }

        [ForeignKey("State")]
        public int CodEdo { get; set; }
        public State State { get; set; }

        public ICollection<Parish> Parishes { get; set; }
    }
}
