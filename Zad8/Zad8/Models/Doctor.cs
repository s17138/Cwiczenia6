using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zad8.Models
{
    public class Doctor
    {
        [Key]
        public int IdDoctor { get; set; }
        [MaxLength(100)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(100)]
        [Required]
        public string LastName { get; set; }
        [MaxLength(100)]
        [Required]
        public string Email { get; set; }
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
