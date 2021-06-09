using APBD8.Models;
using APBD8.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD8.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private IDatabaseService _dbService;
        public DoctorController(IDatabaseService databaseService)
        {
            _dbService = databaseService;
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(_dbService.GetDoctors());
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctorAsync(Doctor doctor)
        {
            int status = await _dbService.AddDoctor(doctor);
            if (status == 0) return BadRequest("Nie można dodać doktora");
            else return Ok($"Dodano doktora {doctor.FirstName} {doctor.LastName}");
        }

        [HttpDelete("{idDoctor}")]
        public async Task<IActionResult> DeleteDoctorAsync(int idDoctor)
        {
            int status = await _dbService.DeleteDoctor(idDoctor);
            if (status == -1) return NotFound($"Nie znaleziono doktora z id {idDoctor}");
            if (status == 0) return BadRequest($"Nie można usunąć doktora z id {idDoctor}");
            return Ok("Pomyślnie usunięto doktora");
        }

        [HttpPut("{idDoctor}")]
        public async Task<IActionResult> UpdateDoctorAsync(int idDoctor, Doctor newDoctor)
        {
            int status = await _dbService.UpdateDoctor(idDoctor, newDoctor);
            if (status == -1) return NotFound($"Nie znaleziono doktora z id {idDoctor}");
            if(status == 0) return BadRequest($"Nie można zaktualizować doktora z id {idDoctor}");
            return Ok($"Zaktualizowano doktora");
        }

    }
}
