using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zad8.Models.dto
{
    public class ResponsePrescription
    {
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public ResponsePatient Patient { get; set; }
        public ResponseDoctor Doctor { get; set; }
        public IEnumerable<ResponseMedicament> Medicaments { get; set; }
    }
}
