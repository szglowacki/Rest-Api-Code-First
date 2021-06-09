using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD8.Models.DTOs.responses
{
    public class PrescriptionExtendedDto
    {
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public RawDoctorDTO Doctor { get; set; }
        public RawPatientDto Patient { get; set; }
        public ICollection<PrescriptionMedicamentDto> PrescrictedMedicaments { get; set; }
        
    }
}
