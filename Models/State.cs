using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace crudNet.Models
{
    public class State
    {
        [Key]
        public int CodEdo { get; set; }
        public string Name { get; set; }

        public ICollection<Municipality> Municipalities { get; set; }
    }
}
