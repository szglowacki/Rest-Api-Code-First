using APBD8.Models.DTOs.responses;
using APBD8.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD8.Controllers
{
    [Route("api/Prescription")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private IDatabaseService _dbService;
        public PrescriptionController(IDatabaseService databaseService)
        {
            _dbService = databaseService;
        }

        [HttpGet("{idPrescription}")]
        public IActionResult GetPrescriptionExtended(int idPrescription)
        {
            PrescriptionExtendedDto prescription = _dbService.GetPrescription(idPrescription);
            if (prescription == null) return NotFound($"Nie znaleziono recepty o id {idPrescription}");
            return Ok(prescription);
        }
    }
}
