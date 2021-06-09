using APBD8.Models;
using APBD8.Models.DTOs.responses;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD8.Services
{
    public class SQLDatabaseService : IDatabaseService
    {
        //private MainDbContext _context = new MainDbContext();
        private MainDbContext _context = new MainDbContext();
    
        




        public IEnumerable<RawDoctorDTO> GetDoctors()
        {
            return _context.Doctor.Select(d => new RawDoctorDTO
            {
                IdDoctor = d.IdDoctor,
                FirstName = d.FirstName,
                LastName = d.LastName,
                Email = d.Email

            });

        }

        public async Task<int> AddDoctor(Doctor doctor)
        {
            await _context.AddAsync(doctor);
            return (await _context.SaveChangesAsync());

        }

        public async Task<int> UpdateDoctor(int idDoctor, Doctor newDoctor)
        {
            Doctor oldDoctor = _context.Doctor.Where(d => d.IdDoctor == idDoctor).SingleOrDefault();
            if (oldDoctor == null) return -1;

            oldDoctor.FirstName = newDoctor.FirstName;
            oldDoctor.LastName = newDoctor.LastName;
            oldDoctor.Prescriptions = newDoctor.Prescriptions;

            return (await _context.SaveChangesAsync());

        }

        public async Task<int> DeleteDoctor(int idDoctor)
        {
            Doctor doctorToDelete = _context.Doctor.Where(d => d.IdDoctor == idDoctor).SingleOrDefault();
            if (doctorToDelete == null) return (-1);

            _context.Remove(doctorToDelete);

            return (await _context.SaveChangesAsync());
        }

        public PrescriptionExtendedDto GetPrescription(int idPrescription)
        {
            Prescription prescription = _context.Prescription.Where(p => p.IdPrescription == idPrescription).SingleOrDefault();
            if (prescription == null) return null;
            Doctor doctor = _context.Doctor.Where(d => d.IdDoctor == prescription.IdDoctor).SingleOrDefault();
            RawDoctorDTO rawDoctor = new RawDoctorDTO { IdDoctor = doctor.IdDoctor, Email = doctor.Email, FirstName = doctor.FirstName, LastName = doctor.LastName };
            Patient patient = _context.Patient.Where(p => p.IdPatient == prescription.IdPatient).SingleOrDefault();
            RawPatientDto rawPatient = new RawPatientDto { IdPatient = patient.IdPatient, Birthdate = patient.Birthdate, FirstName = patient.FirstName, LastName = patient.LastName };
            var prescription_Medicaments = _context.Prescription_Medicament.Where(pm => pm.IdPrescription == idPrescription).ToList();
           
            ICollection<PrescriptionMedicamentDto> medicaments = new List<PrescriptionMedicamentDto>();
            foreach (Prescription_Medicament pm in prescription_Medicaments)
            {

                Medicament m = _context.Medicament.Where(m => m.IdMedicament == pm.IdMedicament).FirstOrDefault() ;
               
                MedicamentDto medicamentDto = new MedicamentDto { IdMedicament = m.IdMedicament, Description = m.Description, Name = m.Name, Type = m.Type };
                medicaments.Add(new PrescriptionMedicamentDto { Medicament = medicamentDto, Details = pm.Details, Dose = pm.Dose });
            }

            return new PrescriptionExtendedDto { Date = prescription.Date, Doctor = rawDoctor, DueDate = prescription.DueDate, IdPrescription = idPrescription, Patient = rawPatient, PrescrictedMedicaments = medicaments };
        }

    }     
}
