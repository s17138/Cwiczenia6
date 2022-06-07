using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zad8.Models.dto
{
    public class ResponseMedicament
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Dose { get; set; }
        public string Type { get; set; }
        public string Details { get; set; }
    }
}
