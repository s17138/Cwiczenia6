using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zad8.Models
{
    public class Medicament
    {
        [Key]
        public int IdMecicament { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        [MaxLength(100)]
        public string Type { get; set; }
        public virtual ICollection<Prescription_Medicament> Prescription_Medicaments { get; set; }
    }
}
