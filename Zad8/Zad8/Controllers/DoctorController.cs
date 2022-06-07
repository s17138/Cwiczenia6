using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zad8.Models.dto;
using Zad8.Services;

namespace Zad8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDbService _dbService;

        public DoctorController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var doctors = await _dbService.GetAllDoctors();
            return Ok(doctors);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDoctor(int id)
        {
            var doctor = await _dbService.GetDoctor(id);
            return Ok(doctor);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var result = await _dbService.DeleteDoctor(id);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddDoctor(ResponseDoctor doctor)
        {
            var result = await _dbService.AddDoctor(doctor);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateDoctor(int id, ResponseDoctor doctor)
        {
            var result = await _dbService.UpdateDoctor(id, doctor);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
