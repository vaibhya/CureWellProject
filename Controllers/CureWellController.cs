using CureWell.Models;
using CureWell.Service;
using Microsoft.AspNetCore.Mvc;

namespace CureWell.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CureWellController : Controller
    {
        private readonly ICureWellService _cureWellService;
        public CureWellController(ICureWellService cureWellService)
        {
            _cureWellService = cureWellService;
        }

        [HttpGet("Doctor")]
        public async Task<IActionResult> GetDoctors()
        {
            var doctorsList = await _cureWellService.GetAllDoctors();
            if(doctorsList ==null)
            {
                return NotFound("No Doctors found.");
            }
            return Ok(doctorsList);
        }
        
        [HttpPost("Doctor")]
        public async Task<IActionResult> AddDoctor(Doctor doctor)
        {
            return Created("",await _cureWellService.AddDoctor(doctor));
        }

        [HttpPut("Doctor")]
        public async Task<IActionResult> UpdateDoctor(Doctor doctor)
        {
            return Ok(await _cureWellService.UpdateDoctorDetails(doctor));
        }
        
        [HttpDelete("Doctor")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            return Ok(await _cureWellService.DeleteDoctor(id));
        }

        [HttpPost("Surgery")]
        public async Task<IActionResult> AddSurgery(Surgery surgery)
        {
            return Created("",await _cureWellService.AddSurgery(surgery));
        }

        [HttpGet("Surgery/Today")]
        public async Task<IActionResult> GetAllSurgeryTypeForToday()
        {
            var surgeryList = await _cureWellService.GetAllSurgeryTypeForToday();
            if(surgeryList ==null)
            {
                return NotFound("No Surgery is scheduled for today!");
            }
            return Ok(surgeryList);
        }

        [HttpPut("Surgery")]
        public async Task<IActionResult> UpdateSurgery(Surgery surgery)
        {
            return Ok(await _cureWellService.UpdateSurgery(surgery));
        }

        [HttpPost("Specialization")]
        public async Task<IActionResult> AddSpecialization(Specialization specialization)
        {
            return Created("",await _cureWellService.AddSpecialization(specialization));
        }

        [HttpGet("Specialization")]
        public async Task<IActionResult> GetSpecializations()
        {
            var specializationList = await _cureWellService.GetAllSpecialization();
            if(specializationList ==null)
            {
                return NotFound("No Specialization found.");
            }
            return Ok(specializationList);
        }
    }
}