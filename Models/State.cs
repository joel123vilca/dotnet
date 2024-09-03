using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crudNet.Models
{
    public class State
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Ajusta CodEdo a string para que coincida con el tipo en Municipality
        public string CodEdo { get; set; }

        public string Name { get; set; }

        public ICollection<Municipality> Municipalities { get; set; }
    }
}
