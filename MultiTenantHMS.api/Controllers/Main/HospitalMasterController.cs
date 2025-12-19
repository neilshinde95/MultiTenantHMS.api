using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenantHMS.BLL.BL.Main;
using MultiTenantHMS.BLL.Interfaces;
using MultiTenantHMS.DAL.Models.Main;

namespace MultiTenantHMS.api.Controllers.Main
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalMasterController : ControllerBase
    {
        private readonly ICommonService _service;

        public HospitalMasterController(ICommonService commonService)
        {
            _service = commonService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetHospitalList()
        {
           var response = await hospital_bl.GetAllHospital(_service);
           return Ok(response);
        }

        [HttpGet("getById{hospitalId}")]
        public async Task<IActionResult> GetHospitalById(int hospitalId)
        {
            if (hospitalId == 0)
                return NotFound();
            var repsonse = await hospital_bl.GetHosspitalById(_service, hospitalId);
            return Ok(repsonse);
        }

        [HttpPost("addHospital")]
        public async Task<IActionResult> AddHospital(HospitalModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await hospital_bl.AddHospital(_service, model);  
            return Ok(response);
        }

        [HttpPut("updateHospital/{hospitalId}")]
        public async Task<IActionResult> UpdateHospital(HospitalModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await hospital_bl.UpdateHospital(_service, model);
            return Ok(response);
        }

        [HttpDelete("delete{hospitalId}")]
        public async Task<IActionResult> Delete(int hospitalId)
        {
            if (hospitalId == 0)
                return NotFound(hospitalId);

            var response = await hospital_bl.DeleteHospital(_service, hospitalId);  
            return Ok(response);
        }

    }
}
