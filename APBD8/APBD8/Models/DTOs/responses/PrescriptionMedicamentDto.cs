using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD8.Models.DTOs.responses
{
    public class PrescriptionMedicamentDto
    {
        public virtual MedicamentDto Medicament { get; set; }

        public int? Dose { get; set; }

        public string Details { get; set; }
    }
}
