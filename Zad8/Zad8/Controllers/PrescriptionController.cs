using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zad8.Services;

namespace Zad8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IDbService _dbService;

        public PrescriptionController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPrescription(int id)
        {
            var prescription = await _dbService.GetPrescription(id);
            return Ok(prescription);
        }
    }
}
