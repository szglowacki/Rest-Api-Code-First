using APBD8.Models;
using APBD8.Models.DTOs.responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD8.Services
{
    public interface IDatabaseService
    {
        public IEnumerable<RawDoctorDTO> GetDoctors();
        public Task<int> AddDoctor(Doctor doctor);
        public Task<int> UpdateDoctor(int idDoctor, Doctor newDoctor);
        public Task<int> DeleteDoctor(int idDoctor);
        public PrescriptionExtendedDto GetPrescription(int idPrescription);
    }
}
